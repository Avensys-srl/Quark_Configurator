Imports System.Linq

Public Class LiveData

    '-------------------- LIVE VALUES --------------------
    Public Property TemperatureFresh As Double
    Public Property TemperatureReturn As Double
    Public Property TemperatureSupply As Double
    Public Property TemperatureExhaust As Double
    Public Property HumidityLeft As Integer
    Public Property HumidityRight As Integer
    Public Property TemperatureHeater As Double
    Public Property FeedbackVMotorR As Double
    Public Property RPMMotorR As Integer
    Public Property FeedbackVMotorF As Double
    Public Property RPMMotorF As Integer
    Public Property Alarms As Byte() = New Byte(12) {}              ' 13 byte (0..12)
    Public Property Belimo1_Inputs As Boolean() = New Boolean(3) {}  ' 4 bool (0..3)
    Public Property Belimo2_Inputs As Boolean() = New Boolean(3) {}
    Public Property BelimoCurrent As Double

    '-------------------- STATUS_UNIT (bitfield) --------------------
    ' Bit positions come da firmware
    Private Const POS_BIT_UNIT_RUN As Integer = 0
    Private Const POS_BIT_DEFROST_OPERATING As Integer = 1
    Private Const POS_BIT_POST_VENT_OPERATING As Integer = 2
    Private Const POS_BIT_IMBALANCE_OPERATING As Integer = 3
    Private Const POS_BIT_BOOST_OPERATING As Integer = 4
    Private Const POS_BIT_BOOST_KHK As Integer = 5
    Private Const POS_BIT_BYPASS_RUN As Integer = 6
    Private Const POS_BIT_BYPASS_CLOSE As Integer = 7
    Private Const POS_BIT_CMD_FAN_INPUT As Integer = 8
    Private Const POS_BIT_MAX_RH As Integer = 9
    Private Const POS_BIT_MAX_CO2 As Integer = 10
    Private Const POS_BIT_MAX_VOC As Integer = 11
    Private Const POS_BIT_IN_TESTING As Integer = 12
    Private Const POS_BIT_DPP_CHECK As Integer = 13
    Private Const POS_BIT_QRK_UPDATE As Integer = 14
    Private Const POS_BIT_BOOST_INPUT2 As Integer = 15

    Private _statusUnit As UShort
    ''' <summary>Valore decimale del bitfield a 16 bit ricevuto dal firmware.</summary>
    Public Property StatusUnit As UShort
        Get
            Return _statusUnit
        End Get
        Set(value As UShort)
            _statusUnit = value
        End Set
    End Property

    ' Helper robusto per testare un bit (0..15)
    Private Shared Function HasBit(v As UShort, pos As Integer) As Boolean
        Dim mask As UInteger = 1UI << pos       ' usa UInteger per evitare overflow del segno
        Return (CUInt(v) And mask) <> 0UI
    End Function

    '-------------------- Flag esposte (read-only, calcolate) --------------------
    Public ReadOnly Property UnitRun As Boolean
        Get
            Return HasBit(_statusUnit, POS_BIT_UNIT_RUN)
        End Get
    End Property

    Public ReadOnly Property DefrostOperating As Boolean
        Get
            Return HasBit(_statusUnit, POS_BIT_DEFROST_OPERATING)
        End Get
    End Property

    Public ReadOnly Property PostVentOperating As Boolean
        Get
            Return HasBit(_statusUnit, POS_BIT_POST_VENT_OPERATING)
        End Get
    End Property

    Public ReadOnly Property ImbalanceOperating As Boolean
        Get
            Return HasBit(_statusUnit, POS_BIT_IMBALANCE_OPERATING)
        End Get
    End Property

    Public ReadOnly Property BoostOperating As Boolean
        Get
            Return HasBit(_statusUnit, POS_BIT_BOOST_OPERATING)
        End Get
    End Property

    Public ReadOnly Property BoostKHK As Boolean
        Get
            Return HasBit(_statusUnit, POS_BIT_BOOST_KHK)
        End Get
    End Property

    Public ReadOnly Property BypassRun As Boolean
        Get
            Return HasBit(_statusUnit, POS_BIT_BYPASS_RUN)
        End Get
    End Property

    Public ReadOnly Property BypassClosed As Boolean
        Get
            Return HasBit(_statusUnit, POS_BIT_BYPASS_CLOSE)
        End Get
    End Property

    Public ReadOnly Property CmdFanInput As Boolean
        Get
            Return HasBit(_statusUnit, POS_BIT_CMD_FAN_INPUT)
        End Get
    End Property

    Public ReadOnly Property MaxRH As Boolean
        Get
            Return HasBit(_statusUnit, POS_BIT_MAX_RH)
        End Get
    End Property

    Public ReadOnly Property MaxCO2 As Boolean
        Get
            Return HasBit(_statusUnit, POS_BIT_MAX_CO2)
        End Get
    End Property

    Public ReadOnly Property MaxVOC As Boolean
        Get
            Return HasBit(_statusUnit, POS_BIT_MAX_VOC)
        End Get
    End Property

    Public ReadOnly Property InTesting As Boolean
        Get
            Return HasBit(_statusUnit, POS_BIT_IN_TESTING)
        End Get
    End Property

    Public ReadOnly Property DppCheck As Boolean
        Get
            Return HasBit(_statusUnit, POS_BIT_DPP_CHECK)
        End Get
    End Property

    Public ReadOnly Property QrkUpdate As Boolean
        Get
            Return HasBit(_statusUnit, POS_BIT_QRK_UPDATE)
        End Get
    End Property

    Public ReadOnly Property BoostInput2 As Boolean
        Get
            Return HasBit(_statusUnit, POS_BIT_BOOST_INPUT2)
        End Get
    End Property

    ' Comodità derivate
    Public ReadOnly Property OverrunActive As Boolean
        Get
            Return MaxRH OrElse MaxCO2 OrElse MaxVOC
        End Get
    End Property

    '-------------------- Validazione --------------------
    Public ReadOnly Property IsValid As Boolean
        Get
            Return TemperatureFresh > -80 AndAlso
                   TemperatureReturn > -80 AndAlso
                   TemperatureSupply > -80 AndAlso
                   TemperatureExhaust > -80 AndAlso
                   TemperatureHeater > -80 AndAlso
                   FeedbackVMotorF >= 0 AndAlso
                   FeedbackVMotorR >= 0 AndAlso
                   RPMMotorF >= 0 AndAlso
                   RPMMotorR >= 0 AndAlso
                   HumidityLeft >= 0 AndAlso
                   HumidityRight >= 0
        End Get
    End Property

    '-------------------- Utility --------------------
    Public Overrides Function ToString() As String
        Dim suHex As String = $"0x{_statusUnit:X4}"
        Return $"StatusUnit={_statusUnit} ({suHex}) [Run={UnitRun}, Defrost={DefrostOperating}, PostVent={PostVentOperating}, " &
               $"Imbalance={ImbalanceOperating}, Boost={BoostOperating}, BoostKHK={BoostKHK}, " &
               $"BypRun={BypassRun}, BypClosed={BypassClosed}, CmdIn={CmdFanInput}, " &
               $"RH={MaxRH}, CO2={MaxCO2}, VOC={MaxVOC}, Test={InTesting}, DPP={DppCheck}, QRK={QrkUpdate}, In2={BoostInput2}], " &
               $"BelimoCurrent: {BelimoCurrent} mA, " &
               $"B1_Inputs: [{String.Join(",", Belimo1_Inputs.Select(Function(b) If(b, "1", "0")))}], " &
               $"B2_Inputs: [{String.Join(",", Belimo2_Inputs.Select(Function(b) If(b, "1", "0")))}]"
    End Function

    ''' <summary>
    ''' Restituisce i codici allarme nel formato "ii-b" (ii=indice byte 00..12, b=bit 1..8).
    ''' </summary>
    Public Function GetAlarmCodes() As String
        Dim codes As New List(Of String)
        For i As Integer = 0 To Alarms.Length - 1
            Dim b As Byte = Alarms(i)
            For bit As Integer = 0 To 7
                If (b And (1 << bit)) <> 0 Then
                    codes.Add($"{i:D2}-{bit + 1}")
                End If
            Next
        Next
        Return If(codes.Count = 0, String.Empty, String.Join(", ", codes))
    End Function

End Class

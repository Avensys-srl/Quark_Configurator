Public Class LiveData

    Public Property TemperatureFresh As Double
    Public Property TemperatureReturn As Double
    Public Property TemperatureSupply As Double
    Public Property TemperatureExhaust As Double
    Public Property HumidityLeft As Integer
    Public Property HumidityRight As Integer
    Public Property FeedbackVMotorR As Double
    Public Property RPMMotorR As Integer
    Public Property FeedbackVMotorF As Double
    Public Property RPMMotorF As Integer
    Public Property Alarms As Byte() = New Byte(12) {}

    Public Overrides Function ToString() As String
        Return $"TFresh: {TemperatureFresh}°C, TReturn: {TemperatureReturn}°C, " &
               $"TSupply: {TemperatureSupply}°C, TExhaust: {TemperatureExhaust}°C, " &
               $"HumL: {HumidityLeft}%, HumR: {HumidityRight}%, " &
               $"VfbR: {FeedbackVMotorR}V, RPMR: {RPMMotorR}, " &
               $"VfbF: {FeedbackVMotorF}V, RPMF: {RPMMotorF}, " &
               $"Alarms: [{String.Join(", ", Alarms)}]"
    End Function

    Public Function GetAlarmCodes() As String
        Dim codes As New List(Of String)

        ' Scorri ciascun byte (0-based)
        For i As Integer = 0 To Alarms.Length - 1
            Dim b As Byte = Alarms(i)
            ' Per ogni bit da 0 a 7 (LSB→MSB)
            For bit As Integer = 0 To 7
                If (b And (1 << bit)) <> 0 Then
                    ' i: indice del byte (0..12), formattato a 2 cifre
                    ' bit+1: indice del bit (1..8)
                    codes.Add($"{i:D2}-{bit + 1}")
                End If
            Next
        Next

        ' Se non ci sono allarmi torna una stringa vuota, altrimenti li unisce con virgola
        Return If(codes.Count = 0, String.Empty, String.Join(", ", codes))
    End Function

End Class

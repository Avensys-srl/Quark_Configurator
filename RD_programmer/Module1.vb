
Module Module1
    Public Class CustomerData
        Public Property FSC_CAF_Speed1 As Integer
        Public Property FSC_CAF_Speed2 As Integer
        Public Property FSC_CAF_Speed3 As Integer
        Public Property CAP_Speed1 As Integer
        Public Property CAP_Speed2 As Integer
        Public Property CAP_Speed3 As Integer
        Public Property BoostTimer As Integer
        Public Property FilterTimer As Integer
        Public Property FireKitTimer As Integer
        Public Property CO2SetPoint As Integer
        Public Property RHSetPoint As Integer
        Public Property VOCSetPoint As Integer
        Public Property TempSetPoint As Integer
        Public Property SUM_WINSetPoint As Integer
        Public Property Configuration As String
        Public Property VersionHW As String
        Public Property VersionSW As String
        Public Property SerialNumber As String
        Public Property KHK_ENABLE As Boolean
        Public Property KHK_NC As Boolean
        Public Property KHK_NO As Boolean
        Public Property KHK_VALUE As Byte
        Public Property IMBALANCESetPoint As SByte
        Public Property IMBALANCE_ENABLE As Byte
        Public Property KHK_SET_POINT As Byte

        Public Property KHKIMBALANCESetPoint As SByte

        Public Sub Clear()
            FSC_CAF_Speed1 = 25
            FSC_CAF_Speed2 = 25
            FSC_CAF_Speed3 = 25
            CAP_Speed1 = 30
            CAP_Speed2 = 30
            CAP_Speed3 = 30
            BoostTimer = 15
            FilterTimer = 30
            FireKitTimer = 10
            CO2SetPoint = 700
            RHSetPoint = 20
            VOCSetPoint = 2
            TempSetPoint = 12
            SUM_WINSetPoint = 12
            Configuration = String.Empty
            VersionHW = String.Empty
            VersionSW = String.Empty
            SerialNumber = String.Empty
            KHK_ENABLE = False
            KHK_NC = True
            KHK_NO = False
            KHK_VALUE = 2
            IMBALANCESetPoint = 0
            IMBALANCE_ENABLE = False
            KHK_SET_POINT = 100
            KHKIMBALANCESetPoint = 0
        End Sub
    End Class

End Module

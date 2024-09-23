
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
            FSC_CAF_Speed1 = 0
            FSC_CAF_Speed2 = 0
            FSC_CAF_Speed3 = 0
            CAP_Speed1 = 0
            CAP_Speed2 = 0
            CAP_Speed3 = 0
            BoostTimer = 0
            FilterTimer = 0
            FireKitTimer = 0
            CO2SetPoint = 0
            RHSetPoint = 0
            VOCSetPoint = 0
            TempSetPoint = 0
            SUM_WINSetPoint = 0
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

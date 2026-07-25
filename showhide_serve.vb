Public Class showhide_serve

    Private Shared template As String = Getgtzip(frmSettings.TextBox13.Text)
    Public Shared Sub serve_home_ON()
        Dim serveH_ON As String = Update_vMix.BuildVmixSelectCommand("SetImageVisibleOn", template, "SERVEH.Source")
        Update_vMix.VTX(serveH_ON)
    End Sub
    Public Shared Sub serve_home_OFF()
        Dim serveH_OFF As String = Update_vMix.BuildVmixSelectCommand("SetImageVisibleOff", template, "SERVEH.Source")
        Update_vMix.VTX(serveH_OFF)
    End Sub

    Public Shared Sub serve_away_ON()
        Dim serveA_ON As String = Update_vMix.BuildVmixSelectCommand("SetImageVisibleOn", template, "SERVEA.Source")
        Update_vMix.VTX(serveA_ON)
    End Sub
    Public Shared Sub serve_away_OFF()
        Dim serveA_OFF As String = Update_vMix.BuildVmixSelectCommand("SetImageVisibleOff", template, "SERVEA.Source")
        Update_vMix.VTX(serveA_OFF)
    End Sub

    Private Shared Function Getgtzip(filePath As String) As String
        ' Find the last backslash in the path
        Dim lastBackslashIndex As Integer = filePath.LastIndexOf("\")
        ' Return the substring that starts right after the last backslash
        Return filePath.Substring(lastBackslashIndex + 1)
    End Function
End Class

Public Class showhide_sets


    Public Shared Sub SET_2_ON(template As String)
        Dim BG2_ON As String = Update_vMix.BuildVmixSelectCommand("SetImageVisibleOn", template, "BG_S2.Source")
        Dim TEXT2_1_ON As String = Update_vMix.BuildVmixSelectCommand("SetTextVisibleOn", template, "HOMEPOINTSSET2.Text")
        Dim TEXT2_2_ON As String = Update_vMix.BuildVmixSelectCommand("SetTextVisibleOn", template, "AWAYPOINTSSET2.Text")
        Update_vMix.VTX(BG2_ON)
        Update_vMix.VTX(TEXT2_1_ON)
        Update_vMix.VTX(TEXT2_2_ON)
    End Sub

    Public Shared Sub SET_2_OFF(template As String)
        Dim BG2_OFF As String = Update_vMix.BuildVmixSelectCommand("SetImageVisibleOff", template, "BG_S2.Source")
        Dim TEXT2_1_OFF As String = Update_vMix.BuildVmixSelectCommand("SetTextVisibleOff", template, "HOMEPOINTSSET2.Text")
        Dim TEXT2_2_OFF As String = Update_vMix.BuildVmixSelectCommand("SetTextVisibleOff", template, "AWAYPOINTSSET2.Text")
        Update_vMix.VTX(BG2_OFF)
        Update_vMix.VTX(TEXT2_1_OFF)
        Update_vMix.VTX(TEXT2_2_OFF)
    End Sub

    Public Shared Sub SET_3_ON(template As String)
        Dim BG3_ON As String = Update_vMix.BuildVmixSelectCommand("SetImageVisibleOn", template, "BG_S3.Source")
        Dim TEXT3_1_ON As String = Update_vMix.BuildVmixSelectCommand("SetTextVisibleOn", template, "HOMEPOINTSSET3.Text")
        Dim TEXT3_2_ON As String = Update_vMix.BuildVmixSelectCommand("SetTextVisibleOn", template, "AWAYPOINTSSET3.Text")
        Update_vMix.VTX(BG3_ON)
        Update_vMix.VTX(TEXT3_1_ON)
        Update_vMix.VTX(TEXT3_2_ON)
    End Sub

    Public Shared Sub SET_3_OFF(template As String)
        Dim BG3_OFF As String = Update_vMix.BuildVmixSelectCommand("SetImageVisibleOff", template, "BG_S3.Source")
        Dim TEXT3_1_OFF As String = Update_vMix.BuildVmixSelectCommand("SetTextVisibleOff", template, "HOMEPOINTSSET3.Text")
        Dim TEXT3_2_OFF As String = Update_vMix.BuildVmixSelectCommand("SetTextVisibleOff", template, "AWAYPOINTSSET3.Text")
        Update_vMix.VTX(BG3_OFF)
        Update_vMix.VTX(TEXT3_1_OFF)
        Update_vMix.VTX(TEXT3_2_OFF)
    End Sub

End Class

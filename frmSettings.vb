Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Xml

Public Class frmSettings
    Private settingsFilePath As String = "c:\VMIX\Beachvolleyball\settings.xml"

    Public Sub frmSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSettings()
        InitializeLabels()
        Me.Text = My.Application.Info.Title & "  SettingsScreen  " & My.Application.Info.Version.ToString + "  -  " & My.Application.Info.CompanyName + " - " & My.Application.Info.Copyright
    End Sub

    Public Sub LoadSettings()
        Try
            If System.IO.File.Exists(settingsFilePath) Then
                Dim xmlDoc As New XmlDocument()
                xmlDoc.Load(settingsFilePath)

                ' Load TextBoxes
                For i As Integer = 1 To 50
                    Dim settingNode As XmlNode = xmlDoc.SelectSingleNode($"/Settings/Setting{i}")
                    If settingNode IsNot Nothing Then
                        Dim textBox As TextBox = TryCast(Me.Controls($"TextBox{i}"), TextBox)
                        If textBox IsNot Nothing Then
                            textBox.Text = settingNode.InnerText
                        Else
                            Throw New Exception($"TextBox{i} not found.")
                        End If
                    End If
                Next

                ' Load CheckBoxes
                For i As Integer = 1 To 7
                    Dim settingNode As XmlNode = xmlDoc.SelectSingleNode($"/Settings/CheckBox{i}")
                    If settingNode IsNot Nothing Then
                        Dim checkBox As CheckBox = TryCast(Me.Controls($"CheckBox{i}"), CheckBox)
                        If checkBox IsNot Nothing Then
                            checkBox.Checked = Boolean.Parse(settingNode.InnerText)
                        Else
                            Throw New Exception($"CheckBox{i} not found.")
                        End If
                    End If
                Next

                ' Load IP TextBox
                Dim ipNode As XmlNode = xmlDoc.SelectSingleNode("/Settings/Setting_IP")
                If ipNode IsNot Nothing Then
                    TextBox_IP.Text = ipNode.InnerText
                Else
                    Throw New Exception("Setting_IP node not found.")
                End If

                ' Load vMix HTTP/TCP port TextBoxes - kein Throw, falls das Setting-XML noch aus
                ' einer Zeit vor CheckBox7/Textbox_portHTTP/TextBox_portTCP stammt (Default aus
                ' SetDefaultValues bzw. Designer bleibt dann einfach stehen).
                Dim portHttpNode As XmlNode = xmlDoc.SelectSingleNode("/Settings/Setting_PortHTTP")
                If portHttpNode IsNot Nothing Then Textbox_portHTTP.Text = portHttpNode.InnerText
                Dim portTcpNode As XmlNode = xmlDoc.SelectSingleNode("/Settings/Setting_PortTCP")
                If portTcpNode IsNot Nothing Then TextBox_portTCP.Text = portTcpNode.InnerText
            Else
                SetDefaultValues()
            End If
        Catch ex As FileNotFoundException
            MessageBox.Show("Settings file not found. Default values will be used.", "Error17", MessageBoxButtons.OK, MessageBoxIcon.Error)
            SetDefaultValues()
        Catch ex As XmlException
            MessageBox.Show($"Error parsing the settings file: {ex.Message}", "Error18", MessageBoxButtons.OK, MessageBoxIcon.Error)
            SetDefaultValues()
        Catch ex As Exception
            MessageBox.Show($"An error occurred while loading settings: {ex.Message}", "Error19", MessageBoxButtons.OK, MessageBoxIcon.Error)
            SetDefaultValues()
        End Try
    End Sub

    Public Sub SetDefaultValues()
        TextBox1.Text = "21"
        TextBox2.Text = "21"
        TextBox3.Text = "15"
        TextBox4.Text = "Tournament Title"
        TextBox5.Text = "FF0000"
        TextBox6.Text = "FFFF00"
        TextBox7.Text = "not set"
        TextBox8.Text = "not set"
        TextBox9.Text = "not set"
        TextBox10.Text = "not set"
        TextBox11.Text = "not set"
        TextBox12.Text = "not set"
        TextBox13.Text = "not set"
        TextBox14.Text = "not set"
        TextBox15.Text = "not set"
        TextBox16.Text = "not set"
        TextBox17.Text = "not set"
        TextBox18.Text = "not set"
        TextBox19.Text = "not set"
        TextBox20.Text = "not set"
        TextBox21.Text = "not set"
        TextBox22.Text = "not set"
        TextBox23.Text = "not set"
        TextBox24.Text = "not set"
        TextBox25.Text = "not set"
        TextBox26.Text = "not set"
        TextBox27.Text = "not set"
        TextBox28.Text = "not set"
        TextBox29.Text = "not set"
        TextBox30.Text = "not set"
        TextBox31.Text = "not set"
        TextBox32.Text = "not set"
        TextBox33.Text = "not set"
        TextBox34.Text = "not set"
        TextBox35.Text = "not set"
        TextBox36.Text = "not set"
        TextBox37.Text = "not set"
        TextBox38.Text = "not set"
        TextBox39.Text = "not set"
        TextBox40.Text = "not set"
        TextBox41.Text = "not set"
        TextBox42.Text = "not set"
        TextBox43.Text = "not set"
        TextBox44.Text = "not set"
        TextBox_IP.Text = "localhost"
        Textbox_portHTTP.Text = "8088"
        TextBox_portTCP.Text = "8099"
        ' HTTP als Default, damit sich am bisherigen (HTTP-only) Verhalten nichts ändert, wenn
        ' noch kein Settings-XML mit einem CheckBox7-Wert existiert.
        CheckBox7.Checked = True
        SaveSettings()
    End Sub

    Public Sub btn_Save_settings_Click(sender As Object, e As EventArgs) Handles btn_Save_settings.Click
        'save all settings and update then all gui elements to the new settings
        ' timer1 handles a "wait" gui element, to signal, that the settings are written
        Dim stopwatch As Stopwatch = Stopwatch.StartNew()
        SaveSettings()
        btn_Save_settings.BackColor = Color.Red
        btn_Exit_settings.Enabled = False
        btn_Exit_settings.Text = "wait"
        Timer1.Interval = 2000
        Timer1.Start()
        BeachVolleyballScorer.IP = TextBox_IP.Text
        BeachVolleyballScorer.ToolStripStatusLabel1.Text = BeachVolleyballScorer.IP
        Dim parsedHttpPort As Integer
        If Integer.TryParse(Textbox_portHTTP.Text.Trim(), parsedHttpPort) Then
            BeachVolleyballScorer.PORT = parsedHttpPort
        End If
        Dim parsedTcpPort As Integer
        If Integer.TryParse(TextBox_portTCP.Text.Trim(), parsedTcpPort) Then
            BeachVolleyballScorer.TcpPort = parsedTcpPort
        End If
        BeachVolleyballScorer.UseHttpForVmix = CheckBox7.Checked
        BeachVolleyballScorer.WinPointsSet1 = TextBox1.Text
        BeachVolleyballScorer.WinPointsSet2 = TextBox2.Text
        BeachVolleyballScorer.WinPointsSet3 = TextBox3.Text
        BeachVolleyballScorer.InitializeSetPointsToWin()
        Update_vMix.SetTitles()
        Update_labels()
        BeachVolleyballScorer.LoadAdvertisingbuttonText()
        BeachVolleyballScorer.LoadGtzipTitles()
        stopwatch.Stop()
        Dim elapsedTicks As Long = stopwatch.ElapsedTicks
        Dim elapsedTime As Double = stopwatch.Elapsed.TotalMilliseconds
        BeachVolleyballScorer.ListBox5.Items.Add($" Save Settings in settings {elapsedTime:F3} ms ")

        If CheckBox3.Checked = True Then
            BeachVolleyballScorer.ToolStripStatusLabel8.Text = "Stationlogo ON"
        Else
            BeachVolleyballScorer.ToolStripStatusLabel8.Text = "Stationlogo OFF"
        End If

        If CheckBox6.Checked = True Then
            BeachVolleyballScorer.btn_scorebug_large.Visible = True
        Else
            BeachVolleyballScorer.btn_scorebug_large.Visible = False
        End If

    End Sub

    Public Sub Update_labels()
        'update gui with freenames, refs and comms
        BeachVolleyballScorer.btn_freename1.Text = TextBox46.Text '.Split(",")(0)
        BeachVolleyballScorer.btn_freename2.Text = TextBox47.Text.Split(",")(0)
        BeachVolleyballScorer.btn_freename3.Text = TextBox48.Text.Split(",")(0)
        BeachVolleyballScorer.btn_freename4.Text = TextBox49.Text.Split(",")(0)
        BeachVolleyballScorer.btn_freename5.Text = TextBox50.Text.Split(",")(0)
        BeachVolleyballScorer.btn_ref1.Text = TextBox7.Text.Split(",")(0)
        BeachVolleyballScorer.btn_ref2.Text = TextBox8.Text.Split(",")(0)
        BeachVolleyballScorer.btn_ref3.Text = TextBox9.Text.Split(",")(0)
        BeachVolleyballScorer.btn_ref4.Text = TextBox10.Text.Split(",")(0)
    End Sub

    Public Sub SaveSettings()
        Try
            Dim xmlDoc As New XmlDocument()
            Dim rootNode As XmlNode = xmlDoc.CreateElement("Settings")
            xmlDoc.AppendChild(rootNode)

            ' save 50 TextBoxes
            For i As Integer = 1 To 50
                Dim textBox As TextBox = TryCast(Me.Controls($"TextBox{i}"), TextBox)
                If textBox IsNot Nothing Then
                    Dim settingNode As XmlNode = xmlDoc.CreateElement($"Setting{i}")
                    settingNode.InnerText = textBox.Text
                    rootNode.AppendChild(settingNode)
                Else
                    Throw New Exception($"TextBox{i} not found.")
                End If
            Next

            ' save 7 CheckBoxes
            For i As Integer = 1 To 7
                Dim checkBox As CheckBox = TryCast(Me.Controls($"CheckBox{i}"), CheckBox)
                If checkBox IsNot Nothing Then
                    Dim settingNode As XmlNode = xmlDoc.CreateElement($"CheckBox{i}")
                    settingNode.InnerText = checkBox.Checked.ToString()
                    rootNode.AppendChild(settingNode)
                Else
                    Throw New Exception($"CheckBox{i} not found.")
                End If
            Next

            ' save IP TextBox
            Dim ipNode As XmlNode = xmlDoc.CreateElement("Setting_IP")
            ipNode.InnerText = TextBox_IP.Text
            rootNode.AppendChild(ipNode)

            ' save vMix HTTP/TCP port TextBoxes
            Dim portHttpNode As XmlNode = xmlDoc.CreateElement("Setting_PortHTTP")
            portHttpNode.InnerText = Textbox_portHTTP.Text
            rootNode.AppendChild(portHttpNode)
            Dim portTcpNode As XmlNode = xmlDoc.CreateElement("Setting_PortTCP")
            portTcpNode.InnerText = TextBox_portTCP.Text
            rootNode.AppendChild(portTcpNode)

            xmlDoc.Save(settingsFilePath)

        Catch ex As Exception
            MessageBox.Show($"An error occurred while saving settings: {ex.Message}", "Error20", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress, TextBox2.KeyPress, TextBox3.KeyPress
        ' Überprüfen, ob die Taste eine Zahl oder eine Steuerungstaste (wie Backspace) ist
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            ' Wenn nicht, die Eingabe abbrechen
            e.Handled = True
        End If
    End Sub

    Private Sub btn_Exit_settings_Click(sender As Object, e As EventArgs) Handles btn_Exit_settings.Click
        Me.Hide()
        BeachVolleyballScorer.Show()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        btn_Save_settings.BackColor = Color.LimeGreen
        ' Timer stoppen
        Timer1.Stop()
        ' Button auf die Standardfarbe zurücksetzen
        btn_Exit_settings.Text = "exit settings"
        btn_Exit_settings.Enabled = True
    End Sub

    Private Sub Button_charmap_Click(sender As Object, e As EventArgs) Handles Button_charmap.Click
        Process.Start("charmap")
    End Sub

    Private Sub Label_Click(sender As Object, e As EventArgs)
        'sub for opening a filedialog, when clicked a label
        Dim label As Label = CType(sender, Label)
        Dim labelName As String = label.Name


        ' extract the label number
        Dim regex As New Regex("\d+")
        Dim match As Match = regex.Match(labelName)

        If match.Success Then
            Dim labelNumber As Integer = CInt(match.Value)

            ' find the corresponding textbox
            Dim textboxName As String = "textbox" & labelNumber.ToString()
            Dim textbox As TextBox = CType(Me.Controls(textboxName), TextBox)

            ' open the file dialog
            Using openFileDialog As New OpenFileDialog
                openFileDialog.InitialDirectory = "C:\vmix\beachvolleyball\titles"
                If openFileDialog.ShowDialog() = DialogResult.OK Then
                    textbox.Text = openFileDialog.FileName
                Else
                    textbox.Text = "not set"
                End If
            End Using
        Else
            MessageBox.Show("Label number conversion failed for: " & labelName, "Error22", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub InitializeLabels()
        ' initialize labels and attach click event handlers
        ' belongs to Sub Label_Click
        For i As Integer = 11 To 42 ' textbox 43-50 enthalten keine pfadnamen
            Dim labelName As String = "label" & i.ToString()
            Dim label As Label = CType(Me.Controls(labelName), Label)

            AddHandler label.Click, AddressOf Label_Click
        Next
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        'checkbox, stationlogo always on or off
        Dim nametemplate1 As String = Getgtzip(TextBox27.Text)
        Dim sendstring As String
        If BeachVolleyballScorer.StationlogoON = False Then
            sendstring = Update_vMix.BuildVmixInputCommand("OverlayInput3IN", nametemplate1)
            Update_vMix.VTX(sendstring)
            BeachVolleyballScorer.StationlogoON = True
            CheckBox3.BackColor = Color.Red
            BeachVolleyballScorer.ToolStripStatusLabel8.Text = "Stationlogo ON"
        Else
            sendstring = "Function=OverlayInput3Out"
            Update_vMix.VTX(sendstring)
            BeachVolleyballScorer.StationlogoON = False
            CheckBox3.BackColor = SystemColors.Control
            BeachVolleyballScorer.ToolStripStatusLabel8.Text = "Stationlogo OFF"
        End If
    End Sub

    Private Shared Function Getgtzip(filePath As String) As String
        'find the last backslash in the path
        Dim lastBackslashIndex As Integer = filePath.LastIndexOf("\")
        'return substring that starts right after the last backslash
        Return filePath.Substring(lastBackslashIndex + 1)
    End Function

    Private Sub btn_help_Click(sender As Object, e As EventArgs) Handles btn_help.Click, TextBox51.Click
        If TextBox51.Visible = False Then
            TextBox51.Visible = True
            TextBox51.BringToFront()
        Else
            TextBox51.Visible = False
        End If
    End Sub

    Private Sub DefaultValues_Settings()
        ' hardcoded values , with this data, the program will work when all files are in the corresponding directorys
        Dim defaultValues As String() = {
        "21",       ' Setting1
        "21",       ' Setting2
        "15",       ' Setting3
        "Beachvolley Pro Tour", ' Setting4
        "F0F0F0",   ' Setting5
        "F0F0F0",   ' Setting6
        "Jonas Personeni, Referee", ' Setting7
        "Miguel Quintana, Assistant Referee", ' Setting8
        "John Miller, commentator", ' Setting9
        "Jack Armstrong, co-commentator", ' Setting10
        "C:\VMIX\beachvolleyball\titles\volley_lower_player_1l.gtzip", ' Setting11
        "C:\VMIX\beachvolleyball\titles\volley_lower_player_2l_info.gtzip", ' Setting12
        "C:\VMIX\beachvolleyball\titles\volley_scorebug.gtzip", ' Setting13
        "C:\VMIX\beachvolleyball\titles\volley_large_result.gtzip", ' Setting14
        "",' Setting15
        "C:\VMIX\beachvolleyball\titles\volley_lower_teamname.gtzip", ' Setting16
        "C:\VMIX\beachvolleyball\titles\volley_match_id.gtzip", ' Setting17
        "C:\VMIX\beachvolleyball\titles\volley_lower_1l.gtzip", ' Setting18
        "C:\VMIX\beachvolleyball\titles\volley_lower_2l.gtzip", ' Setting19
        "C:\VMIX\beachvolleyball\titles\volley_weather.gtzip", ' Setting20
        "C:\VMIX\beachvolleyball\titles\volley_table.gtzip", ' Setting21
        "C:\VMIX\beachvolleyball\titles\volley_openingtitle.gtzip", ' Setting22
        "C:\VMIX\beachvolleyball\titles\volley_intro_venue.gtzip", ' Setting23
        "C:\VMIX\beachvolleyball\titles\volley_tournament.gtzip", ' Setting24
        "C:\VMIX\beachvolleyball\titles\volley_closingtitle.gtzip", ' Setting25
        "", ' Setting26
        "C:\VMIX\beachvolleyball\stationlogo\stationlogo1.gtzip", ' Setting27
        "C:\VMIX\beachvolleyball\titles\volley_start_satellite.gtzip", ' Setting28
        "C:\VMIX\beachvolleyball\titles\volley_start_transmission.gtzip", ' Setting29
        "C:\VMIX\beachvolleyball\titles\volley_countdown.gtzip", ' Setting30
        "C:\VMIX\beachvolleyball\titles\volley_end_transmission.gtzip", ' Setting31
        "C:\VMIX\beachvolleyball\titles\volley_end_playout.gtzip", ' Setting32
        "C:\VMIX\beachvolleyball\advertising\ecopower.gtzip", ' Setting33
        "C:\VMIX\beachvolleyball\advertising\innovatech.gtzip", ' Setting34
        "C:\VMIX\beachvolleyball\advertising\pureessence.gtzip", ' Setting35
        "C:\VMIX\beachvolleyball\advertising\vitaglow.gtzip", ' Setting36
        "",         ' Setting37 (empty string)
        "",         ' Setting38 (empty string)
        "",         ' Setting39 (empty string)
        "",         ' Setting40 (empty string)
        "",         ' Setting41 (empty string)
        "C:\VMIX\beachvolleyball\weatherLogos\cloudy.png", ' Setting42
        "35 °C",    ' Setting43
        "S 3 km/h", ' Setting44
        "22 %",     ' Setting45
        "John Smith, President", ' Setting46
        "Emily Johnson, Secretary General", ' Setting47
        "David Brown, Athlete Development Manager", ' Setting48
        "Sarah Davis, Coaching Director", ' Setting49
        "Michael Wilson, Community Outreach Coordinator" ' Setting50
    }

        ' Assign each value to its corresponding textbox
        For i As Integer = 0 To defaultValues.Length - 1
            Dim textBoxName As String = "TextBox" & (i + 1).ToString()
            Dim ctrl As Control = Me.Controls.Find(textBoxName, True).FirstOrDefault()

            If TypeOf ctrl Is TextBox Then
                DirectCast(ctrl, TextBox).Text = defaultValues(i)
            End If
        Next
    End Sub

    Private Sub Btn_setdefaultvalues_Click(sender As Object, e As EventArgs) Handles Btn_setdefaultvalues.Click
        DefaultValues_Settings()
    End Sub

    Private Sub btn_clear_values_Click(sender As Object, e As EventArgs) Handles btn_clear_values.Click
        For i As Integer = 1 To 50
            Dim textBoxName As String = "TextBox" & i.ToString()
            Dim ctrl As Control = Me.Controls.Find(textBoxName, True).FirstOrDefault()

            If TypeOf ctrl Is TextBox Then
                DirectCast(ctrl, TextBox).Text = String.Empty
            End If
        Next
    End Sub

    Private Sub btn_winpoints_help_Click(sender As Object, e As EventArgs) Handles btn_winpoints_help.Click, TextBox52.Click
        If TextBox52.Visible = False Then
            TextBox52.Visible = True
            TextBox52.BringToFront()
        Else
            TextBox52.Visible = False
        End If
    End Sub

    Private Sub btn_tournament_title_help_Click(sender As Object, e As EventArgs) Handles btn_tournament_title_help.Click, TextBox53.Click
        If TextBox53.Visible = False Then
            TextBox53.Visible = True
            TextBox53.BringToFront()
        Else
            TextBox53.Visible = False
        End If
    End Sub

    Private Sub Btn_missing_files_Click(sender As Object, e As EventArgs) Handles Btn_missing_files.Click
        Dim missingFiles As New List(Of String)

        For i As Integer = 11 To 42
            Dim textBoxName As String = "Textbox" & i
            Dim filePath As String = CType(Me.Controls.Find(textBoxName, True).FirstOrDefault(), TextBox)?.Text.Trim()

            If Not String.IsNullOrEmpty(filePath) AndAlso Not File.Exists(filePath) Then
                missingFiles.Add(filePath)
            End If
        Next

        If missingFiles.Count > 0 Then
            Dim errorMessage As String = "The following files are missing:" & Environment.NewLine & String.Join(Environment.NewLine, missingFiles)
            MessageBox.Show(errorMessage, "missing files", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            MessageBox.Show("all files entered in datafields 11-42 are existing", "check for missing files", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btn_installtitles_in_vmix_Click(sender As Object, e As EventArgs) Handles btn_installtitles_in_vmix.Click
        Dim sendstring As String = ""
        For i = 11 To 41
            sendstring = "Function=Addinput&Value=Title|" + Me.Controls("TextBox" & i).Text
            Update_vMix.VTX(sendstring)
        Next
        'exports the 3 included beachvolleyball courts for testing as background, install the images and deletes the images with folder imediate
        Export_Resources()
        sendstring = "Function=Addinput&Value=Image|C:\vMix\beachvolleyball\testbg\beachvolley1.jpg"
        Update_vMix.VTX(sendstring)
        sendstring = "Function=Addinput&Value=Image|C:\vMix\beachvolleyball\testbg\beachvolley2.jpg"
        Update_vMix.VTX(sendstring)
        sendstring = "Function=Addinput&Value=Image|C:\vMix\beachvolleyball\testbg\beachvolley3.jpg"
        Update_vMix.VTX(sendstring)
        Thread.Sleep(3000)
        Dim folderPath As String = "C:\VMIX\beachvolleyball\testbg"
        Try
            If Directory.Exists(folderPath) Then
                Directory.Delete(folderPath, True)
            End If
        Catch ex As Exception
            'Console.WriteLine("Error deleting folder: " & ex.Message)
        End Try
        BeachVolleyballScorer.LoadGtzipTitles()
    End Sub

    Private Sub Export_Resources()
        ' checks directory
        Dim imagedirectory As String = "C:\vMix\beachvolleyball\testbg"
        If (Not Directory.Exists(imagedirectory)) Then
            Directory.CreateDirectory(imagedirectory)
        End If
        'save all images
        Dim b As Bitmap = My.Resources.beachvolley1
        b.Save("C:\vMix\beachvolleyball\testbg\beachvolley1.jpg")
        b = My.Resources.beachvolley2
        b.Save("C:\vMix\beachvolleyball\testbg\beachvolley2.jpg")
        b = My.Resources.beachvolley3
        b.Save("C:\vMix\beachvolleyball\testbg\beachvolley3.jpg")
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If Me.CheckBox2.Checked = True Then
            BeachVolleyballScorer.btn_Info_Home.Visible = False
            BeachVolleyballScorer.btn_Info_Away.Visible = False
            BeachVolleyballScorer.Label13.Visible = False
        Else
            BeachVolleyballScorer.btn_Info_Home.Visible = True
            BeachVolleyballScorer.btn_Info_Away.Visible = True
            BeachVolleyballScorer.Label13.Visible = True
        End If
    End Sub

    Private Sub CheckBox5_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox5.CheckedChanged
        ' simple scorebug
        BeachVolleyballScorer.btn_scorebug_large.Visible = False
        BeachVolleyballScorer.lbl_resetscore_nextset.Visible = False
        CheckBox6.Visible = False
        If CheckBox5.Checked Then
            BeachVolleyballScorer.lbl_resetscore_nextset.Visible = True
            BeachVolleyballScorer.btn_scorebug.Text = "simple scorebug"
            CheckBox6.Visible = True
            CheckBox6.Checked = False
        Else
            BeachVolleyballScorer.lbl_resetscore_nextset.Visible = False
            BeachVolleyballScorer.btn_scorebug.Text = "scorebug"
            CheckBox6.Visible = False
        End If
    End Sub

    Private Sub CheckBox6_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox6.CheckedChanged
        'combined scorebug,largeresult
        ' BeachVolleyballScorer.btn_scorebug_large.Visible = False
        ' BeachVolleyballScorer.lbl_resetscore_nextset.Visible = False

        If CheckBox5.Checked Then
            If CheckBox6.Checked Then
                BeachVolleyballScorer.btn_scorebug_large.Visible = True
            Else
                BeachVolleyballScorer.btn_scorebug_large.Visible = False

            End If
        Else
            BeachVolleyballScorer.btn_scorebug_large.Visible = False
        End If
    End Sub

End Class

Imports System.Windows.Forms
Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Threading
Imports System.Xml
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Button

Public Class BeachVolleyballScorer
    Public AutoSet As Boolean = False
    Public AutoRes As Boolean = False

    Public IP As String = "localhost"
    Public PORT As Integer = 8088
    ' vMix-TCP-API-Port (Standard 8099, separat vom HTTP-Port PORT/8088). Noch kein
    ' Settings-Textfeld dafür vorhanden - siehe Update_vMix.vb-Kommentar zu VmixTcpSender.
    Public TcpPort As Integer = 8099
    ' Schaltet zwischen HTTP- und TCP-Versand um (Update_vMix.CurrentSender()). Default True,
    ' damit sich am bisherigen (HTTP-only) Verhalten nichts ändert, solange noch keine
    ' Settings-Checkbox dafür existiert.
    Public UseHttpForVmix As Boolean = True
    Public responseData As String
    Public vMixconnectivity As Boolean = False
    Public sendstring As String = ""

    ' Eigener, durchgehend laufender Timer für die vMix-Erreichbarkeitsprüfung. Vorher wurde
    ' CheckConnection() nur beim Formular-Load aufgerufen - ein einzelner transienter
    ' Fehlschlag (z.B. vMix ist beim Programmstart noch nicht bereit) liess vMixconnectivity
    ' dauerhaft False bleiben, bis jemand manuell auf ToolStripStatusLabel7 klickte. Analog zu
    ' Tennis26_Scorer.Timer1_Tick/Fussballuhr.vmixConnectionTimer.
    Private ReadOnly vmixConnectionTimer As New System.Windows.Forms.Timer

    ' Variablen zur Speicherung der Punkte, Sätze und Aufschlag
    Public HomeTeam As String
    Public AwayTeam As String
    Public homeTeamPoints As Integer = 0
    Public awayTeamPoints As Integer = 0
    Public homeTeamSets As Integer = 0
    Public awayTeamSets As Integer = 0
    Public currentServerLabel As String
    Public currentServer As String = "None"
    Public winnerTeam As String = "none"

    Public Home_CountryL, Home_CountryS, Home_NAME1, Home_First_Name1, Home_Age1, Home_Height1, Home_Data1_1, Home_Data2_1, Home_Fact1, Home_Fact2 As String
    Public Home_NAME2, Home_First_Name2, Home_Age2, Home_Height2, Home_Data1_2, Home_Data2_2 As String

    Public Away_CountryL, Away_CountryS, Away_NAME1, Away_First_Name1, Away_Age1, Away_Height1, Away_Data1_1, Away_Data2_1, Away_Fact1, Away_Fact2 As String
    Public Away_NAME2, Away_First_Name2, Away_Age2, Away_Height2, Away_Data1_2, Away_Data2_2 As String

    Public Home_Flagge, Away_Flagge As String

    Public HomeColor As String = "#000000" ' Default color is black
    Public AwayColor As String = "#000000" ' Default color is black

    Private TextOnSecondLine As Boolean = False

    ' Konstante für den notwendigen Vorsprung zum Gewinn eines Satzes
    Public Const winBy As Integer = 2

    ' Liste der Gewinnpunkte für jeden Satz
    Public setPointsToWin As List(Of Integer)
    Public WinPointsSet1 As Integer = 5
    Public WinPointsSet2 As Integer = 5
    Public WinPointsSet3 As Integer = 5

    'booleans for checking overlay in or out
    Public Overlay1 As Boolean = False
    Public Overlay2 As Boolean = False
    Public Overlay3 As Boolean = False
    Public Overlay4 As Boolean = False
    Public PenaltyYellowON As Boolean = False
    Public PenaltyRedON As Boolean = False
    Public PenaltyYellowRedON As Boolean = False
    Public MatchID As Boolean = False
    Public WeatherON As Boolean = False
    Public OpeningTitle As Boolean = False
    Public ClosingTitle As Boolean = False
    Public InfoTitle As Boolean = False
    Public FreenameON As Boolean = False
    Public LargeResultON As Boolean = False
    Public StationlogoON As Boolean = False
    Public AdvertisingON As Boolean = False
    Public RefCom As Boolean = False
    Public Intro As Boolean = False
    Public Tournament As Boolean = False
    Public SecondLineON As Boolean = False
    Public ScorebugLarge As Boolean = False
    Public TimeOut As Boolean = False

    ' Aktueller Satzindex
    Public currentSetIndex As Integer = 60

    ' Variable zur Speicherung, ob ein Satz gewonnen wurde
    Public setWon As Boolean = False

    ' Variable zur Speicherung, ob das Spiel beendet ist
    Public gameEnded As Boolean = False

    ' Punkte für jeden Satz
    Public homeTeamPointsList As List(Of Integer) = New List(Of Integer)({0, 0, 0})
    Public awayTeamPointsList As List(Of Integer) = New List(Of Integer)({0, 0, 0})

    Public currentServerSet As Boolean = False
    ' Wer im aktuell laufenden Satz zuerst aufgeschlagen hat - nötig, um zu Beginn des
    ' nächsten Satzes korrekt zu bestimmen, wer aufschlägt (Regel: das Team, das im
    ' vorigen Satz NICHT zuerst aufgeschlagen hat, schlägt im nächsten Satz zuerst auf).
    ' currentServer allein reicht dafür nicht, da es bei Rally-Point-Scoring während des
    ' Satzes mehrfach wechselt und am Satzende nur noch anzeigt, wer den letzten Punkt
    ' gewonnen hat - nicht, wer den Satz eröffnet hat.
    Private firstServerOfSet As String = "none"

    ' Stack zur Speicherung der Zustände
    Private gameStateStack As Stack(Of GameState) = New Stack(Of GameState)()

    Private countdown As Integer = 0

    Private Const SettingsFile As String = "c:\vmix\beachvolleyball\settings.xml"
    Private Path As String = "c:\vmix\beachvolleyball"
    Private flagDirectory As String = "c:\vmix\beachvolleyball\flags"

    Dim homeSets As Integer = 0
    Dim awaySets As Integer = 0
    Dim pointsChanged As Boolean = False ' Diese Variable verfolgt, ob die Punkte geändert wurden


    Private Sub BeachVolleyballScorer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''sets form leftmost and middle verticaly
        'Me.StartPosition = FormStartPosition.Manual
        'Me.Left = 0
        'Me.Top = (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2

        'names 2 home player buttons & 2 away player buttons
        lbl_Players_Home.Text = Home_First_Name1.Substring(0, 1) + ". " + Home_NAME1 + " / " + Home_First_Name2.Substring(0, 1) + ". " + Home_NAME2
        lbl_Players_Away.Text = Away_First_Name1.Substring(0, 1) + ". " + Away_NAME1 + " / " + Away_First_Name2.Substring(0, 1) + ". " + Away_NAME2

        'gets the actual game from main data
        HomeTeam = BeachVolley_Main.ActualHomeTeam
        AwayTeam = BeachVolley_Main.ActualAwayTeam

        'labels actual team labels
        lbl_Name_Home.Text = HomeTeam
        lbl_Name_Away.Text = AwayTeam

        ' load all settings
        frmSettings.LoadSettings()

        ' sets winpoins from settings
        WinPointsSet1 = CInt(frmSettings.TextBox1.Text)
        WinPointsSet2 = CInt(frmSettings.TextBox2.Text)
        WinPointsSet3 = CInt(frmSettings.TextBox3.Text)

        'sets IP from settings
        IP = frmSettings.TextBox_IP.Text

        ' vMix HTTP/TCP-Port und Protokoll aus Settings übernehmen (analog zu IP oben) -
        ' ohne diese Zeilen würden Textbox_portHTTP/TextBox_portTCP/CheckBox7 nur beim
        ' nächsten "Save Settings"-Klick wirksam, nicht schon beim Programmstart.
        Dim parsedHttpPort As Integer
        If Integer.TryParse(frmSettings.Textbox_portHTTP.Text.Trim(), parsedHttpPort) Then
            PORT = parsedHttpPort
        End If
        Dim parsedTcpPort As Integer
        If Integer.TryParse(frmSettings.TextBox_portTCP.Text.Trim(), parsedTcpPort) Then
            TcpPort = parsedTcpPort
        End If
        UseHttpForVmix = frmSettings.CheckBox7.Checked

        'sets colors from settings, isch glaub unnötig
        HomeColor = frmSettings.TextBox5.Text
        AwayColor = frmSettings.TextBox6.Text
        If HomeColor <> "F0F0F0" Or AwayColor <> "F0F0F0" Then
            Try
                PictureBox_Homecolor.BackColor = ColorTranslator.FromHtml("#" & HomeColor)
                PictureBox_Awaycolor.BackColor = ColorTranslator.FromHtml("#" & AwayColor)
            Catch ex As Exception
                MessageBox.Show($"Error: {ex.Message}", "Error21", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            SET_btncolors_Home()
            SET_btncolors_Away()
        Else
            btn_nocolor_Home.PerformClick()
        End If

        btnHomeTeamPoint.Font = New Font("Segoe UI", 16, FontStyle.Bold)
        btnAwayTeamPoint.Font = New Font("Segoe UI", 16, FontStyle.Bold)


        CheckConnection()
        vmixConnectionTimer.Interval = 1000
        AddHandler vmixConnectionTimer.Tick, AddressOf VmixConnectionTimer_Tick
        vmixConnectionTimer.Start()

        If frmSettings.CheckBox2.Checked = True Then
            btn_Info_Home.Visible = False
            btn_Info_Away.Visible = False
            Label13.Visible = False
        Else
            btn_Info_Home.Visible = True
            btn_Info_Away.Visible = True
            Label13.Visible = True
        End If

        If frmSettings.CheckBox3.Checked = True Then
            ToolStripStatusLabel8.Text = "Stationlogo ON"
        Else
            ToolStripStatusLabel8.Text = "Stationlogo OFF"
        End If

        If frmSettings.CheckBox5.Checked Then
            'simple scorebug
            lbl_resetscore_nextset.Visible = True
            btn_scorebug.Text = "simple scorebug"
            frmSettings.CheckBox6.Visible = True
            frmSettings.CheckBox6.Checked = False
        Else
            lbl_resetscore_nextset.Visible = False
            btn_scorebug.Text = "scorebug"
            frmSettings.CheckBox6.Visible = False
        End If

        If frmSettings.CheckBox6.Checked Then
            'combined
            If frmSettings.CheckBox5.Checked Then
                btn_scorebug_large.Visible = True
            Else
                btn_scorebug_large.Visible = False

            End If
        Else
            btn_scorebug_large.Visible = False
        End If

        lbl_resetscore_nextset.Visible = False


        frmSettings.Update_labels()


        ToolStripStatusLabel1.Text = IP
        ToolStripStatusLabel2.Text = ""
        LoadAdvertisingbuttonText()
        InitializeSetPointsToWin()
        lblCurrentServerAway.Text = ""
        clear_penaltycards()
        'Update_vMix.SetTitles()
        LoadGtzipTitles()
        CheckConnection()
        lbl_countdown.Text = ""
        btnResetGame.PerformClick()
        Me.Text = My.Application.Info.Title & "  ScorerScreen  " & My.Application.Info.Version.ToString + "  -  " & My.Application.Info.CompanyName + " - " & My.Application.Info.Copyright
    End Sub

    Private Sub Fill_xlm_variables()
        WinPointsSet1 = 21
        WinPointsSet2 = 21
        WinPointsSet3 = 15
        frmSettings.TextBox1.Text = WinPointsSet1
        frmSettings.TextBox2.Text = WinPointsSet2
        frmSettings.TextBox3.Text = WinPointsSet3
        frmSettings.SaveSettings()
    End Sub

    Public Sub InitializeSetPointsToWin()
        ' Neue Werte zuweisen
        setPointsToWin = New List(Of Integer)({WinPointsSet1, WinPointsSet2, WinPointsSet3})
        lblWinPoints1.Text = WinPointsSet1.ToString()
        lblWinPoints2.Text = WinPointsSet2.ToString()
        lblWinPoints3.Text = WinPointsSet3.ToString()
    End Sub


    ' Kombinierte Methode für Punkte des Heim- und Auswärtsteams
    Private Sub btnTeamPoint_Click(sender As Object, e As EventArgs) Handles btnHomeTeamPoint.Click, btnAwayTeamPoint.Click
        ' Falls das Spiel beendet ist, keine weiteren Punkte hinzufügen
        If gameEnded Then
            Return
        End If

        ' Zustand speichern
        SaveGameState()

        ' Falls ein Satz gewonnen wurde und noch nicht zurückgesetzt ist, jetzt zurücksetzen
        If setWon Then
            ResetPoints()
            setWon = False
        End If

        ' Punkte hinzufügen
        If sender Is btnHomeTeamPoint Then
            homeTeamPoints += 1
            UpdateScore("HomeTeam")
        ElseIf sender Is btnAwayTeamPoint Then
            awayTeamPoints += 1
            UpdateScore("AwayTeam")
        End If
        update_vMix_Class()
        lblGame_ended.Text = ""
        lblGame_ended.Visible = False
    End Sub

    Private Sub update_vMix_Class()
        Update_vMix.Update_Scorebug_Names()
        Update_vMix.Update_Scorebug_Points()
        Update_vMix.SET1_Color_winner()
    End Sub

    Private Sub PictureBox_Flag_Home_Click(sender As Object, e As EventArgs) Handles PictureBox_Flag_Home.Click
        FlaggeHome()
    End Sub

    Private Sub PictureBox_Flag_Away_Click(sender As Object, e As EventArgs) Handles PictureBox_Flag_Away.Click
        FlaggeAway()
    End Sub

    Private Sub btn_swap_service_Click(sender As Object, e As EventArgs) Handles btn_swap_service.Click
        SwitchServer()
    End Sub

    Private Sub btn_singlename1_Home_Click(sender As Object, e As EventArgs) Handles btn_singlename1_Home.Click, btn_singlename2_Home.Click, btn_singlename1_Away.Click, btn_singlename2_Away.Click
        clear_penaltycards()
        ' Cast sender to a Button
        Dim b As Button = CType(sender, Button)
        Dim nametemplate1 As String
        TextOnSecondLine = False
        ClearRedButtons()

        If frmSettings.CheckBox2.Checked = True Then
            nametemplate1 = Getgtzip(frmSettings.TextBox11.Text)
        Else
            nametemplate1 = Getgtzip(frmSettings.TextBox12.Text)
        End If

        Select Case b.Name
            Case "btn_singlename1_Home"
                Update_vMix.Playername("H1")
                btn_singlename1_Home.BackColor = Color.Red
                TextOnSecondLine = Check2ndLine(Home_Age1, Home_Height1)
                If TextOnSecondLine = True Then lbl_Info_Age_Home.Text = Home_Age1 : lbl_Info_Height_Home.Text = Home_Height1 + "cm"
                If TextOnSecondLine = False Then lbl_Info_Age_Home.Text = "no 2.line Info"
            Case "btn_singlename2_Home"
                Update_vMix.Playername("H2")
                btn_singlename2_Home.BackColor = Color.Red
                TextOnSecondLine = Check2ndLine(Home_Age2, Home_Height2)
                If TextOnSecondLine = True Then lbl_Info_Age_Home.Text = Home_Age2 : lbl_Info_Height_Home.Text = Home_Height2 + "cm"
                If TextOnSecondLine = False Then lbl_Info_Age_Home.Text = "no 2.line Info"
            Case "btn_singlename1_Away"
                Update_vMix.Playername("A1")
                btn_singlename1_Away.BackColor = Color.Red
                TextOnSecondLine = Check2ndLine(Away_Age1, Away_Height1)
                If TextOnSecondLine = True Then lbl_Info_Age_Away.Text = Away_Age1 : lbl_Info_Height_Away.Text = Away_Height1 + "cm"
                If TextOnSecondLine = False Then lbl_Info_Age_Away.Text = "no 2.line Info"
            Case "btn_singlename2_Away"
                Update_vMix.Playername("A2")
                btn_singlename2_Away.BackColor = Color.Red
                TextOnSecondLine = Check2ndLine(Away_Age2, Away_Height2)
                If TextOnSecondLine = True Then lbl_Info_Age_Away.Text = Away_Age2 : lbl_Info_Height_Away.Text = Away_Height2 + "cm"
                If TextOnSecondLine = False Then lbl_Info_Age_Away.Text = "no 2.line Info"
        End Select

        If Overlay1 = False Then
            sendstring = Update_vMix.BuildVmixInputCommand("OverlayInput1IN", nametemplate1)
            Update_vMix.VTX(sendstring)
            Overlay1 = True
        Else
            sendstring = "Function=OverlayInput1Out"
            Update_vMix.VTX(sendstring)
            ClearButtonONVariables()
            ClearRedButtons()
            lbl_Info_Age_Home.Text = ""
            lbl_Info_Height_Home.Text = ""
            lbl_Info_Age_Away.Text = ""
            lbl_Info_Height_Away.Text = ""
        End If
    End Sub

    Function Check2ndLine(Age As String, Height As String) As Boolean
        If String.IsNullOrEmpty(Age) AndAlso String.IsNullOrEmpty(Height) Then
            Return False
            lbl_Info_Age_Home.Text = ""
            lbl_Info_Height_Home.Text = ""
            lbl_Info_Age_Away.Text = ""
            lbl_Info_Height_Away.Text = ""
        Else
            Return True
        End If
    End Function

    Private Sub ClearRedButtons()
        btn_singlename1_Home.BackColor = SystemColors.Control
        btn_singlename2_Home.BackColor = SystemColors.Control
        btn_singlename1_Away.BackColor = SystemColors.Control
        btn_singlename2_Away.BackColor = SystemColors.Control
        btn_teamname_Home.BackColor = SystemColors.Control
        btn_teamname_Away.BackColor = SystemColors.Control
        btn_MatchID.BackColor = SystemColors.Control
        btn_weather.BackColor = SystemColors.Control
        btn_scorebug.BackColor = SystemColors.Control
        btn_large_result.BackColor = SystemColors.Control
        btn_start_satellitetransmission.BackColor = SystemColors.Control
        btn_start_satellitetransmission.BackColor = SystemColors.Control
        btn_starttransmission.BackColor = SystemColors.Control
        btn_countdown.BackColor = SystemColors.Control
        btn_endtransmission.BackColor = SystemColors.Control
        btn_playout.BackColor = SystemColors.Control
        btn_start_satellitetransmission.BackColor = SystemColors.Control
        btn_OpeningTitle.BackColor = SystemColors.Control
        Button_ClosingTitle.BackColor = SystemColors.Control
        btn_advertising1.BackColor = SystemColors.Control
        btn_advertising2.BackColor = SystemColors.Control
        btn_advertising3.BackColor = SystemColors.Control
        btn_advertising4.BackColor = SystemColors.Control
        btn_ref1.BackColor = SystemColors.Control
        btn_ref2.BackColor = SystemColors.Control
        btn_ref3.BackColor = SystemColors.Control
        btn_ref4.BackColor = SystemColors.Control
        btn_freename1.BackColor = SystemColors.Control
        btn_freename2.BackColor = SystemColors.Control
        btn_freename3.BackColor = SystemColors.Control
        btn_freename4.BackColor = SystemColors.Control
        btn_freename5.BackColor = SystemColors.Control
        btn_freename6.BackColor = SystemColors.Control
        btn_Intro_venue.BackColor = SystemColors.Control
        Btn_tournament.BackColor = SystemColors.Control
        btn_Info_Home.BackColor = SystemColors.Control
        btn_Info_Away.BackColor = SystemColors.Control
        btn_scorebug_large.BackColor = SystemColors.Control
        btn_timeout.BackColor = SystemColors.Control
    End Sub
    Private Sub ClearButtonONVariables()
        'booleans for checking overlay in or out
        Overlay1 = False
        Overlay2 = False
        Overlay3 = False
        Overlay4 = False
        PenaltyYellowON = False
        PenaltyRedON = False
        PenaltyYellowRedON = False
        MatchID = False
        WeatherON = False
        OpeningTitle = False
        ClosingTitle = False
        InfoTitle = False
        FreenameON = False
        LargeResultON = False
        StationlogoON = False
        AdvertisingON = False
        RefCom = False
        Tournament = False
        Intro = False
        SecondLineON = False
        ScorebugLarge = False
        TimeOut = False
    End Sub


    Private Sub btn_scorebug_Click(sender As Object, e As EventArgs) Handles btn_scorebug.Click
        'homeTeamSets
        'awayTeamSets
        Dim scorebugtitle As String = ""
        If frmSettings.CheckBox5.Checked Then
            scorebugtitle = Getgtzip(frmSettings.TextBox37.Text)
        ElseIf frmSettings.CheckBox5.Checked And frmSettings.CheckBox6.Checked Then
            scorebugtitle = Getgtzip(frmSettings.TextBox38.Text)
        Else
            scorebugtitle = Getgtzip(frmSettings.TextBox13.Text)
        End If



        Dim VolleySet As Integer = 0
        ClearRedButtons()
        Dim stopwatch As Stopwatch = Stopwatch.StartNew()

        If frmSettings.CheckBox5.Checked = False Then
            If lblCurrentSet.Text = 1 Then
                showhide_sets.SET_2_OFF(scorebugtitle)
                showhide_sets.SET_3_OFF(scorebugtitle)
            ElseIf lblCurrentSet.Text = 2 Then
                showhide_sets.SET_2_ON(scorebugtitle)
                showhide_sets.SET_3_OFF(scorebugtitle)
            ElseIf lblCurrentSet.Text = 3 Then
                showhide_sets.SET_2_ON(scorebugtitle)
                showhide_sets.SET_3_ON(scorebugtitle)
            End If
        End If

        If frmSettings.CheckBox1.Checked = False Then
            If Overlay1 = False Then
                sendstring = Update_vMix.BuildVmixInputCommand("OverlayInput1IN", scorebugtitle)
                Update_vMix.VTX(sendstring)
                Overlay1 = True
                btn_scorebug.BackColor = Color.Red
            Else
                sendstring = "Function=OverlayInput1Out"
                Update_vMix.VTX(sendstring)
                Overlay1 = False
                ScorebugLarge = False
                btn_scorebug.BackColor = SystemColors.Control
                btn_scorebug_large.BackColor = SystemColors.Control
            End If

        ElseIf frmSettings.CheckBox1.Checked = True Then

            If Overlay1 = False Then
                sendstring = Update_vMix.BuildVmixInputCommand("OverlayInput2IN", scorebugtitle)
                Update_vMix.VTX(sendstring)
                Overlay1 = True
                btn_scorebug.BackColor = Color.Red
            Else
                sendstring = "Function=OverlayInput2Out"
                Update_vMix.VTX(sendstring)
                ClearButtonONVariables()
                ClearRedButtons()
            End If
        End If
        stopwatch.Stop()
        Dim elapsedTicks As Long = stopwatch.ElapsedTicks
        Dim elapsedTime As Double = stopwatch.Elapsed.TotalMilliseconds
        ListBox5.Items.Add($"scorebug took {elapsedTime:F3} ms ")
    End Sub

    Private Sub btn_scorebug_large_Click(sender As Object, e As EventArgs) Handles btn_scorebug_large.Click
        Dim scorebugtitle As String = Getgtzip(frmSettings.TextBox38.Text)
        Dim stopwatch As Stopwatch = Stopwatch.StartNew()

        If Overlay1 = True Then
            If ScorebugLarge = False Then
                sendstring = Update_vMix.BuildVmixCommand("TitleBeginAnimation", scorebugtitle, "Page1")
                Update_vMix.VTX(sendstring)
                ScorebugLarge = True
                btn_scorebug_large.BackColor = Color.Red
            Else
                sendstring = Update_vMix.BuildVmixCommand("TitleBeginAnimation", scorebugtitle, "Page2")
                Update_vMix.VTX(sendstring)
                ScorebugLarge = False
                btn_scorebug_large.BackColor = SystemColors.Control
            End If
            stopwatch.Stop()
            Dim elapsedTicks As Long = stopwatch.ElapsedTicks
            Dim elapsedTime As Double = stopwatch.Elapsed.TotalMilliseconds
            ListBox5.Items.Add($"scorebugToLarge took {elapsedTime:F3} ms ")
        End If
    End Sub
    Sub Clearbuttoncolors()
        btn_scorebug.BackColor = SystemColors.Control
    End Sub


    Private Sub btn_teamname_Home_Click(sender As Object, e As EventArgs) Handles btn_teamname_Home.Click, btn_teamname_Away.Click
        ' Cast sender to a Button
        Dim b As Button = CType(sender, Button)
        Dim nametemplate1 As String = Getgtzip(frmSettings.TextBox16.Text)
        ClearRedButtons()

        Select Case b.Name
            Case "btn_teamname_Home"
                Update_vMix.Teamname("H")
                btn_teamname_Home.BackColor = Color.Red
            Case "btn_teamname_Away"
                Update_vMix.Teamname("A")
                btn_teamname_Away.BackColor = Color.Red
        End Select
        If Overlay1 = False Then
            sendstring = Update_vMix.BuildVmixInputCommand("OverlayInput1IN", nametemplate1)
            Update_vMix.VTX(sendstring)
            Overlay1 = True
        Else
            sendstring = "Function=OverlayInput1Out"
            Update_vMix.VTX(sendstring)
            ClearButtonONVariables()
            ClearRedButtons()
        End If
    End Sub

    Private Sub btn_yellowcard_Click(sender As Object, e As EventArgs) Handles btn_yellowcard.Click
        Dim nametemplate1 As String = Getgtzip(frmSettings.TextBox11.Text)
        Dim nametemplate2 As String = Getgtzip(frmSettings.TextBox12.Text)
        If PenaltyYellowON = False Then
            btn_redcard.BackColor = SystemColors.Control
            btn_YellowRedcard.BackColor = SystemColors.Control
            PenaltyRedON = False
            PenaltyYellowRedON = False
            sendstring = Update_vMix.BuildVmixSetCommand("SetColor", nametemplate1, "CARD1.Fill.Color", "#FFFF00FF")
            Update_vMix.VTX(sendstring)
            sendstring = Update_vMix.BuildVmixSetCommand("SetColor", nametemplate1, "CARD2.Fill.Color", "#FFFF00FF")
            Update_vMix.VTX(sendstring)
            sendstring = Update_vMix.BuildVmixSetCommand("SetColor", nametemplate2, "CARD1.Fill.Color", "#FFFF00FF")
            Update_vMix.VTX(sendstring)
            sendstring = Update_vMix.BuildVmixSetCommand("SetColor", nametemplate2, "CARD2.Fill.Color", "#FFFF00FF")
            Update_vMix.VTX(sendstring)
            PenaltyYellowON = True
            btn_yellowcard.BackColor = Color.Red
        Else
            clear_penaltycards()
        End If
    End Sub

    Private Sub btn_redcard_Click(sender As Object, e As EventArgs) Handles btn_redcard.Click
        Dim nametemplate1 As String = Getgtzip(frmSettings.TextBox11.Text)
        Dim nametemplate2 As String = Getgtzip(frmSettings.TextBox12.Text)
        If PenaltyRedON = False Then
            PenaltyYellowON = False
            PenaltyYellowRedON = False
            btn_yellowcard.BackColor = SystemColors.Control
            btn_YellowRedcard.BackColor = SystemColors.Control
            sendstring = Update_vMix.BuildVmixSetCommand("SetColor", nametemplate1, "CARD1.Fill.Color", "#FF0000FF")
            Update_vMix.VTX(sendstring)
            sendstring = Update_vMix.BuildVmixSetCommand("SetColor", nametemplate1, "CARD2.Fill.Color", "#FF0000FF")
            Update_vMix.VTX(sendstring)
            sendstring = Update_vMix.BuildVmixSetCommand("SetColor", nametemplate2, "CARD1.Fill.Color", "#FF0000FF")
            Update_vMix.VTX(sendstring)
            sendstring = Update_vMix.BuildVmixSetCommand("SetColor", nametemplate2, "CARD2.Fill.Color", "#FF0000FF")
            Update_vMix.VTX(sendstring)
            PenaltyRedON = True
            btn_redcard.BackColor = Color.DarkRed
        Else
            clear_penaltycards()
        End If
    End Sub

    Private Sub btn_yellowredcard_Click(sender As Object, e As EventArgs) Handles btn_YellowRedcard.Click
        Dim nametemplate1 As String = Getgtzip(frmSettings.TextBox11.Text)
        Dim nametemplate2 As String = Getgtzip(frmSettings.TextBox12.Text)
        If PenaltyYellowRedON = False Then
            btn_yellowcard.BackColor = SystemColors.Control
            btn_redcard.BackColor = SystemColors.Control
            PenaltyYellowON = False
            PenaltyRedON = False
            sendstring = Update_vMix.BuildVmixSetCommand("SetColor", nametemplate1, "CARD1.Fill.Color", "#FF0000FF")
            Update_vMix.VTX(sendstring)
            sendstring = Update_vMix.BuildVmixSetCommand("SetColor", nametemplate1, "CARD2.Fill.Color", "#FFFF00FF")
            Update_vMix.VTX(sendstring)
            sendstring = Update_vMix.BuildVmixSetCommand("SetColor", nametemplate2, "CARD1.Fill.Color", "#FF0000FF")
            Update_vMix.VTX(sendstring)
            sendstring = Update_vMix.BuildVmixSetCommand("SetColor", nametemplate2, "CARD2.Fill.Color", "#FFFF00FF")
            Update_vMix.VTX(sendstring)
            PenaltyYellowRedON = True
            btn_YellowRedcard.BackColor = Color.Red
        Else
            clear_penaltycards()
        End If
    End Sub
    Private Sub clear_penaltycards()
        Dim nametemplate1 As String = Getgtzip(frmSettings.TextBox11.Text)
        Dim nametemplate2 As String = Getgtzip(frmSettings.TextBox12.Text)
        sendstring = Update_vMix.BuildVmixSetCommand("SetColor", nametemplate1, "CARD1.Fill.Color", "#FFFF0000")
        Update_vMix.VTX(sendstring)
        sendstring = Update_vMix.BuildVmixSetCommand("SetColor", nametemplate1, "CARD2.Fill.Color", "#FFFF0000")
        Update_vMix.VTX(sendstring)
        sendstring = Update_vMix.BuildVmixSetCommand("SetColor", nametemplate2, "CARD1.Fill.Color", "#FFFF0000")
        Update_vMix.VTX(sendstring)
        sendstring = Update_vMix.BuildVmixSetCommand("SetColor", nametemplate2, "CARD2.Fill.Color", "#FFFF0000")
        Update_vMix.VTX(sendstring)
        PenaltyYellowON = False
        PenaltyRedON = False
        PenaltyYellowRedON = False
        btn_yellowcard.BackColor = SystemColors.Control
        btn_redcard.BackColor = SystemColors.Control
        btn_YellowRedcard.BackColor = SystemColors.Control
    End Sub

    Private Sub btn_Exit_LIVE_Click_1(sender As Object, e As EventArgs) Handles btn_Exit_LIVE.Click
        Me.Hide()
        BeachVolley_Main.Show()
    End Sub


    Private Sub btn_MatchID_Click(sender As Object, e As EventArgs) Handles btn_MatchID.Click
        Dim nametemplate1 As String = Getgtzip(frmSettings.TextBox17.Text)
        ClearRedButtons()

        Dim stopwatch As Stopwatch = Stopwatch.StartNew()
        If MatchID = False Then
            Update_vMix.Update_MatchID_Names()
            sendstring = Update_vMix.BuildVmixInputCommand("OverlayInput1IN", nametemplate1)
            Update_vMix.VTX(sendstring)
            MatchID = True
            btn_MatchID.BackColor = Color.Red
        Else
            sendstring = "Function=OverlayInput1Out"
            Update_vMix.VTX(sendstring)
            ClearButtonONVariables()
            ClearRedButtons()
        End If
        stopwatch.Stop()
        Dim elapsedTicks As Long = stopwatch.ElapsedTicks
        Dim elapsedTime As Double = stopwatch.Elapsed.TotalMilliseconds
        ListBox5.Items.Add($" Match ID took {elapsedTime:F3} ms ")
    End Sub

    Private Sub btn_weather_Click(sender As Object, e As EventArgs) Handles btn_weather.Click
        Dim nametemplate1 As String = Getgtzip(frmSettings.TextBox20.Text)
        ClearRedButtons()

        If WeatherON = False Then
            sendstring = Update_vMix.BuildVmixSetCommand("SetImage", nametemplate1, "Image1.Source", frmSettings.TextBox42.Text)
            Update_vMix.VTX(sendstring)
            sendstring = Update_vMix.BuildVmixSetCommand("SetText", nametemplate1, "TEMPERATURE.Text", frmSettings.TextBox43.Text)
            Update_vMix.VTX(sendstring)
            sendstring = Update_vMix.BuildVmixSetCommand("SetText", nametemplate1, "WIND.Text", frmSettings.TextBox44.Text)
            Update_vMix.VTX(sendstring)
            sendstring = Update_vMix.BuildVmixSetCommand("SetText", nametemplate1, "HUM.Text", frmSettings.TextBox45.Text)
            Update_vMix.VTX(sendstring)

            sendstring = Update_vMix.BuildVmixInputCommand("OverlayInput1IN", nametemplate1)
            Update_vMix.VTX(sendstring)
            WeatherON = True
            btn_weather.BackColor = Color.Red
        Else
            sendstring = "Function=OverlayInput1Out"
            Update_vMix.VTX(sendstring)
            ClearRedButtons()
            ClearButtonONVariables()
        End If
    End Sub


    Private Sub btn_OpeningTitle_Click(sender As Object, e As EventArgs) Handles btn_OpeningTitle.Click
        Dim nametemplate As String = Getgtzip(frmSettings.TextBox22.Text)
        ClearRedButtons()
        If OpeningTitle = False Then
            sendstring = Update_vMix.BuildVmixInputCommand("OverlayInput1IN", nametemplate)
            Update_vMix.VTX(sendstring)
            OpeningTitle = True
            btn_OpeningTitle.BackColor = Color.Red
        Else
            sendstring = "Function=OverlayInput1Out"
            Update_vMix.VTX(sendstring)
            ClearButtonONVariables()
            ClearRedButtons()
        End If
    End Sub

    Private Sub btn_Intro_venue_Click(sender As Object, e As EventArgs) Handles btn_Intro_venue.Click
        Dim nametemplate As String = Getgtzip(frmSettings.TextBox23.Text)
        ClearRedButtons()
        If Intro = False Then
            sendstring = Update_vMix.BuildVmixInputCommand("OverlayInput1IN", nametemplate)
            Update_vMix.VTX(sendstring)
            Intro = True
            btn_Intro_venue.BackColor = Color.Red
        Else
            sendstring = "Function=OverlayInput1Out"
            Update_vMix.VTX(sendstring)
            ClearButtonONVariables()
            ClearRedButtons()
        End If
    End Sub


    Private Sub Btn_tournament_Click(sender As Object, e As EventArgs) Handles Btn_tournament.Click
        Dim nametemplate As String = Getgtzip(frmSettings.TextBox24.Text)
        ClearRedButtons()
        If Tournament = False Then
            sendstring = Update_vMix.BuildVmixInputCommand("OverlayInput1IN", nametemplate)
            Update_vMix.VTX(sendstring)
            Tournament = True
            Btn_tournament.BackColor = Color.Red
        Else
            sendstring = "Function=OverlayInput1Out"
            Update_vMix.VTX(sendstring)
            ClearButtonONVariables()
            ClearRedButtons()
        End If
    End Sub

    Private Sub Button_ClosingTitle_Click(sender As Object, e As EventArgs) Handles Button_ClosingTitle.Click
        Dim nametemplate As String = Getgtzip(frmSettings.TextBox25.Text)
        ClearRedButtons()

        If ClosingTitle = False Then
            sendstring = Update_vMix.BuildVmixInputCommand("OverlayInput1IN", nametemplate)
            Update_vMix.VTX(sendstring)
            ClosingTitle = True
            Button_ClosingTitle.BackColor = Color.Red
        Else
            sendstring = "Function=OverlayInput1Out"
            Update_vMix.VTX(sendstring)
            ClearButtonONVariables()
            ClearRedButtons()
        End If
    End Sub

    Private Sub PictureBox_Homecolor_Click(sender As Object, e As EventArgs) Handles PictureBox_Homecolor.Click
        'home color
        ' Display the ColorDialog to choose a color

        Dim nametemplate1 As String = Getgtzip(frmSettings.TextBox13.Text)
        Dim nametemplate2 As String = Getgtzip(frmSettings.TextBox14.Text)
        Dim nametemplate3 As String = Getgtzip(frmSettings.TextBox38.Text)

        If ColorDialog1.ShowDialog() = DialogResult.OK Then
            ' Get the selected color
            Dim selectedColor As Color = ColorDialog1.Color
            ' Convert the selected color to the #RGB format
            PictureBox_Homecolor.BackColor = selectedColor
            HomeColor = selectedColor.ToArgb().ToString("X6").Substring(2)
            SET_btncolors_Home()
        Else
            ' No color was chosen, handle the error here
            MessageBox.Show("No color was chosen.", "Error22", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        sendstring = Update_vMix.BuildVmixSetCommand("SetColor", nametemplate1, "COLORH.Fill.Color", "#" & HomeColor)
        Update_vMix.VTX(sendstring)
        sendstring = Update_vMix.BuildVmixSetCommand("SetColor", nametemplate2, "COLORH.Fill.Color", "#" & HomeColor)
        Update_vMix.VTX(sendstring)
        sendstring = Update_vMix.BuildVmixSetCommand("SetColor", nametemplate3, "COLORH.Fill.Color", "#" & HomeColor)
        Update_vMix.VTX(sendstring)
        frmSettings.TextBox5.Text = HomeColor
        'frmSettings.SaveSettings()
    End Sub

    Private Sub PictureBox_Awaycolor_Click(sender As Object, e As EventArgs) Handles PictureBox_Awaycolor.Click
        'Away color
        ' Display the ColorDialog to choose a color
        Dim nametemplate1 As String = Getgtzip(frmSettings.TextBox13.Text)
        Dim nametemplate2 As String = Getgtzip(frmSettings.TextBox14.Text)
        Dim nametemplate3 As String = Getgtzip(frmSettings.TextBox38.Text)
        If ColorDialog1.ShowDialog() = DialogResult.OK Then
            ' Get the selected color
            Dim selectedColor As Color = ColorDialog1.Color
            ' Convert the selected color to the #RGB format
            PictureBox_Awaycolor.BackColor = selectedColor
            AwayColor = selectedColor.ToArgb().ToString("X6").Substring(2)
            SET_btncolors_Away()
        Else
            ' No color was chosen, handle the error here
            MessageBox.Show("No color was chosen.", "Error23", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        sendstring = Update_vMix.BuildVmixSetCommand("SetColor", nametemplate1, "COLORA.Fill.Color", "#" & AwayColor)
        Update_vMix.VTX(sendstring)
        sendstring = Update_vMix.BuildVmixSetCommand("SetColor", nametemplate2, "COLORA.Fill.Color", "#" & AwayColor)
        Update_vMix.VTX(sendstring)
        sendstring = Update_vMix.BuildVmixSetCommand("SetColor", nametemplate3, "COLORA.Fill.Color", "#" & AwayColor)
        Update_vMix.VTX(sendstring)
        frmSettings.TextBox6.Text = AwayColor
        'frmSettings.SaveSettings()
    End Sub

    Private Sub SET_btncolors_Home()
        'home buttons
        btnHomeTeamPoint.FlatStyle = FlatStyle.Flat ' Ensure the flat style is set to Flat
        btnHomeTeamPoint.FlatAppearance.BorderColor = PictureBox_Homecolor.BackColor
        btnHomeTeamPoint.FlatAppearance.BorderSize = 10 ' Borderwidth

        btn_singlename1_Home.FlatStyle = FlatStyle.Flat ' Ensure the flat style is set to Flat
        btn_singlename1_Home.FlatAppearance.BorderColor = PictureBox_Homecolor.BackColor
        btn_singlename1_Home.FlatAppearance.BorderSize = 6 ' Borderwidth

        btn_singlename2_Home.FlatStyle = FlatStyle.Flat ' Ensure the flat style is set to Flat
        btn_singlename2_Home.FlatAppearance.BorderColor = PictureBox_Homecolor.BackColor
        btn_singlename2_Home.FlatAppearance.BorderSize = 6 ' Borderwidth

        btn_teamname_Home.FlatStyle = FlatStyle.Flat ' Ensure the flat style is set to Flat
        btn_teamname_Home.FlatAppearance.BorderColor = PictureBox_Homecolor.BackColor
        btn_teamname_Home.FlatAppearance.BorderSize = 6 ' Borderwidth
    End Sub
    Private Sub SET_btncolors_Away()
        'away buttons
        btnAwayTeamPoint.FlatStyle = FlatStyle.Flat ' Ensure the flat style is set to Flat
        btnAwayTeamPoint.FlatAppearance.BorderColor = PictureBox_Awaycolor.BackColor ' Change Color.Red to the desired border color
        btnAwayTeamPoint.FlatAppearance.BorderSize = 10 '
        'btnAwayTeamPoint.BackColor = SystemColors.Control

        btn_singlename1_Away.FlatStyle = FlatStyle.Flat ' Ensure the flat style is set to Flat
        btn_singlename1_Away.FlatAppearance.BorderColor = PictureBox_Awaycolor.BackColor
        btn_singlename1_Away.FlatAppearance.BorderSize = 6 ' Borderwidth

        btn_singlename2_Away.FlatStyle = FlatStyle.Flat ' Ensure the flat style is set to Flat
        btn_singlename2_Away.FlatAppearance.BorderColor = PictureBox_Awaycolor.BackColor
        btn_singlename2_Away.FlatAppearance.BorderSize = 6 ' Borderwidth

        btn_teamname_Away.FlatStyle = FlatStyle.Flat ' Ensure the flat style is set to Flat
        btn_teamname_Away.FlatAppearance.BorderColor = PictureBox_Awaycolor.BackColor
        btn_teamname_Away.FlatAppearance.BorderSize = 6 ' Borderwidth
    End Sub

    Public Sub RESET_btncolors()
        Dim nametemplate1 As String = Getgtzip(frmSettings.TextBox13.Text)
        Dim nametemplate2 As String = Getgtzip(frmSettings.TextBox14.Text)
        Dim nametemplate3 As String = Getgtzip(frmSettings.TextBox38.Text)

        sendstring = Update_vMix.BuildVmixSetCommand("SetColor", nametemplate1, "COLORH.Fill.Color", "#FFFFFF00")
        Update_vMix.VTX(sendstring)
        sendstring = Update_vMix.BuildVmixSetCommand("SetColor", nametemplate2, "COLORH.Fill.Color", "#FFFFFF00")
        Update_vMix.VTX(sendstring)
        sendstring = Update_vMix.BuildVmixSetCommand("SetColor", nametemplate3, "COLORH.Fill.Color", "#FFFFFF00")
        Update_vMix.VTX(sendstring)
        sendstring = Update_vMix.BuildVmixSetCommand("SetColor", nametemplate1, "COLORA.Fill.Color", "#FFFFFF00")
        Update_vMix.VTX(sendstring)
        sendstring = Update_vMix.BuildVmixSetCommand("SetColor", nametemplate2, "COLORA.Fill.Color", "#FFFFFF00")
        Update_vMix.VTX(sendstring)
        sendstring = Update_vMix.BuildVmixSetCommand("SetColor", nametemplate3, "COLORA.Fill.Color", "#FFFFFF00")
        Update_vMix.VTX(sendstring)
        PictureBox_Homecolor.BackColor = Color.LightGray
        PictureBox_Awaycolor.BackColor = Color.LightGray
        btnHomeTeamPoint.FlatAppearance.BorderColor = SystemColors.Control
        btnAwayTeamPoint.FlatAppearance.BorderColor = SystemColors.Control
        btn_singlename1_Home.FlatAppearance.BorderColor = SystemColors.Control
        btn_singlename2_Home.FlatAppearance.BorderColor = SystemColors.Control
        btn_teamname_Home.FlatAppearance.BorderColor = SystemColors.Control
        btn_singlename1_Away.FlatAppearance.BorderColor = SystemColors.Control
        btn_singlename2_Away.FlatAppearance.BorderColor = SystemColors.Control
        btn_teamname_Away.FlatAppearance.BorderColor = SystemColors.Control
        frmSettings.TextBox5.Text = "F0F0F0"
        frmSettings.TextBox6.Text = "F0F0F0"
        'frmSettings.SaveSettings()
    End Sub

    Public Sub btn_nocolor_Click(sender As Object, e As EventArgs) Handles btn_nocolor_Home.Click, btn_nocolor_Away.Click
        RESET_btncolors()
    End Sub

    Private Sub ToolStripStatusLabel5_Click(sender As Object, e As EventArgs) Handles ToolStripStatusLabel5.Click
        'settings
        frmSettings.Show()
        Me.Hide()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        'CheckConnection()
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        ' Decrement the countdown
        Dim nametemplate1 As String = Getgtzip(frmSettings.TextBox30.Text)

        countdown -= 1
        ' Update the label text
        lbl_countdown.Text = countdown.ToString()
        sendstring = Update_vMix.BuildVmixSetCommand("SetText", nametemplate1, "TIME.Text", countdown.ToString())
        Update_vMix.VTX(sendstring)
        ' Check if the countdown has reached 0
        If countdown <= 0 Then
            sendstring = "Function=OverlayInput1Off"
            Update_vMix.VTX(sendstring)
            InfoTitle = False
            btn_countdown.BackColor = SystemColors.Control
            lbl_countdown.Text = ""
            Timer3.Stop()
            ' Stop the timer
            Timer3.Stop()
        End If
    End Sub

    Private Sub btn_start_satellitetransmission_Click(sender As Object, e As EventArgs) Handles btn_start_satellitetransmission.Click
        Dim nametemplate1 As String = Getgtzip(frmSettings.TextBox28.Text)
        ClearRedButtons()

        If InfoTitle = False Then
            sendstring = Update_vMix.BuildVmixInputCommand("OverlayInput1IN", nametemplate1)
            Update_vMix.VTX(sendstring)
            InfoTitle = True
            btn_start_satellitetransmission.BackColor = Color.Red
        Else
            sendstring = "Function=OverlayInput1Out"
            Update_vMix.VTX(sendstring)
            ClearButtonONVariables()
            ClearRedButtons()
        End If
    End Sub

    Private Sub Stationlogo()
        Dim nametemplate1 As String = Getgtzip(frmSettings.TextBox27.Text)
        ClearRedButtons()
        If StationlogoON = False Then
            sendstring = Update_vMix.BuildVmixInputCommand("OverlayInput3IN", nametemplate1)
            Update_vMix.VTX(sendstring)
            StationlogoON = True
            btn_start_satellitetransmission.BackColor = Color.Red
        Else
            sendstring = "Function=OverlayInput3Out"
            Update_vMix.VTX(sendstring)
            ClearButtonONVariables()
            ClearRedButtons()
        End If
    End Sub

    Private Sub btn_starttransmission_Click(sender As Object, e As EventArgs) Handles btn_starttransmission.Click
        Dim nametemplate1 As String = Getgtzip(frmSettings.TextBox29.Text)
        ClearRedButtons()
        If InfoTitle = False Then
            sendstring = Update_vMix.BuildVmixInputCommand("OverlayInput1IN", nametemplate1)
            Update_vMix.VTX(sendstring)
            InfoTitle = True
            btn_starttransmission.BackColor = Color.Red
        Else
            sendstring = "Function=OverlayInput1Out"
            Update_vMix.VTX(sendstring)
            ClearButtonONVariables()
            ClearRedButtons()
        End If
    End Sub

    Private Sub btn_countdown_Click(sender As Object, e As EventArgs) Handles btn_countdown.Click
        Dim nametemplate1 As String = Getgtzip(frmSettings.TextBox30.Text)
        ClearRedButtons()

        If InfoTitle = False Then
            lbl_countdown.Text = "60"
            sendstring = Update_vMix.BuildVmixSetCommand("SetText", nametemplate1, "TIME.Text", "60")
            Update_vMix.VTX(sendstring)
            countdown = 60
            sendstring = Update_vMix.BuildVmixInputCommand("OverlayInput1IN", nametemplate1)
            Update_vMix.VTX(sendstring)
            InfoTitle = True
            btn_countdown.BackColor = Color.Red
            Timer3.Interval = 1000
            Timer3.Start()
        Else
            sendstring = "Function=OverlayInput1Off"
            Update_vMix.VTX(sendstring)
            ClearButtonONVariables()
            ClearRedButtons()
            lbl_countdown.Text = ""
            Timer3.Stop()
        End If
    End Sub

    Private Sub btn_endtransmission_Click(sender As Object, e As EventArgs) Handles btn_endtransmission.Click
        Dim nametemplate1 As String = Getgtzip(frmSettings.TextBox31.Text)
        ClearRedButtons()

        If InfoTitle = False Then
            sendstring = Update_vMix.BuildVmixInputCommand("OverlayInput1IN", nametemplate1)
            Update_vMix.VTX(sendstring)
            InfoTitle = True
            btn_endtransmission.BackColor = Color.Red
        Else
            sendstring = "Function=OverlayInput1Out"
            Update_vMix.VTX(sendstring)
            ClearButtonONVariables()
            ClearRedButtons()
        End If
    End Sub

    Private Sub ToolStripStatusLabel7_Click(sender As Object, e As EventArgs) Handles ToolStripStatusLabel7.Click
        CheckConnection()
    End Sub

    ' 1x/Sekunde durchgehender Re-Check (siehe vmixConnectionTimer-Feld oben) - hält
    ' vMixconnectivity/ToolStripStatusLabel7 aktuell, ohne dass jemand manuell klicken muss.
    Private Sub VmixConnectionTimer_Tick(sender As Object, e As EventArgs)
        CheckConnection()
    End Sub

    Private Sub BeachVolleyballScorer_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ' TCP-Verbindung zu vMix sauber trennen, falls die TCP-API gerade aktiv war.
        Update_vMix.DisposeVmixSender()
    End Sub

    Private Sub btn_freename_Click(sender As Object, e As EventArgs) Handles btn_freename1.Click, btn_freename2.Click, btn_freename3.Click, btn_freename4.Click, btn_freename5.Click, btn_freename6.Click
        ' Determine which button was clicked
        Dim button As Button = DirectCast(sender, Button)
        Dim nametemplate1 As String = Getgtzip(frmSettings.TextBox18.Text)
        Dim nametemplate2 As String = Getgtzip(frmSettings.TextBox19.Text)
        Dim stopwatch As Stopwatch = Stopwatch.StartNew()
        ClearRedButtons()
        ' Initialize TextBox based on the button clicked
        Dim textBox As TextBox
        Select Case button.Name
            Case "btn_freename1"
                textBox = frmSettings.TextBox46
            Case "btn_freename2"
                textBox = frmSettings.TextBox47
            Case "btn_freename3"
                textBox = frmSettings.TextBox48
            Case "btn_freename4"
                textBox = frmSettings.TextBox49
            Case "btn_freename5"
                textBox = frmSettings.TextBox50
            Case "btn_freename6"
                textBox = TextBox_freename
            Case Else
                ' If no matching button is found, exit the subroutine
                MessageBox.Show("No matching button found", "Error24", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
        End Select

        ' Get the text from the associated TextBox
        Dim fullText As String = textBox.Text.Trim()

        ' Initialize line1 and line2
        Dim line1 As String
        Dim line2 As String

        ' Check if the text contains a comma
        If fullText.Contains(",") Then
            ' Split the text at the comma
            Dim parts() As String = fullText.Split(New Char() {","c}, 2)
            line1 = parts(0).Trim()
            line2 = parts(1).Trim()
        Else
            ' If no comma, assign full text to line1 and set line2 to an empty string
            line1 = fullText
            line2 = String.Empty
        End If

        If FreenameON = False Then
            ' Display the lines
            sendstring = Update_vMix.BuildVmixSetCommand("SetText", nametemplate1, "NAME1.Text", line1)
            Update_vMix.VTX(sendstring)
            sendstring = Update_vMix.BuildVmixSetCommand("SetText", nametemplate2, "NAME1.Text", line1)
            Update_vMix.VTX(sendstring)
            If line2 <> String.Empty Then
                sendstring = Update_vMix.BuildVmixSetCommand("SetText", nametemplate2, "NAME2.Text", line2)
                Update_vMix.VTX(sendstring)
            End If

            Dim nametemplate As String
            If line2 = String.Empty Then
                nametemplate = "" + nametemplate1 + ""
            Else
                nametemplate = "" + nametemplate2 + ""
            End If

            ' Show the graphics and set the clicked button's background to red
            sendstring = Update_vMix.BuildVmixInputCommand("OverlayInput1IN", nametemplate)
            Update_vMix.VTX(sendstring)
            FreenameON = True
            button.BackColor = Color.Red ' Set only the clicked button's color
        Else
            ' Hide the graphics and reset all button colors to default
            sendstring = "Function=OverlayInput1Out"
            Update_vMix.VTX(sendstring)
            ClearButtonONVariables()
            ClearRedButtons()
        End If
        stopwatch.Stop()
        Dim elapsedTicks As Long = stopwatch.ElapsedTicks
        Dim elapsedTime As Double = stopwatch.Elapsed.TotalMilliseconds
        ListBox5.Items.Add($"freenames took {elapsedTime:F3} ms ")
    End Sub

    Private Sub btn_large_result_Click(sender As Object, e As EventArgs) Handles btn_large_result.Click
        Dim nametemplate As String = Getgtzip(frmSettings.TextBox14.Text)

        ClearRedButtons()
        ' Determine if there are points in the 3rd labels
        Dim hasPointsIn3rd As Boolean = Not String.IsNullOrEmpty(lblHomeTeamPoints3.Text) AndAlso IsNumeric(lblHomeTeamPoints3.Text) AndAlso CInt(lblHomeTeamPoints3.Text) > 0 OrElse
                                        Not String.IsNullOrEmpty(lblAwayTeamPoints3.Text) AndAlso IsNumeric(lblAwayTeamPoints3.Text) AndAlso CInt(lblAwayTeamPoints3.Text) > 0

        ' Determine if there are points in the 2nd labels
        Dim hasPointsIn2nd As Boolean = Not String.IsNullOrEmpty(lblHomeTeamPoints2.Text) AndAlso IsNumeric(lblHomeTeamPoints2.Text) AndAlso CInt(lblHomeTeamPoints2.Text) > 0 OrElse
                                        Not String.IsNullOrEmpty(lblAwayTeamPoints2.Text) AndAlso IsNumeric(lblAwayTeamPoints2.Text) AndAlso CInt(lblAwayTeamPoints2.Text) > 0

        ' Determine if there are points in the 1st labels
        Dim hasPointsIn1st As Boolean = Not String.IsNullOrEmpty(lblHomeTeamPoints1.Text) AndAlso IsNumeric(lblHomeTeamPoints1.Text) AndAlso CInt(lblHomeTeamPoints1.Text) > 0 OrElse
                                        Not String.IsNullOrEmpty(lblAwayTeamPoints1.Text) AndAlso IsNumeric(lblAwayTeamPoints1.Text) AndAlso CInt(lblAwayTeamPoints1.Text) > 0

        ' Determine the graphics title based on the points
        If hasPointsIn3rd Then
            ' Points in either 3rd label
            showhide_sets.SET_2_ON(nametemplate)
            showhide_sets.SET_3_ON(nametemplate)
        ElseIf hasPointsIn2nd Then
            ' Points only in 2nd labels and not in 3rd
            showhide_sets.SET_2_ON(nametemplate)
            showhide_sets.SET_3_OFF(nametemplate)
        ElseIf hasPointsIn1st Then
            ' Points only in 1st labels and not in 2nd or 3rd
            showhide_sets.SET_2_OFF(nametemplate)
            showhide_sets.SET_3_OFF(nametemplate)
        Else
            ' No points in any labels
            showhide_sets.SET_2_OFF(nametemplate)
            showhide_sets.SET_3_OFF(nametemplate)
        End If
        Update_vMix.Update_large_result_Points(nametemplate)


        If LargeResultON = False Then
            sendstring = Update_vMix.BuildVmixInputCommand("OverlayInput1IN", nametemplate)
            Update_vMix.VTX(sendstring)
            LargeResultON = True
            btn_large_result.BackColor = Color.Red
        Else
            sendstring = "Function=OverlayInput1Out"
            Update_vMix.VTX(sendstring)
            ClearButtonONVariables()
            ClearRedButtons()
        End If
    End Sub

    Private Sub btn_playout_Click(sender As Object, e As EventArgs) Handles btn_playout.Click
        Dim nametemplate1 As String = Getgtzip(frmSettings.TextBox32.Text)
        ClearRedButtons()

        If InfoTitle = False Then
            sendstring = Update_vMix.BuildVmixInputCommand("OverlayInput1IN", nametemplate1)
            Update_vMix.VTX(sendstring)
            InfoTitle = True
            btn_playout.BackColor = Color.Red
        Else
            sendstring = "Function=OverlayInput1Out"
            Update_vMix.VTX(sendstring)
            ClearButtonONVariables()
            ClearRedButtons()
        End If
    End Sub

    Private Sub ListBox5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox5.Click
        ListBox5.Items.Clear()
    End Sub

    Private Sub ToolStripStatusLabel4_Click(sender As Object, e As EventArgs) Handles ToolStripStatusLabel4.Click
        If ListBox5.Visible = True Then
            ListBox5.Visible = False
        Else
            ListBox5.Visible = True
            ListBox5.BringToFront()
        End If
    End Sub

    Private Sub btn_Info_Home_Click(sender As Object, e As EventArgs) Handles btn_Info_Home.Click
        If frmSettings.CheckBox2.Checked = False Then
            If TextOnSecondLine = True Then
                If SecondLineON = False Then
                    Dim nametemplate1 As String = Getgtzip(frmSettings.TextBox12.Text)
                    sendstring = Update_vMix.BuildVmixCommand("TitleBeginAnimation", nametemplate1, "Page1")
                    Update_vMix.VTX(sendstring)
                    btn_Info_Home.BackColor = Color.Red
                    SecondLineON = True
                Else
                    sendstring = "Function=OverlayInput1Out"
                    Update_vMix.VTX(sendstring)
                    ClearButtonONVariables()
                    ClearRedButtons()
                    lbl_Info_Age_Home.Text = ""
                    lbl_Info_Height_Home.Text = ""
                    lbl_Info_Age_Away.Text = ""
                    lbl_Info_Height_Away.Text = ""
                End If
            End If
        End If
    End Sub

    Private Sub btn_Info_Away_Click(sender As Object, e As EventArgs) Handles btn_Info_Away.Click
        If frmSettings.CheckBox2.Checked = False Then
            If TextOnSecondLine = True Then
                If SecondLineON = False Then
                    Dim nametemplate1 As String = Getgtzip(frmSettings.TextBox12.Text)
                    sendstring = Update_vMix.BuildVmixCommand("TitleBeginAnimation", nametemplate1, "Page1")
                    Update_vMix.VTX(sendstring)
                    btn_Info_Away.BackColor = Color.Red
                    SecondLineON = True
                Else
                    sendstring = "Function=OverlayInput1Out"
                    Update_vMix.VTX(sendstring)
                    ClearButtonONVariables()
                    ClearRedButtons()
                    lbl_Info_Age_Home.Text = ""
                    lbl_Info_Height_Home.Text = ""
                    lbl_Info_Age_Away.Text = ""
                    lbl_Info_Height_Away.Text = ""
                End If
            End If
        End If
    End Sub

    Private Sub btn_advertising1_Click(sender As Object, e As EventArgs) Handles btn_advertising1.Click, btn_advertising2.Click, btn_advertising3.Click, btn_advertising4.Click
        Dim nametemplate1 As String = ""
        ClearRedButtons()
        Dim stopwatch As Stopwatch = Stopwatch.StartNew()
        ' Determine which button was clicked
        Dim button As Button = DirectCast(sender, Button)
        ' Initialize TextBox based on the button clicked
        Select Case button.Name
            Case "btn_advertising1"
                nametemplate1 = Getgtzip(frmSettings.TextBox33.Text)
                btn_advertising1.BackColor = Color.Red
            Case "btn_advertising2"
                nametemplate1 = Getgtzip(frmSettings.TextBox34.Text)
                btn_advertising2.BackColor = Color.Red
            Case "btn_advertising3"
                nametemplate1 = Getgtzip(frmSettings.TextBox35.Text)
                btn_advertising3.BackColor = Color.Red
            Case "btn_advertising4"
                nametemplate1 = Getgtzip(frmSettings.TextBox36.Text)
                btn_advertising4.BackColor = Color.Red
            Case Else
                ' If no matching button is found, exit the subroutine
                MessageBox.Show("No matching button found", "Error25", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
        End Select
        Dim overlay As String = ""

        If frmSettings.CheckBox1.Checked = False Then overlay = "2"
        If frmSettings.CheckBox1.Checked = True Then overlay = "1"

        If AdvertisingON = False Then
            sendstring = Update_vMix.BuildVmixInputCommand("OverlayInput" & overlay & "IN", nametemplate1)
            Update_vMix.VTX(sendstring)
            AdvertisingON = True
        Else
            sendstring = "Function=OverlayInput" + overlay + "Out"
            Update_vMix.VTX(sendstring)
            ClearButtonONVariables()
            ClearRedButtons()
        End If
    End Sub
    Public Sub LoadAdvertisingbuttonText()
        btn_advertising1.Text = GetFilenameOnly(frmSettings.TextBox33.Text)
        btn_advertising2.Text = GetFilenameOnly(frmSettings.TextBox34.Text)
        btn_advertising3.Text = GetFilenameOnly(frmSettings.TextBox35.Text)
        btn_advertising4.Text = GetFilenameOnly(frmSettings.TextBox36.Text)
    End Sub

    ' Ereignishandler für den Reset Button
    Private Sub btnResetGame_Click(sender As Object, e As EventArgs) Handles btnResetGame.Click
        ResetGame()
        update_vMix_Class()
        lbl_resetscore_nextset.BackColor = SystemColors.Control
    End Sub

    Private Sub btn_ref1_Click(sender As Object, e As EventArgs) Handles btn_ref1.Click, btn_ref2.Click, btn_ref3.Click, btn_ref4.Click
        Dim nametemplate1 As String = Getgtzip(frmSettings.TextBox19.Text)
        ClearRedButtons()
        ' Determine which button was clicked
        Dim button As Button = DirectCast(sender, Button)
        Dim stopwatch As Stopwatch = Stopwatch.StartNew()

        ' Initialize TextBox based on the button clicked
        Dim textBox As TextBox
        Select Case button.Name
            Case "btn_ref1"
                textBox = frmSettings.TextBox7
            Case "btn_ref2"
                textBox = frmSettings.TextBox8
            Case "btn_ref3"
                textBox = frmSettings.TextBox9
            Case "btn_ref4"
                textBox = frmSettings.TextBox10
            Case Else
                ' If no matching button is found, exit the subroutine
                MessageBox.Show("No matching button found", "Error26", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
        End Select

        ' Get the text from the associated TextBox
        Dim fullText As String = textBox.Text.Trim()

        ' Initialize line1 and line2
        Dim line1 As String
        Dim line2 As String

        ' Check if the text contains a comma
        If fullText.Contains(",") Then
            ' Split the text at the comma
            Dim parts() As String = fullText.Split(New Char() {","c}, 2)
            line1 = parts(0).Trim()
            line2 = parts(1).Trim()
        Else
            ' If no comma, assign full text to line1 and set line2 to an empty string
            line1 = fullText
            line2 = String.Empty
        End If

        If FreenameON = False Then
            ' Display the lines
            sendstring = Update_vMix.BuildVmixSetCommand("SetText", nametemplate1, "NAME1.Text", line1)
            Update_vMix.VTX(sendstring)
            If line2 <> String.Empty Then
                sendstring = Update_vMix.BuildVmixSetCommand("SetText", nametemplate1, "NAME2.Text", line2)
                Update_vMix.VTX(sendstring)
            End If
            ' Show the graphics and set the clicked button's background to red
            sendstring = Update_vMix.BuildVmixInputCommand("OverlayInput1IN", nametemplate1)
            Update_vMix.VTX(sendstring)
            FreenameON = True
            button.BackColor = Color.Red ' Set only the clicked button's color
        Else
            ' Hide the graphics and reset all button colors to default
            sendstring = "Function=OverlayInput1Out"
            Update_vMix.VTX(sendstring)
            ClearButtonONVariables()
            ClearRedButtons()
        End If
    End Sub

    Private Sub TextBox_freename_TextChanged(sender As Object, e As EventArgs) Handles TextBox_freename.DoubleClick
        TextBox_freename.Text = ""
    End Sub




    ' Ereignishandler für den Button, um den ersten Aufschläger zu bestimmen
    Private Sub DetermineServer()
        DetermineFirstServer()
    End Sub

    ' Methode zur Aktualisierung des Spielstands
    Private Sub UpdateScore(scoringTeam As String)
        ' Der aktuelle Aufschläger ist das Team, das den Punkt erzielt hat
        currentServer = scoringTeam
        If currentServer = "HomeTeam" Then lblCurrentServerHome.Text = "serve :" + Home_CountryL : lblCurrentServerAway.Text = ""
        If currentServer = "AwayTeam" Then lblCurrentServerAway.Text = "serve :" + Away_CountryL : lblCurrentServerHome.Text = ""

        ' Satzanzeige aktualisieren
        If homeTeamPoints + awayTeamPoints = 1 Then
            lblCurrentSet.Text = currentSetIndex + 1.ToString()

            ' Falls der Operator den ersten Aufschläger nicht per Klick auf Team-Name/Flagge
            ' festgelegt hat (Standard-Workflow: einfach den ersten Punkt vergeben), gilt das
            ' Team, das den ersten Punkt des Satzes erzielt, als erster Aufschläger - so bleibt
            ' die Satzwechsel-Regel in SwitchServer() auch ohne manuelle Festlegung anwendbar.
            If firstServerOfSet = "none" Then
                firstServerOfSet = scoringTeam
            End If
        End If

        ' Speichern der aktuellen Punkte in den Listen
        homeTeamPointsList(currentSetIndex) = homeTeamPoints
        awayTeamPointsList(currentSetIndex) = awayTeamPoints

        ' Überprüfen, ob der aktuelle Satz beendet ist
        If CheckSetWin() Then
            ' Satz gewonnen, Punkte stehen lassen und setWon auf True setzen
            setWon = True

            ' Aufschlag für den nächsten Satz wechseln
            SwitchServer()

            ' Erhöhung des Satzindex, falls das Spiel nicht beendet ist
            If Not gameEnded Then
                currentSetIndex += 1
            End If

            ' Überprüfen, ob das Spiel beendet ist
            If CheckMatchWin() Then
                gameEnded = True
                If homeTeamSets = 2 Then
                    winnerTeam = "Home"
                ElseIf awayTeamSets = 2 Then
                    winnerTeam = "Away"
                End If
                If winnerTeam = "Home" Then
                    Label_Winnertext.Visible = True
                    Label_Winnertext.Text = "GAME OVER, " & Home_CountryL & " wins"
                Else
                    Label_Winnertext.Visible = True
                    Label_Winnertext.Text = "GAME OVER, " & Away_CountryL & " wins"
                End If
            End If
        End If

        ' Aktualisierung der Anzeige
        UpdateDisplay()
        HighlightWinningSet() ' Aufruf der neuen Methode zum Hervorheben
    End Sub

    ' Methode zur Überprüfung, ob ein Satz gewonnen wurde
    Private Function CheckSetWin() As Boolean
        Dim pointsToWinSet As Integer = setPointsToWin(currentSetIndex)
        If homeTeamPoints >= pointsToWinSet AndAlso homeTeamPoints - awayTeamPoints >= winBy Then
            homeTeamSets += 1
            Return True
        ElseIf awayTeamPoints >= pointsToWinSet AndAlso awayTeamPoints - homeTeamPoints >= winBy Then
            awayTeamSets += 1
            Return True
        End If
        Return False
    End Function

    Private Sub lbl_resetscore_nextset_Click(sender As Object, e As EventArgs) Handles lbl_resetscore_nextset.Click
        lblHomePoints.Text = "0"
        lblAwayPoints.Text = "0"
        lbl_resetscore_nextset.BackColor = SystemColors.Control
        Update_vMix.Scorebug_Points_simple()
        Update_vMix.Scorebug_Points_combined()
        lbl_resetscore_nextset.Visible = False
    End Sub

    Private Sub btn_timeout_Click(sender As Object, e As EventArgs) Handles btn_timeout.Click
        'timeout
        ClearRedButtons()
        If TimeOut = False Then
            Update_vMix.Timeout(True)
            TimeOut = True
            btn_timeout.BackColor = Color.Red
        Else
            Update_vMix.Timeout(False)
            ClearButtonONVariables()
            ClearRedButtons()
        End If
    End Sub


    ' Methode zur Überprüfung, ob das Spiel gewonnen wurde
    Private Function CheckMatchWin() As Boolean
        If homeTeamSets = 2 OrElse awayTeamSets = 2 Then
            Return True
        End If
        Return False
    End Function

    ' Methode zum Zurücksetzen der Punkte für den neuen Satz
    Private Sub ResetPoints()
        homeTeamPoints = 0
        awayTeamPoints = 0

        ' Aktualisierung der Anzeige
        UpdateDisplay()
    End Sub

    ' Methode zum Zurücksetzen des Spiels
    Private Sub ResetGame()
        Dim nametemplate1 As String = Getgtzip(frmSettings.TextBox13.Text)
        Dim nametemplate2 As String = Getgtzip(frmSettings.TextBox14.Text)

        homeTeamPoints = 0
        awayTeamPoints = 0
        homeTeamSets = 0
        awayTeamSets = 0
        currentSetIndex = 0
        currentServer = "none"
        lblGame_ended.Visible = True
        lblGame_ended.Text = "Set first serve! →→→click Flag/Name of Hometeam or Awayteam Flag/Name"

        lblCurrentServerHome.Text = ""
        lblCurrentServerAway.Text = ""
        lblCurrentSet.Text = "1" ' Start bei Satz 1
        currentServerSet = False
        firstServerOfSet = "none"
        lbl_Aufschlag_Home.Text = "" : showhide_serve.serve_home_OFF()
        lbl_Aufschlag_Away.Text = "" : showhide_serve.serve_away_OFF()
        setWon = False
        gameEnded = False
        winnerTeam = "none"
        Label_Winnertext.Text = ""
        Label_Winnertext.Visible = False
        ' Zurücksetzen der Punktelisten
        homeTeamPointsList = New List(Of Integer)({0, 0, 0})
        awayTeamPointsList = New List(Of Integer)({0, 0, 0})
        ' Stack leeren
        gameStateStack.Clear()
        ' Aktualisierung der Anzeige
        UpdateDisplay()

        ' Zurücksetzen der Farben der Labels
        ResetLabelColors()
        RESET_btncolors()
        showhide_sets.SET_2_OFF(nametemplate1)
        showhide_sets.SET_3_OFF(nametemplate1)
        showhide_sets.SET_2_OFF(nametemplate2)
        showhide_sets.SET_3_OFF(nametemplate2)

        ' TIMEOUTTEXT/TIMEOUTBG (btn_timeout, Update_vMix.Timeout) waren bisher nie ausgeblendet -
        ' blieben im Zustand des .gtzip-Templates und waren beim Programmstart im grossen
        ' Titel sichtbar.
        Update_vMix.Timeout(False)

    End Sub

    ' Methode zur Aktualisierung der Anzeige
    Private Sub UpdateDisplay()
        lblHomeTeamSets.Text = homeTeamSets.ToString()
        lblAwayTeamSets.Text = awayTeamSets.ToString()
        Set_Aufschläger_Display()

        ' Satzanzeige aktualisieren, außer das Spiel ist beendet
        If Not gameEnded Then
            lblCurrentSet.Text = currentSetIndex + 1.ToString()
        End If

        ' Anzeige der Punkte für jeden Satz
        lblHomeTeamPoints1.Text = homeTeamPointsList(0).ToString()
        lblHomeTeamPoints2.Text = homeTeamPointsList(1).ToString()
        lblHomeTeamPoints3.Text = homeTeamPointsList(2).ToString()
        lblAwayTeamPoints1.Text = awayTeamPointsList(0).ToString()
        lblAwayTeamPoints2.Text = awayTeamPointsList(1).ToString()
        lblAwayTeamPoints3.Text = awayTeamPointsList(2).ToString()

        lbl_Info_Age_Home.Text = ""
        lbl_Info_Height_Home.Text = ""
        lbl_Info_Age_Away.Text = ""
        lbl_Info_Height_Away.Text = ""
    End Sub

    ' Methode zum Hervorheben des gewonnenen Satzes
    Private Sub HighlightWinningSet()
        ' Alle Farben auf Schwarz setzen
        ResetLabelColors()

        For i As Integer = 0 To currentSetIndex - 1
            If homeTeamPointsList(i) >= setPointsToWin(i) AndAlso homeTeamPointsList(i) - awayTeamPointsList(i) >= winBy Then
                If i = 0 Then
                    lblHomeTeamPoints1.ForeColor = Color.Red
                ElseIf i = 1 Then
                    lblHomeTeamPoints2.ForeColor = Color.Red
                ElseIf i = 2 Then
                    lblHomeTeamPoints3.ForeColor = Color.Red
                End If
            ElseIf awayTeamPointsList(i) >= setPointsToWin(i) AndAlso awayTeamPointsList(i) - homeTeamPointsList(i) >= winBy Then
                If i = 0 Then
                    lblAwayTeamPoints1.ForeColor = Color.Red
                ElseIf i = 1 Then
                    lblAwayTeamPoints2.ForeColor = Color.Red
                ElseIf i = 2 Then
                    lblAwayTeamPoints3.ForeColor = Color.Red
                End If
            End If
        Next
        'update_vMix_Class()
    End Sub

    ' Methode zum Zurücksetzen der Farben der Labels
    Private Sub ResetLabelColors()
        lblHomeTeamPoints1.ForeColor = Color.White
        lblHomeTeamPoints2.ForeColor = Color.White
        lblHomeTeamPoints3.ForeColor = Color.White
        lblAwayTeamPoints1.ForeColor = Color.White
        lblAwayTeamPoints2.ForeColor = Color.White
        lblAwayTeamPoints3.ForeColor = Color.White
    End Sub

    ' Methode zur Bestimmung des ersten Aufschlägers
    Private Sub DetermineFirstServer()
        Dim rnd As New Random()
        If rnd.Next(0, 2) = 0 Then
            currentServer = "HomeTeam"
            lblCurrentServerHome.Text = "HomeTeam"
        Else
            currentServer = "AwayTeam"
            lblCurrentServerHome.Text = "AwayTeam"
        End If
        Set_Aufschläger_Display()
    End Sub

    ' Methode zum Wechsel des Aufschlags nach jedem Satz - Regel: das Team, das im vorigen
    ' Satz NICHT zuerst aufgeschlagen hat, schlägt im nächsten Satz zuerst auf. Muss daher auf
    ' firstServerOfSet basieren (wer den eben beendeten Satz eröffnet hat), nicht auf
    ' currentServer (wer zufällig den letzten Punkt des Satzes gewonnen hat - das kann bei
    ' Rally-Point-Scoring ein völlig anderes Team sein).
    Private Sub SwitchServer()
        If firstServerOfSet = "HomeTeam" Then
            currentServer = "AwayTeam"
        Else
            currentServer = "HomeTeam"
        End If
        ' currentServer ist jetzt der erste Aufschläger des neuen Satzes - merken für den
        ' nächsten Satzwechsel.
        firstServerOfSet = currentServer

        If currentServer = "HomeTeam" Then lblCurrentServerHome.Text = "serve :" + Home_CountryL : lblCurrentServerAway.Text = ""
        If currentServer = "AwayTeam" Then lblCurrentServerAway.Text = "serve :" + Away_CountryL : lblCurrentServerHome.Text = ""

        Set_Aufschläger_Display()
    End Sub

    ' Methode zum Speichern des aktuellen Zustands
    Private Sub SaveGameState()
        Dim state As New GameState With {
            .HomeTeamPoints = homeTeamPoints,
            .AwayTeamPoints = awayTeamPoints,
            .HomeTeamSets = homeTeamSets,
            .AwayTeamSets = awayTeamSets,
            .CurrentSetIndex = currentSetIndex,
            .CurrentServer = currentServer,
            .FirstServerOfSet = firstServerOfSet,
            .HomeTeamPointsList = New List(Of Integer)(homeTeamPointsList),
            .AwayTeamPointsList = New List(Of Integer)(awayTeamPointsList),
            .SetWon = setWon,
            .GameEnded = gameEnded
        }
        gameStateStack.Push(state)
    End Sub

    ' Methode zum Wiederherstellen des letzten Zustands
    Private Sub Undo()
        If gameStateStack.Count > 0 Then
            Dim state As GameState = gameStateStack.Pop()
            homeTeamPoints = state.HomeTeamPoints
            awayTeamPoints = state.AwayTeamPoints
            homeTeamSets = state.HomeTeamSets
            awayTeamSets = state.AwayTeamSets
            currentSetIndex = state.CurrentSetIndex
            currentServer = state.CurrentServer
            firstServerOfSet = state.FirstServerOfSet
            homeTeamPointsList = New List(Of Integer)(state.HomeTeamPointsList)
            awayTeamPointsList = New List(Of Integer)(state.AwayTeamPointsList)
            setWon = state.SetWon
            gameEnded = state.GameEnded
            UpdateDisplay()
            ' Fehlte bisher - UpdateScore() ruft nach jedem Punkt sowohl UpdateDisplay() als
            ' auch HighlightWinningSet() auf, Undo() nur ersteres. Ohne diesen Aufruf blieb die
            ' rote Gewinner-Einfärbung eines Satzes stehen, selbst wenn der Undo den Punktestand
            ' wieder unter die Gewinnschwelle brachte (z.B. 21:0 -> Undo -> 20:0).
            HighlightWinningSet()
            lblGame_ended.Visible = False
            lblGame_ended.Text = ""

        End If
    End Sub

    ' Klasse zur Speicherung des Spielzustands
    Private Class GameState
        Public Property HomeTeamPoints As Integer
        Public Property AwayTeamPoints As Integer
        Public Property HomeTeamSets As Integer
        Public Property AwayTeamSets As Integer
        Public Property CurrentSetIndex As Integer
        Public Property CurrentServer As String
        Public Property FirstServerOfSet As String
        Public Property HomeTeamPointsList As List(Of Integer)
        Public Property AwayTeamPointsList As List(Of Integer)
        Public Property SetWon As Boolean
        Public Property GameEnded As Boolean
    End Class

    Private Sub lbl_Name_Home_Click(sender As Object, e As EventArgs) Handles lbl_Name_Home.Click, PictureBox4.Click, PictureBox_Flag_Home.Click, lbl_Players_Home.Click, lbl_Aufschlag_Home.Click

        If currentServerSet = False Then
            currentServer = "HomeTeam"
            firstServerOfSet = "HomeTeam"
            lblGame_ended.Text = ""
            lblGame_ended.Visible = False
            lblCurrentServerHome.Text = "serve: " + Home_CountryL
            lblCurrentServerAway.Text = ""
            Set_Aufschläger_Display()
            currentServerSet = True
        End If
    End Sub

    Private Sub lbl_Name_Away_Click(sender As Object, e As EventArgs) Handles lbl_Name_Away.Click, PictureBox5.Click, PictureBox_Flag_Away.Click, lbl_Players_Away.Click, lbl_Aufschlag_Away.Click
        If currentServerSet = False Then
            currentServer = "AwayTeam"
            firstServerOfSet = "AwayTeam"
            lblGame_ended.Text = ""
            lblGame_ended.Visible = False
            lblCurrentServerHome.Text = ""
            lblCurrentServerAway.Text = "serve: " + Away_CountryL
            Set_Aufschläger_Display()
            currentServerSet = True
        End If
    End Sub

    Private Sub Set_Aufschläger_Display()

        If currentServer <> "none" Then
            'lblCurrentServerHome.Font = New Font("Segoe UI", 12, FontStyle.Bold)
            'lblCurrentServerHome.ForeColor = Color.Black
            'lblCurrentServerHome.Text = "serve: " + currentServer
            If currentServer = "HomeTeam" Then
                lbl_Aufschlag_Home.Text = "►" : showhide_serve.serve_home_ON()
                lbl_Aufschlag_Away.Text = "" : showhide_serve.serve_away_OFF()
                lblCurrentServerHome.Text = "serve: " + Home_CountryL
                lblCurrentServerAway.Text = ""
            End If

            If currentServer = "AwayTeam" Then
                lbl_Aufschlag_Home.Text = "" : showhide_serve.serve_home_OFF()
                lbl_Aufschlag_Away.Text = "►" : showhide_serve.serve_away_ON()
                lblCurrentServerHome.Text = ""
                lblCurrentServerAway.Text = "serve: " + Away_CountryL
            End If
        End If
        If CheckMatchWin() Then
            lbl_Aufschlag_Home.Text = "" : showhide_serve.serve_home_OFF()
            lbl_Aufschlag_Away.Text = "" : showhide_serve.serve_away_OFF()
            lblCurrentServerHome.Text = ""
            lblCurrentServerAway.Text = ""
        End If
    End Sub

    Private Sub btnUndo_Click(sender As Object, e As EventArgs) Handles btnUndo.Click
        Undo()
        update_vMix_Class()
    End Sub

    Public Sub FlaggeHome()
        ' Check if the directory exists
        If Directory.Exists(flagDirectory) Then
            ' Check if the flag image file exists for the home country
            Dim flagFileA As String = flagDirectory + "\" + Home_CountryS + ".png"
            If File.Exists(flagFileA) Then
                ' Flag image exists, store the path in Flagge_Home variable
                Home_Flagge = flagFileA
                PictureBox_Flag_Home.Image = Image.FromFile(Home_Flagge)
                PictureBox_Flag_Home_small.Image = Image.FromFile(Home_Flagge)
            Else
                ' Flag image does not exist, set Flagge_Home to an empty string
                Home_Flagge = ""
                MsgBox("flag " + Home_Flagge + " not found")
            End If
        Else
            ' Flag directory does not exist, set Flagge_Home to an empty string
            MsgBox("flagdirectory " + flagDirectory + " does not exist")
            Away_Flagge = ""
        End If
    End Sub

    Public Sub FlaggeAway()
        ' Check if the directory exists
        If Directory.Exists(flagDirectory) Then
            ' Check if the flag image file exists for the home country
            Dim flagFileA As String = flagDirectory + "\" + Away_CountryS + ".png"
            If File.Exists(flagFileA) Then
                ' Flag image exists, store the path in Flagge_Home variable
                Away_Flagge = flagFileA
                PictureBox_Flag_Away.Image = Image.FromFile(Away_Flagge)
                PictureBox_Flag_Away_small.Image = Image.FromFile(Away_Flagge)
            Else
                ' Flag image does not exist, set Flagge_Home to an empty string
                Away_Flagge = ""
                MsgBox("flag " + Away_Flagge + " not found")
            End If
        Else
            ' Flag directory does not exist, set Flagge_Home to an empty string
            MsgBox("flagdirectory " + flagDirectory + " does not exist")
            Away_Flagge = ""
        End If
    End Sub

    Private Sub BeachVolleyballScorer_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        lbl_Players_Home.Text = Home_First_Name1.Substring(0, 1) + ". " + Home_NAME1 + " / " + Home_First_Name2.Substring(0, 1) + ". " + Home_NAME2
        lbl_Players_Away.Text = Away_First_Name1.Substring(0, 1) + ". " + Away_NAME1 + " / " + Away_First_Name2.Substring(0, 1) + ". " + Away_NAME2
    End Sub

    Public Sub LoadGtzipTitles()
        ' Version getdata from vMix
        Dim stopwatch As Stopwatch = Stopwatch.StartNew()
        ' API URL
        Dim apiUrl As String = "http://" & IP & ":" & PORT.ToString() & "/api/?"
        Dim maxRetries As Integer = 1
        Dim retryDelay As Integer = 2000 ' 2 seconds
        Dim currentAttempt As Integer = 0
        Dim success As Boolean = False
        While currentAttempt < maxRetries And Not success
            Try
                ' Laden der API-Daten
                Dim xmlData As String = String.Empty
                Dim request As HttpWebRequest = CType(WebRequest.Create(apiUrl), HttpWebRequest)
                request.Method = "GET"
                request.Timeout = 2000  ' 2 seconds timeout

                Using response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
                    Using reader As New StreamReader(response.GetResponseStream())
                        xmlData = reader.ReadToEnd()
                    End Using
                End Using
                ' XML-Daten analysieren
                Dim xmlDoc As New XmlDocument()
                xmlDoc.LoadXml(xmlData)
                ' Liste für die Titelnamen mit der Endung ".gtzip"
                Dim gtzipTitles As New List(Of String)()

                ' Alle <input> Knoten durchsuchen
                Dim inputNodes As XmlNodeList = xmlDoc.SelectNodes("//input")
                For Each inputNode As XmlNode In inputNodes
                    Dim title As String = inputNode.Attributes("title").Value
                    If title.EndsWith(".gtzip") Then
                        gtzipTitles.Add(title)
                    End If
                Next
                ' ListBox bereinigen und die gefilterten Titelnamen hinzufügen
                frmSettings.ListBox5.Items.Clear()
                For Each title As String In gtzipTitles
                    frmSettings.ListBox5.Items.Add(title)
                Next
                success = True
            Catch ex As WebException
                MessageBox.Show($"Error getting vMix Data (vMix running?): {ex.Message}", "Error27", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If currentAttempt < maxRetries - 1 Then
                    Thread.Sleep(retryDelay)
                End If
            Catch ex As Exception
                MessageBox.Show($"Error getting vMix Data (vMix running?): {ex.Message}", "Error28", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit While
            End Try
            currentAttempt += 1
        End While
        stopwatch.Stop()
        Dim elapsedTicks As Long = stopwatch.ElapsedTicks
        Dim elapsedTime As Double = stopwatch.Elapsed.TotalMilliseconds
        ListBox5.Items.Add($" Read Titles, fill Listbox {elapsedTime:F3} ms ")
        Update_vMix.SetTitles()
    End Sub




    ' Prüft die vMix-Erreichbarkeit über das aktuell gewählte Protokoll (Update_vMix.CurrentSender)
    ' statt - wie zuvor - über einen rohen TcpClient.Connect auf PORT (8088, dem HTTP-Port).
    ' Das testete weder die echte TCP-API (TcpPort/8099) noch den tatsächlichen HTTP-Sendepfad,
    ' es prüfte nur, ob irgendein TCP-Server auf 8088 lauscht.
    Private Sub CheckConnection()
        vMixconnectivity = Update_vMix.CheckVmixConnection()
        If vMixconnectivity Then
            ToolStripStatusLabel7.Text = "vmix connected"
            ToolStripStatusLabel7.BackColor = Color.LightGreen
            ToolStripStatusLabel1.Text = IP
            ToolStripStatusLabel1.BackColor = SystemColors.Control
            BeachVolley_Main.Label5.Text = "vMix found at IP address " & IP
        Else
            ToolStripStatusLabel7.Text = "vmix not running"
            ToolStripStatusLabel7.BackColor = Color.IndianRed
        End If
    End Sub

    'Public Function FileName(filePath As String) As String
    '    ' Find the last backslash in the path
    '    Dim lastBackslashIndex As Integer = filePath.LastIndexOf("\")
    '    ' Return the substring that starts right after the last backslash
    '    Return filePath.Substring(lastBackslashIndex + 1)
    'End Function

    Private Shared Function Getgtzip(filePath As String) As String
        ' Find the last backslash in the path
        Dim lastBackslashIndex As Integer = filePath.LastIndexOf("\")
        ' Return the substring that starts right after the last backslash
        Return filePath.Substring(lastBackslashIndex + 1)
    End Function

    Private Function GetFilenameOnly(filePath As String) As String
        ' Use Path.GetFileNameWithoutExtension to extract the filename without extension
        Dim fileName As String = System.IO.Path.GetFileNameWithoutExtension(filePath)
        Return fileName
    End Function

    Private Sub UpdatePoints()
        ' Prüfen und aktualisieren der Punkte für jedes Team basierend auf den Sets und Punkten in den Labels

        ' Satz 1
        Dim homePoints1 As Integer = If(Integer.TryParse(lblHomeTeamPoints1.Text, Nothing), Convert.ToInt32(lblHomeTeamPoints1.Text), 0)
        Dim awayPoints1 As Integer = If(Integer.TryParse(lblAwayTeamPoints1.Text, Nothing), Convert.ToInt32(lblAwayTeamPoints1.Text), 0)

        ' Satz 2
        Dim homePoints2 As Integer = If(Integer.TryParse(lblHomeTeamPoints2.Text, Nothing), Convert.ToInt32(lblHomeTeamPoints2.Text), 0)
        Dim awayPoints2 As Integer = If(Integer.TryParse(lblAwayTeamPoints2.Text, Nothing), Convert.ToInt32(lblAwayTeamPoints2.Text), 0)

        ' Satz 3
        Dim homePoints3 As Integer = If(Integer.TryParse(lblHomeTeamPoints3.Text, Nothing), Convert.ToInt32(lblHomeTeamPoints3.Text), 0)
        Dim awayPoints3 As Integer = If(Integer.TryParse(lblAwayTeamPoints3.Text, Nothing), Convert.ToInt32(lblAwayTeamPoints3.Text), 0)

        ' Bestimmen, welcher Satz aktuell gespielt wird
        Dim homeSets As Integer = If(Integer.TryParse(lblHomeTeamSets.Text, Nothing), Convert.ToInt32(lblHomeTeamSets.Text), 0)
        Dim awaySets As Integer = If(Integer.TryParse(lblAwayTeamSets.Text, Nothing), Convert.ToInt32(lblAwayTeamSets.Text), 0)
        Dim currentSet As Integer = homeSets + awaySets + 1

        ' Prüfen, ob das Spiel vorbei ist (ein Team hat 2 Sätze gewonnen)
        If homeSets >= 2 OrElse awaySets >= 2 Then
            lblHomePoints.Text = homePoints3.ToString()
            lblAwayPoints.Text = awayPoints3.ToString()
            Return
        End If

        ' Aktualisierung der Punkteanzeige basierend auf den aktuellen Sätzen
        Select Case currentSet
            Case 1
                lblHomePoints.Text = homePoints1.ToString()
                lblAwayPoints.Text = awayPoints1.ToString()
            Case 2
                If homePoints2 = 0 AndAlso awayPoints2 = 0 Then
                    ' Wenn der Satz noch nicht begonnen hat, bleiben die Punkte des ersten Satzes
                    lblHomePoints.Text = homePoints1.ToString()
                    lblAwayPoints.Text = awayPoints1.ToString()
                Else
                    lblHomePoints.Text = homePoints2.ToString()
                    lblAwayPoints.Text = awayPoints2.ToString()
                End If
            Case 3
                If homePoints3 = 0 AndAlso awayPoints3 = 0 Then
                    ' Wenn der Satz noch nicht begonnen hat, bleiben die Punkte des zweiten Satzes
                    lblHomePoints.Text = homePoints2.ToString()
                    lblAwayPoints.Text = awayPoints2.ToString()
                Else
                    lblHomePoints.Text = homePoints3.ToString()
                    lblAwayPoints.Text = awayPoints3.ToString()
                End If
            Case Else
                ' Hier könnten weitere Fälle für zusätzliche Sätze implementiert werden
        End Select
    End Sub

    ' Annahme: Ein Event-Handler für Änderungen in den Punkte-Labels
    Private Sub PointsLabels_TextChanged(sender As Object, e As EventArgs) Handles _
    lblHomeTeamPoints1.TextChanged, lblHomeTeamPoints2.TextChanged, lblHomeTeamPoints3.TextChanged,
    lblAwayTeamPoints1.TextChanged, lblAwayTeamPoints2.TextChanged, lblAwayTeamPoints3.TextChanged
        UpdatePoints()
    End Sub

    ' Annahme: Ein Event-Handler für Änderungen in den Sets-Labels (z.B. nach einem Satzgewinn)
    Private Sub SetsLabels_TextChanged(sender As Object, e As EventArgs) Handles lblHomeTeamSets.TextChanged, lblAwayTeamSets.TextChanged
        ' Überprüfen, wer den Satz gewonnen hat
        Dim homeSets As Integer = If(Integer.TryParse(lblHomeTeamSets.Text, Nothing), Convert.ToInt32(lblHomeTeamSets.Text), 0)
        Dim awaySets As Integer = If(Integer.TryParse(lblAwayTeamSets.Text, Nothing), Convert.ToInt32(lblAwayTeamSets.Text), 0)
        If frmSettings.CheckBox5.Checked = True Then lbl_resetscore_nextset.BackColor = Color.Red
        lbl_resetscore_nextset.Visible = True

        ' Nach einem Satzgewinn die Punkte aktualisieren
        UpdatePoints()
    End Sub



End Class

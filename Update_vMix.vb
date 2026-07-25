Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports System.Threading
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Button

Public Class Update_vMix
    Public Shared sendstring As String = ""
    Public Shared httpClient As New HttpClient()

    Public Shared Sub Playername(who As String)
        'Home_NAME1, Home_First_Name1, Home_Age1, Home_Height1, Home_Data1_1, Home_Data2_1, Home_Fact1, Home_Fact2
        Dim secondline As String = ""
        Dim secondline1 As String = ""
        Dim secondline2 As String = ""
        Dim spacing As String = "  "
        Dim nametemplate1 As String = Getgtzip(frmSettings.TextBox11.Text)
        Dim nametemplate2 As String = Getgtzip(frmSettings.TextBox12.Text)
        If who = "H1" Then

            Dim stopwatch As Stopwatch = Stopwatch.StartNew()
            sendstring = BuildVmixSetCommand("SetText", nametemplate1, "NAME1.Text", BeachVolleyballScorer.Home_First_Name1 & " " & BeachVolleyballScorer.Home_NAME1)
            VTX(sendstring)
            sendstring = BuildVmixSetCommand("SetImage", nametemplate1, "FLAG.Source", BeachVolleyballScorer.Home_Flagge)
            VTX(sendstring)
            sendstring = BuildVmixSetCommand("SetText", nametemplate2, "NAME1.Text", BeachVolleyballScorer.Home_First_Name1 & " " & BeachVolleyballScorer.Home_NAME1)
            VTX(sendstring)
            If BeachVolleyballScorer.Home_Age1 = "" Then
                secondline1 = ""
                spacing = ""
            Else
                secondline1 = "Age " + BeachVolleyballScorer.Home_Age1
                spacing = "  "
            End If

            If BeachVolleyballScorer.Home_Height1 = "" Then
                secondline2 = ""
                spacing = ""
            Else
                secondline2 = "Height " + BeachVolleyballScorer.Home_Height1
                spacing = "  "
            End If

            sendstring = BuildVmixSetCommand("SetText", nametemplate2, "NAME2.Text", secondline1 & spacing & secondline2)
            VTX(sendstring)
            sendstring = BuildVmixSetCommand("SetImage", nametemplate2, "FLAG.Source", BeachVolleyballScorer.Home_Flagge)
            VTX(sendstring)
            stopwatch.Stop()
            Dim elapsedTicks As Long = stopwatch.ElapsedTicks
            Dim elapsedTime As Double = stopwatch.Elapsed.TotalMilliseconds
            BeachVolleyballScorer.ListBox5.Items.Add($" Playername H1 took {elapsedTime:F3} ms ")
        ElseIf who = "H2" Then
            Dim stopwatch As Stopwatch = Stopwatch.StartNew()

            sendstring = BuildVmixSetCommand("SetText", nametemplate1, "NAME1.Text", BeachVolleyballScorer.Home_First_Name2 & " " & BeachVolleyballScorer.Home_NAME2)
            VTX(sendstring)
            sendstring = BuildVmixSetCommand("SetImage", nametemplate1, "FLAG.Source", BeachVolleyballScorer.Home_Flagge)
            VTX(sendstring)
            sendstring = BuildVmixSetCommand("SetText", nametemplate2, "NAME1.Text", BeachVolleyballScorer.Home_First_Name2 & " " & BeachVolleyballScorer.Home_NAME2)
            VTX(sendstring)
            If BeachVolleyballScorer.Home_Age2 = "" Then
                secondline1 = ""
                spacing = ""
            Else
                secondline1 = "Age " + BeachVolleyballScorer.Home_Age2
                spacing = "  "
            End If

            If BeachVolleyballScorer.Home_Height2 = "" Then
                secondline2 = ""
                spacing = ""
            Else
                secondline2 = "Height " + BeachVolleyballScorer.Home_Height2
                spacing = "  "
            End If

            sendstring = BuildVmixSetCommand("SetText", nametemplate2, "NAME2.Text", secondline1 & spacing & secondline2)
            VTX(sendstring)
            sendstring = BuildVmixSetCommand("SetImage", nametemplate2, "FLAG.Source", BeachVolleyballScorer.Home_Flagge)
            VTX(sendstring)
            stopwatch.Stop()
            Dim elapsedTicks As Long = stopwatch.ElapsedTicks
            Dim elapsedTime As Double = stopwatch.Elapsed.TotalMilliseconds
            BeachVolleyballScorer.ListBox5.Items.Add($" Playername H2 took {elapsedTime:F3} ms ")

        ElseIf who = "A1" Then
            Dim stopwatch As Stopwatch = Stopwatch.StartNew()
            sendstring = BuildVmixSetCommand("SetText", nametemplate1, "NAME1.Text", BeachVolleyballScorer.Away_First_Name1 & " " & BeachVolleyballScorer.Away_NAME1)
            VTX(sendstring)
            sendstring = BuildVmixSetCommand("SetImage", nametemplate1, "FLAG.Source", BeachVolleyballScorer.Away_Flagge)
            VTX(sendstring)
            sendstring = BuildVmixSetCommand("SetText", nametemplate2, "NAME1.Text", BeachVolleyballScorer.Away_First_Name1 & " " & BeachVolleyballScorer.Away_NAME1)
            VTX(sendstring)
            If BeachVolleyballScorer.Away_Age1 = "" Then
                secondline1 = ""
                spacing = ""
            Else
                secondline1 = "Age " + BeachVolleyballScorer.Away_Age1
                spacing = "  "
            End If

            If BeachVolleyballScorer.Away_Height1 = "" Then
                secondline2 = ""
                spacing = ""
            Else
                secondline2 = "Height " + BeachVolleyballScorer.Away_Height1
                spacing = "  "
            End If

            sendstring = BuildVmixSetCommand("SetText", nametemplate2, "NAME2.Text", secondline1 & spacing & secondline2)
            VTX(sendstring)
            sendstring = BuildVmixSetCommand("SetImage", nametemplate2, "FLAG.Source", BeachVolleyballScorer.Away_Flagge)
            VTX(sendstring)
            stopwatch.Stop()
            Dim elapsedTicks As Long = stopwatch.ElapsedTicks
            Dim elapsedTime As Double = stopwatch.Elapsed.TotalMilliseconds
            BeachVolleyballScorer.ListBox5.Items.Add($" Playername A2 took {elapsedTime:F3} ms ")
        ElseIf who = "A2" Then
            Dim stopwatch As Stopwatch = Stopwatch.StartNew()

            sendstring = BuildVmixSetCommand("SetText", nametemplate1, "NAME1.Text", BeachVolleyballScorer.Away_First_Name2 & " " & BeachVolleyballScorer.Away_NAME2)
            VTX(sendstring)
            sendstring = BuildVmixSetCommand("SetImage", nametemplate1, "FLAG.Source", BeachVolleyballScorer.Away_Flagge)
            VTX(sendstring)
            sendstring = BuildVmixSetCommand("SetText", nametemplate2, "NAME1.Text", BeachVolleyballScorer.Away_First_Name2 & " " & BeachVolleyballScorer.Away_NAME2)
            VTX(sendstring)
            If BeachVolleyballScorer.Away_Age2 = "" Then
                secondline1 = ""
                spacing = ""
            Else
                secondline1 = "Age " + BeachVolleyballScorer.Away_Age2
                spacing = "  "
            End If

            If BeachVolleyballScorer.Away_Height2 = "" Then
                secondline2 = ""
                spacing = ""
            Else
                secondline2 = "Height " + BeachVolleyballScorer.Away_Height2
                spacing = "  "
            End If

            sendstring = BuildVmixSetCommand("SetText", nametemplate2, "NAME2.Text", secondline1 & spacing & secondline2)
            VTX(sendstring)
            sendstring = BuildVmixSetCommand("SetImage", nametemplate2, "FLAG.Source", BeachVolleyballScorer.Away_Flagge)
            VTX(sendstring)
            stopwatch.Stop()
            Dim elapsedTicks As Long = stopwatch.ElapsedTicks
            Dim elapsedTime As Double = stopwatch.Elapsed.TotalMilliseconds
            BeachVolleyballScorer.ListBox5.Items.Add($" Playername A2 took {elapsedTime:F3} ms ")
        End If
    End Sub

    Public Shared Sub Teamname(who As String)
        'Home_NAME1, Home_First_Name1, Home_Age1, Home_Height1, Home_Data1_1, Home_Data2_1, Home_Fact1, Home_Fact2
        Dim nametemplate1 As String = Getgtzip(frmSettings.TextBox16.Text)
        If who = "H" Then
            Dim stopwatch As Stopwatch = Stopwatch.StartNew()

            sendstring = BuildVmixSetCommand("SetText", nametemplate1, "NAME1.Text", BeachVolleyballScorer.Home_First_Name1 & " " & BeachVolleyballScorer.Home_NAME1)
            VTX(sendstring)
            sendstring = BuildVmixSetCommand("SetText", nametemplate1, "NAME2.Text", BeachVolleyballScorer.Home_First_Name2 & " " & BeachVolleyballScorer.Home_NAME2)
            VTX(sendstring)
            sendstring = BuildVmixSetCommand("SetText", nametemplate1, "COUNTRY_S.Text", BeachVolleyballScorer.Home_CountryS)
            VTX(sendstring)
            sendstring = BuildVmixSetCommand("SetImage", nametemplate1, "FLAG.Source", BeachVolleyballScorer.Home_Flagge)
            VTX(sendstring)
            stopwatch.Stop()
            Dim elapsedTicks As Long = stopwatch.ElapsedTicks
            Dim elapsedTime As Double = stopwatch.Elapsed.TotalMilliseconds
            BeachVolleyballScorer.ListBox5.Items.Add($" Teamname H took {elapsedTime:F3} ms ")
        ElseIf who = "A" Then
            Dim stopwatch As Stopwatch = Stopwatch.StartNew()
            sendstring = BuildVmixSetCommand("SetText", nametemplate1, "NAME1.Text", BeachVolleyballScorer.Away_First_Name1 & " " & BeachVolleyballScorer.Away_NAME1)
            VTX(sendstring)
            sendstring = BuildVmixSetCommand("SetText", nametemplate1, "NAME2.Text", BeachVolleyballScorer.Away_First_Name2 & " " & BeachVolleyballScorer.Away_NAME2)
            VTX(sendstring)
            sendstring = BuildVmixSetCommand("SetText", nametemplate1, "COUNTRY_S.Text", BeachVolleyballScorer.Away_CountryS)
            VTX(sendstring)
            sendstring = BuildVmixSetCommand("SetImage", nametemplate1, "FLAG.Source", BeachVolleyballScorer.Away_Flagge)
            VTX(sendstring)
            stopwatch.Stop()
            Dim elapsedTicks As Long = stopwatch.ElapsedTicks
            Dim elapsedTime As Double = stopwatch.Elapsed.TotalMilliseconds
            BeachVolleyballScorer.ListBox5.Items.Add($" Teamname A took {elapsedTime:F3} ms ")

        End If
    End Sub
    ' Blendet TIMEOUTTEXT/TIMEOUTBG auf dem Large-Result-Titel (TextBox14) ein oder aus -
    ' verdrahtet mit btn_timeout im Scorer. Normalfarbe (sichtbar) ist #53b1b5d8, zum
    ' Ausblenden wird komplett transparent (#00000000) gesetzt, da Fill.Color-Layer in vMix
    ' keinen eigenen VisibleOn/Off-Befehl unterstützen. Beim Programmstart (ResetGame) wird
    ' show:=False aufgerufen.
    Public Shared Sub Timeout(show As Boolean)
        Dim nametemplate As String = Getgtzip(frmSettings.TextBox14.Text)
        If show Then
            sendstring = BuildVmixSelectCommand("SetTextVisibleOn", nametemplate, "TIMEOUTTEXT.Text")
            VTX(sendstring)
            sendstring = BuildVmixSetCommand("SetColor", nametemplate, "TIMEOUTBG.Fill.Color", "#53b1b5d8")
            VTX(sendstring)
        Else
            sendstring = BuildVmixSelectCommand("SetTextVisibleOff", nametemplate, "TIMEOUTTEXT.Text")
            VTX(sendstring)
            sendstring = BuildVmixSetCommand("SetColor", nametemplate, "TIMEOUTBG.Fill.Color", "#00000000")
            VTX(sendstring)
        End If
    End Sub

    Public Shared Sub SetTitles()
        If frmSettings.CheckBox4.Checked = True Then
            Dim stopwatch As Stopwatch = Stopwatch.StartNew()

            For Each item As String In frmSettings.ListBox5.Items
                If item <> "volley_weather.gtzip" Then
                    Dim sendstring As String = BuildVmixSetCommand("SetText", item, "TITLETEXT.Text", frmSettings.TextBox4.Text)
                    VTX(sendstring)
                End If
            Next
            stopwatch.Stop()
            Dim elapsedTicks As Long = stopwatch.ElapsedTicks
            Dim elapsedTime As Double = stopwatch.Elapsed.TotalMilliseconds
            BeachVolleyballScorer.ListBox5.Items.Add($" Set Titles from list {elapsedTime:F3} ms ")
        End If
    End Sub

    Public Shared Sub SET1_Color_winner()
        Dim stopwatch As Stopwatch = Stopwatch.StartNew()
        Dim nametemplate1 As String = Getgtzip(frmSettings.TextBox13.Text)
        Dim nametemplate2 As String = Getgtzip(frmSettings.TextBox14.Text)
        Dim nametemplate3 As String = Getgtzip(frmSettings.TextBox15.Text)

        'home
        If BeachVolleyballScorer.lblHomeTeamPoints1.ForeColor = Color.Red Then
            sendstring = BuildVmixSetCommand("SetTextColour", nametemplate1, "HOMEPOINTSSET1.Text", "red")
            VTX(sendstring)
            sendstring = BuildVmixSetCommand("SetTextColour", nametemplate2, "HOMEPOINTSSET1.Text", "red")
            VTX(sendstring)
            sendstring = BuildVmixSetCommand("SetTextColour", nametemplate3, "HOMEPOINTSSET1.Text", "red")
            VTX(sendstring)
            stopwatch.Stop()
            Dim elapsedTicks As Long = stopwatch.ElapsedTicks
            Dim elapsedTime As Double = stopwatch.Elapsed.TotalMilliseconds
            BeachVolleyballScorer.ListBox5.Items.Add($" Set red H SET1 {elapsedTime:F3} ms ")

        Else
            sendstring = BuildVmixSetCommand("SetTextColour", nametemplate1, "HOMEPOINTSSET1.Text", "white")
            VTX(sendstring)
            sendstring = BuildVmixSetCommand("SetTextColour", nametemplate2, "HOMEPOINTSSET1.Text", "white")
            VTX(sendstring)
            sendstring = BuildVmixSetCommand("SetTextColour", nametemplate3, "HOMEPOINTSSET1.Text", "white")
            VTX(sendstring)
            stopwatch.Stop()
            Dim elapsedTicks As Long = stopwatch.ElapsedTicks
            Dim elapsedTime As Double = stopwatch.Elapsed.TotalMilliseconds
            BeachVolleyballScorer.ListBox5.Items.Add($"Set white H SET1 {elapsedTime:F3} ms ")

        End If

        If BeachVolleyballScorer.lblHomeTeamPoints2.ForeColor = Color.Red Then
            sendstring = BuildVmixSetCommand("SetTextColour", nametemplate1, "HOMEPOINTSSET2.Text", "red")
            VTX(sendstring)
            sendstring = BuildVmixSetCommand("SetTextColour", nametemplate2, "HOMEPOINTSSET2.Text", "red")
            VTX(sendstring)
            sendstring = BuildVmixSetCommand("SetTextColour", nametemplate3, "HOMEPOINTSSET2.Text", "red")
            VTX(sendstring)
            stopwatch.Stop()
            Dim elapsedTicks As Long = stopwatch.ElapsedTicks
            Dim elapsedTime As Double = stopwatch.Elapsed.TotalMilliseconds
            BeachVolleyballScorer.ListBox5.Items.Add($"Set red H SET2 {elapsedTime:F3} ms ")

        Else
            sendstring = BuildVmixSetCommand("SetTextColour", nametemplate1, "HOMEPOINTSSET2.Text", "white")
            VTX(sendstring)
            sendstring = BuildVmixSetCommand("SetTextColour", nametemplate2, "HOMEPOINTSSET2.Text", "white")
            VTX(sendstring)
            sendstring = BuildVmixSetCommand("SetTextColour", nametemplate3, "HOMEPOINTSSET2.Text", "white")
            VTX(sendstring)
            stopwatch.Stop()
            Dim elapsedTicks As Long = stopwatch.ElapsedTicks
            Dim elapsedTime As Double = stopwatch.Elapsed.TotalMilliseconds
            BeachVolleyballScorer.ListBox5.Items.Add($"Set white H SET2 {elapsedTime:F3} ms ")

        End If

        If BeachVolleyballScorer.lblHomeTeamPoints3.ForeColor = Color.Red Then
            sendstring = BuildVmixSetCommand("SetTextColour", nametemplate1, "HOMEPOINTSSET3.Text", "red")
            VTX(sendstring)
            sendstring = BuildVmixSetCommand("SetTextColour", nametemplate2, "HOMEPOINTSSET3.Text", "red")
            VTX(sendstring)
            sendstring = BuildVmixSetCommand("SetTextColour", nametemplate3, "HOMEPOINTSSET3.Text", "red")
            VTX(sendstring)
            stopwatch.Stop()
            Dim elapsedTicks As Long = stopwatch.ElapsedTicks
            Dim elapsedTime As Double = stopwatch.Elapsed.TotalMilliseconds
            BeachVolleyballScorer.ListBox5.Items.Add($"Set red H SET3 {elapsedTime:F3} ms ")

        Else
            sendstring = BuildVmixSetCommand("SetTextColour", nametemplate1, "HOMEPOINTSSET3.Text", "white")
            VTX(sendstring)
            sendstring = BuildVmixSetCommand("SetTextColour", nametemplate2, "HOMEPOINTSSET3.Text", "white")
            VTX(sendstring)
            sendstring = BuildVmixSetCommand("SetTextColour", nametemplate3, "HOMEPOINTSSET3.Text", "white")
            VTX(sendstring)
            stopwatch.Stop()
            Dim elapsedTicks As Long = stopwatch.ElapsedTicks
            Dim elapsedTime As Double = stopwatch.Elapsed.TotalMilliseconds
            BeachVolleyballScorer.ListBox5.Items.Add($"Set white H SET3 {elapsedTime:F3} ms ")

        End If

        'away
        If BeachVolleyballScorer.lblAwayTeamPoints1.ForeColor = Color.Red Then
            sendstring = BuildVmixSetCommand("SetTextColour", nametemplate1, "AWAYPOINTSSET1.Text", "red")
            VTX(sendstring)
            sendstring = BuildVmixSetCommand("SetTextColour", nametemplate2, "AWAYPOINTSSET1.Text", "red")
            VTX(sendstring)
            sendstring = BuildVmixSetCommand("SetTextColour", nametemplate3, "AWAYPOINTSSET1.Text", "red")
            VTX(sendstring)
            stopwatch.Stop()
            Dim elapsedTicks As Long = stopwatch.ElapsedTicks
            Dim elapsedTime As Double = stopwatch.Elapsed.TotalMilliseconds
            BeachVolleyballScorer.ListBox5.Items.Add($"Set red A SET1 {elapsedTime:F3} ms ")

        Else
            sendstring = BuildVmixSetCommand("SetTextColour", nametemplate1, "AWAYPOINTSSET1.Text", "white")
            VTX(sendstring)
            sendstring = BuildVmixSetCommand("SetTextColour", nametemplate2, "AWAYPOINTSSET1.Text", "white")
            VTX(sendstring)
            sendstring = BuildVmixSetCommand("SetTextColour", nametemplate3, "AWAYPOINTSSET1.Text", "white")
            VTX(sendstring)
            stopwatch.Stop()
            Dim elapsedTicks As Long = stopwatch.ElapsedTicks
            Dim elapsedTime As Double = stopwatch.Elapsed.TotalMilliseconds
            BeachVolleyballScorer.ListBox5.Items.Add($"Set white A SET1 {elapsedTime:F3} ms ")

        End If


        If BeachVolleyballScorer.lblAwayTeamPoints2.ForeColor = Color.Red Then
            sendstring = BuildVmixSetCommand("SetTextColour", nametemplate1, "AWAYPOINTSSET2.Text", "red")
            VTX(sendstring)
            sendstring = BuildVmixSetCommand("SetTextColour", nametemplate2, "AWAYPOINTSSET2.Text", "red")
            VTX(sendstring)
            sendstring = BuildVmixSetCommand("SetTextColour", nametemplate3, "AWAYPOINTSSET2.Text", "red")
            VTX(sendstring)
            stopwatch.Stop()
            Dim elapsedTicks As Long = stopwatch.ElapsedTicks
            Dim elapsedTime As Double = stopwatch.Elapsed.TotalMilliseconds
            BeachVolleyballScorer.ListBox5.Items.Add($"Set red A SET2 {elapsedTime:F3} ms ")

        Else
            sendstring = BuildVmixSetCommand("SetTextColour", nametemplate1, "AWAYPOINTSSET2.Text", "white")
            VTX(sendstring)
            sendstring = BuildVmixSetCommand("SetTextColour", nametemplate2, "AWAYPOINTSSET2.Text", "white")
            VTX(sendstring)
            sendstring = BuildVmixSetCommand("SetTextColour", nametemplate3, "AWAYPOINTSSET2.Text", "white")
            VTX(sendstring)
            stopwatch.Stop()
            Dim elapsedTicks As Long = stopwatch.ElapsedTicks
            Dim elapsedTime As Double = stopwatch.Elapsed.TotalMilliseconds
            BeachVolleyballScorer.ListBox5.Items.Add($"Set white A SET2 {elapsedTime:F3} ms ")

        End If

        If BeachVolleyballScorer.lblAwayTeamPoints3.ForeColor = Color.Red Then
            sendstring = BuildVmixSetCommand("SetTextColour", nametemplate1, "AWAYPOINTSSET3.Text", "red")
            VTX(sendstring)
            sendstring = BuildVmixSetCommand("SetTextColour", nametemplate2, "AWAYPOINTSSET3.Text", "red")
            VTX(sendstring)
            sendstring = BuildVmixSetCommand("SetTextColour", nametemplate3, "AWAYPOINTSSET3.Text", "red")
            VTX(sendstring)
            stopwatch.Stop()
            Dim elapsedTicks As Long = stopwatch.ElapsedTicks
            Dim elapsedTime As Double = stopwatch.Elapsed.TotalMilliseconds
            BeachVolleyballScorer.ListBox5.Items.Add($"Set red A SET3 {elapsedTime:F3} ms ")

        Else
            sendstring = BuildVmixSetCommand("SetTextColour", nametemplate1, "AWAYPOINTSSET3.Text", "white")
            VTX(sendstring)
            sendstring = BuildVmixSetCommand("SetTextColour", nametemplate2, "AWAYPOINTSSET3.Text", "white")
            VTX(sendstring)
            sendstring = BuildVmixSetCommand("SetTextColour", nametemplate3, "AWAYPOINTSSET3.Text", "white")
            VTX(sendstring)
            stopwatch.Stop()
            Dim elapsedTicks As Long = stopwatch.ElapsedTicks
            Dim elapsedTime As Double = stopwatch.Elapsed.TotalMilliseconds
            BeachVolleyballScorer.ListBox5.Items.Add($"Set white A SET3 {elapsedTime:F3} ms ")

        End If
    End Sub

    Public Shared Sub Update_Scorebug_Names()
        Dim stopwatch As Stopwatch = Stopwatch.StartNew()
        Dim nametemplate As String = Getgtzip(frmSettings.TextBox13.Text)

        'home
        sendstring = BuildVmixSetCommand("SetText", nametemplate, "HOMENAME.Text", BeachVolleyballScorer.Home_NAME1 & " / " & BeachVolleyballScorer.Home_NAME2)
        VTX(sendstring)
        sendstring = BuildVmixSetCommand("SetImage", nametemplate, "HOME_FLAG.Source", BeachVolleyballScorer.Home_Flagge)
        VTX(sendstring)

        'away
        sendstring = BuildVmixSetCommand("SetText", nametemplate, "AWAYNAME.Text", BeachVolleyballScorer.Away_NAME1 & " / " & BeachVolleyballScorer.Away_NAME2)
        VTX(sendstring)
        sendstring = BuildVmixSetCommand("SetImage", nametemplate, "AWAY_FLAG.Source", BeachVolleyballScorer.Away_Flagge)
        VTX(sendstring)
        stopwatch.Stop()

        Dim elapsedTicks As Long = stopwatch.ElapsedTicks
        Dim elapsedTime As Double = stopwatch.Elapsed.TotalMilliseconds
        BeachVolleyballScorer.ListBox5.Items.Add($"Update Scorebug Names {elapsedTime:F3} ms ")
    End Sub

    ' Pairing-Präsentation vor dem Spiel (volley_match_id.gtzip, TextBox17) - zeigt volle
    ' Namen (Vorname + Nachname) beider Spieler pro Team, Länderkürzel und Flagge. Wurde beim
    ' ursprünglichen Bau vergessen zu aktualisieren (Peter, 2026); btn_MatchID_Click zeigte den
    ' Titel bisher nur ein/aus, ohne je Daten dafür zu senden. Feldnamen analog zu
    ' Update_Scorebug_Names/Scorebug_Points_simple - falls sie im .gtzip anders heissen, passt
    ' Peter das Template selbst an.
    Public Shared Sub Update_MatchID_Names()
        Dim nametemplate As String = Getgtzip(frmSettings.TextBox17.Text)

        'home
        sendstring = BuildVmixSetCommand("SetText", nametemplate, "HOMENAME.Text", BeachVolleyballScorer.Home_First_Name1 & " " & BeachVolleyballScorer.Home_NAME1 & " / " & BeachVolleyballScorer.Home_First_Name2 & " " & BeachVolleyballScorer.Home_NAME2)
        VTX(sendstring)
        sendstring = BuildVmixSetCommand("SetText", nametemplate, "HOMECOUNTRY_S.Text", BeachVolleyballScorer.Home_CountryS)
        VTX(sendstring)
        sendstring = BuildVmixSetCommand("SetImage", nametemplate, "HOME_FLAG.Source", BeachVolleyballScorer.Home_Flagge)
        VTX(sendstring)

        'away
        sendstring = BuildVmixSetCommand("SetText", nametemplate, "AWAYNAME.Text", BeachVolleyballScorer.Away_First_Name1 & " " & BeachVolleyballScorer.Away_NAME1 & " / " & BeachVolleyballScorer.Away_First_Name2 & " " & BeachVolleyballScorer.Away_NAME2)
        VTX(sendstring)
        sendstring = BuildVmixSetCommand("SetText", nametemplate, "AWAYCOUNTRY_S.Text", BeachVolleyballScorer.Away_CountryS)
        VTX(sendstring)
        sendstring = BuildVmixSetCommand("SetImage", nametemplate, "AWAY_FLAG.Source", BeachVolleyballScorer.Away_Flagge)
        VTX(sendstring)
    End Sub

    Public Shared Sub Update_Scorebug_Points()
        If frmSettings.CheckBox5.Checked Then
            Scorebug_Points_simple()
        ElseIf frmSettings.CheckBox5.Checked And frmSettings.CheckBox6.Checked Then
            Scorebug_Points_combined()
        Else
            Scorebug_Points()
        End If
    End Sub

    Public Shared Sub Scorebug_Points()
        'scorebug with 3 point display and set
        Dim stopwatch As Stopwatch = Stopwatch.StartNew()
        Dim nametemplate As String = Getgtzip(frmSettings.TextBox13.Text)
        'score lower 1. game
        sendstring = BuildVmixSetCommand("SetText", nametemplate, "HOMESETS.Text", BeachVolleyballScorer.homeTeamSets.ToString)
        VTX(sendstring)
        sendstring = BuildVmixSetCommand("SetText", nametemplate, "AWAYSETS.Text", BeachVolleyballScorer.awayTeamSets.ToString)
        VTX(sendstring)
        sendstring = BuildVmixSetCommand("SetText", nametemplate, "HOMEPOINTSSET1.Text", BeachVolleyballScorer.homeTeamPointsList(0).ToString)
        VTX(sendstring)
        sendstring = BuildVmixSetCommand("SetText", nametemplate, "HOMEPOINTSSET2.Text", BeachVolleyballScorer.homeTeamPointsList(1).ToString)
        VTX(sendstring)
        sendstring = BuildVmixSetCommand("SetText", nametemplate, "HOMEPOINTSSET3.Text", BeachVolleyballScorer.homeTeamPointsList(2).ToString)
        VTX(sendstring)
        sendstring = BuildVmixSetCommand("SetText", nametemplate, "AWAYPOINTSSET1.Text", BeachVolleyballScorer.awayTeamPointsList(0).ToString)
        VTX(sendstring)
        sendstring = BuildVmixSetCommand("SetText", nametemplate, "AWAYPOINTSSET2.Text", BeachVolleyballScorer.awayTeamPointsList(1).ToString)
        VTX(sendstring)
        sendstring = BuildVmixSetCommand("SetText", nametemplate, "AWAYPOINTSSET3.Text", BeachVolleyballScorer.awayTeamPointsList(2).ToString)
        VTX(sendstring)


        stopwatch.Stop()
        Dim elapsedTicks As Long = stopwatch.ElapsedTicks
        Dim elapsedTime As Double = stopwatch.Elapsed.TotalMilliseconds
        BeachVolleyballScorer.ListBox5.Items.Add($"Update Scorebug Points {elapsedTime:F3} ms ")

    End Sub

    Public Shared Sub Scorebug_Points_simple()
        Dim stopwatch As Stopwatch = Stopwatch.StartNew()
        Dim nametemplate As String = Getgtzip(frmSettings.TextBox37.Text)

        sendstring = BuildVmixSetCommand("SetText", nametemplate, "HOMESETS.Text", BeachVolleyballScorer.homeTeamSets.ToString)
        VTX(sendstring)
        sendstring = BuildVmixSetCommand("SetText", nametemplate, "AWAYSETS.Text", BeachVolleyballScorer.awayTeamSets.ToString)
        VTX(sendstring)

        sendstring = BuildVmixSetCommand("SetText", nametemplate, "HOMEPOINTS.Text", BeachVolleyballScorer.lblHomePoints.Text)
        VTX(sendstring)
        sendstring = BuildVmixSetCommand("SetText", nametemplate, "AWAYPOINTS.Text", BeachVolleyballScorer.lblAwayPoints.Text)
        VTX(sendstring)

        sendstring = BuildVmixSetCommand("SetText", nametemplate, "HOMECOUNTRY_S.Text", BeachVolleyballScorer.Home_CountryS)
        VTX(sendstring)
        sendstring = BuildVmixSetCommand("SetText", nametemplate, "AWAYCOUNTRY_S.Text", BeachVolleyballScorer.Away_CountryS)
        VTX(sendstring)
        'sendstring = BuildVmixSetCommand("SetImage", nametemplate, "FLAG.Source", BeachVolleyballScorer.Home_Flagge)
        'VTX(sendstring)

        stopwatch.Stop()
        Dim elapsedTicks As Long = stopwatch.ElapsedTicks
        Dim elapsedTime As Double = stopwatch.Elapsed.TotalMilliseconds
        BeachVolleyballScorer.ListBox5.Items.Add($"Update simple scorebug points {elapsedTime:F3} ms ")
    End Sub


    Public Shared Sub Scorebug_Points_combined()
        Dim stopwatch As Stopwatch = Stopwatch.StartNew()
        Dim nametemplate As String = Getgtzip(frmSettings.TextBox38.Text)

        sendstring = BuildVmixSetCommand("SetText", nametemplate, "HOMESETS.Text", BeachVolleyballScorer.homeTeamSets.ToString)
        VTX(sendstring)
        sendstring = BuildVmixSetCommand("SetText", nametemplate, "AWAYSETS.Text", BeachVolleyballScorer.awayTeamSets.ToString)
        VTX(sendstring)
        sendstring = BuildVmixSetCommand("SetText", nametemplate, "HOMESETSL.Text", BeachVolleyballScorer.homeTeamSets.ToString)
        VTX(sendstring)
        sendstring = BuildVmixSetCommand("SetText", nametemplate, "AWAYSETSL.Text", BeachVolleyballScorer.awayTeamSets.ToString)
        VTX(sendstring)
        sendstring = BuildVmixSetCommand("SetText", nametemplate, "HOMEPOINTS.Text", BeachVolleyballScorer.lblHomePoints.Text)
        VTX(sendstring)
        sendstring = BuildVmixSetCommand("SetText", nametemplate, "AWAYPOINTS.Text", BeachVolleyballScorer.lblAwayPoints.Text)
        VTX(sendstring)
        sendstring = BuildVmixSetCommand("SetText", nametemplate, "HOMEPOINTSL.Text", BeachVolleyballScorer.lblHomePoints.Text)
        VTX(sendstring)
        sendstring = BuildVmixSetCommand("SetText", nametemplate, "AWAYPOINTSL.Text", BeachVolleyballScorer.lblAwayPoints.Text)
        VTX(sendstring)

        sendstring = BuildVmixSetCommand("SetText", nametemplate, "HOMENAMEL.Text", BeachVolleyballScorer.lbl_Players_Home.Text)
        VTX(sendstring)
        sendstring = BuildVmixSetCommand("SetText", nametemplate, "AWAYNAMEL.Text", BeachVolleyballScorer.lbl_Players_Away.Text)
        VTX(sendstring)
        sendstring = BuildVmixSetCommand("SetText", nametemplate, "HOMECOUNTRY_S.Text", BeachVolleyballScorer.Home_CountryS)
        VTX(sendstring)
        sendstring = BuildVmixSetCommand("SetText", nametemplate, "AWAYCOUNTRY_S.Text", BeachVolleyballScorer.Away_CountryS)
        VTX(sendstring)
        'sendstring = BuildVmixSetCommand("SetImage", nametemplate, "FLAG.Source", BeachVolleyballScorer.Home_Flagge)
        'VTX(sendstring)

        stopwatch.Stop()
        Dim elapsedTicks As Long = stopwatch.ElapsedTicks
        Dim elapsedTime As Double = stopwatch.Elapsed.TotalMilliseconds
        BeachVolleyballScorer.ListBox5.Items.Add($"Update combined scorebug points {elapsedTime:F3} ms ")

    End Sub


    Public Shared Sub Update_large_result_Points(nametemplate)
        Dim stopwatch As Stopwatch = Stopwatch.StartNew()

        'large result
        sendstring = BuildVmixSetCommand("SetText", nametemplate, "HOMESETS.Text", BeachVolleyballScorer.homeTeamSets.ToString)
        VTX(sendstring)
        sendstring = BuildVmixSetCommand("SetText", nametemplate, "AWAYSETS.Text", BeachVolleyballScorer.awayTeamSets.ToString)
        VTX(sendstring)
        sendstring = BuildVmixSetCommand("SetText", nametemplate, "HOMEPOINTSSET1.Text", BeachVolleyballScorer.lblHomeTeamPoints1.Text)
        VTX(sendstring)
        sendstring = BuildVmixSetCommand("SetText", nametemplate, "HOMEPOINTSSET2.Text", BeachVolleyballScorer.lblHomeTeamPoints2.Text)
        VTX(sendstring)
        sendstring = BuildVmixSetCommand("SetText", nametemplate, "HOMEPOINTSSET3.Text", BeachVolleyballScorer.lblHomeTeamPoints3.Text)
        VTX(sendstring)

        sendstring = BuildVmixSetCommand("SetText", nametemplate, "AWAYPOINTSSET1.Text", BeachVolleyballScorer.lblAwayTeamPoints1.Text)
        VTX(sendstring)
        sendstring = BuildVmixSetCommand("SetText", nametemplate, "AWAYPOINTSSET2.Text", BeachVolleyballScorer.lblAwayTeamPoints2.Text)
        VTX(sendstring)
        sendstring = BuildVmixSetCommand("SetText", nametemplate, "AWAYPOINTSSET3.Text", BeachVolleyballScorer.lblAwayTeamPoints3.Text)
        VTX(sendstring)

        sendstring = BuildVmixSetCommand("SetText", nametemplate, "HOMENAME1.Text", BeachVolleyballScorer.Home_First_Name1 & " " & BeachVolleyballScorer.Home_NAME1)
        VTX(sendstring)
        sendstring = BuildVmixSetCommand("SetText", nametemplate, "HOMENAME2.Text", BeachVolleyballScorer.Home_First_Name2 & " " & BeachVolleyballScorer.Home_NAME2)
        VTX(sendstring)
        sendstring = BuildVmixSetCommand("SetText", nametemplate, "HOMECOUNTRY_S.Text", BeachVolleyballScorer.Home_CountryS)
        VTX(sendstring)
        sendstring = BuildVmixSetCommand("SetImage", nametemplate, "HOME_FLAG.Source", BeachVolleyballScorer.Home_Flagge)
        VTX(sendstring)
        sendstring = BuildVmixSetCommand("SetText", nametemplate, "AWAYNAME1.Text", BeachVolleyballScorer.Away_First_Name1 & " " & BeachVolleyballScorer.Away_NAME1)
        VTX(sendstring)
        sendstring = BuildVmixSetCommand("SetText", nametemplate, "AWAYNAME2.Text", BeachVolleyballScorer.Away_First_Name2 & " " & BeachVolleyballScorer.Away_NAME2)
        VTX(sendstring)
        sendstring = BuildVmixSetCommand("SetText", nametemplate, "AWAYCOUNTRY_S.Text", BeachVolleyballScorer.Away_CountryS)
        VTX(sendstring)
        sendstring = BuildVmixSetCommand("SetImage", nametemplate, "AWAY_FLAG.Source", BeachVolleyballScorer.Away_Flagge)
        VTX(sendstring)

        'set colors
        'home set 1
        If BeachVolleyballScorer.lblHomeTeamPoints1.ForeColor = Color.Red Then
            sendstring = BuildVmixSetCommand("SetTextColour", nametemplate, "HOMEPOINTSSET1.Text", "red")
        Else
            sendstring = BuildVmixSetCommand("SetTextColour", nametemplate, "HOMEPOINTSSET1.Text", "white")
        End If
        VTX(sendstring)
        ' home set 2
        If BeachVolleyballScorer.lblHomeTeamPoints2.ForeColor = Color.Red Then
            sendstring = BuildVmixSetCommand("SetTextColour", nametemplate, "HOMEPOINTSSET2.Text", "red")
        Else
            sendstring = BuildVmixSetCommand("SetTextColour", nametemplate, "HOMEPOINTSSET2.Text", "white")
        End If
        VTX(sendstring)
        'home set 3
        If BeachVolleyballScorer.lblHomeTeamPoints3.ForeColor = Color.Red Then
            sendstring = BuildVmixSetCommand("SetTextColour", nametemplate, "HOMEPOINTSSET3.Text", "red")
        Else
            sendstring = BuildVmixSetCommand("SetTextColour", nametemplate, "HOMEPOINTSSET3.Text", "white")
        End If
        VTX(sendstring)

        'away set 1
        If BeachVolleyballScorer.lblAwayTeamPoints1.ForeColor = Color.Red Then
            sendstring = BuildVmixSetCommand("SetTextColour", nametemplate, "AWAYPOINTSSET1.Text", "red")
        Else
            sendstring = BuildVmixSetCommand("SetTextColour", nametemplate, "AWAYPOINTSSET1.Text", "white")
        End If
        VTX(sendstring)
        'away set 2
        If BeachVolleyballScorer.lblAwayTeamPoints2.ForeColor = Color.Red Then
            sendstring = BuildVmixSetCommand("SetTextColour", nametemplate, "AWAYPOINTSSET2.Text", "red")
        Else
            sendstring = BuildVmixSetCommand("SetTextColour", nametemplate, "AWAYPOINTSSET2.Text", "white")
        End If
        VTX(sendstring)
        'away set 3
        If BeachVolleyballScorer.lblAwayTeamPoints3.ForeColor = Color.Red Then
            sendstring = BuildVmixSetCommand("SetTextColour", nametemplate, "AWAYPOINTSSET3.Text", "red")
        Else
            sendstring = BuildVmixSetCommand("SetTextColour", nametemplate, "AWAYPOINTSSET3.Text", "white")
        End If
        VTX(sendstring)
        stopwatch.Stop()
        Dim elapsedTicks As Long = stopwatch.ElapsedTicks
        Dim elapsedTime As Double = stopwatch.Elapsed.TotalMilliseconds
        BeachVolleyballScorer.ListBox5.Items.Add($"Update Large Result {elapsedTime:F3} ms ")

    End Sub

    ' Wahl zwischen HTTP- und TCP-API (BeachVolleyballScorer.UseHttpForVmix) wird bei jedem
    ' Aufruf frisch gelesen statt einmalig gecacht - so wirkt eine Einstellungsänderung sofort.
    ' Die eigentliche Übersetzung des "Function=X&Param=Y&..."-Strings ins jeweilige Protokoll
    ' steckt in VmixHttpSender/VmixTcpSender (siehe IVmixSender). Analog zu Tennis26/SoccerClock.
    Private Shared ReadOnly httpVmixSender As New VmixHttpSender()
    Private Shared ReadOnly tcpVmixSender As New VmixTcpSender()

    Private Shared Function CurrentSender() As IVmixSender
        If BeachVolleyballScorer.UseHttpForVmix Then
            Return httpVmixSender
        Else
            Return tcpVmixSender
        End If
    End Function

    ' Gibt die aktuell verwendete TCP-Verbindung frei - beim Schliessen der App bzw. beim
    ' Umschalten des Protokolls aufzurufen, damit keine verwaiste Socket-Verbindung offenbleibt.
    Public Shared Sub DisposeVmixSender()
        tcpVmixSender.Dispose()
    End Sub

    ' Baut einen "SetText"/"SetImage"/"SetTextColour"-vMix-Befehl und kodiert den Wert dabei
    ' konsequent URL-sicher. Vorher wurden Namen/Freitexte/Pfade unkodiert eingefügt, sodass
    ' "&", "+", Leerzeichen oder Sonderzeichen die vMix-Request verfälschen bzw. abschneiden
    ' konnten.
    '
    ' WICHTIG: Uri.EscapeDataString statt WebUtility.UrlEncode - letzteres kodiert Leerzeichen
    ' als "+" (alte Formular-Kodierung), was in einer vMix-URL als literales Plus-Zeichen
    ' ankommt. Uri.EscapeDataString erzeugt "%20". Analog zu Tennis26_Scorer.EncodeVmixValue.
    Public Shared Function EncodeVmixValue(value As String) As String
        Return Uri.EscapeDataString(If(value, ""))
    End Function

    Public Shared Function BuildVmixSetCommand(func As String, input As String, selectedName As String, value As String) As String
        Return "Function=" + func + "&Input=" + input + "&SelectedName=" + selectedName + "&Value=" + EncodeVmixValue(value)
    End Function

    ' Für Befehle ohne SelectedName, z.B. "TitleBeginAnimation&Input=X&Value=Page1".
    Public Shared Function BuildVmixCommand(func As String, input As String, value As String) As String
        Return "Function=" + func + "&Input=" + input + "&Value=" + EncodeVmixValue(value)
    End Function

    ' Für reine Overlay-Toggle-Befehle ohne Value/SelectedName, z.B. "OverlayInput1IN&Input=X".
    Public Shared Function BuildVmixInputCommand(func As String, input As String) As String
        Return "Function=" + func + "&Input=" + input
    End Function

    ' Für Sichtbarkeits-Befehle ohne Value, z.B. "SetTextVisibleOn&Input=X&SelectedName=Y".
    Public Shared Function BuildVmixSelectCommand(func As String, input As String, selectedName As String) As String
        Return "Function=" + func + "&Input=" + input + "&SelectedName=" + selectedName
    End Function

    Public Shared Sub VTX(HTML_URL As String)
        Dim stopwatch As Stopwatch = Stopwatch.StartNew()

        Dim sender As IVmixSender = CurrentSender()
        Dim result As String = sender.Send(HTML_URL)
        BeachVolleyballScorer.ToolStripStatusLabel1.Text = BeachVolleyballScorer.IP

        If result.StartsWith("Exception Error in VTX") Then
            BeachVolleyballScorer.vMixconnectivity = False
            BeachVolleyballScorer.ToolStripStatusLabel2.Text = result
        Else
            BeachVolleyballScorer.ToolStripStatusLabel2.Text = result
        End If

        stopwatch.Stop()
        Dim elapsedTime As Double = stopwatch.Elapsed.TotalMilliseconds
        BeachVolleyballScorer.ToolStripStatusLabel4.Text = $"vMix took {elapsedTime:F3} ms "
    End Sub

    ' Prüft die vMix-Erreichbarkeit über das aktuell gewählte Protokoll statt hart über einen
    ' TCP-Verbindungsversuch auf dem HTTP-Port (der bisherige BeachVolleyballScorer.CheckConnection()
    ' testete Port 8088 - den HTTP-Port - per rohem TcpClient.Connect, was weder die echte
    ' TCP-API (Port 8099) noch den HTTP-Pfad tatsächlich prüfte). Analog zu
    ' Tennis26_Scorer/Fussballuhr.CheckVmixConnection: sender.Send("") und Prüfung auf den
    ' "Exception Error in VTX"-Präfix.
    Public Shared Function CheckVmixConnection() As Boolean
        Dim sender As IVmixSender = CurrentSender()
        Dim result As String = sender.Send("")
        Return Not result.StartsWith("Exception Error in VTX")
    End Function

    ' Function to extract the file name from a full path
    Private Shared Function Getgtzip(filePath As String) As String
        ' Find the last backslash in the path
        Dim lastBackslashIndex As Integer = filePath.LastIndexOf("\")
        ' Return the substring that starts right after the last backslash
        Return filePath.Substring(lastBackslashIndex + 1)
    End Function



End Class

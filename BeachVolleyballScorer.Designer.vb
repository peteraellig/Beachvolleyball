<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class BeachVolleyballScorer
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BeachVolleyballScorer))
        Me.btnHomeTeamPoint = New System.Windows.Forms.Button()
        Me.btnAwayTeamPoint = New System.Windows.Forms.Button()
        Me.lblHomeTeamSets = New System.Windows.Forms.Label()
        Me.lblAwayTeamSets = New System.Windows.Forms.Label()
        Me.lblCurrentServerHome = New System.Windows.Forms.Label()
        Me.lblHomeTeamPoints1 = New System.Windows.Forms.Label()
        Me.lblHomeTeamPoints2 = New System.Windows.Forms.Label()
        Me.lblHomeTeamPoints3 = New System.Windows.Forms.Label()
        Me.lblAwayTeamPoints1 = New System.Windows.Forms.Label()
        Me.lblAwayTeamPoints2 = New System.Windows.Forms.Label()
        Me.lblAwayTeamPoints3 = New System.Windows.Forms.Label()
        Me.lblCurrentSet = New System.Windows.Forms.Label()
        Me.btnResetGame = New System.Windows.Forms.Button()
        Me.lblGame_ended = New System.Windows.Forms.Label()
        Me.btnUndo = New System.Windows.Forms.Button()
        Me.lbl_Name_Home = New System.Windows.Forms.Label()
        Me.lbl_Aufschlag_Home = New System.Windows.Forms.Label()
        Me.lbl_Aufschlag_Away = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox_Flag_Home = New System.Windows.Forms.PictureBox()
        Me.PictureBox_Flag_Away = New System.Windows.Forms.PictureBox()
        Me.lbl_Name_Away = New System.Windows.Forms.Label()
        Me.lblCurrentServerAway = New System.Windows.Forms.Label()
        Me.btn_swap_service = New System.Windows.Forms.Button()
        Me.lbl_Players_Home = New System.Windows.Forms.Label()
        Me.lbl_Players_Away = New System.Windows.Forms.Label()
        Me.btn_teamname_Home = New System.Windows.Forms.Button()
        Me.btn_MatchID = New System.Windows.Forms.Button()
        Me.btn_weather = New System.Windows.Forms.Button()
        Me.btn_OpeningTitle = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel6 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblWinPoints1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblWinPoints2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblWinPoints3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel7 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel8 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btn_Exit_LIVE = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btn_singlename1_Home = New System.Windows.Forms.Button()
        Me.btn_singlename2_Home = New System.Windows.Forms.Button()
        Me.btn_singlename1_Away = New System.Windows.Forms.Button()
        Me.btn_singlename2_Away = New System.Windows.Forms.Button()
        Me.btn_yellowcard = New System.Windows.Forms.Button()
        Me.btn_redcard = New System.Windows.Forms.Button()
        Me.btn_teamname_Away = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.btn_YellowRedcard = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBox_Flag_Home_small = New System.Windows.Forms.PictureBox()
        Me.PictureBox_Flag_Away_small = New System.Windows.Forms.PictureBox()
        Me.Button_ClosingTitle = New System.Windows.Forms.Button()
        Me.PictureBox_Homecolor = New System.Windows.Forms.PictureBox()
        Me.PictureBox_Awaycolor = New System.Windows.Forms.PictureBox()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btn_nocolor_Home = New System.Windows.Forms.Button()
        Me.btn_nocolor_Away = New System.Windows.Forms.Button()
        Me.Label_Winnertext = New System.Windows.Forms.Label()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btn_countdown = New System.Windows.Forms.Button()
        Me.btn_playout = New System.Windows.Forms.Button()
        Me.btn_start_satellitetransmission = New System.Windows.Forms.Button()
        Me.btn_endtransmission = New System.Windows.Forms.Button()
        Me.btn_starttransmission = New System.Windows.Forms.Button()
        Me.lbl_countdown = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btn_freename5 = New System.Windows.Forms.Button()
        Me.btn_freename4 = New System.Windows.Forms.Button()
        Me.btn_freename3 = New System.Windows.Forms.Button()
        Me.btn_freename2 = New System.Windows.Forms.Button()
        Me.btn_freename1 = New System.Windows.Forms.Button()
        Me.btn_large_result = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ListBox5 = New System.Windows.Forms.ListBox()
        Me.btn_Info_Home = New System.Windows.Forms.Button()
        Me.btn_Info_Away = New System.Windows.Forms.Button()
        Me.lbl_Info_Age_Home = New System.Windows.Forms.Label()
        Me.lbl_Info_Height_Home = New System.Windows.Forms.Label()
        Me.lbl_Info_Height_Away = New System.Windows.Forms.Label()
        Me.lbl_Info_Age_Away = New System.Windows.Forms.Label()
        Me.btn_advertising1 = New System.Windows.Forms.Button()
        Me.btn_advertising2 = New System.Windows.Forms.Button()
        Me.btn_advertising3 = New System.Windows.Forms.Button()
        Me.btn_advertising4 = New System.Windows.Forms.Button()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.btn_ref1 = New System.Windows.Forms.Button()
        Me.btn_ref2 = New System.Windows.Forms.Button()
        Me.btn_ref3 = New System.Windows.Forms.Button()
        Me.btn_ref4 = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TextBox_freename = New System.Windows.Forms.TextBox()
        Me.btn_freename6 = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Btn_tournament = New System.Windows.Forms.Button()
        Me.btn_Intro_venue = New System.Windows.Forms.Button()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.PictureBox9 = New System.Windows.Forms.PictureBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.btn_scorebug_large = New System.Windows.Forms.Button()
        Me.lblHomePoints = New System.Windows.Forms.Label()
        Me.lblAwayPoints = New System.Windows.Forms.Label()
        Me.lbl_resetscore_nextset = New System.Windows.Forms.Button()
        Me.btn_scorebug = New System.Windows.Forms.Button()
        Me.btn_timeout = New System.Windows.Forms.Button()
        Me.PictureBox10 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox_Flag_Home, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox_Flag_Away, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox_Flag_Home_small, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox_Flag_Away_small, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox_Homecolor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox_Awaycolor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnHomeTeamPoint
        '
        Me.btnHomeTeamPoint.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHomeTeamPoint.Location = New System.Drawing.Point(13, 18)
        Me.btnHomeTeamPoint.Name = "btnHomeTeamPoint"
        Me.btnHomeTeamPoint.Size = New System.Drawing.Size(164, 112)
        Me.btnHomeTeamPoint.TabIndex = 0
        Me.btnHomeTeamPoint.Text = "Punkt Home"
        Me.btnHomeTeamPoint.UseVisualStyleBackColor = True
        '
        'btnAwayTeamPoint
        '
        Me.btnAwayTeamPoint.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAwayTeamPoint.Location = New System.Drawing.Point(13, 205)
        Me.btnAwayTeamPoint.Name = "btnAwayTeamPoint"
        Me.btnAwayTeamPoint.Size = New System.Drawing.Size(164, 112)
        Me.btnAwayTeamPoint.TabIndex = 1
        Me.btnAwayTeamPoint.Text = "Punkt Away"
        Me.btnAwayTeamPoint.UseVisualStyleBackColor = True
        '
        'lblHomeTeamSets
        '
        Me.lblHomeTeamSets.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.lblHomeTeamSets.Font = New System.Drawing.Font("Segoe UI", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHomeTeamSets.Location = New System.Drawing.Point(910, 9)
        Me.lblHomeTeamSets.Name = "lblHomeTeamSets"
        Me.lblHomeTeamSets.Size = New System.Drawing.Size(93, 131)
        Me.lblHomeTeamSets.TabIndex = 4
        Me.lblHomeTeamSets.Text = "0"
        Me.lblHomeTeamSets.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblAwayTeamSets
        '
        Me.lblAwayTeamSets.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.lblAwayTeamSets.Font = New System.Drawing.Font("Segoe UI", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAwayTeamSets.Location = New System.Drawing.Point(910, 195)
        Me.lblAwayTeamSets.Name = "lblAwayTeamSets"
        Me.lblAwayTeamSets.Size = New System.Drawing.Size(95, 131)
        Me.lblAwayTeamSets.TabIndex = 5
        Me.lblAwayTeamSets.Text = "0"
        Me.lblAwayTeamSets.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCurrentServerHome
        '
        Me.lblCurrentServerHome.AutoSize = True
        Me.lblCurrentServerHome.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.lblCurrentServerHome.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentServerHome.ForeColor = System.Drawing.Color.White
        Me.lblCurrentServerHome.Location = New System.Drawing.Point(289, 66)
        Me.lblCurrentServerHome.Name = "lblCurrentServerHome"
        Me.lblCurrentServerHome.Size = New System.Drawing.Size(58, 21)
        Me.lblCurrentServerHome.TabIndex = 6
        Me.lblCurrentServerHome.Text = "Server"
        '
        'lblHomeTeamPoints1
        '
        Me.lblHomeTeamPoints1.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.lblHomeTeamPoints1.Font = New System.Drawing.Font("Segoe UI", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHomeTeamPoints1.ForeColor = System.Drawing.Color.White
        Me.lblHomeTeamPoints1.Location = New System.Drawing.Point(525, 9)
        Me.lblHomeTeamPoints1.Name = "lblHomeTeamPoints1"
        Me.lblHomeTeamPoints1.Size = New System.Drawing.Size(120, 130)
        Me.lblHomeTeamPoints1.TabIndex = 7
        Me.lblHomeTeamPoints1.Text = "000"
        Me.lblHomeTeamPoints1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblHomeTeamPoints2
        '
        Me.lblHomeTeamPoints2.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.lblHomeTeamPoints2.Font = New System.Drawing.Font("Segoe UI", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHomeTeamPoints2.ForeColor = System.Drawing.Color.White
        Me.lblHomeTeamPoints2.Location = New System.Drawing.Point(655, 9)
        Me.lblHomeTeamPoints2.Name = "lblHomeTeamPoints2"
        Me.lblHomeTeamPoints2.Size = New System.Drawing.Size(120, 130)
        Me.lblHomeTeamPoints2.TabIndex = 8
        Me.lblHomeTeamPoints2.Text = "000"
        Me.lblHomeTeamPoints2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblHomeTeamPoints3
        '
        Me.lblHomeTeamPoints3.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.lblHomeTeamPoints3.Font = New System.Drawing.Font("Segoe UI", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHomeTeamPoints3.ForeColor = System.Drawing.Color.White
        Me.lblHomeTeamPoints3.Location = New System.Drawing.Point(781, 9)
        Me.lblHomeTeamPoints3.Name = "lblHomeTeamPoints3"
        Me.lblHomeTeamPoints3.Size = New System.Drawing.Size(120, 130)
        Me.lblHomeTeamPoints3.TabIndex = 9
        Me.lblHomeTeamPoints3.Text = "000"
        Me.lblHomeTeamPoints3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblAwayTeamPoints1
        '
        Me.lblAwayTeamPoints1.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.lblAwayTeamPoints1.Font = New System.Drawing.Font("Segoe UI", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAwayTeamPoints1.ForeColor = System.Drawing.Color.White
        Me.lblAwayTeamPoints1.Location = New System.Drawing.Point(529, 195)
        Me.lblAwayTeamPoints1.Name = "lblAwayTeamPoints1"
        Me.lblAwayTeamPoints1.Size = New System.Drawing.Size(120, 130)
        Me.lblAwayTeamPoints1.TabIndex = 12
        Me.lblAwayTeamPoints1.Text = "000"
        Me.lblAwayTeamPoints1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblAwayTeamPoints2
        '
        Me.lblAwayTeamPoints2.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.lblAwayTeamPoints2.Font = New System.Drawing.Font("Segoe UI", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAwayTeamPoints2.ForeColor = System.Drawing.Color.White
        Me.lblAwayTeamPoints2.Location = New System.Drawing.Point(655, 195)
        Me.lblAwayTeamPoints2.Name = "lblAwayTeamPoints2"
        Me.lblAwayTeamPoints2.Size = New System.Drawing.Size(120, 130)
        Me.lblAwayTeamPoints2.TabIndex = 11
        Me.lblAwayTeamPoints2.Text = "000"
        Me.lblAwayTeamPoints2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblAwayTeamPoints3
        '
        Me.lblAwayTeamPoints3.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.lblAwayTeamPoints3.Font = New System.Drawing.Font("Segoe UI", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAwayTeamPoints3.ForeColor = System.Drawing.Color.White
        Me.lblAwayTeamPoints3.Location = New System.Drawing.Point(781, 195)
        Me.lblAwayTeamPoints3.Name = "lblAwayTeamPoints3"
        Me.lblAwayTeamPoints3.Size = New System.Drawing.Size(120, 130)
        Me.lblAwayTeamPoints3.TabIndex = 10
        Me.lblAwayTeamPoints3.Text = "000"
        Me.lblAwayTeamPoints3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCurrentSet
        '
        Me.lblCurrentSet.AutoSize = True
        Me.lblCurrentSet.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentSet.Location = New System.Drawing.Point(678, 153)
        Me.lblCurrentSet.Name = "lblCurrentSet"
        Me.lblCurrentSet.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCurrentSet.Size = New System.Drawing.Size(143, 31)
        Me.lblCurrentSet.TabIndex = 13
        Me.lblCurrentSet.Text = "current set"
        '
        'btnResetGame
        '
        Me.btnResetGame.BackColor = System.Drawing.Color.IndianRed
        Me.btnResetGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnResetGame.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResetGame.ForeColor = System.Drawing.Color.White
        Me.btnResetGame.Location = New System.Drawing.Point(832, 629)
        Me.btnResetGame.Name = "btnResetGame"
        Me.btnResetGame.Size = New System.Drawing.Size(179, 75)
        Me.btnResetGame.TabIndex = 14
        Me.btnResetGame.Text = "RESET ALL POINTS"
        Me.btnResetGame.UseVisualStyleBackColor = False
        '
        'lblGame_ended
        '
        Me.lblGame_ended.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGame_ended.ForeColor = System.Drawing.Color.IndianRed
        Me.lblGame_ended.Location = New System.Drawing.Point(28, 149)
        Me.lblGame_ended.Name = "lblGame_ended"
        Me.lblGame_ended.Size = New System.Drawing.Size(873, 32)
        Me.lblGame_ended.TabIndex = 15
        Me.lblGame_ended.Text = "lblGame_ended"
        Me.lblGame_ended.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnUndo
        '
        Me.btnUndo.BackColor = System.Drawing.Color.LightSalmon
        Me.btnUndo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUndo.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUndo.Location = New System.Drawing.Point(832, 390)
        Me.btnUndo.Name = "btnUndo"
        Me.btnUndo.Size = New System.Drawing.Size(179, 71)
        Me.btnUndo.TabIndex = 16
        Me.btnUndo.Text = "UNDO"
        Me.btnUndo.UseVisualStyleBackColor = False
        '
        'lbl_Name_Home
        '
        Me.lbl_Name_Home.BackColor = System.Drawing.Color.White
        Me.lbl_Name_Home.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Name_Home.Location = New System.Drawing.Point(221, 13)
        Me.lbl_Name_Home.Name = "lbl_Name_Home"
        Me.lbl_Name_Home.Size = New System.Drawing.Size(293, 21)
        Me.lbl_Name_Home.TabIndex = 17
        Me.lbl_Name_Home.Text = "Name Home Country"
        Me.lbl_Name_Home.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Aufschlag_Home
        '
        Me.lbl_Aufschlag_Home.AutoSize = True
        Me.lbl_Aufschlag_Home.BackColor = System.Drawing.Color.Yellow
        Me.lbl_Aufschlag_Home.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Aufschlag_Home.ForeColor = System.Drawing.Color.IndianRed
        Me.lbl_Aufschlag_Home.Location = New System.Drawing.Point(186, 23)
        Me.lbl_Aufschlag_Home.Name = "lbl_Aufschlag_Home"
        Me.lbl_Aufschlag_Home.Size = New System.Drawing.Size(31, 24)
        Me.lbl_Aufschlag_Home.TabIndex = 19
        Me.lbl_Aufschlag_Home.Text = "►"
        '
        'lbl_Aufschlag_Away
        '
        Me.lbl_Aufschlag_Away.AutoSize = True
        Me.lbl_Aufschlag_Away.BackColor = System.Drawing.Color.Yellow
        Me.lbl_Aufschlag_Away.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Aufschlag_Away.ForeColor = System.Drawing.Color.IndianRed
        Me.lbl_Aufschlag_Away.Location = New System.Drawing.Point(189, 211)
        Me.lbl_Aufschlag_Away.Name = "lbl_Aufschlag_Away"
        Me.lbl_Aufschlag_Away.Size = New System.Drawing.Size(31, 24)
        Me.lbl_Aufschlag_Away.TabIndex = 20
        Me.lbl_Aufschlag_Away.Text = "►"
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.PictureBox4.Location = New System.Drawing.Point(8, 9)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(511, 130)
        Me.PictureBox4.TabIndex = 28
        Me.PictureBox4.TabStop = False
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.PictureBox5.Location = New System.Drawing.Point(8, 195)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(511, 130)
        Me.PictureBox5.TabIndex = 32
        Me.PictureBox5.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(568, 152)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(113, 31)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "Satz Nr:"
        '
        'PictureBox_Flag_Home
        '
        Me.PictureBox_Flag_Home.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.PictureBox_Flag_Home.Location = New System.Drawing.Point(183, 69)
        Me.PictureBox_Flag_Home.Name = "PictureBox_Flag_Home"
        Me.PictureBox_Flag_Home.Size = New System.Drawing.Size(100, 60)
        Me.PictureBox_Flag_Home.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox_Flag_Home.TabIndex = 43
        Me.PictureBox_Flag_Home.TabStop = False
        '
        'PictureBox_Flag_Away
        '
        Me.PictureBox_Flag_Away.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.PictureBox_Flag_Away.Location = New System.Drawing.Point(183, 260)
        Me.PictureBox_Flag_Away.Name = "PictureBox_Flag_Away"
        Me.PictureBox_Flag_Away.Size = New System.Drawing.Size(100, 60)
        Me.PictureBox_Flag_Away.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox_Flag_Away.TabIndex = 44
        Me.PictureBox_Flag_Away.TabStop = False
        '
        'lbl_Name_Away
        '
        Me.lbl_Name_Away.BackColor = System.Drawing.Color.White
        Me.lbl_Name_Away.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Name_Away.Location = New System.Drawing.Point(225, 200)
        Me.lbl_Name_Away.Name = "lbl_Name_Away"
        Me.lbl_Name_Away.Size = New System.Drawing.Size(290, 21)
        Me.lbl_Name_Away.TabIndex = 46
        Me.lbl_Name_Away.Text = "Name Away Team"
        Me.lbl_Name_Away.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCurrentServerAway
        '
        Me.lblCurrentServerAway.AutoSize = True
        Me.lblCurrentServerAway.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.lblCurrentServerAway.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentServerAway.ForeColor = System.Drawing.Color.White
        Me.lblCurrentServerAway.Location = New System.Drawing.Point(289, 254)
        Me.lblCurrentServerAway.Name = "lblCurrentServerAway"
        Me.lblCurrentServerAway.Size = New System.Drawing.Size(58, 21)
        Me.lblCurrentServerAway.TabIndex = 47
        Me.lblCurrentServerAway.Text = "Server"
        '
        'btn_swap_service
        '
        Me.btn_swap_service.BackColor = System.Drawing.Color.LemonChiffon
        Me.btn_swap_service.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_swap_service.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_swap_service.Location = New System.Drawing.Point(832, 509)
        Me.btn_swap_service.Name = "btn_swap_service"
        Me.btn_swap_service.Size = New System.Drawing.Size(179, 74)
        Me.btn_swap_service.TabIndex = 48
        Me.btn_swap_service.Text = "swap serve"
        Me.btn_swap_service.UseVisualStyleBackColor = False
        '
        'lbl_Players_Home
        '
        Me.lbl_Players_Home.BackColor = System.Drawing.Color.White
        Me.lbl_Players_Home.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Players_Home.Location = New System.Drawing.Point(221, 38)
        Me.lbl_Players_Home.Name = "lbl_Players_Home"
        Me.lbl_Players_Home.Size = New System.Drawing.Size(293, 21)
        Me.lbl_Players_Home.TabIndex = 57
        Me.lbl_Players_Home.Text = "Name Home Players"
        Me.lbl_Players_Home.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Players_Away
        '
        Me.lbl_Players_Away.BackColor = System.Drawing.Color.White
        Me.lbl_Players_Away.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Players_Away.Location = New System.Drawing.Point(225, 225)
        Me.lbl_Players_Away.Name = "lbl_Players_Away"
        Me.lbl_Players_Away.Size = New System.Drawing.Size(290, 21)
        Me.lbl_Players_Away.TabIndex = 59
        Me.lbl_Players_Away.Text = "Name Away Players"
        Me.lbl_Players_Away.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_teamname_Home
        '
        Me.btn_teamname_Home.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btn_teamname_Home.FlatAppearance.BorderSize = 5
        Me.btn_teamname_Home.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_teamname_Home.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_teamname_Home.Location = New System.Drawing.Point(550, 391)
        Me.btn_teamname_Home.Name = "btn_teamname_Home"
        Me.btn_teamname_Home.Size = New System.Drawing.Size(170, 70)
        Me.btn_teamname_Home.TabIndex = 60
        Me.btn_teamname_Home.Text = "Teamname Home"
        Me.btn_teamname_Home.UseVisualStyleBackColor = True
        '
        'btn_MatchID
        '
        Me.btn_MatchID.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_MatchID.Location = New System.Drawing.Point(1408, 287)
        Me.btn_MatchID.Name = "btn_MatchID"
        Me.btn_MatchID.Size = New System.Drawing.Size(149, 39)
        Me.btn_MatchID.TabIndex = 61
        Me.btn_MatchID.Text = "match ID"
        Me.btn_MatchID.UseVisualStyleBackColor = True
        '
        'btn_weather
        '
        Me.btn_weather.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_weather.Location = New System.Drawing.Point(1406, 332)
        Me.btn_weather.Name = "btn_weather"
        Me.btn_weather.Size = New System.Drawing.Size(151, 39)
        Me.btn_weather.TabIndex = 62
        Me.btn_weather.Text = "Weather"
        Me.btn_weather.UseVisualStyleBackColor = True
        '
        'btn_OpeningTitle
        '
        Me.btn_OpeningTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_OpeningTitle.Location = New System.Drawing.Point(1411, 43)
        Me.btn_OpeningTitle.Name = "btn_OpeningTitle"
        Me.btn_OpeningTitle.Size = New System.Drawing.Size(150, 40)
        Me.btn_OpeningTitle.TabIndex = 63
        Me.btn_OpeningTitle.Text = "Opening Title"
        Me.btn_OpeningTitle.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Silver
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel5, Me.ToolStripStatusLabel6, Me.lblWinPoints1, Me.lblWinPoints2, Me.lblWinPoints3, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel7, Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel8, Me.ToolStripStatusLabel4, Me.btn_Exit_LIVE})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 735)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1584, 26)
        Me.StatusStrip1.TabIndex = 64
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel5
        '
        Me.ToolStripStatusLabel5.AutoSize = False
        Me.ToolStripStatusLabel5.BackColor = System.Drawing.Color.LimeGreen
        Me.ToolStripStatusLabel5.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel5.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedOuter
        Me.ToolStripStatusLabel5.Margin = New System.Windows.Forms.Padding(10, 0, 40, 0)
        Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
        Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(100, 26)
        Me.ToolStripStatusLabel5.Text = "settings"
        '
        'ToolStripStatusLabel6
        '
        Me.ToolStripStatusLabel6.Name = "ToolStripStatusLabel6"
        Me.ToolStripStatusLabel6.Size = New System.Drawing.Size(113, 21)
        Me.ToolStripStatusLabel6.Text = "setting WINPOINTS:"
        '
        'lblWinPoints1
        '
        Me.lblWinPoints1.ActiveLinkColor = System.Drawing.SystemColors.Control
        Me.lblWinPoints1.AutoSize = False
        Me.lblWinPoints1.BackColor = System.Drawing.Color.LightYellow
        Me.lblWinPoints1.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.lblWinPoints1.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.lblWinPoints1.Name = "lblWinPoints1"
        Me.lblWinPoints1.Size = New System.Drawing.Size(30, 21)
        Me.lblWinPoints1.Text = "ToolStripStatusLabel6"
        '
        'lblWinPoints2
        '
        Me.lblWinPoints2.ActiveLinkColor = System.Drawing.SystemColors.Control
        Me.lblWinPoints2.AutoSize = False
        Me.lblWinPoints2.BackColor = System.Drawing.Color.LightYellow
        Me.lblWinPoints2.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.lblWinPoints2.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.lblWinPoints2.Name = "lblWinPoints2"
        Me.lblWinPoints2.Size = New System.Drawing.Size(30, 21)
        Me.lblWinPoints2.Text = "ToolStripStatusLabel7"
        '
        'lblWinPoints3
        '
        Me.lblWinPoints3.ActiveLinkColor = System.Drawing.SystemColors.Control
        Me.lblWinPoints3.AutoSize = False
        Me.lblWinPoints3.BackColor = System.Drawing.Color.LightYellow
        Me.lblWinPoints3.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.lblWinPoints3.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.lblWinPoints3.Name = "lblWinPoints3"
        Me.lblWinPoints3.Size = New System.Drawing.Size(30, 21)
        Me.lblWinPoints3.Text = "ToolStripStatusLabel8"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.AutoSize = False
        Me.ToolStripStatusLabel3.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel3.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.ToolStripStatusLabel3.Margin = New System.Windows.Forms.Padding(0, 3, 40, 2)
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(120, 21)
        Me.ToolStripStatusLabel3.Text = " Rallye-Point-System"
        '
        'ToolStripStatusLabel7
        '
        Me.ToolStripStatusLabel7.AutoSize = False
        Me.ToolStripStatusLabel7.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel7.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.ToolStripStatusLabel7.Name = "ToolStripStatusLabel7"
        Me.ToolStripStatusLabel7.Size = New System.Drawing.Size(150, 21)
        Me.ToolStripStatusLabel7.Text = " vMix not running"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.AutoSize = False
        Me.ToolStripStatusLabel1.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(100, 21)
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.AutoSize = False
        Me.ToolStripStatusLabel2.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel2.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(350, 21)
        Me.ToolStripStatusLabel2.Text = "ToolStripStatusLabel2"
        '
        'ToolStripStatusLabel8
        '
        Me.ToolStripStatusLabel8.AutoSize = False
        Me.ToolStripStatusLabel8.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel8.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
        Me.ToolStripStatusLabel8.Name = "ToolStripStatusLabel8"
        Me.ToolStripStatusLabel8.Size = New System.Drawing.Size(100, 21)
        Me.ToolStripStatusLabel8.Text = "ToolStripStatusLabel8"
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.AutoSize = False
        Me.ToolStripStatusLabel4.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel4.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
        Me.ToolStripStatusLabel4.Margin = New System.Windows.Forms.Padding(0, 3, 20, 2)
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(72, 21)
        Me.ToolStripStatusLabel4.Text = "vMix timing"
        '
        'btn_Exit_LIVE
        '
        Me.btn_Exit_LIVE.ActiveLinkColor = System.Drawing.Color.IndianRed
        Me.btn_Exit_LIVE.AutoSize = False
        Me.btn_Exit_LIVE.BackColor = System.Drawing.Color.IndianRed
        Me.btn_Exit_LIVE.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.btn_Exit_LIVE.BorderStyle = System.Windows.Forms.Border3DStyle.Raised
        Me.btn_Exit_LIVE.ForeColor = System.Drawing.Color.White
        Me.btn_Exit_LIVE.Margin = New System.Windows.Forms.Padding(0)
        Me.btn_Exit_LIVE.Name = "btn_Exit_LIVE"
        Me.btn_Exit_LIVE.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never
        Me.btn_Exit_LIVE.Size = New System.Drawing.Size(264, 26)
        Me.btn_Exit_LIVE.Spring = True
        Me.btn_Exit_LIVE.Text = "Exit LIVE"
        '
        'btn_singlename1_Home
        '
        Me.btn_singlename1_Home.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btn_singlename1_Home.FlatAppearance.BorderSize = 5
        Me.btn_singlename1_Home.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_singlename1_Home.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_singlename1_Home.Location = New System.Drawing.Point(13, 390)
        Me.btn_singlename1_Home.Name = "btn_singlename1_Home"
        Me.btn_singlename1_Home.Size = New System.Drawing.Size(170, 70)
        Me.btn_singlename1_Home.TabIndex = 65
        Me.btn_singlename1_Home.Text = "Name player1 Home"
        Me.btn_singlename1_Home.UseVisualStyleBackColor = True
        '
        'btn_singlename2_Home
        '
        Me.btn_singlename2_Home.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btn_singlename2_Home.FlatAppearance.BorderSize = 5
        Me.btn_singlename2_Home.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_singlename2_Home.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_singlename2_Home.Location = New System.Drawing.Point(189, 390)
        Me.btn_singlename2_Home.Name = "btn_singlename2_Home"
        Me.btn_singlename2_Home.Size = New System.Drawing.Size(170, 70)
        Me.btn_singlename2_Home.TabIndex = 66
        Me.btn_singlename2_Home.Text = "Name player2 Home"
        Me.btn_singlename2_Home.UseVisualStyleBackColor = True
        '
        'btn_singlename1_Away
        '
        Me.btn_singlename1_Away.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btn_singlename1_Away.FlatAppearance.BorderSize = 5
        Me.btn_singlename1_Away.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_singlename1_Away.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_singlename1_Away.Location = New System.Drawing.Point(12, 513)
        Me.btn_singlename1_Away.Name = "btn_singlename1_Away"
        Me.btn_singlename1_Away.Size = New System.Drawing.Size(170, 70)
        Me.btn_singlename1_Away.TabIndex = 67
        Me.btn_singlename1_Away.Text = "Name player1 Away"
        Me.btn_singlename1_Away.UseVisualStyleBackColor = True
        '
        'btn_singlename2_Away
        '
        Me.btn_singlename2_Away.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btn_singlename2_Away.FlatAppearance.BorderSize = 5
        Me.btn_singlename2_Away.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_singlename2_Away.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_singlename2_Away.Location = New System.Drawing.Point(188, 513)
        Me.btn_singlename2_Away.Name = "btn_singlename2_Away"
        Me.btn_singlename2_Away.Size = New System.Drawing.Size(170, 70)
        Me.btn_singlename2_Away.TabIndex = 68
        Me.btn_singlename2_Away.Text = "Name player2 Away"
        Me.btn_singlename2_Away.UseVisualStyleBackColor = True
        '
        'btn_yellowcard
        '
        Me.btn_yellowcard.BackColor = System.Drawing.Color.Transparent
        Me.btn_yellowcard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btn_yellowcard.ForeColor = System.Drawing.Color.White
        Me.btn_yellowcard.Image = Global.BeachvolleyballScorer.My.Resources.Resources.yellowcard
        Me.btn_yellowcard.Location = New System.Drawing.Point(12, 650)
        Me.btn_yellowcard.Name = "btn_yellowcard"
        Me.btn_yellowcard.Size = New System.Drawing.Size(55, 55)
        Me.btn_yellowcard.TabIndex = 69
        Me.btn_yellowcard.UseVisualStyleBackColor = False
        '
        'btn_redcard
        '
        Me.btn_redcard.BackColor = System.Drawing.Color.Transparent
        Me.btn_redcard.Image = Global.BeachvolleyballScorer.My.Resources.Resources.redcard
        Me.btn_redcard.Location = New System.Drawing.Point(83, 651)
        Me.btn_redcard.Name = "btn_redcard"
        Me.btn_redcard.Size = New System.Drawing.Size(55, 55)
        Me.btn_redcard.TabIndex = 70
        Me.btn_redcard.UseVisualStyleBackColor = False
        '
        'btn_teamname_Away
        '
        Me.btn_teamname_Away.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btn_teamname_Away.FlatAppearance.BorderSize = 5
        Me.btn_teamname_Away.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_teamname_Away.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_teamname_Away.Location = New System.Drawing.Point(550, 513)
        Me.btn_teamname_Away.Name = "btn_teamname_Away"
        Me.btn_teamname_Away.Size = New System.Drawing.Size(170, 70)
        Me.btn_teamname_Away.TabIndex = 72
        Me.btn_teamname_Away.Text = "Teamname Away"
        Me.btn_teamname_Away.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.PictureBox1.Location = New System.Drawing.Point(7, 387)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(728, 80)
        Me.PictureBox1.TabIndex = 73
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.PictureBox2.Location = New System.Drawing.Point(6, 509)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(729, 80)
        Me.PictureBox2.TabIndex = 74
        Me.PictureBox2.TabStop = False
        '
        'btn_YellowRedcard
        '
        Me.btn_YellowRedcard.BackColor = System.Drawing.Color.Transparent
        Me.btn_YellowRedcard.Image = Global.BeachvolleyballScorer.My.Resources.Resources.yellowredcard
        Me.btn_YellowRedcard.Location = New System.Drawing.Point(69, 640)
        Me.btn_YellowRedcard.Name = "btn_YellowRedcard"
        Me.btn_YellowRedcard.Size = New System.Drawing.Size(55, 55)
        Me.btn_YellowRedcard.TabIndex = 76
        Me.btn_YellowRedcard.UseVisualStyleBackColor = False
        Me.btn_YellowRedcard.Visible = False
        '
        'PictureBox_Flag_Home_small
        '
        Me.PictureBox_Flag_Home_small.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.PictureBox_Flag_Home_small.Location = New System.Drawing.Point(445, 397)
        Me.PictureBox_Flag_Home_small.Name = "PictureBox_Flag_Home_small"
        Me.PictureBox_Flag_Home_small.Size = New System.Drawing.Size(83, 50)
        Me.PictureBox_Flag_Home_small.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox_Flag_Home_small.TabIndex = 78
        Me.PictureBox_Flag_Home_small.TabStop = False
        '
        'PictureBox_Flag_Away_small
        '
        Me.PictureBox_Flag_Away_small.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.PictureBox_Flag_Away_small.Location = New System.Drawing.Point(445, 519)
        Me.PictureBox_Flag_Away_small.Name = "PictureBox_Flag_Away_small"
        Me.PictureBox_Flag_Away_small.Size = New System.Drawing.Size(83, 50)
        Me.PictureBox_Flag_Away_small.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox_Flag_Away_small.TabIndex = 79
        Me.PictureBox_Flag_Away_small.TabStop = False
        '
        'Button_ClosingTitle
        '
        Me.Button_ClosingTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_ClosingTitle.Location = New System.Drawing.Point(1412, 181)
        Me.Button_ClosingTitle.Name = "Button_ClosingTitle"
        Me.Button_ClosingTitle.Size = New System.Drawing.Size(150, 40)
        Me.Button_ClosingTitle.TabIndex = 80
        Me.Button_ClosingTitle.Text = "Closing Title"
        Me.Button_ClosingTitle.UseVisualStyleBackColor = True
        '
        'PictureBox_Homecolor
        '
        Me.PictureBox_Homecolor.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.PictureBox_Homecolor.Location = New System.Drawing.Point(293, 110)
        Me.PictureBox_Homecolor.Name = "PictureBox_Homecolor"
        Me.PictureBox_Homecolor.Size = New System.Drawing.Size(167, 20)
        Me.PictureBox_Homecolor.TabIndex = 81
        Me.PictureBox_Homecolor.TabStop = False
        '
        'PictureBox_Awaycolor
        '
        Me.PictureBox_Awaycolor.Location = New System.Drawing.Point(293, 297)
        Me.PictureBox_Awaycolor.Name = "PictureBox_Awaycolor"
        Me.PictureBox_Awaycolor.Size = New System.Drawing.Size(167, 20)
        Me.PictureBox_Awaycolor.TabIndex = 82
        Me.PictureBox_Awaycolor.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(315, 94)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(109, 13)
        Me.Label4.TabIndex = 84
        Me.Label4.Text = "set Color Home Team"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(315, 281)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(107, 13)
        Me.Label5.TabIndex = 85
        Me.Label5.Text = "set Color Away Team"
        '
        'btn_nocolor_Home
        '
        Me.btn_nocolor_Home.FlatAppearance.BorderSize = 0
        Me.btn_nocolor_Home.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_nocolor_Home.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_nocolor_Home.Location = New System.Drawing.Point(465, 110)
        Me.btn_nocolor_Home.Name = "btn_nocolor_Home"
        Me.btn_nocolor_Home.Size = New System.Drawing.Size(48, 20)
        Me.btn_nocolor_Home.TabIndex = 86
        Me.btn_nocolor_Home.Text = "no color"
        Me.btn_nocolor_Home.UseVisualStyleBackColor = True
        '
        'btn_nocolor_Away
        '
        Me.btn_nocolor_Away.FlatAppearance.BorderSize = 0
        Me.btn_nocolor_Away.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_nocolor_Away.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_nocolor_Away.Location = New System.Drawing.Point(465, 296)
        Me.btn_nocolor_Away.Name = "btn_nocolor_Away"
        Me.btn_nocolor_Away.Size = New System.Drawing.Size(48, 20)
        Me.btn_nocolor_Away.TabIndex = 87
        Me.btn_nocolor_Away.Text = "no color"
        Me.btn_nocolor_Away.UseVisualStyleBackColor = True
        '
        'Label_Winnertext
        '
        Me.Label_Winnertext.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Winnertext.ForeColor = System.Drawing.Color.IndianRed
        Me.Label_Winnertext.Location = New System.Drawing.Point(8, 328)
        Me.Label_Winnertext.Name = "Label_Winnertext"
        Me.Label_Winnertext.Size = New System.Drawing.Size(872, 32)
        Me.Label_Winnertext.TabIndex = 88
        Me.Label_Winnertext.Text = "winnerlabel"
        Me.Label_Winnertext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Timer2
        '
        Me.Timer2.Interval = 10000
        '
        'Timer3
        '
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.btn_countdown)
        Me.Panel1.Controls.Add(Me.btn_playout)
        Me.Panel1.Controls.Add(Me.btn_start_satellitetransmission)
        Me.Panel1.Controls.Add(Me.btn_endtransmission)
        Me.Panel1.Controls.Add(Me.btn_starttransmission)
        Me.Panel1.Controls.Add(Me.lbl_countdown)
        Me.Panel1.Location = New System.Drawing.Point(1394, 450)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(184, 200)
        Me.Panel1.TabIndex = 95
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(4, 2)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(110, 13)
        Me.Label7.TabIndex = 119
        Me.Label7.Text = "Broadcast info boards"
        '
        'btn_countdown
        '
        Me.btn_countdown.Location = New System.Drawing.Point(7, 90)
        Me.btn_countdown.Name = "btn_countdown"
        Me.btn_countdown.Size = New System.Drawing.Size(150, 30)
        Me.btn_countdown.TabIndex = 98
        Me.btn_countdown.Text = "countdown"
        Me.btn_countdown.UseVisualStyleBackColor = True
        '
        'btn_playout
        '
        Me.btn_playout.Location = New System.Drawing.Point(7, 162)
        Me.btn_playout.Name = "btn_playout"
        Me.btn_playout.Size = New System.Drawing.Size(150, 30)
        Me.btn_playout.TabIndex = 99
        Me.btn_playout.Text = "playout"
        Me.btn_playout.UseVisualStyleBackColor = True
        '
        'btn_start_satellitetransmission
        '
        Me.btn_start_satellitetransmission.Location = New System.Drawing.Point(7, 18)
        Me.btn_start_satellitetransmission.Name = "btn_start_satellitetransmission"
        Me.btn_start_satellitetransmission.Size = New System.Drawing.Size(150, 30)
        Me.btn_start_satellitetransmission.TabIndex = 97
        Me.btn_start_satellitetransmission.Text = "start of satellite transmission"
        Me.btn_start_satellitetransmission.UseVisualStyleBackColor = True
        '
        'btn_endtransmission
        '
        Me.btn_endtransmission.Location = New System.Drawing.Point(7, 126)
        Me.btn_endtransmission.Name = "btn_endtransmission"
        Me.btn_endtransmission.Size = New System.Drawing.Size(150, 30)
        Me.btn_endtransmission.TabIndex = 96
        Me.btn_endtransmission.Text = "end transmission"
        Me.btn_endtransmission.UseVisualStyleBackColor = True
        '
        'btn_starttransmission
        '
        Me.btn_starttransmission.Location = New System.Drawing.Point(7, 54)
        Me.btn_starttransmission.Name = "btn_starttransmission"
        Me.btn_starttransmission.Size = New System.Drawing.Size(150, 30)
        Me.btn_starttransmission.TabIndex = 95
        Me.btn_starttransmission.Text = "start transmission"
        Me.btn_starttransmission.UseVisualStyleBackColor = True
        '
        'lbl_countdown
        '
        Me.lbl_countdown.AutoSize = True
        Me.lbl_countdown.Location = New System.Drawing.Point(158, 99)
        Me.lbl_countdown.Name = "lbl_countdown"
        Me.lbl_countdown.Size = New System.Drawing.Size(19, 13)
        Me.lbl_countdown.TabIndex = 94
        Me.lbl_countdown.Text = "60"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.btn_freename5)
        Me.Panel2.Controls.Add(Me.btn_freename4)
        Me.Panel2.Controls.Add(Me.btn_freename3)
        Me.Panel2.Controls.Add(Me.btn_freename2)
        Me.Panel2.Controls.Add(Me.btn_freename1)
        Me.Panel2.Location = New System.Drawing.Point(1059, 450)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(323, 201)
        Me.Panel2.TabIndex = 100
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(3, 2)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(59, 13)
        Me.Label8.TabIndex = 120
        Me.Label8.Text = "free names"
        '
        'btn_freename5
        '
        Me.btn_freename5.Location = New System.Drawing.Point(3, 163)
        Me.btn_freename5.Name = "btn_freename5"
        Me.btn_freename5.Size = New System.Drawing.Size(315, 30)
        Me.btn_freename5.TabIndex = 105
        Me.btn_freename5.Text = "btn_freename5"
        Me.btn_freename5.UseVisualStyleBackColor = True
        '
        'btn_freename4
        '
        Me.btn_freename4.Location = New System.Drawing.Point(3, 126)
        Me.btn_freename4.Name = "btn_freename4"
        Me.btn_freename4.Size = New System.Drawing.Size(315, 30)
        Me.btn_freename4.TabIndex = 104
        Me.btn_freename4.Text = "btn_freename4"
        Me.btn_freename4.UseVisualStyleBackColor = True
        '
        'btn_freename3
        '
        Me.btn_freename3.Location = New System.Drawing.Point(2, 90)
        Me.btn_freename3.Name = "btn_freename3"
        Me.btn_freename3.Size = New System.Drawing.Size(316, 30)
        Me.btn_freename3.TabIndex = 103
        Me.btn_freename3.Text = "btn_freename3"
        Me.btn_freename3.UseVisualStyleBackColor = True
        '
        'btn_freename2
        '
        Me.btn_freename2.Location = New System.Drawing.Point(2, 54)
        Me.btn_freename2.Name = "btn_freename2"
        Me.btn_freename2.Size = New System.Drawing.Size(316, 30)
        Me.btn_freename2.TabIndex = 102
        Me.btn_freename2.Text = "btn_freename2"
        Me.btn_freename2.UseVisualStyleBackColor = True
        '
        'btn_freename1
        '
        Me.btn_freename1.Location = New System.Drawing.Point(2, 18)
        Me.btn_freename1.Name = "btn_freename1"
        Me.btn_freename1.Size = New System.Drawing.Size(316, 30)
        Me.btn_freename1.TabIndex = 101
        Me.btn_freename1.Text = "btn_freename1"
        Me.btn_freename1.UseVisualStyleBackColor = True
        '
        'btn_large_result
        '
        Me.btn_large_result.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_large_result.Location = New System.Drawing.Point(1021, 205)
        Me.btn_large_result.Name = "btn_large_result"
        Me.btn_large_result.Size = New System.Drawing.Size(167, 82)
        Me.btn_large_result.TabIndex = 101
        Me.btn_large_result.Text = "pauses/large Result"
        Me.btn_large_result.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.Color.DarkGray
        Me.Label1.Location = New System.Drawing.Point(1414, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(129, 31)
        Me.Label1.TabIndex = 102
        Me.Label1.Text = "these titles must be edited and designed by hand"
        '
        'ListBox5
        '
        Me.ListBox5.BackColor = System.Drawing.SystemColors.Control
        Me.ListBox5.FormattingEnabled = True
        Me.ListBox5.Location = New System.Drawing.Point(1230, 30)
        Me.ListBox5.Name = "ListBox5"
        Me.ListBox5.Size = New System.Drawing.Size(227, 355)
        Me.ListBox5.TabIndex = 103
        Me.ListBox5.Visible = False
        '
        'btn_Info_Home
        '
        Me.btn_Info_Home.FlatAppearance.BorderSize = 0
        Me.btn_Info_Home.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Info_Home.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Info_Home.Location = New System.Drawing.Point(364, 391)
        Me.btn_Info_Home.Name = "btn_Info_Home"
        Me.btn_Info_Home.Size = New System.Drawing.Size(75, 70)
        Me.btn_Info_Home.TabIndex = 104
        Me.btn_Info_Home.Text = "INFO 2.line"
        Me.btn_Info_Home.UseVisualStyleBackColor = True
        '
        'btn_Info_Away
        '
        Me.btn_Info_Away.FlatAppearance.BorderSize = 0
        Me.btn_Info_Away.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Info_Away.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Info_Away.Location = New System.Drawing.Point(365, 513)
        Me.btn_Info_Away.Name = "btn_Info_Away"
        Me.btn_Info_Away.Size = New System.Drawing.Size(75, 70)
        Me.btn_Info_Away.TabIndex = 105
        Me.btn_Info_Away.Text = "INFO 2.line"
        Me.btn_Info_Away.UseVisualStyleBackColor = True
        '
        'lbl_Info_Age_Home
        '
        Me.lbl_Info_Age_Home.AutoSize = True
        Me.lbl_Info_Age_Home.Location = New System.Drawing.Point(365, 372)
        Me.lbl_Info_Age_Home.Name = "lbl_Info_Age_Home"
        Me.lbl_Info_Age_Home.Size = New System.Drawing.Size(19, 13)
        Me.lbl_Info_Age_Home.TabIndex = 106
        Me.lbl_Info_Age_Home.Text = "22"
        '
        'lbl_Info_Height_Home
        '
        Me.lbl_Info_Height_Home.AutoSize = True
        Me.lbl_Info_Height_Home.Location = New System.Drawing.Point(401, 372)
        Me.lbl_Info_Height_Home.Name = "lbl_Info_Height_Home"
        Me.lbl_Info_Height_Home.Size = New System.Drawing.Size(19, 13)
        Me.lbl_Info_Height_Home.TabIndex = 107
        Me.lbl_Info_Height_Home.Text = "22"
        '
        'lbl_Info_Height_Away
        '
        Me.lbl_Info_Height_Away.AutoSize = True
        Me.lbl_Info_Height_Away.Location = New System.Drawing.Point(401, 589)
        Me.lbl_Info_Height_Away.Name = "lbl_Info_Height_Away"
        Me.lbl_Info_Height_Away.Size = New System.Drawing.Size(19, 13)
        Me.lbl_Info_Height_Away.TabIndex = 109
        Me.lbl_Info_Height_Away.Text = "22"
        '
        'lbl_Info_Age_Away
        '
        Me.lbl_Info_Age_Away.AutoSize = True
        Me.lbl_Info_Age_Away.Location = New System.Drawing.Point(365, 589)
        Me.lbl_Info_Age_Away.Name = "lbl_Info_Age_Away"
        Me.lbl_Info_Age_Away.Size = New System.Drawing.Size(19, 13)
        Me.lbl_Info_Age_Away.TabIndex = 108
        Me.lbl_Info_Age_Away.Text = "22"
        '
        'btn_advertising1
        '
        Me.btn_advertising1.BackColor = System.Drawing.Color.Transparent
        Me.btn_advertising1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_advertising1.Location = New System.Drawing.Point(507, 650)
        Me.btn_advertising1.Name = "btn_advertising1"
        Me.btn_advertising1.Size = New System.Drawing.Size(55, 55)
        Me.btn_advertising1.TabIndex = 110
        Me.btn_advertising1.UseVisualStyleBackColor = False
        '
        'btn_advertising2
        '
        Me.btn_advertising2.BackColor = System.Drawing.Color.Transparent
        Me.btn_advertising2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_advertising2.Location = New System.Drawing.Point(578, 650)
        Me.btn_advertising2.Name = "btn_advertising2"
        Me.btn_advertising2.Size = New System.Drawing.Size(55, 55)
        Me.btn_advertising2.TabIndex = 111
        Me.btn_advertising2.UseVisualStyleBackColor = False
        '
        'btn_advertising3
        '
        Me.btn_advertising3.BackColor = System.Drawing.Color.Transparent
        Me.btn_advertising3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_advertising3.Location = New System.Drawing.Point(720, 651)
        Me.btn_advertising3.Name = "btn_advertising3"
        Me.btn_advertising3.Size = New System.Drawing.Size(55, 55)
        Me.btn_advertising3.TabIndex = 112
        Me.btn_advertising3.UseVisualStyleBackColor = False
        '
        'btn_advertising4
        '
        Me.btn_advertising4.BackColor = System.Drawing.Color.Transparent
        Me.btn_advertising4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_advertising4.Location = New System.Drawing.Point(649, 650)
        Me.btn_advertising4.Name = "btn_advertising4"
        Me.btn_advertising4.Size = New System.Drawing.Size(55, 55)
        Me.btn_advertising4.TabIndex = 113
        Me.btn_advertising4.UseVisualStyleBackColor = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox3.Location = New System.Drawing.Point(3, 635)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(141, 75)
        Me.PictureBox3.TabIndex = 114
        Me.PictureBox3.TabStop = False
        '
        'PictureBox6
        '
        Me.PictureBox6.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox6.Location = New System.Drawing.Point(499, 635)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(284, 75)
        Me.PictureBox6.TabIndex = 115
        Me.PictureBox6.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 636)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 116
        Me.Label3.Text = "penalty cards"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(504, 636)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 13)
        Me.Label6.TabIndex = 117
        Me.Label6.Text = "advertising"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(187, 636)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(44, 13)
        Me.Label9.TabIndex = 119
        Me.Label9.Text = "main ref"
        '
        'PictureBox7
        '
        Me.PictureBox7.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox7.Location = New System.Drawing.Point(179, 635)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(282, 75)
        Me.PictureBox7.TabIndex = 118
        Me.PictureBox7.TabStop = False
        '
        'btn_ref1
        '
        Me.btn_ref1.BackColor = System.Drawing.Color.Transparent
        Me.btn_ref1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_ref1.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ref1.Location = New System.Drawing.Point(184, 650)
        Me.btn_ref1.Name = "btn_ref1"
        Me.btn_ref1.Size = New System.Drawing.Size(55, 55)
        Me.btn_ref1.TabIndex = 120
        Me.btn_ref1.UseVisualStyleBackColor = False
        '
        'btn_ref2
        '
        Me.btn_ref2.BackColor = System.Drawing.Color.Transparent
        Me.btn_ref2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_ref2.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ref2.Location = New System.Drawing.Point(255, 649)
        Me.btn_ref2.Name = "btn_ref2"
        Me.btn_ref2.Size = New System.Drawing.Size(55, 55)
        Me.btn_ref2.TabIndex = 121
        Me.btn_ref2.UseVisualStyleBackColor = False
        '
        'btn_ref3
        '
        Me.btn_ref3.BackColor = System.Drawing.Color.Transparent
        Me.btn_ref3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_ref3.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ref3.Location = New System.Drawing.Point(328, 649)
        Me.btn_ref3.Name = "btn_ref3"
        Me.btn_ref3.Size = New System.Drawing.Size(55, 55)
        Me.btn_ref3.TabIndex = 122
        Me.btn_ref3.UseVisualStyleBackColor = False
        '
        'btn_ref4
        '
        Me.btn_ref4.BackColor = System.Drawing.Color.Transparent
        Me.btn_ref4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_ref4.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ref4.Location = New System.Drawing.Point(399, 649)
        Me.btn_ref4.Name = "btn_ref4"
        Me.btn_ref4.Size = New System.Drawing.Size(55, 55)
        Me.btn_ref4.TabIndex = 123
        Me.btn_ref4.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(263, 636)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(41, 13)
        Me.Label10.TabIndex = 124
        Me.Label10.Text = "ass. ref"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(334, 636)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(35, 13)
        Me.Label11.TabIndex = 125
        Me.Label11.Text = "comm"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(401, 636)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(50, 13)
        Me.Label12.TabIndex = 126
        Me.Label12.Text = "co.comm"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.Label13.Location = New System.Drawing.Point(144, 480)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(438, 13)
        Me.Label13.TabIndex = 127
        Me.Label13.Text = "data1 and 2 as well as facts1 and 2 from the player table are currently not proce" &
    "ssed"
        '
        'TextBox_freename
        '
        Me.TextBox_freename.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox_freename.Location = New System.Drawing.Point(1058, 682)
        Me.TextBox_freename.Name = "TextBox_freename"
        Me.TextBox_freename.Size = New System.Drawing.Size(403, 26)
        Me.TextBox_freename.TabIndex = 128
        '
        'btn_freename6
        '
        Me.btn_freename6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_freename6.Location = New System.Drawing.Point(1479, 678)
        Me.btn_freename6.Name = "btn_freename6"
        Me.btn_freename6.Size = New System.Drawing.Size(64, 30)
        Me.btn_freename6.TabIndex = 121
        Me.btn_freename6.Text = "send"
        Me.btn_freename6.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(1060, 666)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(401, 13)
        Me.Label14.TabIndex = 121
        Me.Label14.Text = "instant freename, if you add a comma in the text line, the text after the coma is" &
    " line 2"
        '
        'Btn_tournament
        '
        Me.Btn_tournament.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_tournament.Location = New System.Drawing.Point(1412, 134)
        Me.Btn_tournament.Name = "Btn_tournament"
        Me.Btn_tournament.Size = New System.Drawing.Size(150, 40)
        Me.Btn_tournament.TabIndex = 129
        Me.Btn_tournament.Text = "Tournament"
        Me.Btn_tournament.UseVisualStyleBackColor = True
        '
        'btn_Intro_venue
        '
        Me.btn_Intro_venue.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Intro_venue.Location = New System.Drawing.Point(1412, 89)
        Me.btn_Intro_venue.Name = "btn_Intro_venue"
        Me.btn_Intro_venue.Size = New System.Drawing.Size(150, 40)
        Me.btn_Intro_venue.TabIndex = 130
        Me.btn_Intro_venue.Text = "Intro Venue"
        Me.btn_Intro_venue.UseVisualStyleBackColor = True
        '
        'PictureBox8
        '
        Me.PictureBox8.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox8.Location = New System.Drawing.Point(1394, 14)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(184, 215)
        Me.PictureBox8.TabIndex = 131
        Me.PictureBox8.TabStop = False
        '
        'PictureBox9
        '
        Me.PictureBox9.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox9.Location = New System.Drawing.Point(1394, 237)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(184, 207)
        Me.PictureBox9.TabIndex = 132
        Me.PictureBox9.TabStop = False
        '
        'Label15
        '
        Me.Label15.ForeColor = System.Drawing.Color.DarkGray
        Me.Label15.Location = New System.Drawing.Point(1414, 244)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(144, 33)
        Me.Label15.TabIndex = 133
        Me.Label15.Text = "Match ID is autofilled Weather Data in SETUP"
        '
        'btn_scorebug_large
        '
        Me.btn_scorebug_large.Location = New System.Drawing.Point(1022, 157)
        Me.btn_scorebug_large.Name = "btn_scorebug_large"
        Me.btn_scorebug_large.Size = New System.Drawing.Size(176, 23)
        Me.btn_scorebug_large.TabIndex = 134
        Me.btn_scorebug_large.Text = "scorebug to large and back"
        Me.btn_scorebug_large.UseVisualStyleBackColor = True
        Me.btn_scorebug_large.Visible = False
        '
        'lblHomePoints
        '
        Me.lblHomePoints.AutoSize = True
        Me.lblHomePoints.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.lblHomePoints.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHomePoints.Location = New System.Drawing.Point(910, 140)
        Me.lblHomePoints.Name = "lblHomePoints"
        Me.lblHomePoints.Size = New System.Drawing.Size(29, 17)
        Me.lblHomePoints.TabIndex = 135
        Me.lblHomePoints.Text = "000"
        Me.lblHomePoints.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblHomePoints.Visible = False
        '
        'lblAwayPoints
        '
        Me.lblAwayPoints.AutoSize = True
        Me.lblAwayPoints.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.lblAwayPoints.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAwayPoints.Location = New System.Drawing.Point(910, 326)
        Me.lblAwayPoints.Name = "lblAwayPoints"
        Me.lblAwayPoints.Size = New System.Drawing.Size(29, 17)
        Me.lblAwayPoints.TabIndex = 136
        Me.lblAwayPoints.Text = "000"
        Me.lblAwayPoints.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblAwayPoints.Visible = False
        '
        'lbl_resetscore_nextset
        '
        Me.lbl_resetscore_nextset.Location = New System.Drawing.Point(1230, 10)
        Me.lbl_resetscore_nextset.Name = "lbl_resetscore_nextset"
        Me.lbl_resetscore_nextset.Size = New System.Drawing.Size(72, 129)
        Me.lbl_resetscore_nextset.TabIndex = 137
        Me.lbl_resetscore_nextset.Text = "reset score for next set"
        Me.lbl_resetscore_nextset.UseVisualStyleBackColor = True
        Me.lbl_resetscore_nextset.Visible = False
        '
        'btn_scorebug
        '
        Me.btn_scorebug.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_scorebug.Location = New System.Drawing.Point(1022, 10)
        Me.btn_scorebug.Name = "btn_scorebug"
        Me.btn_scorebug.Size = New System.Drawing.Size(176, 129)
        Me.btn_scorebug.TabIndex = 138
        Me.btn_scorebug.Text = "scorebug"
        Me.btn_scorebug.UseVisualStyleBackColor = True
        '
        'btn_timeout
        '
        Me.btn_timeout.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_timeout.Location = New System.Drawing.Point(1021, 293)
        Me.btn_timeout.Name = "btn_timeout"
        Me.btn_timeout.Size = New System.Drawing.Size(167, 27)
        Me.btn_timeout.TabIndex = 139
        Me.btn_timeout.Text = "Time Out"
        Me.btn_timeout.UseVisualStyleBackColor = True
        '
        'PictureBox10
        '
        Me.PictureBox10.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox10.Location = New System.Drawing.Point(1012, 195)
        Me.PictureBox10.Name = "PictureBox10"
        Me.PictureBox10.Size = New System.Drawing.Size(186, 130)
        Me.PictureBox10.TabIndex = 140
        Me.PictureBox10.TabStop = False
        '
        'BeachVolleyballScorer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1584, 761)
        Me.ControlBox = False
        Me.Controls.Add(Me.btn_timeout)
        Me.Controls.Add(Me.btn_scorebug)
        Me.Controls.Add(Me.lbl_resetscore_nextset)
        Me.Controls.Add(Me.lblAwayPoints)
        Me.Controls.Add(Me.lblHomePoints)
        Me.Controls.Add(Me.btn_scorebug_large)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.btn_Intro_venue)
        Me.Controls.Add(Me.Btn_tournament)
        Me.Controls.Add(Me.btn_freename6)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.TextBox_freename)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.btn_ref4)
        Me.Controls.Add(Me.btn_ref3)
        Me.Controls.Add(Me.btn_ref2)
        Me.Controls.Add(Me.btn_ref1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.PictureBox7)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btn_advertising4)
        Me.Controls.Add(Me.btn_advertising3)
        Me.Controls.Add(Me.btn_advertising2)
        Me.Controls.Add(Me.btn_advertising1)
        Me.Controls.Add(Me.btn_Info_Away)
        Me.Controls.Add(Me.btn_Info_Home)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_large_result)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label_Winnertext)
        Me.Controls.Add(Me.lblGame_ended)
        Me.Controls.Add(Me.btn_nocolor_Away)
        Me.Controls.Add(Me.btn_nocolor_Home)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.PictureBox_Awaycolor)
        Me.Controls.Add(Me.PictureBox_Homecolor)
        Me.Controls.Add(Me.Button_ClosingTitle)
        Me.Controls.Add(Me.PictureBox_Flag_Away_small)
        Me.Controls.Add(Me.btn_singlename1_Home)
        Me.Controls.Add(Me.PictureBox_Flag_Home_small)
        Me.Controls.Add(Me.lblCurrentServerHome)
        Me.Controls.Add(Me.btn_teamname_Away)
        Me.Controls.Add(Me.btn_redcard)
        Me.Controls.Add(Me.btn_yellowcard)
        Me.Controls.Add(Me.btn_singlename2_Away)
        Me.Controls.Add(Me.btn_singlename1_Away)
        Me.Controls.Add(Me.btn_singlename2_Home)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.btn_OpeningTitle)
        Me.Controls.Add(Me.btn_weather)
        Me.Controls.Add(Me.btn_MatchID)
        Me.Controls.Add(Me.btn_teamname_Home)
        Me.Controls.Add(Me.lbl_Players_Away)
        Me.Controls.Add(Me.lbl_Players_Home)
        Me.Controls.Add(Me.btn_swap_service)
        Me.Controls.Add(Me.lblCurrentServerAway)
        Me.Controls.Add(Me.lbl_Name_Away)
        Me.Controls.Add(Me.PictureBox_Flag_Away)
        Me.Controls.Add(Me.PictureBox_Flag_Home)
        Me.Controls.Add(Me.lblCurrentSet)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lbl_Aufschlag_Home)
        Me.Controls.Add(Me.lbl_Name_Home)
        Me.Controls.Add(Me.btnHomeTeamPoint)
        Me.Controls.Add(Me.btnAwayTeamPoint)
        Me.Controls.Add(Me.lbl_Aufschlag_Away)
        Me.Controls.Add(Me.btnUndo)
        Me.Controls.Add(Me.btnResetGame)
        Me.Controls.Add(Me.lblAwayTeamPoints1)
        Me.Controls.Add(Me.lblAwayTeamPoints2)
        Me.Controls.Add(Me.lblAwayTeamPoints3)
        Me.Controls.Add(Me.lblHomeTeamPoints3)
        Me.Controls.Add(Me.lblHomeTeamPoints2)
        Me.Controls.Add(Me.lblHomeTeamPoints1)
        Me.Controls.Add(Me.lblAwayTeamSets)
        Me.Controls.Add(Me.lblHomeTeamSets)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.lbl_Info_Height_Away)
        Me.Controls.Add(Me.lbl_Info_Age_Away)
        Me.Controls.Add(Me.lbl_Info_Height_Home)
        Me.Controls.Add(Me.lbl_Info_Age_Home)
        Me.Controls.Add(Me.PictureBox6)
        Me.Controls.Add(Me.PictureBox8)
        Me.Controls.Add(Me.PictureBox9)
        Me.Controls.Add(Me.ListBox5)
        Me.Controls.Add(Me.btn_YellowRedcard)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.PictureBox10)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(1600, 800)
        Me.MinimumSize = New System.Drawing.Size(1600, 800)
        Me.Name = "BeachVolleyballScorer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BeachVolleyballScorer"
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox_Flag_Home, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox_Flag_Away, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox_Flag_Home_small, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox_Flag_Away_small, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox_Homecolor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox_Awaycolor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnHomeTeamPoint As Button
    Friend WithEvents btnAwayTeamPoint As Button
    Friend WithEvents lblHomeTeamSets As Label
    Friend WithEvents lblAwayTeamSets As Label
    Friend WithEvents lblCurrentServerHome As Label
    Friend WithEvents lblHomeTeamPoints1 As Label
    Friend WithEvents lblHomeTeamPoints2 As Label
    Friend WithEvents lblHomeTeamPoints3 As Label
    Friend WithEvents lblAwayTeamPoints1 As Label
    Friend WithEvents lblAwayTeamPoints2 As Label
    Friend WithEvents lblAwayTeamPoints3 As Label
    Friend WithEvents lblCurrentSet As Label
    Friend WithEvents btnResetGame As Button
    Friend WithEvents lblGame_ended As Label
    Friend WithEvents btnUndo As Button
    Friend WithEvents lbl_Name_Home As Label
    Friend WithEvents lbl_Aufschlag_Home As Label
    Friend WithEvents lbl_Aufschlag_Away As Label
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox_Flag_Home As PictureBox
    Friend WithEvents PictureBox_Flag_Away As PictureBox
    Friend WithEvents lbl_Name_Away As Label
    Friend WithEvents lblCurrentServerAway As Label
    Friend WithEvents btn_swap_service As Button
    Friend WithEvents lbl_Players_Home As Label
    Friend WithEvents lbl_Players_Away As Label
    Friend WithEvents btn_teamname_Home As Button
    Friend WithEvents btn_MatchID As Button
    Friend WithEvents btn_weather As Button
    Friend WithEvents btn_OpeningTitle As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel5 As ToolStripStatusLabel
    Friend WithEvents lblWinPoints1 As ToolStripStatusLabel
    Friend WithEvents lblWinPoints2 As ToolStripStatusLabel
    Friend WithEvents lblWinPoints3 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel6 As ToolStripStatusLabel
    Friend WithEvents btn_singlename1_Home As Button
    Friend WithEvents btn_singlename2_Home As Button
    Friend WithEvents btn_singlename1_Away As Button
    Friend WithEvents btn_singlename2_Away As Button
    Friend WithEvents btn_yellowcard As Button
    Friend WithEvents btn_redcard As Button
    Friend WithEvents btn_teamname_Away As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents btn_Exit_LIVE As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel7 As ToolStripStatusLabel
    Friend WithEvents btn_YellowRedcard As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents PictureBox_Flag_Home_small As PictureBox
    Friend WithEvents PictureBox_Flag_Away_small As PictureBox
    Friend WithEvents Button_ClosingTitle As Button
    Friend WithEvents PictureBox_Homecolor As PictureBox
    Friend WithEvents PictureBox_Awaycolor As PictureBox
    Friend WithEvents ColorDialog1 As ColorDialog
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents btn_nocolor_Home As Button
    Friend WithEvents btn_nocolor_Away As Button
    Friend WithEvents Label_Winnertext As Label
    Friend WithEvents Timer2 As Timer
    Friend WithEvents Timer3 As Timer
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btn_countdown As Button
    Friend WithEvents btn_playout As Button
    Friend WithEvents btn_start_satellitetransmission As Button
    Friend WithEvents btn_endtransmission As Button
    Friend WithEvents btn_starttransmission As Button
    Friend WithEvents lbl_countdown As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btn_freename5 As Button
    Friend WithEvents btn_freename4 As Button
    Friend WithEvents btn_freename3 As Button
    Friend WithEvents btn_freename2 As Button
    Friend WithEvents btn_freename1 As Button
    Friend WithEvents btn_large_result As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents ToolStripStatusLabel4 As ToolStripStatusLabel
    Friend WithEvents ListBox5 As ListBox
    Friend WithEvents btn_Info_Home As Button
    Friend WithEvents btn_Info_Away As Button
    Friend WithEvents lbl_Info_Age_Home As Label
    Friend WithEvents lbl_Info_Height_Home As Label
    Friend WithEvents lbl_Info_Height_Away As Label
    Friend WithEvents lbl_Info_Age_Away As Label
    Friend WithEvents btn_advertising1 As Button
    Friend WithEvents btn_advertising2 As Button
    Friend WithEvents btn_advertising3 As Button
    Friend WithEvents btn_advertising4 As Button
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents PictureBox7 As PictureBox
    Friend WithEvents btn_ref1 As Button
    Friend WithEvents btn_ref2 As Button
    Friend WithEvents btn_ref3 As Button
    Friend WithEvents btn_ref4 As Button
    Friend WithEvents ToolStripStatusLabel8 As ToolStripStatusLabel
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents TextBox_freename As TextBox
    Friend WithEvents btn_freename6 As Button
    Friend WithEvents Label14 As Label
    Friend WithEvents Btn_tournament As Button
    Friend WithEvents btn_Intro_venue As Button
    Friend WithEvents PictureBox8 As PictureBox
    Friend WithEvents PictureBox9 As PictureBox
    Friend WithEvents Label15 As Label
    Friend WithEvents btn_scorebug_large As Button
    Friend WithEvents lblHomePoints As Label
    Friend WithEvents lblAwayPoints As Label
    Friend WithEvents lbl_resetscore_nextset As Button
    Friend WithEvents btn_scorebug As Button
    Friend WithEvents btn_timeout As Button
    Friend WithEvents PictureBox10 As PictureBox
End Class

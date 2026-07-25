<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class BeachVolley_Main
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BeachVolley_Main))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Button_Save = New System.Windows.Forms.Button()
        Me.Button_Live = New System.Windows.Forms.Button()
        Me.Button_exit = New System.Windows.Forms.Button()
        Me.TextBox_Home = New System.Windows.Forms.TextBox()
        Me.TextBox_Away = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.button_flags = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.btn_charmap = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btn_set_list_of_names = New System.Windows.Forms.Button()
        Me.Button_Countries = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(3, 46)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(1580, 426)
        Me.DataGridView1.TabIndex = 1
        '
        'Button_Save
        '
        Me.Button_Save.BackColor = System.Drawing.Color.LimeGreen
        Me.Button_Save.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Save.Location = New System.Drawing.Point(12, 629)
        Me.Button_Save.Name = "Button_Save"
        Me.Button_Save.Size = New System.Drawing.Size(250, 70)
        Me.Button_Save.TabIndex = 2
        Me.Button_Save.Text = "Save Team Data"
        Me.Button_Save.UseVisualStyleBackColor = False
        '
        'Button_Live
        '
        Me.Button_Live.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Live.Location = New System.Drawing.Point(659, 629)
        Me.Button_Live.Name = "Button_Live"
        Me.Button_Live.Size = New System.Drawing.Size(250, 70)
        Me.Button_Live.TabIndex = 3
        Me.Button_Live.Text = "Live Scoring"
        Me.Button_Live.UseVisualStyleBackColor = True
        '
        'Button_exit
        '
        Me.Button_exit.BackColor = System.Drawing.Color.IndianRed
        Me.Button_exit.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_exit.ForeColor = System.Drawing.Color.White
        Me.Button_exit.Location = New System.Drawing.Point(1412, 629)
        Me.Button_exit.Name = "Button_exit"
        Me.Button_exit.Size = New System.Drawing.Size(160, 70)
        Me.Button_exit.TabIndex = 4
        Me.Button_exit.Text = "EXIT"
        Me.Button_exit.UseVisualStyleBackColor = False
        '
        'TextBox_Home
        '
        Me.TextBox_Home.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox_Home.Location = New System.Drawing.Point(12, 499)
        Me.TextBox_Home.Name = "TextBox_Home"
        Me.TextBox_Home.Size = New System.Drawing.Size(439, 35)
        Me.TextBox_Home.TabIndex = 8
        '
        'TextBox_Away
        '
        Me.TextBox_Away.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox_Away.Location = New System.Drawing.Point(1133, 499)
        Me.TextBox_Away.Name = "TextBox_Away"
        Me.TextBox_Away.Size = New System.Drawing.Size(439, 35)
        Me.TextBox_Away.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.LightYellow
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(1033, 21)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Prepare the team list for the upcoming games, one team per row, pay attention to " &
    "spelling (4-eyes principle)   Be sure to save the data after a change"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 537)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 25)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Home Team"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(1463, 536)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(106, 25)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Away Team"
        '
        'button_flags
        '
        Me.button_flags.Location = New System.Drawing.Point(1464, 8)
        Me.button_flags.Name = "button_flags"
        Me.button_flags.Size = New System.Drawing.Size(105, 23)
        Me.button_flags.TabIndex = 14
        Me.button_flags.Text = "existing flags"
        Me.button_flags.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 21
        Me.ListBox1.Location = New System.Drawing.Point(1069, 37)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(505, 571)
        Me.ListBox1.TabIndex = 15
        Me.ListBox1.Visible = False
        '
        'btn_charmap
        '
        Me.btn_charmap.Location = New System.Drawing.Point(1353, 8)
        Me.btn_charmap.Name = "btn_charmap"
        Me.btn_charmap.Size = New System.Drawing.Size(105, 23)
        Me.btn_charmap.TabIndex = 16
        Me.btn_charmap.Text = "Character table"
        Me.btn_charmap.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.LightYellow
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(476, 591)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(627, 14)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Label5"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.LightYellow
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(479, 487)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(624, 104)
        Me.TextBox1.TabIndex = 18
        Me.TextBox1.Text = resources.GetString("TextBox1.Text")
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(12, 30)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(498, 13)
        Me.Label13.TabIndex = 128
        Me.Label13.Text = "data1 and 2 as well as facts1 and 2 from the player table are currently not proce" &
    "ssed any further"
        '
        'btn_set_list_of_names
        '
        Me.btn_set_list_of_names.Location = New System.Drawing.Point(1069, 8)
        Me.btn_set_list_of_names.Name = "btn_set_list_of_names"
        Me.btn_set_list_of_names.Size = New System.Drawing.Size(100, 23)
        Me.btn_set_list_of_names.TabIndex = 129
        Me.btn_set_list_of_names.Text = "Sample Data"
        Me.btn_set_list_of_names.UseVisualStyleBackColor = True
        '
        'Button_Countries
        '
        Me.Button_Countries.Location = New System.Drawing.Point(1215, 8)
        Me.Button_Countries.Name = "Button_Countries"
        Me.Button_Countries.Size = New System.Drawing.Size(132, 23)
        Me.Button_Countries.TabIndex = 130
        Me.Button_Countries.Text = "Country Codes ISO3"
        Me.Button_Countries.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = Global.BeachvolleyballScorer.My.Resources.Resources.volleyball
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.Location = New System.Drawing.Point(499, 440)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(579, 455)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 131
        Me.PictureBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(302, 629)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(149, 23)
        Me.Button1.TabIndex = 132
        Me.Button1.Text = "load extra data"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(302, 676)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(149, 23)
        Me.Button2.TabIndex = 133
        Me.Button2.Text = "save extra data"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'BeachVolley_Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1584, 711)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button_Countries)
        Me.Controls.Add(Me.btn_set_list_of_names)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btn_charmap)
        Me.Controls.Add(Me.button_flags)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextBox_Away)
        Me.Controls.Add(Me.TextBox_Home)
        Me.Controls.Add(Me.Button_exit)
        Me.Controls.Add(Me.Button_Live)
        Me.Controls.Add(Me.Button_Save)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(1600, 750)
        Me.MinimumSize = New System.Drawing.Size(1600, 750)
        Me.Name = "BeachVolley_Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BeachVolley_Main"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button_Save As Button
    Friend WithEvents Button_Live As Button
    Friend WithEvents Button_exit As Button
    Friend WithEvents TextBox_Home As TextBox
    Friend WithEvents TextBox_Away As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents button_flags As Button
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents btn_charmap As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents btn_set_list_of_names As Button
    Friend WithEvents Button_Countries As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
End Class

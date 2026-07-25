Imports System.IO
Imports System.Net.Sockets
Imports System.Xml

Public Class BeachVolley_Main
    Private Tabelle As New DataTable("Tabelle") ' Assigning name to DataTable
    Private directoryPath As String = "C:\VMIX\Beachvolleyball"
    Private settingxmlFilePath As String = "C:\VMIX\beachvolleyball\settings.xml"
    Private settingIP As String = String.Empty
    Private settingPORT As Integer = 8088


    Public ActualHomeTeam As String = ""
    Public ActualAwayTeam As String = ""

    Public Master_Home_CountryL, Master_Home_CountryS, Master_Home_NAME1, Master_Home_First_Name1, Master_Home_Age1, Master_Home_Height1, Master_Home_Data1_1, Master_Home_Data2_1, Master_Home_Fact1, Master_Home_Fact2 As String
    Public Master_Home_NAME2, Master_Home_First_Name2, Master_Home_Age2, Master_Home_Height2, Master_Home_Data1_2, Master_Home_Data2_2 As String

    Public Master_Away_CountryL, Master_Away_CountryS, Master_Away_NAME1, Master_Away_First_Name1, Master_Away_Age1, Master_Away_Height1, Master_Away_Data1_1, Master_Away_Data2_1, Master_Away_Fact1, Master_Away_Fact2 As String
    Public Master_Away_NAME2, Master_Away_First_Name2, Master_Away_Age2, Master_Away_Height2, Master_Away_Data1_2, Master_Away_Data2_2 As String

    Private FlaglistON As Boolean = False
    Private CountrylistON As Boolean = False

    Private Sub BeachVolley_Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSettingIP()
        CheckConnection()
        Try
            Load_XML()

            DataGridView1.DataSource = Tabelle
            DataGridView1.Font = New Font("Segoe UI", 10)
            DataGridView1.EnableHeadersVisualStyles = False
            DataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
            DataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells)

            DataGridView1.Columns("NAME1").HeaderCell.Style.BackColor = Color.LightBlue
            DataGridView1.Columns("First_Name1").HeaderCell.Style.BackColor = Color.LightBlue
            DataGridView1.Columns("Age1").HeaderCell.Style.BackColor = Color.LightBlue
            DataGridView1.Columns("Height1").HeaderCell.Style.BackColor = Color.LightBlue
            DataGridView1.Columns("Data1_1").HeaderCell.Style.BackColor = Color.LightBlue
            DataGridView1.Columns("Data2_1").HeaderCell.Style.BackColor = Color.LightBlue

            DataGridView1.Columns("NAME1").DefaultCellStyle.BackColor = Color.LightBlue
            DataGridView1.Columns("First_Name1").DefaultCellStyle.BackColor = Color.LightBlue
            DataGridView1.Columns("Age1").DefaultCellStyle.BackColor = Color.LightBlue
            DataGridView1.Columns("Height1").DefaultCellStyle.BackColor = Color.LightBlue
            DataGridView1.Columns("Data1_1").DefaultCellStyle.BackColor = Color.LightBlue
            DataGridView1.Columns("Data2_1").DefaultCellStyle.BackColor = Color.LightBlue

            DataGridView1.Columns("NAME2").HeaderCell.Style.BackColor = Color.LightYellow
            DataGridView1.Columns("First_Name2").HeaderCell.Style.BackColor = Color.LightYellow
            DataGridView1.Columns("Age2").HeaderCell.Style.BackColor = Color.LightYellow
            DataGridView1.Columns("Height2").HeaderCell.Style.BackColor = Color.LightYellow
            DataGridView1.Columns("Data1_2").HeaderCell.Style.BackColor = Color.LightYellow
            DataGridView1.Columns("Data2_2").HeaderCell.Style.BackColor = Color.LightYellow

            DataGridView1.Columns("NAME2").DefaultCellStyle.BackColor = Color.LightYellow
            DataGridView1.Columns("First_Name2").DefaultCellStyle.BackColor = Color.LightYellow
            DataGridView1.Columns("Age2").DefaultCellStyle.BackColor = Color.LightYellow
            DataGridView1.Columns("Height2").DefaultCellStyle.BackColor = Color.LightYellow
            DataGridView1.Columns("Data1_2").DefaultCellStyle.BackColor = Color.LightYellow
            DataGridView1.Columns("Data2_2").DefaultCellStyle.BackColor = Color.LightYellow

            Me.Text = My.Application.Info.Title & "  MainScreen  " & My.Application.Info.Version.ToString + "  -  " & My.Application.Info.CompanyName + " - " & My.Application.Info.Copyright

            ' Enable drag and drop for TextBoxes
            TextBox_Home.AllowDrop = True
            TextBox_Away.AllowDrop = True

            ' Add event handlers for drag and drop
            AddHandler DataGridView1.MouseDown, AddressOf DataGridView1_MouseDown
            AddHandler TextBox_Home.DragEnter, AddressOf TextBox_DragEnter
            AddHandler TextBox_Home.DragDrop, AddressOf TextBox_Home_DragDrop
            AddHandler TextBox_Away.DragEnter, AddressOf TextBox_DragEnter
            AddHandler TextBox_Away.DragDrop, AddressOf TextBox_Away_DragDrop

        Catch ex As Exception
            MessageBox.Show($"Error loading form: {ex.Message}", "Error1", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        UpdateHomeVariablesFromTextBox()
        UpdateAwayVariablesFromTextBox()
        BeachVolleyballScorer.RESET_btncolors()
    End Sub

    Private Sub DataGridView1_MouseDown(sender As Object, e As MouseEventArgs)
        Try
            If DataGridView1.SelectedRows.Count > 0 Then
                DataGridView1.DoDragDrop(DataGridView1.SelectedRows(0), DragDropEffects.Copy)
            End If
        Catch ex As Exception
            MessageBox.Show($"An error occurred during drag and drop: {ex.Message}", "Error2", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TextBox_DragEnter(sender As Object, e As DragEventArgs)
        Try
            If e.Data.GetDataPresent(GetType(DataGridViewRow)) Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.None
            End If
        Catch ex As Exception
            MessageBox.Show($"An error occurred during drag enter: {ex.Message}", "Error3", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TextBox_Home_DragDrop(sender As Object, e As DragEventArgs)
        Try
            ' Clear previous team colors
            BeachVolleyballScorer.RESET_btncolors()

            Dim row As DataGridViewRow = CType(e.Data.GetData(GetType(DataGridViewRow)), DataGridViewRow)
            TextBox_Home.Text = row.Cells("CountryL").Value.ToString()
            FillHomeVariables(row)
        Catch ex As Exception
            MessageBox.Show($"An error occurred during drag drop: {ex.Message}", "Error4", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        ActualHomeTeam = TextBox_Home.Text
        If TextBox_Home.Text <> "" And TextBox_Away.Text <> "" Then Update_Teamvariables()
    End Sub

    Private Sub TextBox_Away_DragDrop(sender As Object, e As DragEventArgs)
        Try
            ' Clear previous team colors
            BeachVolleyballScorer.RESET_btncolors()

            Dim row As DataGridViewRow = CType(e.Data.GetData(GetType(DataGridViewRow)), DataGridViewRow)
            TextBox_Away.Text = row.Cells("CountryL").Value.ToString()
            FillAwayVariables(row)
        Catch ex As Exception
            MessageBox.Show($"An error occurred during drag drop: {ex.Message}", "Error5", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        ActualAwayTeam = TextBox_Away.Text
        If TextBox_Home.Text <> "" And TextBox_Away.Text <> "" Then Update_Teamvariables()
    End Sub

    Private Sub FillHomeVariables(row As DataGridViewRow)
        Master_Home_CountryL = row.Cells("CountryL").Value.ToString().Trim
        Master_Home_CountryS = row.Cells("CountryS").Value.ToString().Trim

        Master_Home_NAME1 = row.Cells("NAME1").Value.ToString().Trim
        Master_Home_First_Name1 = row.Cells("First_Name1").Value.ToString().Trim
        Master_Home_Age1 = row.Cells("Age1").Value.ToString().Trim
        Master_Home_Height1 = row.Cells("Height1").Value.ToString().Trim
        Master_Home_Data1_1 = row.Cells("Data1_1").Value.ToString().Trim
        Master_Home_Data2_1 = row.Cells("Data2_1").Value.ToString().Trim

        Master_Home_NAME2 = row.Cells("NAME2").Value.ToString().Trim
        Master_Home_First_Name2 = row.Cells("First_Name2").Value.ToString().Trim
        Master_Home_Age2 = row.Cells("Age2").Value.ToString().Trim
        Master_Home_Height2 = row.Cells("Height2").Value.ToString().Trim
        Master_Home_Data1_2 = row.Cells("Data1_2").Value.ToString().Trim
        Master_Home_Data2_2 = row.Cells("Data2_2").Value.ToString().Trim

        Master_Home_Fact1 = row.Cells("Fact1").Value.ToString().Trim
        Master_Home_Fact2 = row.Cells("Fact2").Value.ToString().Trim
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Load_XML_dialog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            MsgBox("The 'save extra data' option only saves one table. This allows you to prepare several tables in advance. If you want to load one of the prepared tables, you can also use the extra button 'load extra data'")
            Save_Data_Settings_dialog()
        Catch ex As Exception
            MessageBox.Show($"Error saving data: {ex.Message}", "Error11", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FillAwayVariables(row As DataGridViewRow)
        Master_Away_CountryL = row.Cells("CountryL").Value.ToString().Trim
        Master_Away_CountryS = row.Cells("CountryS").Value.ToString().Trim

        Master_Away_NAME1 = row.Cells("NAME1").Value.ToString().Trim
        Master_Away_First_Name1 = row.Cells("First_Name1").Value.ToString().Trim
        Master_Away_Age1 = row.Cells("Age1").Value.ToString().Trim
        Master_Away_Height1 = row.Cells("Height1").Value.ToString().Trim
        Master_Away_Data1_1 = row.Cells("Data1_1").Value.ToString().Trim
        Master_Away_Data2_1 = row.Cells("Data2_1").Value.ToString().Trim

        Master_Away_NAME2 = row.Cells("NAME2").Value.ToString()
        Master_Away_First_Name2 = row.Cells("First_Name2").Value.ToString().Trim
        Master_Away_Age2 = row.Cells("Age2").Value.ToString().Trim
        Master_Away_Height2 = row.Cells("Height2").Value.ToString().Trim
        Master_Away_Data1_2 = row.Cells("Data1_2").Value.ToString().Trim
        Master_Away_Data2_2 = row.Cells("Data2_2").Value.ToString().Trim

        Master_Away_Fact1 = row.Cells("Fact1").Value.ToString().Trim
        Master_Away_Fact2 = row.Cells("Fact2").Value.ToString().Trim
    End Sub

    Private Sub TextBox_Away_TextChanged(sender As Object, e As EventArgs)
        UpdateAwayVariablesFromTextBox()
    End Sub

    Private Sub UpdateHomeVariablesFromTextBox()
        Dim homeName As String = TextBox_Home.Text
        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.Cells("CountryL").Value IsNot Nothing AndAlso row.Cells("CountryL").Value.ToString() = homeName Then
                FillHomeVariables(row)
                Exit For
            End If
        Next
    End Sub

    Private Sub UpdateAwayVariablesFromTextBox()
        Dim awayName As String = TextBox_Away.Text
        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.Cells("CountryL").Value IsNot Nothing AndAlso row.Cells("CountryL").Value.ToString() = awayName Then
                FillAwayVariables(row)
                Exit For
            End If
        Next
    End Sub

    Sub Load_XML()
        Try
            ' Check if directory exists, if not create it
            If Not Directory.Exists(directoryPath) Then
                Directory.CreateDirectory(directoryPath)
            End If

            ' Check if XML file exists, if not create it
            Dim filename As String = Path.Combine(directoryPath, "volley.xml")
            If Not File.Exists(filename) Then
                InitializeDataTable()
                Tabelle.WriteXml(filename, XmlWriteMode.WriteSchema)
            Else
                Try
                    ' Clear existing data from DataTable
                    Tabelle.Clear()
                    ' Read data from XML file into DataTable
                    Tabelle.ReadXml(filename)
                Catch ex As Exception
                    ' XML file exists but cannot be read, reinitialize DataTable and recreate XML file
                    MessageBox.Show($"Error reading XML file: {ex.Message}. Recreating XML file.", "Error6", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    InitializeDataTable()
                    Tabelle.WriteXml(filename, XmlWriteMode.WriteSchema)
                End Try
            End If
            DataGridView1.DataSource = Tabelle

            ' Load saved TextBox selections
            LoadTextBoxSelections(filename)
        Catch ex As Exception
            MessageBox.Show($"Error loading XML: {ex.Message}", "Error7", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub Load_XML_dialog()
        Try
            Dim openFileDialog As New OpenFileDialog()
            openFileDialog.InitialDirectory = "C:\VMIX\Beachvolleyball"
            openFileDialog.Filter = "XML files (*.xml)|*.xml"
            openFileDialog.FileName = "volley.xml"

            ' Zeige den File Dialog und warte auf die Auswahl des Benutzers
            If openFileDialog.ShowDialog() = DialogResult.OK Then
                Dim filename As String = openFileDialog.FileName

                ' Check if XML file exists, if not create it
                If Not File.Exists(filename) Then
                    InitializeDataTable()
                    Tabelle.WriteXml(filename, XmlWriteMode.WriteSchema)
                Else
                    Try
                        ' Clear existing data from DataTable
                        Tabelle.Clear()
                        ' Read data from XML file into DataTable
                        Tabelle.ReadXml(filename)
                    Catch ex As Exception
                        ' XML file exists but cannot be read, reinitialize DataTable and recreate XML file
                        MessageBox.Show($"Error reading XML file: {ex.Message}. Recreating XML file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        InitializeDataTable()
                        Tabelle.WriteXml(filename, XmlWriteMode.WriteSchema)
                    End Try
                End If

                DataGridView1.DataSource = Tabelle

                ' Load saved TextBox selections
                LoadTextBoxSelections(filename)
            End If
        Catch ex As Exception
            MessageBox.Show($"Error loading XML: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub LoadTextBoxSelections(filename As String)
        Try
            Dim doc As New XmlDocument()
            doc.Load(filename)
            Dim settingsNodes = doc.SelectNodes("//Settings")

            If settingsNodes IsNot Nothing Then
                For Each node As XmlNode In settingsNodes
                    Dim settingName = node.SelectSingleNode("SettingName")?.InnerText
                    Dim settingValue = node.SelectSingleNode("SettingValue")?.InnerText

                    If settingName = "HomeTeam" Then
                        TextBox_Home.Text = settingValue
                        ActualHomeTeam = settingValue
                    ElseIf settingName = "AwayTeam" Then
                        TextBox_Away.Text = settingValue
                        ActualAwayTeam = settingValue
                    End If
                Next
            End If
        Catch ex As Exception
            MessageBox.Show($"Error loading settings: {ex.Message}", "Error8", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button_Live_Click(sender As Object, e As EventArgs) Handles Button_Live.Click
        'update teamvariables has to be first, otherwise the form starts without valid variables

        If String.IsNullOrWhiteSpace(TextBox_Home.Text) OrElse String.IsNullOrWhiteSpace(TextBox_Away.Text) Then
            ' Ihr Code hier, wenn mindestens eines der Textfelder leer ist
            MessageBox.Show("Please select the two playing teams first")
        Else
            If TextBox_Home.Text <> "" And TextBox_Away.Text <> "" Then Update_Teamvariables()
            If TextBox_Home.Text <> "" Then UpdateHomeVariablesFromTextBox()
            If TextBox_Away.Text <> "" Then UpdateAwayVariablesFromTextBox()
            Try
                    BeachVolleyballScorer.Show()
                    Me.Hide()
                Catch ex As Exception
                    MessageBox.Show($"Error opening BeachVolleyballScorer: {ex.Message}", "Error9", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If

    End Sub

    Sub Update_Teamvariables()
        ' update for live form also
        ' Assign values to the public variables of BeachVolleyballScorer
        BeachVolleyballScorer.Home_CountryL = Me.Master_Home_CountryL
        BeachVolleyballScorer.Home_CountryS = Me.Master_Home_CountryS

        BeachVolleyballScorer.Home_NAME1 = Me.Master_Home_NAME1
        BeachVolleyballScorer.Home_First_Name1 = Me.Master_Home_First_Name1
        BeachVolleyballScorer.Home_Age1 = Me.Master_Home_Age1
        BeachVolleyballScorer.Home_Height1 = Me.Master_Home_Height1
        BeachVolleyballScorer.Home_Data1_1 = Me.Master_Home_Data1_1
        BeachVolleyballScorer.Home_Data2_1 = Me.Master_Home_Data2_1

        BeachVolleyballScorer.Home_NAME2 = Me.Master_Home_NAME2
        BeachVolleyballScorer.Home_First_Name2 = Me.Master_Home_First_Name2
        BeachVolleyballScorer.Home_Age2 = Me.Master_Home_Age2
        BeachVolleyballScorer.Home_Height2 = Me.Master_Home_Height2
        BeachVolleyballScorer.Home_Data1_2 = Me.Master_Home_Data1_2
        BeachVolleyballScorer.Home_Data2_2 = Me.Master_Home_Data2_2

        BeachVolleyballScorer.Home_Fact1 = Me.Master_Home_Fact1
        BeachVolleyballScorer.Home_Fact2 = Me.Master_Home_Fact2

        'AWAY TEAM Variablenübergabe
        BeachVolleyballScorer.Away_CountryL = Me.Master_Away_CountryL
        BeachVolleyballScorer.Away_CountryS = Me.Master_Away_CountryS

        BeachVolleyballScorer.Away_NAME1 = Me.Master_Away_NAME1
        BeachVolleyballScorer.Away_First_Name1 = Me.Master_Away_First_Name1
        BeachVolleyballScorer.Away_Age1 = Me.Master_Away_Age1
        BeachVolleyballScorer.Away_Height1 = Me.Master_Away_Height1
        BeachVolleyballScorer.Away_Data1_1 = Me.Master_Away_Data1_1
        BeachVolleyballScorer.Away_Data2_1 = Me.Master_Away_Data2_1

        BeachVolleyballScorer.Away_NAME2 = Me.Master_Away_NAME2
        BeachVolleyballScorer.Away_First_Name2 = Me.Master_Away_First_Name2
        BeachVolleyballScorer.Away_Age2 = Me.Master_Away_Age2
        BeachVolleyballScorer.Away_Height2 = Me.Master_Away_Height2
        BeachVolleyballScorer.Away_Data1_2 = Me.Master_Away_Data1_2
        BeachVolleyballScorer.Away_Data2_2 = Me.Master_Away_Data2_2

        BeachVolleyballScorer.Away_Fact1 = Me.Master_Away_Fact1
        BeachVolleyballScorer.Away_Fact2 = Me.Master_Away_Fact2
        BeachVolleyballScorer.FlaggeHome()
        BeachVolleyballScorer.FlaggeAway()

        BeachVolleyballScorer.btnHomeTeamPoint.Text = BeachVolleyballScorer.Home_CountryS & Environment.NewLine & "POINT PLUS" & Environment.NewLine & "+"
        BeachVolleyballScorer.btnAwayTeamPoint.Text = BeachVolleyballScorer.Away_CountryS & Environment.NewLine & "POINT PLUS" & Environment.NewLine & "+"

        BeachVolleyballScorer.HomeTeam = ActualHomeTeam
        BeachVolleyballScorer.AwayTeam = ActualAwayTeam

        BeachVolleyballScorer.lbl_Name_Home.Text = ActualHomeTeam
        BeachVolleyballScorer.lbl_Name_Away.Text = ActualAwayTeam
        BeachVolleyballScorer.lbl_Players_Home.Text = BeachVolleyballScorer.Home_First_Name1.Substring(0, 1) + ". " + BeachVolleyballScorer.Home_NAME1 + " / " + BeachVolleyballScorer.Home_First_Name2.Substring(0, 1) + ". " + BeachVolleyballScorer.Home_NAME2
        BeachVolleyballScorer.lbl_Players_Away.Text = BeachVolleyballScorer.Away_First_Name1.Substring(0, 1) + ". " + BeachVolleyballScorer.Away_NAME1 + " / " + BeachVolleyballScorer.Away_First_Name2.Substring(0, 1) + ". " + BeachVolleyballScorer.Away_NAME2

        BeachVolleyballScorer.btn_singlename1_Home.Text = BeachVolleyballScorer.Home_CountryS & " Player 1" & Environment.NewLine & BeachVolleyballScorer.Home_First_Name1 + " " + BeachVolleyballScorer.Home_NAME1
        BeachVolleyballScorer.btn_singlename2_Home.Text = BeachVolleyballScorer.Home_CountryS & " Player 2" & Environment.NewLine & BeachVolleyballScorer.Home_First_Name2 + " " + BeachVolleyballScorer.Home_NAME2
        BeachVolleyballScorer.btn_singlename1_Away.Text = BeachVolleyballScorer.Away_CountryS & " Player 1" & Environment.NewLine & BeachVolleyballScorer.Away_First_Name1 + " " + BeachVolleyballScorer.Away_NAME1
        BeachVolleyballScorer.btn_singlename2_Away.Text = BeachVolleyballScorer.Away_CountryS & " Player 2" & Environment.NewLine & BeachVolleyballScorer.Away_First_Name2 + " " + BeachVolleyballScorer.Away_NAME2

        BeachVolleyballScorer.btn_teamname_Home.Text = BeachVolleyballScorer.Home_CountryS & Environment.NewLine & "Team Name"
        BeachVolleyballScorer.btn_teamname_Away.Text = BeachVolleyballScorer.Away_CountryS & Environment.NewLine & "Team Name"
    End Sub

    Sub Label_Buttons_BeachvolleyballScorer()
        BeachVolleyballScorer.btnHomeTeamPoint.Text = ""
    End Sub

    Private Sub Button_exit_Click(sender As Object, e As EventArgs) Handles Button_exit.Click
        Try
            If MessageBox.Show("Programm wirklich beenden ?", "Beach Volleyball Scorer", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                Application.Exit()
            End If
        Catch ex As Exception
            MessageBox.Show($"Error exiting application: {ex.Message}", "Error10", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button_Save_Click(sender As Object, e As EventArgs) Handles Button_Save.Click
        Try
            Save_Data_Settings()
            MessageBox.Show("Data saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Load_XML()
            ActualHomeTeam = TextBox_Home.Text
            ActualAwayTeam = TextBox_Away.Text

            BeachVolleyballScorer.lbl_Name_Home.Text = ActualHomeTeam
            BeachVolleyballScorer.lbl_Name_Away.Text = ActualAwayTeam
            ' BeachVolleyballScorer.lbl_Players_Home.Text = BeachVolleyballScorer.Home_First_Name1.Substring(0, 1) + ". " + BeachVolleyballScorer.Home_NAME1 + " / " + BeachVolleyballScorer.Home_First_Name2.Substring(0, 1) + ". " + BeachVolleyballScorer.Home_NAME2
            'BeachVolleyballScorer.lbl_Players_Away.Text = BeachVolleyballScorer.Away_First_Name1.Substring(0, 1) + ". " + BeachVolleyballScorer.Away_NAME1 + " / " + BeachVolleyballScorer.Away_First_Name2.Substring(0, 1) + ". " + BeachVolleyballScorer.Away_NAME2

            BeachVolleyballScorer.HomeTeam = ActualHomeTeam
            BeachVolleyballScorer.AwayTeam = ActualAwayTeam
            DataGridView1.Refresh()

        Catch ex As Exception
            MessageBox.Show($"Error saving data: {ex.Message}", "Error11", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        If TextBox_Home.Text <> "" And TextBox_Away.Text <> "" Then Update_Teamvariables()
        CheckForMissingFlags()
    End Sub


    Sub Save_Data_Settings()
        Try
            ' End editing if a cell is currently being edited
            If DataGridView1.IsCurrentCellInEditMode Then
                DataGridView1.EndEdit()
            End If

            ' Remove empty rows
            RemoveEmptyRows(Tabelle)

            ' Check if DataTable has rows
            If Tabelle.Rows.Count = 0 Then
                InitializeDataTable()
                Tabelle.WriteXml("C:\VMIX\Beachvolley\volley.xml", XmlWriteMode.WriteSchema)
                MessageBox.Show("No data to save. Default data added.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim ds As New DataSet()
            ds.Tables.Add(Tabelle.Copy())

            ' Add TextBox selections to XML
            AddTextBoxSelections(ds)

            ' Write DataSet to XML file
            Dim filename As String = Path.Combine(directoryPath, "volley.xml")
            ds.WriteXml(filename, XmlWriteMode.WriteSchema)

        Catch ex As Exception
            MessageBox.Show($"An error occurred while saving data: {ex.Message}", "Error12", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub Save_Data_Settings_dialog()
        Try
            ' End editing if a cell is currently being edited
            If DataGridView1.IsCurrentCellInEditMode Then
                DataGridView1.EndEdit()
            End If

            ' Remove empty rows
            RemoveEmptyRows(Tabelle)

            '' Check if DataTable has rows
            'If Tabelle.Rows.Count = 0 Then
            '    InitializeDataTable()
            '    Dim defaultFilename As String = "C:\VMIX\Beachvolleyball\volley_extra.xml"
            '    Tabelle.WriteXml(defaultFilename, XmlWriteMode.WriteSchema)
            '    MessageBox.Show("No data to save. Default data added.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    Exit Sub
            'End If

            Dim ds As New DataSet()
            ds.Tables.Add(Tabelle.Copy())

            ' Add TextBox selections to XML
            AddTextBoxSelections(ds)

            ' Create and configure SaveFileDialog
            Dim saveFileDialog As New SaveFileDialog()
            saveFileDialog.InitialDirectory = "C:\VMIX\Beachvolleyball"
            'saveFileDialog.FileName = "volley_extra.xml"
            saveFileDialog.Filter = "XML files (*.xml)|*.xml"

            ' Show SaveFileDialog and wait for user input
            If saveFileDialog.ShowDialog() = DialogResult.OK Then
                Dim filename As String = saveFileDialog.FileName

                ' Write DataSet to XML file
                ds.WriteXml(filename, XmlWriteMode.WriteSchema)
                MessageBox.Show($"Data saved successfully to {filename}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                ' Optional: Show message if user cancels without selecting a file
                MessageBox.Show("No file selected. Data was not saved.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show($"An error occurred while saving data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub AddTextBoxSelections(ds As DataSet)
        Try
            Dim settingsTable As New DataTable("Settings")
            settingsTable.Columns.Add("SettingName")
            settingsTable.Columns.Add("SettingValue")

            settingsTable.Rows.Add("HomeTeam", TextBox_Home.Text)
            settingsTable.Rows.Add("AwayTeam", TextBox_Away.Text)

            ds.Tables.Add(settingsTable)
        Catch ex As Exception
            MessageBox.Show($"An error occurred while adding TextBox selections: {ex.Message}", "Error13", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub RemoveEmptyRows(table As DataTable)
        Try
            For i As Integer = table.Rows.Count - 1 To 0 Step -1
                If table.Rows(i).ItemArray.All(Function(item) String.IsNullOrEmpty(item?.ToString())) Then
                    table.Rows(i).Delete()
                End If
            Next
        Catch ex As Exception
            MessageBox.Show($"An error occurred while removing empty rows: {ex.Message}", "Error14", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub InitializeDataTable()
        Try
            Tabelle.Columns.Add("CountryL", GetType(String))
            Tabelle.Columns.Add("CountryS", GetType(String))
            Tabelle.Columns.Add("NAME1", GetType(String))
            Tabelle.Columns.Add("First_Name1", GetType(String))
            Tabelle.Columns.Add("Age1", GetType(String))
            Tabelle.Columns.Add("Height1", GetType(String))
            Tabelle.Columns.Add("Data1_1", GetType(String))
            Tabelle.Columns.Add("Data2_1", GetType(String))

            Tabelle.Columns.Add("NAME2", GetType(String))
            Tabelle.Columns.Add("First_Name2", GetType(String))
            Tabelle.Columns.Add("Age2", GetType(String))
            Tabelle.Columns.Add("Height2", GetType(String))
            Tabelle.Columns.Add("Data1_2", GetType(String))
            Tabelle.Columns.Add("Data2_2", GetType(String))

            Tabelle.Columns.Add("Fact1", GetType(String))
            Tabelle.Columns.Add("Fact2", GetType(String))


            ' Add a default row to avoid XML serialization issues
            Tabelle.Rows.Add(Tabelle.NewRow())
            DataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)

            DataGridView1.Refresh()

        Catch ex As Exception
            MessageBox.Show($"An error occurred while initializing the data table: {ex.Message}", "Error15", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        ' Spaltenbreiten anpassen, wenn eine Zelle verlassen wird
        DataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
    End Sub

    Private Sub button_flags_Click(sender As Object, e As EventArgs) Handles button_flags.Click
        ListBox1.Items.Clear()
        If FlaglistON = False Then
            ListBox1.Visible = True
            ListBox1.BringToFront()

            ' Specify the directory you want to search in
            Dim flagsPath As String = Path.Combine(directoryPath, "flags")

            ' Check if directory exists, create if not
            If Not Directory.Exists(flagsPath) Then
                Directory.CreateDirectory(flagsPath)
                MessageBox.Show("Das Flags-Verzeichnis wurde erstellt. Bitte fügen Sie PNG-Dateien hinzu: " & flagsPath, "Verzeichnis erstellt", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            ' Get all .png files in the specified directory
            Dim pngFiles As String() = Directory.GetFiles(flagsPath, "*.png")

            ' Clear the listbox before adding new items
            ListBox1.Items.Clear()

            ' Add the .png files to the listbox
            For Each file As String In pngFiles
                ListBox1.Items.Add(Path.GetFileName(file))
            Next
            FlaglistON = True
        Else
            FlaglistON = False
            ListBox1.Visible = False
        End If
    End Sub

    Private Sub Button_Countries_Click(sender As Object, e As EventArgs) Handles Button_Countries.Click
        ListBox1.Items.Clear()
        If CountrylistON = False Then
            ListBox1.Visible = True
            ListBox1.BringToFront()
            ' Define the list of countries with their ISO3 codes
            Dim countries As New List(Of String) From {
            "Afghanistan (AFG)",
            "Albania (ALB)",
            "Algeria (DZA)",
            "American Samoa (ASM)",
            "Andorra (AND)",
            "Angola (AGO)",
            "Anguilla (AIA)",
            "Antarctica (ATA)",
            "Antigua and Barbuda (ATG)",
            "Argentina (ARG)",
            "Armenia (ARM)",
            "Aruba (ABW)",
            "Australia (AUS)",
            "Austria (AUT)",
            "Azerbaijan (AZE)",
            "Bahamas (the) (BHS)",
            "Bahrain (BHR)",
            "Bangladesh (BGD)",
            "Barbados (BRB)",
            "Belarus (BLR)",
            "Belgium (BEL)",
            "Belize (BLZ)",
            "Benin (BEN)",
            "Bermuda (BMU)",
            "Bhutan (BTN)",
            "Bolivia (Plurinational State of) (BOL)",
            "Bonaire, Sint Eustatius and Saba (BES)",
            "Bosnia and Herzegovina (BIH)",
            "Botswana (BWA)",
            "Bouvet Island (BVT)",
            "Brazil (BRA)",
            "British Indian Ocean Territory (the) (IOT)",
            "Brunei Darussalam (BRN)",
            "Bulgaria (BGR)",
            "Burkina Faso (BFA)",
            "Burundi (BDI)",
            "Cabo Verde (CPV)",
            "Cambodia (KHM)",
            "Cameroon (CMR)",
            "Canada (CAN)",
            "Cayman Islands (the) (CYM)",
            "Central African Republic (the) (CAF)",
            "Chad (TCD)",
            "Chile (CHL)",
            "China (CHN)",
            "Christmas Island (CXR)",
            "Cocos (Keeling) Islands (the) (CCK)",
            "Colombia (COL)",
            "Comoros (the) (COM)",
            "Congo (the Democratic Republic of the) (COD)",
            "Congo (the) (COG)",
            "Cook Islands (the) (COK)",
            "Costa Rica (CRI)",
            "Croatia (HRV)",
            "Cuba (CUB)",
            "Curaçao (CUW)",
            "Cyprus (CYP)",
            "Czechia (CZE)",
            "Côte d'Ivoire (CIV)",
            "Denmark (DNK)",
            "Djibouti (DJI)",
            "Dominica (DMA)",
            "Dominican Republic (the) (DOM)",
            "Ecuador (ECU)",
            "Egypt (EGY)",
            "El Salvador (SLV)",
            "Equatorial Guinea (GNQ)",
            "Eritrea (ERI)",
            "Estonia (EST)",
            "Eswatini (SWZ)",
            "Ethiopia (ETH)",
            "Falkland Islands (the) [Malvinas] (FLK)",
            "Faroe Islands (the) (FRO)",
            "Fiji (FJI)",
            "Finland (FIN)",
            "France (FRA)",
            "French Guiana (GUF)",
            "French Polynesia (PYF)",
            "French Southern Territories (the) (ATF)",
            "Gabon (GAB)",
            "Gambia (the) (GMB)",
            "Georgia (GEO)",
            "Germany (DEU)",
            "Ghana (GHA)",
            "Gibraltar (GIB)",
            "Greece (GRC)",
            "Greenland (GRL)",
            "Grenada (GRD)",
            "Guadeloupe (GLP)",
            "Guam (GUM)",
            "Guatemala (GTM)",
            "Guernsey (GGY)",
            "Guinea (GIN)",
            "Guinea-Bissau (GNB)",
            "Guyana (GUY)",
            "Haiti (HTI)",
            "Heard Island and McDonald Islands (HMD)",
            "Holy See (the) (VAT)",
            "Honduras (HND)",
            "Hong Kong (HKG)",
            "Hungary (HUN)",
            "Iceland (ISL)",
            "India (IND)",
            "Indonesia (IDN)",
            "Iran (Islamic Republic of) (IRN)",
            "Iraq (IRQ)",
            "Ireland (IRL)",
            "Isle of Man (IMN)",
            "Israel (ISR)",
            "Italy (ITA)",
            "Jamaica (JAM)",
            "Japan (JPN)",
            "Jersey (JEY)",
            "Jordan (JOR)",
            "Kazakhstan (KAZ)",
            "Kenya (KEN)",
            "Kiribati (KIR)",
            "Korea (the Democratic People's Republic of) (PRK)",
            "Korea (the Republic of) (KOR)",
            "Kuwait (KWT)",
            "Kyrgyzstan (KGZ)",
            "Lao People's Democratic Republic (the) (LAO)",
            "Latvia (LVA)",
            "Lebanon (LBN)",
            "Lesotho (LSO)",
            "Liberia (LBR)",
            "Libya (LBY)",
            "Liechtenstein (LIE)",
            "Lithuania (LTU)",
            "Luxembourg (LUX)",
            "Macao (MAC)",
            "Madagascar (MDG)",
            "Malawi (MWI)",
            "Malaysia (MYS)",
            "Maldives (MDV)",
            "Mali (MLI)",
            "Malta (MLT)",
            "Marshall Islands (the) (MHL)",
            "Martinique (MTQ)",
            "Mauritania (MRT)",
            "Mauritius (MUS)",
            "Mayotte (MYT)",
            "Mexico (MEX)",
            "Micronesia (Federated States of) (FSM)",
            "Moldova (the Republic of) (MDA)",
            "Monaco (MCO)",
            "Mongolia (MNG)",
            "Montenegro (MNE)",
            "Montserrat (MSR)",
            "Morocco (MAR)",
            "Mozambique (MOZ)",
            "Myanmar (MMR)",
            "Namibia (NAM)",
            "Nauru (NRU)",
            "Nepal (NPL)",
            "Netherlands (the) (NLD)",
            "New Caledonia (NCL)",
            "New Zealand (NZL)",
            "Nicaragua (NIC)",
            "Niger (the) (NER)",
            "Nigeria (NGA)",
            "Niue (NIU)",
            "Norfolk Island (NFK)",
            "Northern Mariana Islands (the) (MNP)",
            "Norway (NOR)",
            "Oman (OMN)",
            "Pakistan (PAK)",
            "Palau (PLW)",
            "Palestine, State of (PSE)",
            "Panama (PAN)",
            "Papua New Guinea (PNG)",
            "Paraguay (PRY)",
            "Peru (PER)",
            "Philippines (the) (PHL)",
            "Pitcairn (PCN)",
            "Poland (POL)",
            "Portugal (PRT)",
            "Puerto Rico (PRI)",
            "Qatar (QAT)",
            "Republic of North Macedonia (MKD)",
            "Romania (ROU)",
            "Russian Federation (the) (RUS)",
            "Rwanda (RWA)",
            "Réunion (REU)",
            "Saint Barthélemy (BLM)",
            "Saint Helena, Ascension and Tristan da Cunha (SHN)",
            "Saint Kitts and Nevis (KNA)",
            "Saint Lucia (LCA)",
            "Saint Martin (French part) (MAF)",
            "Saint Pierre and Miquelon (SPM)",
            "Saint Vincent and the Grenadines (VCT)",
            "Samoa (WSM)",
            "San Marino (SMR)",
            "Sao Tome and Principe (STP)",
            "Saudi Arabia (SAU)",
            "Senegal (SEN)",
            "Serbia (SRB)",
            "Seychelles (SYC)",
            "Sierra Leone (SLE)",
            "Singapore (SGP)",
            "Sint Maarten (Dutch part) (SXM)",
            "Slovakia (SVK)",
            "Slovenia (SVN)",
            "Solomon Islands (SLB)",
            "Somalia (SOM)",
            "South Africa (ZAF)",
            "South Georgia and the South Sandwich Islands (SGS)",
            "South Sudan (SSD)",
            "Spain (ESP)",
            "Sri Lanka (LKA)",
            "Sudan (the) (SDN)",
            "Suriname (SUR)",
            "Svalbard and Jan Mayen (SJM)",
            "Sweden (SWE)",
            "Switzerland (CHE)",
            "Syrian Arab Republic (SYR)",
            "Taiwan (Province of China) (TWN)",
            "Tajikistan (TJK)",
            "Tanzania, United Republic of (TZA)",
            "Thailand (THA)",
            "Timor-Leste (TLS)",
            "Togo (TGO)",
            "Tokelau (TKL)",
            "Tonga (TON)",
            "Trinidad and Tobago (TTO)",
            "Tunisia (TUN)",
            "Turkey (TUR)",
            "Turkmenistan (TKM)",
            "Turks and Caicos Islands (the) (TCA)",
            "Tuvalu (TUV)",
            "Uganda (UGA)",
            "Ukraine (UKR)",
            "United Arab Emirates (the) (ARE)",
            "United Kingdom of Great Britain and Northern Ireland (the) (GBR)",
            "United States Minor Outlying Islands (the) (UMI)",
            "United States of America (the) (USA)",
            "Uruguay (URY)",
            "Uzbekistan (UZB)",
            "Vanuatu (VUT)",
            "Venezuela (Bolivarian Republic of) (VEN)",
            "Viet Nam (VNM)",
            "Virgin Islands (British) (VGB)",
            "Virgin Islands (U.S.) (VIR)",
            "Wallis and Futuna (WLF)",
            "Western Sahara (ESH)",
            "Yemen (YEM)",
            "Zambia (ZMB)",
            "Zimbabwe (ZWE)",
            "Åland Islands (ALA)"
        }

            ' Add countries to the ListBox
            ListBox1.Items.AddRange(countries.ToArray())
            CountrylistON = True
        Else
            CountrylistON = False
            ListBox1.Visible = False
        End If

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.Click
        FlaglistON = False
        CountrylistON = False
        ListBox1.Visible = False
    End Sub

    Private Sub btn_charmap_Click(sender As Object, e As EventArgs) Handles btn_charmap.Click
        Process.Start("charmap")
    End Sub

    Private Sub Label5_Click_1(sender As Object, e As EventArgs)
        UpdateAwayVariablesFromTextBox()
    End Sub

    Public Sub LoadSettingIP()
        Try
            Dim xmlDoc As New XmlDocument()
            xmlDoc.Load(settingxmlFilePath)

            ' Select the node containing the Setting_IP
            Dim settingIPNode As XmlNode = xmlDoc.SelectSingleNode("//Settings/Setting_IP")

            ' Check if the node is found and get its value
            If settingIPNode IsNot Nothing Then
                settingIP = settingIPNode.InnerText
            Else
                MessageBox.Show("Setting_IP not found in the XML file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            ' Display the Setting_IP value or use it as needed
            'MessageBox.Show($"Setting_IP: {settingIP}", "Error0", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show($"An error occurred while reading the XML file: {ex.Message}", "Error0a", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CheckConnection()
        'a short test, if vMix is connected
        Try
            Using client As New TcpClient()
                client.Connect(settingIP, settingPORT)
                If client.Connected Then
                    Label5.Text = "vMix found at IP address: " & settingIP
                End If
            End Using
        Catch ex As Exception
            'errorhandling
            MessageBox.Show("vMix is not running, the program reacts only hesitantly because it keeps trying to send data to vMix or receive data from vMix", "Error0a", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Label5.Text = "vMix is not running or cannot be found under the IP address specified in Settings"
        End Try
    End Sub

    Private Sub btn_set_list_of_names_Click(sender As Object, e As EventArgs) Handles btn_set_list_of_names.Click
        ' Zeige die MessageBox mit OK und Abbrechen Schaltflächen
        Dim result As DialogResult = MessageBox.Show("Do you really want to delete all the data in the table and fill in sample data?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)

        ' Überprüfen, welcher Button geklickt wurde
        If result = DialogResult.OK Then
            Sample_Data()
        Else
            ' Code, wenn Abbrechen geklickt wurde
            MessageBox.Show("process canceled")
        End If
    End Sub

    Private Sub Sample_Data()
        ' Fantasiedaten für die angegebene Liste von Namen
        Dim rowsData As New List(Of Dictionary(Of String, String)) From {
            New Dictionary(Of String, String) From {
                {"CountryL", "Germany"},
                {"CountryS", "GER"},
                {"NAME1", "Branch"},
                {"First_Name1", "Erwin"},
                {"Age1", "28"},
                {"Height1", "180"},
                {"Data1_1", "Data1_A"},
                {"Data2_1", "Data1_B"},
                {"NAME2", "Walter"},
                {"First_Name2", "Lukas"},
                {"Age2", "26"},
                {"Height2", "175"},
                {"Data1_2", "Data2_A"},
                {"Data2_2", "Data2_B"},
                {"Fact1", "Interesting Fact 1"},
                {"Fact2", "Interesting Fact 2"}
            },
            New Dictionary(Of String, String) From {
                {"CountryL", "Belgium"},
                {"CountryS", "BEL"},
                {"NAME1", "Garner"},
                {"First_Name1", "Robin"},
                {"Age1", "30"},
                {"Height1", "185"},
                {"Data1_1", "Data3_A"},
                {"Data2_1", "Data3_B"},
                {"NAME2", "Gutierrez"},
                {"First_Name2", "Burl"},
                {"Age2", "29"},
                {"Height2", "180"},
                {"Data1_2", "Data4_A"},
                {"Data2_2", "Data4_B"},
                {"Fact1", "Interesting Fact 3"},
                {"Fact2", "Interesting Fact 4"}
            },
            New Dictionary(Of String, String) From {
                {"CountryL", "Portugal"},
                {"CountryS", "POR"},
                {"NAME1", "Rollins"},
                {"First_Name1", "Douglass"},
                {"Age1", "35"},
                {"Height1", "190"},
                {"Data1_1", "Data5_A"},
                {"Data2_1", "Data5_B"},
                {"NAME2", "Wagner"},
                {"First_Name2", "Irwin"},
                {"Age2", "32"},
                {"Height2", "185"},
                {"Data1_2", "Data6_A"},
                {"Data2_2", "Data6_B"},
                {"Fact1", "Interesting Fact 5"},
                {"Fact2", "Interesting Fact 6"}
            },
            New Dictionary(Of String, String) From {
                {"CountryL", "Italy"},
                {"CountryS", "ITA"},
                {"NAME1", "Sheppard"},
                {"First_Name1", "Giovanni"},
                {"Age1", "27"},
                {"Height1", "175"},
                {"Data1_1", "Data7_A"},
                {"Data2_1", "Data7_B"},
                {"NAME2", "Stokes"},
                {"First_Name2", "Cortez"},
                {"Age2", "28"},
                {"Height2", "180"},
                {"Data1_2", "Data8_A"},
                {"Data2_2", "Data8_B"},
                {"Fact1", "Interesting Fact 7"},
                {"Fact2", "Interesting Fact 8"}
            },
            New Dictionary(Of String, String) From {
                {"CountryL", "Czechia"},
                {"CountryS", "CZE"},
                {"NAME1", "Conner"},
                {"First_Name1", "Graciela"},
                {"Age1", "26"},
                {"Height1", "170"},
                {"Data1_1", "Data9_A"},
                {"Data2_1", "Data9_B"},
                {"NAME2", "Murray"},
                {"First_Name2", "Marci"},
                {"Age2", "24"},
                {"Height2", "165"},
                {"Data1_2", "Data10_A"},
                {"Data2_2", "Data10_B"},
                {"Fact1", "Interesting Fact 9"},
                {"Fact2", "Interesting Fact 10"}
            },
            New Dictionary(Of String, String) From {
                {"CountryL", "Ukraine"},
                {"CountryS", "UKR"},
                {"NAME1", "Wagner"},
                {"First_Name1", "Lina"},
                {"Age1", "29"},
                {"Height1", "168"},
                {"Data1_1", "Data11_A"},
                {"Data2_1", "Data11_B"},
                {"NAME2", "Mccarty"},
                {"First_Name2", "Madge"},
                {"Age2", "27"},
                {"Height2", "160"},
                {"Data1_2", "Data12_A"},
                {"Data2_2", "Data12_B"},
                {"Fact1", "Interesting Fact 11"},
                {"Fact2", "Interesting Fact 12"}
            },
            New Dictionary(Of String, String) From {
                {"CountryL", "Sweden"},
                {"CountryS", "SWE"},
                {"NAME1", "Arellano"},
                {"First_Name1", "Carolyn"},
                {"Age1", "31"},
                {"Height1", "170"},
                {"Data1_1", "Data13_A"},
                {"Data2_1", "Data13_B"},
                {"NAME2", "Woods"},
                {"First_Name2", "Kaitlin"},
                {"Age2", "30"},
                {"Height2", "165"},
                {"Data1_2", "Data14_A"},
                {"Data2_2", "Data14_B"},
                {"Fact1", "Interesting Fact 13"},
                {"Fact2", "Interesting Fact 14"}
            },
            New Dictionary(Of String, String) From {
                {"CountryL", "Montenegro"},
                {"CountryS", "MNE"},
                {"NAME1", "Gross"},
                {"First_Name1", "Margret"},
                {"Age1", "33"},
                {"Height1", "172"},
                {"Data1_1", "Data15_A"},
                {"Data2_1", "Data15_B"},
                {"NAME2", "Rodriguez"},
                {"First_Name2", "Thelma"},
                {"Age2", "32"},
                {"Height2", "168"},
                {"Data1_2", "Data16_A"},
                {"Data2_2", "Data16_B"},
                {"Fact1", "Interesting Fact 15"},
                {"Fact2", "Interesting Fact 16"}
            },
            New Dictionary(Of String, String) From {
                {"CountryL", "Switzerland"},
                {"CountryS", "SUI"},
                {"NAME1", "Meier"},
                {"First_Name1", "Liam"},
                {"Age1", "24"},
                {"Height1", "182"},
                {"Data1_1", "Data17_A"},
                {"Data2_1", "Data17_B"},
                {"NAME2", "Schmid"},
                {"First_Name2", "Mattheo"},
                {"Age2", "26"},
                {"Height2", "198"},
                {"Data1_2", "Data18_A"},
                {"Data2_2", "Data18_B"},
                {"Fact1", "Interesting Fact 17"},
                {"Fact2", "Interesting Fact 18"}
            }
        }
        ' Füllen des DataGridView mit den Fantasiedaten
        FillDataGridWithRows(rowsData)
    End Sub

    ' Subroutine zum Füllen des DataGridView mit mehreren Zeilen
    Private Sub FillDataGridWithRows(rowsData As List(Of Dictionary(Of String, String)))
        ' Leeren der bestehenden Daten
        Tabelle.Rows.Clear()

        ' Hinzufügen der neuen Zeilen
        For Each rowData In rowsData
            Dim newRow As DataRow = Tabelle.NewRow()
            For Each key In rowData.Keys
                newRow(key) = rowData(key)
            Next
            Tabelle.Rows.Add(newRow)
        Next

        ' Aktualisieren des DataGridView
        DataGridView1.DataSource = Tabelle
        DataGridView1.Refresh()
    End Sub

    Private Sub CheckForMissingFlags()
        Dim missingFlags As New List(Of String)()
        Dim flagDirectory As String = "C:\VMIX\beachvolleyball\flags"

        ' Überprüfen, ob das Verzeichnis existiert
        If Not Directory.Exists(flagDirectory) Then
            MessageBox.Show("The flag directory does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Erhalten der Liste der CountryL und CountryS Werte aus dem DataGridView
        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.Cells("CountryS").Value IsNot Nothing AndAlso row.Cells("CountryL").Value IsNot Nothing Then
                Dim countryS As String = row.Cells("CountryS").Value.ToString()
                Dim countryL As String = row.Cells("CountryL").Value.ToString()
                Dim flagPath As String = Path.Combine(flagDirectory, countryS & ".png")

                ' Überprüfen, ob die Flagge existiert
                If Not File.Exists(flagPath) Then
                    missingFlags.Add($"{countryL} - {countryS}.png")
                End If
            End If
        Next

        ' Überprüfen, ob fehlende Flaggen gefunden wurden
        If missingFlags.Count > 0 Then
            Dim message As String = "The following flags are missing:" & Environment.NewLine & String.Join(Environment.NewLine, missingFlags)
            MessageBox.Show(message, "Missing Flags", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            MsgBox("The program has just checked that all flags of the registered teams are present.")
        End If
    End Sub



End Class

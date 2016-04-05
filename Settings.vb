Public Class Settings
    Private Sub BtnFolder_Click(sender As Object, e As EventArgs) Handles BtnFolder.Click
        Dim folderBrowser As New FolderBrowserDialog
        folderBrowser.SelectedPath = My.Computer.FileSystem.SpecialDirectories.MyDocuments & My.Settings.DefPath    'Set the default selected folder path

        If (folderBrowser.ShowDialog() = DialogResult.OK) Then
            TextBox1.Text = folderBrowser.SelectedPath
        End If
        My.Settings.DefPath = TextBox1.Text.Replace(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "").Trim
    End Sub

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = My.Computer.FileSystem.SpecialDirectories.MyDocuments & My.Settings.DefPath
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        My.Settings.Save()
        Me.Close()
    End Sub

    Private Sub BtnProgram_Click(sender As Object, e As EventArgs) Handles BtnProgram.Click
        Dim filedialog As OpenFileDialog = New OpenFileDialog()
        Dim strFileName As String
        filedialog.Title = "Open File Dialog"
        filedialog.InitialDirectory = "W:\TOM\ERIC\NET Dev"
        filedialog.RestoreDirectory = True
        If filedialog.ShowDialog() = DialogResult.OK Then
            TextBox2.Text = filedialog.FileName
        End If

    End Sub
End Class
Public Class Settings
    Private Sub BtnFolder_Click(sender As Object, e As EventArgs) Handles BtnFolder.Click
        Dim folderBrowser As New FolderBrowserDialog
        folderBrowser.SelectedPath = My.Computer.FileSystem.SpecialDirectories.MyDocuments    'Set the default selected folder path

        If (folderBrowser.ShowDialog() = DialogResult.OK) Then
            TextBox1.Text = folderBrowser.SelectedPath
        End If
    End Sub

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = ""
    End Sub
End Class
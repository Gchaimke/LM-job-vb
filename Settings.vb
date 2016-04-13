Public Class Settings
    Private Sub BtnFolder_Click(sender As Object, e As EventArgs) Handles BtnFolder.Click
        Dim folderBrowser As New FolderBrowserDialog
        folderBrowser.SelectedPath = My.Settings.DefPath    'Set the default selected folder path

        If (folderBrowser.ShowDialog() = DialogResult.OK) Then
            TextBox1.Text = folderBrowser.SelectedPath
        End If
        My.Settings.DefPath = TextBox1.Text
    End Sub

    Private Sub BtnProgram_Click(sender As Object, e As EventArgs) Handles BtnProgram.Click
        Dim filedialog As OpenFileDialog = New OpenFileDialog()
        filedialog.Title = "Open File Dialog"
        filedialog.InitialDirectory = "C:\Program Files (x86)\Brady"
        filedialog.RestoreDirectory = True
        If filedialog.ShowDialog() = DialogResult.OK Then
            TextBox2.Text = filedialog.FileName
            My.Settings.ProgramPath = filedialog.FileName
        End If
    End Sub

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = My.Settings.DefPath
        TextBox2.Text = My.Settings.ProgramPath
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        My.Settings.Save()
        Application.Restart()
        Me.Close()

    End Sub

    Private Sub BtnCencel_Click(sender As Object, e As EventArgs) Handles BtnCencel.Click
        Me.Close()
    End Sub
End Class
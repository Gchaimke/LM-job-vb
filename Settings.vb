Imports System.Threading

Public Class Settings

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
        Label4.Text = My.Computer.FileSystem.SpecialDirectories.MyDocuments & My.Settings.DefPath
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

    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click
        My.Settings.Reset()
    End Sub

End Class
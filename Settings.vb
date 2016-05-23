Imports System.Globalization
Imports System.ComponentModel

Imports System.Threading

Public Class Settings

    Private Property CultureInfo As CultureInfo
    Dim component_resource_manager As New ComponentResourceManager(Me.GetType)


    Private Sub ChangeLanguage(ByVal Language As String)
        For Each crl As Control In Me.Controls
            component_resource_manager.ApplyResources(crl, crl.Name, New CultureInfo(Language)) 'Set desired language
        Next crl
        Thread.CurrentThread.CurrentUICulture = New CultureInfo(My.Settings.language)
        Thread.CurrentThread.CurrentCulture = New CultureInfo(My.Settings.language)
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
        Label4.Text = My.Computer.FileSystem.SpecialDirectories.MyDocuments & My.Settings.DefPath
        TextBox2.Text = My.Settings.ProgramPath
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        ChangeLanguage(ComboBox1.SelectedItem.ToString)
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
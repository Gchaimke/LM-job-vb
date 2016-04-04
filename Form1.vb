Option Explicit On
Option Strict On

Imports System.IO

Public Class Form1
    Private MAIN_DIR_NAME As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\LM-job"
    Private LabelMarkPath As String = "C:\Program Files (x86)\Brady\LabelMark5\Bin\LM5.exe"
    Dim SelectedPath As String()
    Dim ProjectsDir As String()
    Dim CurrentProject As String

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BtnOpen.Enabled = False
        BtnDlete.Enabled = False
        BtnEdit.Enabled = False
        If Not Directory.Exists(MAIN_DIR_NAME) Then
            System.IO.Directory.CreateDirectory(MAIN_DIR_NAME)
        End If
        If Not Directory.Exists(MAIN_DIR_NAME & "\Labels\") Then
            System.IO.Directory.CreateDirectory(MAIN_DIR_NAME & "\Labels\")
        End If

    End Sub
    'Main Sub
    Public Sub Main(ByVal args() As String)
        Dim path As String
        For Each path In args
            If File.Exists(path) Then
                ProcessFile(path)
            Else
                If Directory.Exists(path) Then
                    ProcessDirectory()
                Else
                    Console.WriteLine("{0} is not a valid file or directory.", path)
                End If
            End If
        Next path
    End Sub 'Main

    'Process Subs
    Public Sub ProcessFile(ByVal myPath As String)
        Console.WriteLine("Processed file '{0}'.", myPath)
        Dim fileName As String = Path.GetFileNameWithoutExtension(myPath)
        LstJobs.Items.Add(fileName)
    End Sub 'ProcessFile

    Public Sub ProcessDirectory()
        LsbProjects.Items.Clear()
        Dim SearchFor As String = "*" & TxbFilter1.Text.ToString & "*"
        Try
            ProjectsDir = Directory.GetDirectories(MAIN_DIR_NAME, SearchFor)
            Dim i As Integer
            For Each dir As String In ProjectsDir

                Dim dirInfo As New System.IO.DirectoryInfo(dir)
                LsbProjects.Items.Add(dirInfo.Name)
                i += 1
            Next
            Label1.Text = "Found =" & i
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub 'Processdirectory

    Private Sub TxbFilter1_TextChanged(sender As Object, e As EventArgs) Handles TxbFilter1.TextChanged
        ProcessDirectory() 'when text input search for directories as TxbFilter1.text
    End Sub

    Private Sub LsbProjects_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LsbProjects.SelectedIndexChanged
        LstJobs.Items.Clear() 'clear list before add new items
        Try
            CurrentProject = MAIN_DIR_NAME & "\" & LsbProjects.SelectedItem.ToString 'get current selected item from projects list
            SelectedPath = Directory.GetFiles(CurrentProject) 'show all files in the current directory
            Main(SelectedPath)
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try

    End Sub

    Private Sub LstJobs_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LstJobs.SelectedIndexChanged
        BtnOpen.Enabled = True
        BtnDlete.Enabled = True
        BtnEdit.Enabled = True
    End Sub

    Private Sub LstJobs_LostFocus(sender As Object, e As EventArgs) Handles LstJobs.LostFocus
        If BtnOpen.Focused = False Then
            BtnOpen.Enabled = False
            BtnDlete.Enabled = False
            BtnEdit.Enabled = False
        End If
        If BtnEdit.Focused = False Then
            BtnOpen.Enabled = False
            BtnDlete.Enabled = False
            BtnEdit.Enabled = False
        End If
        If BtnDlete.Focused = False Then
            BtnOpen.Enabled = False
            BtnDlete.Enabled = False
            BtnEdit.Enabled = False
        End If
    End Sub
    'Start Buttons functions
    Private Sub BtnProject_Click(sender As Object, e As EventArgs) Handles BtnProject.Click
        Dim NewFolderName As String = MAIN_DIR_NAME & "\" & InputBox("Project Name", "Please Name new project folder")
        Try
            If (Not System.IO.Directory.Exists(NewFolderName)) Then
                System.IO.Directory.CreateDirectory(NewFolderName)
                MsgBox(NewFolderName & " created.")
            Else
                MsgBox("Folder " & NewFolderName & " exist!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try

    End Sub

    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        Try
            Dim OpenFile As String = MAIN_DIR_NAME & "\" & LsbProjects.SelectedItem.ToString & "\Labels\" & LstJobs.SelectedItem.ToString & ".l5f"
            System.Diagnostics.Process.Start(LabelMarkPath, OpenFile)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnOpen_Click(sender As Object, e As EventArgs) Handles BtnOpen.Click
        Try
            Dim OpenFile As String = MAIN_DIR_NAME & "\" & LsbProjects.SelectedItem.ToString & "\" & LstJobs.SelectedItem.ToString & ".lmj"
            System.Diagnostics.Process.Start(LabelMarkPath, OpenFile)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnDlete_Click(sender As Object, e As EventArgs) Handles BtnDlete.Click
        Dim OpenFile As String = MAIN_DIR_NAME & "\" & LsbProjects.SelectedItem.ToString & "\" & LstJobs.SelectedItem.ToString & ".lmj"
        Dim SelectedRow As Integer = LstJobs.SelectedIndex
        If System.IO.File.Exists(OpenFile) = True Then
            LstJobs.Items.RemoveAt(SelectedRow)
            System.IO.File.Delete(OpenFile)
            MessageBox.Show("File Deleted")

        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        FormAddJob.Show()
    End Sub
    'Start Menu Buttons 
    Private Sub HelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem.Click
        AboutBox.Show()
    End Sub

    Private Sub NewProjectFolderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewProjectFolderToolStripMenuItem.Click
        Dim NewFolderName As String = MAIN_DIR_NAME & "\" & InputBox("Project Name", "Please Name new project folder")
        Try
            If (Not System.IO.Directory.Exists(NewFolderName)) Then
                System.IO.Directory.CreateDirectory(NewFolderName)
                MsgBox(NewFolderName & " created.")
            Else
                MsgBox("Folder " & NewFolderName & " exist!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        Settings.Show()
    End Sub

End Class

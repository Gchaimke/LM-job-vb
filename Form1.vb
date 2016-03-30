Imports System
Imports System.IO
Imports System.Collections

Public Class Form1
    Dim MAIN_DIR_NAME As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\LM-job"
    Dim SelectedPath As String()
    Dim ProjectsDir As String()
    Dim CurrentProject As String

    Private Sub Form1_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub Main(ByVal args() As String)
        Dim path As String
        For Each path In args
            If File.Exists(path) Then
                ProcessFile(path)
            Else
                If Directory.Exists(path) Then
                    ProcessDirectory(path)
                Else
                    Console.WriteLine("{0} is not a valid file or directory.", path)
                End If
            End If
        Next path
    End Sub 'Main
    Public Sub ProcessDirectory(ByVal targetDirectory As String)
        Dim fileEntries As String() = Directory.GetFiles(targetDirectory)
        Dim fileName As String
        For Each fileName In fileEntries
            ProcessFile(fileName)
        Next fileName
        Dim subdirectoryEntries As String() = Directory.GetDirectories(targetDirectory)
        For Each subdirectory In subdirectoryEntries
            ProcessDirectory(subdirectory)
            ListBox2.Items.Add(subdirectoryEntries)
        Next subdirectory
    End Sub 'Processdirectory

    Public Sub ProcessFile(ByVal myPath As String)
        Console.WriteLine("Processed file '{0}'.", myPath)
        Dim fileName As String = Path.GetFileNameWithoutExtension(myPath)
        ListBox2.Items.Add(fileName)
    End Sub 'ProcessFile

    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged
        Dim OpenFile As String = MAIN_DIR_NAME & "\" & ListBox2.SelectedItem.ToString & ".lmj"
        MsgBox(OpenFile)
        Try
            System.Diagnostics.Process.Start(OpenFile)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        ListBox1.Items.Clear()
        Dim SearchFor As String = "*" & TextBox1.Text.ToString & "*"
        ProjectsDir = Directory.GetDirectories(MAIN_DIR_NAME, SearchFor)
        Dim i As Integer
        For Each dir As String In ProjectsDir

            Dim dirInfo As New System.IO.DirectoryInfo(dir)
            ListBox1.Items.Add(dirInfo.Name)
            i += 1
        Next
        Label1.Text = "Found =" & i
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        CurrentProject = MAIN_DIR_NAME & "\" & ListBox1.SelectedItem.ToString
        SelectedPath = Directory.GetFiles(CurrentProject)
        Main(SelectedPath)
    End Sub

End Class

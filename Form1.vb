Imports System
Imports System.IO
Imports System.Collections

Public Class Form1
    Dim MainDirectoryPath As String()
    Dim ProjectsDirs As String()

    Private Sub Form1_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load
        MainDirectoryPath = Directory.GetFiles(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "/test")
        ProjectsDirs = Directory.GetDirectories(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "/test")

        For Each dir As String In ProjectsDirs
            Dim dirInfo As New System.IO.DirectoryInfo(dir)
            ComboBox1.Items.Add(dirInfo.Name)
        Next


        Main(MainDirectoryPath)
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
            ComboBox1.Items.Add(subdirectoryEntries)
        Next subdirectory
    End Sub 'Processdirectory

    Public Sub ProcessFile(ByVal myPath As String)
        Console.WriteLine("Processed file '{0}'.", myPath)
        Dim fileName As String = Path.GetFileNameWithoutExtension(myPath)
        ComboBox1.Items.Add(fileName)
    End Sub 'ProcessFile

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim OpenFile As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "/test/" & ComboBox1.SelectedItem.ToString & ".txt"
        System.Diagnostics.Process.Start(OpenFile)
    End Sub

End Class

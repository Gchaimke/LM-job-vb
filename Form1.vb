﻿Option Explicit On
Option Strict On

Imports System
Imports System.IO
Imports System.Collections
Imports System.Xml

Public Class Form1
    Private MAIN_DIR_NAME As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\LM-job"
    Private LabelMarkPath As String = "C:\Program Files (x86)\Brady\LabelMark5\Bin\LM5.exe"
    Dim SelectedPath As String()
    Dim ProjectsDir As String()
    Dim CurrentProject As String


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

    Public Sub ProcessFile(ByVal myPath As String)
        Console.WriteLine("Processed file '{0}'.", myPath)
        Dim fileName As String = Path.GetFileNameWithoutExtension(myPath)
        LstJobs.Items.Add(fileName)
    End Sub 'ProcessFile

    Private Sub TxbFilter1_TextChanged(sender As Object, e As EventArgs) Handles TxbFilter1.TextChanged
        ProcessDirectory()
    End Sub

    Private Sub LsbProjects_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LsbProjects.SelectedIndexChanged
        LstJobs.Items.Clear()
        Try
            CurrentProject = MAIN_DIR_NAME & "\" & LsbProjects.SelectedItem.ToString
            SelectedPath = Directory.GetFiles(CurrentProject)
            Main(SelectedPath)
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try

    End Sub

    Private Sub LstJobs_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LstJobs.SelectedIndexChanged
        Dim OpenFile As String = MAIN_DIR_NAME & "\" & LsbProjects.SelectedItem.ToString & "\" & LstJobs.SelectedItem.ToString & ".lmj"
        If MsgBoxResult.Ok = 1 Then
            Try 'try to open file with LabelMark
                'Create the XmlDocument.
                Dim doc As New XmlDocument()
                doc.Load(OpenFile)
                'Display all the book titles.
                Dim ReturnValue As New List(Of String)
                For Each node As XmlNode In doc.SelectNodes("//LabelFile")
                    LstJobs.Items.Add(node.Attributes("Path").Value)
                Next
                'System.Diagnostics.Process.Start(LabelMarkPath, OpenFile)
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
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

End Class

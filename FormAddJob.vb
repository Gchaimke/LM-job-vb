Option Explicit On

Imports System
Imports System.IO
Imports System.Collections
Imports System.Xml

Public Class FormAddJob
    Private MAIN_DIR_NAME As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\LM-job"
    Dim ProjectsDir As String()
    Dim SelectedPath As String()
    Dim CurrentProject As String

    Private Sub FormAddJob_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            CurrentProject = MAIN_DIR_NAME & "\" & "Labels"
            SelectedPath = Directory.GetFiles(CurrentProject)
            Main(SelectedPath)
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try

        TextBox2.Text = "1"
    End Sub

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
            Label3.Text = "Found =" & i
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub 'Processdirectory

    Public Sub ProcessFile(ByVal myPath As String)
        Console.WriteLine("Processed file '{0}'.", myPath)
        Dim fileName As String = Path.GetFileNameWithoutExtension(myPath)
        cmbLabels.Items.Add(fileName)
    End Sub 'ProcessFile

    Private Sub TxbFilter1_TextChanged(sender As Object, e As EventArgs) Handles TxbFilter1.TextChanged
        ProcessDirectory()
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim FolderName As String = MAIN_DIR_NAME & "\" & LsbProjects.SelectedItem.ToString
        Dim NewJobName As String = TextBox1.Text.ToString
        Dim NewFileName = FolderName & "\" & NewJobName & ".lmj"
        Try
            If File.Exists(NewFileName) Then
                MsgBox("File " & NewFileName & " Exist, Try another name.")
            Else
                File.WriteAllBytes(NewFileName, CType(My.Resources.ResourceManager.GetObject("Blank_job"), Byte()))

                Dim doc As New Xml.XmlDocument
                'load file 
                doc.Load(NewFileName)
                Dim root As XmlNode = doc.SelectSingleNode("//LMJob/LabelFiles")

                If root Is Nothing Then
                    'if this is a new document create root 
                    root = doc.SelectSingleNode("//LMJob/LabelFiles")
                Else
                    'create node 
                    'get root node named users 
                    Dim Usersnode As Xml.XmlElement = doc.SelectSingleNode("//LMJob/LabelFiles")
                    'add the new node 
                    Dim newNode As Xml.XmlElement = doc.CreateElement("LabelFile")
                    'add attributes 
                    newNode.SetAttribute("Path", FolderName & "\Labels\" & TextBox1.Text & ".l5f")
                    newNode.SetAttribute("Printer", "CAB XD4M/300")
                    newNode.SetAttribute("NumberOfCopiesToPrint", TextBox2.Text)
                    newNode.SetAttribute("SideToPrint", "BothSides")
                    newNode.SetAttribute("StandardPrinting", "True")
                    newNode.SetAttribute("PartID", cmbLabels.SelectedItem.ToString)
                    newNode.SetAttribute("LabelsToPrint", "AllLabels")
                    newNode.SetAttribute("HorizontalPrinterPosition", "0")
                    newNode.SetAttribute("VerticalPrinterPosition", "0")
                    Usersnode.AppendChild(newNode)

                End If
                'save doc 
                doc.Save(NewFileName)
                System.IO.Directory.CreateDirectory(FolderName & "\Labels\")
                File.WriteAllBytes(FolderName & "\Labels\" & TextBox1.Text & ".l5f", CType(My.Resources.ResourceManager.GetObject(cmbLabels.SelectedItem.ToString), Byte()))
                MsgBox(NewJobName & " created, in " & FolderName)
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try


    End Sub


    Private Sub TextBox1_GotFocus(sender As Object, e As EventArgs) Handles TextBox1.GotFocus
        If LsbProjects.SelectedIndex < 0 Then
            TxbFilter1.Focus()
            MsgBox("Please Select project")

        End If
    End Sub
End Class
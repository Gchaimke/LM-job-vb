Option Explicit On

Imports System.IO
Imports System.Xml
Imports System.ComponentModel
Imports System.Globalization
Imports System.Resources
Imports System.Reflection
Imports System.Threading

Public Class FormAddJob
    Dim SelectedPath As String()
    Dim CurrentProject As String
    Dim resFile As String = "LM_job.Messages"
    Dim resources As New ResourceManager(resFile, [Assembly].GetExecutingAssembly())

    Private Sub ChangeLanguage(ByVal Language As String)
        For Each c As Control In Me.Controls
            Dim crmLang As ComponentResourceManager = New ComponentResourceManager(GetType(FormAddJob))
            crmLang.ApplyResources(c, c.Name, New CultureInfo(Language)) 'Set desired language
        Next c
        Thread.CurrentThread.CurrentUICulture = New CultureInfo(My.Settings.language)
        Thread.CurrentThread.CurrentCulture = New CultureInfo(My.Settings.language)
    End Sub

    Private Sub FormAddJob_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ChangeLanguage(My.Settings.language)
        If My.Settings.language = "he" Then
            Me.RightToLeft = RightToLeft.Yes
            Me.RightToLeftLayout = True
        End If
        Try
            CurrentProject = Form1.MAIN_DIR_NAME & "\" & Form1.LsbProjects.SelectedItem.ToString & "\" & "Labels"
            SelectedPath = Directory.GetFiles(Form1.MAIN_LABELS_DIR)
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
            End If
        Next path
    End Sub 'Main

    Public Sub ProcessFile(ByVal myPath As String)
        Console.WriteLine("Processed file '{0}'.", myPath)
        Dim fileName As String = Path.GetFileNameWithoutExtension(myPath)
        cmbLabels.Items.Add(fileName)
    End Sub 'ProcessFile

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim FolderName As String = Form1.MAIN_DIR_NAME & "\" & Form1.LsbProjects.SelectedItem.ToString
        Dim NewJobName As String = TextBox1.Text.ToString.Replace(" ", "")
        Dim NewFileName = FolderName & "\" & NewJobName & ".lmj"
        Try
            If TextBox1.Text.ToString = "" Or TextBox1.Text.ToString = " " Then

                MsgBox(resources.GetString("setFileName"))
                Exit Sub
            End If
            If cmbLabels.SelectedIndex < 0 Then
                MsgBox(resources.GetString("selectLabel"))
                cmbLabels.SelectedIndex = 0
                Exit Sub
            End If
            If File.Exists(NewFileName) Then
                MsgBox(resources.GetString("fileMsg") & NewFileName & resources.GetString("existMsg"))
                Exit Sub
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
                    newNode.SetAttribute("Path", FolderName & "\Labels\" & TextBox1.Text & "." & My.Settings.FileExt)
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
                File.WriteAllBytes(FolderName & "\Labels\" & TextBox1.Text & "." & My.Settings.FileExt, CType(My.Resources.ResourceManager.GetObject("_" & cmbLabels.SelectedItem.replace("-", "_")), Byte()))
                MsgBox(NewJobName & " " & resources.GetString("createIn") & " " & FolderName)
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try

    End Sub

End Class
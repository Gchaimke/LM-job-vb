Option Explicit On


Imports System.IO
Imports System.Xml
Imports System.Globalization
Imports System.ComponentModel
Imports System.Resources
Imports System.Reflection
Imports System.Threading

Public Class Form1
    Private Property CultureInfo As CultureInfo
    Dim resFile As String = "LM_job.Messages"
    Dim component_resource_manager As New ComponentResourceManager(Me.GetType)
    Dim resources As New ResourceManager(resFile, [Assembly].GetExecutingAssembly())

    Public MAIN_DIR_NAME As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & My.Settings.DefPath
    Public MAIN_LABELS_DIR As String = MAIN_DIR_NAME & "\Labels\"
    Private LabelMarkPath As String = My.Settings.ProgramPath
    Dim SelectedPath As String()
    Dim ProjectsDir As String()
    Dim CurrentProject As String

    Private Sub ChangeLanguage(ByVal Language As String)
        For Each crl As Control In Me.Controls
            component_resource_manager.ApplyResources(crl, crl.Name, New CultureInfo(Language)) 'Set desired language
        Next crl
        Thread.CurrentThread.CurrentUICulture = New CultureInfo(My.Settings.language)
        Thread.CurrentThread.CurrentCulture = New CultureInfo(My.Settings.language)
        component_resource_manager.ApplyResources(Me, "$this", CultureInfo)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ChangeLanguage(My.Settings.language)
        If My.Settings.language = "he" Then
            Me.RightToLeft = RightToLeft.Yes
            Me.RightToLeftLayout = True
        End If
        Try
            If Not Directory.Exists(MAIN_DIR_NAME) Then
                System.IO.Directory.CreateDirectory(MAIN_DIR_NAME)
            End If
            If Not Directory.Exists(MAIN_LABELS_DIR) Then
                System.IO.Directory.CreateDirectory(MAIN_LABELS_DIR)
                For Each ResourceFile As DictionaryEntry In My.Resources.ResourceManager.GetResourceSet(Globalization.CultureInfo.CurrentCulture, True, True).OfType(Of Object)()
                    If ResourceFile.Key Like "*3PS*" Then
                        Dim fileName As String = ResourceFile.Key.Replace("_", "-")
                        File.WriteAllBytes(MAIN_LABELS_DIR & fileName.TrimStart("-") & "." & My.Settings.FileExt, CType(My.Resources.ResourceManager.GetObject(ResourceFile.Key), Byte()))
                    End If
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

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
            Label1.Text = resources.GetString("found") & i
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
            If LsbProjects.SelectedIndex >= 0 Then
                CurrentProject = MAIN_DIR_NAME & "\" & LsbProjects.SelectedItem.ToString 'get current selected item from projects list
                SelectedPath = Directory.GetFiles(CurrentProject) 'show all files in the current directory
                Main(SelectedPath)
            End If

        Catch ex As Exception
        End Try
    End Sub

    'Start Buttons functions
    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        Try
            Dim OpenFile As String = MAIN_DIR_NAME & "\" & LsbProjects.SelectedItem.ToString & "\Labels\" & LstJobs.SelectedItem.ToString & "." & My.Settings.FileExt
            System.Diagnostics.Process.Start(LabelMarkPath, OpenFile)
        Catch ex As Exception

            If Not File.Exists(My.Settings.ProgramPath) Then
                MsgBox(resources.GetString("instalOrSelect"))
                Settings.Show()
            Else
                MsgBox(resources.GetString("selectLabel"))
            End If
        End Try
    End Sub

    Private Sub BtnOpen_Click(sender As Object, e As EventArgs) Handles BtnOpen.Click
        Try
            Dim OpenFile As String = MAIN_DIR_NAME & "\" & LsbProjects.SelectedItem.ToString & "\" & LstJobs.SelectedItem.ToString & ".lmj"
            System.Diagnostics.Process.Start(LabelMarkPath, OpenFile)
        Catch ex As Exception

            If Not File.Exists(My.Settings.ProgramPath) Then
                MsgBox(resources.GetString("instalOrSelect"))
                Settings.Show()
            Else
                MsgBox(resources.GetString("selectLabel"))
            End If

        End Try
    End Sub

    Private Sub BtnDlete_Click(sender As Object, e As EventArgs) Handles BtnDlete.Click
        Try
            Dim selectedFile As String = MAIN_DIR_NAME & "\" & LsbProjects.SelectedItem.ToString & "\" & LstJobs.SelectedItem.ToString & ".lmj"
            Dim selectedLabel As String = MAIN_DIR_NAME & "\" & LsbProjects.SelectedItem.ToString & "\Labels\" & LstJobs.SelectedItem.ToString & "." & My.Settings.FileExt
            Dim SelectedRow As Integer = LstJobs.SelectedIndex
            If System.IO.File.Exists(selectedFile) = True Then
                LstJobs.Items.RemoveAt(SelectedRow)
                System.IO.File.Delete(selectedFile)
                System.IO.File.Delete(selectedLabel)
                MessageBox.Show(resources.GetString("deleted"))
            End If

        Catch ex As Exception
            MsgBox(resources.GetString("selectLabel"))
        End Try
    End Sub

    Private Sub BtnNewJob_Click(sender As Object, e As EventArgs) Handles BtnNewJob.Click
        If LsbProjects.SelectedIndex < 0 Then
            MsgBox(resources.GetString("selectFolder"))
        Else
            FormAddJob.Show()
        End If
    End Sub

    Private Sub BtnProject_Click(sender As Object, e As EventArgs) Handles BtnProject.Click
        CreateFolder()
    End Sub

    Private Sub CreateFolder()
        Dim NewFolderName As String = MAIN_DIR_NAME & "\" & InputBox(resources.GetString("nameFolder"))
        Try
            If (Not System.IO.Directory.Exists(NewFolderName)) Then
                System.IO.Directory.CreateDirectory(NewFolderName)
            ElseIf NewFolderName = "" Then
                MsgBox(resources.GetString("folderMsg") & NewFolderName & resources.GetString("existMsg"))
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub LstJobs_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LstJobs.SelectedIndexChanged
        Try
            If LstJobs.SelectedIndex >= 0 Then
                Dim doc As New XmlDocument
                Dim selectedFile As String = MAIN_DIR_NAME & "\" & LsbProjects.SelectedItem.ToString & "\" & LstJobs.SelectedItem.ToString & ".lmj"
                doc.Load(selectedFile)
                Dim attribute As XmlNode = doc.SelectSingleNode("//LMJob/LabelFiles/LabelFile")
                LblPrinter.Text = attribute.Attributes("Printer").Value
                LblDetals.Text = attribute.Attributes("PartID").Value
                LblCopies.Text = attribute.Attributes("NumberOfCopiesToPrint").Value
                LblPath.Text = attribute.Attributes("Path").Value
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If LsbProjects.SelectedIndex >= 0 Then
                Dim message, title, defaultValue As String
                Dim myValue As Object
                Dim doc As New XmlDocument
                Dim selectedFile As String = MAIN_DIR_NAME & "\" & LsbProjects.SelectedItem.ToString & "\" & LstJobs.SelectedItem.ToString & ".lmj"
                doc.Load(selectedFile)
                Dim Usersnode As Xml.XmlElement = doc.SelectSingleNode("//LMJob/LabelFiles/LabelFile")

                ' Set prompt.
                message = resources.GetString("numberOfCopies")
                ' Set title.
                title = resources.GetString("editCopies")
                ' Set default value.
                Dim attribute As XmlNode = doc.SelectSingleNode("//LMJob/LabelFiles/LabelFile")
                defaultValue = attribute.Attributes("NumberOfCopiesToPrint").Value

                ' Display message, title, and default value.
                myValue = InputBox(message, title, defaultValue)
                ' If user has clicked Cancel, set myValue to defaultValue 
                If myValue Is "" Then myValue = defaultValue
                Usersnode.SetAttribute("NumberOfCopiesToPrint", myValue)
                'save doc 
                doc.Save(selectedFile)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Settings.Show()
    End Sub
End Class

Option Explicit On


Imports System.IO
Imports System.Xml
Imports System.Threading
Imports System.Globalization

Public Class Form1
    Public MAIN_DIR_NAME As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & My.Settings.DefPath
    Public MAIN_LABELS_DIR As String = MAIN_DIR_NAME & "\Labels\"
    Private LabelMarkPath As String = My.Settings.ProgramPath
    Dim SelectedPath As String()
    Dim ProjectsDir As String()
    Dim CurrentProject As String

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
            If LsbProjects.SelectedIndex >= 0 Then
                CurrentProject = MAIN_DIR_NAME & "\" & LsbProjects.SelectedItem.ToString 'get current selected item from projects list
                SelectedPath = Directory.GetFiles(CurrentProject) 'show all files in the current directory
                Main(SelectedPath)
            End If

        Catch ex As Exception
        End Try
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
            Dim OpenFile As String = MAIN_DIR_NAME & "\" & LsbProjects.SelectedItem.ToString & "\Labels\" & LstJobs.SelectedItem.ToString & "." & My.Settings.FileExt
            System.Diagnostics.Process.Start(LabelMarkPath, OpenFile)
        Catch ex As Exception

            If Not File.Exists(My.Settings.ProgramPath) Then
                MsgBox("Install or select editing program first")
                Settings.Show()
            Else
                MsgBox("Select label first")
            End If
        End Try
    End Sub

    Private Sub BtnOpen_Click(sender As Object, e As EventArgs) Handles BtnOpen.Click
        Try
            Dim OpenFile As String = MAIN_DIR_NAME & "\" & LsbProjects.SelectedItem.ToString & "\" & LstJobs.SelectedItem.ToString & ".lmj"
            System.Diagnostics.Process.Start(LabelMarkPath, OpenFile)
        Catch ex As Exception

            If Not File.Exists(My.Settings.ProgramPath) Then
                MsgBox("Install or select editing program first")
                Settings.Show()
            Else
                MsgBox("Select label first")
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
                MessageBox.Show("File Deleted")
            End If

        Catch ex As Exception
            MsgBox("Select label first")
        End Try
    End Sub

    Private Sub BtnNewJob_Click(sender As Object, e As EventArgs) Handles BtnNewJob.Click
        If LsbProjects.SelectedIndex < 0 Then
            MsgBox("select Project first")
        Else
            FormAddJob.Show()
        End If
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
            ElseIf NewFolderName = "" Then
                MsgBox("Folder " & NewFolderName & " exist!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        Settings.Show()
    End Sub

    Private Sub LstJobs_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LstJobs.SelectedIndexChanged
        Try
            If LstJobs.SelectedIndex >= 0 Then
                Dim doc As New XmlDocument
                Dim selectedFile As String = MAIN_DIR_NAME & "\" & LsbProjects.SelectedItem.ToString & "\" & LstJobs.SelectedItem.ToString & ".lmj"
                doc.Load(selectedFile)
                Dim attribute As XmlNode = doc.SelectSingleNode("//LMJob/LabelFiles/LabelFile")
                LblPrinter.Text = "Printer: " & attribute.Attributes("Printer").Value
                LblDetals.Text = "Label ID: " & attribute.Attributes("PartID").Value
                LblCopies.Text = "Copies: " & attribute.Attributes("NumberOfCopiesToPrint").Value
                LblPath.Text = "Path: " & attribute.Attributes("Path").Value
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
                message = "Enter a number of copies"
                ' Set title.
                title = "Edit Copies"
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

    Private Sub HebrewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HebrewToolStripMenuItem.Click
        ' Sets the culture to UK English
        Thread.CurrentThread.CurrentCulture = New CultureInfo("he-IL")
        ' Sets the UI culture to UK English
        Thread.CurrentThread.CurrentUICulture = New CultureInfo("he-IL")

        Dim frmMain As New Form1
        frmMain.Show()

        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub EnglishToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnglishToolStripMenuItem.Click
        ' Sets the culture to UK English
        Thread.CurrentThread.CurrentCulture = New CultureInfo("en")
        ' Sets the UI culture to UK English
        Thread.CurrentThread.CurrentUICulture = New CultureInfo("en")

        Dim frmMain As New Form1
        frmMain.Show()

        Me.Close()
        Me.Dispose()
    End Sub
End Class

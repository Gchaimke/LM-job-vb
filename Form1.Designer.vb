﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LsbProjects = New System.Windows.Forms.ListBox()
        Me.TxbFilter1 = New System.Windows.Forms.TextBox()
        Me.LstJobs = New System.Windows.Forms.ListBox()
        Me.LblDetals = New System.Windows.Forms.Label()
        Me.LblCopies = New System.Windows.Forms.Label()
        Me.LblPrinter = New System.Windows.Forms.Label()
        Me.LblPath = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.LblPrinterText = New System.Windows.Forms.Label()
        Me.LblDetalsText = New System.Windows.Forms.Label()
        Me.LblCopiesText = New System.Windows.Forms.Label()
        Me.LblPathText = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.BtnEdit = New System.Windows.Forms.Button()
        Me.BtnNewJob = New System.Windows.Forms.Button()
        Me.BtnDlete = New System.Windows.Forms.Button()
        Me.BtnOpen = New System.Windows.Forms.Button()
        Me.BtnProject = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'LsbProjects
        '
        Me.LsbProjects.FormattingEnabled = True
        resources.ApplyResources(Me.LsbProjects, "LsbProjects")
        Me.LsbProjects.Name = "LsbProjects"
        '
        'TxbFilter1
        '
        resources.ApplyResources(Me.TxbFilter1, "TxbFilter1")
        Me.TxbFilter1.Name = "TxbFilter1"
        '
        'LstJobs
        '
        Me.LstJobs.FormattingEnabled = True
        resources.ApplyResources(Me.LstJobs, "LstJobs")
        Me.LstJobs.Name = "LstJobs"
        '
        'LblDetals
        '
        resources.ApplyResources(Me.LblDetals, "LblDetals")
        Me.LblDetals.Name = "LblDetals"
        '
        'LblCopies
        '
        resources.ApplyResources(Me.LblCopies, "LblCopies")
        Me.LblCopies.Name = "LblCopies"
        '
        'LblPrinter
        '
        resources.ApplyResources(Me.LblPrinter, "LblPrinter")
        Me.LblPrinter.Name = "LblPrinter"
        '
        'LblPath
        '
        resources.ApplyResources(Me.LblPath, "LblPath")
        Me.LblPath.Name = "LblPath"
        '
        'Button1
        '
        resources.ApplyResources(Me.Button1, "Button1")
        Me.Button1.Name = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'LblPrinterText
        '
        resources.ApplyResources(Me.LblPrinterText, "LblPrinterText")
        Me.LblPrinterText.Name = "LblPrinterText"
        '
        'LblDetalsText
        '
        resources.ApplyResources(Me.LblDetalsText, "LblDetalsText")
        Me.LblDetalsText.Name = "LblDetalsText"
        '
        'LblCopiesText
        '
        resources.ApplyResources(Me.LblCopiesText, "LblCopiesText")
        Me.LblCopiesText.Name = "LblCopiesText"
        '
        'LblPathText
        '
        resources.ApplyResources(Me.LblPathText, "LblPathText")
        Me.LblPathText.Name = "LblPathText"
        '
        'Button2
        '
        resources.ApplyResources(Me.Button2, "Button2")
        Me.Button2.Image = Global.LM_job.My.Resources.Resources.settings_icon
        Me.Button2.Name = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'BtnEdit
        '
        Me.BtnEdit.Image = Global.LM_job.My.Resources.Resources.edit
        resources.ApplyResources(Me.BtnEdit, "BtnEdit")
        Me.BtnEdit.Name = "BtnEdit"
        Me.BtnEdit.UseVisualStyleBackColor = True
        '
        'BtnNewJob
        '
        resources.ApplyResources(Me.BtnNewJob, "BtnNewJob")
        Me.BtnNewJob.Image = Global.LM_job.My.Resources.Resources.add_file_16
        Me.BtnNewJob.Name = "BtnNewJob"
        Me.BtnNewJob.UseVisualStyleBackColor = True
        '
        'BtnDlete
        '
        Me.BtnDlete.Image = Global.LM_job.My.Resources.Resources.delete
        resources.ApplyResources(Me.BtnDlete, "BtnDlete")
        Me.BtnDlete.Name = "BtnDlete"
        Me.BtnDlete.UseVisualStyleBackColor = True
        '
        'BtnOpen
        '
        Me.BtnOpen.Image = Global.LM_job.My.Resources.Resources.printer_16
        resources.ApplyResources(Me.BtnOpen, "BtnOpen")
        Me.BtnOpen.Name = "BtnOpen"
        Me.BtnOpen.UseVisualStyleBackColor = True
        '
        'BtnProject
        '
        resources.ApplyResources(Me.BtnProject, "BtnProject")
        Me.BtnProject.Image = Global.LM_job.My.Resources.Resources.add_folder_16
        Me.BtnProject.Name = "BtnProject"
        Me.BtnProject.UseVisualStyleBackColor = True
        '
        'Form1
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.LblPathText)
        Me.Controls.Add(Me.LblCopiesText)
        Me.Controls.Add(Me.LblDetalsText)
        Me.Controls.Add(Me.LblPrinterText)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.LblPath)
        Me.Controls.Add(Me.LblPrinter)
        Me.Controls.Add(Me.LblCopies)
        Me.Controls.Add(Me.LblDetals)
        Me.Controls.Add(Me.BtnEdit)
        Me.Controls.Add(Me.BtnNewJob)
        Me.Controls.Add(Me.BtnDlete)
        Me.Controls.Add(Me.BtnOpen)
        Me.Controls.Add(Me.BtnProject)
        Me.Controls.Add(Me.LstJobs)
        Me.Controls.Add(Me.TxbFilter1)
        Me.Controls.Add(Me.LsbProjects)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents LsbProjects As ListBox
    Friend WithEvents TxbFilter1 As TextBox
    Friend WithEvents LstJobs As ListBox
    Friend WithEvents BtnProject As Button
    Friend WithEvents BtnOpen As Button
    Friend WithEvents BtnDlete As Button
    Friend WithEvents BtnNewJob As Button
    Friend WithEvents BtnEdit As Button
    Friend WithEvents LblDetals As Label
    Friend WithEvents LblCopies As Label
    Friend WithEvents LblPrinter As Label
    Friend WithEvents LblPath As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents LblPrinterText As Label
    Friend WithEvents LblDetalsText As Label
    Friend WithEvents LblCopiesText As Label
    Friend WithEvents LblPathText As Label
    Friend WithEvents Button2 As Button
End Class

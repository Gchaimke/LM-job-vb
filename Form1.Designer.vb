<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewProjectFolderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewJobFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LsbProjects = New System.Windows.Forms.ListBox()
        Me.TxbFilter1 = New System.Windows.Forms.TextBox()
        Me.LstJobs = New System.Windows.Forms.ListBox()
        Me.BtnProject = New System.Windows.Forms.Button()
        Me.BtnOpen = New System.Windows.Forms.Button()
        Me.BtnDlete = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.BtnEdit = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(4, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(432, 24)
        Me.MenuStrip1.TabIndex = 4
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewProjectFolderToolStripMenuItem, Me.NewJobFileToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'NewProjectFolderToolStripMenuItem
        '
        Me.NewProjectFolderToolStripMenuItem.Name = "NewProjectFolderToolStripMenuItem"
        Me.NewProjectFolderToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.NewProjectFolderToolStripMenuItem.Text = "New Project folder"
        '
        'NewJobFileToolStripMenuItem
        '
        Me.NewJobFileToolStripMenuItem.Name = "NewJobFileToolStripMenuItem"
        Me.NewJobFileToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.NewJobFileToolStripMenuItem.Text = "New Job file"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SettingsToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 81)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Found ="
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 42)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Project Filter"
        '
        'LsbProjects
        '
        Me.LsbProjects.FormattingEnabled = True
        Me.LsbProjects.Location = New System.Drawing.Point(9, 97)
        Me.LsbProjects.Name = "LsbProjects"
        Me.LsbProjects.Size = New System.Drawing.Size(108, 160)
        Me.LsbProjects.TabIndex = 2
        '
        'TxbFilter1
        '
        Me.TxbFilter1.Location = New System.Drawing.Point(9, 59)
        Me.TxbFilter1.Name = "TxbFilter1"
        Me.TxbFilter1.Size = New System.Drawing.Size(108, 20)
        Me.TxbFilter1.TabIndex = 1
        '
        'LstJobs
        '
        Me.LstJobs.FormattingEnabled = True
        Me.LstJobs.Location = New System.Drawing.Point(128, 97)
        Me.LstJobs.Name = "LstJobs"
        Me.LstJobs.Size = New System.Drawing.Size(145, 160)
        Me.LstJobs.TabIndex = 3
        '
        'BtnProject
        '
        Me.BtnProject.Location = New System.Drawing.Point(9, 263)
        Me.BtnProject.Name = "BtnProject"
        Me.BtnProject.Size = New System.Drawing.Size(108, 23)
        Me.BtnProject.TabIndex = 4
        Me.BtnProject.Text = "New Project folder"
        Me.BtnProject.UseVisualStyleBackColor = True
        '
        'BtnOpen
        '
        Me.BtnOpen.Location = New System.Drawing.Point(279, 205)
        Me.BtnOpen.Name = "BtnOpen"
        Me.BtnOpen.Size = New System.Drawing.Size(75, 23)
        Me.BtnOpen.TabIndex = 6
        Me.BtnOpen.Text = "Open"
        Me.BtnOpen.UseVisualStyleBackColor = True
        '
        'BtnDlete
        '
        Me.BtnDlete.Location = New System.Drawing.Point(279, 234)
        Me.BtnDlete.Name = "BtnDlete"
        Me.BtnDlete.Size = New System.Drawing.Size(75, 23)
        Me.BtnDlete.TabIndex = 7
        Me.BtnDlete.Text = "Delete"
        Me.BtnDlete.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(128, 263)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(145, 23)
        Me.Button3.TabIndex = 8
        Me.Button3.Text = "New job file"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'BtnEdit
        '
        Me.BtnEdit.Location = New System.Drawing.Point(279, 176)
        Me.BtnEdit.Name = "BtnEdit"
        Me.BtnEdit.Size = New System.Drawing.Size(75, 23)
        Me.BtnEdit.TabIndex = 11
        Me.BtnEdit.Text = "Edit"
        Me.BtnEdit.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(432, 295)
        Me.Controls.Add(Me.BtnEdit)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.BtnDlete)
        Me.Controls.Add(Me.BtnOpen)
        Me.Controls.Add(Me.BtnProject)
        Me.Controls.Add(Me.LstJobs)
        Me.Controls.Add(Me.TxbFilter1)
        Me.Controls.Add(Me.LsbProjects)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MainForm"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents LsbProjects As ListBox
    Friend WithEvents TxbFilter1 As TextBox
    Friend WithEvents LstJobs As ListBox
    Friend WithEvents BtnProject As Button
    Friend WithEvents BtnOpen As Button
    Friend WithEvents BtnDlete As Button
    Friend WithEvents NewProjectFolderToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NewJobFileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Button3 As Button
    Friend WithEvents SettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BtnEdit As Button
End Class

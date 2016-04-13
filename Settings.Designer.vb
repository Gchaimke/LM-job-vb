<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Settings
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.BtnFolder = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.BtnCencel = New System.Windows.Forms.Button()
        Me.BtnProgram = New System.Windows.Forms.Button()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxbFileExt = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Projects Folder"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(108, 20)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(305, 20)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.Text = "\LM-job"
        '
        'FolderBrowserDialog1
        '
        Me.FolderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyDocuments
        '
        'BtnFolder
        '
        Me.BtnFolder.Location = New System.Drawing.Point(419, 18)
        Me.BtnFolder.Name = "BtnFolder"
        Me.BtnFolder.Size = New System.Drawing.Size(41, 23)
        Me.BtnFolder.TabIndex = 2
        Me.BtnFolder.Text = "..."
        Me.BtnFolder.UseVisualStyleBackColor = True
        '
        'BtnSave
        '
        Me.BtnSave.Location = New System.Drawing.Point(12, 226)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 23)
        Me.BtnSave.TabIndex = 3
        Me.BtnSave.Text = "Save"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'BtnCencel
        '
        Me.BtnCencel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCencel.Location = New System.Drawing.Point(437, 226)
        Me.BtnCencel.Name = "BtnCencel"
        Me.BtnCencel.Size = New System.Drawing.Size(75, 23)
        Me.BtnCencel.TabIndex = 4
        Me.BtnCencel.Text = "Cencel"
        Me.BtnCencel.UseVisualStyleBackColor = True
        '
        'BtnProgram
        '
        Me.BtnProgram.Location = New System.Drawing.Point(419, 47)
        Me.BtnProgram.Name = "BtnProgram"
        Me.BtnProgram.Size = New System.Drawing.Size(41, 23)
        Me.BtnProgram.TabIndex = 7
        Me.BtnProgram.Text = "..."
        Me.BtnProgram.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.LM_job.My.MySettings.Default, "ProgramPath", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.TextBox2.Location = New System.Drawing.Point(108, 49)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(305, 20)
        Me.TextBox2.TabIndex = 6
        Me.TextBox2.Text = Global.LM_job.My.MySettings.Default.ProgramPath
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Defoult Program"
        '
        'TxbFileExt
        '
        Me.TxbFileExt.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.LM_job.My.MySettings.Default, "FileExt", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.TxbFileExt.Location = New System.Drawing.Point(108, 80)
        Me.TxbFileExt.Name = "TxbFileExt"
        Me.TxbFileExt.Size = New System.Drawing.Size(305, 20)
        Me.TxbFileExt.TabIndex = 9
        Me.TxbFileExt.Text = Global.LM_job.My.MySettings.Default.FileExt
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "File Extension"
        '
        'Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnCencel
        Me.ClientSize = New System.Drawing.Size(524, 261)
        Me.Controls.Add(Me.TxbFileExt)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.BtnProgram)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BtnCencel)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.BtnFolder)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Settings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Settings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents BtnFolder As Button
    Friend WithEvents BtnSave As Button
    Friend WithEvents BtnCencel As Button
    Friend WithEvents BtnProgram As Button
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TxbFileExt As TextBox
    Friend WithEvents Label3 As Label
End Class

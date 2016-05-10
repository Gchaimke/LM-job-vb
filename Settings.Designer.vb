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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Settings))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.BtnCencel = New System.Windows.Forms.Button()
        Me.BtnProgram = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BtnReset = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxbFileExt = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'FolderBrowserDialog1
        '
        Me.FolderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyDocuments
        '
        'BtnSave
        '
        resources.ApplyResources(Me.BtnSave, "BtnSave")
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'BtnCencel
        '
        Me.BtnCencel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        resources.ApplyResources(Me.BtnCencel, "BtnCencel")
        Me.BtnCencel.Name = "BtnCencel"
        Me.BtnCencel.UseVisualStyleBackColor = True
        '
        'BtnProgram
        '
        resources.ApplyResources(Me.BtnProgram, "BtnProgram")
        Me.BtnProgram.Name = "BtnProgram"
        Me.BtnProgram.UseVisualStyleBackColor = True
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'BtnReset
        '
        resources.ApplyResources(Me.BtnReset, "BtnReset")
        Me.BtnReset.Name = "BtnReset"
        Me.BtnReset.UseVisualStyleBackColor = True
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'TxbFileExt
        '
        Me.TxbFileExt.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.LM_job.My.MySettings.Default, "FileExt", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        resources.ApplyResources(Me.TxbFileExt, "TxbFileExt")
        Me.TxbFileExt.Name = "TxbFileExt"
        Me.TxbFileExt.Text = Global.LM_job.My.MySettings.Default.FileExt
        '
        'TextBox2
        '
        Me.TextBox2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.LM_job.My.MySettings.Default, "ProgramPath", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        resources.ApplyResources(Me.TextBox2, "TextBox2")
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Text = Global.LM_job.My.MySettings.Default.ProgramPath
        '
        'ComboBox1
        '
        Me.ComboBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.LM_job.My.MySettings.Default, "language", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {resources.GetString("ComboBox1.Items"), resources.GetString("ComboBox1.Items1")})
        resources.ApplyResources(Me.ComboBox1, "ComboBox1")
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Text = Global.LM_job.My.MySettings.Default.language
        '
        'Settings
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnCencel
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.BtnReset)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxbFileExt)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.BtnProgram)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BtnCencel)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Settings"
        Me.Text = Global.LM_job.My.MySettings.Default.ProgramPath
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents BtnSave As Button
    Friend WithEvents BtnCencel As Button
    Friend WithEvents BtnProgram As Button
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TxbFileExt As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents BtnReset As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents ComboBox1 As ComboBox
End Class

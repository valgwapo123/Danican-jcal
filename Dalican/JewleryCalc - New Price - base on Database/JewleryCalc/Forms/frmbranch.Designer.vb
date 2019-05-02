<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmbranch
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
        Me.lvlbranch = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtBranchname = New System.Windows.Forms.TextBox()
        Me.btnsave = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.txtPath = New System.Windows.Forms.TextBox()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.ofdIMD = New System.Windows.Forms.OpenFileDialog()
        Me.btnUpload = New System.Windows.Forms.Button()
        Me.txtIDBranch = New System.Windows.Forms.TextBox()
        Me.pbStatus = New System.Windows.Forms.ProgressBar()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtbranchcode = New System.Windows.Forms.TextBox()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lvlbranch
        '
        Me.lvlbranch.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.lvlbranch.Location = New System.Drawing.Point(125, 298)
        Me.lvlbranch.Name = "lvlbranch"
        Me.lvlbranch.Size = New System.Drawing.Size(368, 116)
        Me.lvlbranch.TabIndex = 0
        Me.lvlbranch.UseCompatibleStateImageBehavior = False
        Me.lvlbranch.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ID"
        Me.ColumnHeader1.Width = 100
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "BRANCH CODE"
        Me.ColumnHeader2.Width = 100
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(421, 244)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(105, 31)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Add"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(125, 253)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Branch Name:"
        '
        'txtBranchname
        '
        Me.txtBranchname.Location = New System.Drawing.Point(210, 250)
        Me.txtBranchname.Name = "txtBranchname"
        Me.txtBranchname.Size = New System.Drawing.Size(190, 20)
        Me.txtBranchname.TabIndex = 9
        '
        'btnsave
        '
        Me.btnsave.Location = New System.Drawing.Point(130, 426)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(105, 31)
        Me.btnsave.TabIndex = 10
        Me.btnsave.Text = "SAVE"
        Me.btnsave.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(252, 426)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(105, 31)
        Me.Button3.TabIndex = 11
        Me.Button3.Text = "RREMOVE"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'txtPath
        '
        Me.txtPath.Location = New System.Drawing.Point(78, 49)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.ReadOnly = True
        Me.txtPath.Size = New System.Drawing.Size(403, 20)
        Me.txtPath.TabIndex = 12
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(487, 43)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(50, 31)
        Me.btnBrowse.TabIndex = 13
        Me.btnBrowse.Text = ". . ."
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'ofdIMD
        '
        Me.ofdIMD.Filter = "Excel 2003|*.xls|Excel 2007|*.xlsx"
        '
        'btnUpload
        '
        Me.btnUpload.Location = New System.Drawing.Point(352, 75)
        Me.btnUpload.Name = "btnUpload"
        Me.btnUpload.Size = New System.Drawing.Size(105, 31)
        Me.btnUpload.TabIndex = 14
        Me.btnUpload.Text = "Upload"
        Me.btnUpload.UseVisualStyleBackColor = True
        '
        'txtIDBranch
        '
        Me.txtIDBranch.Location = New System.Drawing.Point(121, 81)
        Me.txtIDBranch.Name = "txtIDBranch"
        Me.txtIDBranch.Size = New System.Drawing.Size(190, 20)
        Me.txtIDBranch.TabIndex = 15
        '
        'pbStatus
        '
        Me.pbStatus.Location = New System.Drawing.Point(78, 117)
        Me.pbStatus.Name = "pbStatus"
        Me.pbStatus.Size = New System.Drawing.Size(459, 16)
        Me.pbStatus.TabIndex = 16
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(264, 136)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(15, 13)
        Me.lblStatus.TabIndex = 17
        Me.lblStatus.Text = "%"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(125, 221)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Branch Code:"
        '
        'txtbranchcode
        '
        Me.txtbranchcode.Location = New System.Drawing.Point(210, 218)
        Me.txtbranchcode.Name = "txtbranchcode"
        Me.txtbranchcode.Size = New System.Drawing.Size(190, 20)
        Me.txtbranchcode.TabIndex = 19
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "BRANCH NAME"
        Me.ColumnHeader3.Width = 100
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(63, 23)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(488, 153)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Uploader"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(388, 426)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(105, 31)
        Me.Button2.TabIndex = 21
        Me.Button2.Text = "BROWSE"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'frmbranch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 460)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtbranchcode)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.pbStatus)
        Me.Controls.Add(Me.txtIDBranch)
        Me.Controls.Add(Me.btnUpload)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.txtPath)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.btnsave)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtBranchname)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lvlbranch)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmbranch"
        Me.Text = "frmbranch"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lvlbranch As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtBranchname As System.Windows.Forms.TextBox
    Friend WithEvents btnsave As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents txtPath As System.Windows.Forms.TextBox
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents ofdIMD As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnUpload As System.Windows.Forms.Button
    Friend WithEvents txtIDBranch As System.Windows.Forms.TextBox
    Friend WithEvents pbStatus As System.Windows.Forms.ProgressBar
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtbranchcode As System.Windows.Forms.TextBox
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class

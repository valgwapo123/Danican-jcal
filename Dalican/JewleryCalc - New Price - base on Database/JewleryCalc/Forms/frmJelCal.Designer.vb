<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmJelCal
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmJelCal))
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.lblPath = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.chkProWedGensan = New System.Windows.Forms.CheckBox()
        Me.btnBarcode = New System.Windows.Forms.Button()
        Me.btnGenerate = New System.Windows.Forms.Button()
        Me.btnAddClass = New System.Windows.Forms.Button()
        Me.ofdJeltmp = New System.Windows.Forms.OpenFileDialog()
        Me.sfdPath = New System.Windows.Forms.SaveFileDialog()
        Me.pbstatus = New System.Windows.Forms.ProgressBar()
        Me.lblstatus = New System.Windows.Forms.Label()
        Me.cms = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ShowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGRchecker = New System.Windows.Forms.Button()
        Me.btnBrowseGR = New System.Windows.Forms.Button()
        Me.btnBrowseIMD = New System.Windows.Forms.Button()
        Me.lblGRPath = New System.Windows.Forms.Label()
        Me.lblIMDpath = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.BRANCH = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.cms.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnBrowse
        '
        Me.btnBrowse.Font = New System.Drawing.Font("Forte", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBrowse.Location = New System.Drawing.Point(6, 31)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(75, 35)
        Me.btnBrowse.TabIndex = 0
        Me.btnBrowse.Text = "&Browse"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'lblPath
        '
        Me.lblPath.AutoSize = True
        Me.lblPath.Location = New System.Drawing.Point(10, 13)
        Me.lblPath.Name = "lblPath"
        Me.lblPath.Size = New System.Drawing.Size(59, 14)
        Me.lblPath.TabIndex = 1
        Me.lblPath.Text = "File not yet"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.chkProWedGensan)
        Me.GroupBox1.Controls.Add(Me.btnBarcode)
        Me.GroupBox1.Controls.Add(Me.btnGenerate)
        Me.GroupBox1.Controls.Add(Me.lblPath)
        Me.GroupBox1.Controls.Add(Me.btnBrowse)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 139)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(549, 78)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Forte", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(464, 32)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 32)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "SWITCH"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Forte", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(384, 31)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 32)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Price"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'chkProWedGensan
        '
        Me.chkProWedGensan.AutoSize = True
        Me.chkProWedGensan.Location = New System.Drawing.Point(184, 40)
        Me.chkProWedGensan.Name = "chkProWedGensan"
        Me.chkProWedGensan.Size = New System.Drawing.Size(90, 18)
        Me.chkProWedGensan.TabIndex = 4
        Me.chkProWedGensan.Text = "Gensan Area"
        Me.chkProWedGensan.UseVisualStyleBackColor = True
        '
        'btnBarcode
        '
        Me.btnBarcode.Font = New System.Drawing.Font("Forte", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBarcode.Location = New System.Drawing.Point(305, 31)
        Me.btnBarcode.Name = "btnBarcode"
        Me.btnBarcode.Size = New System.Drawing.Size(75, 32)
        Me.btnBarcode.TabIndex = 3
        Me.btnBarcode.Text = "Barcode"
        Me.btnBarcode.UseVisualStyleBackColor = True
        '
        'btnGenerate
        '
        Me.btnGenerate.Font = New System.Drawing.Font("Forte", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerate.Location = New System.Drawing.Point(87, 32)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(75, 35)
        Me.btnGenerate.TabIndex = 2
        Me.btnGenerate.Text = "&Generate"
        Me.btnGenerate.UseVisualStyleBackColor = True
        '
        'btnAddClass
        '
        Me.btnAddClass.Location = New System.Drawing.Point(234, 323)
        Me.btnAddClass.Name = "btnAddClass"
        Me.btnAddClass.Size = New System.Drawing.Size(120, 47)
        Me.btnAddClass.TabIndex = 3
        Me.btnAddClass.Text = "&Add Class"
        Me.btnAddClass.UseVisualStyleBackColor = True
        '
        'ofdJeltmp
        '
        Me.ofdJeltmp.Filter = "Excel 2003|*.xls|Excel 2007|*.xlsx"
        '
        'sfdPath
        '
        Me.sfdPath.DefaultExt = "xls"
        Me.sfdPath.Filter = "Excel File 2003|*.xls"
        '
        'pbstatus
        '
        Me.pbstatus.Location = New System.Drawing.Point(13, 242)
        Me.pbstatus.Name = "pbstatus"
        Me.pbstatus.Size = New System.Drawing.Size(538, 15)
        Me.pbstatus.TabIndex = 4
        '
        'lblstatus
        '
        Me.lblstatus.AutoSize = True
        Me.lblstatus.Location = New System.Drawing.Point(14, 223)
        Me.lblstatus.Name = "lblstatus"
        Me.lblstatus.Size = New System.Drawing.Size(38, 14)
        Me.lblstatus.TabIndex = 5
        Me.lblstatus.Text = "0.00%"
        '
        'cms
        '
        Me.cms.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowToolStripMenuItem})
        Me.cms.Name = "cms"
        Me.cms.Size = New System.Drawing.Size(104, 26)
        '
        'ShowToolStripMenuItem
        '
        Me.ShowToolStripMenuItem.Name = "ShowToolStripMenuItem"
        Me.ShowToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.ShowToolStripMenuItem.Text = "Show"
        '
        'btnGRchecker
        '
        Me.btnGRchecker.Location = New System.Drawing.Point(7, 91)
        Me.btnGRchecker.Name = "btnGRchecker"
        Me.btnGRchecker.Size = New System.Drawing.Size(86, 39)
        Me.btnGRchecker.TabIndex = 3
        Me.btnGRchecker.Text = "&Check GR"
        Me.btnGRchecker.UseVisualStyleBackColor = True
        '
        'btnBrowseGR
        '
        Me.btnBrowseGR.Location = New System.Drawing.Point(6, 19)
        Me.btnBrowseGR.Name = "btnBrowseGR"
        Me.btnBrowseGR.Size = New System.Drawing.Size(86, 28)
        Me.btnBrowseGR.TabIndex = 6
        Me.btnBrowseGR.Text = "&Broswse GR"
        Me.btnBrowseGR.UseVisualStyleBackColor = True
        '
        'btnBrowseIMD
        '
        Me.btnBrowseIMD.Location = New System.Drawing.Point(6, 53)
        Me.btnBrowseIMD.Name = "btnBrowseIMD"
        Me.btnBrowseIMD.Size = New System.Drawing.Size(86, 28)
        Me.btnBrowseIMD.TabIndex = 7
        Me.btnBrowseIMD.Text = "&Browse IMD"
        Me.btnBrowseIMD.UseVisualStyleBackColor = True
        '
        'lblGRPath
        '
        Me.lblGRPath.AutoSize = True
        Me.lblGRPath.Location = New System.Drawing.Point(98, 26)
        Me.lblGRPath.Name = "lblGRPath"
        Me.lblGRPath.Size = New System.Drawing.Size(77, 14)
        Me.lblGRPath.TabIndex = 8
        Me.lblGRPath.Text = "GR File not yet"
        '
        'lblIMDpath
        '
        Me.lblIMDpath.AutoSize = True
        Me.lblIMDpath.Location = New System.Drawing.Point(98, 60)
        Me.lblIMDpath.Name = "lblIMDpath"
        Me.lblIMDpath.Size = New System.Drawing.Size(79, 14)
        Me.lblIMDpath.TabIndex = 9
        Me.lblIMDpath.Text = "IMD File not yet"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnBrowseGR)
        Me.GroupBox2.Controls.Add(Me.btnGRchecker)
        Me.GroupBox2.Controls.Add(Me.lblIMDpath)
        Me.GroupBox2.Controls.Add(Me.btnBrowseIMD)
        Me.GroupBox2.Controls.Add(Me.lblGRPath)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 120)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(538, 11)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Visible = False
        '
        'BRANCH
        '
        Me.BRANCH.AutoSize = True
        Me.BRANCH.Font = New System.Drawing.Font("Arial", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BRANCH.Location = New System.Drawing.Point(256, 33)
        Me.BRANCH.Name = "BRANCH"
        Me.BRANCH.Size = New System.Drawing.Size(43, 42)
        Me.BRANCH.TabIndex = 13
        Me.BRANCH.Text = "X"
        Me.BRANCH.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(199, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(313, 27)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "JEWEL CALCULATOR V.2.2"
        Me.Label1.Visible = False
        '
        'frmJelCal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(552, 257)
        Me.ContextMenuStrip = Me.cms
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BRANCH)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lblstatus)
        Me.Controls.Add(Me.pbstatus)
        Me.Controls.Add(Me.btnAddClass)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(568, 296)
        Me.MinimumSize = New System.Drawing.Size(568, 296)
        Me.Name = "frmJelCal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Jewelry Calculator | XVAL | Version 1.1.2.0"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.cms.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents lblPath As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnGenerate As System.Windows.Forms.Button
    Friend WithEvents btnAddClass As System.Windows.Forms.Button
    Friend WithEvents ofdJeltmp As System.Windows.Forms.OpenFileDialog
    Friend WithEvents sfdPath As System.Windows.Forms.SaveFileDialog
    Friend WithEvents pbstatus As System.Windows.Forms.ProgressBar
    Friend WithEvents lblstatus As System.Windows.Forms.Label
    Friend WithEvents cms As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ShowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnGRchecker As System.Windows.Forms.Button
    Friend WithEvents btnBrowseGR As System.Windows.Forms.Button
    Friend WithEvents btnBrowseIMD As System.Windows.Forms.Button
    Friend WithEvents lblGRPath As System.Windows.Forms.Label
    Friend WithEvents lblIMDpath As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnBarcode As System.Windows.Forms.Button
    Friend WithEvents chkProWedGensan As System.Windows.Forms.CheckBox
    Friend WithEvents BRANCH As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button

End Class

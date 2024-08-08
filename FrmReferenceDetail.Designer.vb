<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmReferenceDetail
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
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnSave = New System.Windows.Forms.ToolStripButton()
        Me.btnClear = New System.Windows.Forms.ToolStripButton()
        Me.btnSetting = New System.Windows.Forms.ToolStripButton()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.txtColumnName = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.cboReferenceBy = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.pnlReference = New System.Windows.Forms.Panel()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.txtColumnName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboReferenceBy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSave, Me.btnClear, Me.btnSetting})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(304, 25)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Image = Global.DataGenerator.My.Resources.Resources.OK
        Me.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSave.Margin = New System.Windows.Forms.Padding(0)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(55, 25)
        Me.btnSave.Tag = ""
        Me.btnSave.Text = "Save"
        Me.btnSave.ToolTipText = "Save (Ctrl + S)"
        '
        'btnClear
        '
        Me.btnClear.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.Image = Global.DataGenerator.My.Resources.Resources._Exit
        Me.btnClear.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnClear.Margin = New System.Windows.Forms.Padding(0)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(57, 25)
        Me.btnClear.Tag = ""
        Me.btnClear.Text = "Clear"
        Me.btnClear.ToolTipText = "Clear (Ctrl + Del)"
        '
        'btnSetting
        '
        Me.btnSetting.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSetting.Image = Global.DataGenerator.My.Resources.Resources.Detail
        Me.btnSetting.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSetting.Margin = New System.Windows.Forms.Padding(0)
        Me.btnSetting.Name = "btnSetting"
        Me.btnSetting.Size = New System.Drawing.Size(67, 25)
        Me.btnSetting.Tag = ""
        Me.btnSetting.Text = "Setting"
        Me.btnSetting.ToolTipText = "Setting (Ctrl + Shift + S)"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(22, 48)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(65, 13)
        Me.LabelControl3.TabIndex = 7
        Me.LabelControl3.Text = "Column Name"
        '
        'txtColumnName
        '
        Me.txtColumnName.Enabled = False
        Me.txtColumnName.Location = New System.Drawing.Point(141, 45)
        Me.txtColumnName.Name = "txtColumnName"
        Me.txtColumnName.Size = New System.Drawing.Size(138, 20)
        Me.txtColumnName.TabIndex = 8
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(22, 74)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(65, 13)
        Me.LabelControl5.TabIndex = 10
        Me.LabelControl5.Text = "Reference by"
        '
        'cboReferenceBy
        '
        Me.cboReferenceBy.Location = New System.Drawing.Point(141, 71)
        Me.cboReferenceBy.Name = "cboReferenceBy"
        Me.cboReferenceBy.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboReferenceBy.Size = New System.Drawing.Size(138, 20)
        Me.cboReferenceBy.TabIndex = 11
        '
        'pnlReference
        '
        Me.pnlReference.AutoSize = True
        Me.pnlReference.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.pnlReference.Location = New System.Drawing.Point(19, 97)
        Me.pnlReference.Name = "pnlReference"
        Me.pnlReference.Padding = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.pnlReference.Size = New System.Drawing.Size(270, 95)
        Me.pnlReference.TabIndex = 56
        '
        'FrmReferenceDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(304, 201)
        Me.Controls.Add(Me.pnlReference)
        Me.Controls.Add(Me.cboReferenceBy)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.txtColumnName)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(320, 240)
        Me.Name = "FrmReferenceDetail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detail"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.txtColumnName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboReferenceBy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As Windows.Forms.ToolStrip
    Friend WithEvents btnSave As Windows.Forms.ToolStripButton
    Friend WithEvents btnClear As Windows.Forms.ToolStripButton
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtColumnName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboReferenceBy As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents pnlReference As Windows.Forms.Panel
    Friend WithEvents btnSetting As Windows.Forms.ToolStripButton
End Class

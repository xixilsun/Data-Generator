<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReferenceDetail
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
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnSave = New System.Windows.Forms.ToolStripButton()
        Me.btnClear = New System.Windows.Forms.ToolStripButton()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.cboParentTable = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.cboParentID = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.txtColumnName = New DevExpress.XtraEditors.TextEdit()
        Me.cboParentDatabase = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.cboParentTable.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboParentID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtColumnName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboParentDatabase.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(22, 107)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(95, 13)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "Reference to Table "
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSave, Me.btnClear})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(309, 25)
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
        Me.btnSave.Text = "Save"
        '
        'btnClear
        '
        Me.btnClear.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.Image = Global.DataGenerator.My.Resources.Resources._Exit
        Me.btnClear.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnClear.Margin = New System.Windows.Forms.Padding(0)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(57, 25)
        Me.btnClear.Text = "Clear"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(22, 136)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(80, 13)
        Me.LabelControl2.TabIndex = 4
        Me.LabelControl2.Text = "Reference to ID "
        '
        'cboParentTable
        '
        Me.cboParentTable.Location = New System.Drawing.Point(141, 104)
        Me.cboParentTable.Name = "cboParentTable"
        Me.cboParentTable.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboParentTable.Size = New System.Drawing.Size(138, 20)
        Me.cboParentTable.TabIndex = 2
        '
        'cboParentID
        '
        Me.cboParentID.Location = New System.Drawing.Point(141, 133)
        Me.cboParentID.Name = "cboParentID"
        Me.cboParentID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboParentID.Size = New System.Drawing.Size(138, 20)
        Me.cboParentID.TabIndex = 3
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
        'cboParentDatabase
        '
        Me.cboParentDatabase.Location = New System.Drawing.Point(141, 73)
        Me.cboParentDatabase.Name = "cboParentDatabase"
        Me.cboParentDatabase.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboParentDatabase.Size = New System.Drawing.Size(138, 20)
        Me.cboParentDatabase.TabIndex = 1
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(22, 76)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(79, 13)
        Me.LabelControl4.TabIndex = 9
        Me.LabelControl4.Text = "Reference to DB"
        '
        'FrmReferenceDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(309, 176)
        Me.Controls.Add(Me.cboParentDatabase)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.txtColumnName)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.cboParentID)
        Me.Controls.Add(Me.cboParentTable)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.LabelControl1)
        Me.Name = "FrmReferenceDetail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detail"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.cboParentTable.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboParentID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtColumnName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboParentDatabase.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ToolStrip1 As Windows.Forms.ToolStrip
    Friend WithEvents btnSave As Windows.Forms.ToolStripButton
    Friend WithEvents btnClear As Windows.Forms.ToolStripButton
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboParentTable As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents cboParentID As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtColumnName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cboParentDatabase As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
End Class

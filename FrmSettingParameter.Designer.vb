<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmSettingParameter
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
        Me.txtColumnName = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtUserDefined = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboSubcategory = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.cboCategory = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.btnGenerate = New DevExpress.XtraEditors.SimpleButton()
        Me.txtMaxLength = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtParameterList = New System.Windows.Forms.TextBox()
        Me.btnGetParameter = New DevExpress.XtraEditors.SimpleButton()
        Me.pnlParameters = New System.Windows.Forms.Panel()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.txtColumnName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboSubcategory.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboCategory.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMaxLength.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSave, Me.btnClear})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1035, 25)
        Me.ToolStrip1.TabIndex = 3
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
        'txtColumnName
        '
        Me.txtColumnName.Location = New System.Drawing.Point(121, 51)
        Me.txtColumnName.Name = "txtColumnName"
        Me.txtColumnName.Size = New System.Drawing.Size(143, 20)
        Me.txtColumnName.TabIndex = 10
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(25, 54)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(65, 13)
        Me.LabelControl3.TabIndex = 9
        Me.LabelControl3.Text = "Column Name"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label4.Location = New System.Drawing.Point(22, 168)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 14)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "User Defined List"
        '
        'txtUserDefined
        '
        Me.txtUserDefined.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUserDefined.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUserDefined.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtUserDefined.Location = New System.Drawing.Point(25, 188)
        Me.txtUserDefined.Margin = New System.Windows.Forms.Padding(10)
        Me.txtUserDefined.Multiline = True
        Me.txtUserDefined.Name = "txtUserDefined"
        Me.txtUserDefined.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtUserDefined.Size = New System.Drawing.Size(259, 117)
        Me.txtUserDefined.TabIndex = 19
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Location = New System.Drawing.Point(22, 312)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(135, 14)
        Me.Label9.TabIndex = 37
        Me.Label9.Text = "Separate the list by ENTER"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label1.Location = New System.Drawing.Point(22, 111)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 14)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "Subcategory"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label3.Location = New System.Drawing.Point(22, 82)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 14)
        Me.Label3.TabIndex = 39
        Me.Label3.Text = "Category"
        '
        'cboSubcategory
        '
        Me.cboSubcategory.Location = New System.Drawing.Point(121, 108)
        Me.cboSubcategory.Name = "cboSubcategory"
        Me.cboSubcategory.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboSubcategory.Size = New System.Drawing.Size(143, 20)
        Me.cboSubcategory.TabIndex = 44
        '
        'cboCategory
        '
        Me.cboCategory.Location = New System.Drawing.Point(121, 79)
        Me.cboCategory.Name = "cboCategory"
        Me.cboCategory.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboCategory.Size = New System.Drawing.Size(143, 20)
        Me.cboCategory.TabIndex = 45
        '
        'btnGenerate
        '
        Me.btnGenerate.Location = New System.Drawing.Point(436, 312)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(114, 23)
        Me.btnGenerate.TabIndex = 47
        Me.btnGenerate.Text = "Generate Sample"
        '
        'txtMaxLength
        '
        Me.txtMaxLength.Location = New System.Drawing.Point(121, 136)
        Me.txtMaxLength.Name = "txtMaxLength"
        Me.txtMaxLength.Size = New System.Drawing.Size(143, 20)
        Me.txtMaxLength.TabIndex = 51
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(25, 139)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(56, 13)
        Me.LabelControl4.TabIndex = 50
        Me.LabelControl4.Text = "Max Length"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label5.Location = New System.Drawing.Point(301, 168)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 14)
        Me.Label5.TabIndex = 53
        Me.Label5.Text = "Parameter List"
        '
        'txtParameterList
        '
        Me.txtParameterList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtParameterList.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtParameterList.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtParameterList.Location = New System.Drawing.Point(304, 186)
        Me.txtParameterList.Margin = New System.Windows.Forms.Padding(10)
        Me.txtParameterList.Multiline = True
        Me.txtParameterList.Name = "txtParameterList"
        Me.txtParameterList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtParameterList.Size = New System.Drawing.Size(261, 119)
        Me.txtParameterList.TabIndex = 52
        '
        'btnGetParameter
        '
        Me.btnGetParameter.Location = New System.Drawing.Point(306, 312)
        Me.btnGetParameter.Name = "btnGetParameter"
        Me.btnGetParameter.Size = New System.Drawing.Size(114, 23)
        Me.btnGetParameter.TabIndex = 54
        Me.btnGetParameter.Text = "Get Parameter"
        '
        'pnlParameters
        '
        Me.pnlParameters.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.pnlParameters.Location = New System.Drawing.Point(300, 50)
        Me.pnlParameters.Name = "pnlParameters"
        Me.pnlParameters.Size = New System.Drawing.Size(268, 108)
        Me.pnlParameters.TabIndex = 55
        '
        'FrmSettingParameter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1035, 363)
        Me.Controls.Add(Me.pnlParameters)
        Me.Controls.Add(Me.btnGetParameter)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtParameterList)
        Me.Controls.Add(Me.txtMaxLength)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.btnGenerate)
        Me.Controls.Add(Me.cboCategory)
        Me.Controls.Add(Me.cboSubcategory)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtUserDefined)
        Me.Controls.Add(Me.txtColumnName)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "FrmSettingParameter"
        Me.Text = "FrmSettingParameter"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.txtColumnName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboSubcategory.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboCategory.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMaxLength.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As Windows.Forms.ToolStrip
    Friend WithEvents btnSave As Windows.Forms.ToolStripButton
    Friend WithEvents btnClear As Windows.Forms.ToolStripButton
    Friend WithEvents txtColumnName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents txtUserDefined As Windows.Forms.TextBox
    Friend WithEvents Label9 As Windows.Forms.Label
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents cboSubcategory As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents cboCategory As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents btnGenerate As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtMaxLength As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents txtParameterList As Windows.Forms.TextBox
    Friend WithEvents btnGetParameter As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents pnlParameters As Windows.Forms.Panel
End Class

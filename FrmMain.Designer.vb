<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMain))
        Me.txtQuery = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.gc = New DevExpress.XtraGrid.GridControl()
        Me.gv = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.DatasetPanel = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnAdd = New System.Windows.Forms.ToolStripButton()
        Me.btnDelete = New System.Windows.Forms.ToolStripButton()
        Me.btnCategoryDetail = New System.Windows.Forms.ToolStripButton()
        Me.btnClear = New System.Windows.Forms.ToolStripButton()
        Me.btnSaveSetting = New System.Windows.Forms.ToolStripButton()
        Me.btnLoadSetting = New System.Windows.Forms.ToolStripButton()
        Me.SamplePanel = New System.Windows.Forms.Panel()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.btnExportExcel = New System.Windows.Forms.ToolStripButton()
        Me.btnImportExcel = New System.Windows.Forms.ToolStripButton()
        Me.gcOutput = New DevExpress.XtraGrid.GridControl()
        Me.gvOutput = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboDatabase = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboTable = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnPrepareDataset = New DevExpress.XtraEditors.SimpleButton()
        Me.btnGenerate = New DevExpress.XtraEditors.SimpleButton()
        Me.numQty = New DevExpress.XtraEditors.SpinEdit()
        Me.btnCopy = New DevExpress.XtraEditors.SimpleButton()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.gc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DatasetPanel.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SamplePanel.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        CType(Me.gcOutput, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvOutput, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDatabase.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTable.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numQty.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtQuery
        '
        Me.txtQuery.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQuery.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQuery.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtQuery.Location = New System.Drawing.Point(37, 546)
        Me.txtQuery.Margin = New System.Windows.Forms.Padding(10)
        Me.txtQuery.Multiline = True
        Me.txtQuery.Name = "txtQuery"
        Me.txtQuery.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtQuery.Size = New System.Drawing.Size(164, 84)
        Me.txtQuery.TabIndex = 11
        Me.txtQuery.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label4.Location = New System.Drawing.Point(34, 522)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 14)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Result"
        Me.Label4.Visible = False
        '
        'gc
        '
        Me.gc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gc.Location = New System.Drawing.Point(0, 0)
        Me.gc.MainView = Me.gv
        Me.gc.Name = "gc"
        Me.gc.Size = New System.Drawing.Size(827, 242)
        Me.gc.TabIndex = 20
        Me.gc.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gv})
        '
        'gv
        '
        Me.gv.ActiveFilterEnabled = False
        Me.gv.GridControl = Me.gc
        Me.gv.Name = "gv"
        Me.gv.OptionsView.ShowGroupPanel = False
        Me.gv.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowForFocusedRow
        '
        'DatasetPanel
        '
        Me.DatasetPanel.Controls.Add(Me.Panel2)
        Me.DatasetPanel.Controls.Add(Me.ToolStrip1)
        Me.DatasetPanel.Location = New System.Drawing.Point(29, 67)
        Me.DatasetPanel.Name = "DatasetPanel"
        Me.DatasetPanel.Size = New System.Drawing.Size(827, 267)
        Me.DatasetPanel.TabIndex = 21
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.gc)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 25)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(827, 242)
        Me.Panel2.TabIndex = 22
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAdd, Me.btnDelete, Me.btnCategoryDetail, Me.btnClear, Me.btnSaveSetting, Me.btnLoadSetting})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(827, 25)
        Me.ToolStrip1.TabIndex = 21
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(0)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(49, 25)
        Me.btnAdd.Text = "Add"
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(63, 22)
        Me.btnDelete.Text = "Delete"
        '
        'btnCategoryDetail
        '
        Me.btnCategoryDetail.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnCategoryDetail.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCategoryDetail.Image = Global.DataGenerator.My.Resources.Resources.Detail
        Me.btnCategoryDetail.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCategoryDetail.Name = "btnCategoryDetail"
        Me.btnCategoryDetail.Size = New System.Drawing.Size(114, 22)
        Me.btnCategoryDetail.Text = "Category Detail"
        '
        'btnClear
        '
        Me.btnClear.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.Image = Global.DataGenerator.My.Resources.Resources.Clear
        Me.btnClear.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(57, 22)
        Me.btnClear.Text = "Clear"
        '
        'btnSaveSetting
        '
        Me.btnSaveSetting.Image = Global.DataGenerator.My.Resources.Resources.Export
        Me.btnSaveSetting.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSaveSetting.Name = "btnSaveSetting"
        Me.btnSaveSetting.Size = New System.Drawing.Size(91, 22)
        Me.btnSaveSetting.Text = "Save Setting"
        Me.btnSaveSetting.ToolTipText = "Ctrl + S"
        '
        'btnLoadSetting
        '
        Me.btnLoadSetting.Image = Global.DataGenerator.My.Resources.Resources.Import
        Me.btnLoadSetting.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnLoadSetting.Name = "btnLoadSetting"
        Me.btnLoadSetting.Size = New System.Drawing.Size(93, 22)
        Me.btnLoadSetting.Text = "Load Setting"
        Me.btnLoadSetting.ToolTipText = "Ctrl + O"
        '
        'SamplePanel
        '
        Me.SamplePanel.Controls.Add(Me.ToolStrip2)
        Me.SamplePanel.Controls.Add(Me.gcOutput)
        Me.SamplePanel.Location = New System.Drawing.Point(29, 380)
        Me.SamplePanel.Name = "SamplePanel"
        Me.SamplePanel.Size = New System.Drawing.Size(827, 250)
        Me.SamplePanel.TabIndex = 23
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnExportExcel, Me.btnImportExcel})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(827, 25)
        Me.ToolStrip2.TabIndex = 21
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'btnExportExcel
        '
        Me.btnExportExcel.Image = CType(resources.GetObject("btnExportExcel.Image"), System.Drawing.Image)
        Me.btnExportExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExportExcel.Name = "btnExportExcel"
        Me.btnExportExcel.Size = New System.Drawing.Size(89, 22)
        Me.btnExportExcel.Text = "Export Excel"
        Me.btnExportExcel.ToolTipText = "Ctrl + E"
        '
        'btnImportExcel
        '
        Me.btnImportExcel.Image = CType(resources.GetObject("btnImportExcel.Image"), System.Drawing.Image)
        Me.btnImportExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnImportExcel.Name = "btnImportExcel"
        Me.btnImportExcel.Size = New System.Drawing.Size(92, 22)
        Me.btnImportExcel.Text = "Import Excel"
        Me.btnImportExcel.ToolTipText = "Ctrl + I"
        '
        'gcOutput
        '
        Me.gcOutput.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.gcOutput.Location = New System.Drawing.Point(0, 25)
        Me.gcOutput.MainView = Me.gvOutput
        Me.gcOutput.Name = "gcOutput"
        Me.gcOutput.Size = New System.Drawing.Size(827, 225)
        Me.gcOutput.TabIndex = 20
        Me.gcOutput.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvOutput})
        '
        'gvOutput
        '
        Me.gvOutput.ActiveFilterEnabled = False
        Me.gvOutput.GridControl = Me.gcOutput
        Me.gvOutput.Name = "gvOutput"
        Me.gvOutput.OptionsView.ShowGroupPanel = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label6.Location = New System.Drawing.Point(38, 365)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 14)
        Me.Label6.TabIndex = 27
        Me.Label6.Text = "Data Qty"
        '
        'cboDatabase
        '
        Me.cboDatabase.Location = New System.Drawing.Point(37, 64)
        Me.cboDatabase.Name = "cboDatabase"
        Me.cboDatabase.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboDatabase.Size = New System.Drawing.Size(143, 20)
        Me.cboDatabase.TabIndex = 28
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label7.Location = New System.Drawing.Point(34, 44)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 14)
        Me.Label7.TabIndex = 29
        Me.Label7.Text = "Database"
        '
        'cboTable
        '
        Me.cboTable.Location = New System.Drawing.Point(37, 117)
        Me.cboTable.Name = "cboTable"
        Me.cboTable.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboTable.Size = New System.Drawing.Size(143, 20)
        Me.cboTable.TabIndex = 30
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label8.Location = New System.Drawing.Point(34, 100)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 14)
        Me.Label8.TabIndex = 31
        Me.Label8.Text = "Table"
        '
        'btnPrepareDataset
        '
        Me.btnPrepareDataset.Location = New System.Drawing.Point(37, 147)
        Me.btnPrepareDataset.Name = "btnPrepareDataset"
        Me.btnPrepareDataset.Size = New System.Drawing.Size(143, 23)
        Me.btnPrepareDataset.TabIndex = 34
        Me.btnPrepareDataset.Text = "Prepare Dataset"
        Me.btnPrepareDataset.ToolTip = "Ctrl + Shift + P"
        '
        'btnGenerate
        '
        Me.btnGenerate.Location = New System.Drawing.Point(38, 393)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(143, 23)
        Me.btnGenerate.TabIndex = 35
        Me.btnGenerate.Text = "Generate"
        Me.btnGenerate.ToolTip = "F5"
        '
        'numQty
        '
        Me.numQty.EditValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numQty.Location = New System.Drawing.Point(116, 362)
        Me.numQty.Name = "numQty"
        Me.numQty.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.numQty.Properties.IsFloatValue = False
        Me.numQty.Properties.Mask.EditMask = "N00"
        Me.numQty.Properties.MaxValue = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.numQty.Size = New System.Drawing.Size(65, 20)
        Me.numQty.TabIndex = 37
        '
        'btnCopy
        '
        Me.btnCopy.Image = Global.DataGenerator.My.Resources.Resources.copy
        Me.btnCopy.Location = New System.Drawing.Point(38, 422)
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(143, 23)
        Me.btnCopy.TabIndex = 39
        Me.btnCopy.Text = "SQL INSERT"
        Me.btnCopy.ToolTip = "Ctrl + C"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.cboTable)
        Me.Panel4.Controls.Add(Me.btnCopy)
        Me.Panel4.Controls.Add(Me.cboDatabase)
        Me.Panel4.Controls.Add(Me.numQty)
        Me.Panel4.Controls.Add(Me.Label7)
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.Label8)
        Me.Panel4.Controls.Add(Me.btnGenerate)
        Me.Panel4.Controls.Add(Me.txtQuery)
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Controls.Add(Me.btnPrepareDataset)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1078, 667)
        Me.Panel4.TabIndex = 40
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Label3)
        Me.Panel5.Controls.Add(Me.Label1)
        Me.Panel5.Controls.Add(Me.DatasetPanel)
        Me.Panel5.Controls.Add(Me.SamplePanel)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel5.Location = New System.Drawing.Point(189, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(889, 667)
        Me.Panel5.TabIndex = 41
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(26, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 17)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "New DataSet"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Label1.Location = New System.Drawing.Point(27, 355)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 17)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Sample Data"
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1078, 667)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmMain"
        CType(Me.gc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DatasetPanel.ResumeLayout(False)
        Me.DatasetPanel.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.SamplePanel.ResumeLayout(False)
        Me.SamplePanel.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        CType(Me.gcOutput, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvOutput, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDatabase.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTable.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numQty.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtQuery As Windows.Forms.TextBox
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents gc As DevExpress.XtraGrid.GridControl
    Friend WithEvents gv As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ToolStrip1 As Windows.Forms.ToolStrip
    Friend WithEvents btnAdd As Windows.Forms.ToolStripButton
    Friend WithEvents btnCategoryDetail As Windows.Forms.ToolStripButton
    Friend WithEvents btnDelete As Windows.Forms.ToolStripButton
    Friend WithEvents SamplePanel As Windows.Forms.Panel
    Friend WithEvents gcOutput As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvOutput As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents cboDatabase As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents cboTable As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents Label8 As Windows.Forms.Label
    Friend WithEvents btnPrepareDataset As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnGenerate As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents numQty As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents btnLoadSetting As Windows.Forms.ToolStripButton
    Friend WithEvents btnSaveSetting As Windows.Forms.ToolStripButton
    Friend WithEvents btnClear As Windows.Forms.ToolStripButton
    Friend WithEvents btnCopy As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Panel4 As Windows.Forms.Panel
    Friend WithEvents Panel5 As Windows.Forms.Panel
    Friend WithEvents DatasetPanel As Windows.Forms.Panel
    Friend WithEvents Panel2 As Windows.Forms.Panel
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents ToolStrip2 As Windows.Forms.ToolStrip
    Friend WithEvents btnExportExcel As Windows.Forms.ToolStripButton
    Friend WithEvents btnImportExcel As Windows.Forms.ToolStripButton
End Class

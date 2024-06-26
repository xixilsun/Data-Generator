﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.gc = New DevExpress.XtraGrid.GridControl()
        Me.gv = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnAdd = New System.Windows.Forms.ToolStripButton()
        Me.btnDelete = New System.Windows.Forms.ToolStripButton()
        Me.btnCategoryDetail = New System.Windows.Forms.ToolStripButton()
        Me.btnClear = New System.Windows.Forms.ToolStripButton()
        Me.btnExport = New System.Windows.Forms.ToolStripButton()
        Me.btnImport = New System.Windows.Forms.ToolStripButton()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.gcOutput = New DevExpress.XtraGrid.GridControl()
        Me.gvOutput = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboDatabase = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboTable = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnPrepareDataset = New DevExpress.XtraEditors.SimpleButton()
        Me.btnGenerate = New DevExpress.XtraEditors.SimpleButton()
        Me.numQty = New DevExpress.XtraEditors.SpinEdit()
        Me.btnCopy = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.gc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.gcOutput, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvOutput, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDatabase.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTable.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numQty.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtQuery
        '
        Me.txtQuery.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQuery.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQuery.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtQuery.Location = New System.Drawing.Point(38, 564)
        Me.txtQuery.Margin = New System.Windows.Forms.Padding(10)
        Me.txtQuery.Multiline = True
        Me.txtQuery.Name = "txtQuery"
        Me.txtQuery.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtQuery.Size = New System.Drawing.Size(164, 84)
        Me.txtQuery.TabIndex = 11
        Me.txtQuery.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label2.Location = New System.Drawing.Point(211, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 14)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "New DataSet"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label4.Location = New System.Drawing.Point(35, 540)
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
        Me.gc.Size = New System.Drawing.Size(827, 260)
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
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.ToolStrip1)
        Me.Panel1.Location = New System.Drawing.Point(214, 43)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(827, 285)
        Me.Panel1.TabIndex = 21
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.gc)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 25)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(827, 260)
        Me.Panel2.TabIndex = 22
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAdd, Me.btnDelete, Me.btnCategoryDetail, Me.btnClear, Me.btnExport, Me.btnImport})
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
        'btnExport
        '
        Me.btnExport.Image = Global.DataGenerator.My.Resources.Resources.Export
        Me.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(100, 22)
        Me.btnExport.Text = "Export Setting"
        '
        'btnImport
        '
        Me.btnImport.Image = Global.DataGenerator.My.Resources.Resources.Import
        Me.btnImport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(103, 22)
        Me.btnImport.Text = "Import Setting"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.gcOutput)
        Me.Panel3.Location = New System.Drawing.Point(214, 393)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(827, 255)
        Me.Panel3.TabIndex = 23
        '
        'gcOutput
        '
        Me.gcOutput.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gcOutput.Location = New System.Drawing.Point(0, 0)
        Me.gcOutput.MainView = Me.gvOutput
        Me.gcOutput.Name = "gcOutput"
        Me.gcOutput.Size = New System.Drawing.Size(827, 255)
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
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label5.Location = New System.Drawing.Point(211, 376)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 14)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "Sample Data"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Location = New System.Drawing.Point(705, 335)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(330, 14)
        Me.Label9.TabIndex = 36
        Me.Label9.Text = "If column has reference, leave blank for category and subcategory"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label6.Location = New System.Drawing.Point(38, 398)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 14)
        Me.Label6.TabIndex = 27
        Me.Label6.Text = "Data Qty"
        '
        'cboDatabase
        '
        Me.cboDatabase.Location = New System.Drawing.Point(38, 64)
        Me.cboDatabase.Name = "cboDatabase"
        Me.cboDatabase.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboDatabase.Size = New System.Drawing.Size(143, 20)
        Me.cboDatabase.TabIndex = 28
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label7.Location = New System.Drawing.Point(35, 44)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 14)
        Me.Label7.TabIndex = 29
        Me.Label7.Text = "Database"
        '
        'cboTable
        '
        Me.cboTable.Location = New System.Drawing.Point(38, 117)
        Me.cboTable.Name = "cboTable"
        Me.cboTable.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboTable.Size = New System.Drawing.Size(143, 20)
        Me.cboTable.TabIndex = 30
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label8.Location = New System.Drawing.Point(35, 98)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 14)
        Me.Label8.TabIndex = 31
        Me.Label8.Text = "Table"
        '
        'btnPrepareDataset
        '
        Me.btnPrepareDataset.Location = New System.Drawing.Point(38, 147)
        Me.btnPrepareDataset.Name = "btnPrepareDataset"
        Me.btnPrepareDataset.Size = New System.Drawing.Size(143, 23)
        Me.btnPrepareDataset.TabIndex = 34
        Me.btnPrepareDataset.Text = "Prepare Dataset"
        '
        'btnGenerate
        '
        Me.btnGenerate.Location = New System.Drawing.Point(38, 426)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(143, 23)
        Me.btnGenerate.TabIndex = 35
        Me.btnGenerate.Text = "Generate"
        '
        'numQty
        '
        Me.numQty.EditValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numQty.Location = New System.Drawing.Point(116, 395)
        Me.numQty.Name = "numQty"
        Me.numQty.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.numQty.Properties.IsFloatValue = False
        Me.numQty.Properties.Mask.EditMask = "N00"
        Me.numQty.Properties.MaxValue = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.numQty.Properties.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numQty.Size = New System.Drawing.Size(65, 20)
        Me.numQty.TabIndex = 37
        '
        'btnCopy
        '
        Me.btnCopy.Image = Global.DataGenerator.My.Resources.Resources.copy
        Me.btnCopy.Location = New System.Drawing.Point(38, 455)
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(143, 23)
        Me.btnCopy.TabIndex = 39
        Me.btnCopy.Text = "SQL INSERT"
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1066, 667)
        Me.Controls.Add(Me.btnCopy)
        Me.Controls.Add(Me.numQty)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.btnGenerate)
        Me.Controls.Add(Me.btnPrepareDataset)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cboTable)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cboDatabase)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtQuery)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmMain"
        CType(Me.gc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        CType(Me.gcOutput, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvOutput, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDatabase.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTable.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numQty.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtQuery As Windows.Forms.TextBox
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents gc As DevExpress.XtraGrid.GridControl
    Friend WithEvents gv As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents ToolStrip1 As Windows.Forms.ToolStrip
    Friend WithEvents Panel2 As Windows.Forms.Panel
    Friend WithEvents btnAdd As Windows.Forms.ToolStripButton
    Friend WithEvents btnCategoryDetail As Windows.Forms.ToolStripButton
    Friend WithEvents btnDelete As Windows.Forms.ToolStripButton
    Friend WithEvents Panel3 As Windows.Forms.Panel
    Friend WithEvents gcOutput As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvOutput As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents Label9 As Windows.Forms.Label
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents cboDatabase As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents cboTable As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents Label8 As Windows.Forms.Label
    Friend WithEvents btnPrepareDataset As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnGenerate As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents numQty As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents btnImport As Windows.Forms.ToolStripButton
    Friend WithEvents btnExport As Windows.Forms.ToolStripButton
    Friend WithEvents btnClear As Windows.Forms.ToolStripButton
    Friend WithEvents btnCopy As DevExpress.XtraEditors.SimpleButton
End Class

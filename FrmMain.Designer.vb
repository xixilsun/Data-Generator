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
        Me.btnOneData = New System.Windows.Forms.Button()
        Me.txtQuery = New System.Windows.Forms.TextBox()
        Me.cboCategory = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboSubcategory = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnGenerateOneData = New System.Windows.Forms.Button()
        Me.gc = New DevExpress.XtraGrid.GridControl()
        Me.gv = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnAdd = New System.Windows.Forms.ToolStripButton()
        Me.btnDelete = New System.Windows.Forms.ToolStripButton()
        Me.btnCategoryDetail = New System.Windows.Forms.ToolStripButton()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.gcOutput = New DevExpress.XtraGrid.GridControl()
        Me.gvOutput = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.numQty = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboDatabase = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboTable = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.btnPrepareDataset = New DevExpress.XtraEditors.SimpleButton()
        Me.btnGenerate = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.gc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.gcOutput, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvOutput, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numQty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDatabase.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTable.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOneData
        '
        Me.btnOneData.Location = New System.Drawing.Point(633, 475)
        Me.btnOneData.Name = "btnOneData"
        Me.btnOneData.Size = New System.Drawing.Size(143, 28)
        Me.btnOneData.TabIndex = 0
        Me.btnOneData.Text = "Sample"
        Me.btnOneData.UseVisualStyleBackColor = True
        '
        'txtQuery
        '
        Me.txtQuery.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQuery.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQuery.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtQuery.Location = New System.Drawing.Point(19, 412)
        Me.txtQuery.Margin = New System.Windows.Forms.Padding(10)
        Me.txtQuery.Multiline = True
        Me.txtQuery.Name = "txtQuery"
        Me.txtQuery.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtQuery.Size = New System.Drawing.Size(601, 125)
        Me.txtQuery.TabIndex = 11
        '
        'cboCategory
        '
        Me.cboCategory.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.cboCategory.FormattingEnabled = True
        Me.cboCategory.Items.AddRange(New Object() {"Address", "Commerce", "Company", "Database", "Date", "Finance", "Hacker", "Images", "Internet", "Lorem", "Name", "Phone", "Rant", "System", "Vehicle", "Random"})
        Me.cboCategory.Location = New System.Drawing.Point(633, 388)
        Me.cboCategory.Name = "cboCategory"
        Me.cboCategory.Size = New System.Drawing.Size(143, 22)
        Me.cboCategory.TabIndex = 12
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label3.Location = New System.Drawing.Point(630, 371)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 14)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "DataType"
        '
        'cboSubcategory
        '
        Me.cboSubcategory.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.cboSubcategory.FormattingEnabled = True
        Me.cboSubcategory.Items.AddRange(New Object() {"FullName", "FirstName", "LastName"})
        Me.cboSubcategory.Location = New System.Drawing.Point(633, 440)
        Me.cboSubcategory.Name = "cboSubcategory"
        Me.cboSubcategory.Size = New System.Drawing.Size(143, 22)
        Me.cboSubcategory.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label1.Location = New System.Drawing.Point(630, 423)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 14)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Options"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label2.Location = New System.Drawing.Point(16, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 14)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "New DataSet"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label4.Location = New System.Drawing.Point(16, 395)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 14)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Result"
        '
        'btnGenerateOneData
        '
        Me.btnGenerateOneData.Location = New System.Drawing.Point(633, 509)
        Me.btnGenerateOneData.Name = "btnGenerateOneData"
        Me.btnGenerateOneData.Size = New System.Drawing.Size(143, 28)
        Me.btnGenerateOneData.TabIndex = 19
        Me.btnGenerateOneData.Text = "Generate One"
        Me.btnGenerateOneData.UseVisualStyleBackColor = True
        '
        'gc
        '
        Me.gc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gc.Location = New System.Drawing.Point(0, 0)
        Me.gc.MainView = Me.gv
        Me.gc.Name = "gc"
        Me.gc.Size = New System.Drawing.Size(585, 151)
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
        Me.Panel1.Location = New System.Drawing.Point(19, 43)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(585, 176)
        Me.Panel1.TabIndex = 21
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.gc)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 25)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(585, 151)
        Me.Panel2.TabIndex = 22
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAdd, Me.btnDelete, Me.btnCategoryDetail})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(585, 25)
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
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.gcOutput)
        Me.Panel3.Location = New System.Drawing.Point(19, 261)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(585, 109)
        Me.Panel3.TabIndex = 23
        '
        'gcOutput
        '
        Me.gcOutput.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gcOutput.Location = New System.Drawing.Point(0, 0)
        Me.gcOutput.MainView = Me.gvOutput
        Me.gcOutput.Name = "gcOutput"
        Me.gcOutput.Size = New System.Drawing.Size(585, 109)
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
        Me.Label5.Location = New System.Drawing.Point(16, 244)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 14)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "Sample Data"
        '
        'numQty
        '
        Me.numQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.numQty.Font = New System.Drawing.Font("Arial", 8.5!)
        Me.numQty.Location = New System.Drawing.Point(717, 260)
        Me.numQty.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.numQty.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numQty.Name = "numQty"
        Me.numQty.Size = New System.Drawing.Size(59, 21)
        Me.numQty.TabIndex = 26
        Me.numQty.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label6.Location = New System.Drawing.Point(633, 262)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 14)
        Me.Label6.TabIndex = 27
        Me.Label6.Text = "Data Qty"
        '
        'cboDatabase
        '
        Me.cboDatabase.Location = New System.Drawing.Point(633, 62)
        Me.cboDatabase.Name = "cboDatabase"
        Me.cboDatabase.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboDatabase.Size = New System.Drawing.Size(143, 20)
        Me.cboDatabase.TabIndex = 28
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label7.Location = New System.Drawing.Point(630, 42)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 14)
        Me.Label7.TabIndex = 29
        Me.Label7.Text = "Database"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label8.Location = New System.Drawing.Point(630, 96)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 14)
        Me.Label8.TabIndex = 31
        Me.Label8.Text = "Table"
        '
        'cboTable
        '
        Me.cboTable.Location = New System.Drawing.Point(633, 115)
        Me.cboTable.Name = "cboTable"
        Me.cboTable.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboTable.Size = New System.Drawing.Size(143, 20)
        Me.cboTable.TabIndex = 30
        '
        'btnPrepareDataset
        '
        Me.btnPrepareDataset.Location = New System.Drawing.Point(633, 145)
        Me.btnPrepareDataset.Name = "btnPrepareDataset"
        Me.btnPrepareDataset.Size = New System.Drawing.Size(143, 23)
        Me.btnPrepareDataset.TabIndex = 34
        Me.btnPrepareDataset.Text = "Prepare Dataset"
        '
        'btnGenerate
        '
        Me.btnGenerate.Location = New System.Drawing.Point(633, 290)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(143, 23)
        Me.btnGenerate.TabIndex = 35
        Me.btnGenerate.Text = "Generate"
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 556)
        Me.Controls.Add(Me.btnGenerate)
        Me.Controls.Add(Me.btnPrepareDataset)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cboTable)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cboDatabase)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.numQty)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnGenerateOneData)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboSubcategory)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboCategory)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtQuery)
        Me.Controls.Add(Me.btnOneData)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmMain"
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
        CType(Me.numQty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDatabase.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTable.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnOneData As Windows.Forms.Button
    Friend WithEvents txtQuery As Windows.Forms.TextBox
    Friend WithEvents cboCategory As Windows.Forms.ComboBox
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents cboSubcategory As Windows.Forms.ComboBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents btnGenerateOneData As Windows.Forms.Button
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
    Friend WithEvents numQty As Windows.Forms.NumericUpDown
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents cboDatabase As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents Label8 As Windows.Forms.Label
    Friend WithEvents cboTable As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents btnPrepareDataset As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnGenerate As DevExpress.XtraEditors.SimpleButton
End Class

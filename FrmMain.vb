Imports System.Data
Imports System.Linq
Imports System.Text
Imports Bogus
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraReports.Parameters
Imports DataGenerator.My

Public Class FrmMain
    Private dtDataSet As New DataTable("Dataset")
    Private SelectedDatabase As String = ""
    Private SelectedTable As String = ""
    Private BogusDt As New DataTable
    Private AllCategoryList As List(Of String)
    Private AllSubcategoryList As List(Of String)
    Private FirstLoad As Boolean = True


    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Add Handler
        AddHandler cboDatabase.SelectedIndexChanged, AddressOf OnDBSelectedIndexChanged

        'Set validaterow when edit
        'AddHandler gv.ValidateRow, AddressOf OnValidateRow

        AddHandler btnGenerate.Click, AddressOf ProcessGenerateData
        AddHandler btnPrepareDataset.Click, AddressOf PrepareDataset

        'Supress asking edit data?
        AddHandler gv.InvalidRowException, AddressOf OnInvalidRowException

        BogusDt = BogusDatatable()
        'Add default All Category & Subcategory List
        AllCategoryList = BogusDt.AsEnumerable().Select(Function(o) o("Category").ToString).Distinct().ToList
        AllSubcategoryList = BogusDt.AsEnumerable().Select(Function(o) o("Subcategory").ToString).ToList

        Me.KeyPreview = True

        'Prepare Default GridView
        PrepareGridView()

        'Set Default value for Category & Subcategory
        Dim CategoryCombo As RepositoryItemComboBox = CType(gv.Columns("Category").ColumnEdit, RepositoryItemComboBox)
        Dim SubcategoryCombo As RepositoryItemComboBox = CType(gv.Columns("Subcategory").ColumnEdit, RepositoryItemComboBox)

        'Add event handler for category column value change
        'AddHandler CategoryCombo.EditValueChanged, AddressOf OnCategoryChanged
        AddHandler SubcategoryCombo.EditValueChanged, AddressOf OnSubcategoryChanged

        'Add Handler if has category then set subcategory list
        'AddHandler gv.CustomRowCellEditForEditing, AddressOf OnGridViewCustomRowCellEditForEditing

        'Prepare database
        Dim DatabaseList = ModSQL.GetDataTable("SELECT name AS DatabaseName FROM Sysdatabases WHERE name LIKE 'HRdb%'", ModSQL.GetConnectionString("Master")).AsEnumerable.Select(Function(o) o("DatabaseName")).ToList()
        With cboDatabase
            .Properties.Items.AddRange(DatabaseList)
            .SelectedItem = My.Settings.DefaultDatabase
        End With

        FirstLoad = False
    End Sub


    Private Sub OnGridViewCustomRowCellEditForEditing(sender As Object, e As CustomRowCellEditEventArgs)
        Dim View As GridView = CType(sender, GridView)
        Dim RowHandle As Integer = e.RowHandle

        'Get the current category for the row
        Dim CurrentCategory As String = View.GetRowCellValue(RowHandle, "Category").ToString
        Dim CurrentSubcategory As String = View.GetRowCellValue(RowHandle, "Subcategory").ToString

        If e.Column.FieldName = "Subcategory" AndAlso CurrentCategory <> "" Then
            'Create a new RepositoryItemComboBox For the subcategory
            Dim SubcategoryCombo As New RepositoryItemComboBox


            'Populate subcategory
            Dim SubcategoryList As List(Of String) = BogusDt.AsEnumerable().Where(Function(o) o("Category") = CurrentCategory).Select(Function(o) o("Subcategory").ToString).ToList
            SubcategoryCombo.Items.AddRange(SubcategoryList)
            e.RepositoryItem = SubcategoryCombo
        End If
    End Sub

    Private Sub PrepareDataset(sender As Object, e As EventArgs)
        If SelectedDatabase = cboDatabase.SelectedItem AndAlso SelectedTable = cboTable.SelectedItem Then
            If MsgBox("Prepare Dataset?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.No Then Exit Sub
        End If
        SelectedDatabase = cboDatabase.SelectedItem
        SelectedTable = cboTable.SelectedItem
        Dim Sql = "SELECT COLUMN_NAME AS ColumnName, S.is_identity As IsIdentity, S.is_nullable As IsNullable, DATA_TYPE As DataType, CHARACTER_MAXIMUM_LENGTH As MaxLength, " & vbCrLf &
                  "Ref.ParentTable, Ref.ParentID, Ref.ForeignKeyName, Ref.ReferenceTable, Ref.ReferenceColumnName, " & vbCrLf &
                  "CASE WHEN Ref.ReferenceTable IS NOT NULL Then 1 ELSE 0 END AS HasReference" & vbCrLf &
                  "FROM INFORMATION_SCHEMA.COLUMNS C" & vbCrLf &
                  "INNER JOIN sys.Columns S ON C.COLUMN_NAME = S.name" & vbCrLf &
                  "LEFT JOIN " & vbCrLf &
                  "(" & vbCrLf &
                  "	SELECT " & vbCrLf &
                  "    t.name AS ParentTable," & vbCrLf &
                  "    COL_NAME(fc.referenced_object_id, fc.referenced_column_id) AS ParentID," & vbCrLf &
                  "    f.name AS ForeignKeyName," & vbCrLf &
                  "    OBJECT_NAME(f.parent_object_id) AS ReferenceTable," & vbCrLf &
                  "    COL_NAME(fc.parent_object_id, fc.parent_column_id) AS ReferenceColumnName" & vbCrLf &
                  "FROM " & vbCrLf &
                  "    sys.foreign_keys AS f " & vbCrLf &
                  "INNER JOIN " & vbCrLf &
                  "    sys.foreign_key_columns AS fc ON f.OBJECT_ID = fc.constraint_object_id" & vbCrLf &
                  "INNER JOIN " & vbCrLf &
                  "    sys.tables t ON t.OBJECT_ID = fc.referenced_object_id" & vbCrLf &
                  "WHERE " & vbCrLf &
                  "	OBJECT_NAME(f.parent_object_id) = 'Denda'" & vbCrLf &
                  ") REF ON Ref.ReferenceTable = C.TABLE_NAME AND Ref.ReferenceColumnName = C.COLUMN_NAME" & vbCrLf &
                  "WHERE TABLE_NAME = " & SqlStr(SelectedTable) & " AND S.object_id = object_id(" & SqlStr(SelectedTable) & ")"
        Dim Dt As DataTable = GetDataTable(Sql, GetConnectionString(SelectedDatabase))
        dtDataSet.Rows.Clear()

        For Each row In Dt.Rows
            'If identity no need to generate id column
            If row!IsIdentity Then Continue For

            'Set default category & subcategory
            Dim DefaultCategory As String = ""
            Dim DefaultSubcategory As String = ""
            If Not Convert.ToBoolean(row!HasReference) Then
                If row!IsNullable Then
                    DefaultCategory = "Default"
                    DefaultSubcategory = "Null"
                ElseIf row!DataType = "text" Then
                    DefaultCategory = "Lorem"
                    DefaultSubcategory = "Paragraph"
                ElseIf row!DataType = "varchar" AndAlso row!ColumnName.ToString.Contains("user") Then
                    DefaultCategory = "Internet"
                    DefaultSubcategory = "UserName"
                ElseIf row!DataType = "datetime" AndAlso row!ColumnName.ToString.Contains("update") Then
                    DefaultCategory = "Date"
                    DefaultSubcategory = "Past"
                ElseIf row!DataType = "bit" Then
                    DefaultCategory = "Random"
                    DefaultSubcategory = "Bool"
                ElseIf row!DataType.ToString.Contains("varchar") Then
                    DefaultCategory = "Lorem"
                    DefaultSubcategory = "Word"
                ElseIf row!DataType = "money" Then
                    DefaultCategory = "Finance"
                    DefaultSubcategory = "Amount"
                ElseIf row!DataType.ToString.Contains("date") Then
                    DefaultCategory = "Date"
                    DefaultSubcategory = "Between"
                ElseIf row!DataType.ToString.Contains("int") OrElse row!DataType = "numeric" Then
                    DefaultCategory = "Random"
                    DefaultSubcategory = "Number"
                ElseIf row!DataType = "char" Then
                    DefaultCategory = "Random"
                    DefaultSubcategory = "Char"
                End If

            End If
            'Max Length
            Dim Max As String = "-"
            If Not IsDBNull(row!MaxLength) AndAlso row!DataType <> "text" Then Max = row!MaxLength


            dtDataSet.Rows.Add(row!ColumnName, DefaultCategory, DefaultSubcategory, "", "", "", Max,
                               row!HasReference, "", If(row!HasReference, SelectedDatabase, ""), row!ParentTable, row!ParentID, "")
        Next

        'Add Handler
        'Dim SubcategoryCombo As RepositoryItemComboBox = CType(gv.Columns("Subcategory").ColumnEdit, RepositoryItemComboBox)
        'AddHandler SubcategoryCombo.EditValueChanged, AddressOf OnSubcategoryChanged
    End Sub

    Private Sub OnDBSelectedIndexChanged(sender As Object, e As EventArgs)
        Dim cboDB = TryCast(sender, ComboBoxEdit)
        If cboDB.SelectedIndex <> -1 Then
            Dim DatabaseName = cboDatabase.SelectedItem.ToString
            Dim Sql = "SELECT TABLE_NAME AS TableName" & vbCrLf &
                      "FROM INFORMATION_SCHEMA.TABLES" & vbCrLf &
                      "WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_CATALOG = " & SqlStr(DatabaseName) & vbCrLf &
                      "ORDER BY TableName"

            Dim TableList = ModSQL.GetDataTable(Sql, GetConnectionString(DatabaseName)).AsEnumerable.Select(Function(o) o("TableName")).ToList()
            With cboTable
                .Properties.Items.Clear()
                .Properties.Items.AddRange(TableList)
                .SelectedIndex = 0
            End With

            If FirstLoad Then SetSelectedItem(cboTable, My.Settings.DefaultTable)
        End If
    End Sub

    Private Sub SetSelectedItem(cboTable As ComboBoxEdit, selectedItem As String)
        For Each item In cboTable.Properties.Items
            If String.Equals(item.ToString(), selectedItem, StringComparison.OrdinalIgnoreCase) Then
                cboTable.SelectedItem = item.ToString
            End If
        Next
    End Sub

    Private Sub OnInvalidRowException(sender As Object, e As InvalidRowExceptionEventArgs)
        e.ExceptionMode = ExceptionMode.NoAction
    End Sub

    Private Sub ProcessGenerateData(sender As Object, e As EventArgs)
        Try
            'Reset Copy SQL Insert
            btnCopy.Image = Resources.copy

            'Trigger Validation before generate data
            If Not ValidateGenerate() Then Exit Sub
            Dim dtOutput As New DataTable
            Dim AllColumns As String = ""
            Dim col As New List(Of String)
            Dim RowData As String = ""

            For Each row In dtDataSet.Rows
                dtOutput.Columns.Add(row!ColumnName, System.Type.GetType("System.String"))
                AllColumns &= If(AllColumns = "", "", ", ") & row!ColumnName
                col.Add(row!ColumnName)
            Next

            'Set Progress Bar
            Dim frm = New FrmSyMsg
            frm.ActiveAnimation = True
            frm.Show("Start generating data")
            frm.ReSetProgressBar(numQty.Value)
            For i As Integer = 0 To numQty.Value - 1
                Dim paramList As New List(Of String)
                Dim RowHandle As Integer = 0
                frm.SetCount("Data - " & i + 1 & " / " & numQty.Value & vbCrLf & "Generating Data...")
                frm.SetProgressBar()

                For Each Row In dtDataSet.Rows
                    Dim maxLength As Integer = 9999999
                    If Row!MaxLength <> "-" Then maxLength = Convert.ToInt32(Row!MaxLength)

                    Dim RandomResult As String = ""
                    If Not Row!HasReference Then
                        RandomResult = GenerateFakeData(Row!Category, Row!Subcategory, Row!Parameter.ToString, Row!UserDefined.ToString, maxLength)
                    Else
                        RandomResult = GenerateDataFromReference(Row!ParentDatabase.ToString, Row!ParentTable.ToString, Row!ParentID.ToString, Row!Query.ToString, maxLength)
                    End If

                    'If Empty
                    If RandomResult = "" AndAlso Row!Subcategory <> "Empty" Then
                        If Row!HasReference Then
                            gv.FocusedRowHandle = RowHandle
                            gv.SetColumnError(gv.Columns("MaxLength"), "Reference MaxLength is longer than current MaxLength.", DXErrorProvider.ErrorType.Critical)
                        Else
                            gv.FocusedRowHandle = RowHandle
                            MsgBox("Please check setting for Column Name : " & Row!ColumnName, MsgBoxStyle.Critical)
                            OnSettingButtonClick(Nothing, Nothing)
                        End If
                        Exit Sub
                    End If
                    paramList.Add(RandomResult)
                    RowHandle += 1
                Next
                dtOutput.Rows.Add(paramList.ToArray)
            Next

            'Close Progress bar
            frm.Close()
            frm = Nothing

            gcOutput.DataSource = Nothing
            gcOutput.DataSource = dtOutput

            gcOutput.MainView.PopulateColumns()
            gcOutput.MainView.RefreshData()

            gvOutput.OptionsView.ColumnAutoWidth = False
            gvOutput.HorzScrollVisibility = ScrollVisibility.Always
            gvOutput.BestFitColumns()

            Dim Query As String = $"INSERT INTO {If(SelectedTable = "", "MyTable", SelectedTable)} ({AllColumns}) VALUES"
            Dim Count As Integer = 1
            For Each row In dtOutput.Rows
                Dim dataQuery As String = ""
                For Each column As DataColumn In dtOutput.Columns
                    dataQuery &= If(dataQuery = "", "", ", ") & If(row(column) = "NULL" OrElse row(column) = "GETDATE()", row(column), $"'{row(column)}'")
                Next
                Query &= vbCrLf & $"({dataQuery})" & If(dtOutput.Rows.Count = Count, ";", ",")
                Count += 1
            Next
            txtQuery.Text = Query
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub



    Private Function ValidateGenerate() As Boolean
        For i As Integer = 0 To gv.RowCount - 1
            If Not ValidateRow(i) Then
                Return False
            End If
        Next
        Return True
    End Function

    Private Function ValidateRow(rowHandle As Integer) As Boolean
        Dim View As GridView = gv
        View.FocusedRowHandle = rowHandle
        Dim ColumnName As String = If(View.GetRowCellValue(rowHandle, "ColumnName")?.ToString, String.Empty)
        Dim Category As String = If(View.GetRowCellValue(rowHandle, "Category")?.ToString, String.Empty)
        Dim Subcategory As String = If(View.GetRowCellValue(rowHandle, "Subcategory")?.ToString, String.Empty)
        Dim HasReference As Boolean = View.GetRowCellValue(rowHandle, "HasReference")
        Dim ParentDatabase As String = If(View.GetRowCellValue(rowHandle, "ParentDatabase")?.ToString, String.Empty)
        Dim ParentTable As String = If(View.GetRowCellValue(rowHandle, "ParentTable")?.ToString, String.Empty)
        Dim ParentID As String = If(View.GetRowCellValue(rowHandle, "ParentID")?.ToString, String.Empty)

        If HasReference AndAlso Not String.IsNullOrWhiteSpace(Category) AndAlso Not String.IsNullOrWhiteSpace(Subcategory) Then
            View.SetRowCellValue(rowHandle, "Category", String.Empty)
            View.SetRowCellValue(rowHandle, "Subcategory", String.Empty)
        End If

        If String.IsNullOrWhiteSpace(ColumnName) Then
            MsgBox("ColumnName must not be empty.", MsgBoxStyle.Critical)
            View.SetColumnError(View.Columns("ColumnName"), "ColumnName must not be empty.", DXErrorProvider.ErrorType.Critical)
            Return False
        ElseIf Not HasReference AndAlso String.IsNullOrWhiteSpace(Category) Then
            MsgBox("Category must not be empty.", MsgBoxStyle.Critical)
            View.SetColumnError(View.Columns("Category"), "Category must not be empty.", DXErrorProvider.ErrorType.Critical)
            Return False
        ElseIf Not HasReference AndAlso String.IsNullOrWhiteSpace(Subcategory) Then
            MsgBox("Subcategory must not be empty.", MsgBoxStyle.Critical)
            View.SetColumnError(View.Columns("Subcategory"), "Subcategory must not be empty.", DXErrorProvider.ErrorType.Critical)
            Return False
        Else
            View.ClearColumnErrors()
            Return True
        End If
    End Function

    Private Sub CommitNewRow()
        gv.UpdateCurrentRow()

        gv.CloseEditor()
        gv.UpdateCurrentRow()
        gv.RefreshData()
    End Sub

    Private Sub PrepareGridView()
        dtDataSet.Columns.Add("ColumnName", System.Type.GetType("System.String"))
        dtDataSet.Columns.Add("Category", System.Type.GetType("System.String"))
        dtDataSet.Columns.Add("Subcategory", System.Type.GetType("System.String"))
        dtDataSet.Columns.Add("Setting", System.Type.GetType("System.String"))
        dtDataSet.Columns.Add("Parameter", System.Type.GetType("System.String"))
        dtDataSet.Columns.Add("UserDefined", System.Type.GetType("System.String"))
        dtDataSet.Columns.Add("MaxLength", System.Type.GetType("System.String"))
        dtDataSet.Columns.Add("HasReference", System.Type.GetType("System.Boolean"))
        dtDataSet.Columns.Add("Ref", System.Type.GetType("System.String"))
        dtDataSet.Columns.Add("ParentDatabase", System.Type.GetType("System.String"))
        dtDataSet.Columns.Add("ParentTable", System.Type.GetType("System.String"))
        dtDataSet.Columns.Add("ParentID", System.Type.GetType("System.String"))
        dtDataSet.Columns.Add("Query", System.Type.GetType("System.String"))
        dtDataSet.Columns("MaxLength").DefaultValue = "-"
        dtDataSet.Columns("HasReference").DefaultValue = False

        gc.DataSource = dtDataSet

        'Set GridView 
        SetGridView()

        dtDataSet.Rows.Add(dtDataSet.NewRow())
    End Sub

    Private Sub SetGridView()
        'Hide
        gv.Columns("Category").Visible = False
        gv.Columns("Parameter").Visible = False
        gv.Columns("UserDefined").Visible = False
        gv.Columns("ParentDatabase").Visible = False
        gv.Columns("ParentTable").Visible = False
        gv.Columns("ParentID").Visible = False
        gv.Columns("Query").Visible = False

        gv.Columns("Ref").Width = 30
        gv.Columns("Setting").Width = 30
        gv.Columns("HasReference").Width = 50
        gv.Columns("HasReference").OptionsColumn.AllowEdit = False
        'Call method to setup dropdowns
        SetupDropdownColumns()

        Dim btnSetting As New RepositoryItemButtonEdit
        btnSetting.Buttons(0).Caption = "Setting Parameter"
        btnSetting.TextEditStyle = TextEditStyles.HideTextEditor

        Dim btnReference As New RepositoryItemButtonEdit
        btnReference.Buttons(0).Caption = "Reference"
        btnReference.TextEditStyle = TextEditStyles.HideTextEditor

        'Add buttonclick event
        AddHandler btnSetting.ButtonClick, AddressOf OnSettingButtonClick
        AddHandler btnReference.ButtonClick, AddressOf OnReferenceButtonClick

        'Set as Button
        gv.Columns("Setting").ColumnEdit = btnSetting
        gv.Columns("Ref").ColumnEdit = btnReference
    End Sub

    Private Sub OnSettingButtonClick(sender As Object, e As ButtonPressedEventArgs)
        Dim Frm As New FrmSettingParameter
        Dim RowHandle As Integer = gv.FocusedRowHandle
        Frm.ColumnName = gv.GetRowCellValue(RowHandle, "ColumnName").ToString
        Frm.Category = gv.GetRowCellValue(RowHandle, "Category").ToString
        Frm.Subcategory = gv.GetRowCellValue(RowHandle, "Subcategory").ToString
        Frm.MaxLength = gv.GetRowCellValue(RowHandle, "MaxLength").ToString
        Frm.Parameter = gv.GetRowCellValue(RowHandle, "Parameter").ToString
        Frm.UserDefined = gv.GetRowCellValue(RowHandle, "UserDefined").ToString
        Frm.CategoryList = AllCategoryList
        Frm.SubcategoryList = AllSubcategoryList

        Frm.ShowDialog()
        If Frm.IsOK Then
            gv.SetRowCellValue(RowHandle, "ColumnName", Frm.ColumnName)
            gv.SetRowCellValue(RowHandle, "Category", Frm.Category)
            gv.SetRowCellValue(RowHandle, "Subcategory", Frm.Subcategory)
            gv.SetRowCellValue(RowHandle, "MaxLength", Frm.MaxLength)
            gv.SetRowCellValue(RowHandle, "Parameter", Frm.Parameter)
            gv.SetRowCellValue(RowHandle, "UserDefined", Frm.UserDefined)
        End If
    End Sub

    Private Sub OnReferenceButtonClick(sender As Object, e As ButtonPressedEventArgs)
        Dim Frm As New FrmReferenceDetail
        Dim RowHandle As Integer = gv.FocusedRowHandle
        Frm.ColumnName = gv.GetRowCellValue(RowHandle, "ColumnName").ToString
        Frm.HasReference = CType(gv.GetRowCellValue(RowHandle, "HasReference"), Boolean)
        Frm.ParentDatabase = gv.GetRowCellValue(RowHandle, "ParentDatabase").ToString
        Frm.ParentTable = gv.GetRowCellValue(RowHandle, "ParentTable").ToString
        Frm.ParentID = gv.GetRowCellValue(RowHandle, "ParentID").ToString
        Frm.Query = gv.GetRowCellValue(RowHandle, "Query").ToString
        Frm.ShowDialog()
        If Frm.IsOK Then
            gv.SetRowCellValue(RowHandle, "HasReference", Frm.HasReference)
            If Frm.HasReference Then
                gv.SetRowCellValue(RowHandle, "ParentDatabase", Frm.ParentDatabase)
                gv.SetRowCellValue(RowHandle, "ParentTable", Frm.ParentTable)
                gv.SetRowCellValue(RowHandle, "ParentID", Frm.ParentID)
                gv.SetRowCellValue(RowHandle, "Query", Frm.Query)
            Else
                gv.SetRowCellValue(RowHandle, "ParentDatabase", String.Empty)
                gv.SetRowCellValue(RowHandle, "ParentTable", String.Empty)
                gv.SetRowCellValue(RowHandle, "ParentID", String.Empty)
                gv.SetRowCellValue(RowHandle, "Query", String.Empty)
            End If
        End If
    End Sub

    Private Sub SetupDropdownColumns()
        'Create RepositoryItemComboBox for Category Column
        Dim CategoryCombo As New RepositoryItemComboBox()
        Dim CategoryList As List(Of String) = AllCategoryList
        CategoryCombo.Items.AddRange(CategoryList)

        'Assign RepositoryItemComboBox to GridView Column
        gv.Columns("Category").ColumnEdit = CategoryCombo

        'Create RepositoryItemComboBox for Subcategory Column
        Dim SubcategoryCombo As New RepositoryItemComboBox()
        Dim SubcategoryList As List(Of String) = AllSubcategoryList

        SubcategoryCombo.Items.AddRange(SubcategoryList)
        gv.Columns("Subcategory").ColumnEdit = SubcategoryCombo
    End Sub

    Private Sub OnCategoryChanged(sender As Object, e As EventArgs)
        'Get the current view and focused row handle
        Dim view As GridView = CType(gc.FocusedView, GridView)
        Dim rowHandle As Integer = view.FocusedRowHandle

        'Get the new value of the category column
        Dim Editor As ComboBoxEdit = CType(sender, ComboBoxEdit)
        Dim NewCategory As String = Editor.EditValue.ToString()

        'Ensure the value is updated in gridview
        view.SetRowCellValue(rowHandle, "Category", NewCategory)

    End Sub

    Private Sub OnSubcategoryChanged(sender As Object, e As EventArgs)
        'Get the current view and focused row handle
        Dim view As GridView = CType(gc.FocusedView, GridView)
        Dim rowHandle As Integer = view.FocusedRowHandle

        ''Get the new value of the category column
        Dim cboSubategory As ComboBoxEdit = CType(sender, ComboBoxEdit)
        Dim NewSubcategory As String = cboSubategory.EditValue.ToString()
        'Dim NewSubcategory As String = view.GetRowCellValue(rowHandle, "Subcategory").ToString
        'Dim cboSubategory As ComboBoxEdit = TryCast(sender, ComboBoxEdit)

        If cboSubategory.Properties.Items.Contains(NewSubcategory) Then
            ''Ensure the value is updated in gridview
            'view.SetRowCellValue(rowHandle, "Subcategory", NewSubcategory)
            'Dim Subcategory As String = view.GetRowCellValue(rowHandle, "Subcategory")
            Dim OldCategory As String = view.GetRowCellValue(rowHandle, "Category").ToString
            Dim NewCategory As String = BogusDt.AsEnumerable().Where(Function(o) o("Subcategory") = NewSubcategory).Select(Function(o) o("Category").ToString).First
            If OldCategory <> NewCategory Then
                view.SetRowCellValue(rowHandle, "Category", NewCategory)
            End If
        End If
    End Sub

    Private Sub frmConvert_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            ProcessGenerateData(sender, e)
        ElseIf e.Control AndAlso e.KeyCode = Keys.C Then
            btnCopy_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub FillComboBox(cboTable As Windows.Forms.ComboBox, dataSource As List(Of String))
        With cboTable
            .DataSource = dataSource
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = 0
        End With
    End Sub

    Private Sub TestingGenerateData()
        Dim faker As New Faker(Of Customer)

        '-- Make a rule for each property
        faker.RuleFor(Function(c) c.FirstName, Function(f) f.Name.FullName) _
             .RuleFor(Function(c) c.LastName, Function(f) f.Name.LastName) _
                                                                           _
             .Rules(Sub(f, c)   '-- Or, alternatively, in bulk with .Rules() 
                        c.Age = f.Random.Int(18, 35)
                        c.Title = f.Name.JobTitle()
                    End Sub)

        Dim cust = faker.Generate(10)
        Dim sb = New StringBuilder()
        For Each cus In cust
            sb.AppendLine(PropertyList(cus))
        Next
        txtQuery.Text = sb.ToString
    End Sub

    '<Extension()>
    Public Shared Function PropertyList(ByVal obj As Object) As String
        Dim props = obj.[GetType]().GetProperties()
        Dim sb = New StringBuilder()

        For Each p In props
            sb.AppendLine(p.Name & ": " & p.GetValue(obj, Nothing))
        Next

        Return sb.ToString()
    End Function

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim newRow As DataRow = dtDataSet.NewRow()
        dtDataSet.Rows.Add(newRow)
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If gv.RowCount > 0 Then
            Dim rowIndex As Integer = gv.FocusedRowHandle
            dtDataSet.Rows.RemoveAt(rowIndex)
        End If
    End Sub

    Private Sub btnCategoryDetail_Click(sender As Object, e As EventArgs) Handles btnCategoryDetail.Click
        Dim Frm As New FrmCategoryDetail
        Frm.ShowDialog()
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Using SaveFileDialog As New SaveFileDialog()
            SaveFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*"
            SaveFileDialog.Title = "Export Dataset Settings"
            SaveFileDialog.FileName = cboTable.SelectedItem
            SaveFileDialog.InitialDirectory = My.Settings.DefaultExportPath

            If SaveFileDialog.ShowDialog() = DialogResult.OK Then
                Dim FilePath As String = SaveFileDialog.FileName

                SaveDatasetSetting(dtDataSet, FilePath)
            End If
        End Using
    End Sub

    Private Sub SaveDatasetSetting(dtDataSet As DataTable, filePath As String)
        Try
            dtDataSet.WriteXml(filePath, XmlWriteMode.WriteSchema)
        Catch ex As Exception
            MsgBox("Error saving setting :" & vbCrLf & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Public Function LoadDatatableFromFile(filePath As String) As DataTable
        Dim dt As New DataTable
        Try
            dt.ReadXml(filePath)
        Catch ex As Exception
            MsgBox("Error load setting :" & vbCrLf & ex.Message, MsgBoxStyle.Critical)
        End Try
        Return dt
    End Function
    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        Using OpenFileDialog As New OpenFileDialog()
            OpenFileDialog.InitialDirectory = My.Settings.DefaultExportPath
            OpenFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*"
            OpenFileDialog.Title = "Import Dataset Settings"
            If OpenFileDialog.ShowDialog() = DialogResult.OK Then
                Dim FilePath As String = OpenFileDialog.FileName
                dtDataSet = LoadDatatableFromFile(FilePath)
                cboTable.SelectedItem = IO.Path.GetFileNameWithoutExtension(OpenFileDialog.FileName)
                SelectedTable = cboTable.SelectedItem
                gc.DataSource = dtDataSet
            End If
        End Using
    End Sub

    Private Sub btnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click
        If txtQuery.Text.Trim = "" Then Exit Sub
        Clipboard.SetText(txtQuery.Text)
        btnCopy.Image = Resources.copy2
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        dtDataSet.Clear()
    End Sub

End Class


Public Class Customer
    Public Property FirstName() As String
    Public Property LastName() As String
    Public Property Age() As Integer
    Public Property Title() As String
End Class
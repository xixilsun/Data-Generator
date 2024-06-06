Imports System.Data
Imports System.Linq
Imports System.Runtime.CompilerServices
Imports System.Text
Imports Bogus
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System.Reflection
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraEditors
Imports Bogus.DataSets
Imports DevExpress.Utils.Serializing
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraEditors.Controls
Imports System.ComponentModel
Imports System.Drawing

Public Class FrmMain
    Private dtDataSet As New DataTable
    Private SelectedDatabase As String = My.Settings.DefaultDatabase
    Private SelectedTable As String = My.Settings.DefaultTable
    Private BogusDt As New DataTable
    Private AllCategoryList As List(Of String)
    Private AllSubcategoryList As List(Of String)
    Private FirstLoad As Boolean = True

    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Add Handler
        AddHandler cboDatabase.SelectedIndexChanged, AddressOf OnDBSelectedIndexChanged
        AddHandler dtDataSet.RowChanged, AddressOf DatasetRowChanged
        AddHandler cboCategory.SelectedIndexChanged, AddressOf FillSubcategoryComboBox
        'AddHandler cboSubcategory.SelectedIndexChanged, AddressOf FillCategoryComboBox
        'AddHandler gv.ValidateRow, AddressOf OnValidateRow
        AddHandler btnGenerate.Click, AddressOf ProcessGenerateData
        AddHandler btnPrepareDataset.Click, AddressOf PrepareDataset
        'Supress asking edit data?
        AddHandler gv.InvalidRowException, AddressOf OnInvalidRowException

        BogusDt = BogusDatatable()
        'Add default All Category & Subcategory List
        AllCategoryList = BogusDt.AsEnumerable().Select(Function(o) o("Category").ToString).Distinct().ToList
        AllSubcategoryList = BogusDt.AsEnumerable().Select(Function(o) o("Subcategory").ToString).ToList

        FillComboBox(cboCategory, AllCategoryList)
        'FillSubcategory(cboCategory.SelectedValue)

        'TestingGenerateData()
        Me.KeyPreview = True

        'Prepare GridView
        PrepareGridView()

        'Set Default value for Category & Subcategory
        Dim CategoryCombo As RepositoryItemComboBox = CType(gv.Columns("Category").ColumnEdit, RepositoryItemComboBox)
        Dim SubcategoryCombo As RepositoryItemComboBox = CType(gv.Columns("Subcategory").ColumnEdit, RepositoryItemComboBox)


        'Add event handler for category column value change
        AddHandler CategoryCombo.EditValueChanged, AddressOf OnCategoryChanged
        AddHandler SubcategoryCombo.EditValueChanged, AddressOf OnSubcategoryChanged

        'Add Handler for CustomRowCellForEditing
        AddHandler gv.CustomRowCellEditForEditing, AddressOf OnGridViewCustomRowCellEditForEditing

        'Prepare database
        'txtServer.Text = "172.18.3.14"
        Dim DatabaseList = ModSQL.GetDataTable("SELECT name AS DatabaseName FROM Sysdatabases WHERE name LIKE 'HRdb%'", ModSQL.GetConnectionString("Master")).AsEnumerable.Select(Function(o) o("DatabaseName")).ToList()
        With cboDatabase
            .Properties.Items.AddRange(DatabaseList)
            .SelectedItem = SelectedDatabase
        End With

        If FirstLoad Then cboTable.SelectedItem = SelectedTable
        FirstLoad = False
    End Sub

    Private Sub OnGridViewCustomRowCellEditForEditing(sender As Object, e As CustomRowCellEditEventArgs)
        If e.Column.FieldName = "Subcategory" And Not FirstLoad Then
            'Create a new RepositoryItemComboBox For the subcategory
            Dim SubcategoryCombo As New RepositoryItemComboBox

            Dim View As GridView = CType(sender, GridView)
            Dim RowHandle As Integer = e.RowHandle

            'Get the current category for the row
            Dim CurrentCategory As String = View.GetRowCellValue(RowHandle, "Category").ToString

            'Populate subcategory
            Dim SubcategoryList As List(Of String) = BogusDt.AsEnumerable().Where(Function(o) o("Category") = CurrentCategory).Select(Function(o) o("Subcategory").ToString).ToList
            SubcategoryCombo.Items.AddRange(SubcategoryList)
            e.RepositoryItem = SubcategoryCombo

        End If
    End Sub

    Private Sub PrepareDataset(sender As Object, e As EventArgs)
        Dim Sql = "SELECT column_name AS ColumnName" & vbCrLf &
                  "FROM INFORMATION_SCHEMA.COLUMNS" & vbCrLf &
                  "WHERE TABLE_NAME = " & SqlStr(cboTable.SelectedItem)
        Dim Dt As DataTable = GetDataTable(Sql, GetConnectionString(cboDatabase.SelectedItem))
        dtDataSet.Rows.Clear()

        For Each row In Dt.Rows
            dtDataSet.Rows.Add(row!ColumnName)
        Next
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

            If FirstLoad Then SetSelectedItem(cboTable, SelectedTable)
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

    Private Sub OnValidateRow(sender As Object, e As ValidateRowEventArgs)
        e.Valid = ValidateRow(e.RowHandle)
    End Sub

    Private Sub DatasetRowChanged(sender As Object, e As DataRowChangeEventArgs)
        If e.Action = DataRowAction.Add Then
            'Get the current view and focused row handle
            Dim View As GridView = CType(gc.FocusedView, GridView)
            Dim RowHandle As Integer = View.RowCount - 1
            'Set Default value for Category
            Dim CategoryCombo As RepositoryItemComboBox = CType(View.Columns("Category").ColumnEdit, RepositoryItemComboBox)
            If CategoryCombo.Items.Count > 0 Then
                View.SetRowCellValue(RowHandle, "Category", CategoryCombo.Items(0).ToString)
            End If

            'Set Default value for Subcategory
            Dim SubcategoryCombo As RepositoryItemComboBox = CType(View.Columns("Subcategory").ColumnEdit, RepositoryItemComboBox)
            If SubcategoryCombo.Items.Count > 0 Then
                View.SetRowCellValue(RowHandle, "Subcategory", SubcategoryCombo.Items(0).ToString)
            End If

            'Set focused row handle on new row
            View.FocusedRowHandle = RowHandle
        End If
    End Sub

    Private Sub FillSubcategoryComboBox(sender As Object, e As EventArgs)
        Dim Category As String = cboCategory.SelectedValue
        Dim SubcategoryList As List(Of String) = BogusDt.AsEnumerable().Where(Function(x) x("Category") = Category).Select(Function(o) o("Subcategory").ToString).ToList()
        FillComboBox(cboSubcategory, SubcategoryList)
    End Sub

    Private Sub ProcessGenerateData(sender As Object, e As EventArgs)
        Dim ColumnName As String = "", Category As String = "", Subcategory As String = "", OptionalValue As String = ""
        Try
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

            For i As Integer = 0 To numQty.Value - 1
                Dim paramList As New List(Of String)
                For Each Row In dtDataSet.Rows
                    paramList.Add(GenerateFakeData(Row!Category, Row!Subcategory))
                Next

                dtOutput.Rows.Add(paramList.ToArray)
            Next

            gcOutput.DataSource = Nothing
            gcOutput.DataSource = dtOutput

            gcOutput.MainView.PopulateColumns()
            gcOutput.MainView.RefreshData()

            gvOutput.OptionsView.ColumnAutoWidth = False
            gvOutput.HorzScrollVisibility = ScrollVisibility.Always
            gvOutput.BestFitColumns()

            Dim Query As String = $"INSERT INTO MyTable ({AllColumns}) VALUES"
            Dim Count As Integer = 1
            For Each row In dtOutput.Rows
                Dim dataQuery As String = ""
                For Each column As DataColumn In dtOutput.Columns
                    dataQuery &= If(dataQuery = "", "", ", ") & $"'{row(column)}'"
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
        Dim ColumnName As String = If(View.GetRowCellValue(rowHandle, "ColumnName")?.ToString, String.Empty)

        If String.IsNullOrWhiteSpace(ColumnName) Then
            View.SetColumnError(View.Columns("ColumnName"), "ColumnName must not be empty.", DXErrorProvider.ErrorType.Critical)
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
        dtDataSet.Columns.Add("Optional", System.Type.GetType("System.String"))

        gc.DataSource = dtDataSet

        'Call method to setup dropdowns
        SetupDropdownColumns()

        dtDataSet.Rows.Add(dtDataSet.NewRow())
    End Sub

    Private Sub SetupDropdownColumns()
        'Create RepositoryItemComboBox for Category Column
        Dim CategoryCombo As New RepositoryItemComboBox()
        Dim CategoryList As List(Of String) = AllCategoryList
        CategoryCombo.Items.AddRange(CategoryList)

        'Assign RepositoryItemComboBox to GridView Column
        gv.Columns("Category").ColumnEdit = CategoryCombo

        SetupSubcategoryDropdown()
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

        'Refresh the view to trigger CustomRowCellEditforEditing
        'view.RefreshRowCell(rowHandle, view.Columns("Subcategory"))
        'SetupSubcategoryDropdown(NewCategory)
    End Sub

    Private Sub OnSubcategoryChanged(sender As Object, e As EventArgs)
        'Get the current view and focused row handle
        Dim view As GridView = CType(gc.FocusedView, GridView)
        Dim rowHandle As Integer = view.FocusedRowHandle

        ''Get the new value of the category column
        Dim cboSubategory As ComboBoxEdit = CType(sender, ComboBoxEdit)
        Dim NewSubcategory As String = cboSubategory.EditValue.ToString()

        'Dim cboSubategory As ComboBoxEdit = TryCast(sender, ComboBoxEdit)

        If cboSubategory.Properties.Items.Contains(NewSubcategory) Then
            ''Ensure the value is updated in gridview
            'view.SetRowCellValue(rowHandle, "Subcategory", NewSubcategory)
            'Dim Subcategory As String = view.GetRowCellValue(rowHandle, "Subcategory")
            Dim OldCategory As String = view.GetRowCellValue(rowHandle, "Category")
            Dim NewCategory As String = BogusDt.AsEnumerable().Where(Function(o) o("Subcategory") = NewSubcategory).Select(Function(o) o("Category").ToString).First
            If OldCategory <> NewCategory Then
                view.SetRowCellValue(rowHandle, "Category", NewCategory)
            End If
        End If
    End Sub

    Private Sub SetupSubcategoryDropdown(Optional category As String = "")
        'Create RepositoryItemComboBox for Subcategory Column
        Dim SubcategoryCombo As New RepositoryItemComboBox()
        'If the form is on the first load, the category is empty, set subcategory As All category 
        Dim SubcategoryList As List(Of String) = AllSubcategoryList

        If Not FirstLoad AndAlso category <> "" Then
            Dim view As GridView = CType(gc.FocusedView, GridView)
            Dim RowHandle As Integer = view.FocusedRowHandle

            SubcategoryList = BogusDt.AsEnumerable().Where(Function(o) o("Category").ToString = category).Select(Function(o) o("Subcategory").ToString).ToList()
            view.SetRowCellValue(RowHandle, "Subcategory", SubcategoryList.FirstOrDefault)

            SubcategoryCombo.Items.AddRange(SubcategoryList)

            gv.Columns("Subcategory").ColumnEdit = SubcategoryCombo

            'SubcategoryCombo = CType(view.Columns("Subcategory").ColumnEdit, RepositoryItemComboBox)
            'SubcategoryCombo.Items.Clear()

            'SubcategoryList
        End If
        SubcategoryCombo.Items.AddRange(SubcategoryList)
        gv.Columns("Subcategory").ColumnEdit = SubcategoryCombo
    End Sub

    Private Sub frmConvert_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            btnGenerateOneData_Click(sender, e)
        End If
    End Sub
    Private Sub FillSubcategory(category As String)

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

    Private Sub Test2()
        Dim faker As New Faker("en")
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


    'Private Sub cboDataType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCategory.SelectedIndexChanged
    '    FillSubcategory(cboCategory.SelectedValue)
    'End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnOneData.Click
        Try
            Dim faker As New Faker()
            'Dim x = cboCategory.SelectedValue & "." & cboSubcategory.SelectedValue \

            Dim category = cboCategory.SelectedValue
            Dim subcategory = cboSubcategory.SelectedValue

            Dim parsingString = $"{{{{{category}.{subcategory}}}}}"
            'parsingString = "{{name.firstname(Female)}}"
            Dim randomName = faker.Parse(parsingString)
            txtQuery.Text = randomName

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        'TestingGenerateData()
    End Sub

    Private Function GenerateFakeData(category As String, subcategory As String) As String
        Try
            'Create a new Faker instance
            Dim Fake As New Faker()
            Dim RandomValue As String = ""

            Dim CategoryProperty As PropertyInfo = GetType(Faker).GetProperty(category, BindingFlags.Public Or BindingFlags.Instance)
            If CategoryProperty Is Nothing Then Throw New Exception("Unknown category")

            Dim CategoryInstance As Object = CategoryProperty.GetValue(Fake)

            'Special Handling for overloaded methods like Random.Number
            If category = "Random" AndAlso
                (subcategory = "Number" OrElse subcategory = "Bool" OrElse subcategory = "String") Then
                If subcategory = "Number" Then
                    RandomValue = Fake.Random.Number(0, 100).ToString()
                ElseIf subcategory = "Bool" Then
                    RandomValue = Fake.Random.Bool().ToString
                ElseIf subcategory = "String" Then
                    RandomValue = Fake.Random.String(10).ToString
                End If

            ElseIf category = "Company" AndAlso
                    subcategory = "CompanyName" Then
                RandomValue = Fake.Company.CompanyName
            ElseIf category = "Lorem" AndAlso subcategory = "Paragraphs" Then
                RandomValue = Fake.Lorem.Paragraphs(3, vbCrLf)
            Else
                Dim SubcategoryMethod As MethodInfo = CategoryInstance.GetType().GetMethod(subcategory, BindingFlags.Public Or BindingFlags.Instance)
                If SubcategoryMethod Is Nothing Then Throw New Exception("Unknown subcategory")

                'Check if the method has parameter
                Dim parameters As ParameterInfo() = SubcategoryMethod.GetParameters()
                Dim result As Object

                If parameters.Length > 0 Then
                    Dim paramValues As Object() = parameters.Select(Function(p) GetDefaultValue(p)).ToArray
                    result = SubcategoryMethod.Invoke(CategoryInstance, paramValues)
                Else
                    result = SubcategoryMethod.Invoke(CategoryInstance, Nothing)
                End If

                If TypeOf result Is String Then
                    RandomValue = Replace(result, vbLf, vbCrLf)
                Else
                    If result.length > 1 Then
                        For Each obj In result
                            RandomValue &= If(RandomValue = "", "", vbCrLf) & obj.ToString
                        Next
                    End If
                End If
            End If

            Return RandomValue
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return ""
    End Function

    Private Function GetDefaultValue(param As ParameterInfo) As Object
        If param.HasDefaultValue Then
            Return param.DefaultValue
        ElseIf param.ParameterType.IsValueType Then
            Return Activator.CreateInstance(param.ParameterType)
        Else
            Return Nothing
        End If
        Return Nothing
    End Function


    Private Sub btnGenerateOneData_Click(sender As Object, e As EventArgs) Handles btnGenerateOneData.Click
        txtQuery.Text = GenerateFakeData(cboCategory.SelectedValue, cboSubcategory.SelectedValue)
    End Sub

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

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click

    End Sub

    Private Sub btnCategoryDetail_Click(sender As Object, e As EventArgs) Handles btnCategoryDetail.Click
        Dim Frm As New FrmCategoryDetail
        Frm.ShowDialog()
    End Sub
End Class


Public Class Customer
    Public Property FirstName() As String
    Public Property LastName() As String
    Public Property Age() As Integer
    Public Property Title() As String
End Class
Imports System.Collections.Generic
Imports System.Linq
Imports System.Data
Imports DevExpress.Xpo.DB
Imports System.ComponentModel
Imports System.Reflection
Imports Bogus
Imports System.Windows.Forms
Imports System.Drawing
Imports DevExpress.XtraEditors

Public Class FrmSettingParameter
    Private _ColumnName As String = ""
    Private _Category As String = ""
    Private _Subcategory As String = ""
    Private _CategoryList As New List(Of String)
    Private _SubcategoryList As New List(Of String)
    Private _Parameter As String = ""
    Private _UserDefined As String = ""
    Private _MaxLength As String = ""
    Private _IsOK As Boolean
    Private IsFirstLoad As Boolean = True

    Public ReadOnly Property IsOK As Boolean
        Get
            Return _IsOK
        End Get
    End Property
    Public Property Parameter As String
        Set(ByVal value As String)
            _Parameter = value
        End Set
        Get
            Return _Parameter
        End Get
    End Property
    Public Property UserDefined As String
        Set(ByVal value As String)
            _UserDefined = value
        End Set
        Get
            Return _UserDefined
        End Get
    End Property
    Public Property MaxLength As String
        Set(ByVal value As String)
            _MaxLength = value
        End Set
        Get
            Return _MaxLength
        End Get
    End Property
    Public Property ColumnName As String
        Set(ByVal value As String)
            _ColumnName = value
        End Set
        Get
            Return _ColumnName
        End Get
    End Property
    Public Property Category As String
        Set(ByVal value As String)
            _Category = value
        End Set
        Get
            Return _Category
        End Get
    End Property

    Public Property Subcategory As String
        Set(ByVal value As String)
            _Subcategory = value
        End Set
        Get
            Return _Subcategory
        End Get
    End Property

    Public Property CategoryList As List(Of String)
        Set(ByVal value As List(Of String))
            _CategoryList = value
        End Set
        Get
            Return _CategoryList
        End Get
    End Property

    Public Property SubcategoryList As List(Of String)
        Set(ByVal value As List(Of String))
            _SubcategoryList = value
        End Set
        Get
            Return _SubcategoryList
        End Get
    End Property

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        Try
            If cboCategory.SelectedItem = "" AndAlso cboSubcategory.SelectedItem = "" Then Throw New Exception("Please choose CategoryAttribute & subcategory")

            'Get Parameter to ParameterList Textbox
            SetParameterList()
            Dim Sample As String = GenerateFakeData(cboCategory.SelectedItem, cboSubcategory.SelectedItem, txtParameterList.Text, txtUserDefined.Text)

            MsgBox(Sample, MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub SetParameterList()
        'Get Parameter to ParameterList
        Dim ParameterText As String = ""
        For Each ctrl As Control In pnlParameters.Controls
            If TypeOf ctrl Is TextEdit Then
                Dim txt As TextEdit = DirectCast(ctrl, TextEdit)
                ParameterText &= If(ParameterText = "", "", vbCrLf) & txt.Name & "=" & txt.Text
            ElseIf TypeOf ctrl Is SpinEdit Then
                Dim num As SpinEdit = DirectCast(ctrl, SpinEdit)
                ParameterText &= If(ParameterText = "", "", vbCrLf) & num.Name & "=" & num.Value
            ElseIf TypeOf ctrl Is ComboBoxEdit Then
                Dim cbo As ComboBoxEdit = DirectCast(ctrl, ComboBoxEdit)
                ParameterText &= If(ParameterText = "", "", vbCrLf) & cbo.Name & "=" & cbo.SelectedItem
            ElseIf TypeOf ctrl Is DateEdit Then
                Dim _date As DateEdit = DirectCast(ctrl, DateEdit)
                ParameterText &= If(ParameterText = "", "", vbCrLf) & _date.Name & "=" & _date.EditValue
            End If
        Next
        txtParameterList.Text = ParameterText
    End Sub

    Private Sub FrmSettingParameter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtColumnName.Text = _ColumnName
        txtParameterList.Text = _Parameter
        txtMaxLength.Text = _MaxLength
        txtUserDefined.Text = _UserDefined
        With cboCategory
            .Properties.Items.AddRange(CategoryList)
            .SelectedItem = _Category
        End With
        With cboSubcategory
            .Properties.Items.AddRange(SubcategoryList)
            .SelectedItem = _Subcategory
        End With
        IsFirstLoad = False
    End Sub

    Private Sub cboCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCategory.SelectedIndexChanged
        Dim Category As String = cboCategory.SelectedItem
        If cboCategory.Properties.Items.Contains(Category) Then
            Dim SubcategoryList As List(Of String) = BogusDatatable().AsEnumerable().Where(Function(x) x("Category") = Category).Select(Function(o) o("Subcategory").ToString).ToList()
            With cboSubcategory
                .Properties.Items.Clear()
                .Properties.Items.AddRange(SubcategoryList)
                If Not IsFirstLoad Then .SelectedIndex = 0
            End With
        End If
    End Sub

    Private Sub cboSubcategory_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cboSubcategory.SelectedIndexChanged
        Dim SelectedSubcategory As String = cboSubcategory.SelectedItem
        If cboSubcategory.Properties.Items.Contains(SelectedSubcategory) Then
            Dim NewCategory As String = BogusDatatable().AsEnumerable().Where(Function(o) o("Subcategory") = SelectedSubcategory).Select(Function(o) o("Category").ToString).First()
            If cboCategory.SelectedItem <> NewCategory Then
                RemoveHandler cboCategory.SelectedIndexChanged, AddressOf cboCategory_SelectedIndexChanged
                cboCategory.SelectedItem = NewCategory
                AddHandler cboCategory.SelectedIndexChanged, AddressOf cboCategory_SelectedIndexChanged
            End If

            txtUserDefined.Enabled = SelectedSubcategory = "UserDefined"
            If Not txtUserDefined.Enabled Then txtUserDefined.Text = ""
            'Clear panel Parameter if subcategory changed
            pnlParameters.Controls.Clear()

            'Get Parameter of subcategory
            GetParameterInput(NewCategory, SelectedSubcategory)
        End If
    End Sub

    Private Sub AddInputBox(labelText As String, paramType As Type, Optional paramDefaultValue As Object = Nothing)
        Dim lbl As New Label()
        Dim IsNotFound As Boolean = False
        lbl.Text = labelText
        lbl.AutoSize = True
        lbl.Location = New Point(0, pnlParameters.Controls.Count * 14 + 4)
        If IsFirstLoad AndAlso txtParameterList.Text.Trim <> "" Then
            Dim value As Object = GetValueByKey(txtParameterList.Text, labelText, paramType)
            If value.ToString <> "" Then paramDefaultValue = value
        End If

        If paramType = Type.GetType("System.String") OrElse paramType = Type.GetType("System.Char") Then
            Dim txt As New TextEdit()
            txt.Location = New Point(110, pnlParameters.Controls.Count * 14)
            txt.Width = 143
            txt.Name = labelText
            txt.Text = paramDefaultValue

            pnlParameters.Controls.Add(txt)
        ElseIf paramType.FullName.Contains("System.Int32") Then
            Dim txt As New SpinEdit()
            txt.Location = New Point(110, pnlParameters.Controls.Count * 14)
            txt.Width = 143
            txt.Name = labelText
            txt.Properties.IsFloatValue = False
            txt.Properties.EditMask = "n0"
            txt.Value = If(labelText = "Length" AndAlso txtMaxLength.Text <> "-" AndAlso Not IsFirstLoad, Convert.ToInt32(txtMaxLength.Text), paramDefaultValue)
            If txtMaxLength.Text <> "-" And labelText = "Length" Then txt.Properties.MaxValue = Convert.ToInt32(txtMaxLength.Text)
            pnlParameters.Controls.Add(txt)
        ElseIf paramType.FullName.Contains("System.DateTime") Then
            Dim txt As New DateEdit()
            txt.Location = New Point(110, pnlParameters.Controls.Count * 14)
            txt.Width = 143
            txt.Name = labelText
            txt.EditValue = paramDefaultValue

            pnlParameters.Controls.Add(txt)
        ElseIf paramType = Type.GetType("System.Decimal") OrElse paramType = Type.GetType("System.Double") OrElse paramType = Type.GetType("System.Single") Then
            Dim txt As New SpinEdit()
            txt.Properties.IsFloatValue = True
            txt.Properties.EditMask = "n2"
            txt.Properties.Increment = 0.1
            txt.Location = New Point(110, pnlParameters.Controls.Count * 14)
            txt.Width = 143
            txt.Name = labelText
            txt.Value = paramDefaultValue

            pnlParameters.Controls.Add(txt)
        ElseIf paramType.FullName.Contains("System.Boolean") Then
            Dim txt As New ComboBoxEdit()
            txt.Properties.Items.Add(True)
            txt.Properties.Items.Add(False)
            txt.Location = New Point(110, pnlParameters.Controls.Count * 14)
            txt.Width = 143
            txt.Name = labelText
            txt.SelectedItem = paramDefaultValue
            pnlParameters.Controls.Add(txt)
        ElseIf paramType.FullName.Contains("Gender") Then
            Dim txt As New ComboBoxEdit()
            txt.Properties.Items.AddRange(GenderList)
            txt.Location = New Point(110, pnlParameters.Controls.Count * 14)
            txt.Width = 143
            txt.Name = labelText
            txt.SelectedItem = paramDefaultValue
            pnlParameters.Controls.Add(txt)
        Else
            IsNotFound = True
            MsgBox(paramType.FullName, MsgBoxStyle.Information)
        End If

        If Not IsNotFound Then
            pnlParameters.Controls.Add(lbl)
        End If
    End Sub
    Private Sub AddLabel(labelText As String)
        Dim lbl As New Label()
        Dim IsNotFound As Boolean = False
        lbl.Text = labelText
        lbl.ForeColor = Color.Blue
        lbl.AutoSize = True
        lbl.Location = New Point(0, pnlParameters.Controls.Count * 14 + 4)
        pnlParameters.Controls.Add(lbl)
    End Sub

    Private Sub btnGetParameter_Click(sender As Object, e As EventArgs)
        txtParameterList.Clear()
        Try
            Dim AllParameter As String = ""
            If cboCategory.SelectedItem = "" AndAlso cboSubcategory.SelectedItem = "" Then Throw New Exception("Please choose CategoryAttribute & subcategory")
            'Create a new Faker instance
            _Category = cboCategory.SelectedItem
            _Subcategory = cboSubcategory.SelectedItem
            Dim Fake As New Faker()

            If _Subcategory = "Number" Then
                AllParameter = "Min=" & vbCrLf & "Max="
            Else
                Dim CategoryProperty As PropertyInfo = GetType(Faker).GetProperty(_Category, BindingFlags.Public Or BindingFlags.Instance)
                If CategoryProperty Is Nothing Then Throw New Exception("Unknown category")

                Dim CategoryInstance As Object = CategoryProperty.GetValue(Fake)

                Dim SubcategoryMethod As MethodInfo = CategoryInstance.GetType().GetMethod(_Subcategory, BindingFlags.Public Or BindingFlags.Instance)
                If SubcategoryMethod Is Nothing Then Throw New Exception("Unknown subcategory")

                'Check if the method has parameter
                Dim parameters As ParameterInfo() = SubcategoryMethod.GetParameters()
                For Each param In parameters
                    AllParameter &= If(AllParameter = "", "", vbCrLf) & param.Name.ToString & "="
                Next
            End If
            txtParameterList.Text = AllParameter
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub GetParameterInput(selectedCategory As String, selectedSubcategory As String)
        Try
            Dim Fake As New Faker()

            If selectedCategory = "Random" AndAlso selectedSubcategory = "Digits" Then
                selectedCategory = "Phone"
                selectedSubcategory = "PhoneNumber"
            End If

            If selectedSubcategory = "Number" Then
                AddInputBox("Min", Type.GetType("System.Int32"), 0)
                AddInputBox("Max", Type.GetType("System.Int32"), 100)
            ElseIf selectedSubcategory = "Amount" Then
                AddInputBox("Min", Type.GetType("System.Int32"), 1)
                AddInputBox("Max", Type.GetType("System.Int32"), 10000)
                AddInputBox("Decimals", Type.GetType("System.Int32"), 0)
                AddLabel("Amount will be in thousands")
            ElseIf selectedSubcategory = "String" Then
                AddInputBox("Length", Type.GetType("System.Int32"), 10)

            ElseIf selectedSubcategory = "Paragraphs" Then
                AddInputBox("Min", Type.GetType("System.Int32"), 1)
                AddInputBox("Max", Type.GetType("System.Int32"), 10)
                AddInputBox("Separator", Type.GetType("System.String"), vbCrLf)
            ElseIf ("CompanyName-CountryCode-UserDefined-Gender-Null-Empty-Now-").Contains(selectedSubcategory & "-") Then
                'Do Nothing
            Else
                Dim CategoryProperty As PropertyInfo = GetType(Faker).GetProperty(selectedCategory, BindingFlags.Public Or BindingFlags.Instance)
                If CategoryProperty Is Nothing Then Throw New Exception("Unknown category")

                Dim CategoryInstance As Object = CategoryProperty.GetValue(Fake)

                Dim SubcategoryMethod As MethodInfo = CategoryInstance.GetType().GetMethod(selectedSubcategory, BindingFlags.Public Or BindingFlags.Instance)
                If SubcategoryMethod Is Nothing Then Throw New Exception("Unknown subcategory")

                'Check if the method has parameter
                Dim parameters As ParameterInfo() = SubcategoryMethod.GetParameters()
                For Each param In parameters
                    If param.Name.ToString <> "separator" Then AddInputBox(UppercaseFirstLetter(param.Name.ToString), param.ParameterType, If(param.HasDefaultValue, param.DefaultValue, Nothing))
                Next
                If selectedSubcategory = "AlphaNumeric" Then AddInputBox("IsUpperCase", Type.GetType("System.Boolean"), True)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        _Category = cboCategory.SelectedItem
        _Subcategory = cboSubcategory.SelectedItem
        _ColumnName = txtColumnName.Text
        _MaxLength = txtMaxLength.Text

        SetParameterList()
        _Parameter = txtParameterList.Text
        If Not IsValid() Then Exit Sub

        If _Subcategory = "UserDefined" Then _UserDefined = txtUserDefined.Text
        'Get Parameter to ParameterList Textbox

        _IsOK = True
        Me.Dispose()
    End Sub

    Private Function IsValid() As Boolean
        Dim bool = False
        Try
            If _Subcategory = "UserDefined" AndAlso txtUserDefined.Text.Trim = "" Then
                Throw New Exception("Please fill user defined list!")
            ElseIf _Category = "" OrElse _Subcategory = "" Then
                Throw New Exception("Please fill category and subcategory!")
            End If

            bool = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return bool
    End Function

End Class
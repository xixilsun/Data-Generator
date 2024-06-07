Imports System.Collections.Generic
Imports System.Linq
Imports System.Data
Imports DevExpress.Xpo.DB
Imports System.ComponentModel
Imports System.Reflection
Imports Bogus

Public Class FrmSettingParameter
    Private _ColumnName As String = ""
    Private _Category As String = ""
    Private _Subcategory As String = ""
    Private _CategoryList As New List(Of String)
    Private _SubcategoryList As New List(Of String)
    Private _Parameter As String = ""
    Private _MaxLength As String = ""
    Private _IsOK As Boolean

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

    Private Sub cboSubcategory_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        Try
            If cboCategory.SelectedItem = "" AndAlso cboSubcategory.SelectedItem = "" Then Throw New Exception("Please choose CategoryAttribute & subcategory")

            Dim Sample As String = GenerateFakeData(cboCategory.SelectedItem, cboSubcategory.SelectedItem, txtParameterList.Text)
            MsgBox(Sample, MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub FrmSettingParameter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtColumnName.Text = _ColumnName
        txtParameter.Text = _Parameter
        With cboCategory
            .Properties.Items.AddRange(CategoryList)
            .SelectedItem = _Category
        End With
        With cboSubcategory
            .Properties.Items.AddRange(SubcategoryList)
            .SelectedItem = _Subcategory
        End With
        txtMaxLength.Text = _MaxLength

    End Sub

    Private Sub cboCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCategory.SelectedIndexChanged
        Dim Category As String = cboCategory.SelectedItem
        If cboCategory.Properties.Items.Contains(Category) Then
            Dim SubcategoryList As List(Of String) = BogusDatatable().AsEnumerable().Where(Function(x) x("Category") = Category).Select(Function(o) o("Subcategory").ToString).ToList()
            With cboSubcategory
                .Properties.Items.Clear()
                .Properties.Items.AddRange(SubcategoryList)
                .SelectedIndex = 0
            End With
        End If
    End Sub

    Private Sub cboSubcategory_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cboSubcategory.SelectedIndexChanged
        Dim Subcategory As String = cboSubcategory.SelectedItem
        If cboSubcategory.Properties.Items.Contains(Subcategory) Then
            Dim NewCategory As String = BogusDatatable().AsEnumerable().Where(Function(o) o("Subcategory") = Subcategory).Select(Function(o) o("Category").ToString).First()
            If cboCategory.SelectedItem <> NewCategory Then
                cboCategory.SelectedItem = NewCategory
            End If
        End If
    End Sub

    Private Sub btnGetParameter_Click(sender As Object, e As EventArgs) Handles btnGetParameter.Click
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
End Class
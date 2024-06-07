Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System.Data
Imports System.Linq
Imports System.Runtime.CompilerServices
Imports System.Text
Imports Bogus
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
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.Utils
Imports DevExpress.Xpo.DB
Public Class FrmReferenceDetail
    Public ColumnName As String = ""
    Public ParentDatabase As String = ""
    Public ParentTable As String = ""
    Public ParentID As String = ""
    Public HasReference As Boolean
    Public IsOK As Boolean

    Public WriteOnly Property _IsOK As Boolean
        Set(ByVal value As Boolean)
            IsOK = value
        End Set
    End Property
    Public Property _ColumnName As String
        Set(ByVal value As String)
            ColumnName = value
        End Set
        Get
            Return ColumnName
        End Get
    End Property
    Public Property _ParentDatabase As String
        Set(ByVal value As String)
            ParentDatabase = value
        End Set
        Get
            Return ParentDatabase
        End Get
    End Property

    Public Property _ParentTable As String
        Set(ByVal value As String)
            ParentTable = value
        End Set
        Get
            Return ParentTable
        End Get
    End Property

    Public Property _ParentID As String
        Set(ByVal value As String)
            ParentID = value
        End Set
        Get
            Return ParentID
        End Get
    End Property

    Public Property _HasReference As Boolean
        Set(ByVal value As Boolean)
            HasReference = value
        End Set
        Get
            Return HasReference
        End Get
    End Property


    Private Sub FrmReferenceDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtColumnName.Text = ColumnName

        Dim DatabaseList = ModSQL.GetDataTable("SELECT name AS DatabaseName FROM Sysdatabases WHERE name LIKE 'HRdb%'", ModSQL.GetConnectionString("Master")).AsEnumerable.Select(Function(o) o("DatabaseName")).ToList()
        With cboParentDatabase
            .Properties.Items.AddRange(DatabaseList)
            .SelectedItem = If(HasReference, ParentDatabase, Nothing)
        End With

        Dim Sql = "SELECT TABLE_NAME AS TableName" & vbCrLf &
                "FROM INFORMATION_SCHEMA.TABLES" & vbCrLf &
                "WHERE TABLE_TYPE = 'BASE TABLE' " & vbCrLf &
                If(HasReference, "AND TABLE_CATALOG = " & SqlStr(ParentDatabase) & vbCrLf, "") &
                "ORDER BY TABLE_NAME"

        Dim TableList = ModSQL.GetDataTable(Sql, GetConnectionString(ParentDatabase)).AsEnumerable.Select(Function(o) o("TableName")).ToList()
        With cboParentTable
            .Properties.Items.AddRange(TableList)
            .SelectedItem = ParentTable
        End With

        If HasReference Then
            Sql = "SELECT column_name AS ColumnName" & vbCrLf &
              "FROM INFORMATION_SCHEMA.COLUMNS" & vbCrLf &
              "WHERE TABLE_NAME = " & SqlStr(cboParentTable.SelectedItem)

            Dim ColumnList = GetDataTable(Sql, GetConnectionString(ParentDatabase)).AsEnumerable.Select(Function(o) o("ColumnName")).ToList
            With cboParentID
                .Properties.Items.AddRange(ColumnList)
                .SelectedItem = ParentID
            End With
        End If
    End Sub

    Private Sub TextEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles txtColumnName.EditValueChanged

    End Sub

    Private Sub cboParentTable_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboParentTable.SelectedIndexChanged
        If cboParentTable.Properties.Items.Contains(cboParentTable.SelectedItem) Then
            Dim Sql = "SELECT column_name AS ColumnName" & vbCrLf &
                  "FROM INFORMATION_SCHEMA.COLUMNS" & vbCrLf &
                  "WHERE TABLE_NAME = " & SqlStr(cboParentTable.SelectedItem)

            Dim ColumnList = GetDataTable(Sql, GetConnectionString(cboParentDatabase.SelectedItem)).AsEnumerable.Select(Function(o) o("ColumnName")).ToList
            With cboParentID
                .Properties.Items.Clear()
                .Properties.Items.AddRange(ColumnList)
                .SelectedItem = ParentID
            End With

        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If cboParentTable.SelectedItem <> "" AndAlso cboParentID.SelectedItem <> "" AndAlso cboParentDatabase.SelectedItem <> "" Then
            _ParentDatabase = cboParentDatabase.SelectedItem
            _ParentTable = cboParentTable.SelectedItem
            _ParentID = cboParentID.SelectedItem
            _HasReference = True
            _IsOK = True
            Me.Dispose()
        ElseIf cboParentTable.SelectedItem = "" AndAlso cboParentID.SelectedItem = "" AndAlso cboParentDatabase.SelectedItem = "" Then
            _HasReference = False
            _IsOK = True
            Me.Dispose()
        Else
            MsgBox("Please select Reference to database, table and ID!", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        cboParentDatabase.SelectedItem = Nothing
        cboParentTable.SelectedItem = Nothing
        cboParentID.SelectedItem = Nothing
    End Sub

    Private Sub cboParentDatabase_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboParentDatabase.SelectedIndexChanged
        If cboParentDatabase.Properties.Items.Contains(cboParentDatabase.SelectedItem) Then
            Dim Sql = "SELECT TABLE_NAME AS TableName" & vbCrLf &
                "FROM INFORMATION_SCHEMA.TABLES" & vbCrLf &
                "WHERE TABLE_TYPE = 'BASE TABLE' " & vbCrLf &
                "AND TABLE_CATALOG = " & SqlStr(cboParentDatabase.SelectedItem) & vbCrLf &
                "ORDER BY TABLE_NAME"

            Dim TableList = ModSQL.GetDataTable(Sql, GetConnectionString(cboParentDatabase.SelectedItem)).AsEnumerable.Select(Function(o) o("TableName")).ToList()
            With cboParentTable
                .Properties.Items.Clear()
                .Properties.Items.AddRange(TableList)
                .SelectedItem = ParentTable
            End With

        End If
    End Sub

    Private Sub LabelControl4_Click(sender As Object, e As EventArgs) Handles LabelControl4.Click

    End Sub
End Class
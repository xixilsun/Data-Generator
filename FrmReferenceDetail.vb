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
    Public _ColumnName As String = ""
    Public _DatabaseName As String = ""
    Public _ParentTable As String = ""
    Public _ParentID As String = ""

    Public Property ColumnName As String
        Set(ByVal value As String)
            _ColumnName = value
        End Set
        Get
            Return _ColumnName
        End Get
    End Property
    Public Property DatabaseName As String
        Set(ByVal value As String)
            _DatabaseName = value
        End Set
        Get
            Return _DatabaseName
        End Get
    End Property

    Public Property ParentTable As String
        Set(ByVal value As String)
            _ParentTable = value
        End Set
        Get
            Return _ParentTable
        End Get
    End Property

    Public Property ParentID As String
        Set(ByVal value As String)
            _ParentID = value
        End Set
        Get
            Return _ParentID
        End Get
    End Property

    Private Sub FrmReferenceDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtColumnName.Text = _ColumnName

        Dim Sql = "SELECT TABLE_NAME AS TableName" & vbCrLf &
                "FROM INFORMATION_SCHEMA.TABLES" & vbCrLf &
                "WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_CATALOG = " & SqlStr(_DatabaseName) & vbCrLf &
                "ORDER BY TableName"

        Dim TableList = ModSQL.GetDataTable(Sql, GetConnectionString(_DatabaseName)).AsEnumerable.Select(Function(o) o("TableName")).ToList()
        With cboParentTable
            .Properties.Items.Clear()
            .Properties.Items.AddRange(TableList)
            .SelectedItem = _ParentTable
        End With
    End Sub

    Private Sub TextEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles txtColumnName.EditValueChanged

    End Sub

    Private Sub cboParentTable_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboParentTable.SelectedIndexChanged

    End Sub

    Private Sub cboParentID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboParentID.SelectedIndexChanged

    End Sub
End Class
﻿Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid
Public Class FrmReferenceDetail
    Private _frmMain As FrmMain
    Private _gv As GridView
    Private _currentRowHandle As Integer

    Private _ColumnName As String = ""
    Private _ParentDatabase As String = ""
    Private _ParentTable As String = ""
    Private _ParentID As String = ""
    Private _Query As String = ""
    Private _HasReference As Boolean
    Private _IsOK As Boolean
    Private cboParentDatabase As New ComboBoxEdit
    Private cboParentTable As New ComboBoxEdit
    Private cboParentID As New ComboBoxEdit
    Private txtQuery As New MemoEdit

    Public WriteOnly Property FrmMain As FrmMain
        Set(ByVal value As FrmMain)
            _frmMain = value
        End Set
    End Property

    Public Property RowHandle As Integer
        Set(ByVal value As Integer)
            _currentRowHandle = value
        End Set
        Get
            Return _currentRowHandle
        End Get
    End Property

    Public Property Gv As GridView
        Set(ByVal value As GridView)
            _gv = value
        End Set
        Get
            Return _gv
        End Get
    End Property

    Private Sub FrmReferenceDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _ColumnName = _gv.GetRowCellValue(_currentRowHandle, "ColumnName").ToString
        _HasReference = CType(_gv.GetRowCellValue(_currentRowHandle, "HasReference"), Boolean)
        _ParentDatabase = _gv.GetRowCellValue(_currentRowHandle, "ParentDatabase").ToString
        _ParentTable = _gv.GetRowCellValue(_currentRowHandle, "ParentTable").ToString
        _ParentID = _gv.GetRowCellValue(_currentRowHandle, "ParentID").ToString
        _Query = _gv.GetRowCellValue(_currentRowHandle, "Query").ToString

        txtColumnName.Text = _ColumnName
        'SetDefaultComboBox()

        With cboReferenceBy
            .Properties.Items.Add("Reference ID")
            .Properties.Items.Add("Query")
            .SelectedIndex = If(_Query <> "", 1, 0)
        End With

        Me.KeyPreview = True
    End Sub

    Private Sub frmConvert_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Control AndAlso e.Shift AndAlso e.KeyCode = Keys.S Then
            btnSetting_Click(Nothing, Nothing)
        ElseIf e.Control AndAlso e.KeyCode = Keys.Delete Then
            btnClear_Click(Nothing, Nothing)
        ElseIf e.Control AndAlso e.KeyCode = Keys.S Then
            btnSave_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()
            'ElseIf e.Alt Then
            '    For Each ctrl As Control In Me.Controls
            '        If TypeOf ctrl Is ToolStrip Then
            '            Dim ts As ToolStrip = DirectCast(ctrl, ToolStrip)
            '            For Each item In ts.Items
            '                If TypeOf item Is ToolStripButton Then
            '                    Dim btn As ToolStripButton = DirectCast(item, ToolStripButton)
            '                    btn.Text = btn.Text & " (" & btn.Tag & ")"

            '                End If
            '            Next
            '        End If
            '    Next
        End If
    End Sub

    Private Sub SetDefaultComboBox()
        Dim DatabaseList = ModSQL.GetDataTable("SELECT name AS DatabaseName FROM Sysdatabases WHERE name LIKE 'HRdb%'", ModSQL.GetConnectionString("Master")).AsEnumerable.Select(Function(o) o("DatabaseName")).ToList()
        With cboParentDatabase
            .Properties.Items.AddRange(DatabaseList)
            .SelectedItem = If(_HasReference, _ParentDatabase, Nothing)
        End With

        If _HasReference And _Query = "" Then
            Dim Sql = "SELECT TABLE_NAME AS TableName" & vbCrLf &
                    "FROM INFORMATION_SCHEMA.TABLES" & vbCrLf &
                    "WHERE TABLE_TYPE = 'BASE TABLE' " & vbCrLf &
                    If(_HasReference, "AND TABLE_CATALOG = " & SqlStr(_ParentDatabase) & vbCrLf, "") &
                    "ORDER BY TABLE_NAME"

            Dim TableList = ModSQL.GetDataTable(Sql, GetConnectionString(_ParentDatabase)).AsEnumerable.Select(Function(o) o("TableName")).ToList()
            With cboParentTable
                .Properties.Items.AddRange(TableList)
                .SelectedItem = _ParentTable
            End With

            If _HasReference Then
                Sql = "SELECT column_name AS ColumnName" & vbCrLf &
                  "FROM INFORMATION_SCHEMA.COLUMNS" & vbCrLf &
                  "WHERE TABLE_NAME = " & SqlStr(cboParentTable.SelectedItem)

                Dim ColumnList = GetDataTable(Sql, GetConnectionString(_ParentDatabase)).AsEnumerable.Select(Function(o) o("ColumnName")).ToList
                With cboParentID
                    .Properties.Items.AddRange(ColumnList)
                    .SelectedItem = _ParentID
                End With
            End If
        End If
    End Sub

    Private Sub cboParentTable_SelectedIndexChanged(sender As Object, e As EventArgs)
        'Dim cboParentTable As ComboBoxEdit = CType(sender, ComboBoxEdit)
        If cboParentTable.Properties.Items.Contains(cboParentTable.SelectedItem) Then
            Dim Sql = "SELECT column_name AS ColumnName" & vbCrLf &
                  "FROM INFORMATION_SCHEMA.COLUMNS" & vbCrLf &
                  "WHERE TABLE_NAME = " & SqlStr(cboParentTable.SelectedItem)

            Dim ColumnList = GetDataTable(Sql, GetConnectionString(cboParentDatabase.SelectedItem)).AsEnumerable.Select(Function(o) o("ColumnName")).ToList
            With cboParentID
                .Properties.Items.Clear()
                .Properties.Items.AddRange(ColumnList)
                .SelectedItem = _ParentID
            End With

        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If (cboParentTable.SelectedItem <> "" AndAlso cboParentID.SelectedItem <> "" AndAlso cboParentDatabase.SelectedItem <> "") OrElse (cboParentDatabase.SelectedItem <> "" AndAlso txtQuery.Text <> "") Then
            _ParentDatabase = cboParentDatabase.SelectedItem
            _ParentTable = cboParentTable.SelectedItem
            _ParentID = cboParentID.SelectedItem
            _Query = txtQuery.Text
            _HasReference = True
            _IsOK = True
            Me.Dispose()
        ElseIf cboParentTable.SelectedItem = "" AndAlso cboParentID.SelectedItem = "" AndAlso cboParentDatabase.SelectedItem = "" AndAlso txtQuery.Text = "" Then
            _ParentDatabase = String.Empty
            _ParentTable = String.Empty
            _ParentID = String.Empty
            _Query = String.Empty
            _HasReference = False
            _IsOK = True
            Me.Dispose()
        Else
            MsgBox("Fill Input!", MsgBoxStyle.Critical)
        End If

        If _IsOK Then
            _gv.SetRowCellValue(_currentRowHandle, "HasReference", _HasReference)
            _gv.SetRowCellValue(_currentRowHandle, "ParentDatabase", _ParentDatabase)
            _gv.SetRowCellValue(_currentRowHandle, "ParentTable", _ParentTable)
            _gv.SetRowCellValue(_currentRowHandle, "ParentID", _ParentID)
            _gv.SetRowCellValue(_currentRowHandle, "Query", _Query)
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        cboParentDatabase.SelectedItem = Nothing
        cboParentTable.SelectedItem = Nothing
        cboParentID.SelectedItem = Nothing
        txtQuery.Text = ""
    End Sub

    Private Sub cboParentDatabase_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim cboParentDatabase = DirectCast(pnlReference.Controls.Item(1), ComboBoxEdit)
        Dim cboParentTable = DirectCast(pnlReference.Controls.Item(3), ComboBoxEdit)
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
                .SelectedItem = _ParentTable
            End With

        End If
    End Sub


    Private Sub cboReferenceBy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboReferenceBy.SelectedIndexChanged
        'Clear panel Reference
        pnlReference.Controls.Clear()
        If cboReferenceBy.SelectedItem = "Query" Then
            AddInputReference("Reference to DB")
            AddInputReferenceByQuery()
            cboParentDatabase = DirectCast(pnlReference.Controls.Item(1), ComboBoxEdit)
            txtQuery = DirectCast(pnlReference.Controls.Item(3), MemoEdit)

            'Set Default text for txtQuery
            SetDefaultComboBox()

            If _HasReference Then
                txtQuery.Text = _Query
            End If
        Else
            AddInputReference("Reference to DB")
            AddInputReference("Reference to Table")
            AddInputReference("Reference to ID")

            cboParentDatabase = DirectCast(pnlReference.Controls.Item(1), ComboBoxEdit)
            cboParentTable = DirectCast(pnlReference.Controls.Item(3), ComboBoxEdit)
            cboParentID = DirectCast(pnlReference.Controls.Item(5), ComboBoxEdit)

            SetDefaultComboBox()

            AddHandler cboParentDatabase.SelectedIndexChanged, AddressOf cboParentDatabase_SelectedIndexChanged
            AddHandler cboParentTable.SelectedIndexChanged, AddressOf cboParentTable_SelectedIndexChanged
        End If

    End Sub

    Private Sub AddInputReferenceByQuery()
        'Add Label
        Dim lbl As New Label With {
            .Text = "Query",
            .AutoSize = True,
            .Location = New Point(0, pnlReference.Controls.Count * 14 + 4)
        }
        pnlReference.Controls.Add(lbl)

        'Add Input box
        Dim memoEdit As New MemoEdit With {
            .Width = 257,
            .Height = 80,
            .Location = New Point(2, pnlReference.Controls.Count * 14 + 10)
        }
        pnlReference.Controls.Add(memoEdit)

        'Add Label
        Dim lbl2 As New Label With {
            .MaximumSize = New Size(270, 0),
            .Text = "Input #ColumnName# to indicate data from previous column on the same row",
            .ForeColor = Color.Blue,
            .AutoSize = True,
            .Location = New Point(0, pnlReference.Controls.Count * 14 + memoEdit.Height + 4)
        }
        pnlReference.Controls.Add(lbl2)
    End Sub

    Private Sub AddInputReference(labelText As String)
        Dim lbl As New Label With {
                .Text = labelText,
                .AutoSize = True,
                .Location = New Point(0, pnlReference.Controls.Count * 14 + 4)
            }
        Dim cbo As New ComboBoxEdit With {
                .Width = 138,
                .Location = New Point(122, pnlReference.Controls.Count * 14)
            }
        pnlReference.Controls.Add(lbl)
        pnlReference.Controls.Add(cbo)
    End Sub

    Private Sub btnSetting_Click(sender As Object, e As EventArgs) Handles btnSetting.Click
        Me.Dispose()
        _gv.FocusedRowHandle = _currentRowHandle
        _frmMain.OnSettingButtonClick(Nothing, Nothing)
    End Sub
End Class
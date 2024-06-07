Imports System.Data
Imports System.Linq
Public Class FrmReferenceDetail
    Private _ColumnName As String = ""
    Private _ParentDatabase As String = ""
    Private _ParentTable As String = ""
    Private _ParentID As String = ""
    Private _HasReference As Boolean
    Private _IsOK As Boolean

    Public ReadOnly Property IsOK As Boolean
        Get
            Return _IsOK
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
    Public Property ParentDatabase As String
        Set(ByVal value As String)
            _ParentDatabase = value
        End Set
        Get
            Return _ParentDatabase
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

    Public Property HasReference As Boolean
        Set(ByVal value As Boolean)
            _HasReference = value
        End Set
        Get
            Return _HasReference
        End Get
    End Property


    Private Sub FrmReferenceDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtColumnName.Text = _ColumnName

        Dim DatabaseList = ModSQL.GetDataTable("SELECT name AS DatabaseName FROM Sysdatabases WHERE name LIKE 'HRdb%'", ModSQL.GetConnectionString("Master")).AsEnumerable.Select(Function(o) o("DatabaseName")).ToList()
        With cboParentDatabase
            .Properties.Items.AddRange(DatabaseList)
            .SelectedItem = If(_HasReference, _ParentDatabase, Nothing)
        End With

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
                .SelectedItem = _ParentID
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
                .SelectedItem = _ParentTable
            End With

        End If
    End Sub
End Class
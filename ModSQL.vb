Imports System.Collections
Imports System.Data
Imports System.Data.SqlClient
Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.CompilerServices
Module ModSQL
    Public Function GetConnectionString(ByVal xAppName As String, ByVal xServer As String, ByVal xName As String, ByVal xUser As String, ByVal xPwd As String, ByVal xAuth As Boolean) As String
        If Not xAuth Then
            Return "Persist Security Info=False;Data Source= " & xServer & ";Initial Catalog= " & xName & ";User ID= " & xUser & "; PWD= " & xPwd & "; Application Name= " & xAppName
        End If

        Return "Persist Security Info=False;Data Source= " & xServer & ";Initial Catalog= " & xName & ";Integrated Security=SSPI; Application Name= " & xAppName
    End Function

    Public Function GetConnectionString(ByVal Optional xName As String = "HRdb_PS") As String
        Return GetConnectionString("DataGenerator", "172.18.3.14", xName, "", "", True)
    End Function


    Public Function GetDataTable(ByVal pstrSQL As String, ByVal p_ConnectionString As String, ByVal Optional TimeOut As Integer = 30, ByVal Optional p_WithSchema As Boolean = False, ByVal Optional p_IsErrorRaise As Boolean = False) As DataTable
        Dim sqlDataAdapter As SqlDataAdapter = Nothing
        Dim dataTable As DataTable = Nothing
        Dim text As String = ""
        Dim sqlConnection As SqlConnection = Nothing

        Try
            dataTable = New DataTable()
            text = p_ConnectionString
            sqlConnection = New SqlConnection(text)
            sqlConnection.Open()

            If sqlConnection.State = ConnectionState.Closed Then
                Throw New Exception("Connection was closed")
            End If

            sqlDataAdapter = New SqlDataAdapter(pstrSQL, sqlConnection)
            sqlDataAdapter.SelectCommand.CommandTimeout = TimeOut

            If p_WithSchema Then
                sqlDataAdapter.FillSchema(dataTable, SchemaType.Source)
            End If

            sqlDataAdapter.Fill(dataTable)
        Catch ex As Exception
            ProjectData.SetProjectError(ex)
            Dim ex2 As Exception = ex
            dataTable = Nothing

            If p_IsErrorRaise Then
                Throw ex2
            End If

            Interaction.MsgBox(ex2.Message & vbCrLf & pstrSQL, MsgBoxStyle.Critical)
            ProjectData.ClearProjectError()
        Finally

            If sqlConnection.State <> 0 Then
                sqlConnection.Close()
            End If

            sqlDataAdapter?.Dispose()
            sqlDataAdapter = Nothing
            sqlConnection?.Dispose()
            sqlConnection = Nothing
        End Try

        Return dataTable
    End Function

    Public Function GetOneData(ByVal strSQL As String, ByVal pDefaultValue As Object, ByVal pConnectionString As String) As Object
        Dim sqlConnection As SqlConnection = Nothing
        Dim sqlCommand As SqlCommand = Nothing
        Dim obj As Object = Nothing

        Try
            sqlConnection = New SqlConnection(pConnectionString)
            sqlConnection.Open()

            If sqlConnection.State = ConnectionState.Closed Then
                obj = Nothing
                Interaction.MsgBox("Connection was closed", MsgBoxStyle.Critical)
            Else
                sqlCommand = New SqlCommand(strSQL, sqlConnection)
                obj = RuntimeHelpers.GetObjectValue(sqlCommand.ExecuteScalar())
            End If

        Catch ex As Exception
            ProjectData.SetProjectError(ex)
            Dim ex2 As Exception = ex
            Throw ex2
        Finally
            sqlCommand?.Dispose()
            sqlCommand = Nothing
            sqlConnection.Close()
            sqlConnection = Nothing
        End Try

        If obj Is Nothing Then
            obj = RuntimeHelpers.GetObjectValue(pDefaultValue)
        End If

        Return obj
    End Function

    Public Sub ExecuteSQL(p_SQL As String, connectionString As String)
        Dim sqlCommand As SqlCommand = Nothing
        Dim sqlConnection As SqlConnection = Nothing
        Dim sqlTransaction As SqlTransaction = Nothing

        Try
            sqlConnection = New SqlConnection(connectionString)
            sqlConnection.Open()
            sqlTransaction = sqlConnection.BeginTransaction()
            Dim sqlCommand2 As SqlCommand = New SqlCommand()
            sqlCommand2.Connection = sqlConnection
            sqlCommand2.Transaction = sqlTransaction
            sqlCommand2.CommandType = CommandType.Text
            sqlCommand = sqlCommand2
            sqlCommand.CommandText = p_SQL
            sqlCommand.ExecuteNonQuery()
            sqlTransaction.Commit()
        Catch ex As SqlException
            ProjectData.SetProjectError(ex)
            Dim ex2 As SqlException = ex
            sqlTransaction?.Rollback()
            Throw ex2
        Catch ex3 As Exception
            ProjectData.SetProjectError(ex3)
            Dim ex4 As Exception = ex3
            sqlTransaction?.Rollback()
            Throw ex4
        Finally

            If sqlCommand IsNot Nothing Then
                sqlCommand.Dispose()
                sqlCommand = Nothing
            End If

            If sqlTransaction IsNot Nothing Then
                sqlTransaction.Dispose()
                sqlTransaction = Nothing
            End If

            If sqlConnection IsNot Nothing Then

                If sqlConnection.State <> 0 Then
                    sqlConnection.Close()
                End If

                sqlConnection.Dispose()
                sqlConnection = Nothing
            End If
        End Try
    End Sub

    Public Function ExecuteLoopSQL(sSQLs As ArrayList, connectionString As String) As Boolean
        Dim oBol As Boolean = False

        Dim sqlConnection As SqlConnection = Nothing
        Dim sqlTransaction As SqlTransaction = Nothing
        Dim sqlCommand As SqlCommand = Nothing

        Dim sSQL As String = ""

        Try

            sqlConnection = New SqlConnection(connectionString)
            sqlConnection.Open()
            sqlTransaction = sqlConnection.BeginTransaction()


            sqlCommand = New SqlClient.SqlCommand
            With sqlCommand
                .Connection = sqlConnection
                .Transaction = sqlTransaction

                'CmdSql.CommandType = CommandType.Text
                For Each sSQL In sSQLs
                    If sSQL <> "" Then
                        .CommandText = sSQL
                        .ExecuteNonQuery()
                    End If
                Next
            End With

            sqlTransaction.Commit()
            oBol = True

        Catch ex2 As SqlException
            sqlTransaction.Rollback()
            MsgBox(ex2.Message & vbNewLine & sSQL, MsgBoxStyle.Critical, "ExecuteLoopSQL")

        Catch ex As Exception
            sqlTransaction.Rollback()

            MsgBox(ex.Message & vbNewLine & sSQL, MsgBoxStyle.Critical, "ExecuteLoopSQL")
        Finally
            sqlConnection.Close()
            sqlConnection = Nothing

            If sqlCommand IsNot Nothing Then sqlCommand.Dispose()
            sqlCommand = Nothing

            If sqlTransaction IsNot Nothing Then sqlTransaction.Dispose()
            sqlTransaction = Nothing
        End Try

        Return oBol
    End Function
End Module

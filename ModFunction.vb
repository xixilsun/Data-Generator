Module ModFunction
    Public Function SqlStr(param As String) As String
        Return "'" & param & "'"
    End Function
End Module

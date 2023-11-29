Imports System.Data.OleDb
Module ModAcc


    Public Function GetConnectionString(ByVal Server As String, ByVal Database As String, ByVal AppName As String, Optional ByVal UseWindowsAuth As Boolean = True, Optional ByVal SQLUser As String = "", Optional ByVal SQLPass As String = "", Optional ByVal TimeOut As Integer = 30) As String
        Dim ConnStr As String = "Server=" & Server & "; Database=" & Database & "; Application Name=" & AppName & "; Connection Timeout=" & TimeOut & ";"

        If Not UseWindowsAuth Then
            ConnStr = ConnStr & "User Id=" & SQLUser & "; Password=" & SQLPass & ";"
        Else
            ConnStr = ConnStr & "Integrated Security=True;"
        End If

        Return ConnStr
    End Function

    Public Sub ExecuteSQL(ByVal SQLQuery As String, ByVal ConnStr As String, ByVal Optional TimeOut As Integer = 30)
        Dim oConn As OleDbConnection = Nothing
        Dim oTrans As OleDbTransaction = Nothing
        Dim oCmd As OleDbCommand = Nothing

        Try
            oConn = New OleDbConnection(ConnStr)
            oConn.Open()
            oTrans = oConn.BeginTransaction()
            oCmd = New OleDbCommand(SQLQuery, oConn, oTrans)
            oCmd.CommandTimeout = TimeOut
            oCmd.ExecuteNonQuery()
            oTrans.Commit()

        Catch es As OleDbException
            oTrans.Rollback()
            Throw es

        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If oConn.State <> ConnectionState.Closed Then oConn.Close()
            oConn.Dispose()
            oCmd.Dispose()
            oTrans.Dispose()
        End Try
    End Sub

    Public Function GetOneData(ByVal SQLQuery As String, ByVal DefaultValue As Object, ByVal ConnStr As String) As Object
        Dim oConn As OleDbConnection = Nothing
        Dim oCmd As OleDbCommand = Nothing
        Dim result As Object = Nothing

        Try

            oConn = New OleDbConnection(ConnStr)
            oConn.Open()
            oCmd = New OleDbCommand(SQLQuery, oConn)
            result = oCmd.ExecuteScalar()
            If result Is Nothing Then result = DefaultValue

        Catch es As OleDbException
            Throw es

        Catch ex As Exception
            Throw ex
        Finally
            If oConn.State <> ConnectionState.Closed Then oConn.Close()
            oConn.Dispose()
            oCmd.Dispose()
        End Try

        Return result

    End Function

    Public Function GetDataTable(ByVal SQLQuery As String, ByVal ConnStr As String, ByVal Optional TimeOut As Integer = 30, ByVal Optional SchemaOnly As Boolean = False) As DataTable
        Dim oConn As OleDbConnection = Nothing
        Dim oDt As New DataTable
        Dim oCmd As OleDbCommand = Nothing

        Try
            oConn = New OleDbConnection(ConnStr)
            oConn.Open()
            If SchemaOnly Then SQLQuery = "SET FMTONLY ON" & vbCrLf & SQLQuery & vbCrLf & "SET FMTONLY OFF"
            oCmd = New OleDbCommand(SQLQuery, oConn)
            oCmd.CommandTimeout = TimeOut

            If SchemaOnly Then
                oDt.Load(oCmd.ExecuteReader)
            Else
                Using dad As New OleDbDataAdapter(oCmd)
                    dad.Fill(oDt)
                    dad.Dispose()
                End Using
            End If

        Catch es As OleDbException
            Throw es

        Catch ex As Exception
            If Not ex.Message = "Conversion overflows." Then Throw ex
        Finally
            If oConn.State <> ConnectionState.Closed Then oConn.Close()
            oConn.Dispose()
            oCmd.Dispose()
        End Try

        Return oDt

    End Function

    Public Function HasRow(ByVal SQLQuery As String, ByVal ConnStr As String) As Boolean
        Dim oConn As OleDbConnection = Nothing
        Dim oCmd As OleDbCommand = Nothing
        Dim result As Boolean = False

        Try
            oConn = New OleDbConnection(ConnStr)
            oConn.Open()
            oCmd = New OleDbCommand(SQLQuery, oConn)

            Dim reader As OleDbDataReader = oCmd.ExecuteReader()
            If reader.Read Then result = True

        Catch es As OleDbException
            Throw es

        Catch ex As Exception
            Throw ex
        Finally
            If oConn.State <> ConnectionState.Closed Then oConn.Close()
            oConn.Dispose()
            oCmd.Dispose()
        End Try

        Return result
    End Function

    Public Function IsNulls(ByVal CheckValue As Object, DefaultValue As Object) As Object
        If IsNothing(CheckValue) Then
            Return DefaultValue
        ElseIf IsDBNull(CheckValue) Then
            Return DefaultValue
        Else
            Return CheckValue
        End If
    End Function

    Public Function IsNullsOrBlank(ByVal CheckValue As Object, DefaultValue As Object) As Object
        If IsNothing(CheckValue) Then
            Return DefaultValue
        ElseIf IsDBNull(CheckValue) Then
            Return DefaultValue
        ElseIf CheckValue.ToString = "" Then
            Return DefaultValue
        Else
            Return CheckValue
        End If
    End Function

    Public Function StrSQL(ByVal oValue As String) As String
        Return "'" & oValue & "'"
    End Function

    Public Function SQLDate(ByVal oDate As Date) As String
        Return "#" & oDate.Month & "/" & oDate.Day & "/" & oDate.Year & "#"
    End Function

    Public Function SQLDatetime(ByVal oDate As DateTime) As String
        Return "#" & oDate.Month & "/" & oDate.Day & "/" & oDate.Year & " " & oDate.Hour & ":" & oDate.Minute & ":" & oDate.Second & "#"
    End Function

End Module

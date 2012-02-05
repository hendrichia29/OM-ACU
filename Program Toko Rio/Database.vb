Imports MySql.Data.MySqlClient

Module DataBase
    ReadOnly connection_string As String = " server=localhost ; uid=root ; database=" & dbName & " ;Allow Zero Datetime=true " 'connection string
    Public dbconnection As New MySqlConnection(connection_string) 'database connection
    Public dbconmanual As New MySqlConnection(connection_string) 'database connection

    Public Sub open_connection()
        If dbconnection.State <> ConnectionState.Closed Then
            dbconnection.Close()
        End If
        dbconnection.Open()
    End Sub

    Public Function execute_reader(ByVal query As String) As MySqlDataReader
        open_connection()
        Dim sql_command As New MySqlCommand
        Try
            sql_command = New MySqlCommand(query, dbconnection)
        Catch ex As Exception
            MsgBox(ex, MsgBoxStyle.Critical, "Error!!!")
        End Try
        Return sql_command.ExecuteReader
    End Function

    Public Function execute_datatable(ByVal query As String) As DataTable
        open_connection()
        Dim adapter As New MySqlDataAdapter
        Dim datatable As New DataTable
        Try
            adapter = New MySqlDataAdapter(query, dbconnection)
            adapter.Fill(datatable)
            Return datatable
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Error!!!")
        End Try
        Return datatable
    End Function

    Public Function execute_update(ByVal query As String) As Integer
        open_connection()
        Dim sql_command As New MySqlCommand
        Try
            sql_command = New MySqlCommand(query, dbconnection)
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Error!!!")
        End Try
        Return sql_command.ExecuteNonQuery
    End Function

    Public Function execute_update_manual(ByVal query As String) As Integer
        Dim sql_command As New MySqlCommand
        sql_command = New MySqlCommand(query, dbconmanual)
        Return sql_command.ExecuteNonQuery
    End Function

    Public Function execute_reader_manual(ByVal query As String) As MySqlDataReader
        Dim sql_command As New MySqlCommand
        sql_command = New MySqlCommand(query, dbconmanual)
        Return sql_command.ExecuteReader
    End Function
End Module

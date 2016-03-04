Imports System.Data.SqlClient

Module ModuleConnect
    Public ds As New DataSet

    '---Kết nối database trên local---
    'Public Connectionstring As String = "Data Source=.;Initial Catalog=QL_Ban_Hang;Integrated Security=True"

    '---Kết nối database trên Somee.com---
    Public Connectionstring As String ="workstation id=QLBanHang.mssql.somee.com;packet size=4096;user id=duynps02822_SQLLogin_1;pwd=xsqz5k623l;data source=QLBanHang.mssql.somee.com;persist security info=False;initial catalog=QLBanHang"

    Public Sub ExecuteNonQuery(sql As String)
        Dim Connection As New SqlConnection(Connectionstring)
        Dim Command As New SqlCommand(sql, Connection)
        Connection.Open()
        Command.ExecuteNonQuery()
        Connection.Close()
    End Sub

    Public Sub Connect(sql As String, TableName As String)
        Dim Connection As New SqlConnection(Connectionstring)
        Dim DataAdapter As New SqlDataAdapter(sql, Connection)
        If ds.Tables.Contains(TableName) Then
            ds.Tables(TableName).Clear()
        End If
        DataAdapter.Fill(ds, TableName)
        Connection.Close()
    End Sub

End Module

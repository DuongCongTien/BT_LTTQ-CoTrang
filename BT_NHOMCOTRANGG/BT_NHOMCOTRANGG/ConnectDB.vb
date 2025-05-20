Imports System.Data.SqlClient

Public Class ConnectDB
    'Private constring As String = "Data Source=localhost;Initial Catalog=QuanLyMayBay;User ID=sa;Password=123456789"
    'Public Function getConnection() As SqlConnection
    '    Return New SqlConnection(constring)
    'End Function

    Public Shared conn As New SqlConnection("Data Source=localhost;Initial Catalog=QuanLyMayBay;User ID=sa;Password=123456789")
End Class

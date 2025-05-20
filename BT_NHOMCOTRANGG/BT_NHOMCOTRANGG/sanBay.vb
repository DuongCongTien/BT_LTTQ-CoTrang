Imports System.Data.Common
Imports System.Data.SqlClient

Public Class sanBay

    Private Sub LoadData()
        Try
            If ConnectDB.conn.State = ConnectionState.Open Then ConnectDB.conn.Close()
            ConnectDB.conn.Open()

            Dim cmd As New SqlCommand("SELECT * FROM sanBay", ConnectDB.conn)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable()
            da.Fill(dt)
            DataGrid1.DataSource = dt
        Catch ex As Exception
            MessageBox.Show("Lỗi kết nối: " & ex.Message)
        Finally
            If ConnectDB.conn.State = ConnectionState.Open Then ConnectDB.conn.Close()
        End Try
    End Sub

    Private Sub sanBay_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGrid1.Font = New Font("Segoe UI", 12)
        LoadData()
    End Sub

    ' Hiển thị dữ liệu khi click
    Private Sub DataGrid1_Click(sender As Object, e As EventArgs) Handles DataGrid1.Click
        Dim i As Integer = DataGrid1.CurrentRowIndex
        txtMaSB.Text = DataGrid1.Item(i, 0).ToString()
        txtTenSB.Text = DataGrid1.Item(i, 1).ToString()
        txtDiaChiSB.Text = DataGrid1.Item(i, 2).ToString()
    End Sub

    ' Thêm
    Private Sub btnThem_Click(sender As Object, e As EventArgs) Handles btnThem.Click
        Try
            If ConnectDB.conn.State = ConnectionState.Open Then ConnectDB.conn.Close()
            ConnectDB.conn.Open()

            Dim sql As String = "INSERT INTO sanBay (maSanBay, tenSanBay, diaChi) VALUES (@ma, @ten, @dc)"
            Dim cmd As New SqlCommand(sql, ConnectDB.conn)
            cmd.Parameters.AddWithValue("@ma", txtMaSB.Text)
            cmd.Parameters.AddWithValue("@ten", txtTenSB.Text)
            cmd.Parameters.AddWithValue("@dc", txtDiaChiSB.Text)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Thêm thành công!")
            LoadData()
        Catch ex As Exception
            MessageBox.Show("Lỗi thêm: " & ex.Message)
        Finally
            If ConnectDB.conn.State = ConnectionState.Open Then ConnectDB.conn.Close()
        End Try
    End Sub

    ' Sửa
    Private Sub btnSua_Click(sender As Object, e As EventArgs) Handles btnSua.Click
        Try
            If ConnectDB.conn.State = ConnectionState.Open Then ConnectDB.conn.Close()
            ConnectDB.conn.Open()

            Dim sql As String = "UPDATE sanBay SET tenSanBay = @ten, diaChi = @diachi WHERE maSanBay = @ma"
            Dim cmd As New SqlCommand(sql, ConnectDB.conn)
            cmd.Parameters.AddWithValue("@ma", txtMaSB.Text)
            cmd.Parameters.AddWithValue("@ten", txtTenSB.Text)
            cmd.Parameters.AddWithValue("@diachi", txtDiaChiSB.Text)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Cập nhật thành công!")
            LoadData()
        Catch ex As Exception
            MessageBox.Show("Lỗi sửa: " & ex.Message)
        Finally
            If ConnectDB.conn.State = ConnectionState.Open Then ConnectDB.conn.Close()
        End Try
    End Sub

    ' Xóa
    Private Sub btnXoa_Click(sender As Object, e As EventArgs) Handles btnXoa.Click
        If MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Try
                If ConnectDB.conn.State = ConnectionState.Open Then ConnectDB.conn.Close()
                ConnectDB.conn.Open()

                Dim sql As String = "DELETE FROM sanBay WHERE maSanBay = @ma"
                Dim cmd As New SqlCommand(sql, ConnectDB.conn)
                cmd.Parameters.AddWithValue("@ma", txtMaSB.Text)
                cmd.ExecuteNonQuery()
                MessageBox.Show("Xóa thành công!")
                LoadData()
            Catch ex As Exception
                MessageBox.Show("Lỗi xóa: " & ex.Message)
            Finally
                If ConnectDB.conn.State = ConnectionState.Open Then ConnectDB.conn.Close()
            End Try
        End If
    End Sub

    Private Sub btnThoat_Click(sender As Object, e As EventArgs) Handles btnThoat.Click
        If MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận thoát", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub btnTimKiem_Click(sender As Object, e As EventArgs) Handles btnTimKiem.Click
        Try
            If ConnectDB.conn.State = ConnectionState.Open Then ConnectDB.conn.Close()
            ConnectDB.conn.Open()

            Dim sql As String = "SELECT * FROM sanBay WHERE tenSanBay COLLATE SQL_Latin1_General_CP1_CI_AS LIKE @keyword"
            Dim cmd As New SqlCommand(sql, ConnectDB.conn)
            cmd.Parameters.AddWithValue("@keyword", "%" & txtTimKiem.Text & "%")

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable()
            da.Fill(dt)
            DataGrid1.DataSource = dt
        Catch ex As Exception
            MessageBox.Show("Lỗi tìm kiếm: " & ex.Message)
        Finally
            If ConnectDB.conn.State = ConnectionState.Open Then ConnectDB.conn.Close()
        End Try
    End Sub


End Class

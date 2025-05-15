Imports System.Data.SqlClient

Public Class hangHangKhong
    Private Sub LoadData()
        Try
            If ConnectDB.conn.State = ConnectionState.Open Then ConnectDB.conn.Close()
            ConnectDB.conn.Open()

            Dim cmd As New SqlCommand("SELECT * FROM hangHangKhong", ConnectDB.conn)
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

    Private Sub hangHangKhong_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGrid1.Font = New Font("Segoe UI", 12)
        LoadData()
    End Sub

    ' Hiển thị dữ liệu khi click
    Private Sub DataGrid1_Click(sender As Object, e As EventArgs) Handles DataGrid1.Click
        Dim i As Integer = DataGrid1.CurrentRowIndex
        txtHangHangKhong.Text = DataGrid1.Item(i, 0).ToString()
        txtTenHangHangKhong.Text = DataGrid1.Item(i, 1).ToString()
        txtQuocGia.Text = DataGrid1.Item(i, 2).ToString()
    End Sub

    ' Thêm
    Private Sub btnThem_Click(sender As Object, e As EventArgs) Handles btnThem.Click
        Try
            If ConnectDB.conn.State = ConnectionState.Open Then ConnectDB.conn.Close()
            ConnectDB.conn.Open()

            Dim sql As String = "INSERT INTO hangHangKhong (maHangHangKhong, tenHangHangKhong,quocGia) VALUES (@maHangHangKhong, @tenHangHangKhong, @quocGia)"
            Dim cmd As New SqlCommand(sql, ConnectDB.conn)
            cmd.Parameters.AddWithValue("@maHangHangKhong", txtHangHangKhong.Text)
            cmd.Parameters.AddWithValue("@tenHangHangKhong", txtTenHangHangKhong.Text)
            cmd.Parameters.AddWithValue("@quocGia", txtQuocGia.Text)
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

            Dim sql As String = "UPDATE hangHangKhong SET tenHangHangKhong = @tenHangHangKhong, quocGia = @quocGia WHERE maHangHangKhong = @maHangHangKhong"
            Dim cmd As New SqlCommand(sql, ConnectDB.conn)
            cmd.Parameters.AddWithValue("@maHangHangKhong", txtHangHangKhong.Text)
            cmd.Parameters.AddWithValue("@tenHangHangKhong", txtTenHangHangKhong.Text)
            cmd.Parameters.AddWithValue("@quocGia", txtQuocGia.Text)
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

                Dim sql As String = "DELETE FROM hangHangKhong WHERE maHangHangKhong = @maHangHangKhong"
                Dim cmd As New SqlCommand(sql, ConnectDB.conn)
                cmd.Parameters.AddWithValue("@maHangHangKhong", txtHangHangKhong.Text)
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
End Class
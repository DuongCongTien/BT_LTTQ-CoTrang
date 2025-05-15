Imports System.Data.SqlClient

Public Class hoaDon

    Private Sub LoadData()
        Try
            If ConnectDB.conn.State = ConnectionState.Open Then ConnectDB.conn.Close()
            ConnectDB.conn.Open()

            Dim cmd As New SqlCommand("SELECT * FROM hoaDon", ConnectDB.conn)
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

    Private Sub ChuyenBay_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGrid1.Font = New Font("Segoe UI", 12)
        LoadData()
    End Sub

    ' Hiển thị dữ liệu khi click
    Private Sub DataGrid1_Click(sender As Object, e As EventArgs) Handles DataGrid1.Click
        Dim i As Integer = DataGrid1.CurrentRowIndex
        txtMaHoaDon.Text = DataGrid1.Item(i, 0).ToString()
        txtMaVe.Text = DataGrid1.Item(i, 1).ToString()
        txtPhuongThucThanhToan.Text = DataGrid1.Item(i, 2).ToString()
        txtTongTien.Text = DataGrid1.Item(i, 3).ToString()
        txtNgayLap.Text = DataGrid1.Item(i, 4).ToString()
        txtTinhTrangThanhToan.Text = DataGrid1.Item(i, 5).ToString()
    End Sub

    ' Thêm
    Private Sub btnThem_Click(sender As Object, e As EventArgs) Handles btnThem.Click
        Try
            If ConnectDB.conn.State = ConnectionState.Open Then ConnectDB.conn.Close()
            ConnectDB.conn.Open()

            Dim sql As String = "INSERT INTO hoaDon (maHoaDon, maVe, phuongThucThanhToan, tongTien, ngayLap, tinhTrangThanhToan) VALUES (@maHoaDon, @maVe, @phuongThucThanhToan, @tongTien,  @ngayLap, @tinhTrangThanhToan)"
            Dim cmd As New SqlCommand(sql, ConnectDB.conn)
            cmd.Parameters.AddWithValue("@maHoaDon", txtMaHoaDon.Text)
            cmd.Parameters.AddWithValue("@maVe", txtMaVe.Text)
            cmd.Parameters.AddWithValue("@phuongThucThanhToan", txtPhuongThucThanhToan.Text)
            cmd.Parameters.AddWithValue("@tongTien", txtTongTien.Text)
            cmd.Parameters.AddWithValue("@ngayLap", DateTime.Parse(txtNgayLap.Text))
            cmd.Parameters.AddWithValue("@tinhTrangThanhToan", txtTinhTrangThanhToan.Text)
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

            Dim sql As String = "UPDATE hoaDon SET maHoaDon = @maHoaDon, maVe = @maVe, phuongThucThanhToan = @phuongThucThanhToan, tongTien = @tongTien, ngayLap = @ngayLap, tinhTrangThanhToan = @tinhTrangThanhToan WHERE maHoaDon = @maHoaDon"
            Dim cmd As New SqlCommand(sql, ConnectDB.conn)
            cmd.Parameters.AddWithValue("@maHoaDon", txtMaHoaDon.Text)
            cmd.Parameters.AddWithValue("@maVe", txtMaVe.Text)
            cmd.Parameters.AddWithValue("@phuongThucThanhToan", txtPhuongThucThanhToan.Text)
            cmd.Parameters.AddWithValue("@tongTien", txtTongTien.Text)
            cmd.Parameters.AddWithValue("@ngayLap", DateTime.Parse(txtNgayLap.Text))
            cmd.Parameters.AddWithValue("@tinhTrangThanhToan", txtTinhTrangThanhToan.Text)
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

                Dim sql As String = "DELETE FROM hoaDon WHERE maHoaDon = @maHoaDon"
                Dim cmd As New SqlCommand(sql, ConnectDB.conn)
                cmd.Parameters.AddWithValue("@maHoaDon", txtMaHoaDon.Text)
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
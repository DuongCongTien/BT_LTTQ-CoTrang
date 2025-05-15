Imports System.Data.SqlClient

Public Class ChuyenBay
    Private Sub LoadData()
        Try
            If ConnectDB.conn.State = ConnectionState.Open Then ConnectDB.conn.Close()
            ConnectDB.conn.Open()

            Dim cmd As New SqlCommand("SELECT * FROM chuyenBay", ConnectDB.conn)
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
        txtMaChuyenBay.Text = DataGrid1.Item(i, 0).ToString()
        txtMaSanBayDi.Text = DataGrid1.Item(i, 1).ToString()
        txtMaSanBayDen.Text = DataGrid1.Item(i, 2).ToString()
        txtMaHangHangKhong.Text = DataGrid1.Item(i, 3).ToString()
        txtGioKhoiHanh.Text = DataGrid1.Item(i, 4).ToString()
        txtGioDen.Text = DataGrid1.Item(i, 5).ToString()
        txtTrangThai.Text = DataGrid1.Item(i, 6).ToString()
        txtSoGheTrong.Text = DataGrid1.Item(i, 7).ToString()
    End Sub

    ' Thêm
    Private Sub btnThem_Click(sender As Object, e As EventArgs) Handles btnThem.Click
        Try
            If ConnectDB.conn.State = ConnectionState.Open Then ConnectDB.conn.Close()
            ConnectDB.conn.Open()

            Dim sql As String = "INSERT INTO chuyenBay (maChuyenBay, maSanBayDi, maSanBayDen, maHangHangKhong, gioKhoiHanh, gioDen, trangThaiChuyenBay, soGheTrong) VALUES (@maChuyenBay, @maSanBayDi, @maSanBayDen, @maHangHangKhong, @gioKhoiHanh, @gioDen, @trangThaiChuyenBay, @soGheTrong)"
            Dim cmd As New SqlCommand(sql, ConnectDB.conn)
            cmd.Parameters.AddWithValue("@maChuyenBay", txtMaChuyenBay.Text)
            cmd.Parameters.AddWithValue("@maSanBayDi", txtMaSanBayDi.Text)
            cmd.Parameters.AddWithValue("@maSanBayDen", txtMaSanBayDen.Text)
            cmd.Parameters.AddWithValue("@maHangHangKhong", txtMaHangHangKhong.Text)
            cmd.Parameters.AddWithValue("@gioKhoiHanh", DateTime.Parse(txtGioKhoiHanh.Text))
            cmd.Parameters.AddWithValue("@gioDen", DateTime.Parse(txtGioDen.Text))
            cmd.Parameters.AddWithValue("@trangThaiChuyenBay", txtTrangThai.Text)
            cmd.Parameters.AddWithValue("@soGheTrong", txtSoGheTrong.Text)
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

            Dim sql As String = "UPDATE chuyenBay SET maSanBayDi = @maSanBayDi, maSanBayDen = @maSanBayDen, maHangHangKhong = @maHangHangKhong, gioKhoiHanh = @gioKhoiHanh, gioDen = @gioDen, trangThaiChuyenBay = @trangThaiChuyenBay, soGheTrong = @soGheTrong WHERE maChuyenBay = @maChuyenBay"
            Dim cmd As New SqlCommand(sql, ConnectDB.conn)
            cmd.Parameters.AddWithValue("@maChuyenBay", txtMaChuyenBay.Text)
            cmd.Parameters.AddWithValue("@maSanBayDi", txtMaSanBayDi.Text)
            cmd.Parameters.AddWithValue("@maSanBayDen", txtMaSanBayDen.Text)
            cmd.Parameters.AddWithValue("@maHangHangKhong", txtMaHangHangKhong.Text)
            cmd.Parameters.AddWithValue("@gioKhoiHanh", DateTime.Parse(txtGioKhoiHanh.Text))
            cmd.Parameters.AddWithValue("@gioDen", DateTime.Parse(txtGioDen.Text))
            cmd.Parameters.AddWithValue("@trangThaiChuyenBay", txtTrangThai.Text)
            cmd.Parameters.AddWithValue("@soGheTrong", txtSoGheTrong.Text)
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

                Dim sql As String = "DELETE FROM chuyenBay WHERE maChuyenBay = @maChuyenBay"
                Dim cmd As New SqlCommand(sql, ConnectDB.conn)
                cmd.Parameters.AddWithValue("@maChuyenBay", txtMaChuyenBay.Text)
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
Imports System.Data.SqlClient

Public Class veMayBay
    Private Sub LoadData()
        Try
            If ConnectDB.conn.State = ConnectionState.Open Then ConnectDB.conn.Close()
            ConnectDB.conn.Open()

            Dim cmd As New SqlCommand("SELECT * FROM veMayBay", ConnectDB.conn)
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

    Private Sub veMayBay_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGrid1.Font = New Font("Segoe UI", 12)
        LoadData()
    End Sub

    ' Hiển thị dữ liệu khi click
    Private Sub DataGrid1_Click(sender As Object, e As EventArgs) Handles DataGrid1.Click
        Dim i As Integer = DataGrid1.CurrentRowIndex
        txtMaVe.Text = DataGrid1.Item(i, 0).ToString()
        txtMaChuyenBay.Text = DataGrid1.Item(i, 1).ToString()
        txtMaKhachHang.Text = DataGrid1.Item(i, 2).ToString()
        txtNgayDat.Text = DataGrid1.Item(i, 3).ToString()
        txtGiaVe.Text = DataGrid1.Item(i, 4).ToString()
        txtTrangThai.Text = DataGrid1.Item(i, 5).ToString()
        txtSoGhe.Text = DataGrid1.Item(i, 6).ToString()
        txtLoaiVe.Text = DataGrid1.Item(i, 7).ToString()
        txtHanHanhLy.Text = DataGrid1.Item(i, 8).ToString()

        Dim loaiVeDi As Integer = Integer.Parse(DataGrid1.Item(i, 9).ToString())
        If loaiVeDi = 1 Then
            cboLoaiVeDi.Text = "Một chiều"
        ElseIf loaiVeDi = 2 Then
            cboLoaiVeDi.Text = "Khứ hồi"
        End If

    End Sub

    Private Sub btnThem_Click(sender As Object, e As EventArgs) Handles btnThem.Click
        Try
            If ConnectDB.conn.State = ConnectionState.Open Then ConnectDB.conn.Close()
            ConnectDB.conn.Open()

            Dim loaiVeDi As Integer = If(cboLoaiVeDi.Text = "Một chiều", 1, 2)

            Dim sql As String = "INSERT INTO veMayBay VALUES (@maVe, @maChuyenBay, @maKH, @ngayDat, @giaVe, @trangThai, @soGhe, @loaiVe, @hanHanhLy, @loaiVeDi)"
            Dim cmd As New SqlCommand(sql, ConnectDB.conn)

            cmd.Parameters.AddWithValue("@maVe", txtMaVe.Text)
            cmd.Parameters.AddWithValue("@maChuyenBay", txtMaChuyenBay.Text)
            cmd.Parameters.AddWithValue("@maKH", txtMaKhachHang.Text)
            cmd.Parameters.AddWithValue("@ngayDat", DateTime.Parse(txtNgayDat.Text))
            cmd.Parameters.AddWithValue("@giaVe", Decimal.Parse(txtGiaVe.Text))
            cmd.Parameters.AddWithValue("@trangThai", txtTrangThai.Text)
            cmd.Parameters.AddWithValue("@soGhe", txtSoGhe.Text)
            cmd.Parameters.AddWithValue("@loaiVe", txtLoaiVe.Text)
            cmd.Parameters.AddWithValue("@hanHanhLy", Integer.Parse(txtHanHanhLy.Text))
            cmd.Parameters.AddWithValue("@loaiVeDi", loaiVeDi)

            cmd.ExecuteNonQuery()
            MessageBox.Show("Thêm vé thành công!")
            LoadData()
        Catch ex As Exception
            MessageBox.Show("Lỗi thêm: " & ex.Message)
        Finally
            If ConnectDB.conn.State = ConnectionState.Open Then ConnectDB.conn.Close()
        End Try
    End Sub

    Private Sub btnSua_Click(sender As Object, e As EventArgs) Handles btnSua.Click
        Try
            If ConnectDB.conn.State = ConnectionState.Open Then ConnectDB.conn.Close()
            ConnectDB.conn.Open()

            Dim loaiVeDi As Integer = If(cboLoaiVeDi.Text = "Một chiều", 1, 2)

            Dim sql As String = "UPDATE veMayBay SET maChuyenBay=@maChuyenBay, maKH=@maKH, ngayDat=@ngayDat, giaVe=@giaVe, trangThai=@trangThai, soGhe=@soGhe, loaiVe=@loaiVe, hanHanhLy=@hanHanhLy, loaiVeDi=@loaiVeDi WHERE maVe=@maVe"
            Dim cmd As New SqlCommand(sql, ConnectDB.conn)

            cmd.Parameters.AddWithValue("@maVe", txtMaVe.Text)
            cmd.Parameters.AddWithValue("@maChuyenBay", txtMaChuyenBay.Text)
            cmd.Parameters.AddWithValue("@maKH", txtMaKhachHang.Text)
            cmd.Parameters.AddWithValue("@ngayDat", DateTime.Parse(txtNgayDat.Text))
            cmd.Parameters.AddWithValue("@giaVe", Decimal.Parse(txtGiaVe.Text))
            cmd.Parameters.AddWithValue("@trangThai", txtTrangThai.Text)
            cmd.Parameters.AddWithValue("@soGhe", txtSoGhe.Text)
            cmd.Parameters.AddWithValue("@loaiVe", txtLoaiVe.Text)
            cmd.Parameters.AddWithValue("@hanHanhLy", Integer.Parse(txtHanHanhLy.Text))
            cmd.Parameters.AddWithValue("@loaiVeDi", loaiVeDi)

            cmd.ExecuteNonQuery()
            MessageBox.Show("Cập nhật thành công!")
            LoadData()
        Catch ex As Exception
            MessageBox.Show("Lỗi sửa: " & ex.Message)
        Finally
            If ConnectDB.conn.State = ConnectionState.Open Then ConnectDB.conn.Close()
        End Try
    End Sub

    Private Sub btnXoa_Click(sender As Object, e As EventArgs) Handles btnXoa.Click
        Try
            If txtMaVe.Text = "" Then
                MessageBox.Show("Vui lòng chọn vé cần xóa.")
                Return
            End If

            If MessageBox.Show("Bạn có chắc chắn muốn xóa vé này?", "Xác nhận xóa", MessageBoxButtons.YesNo) = DialogResult.No Then
                Return
            End If

            If ConnectDB.conn.State = ConnectionState.Open Then ConnectDB.conn.Close()
            ConnectDB.conn.Open()

            Dim sql As String = "DELETE FROM veMayBay WHERE maVe=@maVe"
            Dim cmd As New SqlCommand(sql, ConnectDB.conn)
            cmd.Parameters.AddWithValue("@maVe", txtMaVe.Text)

            cmd.ExecuteNonQuery()
            MessageBox.Show("Xóa thành công!")
            LoadData()
        Catch ex As Exception
            MessageBox.Show("Lỗi xóa: " & ex.Message)
        Finally
            If ConnectDB.conn.State = ConnectionState.Open Then ConnectDB.conn.Close()
        End Try
    End Sub


    Private Sub btnThoat_Click(sender As Object, e As EventArgs) Handles btnThoat.Click
        If MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận thoát", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub
End Class
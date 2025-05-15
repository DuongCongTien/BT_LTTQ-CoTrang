Imports System.Data.SqlClient

Public Class khachHang
    Private Sub LoadData()
        Try
            If ConnectDB.conn.State = ConnectionState.Open Then ConnectDB.conn.Close()
            ConnectDB.conn.Open()

            Dim cmd As New SqlCommand("SELECT * FROM khachHang", ConnectDB.conn)
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

    Private Sub khachHang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGrid1.Font = New Font("Segoe UI", 12)
        LoadData()
    End Sub

    ' Hiển thị dữ liệu khi click
    Private Sub DataGrid1_Click(sender As Object, e As EventArgs) Handles DataGrid1.Click
        Dim i As Integer = DataGrid1.CurrentRowIndex
        txtMaKhachHang.Text = DataGrid1.Item(i, 0).ToString()
        txtTenKhachHang.Text = DataGrid1.Item(i, 1).ToString()
        txtCCCD.Text = DataGrid1.Item(i, 2).ToString()
        txtEmail.Text = DataGrid1.Item(i, 3).ToString()
        txtSDT.Text = DataGrid1.Item(i, 4).ToString()
        txtNgaySinh.Text = DataGrid1.Item(i, 5).ToString()
        Dim gioiTinh As String = DataGrid1.Item(i, 6).ToString()
        If gioiTinh = "M" Then
            radNam.Checked = True
        ElseIf gioiTinh = "F" Then
            radNu.Checked = True
        End If
        txtLoaiKhachHang.Text = DataGrid1.Item(i, 7).ToString()
    End Sub

    Private Sub btnThem_Click(sender As Object, e As EventArgs) Handles btnThem.Click
        Try
            If ConnectDB.conn.State = ConnectionState.Open Then ConnectDB.conn.Close()
            ConnectDB.conn.Open()

            Dim sql As String = "INSERT INTO khachHang (maKH, tenKH, cccd, email, soDienThoai, ngaySinh, gioiTinh, loaiKH) 
                            VALUES (@maKH, @tenKH, @cccd, @email, @soDT, @ngaySinh, @gioiTinh, @loaiKH)"
            Dim cmd As New SqlCommand(sql, ConnectDB.conn)

            cmd.Parameters.AddWithValue("@maKH", Integer.Parse(txtMaKhachHang.Text))
            cmd.Parameters.AddWithValue("@tenKH", txtTenKhachHang.Text)
            cmd.Parameters.AddWithValue("@cccd", txtCCCD.Text)
            cmd.Parameters.AddWithValue("@email", txtEmail.Text)
            cmd.Parameters.AddWithValue("@soDT", txtSDT.Text)
            cmd.Parameters.AddWithValue("@ngaySinh", DateTime.Parse(txtNgaySinh.Text))
            cmd.Parameters.AddWithValue("@gioiTinh", If(radNam.Checked, "M", "F"))
            cmd.Parameters.AddWithValue("@loaiKH", txtLoaiKhachHang.Text)

            cmd.ExecuteNonQuery()
            MessageBox.Show("Thêm thành công!")
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

            Dim sql As String = "UPDATE khachHang SET tenKH=@tenKH, cccd=@cccd, email=@email, soDienThoai=@soDT, 
                            ngaySinh=@ngaySinh, gioiTinh=@gioiTinh, loaiKH=@loaiKH WHERE maKH=@maKH"
            Dim cmd As New SqlCommand(sql, ConnectDB.conn)

            cmd.Parameters.AddWithValue("@maKH", Integer.Parse(txtMaKhachHang.Text))
            cmd.Parameters.AddWithValue("@tenKH", txtTenKhachHang.Text)
            cmd.Parameters.AddWithValue("@cccd", txtCCCD.Text)
            cmd.Parameters.AddWithValue("@email", txtEmail.Text)
            cmd.Parameters.AddWithValue("@soDT", txtSDT.Text)
            cmd.Parameters.AddWithValue("@ngaySinh", DateTime.Parse(txtNgaySinh.Text))
            cmd.Parameters.AddWithValue("@gioiTinh", If(radNam.Checked, "M", "F"))
            cmd.Parameters.AddWithValue("@loaiKH", txtLoaiKhachHang.Text)
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
        If MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Try
                If ConnectDB.conn.State = ConnectionState.Open Then ConnectDB.conn.Close()
                ConnectDB.conn.Open()

                Dim cmd As New SqlCommand("DELETE FROM khachHang WHERE maKH = @maKH", ConnectDB.conn)
                cmd.Parameters.AddWithValue("@maKH", Integer.Parse(txtMaKhachHang.Text))
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
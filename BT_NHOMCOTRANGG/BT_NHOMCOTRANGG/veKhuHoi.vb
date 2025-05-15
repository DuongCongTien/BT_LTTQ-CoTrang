Imports System.Data.SqlClient

Public Class veKhuHoi

    Private Sub LoadData()
        Try
            If ConnectDB.conn.State = ConnectionState.Open Then ConnectDB.conn.Close()
            ConnectDB.conn.Open()

            Dim cmd As New SqlCommand("SELECT * FROM veKhuHoi", ConnectDB.conn)
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

    Private Sub veKhuHoi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGrid1.Font = New Font("Segoe UI", 12)
        LoadData()
    End Sub

    ' Hiển thị dữ liệu khi click
    Private Sub DataGrid1_Click(sender As Object, e As EventArgs) Handles DataGrid1.Click
        Dim i As Integer = DataGrid1.CurrentRowIndex
        txtMaVeDi.Text = DataGrid1.Item(i, 0).ToString()
        txtMaVeVe.Text = DataGrid1.Item(i, 1).ToString()
    End Sub

    ' Thêm
    Private Sub btnThem_Click(sender As Object, e As EventArgs) Handles btnThem.Click
        Try
            If ConnectDB.conn.State = ConnectionState.Open Then ConnectDB.conn.Close()
            ConnectDB.conn.Open()

            Dim sql As String = "INSERT INTO veKhuHoi(maVeDi, maVeVe) VALUES (@maVeDi, @maVeVe)"
            Dim cmd As New SqlCommand(sql, ConnectDB.conn)
            cmd.Parameters.AddWithValue("@maVeDi", txtMaVeDi.Text)
            cmd.Parameters.AddWithValue("@maVeVe", txtMaVeVe.Text)
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

            Dim sql As String = "UPDATE veKhuHoi SET maVeDi = @maVeDi, maVeVe = @maVeVe WHERE maVeDi = @maVeDi"
            Dim cmd As New SqlCommand(sql, ConnectDB.conn)
            cmd.Parameters.AddWithValue("@maVeDi", txtMaVeDi.Text)
            cmd.Parameters.AddWithValue("@maVeVe", txtMaVeVe.Text)
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

                Dim sql As String = "DELETE FROM veKhuHoi WHERE maVeDi = @maVeDi"
                Dim cmd As New SqlCommand(sql, ConnectDB.conn)
                cmd.Parameters.AddWithValue("@maVeDi", txtMaVeDi.Text)
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
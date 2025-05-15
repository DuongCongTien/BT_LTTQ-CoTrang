Public Class Form1
    Private Sub btnKhachHang_Click(sender As Object, e As EventArgs)
        Dim KhachHang As New khachHang()
        KhachHang.Show()
    End Sub

    Private Sub btnHoaDon_Click(sender As Object, e As EventArgs)
        Dim HoaDon As New hoaDon()
        HoaDon.Show()
    End Sub

    Private Sub btnHangHangKhong_Click(sender As Object, e As EventArgs)
        Dim HangHangKhong As New hangHangKhong()
        HangHangKhong.Show()
    End Sub

    Private Sub btnChuyenBay_Click(sender As Object, e As EventArgs)
        Dim ChuyenBay As New ChuyenBay()
        ChuyenBay.Show()
    End Sub

    Private Sub btnVeMayBay_Click(sender As Object, e As EventArgs)
        Dim VeMayBay As New veMayBay()
        VeMayBay.Show()
    End Sub

    Private Sub btnVeKhuHoi_Click(sender As Object, e As EventArgs)
        Dim VeKhuHoi As New veKhuHoi()
        VeKhuHoi.Show()
    End Sub

    Private Sub btnSanBay_Click(sender As Object, e As EventArgs)
        Dim SanBay As New sanBay()
        SanBay.Show()
    End Sub


End Class

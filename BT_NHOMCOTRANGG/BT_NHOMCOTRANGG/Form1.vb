Public Class Form1


    Private Sub ThêmVéMáyBayToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ThêmVéMáyBayToolStripMenuItem.Click
        Dim f As New veMayBay
        f.Show()
    End Sub

    Private Sub ThêmKháchHàngToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ThêmKháchHàngToolStripMenuItem.Click
        Dim f As New khachHang
        f.Show()
    End Sub

    Private Sub SânBayToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SânBayToolStripMenuItem.Click
        Dim f As New sanBay
        f.Show()
    End Sub

    Private Sub ChuyếnBayToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChuyếnBayToolStripMenuItem.Click
        Dim f As New ChuyenBay
        f.Show()
    End Sub

    Private Sub HãngHàngKhôngToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HãngHàngKhôngToolStripMenuItem.Click
        Dim f As New hangHangKhong
        f.Show()
    End Sub

    Private Sub VéKhứHồiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VéKhứHồiToolStripMenuItem.Click
        Dim f As New veKhuHoi
        f.Show()
    End Sub

    Private Sub HóaĐơnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HóaĐơnToolStripMenuItem.Click
        Dim f As New hoaDon
        f.Show()
    End Sub


    'Tim kiem
    Private Sub VéMáyBayToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles VéMáyBayToolStripMenuItem1.Click
        Dim f As New timKiemVe
        f.Show()
    End Sub

    Private Sub KháchHàngToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KháchHàngToolStripMenuItem.Click
        Dim f As New timKiemKhachHang
        f.Show()
    End Sub

    Private Sub SânBayToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles SânBayToolStripMenuItem2.Click
        Dim f As New timKiemSanBay
        f.Show()
    End Sub

    Private Sub ChuyếnBayToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ChuyếnBayToolStripMenuItem2.Click
        Dim f As New timKiemChuyenBay
        f.Show()
    End Sub

    Private Sub HãngHàngKhôngToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles HãngHàngKhôngToolStripMenuItem2.Click
        Dim f As New timKiemHHK
        f.Show()
    End Sub

    Private Sub VéKhứHồiToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles VéKhứHồiToolStripMenuItem2.Click
        Dim f As New timKiemVeKhuHoi
        f.Show()
    End Sub

    Private Sub HóaĐơnToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles HóaĐơnToolStripMenuItem2.Click
        Dim f As New timKiemHD
        f.Show()
    End Sub

    'Thong ke

    Private Sub VéMáyBayToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles VéMáyBayToolStripMenuItem2.Click
        Dim f As New reportVeMayBay
        f.Show()
    End Sub

    Private Sub KháchHàngToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles KháchHàngToolStripMenuItem2.Click
        Dim f As New reportKH
        f.Show()
    End Sub

    Private Sub SânBayToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles SânBayToolStripMenuItem3.Click
        Dim f As New reportSanBay
        f.Show()
    End Sub

    Private Sub ChuyếnBayToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ChuyếnBayToolStripMenuItem3.Click
        Dim f As New reportChuyenBay
        f.Show()
    End Sub

    Private Sub HóaĐơnToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles HóaĐơnToolStripMenuItem3.Click

    End Sub

    'Tinh toan

    Private Sub TổngDoanhThuToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TổngDoanhThuToolStripMenuItem.Click

    End Sub

    Private Sub SốTiềnKHPhảiTrảToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SốTiềnKHPhảiTrảToolStripMenuItem.Click

    End Sub

    Private Sub SốLượngChuyếnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SốLượngChuyếnToolStripMenuItem.Click

    End Sub
End Class

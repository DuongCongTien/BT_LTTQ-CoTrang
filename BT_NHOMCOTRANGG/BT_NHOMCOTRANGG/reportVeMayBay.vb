Public Class reportVeMayBay
    Private Sub reportVeMayBay_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.ReportViewer1.RefreshReport()
        Me.ReportViewer2.RefreshReport
    End Sub
End Class
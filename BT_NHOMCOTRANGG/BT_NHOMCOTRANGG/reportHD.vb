Public Class reportHD
    Private Sub reportHD_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.ReportViewer1.RefreshReport()
        Me.ReportViewer2.RefreshReport
    End Sub
End Class
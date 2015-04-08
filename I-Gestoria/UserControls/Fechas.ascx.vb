
Partial Class UserControls_Fechas
    Inherits System.Web.UI.UserControl
    Private Sub Fechas_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            SetFechas()
        End If
    End Sub

    Public Function SetFechas()
        Dim FechaActual As System.DateTime
        Dim answer As System.DateTime
        FechaActual = System.DateTime.Now
        answer = FechaActual.AddDays(-30)

        'answer = CDate(Today.Date.Year & "/" & Today.Date.Month & "/" & Today.Day - 30)
        Me.rdFI.SelectedDate = answer
        Me.rdFF.SelectedDate = FechaActual


    End Function
End Class




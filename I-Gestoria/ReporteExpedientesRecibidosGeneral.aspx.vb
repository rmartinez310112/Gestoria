Imports System.Data.SqlClient
Imports System.Data
Partial Class ReporteExpedientesRecibidosGeneral
    Inherits System.Web.UI.Page




    Public Function SelectRecords_EntregaExpedientesSinVerificar(ByVal fechaini As String, ByVal fechaFin As String) As DataSet
        Dim conn As New SqlConnection(Session("connGestion"))
        Dim cmd As New SqlDataAdapter("select * from EntregaExpedientesGestoriaGeneral_vw	 where EntregaExpediente_fecha >='" & fechaini & " 00:00' and EntregaExpediente_fecha<='" & fechaFin & " 23:59:59'", conn)
        Dim dts As New DataSet()

        Try
            conn.Open()
            cmd.Fill(dts)
            Return dts
            conn.Close()
        Catch

        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Dispose()
            cmd.Dispose()
        End Try
    End Function

    Protected Sub Button1_Click(sender As Object, e As System.EventArgs) Handles Button1.Click
        Dim ds As DataSet = New DataSet
        Dim fechaini, fechafin As String
        fechaini = Format(rdFI.SelectedDate, "MM/dd/yyyy")
        fechafin = Format(rdFI0.SelectedDate, "MM/dd/yyyy")
        ds = SelectRecords_EntregaExpedientesSinVerificar(fechaini, fechafin)
        radExpedienteVer.DataSource = ds.Tables(0)
        radExpedienteVer.DataBind()
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            rdFI.SelectedDate = Now()
            rdFI0.SelectedDate = Now()
        End If
    End Sub
End Class

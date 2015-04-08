Imports System.Data
Imports System.Data.SqlClient



Partial Class BuscarServiciosGestoria_cliente
    Inherits System.Web.UI.Page
    Dim csNeg As New ClaseNegocios
    Dim csSQLsvr As New BaseDatosSQL
    Dim csDAL As New DALClass
    Dim Cadena As String = GlobalVariables.sqlString


#Region "Procesos y funciones"
    Protected Sub ConfigureNotification(ByVal texto As String)
        'String
        'lblError0.Text = texto
        RadNotification2.Title = "Atención"
        RadNotification2.Text = texto
        'Enum
        RadNotification2.Position = Telerik.Web.UI.NotificationPosition.Center
        RadNotification2.Animation = Telerik.Web.UI.NotificationAnimation.Fade
        'notificacion.ContentScrolling = Telerik.Web.UI.NotificationScrolling.Default
        RadNotification2.AutoCloseDelay = 50000
        'Unit
        RadNotification2.Width = 300
        RadNotification2.Height = 150
        RadNotification2.OffsetX = -10
        RadNotification2.OffsetY = 10

        RadNotification2.Pinned = False
        RadNotification2.EnableRoundedCorners = True
        RadNotification2.EnableShadow = True
        RadNotification2.KeepOnMouseOver = False
        RadNotification2.VisibleTitlebar = True
        RadNotification2.ShowCloseButton = True

        RadNotification2.Show()

    End Sub

    Public Sub cargaEstados()
        Dim comando As String

        comando = "exec Select_estados_sp"

        csSQLsvr.LlenarRadCombo(cboEstado, comando, Session("connGestion"))

    End Sub


    Public Sub cargaClientes(ByVal clvCliente As String)
        Dim comando As String = "SELECT DISTINCT cliente_clvCliente, cliente_NomCliente  FROM         Servicios_Clientes_Activos_vw  where cliente_clvCliente = 0 or cliente_clvCliente in (" & Session("ClienteTablero") & ") ORDER BY cliente_clvCliente "
        csSQLsvr.LlenarRadCombo(CboCliente, comando, Session("connGestion"))
    End Sub



    Public Sub cargaServicioTipo()
        Dim comando As String = "select Tramite_clvTramite, Tramite_Descripcion from TramitesGestion  order by Tramite_clvTramite"
        csSQLsvr.LlenarRadCombo(cboServicioTipo, comando, Session("connGestion"))

    End Sub

    Public Sub SetFechas()
        Dim FechaActual As System.DateTime
        Dim answer As System.DateTime
        FechaActual = System.DateTime.Now
        answer = FechaActual.AddDays(-30)

        'answer = CDate(Today.Date.Year & "/" & Today.Date.Month & "/" & Today.Day - 30)
        Me.rdFI.SelectedDate = answer
        Me.rdFF.SelectedDate = DateTime.Now.Date
    End Sub

#End Region

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            cargaEstados()
            cargaClientes(Session("ClienteTablero"))
            cargaServicioTipo()
            SetFechas()
        End If
    End Sub
    Private Function Contiene(ByVal texto As String) As String
        Contiene = " like '%" & texto.Trim & "%'"
        Return Contiene
    End Function

    Protected Sub btnBuscar0_Click(sender As Object, e As System.EventArgs) Handles btnBuscar0.Click

        Dim fechani As String = Format(rdFI.SelectedDate, "MM/dd/yyyy") & " 00:00"
        Dim fechaFin As String = Format(rdFF.SelectedDate, "MM/dd/yyyy") & " 23:59:59"
        Dim cliente As Integer = CboCliente.SelectedValue
        Dim estado As Integer = cboEstado.SelectedValue
        Dim tipoServ As Integer = cboServicioTipo.SelectedValue
        Dim polizas As String = txtPoliza.Text.Trim
        Dim contrato As String = txtContrato.Text.Trim

        Dim NomReporta As String = txtNomReporta.Text.Trim
        Dim ApePatReporta As String = txtApePatReporta.Text.Trim
        Dim NomASeg As String = txtNomASeg.Text.Trim
        Dim ApePatAseg As String = txtApePatAseg.Text.Trim
        Dim telASeg As String = txtelAseg.Text.Trim
        Dim buscar1, buscar2, buscar3, buscar4, buscar5, buscar6, buscar7, buscar8, buscar9, buscar10, buscarTotal As String
        If cliente = 0 Then buscar1 = "" Else buscar1 = " and reporte_cliente=" & cliente
        If estado = 0 Then buscar2 = "" Else buscar2 = " and reporte_clvEstado=" & estado
        If tipoServ = 0 Then buscar3 = "" Else buscar3 = " and Reporte_tipo=" & tipoServ
        If polizas = String.Empty Then buscar4 = "" Else buscar4 = " and reporte_poliza " & Contiene(polizas)
        If contrato = String.Empty Then buscar5 = "" Else buscar5 = " and reporte_contrato" & Contiene(contrato)
        If NomReporta = String.Empty Then buscar6 = "" Else buscar6 = " and reporte_nombreReporta" & Contiene(NomReporta)
        If ApePatReporta = String.Empty Then buscar7 = "" Else buscar7 = " and reporte_Apaternoreporta" & Contiene(ApePatReporta)
        If NomASeg = String.Empty Then buscar8 = "" Else buscar8 = " and asegurado" & Contiene(NomASeg)
        If ApePatAseg = String.Empty Then buscar9 = "" Else buscar9 = " and asegurado" & Contiene(ApePatAseg)
        If telASeg = String.Empty Then buscar10 = "" Else buscar10 = " and reporte_telAseg" & Contiene(telASeg)
        buscarTotal = buscar1 & buscar2 & buscar3 & buscar4 & buscar5 & buscar6 & buscar7 & buscar8 & buscar9 & buscar10

        Dim strConnString As String = Session("connGestion")
        Using con As New SqlConnection(strConnString)
            Using cmd As New SqlCommand()
                cmd.CommandText = "SELECT NoGestion ,estado,reporte_fecharepor,  rtrim(Reporte_APaternoReporta ) + ' '+ rtrim(Reporte_NombreReporta) as NombreReporta,asegurado,Reporte_TelAseg,cliente_NomCliente,Nom_Aseguradora,Reporte_poliza,Reporte_contrato, " & _
            "Servicio_NomServicio,(case reporte_status  when 0 then 'Activo' when 1 then 'Cancelado' when 3 then 'Terminado' when 10 then 'Cancelado' end) status" & _
             " FROM  ResportesGestionTotal_vw where reporte_cliente in (" & Session("ClienteTablero") & ") and  reporte_fecharepor>='" & fechani & "' and reporte_fecharepor<= '" & fechaFin & "' " & buscarTotal
                cmd.Connection = con
                con.Open()
                RadGrid1.DataSource = cmd.ExecuteReader()
                RadGrid1.DataBind()
                con.Close()
            End Using
        End Using

        'Dim cuenta As Integer = RadGrid1.Items.Count - 1
        'If cuenta = 0 Then
        '    ConfigureNotification("No hay registros que cumplan con los criterios seleccionados..")
        'End If
    End Sub

    Protected Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If e.CommandName = "cmdServicio" Then
            Dim master As MasterPageGestionOperativa = DirectCast(Me.Master, MasterPageGestionOperativa)
            Dim nExpediente As Telerik.Web.UI.RadNumericTextBox = Me.Master.FindControl("txtNoGestion")
            nExpediente.Text = e.CommandSource.text
            Session("noGestionIntegral") = e.CommandSource.text
            master.CargaDatosExpediente()
            master.Response.Redirect("BuscarServiciosGestoria.aspx")
        End If
    End Sub
End Class



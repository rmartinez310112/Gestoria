Imports System.Data
Imports System.Data.SqlClient

Partial Class AsignacionControl_BuscarServiciosGestoria
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
   

    Public Sub cargaClientes()
        Dim comando As String = "exec Select_cbo_clientes"
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
            cargaClientes()
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
        Dim Placas As String = txtPlacas.Text.Trim
        Dim Serie As String = txtSerie.Text.Trim
        Dim buscar1, buscar2, buscar3, buscar4, buscar5, buscar6, buscar7, buscar8, buscar9, buscar10, buscar11, buscar12, buscarTotal As String
        If cliente = 0 Then buscar1 = "" Else buscar1 = " and RGT.reporte_cliente=" & cliente
        If estado = 0 Then buscar2 = "" Else buscar2 = " and RGT.reporte_clvEstado=" & estado
        If tipoServ = 0 Then buscar3 = "" Else buscar3 = " and RGT.Reporte_tipo=" & tipoServ
        If polizas = String.Empty Then buscar4 = "" Else buscar4 = " and RGT.reporte_poliza " & Contiene(polizas)
        If contrato = String.Empty Then buscar5 = "" Else buscar5 = " and RGT.reporte_contrato" & Contiene(contrato)
        If NomReporta = String.Empty Then buscar6 = "" Else buscar6 = " and RGT.reporte_nombreReporta" & Contiene(NomReporta)
        If ApePatReporta = String.Empty Then buscar7 = "" Else buscar7 = " and RGT.reporte_Apaternoreporta" & Contiene(ApePatReporta)
        If NomASeg = String.Empty Then buscar8 = "" Else buscar8 = " and RGT.asegurado" & Contiene(NomASeg)
        If ApePatAseg = String.Empty Then buscar9 = "" Else buscar9 = " and RGT.asegurado" & Contiene(ApePatAseg)
        If telASeg = String.Empty Then buscar10 = "" Else buscar10 = " and RGT.reporte_telAseg" & Contiene(telASeg)
        If Placas = String.Empty Then buscar11 = "" Else buscar11 = " and NS.Placas" & Contiene(Placas)
        If Serie = String.Empty Then buscar12 = "" Else buscar12 = " and NS.NumSerie" & Contiene(Serie)
        buscarTotal = buscar1 & buscar2 & buscar3 & buscar4 & buscar5 & buscar6 & buscar7 & buscar8 & buscar9 & buscar10 & buscar11 & buscar12
       
        Dim strConnString As String = Session("connGestion")
        Using con As New SqlConnection(strConnString)
            Using cmd As New SqlCommand()
                cmd.CommandText = " SELECT RGT.NoGestion ,RGT.estado,RGT.reporte_fecharepor " & _
            " ,  rtrim(RGT.Reporte_APaternoReporta ) + ' '+ rtrim(RGT.Reporte_NombreReporta) as NombreReporta " & _
            " ,RGT.asegurado,RGT.Reporte_TelAseg,RGT.cliente_NomCliente,RGT.Nom_Aseguradora " & _
            " ,RGT.Reporte_poliza,RGT.Reporte_contrato, RGT.Servicio_NomServicio, " & _
            " (case RGT.reporte_status  when 0 then 'Activo' when 1 then " & _
            "'Cancelado' when 3 then 'Terminado' when 10 then 'Cancelado' end) status " & _
            " , NS.NoSiniestro, NS.NumSerie FROM  ResportesGestionTotal_vw RGT " & _
            " left outer join Vw_NumeroSiniestros NS on RGT.Reporte_anio = NS.Reporte_anio " & _
            " and RGT.Reporte_cliente = NS.Reporte_cliente and RGT.Reporte_Tipo = NS.Reporte_Tipo " & _
            " and RGT.Reporte_clvEstado = NS.Reporte_clvEstado and RGT.Reporte_Numero = NS.Reporte_Numero " & _
            " where RGT.reporte_fecharepor>='" & fechani & "' and RGT.reporte_fecharepor<= '" & fechaFin & "' " & buscarTotal
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

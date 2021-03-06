﻿Imports System.Data
Imports Telerik.Web.UI
Imports Telerik.Web
Imports Telerik

Partial Class AsignacionControl_AsignarGestor_Pendiente1

    Inherits System.Web.UI.Page
    Dim csNeg As New ClaseNegocios
    Dim csSQLsvr As New BaseDatosSQL
    Dim csDAL As New DALClass
    Dim Cadena As String = GlobalVariables.sqlString
    Dim VentanasWin As New Ventanas

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

    Public Sub cargaEstados(ByVal region As String)
        Dim comando As String
        If region <> "" Then
            comando = "exec Select_estados_sp @id_regional = " & region
        Else
            comando = "exec Select_estados_sp"
        End If
        csSQLsvr.LlenarRadCombo(cboEstado, comando, Session("connGestion"))

    End Sub

    Public Sub cargaStatusAsigna()
        Dim comando As String = "exec Select_EstatusAsigna_Gestor_sp "
        csSQLsvr.LlenarRadCombo(cboStatusAsigna, comando, Session("connGestion"))
    End Sub

    Public Sub cargaClientes()
        Dim comando As String = "exec Select_cbo_clientes"
        csSQLsvr.LlenarRadCombo(CboCliente, comando, Session("connGestion"))
    End Sub

    Public Sub cargaRegion()
        Dim comando As String = "select clave, nombre from Regional order by clave"
        csSQLsvr.LlenarRadCombo(cboRegion, comando, Session("connGestion"))

    End Sub

    Public Sub cargaServicioTipo()
        Dim comando As String = "select Tramite_clvTramite, Tramite_Descripcion from TramitesGestion where Tramite_clvTramite < 14 order by Tramite_clvTramite"
        csSQLsvr.LlenarRadCombo(cboServicioTipo, comando, Session("connGestion"))

    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        LlenaGrid()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        VentanasWin = New Ventanas(Master)
        If Not Page.IsPostBack Then
            cargaEstados(cboRegion.SelectedValue)
            cargaClientes()
            cargaRegion()
            cargaServicioTipo()
            cargaStatusAsigna()
            SetFechas()
            ReasignaFiltros()
            LlenaGrid()
            If Request.QueryString("Detalle") = 1 Then
                btnDetalleGestor.Visible = True
            End If
        End If
    End Sub

    Public Function SetFechas()
        Dim FechaActual As System.DateTime
        Dim answer As System.DateTime
        FechaActual = System.DateTime.Now
        answer = FechaActual.AddDays(-30)

        'answer = CDate(Today.Date.Year & "/" & Today.Date.Month & "/" & Today.Day - 30)
        Me.rdFI.SelectedDate = answer
        Me.rdFF.SelectedDate = DateTime.Now.Date
    End Function

    Public Sub LlenaGrid()

        btnDetalleGestor.Visible = False
        Dim poliza As String = txtPoliza.Text
        Dim cliente As String = CboCliente.SelectedValue
        Dim tipoServicio As String = cboServicioTipo.SelectedValue
        Dim FechaInicio As String = rdFI.SelectedDate.Value.ToString("yyyyMMdd")
        Dim FechaFinal As String = rdFF.SelectedDate.Value.ToString("yyyyMMdd")
        Dim Regional As String = cboRegion.SelectedValue
        Dim Estado As String = cboEstado.SelectedValue
        Dim EstatusAsignacion As String = cboStatusAsigna.SelectedValue
        Dim Orden As String = ""

        If ChkOrdenar.Checked Then

            If RadioButtonList1.SelectedValue = 0 Then
                Orden = " order by NomAseg "
            End If

        End If

        Dim ds As New DataSet
        Dim dt As New DataTable

        If Me.chkJuridico.Checked Then
            ds = csDAL.CargaAsignacionesSinJuridico(poliza, cliente, tipoServicio, FechaInicio, FechaFinal, Regional, Estado, EstatusAsignacion, Orden)
            dt = ds.Tables(0)
        Else
            ds = csDAL.CargaAsignaciones(poliza, cliente, tipoServicio, FechaInicio, FechaFinal, Regional, Estado, EstatusAsignacion, Orden)
            dt = ds.Tables(0)
        End If


        If dt.Rows.Count <> 0 Then
            ViewState("dataset") = dt
            radSeguimiento.CurrentPageIndex = 0
            radSeguimiento.DataSource = dt
            radSeguimiento.DataBind()
            radSeguimiento.Dispose()
            'UpdatePanelGrid.Update()



            If Me.chkJuridico.Checked = False Then
                RecalculaValoresGrid()
            End If

            lblNumServ.Text = dt.Rows.Count

        Else


            ''Mensage de que no se tienen valores a mostrar
            radSeguimiento.Rebind()
            ds.Tables.Clear()
            ConfigureNotification("No existen datos a mostrar.")

        End If
    End Sub

    Protected Sub chkJuridico_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkJuridico.CheckedChanged
        LlenaGrid()
    End Sub

    Protected Sub cboRegion_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cboRegion.SelectedIndexChanged
        cargaEstados(cboRegion.SelectedValue)
    End Sub

    Protected Sub radSeguimiento_PageIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridPageChangedEventArgs) Handles radSeguimiento.PageIndexChanged

        'Paginación
        Dim dt As DataTable = ViewState("dataset")
        radSeguimiento.DataSource = dt.DefaultView
        radSeguimiento.DataBind()
        radSeguimiento.Dispose()
        UpdatePanelGrid.Update()
        RecalculaValoresGrid()
    End Sub

    Protected Sub grid_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles radSeguimiento.ItemCommand

        RecalculaValoresGrid()

        If e.CommandName = "cmdcontactar" Then
            Dim indexRow As Integer = Convert.ToInt32(e.Item.ItemIndex)

            Dim item As GridDataItem = radSeguimiento.Items(indexRow)
            Dim item3 As GridDataItem = DirectCast(e.Item, GridDataItem)
            Dim sGestion As String = DirectCast(item3("cmdNumservicio").Controls(0), LinkButton).Text
            Session("NumGestionSeguimiento") = sGestion
            ' aqui mandar el no. de servicio escogido al encabezado.

            VentanasWin.Abrir_winwinSeguimiento()

        ElseIf e.CommandName = "cmdNumservicio" Then

            Dim master As MasterPageGestionOperativa = DirectCast(Me.Master, MasterPageGestionOperativa)
            Dim nExpediente As Telerik.Web.UI.RadNumericTextBox = Me.Master.FindControl("txtNoGestion")
            nExpediente.Text = e.CommandSource.text
            Session("noGestionIntegral") = e.CommandSource.text
            master.CargaDatosExpediente()
            LlenaGrid()
            btnDetalleGestor.Visible = True
            Dim redireccion As String = "~/AsignacionControl/AsignarGestor_Pendiente1.aspx?Detalle=1" & ResguardaFiltros()
            master.Response.Redirect(redireccion)

        ElseIf e.CommandName = "cmdAsignacion" Then

            Dim indexRow As Integer = Convert.ToInt32(e.Item.ItemIndex)

            Dim item As GridDataItem = radSeguimiento.Items(indexRow)
            Dim item3 As GridDataItem = DirectCast(e.Item, GridDataItem)
            Dim sGestion As String = DirectCast(item3("cmdNumservicio").Controls(0), LinkButton).Text
            Session("NumGestionSeguimiento") = sGestion
            Dim p_estado As String = Mid(sGestion, 9, 2)

            Session("estado") = p_estado

            VentanasWin.Abrir_winwinPrimerCg()

        End If

    End Sub

    Protected Sub btnDetalleUsu0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDetalleGestor.Click

        If Session("noGestionIntegral") <> "" Then

            VentanasWin.Abrir_winwinDetalleGestor()
            RecalculaValoresGrid()
        Else
            ConfigureNotification("Favor de seleccionar un numero de servicio")
        End If

    End Sub

    Protected Sub RadAjaxManager1_AjaxRequest(ByVal sender As Object, ByVal e As Web.UI.AjaxRequestEventArgs) Handles RadAjaxManager1.AjaxRequest

        If e.Argument = "Rebind" Then
            radSeguimiento.MasterTableView.SortExpressions.Clear()
            radSeguimiento.MasterTableView.GroupByExpressions.Clear()
            radSeguimiento.Rebind()
            LlenaGrid()
            RecalculaValoresGrid()
        ElseIf e.Argument = "RebindAndNavigate" Then
            radSeguimiento.MasterTableView.SortExpressions.Clear()
            radSeguimiento.MasterTableView.GroupByExpressions.Clear()
            radSeguimiento.MasterTableView.CurrentPageIndex = radSeguimiento.MasterTableView.PageCount - 1
            radSeguimiento.Rebind()
        End If
    End Sub

    Public Sub RecalculaValoresGrid()
        Dim cuentaContactoCliente As Integer = 0
        Dim cuentaContactoGestor As Integer = 0
        For Each item As GridDataItem In radSeguimiento.Items

            If item.Cells(8).Text = "" Then
                item.Cells(10).Text = ""
            End If

            If item.Cells(12).Text <> "" Then
                item.Cells(11).Text = item.Cells(12).Text
                item.Cells(11).ForeColor = Drawing.Color.Black
            Else
                cuentaContactoCliente += 1
            End If

            If item.Cells(11).ForeColor <> Drawing.Color.Black Then
                item.Cells(16).Text = ""
            Else
                cuentaContactoGestor += 1
            End If


            ''If item.Cells(13).Text = "" Then

            ''End If

            'If item.Cells(16).Text <> "" Then

            'End If


        Next

        lblPendientescontactoCliente.Text = cuentaContactoCliente
        lblPendientesAsignar.Text = cuentaContactoGestor
    End Sub

    Public Function ResguardaFiltros() As String
        Dim poliza As String = txtPoliza.Text
        Dim cliente As String = CboCliente.SelectedValue
        Dim tipoServicio As String = cboServicioTipo.SelectedValue
        Dim FechaInicio As String = csDAL.FormatoFecha(rdFI.SelectedDate.Value.ToString())
        Dim FechaFinal As String = csDAL.FormatoFecha(rdFF.SelectedDate.Value.ToString())
        Dim Regional As String = cboRegion.SelectedValue
        Dim Estado As String = cboEstado.SelectedValue
        Dim EstatusAsignacion As String = cboStatusAsigna.SelectedValue

        Dim cadena As String = ""

        If poliza <> "" Then
            cadena = "&Poliza=" & poliza
        End If

        If cliente <> "" Then
            cadena = cadena & "&Cliente=" & cliente
        End If

        If tipoServicio <> "" Then
            cadena = cadena & "&Tipo=" & tipoServicio
        End If

        cadena = cadena & "&FIni=" & FechaInicio & "&FFin=" & FechaFinal

        If Regional <> "" Then
            cadena = cadena & "&Regional=" & Regional
        End If

        If Estado <> "" Then
            cadena = cadena & "&Estado=" & Estado
        End If

        If EstatusAsignacion <> "" Then
            cadena = cadena & "&EstatusAsignacion=" & EstatusAsignacion
        End If

        ResguardaFiltros = cadena
        Return ResguardaFiltros
    End Function

    Public Sub ReasignaFiltros()
        Dim poliza As String = Request.QueryString("Poliza")
        Dim cliente As String = Request.QueryString("Cliente")
        Dim tipoServicio As String = Request.QueryString("Tipo")
        Dim FechaInicio As String = Request.QueryString("FIni")
        Dim FechaFinal As String = Request.QueryString("FFin")
        Dim Regional As String = Request.QueryString("Regional")
        Dim Estado As String = Request.QueryString("Estado")
        Dim EstatusAsignacion As String = Request.QueryString("EstatusAsignacion")

        If poliza <> "" Then
            txtPoliza.Text = poliza
        End If

        If cliente <> "" Then
            CboCliente.SelectedValue = cliente
        End If

        If tipoServicio <> "" Then
            cboServicioTipo.SelectedValue = tipoServicio
        End If

        'If FechaInicio <> "" Then
        '    rdFI.SelectedDate = FechaInicio
        'End If

        'If FechaFinal <> "" Then
        '    rdFF.SelectedDate = FechaFinal
        'End If

        If Regional <> "" Then
            cboRegion.SelectedValue = Regional
        End If

        If Estado <> "" Then
            cboEstado.SelectedValue = Estado
        End If

        If EstatusAsignacion <> "" Then
            cboStatusAsigna.SelectedValue = EstatusAsignacion
        End If

    End Sub

    
    Protected Sub ChkOrdenar_CheckedChanged(sender As Object, e As System.EventArgs) Handles ChkOrdenar.CheckedChanged
        If ChkOrdenar.Checked Then
            RadioButtonList1.Visible = True
        Else
            RadioButtonList1.Visible = False
        End If
    End Sub
End Class
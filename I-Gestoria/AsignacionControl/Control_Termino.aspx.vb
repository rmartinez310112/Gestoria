Imports System.Data
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

    'Public Sub cargaStatusAsigna()
    '    Dim comando As String = "exec Select_EstatusAsigna_Gestor_sp "
    '    csSQLsvr.LlenarRadCombo(cboStatusAsigna, comando, Session("connGestion"))
    'End Sub

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
       

        'LlenaGrid()

        LlenaGridFiltros()


    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        VentanasWin = New Ventanas(Master)
        If Not IsPostBack Then

            cargaEstados(cboRegion.SelectedValue)
            cargaClientes()
            cargaRegion()
            cargaServicioTipo()
            'cargaStatusAsigna()
            SetFechas()

            If Request.QueryString("Detalle") = 1 Then

                'btnRecepcionIdividual.Visible = True
                ReasignaFiltros()
                ViewState("dataset") = Session("dtfilt")
                LlenaGridFiltros()


            Else
                LlenaGrid()

            End If
            'Else
            '    btnRecepcionIdividual.Visible = True
            '    ReasignaFiltros()
            '    ViewState("dataset") = Session("dtfilt")
            '    LlenaGridFiltros()
        Else
            'If Request.QueryString("Detalle") = 1 Then
            '    'btnRecepcionIdividual.Visible = True
            '    ReasignaFiltros()
            '    ViewState("dataset") = Session("dtfilt")
            '    LlenaGridFiltros()
            '    CalculaIndicadores(ViewState("dataset"))
            'Else
            '    LlenaGrid()
            'End If
        End If
        RecalculaValoresGrid()

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

        MuestraBotonesDetalle(0)
        
        Dim EstatusExpediente As String = cboEstatusExpediente.SelectedValue

        Dim ds As New DataSet
        Dim dt As New DataTable

        ds = csDAL.CargaTerminos(EstatusExpediente)
        dt = ds.Tables(0)
        '' hacer los filtros con el rowfiltes al ds
        'cliente, tipoServicio, FechaInicio, FechaFinal, Regional, Estado

        If dt.Rows.Count <> 0 Then
            For Each dr In ds.Tables(0).Rows
                If Trim(dr("Reporte_CiaAsegura")) <> String.Empty Then ' para saber si es moral o fisica
                    Session("tipoPersona") = 2 'moral
                Else
                    Session("tipoPersona") = 1 'fisica
                End If
            Next

            ViewState("dataset") = dt

            radSeguimiento.CurrentPageIndex = 0
            radSeguimiento.DataSource = ValidaFiltros()
            radSeguimiento.DataBind()
            radSeguimiento.Dispose()
            RecalculaValoresGrid()
            'UpdatePanelGrid.Update()

        Else


            ''Mensage de que no se tienen valores a mostrar
            radSeguimiento.Rebind()
            ds.Tables.Clear()
            ConfigureNotification("No existen datos a mostrar.")

        End If
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



        If e.CommandName = "cmdRecepcion" Then

            Dim indexRow As Integer = Convert.ToInt32(e.Item.ItemIndex)

            Dim item As GridDataItem = radSeguimiento.Items(indexRow)
            Dim item3 As GridDataItem = DirectCast(e.Item, GridDataItem)
            Dim sGestion As String = DirectCast(item3("cmdNumservicio").Controls(0), LinkButton).Text
            Session("NumGestionControlTerm") = sGestion
            Session("ModoVentanaControlTerm") = 1
            ' aqui mandar el no. de servicio escogido al encabezado.

            VentanasWin.Abrir_winwinRecepcion()

        ElseIf e.CommandName = "cmdVerifica" Then

            Dim indexRow As Integer = Convert.ToInt32(e.Item.ItemIndex)

            Dim item As GridDataItem = radSeguimiento.Items(indexRow)
            Dim item3 As GridDataItem = DirectCast(e.Item, GridDataItem)
            Dim sGestion As String = DirectCast(item3("cmdNumservicio").Controls(0), LinkButton).Text
            Session("NumGestionControlTerm") = sGestion
            ' aqui mandar el no. de servicio escogido al encabezado.

            VentanasWin.Abrir_winwinVerificacionExp()

        ElseIf e.CommandName = "cmdDigitalizacion" Then

            Dim indexRow As Integer = Convert.ToInt32(e.Item.ItemIndex)

            Dim item As GridDataItem = radSeguimiento.Items(indexRow)
            Dim item3 As GridDataItem = DirectCast(e.Item, GridDataItem)
            Dim sGestion As String = DirectCast(item3("cmdNumservicio").Controls(0), LinkButton).Text
            Session("NumGestionControlTerm") = sGestion
            ' aqui mandar el no. de servicio escogido al encabezado.

            VentanasWin.Abrir_winwinDigitalizacion()

        ElseIf e.CommandName = "cmdEntrega" Then

            Dim indexRow As Integer = Convert.ToInt32(e.Item.ItemIndex)

            Dim item As GridDataItem = radSeguimiento.Items(indexRow)
            Dim item3 As GridDataItem = DirectCast(e.Item, GridDataItem)
            Dim sGestion As String = DirectCast(item3("cmdNumservicio").Controls(0), LinkButton).Text
            Session("NumGestionControlTerm") = sGestion
            ' aqui mandar el no. de servicio escogido al encabezado.

            VentanasWin.Abrir_winwinEntrega()

        ElseIf e.CommandName = "cmdNumservicio" Then
            Dim master As MasterPageGestionOperativa = DirectCast(Me.Master, MasterPageGestionOperativa)
            Dim nExpediente As Telerik.Web.UI.RadNumericTextBox = Me.Master.FindControl("txtNoGestion")
            nExpediente.Text = e.CommandSource.text
            Session("NumGestionControlTerm") = e.CommandSource.text
            master.CargaDatosExpediente()
            BtnDetRecepcion.Visible = True
            MuestraBotonesDetalle(1)
            Dim redireccion As String = "~/AsignacionControl/Control_Termino.aspx?Detalle=1" & ResguardaFiltros()
            master.Response.Redirect(redireccion)

        End If

    End Sub

    Protected Sub RadAjaxManager1_AjaxRequest(ByVal sender As Object, ByVal e As Web.UI.AjaxRequestEventArgs) Handles RadAjaxManager1.AjaxRequest

        If e.Argument = "Rebind" Then
            radSeguimiento.MasterTableView.SortExpressions.Clear()
            radSeguimiento.MasterTableView.GroupByExpressions.Clear()
            radSeguimiento.Rebind()
            LlenaGrid()
        ElseIf e.Argument = "RebindAndNavigate" Then
            radSeguimiento.MasterTableView.SortExpressions.Clear()
            radSeguimiento.MasterTableView.GroupByExpressions.Clear()
            radSeguimiento.MasterTableView.CurrentPageIndex = radSeguimiento.MasterTableView.PageCount - 1
            radSeguimiento.Rebind()
        End If
    End Sub

    Public Sub RecalculaValoresGrid()

        For Each item As GridDataItem In radSeguimiento.Items

            If Trim(item.Cells(10).Text) = "01/01/1900" Then
                item.Cells(10).Text = ""
            End If

            If Trim(item.Cells(12).Text) = "01/01/1900" Then
                item.Cells(12).Text = ""
            End If

            If Trim(item.Cells(14).Text) = "01/01/1900" Then
                item.Cells(14).Text = ""
            End If

            If Trim(item.Cells(16).Text) = "01/01/1900" Then
                item.Cells(16).Text = ""
            End If

            If Trim(item.Cells(18).Text) = "01/01/1900" Then
                item.Cells(18).Text = ""
            End If

            'If Trim(item.Cells(18).Text) <> "01/01/1900" Or Trim(item.Cells(18).Text) <> "" Then
            '    item.Cells(9).Text = ""
            'End If

            If Trim(item.Cells(10).Text) <> "" Then
                item.Cells(9).Text = ""
            End If

        Next

    End Sub

    Public Function ResguardaFiltros() As String
        Dim cliente As String = CboCliente.SelectedValue
        Dim tipoServicio As String = cboServicioTipo.SelectedValue
        Dim FechaInicio As String = rdFI.SelectedDate.Value.ToString("yyyy-MM-dd")
        Dim FechaFinal As String = rdFF.SelectedDate.Value.ToString("yyyy-MM-dd")
        Dim Regional As String = cboRegion.SelectedValue
        Dim Estado As String = cboEstado.SelectedValue
        Dim EstatusExpediente As String = cboEstatusExpediente.SelectedValue


        Dim cadena As String = ""


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

        If EstatusExpediente <> "" Then
            cadena = cadena & "&EstatusExpediente=" & EstatusExpediente
        End If

        ResguardaFiltros = cadena
        Return ResguardaFiltros
    End Function

    Public Sub ReasignaFiltros()

        Dim Poliza As String = Request.QueryString("Poliza")
        Dim cliente As String = Request.QueryString("Cliente")
        Dim tipoServicio As String = Request.QueryString("Tipo")
        Dim FechaInicio As String = Request.QueryString("FIni")
        Dim FechaFinal As String = Request.QueryString("FFin")
        Dim Regional As String = Request.QueryString("Regional")
        Dim Estado As String = Request.QueryString("Estado")
        Dim EstatusExpediente As String = Request.QueryString("EstatusExpediente")

        If Poliza <> "" Then
            TxtPoliza.Text = Poliza
        End If

        If cliente <> "" Then
            CboCliente.SelectedValue = cliente
        End If

        If tipoServicio <> "" Then
            cboServicioTipo.SelectedValue = tipoServicio
        End If

        If FechaInicio <> "" Then
            rdFI.SelectedDate = FechaInicio
        End If

        If FechaFinal <> "" Then
            rdFF.SelectedDate = FechaFinal
        End If

        If Regional <> "" Then
            cboRegion.SelectedValue = Regional
        End If

        If Estado <> "" Then
            cboEstado.SelectedValue = Estado
        End If

        If EstatusExpediente <> "" Then
            cboEstatusExpediente.SelectedValue = EstatusExpediente
        End If

    End Sub

    Public Function ValidaFiltros() As DataTable

        Dim poliza As String = TxtPoliza.Text
        Dim cliente As String = CboCliente.SelectedValue
        Dim tipoServicio As String = cboServicioTipo.SelectedValue
        Dim FechaInicio As String = rdFI.SelectedDate.Value.ToString("yyyyMMdd")
        Dim FechaFinal As String = rdFF.SelectedDate.Value.ToString("yyyyMMdd")
        Dim Regional As String = cboRegion.SelectedValue
        Dim Estado As String = cboEstado.SelectedValue
        Dim EstatusExpediente As String = cboEstatusExpediente.SelectedValue


        Dim filtro As String = ""
        Dim filtro2 As String = ""
        Dim y As String = String.Empty

        If poliza <> "" Then
            filtro = "Reporte_poliza = '" & poliza & "'"
        End If


        If cliente <> 0 Then
            If poliza <> "" Then y = " AND "
            filtro = filtro & y & "Reporte_cliente = " & cliente
        End If

        If tipoServicio <> 0 Then
            If poliza <> "" Or cliente <> 0 Then y = " AND "
            filtro = filtro & y & "Reporte_Tipo = " & tipoServicio
        End If

        If Regional <> 0 Then
            If poliza <> "" Or cliente <> 0 Or tipoServicio <> 0 Then y = " AND "
            filtro = filtro & y & "NumRegion = " & Regional
        End If

        If Estado <> 0 Then
            If poliza <> "" Or cliente <> 0 Or tipoServicio <> 0 Or Regional <> 0 Then y = " AND "
            filtro = filtro & y & "NumEdo = " & Estado
        End If


        If EstatusExpediente <> 0 Then
            If poliza <> "" Or cliente <> 0 Or tipoServicio <> 0 Or Regional <> 0 Or Estado <> 0 Then y = " AND "
            Select Case EstatusExpediente

                Case 1 'Expedientes Entregados 1   --- Este no debe de ir
                    filtro = filtro & y & "convert(EntregaExpedienteTerminado, 'System.String') <> '' "
                Case 2 'Expedientes Rechazados 2
                    filtro = filtro & y & "convert(fecha_rechazo, 'System.String') <> '' "
                Case 3 'Expedientes Digitalizados 3
                    filtro = filtro & y & "convert(DigitalizacionExpediente, 'System.String')  <> '' "
                Case 4 'Expedientes Verificados 4
                    filtro = filtro & y & "convert(VerificacionExpediente, 'System.String') <> '01/01/1900 12:00:00 a.m.' AND convert(VerificacionExpediente, 'System.String') <> '01/01/1900' "
                Case 5 'Pendientes de Entrega 5
                    filtro = filtro & y & " convert(RecepcionExpediente, 'System.String') <> '' "
                    filtro2 = " convert(VerificacionExpediente, 'System.String') <> '01/01/1900 12:00:00 a.m.' AND convert(VerificacionExpediente, 'System.String') <> '01/01/1900' "
                    filtro2 = filtro2 & " AND isnull(Convert(DigitalizacionExpediente, 'System.String'), '')  <> '' "
                    'filtro2 = filtro2 & " AND isnull(Convert(DigitalizacionExpediente, 'System.String'), '')  <> '' "
                    'convert(DigitalizacionExpediente, 'System.String') <> '' AND convert(VerificacionExpediente, 'System.String') <> '01/01/1900 12:00:00 a.m.' AND convert(VerificacionExpediente, 'System.String') <> '01/01/1900' AND convert(RecepcionExpediente, 'System.String') <> '' AND isnull(Convert(EntregaExpedienteTerminado, 'System.String'), '') = '' 
                Case 6
                    filtro = filtro & y & "isnull(Convert(fecha_rechazo, 'System.String'), '') = '' "
                Case 7 'Pendientes de Digitalizacion
                    filtro = filtro & y & "convert(RecepcionExpediente, 'System.String') <> '' "  'Recibido
                    filtro2 = "convert(VerificacionExpediente, 'System.String') <> '01/01/1900 12:00:00 a.m.' AND convert(VerificacionExpediente, 'System.String') <> '01/01/1900' "
                    filtro2 = filtro2 & " AND isnull(Convert(DigitalizacionExpediente, 'System.String'), '')  = '' "
                Case 8 'Pendientes de Verificar
                    filtro = filtro & y & "convert(RecepcionExpediente, 'System.String') <> '' AND isnull(Convert(VerificacionExpediente, 'System.String'), '') = '' "
                Case 9 'Expedientes Recibidos  
                    filtro = filtro & y & "convert(RecepcionExpediente, 'System.String') <> '' "
                Case 10 'Pendientes de Recibidir
                    filtro = filtro & y & "isnull(Convert(RecepcionExpediente, 'System.String'), '') = '' "
                Case 11 'En Transito
                    filtro = filtro & y & "transito = 1 "
            End Select

        End If

        If poliza <> "" Or tipoServicio <> 0 Or cliente <> 0 Or Regional <> 0 Or Estado <> 0 Or EstatusExpediente <> 0 Then y = " AND "
        filtro = filtro & y & " Convert(Reporte_FechaRepor, 'System.String')  > '" & FechaInicio & "'"
        filtro = filtro & " AND Convert(Reporte_FechaRepor, 'System.String')  < '" & FechaFinal & "'"

        Dim DV As New DataView(ViewState("dataset"))
        DV.RowFilter = filtro
       
        'PrintDataView(DV)

        RecalculaValoresGrid()
        CalculaIndicadores(DV.ToTable)
        Session("dtfilt") = DV.ToTable
        If filtro2 <> "" Then
            Dim DV2 As New DataView(Session("dtfilt"))
            DV2.RowFilter = filtro2
            RecalculaValoresGrid()
            CalculaIndicadores(DV2.ToTable)
            'Session("dtfilt")
            ValidaFiltros = DV2.ToTable
        Else
            ValidaFiltros = DV.ToTable
        End If


    End Function

    Public Sub LlenaGridFiltros()
        radSeguimiento.CurrentPageIndex = 0
        If Request.QueryString("Detalle") = 1 Then
            radSeguimiento.DataSource = Session("dtfilt")
            ValidaFiltros()
        Else
            radSeguimiento.DataSource = ValidaFiltros()
        End If

        radSeguimiento.DataBind()
        radSeguimiento.Dispose()
        RecalculaValoresGrid()

    End Sub

    Public Sub CalculaIndicadores(ByVal dt As DataTable)

        Dim DV As New DataView(dt)

        DV.RowFilter = " Convert(RecepcionExpediente, 'System.String') <> '' "
        lblRecepcionExpediente.Text = Dv.Count

        DV.RowFilter = " Convert(DigitalizacionExpediente, 'System.String') <> '' "
        lblDigitilizacionExpediente.Text = Dv.Count

        DV.RowFilter = " convert(VerificacionExpediente, 'System.String') <> '01/01/1900 12:00:00 a.m.' AND convert(VerificacionExpediente, 'System.String') <> '01/01/1900' "
        lblExpedientesVerificados.Text = Dv.Count

        DV.RowFilter = " Convert(EntregaExpedienteTerminado, 'System.String') <> '01/01/1900 12:00:00 a.m.' "
        lblExpedientesEntregados.Text = DV.Count

        DV.RowFilter = "Convert(fecha_rechazo, 'System.String') <> '01/01/1900 12:00:00 a.m.' "
        lblExpedientesRechazados.Text = DV.Count

    End Sub

    Protected Sub BtnDetRecepcion_Click(sender As Object, e As System.EventArgs) Handles BtnDetRecepcion.Click
        Dim master As MasterPageGestionOperativa = DirectCast(Me.Master, MasterPageGestionOperativa)
        Dim nExpediente As Telerik.Web.UI.RadNumericTextBox = Me.Master.FindControl("txtNoGestion")
        If Session("noGestionIntegral") <> Nothing And nExpediente.Text <> String.Empty Then
            VentanasWin.Abrir_winwinDetalleRecepcion()
        Else
            ConfigureNotification("Debe Escoger Numero de Servicio")
        End If

    End Sub

    Protected Sub BtnDetVerificacion_Click(sender As Object, e As System.EventArgs) Handles BtnDetVerificacion.Click
        Dim master As MasterPageGestionOperativa = DirectCast(Me.Master, MasterPageGestionOperativa)
        Dim nExpediente As Telerik.Web.UI.RadNumericTextBox = Me.Master.FindControl("txtNoGestion")
        If Session("noGestionIntegral") <> Nothing And nExpediente.Text <> String.Empty Then
            VentanasWin.Abrir_winwinDetalleVerificacion()
        Else
            ConfigureNotification("Debe Escoger Numero de Servicio")
        End If
    End Sub

    Protected Sub BtnDetDigitalizacion_Click(sender As Object, e As System.EventArgs) Handles BtnDetDigitalizacion.Click
        Dim master As MasterPageGestionOperativa = DirectCast(Me.Master, MasterPageGestionOperativa)
        Dim nExpediente As Telerik.Web.UI.RadNumericTextBox = Me.Master.FindControl("txtNoGestion")
        If Session("noGestionIntegral") <> Nothing And nExpediente.Text <> String.Empty Then
            VentanasWin.Abrir_winwinDetalleDigitalizacion()
        Else
            ConfigureNotification("Debe Escoger Numero de Servicio")
        End If
    End Sub

    Protected Sub BtnDetEntrega_Click(sender As Object, e As System.EventArgs) Handles BtnDetEntrega.Click
        Dim master As MasterPageGestionOperativa = DirectCast(Me.Master, MasterPageGestionOperativa)
        Dim nExpediente As Telerik.Web.UI.RadNumericTextBox = Me.Master.FindControl("txtNoGestion")
        If Session("noGestionIntegral") <> Nothing And nExpediente.Text <> String.Empty Then
            VentanasWin.Abrir_winwinDetalleEntrega()
        Else
            ConfigureNotification("Debe Escoger Numero de Servicio")
        End If
    End Sub

    Public Sub MuestraBotonesDetalle(ByVal muestra As Integer)
        If muestra = 0 Then
            BtnDetRecepcion.Visible = False
            BtnDetVerificacion.Visible = False
            BtnDetDigitalizacion.Visible = False
            BtnDetEntrega.Visible = False
        Else
            BtnDetRecepcion.Visible = True
            BtnDetVerificacion.Visible = True
            BtnDetDigitalizacion.Visible = True
            BtnDetEntrega.Visible = True
        End If

    End Sub

    Protected Sub Button1_Click(sender As Object, e As System.EventArgs) Handles BtnActualiza.Click
        LlenaGrid()
    End Sub

    Protected Sub cboServicioTipo_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cboServicioTipo.SelectedIndexChanged

    End Sub
End Class
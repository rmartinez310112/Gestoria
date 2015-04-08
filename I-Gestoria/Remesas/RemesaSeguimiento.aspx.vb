Imports System.Data
Imports Telerik.Web.UI
Imports Telerik.Web


Partial Class RemesaSeguimiento
    Inherits System.Web.UI.Page
    Dim csSQLsvr As New BaseDatosSQL
    Dim resp As New Resultado
    'Private master As MasterPage
    Dim VentanasWin As New Ventanas
    Dim csDAL As New DALClass

    'VARIABLES
    Private _cliente As Integer
    Private _region As Integer
    Private _estado As Integer
    Private _poliza As String
    Private _fechai As String
    Private _fechaf As String
    Private _fechai0 As String
    Private _fechaf0 As String
    Private _TipoSeg As String
    Private _Medio As String
    'PROPIEDADES

    'enumerado del grid
    ''' <summary>
    ''' enumerado del grid(columnas
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Enum ColGrid
        Gestion = 2
        NoGestion2
        Poliza
        Estado
        Municipio
        Cliente
        TipoServicio
        FechaHoraCita
        DiasTranscurridos
        SegACita
        SegDCita
        SegATramite
        SegEnvDoc
        Int
        SigAc
        FecLimSeg
        ExpeRec
        MotiRec

    End Enum

    Public Property TipoSeg As String
        Set(value As String)
            _TipoSeg = value
        End Set
        Get
            Return _TipoSeg
        End Get
    End Property


    Public Property strQuery As String
        Set(value As String)
            ViewState("_strquery") = value
        End Set
        Get
            Return ViewState("_strquery")
        End Get
    End Property

    Public Property Poliza() As String
        Set(value As String)
            _poliza = value
        End Set
        Get
            Return _poliza
        End Get
    End Property
    Public Property Estado() As String
        Set(value As String)
            _estado = value
        End Set
        Get
            Return _estado
        End Get
    End Property
    Public Property Medio() As String
        Set(value As String)
            _Medio = value
        End Set
        Get
            Return _Medio
        End Get
    End Property
    Public Property Region() As String
        Set(value As String)
            _region = value
        End Set
        Get
            Return _region
        End Get
    End Property

    Public Property Cliente() As String
        Set(value As String)
            _cliente = value
        End Set
        Get
            Return _cliente
        End Get
    End Property

    Public Property FechaI() As String
        Set(value As String)
            _fechai = value
        End Set
        Get
            Return _fechai
        End Get
    End Property

    Public Property FechaF() As String
        Set(value As String)
            _fechaf = value
        End Set
        Get
            Return _fechaf
        End Get
    End Property

    Public Property FechaI0() As String
        Set(value As String)
            _fechai0 = value
        End Set
        Get
            Return _fechai0
        End Get
    End Property

    Public Property FechaF0() As String
        Set(value As String)
            _fechaf0 = value
        End Set
        Get
            Return _fechaf0
        End Get
    End Property

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        VentanasWin = New Ventanas(Master)
        strQuery = String.Empty
        If Not Page.IsPostBack Then

            cargaClientes()
            CargaTipoSeg()
            cargaEstados()
            Seleccioninicialfechas()
            ReasignaFiltros()
            EvaluaCondiciones()
            CargarGrid()
            cargaTipoSeguimiento()


        End If
    End Sub

    Public Sub cargaTipoSeguimiento()
        csSQLsvr.LlenarRadCombo(cmbSeguimiento, "SELECT catTipoSeg_clvTipoSeg,catTipoSeg_Descripcion FROM catTipoSeguimiento", Session("connGestion"))
    End Sub
    Public Sub cargaClientes()
        Dim comando As String = "exec Select_cbo_clientes"
        csSQLsvr.LlenarRadCombo(cmbEstado, comando, Session("connGestion"))
    End Sub


    Public Sub cargaEstados()

        Dim comando As String = "exec Select_cbo_estados"
        csSQLsvr.LlenarRadCombo(cmbEstado, comando, Session("connGestion"))

    End Sub
    Public Sub CargaMpio(ByVal clvEstado As Integer)

        Dim comando As String = "exec Select_cbo_Municipios " & clvEstado
        csSQLsvr.LlenarRadCombo(cboMpio, comando, Session("connGestion"))
    End Sub
    Public Sub CargaTipoSeg()

        Dim comando As String = "exec Select_cbo_TipoSeguimientoAsigCat "
        csSQLsvr.LlenarRadCombo(cmbSeguimiento, comando, Session("connGestion"))
    End Sub

    Public Function SetFechas()
        Dim FechaActual As System.DateTime
        Dim answer As System.DateTime
        FechaActual = System.DateTime.Now
        answer = FechaActual.AddDays(-30)

        'answer = CDate(Today.Date.Year & "/" & Today.Date.Month & "/" & Today.Day - 30)
        Me.rdDtpFI.SelectedDate = answer
        Me.rdDtpFF.SelectedDate = DateTime.Now.Date


    End Function

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        ValidaParametros()
        strQuery = String.Empty
    End Sub
    Private Function EvaluaCondiciones() As Boolean
        GetCliente()
        GetOpcion()

        GetEstado()
        GetPoliza()
        GetTipoSeguimiento()


    End Function

    Private Function GetTipoSeguimiento()
        'TipoSeg = cmbSeguimiento.SelectedValue
        'If (TipoSeg <> 0) Then
        '    strQuery = strQuery + "AND RGT.region = " + TipoSeg + " "
        'End If
    End Function

    Private Function ValidaParametros()
        Dim Ds As New DataSet
        EvaluaCondiciones()
        CargarGrid()
    End Function

    Private Function GetPoliza() As Boolean
        Poliza = txtRemesa.Text
        If (String.IsNullOrEmpty(Poliza) = False) Then
            strQuery = strQuery + "AND RGT.Reporte_poliza = ''" + Poliza + "'' "
        End If
        Return True
    End Function
    'Private Function GetRegion() As Boolean
    '    Region = cmbRegion.SelectedValue
    '    If (Region <> 0) Then
    '        strQuery = strQuery + "AND RGT.region = " + Region + " "
    '    End If
    '    Return True
    'End Function
    'Private Function GetMedio() As Boolean
    '    Medio = cboMedActiv.SelectedValue
    '    If Medio = Nothing Then
    '        Medio = 0
    '    End If
    '    If (Medio <> 0) Then
    '        strQuery = strQuery + "AND MC.Medio_Contacto  = " + Medio + " "
    '    End If
    '    Return True
    'End Function

    Private Function GetEstado() As Boolean
        Estado = cboMpio.SelectedValue
        If (Estado <> 0) Then
            strQuery = strQuery + "AND RGT.Reporte_clvEstado = " + Estado + " "
        End If
        Return True
    End Function

    Private Function GetOpcion() As Boolean

        'If rdDtpFI.SelectedDate Is Nothing Then
        '    'Dim FechaActual As System.DateTime
        '    'Dim answer As System.DateTime
        '    'FechaActual = System.DateTime.Now
        '    'answer = FechaActual.AddDays(-30)

        '    ''answer = CDate(Today.Date.Year & "/" & Today.Date.Month & "/" & Today.Day - 30)
        '    'Me.rdDtpFI.SelectedDate = answer
        '    'Me.rdDtpFF.SelectedDate = DateTime.Now.Date



        '    FechaI = rdDtpFI.SelectedDate.Value.ToString("yyyy-MM-dd") '  .SelectedDate .ToString("yyyy-MM-dd")
        '    FechaF = rdDtpFF.SelectedDate.Value.ToString("yyyy-MM-dd") '.ToString("yyyy-MM-dd")
        '    strQuery = strQuery + "AND FechaCita >= ''" + FechaI + "'' AND FechaCita <= ''" + (DateAdd(DateInterval.Day, 1, CDate(FechaF))).ToString("yyyy-MM-dd") + "'' "

        'Else
        '    If strQuery IsNot Nothing Then
        '        If strQuery.Contains("AND FechaCita >=") = False Then
        '            FechaI = rdDtpFI.SelectedDate.Value.ToString("yyyy-MM-dd") '  .SelectedDate .ToString("yyyy-MM-dd")
        '            FechaF = rdDtpFF.SelectedDate.Value.ToString("yyyy-MM-dd") '.ToString("yyyy-MM-dd")
        '            strQuery = strQuery + "AND FechaCita >= ''" + FechaI + "'' AND FechaCita <= ''" + (DateAdd(DateInterval.Day, 1, CDate(FechaF))).ToString("yyyy-MM-dd") + "'' "
        '        End If
        '    End If


        'End If

        '    Dim FechaActual As System.DateTime
        '    Dim answer As System.DateTime
        '    FechaActual = System.DateTime.Now
        '    answer = FechaActual.AddDays(-30)

        '    'answer = CDate(Today.Date.Year & "/" & Today.Date.Month & "/" & Today.Day - 30)

        '    Me.rdDtpFI.SelectedDate = answer
        '    Me.rdDtpFF.SelectedDate = DateTime.Now.Date


        '    strQuery = strQuery + "AND Reporte_FechaRepor >= ''" + FechaI + "'' AND Reporte_FechaRepor <= ''" + (DateAdd(DateInterval.Day, 1, CDate(FechaF))).ToString("yyyy-MM-dd") + "'' "






        'answer = CDate(Today.Date.Year & "/" & Today.Date.Month & "/" & Today.Day - 30)

        'FechaI = rdDtpFI.SelectedDate.Value.ToString("yyyy-MM-dd") '  .SelectedDate .ToString("yyyy-MM-dd")
        'FechaF = rdDtpFF.SelectedDate.Value.ToString("yyyy-MM-dd") '.ToString("yyyy-MM-dd")
        'strQuery = strQuery + "AND RGT.Reporte_FechaRepor >= ''" + FechaI + "'' AND RGT.Reporte_FechaRepor <= ''" + (DateAdd(DateInterval.Day, 1, CDate(FechaF))).ToString("yyyy-MM-dd") + "'' "
    End Function

    Private Function GetCliente() As Boolean
        Cliente = cmbEstado.SelectedValue
        If (Cliente <> 0) Then
            strQuery = strQuery + "AND RGT.Reporte_cliente = " + Cliente + " "
        End If
        Return True
    End Function

    Protected Sub radSeguimiento_PageSizeChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridPageSizeChangedEventArgs) Handles radSeguimiento.PageSizeChanged
        Dim num As Integer
        num = e.NewPageSize
        CargarGrid()
    End Sub

    Private Sub CargarGrid()
        'Prepara el datatable
        'resp = serv.Consultar_Conductores(Session("IdUsuario"), -1)
        'resp.DataTable.DefaultView.Sort = ""
        'ViewState("dataset") = resp.datatable ' Lo almacena en el viewstate para poder paginar






        resp.DataTable = csSQLsvr.QueryDataDatable("exec spGetSeguimientoGestoria '" & strQuery & "'", Session("connGestion"))
        ViewState("dataset") = resp.DataTable

        If cmbSeguimiento.SelectedValue <> "0" And cmbSeguimiento.SelectedValue <> "-1" And cmbSeguimiento.SelectedValue <> "" Then
            TipoSeguimiento()
        End If



        'csSQLsvr.LlenarRadGridCustom(radSeguimiento, "exec spGetSeguimientoGestoria", Session("connGestion"), numPage)

        ' Carga el grid
        radSeguimiento.CurrentPageIndex = 0
        radSeguimiento.DataSource = ViewState("dataset")
        radSeguimiento.DataBind()
        radSeguimiento.Dispose()

        RecalculaValoresGrid()

        'lblNumcitas.Text = resp.DataTable.Rows.Count


        ''UpdatePanelGrid.Update()
    End Sub

    Public Sub TipoSeguimiento()

        Dim DV1 As New DataView(ViewState("dataset"))
        Select Case cmbSeguimiento.SelectedValue

            Case 1
                DV1.RowFilter = "isnull(Convert(datosSeguimiento_FechaAlta, 'System.String'), '') = '' and SigAc <> 'Seguimiento a trámite Contácto Gestor.' and isnull(Convert(CausaTerm, 'System.String'), '') = '' "
                'strQuery = "AND  FechaCita between dateadd(day,-1,GETDATE()) and dateadd(day,1,GETDATE()) AND  DSC.datosSeguimiento_FechaAlta is null "
            Case 2
                Dim filtro As String
                filtro = "SigAc = 'Seguimiento a Trámite'  "
                filtro = filtro & " or  (isnull(Convert(datosSeguimiento_FechaAlta, 'System.String'), '') <> '' and isnull(Convert(CausaTerm, 'System.String'), '') <> 'Tramite concluido' )"
                filtro = filtro & " and isnull(Convert(CausaTerm, 'System.String'), '') <> 'Documentación incompleta '"
                DV1.RowFilter = filtro
                'strQuery = "AND  DSC.datosSeguimiento_FechaAlta between dateadd(day,-1,GETDATE()) and dateadd(day,1,GETDATE()) "
            Case 3
                Dim filtro As String
                filtro = "isnull(Convert(CausaTerm, 'System.String'), '') = 'Tramite concluido' and SigAc = 'Pasar Siguiente Etapa: Segiomiento a Envio de Documento  Intentar: Inmediatamente' or (isnull(Convert(CausaTerm, 'System.String'), '') = 'Tramite concluido' and SigAc = 'Nuevo Intento de Llamada Intentar:10 minutos')"
                filtro = filtro & " or (isnull(Convert(CausaTerm, 'System.String'), '') = 'Documentación incompleta ')"
                DV1.RowFilter = filtro

                'Pasar Siguiente Etapa: Segiomiento a Envio de Documento  Intentar: Inmediatamente
                'SigAc = 'Pasar Siguiente Etapa: Segiomiento a Envio de Documento Intentar: Inmediatamente'
                'strQuery = "AND  DSC.datosSeguimiento_FechaAlta between dateadd(day,-1,GETDATE()) and dateadd(day,1,GETDATE()) AND  DSC.datosSeguimiento_FechaAlta is not null "
                'strQuery = "AND  ExpRec = GETDATE() "

        End Select

        ViewState("dataset") = DV1.ToTable()

    End Sub

    Public Sub RecalculaValoresGrid()

        lblNumcitas.Text = ViewState("dataset").rows.count ' resp.DataTable.Rows.Count

        Dim DV As New DataView(ViewState("dataset"))
        DV.RowFilter = "isnull(Convert(datosSeguimiento_FechaAlta, 'System.String'), '') = '' and SigAc <> 'Seguimiento a trámite Contácto Gestor.' and isnull(Convert(CausaTerm, 'System.String'), '') = '' "
        lblPendientesconcretar.Text = DV.Count()

        Dim filtro As String
        filtro = "SigAc = 'Seguimiento a Trámite'  "
        filtro = filtro & " or  (isnull(Convert(datosSeguimiento_FechaAlta, 'System.String'), '') <> '' and isnull(Convert(CausaTerm, 'System.String'), '') <> 'Tramite concluido' )"
        filtro = filtro & " and isnull(Convert(CausaTerm, 'System.String'), '') <> 'Documentación incompleta '"


        '        DV.RowFilter = "SigAc = 'Seguimiento a Trámite' and CausaTerm <> 'Tramite concluido'  "
        DV.RowFilter = filtro
        Dim causa As Integer = DV.Count()
        lblPendientesSeguimiento.Text = causa

        'DV.RowFilter = "(isnull(Convert(datosSeguimiento_FechaAlta, 'System.String'), '') = '' and CausaTerm = 'Tramite concluido') or SigAc = 'Reportar a supervisor de RED este servicioIntentar:Inmediatamente'"


        DV.RowFilter = "isnull(Convert(CausaTerm, 'System.String'), '') = 'Tramite concluido' or (isnull(Convert(CausaTerm, 'System.String'), '') <> 'Documentacion incompleta' and isnull(Convert(CausaTerm, 'System.String'), '') = 'Documentación incompleta ')"
        causa = DV.Count()
        lblSeguimeintoEnvio.Text = causa
        'lblNumcitas.Text(-causa)

    End Sub

    Protected Sub radSeguimiento_PageIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridPageChangedEventArgs) Handles radSeguimiento.PageIndexChanged
        ' Paginación
        Dim dt As DataTable = ViewState("dataset")
        radSeguimiento.DataSource = dt.DefaultView
        radSeguimiento.DataBind()
        radSeguimiento.Dispose()
        'UpdatePanelGrid.Update()
    End Sub

    Protected Sub radSeguimiento_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles radSeguimiento.ItemCommand
        Select Case e.CommandName

            Case "cmdNoGestion"

                Dim r As GridItem = e.Item
                Dim master As MasterPageGestionOperativa = DirectCast(Me.Master, MasterPageGestionOperativa)
                Dim nExpediente As Telerik.Web.UI.RadNumericTextBox = Me.Master.FindControl("txtNoGestion")
                nExpediente.Text = r.Cells(ColGrid.NoGestion2).Text
                Session("Gestion") = r.Cells(ColGrid.NoGestion2).Text
                master.CargaDatosExpediente()
                'master.Response.Redirect("~/AsignacionControl/Seguimiento.aspx")
                Dim redireccion As String = "~/AsignacionControl/Seguimiento.aspx?Detalle=1" & ResguardaFiltros()
                master.Response.Redirect(redireccion)

            Case "cmdSegACita"

                Dim r As GridItem = e.Item
                Dim indexRow As Integer = Convert.ToInt32(e.Item.ItemIndex)
                Dim item As GridDataItem = radSeguimiento.Items(indexRow)
                Dim item3 As GridDataItem = DirectCast(e.Item, GridDataItem)
                Dim lnkSegACita As LinkButton = DirectCast(item3("SegACita").Controls(0), LinkButton)
                Session("Gestion") = r.Cells(ColGrid.NoGestion2).Text
                Session("Usuario") = Session("clvUsuario")
                VentanasWin.Abrir_winSegACita()

            Case "cmdSegDCita"

                Dim r As GridItem = e.Item
                Dim item3 As GridDataItem = DirectCast(e.Item, GridDataItem)
                Session("Gestion") = r.Cells(ColGrid.NoGestion2).Text
                VentanasWin.Abrir_winSegDCita()

            Case "cmdSegTramite"
                Dim r As GridItem = e.Item
                Dim item3 As GridDataItem = DirectCast(e.Item, GridDataItem)
                Session("Gestion") = r.Cells(ColGrid.NoGestion2).Text
                VentanasWin.Abrir_winSegTramite()

            Case "cmdSegEnvDoc"
                Dim r As GridItem = e.Item
                Dim item3 As GridDataItem = DirectCast(e.Item, GridDataItem)
                Session("Gestion") = r.Cells(ColGrid.NoGestion2).Text
                VentanasWin.Abrir_winSegEnvDoc()

            Case "CmdNumRechazos"
                Dim r As GridItem = e.Item
                Dim item3 As GridDataItem = DirectCast(e.Item, GridDataItem)
                Session("Gestion") = r.Cells(ColGrid.NoGestion2).Text
                VentanasWin.Abrir_winwinSegDetRec()

            Case Else

        End Select

    End Sub

    Protected Sub radSeguimiento_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles radSeguimiento.ItemDataBound
        If TypeOf e.Item Is GridDataItem Then
            Dim gridDataItem As GridDataItem = CType(e.Item, GridDataItem)
            'Dim strColumnValue As String = gridDataItem("FieldName").Text
            'DO SOMETHING
            'gridDataItem("FieldName").Text = strColumnValue
        End If
    End Sub

    Protected Sub RadAjaxManager1_AjaxRequest(ByVal sender As Object, ByVal e As UI.AjaxRequestEventArgs) 'Handles RadAjaxManager1.AjaxRequest
        ' RadAjaxManager1.RaisePostBackEvent("Rebind")
        If e.Argument = "Rebind" Then
            radSeguimiento.MasterTableView.SortExpressions.Clear()
            radSeguimiento.MasterTableView.GroupByExpressions.Clear()
            radSeguimiento.Rebind()
            CargarGrid()
        ElseIf e.Argument = "RebindAndNavigate" Then
            radSeguimiento.MasterTableView.SortExpressions.Clear()
            radSeguimiento.MasterTableView.GroupByExpressions.Clear()
            radSeguimiento.MasterTableView.CurrentPageIndex = radSeguimiento.MasterTableView.PageCount - 1
            radSeguimiento.Rebind()
        End If
        'RadAjaxManager1.EnableAJAX = False
    End Sub

    Protected Sub radSeguimiento_ItemCreated(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles radSeguimiento.ItemCreated
        'If TypeOf e.Item Is GridDataItem Then
        '    Dim editLink As HyperLink = DirectCast(e.Item.FindControl("EditLink"), HyperLink)
        '    editLink.Attributes("href") = "javascript:void(0);"
        '    editLink.Attributes("onclick") = [String].Format("return ShowEditForm('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues(e.Item.ItemIndex)("EmployeeID"), e.Item.ItemIndex)
        'End If
    End Sub

    Protected Sub detalle1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles detalle1.Click

        If Session("noGestionIntegral") <> "" Then

            VentanasWin.Abrir_winwinDetalleSeguimientoGestor()
            RecalculaValoresGrid()
        Else
            ConfigureNotification("Favor de seleccionar un numero de servicio")
        End If

    End Sub

    Protected Sub RadButton3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButton3.Click

        If Session("noGestionIntegral") <> "" Then

            VentanasWin.Abrir_winwinDetalleSeguimientoLlamada()
            RecalculaValoresGrid()
        Else
            ConfigureNotification("Favor de seleccionar un numero de servicio")
        End If

    End Sub

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


    Public Function ResguardaFiltros() As String
        Dim poliza As String = txtRemesa.Text
        Dim cliente As String = cmbEstado.SelectedValue
        'Dim tipoServicio As String = cmbSeguimiento.SelectedValue
        Dim FechaInicio As String = csDAL.FormatoFecha(rdDtpFI.SelectedDate.Value.ToString())
        Dim FechaFinal As String = csDAL.FormatoFecha(rdDtpFF.SelectedDate.Value.ToString())

        Dim Estado As String = cboMpio.SelectedValue
        Dim seguimiento As String = cmbSeguimiento.SelectedValue

        Dim cadena As String = ""

        If poliza <> "" Then
            cadena = "&Poliza=" & poliza
        End If

        If cliente <> "" Then
            cadena = cadena & "&Cliente=" & cliente
        End If

        'If tipoServicio <> "" Then
        '    cadena = cadena & "&Tipo=" & tipoServicio
        'End If

        cadena = cadena & "&FIni=" & FechaInicio & "&FFin=" & FechaFinal

        'If Regional <> "" Then
        '    cadena = cadena & "&Regional=" & Regional
        'End If

        If Estado <> "" Then
            cadena = cadena & "&Estado=" & Estado
        End If

        If seguimiento <> "" Then
            cadena = cadena & "&EstatusSeguimiento=" & seguimiento
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
        Dim EstatusSeguimiento As String = Request.QueryString("EstatusSeguimiento")

        If poliza <> "" Then
            txtRemesa.Text = poliza
        End If

        If cliente <> "" Then
            cmbEstado.SelectedValue = cliente
        End If

        'If tipoServicio <> "" Then
        '    cmbSeguimiento.SelectedValue = tipoServicio
        'End If

        If FechaInicio <> "" Then
            rdDtpFI.SelectedDate = FechaInicio
        End If

        If FechaFinal <> "" Then
            rdDtpFF.SelectedDate = FechaFinal
        End If

        'If Regional <> "" Then
        '    cmbRegion.SelectedValue = Regional
        'End If

        If Estado <> "" Then
            cboMpio.SelectedValue = Estado
        End If

        If EstatusSeguimiento <> "" Then
            cmbSeguimiento.SelectedValue = EstatusSeguimiento
        End If

    End Sub


    Protected Sub Button1_Click(sender As Object, e As System.EventArgs) Handles BtnActualiza.Click
        EvaluaCondiciones()
        CargarGrid()
    End Sub



    Public Sub Rechazos()

        Dim DV1 As New DataView(ViewState("dataset"))

        DV1.RowFilter = "isnull(Convert(NúmeroRechazos, 'System.String'), '') <> '0' "
        'strQuery = "AND  FechaCita between dateadd(day,-1,GETDATE()) and dateadd(day,1,GETDATE()) AND  DSC.datosSeguimiento_FechaAlta is null "

        ViewState("dataset") = DV1.ToTable()

    End Sub



    Public Sub Seleccioninicialfechas()

        Finicio.Visible = True
        Ffinal.Visible = True
        rdDtpFF.Visible = True
        rdDtpFI.Visible = True
    End Sub

    Protected Sub cmbEstado_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbEstado.SelectedIndexChanged
        CargaMpio(cmbEstado.SelectedValue)
    End Sub
End Class
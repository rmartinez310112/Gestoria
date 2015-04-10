Imports System.Data
Imports Telerik.Web.UI
Imports Telerik.Web
Imports Telerik

Partial Class RemesaAsignarGestor

    Inherits System.Web.UI.Page
    Dim csNeg As New ClaseNegocios
    Dim csSQLsvr As New BaseDatosSQL
    Dim csDAL As New DALClass
    Dim Cadena As String = GlobalVariables.sqlString
    Dim VentanasWin As New Ventanas



    Public Sub CargaMpio(ByVal clvEstado As Integer)

        Dim comando As String = "exec Select_cbo_Municipios " & clvEstado
        csSQLsvr.LlenarRadCombo(cboMpio, comando, Session("connGestion"))
    End Sub

    Public Sub CargaTipoSeg()

        Dim comando As String = "exec Select_cbo_TipoSeguimientoAsigCat "
        csSQLsvr.LlenarRadCombo(cboStatusAsigna, comando, Session("connGestion"))
    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        LlenaGrid()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        VentanasWin = New Ventanas(Master)

        If Not Page.IsPostBack Then
            csDAL.CargaEstados(cboEstado)
            'cargaEstados(cboRegion.SelectedValue)
            'cargaClientes()
            'cargaRegion()
            'cargaServicioTipo()
            CargaTipoSeg()
            SetFechas()
            ReasignaFiltros()
            LlenaGrid()

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

        Dim remesa As String = txtRemesa.Text
        'Dim cliente As String = CboCliente.SelectedValue
        'Dim tipoServicio As String = cboServicioTipo.SelectedValue
        Dim FechaInicio As String = rdFI.SelectedDate.Value.ToString("yyyyMMdd")
        Dim FechaFinal As String = rdFF.SelectedDate.Value.ToString("yyyyMMdd")
        'Dim Regional As String = cboRegion.SelectedValue
        Dim Estado As String = cboEstado.SelectedValue
        Dim EstatusAsignacion As String = cboStatusAsigna.SelectedValue
        Dim Orden As String = ""


        Dim dt As New DataTable

        Dim _filtros As String = " WHERE RG.RFC_Gestor = '''' "

        dt = csDAL.RemesaCargaAsignaciones(_filtros)


        If dt.Rows.Count <> 0 Then
            ViewState("dataset") = dt
            radRemesaAsignacion.CurrentPageIndex = 0
            radRemesaAsignacion.DataSource = dt
            radRemesaAsignacion.DataBind()
            radRemesaAsignacion.Dispose()
            'UpdatePanelGrid.Update()

            lblNumServ.Text = dt.Rows.Count

        Else

            ''Mensage de que no se tienen valores a mostrar
            radRemesaAsignacion.Rebind()
            csDAL.ConfigureNotification(RadNotification2, "No existen datos a mostrar.")

        End If
    End Sub

    'Protected Sub chkJuridico_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkJuridico.CheckedChanged
    '    LlenaGrid()
    'End Sub

    'Protected Sub cboRegion_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cboRegion.SelectedIndexChanged
    '    'cargaEstados(cboRegion.SelectedValue)
    'End Sub

    Protected Sub radSeguimiento_PageIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridPageChangedEventArgs) Handles radRemesaAsignacion.PageIndexChanged

        'Paginación
        Dim dt As DataTable = ViewState("dataset")
        radRemesaAsignacion.DataSource = dt.DefaultView
        radRemesaAsignacion.DataBind()
        radRemesaAsignacion.Dispose()
        UpdatePanelGrid.Update()
        RecalculaValoresGrid()
    End Sub

    Protected Sub grid_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles radRemesaAsignacion.ItemCommand

        RecalculaValoresGrid()

        If e.CommandName = "cmdcontactar" Then
            Dim indexRow As Integer = Convert.ToInt32(e.Item.ItemIndex)

            Dim item As GridDataItem = radRemesaAsignacion.Items(indexRow)
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

            Dim redireccion As String = "~/AsignacionControl/AsignarGestor_Pendiente1.aspx?Detalle=1" & ResguardaFiltros()
            master.Response.Redirect(redireccion)

        ElseIf e.CommandName = "cmdAsignacion" Then

            Session("NumRemesa") = "RM20151"
            If Session("NumRemesa") <> "" Then

                VentanasWin.Abrir_WinWinRemesaPrimerContacto()
                '    RecalculaValoresGrid()

            Else

                csDAL.ConfigureNotification(RadNotification2, "Favor de seleccionar un numero de servicio")

            End If


            Dim indexRow As Integer = Convert.ToInt32(e.Item.ItemIndex)

            Dim item As GridDataItem = radRemesaAsignacion.Items(indexRow)
            Dim item3 As GridDataItem = DirectCast(e.Item, GridDataItem)
            Dim sGestion As String = DirectCast(item3("cmdNumservicio").Controls(0), LinkButton).Text
            Session("NumGestionSeguimiento") = sGestion
            Dim p_estado As String = Mid(sGestion, 9, 2)

            Session("estado") = p_estado

            VentanasWin.Abrir_winwinPrimerCg()

        ElseIf e.CommandName = "CmdEnlaceAsignacion" Then

            Dim indexRow As Integer = Convert.ToInt32(e.Item.ItemIndex)

            Dim item As GridDataItem = radRemesaAsignacion.Items(indexRow)
            Dim item3 As GridDataItem = DirectCast(e.Item, GridDataItem)
            Dim sRemesa As String = DirectCast(item3("cmdNumRemesa").Controls(0), LinkButton).Text
            Session("NumRemesa") = sRemesa

            VentanasWin.Abrir_WinWinRemesaPrimerContacto()

            'Abrir_winwinRemesaEntregaCotizacion
            'RemesaEntregaCotizacion.aspx

            'CmdEnlaceAsignacion

        ElseIf e.CommandName = "CmdEnlaceEntrega" Then

            Dim indexRow As Integer = Convert.ToInt32(e.Item.ItemIndex)

            Dim item As GridDataItem = radRemesaAsignacion.Items(indexRow)
            Dim item3 As GridDataItem = DirectCast(e.Item, GridDataItem)
            Dim sRemesa As String = DirectCast(item3("cmdNumRemesa").Controls(0), LinkButton).Text
            Session("NumRemesa") = sRemesa

            VentanasWin.Abrir_WinWinRemesaRecepcionDocumentos()

            'Abrir_winwinRemesaEntregaCotizacion
            'RemesaEntregaCotizacion.aspx

            'CmdEnlaceAsignacion

        ElseIf e.CommandName = "CmdEnlaceCotizacion" Then



            Dim indexRow As Integer = Convert.ToInt32(e.Item.ItemIndex)

            Dim item As GridDataItem = radRemesaAsignacion.Items(indexRow)
            Dim item3 As GridDataItem = DirectCast(e.Item, GridDataItem)
            Dim sRemesa As String = DirectCast(item3("cmdNumRemesa").Controls(0), LinkButton).Text
            Session("NumRemesa") = sRemesa

            VentanasWin.Abrir_winwinRemesaEntregaCotizacion()
            'Abrir_winwinRemesaEntregaCotizacion
            'RemesaEntregaCotizacion.aspx

            'CmdEnlaceAsignacion


        End If

    End Sub



    Protected Sub RadAjaxManager1_AjaxRequest(ByVal sender As Object, ByVal e As Web.UI.AjaxRequestEventArgs) Handles RadAjaxManager1.AjaxRequest

        If e.Argument = "Rebind" Then
            radRemesaAsignacion.MasterTableView.SortExpressions.Clear()
            radRemesaAsignacion.MasterTableView.GroupByExpressions.Clear()
            radRemesaAsignacion.Rebind()
            LlenaGrid()
            RecalculaValoresGrid()
        ElseIf e.Argument = "RebindAndNavigate" Then
            radRemesaAsignacion.MasterTableView.SortExpressions.Clear()
            radRemesaAsignacion.MasterTableView.GroupByExpressions.Clear()
            radRemesaAsignacion.MasterTableView.CurrentPageIndex = radRemesaAsignacion.MasterTableView.PageCount - 1
            radRemesaAsignacion.Rebind()
        End If
    End Sub

    Public Sub RecalculaValoresGrid()
        Dim cuentaContactoCliente As Integer = 0
        Dim cuentaContactoGestor As Integer = 0
        For Each item As GridDataItem In radRemesaAsignacion.Items

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
        Dim poliza As String = txtRemesa.Text
        'Dim cliente As String = CboCliente.SelectedValue
        'Dim tipoServicio As String = cboServicioTipo.SelectedValue
        Dim FechaInicio As String = csDAL.FormatoFecha(rdFI.SelectedDate.Value.ToString())
        Dim FechaFinal As String = csDAL.FormatoFecha(rdFF.SelectedDate.Value.ToString())
        'Dim Regional As String = cboRegion.SelectedValue
        Dim Estado As String = cboEstado.SelectedValue
        Dim EstatusAsignacion As String = cboStatusAsigna.SelectedValue

        Dim cadena As String = ""

        If poliza <> "" Then
            cadena = "&Poliza=" & poliza
        End If

        'If cliente <> "" Then
        '    cadena = cadena & "&Cliente=" & cliente
        'End If

        'If tipoServicio <> "" Then
        '    cadena = cadena & "&Tipo=" & tipoServicio
        'End If

        'cadena = cadena & "&FIni=" & FechaInicio & "&FFin=" & FechaFinal

        'If Regional <> "" Then
        '    cadena = cadena & "&Regional=" & Regional
        'End If

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
            txtRemesa.Text = poliza
        End If

        'If cliente <> "" Then
        '    CboCliente.SelectedValue = cliente
        'End If

        'If tipoServicio <> "" Then
        '    cboServicioTipo.SelectedValue = tipoServicio
        'End If

        'If FechaInicio <> "" Then
        '    rdFI.SelectedDate = FechaInicio
        'End If

        'If FechaFinal <> "" Then
        '    rdFF.SelectedDate = FechaFinal
        'End If

        'If Regional <> "" Then
        '    cboRegion.SelectedValue = Regional
        'End If

        If Estado <> "" Then
            cboEstado.SelectedValue = Estado
        End If

        If EstatusAsignacion <> "" Then
            cboStatusAsigna.SelectedValue = EstatusAsignacion
        End If

    End Sub


    'Protected Sub ChkOrdenar_CheckedChanged(sender As Object, e As System.EventArgs) Handles ChkOrdenar.CheckedChanged
    '    If ChkOrdenar.Checked Then
    '        RadioButtonList1.Visible = True
    '    Else
    '        RadioButtonList1.Visible = False
    '    End If
    'End Sub

    Protected Sub cboEstado_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cboEstado.SelectedIndexChanged

        csDAL.CargaMpio(cboMpio, cboEstado.SelectedValue)

    End Sub


End Class
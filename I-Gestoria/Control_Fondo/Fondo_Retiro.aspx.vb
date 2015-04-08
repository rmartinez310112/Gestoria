Imports System.Data
Imports System.Web.UI.WebControls
Imports Telerik.Web.UI
Partial Class Control_Fondo_Fondo_Retiro
    Inherits System.Web.UI.Page

    Dim datfondo As New Datos_Fondos
    Dim resfondo As Resultado
    Dim bor As BorderStyle = BorderStyle.Dotted
    Dim col As Drawing.Color = Drawing.Color.Aqua
    Dim win As Ventanas

    Private Enum ColGrid
        Monto = 2
        FechaRegistro
        Usuario
        Cliente
        Motivo_Salida
        fechaDispersion
        usuarioDisperso
        fechaContabilidad
        usuarioContabilid
        Estatus
        MotivoRechazo
    End Enum

    Private Sub CargarDDLMotivoRetiro(ByVal cliente As Integer, ByVal tipo As Integer)
        ddlMotivoRetiro.Items.Clear()
        ddlMotivoRetiro.SelectedValue = Nothing
        resfondo = datfondo.Consulta_MotivosRetiros(cliente, tipo)

        'carga datos en ddl
        ddlMotivoRetiro.DataSource = resfondo.DataTable
        ddlMotivoRetiro.DataBind()

        'Agrega el campo inicial
        AgregarValorInicialDDL(ddlMotivoRetiro)
    End Sub

    Private Sub VerificaCamposInsertar()

        If txtNoServicio.Text.Trim <= "0" Or txtNoServicio.Text.Trim = "" Then
            ConfigureNotification("Anota el Número de Servicio Correspondiente", 300, 100)
            txtNoServicio.Focus()
            Session("Validacion") = "1"
            Exit Sub
        End If

        If txtMonto.Text.Trim <= "0" Or txtMonto.Text.Trim = "" Then
            ConfigureNotification("Anota el Monto Correspondiente", 300, 100)
            txtMonto.Focus()
            Session("Validacion") = "1"
            Exit Sub
        End If

        If ddlMotivoRetiro.SelectedValue = -1 Then
            ConfigureNotification("Anota el Motivo de Retiro", 300, 100)
            ddlMotivoRetiro.Focus()
            Session("Validacion") = "1"
            Exit Sub
        End If

        If txtMonto.Value > txtSaldoActual.Value Then
            win.Confirm("Saldo Insuficiente.¿Realizar petición de Retiro de todas formas?", "confirmCallBack_Guardar")
            Session("Validacion") = "1"
            Exit Sub
        End If

    End Sub

    Private Sub CargarGridRetiros()
        Dim fondo As New Retiro_Fondos

        fondo.Anio = Session("Anio")
        fondo.Cliente = Session("Cliente")
        fondo.Tipo = Session("Tipo")
        fondo.ClvEstado = Session("ClvEstado")
        fondo.Numero = Session("Numero")
        fondo.fase2 = 1

        griddepositos.MasterTableView.NoMasterRecordsText = IIf(txtNoServicio.Text = "", "Sin Retiros", "Sin Retiros del No. Servicio: " & txtNoServicio.Text)
        resfondo = datfondo.Consultar_Fondo_Retiro(fondo)

        ' Carga el grid
        griddepositos.DataSource = resfondo.DataTable
        griddepositos.DataBind()

        For Each item As GridDataItem In griddepositos.Items

            If item.Cells(ColGrid.fechaDispersion).Text = "&nbsp;" Then
                item.Cells(ColGrid.fechaDispersion).Text = "-----"
            End If

            If item.Cells(ColGrid.usuarioDisperso).Text = "&nbsp;" Then
                item.Cells(ColGrid.usuarioDisperso).Text = "-----"
            End If

            If item.Cells(ColGrid.fechaContabilidad).Text = "&nbsp;" Then
                item.Cells(ColGrid.fechaContabilidad).Text = "-----"
            End If

            If item.Cells(ColGrid.usuarioContabilid).Text = "&nbsp;" Then
                item.Cells(ColGrid.usuarioContabilid).Text = "-----"
            End If

            If item.Cells(ColGrid.MotivoRechazo).Text = "&nbsp;" Then
                item.Cells(ColGrid.MotivoRechazo).Text = "-----"
            End If

            Select Case item.Cells(ColGrid.Estatus).Text
                Case 1
                    item.Cells(ColGrid.Estatus).Text = "Pendiente para Tesoreria"
                Case 2
                    item.Cells(ColGrid.Estatus).Text = "Pendiente para Contabilidad"
                Case 3
                    item.Cells(ColGrid.Estatus).Text = "Retiro Rechazado"
                Case 4
                    item.Cells(ColGrid.Estatus).Text = "Retiro Realizado con Éxito"
            End Select
        Next

        resfondo = datfondo.Consulta_Clientes(IIf(Session("clvCliente") Is Nothing, -1, Session("clvCliente")))
        If resfondo.Estatus = Estatus.Exito Then
            If resfondo.DataTable.Rows.Count > 0 Then
                fondo.cliente_clvCliente = -1
                resfondo = datfondo.Consultar_MontoTotal_Ingreso_Retiro(fondo)
                If resfondo.Estatus = Estatus.Exito Then
                    If resfondo.DataTable.Rows.Count > 0 Then
                        Dim row As DataRow = resfondo.DataTable.Rows(0)
                        If row("Monto") Is DBNull.Value Or row("Monto") = 0 Then
                            txtSaldoServ.Text = "0.0"
                        Else
                            txtSaldoServ.Text = row("Monto")
                        End If
                    Else
                        txtSaldoServ.Text = "0.0"
                    End If
                Else
                    ConfigureNotification("Error al calcular el Saldo Retiro " & resfondo.ErrorDesc, 300, 100)
                    Exit Sub
                End If

                fondo.cliente_clvCliente = IIf(Session("clvCliente") Is Nothing, -1, Session("clvCliente"))
                resfondo = datfondo.Consultar_MontoTotal_Ingreso_Retiro(fondo)
                If resfondo.Estatus = Estatus.Exito Then
                    If resfondo.DataTable.Rows.Count > 0 Then
                        Dim row As DataRow = resfondo.DataTable.Rows(0)
                        If row("Monto") Is DBNull.Value Or row("Monto") = 0 Then
                            txtSaldoInicial.Text = "0.0"
                        Else
                            txtSaldoInicial.Text = row("Monto")
                        End If
                    Else
                        txtSaldoInicial.Text = "0.0"
                    End If
                Else
                    ConfigureNotification("Error al calcular Saldo Inicial " & resfondo.ErrorDesc, 300, 100)
                    Exit Sub
                End If

                fondo.Anio = 1
                resfondo = datfondo.Consultar_MontoTotal_Ingreso_Retiro(fondo)
                If resfondo.Estatus = Estatus.Exito Then
                    If resfondo.DataTable.Rows.Count > 0 Then
                        Dim row As DataRow = resfondo.DataTable.Rows(0)
                        If row("Monto") Is DBNull.Value Or row("Monto") = 0 Then
                            txtTotalRetiros.Text = "0.0"
                            txtSaldoActual.Text = txtSaldoInicial.Text
                        Else
                            txtTotalRetiros.Text = row("Monto")
                            txtSaldoActual.Text = txtSaldoInicial.Text - row("Monto")
                        End If
                    Else
                        txtTotalRetiros.Text = "0.0"
                        txtSaldoActual.Text = txtSaldoInicial.Text
                    End If
                Else
                    ConfigureNotification("Error al calcular Saldo Inicial " & resfondo.ErrorDesc, 300, 100)
                    Exit Sub
                End If
                Session("Check") = "Si"
            Else
                ConfigureNotification("Servicio Registrado con Cliente que no Maneja Fondos: " & Session("NomCliente"), 300, 100)
                btnGuardar.Visible = False
                'btnBeneficia.Visible = True
                'habilitar(False)
                Session("Fondos") = "No"
                BuscarClave()
                Exit Sub
            End If
        Else
            ConfigureNotification("Error al Consultar Cliente: " & resfondo.ErrorDesc, 300, 100)
            Exit Sub
        End If

    End Sub

    Protected Sub Obligatorios()
        txtNoServicio.BorderStyle = bor
        txtNoServicio.BorderWidth = 2
        txtNoServicio.BorderColor = col
        txtTipoServicio.BorderStyle = bor
        txtCliente.BorderStyle = bor
        txtAjustador.BorderStyle = bor
        txtCuentaClave.BorderStyle = bor
        txtEstado.BorderStyle = bor
        txtMonto.BorderStyle = bor
        txtMonto.BorderWidth = 2
        txtMonto.BorderColor = col
        ddlMotivoRetiro.BorderStyle = bor
        ddlMotivoRetiro.BorderColor = col
        txtNumAutorizaDis.BorderStyle = bor
        txtNumAutorizaDis.BorderWidth = 2
        txtNumAutorizaDis.BorderColor = col
        txtNumAutorizaCon.BorderStyle = bor
        txtNumAutorizaCon.BorderWidth = 2
        txtNumAutorizaCon.BorderColor = col
        lblUsuario.Text = Session("clvUsuario")
        calFecDisp.BorderStyle = bor
        calFecDisp.BorderColor = col
        calFecConta.BorderStyle = bor
        calFecConta.BorderColor = col
        'calFecDisp.SelectedDate = Date.Now
        'calFecConta.SelectedDate = Date.Now
        'calFecDisp.MaxDate = Date.Now
        'calFecConta.MaxDate = Date.Now
        'lblUsuarioDispersion.Text = Session("clvUsuario")
        'lblusuariocontabilidad.Text = Session("clvUsuario")
        If Session("permiso") = "No" Then
            Session("permiso") = ""
        Else
            ConfigureNotification("Campos Azules son Obligatorios", 300, 100)
        End If
        txtMotivoRechazo.BorderStyle = bor
    End Sub

    Protected Sub Limpiar()
        Check.Checked = False
        txtNoServicio.Text = ""
        txtTipoServicio.Text = ""
        txtAjustador.Text = ""
        txtCuentaClave.Text = ""
        txtEstado.Text = ""
        txtMonto.Text = ""
        txtCliente.Text = ""
        txtFecRegistro.Text = Date.Now
        lblUsuario.Text = ""
        ddlMotivoRetiro.SelectedValue = -1
        'calFecDisp.SelectedDate = calFecDisp.MaxDate
        txtNumAutorizaDis.Text = ""
        'calFecConta.SelectedDate = calFecConta.MaxDate
        txtNumAutorizaCon.Text = ""
        Session("Anio") = 0
        Session("Cliente") = 0
        Session("Tipo") = 0
        Session("ClvEstado") = 0
        Session("Numero") = 0
        Session("RfcGestor") = ""
        Session("clvCliente") = -1
        Session("NomCliente") = ""
        Session("Nuevo") = ""
        'Session("Fondos") = ""
        CargarGridRetiros()
    End Sub

    Protected Sub Limpiar2()
        btnCancelar.Visible = False
        btnBeneficia.Visible = False
        btnGuardar.Visible = False
    End Sub

    Protected Sub ConfigureNotification(ByVal texto As String, ByVal ancho As Integer, ByVal alto As Integer)
        RadNotification2.Title = "Atención"
        RadNotification2.Text = texto
        'Enum
        RadNotification2.Position = Telerik.Web.UI.NotificationPosition.Center
        RadNotification2.Animation = Telerik.Web.UI.NotificationAnimation.Fade
        'notificacion.ContentScrolling = Telerik.Web.UI.NotificationScrolling.Default
        RadNotification2.AutoCloseDelay = 4000
        'Unit
        RadNotification2.Width = ancho
        RadNotification2.Height = alto
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

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        win = New Ventanas(Master)
        If Session("nivel") Is Nothing Then
            Response.Redirect("~/InicioSesion.aspx")
            Exit Sub
        End If
        If Session("nivel") <> "02" And Session("nivel") <> "04" And Session("nivel") <> "08" And Session("nivel") <> "07" Then
            win.Alert("No tiene los privilegios para ingresar a la página de Retiro de Fondos, favor de consultar al administrador. Gracias", "Notificacion_Permiso")
            Session("permiso") = "No"
        End If

        If Not Page.IsPostBack Then
            Limpiar()
            Obligatorios()
            'calFecDisp.SelectedDate = Now()
            If Session("noGestionIntegral") Is Nothing Or Session("noGestionIntegral") Is DBNull.Value Then
                txtNoServicio.Text = ""
            Else
                txtNoServicio.Text = Session("noGestionIntegral")
                txtNoServicio_TextChanged(txtNoServicio.Text, e)
            End If
        End If
        If Page.IsPostBack Then
            If Request.Form("__EventTarget") = "Guardar" Then
                GuardarRetiro()
            End If

            If Request.Form("__EventTarget") = "Notificacion_Permiso" Then
                Regresar()
            End If
        End If
    End Sub

    Private Sub Regresar()
        Response.Redirect("~/Default2.aspx")
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As System.EventArgs) Handles btnCancelar.Click
        Limpiar()
        Limpiar2()
        griddepositos.DataSource = ""
        griddepositos.DataBind()
        Obligatorios()
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As System.EventArgs) Handles btnGuardar.Click
        If Check.Visible = True Then
            CargarGridRetiros()
            VerificaCamposInsertar()
            If Session("Validacion") = "1" Then
                Session("Validacion") = ""
                Exit Sub
            Else
                GuardarRetiro()
                Session("Validacion") = ""
            End If
        Else
            Session("clvCliente") = ViewState("clvCliente")
            Session("NomCliente") = ViewState("NomCliente")
            CargarGridRetiros()
            VerificaCamposInsertar()
            If Session("Validacion") = "1" Then
                Session("Validacion") = ""
                Exit Sub
            Else
                GuardarRetiro()
                Session("Validacion") = ""
            End If
        End If
    End Sub

    Private Function ConstruirRetiroFondo(ByVal fase As EnumFasesGuardar) As Retiro_Fondos
        Dim fondo As New Retiro_Fondos

        fondo.fase = fase

        fondo.Anio = Session("Anio")
        fondo.Cliente = Session("Cliente")
        fondo.Tipo = Session("Tipo")
        fondo.ClvEstado = Session("ClvEstado")
        fondo.Numero = Session("Numero")

        fondo.cliente_clvCliente = Session("clvCliente")
        fondo.monto = IIf(txtMonto.Text.Trim = "", 0, txtMonto.Text.Trim)
        fondo.motivosalida = ddlMotivoRetiro.SelectedItem.Text
        fondo.rfcgestor = Session("rfcGestor")
        fondo.clavedeposito = IIf(txtCuentaClave.Text.Trim = "", 0, txtCuentaClave.Text.Trim)
        fondo.usuario = lblUsuario.Text

        fondo.fechadispersion = IIf(IsNothing(calFecDisp.SelectedDate), #1/1/1900#, calFecDisp.SelectedDate)
        fondo.fechacontabilidad = IIf(IsNothing(calFecConta.SelectedDate), #1/1/1900#, calFecConta.SelectedDate)
        fondo.numautorizadis = IIf(txtNumAutorizaDis.Text.Trim = "", 0, txtNumAutorizaDis.Text.Trim)
        fondo.numautorizaconta = IIf(txtNumAutorizaCon.Text.Trim = "", 0, txtNumAutorizaCon.Text.Trim)
        fondo.usuariodipersion = lblUsuarioDispersion.Text
        fondo.usuariocontabilidad = lblusuariocontabilidad.Text

        fondo.usuarioAutoriza = lblUsuario.Text


        fondo.motivorechazo = txtMotivoRechazo.Text.Trim

        Return fondo
    End Function

    Protected Sub btnNuevo_Click(sender As Object, e As System.EventArgs) Handles btnNuevo.Click
        Limpiar()
        Obligatorios()
        CargarGridRetiros()
        btnNuevo.Visible = False
        habilitar(True)
    End Sub

    Protected Sub txtNoServicio_TextChanged(sender As Object, e As System.EventArgs) Handles txtNoServicio.TextChanged
        If txtNoServicio.Text.Trim > "0" And txtNoServicio.Text.Trim <> "" Then
            btnRechaza.Visible = False
            btnCancelar.Visible = False
            resfondo = datfondo.Consultar_NumServicio(txtNoServicio.Text)

            If resfondo.Estatus = Estatus.Exito Then
                If resfondo.DataTable.Rows.Count > 0 Then
                    Dim row As DataRow = resfondo.DataTable.Rows(0)

                    Session("Anio") = IIf(row("reporte_anio") Is DBNull.Value, 0, row("reporte_anio"))
                    Session("Cliente") = IIf(row("reporte_cliente") Is DBNull.Value, 0, row("reporte_cliente"))
                    Session("Tipo") = IIf(row("reporte_tipo") Is DBNull.Value, 0, row("reporte_tipo"))
                    Session("ClvEstado") = IIf(row("reporte_clvestado") Is DBNull.Value, 0, row("reporte_clvestado"))
                    Session("Numero") = IIf(row("reporte_numero") Is DBNull.Value, 0, row("reporte_numero"))

                    CargarDDLMotivoRetiro(Session("Cliente"), Session("Tipo"))
                    'hace la consulta para saber si el servicio tiene un proceso de la tabla de fondos_salidas
                    Dim fondo As New Retiro_Fondos

                    fondo.Anio = Session("Anio")
                    fondo.Cliente = Session("Cliente")
                    fondo.Tipo = Session("Tipo")
                    fondo.ClvEstado = Session("ClvEstado")
                    fondo.Numero = Session("Numero")
                    fondo.fase2 = 2

                    resfondo = datfondo.Consultar_Fondo_Retiro(fondo)

                    If resfondo.Estatus = Estatus.Exito Then
                        If resfondo.DataTable.Rows.Count > 0 Then
                            Dim ro As DataRow = resfondo.DataTable.Rows(0)
                            'supervisor

                            txtTipoServicio.Text = IIf(ro("TipoServicio") Is DBNull.Value, " ", ro("TipoServicio"))
                            txtCliente.Text = IIf(row("cliente_NomCliente") Is DBNull.Value, " ", row("cliente_NomCliente"))
                            txtAjustador.Text = IIf(ro("Ajustador") Is DBNull.Value, " ", ro("Ajustador"))
                            txtCuentaClave.Text = IIf(ro("ctaClaveDeposito") Is DBNull.Value, "0", ro("ctaClaveDeposito"))
                            txtEstado.Text = IIf(ro("Estado") Is DBNull.Value, " ", ro("Estado"))
                            txtMonto.Text = IIf(ro("Monto") Is DBNull.Value, " ", ro("Monto"))

                            Session("clvCliente") = IIf(row("reporte_cliente") Is DBNull.Value, -1, row("reporte_cliente"))
                            Session("clvCliente2") = IIf(ro("cliente_clvCliente") Is DBNull.Value, -1, ro("cliente_clvCliente"))

                            If Session("clvCliente") <> Session("clvCliente2") Then
                                Session("clvCliente") = Session("clvCliente2")
                            End If

                            Session("NomCliente") = IIf(ro("cliente_NomCliente") Is DBNull.Value, " ", row("cliente_NomCliente"))
                            ViewState("clvCliente") = IIf(ro("reporte_cliente") Is DBNull.Value, -1, row("reporte_cliente"))
                            ViewState("NomCliente") = IIf(ro("cliente_NomCliente") Is DBNull.Value, " ", row("cliente_NomCliente"))

                            txtFecRegistro.Text = IIf(ro("fechaAlta") Is DBNull.Value, Date.Now, ro("fechaAlta"))
                            lblUsuario.Text = IIf(ro("usuario") Is DBNull.Value, "-----", ro("usuario"))
                            ddlMotivoRetiro.SelectedItem.Text = IIf(ro("Motivo_Salida") Is DBNull.Value, "- Seleccione -", ro("Motivo_Salida"))

                            'If ro("Motivo_Salida") Is DBNull.Value Then
                            '    If Session("nivel") <> 2 Then
                            '        win.Alert("No tiene los privilegios para realizar una Solicitud de Retiro en la página de Retiro de Fondos, favor de consultar al administrador. Gracias", "Notificacion_Permiso")
                            '        Session("permiso") = "No"
                            '        Exit Sub
                            '    End If
                            'End If

                            'Autorizacion
                            If ro("Motivo_Salida") IsNot DBNull.Value And ro("NumAutorizaDispersion") Is DBNull.Value And (ro("UsuarioAutoriza") Is DBNull.Value Or ro("UsuarioAutoriza") Is DBNull.Value) Then
                                If Session("nivel") <> "02" Then
                                    win.Alert("No tiene los privilegios para realizar la siguiente acción de la página de Retiro de Fondos, favor de consultar al administrador. Gracias", "Notificacion_Permiso")
                                    Session("permiso") = "No"
                                    Exit Sub
                                End If

                                'lblfecdisp.Visible = True
                                'calFecDisp.Visible = True
                                calFecDisp.SelectedDate = IIf(ro("fechaDispersion") Is DBNull.Value, Date.Now, ro("fechaDispersion"))
                                calFecDisp.MaxDate = DateAdd(DateInterval.Day, 1, Date.Now)
                                calFecDisp.MinDate = ro("fechaAlta") 'CDate(ro("fechaAlta")).ToString("8/27/2014 00:00:00")
                                'lblnumautodis.Visible = True
                                'txtNumAutorizaDis.Visible = True
                                txtNumAutorizaDis.Text = IIf(ro("NumAutorizaDispersion") Is DBNull.Value, "", ro("NumAutorizaDispersion"))
                                lblusuariodisp.Visible = True
                                lblUsuarioDispersion.Visible = True
                                lblUsuarioDispersion.Text = IIf(ro("usuarioDisperso") Is DBNull.Value, Session("clvUsuario"), ro("usuarioDisperso"))
                                habilitarinsertar(False)
                                'lbldatosdis.Visible = True
                                btnBeneficia.Visible = False
                                btnCancelar.Visible = False
                                btnAutoriza.Visible = True
                                lblMotivoRechazo.Visible = True
                                txtMotivoRechazo.Visible = True
                                btnRechaza.Visible = True
                                btnGuardarConta.Visible = False

                                lbldatosconta.Visible = False
                                lblfecconta.Visible = False
                                calFecConta.Visible = False
                                lblnumautocont.Visible = False
                                txtNumAutorizaCon.Visible = False
                                lblusuarioconta.Visible = False
                                lblusuariocontabilidad.Visible = False
                                btnGuardarDisp.Visible = False
                                lblusuariodisp.Visible = False
                                lblUsuarioDispersion.Visible = False

                            End If

                            'Dispersion
                            If ro("Motivo_Salida") IsNot DBNull.Value And ro("NumAutorizaDispersion") Is DBNull.Value And (ro("UsuarioAutoriza") IsNot DBNull.Value And ro("UsuarioAutoriza") <> String.Empty) Then
                                If Session("nivel") <> "08" Then
                                    win.Alert("No tiene los privilegios para realizar la siguiente acción de la página de Retiro de Fondos, favor de consultar al administrador. Gracias", "Notificacion_Permiso")
                                    Session("permiso") = "No"
                                    Exit Sub
                                End If


                                lblfecdisp.Visible = True
                                calFecDisp.Visible = True
                                calFecDisp.SelectedDate = IIf(ro("fechaDispersion") Is DBNull.Value, Date.Now, ro("fechaDispersion"))
                                calFecDisp.MaxDate = DateAdd(DateInterval.Day, 1, Date.Now)
                                calFecDisp.MinDate = ro("fechaAlta") 'CDate(ro("fechaAlta")).ToString("8/27/2014 00:00:00")
                                lblnumautodis.Visible = True
                                txtNumAutorizaDis.Visible = True
                                'txtNumAutorizaDis.Text = IIf(ro("NumAutorizaDispersion") Is DBNull.Value, "", ro("NumAutorizaDispersion"))
                                lblusuariodisp.Visible = True
                                lblUsuarioDispersion.Visible = True
                                lblUsuarioDispersion.Text = IIf(ro("usuarioDisperso") Is DBNull.Value, Session("clvUsuario"), ro("usuarioDisperso"))
                                btnGuardarDisp.Visible = True
                                habilitarinsertar(False)
                                'lbldatosdis.Visible = True
                                btnBeneficia.Visible = False
                                'btnAutoriza.Visible = False
                                'btnCancelar.Visible = False

                                'btnRechaza.Visible = True
                                btnGuardar.Visible = False
                                'btnAutoriza.Visible = False
                                'btnGuardarActua.Visible = True


                            End If

                            'contabilidad
                            If ro("NumAutorizaDispersion") IsNot DBNull.Value Then
                                If Session("nivel") <> 9 Then
                                    win.Alert("No tiene los privilegios para realizar la siguiente acción de la página de Retiro de Fondos, favor de consultar al administrador. Gracias", "Notificacion_Permiso")
                                    Session("permiso") = "No"
                                    Exit Sub
                                End If
                                lblfecconta.Visible = True
                                calFecConta.Visible = True
                                calFecConta.SelectedDate = IIf(ro("FechaContabilidad") Is DBNull.Value, Date.Now, ro("FechaContabilidad"))
                                calFecConta.MaxDate = Date.Now
                                calFecConta.MinDate = ro("fechaAlta") 'ro("fechaDispersion")
                                lblnumautocont.Visible = True
                                txtNumAutorizaCon.Visible = True
                                txtNumAutorizaCon.Text = IIf(ro("NumAutorizaContabilidad") Is DBNull.Value, "", ro("NumAutorizaContabilidad"))
                                'lblusuarioconta.Visible = True
                                'lblusuariocontabilidad.Visible = True
                                lblusuariocontabilidad.Text = IIf(ro("usuarioContabilid") Is DBNull.Value, Session("clvUsuario"), ro("usuarioContabilid"))
                                btnGuardarConta.Visible = True
                                btnGuardarDisp.Visible = False
                                habilitarinsertar(False)
                                habilitardisper(False)
                                lbldatosconta.Visible = True
                                btnBeneficia.Visible = False
                                btnCancelar.Visible = False
                                btnAutoriza.Visible = False
                            End If

                            'lblMotivoRechazo.Visible = True
                            'txtMotivoRechazo.Visible = True
                            'btnRechaza.Visible = True
                            'btnGuardar.Visible = False
                            'btnAutoriza.Visible = False
                            'btnGuardarActua.Visible = True
                            CargarGridRetiros()
                            'txtMotivoRechazo.Text = IIf(ro("MotivoRechazo") = "", "", ro("MotivoRechazo"))
                        Else
                            If Session("nivel") <> "02" And Session("nivel") <> "08" And Session("nivel") <> "09" And Session("nivel") <> "07" Then
                                win.Alert("No tiene los privilegios para realizar una Solicitud de Retiro en la página de Retiro de Fondos, favor de consultar al administrador. Gracias", "Notificacion_Permiso")
                                Session("permiso") = "No"
                                Exit Sub
                            End If
                            txtTipoServicio.Text = IIf(row("TipoServicio") Is DBNull.Value, " ", row("TipoServicio"))
                            txtCliente.Text = IIf(row("cliente_NomCliente") Is DBNull.Value, " ", row("cliente_NomCliente"))
                            txtAjustador.Text = IIf(row("Ajustador") Is DBNull.Value, " ", row("Ajustador"))
                            'Aqui mandaba el error
                            txtCuentaClave.Text = IIf(row("clave") Is DBNull.Value, "0", row("clave"))
                            txtEstado.Text = IIf(row("Estado") Is DBNull.Value, " ", row("Estado"))
                            '
                            If row("rfc_gestor") Is DBNull.Value Then
                                ConfigureNotification("El No. de Servicio no tiene asignado ningún Gestor por lo tanto no se puede realizar la acción deseada.", 400, 100)
                                btnGuardar.Visible = False
                                btnBeneficia.Visible = False
                                Check.Visible = False
                                Exit Sub
                            Else
                                If row("rfc_gestor") = "" Then
                                    ConfigureNotification("El No. de Servicio no tiene asignado ningún Gestor por lo tanto no se puede realizar la acción deseada.", 400, 100)
                                    btnGuardar.Visible = False
                                    btnBeneficia.Visible = False
                                    Check.Visible = False
                                    Exit Sub
                                End If
                            End If

                            Session("RfcGestor") = IIf(row("rfc_gestor") Is DBNull.Value, " ", row("rfc_gestor"))
                            Session("clvCliente") = IIf(row("reporte_cliente") Is DBNull.Value, -1, row("reporte_cliente"))
                            Session("NomCliente") = IIf(row("cliente_NomCliente") Is DBNull.Value, " ", row("cliente_NomCliente"))
                            ViewState("clvCliente") = IIf(row("reporte_cliente") Is DBNull.Value, -1, row("reporte_cliente"))
                            ViewState("NomCliente") = IIf(row("cliente_NomCliente") Is DBNull.Value, " ", row("cliente_NomCliente"))

                            CargarGridRetiros()

                            If Session("ValidaClave") = "1" Then
                                ConfigureNotification("Error al Buscar Clave de Beneficia, Contacte al Administrador", 300, 200)
                                btnBeneficia.Visible = False
                                btnGuardar.Visible = False
                                Session("ValidaClave") = ""
                                Exit Sub
                            End If

                            If row("reporte_status") IsNot DBNull.Value Then
                                If row("reporte_status") <> 0 Then
                                    ConfigureNotification("Solo Servicios activos pueden realizar retiros", 300, 100)
                                    btnCancelar.Visible = False
                                    btnBeneficia.Visible = False
                                    btnGuardar.Visible = False
                                    'btnNuevo.Visible = True
                                    habilitar(False)
                                    Exit Sub
                                End If
                            Else
                                ConfigureNotification("Solo Servicios activos pueden realizar retiros", 300, 100)
                                btnCancelar.Visible = False
                                btnGuardar.Visible = False
                                btnNuevo.Visible = True
                                habilitar(False)
                                Exit Sub
                            End If
                            If Session("Fondos") = "No" Then
                                btnGuardar.Visible = False
                                Session("Fondos") = ""
                                btnBeneficia.Visible = True
                                Check.Visible = False
                            Else
                                btnGuardar.Visible = True
                                btnBeneficia.Visible = False
                                Check.Visible = True
                            End If

                            'btnBeneficia.Visible = True
                            'btnCancelar.Visible = True
                        End If
                    Else
                        ConfigureNotification("Error al Consultar el Número de Gestión.Contacte al Administrador" & resfondo.ErrorDesc, 300, 150)
                    End If
                Else
                    ConfigureNotification("El Gestión buscado no existe. Verifiquelo", 300, 100)
                    txtNoServicio.Text = ""
                End If
            Else
                ConfigureNotification("Error al Consultar el Número de Gestión.Contacte al Administrador" & resfondo.ErrorDesc, 300, 150)
            End If
        End If
    End Sub

    Private Sub habilitar(Optional ByVal habilita As Boolean = True)
        txtNoServicio.Enabled = habilita
        txtMonto.Enabled = habilita
        ddlMotivoRetiro.Enabled = habilita
        calFecDisp.Enabled = habilita
        txtNumAutorizaDis.Enabled = habilita
        calFecConta.Enabled = habilita
        txtNumAutorizaCon.Enabled = habilita
        txtMotivoRechazo.Enabled = habilita
    End Sub

    Private Sub habilitarinsertar(Optional ByVal habilita As Boolean = True)
        txtNoServicio.Enabled = habilita
        txtMonto.Enabled = habilita
        ddlMotivoRetiro.Enabled = habilita
        txtNoServicio.BorderColor = Nothing
        txtMonto.BorderColor = Nothing
        ddlMotivoRetiro.BorderStyle = Nothing
    End Sub

    Private Sub habilitardisper(Optional ByVal habilita As Boolean = True)
        calFecDisp.Enabled = habilita
        txtNumAutorizaDis.Enabled = habilita
        calFecDisp.BorderStyle = Nothing
        txtNumAutorizaDis.BorderColor = Nothing
    End Sub

    Protected Sub btnBeneficia_Click(sender As Object, e As System.EventArgs) Handles btnBeneficia.Click
        'If Session("Nuevo") = "1" Then 'btnNuevo.Visible = True Then
        '    btnBeneficia.Visible = False
        '    btnGuardar.Visible = False
        '    btnCancelar.Visible = False
        '    btnNuevo.Visible = True
        '    habilitar(False)
        '    Session("Nuevo") = ""
        '    Exit Sub
        'Else
        BuscarClave()

        If Session("ValidaClave") = 1 Then
            ConfigureNotification("Error al Buscar Clave de Beneficia, Contacte al Administrador", 300, 200)
            btnBeneficia.Visible = False
            btnGuardar.Visible = False
            Session("ValidaClave") = ""
            Exit Sub
        Else
            'CargarGridRetiros()
            VerificaCamposInsertar()
            If Session("Validacion") = "1" Then
                Session("Validacion") = ""
                Exit Sub
            Else
                GuardarRetiro()
                Session("Validacion") = ""
            End If
        End If
        'End If
    End Sub

    Protected Sub BuscarClave()
        resfondo = datfondo.Consultar_ClaveCliente("BENEFICIA")

        If resfondo.Estatus = Estatus.Exito Then
            If resfondo.DataTable.Rows.Count > 0 Then
                Dim row As DataRow = resfondo.DataTable.Rows(0)
                Session("clvCliente") = IIf(row("cliente_clvCliente") Is DBNull.Value, -1, row("cliente_clvCliente"))
                Session("NomCliente") = IIf(row("cliente_NomCliente") Is DBNull.Value, " ", row("cliente_NomCliente"))
                CargarGridRetiros()
            Else
                ConfigureNotification("No se encontro la Clave del Cliente Beneficia, Contacta al Administrador", 300, 150)
                Session("ValidaClave") = "1"
                Exit Sub
            End If
        Else
            ConfigureNotification("Error al buscar la Clave del Cliente Beneficia, Contacta al Administrador", 300, 150)
            Session("ValidaClave") = "1"
            Exit Sub
        End If
    End Sub

    Protected Sub GuardarRetiro()
        If Session("Nuevo") = "1" Then 'btnNuevo.Visible = True Then
            btnBeneficia.Visible = False
            btnGuardar.Visible = False
            btnCancelar.Visible = False
            Check.Visible = False
            btnNuevo.Visible = True
            habilitar(False)
            CargarGridRetiros()
            'Session("Nuevo") = ""
            Exit Sub
        Else
            Dim fondo As Retiro_Fondos = ConstruirRetiroFondo(EnumFasesGuardar.Insertar)

            resfondo = datfondo.Insertar_Fondos_Retiro(fondo)

            If resfondo.Estatus = Estatus.Exito Then
                ConfigureNotification("Retiro Guardado Correctamente", 300, 100)
                btnCancelar.Visible = False
                btnGuardar.Visible = False
                btnBeneficia.Visible = False
                Check.Visible = False
                btnNuevo.Visible = True
                Session("Nuevo") = "1"
                habilitar(False)
                CargarGridRetiros()
                'Session("Fondos") = "No"
            Else
                ConfigureNotification("Error al Guardar el Retiro" & resfondo.ErrorDesc, 300, 300)
            End If
        End If
    End Sub

    Protected Sub Check_CheckedChanged(sender As Object, e As System.EventArgs) Handles Check.CheckedChanged
        If Check.Checked = True Then
            BuscarClave()
        Else
            Session("clvCliente") = ViewState("clvCliente")
            Session("NomCliente") = ViewState("NomCliente")
            CargarGridRetiros()
        End If
    End Sub

    Protected Sub btnRechaza_Click(sender As Object, e As System.EventArgs) Handles btnRechaza.Click
        If Session("Nuevo") = "1" Then 'btnNuevo.Visible = True Then
            btnBeneficia.Visible = False
            btnGuardar.Visible = False
            btnCancelar.Visible = False
            Check.Visible = False
            btnNuevo.Visible = False
            btnRechaza.Visible = False
            btnGuardarDisp.Visible = False
            btnGuardarConta.Visible = False
            habilitar(False)
            CargarGridRetiros()
            'Session("Nuevo") = ""
            Exit Sub
        Else
            If txtMotivoRechazo.Text = "" Then
                ConfigureNotification("Anota el Motivo del Rechazo", 300, 100)
                txtMotivoRechazo.BorderColor = col
                txtMotivoRechazo.Focus()
                Exit Sub
            End If

            Dim fondo As Retiro_Fondos = ConstruirRetiroFondo(EnumFasesGuardar.Rechazar)

            resfondo = datfondo.Actualizar_Fondos_Retiro(fondo)

            If resfondo.Estatus = Estatus.Exito Then
                ConfigureNotification("Rechazo Guardado Correctamente", 300, 100)
                btnCancelar.Visible = False
                btnGuardar.Visible = False
                btnBeneficia.Visible = False
                btnRechaza.Visible = False
                Check.Visible = False
                btnNuevo.Visible = False
                btnGuardarDisp.Visible = False
                btnGuardarConta.Visible = False
                Session("Nuevo") = "1"
                habilitar(False)
                CargarGridRetiros()
            Else
                ConfigureNotification("Error al Guardar el Rechazo" & resfondo.ErrorDesc, 300, 200)
            End If
        End If
    End Sub

    Protected Sub btnGuardarDisp_Click(sender As Object, e As System.EventArgs) Handles btnGuardarDisp.Click
        If Session("Nuevo") = "1" Then 'btnNuevo.Visible = True Then
            btnBeneficia.Visible = False
            btnGuardar.Visible = False
            btnCancelar.Visible = False
            Check.Visible = False
            btnNuevo.Visible = False
            btnRechaza.Visible = False
            btnGuardarDisp.Visible = False
            habilitar(False)
            CargarGridRetiros()
            'Session("Nuevo") = ""
            Exit Sub
        Else
            If calFecDisp.SelectedDate Is Nothing Then
                ConfigureNotification("Selecciona la Fecha de Dispersión", 300, 100)
                calFecDisp.Calendar.Focus()
                Exit Sub
            End If
            If txtNumAutorizaDis.Text.Trim <= "0" Or txtNumAutorizaDis.Text.Trim = "" Then
                ConfigureNotification("Anota el Número de Autorización", 300, 100)
                txtNumAutorizaDis.Focus()
                Exit Sub
            End If


            Dim fondo As Retiro_Fondos = ConstruirRetiroFondo(EnumFasesGuardar.ActualizarDispersion)

            resfondo = datfondo.Actualizar_Fondos_Retiro(fondo)

            If resfondo.Estatus = Estatus.Exito Then
                ConfigureNotification("Datos de Dispersión Guardados Correctamente", 300, 100)
                btnCancelar.Visible = False
                btnGuardar.Visible = False
                btnBeneficia.Visible = False
                btnRechaza.Visible = False
                Check.Visible = False
                btnNuevo.Visible = False
                btnGuardarDisp.Visible = False
                Session("Nuevo") = "1"
                habilitar(False)
                CargarGridRetiros()
            Else
                ConfigureNotification("Error al Guardar los Datos de Dispersión" & resfondo.ErrorDesc, 300, 200)
            End If
        End If
    End Sub

    Protected Sub btnGuardarConta_Click(sender As Object, e As System.EventArgs) Handles btnGuardarConta.Click
        If Session("Nuevo") = "1" Then 'btnNuevo.Visible = True Then
            btnBeneficia.Visible = False
            btnGuardar.Visible = False
            btnCancelar.Visible = False
            Check.Visible = False
            btnNuevo.Visible = False
            btnRechaza.Visible = False
            btnGuardarDisp.Visible = False
            habilitar(False)
            CargarGridRetiros()
            'Session("Nuevo") = ""
            Exit Sub
        Else

            If calFecConta.SelectedDate Is Nothing Then
                ConfigureNotification("Selecciona la Fecha de Contabilidad", 300, 100)
                calFecConta.Calendar.Focus()
                Exit Sub
            End If

            If txtNumAutorizaCon.Text.Trim <= "0" Or txtNumAutorizaCon.Text.Trim = "" Then
                ConfigureNotification("Anota el Número de Autorización", 300, 100)
                txtNumAutorizaCon.Focus()
                Exit Sub
            End If

            Dim fondo As Retiro_Fondos = ConstruirRetiroFondo(EnumFasesGuardar.ActualizarContabilidad)

            resfondo = datfondo.Actualizar_Fondos_Retiro(fondo)

            If resfondo.Estatus = Estatus.Exito Then
                ConfigureNotification("Datos de Contabilidad Guardados Correctamente", 300, 100)
                btnCancelar.Visible = False
                btnGuardar.Visible = False
                btnBeneficia.Visible = False
                btnRechaza.Visible = False
                Check.Visible = False
                btnNuevo.Visible = False
                btnGuardarConta.Visible = False
                Session("Nuevo") = "1"
                habilitar(False)
                CargarGridRetiros()
            Else
                ConfigureNotification("Error al Guardar los Datos de Contabilidad" & resfondo.ErrorDesc, 300, 200)
            End If
        End If
    End Sub

    Protected Sub btnAutoriza_Click(sender As Object, e As System.EventArgs) Handles btnAutoriza.Click
        Dim fondo As Retiro_Fondos = ConstruirRetiroFondo(EnumFasesGuardar.ActualizarAutorizacion)

        resfondo = datfondo.Actualizar_Fondos_Retiro(fondo)

        If resfondo.Estatus = Estatus.Exito Then
            ConfigureNotification("Datos de Autorizacion Guardados Correctamente", 300, 100)
            btnCancelar.Visible = False
            btnGuardar.Visible = False
            btnBeneficia.Visible = False
            btnRechaza.Visible = False
            Check.Visible = False
            btnNuevo.Visible = False
            btnGuardarConta.Visible = False
            btnAutoriza.Visible = False
            Session("Nuevo") = "1"
            habilitar(False)
            CargarGridRetiros()
        Else
            ConfigureNotification("Error al Guardar los Datos de Contabilidad" & resfondo.ErrorDesc, 300, 200)
        End If

    End Sub
End Class

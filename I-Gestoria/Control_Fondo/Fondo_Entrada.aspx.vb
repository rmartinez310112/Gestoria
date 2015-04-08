Imports System.Data
Partial Class Control_Fondo_Fondo_Entrada
Inherits System.Web.UI.Page

    Dim datfondo As New Datos_Fondos
    Dim resfondo As Resultado
    Dim win As New Ventanas
    'Dim datfondo2 As New Datos_Fondos
    'Dim resfondo2 As Resultado
    Dim bor As BorderStyle = BorderStyle.Dotted
    Dim col As Drawing.Color = Drawing.Color.Aqua

    Private Sub CargarDDLCliente()
        ddlCliente.Items.Clear()

        resfondo = datfondo.Consulta_Clientes(-1)

        'carga datos en ddl
        ddlCliente.DataSource = resfondo.DataTable
        ddlCliente.DataBind()

        'Agrega el campo inicial
        AgregarValorInicialDDL(ddlCliente)
    End Sub

    Private Sub CargarGridDepositos()
        'Dim s As New CBusqueda_Servicio_pagos

        ' Prepara los campos para hacer la búsqueda por filtros
        's.AsegNombre = "NADA" 'txtNombreAsegurado.Text.Trim()
        's.NombreAseguradora = IIf(ddlAseguradora.SelectedItem.Text.Trim() = "----------", "", ddlAseguradora.SelectedItem.Text.Trim())
        's.NumPoliza = txtNumPoliza.Text.Trim()
        's.NumSiniestro = txtNumSiniestro.Text.Trim()
        's.NumServicio = txtNumServicio.Text.Trim
        's.Placas = txtPlacas.Text.Trim
        Dim montos As New Retiro_Fondos
        montos.cliente_clvCliente = ddlCliente.SelectedValue
        montos.Anio = 0
        montos.Cliente = 0
        montos.Tipo = 0
        montos.ClvEstado = 0
        montos.Numero = 0

        'Dim clave As Integer = ddlCliente.SelectedValue
        griddepositos.MasterTableView.NoMasterRecordsText = IIf(ddlCliente.SelectedValue = -1, "Sin depositos aún", "Sin depositos aún del Cliente: " & ddlCliente.SelectedItem.Text)
        resfondo = datfondo.Consultar_Fondo_Ingreso(montos)

        ' Carga el grid
        griddepositos.DataSource = resfondo.DataTable
        griddepositos.DataBind()

        resfondo = datfondo.Consultar_MontoTotal_Ingreso_Retiro(montos)
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
        End If

        montos.Anio = 1
        resfondo = datfondo.Consultar_MontoTotal_Ingreso_Retiro(montos)
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
        End If
    End Sub

    'Protected Sub CargarCliente()
    '    ddlCliente.Items.Clear()
    '    Dim comando As String = "select cliente_clvCliente, cliente_NomCliente, Cliente_Activo, CVEASEGURADORA, clvLegal, Maneja_Fondo from Clientes where Cliente_Activo=1 and Maneja_Fondo = 1"
    '    csSQLsvr.LlenarRadCombo(ddlCliente, comando, Session("conngestion"))
    'End Sub

    Protected Sub Obligatorios()
        ddlCliente.BorderStyle = bor
        ddlCliente.BorderColor = col
        txtMonto.BorderStyle = bor
        txtMonto.BorderColor = col
        txtNoReferencia.BorderStyle = bor
        txtNoReferencia.BorderColor = col
        calFecDeposito.BorderStyle = bor
        calFecDeposito.BorderColor = col
        calFecDeposito.MaxDate = Date.Now
        'calFechaAlta.SelectedDate = Date.Now
        lblUsuario.Text = Session("clvUsuario")
        If Session("permiso") = "No" Then
            Session("permiso") = ""
        Else
            ConfigureNotification("Campos Azules son Obligatorios", 300, 100)
        End If
    End Sub

    Protected Sub Limpiar()
        txtMonto.Text = ""
        txtNoReferencia.Text = ""
        calFecDeposito.SelectedDate = Date.Now
        lblUsuario.Text = ""
        'calFechaAlta.SelectedDate = Date.Now
        CargarGridDepositos()
    End Sub

    Protected Sub ConfigureNotification(ByVal texto As String, ByVal ancho As Integer, ByVal alto As Integer)
        'String
        'lblError0.Text = texto
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

        If Session("nivel") <> 2 And Session("nivel") <> 4 Then
            win.Alert("No tiene los privilegios para ingresar a la página de Registro de Fondos, favor de consultar al administrador. Gracias", "Notificacion_Permiso")
            Session("permiso") = "No"
        End If

        If Session("nivel") = 4 Then
            btnGuardar.Visible = False
            btnCancelar.Visible = False
            btnNuevo.Visible = False
        End If

        If Not Page.IsPostBack Then
            CargarDDLCliente()
            ddlCliente.SelectedValue = -1
            Limpiar()
            Obligatorios()
            txtFecRegistro.Text = Date.Now
        End If
        If Page.IsPostBack Then
            'btnNuevo_Click(btnNuevo, e)
            If Request.Form("__EventTarget") = "Notificacion_Permiso" Then
                Regresar()
            End If
        End If
    End Sub

    Private Sub Regresar()
        Response.Redirect("~/Default2.aspx")
    End Sub


    Protected Sub btnCancelar_Click(sender As Object, e As System.EventArgs) Handles btnCancelar.Click
        ddlCliente.SelectedValue = -1
        Limpiar()
        griddepositos.DataSource = ""
        griddepositos.DataBind()
        Obligatorios()
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As System.EventArgs) Handles btnGuardar.Click
        If ddlCliente.SelectedValue = -1 Then
            ConfigureNotification("Elije el Cliente a Registrar el Deposito", 300, 100)
            ddlCliente.Focus()
            Exit Sub
        End If
        If txtMonto.Text <= "0" Or txtMonto.Text = "" Then
            ConfigureNotification("Anota el Monto Correspondiente", 300, 100)
            txtMonto.Focus()
            Exit Sub
        End If
        If txtNoReferencia.Text <= "0" Or txtNoReferencia.Text = "" Then
            ConfigureNotification("Anota el Número de Referencia", 300, 100)
            txtNoReferencia.Focus()
            Exit Sub
        End If
	If calFecDeposito.SelectedDate Is Nothing Then
            ConfigureNotification("Elije la Fecha de Deposito", 300, 100)
            calFecDeposito.DateInput.Focus()
            Exit Sub
        End If

        If Session("Nuevo") = "1" Then
            btnGuardar.Visible = False
            btnCancelar.Visible = False
            btnNuevo.Visible = True
            habilitar(False)
            CargarGridDepositos()
            Exit Sub
        Else
            Dim fondo As Ingreso_Fondos = ConstruirIngresoFondo()

            resfondo = datfondo.Insertar_Fondos_Ingreso(fondo)
            If resfondo.Estatus = Estatus.Exito Then
                ConfigureNotification("Deposito Guardado Correctamente", 300, 100)
                btnCancelar.Visible = False
                btnGuardar.Visible = False
                btnNuevo.Visible = True
                habilitar(False)
                CargarGridDepositos()
                Session("Nuevo") = "1"
            Else
                ConfigureNotification("Error al Ingresar Fondo" & resfondo.ErrorDesc, 300, 300)
            End If
        End If
        'Dim comando As String = "insert into Fondos_Entrada (cliente_clvCliente,monto,ref_bancaria,usuario,fechadeposito,fechaalta,consec) values (" & ddlCliente.SelectedValue & "," & txtMonto.Text.Trim & "," & txtNoReferencia.Text.Trim & "," & lblUsuario.Text & "," & calFecDeposito.SelectedDate & "," & calFechaAlta.SelectedDate & ")"
        'csSQLsvr.EjecutarSP(comando, Session("conngestion"))

        'Dim comando2 As String = "exec buscaExpedienteGestionGeneral_sp " & ddlCliente.SelectedValue & "," & txtMonto.Text.Trim & "," & txtNoReferencia.Text.Trim & "," & lblUsuario.Text & "," & calFecDeposito.SelectedDate & "," & calFechaAlta.SelectedDate
        'csSQLsvr.QueryDataSet(comando2, Session("conngestion"))

    End Sub

    Private Function ConstruirIngresoFondo() As Ingreso_Fondos
        Dim fondo As New Ingreso_Fondos

        fondo.cliente_clvCliente = ddlCliente.SelectedValue
        fondo.monto = IIf(txtMonto.Text.Trim = "", 0, txtMonto.Text.Trim)
        fondo.fechadeposito = IIf(calFecDeposito.SelectedDate Is Nothing, "#1/1/1900#", calFecDeposito.SelectedDate)
        fondo.ref_bancaria = IIf(txtNoReferencia.Text.Trim = "", 0, txtNoReferencia.Text.Trim)
        'fondo.fechaalta = IIf(calFechaAlta.SelectedDate Is Nothing, "#1/1/1900#", calFechaAlta.SelectedDate)
        fondo.usuario = lblUsuario.Text

        Return fondo
    End Function

    Protected Sub ddlCliente_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles ddlCliente.SelectedIndexChanged
        CargarGridDepositos()
        'UpdatePanelGrid.Update()
        'Dim comando As String = "select * from Fondo_Entrada where cliente_clvCliente = " + ddlCliente.SelectedValue + ""
        'csSQLsvr.LlenarRadGrid(griddepositos, comando, Session("conngestion"))
    End Sub

    Protected Sub btnNuevo_Click(sender As Object, e As System.EventArgs) Handles btnNuevo.Click
        Limpiar()
        Obligatorios()
        ddlCliente.SelectedValue = -1
        CargarGridDepositos()
        btnGuardar.Visible = True
        btnCancelar.Visible = True
        btnNuevo.Visible = False
        Session("Nuevo") = ""
        habilitar(True)
    End Sub

    Private Sub habilitar(Optional ByVal habilita As Boolean = True)
        ddlCliente.Enabled = habilita
        txtMonto.Enabled = habilita
        txtNoReferencia.Enabled = habilita
        calFecDeposito.Enabled = habilita
    End Sub
End Class

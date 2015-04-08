Imports System.Data
Imports System.Web
Partial Class GestionFallecimiento_DatosGestionFallecimiento_ABC
Inherits System.Web.UI.Page
    Dim csNeg As New ClaseNegocios
    Dim csSQLsvr As New BaseDatosSQL
    Dim csDAL As New DALClass
    #Region "procesos"

    Public Sub CargaContactos(ByVal NoGestion As String)
        Dim dsCto As New DataSet
        dsCto = csDAL.select_DatosContactos(NoGestion)
            With RadGrid1
            .DataSource = dsCto.Tables(0)
            .DataBind()
        End With
        dsCto.Clear()
        dsCto.Dispose()
    End Sub

    Private Function ValidaVacios() As Boolean
        ValidaVacios = False
        If csNeg.VaciosTexto(txtPaterno) = True Then
            ConfigureNotification("El apellido paterno de la persona que reporta no puede estar vacio")
            SetFocus(txtPaterno)
            ValidaVacios = False
            Return ValidaVacios
            Exit Function
        End If

        If csNeg.VaciosTexto(txtMaterno) = True Then
            ConfigureNotification("El apellido materno de la persona que reporta no puede estar vacio")
            SetFocus(txtMaterno)
            ValidaVacios = False
            Return ValidaVacios
            Exit Function
        End If
        If csNeg.VaciosTexto(txtNombre) = True Then
            ConfigureNotification("El nombre de la persona que reporta no puede estar vacio")
            SetFocus(txtNombre)
            ValidaVacios = False
            Return ValidaVacios
            Exit Function
        End If

        If csNeg.VaciosTexto(txtLadaCto) = True Then
            ConfigureNotification("Es necesaria la clave lada de la persona que reporta")
            SetFocus(txtLadaCto)
            ValidaVacios = False
            Return ValidaVacios
            Exit Function
        End If

        If csNeg.VaciosTexto(txtTelCon) = True Then
            ConfigureNotification("Es necesaria la el telefono de la persona que reporta")
            SetFocus(txtTelCon)
            ValidaVacios = False
            Return ValidaVacios
            Exit Function
        End If


        If Not txtFechaOcur.SelectedDate.HasValue Then
            ConfigureNotification("Es necesaria la fecha en que ocurrio el siniestro")
            SetFocus(txtFechaOcur)
            ValidaVacios = False
            Return ValidaVacios
            Exit Function

        End If



        If csNeg.VaciosTexto(txtTelCon) = True Then
            ConfigureNotification("Es necesaria la el telefono de la persona que reporta")
            SetFocus(txtTelCon)
            ValidaVacios = False
            Return ValidaVacios
            Exit Function
        End If


        If csNeg.VaciosTexto(txtNoPoliza) = True Then
            ConfigureNotification("Es necesario el No. de poliza")
            SetFocus(txtNoPoliza)
            ValidaVacios = False
            Return ValidaVacios
            Exit Function
        End If

        If txtCia.Text.Trim = String.Empty Then
            If csNeg.VaciosTexto(txtApepatAseg) = True Then
                ConfigureNotification("El apellido paterno del asegurado es obligatorio")
                SetFocus(txtApepatAseg)
                ValidaVacios = False
                Return ValidaVacios
                Exit Function
            End If

            If csNeg.VaciosTexto(txtApeMatAseg) = True Then
                ConfigureNotification("El apellido materno del asegurado es obligatorio")
                SetFocus(txtApeMatAseg)
                ValidaVacios = False
                Return ValidaVacios
                Exit Function
            End If
            If csNeg.VaciosTexto(txtNomAseg) = True Then
                ConfigureNotification("El nombre del asegurado es obligatorio")
                SetFocus(txtNomAseg)
                ValidaVacios = False
                Return ValidaVacios
                Exit Function
            End If
        End If

        If txtEmail.Text.Trim <> String.Empty Then
            If csNeg.VerificaEmail(txtEmail.Text) = False Then
                ConfigureNotification("El email no tiene en el formato correcto")
                SetFocus(txtEmail)
                ValidaVacios = False
                Return ValidaVacios
                Exit Function
            End If
        End If

        lblError0.Text = String.Empty
        ValidaVacios = True
        Return ValidaVacios

    End Function

    Protected Sub ConfigureNotification(ByVal texto As String)
        'String
        lblError0.Text = texto
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

    Private Sub cargaDatosGestionFallecimiento(ByVal datosGestion As DataSet)
        Dim dr As DataRow
        For Each dr In datosGestion.Tables(0).Rows
            tblTipoLlamada.SelectedValue = dr("GestionFallecimiento_Llama")
            rblTipoFallece.SelectedValue = dr("GestionFallecimiento_TipoFallece")
            txtDescripFallece.Text = dr("GestionFallecimiento_Descripcion")
            If Not IsDBNull(dr("ReporteGeneral_MedioContacto")) Then
                tblTipoActivacion.SelectedValue = dr("ReporteGeneral_MedioContacto")
            End If
            If Not IsDBNull(dr("Reporte_estatusPoliza")) Then
                txtStatus.Text = dr("Reporte_estatusPoliza")
            End If
            'Dim fechaIni As String = dr("inicioVigencia")
            'Dim fechaFin As String = dr("finVigencia")

            If Not IsDBNull(dr("Reporte_NombreReporta")) Then
                txtNomAseg.Text = dr("Reporte_NombreReporta")
            End If

            If Not IsDBNull(dr("Reporte_APaternoReporta")) Then
                txtApepatAseg.Text = dr("Reporte_APaternoReporta")
            End If

            If Not IsDBNull(dr("Reporte_AMaternoReporta")) Then
                txtApeMatAseg.Text = dr("Reporte_AMaternoReporta")
            End If

            If Not IsDBNull(dr("Reporte_CiaAsegura")) Then
                txtCia.Text = dr("Reporte_CiaAsegura")
            End If

            If Not IsDBNull(dr("Reporte_TelAseg")) Then
                txtTelCon0.Text = dr("Reporte_TelAseg")
            End If

            If Not IsDBNull(dr("Reporte_MailAseg")) Then
                txtEmail.Text = dr("Reporte_MailAseg")
            End If

            If Not IsDBNull(dr("Reporte_contrato")) Then
                txtContrato.Text = dr("Reporte_contrato")
            End If
        Next
        datosGestion.Clear()
        datosGestion.Dispose()
    End Sub

    Private Sub cargaDatosGestion(ByVal datosGestion As DataSet)
        Dim dr As DataRow
        For Each dr In datosGestion.Tables(0).Rows
            cboEstado.SelectedValue = dr("Reporte_clvEstado")
            CargaMpio(dr("Reporte_clvEstado"))
            cboMpio.SelectedValue = dr("Reporte_clvMpio")
            txtNombre.Text = dr("Reporte_NombreReporta").ToString.Trim
            txtPaterno.Text = dr("Reporte_APaternoReporta").ToString.Trim
            txtMaterno.Text = dr("Reporte_AMaternoReporta").ToString.Trim()
            txtLadaCto.Text = dr("Reporte_LadaReporta")
            txtTelCon.Text = dr("Reporte_telReporta")
            txtNomAseg.Text = dr("Reporte_NombreAseg").ToString.Trim
            txtApepatAseg.Text = dr("Reporte_ApaternoAseg").ToString.Trim
            txtApeMatAseg.Text = dr("Reporte_AMaternoAseg").ToString.Trim
            txtLadaCto0.Text = dr("Reporte_LadaAseg")
            txtTelCon0.Text = dr("Reporte_TelAseg")
            txtLadaCto1.Text = dr("Reporte_movilLadaAseg")
            txtTelCon1.Text = dr("Reporte_movilAseg")
            txtCia.Text = dr("Reporte_CiaAsegura").ToString.Trim()
            txtEmail.Text = dr("Reporte_MailAseg").ToString.Trim
            txtNoPoliza.Text = dr("Reporte_poliza")
            txtInciso.Text = dr("Reporte_Inciso")
            txtCliente.Text = csDAL.buscaAseguradora(dr("Reporte_cliente"))
            txtTipoServicio.Text = csDAL.buscaTipoServicio(dr("Reporte_cliente"), dr("Reporte_Tipo"))
            If Not IsDBNull(dr("Reporte_Leasing")) Then
                rdoLeasing.SelectedValue = dr("Reporte_Leasing")
            End If

            If CDate(dr("Reporte_FechaOcurre")) = "1/1/1900" Then
                txtFechaOcur.SelectedDate = txtFechaOcur0.MinDate

            Else
                txtFechaOcur.SelectedDate = CDate(dr("Reporte_FechaOcurre"))
            End If

            If CDate(dr("Reporte_inicioVigencia")) = "1/1/1900" Then
                txtFechaOcur0.SelectedDate = txtFechaOcur0.MinDate
            Else
                txtFechaOcur0.SelectedDate = CDate(dr("Reporte_inicioVigencia"))
            End If

            If CDate(dr("Reporte_FinVigencia")) = "1/1/1900" Then
                txtFechaOcur1.SelectedDate = txtFechaOcur0.MinDate

            Else
                txtFechaOcur1.SelectedDate = CDate(dr("Reporte_FinVigencia"))
            End If
            txtNoGo.Text = dr("Reporte_noControlGO")
            txtnocredito.Text = dr("Reporte_NoCredito")

            If txtFechaInicioCred.SelectedDate = " 01/01/1900 12:00:00 a.m." Then
                txtFechaInicioCred.SelectedDate = CDate(dr("Reporte_inicioVigCredito"))
            End If
            If txtFechaFinCred.SelectedDate = " 01/01/1900 12:00:00 a.m." Then
                txtFechaFinCred.SelectedDate = CDate(dr("Reporte_finVigCredito"))
            End If

            txtAviso.Text = dr("Reporte_AvisoServicio")
            'txtLadaCto0.Text = dr("ReporteGestionPTRobo_LadaConducia")
            'txtTelCon0.Text = dr("ReporteGestionPTRobo_telConducia")
            'txtLadaCto1.Text = dr("ReporteGestionPTRobo_CelLadaConducia")
            'txtTelCon1 = dr("ReporteGestionPTRobo_CelTelConducia")
            rblAsegContr.SelectedValue = dr("Reporte_AsegContrato")

            txtLadaEx.Text = dr("Reporte_LadaEx").ToString.Trim
            txtTelEx.Text = dr("Reporte_TelEx").ToString.Trim


        Next
        datosGestion.Clear()
        datosGestion.Dispose()
    End Sub

    Public Sub cargaEstados()

        Dim comando As String = "exec Select_cbo_estados"
        csSQLsvr.LlenarRadCombo(cboEstado, comando, Session("connGestion"))

    End Sub

    Public Sub CargaMpio(ByVal clvEstado As Integer)

        Dim comando As String = "exec Select_cbo_Municipios " & clvEstado
        csSQLsvr.LlenarRadCombo(cboMpio, comando, Session("connGestion"))
    End Sub

    #End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Not Session("noGestionIntegral") = Nothing Then
                cargaEstados()
                CargaTelefonosExtra(Session("noGestionIntegral"))
                'Session("noGestionIntegral") = 20131312291
                CargaContactos(Session("noGestionIntegral"))
                cargaDatosGestion(csDAL.select_GestionFallecimiento(Session("noGestionIntegral")))
                cargaDatosGestionFallecimiento(csDAL.select_GestionFallecimiento(Session("noGestionIntegral")))
                CargaCorreoMotivo()
                cargaMotivoNoenvioCorreos()
            Else
                ConfigureNotification("Favor de Introducir No.Gestion")
            End If
            End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If ValidaVacios() = True Then


            Dim pReporte_clvMpio As Integer = cboMpio.SelectedValue
            Dim pReporte_APaternoReporta As String = txtPaterno.Text.Trim.ToUpper
            Dim pReporte_AMaternoReporta As String = txtMaterno.Text.Trim.ToUpper
            Dim pReporte_NombreReporta As String = txtNombre.Text.Trim.ToUpper
            Dim pReporte_LadaReporta As String = txtLadaCto.Text.Trim
            Dim pReporte_telReporta As String = txtTelCon.Text.Trim
            Dim pReporte_poliza As String = txtNoPoliza.Text.Trim.ToUpper
            Dim pReporte_Inciso As String = txtInciso.Text.Trim.ToUpper
            Dim pReporte_ApaternoAseg As String = txtApepatAseg.Text.Trim
            Dim pReporte_AMaternoAseg As String = txtApeMatAseg.Text.Trim
            Dim pReporte_NombreAseg As String = txtNomAseg.Text.Trim
            Dim pReporte_MailAseg As String = txtEmail.Text.Trim.ToLower
            Dim pReporte_CiaAsegura As String = txtCia.Text.Trim.ToUpper
            Dim pReporte_UsuarioMod As String = Session("clvUsuario")
            Dim pReporte_LadaAseg As String = txtLadaCto0.Text.Trim
            Dim pReporte_TelAseg As String = txtTelCon0.Text.Trim
            Dim pReporte_ladaMovil As String = txtLadaCto1.Text.Trim
            Dim pReporte_telMovil As String = txtTelCon1.Text.Trim
            Dim pReporte_contrato As String = txtcontrato.text.trim
            Dim pReporte_AsegContrato As String = rblAsegContr.SelectedValue
            Dim GestionFallecimiento_Llama As Integer = tblTipoLlamada.SelectedValue
            Dim GestionFallecimiento_TipoFallece As Integer = rblTipoFallece.SelectedValue
            Dim GestionFallecimiento_Descripcion As String = txtDescripFallece.Text.Trim
            Dim pReporte_MedioContacto As String = tblTipoActivacion.SelectedValue
            Dim pReporte_Leasing As String = rdoLeasing.SelectedValue
            Dim pReporte_LadaExtra As String = txtLadaEx.Text.Trim
            Dim pReporte_TelExtra As String = txtTelEx.Text.Trim
            Dim pReporteMotivoNoCorreo As Integer = cboMotivoNoCorreo.SelectedValue

            If csDAL.update_reporteGestion(Session("noGestionIntegral"), pReporte_clvMpio, pReporte_APaternoReporta, pReporte_AMaternoReporta, pReporte_NombreReporta, pReporte_LadaReporta, pReporte_telReporta, pReporte_poliza, pReporte_Inciso, pReporte_ApaternoAseg, pReporte_AMaternoAseg, pReporte_NombreAseg, pReporte_MailAseg, pReporte_CiaAsegura, pReporte_UsuarioMod, pReporte_LadaAseg, pReporte_TelAseg, pReporte_ladaMovil, pReporte_telMovil, pReporte_contrato, pReporte_AsegContrato, pReporte_Leasing, pReporte_LadaExtra, pReporte_TelExtra, pReporteMotivoNoCorreo) = True Then
                If csDAL.update_reporteGestionFallecimiento(Session("noGestionIntegral"), GestionFallecimiento_Llama, GestionFallecimiento_TipoFallece, GestionFallecimiento_Descripcion, pReporte_UsuarioMod, pReporte_MedioContacto) = True Then
                    ConfigureNotification("Se actualizo la información con exito..")
                    Button1.Visible = False
                Else
                    ConfigureNotification("Error al guardar los datos, por favor verifique la información..")
                End If

            Else
                ConfigureNotification("Error al guardar los datos, por favor verifique la información..")

            End If
        End If

    End Sub

    Protected Sub cmdNewContac_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdNewContac.Click
        Panel1.Visible = True
        txtNomCot.Text = String.Empty
        txtPatCot.Text = String.Empty
        txtMatCot.Text = String.Empty
        txtLadaCot.Text = String.Empty
        txtTelCot.Text = String.Empty
        txtObservaciones.Text = String.Empty
        cmdNewContac.Visible = False
        cmdNewContac0.Visible = True
    End Sub

    Protected Sub cmdNewContac0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdNewContac0.Click

        Dim NoGestion As String = Session("noGestionIntegral")
        Dim GestionContacto_ApePat As String = txtPatCot.Text.Trim
        Dim GestionContacto_ApeMat As String = txtMatCot.Text.Trim
        Dim GestionContacto_Nombre As String = txtNomCot.Text.Trim
        Dim GestionContacto_Lada As String = txtLadaCot.Text.Trim
        Dim GestionContacto_Telefono As String = txtTelCot.Text.Trim
        Dim GestionContacto_Observaciones As String = txtObservaciones.Text.Trim
        Dim GestionContacto_UsrCambio As String = Session("clvUsuario")
        If GestionContacto_ApePat = String.Empty Or GestionContacto_ApeMat = String.Empty Or GestionContacto_Nombre = String.Empty Or GestionContacto_Telefono = String.Empty Then
            ConfigureNotification("Son necesario mas datos para generar un nuevo contacto..")
            Exit Sub
        End If

        If csDAL.Insert_GestionContacto(NoGestion, GestionContacto_ApePat, GestionContacto_ApeMat, GestionContacto_Nombre, GestionContacto_Lada, GestionContacto_Telefono, GestionContacto_Observaciones, GestionContacto_UsrCambio) = True Then
            ConfigureNotification("Contacto dado de Alta con exito..")
            cmdNewContac.Visible = True
            cmdNewContac0.Visible = False
            Panel1.Visible = False
            CargaContactos(Session("noGestionIntegral"))
        Else
            ConfigureNotification("Error al dar de alta el nuevo Contacto verifique la información..")

        End If
    End Sub

    Protected Sub Button2_Click(sender As Object, e As System.EventArgs) Handles Button2.Click
        Dim NoGestion As String = Session("noGestionIntegral")
        Dim lada As String = txt_ladaextra.Text.Trim
        Dim tel As String = txt_telextra.Text.Trim
        Dim tipo As String = txt_tipoTelExtra.Text.Trim

        If csDAL.Insert_TelExtrass(NoGestion, lada, tel, tipo) = True Then
            ConfigureNotification("Telefono dado de Alta con exito..")
            Panel2.Visible = False

            CargaTelefonosExtra(Session("noGestionIntegral"))
        Else
            ConfigureNotification("Error al dar de alta el nuevo telefono verifique la información..")

        End If
    End Sub

    Protected Sub Button3_Click(sender As Object, e As System.EventArgs) Handles Button3.Click
        Panel2.Visible = True
    End Sub
    Public Sub CargaTelefonosExtra(ByVal NoGestion As String)
        Dim dsCto As New DataSet
        dsCto = csDAL.select_TelExtras(NoGestion)
        With RadGrid2
            .DataSource = dsCto.Tables(0)
            .DataBind()
        End With
        dsCto.Clear()
        dsCto.Dispose()
    End Sub

    Public Sub CargaCorreoMotivo()
        Dim ds As New DataSet
        Dim dr As DataRow

        ds = csDAL.select_CorreoOpc(Session("noGestionIntegral"))
        If ds.Tables(0).Rows.Count <> 0 Then
            For Each dr In ds.Tables(0).Rows
                If dr("Reporte_MailAseg") <> "" Then
                    rdoNoCorreo.SelectedValue = 1
                    txtEmail.Text = dr("Reporte_MailAseg")
                    cboMotivoNoCorreo.Visible = False
                    Label115.Visible = False
                ElseIf Not IsDBNull(dr("Reporte_MotivoNoCorreo")) <> Nothing Or Not IsDBNull(dr("Reporte_MotivoNoCorreo")) <> 0 Then
                    cboMotivoNoCorreo.SelectedValue = dr("Reporte_MotivoNoCorreo")
                    rdoNoCorreo.SelectedValue = 2
                    txtEmail.Visible = False
                    Label115.Visible = True
                    Label9.Visible = False
                Else
                    rdoNoCorreo.SelectedValue = 1
                    txtEmail.Visible = True
                    cboMotivoNoCorreo.Visible = False
                    Label115.Visible = False

                End If
            Next
        End If
    End Sub

    Protected Sub rdoNoCorreo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdoNoCorreo.SelectedIndexChanged
        If rdoNoCorreo.SelectedValue = 1 Then
            txtEmail.Visible = True
            Label9.Visible = True
            cboMotivoNoCorreo.Visible = False
            Label115.Visible = False
            cboMotivoNoCorreo.SelectedValue = ""
        Else
            txtEmail.Visible = False
            Label9.Visible = False
            cboMotivoNoCorreo.Visible = True
            Label115.Visible = True
            txtEmail.Text = ""
        End If
    End Sub
    Public Sub cargaMotivoNoenvioCorreos()

        Dim comando As String = "exec Select_cboMotivoNoCorreo_sp"
        csSQLsvr.LlenarRadCombo(cboMotivoNoCorreo, comando, Session("connGestion"))

    End Sub
End Class

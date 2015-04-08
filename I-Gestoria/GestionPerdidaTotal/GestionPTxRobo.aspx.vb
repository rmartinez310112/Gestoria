Imports System.Data
Imports System.Web
Partial Class GestionPerdidaTotal_GestionPTxRobo
Inherits System.Web.UI.Page
    Dim csNeg As New ClaseNegocios
    Dim csSQLsvr As New BaseDatosSQL
    Dim csDAL As New DALClass
    Dim conBaseDatos As String = System.Configuration.ConfigurationManager.AppSettings("ConnStringSQL")
    #Region "procesos"

    Protected Sub ConfigureNotification(ByVal titulo As String, ByVal texto As String)
        'String
        lblError.Text = texto
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

    Public Sub CargaSubmarca(ByVal marca As String)
        Dim comando As String = "exec select_Cbo_Submarcas '" & marca.Trim & "'"
        'Dim comando As String = "SELECT     CONSEC, RTRIM(TIPO) + ' | ' + RTRIM(DESCRIPCION) AS submarca FROM Amis where marca='" & marca & "'"

        Dim ds As New DataSet
        ds = csSQLsvr.QueryDataSet(comando, Session("connGestion"))

        'Dim newRutasRow As DataRow = ds.Tables(0).NewRow()
        'newRutasRow("CONSEC") = "0"
        'newRutasRow("submarca") = "Seleccione una SubMarca"
        'ds.Tables(0).Rows.Add(newRutasRow)
            With cboSubmarca
            .DataSource = ds.Tables(0)
            .DataTextField = ds.Tables(0).Columns(1).Caption.ToString
            .DataValueField = ds.Tables(0).Columns(0).Caption.ToString
            .DataBind()
        End With

        ds.Clear()
        ds.Dispose()

    End Sub

    Public Sub cargaMarca()
        Dim comando As String = "exec Select_cbo_marcas"
        csSQLsvr.LlenarRadCombo(cboMarca, comando, Session("connGestion"))

    End Sub

    'Protected Sub ConfigureNotification(ByVal titulo As String, ByVal texto As String)
    '    'String
    '    lblError.Text = texto
    '    lblError0.Text = texto
    '    notificacion.Title = titulo
    '    notificacion.Text = texto
    '    'Enum
    '    notificacion.Position = Telerik.Web.UI.NotificationPosition.Center
    '    notificacion.Animation = Telerik.Web.UI.NotificationAnimation.Fade
    '    'notificacion.ContentScrolling = Telerik.Web.UI.NotificationScrolling.Default
    '    notificacion.AutoCloseDelay = 5000
    '    'Unit
    '    notificacion.Width = 300
    '    notificacion.Height = 150
    '    notificacion.OffsetX = -10
    '    notificacion.OffsetY = 10

    '    notificacion.Pinned = True
    '    notificacion.EnableRoundedCorners = True
    '    notificacion.EnableShadow = True
    '    notificacion.KeepOnMouseOver = False
    '    notificacion.VisibleTitlebar = True
    '    notificacion.ShowCloseButton = True
    '    notificacion.Show()

    'End Sub

    Private Function ValidaVacios() As Boolean
        ValidaVacios = False

        If csNeg.VaciosTexto(txtPaterno) = True Then
            ConfigureNotification("Atención", "El apellido paterno de la persona que reporta no puede estar vacio")
            SetFocus(txtPaterno)
            ValidaVacios = False
            Return ValidaVacios
            Exit Function
        End If

        If csNeg.VaciosTexto(txtMaterno) = True Then
            ConfigureNotification("Atención", "El apellido materno de la persona que reporta no puede estar vacio")
            SetFocus(txtMaterno)
            ValidaVacios = False
            Return ValidaVacios
            Exit Function
        End If
        If csNeg.VaciosTexto(txtNombre) = True Then
            ConfigureNotification("Atención", "El nombre de la persona que reporta no puede estar vacio")
            SetFocus(txtNombre)
            ValidaVacios = False
            Return ValidaVacios
            Exit Function
        End If

        If csNeg.VaciosTexto(txtLadaCto) = True Then
            ConfigureNotification("Atención", "Es necesaria la clave lada de la persona que reporta")
            SetFocus(txtLadaCto)
            ValidaVacios = False
            Return ValidaVacios
            Exit Function
        End If

        If csNeg.VaciosTexto(txtTelCon) = True Then
            ConfigureNotification("Atención", "Es necesaria la el telefono de la persona que reporta")
            SetFocus(txtTelCon)
            ValidaVacios = False
            Return ValidaVacios
            Exit Function
        End If


        If Not txtFechaOcur.SelectedDate.HasValue Then
            ConfigureNotification("Atención", "Es necesaria la fecha en que ocurrio el siniestro")
            SetFocus(txtFechaOcur)
            ValidaVacios = False
            Return ValidaVacios
            Exit Function

        End If

        If Not txtHoraOcurr.SelectedDate.HasValue Then
            ConfigureNotification("Atención", "Es necesaria la hora en que ocurrio el siniestro")
            SetFocus(txtHoraOcurr)
            ValidaVacios = False
            Return ValidaVacios
            Exit Function

        End If

        If csNeg.VaciosTexto(txtTelCon) = True Then
            ConfigureNotification("Atención", "Es necesaria la el telefono de la persona que reporta")
            SetFocus(txtTelCon)
            ValidaVacios = False
            Return ValidaVacios
            Exit Function
        End If


        If csNeg.VaciosTexto(txtNoPoliza) = True Then
            ConfigureNotification("Atención", "Es necesario el No. de poliza")
            SetFocus(txtNoPoliza)
            ValidaVacios = False
            Return ValidaVacios
            Exit Function
        End If
        If txtCia.Text.Trim = String.Empty Then
            If csNeg.VaciosTexto(txtApepatAseg) = True Then
                ConfigureNotification("Atención", "El apellido paterno del asegurado es obligatorio")
                SetFocus(txtApepatAseg)
                ValidaVacios = False
                Return ValidaVacios
                Exit Function
            End If

            If csNeg.VaciosTexto(txtApeMatAseg) = True Then
                ConfigureNotification("Atención", "El apellido materno del asegurado es obligatorio")
                SetFocus(txtApeMatAseg)
                ValidaVacios = False
                Return ValidaVacios
                Exit Function
            End If
            If csNeg.VaciosTexto(txtNomAseg) = True Then
                ConfigureNotification("Atención", "El nombre del asegurado es obligatorio")
                SetFocus(txtNomAseg)
                ValidaVacios = False
                Return ValidaVacios
                Exit Function
            End If
        End If
        If csNeg.VaciosTexto(txtLadaAseg) = True Then
            ConfigureNotification("Atención", "Es necesaria la clave lada  del asegurado")
            SetFocus(txtLadaAseg)
            ValidaVacios = False
            Return ValidaVacios
            Exit Function
        End If

        If csNeg.VaciosTexto(txtTelAseg) = True Then
            ConfigureNotification("Atención", "Es necesaria la el telefono del asegurado")
            SetFocus(txtTelAseg)
            ValidaVacios = False
            Return ValidaVacios
            Exit Function
        End If

        If csNeg.VaciosTexto(txtApepatAseg) = True And csNeg.VaciosTexto(txtNomAseg) = True Then
            ConfigureNotification("Atención", "Si el asegurado es persona moral es necesario el nombre de la Compañia")
            SetFocus(txtCia)
            ValidaVacios = False
            Return ValidaVacios
            Exit Function

        End If
        If csNeg.VaciosTexto(txtNoSiniestro) = True Then
            ConfigureNotification("Atención", "Es necesario el No. de Siniestro")
            SetFocus(txtNoSiniestro)
            ValidaVacios = False
            Return ValidaVacios
            Exit Function
        End If

        If csNeg.VaciosTexto(txtModelo) = True Then
            ConfigureNotification("Atención", "Es modelo del vehiculo es necesario")
            SetFocus(txtModelo)
            ValidaVacios = False
            Return ValidaVacios
            Exit Function
        End If

        If cboSubmarca.SelectedValue = 0 Then
            ConfigureNotification("Atención", "La submarca del vehiculo es necesario")
            SetFocus(cboSubmarca)
            ValidaVacios = False
            Return ValidaVacios
            Exit Function
        End If

        If txtEmail.Text.Trim <> String.Empty Then
            If csNeg.VerificaEmail(txtEmail.Text) = False Then
                ConfigureNotification("Atención", "El email no tiene en el formato correcto")
                SetFocus(txtEmail)
                ValidaVacios = False
                Return ValidaVacios
                Exit Function
            End If
        End If

        If txtNoAverig.Text.Trim = String.Empty Then
            ConfigureNotification("Atención", "Es necesario el No. de Averiguación previa")
            SetFocus(txtNoAverig)
            ValidaVacios = False
            Return ValidaVacios
            Exit Function
        End If



        lblError.Text = String.Empty
        lblError0.Text = String.Empty
        ValidaVacios = True
        Return ValidaVacios

    End Function

    Public Sub cargaEstados()

        Dim comando As String = "exec Select_cbo_estados"
        csSQLsvr.LlenarRadCombo(cboEstado, comando, Session("connGestion"))
        csSQLsvr.LlenarRadCombo(cboEstadoPlacas, comando, Session("connGestion"))
    End Sub

    Public Sub CargaMpio(ByVal clvEstado As Integer)

        Dim comando As String = "exec Select_cbo_Municipios " & clvEstado
        csSQLsvr.LlenarRadCombo(cboMpio, comando, Session("connGestion"))
        csSQLsvr.LlenarRadCombo(cboMpioPlacas, comando, Session("connGestion"))
    End Sub

    Private Sub cargaDatosGestion(ByVal datosGestion As DataSet)
        Dim dr As DataRow
        For Each dr In datosGestion.Tables(0).Rows
            cboEstado.SelectedValue = dr("Reporte_clvEstado")
            CargaMpio(dr("Reporte_clvEstado"))
            cboMpio.SelectedValue = dr("Reporte_clvMpio")
            cboEstadoPlacas.SelectedValue = dr("ReporteGestionPTRobo_EdoPlacas")
            CargaMpio(dr("ReporteGestionPTRobo_EdoPlacas"))
            cboMpioPlacas.SelectedValue = dr("ReporteGestionPTRobo_MpioPlacas")
            txtNombre.Text = dr("Reporte_NombreReporta").ToString.Trim
            txtPaterno.Text = dr("Reporte_APaternoReporta").ToString.Trim
            txtMaterno.Text = dr("Reporte_AMaternoReporta").ToString.Trim()
            txtLadaCto.Text = dr("Reporte_LadaReporta")
            txtTelCon.Text = dr("Reporte_telReporta")
            txtNomAseg.Text = dr("Reporte_NombreAseg").ToString.Trim
            txtApepatAseg.Text = dr("Reporte_ApaternoAseg").ToString.Trim
            txtApeMatAseg.Text = dr("Reporte_AMaternoAseg").ToString.Trim
            txtCia.Text = dr("Reporte_CiaAsegura").ToString.Trim()
            txtEmail.Text = dr("Reporte_MailAseg").ToString.Trim
            txtNoPoliza.Text = dr("Reporte_poliza")
            txtInciso.Text = dr("Reporte_Inciso")
            txtCliente.Text = csDAL.buscaAseguradora(dr("Reporte_cliente"))
            txtTipoServicio.Text = csDAL.buscaTipoServicio(dr("Reporte_cliente"), dr("Reporte_Tipo"))
            'txtFechaOcur.SelectedDate = dr("Reporte_FechaOcurre")
            Dim horaOcurre = Convert.ToDateTime(Format(dr("Reporte_FechaOcurre"), "HH:mm"))
            txtHoraOcurr.SelectedDate = CDate(horaOcurre)
            txtLadaAseg.Text = dr("Reporte_LadaAseg")
            txtStatus.Text = dr("Reporte_estatusPoliza")
            txtTelAseg.Text = dr("Reporte_TelAseg")
            txtLadaAseg0.Text = dr("Reporte_movilLadaAseg")
            txtTelMovil.Text = dr("Reporte_movilAseg")
            txtLadaEx.Text = dr("Reporte_LadaEx").ToString.Trim
            txtTelEx.Text = dr("Reporte_TelEx").ToString.Trim
            'RadDatePicker1.SelectedDate = CDate(Format(dr("Reporte_inicioVigencia"), "dd/MM/yyyy"))
            If Not IsDBNull(dr("Reporte_Leasing")) Then
                rdoLeasing.SelectedValue = dr("Reporte_Leasing")
            End If

            If dr("Reporte_FinVigencia") <> "1/1/1900" Then
                RadDatePicker1.SelectedDate = dr("Reporte_inicioVigencia")
            End If


            If dr("Reporte_FinVigencia") <> "01/01/1900" Then

                RadDatePicker2.SelectedDate = dr("Reporte_FinVigencia")

            End If
            
            RadTxtGoControl.Text = dr("Reporte_noControlGO")
            txtnocredito.Text = dr("Reporte_NoCredito")
            txtFechaInicioCred.SelectedDate = CDate(dr("Reporte_inicioVigCredito"))
            txtFechaFinCred.SelectedDate = CDate(dr("Reporte_finVigCredito"))
            txtAviso.Text = dr("Reporte_AvisoServicio")

            txtContrato.Text = dr("Reporte_contrato")
            rblAsegContr.SelectedValue = dr("Reporte_AsegContrato")

           
        Next
        datosGestion.Clear()
        datosGestion.Dispose()
    End Sub

    Private Sub cargaDatosGestionPT(ByVal datosGestionPT As DataSet)
        Dim dr As DataRow
        For Each dr In datosGestionPT.Tables(0).Rows
            txtNoSiniestro.Text = dr("ReporteGestionPTRobo_NoSiniestro")
            txtNoReporte.Text = dr("ReporteGestionPTRobo_NoReporte")
            txtNoAverig.Text = dr("ReporteGestionPTRobo_NoAveriguacion")
            txtFechaAver.SelectedDate = dr("ReporteGestionPTRobo_FechaAverigua")
            txtModelo.Text = dr("ReporteGestionPTRobo_ModeloVehi")
            txtColor.Text = dr("ReporteGestionPTRobo_ColorVehi")
            txtSerie.Text = dr("ReporteGestionPTRobo_SerieVehi")
            txtPlacas.Text = dr("ReporteGestionPTRobo_PlacasVehi")
            txtApepatConducia.Text = dr("ReporteGestionPTRobo_PaternoConducia").ToString.Trim
            txtApematConducia.Text = dr("ReporteGestionPTRobo_MaternoConducia").ToString.Trim
            txtNombreConducia.Text = dr("ReporteGestionPTRobo_nombreConducia").ToString.Trim
            txtLadaConducia.Text = dr("ReporteGestionPTRobo_LadaConducia")
            txtTelConducia.Text = dr("ReporteGestionPTRobo_telConducia")
            txtLadaMovilConducia.Text = dr("ReporteGestionPTRobo_CelLadaConducia")
            txtTelMovilConducia.Text = dr("ReporteGestionPTRobo_CelTelConducia")
            txtFechaRobo.SelectedDate = CDate(dr("ReporteGestionPTRobo_FEchaRobo"))
            'Dim horaOcurreRobo = Convert.ToDateTime(Format(dr("ReporteGestionPTRobo_HoraRobo"), "HH:mm"))
            IIf(dr("ReporteGestionPTRobo_HoraRobo").ToString.Contains("00:00:00"), "", txtHoraRobo.SelectedDate = dr("ReporteGestionPTRobo_HoraRobo"))
            txtCalleRobo.Text = dr("ReporteGestionPTRobo_CalleRobo").ToString.Trim
            txtColoniaRobo.Text = dr("ReporteGestionPTRobo_ColoniaRobo").ToString.Trim
            txtReferenciaRobo.Text = dr("ReporteGestionPTRobo_Referencias").ToString.Trim
            rblTipoRobo.SelectedValue = dr("ReporteGestionPTRobo_TipoRobo")
            rblConduciaUsted.SelectedValue = dr("ReporteGestionPTRobo_QuienConducia")
            txtTipoCarga.Text = dr("ReporteGestionPTRobo_TipoCarga").ToString.Trim
            txtPaquete.Text = dr("ReporteGestionPTRobo_Paquete").ToString.Trim
            txtDescripcion.Text = dr("ReporteGestionPTRobo_Descripcion").ToString.Trim
            txtFolioEnlaceAseg.Text = IIf(IsDBNull(dr("ReportePTroboEnlaceAseg")), "", dr("ReportePTroboEnlaceAseg"))

            tblTipoLlamada.SelectedValue = dr("ReporteGestionPTRobo_Llama")
            Select Case Len(Trim(dr("ReporteGestionPTRobo_MarcaVehi")))
                Case Is = 1
                    dr("ReporteGestionPTRobo_MarcaVehi") = "00" & Trim(dr("ReporteGestionPTRobo_MarcaVehi"))
                Case Is = 2
                    dr("ReporteGestionPTRobo_MarcaVehi") = "0" & Trim(dr("ReporteGestionPTRobo_MarcaVehi"))
            End Select
            cboMarca.SelectedValue = Trim(dr("ReporteGestionPTRobo_MarcaVehi"))

            CargaSubmarca(Trim(dr("ReporteGestionPTRobo_MarcaVehi")))
            cboSubmarca.SelectedValue = Trim(dr("ReporteGestionPTRobo_SubMarcaVehi"))

            If Not IsDBNull(dr("ReporteGeneral_MedioContacto")) Then
                tblTipoActivacion.SelectedValue = dr("ReporteGeneral_MedioContacto")
            End If
        Next
        datosGestionPT.Clear()
        datosGestionPT.Dispose()
    End Sub

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Not Session("noGestionIntegral") = Nothing Then
                'Session("noGestionIntegral") = 20131311292
                cargaEstados()
                cargaMarca()
                CargaContactos(Session("noGestionIntegral"))
                CargaTelefonosExtra(Session("noGestionIntegral"))
                cargaDatosGestion(csDAL.buscaExpedienteGestionPTxRobo(Session("noGestionIntegral")))
                cargaDatosGestionPT(csDAL.buscaExpedienteGestionPTxRobo(Session("noGestionIntegral")))
                CargaCorreoMotivo()
                cargaMotivoNoenvioCorreos()
            Else
                ConfigureNotification("Atencion", "Favor de Introducir No.Gestion")
            End If
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click, Button2.Click
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
            Dim pReporte_contrato As String = txtContrato.Text.Trim.ToUpper
            Dim pReporte_AsegContrato As Integer = rblAsegContr.SelectedValue
            Dim pReporte_LadaAseg As String = txtLadaAseg.Text.Trim
            Dim pReporte_TelAseg As String = txtTelAseg.Text.Trim
            Dim pReporte_LadamovilAseg As String = txtLadaAseg0.Text.Trim
            Dim pReporte_movilAseg As String = txtTelMovil.Text.Trim
            Dim ReporteGestionPTRobo_NoSiniestro As String = txtNoSiniestro.Text.Trim.ToUpper
            Dim ReporteGestionPTRobo_NoAveriguacion As String = txtNoAverig.Text.Trim.ToUpper
            Dim ReporteGestionPTRobo_FechaAverigua As String = Format(txtFechaAver.SelectedDate, "yyyyMMdd")
            Dim ReporteGestionPTRobo_MarcaVehi As Integer = cboMarca.SelectedValue
            'Dim GestionPT_SubMarcaVehi As String = cboSubmarca.SelectedValue
            Dim ReporteGestionPTRobo_SubMarcaVehi As String = cboSubmarca.SelectedValue
            Dim ReporteGestionPTRobo_ModeloVehi As String = txtModelo.Text.Trim
            Dim ReporteGestionPTRobo_ColorVehi As String = txtColor.Text.Trim.ToUpper
            Dim Rep_tipoVehi As Integer = rblTipVehi.SelectedValue
            Dim ReporteGestionPTRobo_TipoVehi As Integer = rblTipVehi.Text.Trim
            Dim ReporteGestionPTRobo_SerieVehi As String = txtSerie.Text.Trim.ToUpper
            Dim ReporteGestionPTRobo_PlacasVehi As String = txtPlacas.Text.Trim.ToUpper
            Dim ReporteGestionPTRobo_Llama As Integer = tblTipoLlamada.SelectedValue
            Dim ReporteGestionPTRobo_SubMarcaVehi2 As String = "" ' csDAL.buscaSubmarca(cboSubmarca.SelectedValue, "CLAVES_AMIS")
            Dim ReporteGestionPTRobo_NoReporte As String = txtNoReporte.Text.Trim.ToUpper
            Dim ReporteGestionPTRobo_FEchaRobo As String = Format(txtFechaAver.SelectedDate, "yyyyMMdd")
            Dim ReporteGestionPTRobo_HoraRobo As String = txtHoraRobo.SelectedDate.ToString
            Dim ReporteGestionPTRobo_CalleRobo As String = txtCalleRobo.Text
            Dim ReporteGestionPTRobo_ColoniaRobo As String = txtColoniaRobo.Text
            Dim ReporteGestionPTRobo_Referencias As String = txtReferenciaRobo.Text
            Dim ReporteGestionPTRobo_TipoRobo As String = rblTipoRobo.SelectedValue
            Dim ReporteGestionPTRobo_QuienConducia As String = rblConduciaUsted.SelectedValue
            Dim ReporteGestionPTRobo_nombreConducia As String = txtNombreConducia.Text
            Dim ReporteGestionPTRobo_PaternoConducia As String = txtApepatConducia.Text
            Dim ReporteGestionPTRobo_MaternoConducia As String = txtApematConducia.Text
            Dim ReporteGestionPTRobo_LadaConducia As String = txtLadaConducia.Text
            Dim ReporteGestionPTRobo_telConducia As String = txtTelConducia.Text
            Dim ReporteGestionPTRobo_CelLadaConducia As String = txtLadaMovilConducia.Text
            Dim ReporteGestionPTRobo_CelTelConducia As String = txtTelMovilConducia.Text
            Dim ReporteGestionPTRobo_EdoPlacas As String = cboEstadoPlacas.SelectedValue
            Dim ReporteGestionPTRobo_MpioPlacas As String = cboMpioPlacas.SelectedValue
            Dim ReporteGestionPTRobo_TipoCarga As String = txtTipoCarga.Text
            Dim ReporteGestionPTRobo_Paquete As String = txtPaquete.Text
            Dim ReporteGestionPTRobo_Descripcion As String = txtDescripcion.Text
            Dim pReporte_MedioContacto As String = tblTipoActivacion.SelectedValue
            Dim pReporte_Leasing As String = rdoLeasing.SelectedValue
            Dim pReporte_LadaExtra As String = txtLadaEx.Text
            Dim pReporte_TelExtra As String = txtTelEx.Text
            Dim pReporteMotivoNoCorreo As Integer = cboMotivoNoCorreo.SelectedValue

            If csDAL.update_reporteGestion(Session("noGestionIntegral"), pReporte_clvMpio, pReporte_APaternoReporta, pReporte_AMaternoReporta, pReporte_NombreReporta, pReporte_LadaReporta, pReporte_telReporta, pReporte_poliza, pReporte_Inciso, pReporte_ApaternoAseg, pReporte_AMaternoAseg, pReporte_NombreAseg, pReporte_MailAseg, pReporte_CiaAsegura, pReporte_UsuarioMod, pReporte_LadaAseg, pReporte_TelAseg, pReporte_LadamovilAseg, pReporte_movilAseg, pReporte_contrato, pReporte_AsegContrato, pReporte_Leasing, pReporte_LadaExtra, pReporte_TelExtra, pReporteMotivoNoCorreo) = True Then
                If csDAL.update_ReporteGestionPTxRobo(Session("noGestionIntegral"), ReporteGestionPTRobo_NoSiniestro, ReporteGestionPTRobo_NoReporte, ReporteGestionPTRobo_NoAveriguacion, ReporteGestionPTRobo_FechaAverigua, ReporteGestionPTRobo_MarcaVehi, ReporteGestionPTRobo_SubMarcaVehi, ReporteGestionPTRobo_SubMarcaVehi2, ReporteGestionPTRobo_ModeloVehi, ReporteGestionPTRobo_ColorVehi, ReporteGestionPTRobo_SerieVehi, ReporteGestionPTRobo_PlacasVehi, ReporteGestionPTRobo_TipoVehi, ReporteGestionPTRobo_Llama, ReporteGestionPTRobo_FEchaRobo, ReporteGestionPTRobo_HoraRobo, ReporteGestionPTRobo_CalleRobo, ReporteGestionPTRobo_ColoniaRobo, ReporteGestionPTRobo_Referencias, ReporteGestionPTRobo_TipoRobo, ReporteGestionPTRobo_QuienConducia, ReporteGestionPTRobo_nombreConducia, ReporteGestionPTRobo_PaternoConducia, ReporteGestionPTRobo_MaternoConducia, ReporteGestionPTRobo_LadaConducia, ReporteGestionPTRobo_telConducia, ReporteGestionPTRobo_CelLadaConducia, ReporteGestionPTRobo_CelTelConducia, ReporteGestionPTRobo_EdoPlacas, ReporteGestionPTRobo_MpioPlacas, ReporteGestionPTRobo_TipoCarga, ReporteGestionPTRobo_Paquete, ReporteGestionPTRobo_Descripcion, pReporte_MedioContacto) = True Then
                    ConfigureNotification("Atención", "Se actualizo la información con exito..")
                Else
                    ConfigureNotification("Atención", "Error al guardar los datos, por favor verifique la información..")
                End If
            Else
                ConfigureNotification("Atención", "Error al guardar los datos, por favor verifique la información..")
            End If
        End If
    End Sub

    Protected Sub cmdNewContac_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdNewContac.Click
        Panel1.Visible = True
        txtNomCot.Text = String.Empty
        txtPatCot.Text = String.Empty
        txtMatCot.Text = String.Empty
        txtLadaCot.Text = String.Empty
        txtTelCon.Text = String.Empty
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
            ConfigureNotification("Atención", "Son necesario mas datos para generar un nuevo contacto..")
            Exit Sub
        End If

        If csDAL.Insert_GestionContacto(NoGestion, GestionContacto_ApePat, GestionContacto_ApeMat, GestionContacto_Nombre, GestionContacto_Lada, GestionContacto_Telefono, GestionContacto_Observaciones, GestionContacto_UsrCambio) = True Then
            ConfigureNotification("Atención", "Contacto dado de Alta con exito..")
            cmdNewContac.Visible = True
            cmdNewContac0.Visible = False
            Panel1.Visible = False
            CargaContactos(Session("noGestionIntegral"))
        Else
            ConfigureNotification("Atención", "Error al dar de alta el nuevo Contacto verifique la información..")

        End If
    End Sub
    
    Protected Sub Button4_Click(sender As Object, e As System.EventArgs) Handles Button4.Click
        Panel2.Visible = True
    End Sub

    Protected Sub Button3_Click(sender As Object, e As System.EventArgs) Handles Button3.Click
        Dim NoGestion As String = Session("noGestionIntegral")
        Dim lada As String = txt_ladaextra.Text.Trim
        Dim tel As String = txt_telextra.Text.Trim
        Dim tipo As String = txt_tipoTelExtra.Text.Trim

        If csDAL.Insert_TelExtrass(NoGestion, lada, tel, tipo) = True Then
            ConfigureNotification("atencion", "Telefono dado de Alta con exito..")
            Panel2.Visible = False

            CargaTelefonosExtra(Session("noGestionIntegral"))
        Else
            ConfigureNotification("atencion", "Error al dar de alta el nuevo telefono verifique la información..")

        End If
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

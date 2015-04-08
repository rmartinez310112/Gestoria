Imports System.Data

Partial Class GestionGeneralNRFM_AsistenciaLegal
    Inherits System.Web.UI.Page
    Dim csNeg As New ClaseNegocios
    Dim csSQLsvr As New BaseDatosSQL
    Dim csDAL As New DALClass
#Region "Notificacion"
    Protected Sub ConfigureNotification(ByVal titulo As String, ByVal texto As String)
        'String
        'lblError.Text = texto
        'lblError0.Text = texto
        RadNotification2.Title = "Aviso!"
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

        RadNotification2.Pinned = True
        RadNotification2.EnableRoundedCorners = True
        RadNotification2.EnableShadow = True
        RadNotification2.KeepOnMouseOver = False
        RadNotification2.VisibleTitlebar = True
        RadNotification2.ShowCloseButton = True
        RadNotification2.Show()

    End Sub
#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Session("noGestionIntegral") <> Nothing Then
                'Session("noGestionIntegral") = 20131311292
                cargaEstados()
                cargaMarca()
                CargaTelefonosExtra(Session("noGestionIntegral"))
                'CargaContactos(Session("noGestionIntegral"))
                cargaDatosGestion(csDAL.buscaExpedienteGestion(Session("noGestionIntegral")))
                cargaDatosGestionPT(csDAL.buscaExpedienteGestionPTxRobo2(Session("noGestionIntegral")))
                CargaCorreoMotivo()
                cargaMotivoNoenvioCorreos()
            Else
                ConfigureNotification("Aviso", "Favor de Introducir No.Gestion")
            End If
        End If
    End Sub

    Private Sub cargaDatosGestion(ByVal datosGestion As DataSet)
        Dim dr As DataRow
        For Each dr In datosGestion.Tables(0).Rows
            Try
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
                txtCia.Text = dr("Reporte_CiaAsegura").ToString.Trim()
                txtEmail.Text = dr("Reporte_MailAseg").ToString.Trim
                txtPoliza.Text = dr("Reporte_poliza")
                txtInciso.Text = dr("Reporte_Inciso")
                txtContrato.Text = dr("Reporte_contrato")
                'txtStatus.Text = dr("Reporte_estatusPoliza").ToString.Trim
                txtCliente.Text = csDAL.buscaAseguradora(dr("Reporte_cliente"))
                txtTipoServicio.Text = csDAL.buscaTipoServicio(dr("Reporte_cliente"), dr("Reporte_Tipo"))
                'txtFechaOcur.SelectedDate = dr("Reporte_FechaOcurre")
                'Dim horaOcurre = Convert.ToDateTime(Format(dr("Reporte_FechaOcurre"), "HH:mm"))
                'txtHoraOcurr.SelectedDate = CDate(horaOcurre)
                txtLadaCto0.Text = dr("Reporte_LadaAseg")
                txtTelCon0.Text = dr("Reporte_TelAseg")
                txtLadaCto1.Text = dr("Reporte_movilLadaAseg")
                txtTelCon1.Text = dr("Reporte_movilAseg")
                txtSta.Text = dr("Reporte_estatusPoliza")
                txt_ladaextra.Text = dr("Reporte_LadaEx").ToString.Trim
                txt_telextra.Text = dr("Reporte_TelEx").ToString.Trim

                If Not IsDBNull(dr("Reporte_Leasing")) Then
                    rdoLeasing.SelectedValue = dr("Reporte_Leasing")
                End If
                'If dr("Reporte_FinVigencia") <> " 01/01/1900 12:00:00 a.m." Then
                '    RadDatePicker1.SelectedDate = CDate(Format(dr("Reporte_inicioVigencia"), "dd/MM/yyyy"))
                'End If
                If dr("Reporte_inicioVigencia") <> " 01/01/1900 12:00:00 a.m." Then
                    pckIniContrato.SelectedDate = CDate(Format(dr("Reporte_inicioVigencia"), "dd/MM/yyyy"))
                End If
                If dr("Reporte_FinVigencia") <> " 01/01/1900 12:00:00 a.m." Then
                    pckFinContrato.SelectedDate = CDate(Format(dr("Reporte_FinVigencia"), "dd/MM/yyyy"))
                End If
                If txtNomAseg.Text = Nothing And txtApepatAseg.Text = Nothing And txtApeMatAseg.Text = Nothing Then
                    rdoPersona.SelectedValue = 2
                    txtCia.Text = dr("Reporte_CiaAsegura").ToString.Trim
                    Label10.Visible = False
                    Label11.Visible = False
                    Label12.Visible = False
                    lblFisica.Visible = False
                    txtApepatAseg.Visible = False
                    txtApeMatAseg.Visible = False
                    txtNomAseg.Visible = False
                    lblMoral.Visible = True
                    txtCia.Visible = True


                End If
            Catch ex As Exception

            End Try

        Next
        datosGestion.Clear()
        datosGestion.Dispose()
    End Sub
    Private Sub cargaDatosGestionPT(ByVal datosGestionPT As DataSet)
        Dim dr As DataRow
        For Each dr In datosGestionPT.Tables(0).Rows
            txtNoSiniestro.Text = dr("ReporteGestionPTRobo_NoSiniestro")
            txtNoReporte.Text = dr("ReporteGestionPTRobo_NoReporte")
            'txtNoAverig.Text = dr("ReporteGestionPTRobo_NoAveriguacion")
            'txtFechaAver.SelectedDate = dr("ReporteGestionPTRobo_FechaAverigua")
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
            txtHoraRobo.SelectedTime = dr("ReporteGestionPTRobo_HoraRobo")
            txtCalleRobo.Text = dr("ReporteGestionPTRobo_CalleRobo").ToString.Trim
            txtColoniaRobo.Text = dr("ReporteGestionPTRobo_ColoniaRobo").ToString.Trim
            txtReferenciaRobo.Text = dr("ReporteGestionPTRobo_Referencias").ToString.Trim
            rblTipoRobo.SelectedValue = dr("ReporteGestionPTRobo_TipoRobo")
            rblConduciaUsted.SelectedValue = dr("ReporteGestionPTRobo_QuienConducia")
            'txtTipoCarga.Text = dr("ReporteGestionPTRobo_TipoCarga").ToString.Trim
            'txtPaquete.Text = dr("ReporteGestionPTRobo_Paquete").ToString.Trim
            'txtDescripcion.Text = dr("ReporteGestionPTRobo_Descripcion").ToString.Trim
            rdoConductor.SelectedValue = dr("ReporteGestionAsistencia_conductorDetenido")
            rdoVehiculoDet.SelectedValue = dr("ReporteGestionAsistencia_VehiculoDetenido")
            rdoCargoIni.SelectedValue = dr("ReporteGestionAsistencia_CargoInicial")

            If Not IsDBNull(dr("ReporteGeneral_MedioContacto")) Then
                tblTipoActivacion.SelectedValue = dr("ReporteGeneral_MedioContacto")
            End If
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
        Next
        datosGestionPT.Clear()
        datosGestionPT.Dispose()
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
    Public Sub CargaMpio(ByVal clvEstado As Integer)

        Dim comando As String = "exec Select_cbo_Municipios " & clvEstado
        csSQLsvr.LlenarRadCombo(cboMpio, comando, Session("connGestion"))
    End Sub

    Protected Sub cboMarca_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cboMarca.SelectedIndexChanged
        CargaSubmarca(cboMarca.SelectedValue)
    End Sub
    Public Sub cargaEstados()

        Dim comando As String = "exec Select_cbo_estados"
        csSQLsvr.LlenarRadCombo(cboEstado, comando, Session("connGestion"))

    End Sub
    Public Sub cargaMarca()
        Dim comando As String = "exec Select_cbo_marcas"
        csSQLsvr.LlenarRadCombo(cboMarca, comando, Session("connGestion"))

    End Sub

    Protected Sub rdoPersona_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles rdoPersona.SelectedIndexChanged
        If rdoPersona.SelectedValue = 1 Then
            Label10.Visible = True
            Label11.Visible = True
            Label12.Visible = True
            txtApepatAseg.Visible = True
            txtApeMatAseg.Visible = True
            txtNomAseg.Visible = True
            lblMoral.Visible = False
            txtCia.Visible = False
        ElseIf rdoPersona.SelectedValue = 2 Then
            Label10.Visible = False
            Label11.Visible = False
            Label12.Visible = False
            txtApepatAseg.Visible = False
            txtApeMatAseg.Visible = False
            txtNomAseg.Visible = False
            lblMoral.Visible = True
            txtCia.Visible = True
        End If
        LimpiaCajas()
    End Sub

    Private Sub LimpiaCajas()
        txtApepatAseg.Text = ""
        txtApeMatAseg.Text = ""
        txtNomAseg.Text = ""

        txtCia.Text = ""

    End Sub

    Protected Sub Button1_Click(sender As Object, e As System.EventArgs) Handles Button1.Click
        'If ValidaVacios() = True Then

        'Dim pReporte_cliente As Integer = txtCliente.Text.Trim
        'Dim pReporte_Tipo As String = txtTipoServicio.Text.Trim
        Dim pReporte_clvEstado As Integer = cboEstado.SelectedValue
        Dim pReporte_clvMpio As Integer = cboMpio.SelectedValue
        Dim pReporte_fechaRepor As String = Format(Now(), " yyyyMMdd")
        Dim pReporte_FechaOcurre = ""
        Dim pReporte_APaternoReporta As String = txtPaterno.Text.Trim.ToUpper
        Dim pReporte_AMaternoReporta As String = txtMaterno.Text.Trim.ToUpper
        Dim pReporte_NombreReporta As String = txtNombre.Text.Trim.ToUpper
        Dim pReporte_LadaReporta As String = txtLadaCto.Text.Trim
        Dim pReporte_telReporta As String = txtTelCon.Text.Trim
        Dim pReporte_status As Integer = 0
        Dim pReporte_UsuarioReg As String = Session("clvUsuario")
        Dim pReporte_HRiniCaptura As String = Session("hrInicioCaptura")
        Dim pReporte_poliza As String = txtPoliza.Text.Trim.ToUpper
        Dim pReporte_Inciso As String = txtInciso.Text.Trim.ToUpper
        Dim pReporte_ApaternoAseg As String = txtApepatAseg.Text.Trim
        Dim pReporte_AMaternoAseg As String = txtApeMatAseg.Text.Trim
        Dim pReporte_NombreAseg As String = txtNomAseg.Text.Trim
        Dim pReporte_MailAseg As String = txtEmail.Text.Trim.ToLower
        Dim pReporte_CiaAsegura As String = txtCia.Text.Trim
        'rblAsegContr.SelectedItem.ToString.Trim()
        Dim pReporte_LadaReportaCel As String = txtLadaCto1.Text.Trim
        Dim pReporte_ReportaCel As String = txtTelCon1.Text.Trim


        Dim pReporte_AsegContrato As Integer = 0
        Dim pContrato As String = ""
        Dim Reporte_LadaAseg As String = txtLadaCto0.Text.Trim
        Dim Reporte_TelAseg As String = txtTelCon0.Text.Trim
        Dim Reporte_movilAseg As String = txtTelCon1.Text.Trim
        Dim pReporte_UsuarioMod As String = Session("clvUsuario")
        Dim GestionGeneral_Llama As Integer = tblTipoLlamada.SelectedValue
        Dim GestionFallecimiento_TipoFallece As Integer = -1
        Dim GestionFallecimiento_Descripcion As String = "N/A"

        Dim Reporte_estatusPoliza As String = txtSta.Text.Trim
        Dim Reporte_inicioVigencia As String = Format(pckIniContrato.SelectedDate, "MM/dd/yyyy")
        Dim Reporte_FinVigencia As String = Format(pckFinContrato.SelectedDate, "MM/dd/yyyy")
        Dim Reporte_noControlGO As String = ""


        Dim Reporte_movilLadaAseg As String = txtLadaCto1.Text.Trim

        Dim Reporte_NoCredito As String = ""
        Dim Reporte_inicioVigCredito As String = ""
        Dim Reporte_finVigCredito As String = ""
        Dim Reporte_AvisoServicio As String = ""
        Dim ReporteGestionPTRobo_NoSiniestro As String = txtNoSiniestro.Text.Trim.ToUpper
        Dim ReporteGestionPTRobo_NoAveriguacion As String = ""
        Dim ReporteGestionPTRobo_FechaAverigua As String = ""
        Dim ReporteGestionPTRobo_MarcaVehi As Integer = cboMarca.SelectedValue
        'Dim GestionPT_SubMarcaVehi As String = csDAL.buscaSubmarca(cboSubmarca.SelectedValue, "CLAVE_MARCA_TIPO")
        Dim ReporteGestionPTRobo_SubMarcaVehi As String = cboSubmarca.SelectedValue
        Dim ReporteGestionPTRobo_ModeloVehi As String = txtModelo.Text.Trim
        Dim ReporteGestionPTRobo_ColorVehi As String = txtColor.Text.Trim.ToUpper
        Dim Rep_tipoVehi As Integer = 0
        Dim ReporteGestionPTRobo_TipoVehi As Integer = 0
        Dim ReporteGestionPTRobo_SerieVehi As String = txtSerie.Text.Trim.ToUpper
        Dim ReporteGestionPTRobo_PlacasVehi As String = txtPlacas.Text.Trim.ToUpper
        Dim ReporteGestionPTRobo_Llama As Integer = tblTipoLlamada.SelectedValue
        Dim ReporteGestionPTRobo_SubMarcaVehi2 As String = "" ' csDAL.buscaSubmarca(cboSubmarca.SelectedValue, "CLAVES_AMIS")
        Dim ReporteGestionPTRobo_NoReporte As String = txtNoReporte.Text.Trim.ToUpper
        Dim ReporteGestionPTRobo_FEchaRobo As String = ""
        Dim ReporteGestionPTRobo_HoraRobo As String = txtHoraRobo.SelectedTime.ToString
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
        Dim ReporteGestionPTRobo_EdoPlacas As String = 0
        Dim ReporteGestionPTRobo_MpioPlacas As String = 0
        Dim ReporteGestionPTRobo_TipoCarga As String = ""
        Dim ReporteGestionPTRobo_Paquete As String = ""
        Dim ReporteGestionPTRobo_Descripcion As String = ""
        Dim pReporte_MedioContacto As String = tblTipoActivacion.SelectedValue
        Dim pReporte_Leasing As String = rdoLeasing.SelectedValue
        Dim pReporte_LadaExtra As String = txtLadaEx.Text.Trim
        Dim pReporte_TelExtra As String = txtTelEx.Text.Trim
        Dim pReporteMotivoNoCorreo As Integer = cboMotivoNoCorreo.SelectedValue

        If csDAL.update_reporteGestion2(Session("noGestionIntegral"), pReporte_clvMpio, pReporte_APaternoReporta, pReporte_AMaternoReporta, pReporte_NombreReporta, pReporte_LadaReporta, pReporte_telReporta, _
pReporte_poliza, pReporte_Inciso, pReporte_ApaternoAseg, _
pReporte_AMaternoAseg, pReporte_NombreAseg, pReporte_MailAseg, pReporte_CiaAsegura, pReporte_UsuarioMod, Reporte_LadaAseg, Reporte_TelAseg, Reporte_movilAseg, pContrato, _
Reporte_movilLadaAseg, Reporte_estatusPoliza, Reporte_inicioVigencia, Reporte_FinVigencia, pReporte_AsegContrato, pReporte_Leasing, pReporte_LadaExtra, pReporte_TelExtra, pReporteMotivoNoCorreo) = True Then
            If csDAL.update_ReporteGestionPTxRobo(Session("noGestionIntegral"), ReporteGestionPTRobo_NoSiniestro, ReporteGestionPTRobo_NoReporte, ReporteGestionPTRobo_NoAveriguacion, ReporteGestionPTRobo_FechaAverigua, ReporteGestionPTRobo_MarcaVehi, ReporteGestionPTRobo_SubMarcaVehi, ReporteGestionPTRobo_SubMarcaVehi2, ReporteGestionPTRobo_ModeloVehi, ReporteGestionPTRobo_ColorVehi, ReporteGestionPTRobo_SerieVehi, ReporteGestionPTRobo_PlacasVehi, ReporteGestionPTRobo_TipoVehi, ReporteGestionPTRobo_Llama, ReporteGestionPTRobo_FEchaRobo, ReporteGestionPTRobo_HoraRobo, ReporteGestionPTRobo_CalleRobo, ReporteGestionPTRobo_ColoniaRobo, ReporteGestionPTRobo_Referencias, ReporteGestionPTRobo_TipoRobo, ReporteGestionPTRobo_QuienConducia, ReporteGestionPTRobo_nombreConducia, ReporteGestionPTRobo_PaternoConducia, ReporteGestionPTRobo_MaternoConducia, ReporteGestionPTRobo_LadaConducia, ReporteGestionPTRobo_telConducia, ReporteGestionPTRobo_CelLadaConducia, ReporteGestionPTRobo_CelTelConducia, ReporteGestionPTRobo_EdoPlacas, ReporteGestionPTRobo_MpioPlacas, ReporteGestionPTRobo_TipoCarga, ReporteGestionPTRobo_Paquete, ReporteGestionPTRobo_Descripcion, pReporte_MedioContacto) = True Then
                ConfigureNotification("Aviso", "Se actualizo la información con exito..")
            Else
                ConfigureNotification("Aviso", "Error al guardar los datos, por favor verifique la información..")
            End If
        Else
            ConfigureNotification("Aviso", "Error al guardar los datos, por favor verifique la información..")
        End If
        'End If     
    End Sub

    'Public Sub nota(ByVal mensaje As String)
    '    Dim script As String
    '    script = "alert( '" + mensaje.Replace("'", "\"") + '")
    '    'ScriptManager.RegisterStartupScript(this, this.GetType(), "ERROR", script, true);
    '    '       string script = "alert('" + mensaje.Replace("'", "\"") + "');";
    '    'ScriptManager.RegisterStartupScript(this, this.GetType(), "ERROR", script, true);
    'End Sub

    Protected Sub Button2_Click(sender As Object, e As System.EventArgs) Handles Button2.Click
        Dim NoGestion As String = Session("noGestionIntegral")
        Dim lada As String = txt_ladaextra.Text.Trim
        Dim tel As String = txt_telextra.Text.Trim
        Dim tipo As String = txt_tipoTelExtra.Text.Trim

        If csDAL.Insert_TelExtrass(NoGestion, lada, tel, tipo) = True Then
            ConfigureNotification("aviso", "Telefono dado de Alta con exito..")
            Panel2.Visible = False

            CargaTelefonosExtra(Session("noGestionIntegral"))
        Else
            ConfigureNotification("aviso", "Error al dar de alta el nuevo telefono verifique la información..")

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

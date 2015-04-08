Imports System.Data

Partial Class GestionGeneralNRFM_GeneralNRFM
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
            'Session("noGestionIntegral") = 20151822351245
            If Session("noGestionIntegral") <> Nothing Then
                'Session("noGestionIntegral") = 20131311292
                cargaEstados()
                cargaMarca()
                cargaDistribuidor()
                CargaTelefonosExtra(Session("noGestionIntegral"))
                'CargaContactos(Session("noGestionIntegral"))
                cargaDatosGestion(csDAL.buscaExpedienteGestion(Session("noGestionIntegral")))
                cargaDatosGestionGeneral(csDAL.buscaExpedienteGestionGeneral(Session("noGestionIntegral")))
                CargaCorreoMotivo()
                cargaMotivoNoenvioCorreos()
                PagoEvento(Session("noGestionIntegral"))
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
                txtLadaEx.Text = dr("Reporte_LadaEx").ToString.Trim
                txtTelEx.Text = dr("Reporte_TelEx").ToString.Trim

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
    Private Sub cargaDatosGestionGeneral(ByVal datosGestionG As DataSet)
        Dim dr As DataRow
        For Each dr In datosGestionG.Tables(0).Rows
            'txtNoSiniestro.Text = dr("ReporteGestionPT_NoSiniestro")
            'txtNoReporte.Text = dr("ReporteGestionPT_NoReporte")


            'txtNoAverig.Text = dr("ReporteGestionPT_NoAveriguacion")
            'txtFechaAver.SelectedDate = dr("ReporteGestionPT_FechaAverigua")
            txtModelo.Text = dr("ReporteGestionPT_ModeloVehi")
            txtColor.Text = dr("ReporteGestionPT_ColorVehi")
            txtSerie.Text = dr("ReporteGestionPT_SerieVehi")
            txtPlacas.Text = dr("ReporteGestionPT_PlacasVehi")
            'txtObservaciones.Text = dr("ReporteObservacion")
            'txt_NomEnt.Text = dr("ReporteGeneral_NomEnt")
            'txt_LadaEnt.Text = dr("ReporteGeneral_LadaEnt")
            'txt_TelEnt.Text = dr("ReporteGeneral_TelEnt")

            If Not IsDBNull(dr("ReporteGeneral_NomEnt")) Then
                tblTipoActivacion.SelectedValue = dr("ReporteGeneral_NomEnt")
            End If
            If Not IsDBNull(dr("ReporteGeneral_LadaEnt")) Then
                tblTipoActivacion.SelectedValue = dr("ReporteGeneral_LadaEnt")
            End If
            If Not IsDBNull(dr("ReporteGeneral_TelEnt")) Then
                tblTipoActivacion.SelectedValue = dr("ReporteGeneral_TelEnt")
            End If

            If Not IsDBNull(dr("ReporteGeneral_MedioContacto")) Then
                tblTipoActivacion.SelectedValue = dr("ReporteGeneral_MedioContacto")
            End If

            tblTipoLlamada.SelectedValue = dr("ReporteGeneral_Llama")

            Select Case Len(Trim(dr("ReporteGestionPT_MarcaVehi")))
                Case Is = 1
                    dr("ReporteGestionPT_MarcaVehi") = "00" & Trim(dr("ReporteGestionPT_MarcaVehi"))
                Case Is = 2
                    dr("ReporteGestionPT_MarcaVehi") = "0" & Trim(dr("ReporteGestionPT_MarcaVehi"))
            End Select
            cboMarca.SelectedValue = Trim(dr("ReporteGestionPT_MarcaVehi"))

            CargaSubmarca(Trim(dr("ReporteGestionPT_MarcaVehi")))
            cboSubmarca.SelectedValue = Trim(dr("ReporteGestionPT_SubMarcaVehi"))
        Next
        datosGestionG.Clear()
        datosGestionG.Dispose()
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
        Dim _ReporteGestionPTRobo_MarcaVehi As String = cboMarca.SelectedValue
        Dim _ReporteGestionPTRobo_SubMarcaVehi As String = cboSubmarca.SelectedValue
        Dim _ReporteGestionPTRobo_ModeloVehi As Integer = Convert.ToInt16(txtModelo.Text.Trim)
        '_ReporteGestionPTRobo_ModeloVehi = txtModelo.Text.Trim
        Dim _ReporteGestionPTRobo_ColorVehi As String = txtColor.Text.Trim
        Dim _ReporteGestionPTRobo_SerieVehi As String = txtSerie.Text.Trim
        Dim _ReporteGestionPTRobo_PlacasVehi As String = txtPlacas.Text.Trim
        Dim ReporteInfoCorreo As String = rdoInfoCorreo.SelectedValue
        Dim ReporteInfoCel As String = rdoInfoCel.SelectedValue
        Dim ReporteGestionPTRobo_Descripcion As String = "N/A"
        Dim pReporte_MedioContacto As String = tblTipoActivacion.SelectedValue
        Dim pReporte_Leasing As String = rdoLeasing.SelectedValue
        Dim pReporte_LadaExtra As String = txtLadaEx.Text.Trim
        Dim pReporte_TelExtra As String = txtTelEx.Text.Trim
        Dim pReporteMotivoNoCorreo As Integer = cboMotivoNoCorreo.SelectedValue
        Dim pReporte_NomEnt As String = txt_NomEnt.Text.Trim
        Dim pReporte_LadaEnt As String = txt_LadaEnt.Text.Trim
        Dim pReporte_TelEnt As String = txt_TelEnt.Text

        If csDAL.update_reporteGestion2(Session("noGestionIntegral"), pReporte_clvMpio, pReporte_APaternoReporta, pReporte_AMaternoReporta, pReporte_NombreReporta, pReporte_LadaReporta, pReporte_telReporta, _
pReporte_poliza, pReporte_Inciso, pReporte_ApaternoAseg, _
pReporte_AMaternoAseg, pReporte_NombreAseg, pReporte_MailAseg, pReporte_CiaAsegura, pReporte_UsuarioMod, Reporte_LadaAseg, Reporte_TelAseg, Reporte_movilAseg, pContrato, _
Reporte_movilLadaAseg, Reporte_estatusPoliza, Reporte_inicioVigencia, Reporte_FinVigencia, pReporte_AsegContrato, pReporte_Leasing, pReporte_LadaExtra, pReporte_TelExtra, pReporteMotivoNoCorreo) = True Then
            If csDAL.update_ReporteGestionGeneralPagoxEvento(Session("noGestionIntegral"), _ReporteGestionPTRobo_MarcaVehi, _ReporteGestionPTRobo_SubMarcaVehi, _ReporteGestionPTRobo_ModeloVehi, _ReporteGestionPTRobo_ColorVehi, _ReporteGestionPTRobo_PlacasVehi, _ReporteGestionPTRobo_SerieVehi, ReporteInfoCorreo, ReporteInfoCel, ReporteGestionPTRobo_Descripcion, GestionGeneral_Llama, pReporte_MedioContacto, pReporte_NomEnt, pReporte_LadaEnt, pReporte_TelEnt) Then
                ConfigureNotification("Aviso", "Se actualizo la información con exito..")
            Else
                ConfigureNotification("Aviso", "Error al guardar los datos, por favor verifique la información..")
            End If
        Else
            ConfigureNotification("Aviso", "Error al guardar los datos, por favor verifique la información..")
        End If
        'End If     
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
    Public Sub cargaDistribuidor()
        Dim comando As String = "exec Select_cbo_distribuidor"
        csSQLsvr.LlenarRadCombo(cboDistribuidor, comando, Session("connGestion"))
    End Sub

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
    Public Sub PagoEvento(ByVal NoGestion As String)
        Dim ds As New DataSet
        Dim dr As DataRow

        ds = csDAL.select_PagoEvento(NoGestion)
        If ds.Tables(0).Rows.Count <> 0 Then
            For Each dr In ds.Tables(0).Rows
                If dr("ReporteGestion_FechaAlta") <> Nothing Then
                    chkPAgoEvento.Checked = True

                End If

                    Next

        End If


    End Sub
End Class

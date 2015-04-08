Imports System.Data

Partial Class GestionPerdidaTotal_DatosGestionPTOrdaz_ABC
Inherits System.Web.UI.Page

    Dim csNeg As New ClaseNegocios
    Dim csSQLsvr As New BaseDatosSQL
    Dim csDAL As New DALClass
    #Region "procesos"
    'Protected Sub ConfigureNotification(ByVal texto As String)
    '    'String
    '    lblError.Text = texto
    '    lblError0.Text = texto
    '    RadNotification2.Title = "Atención"
    '    RadNotification2.Text = texto
    '    'Enum
    '    RadNotification2.Position = Telerik.Web.UI.NotificationPosition.Center
    '    RadNotification2.Animation = Telerik.Web.UI.NotificationAnimation.Fade
    '    'notificacion.ContentScrolling = Telerik.Web.UI.NotificationScrolling.Default
    '    RadNotification2.AutoCloseDelay = 5000
    '    'Unit
    '    RadNotification2.Width = 300
    '    RadNotification2.Height = 150
    '    RadNotification2.OffsetX = -10
    '    RadNotification2.OffsetY = 10

    '    RadNotification2.Pinned = False
    '    RadNotification2.EnableRoundedCorners = True
    '    RadNotification2.EnableShadow = True
    '    RadNotification2.KeepOnMouseOver = False
    '    RadNotification2.VisibleTitlebar = True
    '    RadNotification2.ShowCloseButton = True
    '    RadNotification2.Show()

    'End Sub

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

    Protected Sub ConfigureNotification(ByVal titulo As String, ByVal texto As String)
        'String
        lblError.Text = texto
        lblError0.Text = texto
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

    Private Function ValidaVacios() As Boolean
        ValidaVacios = False

        If csNeg.VaciosTexto(txtPaterno) = True Then
            ConfigureNotification("Aviso", "El apellido paterno de la persona que reporta no puede estar vacio")
            SetFocus(txtPaterno)
            ValidaVacios = False
            Return ValidaVacios
            Exit Function
        End If

        If csNeg.VaciosTexto(txtMaterno) = True Then
            ConfigureNotification("Aviso", "El apellido materno de la persona que reporta no puede estar vacio")
            SetFocus(txtMaterno)
            ValidaVacios = False
            Return ValidaVacios
            Exit Function
        End If
        If csNeg.VaciosTexto(txtNombre) = True Then
            ConfigureNotification("Aviso", "El nombre de la persona que reporta no puede estar vacio")
            SetFocus(txtNombre)
            ValidaVacios = False
            Return ValidaVacios
            Exit Function
        End If

        If csNeg.VaciosTexto(txtLadaCto) = True Then
            ConfigureNotification("Aviso", "Es necesaria la clave lada de la persona que reporta")
            SetFocus(txtLadaCto)
            ValidaVacios = False
            Return ValidaVacios
            Exit Function
        End If

        If csNeg.VaciosTexto(txtTelCon) = True Then
            ConfigureNotification("Aviso", "Es necesaria la el telefono de la persona que reporta")
            SetFocus(txtTelCon)
            ValidaVacios = False
            Return ValidaVacios
            Exit Function
        End If


        If Not txtFechaOcur.SelectedDate.HasValue Then
            ConfigureNotification("Aviso", "Es necesaria la fecha en que ocurrio el siniestro")
            SetFocus(txtFechaOcur)
            ValidaVacios = False
            Return ValidaVacios
            Exit Function

        End If

        If Not txtHoraOcurr.SelectedDate.HasValue Then
            ConfigureNotification("Aviso", "Es necesaria la hora en que ocurrio el siniestro")
            SetFocus(txtHoraOcurr)
            ValidaVacios = False
            Return ValidaVacios
            Exit Function

        End If

        If csNeg.VaciosTexto(txtTelCon) = True Then
            ConfigureNotification("Aviso", "Es necesaria la el telefono de la persona que reporta")
            SetFocus(txtTelCon)
            ValidaVacios = False
            Return ValidaVacios
            Exit Function
        End If


        If csNeg.VaciosTexto(txtNoPoliza) = True Then
            ConfigureNotification("Aviso", "Es necesario el No. de poliza")
            SetFocus(txtNoPoliza)
            ValidaVacios = False
            Return ValidaVacios
            Exit Function
        End If
        If txtCia.Text.Trim = String.Empty Then
            If csNeg.VaciosTexto(txtApepatAseg) = True Then
                ConfigureNotification("Aviso", "El apellido paterno del asegurado es obligatorio")
                SetFocus(txtApepatAseg)
                ValidaVacios = False
                Return ValidaVacios
                Exit Function
            End If

            If csNeg.VaciosTexto(txtApeMatAseg) = True Then
                ConfigureNotification("Aviso", "El apellido materno del asegurado es obligatorio")
                SetFocus(txtApeMatAseg)
                ValidaVacios = False
                Return ValidaVacios
                Exit Function
            End If
            If csNeg.VaciosTexto(txtNomAseg) = True Then
                ConfigureNotification("Aviso", "El nombre del asegurado es obligatorio")
                SetFocus(txtNomAseg)
                ValidaVacios = False
                Return ValidaVacios
                Exit Function
            End If
        End If
        If csNeg.VaciosTexto(txtLadaAseg) = True Then
            ConfigureNotification("Aviso", "Es necesaria la clave lada  del asegurado")
            SetFocus(txtLadaAseg)
            ValidaVacios = False
            Return ValidaVacios
            Exit Function
        End If

        If csNeg.VaciosTexto(txtTelAseg) = True Then
            ConfigureNotification("Aviso", "Es necesaria la el telefono del asegurado")
            SetFocus(txtTelAseg)
            ValidaVacios = False
            Return ValidaVacios
            Exit Function
        End If

        If csNeg.VaciosTexto(txtApepatAseg) = True And csNeg.VaciosTexto(txtNomAseg) = True Then
            ConfigureNotification("Aviso", "Si el asegurado es persona moral es necesario el nombre de la Compañia")
            SetFocus(txtCia)
            ValidaVacios = False
            Return ValidaVacios
            Exit Function

        End If
        If csNeg.VaciosTexto(txtNoSiniestro) = True Then
            ConfigureNotification("Aviso", "Es necesario el No. de Siniestro")
            SetFocus(txtNoSiniestro)
            ValidaVacios = False
            Return ValidaVacios
            Exit Function
        End If

        If csNeg.VaciosTexto(txtModelo) = True Then
            ConfigureNotification("Aviso", "Es modelo del vehiculo es necesario")
            SetFocus(txtModelo)
            ValidaVacios = False
            Return ValidaVacios
            Exit Function
        End If

        If cboSubmarca.SelectedValue = 0 Then
            ConfigureNotification("Aviso", "La submarca del vehiculo es necesario")
            SetFocus(cboSubmarca)
            ValidaVacios = False
            Return ValidaVacios
            Exit Function
        End If

        If txtEmail.Text.Trim <> String.Empty Then
            If csNeg.VerificaEmail(txtEmail.Text) = False Then
                ConfigureNotification("Aviso", "El email no tiene en el formato correcto")
                SetFocus(txtEmail)
                ValidaVacios = False
                Return ValidaVacios
                Exit Function
            End If
        End If

        'If txtNoAverig.Text.Trim = String.Empty Then
        '    ConfigureNotification("Aviso", "Es necesario el No. de Averiguación previa")
        '    SetFocus(txtNoAverig)
        '    ValidaVacios = False
        '    Return ValidaVacios
        '    Exit Function
        'End If



        lblError.Text = String.Empty
        lblError0.Text = String.Empty
        ValidaVacios = True
        Return ValidaVacios

    End Function

    Public Sub cargaEstados()

        Dim comando As String = "exec Select_cbo_estados"
        csSQLsvr.LlenarRadCombo(cboEstado, comando, Session("connGestion"))

    End Sub

    Public Sub CargaMpio(ByVal clvEstado As Integer)

        Dim comando As String = "exec Select_cbo_Municipios " & clvEstado
        csSQLsvr.LlenarRadCombo(cboMpio, comando, Session("connGestion"))
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
                txtNoPoliza.Text = dr("Reporte_poliza")
                txtInciso.Text = dr("Reporte_Inciso")
                txtContrato.Text = dr("Reporte_contrato")
                txtStatus.Text = dr("Reporte_estatusPoliza").ToString.Trim
                txtCliente.Text = csDAL.buscaAseguradora(dr("Reporte_cliente"))
                txtTipoServicio.Text = csDAL.buscaTipoServicio(dr("Reporte_cliente"), dr("Reporte_Tipo"))
                'txtFechaOcur.SelectedDate = dr("Reporte_FechaOcurre")
                Dim horaOcurre = Convert.ToDateTime(Format(dr("Reporte_FechaOcurre"), "HH:mm"))
                txtHoraOcurr.SelectedDate = CDate(horaOcurre)
                txtLadaAseg.Text = dr("Reporte_LadaAseg")
                txtTelAseg.Text = dr("Reporte_TelAseg")
                txtLadaCto1.Text = dr("Reporte_movilLadaAseg")
                txtTelMovil.Text = dr("Reporte_movilAseg")
                'txtFechaOcur0.SelectedDate = CDate(dr("Reporte_inicioVigencia"))
                'txtFechaOcur1.SelectedDate = CDate(dr("Reporte_FinVigencia"))
                txtNoGo.Text = dr("Reporte_noControlGO")
                txtnocredito.Text = dr("Reporte_NoCredito")
                txtAviso.Text = dr("Reporte_AvisoServicio")
                txtLadaEx.Text = dr("Reporte_LadaEx").ToString.Trim
                txtTelEx.Text = dr("Reporte_TelEx").ToString.Trim

                If Not IsDBNull(dr("Reporte_Leasing")) Then
                    rdoLeasing.SelectedValue = dr("Reporte_Leasing")
                End If

                If txtFechaInicioCred.SelectedDate = " 01/01/1900 12:00:00 a.m." Then
                    txtFechaInicioCred.SelectedDate = CDate(dr("Reporte_inicioVigCredito"))
                End If
                If txtFechaFinCred.SelectedDate = " 01/01/1900 12:00:00 a.m." Then
                    txtFechaFinCred.SelectedDate = CDate(dr("Reporte_finVigCredito"))
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
                rblAsegContr.SelectedValue = dr("Reporte_AsegContrato")
            Catch ex As Exception

            End Try
           
        Next
        datosGestion.Clear()
        datosGestion.Dispose()
    End Sub

    Private Sub cargaDatosGestionPT(ByVal datosGestionPT As DataSet)
        Dim dr As DataRow
        For Each dr In datosGestionPT.Tables(0).Rows
            txtNoSiniestro.Text = dr("ReporteGestionPT_NoSiniestro")
            txtNoReporte.Text = dr("ReporteGestionPT_NoReporte")


            'txtNoAverig.Text = dr("ReporteGestionPT_NoAveriguacion")
            'txtFechaAver.SelectedDate = dr("ReporteGestionPT_FechaAverigua")
            txtModelo.Text = dr("ReporteGestionPT_ModeloVehi")
            txtColor.Text = dr("ReporteGestionPT_ColorVehi")
            txtSerie.Text = dr("ReporteGestionPT_SerieVehi")
            txtPlacas.Text = dr("ReporteGestionPT_PlacasVehi")
            tblTipoLlamada.SelectedValue = dr("ReporteGestionPT_Llama")
            If Not IsDBNull(dr("ReporteGeneral_MedioContacto")) Then
                tblTipoActivacion.SelectedValue = dr("ReporteGeneral_MedioContacto")
            End If

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
        datosGestionPT.Clear()
        datosGestionPT.Dispose()
    End Sub

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Session("noGestionIntegral") <> Nothing Then
                'Session("noGestionIntegral") = 20131311292
                cargaEstados()
                cargaMarca()
                CargaContactos(Session("noGestionIntegral"))
                CargaTelefonosExtra(Session("noGestionIntegral"))
                cargaDatosGestion(csDAL.buscaExpedienteGestion(Session("noGestionIntegral")))
                cargaDatosGestionPT(csDAL.buscaExpedienteGestionPTxDM(Session("noGestionIntegral")))
                CargaCorreoMotivo()
                cargaMotivoNoenvioCorreos()
            Else
                ConfigureNotification("Aviso", "Favor de Introducir No.Gestion")
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
            Dim pReporte_contrato As String = txtContrato.Text.Trim
            Dim pReporte_AsegContrato As Integer = rblAsegContr.SelectedValue
            Dim pReporte_LadaAseg As String = txtLadaAseg.Text.Trim
            Dim pReporte_TelAseg As String = txtTelAseg.Text.Trim
            Dim pReporte_LadamovilAseg As String = txtLadaCto1.Text.Trim
            Dim pReporte_movilAseg As String = txtTelMovil.Text.Trim
            Dim GestionPT_NoSiniestro As String = txtNoSiniestro.Text.Trim.ToUpper
            'Dim GestionPT_NoAveriguacion As String = txtNoAverig.Text.Trim.ToUpper
            'Dim GestionPT_FechaAverigua As String = Format(txtFechaAver.SelectedDate, "yyyyMMdd")
            Dim GestionPT_MarcaVehi As Integer = cboMarca.SelectedValue
            Dim GestionPT_SubMarcaVehi As String = cboSubmarca.SelectedValue
            'Dim GestionPT_SubMarcaVehi As String = cboSubmarca.SelectedValue
            Dim GestionPT_ModeloVehi As String = txtModelo.Text.Trim
            Dim GestionPT_ColorVehi As String = txtColor.Text.Trim.ToUpper
            Dim GestionPT_SerieVehi As String = txtSerie.Text.Trim.ToUpper
            Dim GestionPT_PlacasVehi As String = txtPlacas.Text.Trim.ToUpper
            Dim GestionPT_Llama As Integer = tblTipoLlamada.SelectedValue
            Dim GestionPT_SubMarcaVehi2 As String = "" ' csDAL.buscaSubmarca(cboSubmarca.SelectedValue, "CLAVES_AMIS")
            Dim GestionPT_NoReporte As String = txtNoReporte.Text.Trim.ToUpper
            Dim pReporte_MedioContacto As String = tblTipoActivacion.SelectedValue
            Dim pReporte_Leasing As String = rdoLeasing.SelectedValue
            Dim pReporte_LadaExtra As String = txtLadaEx.Text
            Dim pReporte_TelExtra As String = txtTelEx.Text
            Dim pReporteMotivoNoCorreo As Integer = cboMotivoNoCorreo.SelectedValue

            If csDAL.update_reporteGestion(Session("noGestionIntegral"), pReporte_clvMpio, pReporte_APaternoReporta, pReporte_AMaternoReporta, pReporte_NombreReporta, pReporte_LadaReporta, pReporte_telReporta, pReporte_poliza, pReporte_Inciso, pReporte_ApaternoAseg, pReporte_AMaternoAseg, pReporte_NombreAseg, pReporte_MailAseg, pReporte_CiaAsegura, pReporte_UsuarioMod, pReporte_LadaAseg, pReporte_TelAseg, pReporte_LadamovilAseg, pReporte_movilAseg, pReporte_contrato, pReporte_AsegContrato, pReporte_Leasing, pReporte_LadaExtra, pReporte_TelExtra, pReporteMotivoNoCorreo) = True Then
                If csDAL.update_ReporteGestionPT(Session("noGestionIntegral"), GestionPT_NoSiniestro, GestionPT_MarcaVehi, GestionPT_SubMarcaVehi, GestionPT_SubMarcaVehi2, GestionPT_ModeloVehi, GestionPT_ColorVehi, GestionPT_SerieVehi, GestionPT_PlacasVehi, GestionPT_Llama, GestionPT_NoReporte, pReporte_UsuarioMod, pReporte_MedioContacto) = True Then
                    ConfigureNotification("Aviso", "Se actualizo la información con exito..")
                Else
                    ConfigureNotification("Aviso", "Error al guardar los datos, por favor verifique la información..")
                End If
            Else
                ConfigureNotification("Aviso", "Error al guardar los datos, por favor verifique la información..")
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
            ConfigureNotification("Aviso", "Son necesario mas datos para generar un nuevo contacto..")
            Exit Sub
        End If

        If csDAL.Insert_GestionContacto(NoGestion, GestionContacto_ApePat, GestionContacto_ApeMat, GestionContacto_Nombre, GestionContacto_Lada, GestionContacto_Telefono, GestionContacto_Observaciones, GestionContacto_UsrCambio) = True Then
            ConfigureNotification("Aviso", "Contacto dado de Alta con exito..")
            cmdNewContac.Visible = True
            cmdNewContac0.Visible = False
            Panel1.Visible = False
            CargaContactos(Session("noGestionIntegral"))
        Else
            ConfigureNotification("Aviso", "Error al dar de alta el nuevo Contacto verifique la información..")

        End If
    End Sub

    Protected Sub cboMarca_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cboMarca.SelectedIndexChanged
        CargaSubmarca(cboMarca.SelectedValue)
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

    Protected Sub Button4_Click(sender As Object, e As System.EventArgs) Handles Button4.Click
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
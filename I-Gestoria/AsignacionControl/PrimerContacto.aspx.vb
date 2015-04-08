Imports System.Data
Imports System.Data.SqlClient

Partial Class AsignacionControl_PrimerContacto

    Inherits System.Web.UI.Page
    Dim csNeg As New ClaseNegocios
    Dim csSQLsvr As New BaseDatosSQL
    Dim cbGes As New ClaseBaseGestoria
    Dim csDAL As New DALClass


    Private Sub RegistraScript()
        ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind();", True)
    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RdoClienteAcepta.SelectedIndexChanged
        If RdoClienteAcepta.SelectedValue = 1 Then

            PanelSiAceptaPreg.Visible = True
            PanelNoAceptaPreg.Visible = False
            RadGrid1.Visible = True
        Else

            PanelSiAceptaPreg.Visible = False
            PanelNoAceptaPreg.Visible = True
            RadGrid1.Visible = False
        End If
    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        CargarCausasCancela()
        CargarMotivoNoEfec()
        BuscaDatosContacto()

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            RadDatePicker1.SelectedDate = Now()
            RadDatePicker1.MinDate = Now()
            RadDatePicker2.MinDate = Now()
            'RadTimePicker1.MinDate = Now() 'DateAdd(DateInterval.Hour, -12, Now())
            'RadTimePicker1.
            'RadTimePicker1.MinDate = Now() 'DateAdd(DateInterval.Hour, -12, Now())

            Dim sGestion As String = Session("NumGestionSeguimiento").Trim
            Dim p_estado As String = Mid(sGestion, 9, 2)
            Dim p_tipo As String = Mid(sGestion, 7, 2)
            Session("tipo") = p_tipo
            cargaDistribuidor(p_estado)

            lblFecha0.Visible = False
            lblHorario0.Visible = False

            RadDatePicker2.Visible = False
            RadTimePicker2.Visible = False
            btnProxLlamada.Visible = False


            If RdoClienteAcepta.SelectedValue = 1 Then

                If p_tipo = 12 Then
                    PanelFallecimiento.Visible = True
                    PanelNoefectivo.Visible = False
                    PanelEfectivo.Visible = False
                    divs.Visible = True
                Else
                    PanelNoefectivo.Visible = False
                    PanelEfectivo.Visible = True
                    PanelFallecimiento.Visible = False
                    divs.Visible = True
                End If


                If RdoClienteAcepta.SelectedValue = 1 Then

                    PanelSiAceptaPreg.Visible = True
                    PanelNoAceptaPreg.Visible = False

                Else

                    PanelSiAceptaPreg.Visible = False
                    PanelNoAceptaPreg.Visible = True

                End If
                'ElseIf p_tipo = 12 Then
                '    PanelFallecimiento.Visible = True
                '    PanelEfectivo.Visible = False
                'ElseIf p_tipo <> 12 Then

                '    PanelEfectivo.Visible = True
                '    PanelFallecimiento.Visible = False
            Else

                PanelNoefectivo.Visible = True
                PanelEfectivo.Visible = False
                PanelFallecimiento.Visible = False
            End If

        End If
    End Sub

    Public Sub CargarCausasCancela()
        Dim comando As String = "exec Cancela_Motivo_sp"
        csSQLsvr.LlenarRadCombo(cboMotivoCanSer, comando, Session("connGestion"))
    End Sub
    Public Sub CargarMotivoNoEfec()
        Dim comando As String = "select * from CatCausasRechazoNOefectivas"
        csSQLsvr.LlenarRadCombo(cboMotivoNoefectivo, comando, Session("connGestion"))
    End Sub

    Public Sub BuscaDatosContacto()
        Dim sGestion As String = Session("NumGestionSeguimiento").Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Dim comando As String = "EXEC Select_datosAseg " & p_Anio & ", " & p_Cliente & ", " & p_tipo & ", " & p_estado & ", " & p_consec

        Dim DS As New DataSet
        Dim Usua As String

        DS = csSQLsvr.QueryDataSet(comando, Session("connGestion"))

        Dim dr As DataRow
        For Each dr In DS.Tables(0).Rows
            TxtMail.Text = dr("Reporte_MailAseg")
            'NombreAseg.Text = dr("Reporte_NombreAseg") & " " & dr("Reporte_ApaternoAseg")
            Contrato.Text = dr("cliente_NomCliente")
            NombreAsegI.Text = dr("Reporte_NombreAseg") & " " & dr("Reporte_ApaternoAseg")
            Label5.Text = dr("Reporte_NombreAseg") & " " & dr("Reporte_ApaternoAseg")
            Label14.Text = dr("Reporte_NombreAseg") & " " & dr("Reporte_ApaternoAseg")
            Label6.Text = dr("cliente_NomCliente")
            Usua = dr("Reporte_NombreAseg") & " " & dr("Reporte_ApaternoAseg")
        Next
        Session("usua") = Usua
    End Sub
    Public Sub cargaDistribuidor(ByVal clvEstado As Integer)
        Dim comando As String = "exec Select_cbo_distribuidor " & clvEstado
        csSQLsvr.LlenarRadCombo(cboDistribuidor, comando, Session("connGestion"))
    End Sub
    'Public Sub cargaEstados(ByVal region As String)
    '    Dim comando As String
    '    If region <> "" Then
    '        comando = "exec Select_estados_sp @id_regional = " & region
    '    Else
    '        comando = "exec Select_estados_sp"
    '    End If
    '    csSQLsvr.LlenarRadCombo(cboEstado, comando, Session("connGestion"))

    'End Sub

    Protected Sub RadioButtonList2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdoUsuario.SelectedIndexChanged

        If rdoUsuario.SelectedValue = 1 Then
            If Session("tipo") = 12 Then
                PanelFallecimiento.Visible = True
                PanelEfectivo.Visible = False
                PanelSiAceptaPreg.Visible = True
                RadGrid1.Visible = True
                PanelNoefectivo.Visible = False
                divs.Visible = True
            Else
                PanelNoefectivo.Visible = False
                PanelEfectivo.Visible = True
                PanelSiAceptaPreg.Visible = True
                RadGrid1.Visible = True
                PanelFallecimiento.Visible = False
                divs.Visible = True
            End If


        Else

            PanelNoefectivo.Visible = True
            PanelEfectivo.Visible = False
            PanelSiAceptaPreg.Visible = False
            RadGrid1.Visible = False
            PanelFallecimiento.Visible = False
            divs.Visible = False
        End If
    End Sub
    Public Function GuardarResultadosLlamada(ByVal servicio As String, ByVal resultado As Integer, ByVal causaRechazo As Integer, ByVal usuario As String) As Integer
        ' descomponemos el numero de gestion
        GuardarResultadosLlamada = 0
        Dim sGestion As String = servicio.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Dim CatTipoLlamada As Integer = 1 ' llamada al cliente de acuerdo al catalogo de   CatTiposLlamadas_Gestoria su valor es 1, gestor seria 2
        Dim CatResLlamadas_ClvResultado As Integer = resultado ' si llamada fue efectiva el valor es 1, no efectiva 2
        Dim Etapa_clvEtapa As Integer = 1 ' de acuerdo al catalogo de   EtapasServicioGestoria_tbl como es 1° contacto cliente=1, si fuera al gestor 1° contacto gestor=2
        Dim ResLlamadas_FechaAlta As String = "getdate()"
        Dim dsResul As Integer
        dsResul = cbGes.Insert_ResultadoLlamadasGestoria_tbl(p_Anio, p_Cliente, p_tipo, p_estado, p_consec, CatTipoLlamada, CatResLlamadas_ClvResultado, Etapa_clvEtapa, causaRechazo, ResLlamadas_FechaAlta, usuario)
        If dsResul > 0 Then
            GuardarResultadosLlamada = 1 ' Resultado 1 la insersion fue efectiva, cero fue no efectiva
        End If

    End Function

    Public Function GuardarCita(ByVal servicio As String, ByVal resultado As Integer, ByVal usuario As String) As Integer
        ' descomponemos el numero de gestion
        GuardarCita = 0
        Dim sGestion As String = servicio.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Dim subject As String = txtLugar.Text
        '"Lugar de la cita: " & txtLugar.Text
        Dim Fecha As String = (RadDatePicker1.SelectedDate).ToString
        Dim HoraCita As String = (RadTimePicker1.SelectedTime).ToString
        Fecha = Fecha.Substring(0, 10)
        Dim FechaCita As DateTime = CDate(Fecha & " " & HoraCita)
        Dim description As String = ""


        Dim dsResul As Integer
        dsResul = cbGes.Insert_Cita(p_Anio, p_Cliente, p_tipo, p_estado, p_consec, subject, CDate(FechaCita), description, TxtMail.Text)
        If dsResul > 0 Then

            GuardarCita = 1 ' Resultado 1 la insersion fue efectiva, cero fue no efectiva
            If chkEnvio.Checked Then
                cbGes.Insert_EnvioEmailGestoria(p_Anio, p_Cliente, p_tipo, p_estado, p_consec, TxtMail.Text.Trim, 1)
            End If

        End If

    End Function
    Public Function GuardarCitaDist(ByVal servicio As String, ByVal resultado As Integer, ByVal usuario As String) As Integer
        ' descomponemos el numero de gestion
        GuardarCitaDist = 0
        Dim sGestion As String = servicio.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Dim subject As String = "Lugar de la cita: " & cboDistribuidor.Text
        Dim Fecha As String = (RadDatePicker1.SelectedDate).ToString
        Dim HoraCita As String = (RadTimePicker1.SelectedTime).ToString
        Fecha = Fecha.Substring(0, 10)
        Dim FechaCita As DateTime = CDate(Fecha & " " & HoraCita)
        Dim description As String = ""


        Dim dsResul As Integer
        dsResul = cbGes.Insert_Cita(p_Anio, p_Cliente, p_tipo, p_estado, p_consec, subject, CDate(FechaCita), description, TxtMail.Text)
        If dsResul > 0 Then

            GuardarCitaDist = 1 ' Resultado 1 la insersion fue efectiva, cero fue no efectiva
            If chkEnvio.Checked Then
                cbGes.Insert_EnvioEmailGestoria(p_Anio, p_Cliente, p_tipo, p_estado, p_consec, TxtMail.Text.Trim, 1)
            End If

        End If

    End Function

    Private Function buscarGestor(ByVal noservicio As String) As String
        buscarGestor = String.Empty
        Try

            Dim sGestion As String = noservicio.Trim
            Dim nLargo As Integer = Len(sGestion)
            Dim p_Anio As String = Mid(sGestion, 1, 4)
            Dim p_Cliente As String = Mid(sGestion, 5, 2)
            Dim p_tipo As String = Mid(sGestion, 7, 2)
            Dim p_estado As String = Mid(sGestion, 9, 2)
            Dim p_consec As String = Mid(sGestion, 11, nLargo)
            Dim comando As String = "exec sp_Selectgestor " & p_Anio & "," & p_Cliente & "," & p_tipo & "," & p_estado & "," & p_consec
            Dim ds As DataSet = New DataSet
            ds = csSQLsvr.QueryDataSet(comando, Session("connGestion"))
            Dim dr As DataRow
            For Each dr In ds.Tables(0).Rows
                buscarGestor = dr("nombre").ToString.Trim & " " & dr("paterno").ToString.Trim
            Next
            Return buscarGestor
        Catch ex As Exception
            ConfigureNotification("Error: al buscar los datos del gestor asigando. " & ex.Message)
        End Try
    End Function


    Public Function RechazaServicio(ByVal servicio As String, ByVal resultado As Integer, ByVal usuario As String) As Integer
        ' descomponemos el numero de gestion
        RechazaServicio = 0
        Dim sGestion As String = servicio.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Dim CausaCancelacion As String = cboMotivoCanSer.SelectedValue
        Dim Etapa_clvEtapa As Integer = 1 ' de acuerdo al catalogo de   EtapasServicioGestoria_tbl como es 1° contacto cliente=1, si fuera al gestor 1° contacto gestor=2

        Dim dsResul As Integer
        dsResul = cbGes.Cancela_Servicio(p_Anio, p_Cliente, p_tipo, p_estado, p_consec, CausaCancelacion, usuario)

        If dsResul > 0 Then
            RechazaServicio = 1 ' Resultado 1 la insersion fue efectiva, cero fue no efectiva
        End If

    End Function

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If rdoUsuario.SelectedItem.Value = 2 Then ' si tenemos como no efectiva debe de haber una causa de no efectiva

            If cboMotivoNoefectivo.SelectedItem.Value <> 0 Then
                Dim resultado As Integer = GuardarResultadosLlamada(Session("NumGestionSeguimiento").Trim, rdoUsuario.SelectedValue, cboMotivoNoefectivo.SelectedItem.Value, Session("clvUsuario"))
                lblAccionNoefectiva.Text = buscarSigAccionNoEfectiva(cboMotivoNoefectivo.SelectedValue)
                siguienteAccion(Session("NumGestionSeguimiento").Trim, 1, 1, lblAccionNoefectiva.Text.Trim, Session("clvUsuario"))
                csDAL.Insert_BitacoraCambios(Session("NumGestionSeguimiento").Trim, "Control de Asignacion:Contacto a Usuario:" & " " & Session("usua") & ",llamada No Posible," & cboMotivoNoefectivo.Text & "," & lblAccionNoefectiva.Text.Trim, Session("clvUsuario"))

                ConfigureNotification("Llamada no efectiva guardada con exito")
                RegistraScript()
            Else
                ConfigureNotification("Seleccionar causa no efectiva")
            End If

        Else

            Dim resultado As Integer = GuardarResultadosLlamada(Session("NumGestionSeguimiento").Trim, rdoUsuario.SelectedValue, 0, Session("clvUsuario"))
            If resultado >= 1 Then

                If RdoClienteAcepta.SelectedValue = 1 Then
                    If txtLugar.Text IsNot Nothing And RadDatePicker1.SelectedDate IsNot Nothing And RadTimePicker1.SelectedTime IsNot Nothing Then
                        resultado = GuardarCita(Session("NumGestionSeguimiento").Trim, 0, Session("clvUsuario"))

                        If resultado >= 1 Then
                            siguienteAccion(Session("NumGestionSeguimiento").Trim, 1, 1, "Pendiente de Contactar al Gestor".Trim & " el " & Now().ToString("dd/MM/yyyy") & " a las " & Now().ToString("hh:mm"), Session("clvUsuario"))
                            csDAL.Insert_BitacoraCambios(Session("NumGestionSeguimiento").Trim, "Control de Asignacion: Usuario:" & " " & Session("usua") & ",Acepta Servicio:llamada Efectiva, informacion del lugar de la cita en:" & txtLugar.Text & ", entrega de documentos." & "Pendiente de Contactar al Gestor".Trim & " el " & Now().ToString("dd/MM/yyyy") & " a las " & Now().ToString("hh:mm"), Session("clvUsuario"))

                            ConfigureNotification("Cita guardada con exito")

                            ' Proceso para SMS ''Insertamos en tabla EnvioMailSMS_tbl la etapa 3 (Etapa de Avisio de Cita)
                            csDAL.InsertEnvioSms(Session("NumGestionSeguimiento").Trim, 3)

                            btnGuardar.Enabled = False
                            RegistraScript()
                        Else
                            ConfigureNotification("Se genero un error al grabar la cita")
                        End If
                        'ElseIf txtLugar.Text = Nothing And RadDatePicker1.SelectedDate IsNot Nothing And RadTimePicker1.SelectedTime IsNot Nothing Then
                        '    resultado = GuardarCitaDist(Session("NumGestionSeguimiento").Trim, 0, Session("clvUsuario"))
                        '    If resultado >= 1 Then
                        '        siguienteAccion(Session("NumGestionSeguimiento").Trim, 1, 1, "Siguiente accion: Contactar al Gestor".Trim, Session("clvUsuario"))
                        '        ConfigureNotification("Cita guardada con exito")
                        '        btnGuardar.Enabled = False
                        '        RegistraScript()
                        '    Else
                        '        ConfigureNotification("Se genero un error al grabar la cita")
                        '    End If
                    Else

                        ConfigureNotification("Debe llenar todos los campos (Lugar, Fecha y hora de cita)")
                    End If

                Else
                    If cboMotivoCanSer.SelectedValue <> 0 Then

                        resultado = RechazaServicio(Session("NumGestionSeguimiento").Trim, 0, Session("clvUsuario"))

                        If resultado >= 1 Then
                            siguienteAccion(Session("NumGestionSeguimiento").Trim, 1, 1, lblAccionCancelaServ.Text.Trim, Session("clvUsuario"))
                            csDAL.Insert_BitacoraCambios(Session("NumGestionSeguimiento").Trim, "Control de Asignacion: Contacto a Usuario: " & Session("usua") & " No acepta Servicio, " & lblAccionCancelaServ.Text.Trim, Session("clvUsuario"))
                            ConfigureNotification("Motivo de Cancelacion de Servicio Guardado con exito")
                            RegistraScript()
                        Else
                            ConfigureNotification("Se genero un error al grabar la cancelacion del servicio")
                            RegistraScript()
                        End If


                    Else
                        ConfigureNotification("Debe de seleccionar un motivo de cancelacion")
                    End If
                End If
            End If

        End If



    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Dim sGestion As String = Session("NumGestionSeguimiento")
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)

        Dim ds As New DataSet
        Dim dt As New DataTable

        ds = csDAL.CargaDocumentos(p_tipo, p_Cliente)
        dt = ds.Tables(0)

        If dt.Rows.Count <> 0 Then

            RadGrid1.CurrentPageIndex = 0
            RadGrid1.DataSource = dt
            RadGrid1.DataBind()
            RadGrid1.Dispose()
            RadGrid1.Visible = True

            ds.Clear()

        Else

            ''Mensage de que no se tienen valores a mostrar
            RadGrid1.Rebind()
            ds.Tables.Clear()
            RadGrid1.Visible = False
        End If
    End Sub

    Protected Sub ConfigureNotification(ByVal texto As String)
        'String
        'lblError0.Text = texto
        RadNotification.Title = "Atención"
        RadNotification.Text = texto
        'Enum
        RadNotification.Position = Telerik.Web.UI.NotificationPosition.Center
        RadNotification.Animation = Telerik.Web.UI.NotificationAnimation.Fade
        'notificacion.ContentScrolling = Telerik.Web.UI.NotificationScrolling.Default
        RadNotification.AutoCloseDelay = 50000
        'Unit
        RadNotification.Width = 300
        RadNotification.Height = 150
        RadNotification.OffsetX = -10
        RadNotification.OffsetY = 10

        RadNotification.Pinned = False
        RadNotification.EnableRoundedCorners = True
        RadNotification.EnableShadow = True
        RadNotification.KeepOnMouseOver = False
        RadNotification.VisibleTitlebar = True
        RadNotification.ShowCloseButton = True
        RadNotification.Show()

    End Sub

    Private Function buscarSigAccionNoEfectiva(ByVal clvNoEfectiva As Integer) As String
        Try
            buscarSigAccionNoEfectiva = String.Empty
            Dim ds As DataSet = New DataSet
            Dim comando As String = "select catRechazo_SigAccion,tiempo FROM CatCausasRechazoNOefectivas where catRechazo_clvRechazo=" & clvNoEfectiva

            ds = csSQLsvr.QueryDataSet(comando, Session("connGestion"))
            Dim dr As DataRow
            For Each dr In ds.Tables(0).Rows
                'buscarSigAccionNoEfectiva = dr("catRechazo_SigAccion") & "  Intentar: " & dr("tiempo")
                buscarSigAccionNoEfectiva = Replace(Replace(Replace(Replace(dr("catRechazo_SigAccion"), "{0}:", ""), "{1}", "Contacto Usuario"), "{2}", "Llamada No Efectiva"), "{3}", cboMotivoNoefectivo.SelectedItem.Text) & Replace(Replace(" " & dr("tiempo"), "{0}", Now().ToString("dd-MM-yyyy")), "{1}", DateAdd(DateInterval.Minute, 10, (Now())).ToString("HH:mm"))
            Next

        Catch ex As Exception

        End Try

    End Function

    Private Function buscarSigAccionCancela(ByVal clvCancelacion As Integer) As String
        Try
            buscarSigAccionCancela = String.Empty
            Dim ds As DataSet = New DataSet
            Dim comando As String = "select catRechazo_SigAccion,tiempo FROM CancelacionGestoriaEtapas_Tipos where clave_cancela = " & clvCancelacion


            ds = csSQLsvr.QueryDataSet(comando, Session("connGestion"))
            Dim dr As DataRow
            For Each dr In ds.Tables(0).Rows

                buscarSigAccionCancela = dr("catRechazo_SigAccion") & "  el " & Now().ToString("dd-MM-yyyy") & " a las " & Now().ToString("HH:mm")

            Next


        Catch ex As Exception

        End Try

    End Function

    Private Sub siguienteAccion(ByVal nogestion As String, ByVal RegistroAccion_Etapa As String, ByVal RegistroAccion_TipoPersona As String, ByVal RegistroAccion_AccionSiguiente As String, ByVal RegistroAccion_usuario As String)
        Try
            Dim sGestion As String = nogestion.Trim
            Dim nLargo As Integer = Len(sGestion)
            Dim p_Anio As String = Mid(sGestion, 1, 4)
            Dim p_Cliente As String = Mid(sGestion, 5, 2)
            Dim p_tipo As String = Mid(sGestion, 7, 2)
            Dim p_estado As String = Mid(sGestion, 9, 2)
            Dim p_consec As String = Mid(sGestion, 11, nLargo)
            cbGes.Insert_ProximaAccion(p_Anio, p_Cliente, p_tipo, p_estado, p_consec, RegistroAccion_Etapa, RegistroAccion_TipoPersona, RegistroAccion_AccionSiguiente, RegistroAccion_usuario)
        Catch ex As Exception

        End Try
    End Sub



    Protected Sub cboMotivoNoefectivo_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cboMotivoNoefectivo.SelectedIndexChanged
        lblAccionNoefectiva.Text = buscarSigAccionNoEfectiva(cboMotivoNoefectivo.SelectedValue)
    End Sub

    Protected Sub cboMotivoCanSer_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cboMotivoCanSer.SelectedIndexChanged
        lblAccionCancelaServ.Text = buscarSigAccionCancela(cboMotivoCanSer.SelectedValue)
    End Sub
    Protected Sub RdoClienteNextLlamada_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles RdoClienteNextLlamada.SelectedIndexChanged
        If RdoClienteNextLlamada.SelectedValue = 1 Then
            lblFecha0.Visible = True
            lblHorario0.Visible = True
            RadDatePicker2.Visible = True
            RadTimePicker2.Visible = True
            btnProxLlamada.Visible = True

        End If

    End Sub

    Protected Sub btnProxLlamada_Click(sender As Object, e As System.EventArgs) Handles btnProxLlamada.Click
        If RadDatePicker2.SelectedDate IsNot Nothing And RadTimePicker2.SelectedTime IsNot Nothing Then
            siguienteAccion(Session("NumGestionSeguimiento").Trim, 1, 1, "Contactar nuevamente el dia " + RadDatePicker2.SelectedDate + " a las " + RadTimePicker2.SelectedTime.ToString, Session("clvUsuario"))
            csDAL.Insert_BitacoraCambios(Session("NumGestionSeguimiento").Trim, "Control de Asignacion:Contacto a Usuario:" & " " & Session("usua") & ",llamada No Posible" & "Contactar nuevamente el dia " + RadDatePicker2.SelectedDate + " a las " + RadTimePicker2.SelectedTime.ToString, Session("clvUsuario"))
            ConfigureNotification("Se agendo Nueva llamada con exito")
            btnGuardar.Enabled = False
            RegistraScript()
        Else
            ConfigureNotification("Debes llenar los campos de fecha y hora")
        End If
    End Sub


    Protected Sub cboDistribuidor_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cboDistribuidor.SelectedIndexChanged
        If cboDistribuidor.SelectedValue <> "" Then
            Dim dsDis As New DataSet
            Dim dr As DataRow

            dsDis = csDAL.CargaDirCita(cboDistribuidor.SelectedValue)
            If dsDis.Tables(0).Rows.Count <> 0 Then
                For Each dr In dsDis.Tables(0).Rows
                    txtLugar.Text = dr("Direccion").ToString.Trim
                Next

            End If
        End If

    End Sub

    'Protected Sub RadTimePicker1_SelectedDateChanged(sender As Object, e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadTimePicker1.SelectedDateChanged


    '    If RadDatePicker1.MinDate = Format(Now(), "MM") Then RadTimePicker1.MinDate = Now()
    'End Sub

    'Protected Sub RadTimePicker2_SelectedDateChanged(sender As Object, e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadTimePicker2.SelectedDateChanged
    '    If RadDatePicker2.MinDate = Now() Then RadTimePicker2.MinDate = Now()
    'End Sub
End Class

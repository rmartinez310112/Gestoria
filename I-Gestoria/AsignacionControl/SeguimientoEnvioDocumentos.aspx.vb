Imports System.Data
Partial Class FrontOffice_SeguimientoEnvioDocumentos
    Inherits System.Web.UI.Page
    Dim csNeg As New ClaseNegocios
    Dim csSQLsvr As New BaseDatosSQL
    Dim csDAL As New DALClass
    Dim cbGes As New ClaseBaseGestoria

#Region "Procesos"

    ' ReportesGestionTotalSeguimiento_vw DiasTramite


    Private Function buscarFechaLimiteTramite(ByVal nogestion As String) As String
        Try
            buscarFechaLimiteTramite = String.Empty
            Dim ds As DataSet = New DataSet
            Dim comando As String = "select DiasTramite FROM ReportesGestionTotalSeguimiento_vw where NoGestion=" & nogestion
            ds = csSQLsvr.QueryDataSet(comando, Session("connGestion"))
            Dim dr As DataRow
            For Each dr In ds.Tables(0).Rows
                buscarFechaLimiteTramite = Format(dr("DiasTramite"), "dd/MM/yyyy")
            Next

        Catch ex As Exception

        End Try

    End Function



    Private Function buscarSigAccionNoEfectiva(ByVal clvNoEfectiva As Integer) As String
        Try
            buscarSigAccionNoEfectiva = String.Empty
            Dim ds As DataSet = New DataSet
            Dim comando As String = "select catRechazo_SigAccion,tiempo FROM CatCausasRechazoNOefectivas where catRechazo_clvRechazo=" & clvNoEfectiva

            ds = csSQLsvr.QueryDataSet(comando, Session("connGestion"))
            Dim dr As DataRow
            For Each dr In ds.tables(0).rows
                'buscarSigAccionNoEfectiva = dr("catRechazo_SigAccion") & "Intentar: el " & Now().ToString("dd-MM-yyyy") & "a las " & Now().ToString("HH:mm")
                buscarSigAccionNoEfectiva = Replace(Replace(Replace(Replace(dr("catRechazo_SigAccion"), "{0}", ""), "{1}", ""), "{2}", "Llamada No Efectiva"), "{3}", cboCausasConclusion.SelectedItem.Text) & Replace(Replace(" " & dr("tiempo"), "{0}", Now().ToString("dd-MM-yyyy")), "{1}", DateAdd(DateInterval.Minute, 10, (Now())).ToString("HH:mm"))
            Next
        Catch ex As Exception

        End Try

    End Function


     Private Function buscarSigAccionNoEntregaDoc(ByVal clvNoEfectiva As Integer) As String
        Try
            buscarSigAccionNoEntregaDoc = String.Empty
            Dim ds As DataSet = New DataSet
            Dim comando As String = "SELECT     catRechazo_SigAccion, tiempo FROM   catCausaConclusionGestorSegui where catCausaConclusionGestor=" & clvNoEfectiva

            ds = csSQLsvr.QueryDataSet(comando, Session("connGestion"))
            Dim dr As DataRow
            For Each dr In ds.Tables(0).Rows
                If clvNoEfectiva = 101 Then
                    '    buscarSigAccionNoEntregaDoc = Replace(Replace(Replace(dr("catRechazo_SigAccion"), "{0}", "Seguimiento a Tramite"), "{1}", "Contacto Gestor"), "{2}", cboCausasConclusion.SelectedItem.Text) & Replace(Replace(" " & dr("tiempo"), "{0}", Now().ToString("dd-MM-yyyy")), "{1}", Now().ToString("HH:mm"))
                    buscarSigAccionNoEntregaDoc = Replace(Replace(Replace(dr("catRechazo_SigAccion"), "{0} :", ""), "{1} :", ""), "{2}", cboCausasConclusion.SelectedItem.Text) & Replace(Replace(" " & dr("tiempo"), "{0}", (fechaSegEnvio.SelectedDate.Value).ToString("dd-MM-yyyy")), "{1}", fechaSegEnvio.SelectedDate.Value.ToString("HH:mm"))
                Else
                    buscarSigAccionNoEntregaDoc = Replace(Replace(Replace(dr("catRechazo_SigAccion"), "{0} :", ""), "{1} :", ""), "{2}", cboCausasConclusion.SelectedItem.Text) & Now().ToString("dd-MM-yyyy") & " a las " & Now().ToString("HH:mm")
                End If
                'buscarSigAccionNoEntregaDoc = dr("catRechazo_SigAccion") & "Intentar: el " & Now().ToString("dd-MM-yyyy") & "a las " & Now().ToString("HH:mm")
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

    Private Function Insert_SeguimientosTramiteGestor_tbl(ByVal nogestion As String, ByVal SegTramite_StatusTamite As Integer, ByVal SegTramite_respTramite As String, ByVal SegTramite_FechaProxLlamada As String) As Integer
        Insert_SeguimientosTramiteGestor_tbl = 0
        Try
            Dim sGestion As String = nogestion.Trim
            Dim nLargo As Integer = Len(sGestion)
            Dim p_Anio As String = Mid(sGestion, 1, 4)
            Dim p_Cliente As String = Mid(sGestion, 5, 2)
            Dim p_tipo As String = Mid(sGestion, 7, 2)
            Dim p_estado As String = Mid(sGestion, 9, 2)
            Dim p_consec As String = Mid(sGestion, 11, nLargo)
            Insert_SeguimientosTramiteGestor_tbl = cbGes.Insert_SeguimientosTramiteGestor_tbl(p_Anio, p_Cliente, p_tipo, p_estado, p_consec, SegTramite_StatusTamite, SegTramite_respTramite, SegTramite_FechaProxLlamada)

        Catch ex As Exception
            ConfigureNotification("Error al guardar la información" & ex.Message)
        End Try

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


    Private Function buscarAsegurado(ByVal noservicio As String) As String
        buscarAsegurado = String.Empty
        Try

            Dim sGestion As String = noservicio.Trim
            Dim nLargo As Integer = Len(sGestion)
            Dim p_Anio As String = Mid(sGestion, 1, 4)
            Dim p_Cliente As String = Mid(sGestion, 5, 2)
            Dim p_tipo As String = Mid(sGestion, 7, 2)
            Dim p_estado As String = Mid(sGestion, 9, 2)
            Dim p_consec As String = Mid(sGestion, 11, nLargo)
            Dim comando As String = "exec Select_datosAseg " & p_Anio & "," & p_Cliente & "," & p_tipo & "," & p_estado & "," & p_consec
            Dim ds As DataSet = New DataSet
            ds = csSQLsvr.QueryDataSet(comando, Session("connGestion"))
            Dim dr As DataRow
            For Each dr In ds.Tables(0).Rows
                buscarAsegurado = dr("reporte_nombreaseg").ToString.Trim & " " & dr("reporte_apaternoAseg").ToString.Trim & " Tipo de servicio:" & dr("servicio_nomServicio").ToString.Trim
            Next
            Return buscarAsegurado
        Catch ex As Exception
            ConfigureNotification("Error: al buscar los datos del asegurado. " & ex.Message)
        End Try
    End Function

    Public Sub guardar_Recepcion(ByVal noServicio As String)
        Try
            Dim sGestion As String = noServicio.Trim
            Dim nLargo As Integer = Len(sGestion)
            Dim p_Anio As String = Mid(sGestion, 1, 4)
            Dim p_Cliente As String = Mid(sGestion, 5, 2)
            Dim p_tipo As String = Mid(sGestion, 7, 2)
            Dim p_estado As String = Mid(sGestion, 9, 2)
            Dim p_consec As String = Mid(sGestion, 11, nLargo)

            Dim fechaRecepcion As String = Format(fechaSegEnvio.SelectedDate, "yyyyMMdd")
            Dim comentarios As String = txtComentarios.Text.Trim.ToUpper
            Dim guia As String = txtGuia.Text.Trim.ToUpper
            Dim TipoEntrega As String = rblTipoEntrega.SelectedItem.Value
            cbGes.Insert_EntregaExpedientesGestoria(p_Anio, p_Cliente, p_tipo, p_estado, p_consec, comentarios, Session("clvUsuario"), fechaRecepcion, "0", "01/01/1900", TipoEntrega, guia)
            ConfigureNotification("La información se guardo correctamente")
            cmdGuardar.Enabled = False
        Catch ex As Exception
            ConfigureNotification("Error: al guardar información " & ex.Message)
        End Try

    End Sub
    Public Sub CargarMotivoNoEfec()
        Dim comando As String = "select * from CatCausasRechazoNOefectivas"
        csSQLsvr.LlenarRadCombo(cboMotivoNoefectivo, comando, Session("connGestion"))
    End Sub

    Public Sub CargarCausasGestor()
        Dim comando As String = "select * from catCausaConclusionGestorSegui where catCausaConclusionGestor <> 100 order by catCausaConclusionGestor"
        csSQLsvr.LlenarRadCombo(cboCausasConclusion, comando, Session("connGestion"))
    End Sub

    Public Sub CargarCiaPaqueteria()
        Dim comando As String = "select * from mensajeriaCompañias_tbl order by mensajeria_id "
        csSQLsvr.LlenarRadCombo(cbomensajeria, comando, Session("connGestion"))
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
        Dim CatTipoLlamada As Integer = 2 ' llamada al cliente de acuerdo al catalogo de   CatTiposLlamadas_Gestoria su valor es 1, gestor seria 2
        Dim CatResLlamadas_ClvResultado As Integer = resultado ' si llamada fue efectiva el valor es 1, no efectiva 2
        Dim Etapa_clvEtapa As Integer = 2 ' de acuerdo al catalogo de   EtapasServicioGestoria_tbl como es 1° contacto cliente=1, si fuera al gestor 1° contacto gestor=2
        Dim ResLlamadas_FechaAlta As String = "getdate()"
        Dim dsResul As Integer
        dsResul = cbGes.Insert_ResultadoLlamadasGestoria_tbl(p_Anio, p_Cliente, p_tipo, p_estado, p_consec, CatTipoLlamada, CatResLlamadas_ClvResultado, Etapa_clvEtapa, causaRechazo, ResLlamadas_FechaAlta, usuario)
        If dsResul > 0 Then
            GuardarResultadosLlamada = 1 ' Resultado 1 la insersion fue efectiva, cero fue no efectiva
        End If

    End Function
#End Region

    Protected Sub RadioButtonList1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        If RadioButtonList1.SelectedValue = 1 Then
            PanelEfectiva.Visible = True
            PanelNOEfectiva.Visible = False
            cmdGuardar.Enabled = True
        Else
            PanelEfectiva.Visible = False
            PanelNOEfectiva.Visible = True
            cmdGuardar.Enabled = True
        End If
    End Sub

    Protected Sub RadioButtonList2_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles RadioButtonList2.SelectedIndexChanged
        If RadioButtonList2.SelectedValue = 1 Then
            PanelPendiente.Visible = False
            PanelConcluido.Visible = True
        Else
            PanelPendiente.Visible = True
            PanelConcluido.Visible = False
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Session("noGestionIntegral") = Session("Gestion")
            'Session("clvUsuario") = "CZL"
            fechaSegEnvio.MinDate = Now()
            fechaSeguiDoc.MinDate = Now()

            fechaSegEnvio.SelectedDate = DateAdd(DateInterval.Day, 1, Now())
            fechaSeguiDoc.SelectedDate = DateAdd(DateInterval.Day, 1, Now())
            CargarMotivoNoEfec()
            CargarCausasGestor()
            CargarCiaPaqueteria()
            lblNomAjustador.Text = buscarGestor(Session("noGestionIntegral"))
            lblDatosServicio.Text = buscarAsegurado(Session("noGestionIntegral"))
            lblDatosServicio0.Text = Session("noGestionIntegral")
            lblFechaMaxTramite.Text = buscarFechaLimiteTramite(Session("noGestionIntegral"))
        End If
    End Sub

    Private Sub RegistraScript()
        ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind();", True)
    End Sub


    Protected Sub cmdGuardar_Click(sender As Object, e As System.EventArgs) Handles cmdGuardar.Click
        Dim resultado As Integer = 0
        If RadioButtonList1.SelectedItem.Value = 2 Then ' si tenemos como no efectiva debe de haber una causa de no efectiva
            If cboMotivoNoefectivo.SelectedItem.Value <> Nothing Then
                If cboMotivoNoefectivo.SelectedItem.Value <> 1 Then

                    resultado = GuardarResultadosLlamada(Session("noGestionIntegral"), RadioButtonList1.SelectedValue, cboMotivoNoefectivo.SelectedItem.Value, Session("clvUsuario"))
                    Dim sigAccion As String = buscarSigAccionNoEfectiva(cboMotivoNoefectivo.SelectedItem.Value)
                    siguienteAccion(Session("noGestionIntegral"), 2, 2, sigAccion, Session("clvUsuario"))
                    csDAL.Insert_BitacoraGestionExpe(Session("noGestionIntegral"), "Seguimiento envio de documentos: Contancto Gestor: " & lblNomAjustador.Text.Trim & " , Llamada No Efectiva, " & sigAccion, Session("clvUsuario"))

                    ConfigureNotification("La información se guardo correctamente..")
                    RegistraScript()
                    cmdGuardar.Enabled = False
                    Exit Sub

                End If
            Else
                ConfigureNotification("Favor de seleccionar motivo de no envio..")
                Exit Sub
            End If
        End If

        If RadioButtonList1.SelectedItem.Value = 2 Then
            If cboMotivoNoefectivo.SelectedItem.Value <> Nothing Then
                If cboMotivoNoefectivo.SelectedItem.Value = 1 Then
                    ConfigureNotification("Es necesario que escoga por que la llamada fue no efectiva..")
                    ' mandar mensaje que no exite causa de no efectiva
                    Exit Sub
                End If
            Else
                ConfigureNotification("Es necesario que escoga motivo de no envio..")
                Exit Sub
            End If



        End If

        If RadioButtonList1.SelectedItem.Value = 1 Then ' si fue efectiva hacemos la insercion
            If RadioButtonList2.SelectedValue = 1 Then ' ya se enviaron los documentos
                If rblTipoEntrega.SelectedValue = 1 Then
                    If cbomensajeria.SelectedValue <> 0 Then
                        resultado = GuardarResultadosLlamada(Session("noGestionIntegral"), RadioButtonList1.SelectedValue, 0, Session("clvUsuario"))
                        guardar_Recepcion(Session("noGestionIntegral"))
                        siguienteAccion(Session("noGestionIntegral"), 2, 2, "Servicio pasa a Backoffice para seguimiento", Session("clvUsuario"))
                        csDAL.Insert_BitacoraGestionExpe(Session("noGestionIntegral"), "Seguimiento envio de documentos: Contancto Gestor: " & lblNomAjustador.Text.Trim & " , Llamada Efectiva, Documentos Enviados con el Numero de guia: " & txtGuia.Text.Trim & ", Entrega Local" & ", Compañia " & cbomensajeria.Text.Trim & " en la fecha " & fechaSegEnvio.SelectedDate, Session("clvUsuario"))

                        ConfigureNotification("La información se guardo correctamente..")
                        RegistraScript()
                        cmdGuardar.Enabled = False
                        Exit Sub
                    Else
                        ConfigureNotification("Debe seleccionar una compañia de mensajeria..")
                        Exit Sub
                    End If
                ElseIf rblTipoEntrega.SelectedValue = 2 Then
                    If cbomensajeria.SelectedValue <> 0 And txtGuia.Text <> "" Then
                        resultado = GuardarResultadosLlamada(Session("noGestionIntegral"), RadioButtonList1.SelectedValue, 0, Session("clvUsuario"))
                        guardar_Recepcion(Session("noGestionIntegral"))
                        siguienteAccion(Session("noGestionIntegral"), 2, 2, "Servicio pasa a Backoffice para seguimiento", Session("clvUsuario"))
                        csDAL.Insert_BitacoraGestionExpe(Session("noGestionIntegral"), "Seguimiento envio de documentos: Contancto Gestor: " & lblNomAjustador.Text.Trim & " , Llamada Efectiva, Documentos Enviados con el Numero de guia: " & txtGuia.Text.Trim & ", Entrega Foranea" & ", Compañia " & cbomensajeria.Text.Trim & " en la fecha " & fechaSegEnvio.SelectedDate, Session("clvUsuario"))

                        ConfigureNotification("La información se guardo correctamente..")
                        RegistraScript()
                        cmdGuardar.Enabled = False
                        Exit Sub
                    Else
                        ConfigureNotification("Debe seleccionar una compañia de mensajeria y/o numero de guia..")
                        Exit Sub
                    End If
                End If
            End If

            ' si la llamada fue efectiva y no se han enviado los documentos
            If RadioButtonList2.SelectedItem.Value = 2 Then
                Dim sigAccion As String = buscarSigAccionNoEntregaDoc(cboCausasConclusion.SelectedValue)
                siguienteAccion(Session("noGestionIntegral"), 2, 2, sigAccion, Session("clvUsuario"))
                csDAL.Insert_BitacoraGestionExpe(Session("noGestionIntegral"), "Seguimiento envio de documentos: Contancto Gestor: " & lblNomAjustador.Text.Trim & " , Llamada No Efectiva, " & sigAccion, Session("clvUsuario"))
                Dim SegTramite_StatusTamite As String = RadioButtonList2.SelectedItem.Value
                Dim SegTramite_respTramite As String = cboCausasConclusion.SelectedItem.Value
                Dim SegTramite_FechaProxLlamada As String = Format(fechaSegEnvio.SelectedDate, "MM/dd/yyy")
                If Insert_SeguimientosTramiteGestor_tbl(Session("noGestionIntegral"), SegTramite_StatusTamite, SegTramite_respTramite, SegTramite_FechaProxLlamada) <> 0 Then
                    ConfigureNotification("La información se guardo correctamente..")
                    RegistraScript()
                    cmdGuardar.Enabled = False
                Else
                    ConfigureNotification("Error al guardar la informacion, por favor verifique..")
                End If
            End If

        End If


    End Sub

    Protected Sub cboMotivoNoefectivo_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cboMotivoNoefectivo.SelectedIndexChanged

    End Sub
End Class

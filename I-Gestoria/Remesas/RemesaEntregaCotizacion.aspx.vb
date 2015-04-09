Imports System.Data

Partial Class RemesaEntregaCotizacion
    Inherits System.Web.UI.Page
    Dim _Conn As String
    Dim _NumGestion As String
    Dim Win As Ventanas
    Dim csSQLsvr As New BaseDatosSQL
    Dim cbGes As New ClaseBaseGestoria
    Dim _nocita As Integer
    Dim _resultllamada As Boolean
    Dim csDAL As New DALClass

    ''' <summary>
    ''' Propiedad que almacena el numero de cita
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property NoCita As Integer
        Set(value As Integer)
            ViewState(_nocita) = value
        End Set
        Get
            Return ViewState(_nocita)
        End Get
    End Property
    ''' <summary>
    ''' Propiedad que almacena si la llamada entre el gestor y el cliente 
    ''' fue efectiva, ambos acudiran a la cita y la etapa actual es Seguimiento de cita 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ResultLlamada As Boolean
        Set(value As Boolean)
            ViewState(_resultllamada) = value
        End Set
        Get
            Return ViewState(_resultllamada)
        End Get
    End Property

    '''
    '''falta un manejo de sesiones
    '''

    Sub New()
        Me._Conn = ConfigurationManager.ConnectionStrings("ConnStringSQL").ToString()
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Win = New Ventanas(Page)
        _NumGestion = Session("Gestion")
        'OcultaPaneles()
        If Not IsPostBack Then
            RDPFechaRep.MinDate = Now()

            cargacomboContacto()
            cargacomboMotivoNE()
            cargacomboMotivoReprog()
            cargacomboMotivoGestor()
            cargaEtiquetas()
            EvaluaResultadoLlamada()
            'aqui verificar si es primera cita o segunda.

        End If
    End Sub
    Private Function VerificaNoLlamada(ByVal servicio As String) As Integer

        Dim sGestion As String = servicio.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)

        Dim RoomID As String = 1 'IIf(rdIdCliente.SelectedValue = "1", "1", "2")

        Dim _query As New StringBuilder

        _query.Append(" SELECT count(*) as cuenta FROM AppointmentsGestion WHERE   ")
        _query.Append(" Reporte_anio=  " + p_Anio + "     and                    ")
        _query.Append(" Reporte_cliente=   " + p_Cliente + " and                 ")
        _query.Append(" Reporte_Tipo = " + p_tipo + "           and              ")
        _query.Append(" Reporte_clvEstado=" + p_estado + "         and           ")
        _query.Append(" Reporte_Numero=  " + p_consec + "                        ")
        _query.Append(" AND RoomID= " + RoomID + "                               ")

        Return csSQLsvr.ExecuteEscalar(_query.ToString(), _Conn)

    End Function

    Private Function cargaEtiquetas()
        lblUsuarioRegistro.Text = Session("Usuario")
        lblAsistFechaReg.Text = System.DateTime.Now.ToShortDateString()
        lblAsistUsuarioRegistro.Text = Session("Usuario")


        'Llena para el panel PanelNoCancela
        lblFechaRPanelNoCancela.Text = System.DateTime.Now.ToShortDateString()
        lblUsuarioPanelNoCancela.Text = Session("Usuario")

    End Function
    Protected Sub Group1_CheckedChanged(sender As Object, e As System.EventArgs)
    End Sub

    Private Function cargacomboMotivoNE()
        General.LlenaRadCombo(rdIdMotivoNE, "SELECT catRechazo_clvRechazo,catRechazo_Descrip,catRechazo_SigAccion FROM CatCausasRechazoNoefectivas", _Conn)
    End Function
    Private Function cargacomboContacto()
        General.LlenaRadCombo(rdIdCliente, " SELECT CatTipoLlamada_cvLlamada,CatTipoLlamada_Descri FROM catTiposLlamadas_Gestoria", _Conn)
    End Function

    Private Function cargacomboMotivoReprog()
        General.LlenaRadCombo(cmbMotRep, "  select catReprog_cvl,catReprog_Desc,catReprog_SigAccion from CatCausasReprog order by catReprog_Desc asc", _Conn)
    End Function

    Private Function cargacomboMotivoGestor()
        General.LlenaRadCombo(cmbGestor, "   select CatClv_CausaRechazoG,CatRechazo_DescripG,catRechazo_SigAccion,tiempo from CatCausasRechazoGestor where CatClv_CausaRechazoG > 0", _Conn)
    End Function

    'efectiva o noEfectiva
    Protected Sub RadioButtonList1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        EvaluaOcultaPaneles()
        If (RadioButtonList1.SelectedValue <> "") Then
            If RadioButtonList1.SelectedValue = 1 Then
                PanelEfectiva.Visible = True
                PanelNoEfectiva.Visible = False
                Onselected(AsisteCita)
            Else
                lblFechaRegistro.Text = DateTime.Now.ToShortDateString()
                PanelEfectiva.Visible = False
                PanelNoEfectiva.Visible = True
            End If
        End If
    End Sub
    Private Function LlenaPanelEfectiva()
        Dim dtPanE As DataTable
        dtPanE = csSQLsvr.QueryDataDatable("select Start,Subject , Description from AppointmentsGestionUltimaCitaGestoria_vw where numServicio ='" + _NumGestion + "' ", _Conn)
        If (dtPanE.Rows.Count > 0) Then
            lbFechaCita.Text = dtPanE.Rows(0)("Start").ToString()
            lbLugarCita.Text = "-" & dtPanE.Rows(0)("Subject").ToString() & vbCrLf & "-" & dtPanE.Rows(0)("Description").ToString()
        Else
            lbFechaCita.Text = "No existen datos de la cita"
            lbFechaCita.ForeColor = Drawing.Color.Red
            lbLugarCita.Text = "No existen datos de la cita"
            lbLugarCita.ForeColor = Drawing.Color.Red
        End If
    End Function
    Private Function OcultaPaneles()
        Dim panelControl() As Panel = {PanelSiAsis, PanelNoCancela}
        For Each element In panelControl
            If (element.Visible = True) Then
                element.Visible = False
            End If
        Next
    End Function

    Private Function EvaluaOcultaPaneles() As Boolean
        Dim panelControl() As Panel = {PanelSiAsis, panelGestor, panelSiConcreta, panelGestorSiAsis, PanelNoCancela, PanelNoEfectiva, PanelEfectiva}
        'Dim bandera As Boolean = False
        For Each element In panelControl
            If (element.Visible = True) Then
                element.Visible = False
            End If
        Next
        'Return bandera
    End Function

    Private Function Onselected(ByVal x As RadioButtonList)
        Dim lisItem() As RadioButtonList = {x} ' {AsisteCita, RadioButtonList2}
        For Each elementItem In lisItem
            elementItem.ClearSelection()
        Next
    End Function

    Protected Function EvaluaResultadoLlamada() As Boolean
        ResultLlamada = csSQLsvr.ResultLlamada(_NumGestion, _Conn)
    End Function

    'RadioButtonList
    'Asistir a la cita
    Protected Sub AsisteCita_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles AsisteCita.SelectedIndexChanged
        OcultaPanelesInferiores()

        LimpiaValores()
        If (AsisteCita.SelectedValue <> "") Then
            If (AsisteCita.SelectedValue = 1 And rdIdCliente.SelectedValue = 1 And NoCita <= 1) Then 'si asiste y es cliente y es la PRIMER cita
                resetValores(rlCitaConcret)
                If (ResultLlamada = False) Then
                    PanelNoCancela.Visible = True
                    SeteaPanel(1) '1 = cliente , 2= gestor
                Else
                    panelGestorSiAsis.Visible = True
                    PanelNoCancela.Visible = False
                End If
            ElseIf (AsisteCita.SelectedValue = 1 And rdIdCliente.SelectedValue = 1 And NoCita > 1) Then 'si asiste y es cliente y es la SEGUNDA cita)
                'resetValores(AsisteCita)
                panelGestorSiAsis.Visible = True

            ElseIf (AsisteCita.SelectedValue = 1 And rdIdCliente.SelectedValue = 2 And NoCita <= 1) Then 'si asiste y es Gestor y es la PRIMER cita
                resetValores(rlCitaConcret)
                If (ResultLlamada = False) Then
                    PanelNoCancela.Visible = True
                    SeteaPanel(2)
                Else
                    panelGestorSiAsis.Visible = True
                    PanelNoCancela.Visible = False
                    btnESiAsis.Visible = True
                End If
            ElseIf (AsisteCita.SelectedValue = 1 And rdIdCliente.SelectedValue = 2 And NoCita > 1) Then 'si asiste y es Gestor y es la SEGUNDA cita
                PanelSiAsis.Visible = True
                lblSigAccNE.Text = "Seguimiento a, resultado de la cita. Contacto con Cliente. el " & Now().ToString("dd-MM-yyyy") & "a las " & Now().ToString("HH:mm")
                panelGestorSiAsis.Visible = True
                ReqCita.Visible = False
                'panelSiConcreta.Visible

            ElseIf (AsisteCita.SelectedValue = 2 And rdIdCliente.SelectedValue = 2) Then 'no asiste y es Gestor 
                panelGestor.Visible = True
            ElseIf (AsisteCita.SelectedValue = 2 And rdIdCliente.SelectedValue = 1) Then 'no asiste y es cliente 
                PanelNoCancela.Visible = True
                HabilitaPanel()
            End If
        End If
    End Sub
    Private Function HabilitaPanel()
        'cmbMotRep.SelectedValue = 0
        RDPFechaRep.SelectedDate = Nothing
        RadTimePicker1.SelectedDate = Nothing
        TbLugarCita.Text = ""
        cmbMotRep.SelectedValue = ""
        cmbMotRep.Enabled = True
        cmbMotRep_SelectedIndexChanged(Nothing, Nothing)
        'RDPFechaRep.SelectedDate = ""
    End Function
    Private Function SeteaPanel(ByVal tipo As Integer)
        Dim span As TimeSpan
        Select Case (tipo)
            Case Is = 1 'cliente
                cmbMotRep.Enabled = False
                cmbMotRep.SelectedValue = 8
                'cmbMotRep_SelectedIndexChanged
                cmbMotRep_SelectedIndexChanged(Nothing, Nothing)
                Dim dtPanE As DataTable
                dtPanE = csSQLsvr.QueryDataDatable("select Start,Subject , Description from AppointmentsGestionUltimaCitaGestoria_vw where numServicio ='" + _NumGestion + "' ", _Conn)
                If (dtPanE.Rows.Count > 0) Then
                    TbLugarCita.Text = dtPanE.Rows(0)("Subject").ToString() & vbCrLf & "-" & dtPanE.Rows(0)("Description").ToString()
                    RDPFechaRep.SelectedDate = dtPanE.Rows(0)("Start").ToString().Substring(0, 10)
                    RadTimePicker1.SelectedDate = Convert.ToDateTime(dtPanE.Rows(0)("Start").ToString().Substring(12, 4))
                Else
                    TbLugarCita.Text = "Sin Asignar."
                    RDPFechaRep.SelectedDate = System.DateTime.Now.ToShortDateString()
                    'RadTimePicker1.SelectedTime = Format(Now(), "MM/dd/yyyy")


                    RadTimePicker1.SelectedDate = Convert.ToDateTime(System.DateTime.Now.ToShortTimeString())
                End If

                TbLugarCita.Enabled = False
                RDPFechaRep.Enabled = False
                RadTimePicker1.Enabled = False
            Case Is = 2
                cmbMotRep.Enabled = False
                cmbMotRep.SelectedValue = 9
                cmbMotRep_SelectedIndexChanged(Nothing, Nothing)
                Dim dtPanE As DataTable
                dtPanE = csSQLsvr.QueryDataDatable("select Start,Subject , Description from AppointmentsGestionUltimaCitaGestoria_vw where numServicio ='" + _NumGestion + "' ", _Conn)
                If (dtPanE.Rows.Count > 0) Then
                    TbLugarCita.Text = dtPanE.Rows(0)("Subject").ToString() & vbCrLf & "-" & dtPanE.Rows(0)("Description").ToString()
                    RDPFechaRep.SelectedDate = dtPanE.Rows(0)("Start").ToString().Substring(0, 10)
                    RadTimePicker1.SelectedDate = Convert.ToDateTime(dtPanE.Rows(0)("Start").ToString().Substring(12, 4))
                Else
                    TbLugarCita.Text = "Sin Asignar."
                    RDPFechaRep.SelectedDate = System.DateTime.Now.ToShortDateString()
                    RadTimePicker1.SelectedDate = Convert.ToDateTime(System.DateTime.Now.ToShortTimeString())
                End If
        End Select



    End Function

    Private Function LimpiaValores()
        radtbIFE.Text = ""
        radtbAcuerdo.Text = ""
    End Function

    Private Function OcultaPanelesInferiores()
        panelGestorSiAsis.Visible = False
        panelSiConcreta.Visible = False
        PanelNoCancela.Visible = False
        PanelSiAsis.Visible = False
        panelGestor.Visible = False
        'ReqCita.Visible = False 
        ReqCita.Checked = False
    End Function
    Private Sub resetValores(ByVal rbList As RadioButtonList)
        'AsisteCita
        For Each elementItem In rbList.Items
            elementItem.selected = False
        Next
    End Sub

    Private Sub EvaluaPanel(ByVal rbList As RadioButtonList)
        For Each elementItem In rbList.Items
            If (elementItem.value = 1 And rdIdCliente.SelectedValue = 2) Then
                elementItem.enabled = False
            Else
                elementItem.enabled = True
            End If
        Next
    End Sub

    Protected Sub RadTimePicker1_SelectedDateChanged(sender As Object, e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadTimePicker1.SelectedDateChanged

    End Sub
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
                buscarAsegurado = dr("reporte_nombreaseg").ToString.Trim & " " & dr("reporte_apaternoAseg").ToString.Trim
            Next
            Return buscarAsegurado
        Catch ex As Exception
            ConfigureNotification("Error: al buscar los datos del asegurado. " & ex.Message)
        End Try
    End Function

    Private Function buscarSigAccionNoEfectiva(ByVal clvNoEfectiva As Integer) As String
        Try
            buscarSigAccionNoEfectiva = String.Empty
            Dim ds As DataSet = New DataSet
            Dim comando As String = "SELECT catRechazo_SigAccion,tiempo FROM CatCausasRechazoNOefectivas WHERE catRechazo_clvRechazo=" & clvNoEfectiva

            ds = csSQLsvr.QueryDataSet(comando, Session("connGestion"))
            Dim dr As DataRow
            For Each dr In ds.Tables(0).Rows
                'buscarSigAccionNoEfectiva = Replace(Replace(Replace(dr("catRechazo_SigAccion"), "{0}", Now().ToString("dd-MM-yyyy")), "{1}", DateAdd(DateInterval.Minute, 10, (Now())).ToString("HH:mm")), "{2}", "Seguimiento Antes de Cita") & IIf(IsDBNull(dr("tiempo")), "", dr("tiempo"))
                buscarSigAccionNoEfectiva = Replace(Replace(Replace(Replace(dr("catRechazo_SigAccion"), "{0}", "Seguimiento Antes de Cita"), "{1}", rdIdCliente.SelectedItem.Text), "{2}", "Llamada No Efectiva"), "{3}", rdIdMotivoNE.SelectedItem.Text) & Replace(Replace(" " & dr("tiempo"), "{0}", Now().ToString("dd-MM-yyyy")), "{1}", DateAdd(DateInterval.Minute, 10, (Now())).ToString("HH:mm"))
            Next
        Catch ex As Exception

        End Try
    End Function


    Private Function buscarSigAccionEfectivaGestor(ByVal clvEfectivaGestor As Integer) As String
        Try
            buscarSigAccionEfectivaGestor = String.Empty
            Dim ds As DataSet = New DataSet
            Dim comando As String = "SELECT catRechazo_SigAccion,tiempo FROM CatCausasRechazoGestor WHERE CatClv_CausaRechazoG=" & clvEfectivaGestor

            ds = csSQLsvr.QueryDataSet(comando, Session("connGestion"))
            Dim dr As DataRow
            For Each dr In ds.Tables(0).Rows
                buscarSigAccionEfectivaGestor = Replace(dr("catRechazo_SigAccion"), "{0}", cmbGestor.SelectedItem.Text) & "  Intentar el " & Now().ToString("dd-MM-yyyy") & "a las " & Now().ToString("HH:mm")
            Next
        Catch ex As Exception

        End Try
    End Function



    Private Function buscarSigAccionNoCancela(ByVal clvNoNoCancela As Integer) As String
        Try
            buscarSigAccionNoCancela = String.Empty
            Dim ds As DataSet = New DataSet
            Dim comando As String = "SELECT catReprog_cvl,catReprog_Desc,catReprog_SigAccion FROM CatCausasReprog WHERE catReprog_cvl=" & clvNoNoCancela

            ds = csSQLsvr.QueryDataSet(comando, Session("connGestion"))
            Dim dr As DataRow
            For Each dr In ds.Tables(0).Rows
                'buscarSigAccionNoCancela = dr("catReprog_SigAccion")

                buscarSigAccionNoCancela = Replace(Replace(Replace(Replace(dr("catReprog_SigAccion"), "{0}", "Seguimiento Antes de Cita"), "{1}", rdIdCliente.SelectedItem.Text), "{2}", "Llamada No Efectiva"), "{3}", cmbMotRep.SelectedItem.Text) & IIf(dr("catReprog_SigAccion").contains("{1}"), Now().ToString("dd-MM-yyyy") & " a las " & Now().ToString("HH:mm"), Now().ToString("dd-MM-yyyy") & " a las " & DateAdd(DateInterval.Hour, 2, (Now())).ToString("HH:mm"))
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
        RadNotification.Width = 400
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

    'Guarda NO EFECTIVA
    '12/05/2014
    'JAMG
    Protected Sub btnGuardarNE_Click(sender As Object, e As System.EventArgs) Handles btnGuardarNE.Click
        'Dim Win As New Ventanas
        'Guardar no efectiva
        '.clasebaseGestoria
        ''llamar ResultadosLlamada de la clase  clasebaseGestoria
        Try
            If (rdIdMotivoNE.SelectedValue <> "") Then
                If (Me.GuardarResultadosLlamada(_NumGestion, 2, IIf(rdIdCliente.SelectedValue = "1", "1", "2"), Convert.ToInt32(rdIdMotivoNE.SelectedValue), Session("Usuario")) = 1) Then
                    'ConfigureNotification("La información se guardó exitosamente.")
                    'Win.AlertPopup("Se canceló el servicio con éxito", "Navegar_ServiciosBusqueda")
                    csDAL.Insert_BitacoraGestionExpe(_NumGestion, lblAccionSigNE.Text.Trim, Session("Usuario"))
                End If
            Else
                ConfigureNotification("Seleccione un Motivo.")
            End If
            ' ScriptManager.RegisterStartupScript(Me, Me.GetType(), "close", "CloseModal();", True)
        Catch ex As Exception
            ConfigureNotification(ex.Message.ToString())
        End Try
    End Sub

    Public Function GuardarResultadosLlamada(ByVal servicio As String, ByVal resultado As Integer, ByVal TipoLlamada As Integer, ByVal causaRechazo As Integer, ByVal usuario As String) As Integer
        ' descomponemos el numero de gestion
        GuardarResultadosLlamada = 0
        Dim sGestion As String = servicio.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Dim CatTipoLlamada As Integer = TipoLlamada ' llamada al cliente de acuerdo al catalogo de   CatTiposLlamadas_Gestoria su valor es 1, gestor seria 2
        Dim CatResLlamadas_ClvResultado As Integer = resultado ' si llamada fue efectiva el valor es 1, no efectiva 2
        Dim Etapa_clvEtapa As Integer = 2 ' de acuerdo al catalogo de   EtapasServicioGestoria_tbl como es 1° contacto cliente=1, si fuera al gestor 1° contacto gestor=2
        Dim ResLlamadas_FechaAlta As String = "getdate()"
        Dim dsResul As Integer
        dsResul = cbGes.Insert_ResultadoLlamadasGestoria_tbl(p_Anio, p_Cliente, p_tipo, p_estado, p_consec, CatTipoLlamada, CatResLlamadas_ClvResultado, Etapa_clvEtapa, causaRechazo, ResLlamadas_FechaAlta, usuario)

        If dsResul > 0 Then
            GuardarResultadosLlamada = 1 ' Resultado 1 la insersion fue efectiva, cero fue no efectiva
            Me.siguienteAccion(servicio, 2, TipoLlamada, lblAccionSigNE.Text.Trim, usuario)
            ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind();", True)
        End If
        'cierra la venmtana
        'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "close", "CloseModal();", True)
        'Win.Closewindow(Page)

    End Function
    'INDEXCHANGE combo de motivos (No efectiva)
    Protected Sub rdIdMotivoNE_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles rdIdMotivoNE.SelectedIndexChanged
        Dim i As String

        i = rdIdMotivoNE.SelectedValue
        If (i <> "") Then
            lblAccionSigNE.Text = Me.buscarSigAccionNoEfectiva(i)
        End If
    End Sub

    Private Function MuestraNumCita()
        'Asigna en la propiedad "NoCita" Si es Primera VEZ o no 
        NoCita = VerificaNoLlamada(_NumGestion)
        numllamadas.Visible = True
        lblNumllamadas.Visible = True
        lblNumllamadas.Text = NoCita
    End Function

    'Contacto
    'opcion 1 = cliente
    'Opcion 2 = Gestor
    Protected Sub rdIdCliente_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles rdIdCliente.SelectedIndexChanged


        MuestraNumCita()
        resetValores(AsisteCita)
        EvaluaOcultaPaneles()
        resetValores(RadioButtonList1)
        If (rdIdCliente.SelectedValue <> "") Then   'CLIENTE
            RadioButtonList1.Enabled = True
            lblsr.Visible = True
            lblTexto.Visible = True
            Texto.Visible = True
            LlenaPanelEfectiva()
            'Cliente
            If (rdIdCliente.SelectedValue = 1) Then
                lbGestor.Text = Me.buscarGestor(_NumGestion)

                'asigna etiquetas
                lblsr.Text = "Sr (a)"
                lblTexto.Text = Me.buscarAsegurado(_NumGestion)
                Texto.Text = ", nos comunicamos del programa NR CONCIERGE, para confirmar la cita que tiene agendada para el dia de hoy a las: "
                ImgGestor.Visible = False
                'Gestor
            ElseIf (rdIdCliente.SelectedValue = 2) Then
                'asigna etiquetas
                lblsr.Text = "Sr (a)"
                lblTexto.Text = Me.buscarGestor(_NumGestion)
                Texto.Text = "Buenos días / tardes / noches, nos comunicamos de BENEFICIA.MX, para  confirmar que usted haya asistido a la  cita que se agendo con usted."
                ImgGestor.Visible = True
            End If
        Else                                      'GESTOR
            EvaluaOcultaPaneles()
            RadioButtonList1.Enabled = False
            lblTexto.Visible = False
            lblsr.Visible = False
            Texto.Visible = False
        End If
    End Sub

    Protected Sub btnESiAsis_Click(sender As Object, e As System.EventArgs) Handles btnESiAsis.Click

        Try
            'If (rdIdMotivoNE.SelectedValue <> "") Then
            If (Me.GuardarResultadosLlamada(_NumGestion, 1, IIf(rdIdCliente.SelectedValue = "1", "1", "2"), 0, Session("Usuario")) = 1) Then
                Me.siguienteAccion(_NumGestion, 2, IIf(rdIdCliente.SelectedValue = "1", "1", "2"), lblSigAccNE.Text.Trim, Session("Usuario"))
                If rdIdCliente.SelectedValue = 1 Then
                    csDAL.Insert_BitacoraGestionExpe(_NumGestion, "Seguimiento antes de Cita: Usuario: " & lblTexto.Text & " Asistira a Cita, Llamada Efectiva, Informacion del lugar de la cita en: " & lblLugarCita.Text.Trim & " Agente " & lbGestor.Text.Trim & ", " & Label3.Text.Trim & ", Siguiente accion: " & lblSigAccNE.Text.Trim, Session("Usuario"))
                Else
                    csDAL.Insert_BitacoraGestionExpe(_NumGestion, "Seguimiento antes de Cita: Gestor: " & lbGestor.Text.Trim & " Asistira a Cita, Llamada Efectiva, Informacion del lugar de la cita en: " & lblLugarCita.Text.Trim & " Agente " & lbGestor.Text.Trim & ", " & Label3.Text.Trim & ", Siguiente accion: " & lblSigAccNE.Text.Trim, Session("Usuario"))

                End If
            End If
            'Else
            'ConfigureNotification("Seleccione un Motivo.")
            'End If
        Catch ex As Exception
            ConfigureNotification(ex.Message.ToString())
        End Try

    End Sub


    'Citas Concretadas
    Protected Sub rlCitaConcret_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles rlCitaConcret.SelectedIndexChanged
        OcultaPanelesInferioresCitaConcret()
        LimpiaValores()
        If (rlCitaConcret.SelectedValue = 1 And rdIdCliente.SelectedValue = 2) Then 'cita concretada SI y es Gestor
            panelSiConcreta.Visible = True
            'lblSigAccNE.Text = "Seguimiento a Trámite"
        ElseIf (rlCitaConcret.SelectedValue = 2 And rdIdCliente.SelectedValue = 2) Then   'cita concretada NO y es Gestor
            If CInt(lblNumllamadas.Text) > 1 Then
                panelGestor.Visible = True
            Else
                panelGestor.Visible = True
                'PanelSiAsis.Visible = True
                ReqCita.Visible = True
                lblSigAccNE.Text = "Seguimiento a, resultado de la cita. Pendiente Contacto con Cliente el " & Now().ToString("dd-MM-yyyy") & " a las " & DateAdd(DateInterval.Hour, 2, Now()).ToString("HH:mm")

            End If

        ElseIf (rlCitaConcret.SelectedValue = 1 And rdIdCliente.SelectedValue = 1) Then   'cita concretada SI y es cliente
            PanelSiAsis.Visible = True
            ReqCita.Visible = True
            lblSigAccNE.Text = "Seguimiento cita concretada. Contacto con Gestor el " & Now().ToString("dd-MM-yyyy") & " a las " & DateAdd(DateInterval.Hour, 2, Now()).ToString("HH:mm")
        ElseIf (rlCitaConcret.SelectedValue = 2 And rdIdCliente.SelectedValue = 1) Then   'cita concretada NO y es Cliente
            PanelNoCancela.Visible = True

        End If
    End Sub

    Private Function OcultaPanelesInferioresCitaConcret()
        ReqCita.Visible = False
        panelSiConcreta.Visible = False
        panelGestor.Visible = False
        PanelSiAsis.Visible = False
        PanelNoCancela.Visible = False
        ReqCita.Visible = False
        ReqCita.Checked = False
    End Function

    Protected Sub cmbMotRep_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbMotRep.SelectedIndexChanged
        Dim i As String
        i = cmbMotRep.SelectedValue
        If (i <> "") Then
            If i = 8 Then
                lbLugarCita0.Text = lbLugarCita.Text
                lbFechaCita0.Text = lbFechaCita.Text
                lbLugarCita0.Visible = True
                lbFechaCita0.Visible = True

                TbLugarCita.Visible = False
                RDPFechaRep.Visible = False
                RadTimePicker1.Visible = False
                Label25.Visible = False

                TbLugarCita.Text = lbLugarCita.Text
                RDPFechaRep.MinDate = lbFechaCita.Text
                RDPFechaRep.SelectedDate = lbFechaCita.Text
                RadTimePicker1.SelectedDate = lbFechaCita.Text

                ' Seguimiento a, resultado de la cita. Contacto con Cliente.
                lblFechaRep.Text = "Fecha y hora de la Cita:" 'Fecha Reprogramación:
                'Left(lbFechaCita.Text, 17).
            Else
                lbLugarCita0.Visible = False
                lbFechaCita0.Visible = False

                TbLugarCita.Visible = True
                RDPFechaRep.Visible = True
                RadTimePicker1.Visible = True
                Label25.Visible = True

                TbLugarCita.Text = ""
                RDPFechaRep.MinDate = Now()
                RDPFechaRep.SelectedDate = Now()
                RadTimePicker1.SelectedDate = Now()
                lblFechaRep.Text = "Fecha Reprogramación:"

            End If
            lblAccionSiguiente.Text = Me.buscarSigAccionNoCancela(i)
        Else
            lblAccionSiguiente.Text = "-----"
        End If
    End Sub

    Protected Sub cmbGestor_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbGestor.SelectedIndexChanged
        Dim i As String
        i = cmbGestor.SelectedValue
        If (i <> "") Then
            lblASGestor.Text = Me.buscarSigAccionEfectivaGestor(i)
            If i = 6 Then lblASGestor.Text = "Seguimiento a, resultado de la cita. Contacto con Cliente. el " & Now().ToString("dd-MM-yyyy") & "a las " & DateAdd(DateInterval.Hour, 2, Now()).ToString("HH:mm")
        Else
            lblASGestor.Text = "-----"
        End If
    End Sub

    'Muestra REPROGRAMACION O NO
    Protected Sub ReqCita_CheckedChanged(sender As Object, e As System.EventArgs) Handles ReqCita.CheckedChanged
        ocultaPanelesReq()
        If (ReqCita.Checked) Then
            PanelNoCancela.Visible = True
        Else
            PanelSiAsis.Visible = True
        End If
    End Sub

    Private Function ocultaPanelesReq()
        PanelSiAsis.Visible = False
        PanelNoCancela.Visible = False
    End Function

    'Efectiva  yRequiere otra cita(seleccionan el check box)
    Protected Sub RadButton1_Click(sender As Object, e As System.EventArgs) Handles RadButton1.Click
        Dim _respuesta As String = ValidaControles()


        'NoCita

        Try
            If (_respuesta = "") Then
                If (NoCita >= 1 And ResultLlamada = True) Then
                    If (Me.GuardarResultadosLlamada(_NumGestion, 1, IIf(rdIdCliente.SelectedValue = "1", "1", "2"), 0, Session("Usuario")) = 1) Then
                        Me.siguienteAccion(_NumGestion, 2, IIf(rdIdCliente.SelectedValue = "1", "1", "2"), lblAccionSiguiente.Text.Trim, Session("Usuario"))
                        GuardarCita(_NumGestion, IIf(rdIdCliente.SelectedValue = "1", "1", "2"), Session("Usuario"))
                        csDAL.Insert_BitacoraGestionExpe(_NumGestion, lblAccionSiguiente.Text.Trim, Session("Usuario"))
                        ConfigureNotification("Datos Guardados exitosamente.")

                        ' Proceso para SMS ''Insertamos en tabla EnvioMailSMS_tbl la etapa 5 (Etapa de Seguimiento Reprogramacion de la Cita)
                        csDAL.InsertEnvioSms(Session("NumGestionSeguimiento").Trim, 5)

                        LimpioControlesRep()
                    End If
                ElseIf (NoCita <= 1 And ResultLlamada = False) Then
                    If (Me.GuardarResultadosLlamada(_NumGestion, 1, IIf(rdIdCliente.SelectedValue = "1", "1", "2"), 0, Session("Usuario")) = 1) Then
                        Me.siguienteAccion(_NumGestion, 2, IIf(rdIdCliente.SelectedValue = "1", "1", "2"), lblAccionSiguiente.Text.Trim, Session("Usuario"))
                        ConfigureNotification("Datos Guardados exitosamente.")
                        LimpioControlesRep()
                    End If
                End If
            Else
                ConfigureNotification(_respuesta)
            End If
        Catch ex As Exception
            ConfigureNotification(ex.Message.ToString())
        End Try
    End Sub
    Private Function LimpioControlesRep()
        cmbMotRep.SelectedValue = ""
        TbLugarCita.Text = ""
        RDPFechaRep.SelectedDate = Nothing
        RadTimePicker1.SelectedDate = Nothing
        cmbMotRep.SelectedIndex = 0
    End Function


    Private Function ValidaControles() As String
        Dim _string As String = ""
        If (cmbMotRep.SelectedValue = "") Then
            _string = _string & "- Seleccione un Motivo de Reprogramación."
        ElseIf (TbLugarCita.Text = "") Then
            _string = _string & "- Ingrese lugar cita."
        ElseIf (RDPFechaRep.SelectedDate Is Nothing) Then
            _string = _string & "- Ingrese fecha de Reprogramación."
        ElseIf (RadTimePicker1.SelectedDate Is Nothing) Then
            _string = _string & "- Ingrese hora de Reprogramación."
        End If
        Return _string
    End Function
    Public Function GuardarCita(ByVal servicio As String, ByVal RoomId As String, ByVal usuario As String) As Integer
        ' descomponemos el numero de gestion
        GuardarCita = 0
        Dim sGestion As String = servicio.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Dim subject As String = IIf(TbLugarCita.Text.Contains("Lugar de la cita"), TbLugarCita.Text, "Lugar de la cita: " & TbLugarCita.Text)
        Dim Fecha As String = (RDPFechaRep.SelectedDate).ToString
        Dim HoraCita As String = (RadTimePicker1.SelectedTime).ToString
        Fecha = Fecha.Substring(0, 10)
        Dim FechaCita As DateTime = CDate(Fecha & " " & HoraCita)
        Dim description As String = IIf(rdIdCliente.SelectedValue = "1", "Cita seguimiento Cliente", "Cita Seguimiento Gestor")


        Dim dsResul As Integer
        dsResul = General.Insert_Cita(_Conn, p_Anio, p_Cliente, p_tipo, p_estado, p_consec, subject, CDate(FechaCita), description, RoomId)
        If dsResul > 0 Then
            GuardarCita = 1 ' Resultado 1 la insersion fue efectiva, cero fue no efectiva
        End If

    End Function


    'pendiente de Guardar
    '14/05/2014
    Protected Sub btnGuardaGestor_Click(sender As Object, e As System.EventArgs) Handles btnGuardaGestor.Click
        Try
            '' 2 = SegTramiteEstatus(NO)
            If (cmbGestor.SelectedValue <> "") Then
                Dim clvRechazo As Integer = Convert.ToInt32(cmbGestor.SelectedValue)
                If clvRechazo = 6 Then
                    'clvRechazo = 0
                    If (Me.GuardarResultadosLlamada(_NumGestion, 1, IIf(rdIdCliente.SelectedValue = "1", "1", "2"), Convert.ToInt32(0), Session("Usuario")) = 1) Then
                        'If (Me.Insert_SeguimientosTramiteGestor_tbl(_NumGestion, 1, 0, Format(System.DateTime.Now, "MM/dd/yyyy")) <> 0) Then
                        'cbGes.InsertDatosSeguimiento(p_Anio, p_Cliente, p_tipo, p_estado, p_consec, IFE, Acuerdo, Usuario)
                        'Me.siguienteAccion(_NumGestion, 2, 2, lblASGestor.Text.Trim, Session("Usuario"))
                        Me.siguienteAccion(_NumGestion, 2, IIf(rdIdCliente.SelectedValue = "1", "1", "2"), lblASGestor.Text.Trim, Session("Usuario"))

                        ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind();", True)
                        ConfigureNotification("La Información se guardó exitosamente.")
                        'End If

                    End If
                Else
                    If (Me.GuardarResultadosLlamada(_NumGestion, 1, IIf(rdIdCliente.SelectedValue = "1", "1", "2"), clvRechazo, Session("Usuario")) = 1) Then
                        If (Me.Insert_SeguimientosTramiteGestor_tbl(_NumGestion, 2, clvRechazo, Format(System.DateTime.Now, "MM/dd/yyyy")) <> 0) Then
                            Me.siguienteAccion(_NumGestion, 2, IIf(rdIdCliente.SelectedValue = "1", "1", "2"), lblASGestor.Text.Trim, Session("Usuario"))
                            csDAL.Insert_BitacoraGestionExpe(_NumGestion, "Seguimiento antes de Cita: Contacto Gestor: " & lbGestor.Text.Trim & ", " & lblASGestor.Text.Trim, Session("Usuario"))
                            ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind();", True)
                            ConfigureNotification("La Información se guardó exitosamente.")
                        End If
                    End If
                End If




            Else
                ConfigureNotification("Ingrese Motivo.")
            End If
        Catch ex As Exception
            ConfigureNotification("Error al guardar la información" & ex.Message)
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


    'Pendiente de guardar
    '14/05/2014
    Protected Sub rbSiCitaconcretada_Click(sender As Object, e As System.EventArgs) Handles rbSiCitaconcretada.Click
        Try

            If (radtbIFE.Text <> "") Then
                Dim IFE As String = radtbIFE.Text
                Dim Acuerdo As String = radtbAcuerdo.Text.Trim
                Dim Usuario As String = Session("Usuario")
                'Dim FechaAlta As String = Format(System.DateTime.Now, "MM/dd/yyyy")
                Dim sGestion As String = _NumGestion.Trim
                Dim nLargo As Integer = Len(sGestion)
                Dim p_Anio As String = Mid(sGestion, 1, 4)
                Dim p_Cliente As String = Mid(sGestion, 5, 2)
                Dim p_tipo As String = Mid(sGestion, 7, 2)
                Dim p_estado As String = Mid(sGestion, 9, 2)
                Dim p_consec As String = Mid(sGestion, 11, nLargo)


                If (Me.GuardarResultadosLlamada(_NumGestion, 1, IIf(rdIdCliente.SelectedValue = "1", "1", "2"), Convert.ToInt32(0), Session("Usuario")) = 1) Then
                    cbGes.InsertDatosSeguimiento(p_Anio, p_Cliente, p_tipo, p_estado, p_consec, IFE, Acuerdo, Usuario)
                    Me.siguienteAccion(_NumGestion, 2, IIf(rdIdCliente.SelectedValue = "1", "1", "2"), lblas.Text.Trim, Session("Usuario"))

                    ' Proceso para SMS ''Insertamos en tabla EnvioMailSMS_tbl la etapa 4 (Etapa de Seguimiento Acudio a Cita)
                    csDAL.InsertEnvioSms(Session("NumGestionSeguimiento").Trim, 4)

                    ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind();", True)
                End If
            Else
                ConfigureNotification("Ingrese IFE para continuar.")
            End If
        Catch ex As Exception
            ConfigureNotification("Error al guardar la información" & ex.Message)
        End Try
    End Sub

    Protected Sub ImgGestor_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ImgGestor.Click
        CargaDatosAjustador(_NumGestion)
    End Sub


    Private Sub CargaDatosAjustador(ByVal noservicio As String)
        Try
            Dim sGestion As String = noservicio.Trim
            Dim nLargo As Integer = Len(sGestion)
            Dim p_Anio As String = Mid(sGestion, 1, 4)
            Dim p_Cliente As String = Mid(sGestion, 5, 2)
            Dim p_tipo As String = Mid(sGestion, 7, 2)
            Dim p_estado As String = Mid(sGestion, 9, 2)
            Dim p_consec As String = Mid(sGestion, 11, nLargo)
            Dim comando As String = "exec sp_SelectGestorDatosContacto " & p_Anio & "," & p_Cliente & "," & p_tipo & "," & p_estado & "," & p_consec
            Dim ds As DataSet = New DataSet
            ds = csSQLsvr.QueryDataSet(comando, Session("connGestion"))
            Dim dr As DataRow
            For Each dr In ds.Tables(0).Rows
                ConfigureNotification("Datos del Gestor:" & "<br \>" & _
                                        "" & "<pre>" & _
                                        "Nombre de Gestor:" & dr("Nombre") & "  " & dr("Paterno") & "<br \>" & _
                                        "Telefono Celular:" & dr("Celular") & "<br \>" & _
                                        "Tel1:" & dr("tel1") & "<br \>" & _
                                        "Tel2:" & dr("tel2") & "<br \>" & _
                                        "tel3" & "<br \><br \>" & "</pre>")
            Next
            ds.Clear()
            ds.Dispose()
        Catch ex As Exception
            ConfigureNotification("Error al cargar los datos del gestor, por favor verifique...")
        End Try

    End Sub

    Protected Sub ReqCita0_CheckedChanged(sender As Object, e As System.EventArgs) Handles ReqCita0.CheckedChanged
        ocultaPanelesReq()
        If (ReqCita.Checked) Then
            PanelNoCancela.Visible = True
        Else
            PanelSiAsis.Visible = True
        End If
    End Sub
End Class



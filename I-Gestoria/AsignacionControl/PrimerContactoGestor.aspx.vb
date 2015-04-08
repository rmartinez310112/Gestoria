Imports System.Data
Imports System.Web
Imports Telerik.Web.UI
Imports System.Data.SqlClient

Partial Class AsignacionControl_PrimerContactoGestor
    Inherits System.Web.UI.Page
    Dim csNeg As New ClaseNegocios
    Dim csSQLsvr As New BaseDatosSQL
    Dim cbGes As New ClaseBaseGestoria
    Dim csDAL As New DALClass

    Dim FechaIniCita As Date
    Dim FechaFinCita As Date


    Private Sub RegistraScript()
        ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind();", True)
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As System.EventArgs) Handles btnGuardar.Click
        If rdoUsuario.SelectedItem.Value = 2 And cboMotivoNoefectivo.SelectedItem.Value <> 1 Then ' si tenemos como no efectiva debe de haber una causa de no efectiva
            Dim resultado As Integer = GuardarResultadosLlamada(Session("NumGestionSeguimiento"), rdoUsuario.SelectedValue, cboMotivoNoefectivo.SelectedItem.Value, Session("clvUsuario"))
            RegistraScript()
            siguienteAccion(Session("NumGestionSeguimiento"), 1, 2, lblAccionNoefectiva.Text.Trim, Session("clvUsuario"))
            csDAL.Insert_BitacoraCambios(Session("NumGestionSeguimiento").Trim, "Control de Asignacion: Contacto Gestor: " & Session("NombreApellidoGstor") & "Llamada No Efectiva" & lblAccionNoefectiva.Text.Trim, Session("clvUsuario"))
            ConfigureNotification("La informacion se guardo correctamente,Seleccione otro Gestor")
        End If
        If rdoUsuario.SelectedItem.Value = 2 And cboMotivoNoefectivo.SelectedItem.Value = 1 Then ' si tenemos como no efectiva debe de haber una causa de no efectiva
            ConfigureNotification("Es necesario seleccionar un motivo por lo cual la llamada fue no efectiva")
            Exit Sub
        End If

        If rdoUsuario.SelectedItem.Value = 1 Then ' si fue efectiva hacemos la insercion
            Dim resultado As Integer = GuardarResultadosLlamada(Session("NumGestionSeguimiento").Trim, rdoUsuario.SelectedValue, 0, Session("clvUsuario"))
            Dim descrip As String = "Se asigno Gestor"
            RegistraScript()
            If resultado = 1 Then


                If rdoGestorAcepta.SelectedValue = 2 Then

                    'resultado = RechazaServicio(Session("NumGestionSeguimiento").Trim, 0, Session("clvUsuario"))
                    siguienteAccion(Session("NumGestionSeguimiento"), 1, 2, lblAccionNoAcep.Text.Trim, Session("clvUsuario"))
                    csDAL.Insert_BitacoraCambios(Session("NumGestionSeguimiento").Trim, "Control de Asignacion: " & lblAccionNoAcep.Text.Trim, Session("clvUsuario"))
                    ConfigureNotification("La informacion se guardo correctamente,Seleccione otro Gestor")
                    RegistraScript()
                Else
                    resultado = Update_ReporteGestion(Session("NumGestionSeguimiento").Trim)
                    resultado = GuardarCitaGes(Session("NumGestionSeguimiento").Trim, 0, Session("clvUsuario"))
                    csDAL.Insert_BitacoraGestionExpe(Session("NumGestionSeguimiento"), descrip, Session("clvUsuario"))
                    siguienteAccion(Session("NumGestionSeguimiento"), 1, 2, "Se asigno el Gestor correctamente, Pasar siguiente accion", Session("clvUsuario"))
                    csDAL.Insert_BitacoraCambios(Session("NumGestionSeguimiento").Trim, "Control de Asignacion: Se asigna Gestor" & Session("NombreApellidoGstor") & ",informacion de cita Agencia " & lblLugar.Text & ", " & lblFecha.Text & ", " & lblHora.Text.Trim & ".Se envio por correo la informacion a" & txtMailGestor.Text & " y " & txtMailCliente.Text.Trim & ". Pendiente seguimiento antes de cita", Session("clvUsuario"))

                    ConfigureNotification("La informacion se guardo correctamente,Se asigno el Gestor correctamente")

                    ' Proceso para SMS ''Insertamos en tabla EnvioMailSMS_tbl la etapa 2 (Etapa de Asignacion de Gestor)
                    csDAL.InsertEnvioSms(Session("NumGestionSeguimiento").Trim, 2)

                    btnGuardar.Enabled = False
                    RegistraScript()
                End If
            End If
        End If



    End Sub
    Public Sub cargaGestores(ByVal estado As Integer)
        Dim ds As New DataSet
        If rdoGesCita.SelectedValue = "" Then
            ds = csDAL.buscaGestores(estado)
        ElseIf rdoGesCita.SelectedValue = "2" Then
            Dim fecha As Date = Convert.ToDateTime(lblFechaCita.Text)

            FechaIniCita = DateAdd(DateInterval.Minute, -30, fecha)
            FechaFinCita = DateAdd(DateInterval.Minute, 30, fecha)
            ds = csDAL.buscaGestores(estado, 0, Format(FechaIniCita, "MM/dd/yyyy HH:mm"), Format(FechaFinCita, "MM/dd/yyyy HH:mm"))

        Else
            ds = csDAL.buscaGestores(estado)
        End If
        With grdiGestores
            .DataSource = ds.Tables(0).Rows
            .DataBind()
        End With
        'rfc = ""
        ds.Clear()
        ds.Dispose()
    End Sub
    Public Sub cargaGestores1(ByVal estado As Integer)
        Dim ds As New DataSet
        Dim mpio As Integer = Session("MPIO")
        cboEstado.SelectedValue = estado
        ds = csDAL.buscaGestores(estado, mpio)
        With grdiGestores
            .DataSource = ds.Tables(0).Rows
            .DataBind()
        End With
        'rfc = ""
        ds.Clear()
        ds.Dispose()
    End Sub

    Public Sub cargaGestoresLeasing(ByVal estado As Integer)

        Dim ds As New DataSet
        Dim mpio As Integer

        Dim sGestion As String = Session("NumGestionSeguimiento").Trim()
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        cboEstado.SelectedValue = estado
        If estado = p_estado Then
            mpio = Session("MPIO")
        Else
            mpio = 0
        End If
        ds = csDAL.buscaGestoresLeasing(estado, mpio, p_Cliente)

        With grdiGestores
            .DataSource = ds.Tables(0).Rows
            .DataBind()
        End With



        If ds.Tables(0).Rows.Count = 0 Then
            Dim dsclientes As New DataSet
            dsclientes = csDAL.buscaNombreCliente(p_Cliente)
            Dim nomCliente As String = ""
            Dim dr As DataRow
            For Each dr In dsclientes.Tables(0).Rows

                nomCliente = IIf(IsDBNull(dr("cliente_NomCliente")), "", dr("cliente_NomCliente"))

            Next

            'rfc = ""
            ds.Clear()
            ds.Dispose()

            ConfigureNotification("No hay gestor asignado con poderes leasing para la compañia: " & nomCliente)
        End If


    End Sub

    Protected Sub rdoUsuario_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles rdoUsuario.SelectedIndexChanged
        rdoGestorAcepta.SelectedValue = Nothing
        If Session("GestorSeleccionado") = 0 Then
            ConfigureNotification("Es necesario seleccionar un Gestor")
            btnGuardar.Enabled = False
            rdoUsuario.SelectedValue = Nothing
            Exit Sub
        Else
            btnGuardar.Enabled = True
        End If
        If rdoUsuario.SelectedValue = 1 Then
            PanelNoefectivo.Visible = False
            PanelGestorAcepSer.Visible = True
            PanelNoAcepSer.Visible = False
            PaneEfectivo.Visible = False
            btnGuardar.Visible = False
        ElseIf rdoUsuario.SelectedValue = 2 Then
            PanelNoefectivo.Visible = True
            PanelGestorAcepSer.Visible = False
            PanelNoAcepSer.Visible = False
            PaneEfectivo.Visible = False
            btnGuardar.Visible = False
        Else
            MsgBox("Elegir una Opcion")
        End If
    End Sub
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            Session("GestorSeleccionado") = 0
            PaneEfectivo.Visible = False
            PanelNoefectivo.Visible = False
            PanelGestorAcepSer.Visible = False
            PanelNoAcepSer.Visible = False
            CargarMotivoNoEfec()
            cargaEstados()
            Cargar_MotivoRechazoGestor()
            btnGuardar.Visible = False
            VerificaEstado_Mpio(Session("NumGestionSeguimiento").Trim)
            Dim dsdatosExp As New DataSet

            dsdatosExp = csDAL.buscaExpedienteGestion(Session("NumGestionSeguimiento").Trim)

            If dsdatosExp.Tables(0).Rows.Count > 0 Then
                Dim dr As DataRow
                Dim leasing As String

                For Each dr In dsdatosExp.Tables(0).Rows

                    leasing = IIf(IsDBNull(dr("Reporte_leasing")), 0, dr("Reporte_leasing"))

                Next
                Session("Leasing") = leasing
                If leasing = 1 Then

                    cargaGestoresLeasing(Session("ESTADO"))
                    buscarCita(Session("NumGestionSeguimiento").Trim)

                Else

                    cargaGestores1(Session("ESTADO"))
                    buscarCita(Session("NumGestionSeguimiento").Trim)

                End If

            End If



        End If
    End Sub
    Public Sub CargarMotivoNoEfec()
        Dim comando As String = "select * from CatCausasRechazoNOefectivas"
        csSQLsvr.LlenarRadCombo(cboMotivoNoefectivo, comando, Session("connGestion"))
    End Sub
    Public Sub cargaEstados()

        Dim comando As String = "exec Select_cbo_estados"
        csSQLsvr.LlenarRadCombo(cboEstado, comando, Session("connGestion"))

    End Sub
    'Public Sub cargaEstados1(ByVal estado As Integer)

    '    Dim comando As String = "exec Select_cbo_estados"
    '    csSQLsvr.LlenarRadCombo(cboEstado, comando, Session("connGestion"))

    'End Sub

    Protected Sub cboEstado_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cboEstado.SelectedIndexChanged
        If Session("Leasing") = 1 Then
            cargaGestoresLeasing(cboEstado.SelectedValue)
        Else
            cargaGestores(cboEstado.SelectedValue)
        End If

    End Sub

    Protected Sub rdoGestorAcepta_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles rdoGestorAcepta.SelectedIndexChanged

        If rdoGestorAcepta.SelectedValue = 1 Then
            PaneEfectivo.Visible = True
            PanelNoAcepSer.Visible = False
            btnGuardar.Visible = True
        ElseIf rdoGestorAcepta.SelectedValue = 2 Then
            PaneEfectivo.Visible = False
            PanelNoAcepSer.Visible = True
            btnGuardar.Visible = False
        End If
    End Sub
    Public Sub Cargar_MotivoRechazoGestor()
        Dim comando As String = "select CatClv_CausaRechazoG,CatRechazo_DescripG from CatCausasRechazoGestor order by CatClv_CausaRechazoG  "
        csSQLsvr.LlenarRadCombo(cboMotRechaGes, comando, Session("connGestion"))
    End Sub
    Public Sub cargarAccion(ByVal accion As String)
        Dim comando As String
        If accion <> "" Then
            comando = "exec Select_CausaRechazoGestor_sp @clv_Causa = " & accion

            'Else
            '    comando = "exec Select_estados_sp"
        End If
        csSQLsvr.LlenarRadCombo(cboEstado, comando, Session("connGestion"))

    End Sub

    Protected Sub cboMotRechaGes_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cboMotRechaGes.SelectedIndexChanged
        If cboMotRechaGes.SelectedValue <> 0 Then
            btnGuardar.Visible = True
            lblAccionNoAcep.Text = buscarSigAccionRechazoGestor(cboMotRechaGes.SelectedValue)
        Else
            MsgBox("Elija una opcion")
        End If

        cargarAccion(lblAccion.Text)
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
        Dim CausaCancelacion As String = cboMotRechaGes.SelectedValue
        Dim Etapa_clvEtapa As Integer = 2 ' de acuerdo al catalogo de   EtapasServicioGestoria_tbl como es 1° contacto cliente=1, si fuera al gestor 1° contacto gestor=2

        Dim dsResul As Integer
        dsResul = cbGes.Cancela_Servicio(p_Anio, p_Cliente, p_tipo, p_estado, p_consec, CausaCancelacion, usuario)

        If dsResul > 0 Then
            RechazaServicio = 1 ' Resultado 1 la insersion fue efectiva, cero fue no efectiva
        End If
    End Function
    Public Function BitacoraGes(ByVal servicio As String) As Integer



    End Function

    Protected Sub grdiGestores_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles grdiGestores.ItemCommand
        If e.CommandName = "cmdRfc" Then
            Session("GestorSeleccionado") = 1
            Dim dataItem As GridDataItem = e.Item
            Dim indexRow As Integer = Convert.ToInt32(e.Item.ItemIndex)
            Dim item As GridDataItem = grdiGestores.Items(indexRow)
            Dim item3 As GridDataItem = DirectCast(e.Item, GridDataItem)
            Session("rfc") = item.Cells(3).Text
            Session("NombreApellidoGstor") = ""
            Session("NombreApellidoGstor") = (item.Cells(4).Text).Trim & " " & (item.Cells(5).Text).Trim

            dataItem.BackColor = Drawing.Color.Yellow
            'Dim sGestion As String = DirectCast(item3("cmdNumservicio").Controls(o), LinkButton).Text
        End If
    End Sub
    Public Function Update_ReporteGestion(ByVal servicio As String) As Integer
        ' descomponemos el numero de gestion
        'RechazaServicio = 0
        Dim sGestion As String = servicio.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        'Dim AvisoGestor As String = "getdate()"
        Dim rfc_gestor As String = Session("rfc")
        'Dim CausaCancelacion As String = cboMotivoCanSer.SelectedValue
        'Dim Etapa_clvEtapa As Integer = 1 ' de acuerdo al catalogo de   EtapasServicioGestoria_tbl como es 1° contacto cliente=1, si fuera al gestor 1° contacto gestor=2

        Dim dsResul As Integer
        dsResul = cbGes.Update_AsignaGestor(p_Anio, p_Cliente, p_tipo, p_estado, p_consec, rfc_gestor)

        If dsResul > 0 Then
            'RechazaServicio = 1 ' Resultado 1 la insersion fue efectiva, cero fue no efectiva
        End If

    End Function

    Protected Sub cboMotivoNoefectivo_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cboMotivoNoefectivo.SelectedIndexChanged
        If cboMotivoNoefectivo.SelectedValue <> 0 Then
            btnGuardar.Visible = True
            lblAccionNoefectiva.Text = buscarSigAccionNoEfectiva(cboMotivoNoefectivo.SelectedValue)

        Else
            MsgBox("Necesita seleccionar una opcion")
        End If
    End Sub

    Protected Sub rdoGesCita_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdoGesCita.SelectedIndexChanged
        If rdoGesCita.SelectedValue >= 1 Then
            If Session("Leasing") = 1 Then
                Session("MPIO") = 0
                cargaGestoresLeasing(cboEstado.SelectedValue)
            Else
                cargaGestores(cboEstado.SelectedValue)
            End If

        End If
    End Sub

    Public Function GuardarCitaGes(ByVal servicio As String, ByVal resultado As Integer, ByVal usuario As String) As Integer
        ' descomponemos el numero de gestion
        GuardarCitaGes = 0
        Dim sGestion As String = servicio.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Dim subject As String = "Lugar de la cita: " & lblLugarCita.Text
        'Dim Fecha As String = lblFechaCita.Text
        'Dim HoraCita As String = (RadTimePicker1.SelectedTime).ToString
        'Fecha = Fecha.Substring(0, 10)
        Dim FechaCita As String = lblFechaCita.Text 'se tiene que ingresar  lblFechaCita.Text para que mande el parametro correcto
        Dim description As String = ""


        Dim dsResul As Integer
        dsResul = cbGes.Insert_CitaGestor(p_Anio, p_Cliente, p_tipo, p_estado, p_consec, subject, CDate(FechaCita), description, txtMailCliente.Text, txtMailGestor.Text)
        If dsResul > 0 Then
            GuardarCitaGes = 1 ' Resultado 1 la insersion fue efectiva, cero fue no efectiva
            'cbGes.Insert_EnvioEmailGestoria(p_Anio, p_Cliente, p_tipo, p_estado, p_consec, txtMailCliente.Text.Trim, 1)
            'cbGes.Insert_EnvioEmailGestoria(p_Anio, p_Cliente, p_tipo, p_estado, p_consec, txtMailGestor.Text.Trim, 1)
        End If

    End Function
    Private Function buscarSigAccionNoEfectiva(ByVal clvNoEfectiva As Integer) As String
        Try
            buscarSigAccionNoEfectiva = String.Empty
            Dim ds As DataSet = New DataSet
            Dim comando As String = "select catRechazo_SigAccion,tiempo FROM CatCausasRechazoNOefectivas where catRechazo_clvRechazo=" & clvNoEfectiva

            ds = csSQLsvr.QueryDataSet(comando, Session("connGestion"))
            Dim dr As DataRow
            For Each dr In ds.Tables(0).Rows
                buscarSigAccionNoEfectiva = Replace(Replace(Replace(Replace(dr("catRechazo_SigAccion"), "{0}:", ""), "{1}", "Contacto Gestor"), "{2}", "Llamada No Efectiva"), "{3}", cboMotivoNoefectivo.SelectedItem.Text) & Replace(Replace(" " & dr("tiempo"), "{0}", Now().ToString("dd-MM-yyyy")), "{1}", DateAdd(DateInterval.Minute, 10, (Now())).ToString("HH:mm"))
            Next
        Catch ex As Exception

        End Try

    End Function
    Private Function buscarSigAccionRechazoGestor(ByVal clvNoRechazo As Integer) As String
        Try
            buscarSigAccionRechazoGestor = String.Empty
            Dim ds As DataSet = New DataSet
            Dim comando As String = "select catRechazo_SigAccion,tiempo FROM CatCausasRechazoGestor where CatClv_CausaRechazoG=" & clvNoRechazo

            Dim nomgetor As String = IIf(Session("NombreApellidoGstor") Is Nothing, "", Session("NombreApellidoGstor"))


            ds = csSQLsvr.QueryDataSet(comando, Session("connGestion"))
            Dim dr As DataRow
            For Each dr In ds.Tables(0).Rows
                buscarSigAccionRechazoGestor = Replace(Replace(dr("catRechazo_SigAccion"), "{1}", cboMotRechaGes.SelectedItem.Text), "{0}", nomgetor) & Replace(Replace(" " & dr("tiempo"), "{0}", Now().ToString("dd-MM-yyyy")), "{1}", Now().ToString("HH:mm"))
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
    Private Sub buscarCita(ByVal noservicio As String)
        Dim Cita As New List(Of String)
        Try

            Dim sGestion As String = noservicio.Trim
            Dim nLargo As Integer = Len(sGestion)
            Dim p_Anio As String = Mid(sGestion, 1, 4)
            Dim p_Cliente As String = Mid(sGestion, 5, 2)
            Dim p_tipo As String = Mid(sGestion, 7, 2)
            Dim p_estado As String = Mid(sGestion, 9, 2)
            Dim p_consec As String = Mid(sGestion, 11, nLargo)
            Dim comando As String = "exec sp_SelectCita " & p_Anio & "," & p_Cliente & "," & p_tipo & "," & p_estado & "," & p_consec
            Dim ds As DataSet = New DataSet
            ds = csSQLsvr.QueryDataSet(comando, Session("connGestion"))
            Dim dr As DataRow
            If ds.Tables(0).Rows.Count <> 0 Then
                For Each dr In ds.Tables(0).Rows
                    If dr("Start").ToString IsNot Nothing Then

                        Dim Fecha As String = (dr("Start").ToString.Trim).Substring(0, 10)
                        Dim Hora As String = (dr("Start").ToString.Trim).Substring(10)

                        lblFecha.Text = Fecha
                        lblHora.Text = Hora
                        lblFechaCita.Text = dr("Start").ToString.Trim

                    End If
                    lblMotivoCita.Text = dr("Description").ToString.Trim
                    lblFechaCita.Text = dr("Start").ToString.Trim

                    lblLugarCita.Text = Replace(dr("Subject").ToString.Trim, "Lugar de la cita:", "") 'Lugar de cita
                    lblLugar.Text = Replace(dr("Subject").ToString.Trim, "Lugar de la cita:", "") 'Lugar de cita
                    lblMotivo.Text = dr("Description").ToString.Trim
                    lblServicio.Text = sGestion
                    lblContrato.text = dr("cliente_NomCliente").ToString.Trim
                    lblTipo.Text = dr("Servicio_NomServicio").ToString.Trim
                    lblCliente.Text = dr("Reporte_NombreAseg").ToString.Trim & " " & dr("Reporte_ApaternoAseg").ToString.Trim

                    txtMailCliente.Text = dr("Reporte_MailAseg").ToString.Trim
                Next
            End If

            comando = "exec sp_Selectgestor " & p_Anio & "," & p_Cliente & "," & p_tipo & "," & p_estado & "," & p_consec
            ds = csSQLsvr.QueryDataSet(comando, Session("connGestion"))

            For Each dr In ds.Tables(0).Rows
                txtMailGestor.Text = dr("EMAIL").ToString.Trim

            Next

        Catch ex As Exception
            ConfigureNotification("Error: al buscar los datos del gestor asigando. " & ex.Message)
        End Try
    End Sub
    Public Sub envioEmails(ByVal noservicio As String)
        Dim sGestion As String = noservicio.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        If CheckBox1.Checked Then
            cbGes.Insert_EnvioEmailGestoria(p_Anio, p_Cliente, p_tipo, p_estado, p_consec, txtMailCliente.Text.Trim, 1)
        End If
        If CheckBox2.Checked Then
            cbGes.Insert_EnvioEmailGestoria(p_Anio, p_Cliente, p_tipo, p_estado, p_consec, txtMailGestor.Text.Trim, 1)
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
    Public Sub VerificaEstado_Mpio(ByVal sGestion As String)
        'Session("NumGestionSeguimiento") = sGestion
        Dim ds As Data.DataTable
        Dim estado As Integer
        Dim mpio As Integer
        ds = csDAL.GestoresEdos_Mpios(sGestion)
        If ds.Rows.Count > 0 Then
            'Cache.Add("Datos",ds,Cache.)
            Dim dr As DataRow = ds.Rows(0)


            estado = dr("Reporte_clvEstado")
            mpio = dr("Reporte_clvMpio")

        End If
        Session("ESTADO") = estado
        Session("MPIO") = mpio

    End Sub


End Class

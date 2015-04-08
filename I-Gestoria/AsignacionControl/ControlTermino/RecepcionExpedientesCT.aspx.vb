Imports System.Data

Partial Class AsignacionControl_ControlTermino_RecepcionExpedientesCT
    Inherits System.Web.UI.Page
    Dim csBaseGes As New ClaseBaseGestoria
    Dim VentanasWin As New Ventanas
    Dim modoventana As Integer
    Dim csDAL As New DALClass
    Dim csSQLsvr As New BaseDatosSQL
#Region "procesos"

    Public Sub ABRIR_VENTANA(ByVal PopUpWindowPage As String, ByVal alto As Integer, ByVal largo As Integer)

        Dim Script As String = ""

        Script = " <script language=JavaScript id='PopupWindow'>  var confirmWin = null; confirmWin = window.open('" & PopUpWindowPage & "','myWindow','status = 1, scrollbars=1,height = " & alto & ", width = " & largo & ", resizable = 1 '); if((confirmWin != null) && (confirmWin.opener==null)) { confirmWin.opener = self; } </script> "
        If Not ClientScript.IsStartupScriptRegistered("PopupWindow") Then
            'ClientScript.RegisterStartupScript(Me.GetType, "PopupWindow", Script)
            ClientScript.RegisterClientScriptBlock(Me.GetType, "PopupWindow", Script)
        End If

    End Sub


    Public Sub guardar_Recepcion(ByVal noServicio As String)
        Dim sGestion As String = noServicio.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)

        Dim fechaRecepcion As String = Format(dateRecibe.SelectedDate, "yyyy/MM/dd")
        Dim horaRecepcion As String = (RadTimePicker1.SelectedTime.Value.Hours & ":" & RadTimePicker1.SelectedTime.Value.Minutes & ":" & RadTimePicker1.SelectedTime.Value.Seconds)
        Dim fechayHora As String = fechaRecepcion & " " & horaRecepcion
        Dim comentarios As String = txtComentarios.Text.Trim.ToUpper
        Dim guia As String = txtGuia.Text.Trim.ToUpper
        Dim TipoEntrega As String = rblTipoEntrega.SelectedItem.Value

        If csDAL.valida_EntregaExpedientesGestoria(p_Anio, p_Cliente, p_tipo, p_estado, p_consec) = True Then

            Dim msgError As String = csDAL.RegresoSeguimiento(Session("NumGestionControlTerm"))
            If msgError <> "" Then
                ConfigureNotification(msgError)
            Else
                csBaseGes.Insert_EntregaExpedientesGestoria(p_Anio, p_Cliente, p_tipo, p_estado, p_consec, comentarios, Session("clvUsuario"), fechayHora, "0", "01/01/1900", TipoEntrega, guia)
                ConfigureNotification("Guardado Exitosamente y genero historico de recepciones")
                RegistraScript()
            End If
        Else
            csBaseGes.Insert_EntregaExpedientesGestoria(p_Anio, p_Cliente, p_tipo, p_estado, p_consec, comentarios, Session("clvUsuario"), fechayHora, "0", "01/01/1900", TipoEntrega, guia)
            ConfigureNotification("Guardado Exitosamente, primera recepcion")
            RegistraScript()
        End If

    End Sub


    Public Sub buscaServicio(ByVal noServicio As String)

        Dim sGestion As String = noServicio.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Dim ds As New DataSet

        If p_Anio.Trim = String.Empty Then p_Anio = 0
        If p_Cliente.Trim = String.Empty Then p_Cliente = 0
        If p_tipo.Trim = String.Empty Then p_tipo = 0
        If p_estado.Trim = String.Empty Then p_estado = 0
        If p_consec.Trim = String.Empty Then p_consec = 0


        ds = csBaseGes.SelectRecords_reportesGestion(p_Anio, p_Cliente, p_tipo, p_estado, p_consec)
        Dim dr As DataRow
        'MyDataSet.Tables.Count = 0
        If ds.Tables(0).Rows.Count > 0 Then
            For Each dr In ds.Tables(0).Rows
                lbldatos.Text = " No. de Servicio:" & noServicio & Chr(13) & "Asegurado: " & dr("Reporte_ApaternoAseg") & " " & dr("Reporte_AMaternoAseg") & " " & dr("Reporte_NombreAseg") & Chr(13) & "No. de Poliza:" & dr("Reporte_poliza")
                'Dim master As MasterPageGestionOperativa = DirectCast(Me.Master, MasterPageGestionOperativa)
                'Dim nExpediente As Telerik.Web.UI.RadNumericTextBox = master.FindControl("txtNoGestion")
                ''Session("noGestionIntegral") = txtExpediente.Text
                'nExpediente.Text = p_Anio & p_Cliente & p_tipo & p_estado & p_consec

                'master.CargaDatosExpediente()

                ' aqui por favor enviar a la master page el No. de Servicio para que se refrequen los datos.
                cmdGuardar.Enabled = True
            Next
        Else
            lbldatos.Text = " El No. de Servicio no Existe"
            cmdGuardar.Enabled = False
        End If

    End Sub


#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        VentanasWin = New Ventanas(Master)
        'Session("clvUsuario") = "CZL"

        If Not Page.IsPostBack Then
            CargarCiaPaqueteria()
            dateRecibe.SelectedDate = Now()
            RadTimePicker1.SelectedDate = Now()
            RadTimePicker1.DateInput.DisplayText = Hour(Now()) & ":" & Minute(Now())

            'Dim dt As DataTable

            'dt = csBaseGes.LlenaGuia(Session("NumGestionControlTerm"))

            Dim dr As DataRow
            'MyDataSet.Tables.Count = 0
            'If dt.Rows.Count > 0 Then
            modoventana = 3
            'For Each dr In dt.Rows
            'txtGuia.Text = dr("EntregaExpediente_Guia")
            'txtComentarios.Text = dr("EntregaExpediente_Comentario")
            'dateRecibe.SelectedDate = CDate(dr("EntregaExpediente_fecha"))
            'Next
            'End If

            If Session("ModoVentanaControlTerm") <> 0 Then
                If Session("NumGestionControlTerm") <> 0 Then
                    If modoventana <> 3 Then modoventana = Session("ModoVentanaControlTerm")
                    CargaControles(modoventana)
                    txtExpediente.Text = Session("NumGestionControlTerm")
                End If
            End If

        End If

    End Sub

    Public Sub CargaControles(ByVal modo As Integer)

        Select Case modo

            Case 1
                ControlesInicio()
                cmdGuardar0.Visible = False
                Label7.Visible = False
            Case 2
                Label7.Visible = True
                cmdGuardar0.Visible = True
                txtExpediente.Text = String.Empty
                Dim dsVer As DataSet
                dsVer = csBaseGes.SelectRecords_EntregaExpedientesSinVerificar
                With radExpedienteVer
                    .DataSource = dsVer.Tables(0)
                    .DataBind()
                End With
            Case 3
                Panel1.Visible = True
                cmdGuardar0.Visible = False
                Label7.Visible = False
        End Select
    End Sub


    Protected Sub txtExpediente_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtExpediente.TextChanged
        If txtExpediente.Text.Trim <> String.Empty Then
            buscaServicio(txtExpediente.Text)
        End If

    End Sub

    Protected Sub cmdGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGuardar.Click

        If rblTipoEntrega.SelectedValue = 1 Then
            If txtGuia.Text <> "" Then
                guardar_Recepcion(txtExpediente.Text.Trim)
            Else
                ConfigureNotification("Es necesario ingresar guia")
            End If
        Else
            guardar_Recepcion(txtExpediente.Text.Trim)
        End If
        

    End Sub

    Protected Sub radExpedienteVer_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles radExpedienteVer.ItemCommand


        If e.CommandName = "cmdServicio" Then
            'Dim master As MasterPageGestionOperativa = DirectCast(Me.Master, MasterPageGestionOperativa)
            'Dim nExpediente As Telerik.Web.UI.RadNumericTextBox = Me.Master.FindControl("txtNoGestion")
            'nExpediente.Text = e.Item.Cells(3).Text.Trim
            'Session("noGestionIntegral") = e.Item.Cells(3).Text.Trim
            'master.CargaDatosExpediente()
            ' aqui mandar el no. de servicio escogido al encabezado.
            Dim nServicio = e.Item.Cells(3).Text.Trim
            txtExpediente.Text = nServicio
            VentanasWin.Abrir_winwinVerificacionExp()

            'ABRIR_VENTANA("BackOffice/VerificacionExpedientesBO.aspx?nogestion=" & nServicio, 800, 1000)

        End If
    End Sub

    Protected Sub cmdGuardar0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGuardar0.Click

        ControlesInicio()

    End Sub

    Public Sub ControlesInicio()
        Panel1.Visible = True
        'txtExpediente.Text = String.Empty
        txtComentarios.Text = String.Empty
        txtGuia.Text = String.Empty
        dateRecibe.SelectedDate = Now()
    End Sub

    Protected Sub ConfigureNotification(ByVal texto As String)
        'String
        'lblError0.Text = texto
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

    Private Sub RegistraScript()
        ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind();", True)

    End Sub

    Public Sub CargarCiaPaqueteria()
        Dim comando As String = "select * from mensajeriaCompañias_tbl order by mensajeria_id "
        csSQLsvr.LlenarRadCombo(cbomensajeria, comando, Session("connGestion"))
    End Sub

    
End Class

Imports System.Data
Imports System.Web
Imports Telerik.Web.UI

Partial Class BackOffice_VerificacionExpedientesBO
    Inherits System.Web.UI.Page
    Dim csNeg As New ClaseNegocios
    Dim csSQLsvr As New BaseDatosSQL
    Dim csDAL As New DALClass
    Dim csBaseGes As New ClaseBaseGestoria
#Region "procesos"
    Public Sub revisaDocumentosVerificados(ByVal noServicio As String, ByVal Tramite_clvTramite As String)
        Dim sGestion As String = noServicio.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Dim ds As New DataSet
        Dim comando As String = "select * from CheckListDocumentosIntegracionExpediente   where chkAutentiificado=0 and  " & _
        " Reporte_anio=" & p_Anio & " and " & _
        " Reporte_cliente=" & p_Cliente & " and " & _
        " Reporte_Tipo=" & p_tipo & " and " & _
        " Reporte_clvEstado=" & p_estado & " and " & _
        " Reporte_Numero=" & p_consec & " and " & _
        " Tramite_clvTramite=" & Tramite_clvTramite
        ds = csSQLsvr.QueryDataSet(comando, Session("connGestion"))
        Dim cuenta As Integer = ds.Tables(0).Rows.Count
        If cuenta = 0 Then
            comando = "update EntregaExpedientesGestoria set EntregaExpediente_Verificado=1,EntregaExpediente_fechaVer=getdate(),EntregaExpediente_usuVer='" & Session("clvUsuario") & "'  where  " & _
        " Reporte_anio=" & p_Anio & " and " & _
        " Reporte_cliente=" & p_Cliente & " and " & _
        " Reporte_Tipo=" & p_tipo & " and " & _
        " Reporte_clvEstado=" & p_estado & " and " & _
        " Reporte_Numero=" & p_consec
            csSQLsvr.EjecutarSP(comando, Session("connGestion"))
        End If


    End Sub


    Public Function verificaRechazados() As Integer
        Dim cuenta As Integer = RadGrid2.Items.Count - 1
        Dim x As Integer = 0
        verificaRechazados = 1
        For x = 0 To cuenta ' revisamos q este toda la información para guardar los datos
            Dim rblAceptado As RadioButtonList = RadGrid2.Items(x).FindControl("rblAcep") ' checamos si esta aceptado o rechazado
            Dim txtObervaciones As TextBox = RadGrid2.Items(x).FindControl("txtObs") ' checamos q este la causa del rechazo.
            Dim cboMtvoRechazo As RadComboBox = RadGrid2.Items(x).FindControl("RadComboBox1")
            If rblAceptado.SelectedValue <> "" Then
                If rblAceptado.SelectedValue = 0 And cboMtvoRechazo.SelectedValue = 1 Then
                    lblError.Text = "Si hay un documento rechazado es necesario dar el motivo de rechazo, no es posible guardar la entrega de documentos.."
                    RadGrid2.Items(x).Cells(10).Text = "Si hay un documento rechazado es necesario dar el motivo de rechazo.."
                    lblError.Text = "Aviso:Si hay un documento rechazado es necesario dar el motivo de rechazo, no es posible guardar la entrega de documentos.."
                    verificaRechazados = 1
                    Exit For
                Else
                    lblError.Text = String.Empty
                    RadGrid2.Items(x).Cells(10).Text = String.Empty
                    verificaRechazados = 0
                End If
            Else
                lblError.Text = "Aviso:Es necesario califar todos los documentos, favor de verificar.."
            End If
        Next
        Return verificaRechazados
    End Function

    Private Sub revisarDocumentosPendientesRecepcion(ByVal noGestion As String)

        Dim dsDocSol As New DataSet
        dsDocSol = csDAL.revisarDocumentosPendientesRecepcionBO(noGestion)
        With RadGrid2
            .DataSource = dsDocSol.Tables(0)
            .DataBind()
        End With

    End Sub

    Private Sub cargaDocumentosSolicitad(ByVal nogestion As String)
        Dim ds As New DataSet
        ds = csDAL.DocumentosSolicitadosBO(nogestion)
        With RadGrid3
            .DataSource = ds.Tables(0)
            .DataBind()
        End With

    End Sub

    Private Sub CargaDocumentosSolicitar2(cliente_clvCliente As Integer, clv_servVeh As Integer, clvEstado As Integer, clvTramite As Integer, tipoPersona As Integer, anioServicio As Integer, consecSer As Integer)
        Dim ds As New DataSet

        Dim comando As String = " exec select_TramitesIntegracionGestion " & cliente_clvCliente & "," & clv_servVeh & "," & clvTramite & "," & tipoPersona & "," & anioServicio & "," & consecSer

        ds = csSQLsvr.QueryDataSet(comando, Session("connGestion"))

        If ds.Tables(0).Rows.Count = 0 Then
            ds.Clear()
            comando = " exec select_TramitesIntegracionGestion " & cliente_clvCliente & "," & clv_servVeh & "," & clvTramite & "," & tipoPersona & "," & anioServicio & "," & consecSer
        End If

        If ds.Tables(0).Rows.Count <> 0 Then

            With RadGrid1
                .DataSource = ds.Tables(0)
                .DataBind()
            End With

        End If

        Dim cuenta As Integer = RadGrid1.Items.Count - 1
        Dim x As Integer = 0

        For x = 0 To cuenta

            Dim Tramite_clvTramite As Integer = RadGrid1.Items(x).Cells(2).Text.Trim
            Dim Tramite_cvlSubTramite As Integer = RadGrid1.Items(x).Cells(3).Text.Trim
            'Dim fechachkSolicitado = Format(Now(), "yyyyMMdd")
            Dim fk_usuario_chkSolicitado As String = Session("clvUsuario")
            Dim Tramite_TipoPersona As Integer = RadGrid1.Items(x).Cells(4).Text.Trim
            Dim Tramite_servVeh As Integer = RadGrid1.Items(x).Cells(5).Text.Trim

            If csDAL.GuardaDocumentosSolicitadoBO(Session("NumGestionControlTerm"), Tramite_clvTramite, Tramite_cvlSubTramite, CStr(Format(Now(), "yyyyMMdd")), fk_usuario_chkSolicitado, Tramite_TipoPersona, Tramite_servVeh) = True Then

                RadGrid1.Items(x).Cells(9).Text = "Documento Solicitado"
                RadGrid1.Items(x).Enabled = False
                RadGrid1.Items(x).BackColor = System.Drawing.ColorTranslator.FromHtml("#6600FF")
                RadGrid1.Items(x).ForeColor = Drawing.Color.White

            End If

        Next

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
                If Trim(dr("Reporte_CiaAsegura")) <> String.Empty Then ' para saber si es moral o fisica
                    Session("tipoPersona") = 2 'moral
                Else
                    Session("tipoPersona") = 1 'fisica
                End If

                If Trim(dr("RFC_Gestor")) = String.Empty Then
                    lblAviso.Text = "El servicio NO tiene gestor asignado, no se realizara la solicitud de pago"
                Else
                    lblAviso.Text = ""
                End If

            Next
        End If
    End Sub
#End Region

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            If Session("NumGestionControlTerm") <> Nothing Then
                buscaServicio(Session("NumGestionControlTerm"))
                Dim sGestion As String = Session("NumGestionControlTerm")
                Dim nLargo As Integer = Len(sGestion)
                Dim p_Anio As String = Mid(sGestion, 1, 4)
                Dim p_Cliente As String = Mid(sGestion, 5, 2)
                Dim p_tipo As String = Mid(sGestion, 7, 2)
                Dim p_estado As String = Mid(sGestion, 9, 2)
                Dim p_consec As String = Mid(sGestion, 11, nLargo)
                Dim tipoVehi As Integer = csDAL.BuscarTipoVehi(Session("NumGestionControlTerm"))
                If tipoVehi <> 1 Then
                    tipoVehi = 1
                End If
                ' este proceso hace la solictud automatica de los documentos para que puedan ser posteriormente revisados y aceptados.
                CargaDocumentosSolicitar2(p_Cliente, tipoVehi, p_estado, p_tipo, Session("tipoPersona"), p_Anio, p_consec)
                ' Este proceso revisa que documentos estan pendientes de recebir por parte de BO
                fechaSol.SelectedDate = Now()  'csDAL.HoraServidor
                revisarDocumentosPendientesRecepcion(Session("NumGestionControlTerm"))
                cargaDocumentosSolicitad(Session("NumGestionControlTerm"))

            End If
        End If
    End Sub

    Protected Sub button_Click(sender As Object, e As System.EventArgs) Handles button.Click
        If verificaRechazados() = 0 Then

            Dim cuenta As Integer = RadGrid2.Items.Count - 1
            Dim x As Integer
            Dim validaErrores As Integer = 0


            Dim cuentaaceptados As Integer = 0
            Dim y As Integer

            For y = 0 To cuenta
                Dim rblAceptado As RadioButtonList = RadGrid2.Items(y).FindControl("rblAcep") ' checamos si esta aceptado o rechazado
                If rblAceptado.SelectedValue = 1 Then
                    cuentaaceptados += 1
                End If
            Next

            'TENGO Q HACER MODIFICACIONES PARA
            If (cuenta + 1) = cuentaaceptados Then

                'realizaModificacionesVerificacion(1)
                Dim lista As New List(Of String)
                lista = csDAL.SolicitudPago(Session("NumGestionControlTerm"), Session("clvUsuario"))
                Dim nombreGestor As String
                Dim COSTO As String

                If Trim(lista.Item(2)) = "" Then
                    ConfigureNotification("No se tiene gestor Asignado.. Favor de Validar")
                    Exit Sub
                End If

                nombreGestor = csDAL.ObtieneNombreGestor(Trim(lista.Item(2)))
                COSTO = lista.Item(4)

                lit.Text = "¿Desea requisitar el pago del gestor: " & nombreGestor & ", por el monto de: $" & COSTO & ".00?"
                ConfigureNotificationSiNo("")

            Else

                realizaModificacionesVerificacion(0)

            End If



        End If

    End Sub



    Protected Sub chkEntregados_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkEntregados.CheckedChanged
        cargaDocumentosSolicitad(Session("NumGestionControlTerm"))
        If chkEntregados.Checked = True Then
            RadGrid3.Visible = True
            RadGrid2.Visible = False
        Else
            RadGrid3.Visible = False
            RadGrid2.Visible = True
        End If
    End Sub

    Protected Sub ConfigureNotification(ByVal texto As String)
        'String
        'lblError0.Text = texto
        RadNotification1.Title = "Atención"
        RadNotification1.Text = texto
        'Enum
        RadNotification1.Position = Telerik.Web.UI.NotificationPosition.Center
        RadNotification1.Animation = Telerik.Web.UI.NotificationAnimation.Fade
        'notificacion.ContentScrolling = Telerik.Web.UI.NotificationScrolling.Default
        RadNotification1.AutoCloseDelay = 50000
        'Unit
        RadNotification1.Width = 300
        RadNotification1.Height = 150
        RadNotification1.OffsetX = -10
        RadNotification1.OffsetY = 10

        RadNotification1.Pinned = False
        RadNotification1.EnableRoundedCorners = True
        RadNotification1.EnableShadow = True
        RadNotification1.KeepOnMouseOver = False
        RadNotification1.VisibleTitlebar = True
        RadNotification1.ShowCloseButton = True

        RadNotification1.Show()

    End Sub

    Protected Sub ConfigureNotificationSiNo(ByVal texto As String)
        'String
        'lblError0.Text = texto
        RadNotification2.Title = "Atención"
        RadNotification2.Text = texto
        'Enum
        RadNotification2.Position = Telerik.Web.UI.NotificationPosition.Center
        RadNotification2.Animation = Telerik.Web.UI.NotificationAnimation.Fade
        RadNotification2.ContentScrolling = Telerik.Web.UI.NotificationScrolling.Default
        RadNotification2.AutoCloseDelay = 50000
        'Unit
        RadNotification1.Width = 300
        RadNotification2.Height = 150
        RadNotification1.OffsetX = -10
        RadNotification1.OffsetY = 10

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

    Protected Sub btnAceptar_Click(sender As Object, e As System.EventArgs) Handles btnAceptar.Click
        realizaModificacionesVerificacion(1)
        RadNotification2.AutoCloseDelay = 0
    End Sub

    Protected Sub btnRechazar_Click(sender As Object, e As System.EventArgs) Handles btnRechazar.Click
        ConfigureNotification("No se realiza la solicitud de pago, favor de verificar.")
        RegistraScript()
    End Sub

    Public Sub realizaModificacionesVerificacion(tipo As Integer)
        Dim cuenta As Integer = RadGrid2.Items.Count - 1
        Dim x As Integer
        Dim validaErrores As Integer = 0

        Dim noGEstion As String = Session("NumGestionControlTerm")
        Dim sGestion As String = noGEstion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)

        'If csDAL.ValidaComprobacionPagoDerechos(Session("NumGestionControlTerm")) = True Then

        If csDAL.ValidaFondoEntrada(Session("NumGestionControlTerm")) = True Then
            If csDAL.ValidaRegistroFondoSalida(Session("NumGestionControlTerm")) = True Then
                If csDAL.ValidaCompobacionFondoSalida(Session("NumGestionControlTerm")) = False Then
                    ConfigureNotification("No se ha comprobado el pago de derechos, por lo que no se puede solicitar la requisicion de pago de honorarios del gesto asignado")
                    Exit Sub
                    'RegistraScript()
                End If
            End If
        End If

        For x = 0 To cuenta
            Dim rblAceptado As RadioButtonList = RadGrid2.Items(x).FindControl("rblAcep") ' checamos si esta aceptado o rechazado
            Dim txtOberv As TextBox = RadGrid2.Items(x).FindControl("txtObs")
            Dim cboMtvoRechazo As RadComboBox = RadGrid2.Items(x).FindControl("RadComboBox1")

            Dim Tramite_clvTramite As Integer = CInt(RadGrid2.Items(x).Cells(2).Text.Trim)
            ' RadGrid2.Items(x).Cells(2).Text.Trim
            Dim Tramite_cvlSubTramite As Integer = RadGrid2.Items(x).Cells(3).Text.Trim
            Dim consec As Integer = RadGrid2.Items(x).Cells(4).Text.Trim
            Dim fechachkSolicitado = Format(fechaSol.SelectedDate, "yyyyMMdd")
            Dim fk_usuario_chkSolicitado As String = Session("clvUsuario")
            Dim tramDescrip As String = RadGrid2.Items(x).Cells(5).Text.Trim
            Dim tramDoc As String = RadGrid2.Items(x).Cells(6).Text.Trim
            Dim MotivoRecha As String = cboMtvoRechazo.SelectedItem.Text
            Dim causaRecha As String = txtOberv.Text.Trim.ToUpper

            If rblAceptado.SelectedValue <> "" Then
                If rblAceptado.SelectedValue = 1 Then
                    If csDAL.DocumentosExpedienteGestionAceptadosBOTermino(Session("NumGestionControlTerm"), Tramite_clvTramite, Tramite_cvlSubTramite, fechachkSolicitado, fk_usuario_chkSolicitado, causaRecha, MotivoRecha, consec) Then
                        RadGrid2.Items(x).Cells(10).Text = "El documento ha sido guardado como aceptado.."
                        RadGrid2.Items(x).Enabled = False
                        RadGrid2.Items(x).BackColor = System.Drawing.ColorTranslator.FromHtml("#6600FF")
                        RadGrid2.Items(x).ForeColor = Drawing.Color.White
                        For Each li As ListItem In rblAceptado.Items
                            li.Selected = False
                        Next
                        revisaDocumentosVerificados(Session("NumGestionControlTerm"), Tramite_clvTramite)
                        'Hacer funcion para q valide q todo fue aceptado



                    Else
                        RadGrid2.Items(x).Cells(10).Text = "Error al marcar el documento como entregado..vuelva a intentarlo.."
                    End If

                Else

                    If csDAL.TerminoDocumentosExpedienteGestionRechazadosBO(Session("NumGestionControlTerm"), tramDescrip, tramDoc, fk_usuario_chkSolicitado, MotivoRecha, fechaSol.SelectedDate) = True Then

                        RadGrid2.Items(x).Cells(10).Text = "Documento Rechazado.."
                        RadGrid2.Items(x).Enabled = False
                        RadGrid2.Items(x).BackColor = Drawing.Color.DarkRed
                        RadGrid2.Items(x).ForeColor = Drawing.Color.White

                        For Each li As ListItem In rblAceptado.Items
                            li.Selected = False
                        Next

                        validaErrores += 1

                    Else

                        RadGrid2.Items(x).Cells(10).Text = "Error al marcar el documento como rechazado..vuelva a intentarlo.."

                    End If

                End If
            Else
                ConfigureNotification("Es necesario calificar todos los documentos. Favor de validar..")
            End If

        Next
        If validaErrores > 0 Then
            Dim msgError As String = csDAL.RegresoSeguimiento(Session("NumGestionControlTerm"))
            If msgError <> "" Then
                ConfigureNotification(msgError)
            Else
                RegistraScript()
            End If
        End If



        If tipo = 1 Then

            If csDAL.ValidaExpedienteVerificado(Session("NumGestionControlTerm")) = True Then

                If lblAviso.Text Is String.Empty Then

                    If csDAL.Verifica_pagosGestor(Session("NumGestionControlTerm")) = True Then
                        If csDAL.CargaPagoGestor(Session("NumGestionControlTerm"), Session("clvUsuario")) = True Then
                            ConfigureNotification("Se solicito exitosamente el pago de honorarios del gestor asignado")
                            RegistraScript()
                        Else
                            ConfigureNotification("No existe gestor asignado")
                            RegistraScript()
                        End If
                    Else
                        ConfigureNotification("Ya existe un pago registrado para este servicio, Favor de validar")
                        RegistraScript()
                    End If

                Else

                    ConfigureNotification("No existe gestor asignado")

                End If

            Else

                ConfigureNotification("existen documentos rechazados, favor de validar {0} ")
                RegistraScript()

            End If
        End If
        'Else

        '    ConfigureNotification("No se ha comprobado el pago de derechos, por lo que no se puede solicitar la requisicion de pago de honorarios del gesto asignado")
        '    RegistraScript()
        'End If
        RegistraScript()
    End Sub

    Protected Sub btnSinCosto_Click(sender As Object, e As System.EventArgs) Handles btnSinCosto.Click

        realizaModificacionesVerificacion(0)
        RadNotification2.AutoCloseDelay = 0

    End Sub
End Class

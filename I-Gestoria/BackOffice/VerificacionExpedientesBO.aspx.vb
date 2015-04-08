Imports System.Data
Imports System.Web

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
            If rblAceptado.SelectedValue = 0 And txtObervaciones.Text.Trim = String.Empty Then
                lblError.Text = "Si hay un documento rechazado es necesario dar las obervaciones, no es posible guardar la entrega de documentos.."
                RadGrid2.Items(x).Cells(9).Text = "Si hay un documento rechazado es necesario dar las obervaciones.."
                lblError.Text = "Aviso:Si hay un documento rechazado es necesario dar las observaciones, no es posible guardar la entrega de documentos.."
                verificaRechazados = 1
                Exit For
            Else
                lblError.Text = String.Empty
                RadGrid2.Items(x).Cells(9).Text = String.Empty
                verificaRechazados = 0
            End If
        Next
        Return verificaRechazados
    End Function
    Private Sub revisarDocumentosPendientesRecepcion(noGestion As String)
        Dim dsDocSol As New DataSet
        dsDocSol = csDAL.revisarDocumentosPendientesRecepcionBO(noGestion)
        With RadGrid2
            .DataSource = dsDocSol.Tables(0)
            .DataBind()
        End With


    End Sub


    Private Sub cargaDocumentosSolicitad(nogestion As String)
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
            If csDAL.GuardaDocumentosSolicitadoBO(Session("noGestionIntegral"), Tramite_clvTramite, Tramite_cvlSubTramite, CStr(Format(Now(), "yyyyMMdd")), fk_usuario_chkSolicitado, Tramite_TipoPersona, Tramite_servVeh) = True Then
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
            Next
        End If
    End Sub
#End Region

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Session("noGestionIntegral") = Request.QueryString("nogestion")

            If Session("noGestionIntegral") <> Nothing Then
                buscaServicio(Session("noGestionIntegral"))
                Dim sGestion As String = Session("noGestionIntegral")
                Dim nLargo As Integer = Len(sGestion)
                Dim p_Anio As String = Mid(sGestion, 1, 4)
                Dim p_Cliente As String = Mid(sGestion, 5, 2)
                Dim p_tipo As String = Mid(sGestion, 7, 2)
                Dim p_estado As String = Mid(sGestion, 9, 2)
                Dim p_consec As String = Mid(sGestion, 11, nLargo)
                Dim tipoVehi As Integer = csDAL.BuscarTipoVehi(Session("noGestionIntegral"))
                If tipoVehi <> 1 Then
                    tipoVehi = 1
                End If
                ' este proceso hace la solictud automatica de los documentos para que puedan ser posteriormente revisados y aceptados.
                CargaDocumentosSolicitar2(p_Cliente, tipoVehi, p_estado, p_tipo, Session("tipoPersona"), p_Anio, p_consec)
                ' Este proceso revisa que documentos estan pendientes de recebir por parte de BO
                fechaSol.SelectedDate = Now()  'csDAL.HoraServidor
                revisarDocumentosPendientesRecepcion(Session("noGestionIntegral"))
                cargaDocumentosSolicitad(Session("noGestionIntegral"))


                
            End If
        End If
    End Sub

    Protected Sub button_Click(sender As Object, e As System.EventArgs) Handles button.Click
        If verificaRechazados() = 0 Then

            Dim cuenta As Integer = RadGrid2.Items.Count - 1
            Dim x As Integer

            For x = 0 To cuenta
                Dim rblAceptado As RadioButtonList = RadGrid2.Items(x).FindControl("rblAcep") ' checamos si esta aceptado o rechazado
                Dim txtOberv As TextBox = RadGrid2.Items(x).FindControl("txtObs")

                Dim Tramite_clvTramite As Integer = RadGrid2.Items(x).Cells(2).Text.Trim
                Dim Tramite_cvlSubTramite As Integer = RadGrid2.Items(x).Cells(3).Text.Trim
                Dim consec As Integer = RadGrid2.Items(x).Cells(4).Text.Trim
                Dim fechachkSolicitado = Format(fechaSol.SelectedDate, "yyyyMMdd")
                Dim fk_usuario_chkSolicitado As String = Session("clvUsuario")
                Dim tramDescrip As String = RadGrid2.Items(x).Cells(5).Text.Trim
                Dim tramDoc As String = RadGrid2.Items(x).Cells(6).Text.Trim
                Dim causaRecha As String = txtOberv.Text.Trim.ToUpper


                If rblAceptado.SelectedValue = 1 Then

                    If csDAL.DocumentosExpedienteGestionAceptadosBO(Session("noGestionIntegral"), Tramite_clvTramite, Tramite_cvlSubTramite, fechachkSolicitado, fk_usuario_chkSolicitado, causaRecha, consec) Then
                        RadGrid2.Items(x).Cells(9).Text = "El documento ha sido guardado como aceptado.."
                        RadGrid2.Items(x).Enabled = False
                        RadGrid2.Items(x).BackColor = System.Drawing.ColorTranslator.FromHtml("#6600FF")
                        RadGrid2.Items(x).ForeColor = Drawing.Color.White
                        For Each li As ListItem In rblAceptado.Items
                            li.Selected = False
                        Next
                        revisaDocumentosVerificados(Session("noGestionIntegral"), Tramite_clvTramite)
                    Else
                        RadGrid2.Items(x).Cells(9).Text = "Error al marcar el documento como entregado..vuelva a intentarlo.."
                    End If

                Else
                    If csDAL.DocumentosExpedienteGestionRechazadosBO(Session("noGestionIntegral"), tramDescrip, tramDoc, fk_usuario_chkSolicitado, causaRecha) = True Then
                        RadGrid2.Items(x).Cells(9).Text = "Documento Rechazado.."
                        RadGrid2.Items(x).Enabled = False
                        RadGrid2.Items(x).BackColor = Drawing.Color.DarkRed
                        RadGrid2.Items(x).ForeColor = Drawing.Color.White
                        For Each li As ListItem In rblAceptado.Items
                            li.Selected = False
                        Next
                    Else
                        RadGrid2.Items(x).Cells(9).Text = "Error al marcar el documento como rechazado..vuelva a intentarlo.."
                    End If
                End If


            Next
        End If
    End Sub

    Protected Sub chkEntregados_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkEntregados.CheckedChanged
        cargaDocumentosSolicitad(Session("noGestionIntegral"))
        If chkEntregados.Checked = True Then
            RadGrid3.Visible = True
            RadGrid2.Visible = False
          
        Else
            RadGrid3.Visible = False
            RadGrid2.Visible = True

        End If
    End Sub
End Class

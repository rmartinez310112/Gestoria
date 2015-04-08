Imports System.Data
Imports System.Web
Partial Class GestionDocumentos_SolicitudDocumentosGestion
Inherits System.Web.UI.Page
    Dim csNeg As New ClaseNegocios
    Dim csSQLsvr As New BaseDatosSQL
    Dim csDAL As New DALClass
    #Region "procesos"

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
    Private Sub RevisaDocumentosYaCargados()
        Dim cuenta As Integer = RadGrid1.Items.Count - 1
        Dim x As Integer = 0
        For x = 0 To cuenta

            Dim Tramite_clvTramite As Integer = RadGrid1.Items(x).Cells(2).Text.Trim
            Dim Tramite_cvlSubTramite As Integer = RadGrid1.Items(x).Cells(3).Text.Trim
            Dim Tramite_TipoPersona As Integer = RadGrid1.Items(x).Cells(4).Text.Trim
            Dim Tramite_servVeh As Integer = RadGrid1.Items(x).Cells(5).Text.Trim
            If csDAL.buscaDocumentosGestionAsignadosTramite(Session("noGestionIntegral"), Tramite_clvTramite, Tramite_cvlSubTramite, Tramite_TipoPersona, Tramite_servVeh) = 1 Then
                RadGrid1.Items(x).Display = False
            End If
        Next
      
    End Sub

    Private Sub ChecarDocumentosSolicitados(noGestion As String)
        Dim dsDocSol As New DataSet
        dsDocSol = csDAL.ChecarDocumentosSolicitados(noGestion)
        Dim dr As DataRow
        For Each dr In dsDocSol.Tables(0).Rows
            Dim Tramite_clvTramite As Integer = dr("Tramite_clvTramite")
            Dim Tramite_cvlSubTramite As Integer = dr("Tramite_cvlSubTramite")

            Dim cuenta As Integer = RadGrid1.Items.Count - 1
            Dim x As Integer = 0
            For x = 0 To cuenta
                If RadGrid1.Items(x).Cells(2).Text.Trim = Tramite_clvTramite And RadGrid1.Items(x).Cells(3).Text.Trim = Tramite_cvlSubTramite Then
                    RadGrid1.Items(x).Display = False
                End If
            Next

        Next

    End Sub

    Private Sub RevisarDocumentos(noGestion As String)
        Dim dsDocSol As New DataSet
        dsDocSol = csDAL.revisarDocumentos(noGestion)
            With RadGrid2
            .DataSource = dsDocSol.Tables(0)
            .DataBind()
        End With
    End Sub

    Private Sub cargaComboDocumentos(tipoSer As Integer, clvCliente As Integer)
        Dim dsDoc As New DataSet
        dsDoc = csDAL.BuscaListaDocumentos(tipoSer, clvCliente)
            With cboTipo
            .DataSource = dsDoc.Tables(0)
            .DataTextField = dsDoc.Tables(0).Columns(1).Caption.ToString
            .DataValueField = dsDoc.Tables(0).Columns(0).Caption.ToString
            .DataBind()
        End With
        dsDoc.Clear()

    End Sub

    Private Sub CargaDocumentosSolicitar(clvEstado As Integer, clvTramite As Integer, tipoPersona As Integer)
        Dim ds As New DataSet
        Dim comando As String = " exec select_TramitesXEstadoGestion " & clvEstado & "," & clvTramite & "," & tipoPersona
        ds = csSQLsvr.QueryDataSet(comando, Session("connGestion"))
        If ds.Tables(0).Rows.Count = 0 Then
            ds.Clear()
            comando = " exec select_TramitesXEstadoGestionTodos " & clvTramite & "," & tipoPersona
            ds = csSQLsvr.QueryDataSet(comando, Session("connGestion"))
        End If
        If ds.Tables(0).Rows.Count <> 0 Then
                With RadGrid1
                .DataSource = ds.Tables(0)
                .DataBind()
            End With
        End If

        ChecarDocumentosSolicitados(Session("noGestionIntegral"))
    End Sub

    Private Sub CargaDocumentosSolicitar2(cliente_clvCliente As Integer, clv_servVeh As Integer, clvEstado As Integer, clvTramite As Integer, tipoPersona As Integer, anioServicio As Integer, consecSer As Integer)
        Dim ds As New DataSet
        Dim comando As String = " exec select_TramitesXEstadoGestion2 " & cliente_clvCliente & "," & clv_servVeh & "," & clvEstado & "," & clvTramite & "," & tipoPersona & "," & anioServicio & "," & consecSer
        ds = csSQLsvr.QueryDataSet(comando, Session("connGestion"))
        If ds.Tables(0).Rows.Count = 0 Then
            ds.Clear()
            comando = " exec select_TramitesXEstadoGestionTodos2 " & cliente_clvCliente & "," & clv_servVeh & "," & clvTramite & "," & tipoPersona & "," & anioServicio & "," & consecSer
        End If
        If ds.Tables(0).Rows.Count <> 0 Then
            With RadGrid1
                .DataSource = ds.Tables(0)
                .DataBind()
            End With
        End If

        ChecarDocumentosSolicitados(Session("noGestionIntegral"))
    End Sub

    #End Region

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Session("noGestionIntegral") <> Nothing Then
                Dim sGestion As String = Session("noGestionIntegral")
                Dim nLargo As Integer = Len(sGestion)
                Dim p_Anio As String = Mid(sGestion, 1, 4)
                Dim p_Cliente As String = Mid(sGestion, 5, 2)
                Dim p_tipo As String = Mid(sGestion, 7, 2)
                Dim p_estado As String = Mid(sGestion, 9, 2)
                Dim p_consec As String = Mid(sGestion, 11, nLargo)


                cargaComboDocumentos(p_tipo, p_Cliente)
                RevisarDocumentos(Session("noGestionIntegral"))
                Panel1.Visible = False
                Panel2.Visible = False
                button2.Visible = False
                Label9.Visible = False
            Else
                ConfigureNotification("Favor de Introducir No.Gestion")
                Panel1.Visible = False
                Panel2.Visible = False
                button2.Visible = False
                Label9.Visible = False
            End If
        End If
    End Sub

    'Protected Sub RadButton1_Click(sender As Object, e As System.EventArgs) Handles RadButton1.Click

    '    ' Descomponemos el No. de gestion para saber de que tipo es
    '    Dim sGestion As String = Session("noGestionIntegral")
    '    Dim nLargo As Integer = Len(sGestion)
    '    Dim p_Anio As String = Mid(sGestion, 1, 4)
    '    Dim p_Cliente As String = Mid(sGestion, 5, 2)
    '    Dim p_tipo As String = Mid(sGestion, 7, 2)
    '    Dim p_estado As String = Mid(sGestion, 9, 2)
    '    Dim p_consec As String = Mid(sGestion, 11, nLargo)
    '    Dim tipoVehi As Integer = csDAL.BuscarTipoVehi(Session("noGestionIntegral"))


    '    CargaDocumentosSolicitar2(p_Cliente, tipoVehi, p_estado, cboTipo.SelectedValue, Session("tipoPersona"))
    '    RevisaDocumentosYaCargados()
    'End Sub

    'Protected Sub RadButton2_Click(sender As Object, e As System.EventArgs) Handles RadButton2.Click
    '    Dim cuenta As Integer = RadGrid1.Items.Count - 1
    '    Dim x As Integer = 0
    '    For x = 0 To cuenta
    '        Dim chkSoli As CheckBox = RadGrid1.Items(x).FindControl("chkSol")
    '        Dim Tramite_clvTramite As Integer = RadGrid1.Items(x).Cells(2).Text.Trim
    '        Dim Tramite_cvlSubTramite As Integer = RadGrid1.Items(x).Cells(3).Text.Trim
    '        Dim fechachkSolicitado = Format(fechaSol.SelectedDate, "yyyyMMdd")
    '        Dim fk_usuario_chkSolicitado As String = Session("clvUsuario")
    '        Dim Tramite_TipoPersona As Integer = RadGrid1.Items(x).Cells(4).Text.Trim
    '        Dim Tramite_servVeh As Integer = RadGrid1.Items(x).Cells(5).Text.Trim

    '        If chkSoli.Checked = True Then

    '            If csDAL.GuardaDocumentosSolicitado(Session("noGestionIntegral"), Tramite_clvTramite, Tramite_cvlSubTramite, fechachkSolicitado, fk_usuario_chkSolicitado, Tramite_TipoPersona, Tramite_servVeh) = True Then
    '                RadGrid1.Items(x).Cells(9).Text = "Documento Solicitado"
    '                chkSoli.Checked = False
    '                RadGrid1.Items(x).Enabled = False
    '                RadGrid1.Items(x).BackColor = System.Drawing.ColorTranslator.FromHtml("#6600FF")
    '                RadGrid1.Items(x).ForeColor = Drawing.Color.White
    '            Else
    '                RadGrid1.Items(x).Cells(9).Text = "Error al guardar la Solicitud"
    '            End If
    '        End If
    '    Next

    '    RevisarDocumentos(Session("noGestionIntegral"))
    'End Sub

    Protected Sub chkEntregados_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkEntregados.CheckedChanged
        If chkEntregados.Checked = True Then
            RevisarDocumentos(Session("noGestionIntegral"))
            RadGrid2.Visible = True
            Panel1.Visible = False
            RadGrid1.Visible = False
            Label9.Visible = False
            button2.Visible = False
            If RadGrid2.Items.Count - 1 > 0 Then
                RadGrid2.Visible = True
                Panel2.Visible = True
            Else
                RadGrid2.Visible = False
            End If
        Else
            RadGrid2.Visible = False
            Panel2.Visible = False
        End If
    End Sub

    Protected Sub button12_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles button12.Click
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

        CargaDocumentosSolicitar2(p_Cliente, tipoVehi, p_estado, cboTipo.SelectedValue, Session("tipoPersona"), p_Anio, p_consec)

        RevisaDocumentosYaCargados()
        Panel1.Visible = True
        RadGrid1.Visible = True
        button2.Visible = True
        Label9.Visible = True
    End Sub

    Protected Sub button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles button2.Click
        Dim cuenta As Integer = RadGrid1.Items.Count - 1
        Dim x As Integer = 0
        For x = 0 To cuenta
            Dim chkSoli As CheckBox = RadGrid1.Items(x).FindControl("chkSol")
            Dim Tramite_clvTramite As Integer = RadGrid1.Items(x).Cells(2).Text.Trim
            Dim Tramite_cvlSubTramite As Integer = RadGrid1.Items(x).Cells(3).Text.Trim
            'Dim fechachkSolicitado = Format(Now(), "yyyyMMdd")
            Dim fk_usuario_chkSolicitado As String = Session("clvUsuario")
            Dim Tramite_TipoPersona As Integer = RadGrid1.Items(x).Cells(4).Text.Trim
            Dim Tramite_servVeh As Integer = RadGrid1.Items(x).Cells(5).Text.Trim

            If chkSoli.Checked = True Then

                If csDAL.GuardaDocumentosSolicitado(Session("noGestionIntegral"), Tramite_clvTramite, Tramite_cvlSubTramite, CStr(Format(Now(), "yyyyMMdd")), fk_usuario_chkSolicitado, Tramite_TipoPersona, Tramite_servVeh) = True Then
                    RadGrid1.Items(x).Cells(9).Text = "Documento Solicitado"
                    chkSoli.Checked = False
                    RadGrid1.Items(x).Enabled = False
                    RadGrid1.Items(x).BackColor = System.Drawing.ColorTranslator.FromHtml("#6600FF")
                    RadGrid1.Items(x).ForeColor = Drawing.Color.White
                Else
                    RadGrid1.Items(x).Cells(9).Text = "Error al guardar la Solicitud"
                End If
            End If
        Next

        RevisarDocumentos(Session("noGestionIntegral"))
    End Sub
End Class

Imports System.Data
Imports System.Web
Partial Class GestionDocumentos_EntregaDocumentosGestor
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
    Private Sub cargaDocumentosSolicitad(nogestion As String)
        Dim ds As New DataSet
        ds = csDAL.DocumentosEntregadosGestor(nogestion)
            With RadGrid2
            .DataSource = ds.Tables(0)
            .DataBind()
        End With

    End Sub

    Private Sub CargaDocumentosPEndientesEntregar(nogestion As String)
        Dim ds As New DataSet
        ds = csDAL.revisarDocumentosPendientesEntregaGestor(nogestion)
            With RadGrid1
            .DataSource = ds.Tables(0)
            .DataBind()
        End With

    End Sub
    #End Region

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Session("noGestionIntegral") <> Nothing Then
                fechaSol.SelectedDate = Now()
                'csDAL.HoraServidor
                CargaDocumentosPEndientesEntregar(Session("noGestionIntegral"))
                cargaDocumentosSolicitad(Session("noGestionIntegral"))
                Panel1.Visible = True
            Else
                ConfigureNotification("Favor de Introducir No.Gestion")
            End If
        End If
    End Sub

    'Protected Sub RadButton2_Click(sender As Object, e As System.EventArgs) Handles RadButton2.Click
    '    Dim cuenta As Integer = RadGrid1.Items.Count - 1
    '    Dim x As Integer = 0
    '    For x = 0 To cuenta
    '        Dim chkSoli As CheckBox = RadGrid1.Items(x).FindControl("chkRev")
    '        Dim Tramite_clvTramite As Integer = RadGrid1.Items(x).Cells(2).Text.Trim
    '        Dim Tramite_cvlSubTramite As Integer = RadGrid1.Items(x).Cells(3).Text.Trim
    '        Dim consecDoc As Integer = RadGrid1.Items(x).Cells(4).Text.Trim

    '        Dim fechachkSolicitado = Format(fechaSol.SelectedDate, "yyyyMMdd")
    '        Dim fk_usuario_chkSolicitado As String = Session("clvUsuario")
    '        Dim txtObervaciones As Telerik.Web.UI.RadTextBox = RadGrid1.Items(x).FindControl("txtobs")
    '        Dim tipoEntrega As Integer = rblTipoEntrega.SelectedValue
    '        If chkSoli.Checked = True Then

    '            If csDAL.DocumentosEntregadosGestor(Session("noGestionIntegral"), Tramite_clvTramite, Tramite_cvlSubTramite, fechachkSolicitado, fk_usuario_chkSolicitado, txtObervaciones.Text.Trim, tipoEntrega, consecDoc) = True Then
    '                RadGrid1.Items(x).Cells(9).Text = "Documento Entregado"
    '                chkSoli.Checked = False
    '                RadGrid1.Items(x).Enabled = False
    '                RadGrid1.Items(x).BackColor = System.Drawing.ColorTranslator.FromHtml("#6600FF")
    '                RadGrid1.Items(x).ForeColor = Drawing.Color.White
    '            Else
    '                RadGrid1.Items(x).Cells(9).Text = "Error al guardar el registro"
    '            End If
    '        End If
    '    Next
    'End Sub

    Protected Sub chkEntregados_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkEntregados.CheckedChanged
        'DocumentosEntregadosGestor
        cargaDocumentosSolicitad(Session("noGestionIntegral"))
        If chkEntregados.Checked = True Then
            RadGrid2.Visible = True
            Panel2.Visible = True
            Panel1.Visible = False
            RadGrid1.Visible = False
            Label8.Visible = False
            Label9.Visible = False
            rblTipoEntrega.Visible = False
            button1.Visible = False
        Else
            RadGrid2.Visible = False
            Panel2.Visible = False
            Panel1.Visible = True
            RadGrid1.Visible = True
            Label8.Visible = True
            Label9.Visible = True
            rblTipoEntrega.Visible = True
            button1.Visible = True
        End If
    End Sub

    Protected Sub button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles button1.Click
        Dim cuenta As Integer = RadGrid1.Items.Count - 1
        Dim x As Integer = 0
        For x = 0 To cuenta
            Dim chkSoli As CheckBox = RadGrid1.Items(x).FindControl("chkRev")
            Dim Tramite_clvTramite As Integer = RadGrid1.Items(x).Cells(2).Text.Trim
            Dim Tramite_cvlSubTramite As Integer = RadGrid1.Items(x).Cells(3).Text.Trim
            Dim consecDoc As Integer = RadGrid1.Items(x).Cells(4).Text.Trim

            Dim fechachkSolicitado = Format(fechaSol.SelectedDate, "yyyyMMdd")
            Dim fk_usuario_chkSolicitado As String = Session("clvUsuario")
            Dim txtObervaciones As Telerik.Web.UI.RadTextBox = RadGrid1.Items(x).FindControl("txtobs")
            Dim tipoEntrega As Integer = rblTipoEntrega.SelectedValue
            If chkSoli.Checked = True Then

                If csDAL.DocumentosEntregadosGestor(Session("noGestionIntegral"), Tramite_clvTramite, Tramite_cvlSubTramite, fechachkSolicitado, fk_usuario_chkSolicitado, txtObervaciones.Text.Trim, tipoEntrega, consecDoc) = True Then
                    RadGrid1.Items(x).Cells(9).Text = "Documento Entregado"
                    chkSoli.Checked = False
                    RadGrid1.Items(x).Enabled = False
                    RadGrid1.Items(x).BackColor = System.Drawing.ColorTranslator.FromHtml("#6600FF")
                    RadGrid1.Items(x).ForeColor = Drawing.Color.White
                Else
                    RadGrid1.Items(x).Cells(9).Text = "Error al guardar el registro"
                End If
            End If
        Next
    End Sub
End Class

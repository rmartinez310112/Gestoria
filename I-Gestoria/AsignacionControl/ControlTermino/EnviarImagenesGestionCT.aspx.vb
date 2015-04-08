Imports System.Data
Imports System.Web

Partial Class GestionDocumentos_EnviarImagenesGestion
Inherits System.Web.UI.Page
    Dim csNeg As New ClaseNegocios
    Dim csSQLsvr As New BaseDatosSQL
    Dim csDAL As New DALClass
    Dim VentanasWin As New Ventanas
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
    Public Sub ABRIR_VENTANA(ByVal PopUpWindowPage As String, ByVal alto As Integer, ByVal largo As Integer)
        Dim Script As String = ""
        Script = " <script language=JavaScript id='PopupWindow'>  var confirmWin = null; confirmWin = window.open('" & PopUpWindowPage & "','myWindow','status = 1, scrollbars=1,height = " & alto & ", width = " & largo & ", resizable = 1 '); if((confirmWin != null) && (confirmWin.opener==null)) { confirmWin.opener = self; } </script> "
        If Not ClientScript.IsStartupScriptRegistered("PopupWindow") Then
            ClientScript.RegisterStartupScript(Me.GetType, "PopupWindow", Script)
        End If
    End Sub

  
    Private Sub cargaDocumentosSolicitad(nogestion As String)
        Dim ds As New DataSet
        ds = csDAL.DocumentosSolicitados(nogestion)
            With RadGrid1
            .DataSource = ds.Tables(0)
            .DataBind()
        End With
        Dim cuenta As Integer = RadGrid1.Items.Count - 1
        Dim x As Integer = 0
        For x = 0 To cuenta

            Dim Tramite_clvTramite As Integer = RadGrid1.Items(x).Cells(2).Text.Trim
            'ds.Tables(0).Rows(x).Item(2).ToString.Trim
            'RadGrid1.Items(x).Cells(2).Text.Trim
            Dim Tramite_cvlSubTramite As Integer = RadGrid1.Items(x).Cells(3).Text.Trim

            If csDAL.RevisaRegImagenes(Session("NumGestionControlTerm"), Tramite_clvTramite, Tramite_cvlSubTramite) > 0 Then
                RadGrid1.Items(x).BackColor = System.Drawing.ColorTranslator.FromHtml("#5882FA")
                'RadGrid1.Items(x).ForeColor = Drawing.Color.White
            End If

        Next
    End Sub

    #End Region
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        VentanasWin = New Ventanas(Master)
        RadGrid1.Visible = False
        LinkButton1.Visible = False
        LinkButton2.Visible = False
        If Not Page.IsPostBack Then
            If Session("NumGestionControlTerm") <> Nothing Then
                cargaDocumentosSolicitad(Session("NumGestionControlTerm"))
                Panel1.Visible = True
            Else
                ConfigureNotification("Favor de Introducir No.Gestion")
            End If
        End If
    End Sub
    Protected Sub RadGrid1_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand

        Dim Tramite_clvTramite As Integer = e.Item.Cells(2).Text.Trim
        Dim Tramite_cvlSubTramite As Integer = e.Item.Cells(3).Text.Trim
        Dim Tramite_TipoPersona As Integer = e.Item.Cells(4).Text.Trim
        Dim Tramite_servVeh As Integer = e.Item.Cells(5).Text.Trim
        Dim consec As Integer = e.Item.Cells(6).Text.Trim

        If e.CommandName = "cmdEnviar" Then
            'Dim window As New Telerik.Web.UI.RadWindow
            Session("Tramite_clvTramiteCT") = Tramite_clvTramite
            Session("Tramite_cvlSubTramiteCT") = Tramite_cvlSubTramite
            Session("Tramite_TipoPersonaCT") = Tramite_TipoPersona
            Session("Tramite_servVehCT") = Tramite_servVeh
            Session("consecCT") = consec
            'VentanasWin.Abrir_winwinCargaImg()
            'CargaImagenGestionPDF.aspx
            ABRIR_VENTANA("CargaImagenGestion.aspx?Tramite_clvTramite=" & Tramite_clvTramite & "&Tramite_cvlSubTramite=" & Tramite_cvlSubTramite & "&Tramite_TipoPersona=" & Tramite_TipoPersona & "&Tramite_servVeh=" & Tramite_servVeh & "&consec=" & consec, 800, 600)

            '    With window
            '    .NavigateUrl = "CargaImagenGestion.aspx?Tramite_clvTramite=" & Tramite_clvTramite & "&Tramite_cvlSubTramite=" & Tramite_cvlSubTramite & "&Tramite_TipoPersona=" & Tramite_TipoPersona & "&Tramite_servVeh=" & Tramite_servVeh & "&consec=" & consec
            '    .VisibleOnPageLoad = True
            '    .ID = "RadWindow1"
            '    .Width = 850
            '    .Height = 600
            '    .Modal = True
            '    RadWindowManager1.Windows.Add(window)

            'End With
            'Me.Page.Dispose()

        End If

    End Sub
    'Protected Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand

    '    Dim Tramite_clvTramite As Integer = e.Item.Cells(2).Text.Trim
    '    Dim Tramite_cvlSubTramite As Integer = e.Item.Cells(3).Text.Trim
    '    Dim Tramite_TipoPersona As Integer = e.Item.Cells(4).Text.Trim
    '    Dim Tramite_servVeh As Integer = e.Item.Cells(5).Text.Trim
    '    Dim consec As Integer = e.Item.Cells(6).Text.Trim

    '    If e.CommandName = "cmdEnviar" Then


    '        ABRIR_VENTANA("CargaImagenGestion.aspx?Tramite_clvTramite=" & Tramite_clvTramite & "&Tramite_cvlSubTramite=" & Tramite_cvlSubTramite & "&consec=" & consec & "&Tramite_TipoPersona=" & Tramite_TipoPersona & "&Tramite_servVeh=" & Tramite_servVeh, 600, 800)


    '        'Dim window1 As New Telerik.Web.UI.RadWindow
    '        'window1.NavigateUrl = "CargaImagenGestion.aspx?Tramite_clvTramite=" & e.Item.Cells(2).Text & "&Tramite_cvlSubTramite=" & e.Item.Cells(3).Text
    '        'window1.VisibleOnPageLoad = True
    '        'window1.ID = "RadWindow1"
    '        'window1.Width = 800
    '        'window1.Height = 600
    '        'window1.Modal = True
    '        'window1.ReloadOnShow = True
    '        'window1.DestroyOnClose = False
    '        'window1.EnableViewState = False
    '        'RadWindowManager1.Windows.Add(window1)
    '        '' Response.Redirect("EnviarImagenDocumentosGestion.aspx")


    '    End If

    '    If e.CommandName = "cmdVer" Then

    '        ABRIR_VENTANA("VerImagenesGestion.aspx?Tramite_clvTramite=" & e.Item.Cells(2).Text & "&Tramite_cvlSubTramite=" & e.Item.Cells(3).Text & "&Tramite_TipoPersona=" & Tramite_TipoPersona & "&Tramite_servVeh=" & Tramite_servVeh, 600, 800)
    '        'Dim window2 As New Telerik.Web.UI.RadWindow
    '        'window2.NavigateUrl = "VerImagenesGestion.aspx?Tramite_clvTramite=" & e.Item.Cells(2).Text & "&Tramite_cvlSubTramite=" & e.Item.Cells(3).Text
    '        'window2.VisibleOnPageLoad = True
    '        'window2.ID = "RadWindow1"
    '        'window2.Width = 800
    '        'window2.Height = 600
    '        'window2.Modal = True
    '        'window2.ReloadOnShow = True
    '        'window2.DestroyOnClose = False
    '        'window2.EnableViewState = False
    '        'RadWindowManager1.Windows.Add(window2)
    '        '' Response.Redirect("EnviarImagenDocumentosGestion.aspx")


    '    End If
    'End Sub


    Protected Sub LinkButton1_Click(sender As Object, e As System.EventArgs) Handles LinkButton1.Click
        cargaDocumentosSolicitad(Session("NumGestionControlTerm"))
        Panel1.Visible = True
    End Sub

    Protected Sub LinkButton2_Click(sender As Object, e As System.EventArgs) Handles LinkButton2.Click
        RegistraScript()
    End Sub

    Private Sub RegistraScript()
        ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind();", True)
    End Sub

    Protected Sub BtnAceptadosPDF_Click(sender As Object, e As System.EventArgs) Handles BtnAceptadosPDF.Click
        ABRIR_VENTANA("CargaImagenGestionPDF.aspx?Tipo=1", 800, 600)
        RadGrid1.Visible = False
        LinkButton1.Visible = False
        LinkButton2.Visible = False
    End Sub

    Protected Sub BtnRechazadosPDF_Click(sender As Object, e As System.EventArgs) Handles BtnRechazadosPDF.Click
        ABRIR_VENTANA("CargaImagenGestionPDFRechazados.aspx?Tipo=2", 800, 600)
        RadGrid1.Visible = False
        LinkButton1.Visible = False
        LinkButton2.Visible = False
    End Sub

    Protected Sub BtnXDocumento_Click(sender As Object, e As System.EventArgs) Handles BtnXDocumento.Click
        RadGrid1.Visible = True
        LinkButton1.Visible = True
        LinkButton2.Visible = True
    End Sub
End Class

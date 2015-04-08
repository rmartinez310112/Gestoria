Imports System.Data
Imports System.Web

Partial Class GestionDocumentos_VerificarImagenesGestion
Inherits System.Web.UI.Page
    Dim csNeg As New ClaseNegocios
    Dim csSQLsvr As New BaseDatosSQL
    Dim csDAL As New DALClass
    #Region "procesos"

    Private Sub cargaDocumentosSolicitad(ByVal nogestion As String)
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
            Dim Tramite_cvlSubTramite As Integer = RadGrid1.Items(x).Cells(3).Text.Trim
            Dim Tramite_TipoPersona As Integer = RadGrid1.Items(x).Cells(4).Text.Trim
            Dim Tramite_servVeh As Integer = RadGrid1.Items(x).Cells(5).Text.Trim

            If csDAL.RevisaRegImagenes(Session("noGestionIntegral"), Tramite_clvTramite, Tramite_cvlSubTramite) > 0 Then
                RadGrid1.Items(x).BackColor = System.Drawing.ColorTranslator.FromHtml("#5882FA")
                RadGrid1.Items(x).EditFormItem("column3").Text = ""

                If csDAL.ValidaChkAutentificado(Session("noGestionIntegral"), Tramite_clvTramite, Tramite_cvlSubTramite, Tramite_TipoPersona, Tramite_servVeh, 1) > 0 Then
                    RadGrid1.Items(x).BackColor = System.Drawing.ColorTranslator.FromHtml("#82f957")
                    RadGrid1.Items(x).EditFormItem("column3").Text = "Verificado"


                ElseIf csDAL.ValidaChkAutentificado(Session("noGestionIntegral"), Tramite_clvTramite, Tramite_cvlSubTramite, Tramite_TipoPersona, Tramite_servVeh, 2) > 0 Then
                    RadGrid1.Items(x).BackColor = System.Drawing.ColorTranslator.FromHtml("#F65B18")
                    RadGrid1.Items(x).EditFormItem("column3").Text = "Rechazado"
                    RadGrid1.Items(x).EditFormItem("column4").Text = ""

                End If


            Else
                RadGrid1.Items(x).EditFormItem("column3").Text = ""
                RadGrid1.Items(x).EditFormItem("column4").Text = ""
            End If



        Next
    End Sub

#End Region
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
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            If Session("noGestionIntegral") <> Nothing Then
                cargaDocumentosSolicitad(Session("noGestionIntegral"))
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


        Try
            If e.CommandName = "cmdVer" Then
                Dim window As New Telerik.Web.UI.RadWindow
                    With window
                    .NavigateUrl = "AutorizarImagenesGestion.aspx?Tramite_clvTramite=" & Tramite_clvTramite & "&Tramite_cvlSubTramite=" & Tramite_cvlSubTramite & "&Tramite_TipoPersona=" & Tramite_TipoPersona & "&Tramite_servVeh=" & Tramite_servVeh & "&consec=" & consec
                    .VisibleOnPageLoad = True
                    .ID = "RadWindow1"
                    .Width = 800
                    .Height = 600
                    .Modal = True
                    RadWindowManager1.Windows.Add(window)
                End With
            End If
        Catch ex As Exception
            MsgBox(ex, MsgBoxStyle.Critical)
        End Try
    End Sub
End Class

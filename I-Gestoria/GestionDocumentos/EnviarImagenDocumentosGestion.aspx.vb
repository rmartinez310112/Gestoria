Imports System.Data
Imports System.Web
Partial Class GestionDocumentos_EnviarImagenDocumentosGestion
Inherits System.Web.UI.Page
    Dim csNeg As New ClaseNegocios
    Dim csSQLsvr As New BaseDatosSQL
    Dim csDAL As New DALClass
    #Region "procesos"

    Public Sub ABRIR_VENTANA(ByVal PopUpWindowPage As String, ByVal alto As Integer, ByVal largo As Integer)
        Dim Script As String = ""
        Script = " <script language=JavaScript id='PopupWindow'>  var confirmWin = null; confirmWin = window.open('" & PopUpWindowPage & "','myWindow','status = 1, scrollbars=1,height = " & alto & ", width = " & largo & ", resizable = 1 '); if((confirmWin != null) && (confirmWin.opener==null)) { confirmWin.opener = self; } </script> "
        If Not ClientScript.IsStartupScriptRegistered("PopupWindow") Then
            ClientScript.RegisterStartupScript(Me.GetType, "PopupWindow", Script)
        End If
    End Sub

    Protected Sub ConfigureNotification(ByVal titulo As String, ByVal texto As String)
        'String
        lblError.Text = texto
        lblError.Text = texto
        RadNotification2.Title = "Aviso!"
        RadNotification2.Text = texto
        'Enum
        RadNotification2.Position = Telerik.Web.UI.NotificationPosition.Center
        RadNotification2.Animation = Telerik.Web.UI.NotificationAnimation.Fade
        'notificacion.ContentScrolling = Telerik.Web.UI.NotificationScrolling.Default
        RadNotification2.AutoCloseDelay = 10000
        'Unit
        RadNotification2.Width = 300
        RadNotification2.Height = 150
        RadNotification2.OffsetX = -10
        RadNotification2.OffsetY = 10

        RadNotification2.Pinned = True
        RadNotification2.EnableRoundedCorners = True
        RadNotification2.EnableShadow = True
        RadNotification2.KeepOnMouseOver = False
        RadNotification2.VisibleTitlebar = True
        RadNotification2.ShowCloseButton = True
        RadNotification2.Show()

    End Sub
    Private Sub cargaDocumentosSolicitad(nogestion As String)
        Dim ds As New DataSet
        ds = csDAL.DocumentosSolicitados(nogestion)
            With RadGrid1
            .DataSource = ds.Tables(0)
            .DataBind()
        End With

    End Sub

    #End Region
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
       
        If Not Page.IsPostBack Then
            If Session("noGestionIntegral") <> Nothing Then
                cargaDocumentosSolicitad(Session("noGestionIntegral"))
            End If
        End If
    End Sub

    Protected Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If e.CommandName = "cmdEnviar" Then

            ABRIR_VENTANA("CargaImagenGestion.aspx?Tramite_clvTramite=" & e.Item.Cells(2).Text & "&Tramite_cvlSubTramite=" & e.Item.Cells(3).Text, 600, 800)
            'Dim window1 As New Telerik.Web.UI.RadWindow
            'window1.NavigateUrl = "CargaImagenGestion.aspx?Tramite_clvTramite=" & e.Item.Cells(2).Text & "&Tramite_cvlSubTramite=" & e.Item.Cells(3).Text
            'window1.VisibleOnPageLoad = True
            'window1.ID = "RadWindow1"
            'window1.Width = 800
            'window1.Height = 600
            'window1.Modal = True
            'window1.ReloadOnShow = True
            'window1.DestroyOnClose = True
            'RadWindowManager1.Windows.Add(window1)
            '' Response.Redirect("EnviarImagenDocumentosGestion.aspx")


        End If
    End Sub
End Class

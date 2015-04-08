
Partial Class AsignacionControl_ControlTermino_RevisarDocumentosCargados
    Inherits System.Web.UI.Page

    Dim csNeg As New ClaseNegocios
    Dim csSQLsvr As New BaseDatosSQL
    Dim csDAL As New DALClass

#Region "procesos"
    

#End Region
    '

    Private Sub CargarListadImagenes()
        GridView1.DataSource = DALClass.GetAll(Session("noGestionIntegral"), "ArchivosAceptadosPDF")
        GridView1.DataBind()

    End Sub



  

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            CargarListadImagenes()
        Else
            If Session("noGestionIntegral") <> Nothing Then
                CargarListadImagenes()

            Else
                ConfigureNotification("Ingrese numero de Servicio")
            End If
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
End Class


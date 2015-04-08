Imports System.Data

Partial Class AsignacionControl_ControlTermino_DetalleRechazo
    Inherits System.Web.UI.Page
    Dim csBaseGes As New ClaseBaseGestoria



    Public Sub LlenaGrid()

        Dim dt As DataTable

        dt = csBaseGes.Select_DetalleDigitalizacion(Session("NumGestionControlTerm"))
        '' hacer los filtros con el rowfiltes al ds
        'cliente, tipoServicio, FechaInicio, FechaFinal, Regional, Estado

        If dt.Rows.Count <> 0 Then

            ViewState("dataset") = dt

            GridDetalleRecepcion.CurrentPageIndex = 0
            GridDetalleRecepcion.DataSource = ViewState("dataset")
            GridDetalleRecepcion.DataBind()
            GridDetalleRecepcion.Dispose()
            'UpdatePanelGrid.Update()

        Else

            ''Mensage de que no se tienen valores a mostrar
            GridDetalleRecepcion.Rebind()
            dt.Clear()
            ConfigureNotification("No existen datos a mostrar.")
            'RegistraScript()

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

    Protected Sub form1_Load(sender As Object, e As System.EventArgs) Handles form1.Load

        If Session("NumGestionControlTerm") <> Nothing Then
            LlenaGrid()
        Else
            ConfigureNotification("Debe selecionar Numero de Gestion")
            RegistraScript()
        End If
    End Sub

    Private Sub RegistraScript()
        ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind();", True)
    End Sub
End Class

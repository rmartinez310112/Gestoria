
Partial Class Cancelacion
    Inherits System.Web.UI.Page
    Dim dal As New DALClass

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

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            If Session("noGestionIntegral") <> Nothing Then

            Else
                ConfigureNotification("Favor de Introducir No.Gestion")
            End If
        End If
    End Sub

    Protected Sub RadButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButton1.Click
        'If Not Page.IsPostBack Then
        Dim master As MasterPageGestionOperativa = DirectCast(Me.Master, MasterPageGestionOperativa)
        If Session("noGestionIntegral") <> Nothing Then
            If ValidaMotivo(CboCancela) <> False Then
                If Session("clvUsuario") = Nothing Then
                    Response.Redirect("~/InicioSesion.aspx")
                End If
                If dal.CancelaServicio(Session("noGestionIntegral"), Session("clvUsuario"), CboCancela.SelectedItem.Value, 1) = "0" Then

                    master.CargaDatosExpediente()
                    'master.Response.Redirect("~/AsignacionControl/TableroControlGestion.aspx")
                    ConfigureNotifation("Atención", "No.Gestion cancelado con exito. Se le recuerda que una vez cancelado el servicio ya no se podra reactivar")

                Else
                    ConfigureNotifation("Atención", "Error en la cancelacion de servicio, favor de avisar al administrador")
                End If
            End If
        Else
            ConfigureNotifation("Atención", "Favor de Introducir No.Gestion")
        End If

    End Sub

    Public Function ValidaMotivo(ByVal CboCancel As Telerik.Web.UI.RadComboBox) As String
        If CboCancel.SelectedValue <> 0 Then
            Return True
        Else
            ConfigureNotifation("Atención", "Debe selecionar una causa valida")
            Return False
        End If
    End Function

    Public Sub ConfigureNotifation(ByVal titulo As String, ByVal texto As String)
        Dim master As MasterPageGestionOperativa = DirectCast(Me.Master, MasterPageGestionOperativa)
        master.ConfigureNotification(titulo, texto, 6000)
    End Sub

End Class

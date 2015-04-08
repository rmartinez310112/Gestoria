Partial Class Frm_citas_WebCitasXexpediente
Inherits System.Web.UI.Page
    Dim csNeg As New ClaseNegocios
    Dim csSQLsvr As New BaseDatosSQL
    Dim csDAL As New DALClass

#Region "procesos"

    Protected Sub AppointmentsDataSource_Updating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceCommandEventArgs) Handles AppointmentsDataSource.Updating
        If Session("noGestionIntegral") <> Nothing Then
            csDAL.Insert_BitacoraCambios(Session("noGestionIntegral"), "Se realizaron cambios a la cita por parte del usuario", Session("clvUsuario"))
        End If
    End Sub

    Protected Sub AppointmentsDataSource_Deleted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceStatusEventArgs) Handles AppointmentsDataSource.Deleted
        If Session("noGestionIntegral") <> Nothing Then
            csDAL.Insert_BitacoraCambios(Session("noGestionIntegral"), "Se cancelo una cita por parte del usuario", Session("clvUsuario"))
        End If
    End Sub

    Private Sub AppointmentsDataSource_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceCommandEventArgs) Handles AppointmentsDataSource.Inserting
        If Session("noGestionIntegral") <> Nothing Then
            Dim sGestion As String = Session("noGestionIntegral")
            Dim nLargo As Integer = Len(sGestion)
            Session("p_Anio") = Mid(sGestion, 1, 4)
            Session("p_Cliente") = Mid(sGestion, 5, 2)
            Session("p_tipo") = Mid(sGestion, 7, 2)
            Session("p_estado") = Mid(sGestion, 9, 2)
            Session("p_consec") = Mid(sGestion, 11, nLargo)
            'Description

            e.Command.Parameters("@Description").Value = "No.Gestion:" & Session("noGestionIntegral") & "  Motivo de la Cita:" & e.Command.Parameters("@Subject").Value
            e.Command.Parameters("@Subject").Value = "No.Gestion:" & Session("noGestionIntegral") & "  Motivo de la Cita:" & e.Command.Parameters("@Subject").Value
            e.Command.Parameters("@Reporte_anio").Value = Session("p_Anio")
            e.Command.Parameters("@Reporte_cliente").Value = Session("p_Cliente")
            e.Command.Parameters("@Reporte_Tipo").Value = Session("p_tipo")
            e.Command.Parameters("@Reporte_clvEstado").Value = Session("p_estado")
            e.Command.Parameters("@Reporte_Numero").Value = Session("p_consec")
            'e.Command.Parameters("@IDExpe").Value = Session("nNumExpe")

            csDAL.Insert_BitacoraCambios(Session("noGestionIntegral"), "Se adiciono una cita por parte del usuario", Session("clvUsuario"))
        End If
    End Sub

    Private Sub AppointmentsDataSource_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles AppointmentsDataSource.Selecting
        If Session("noGestionIntegral") <> Nothing Then
            Dim sGestion As String = Session("noGestionIntegral")
            Dim nLargo As Integer = Len(sGestion)
            Session("p_Anio") = Mid(sGestion, 1, 4)
            Session("p_Cliente") = Mid(sGestion, 5, 2)
            Session("p_tipo") = Mid(sGestion, 7, 2)
            Session("p_estado") = Mid(sGestion, 9, 2)
            Session("p_consec") = Mid(sGestion, 11, nLargo)


            e.Command.Parameters("@Reporte_anio").Value = Session("p_Anio")
            e.Command.Parameters("@Reporte_cliente").Value = Session("p_Cliente")
            e.Command.Parameters("@Reporte_Tipo").Value = Session("p_tipo")
            e.Command.Parameters("@Reporte_clvEstado").Value = Session("p_estado")
            e.Command.Parameters("@Reporte_Numero").Value = Session("p_consec")
            'e.Command.Parameters("@IDExpe").Value = Session("nNumExpe")
        Else
            ConfigureNotification("Favor de Introducir No.Gestion")
        End If
    End Sub

    Private Sub UsuariosDataSource_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles UsuariosDataSource.Selecting
        If Session("noGestionIntegral") <> Nothing Then
            e.Command.Parameters("@userID").Value = Session("nFkUsuario")
        End If
    End Sub

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("noGestionIntegral") <> Nothing Then
            'Dim nExpediente As Telerik.Web.UI.RadTextBox = Me.Master.FindControl("txtBuscar")
            'nExpediente.Text = Session("noGestionIntegral")
            ''Dim masterPag As Home2 = DirectCast(Me.Master, Home2)
            ''masterPag.buscar_Cliente()
            rblTipoCita.SelectedValue = 1
        Else
            ConfigureNotification("Favor de Introducir No.Gestion")
            'Response.Redirect("~/GestionCitas/WebCitasXusuario.aspx")
        End If
    End Sub

    Protected Sub rblTipoCita_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rblTipoCita.SelectedIndexChanged
        If rblTipoCita.SelectedValue = 2 Then
            If Session("noGestionIntegral") <> Nothing Then
                Response.Redirect("~/GestionCitas/WebCitasXusuario.aspx")
            End If
        End If
    End Sub

    Protected Sub ConfigureNotification(ByVal texto As String)
        'String
        RadNotification1.Title = "Atención"
        RadNotification1.Text = texto
        'Enum
        RadNotification1.Position = Telerik.Web.UI.NotificationPosition.Center
        RadNotification1.Animation = Telerik.Web.UI.NotificationAnimation.Fade
        'notificacion.ContentScrolling = Telerik.Web.UI.NotificationScrolling.Default
        RadNotification1.AutoCloseDelay = 5000
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

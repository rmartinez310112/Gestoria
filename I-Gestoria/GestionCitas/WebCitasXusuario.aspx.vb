Imports System
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Telerik.Web.UI

Partial Class Frm_citas_WebCitasXusuario
Inherits System.Web.UI.Page

    Private Sub AppointmentsDataSource_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceCommandEventArgs) Handles AppointmentsDataSource.Inserting
        If Session("noGestionIntegral") <> Nothing Then
            e.Command.Parameters("@UserID").Value = Session("nFkUsuario")
        End If
    End Sub

    Private Sub AppointmentsDataSource_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles AppointmentsDataSource.Selecting
        If Session("noGestionIntegral") <> Nothing Then
            e.Command.Parameters("@UserID").Value = Session("nFkUsuario")
        End If
    End Sub


    Private Sub UsuariosDataSource_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles UsuariosDataSource.Selecting
        If Session("noGestionIntegral") <> Nothing Then
            e.Command.Parameters("@userID").Value = Session("nFkUsuario")
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Session("noGestionIntegral") <> Nothing Then
                rblTipoCita.SelectedValue = 1
            End If
        End If
    End Sub

    Protected Sub rblTipoCita_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rblTipoCita.SelectedIndexChanged
        If rblTipoCita.SelectedValue = 1 Then
            If Session("noGestionIntegral") <> Nothing Then
                Response.Redirect("~/GestionCitas/WebCitasXexpediente.aspx")
            End If
        End If
    End Sub
End Class

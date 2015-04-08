Imports System.Data
Partial Class InicioSesion
Inherits System.Web.UI.Page
    Dim csDAL As New DALClass
    Dim csNeg As New ClaseNegocios
    Dim csSQLsvr As New BaseDatosSQL

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        If TextBox1.Text <> Nothing Then
            If TextBox2.Text <> Nothing Then
                Dim Usua As String = TextBox1.Text
                Dim Pass As String = TextBox2.Text

                Dim ds As DataSet = New DataSet
                ds = csDAL.InicioSesion(Usua, Pass)
                If ds.Tables(0).Rows.Count <> 0 Then
                    Session("clvUsuario") = Usua
                    Dim drSub As DataRow
                    For Each drSub In ds.Tables(0).Rows
                        Session("nFkUsuario") = drSub("id_sesion")
                        Session("nivel") = drSub("nivel_sesion")
                        Session("ClienteTablero") = drSub("cliente")
                    Next
                    FormsAuthentication.RedirectFromLoginPage(Usua, False)
                    Response.Redirect("Default2.aspx", False)
                Else
                    csNeg.WindowAlert(RadAjaxManager1, "Usuario invalido, favor de verificar...")
                End If
            Else
                csNeg.WindowAlert(RadAjaxManager1, "Favor de ingrasar su clave de acceso...")
            End If
        Else
            csNeg.WindowAlert(RadAjaxManager1, "Favor de ingrasar su usuario...")
        End If
    End Sub
End Class

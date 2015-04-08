Imports System.Data
Imports System.Web
Partial Class AsignacionControl_CierreAsignacionGestionCC
Inherits System.Web.UI.Page
    Dim csNeg As New ClaseNegocios
    Dim csSQLsvr As New BaseDatosSQL
    Dim csDAL As New DALClass
    Protected Sub Button1_Click(sender As Object, e As System.EventArgs) Handles Button1.Click
        If txtCierre.Text.Trim = String.Empty Then
            lblError.Text = "No se puede hacer el cierre no ha introducido datos.."
            Exit Sub
        End If
        lblError.Text = String.Empty
        If csDAL.CerrarGestionCC(Request.QueryString("nogestion"), Session("clvUsuario"), txtCierre.Text.Trim) = True Then
            lblError.Text = "El cierre se ha realizado con exito.."
            Button1.Enabled = False
            csDAL.Insert_BitacoraCambios(Request.QueryString("nogestion"), "Se realizo el cierre en CC de la gestion", Session("clvUsuario"))
        Else
            lblError.Text = "Error al realizar el cierre.."
        End If
    End Sub
End Class

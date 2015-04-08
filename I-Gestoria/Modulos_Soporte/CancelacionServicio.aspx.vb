Imports System.Data
Partial Class Modulos_Soporte_CancelacionServicio
Inherits System.Web.UI.Page
    Dim csNeg As New ClaseNegocios
    Dim csSQLsvr As New BaseDatosSQL
    Dim csDAL As New DALClass
    Protected Sub Button1_Click(sender As Object, e As System.EventArgs) Handles Button1.Click

    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim comando As String = "select  Clave_Cancela, Descripcion_Cancela FROM CancelacionGestoria_Tipos where Tipo_cancela=1"
            csSQLsvr.LlenarRadCombo(cboCancela, comando, Session("connGestion"))
        End If
    End Sub
End Class

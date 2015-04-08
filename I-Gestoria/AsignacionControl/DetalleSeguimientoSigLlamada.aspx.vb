Imports System.Data

Partial Class FrontOffice_DetalleSeguimientoSigLlamada
    Inherits System.Web.UI.Page
    Dim csNeg As New ClaseNegocios
    Dim csSQLsvr As New BaseDatosSQL
    Dim csDAL As New DALClass
    Dim cbGes As New ClaseBaseGestoria

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Session("noGestionIntegral") = Session("Gestion")
        'Session("noGestionIntegral") = 20141310211598
        Dim comando As String = "SELECT     Servicio, LLamada, rtrim(RegistroAccion_AccionSiguiente) AS 'Accion Siguiente', RegistroAccion_usuario AS Usuario, RegistroAccion_Fecha AS 'Fecha Llamada' FROM         vw_SiguientesAccionesSeguimiento where Servicio= '" & Session("noGestionIntegral") & "'"
        Dim ds As DataSet = New DataSet
        ds = csSQLsvr.QueryDataSet(comando, Session("connGestion"))
        With RadGrid1
            .DataSource = ds.Tables(0)
            .DataBind()
        End With

    End Sub
End Class

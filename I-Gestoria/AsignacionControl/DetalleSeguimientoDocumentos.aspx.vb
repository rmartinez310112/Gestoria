Imports System.Data

Partial Class AsignacionControl_DetalleSeguimientoDocumentos
    Inherits System.Web.UI.Page
    Dim csNeg As New ClaseNegocios
    Dim csSQLsvr As New BaseDatosSQL
    Dim csDAL As New DALClass
    Dim cbGes As New ClaseBaseGestoria


    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Session("noGestionIntegral") = Session("Gestion")
        'Session("noGestionIntegral") = 201413102168
        Dim comando As String = " select NumServicio as Servicio, SegTramite_fechaAlta as  'Fecha de Seguimiento' ,Resultado ,catDesCausaConclusionGestor as Observaciones, CONVERT(VARCHAR(10), SegTramite_FechaProxLlamada, 103)  as 'Fecha de Prox.Llamada'  from vw_SeguimientoTramitesGestorDetalle where NumServicio = '" & Session("noGestionIntegral") & "' order by SegTramite_fechaAlta"
        Dim ds As DataSet = New DataSet
        ds = csSQLsvr.QueryDataSet(comando, Session("connGestion"))
        With RadGrid1
            .DataSource = ds.Tables(0)
            .DataBind()
        End With

    End Sub
End Class

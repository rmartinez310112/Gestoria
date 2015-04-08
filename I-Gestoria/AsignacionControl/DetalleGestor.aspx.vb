Imports System.Data

Partial Class AsignacionControl_DetalleGestor
    Inherits System.Web.UI.Page
    Dim csDAL As New DALClass

    Public Sub llenagrid()
        Dim ds As New DataSet
        Dim sGestion As String = Session("noGestionIntegral").Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        ds = csDAL.CargaDetallesPrimerContacto(p_Anio, p_Cliente, p_tipo, p_estado, p_consec)
        Dim dt As New DataTable
        dt = ds.Tables(0)
        If dt.Rows.Count <> 0 Then
            'ViewState("dataset") = dt
            RadGrid1.CurrentPageIndex = 0
            RadGrid1.DataSource = dt
            RadGrid1.DataBind()
            RadGrid1.Dispose()
            'RadGrid1.Update()

        End If



    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        llenagrid()
    End Sub
End Class

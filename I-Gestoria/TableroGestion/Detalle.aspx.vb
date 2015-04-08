Imports System.Data
Partial Class TableroGestion_Detalle
    Inherits System.Web.UI.Page

    Dim csSQLsvr As New BaseDatosSQL
    Dim csDAL As New DALClass
    Private _strquery As String


    'PROPIEDADES

    Public Property strQuery As String
        Set(value As String)
            ViewState("_strquery") = value
        End Set
        Get
            Return ViewState("_strquery")
        End Get
    End Property


    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        LlenaDetalles()
    End Sub

    'PROPIEDADES
    Private Function LlenaDetalles()
        Dim Ds As New DataSet

        Dim clientetablero As String
        Dim IdCliente As String
        Dim IdServicio As String
        Dim IdRegion As String
        Dim IdEstado As String
        Dim FechaI As String
        Dim FechaF As String
        Dim IdMes As String
        Dim IdTipo As String



        'Tipo = 0 (TODOSOCURRIDOS) , TIPO = 1(CANCELADOS)
        clientetablero = Request.QueryString("sesionClienteTablero")
        IdCliente = Request.QueryString("IdCliente")
        IdServicio = Request.QueryString("IdServicio")
        IdRegion = Request.QueryString("IdRegion")
        IdEstado = Request.QueryString("IdEstado")
        FechaI = Request.QueryString("FechaI")
        FechaF = Request.QueryString("FechaF")
        IdMes = Request.QueryString("IdMes")
        IdTipo = Request.QueryString("Tipo")

        Select Case IdTipo
            Case 1
                strQuery = strQuery + " AND RSG.Reporte_status=1"
            Case 3
                strQuery = strQuery + " AND RSG.Reporte_status=3"
            Case 4
                strQuery = strQuery + " AND Reporte_status =0"

        End Select

        If (IdCliente <> 0) Then
            strQuery = strQuery + " AND RSG.Reporte_cliente = " + IdCliente + ""
        Else
            If (clientetablero <> "") And (clientetablero <> "0") Then
                strQuery = strQuery + " AND RSG.Reporte_cliente in (" + clientetablero + ")"
            End If
        End If

        If (IdServicio <> 0) Then
            strQuery = strQuery + " AND RSG.Reporte_Tipo = " + IdServicio + ""
        End If

        If (IsNothing(IdMes) = False) Then
            strQuery = strQuery + " AND (MONTH(convert(datetime,RSG.fecha)) = " + IdMes + " AND YEAR(convert(datetime,RSG.Reporte_FechaRepor)) = YEAR(GETDATE()))"
        End If

        If (IsNothing(FechaI) = False And IsNothing(FechaF) = False) Then
            strQuery = strQuery + " AND convert(datetime,RSG.fecha) BETWEEN ''" + FechaI + "'' AND ''" + FechaF + "''"
        End If

        If (IdRegion <> 0) Then
            strQuery = strQuery + " AND RSG.clvRegional = " + IdRegion + ""
        End If

        If (IdEstado <> 0) Then
            strQuery = strQuery + " AND RSG.Reporte_clvEstado = " + IdEstado + ""
        End If

        Dim _query As String = ""

        _query = " GestionaDetalleTableros '" + strQuery + "' "
        Ds = csDAL.CargaDetalleTableroServicio(_query)

        If (Ds.Tables(0).Rows.Count > 0) Then
            With RDDetalles

                .DataSource = Ds.Tables(0)
                .DataBind()

            End With
        End If

    End Function

    Protected Sub Export_Command(sender As Object, e As System.Web.UI.WebControls.CommandEventArgs) Handles Export.Command

        RDDetalles.ExportSettings.Excel.Format = Telerik.Web.UI.GridExcelExportFormat.ExcelML
        RDDetalles.ExportSettings.IgnorePaging = True
        RDDetalles.ExportSettings.ExportOnlyData = True
        RDDetalles.ExportSettings.OpenInNewWindow = True
        RDDetalles.MasterTableView.ExportToExcel()

    End Sub

    Protected Sub Export_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles Export.Click

    End Sub
End Class

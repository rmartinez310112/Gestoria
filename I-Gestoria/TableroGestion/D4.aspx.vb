Imports System.Data
Partial Class TableroGestion_D4
    Inherits System.Web.UI.Page

        Dim csNeg As New ClaseNegocios
        Dim csSQLsvr As New BaseDatosSQL
        Dim csDAL As New DALClass
        Private _strquery As String

        'Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        '    If Not Page.IsPostBack Then
        '        Dim ds As New DataSet
        '        LlenaDetalles()
        '        ds = csDAL.CargaTableroDesempeñoTotal()
        '        With RadGrid1
        '            .DataSource = ds.Tables(0)
        '            .DataBind()
        '        End With
        '        ds.Clear()
        '        ds.Dispose()

        '    End If



        'End Sub

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



        clientetablero = Request.QueryString("sesionClienteTablero")
        IdCliente = Request.QueryString("IdCliente")
        IdServicio = Request.QueryString("IdServicio")
        IdRegion = Request.QueryString("IdRegion")
        IdEstado = Request.QueryString("IdEstado")
        FechaI = Request.QueryString("FechaI")
        FechaF = Request.QueryString("FechaF")
        IdMes = Request.QueryString("IdMes")

        If (IdCliente <> 0) Then
            strQuery = strQuery + " AND RSG.Reporte_cliente = " + IdCliente + ""
        Else
            If (clientetablero <> "") Or (clientetablero <> "0") Then
                strQuery = strQuery + " AND RSG.Reporte_cliente in (" + clientetablero + ")"
            End If
        End If

            If (IdServicio <> 0) Then
                strQuery = strQuery + " AND RSG.Reporte_Tipo = " + IdServicio + ""
            End If

            If (IsNothing(IdMes) = False) Then
                strQuery = strQuery + " AND (MONTH(RSG.Reporte_FechaRepor) = " + IdMes + " AND YEAR(RSG.Reporte_FechaRepor) = YEAR(GETDATE()))"
            End If

            If (IsNothing(FechaI) = False And IsNothing(FechaF) = False) Then
                strQuery = strQuery + " AND RSG.Reporte_FechaRepor BETWEEN ''" + FechaI + "'' AND ''" + FechaF + "''"
            End If

            If (IdRegion <> 0) Then
                strQuery = strQuery + " AND RSG.clvRegional = " + IdRegion + ""
            End If

            If (IdEstado <> 0) Then
                strQuery = strQuery + " AND RSG.Reporte_clvEstado = " + IdEstado + ""
            End If

            Dim _query As String = ""

            _query = "AvanceTotal'" + strQuery + "' "
            Ds = csDAL.CargaDetalleTableroDesempeño(_query)
            If (Ds.Tables(0).Rows.Count > 0) Then
                With RadGrid1
                    .DataSource = Ds.Tables(0)
                    .DataBind()
                End With
            End If
        End Function
    End Class



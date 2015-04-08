Imports System.Data
Imports System.Web
Partial Class TiposServicios
Inherits System.Web.UI.Page
    Dim csNeg As New ClaseNegocios
    Dim csSQLsvr As New BaseDatosSQL
    Dim csDAL As New DALClass
    #Region "procesos"
    Private Sub cargaDatosGestion(ByVal datosGestion As DataSet)
        Dim dr As DataRow
        For Each dr In datosGestion.Tables(0).Rows
            'Session("nAseguradora") = csDAL.buscaAseguradora(dr("Reporte_cliente"))
            'Session("nTipoSer") = csDAL.buscaTipoServicio(dr("Reporte_cliente"), dr("Reporte_Tipo"))
            'Session("nStatus") = csDAL.buscaEstatusServicio(dr("Reporte_status"))

            'If Session("nAseguradora") = 13 And Session("nTipoSer") = 11 Then
            '    Response.Redirect("~/GestionPerdidaTotal/GestionPTxRobo.aspx")
            'End If

            'If Session("nAseguradora") = 13 And Session("nTipoSer") = 12 Then
            '    Response.Redirect("~/GestionFallecimiento/DatosGestionFallecimiento_ABC.aspx")
            'End If

        Next
        datosGestion.Clear()
        datosGestion.Dispose()
    End Sub
    #End Region


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim menu As Integer = Request.QueryString("menu")

        'If Menu = 0 Then
        '    Response.Redirect("~/AsignacionControl/AsignarGestor.aspx")
        'End If


        'If menu = 10 Then
        '    Response.Redirect("~/AsignacionControl/TableroControlGestion.aspx")
        'End If


        If Session("noGestionIntegral") <> Nothing Then


            If Not Page.IsPostBack Then
                Dim sGestion As String = Session("noGestionIntegral")
                Dim nLargo As Integer = Len(sGestion)
                Dim p_Anio As String = Mid(sGestion, 1, 4)
                Dim p_Cliente As String = Mid(sGestion, 5, 2)
                Dim p_tipo As String = Mid(sGestion, 7, 2)
                Dim p_estado As String = Mid(sGestion, 9, 2)
                Dim p_consec As String = Mid(sGestion, 11, nLargo)


                Session("p_Anio") = p_Anio
                Session("p_Cliente") = p_Cliente
                Session("p_tipo") = p_tipo
                Session("p_estado") = p_estado


                If menu = 1 Then

                   
                If p_tipo = 11 Then
                    Response.Redirect("~/GestionPerdidaTotal/GestionPTxRobo.aspx")

                End If

                If p_tipo = 12 Then
                    Response.Redirect("~/GestionFallecimiento/DatosGestionFallecimiento_ABC.aspx")
                End If

                If p_tipo = 10 Then
                    Response.Redirect("~/GestionPerdidaTotal/DatosGestionPTOrdaz_ABC.aspx")
                End If

                If p_tipo = 13 Then
                    Response.Redirect("~/GestionInvalidez/GestionXinvalidez.aspx")
                End If

                If p_tipo > 13 And p_tipo < 35 Then
                    Response.Redirect("~/GestionGeneralNRFM/GeneralNRFM.aspx")
                End If
                If p_tipo > 34 Then
                    Response.Redirect("~/GestionGeneral/General.aspx")
                End If

            End If



            '    If menu = 2 Then
            '        Response.Redirect("~/GestionDocumentos/SolicitudDocumentosGestion.aspx")
            '    End If

            '    If menu = 3 Then
            '        Response.Redirect("~/GestionDocumentos/AceptarDocumentosGestion.aspx")
            '    End If

            '    If menu = 4 Then
            '        Response.Redirect("~/GestionDocumentos/EntregaDocumentosGestor.aspx")
            '    End If

            '    If menu = 5 Then
            '        Response.Redirect("~/GestionDocumentos/EnviarImagenesGestion.aspx")
            '    End If

            '    If menu = 6 Then
            '        Response.Redirect("~/GestionCitas/WebCitasXexpediente.aspx")
            '    End If
            '    If menu = 7 Then
            '        Response.Redirect("~/AsignacionControl/BitacoraGestionExpediente.aspx")
            '    End If
        End If

        Else

        End If
    End Sub
End Class

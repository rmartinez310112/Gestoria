Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Partial Class GestionDocumentos_VerImagenesGestion
Inherits System.Web.UI.Page
    Dim csNeg As New ClaseNegocios
    Dim csSQLsvr As New BaseDatosSQL
    Dim csDAL As New DALClass
    Private Function GetCustomerPhoto(consec As String) As Byte()
        Dim conn As New SqlConnection(Session("connGestion"))
        Dim comm As New SqlCommand("SELECT img_data FROM imagenesGestionDocumentos WHERE img_pk = @consecID", conn)
        comm.Parameters.Add(New SqlParameter("@consecID", consec))

        conn.Open()
        Dim data As Object = comm.ExecuteScalar()
        conn.Close()

        Return DirectCast(data, Byte())
    End Function
    Public Function BaseToImage(ByVal consec As String) As String
        'Setup image and get data stream together
        BaseToImage = String.Empty
        Try

            Dim sNombreFile As String = (csNeg.RandomNumber(100, 500)) & (csNeg.RandomNumber(10, 99)) & (csNeg.RandomNumber(1, 30)) & (csNeg.RandomNumber(1, 20) & Format(Now(), "HHmmss"))
            Dim img As System.Drawing.Image
            Dim MS As System.IO.MemoryStream = New System.IO.MemoryStream
            Dim b() As Byte

            'Converts the base64 encoded msg to image data
            b = GetCustomerPhoto(consec)
            MS = New System.IO.MemoryStream(b)

            'creates image
            img = System.Drawing.Image.FromStream(MS)
            img.Save(Server.MapPath("~/imagenesURL/" & sNombreFile & ".jpg"))
            BaseToImage = "/Gestoria/imagenesURL/" & sNombreFile & ".jpg"
            'img.Save(Server.MapPath("~/imagenesURL/" & sNombreFile & ".jpg"))
            'BaseToImage = "/Gestoria/imagenesURL/" & sNombreFile & ".jpg"

        Catch ex As Exception


        End Try

        Return BaseToImage

    End Function

    Private Sub buscaImagenes(ByVal noGestion As String, clvTramite As Integer, clvSubtramite As Integer, Tramite_TipoPersona As Integer, Tramite_servVeh As Integer)
        Dim sGestion As String = noGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Try
            Dim comando As String = "select * from imagenesGestionDocumentos where  " & _
            " Reporte_anio=" & p_Anio & " and " & _
            "Reporte_cliente=" & p_Cliente & " and " & _
            " Reporte_Tipo=" & p_tipo & " and " & _
            "Reporte_clvEstado=" & p_estado & " and " & _
            " Reporte_Numero=" & p_consec & " and " & _
            " Tramite_clvTramite=" & clvTramite & " and " & _
            " Tramite_cvlSubTramite=" & clvSubtramite & " and " & _
            " Tramite_TipoPersona=" & Tramite_TipoPersona & " and " & _
            "Tramite_servVeh=" & Tramite_servVeh
            Dim ds2 As New DataSet
            ds2 = csSQLsvr.QueryDataSet(comando, Session("connGestion"))
                With RadGrid1
                .DataSource = ds2.Tables(0)
                .DataBind()
            End With
            Dim x As Integer = 0
            Dim cuenta As Integer = ds2.Tables(0).Rows.Count - 1
            For x = 0 To cuenta
                Dim urlImagen = BaseToImage(RadGrid1.Items(x).Cells(2).Text)
                Dim nImagen As System.Web.UI.WebControls.Image = RadGrid1.Items(x).FindControl("Image1")
                Dim sUrlImagen As HyperLink = RadGrid1.Items(x).FindControl("linkImagen")
                sUrlImagen.Text = "Ver imagen  " '& RadGrid1.Items(x).Cells(2).Text
                sUrlImagen.NavigateUrl = urlImagen
                nImagen.ImageUrl = urlImagen

            Next
            ds2.Clear()
        Catch ex As Exception

        End Try


    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("noGestionIntegral") <> Nothing Then
            buscaImagenes(Session("noGestionIntegral"), Request.QueryString("Tramite_clvTramite"), Request.QueryString("Tramite_cvlSubTramite"), Request.QueryString("Tramite_TipoPersona"), Request.QueryString("Tramite_servVeh"))
            txtDesc.Text = csDAL.TipoTramite(Request.QueryString("Tramite_clvTramite"), Request.QueryString("Tramite_cvlSubTramite"), Request.QueryString("Tramite_TipoPersona"), Request.QueryString("Tramite_servVeh"))
        End If
    End Sub
End Class

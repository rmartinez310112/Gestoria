Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Partial Class GestionDocumentos_CargaImagenGestion
Inherits System.Web.UI.Page
    Dim csNeg As New ClaseNegocios
    Dim csSQLsvr As New BaseDatosSQL
    Dim csDAL As New DALClass

    #Region "procesos"
    'Public Sub DownloadFile(ByVal fileName As String)
    '    Response.Clear()
    '    Response.ContentType = "application\octet-stream"
    '    'Dim file As New System.IO.FileInfo(Server.MapPath(fileName))
    '    Dim file As New System.IO.FileInfo(fileName)
    '    Response.AddHeader("Content-Disposition", "attachment; filename=" & file.Name)
    '    Response.AddHeader("Content-Length", file.Length.ToString())
    '    Response.ContentType = "application/octet-stream"
    '    Response.WriteFile(file.FullName)
    '    Response.Flush()
    'End Sub


    'Protected Sub ConfigureNotification(ByVal titulo As String, ByVal texto As String)
    '    'String
    '    notificacion.Title = titulo
    '    notificacion.Text = texto
    '    'Enum
    '    notificacion.Position = Telerik.Web.UI.NotificationPosition.Center
    '    notificacion.Animation = Telerik.Web.UI.NotificationAnimation.Fade
    '    'notificacion.ContentScrolling = Telerik.Web.UI.NotificationScrolling.Default
    '    notificacion.AutoCloseDelay = 1000
    '    'Unit
    '    notificacion.Width = 300
    '    notificacion.Height = 60
    '    notificacion.OffsetX = -10
    '    notificacion.OffsetY = 10

    '    notificacion.Pinned = True
    '    notificacion.EnableRoundedCorners = True
    '    notificacion.EnableShadow = False
    '    notificacion.KeepOnMouseOver = False
    '    notificacion.VisibleTitlebar = False
    '    notificacion.ShowCloseButton = False
    '    notificacion.Show()
    'End Sub


    'Private Sub buscaImagenes(ByVal noGestion As String, ByVal clvTramite As Integer, ByVal clvSubtramite As Integer, ByVal Tramite_TipoPersona As Integer, ByVal Tramite_servVeh As Integer)
    '    Dim sGestion As String = noGestion.Trim
    '    Dim nLargo As Integer = Len(sGestion)
    '    Dim p_Anio As String = Mid(sGestion, 1, 4)
    '    Dim p_Cliente As String = Mid(sGestion, 5, 2)
    '    Dim p_tipo As String = Mid(sGestion, 7, 2)
    '    Dim p_estado As String = Mid(sGestion, 9, 2)
    '    Dim p_consec As String = Mid(sGestion, 11, nLargo)
    '    Try
    '        Dim comando As String = " select * from imagenesGestionDocumentos where  " & _
    '        " Reporte_anio=" & p_Anio & " and " & _
    '        " Reporte_cliente=" & p_Cliente & " and " & _
    '        " Reporte_Tipo=" & p_tipo & " and " & _
    '        " Reporte_clvEstado=" & p_estado & " and " & _
    '        " Reporte_Numero=" & p_consec & " and " & _
    '        " Tramite_clvTramite=" & clvTramite & " and " & _
    '        " Tramite_cvlSubTramite=" & clvSubtramite & " and " & _
    '        " Tramite_TipoPersona=" & Tramite_TipoPersona & " and " & _
    '        " Tramite_servVeh=" & Tramite_servVeh & " and " & _
    '        " chkAutentiificado in(0,1) "

    '        Dim ds2 As New DataSet
    '        ds2 = csSQLsvr.QueryDataSet(comando, Session("connGestion"))
    '            With RadGrid1
    '            .DataSource = ds2.Tables(0)
    '            .DataBind()
    '        End With
    '        Dim x As Integer
    '        Dim cuenta As Integer = ds2.Tables(0).Rows.Count - 1
    '        For x = 0 To cuenta
    '            Dim urlImagen = BaseToImage(RadGrid1.Items(x).Cells(2).Text)
    '            Dim nImagen As System.Web.UI.WebControls.Image = RadGrid1.Items(x).FindControl("Image1")
    '            Dim sUrlImagen As HyperLink = RadGrid1.Items(x).FindControl("linkImagen")
    '                With sUrlImagen
    '                .NavigateUrl = "Default.aspx?Tramite_clvTramite=" & clvTramite & "&Tramite_cvlSubTramite=" & clvSubtramite & "&Tramite_TipoPersona=" & Tramite_TipoPersona & "&Tramite_servVeh=" & Tramite_servVeh & "&consec=" & p_consec & "&imagen=" & urlImagen & "&pagina=" & 0
    '                .Text = "Ver imagen  "
    '            End With
    '            nImagen.ImageUrl = urlImagen
    '        Next
    '        ds2.Clear()
    '    Catch ex As Exception

    '    End Try
    'End Sub


    'Private Function GetCustomerPhoto(ByVal consec As String) As Byte()
    '    Dim conn As New SqlConnection(Session("connGestion"))
    '    Dim comm As New SqlCommand("SELECT img_data FROM imagenesGestionDocumentos WHERE img_pk = @consecID", conn)
    '    comm.Parameters.Add(New SqlParameter("@consecID", consec))

    '    conn.Open()
    '    Dim data As Object = comm.ExecuteScalar()
    '    conn.Close()

    '    Return DirectCast(data, Byte())
    'End Function

    'Public Function BaseToImage(ByVal consec As String) As String
    '    'Setup image and get data stream together
    '    BaseToImage = String.Empty
    '    Try

    '        Dim sNombreFile As String = (csNeg.RandomNumber(100, 500)) & (csNeg.RandomNumber(10, 99)) & (csNeg.RandomNumber(1, 30)) & (csNeg.RandomNumber(1, 20) & Format(Now(), "HHmmss"))
    '        Dim img As System.Drawing.Image
    '        Dim MS As System.IO.MemoryStream = New System.IO.MemoryStream
    '        Dim b() As Byte

    '        'Converts the base64 encoded msg to image data
    '        b = GetCustomerPhoto(consec)
    '        MS = New System.IO.MemoryStream(b)

    '        'creates image
    '        img = System.Drawing.Image.FromStream(MS)
    '        img.Save(Server.MapPath("~/imagenesURL/" & sNombreFile & ".jpg"))
    '        BaseToImage = "/I-Gestoria/imagenesURL/" & sNombreFile & ".jpg"

    '        'img.Save(Server.MapPath("~/imagenesURL/" & sNombreFile & ".jpg"))
    '        'BaseToImage = "/Gestoria/imagenesURL/" & sNombreFile & ".jpg"

    '    Catch ex As Exception


    '    End Try

    '    Return BaseToImage

    'End Function



    'Private Function getFileExtension(ByVal mimetype As String) As String ' Extensiones soportadas
    '    mimetype = mimetype.Split("/"c)(1).ToLower()
    '    Dim hTable As New Hashtable()
    '    hTable.Add("pjpeg", "jpg")
    '    hTable.Add("jpeg", "jpg")
    '    hTable.Add("gif", "gif")
    '    hTable.Add("x-png", "png")
    '    hTable.Add("png", "png")
    '    hTable.Add("bmp", "bmp")
    '    If hTable.Contains(mimetype) Then
    '        Return DirectCast(hTable(mimetype), String)
    '    Else
    '        Return Nothing
    '    End If
    'End Function

    #End Region
    'Protected Sub cmdSubir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSubir.Click
    '    Dim sGestion As String = Session("NumGestionControlTerm")
    '    Dim nLargo As Integer = Len(sGestion)
    '    Dim p_Anio As String = Mid(sGestion, 1, 4)
    '    Dim p_Cliente As String = Mid(sGestion, 5, 2)
    '    Dim p_tipo As String = Mid(sGestion, 7, 2)
    '    Dim p_estado As String = Mid(sGestion, 9, 2)
    '    Dim p_consec As String = Mid(sGestion, 11, nLargo)
    '    Dim Tramite_clvTramite As Integer = Session("Tramite_clvTramiteCT")
    '    Dim Tramite_cvlSubTramite As Integer = Session("Tramite_cvlSubTramiteCT")
    '    Dim Tramite_TipoPersona As Integer = Session("Tramite_TipoPersonaCT")
    '    Dim Tramite_servVeh As Integer = Session("Tramite_servVehCT")


    '    If Request.Files.Count <> 0 Then
    '        Dim httpFile As HttpPostedFile = Request.Files(0)
    '        Dim extension As String = Me.getFileExtension(httpFile.ContentType)
    '        If extension Is Nothing Then
    '            ConfigureNotification("Error:", "Este tipo de archivo no es valido, solo se acepta archivos de imagenes..")
    '            Exit Sub
    '        End If

    '        Dim _sqlConnection As New SqlConnection()
    '        Dim _sqlCommand As New SqlCommand()

    '        _sqlConnection.ConnectionString = Session("connGestion")
    '        _sqlConnection.Open()
    '        _sqlCommand.Connection = _sqlConnection
    '        Dim SQLString As String = "Insert into imagenesGestionDocumentos (Reporte_anio,Reporte_cliente,Reporte_Tipo,Reporte_clvEstado,Reporte_Numero,Tramite_clvTramite,Tramite_cvlSubTramite,img_name,img_data,img_contenttype,Tramite_TipoPersona,Tramite_servVeh) values (@Reporte_anio,@Reporte_cliente,@Reporte_Tipo,@Reporte_clvEstado,@Reporte_Numero,@Tramite_clvTramite,@Tramite_cvlSubTramite,@img_name,@img_data,@img_contenttype,@Tramite_TipoPersona,@Tramite_servVeh)"
    '        _sqlCommand.CommandText = SQLString
    '        _sqlCommand.Parameters.AddWithValue("@Reporte_anio", p_Anio)
    '        _sqlCommand.Parameters.AddWithValue("@Reporte_cliente", p_Cliente)
    '        _sqlCommand.Parameters.AddWithValue("@Reporte_Tipo", p_tipo)
    '        _sqlCommand.Parameters.AddWithValue("@Reporte_clvEstado", p_estado)
    '        _sqlCommand.Parameters.AddWithValue("@Reporte_Numero", p_consec)
    '        _sqlCommand.Parameters.AddWithValue("@Tramite_clvTramite", Tramite_clvTramite)
    '        _sqlCommand.Parameters.AddWithValue("@Tramite_cvlSubTramite", Tramite_cvlSubTramite)
    '        _sqlCommand.Parameters.AddWithValue("@img_contenttype", "jpeg")
    '        _sqlCommand.Parameters.AddWithValue("@Tramite_TipoPersona", Tramite_TipoPersona)
    '        _sqlCommand.Parameters.AddWithValue("@Tramite_servVeh", Tramite_servVeh)

    '        'create byte[] of length equal to the inputstream of the selected image.
    '        Dim imageByte As Byte() = New Byte(httpFile.InputStream.Length) {}
    '        httpFile.InputStream.Read(imageByte, 0, imageByte.Length)
    '        _sqlCommand.Parameters.AddWithValue("@img_data", imageByte)
    '        _sqlCommand.Parameters.AddWithValue("@img_name", txtDescrip.Text.Trim.ToUpper)
    '        _sqlCommand.ExecuteNonQuery()
    '        _sqlConnection.Close()
    '        ConfigureNotification("Listo:", "La imagen se envio correctamente ..")
    '        buscaImagenes(sGestion, Tramite_clvTramite, Tramite_cvlSubTramite, Tramite_TipoPersona, Tramite_servVeh)
    '    Else
    '        ConfigureNotification("Error:", "Es necesario que seleccione un archivo ..")
    '    End If
    'End Sub

    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    If Not Page.IsPostBack Then
    '        If Session("NumGestionControlTerm") <> Nothing Then
    '            buscaImagenes(Session("NumGestionControlTerm"), Session("Tramite_clvTramiteCT"), Session("Tramite_cvlSubTramiteCT"), Session("Tramite_TipoPersonaCT"), Session("Tramite_servVehCT"))
    '            txtDesc.Text = csDAL.TipoTramite(Session("Tramite_clvTramiteCT"), Session("Tramite_cvlSubTramiteCT"), Session("Tramite_TipoPersonaCT"), Session("Tramite_servVehCT"))
    '        End If
    '    End If
    'End Sub


    Private Sub CargarListadImagenes()
        GridView1.DataSource = DALClass.GetAll(Session("NumGestionControlTerm"), "ArchivosAceptadosPDF")
        GridView1.DataBind()

    End Sub


    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)

        If FileUpload1.HasFile Then
            Using reader As New BinaryReader(FileUpload1.PostedFile.InputStream)
                Dim image As Byte() = reader.ReadBytes(FileUpload1.PostedFile.ContentLength)


                DALClass.Guardar(Session("NumGestionControlTerm"), "ArchivosAceptadosPDF", Session("clvUsuario"), FileUpload1.FileName, FileUpload1.PostedFile.ContentLength, image)
            End Using

            CargarListadImagenes()
        End If

    End Sub

    Protected Sub GridView1_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        'se obtiene el nombre de campo definido en el DataKeyNames del gridview
        Dim id As Integer = Convert.ToInt32(GridView1.DataKeys(e.RowIndex).Value)

        DALClass.DeleteById(id)

        CargarListadImagenes()
    End Sub


    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarListadImagenes()
        Else
            If Session("NumGestionControlTerm") <> Nothing Then
                CargarListadImagenes()
            End If
        End If
    End Sub
End Class


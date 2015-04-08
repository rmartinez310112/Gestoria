Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Reflection

Partial Class GestionDocumentos_AutorizarImagenesGestion
Inherits System.Web.UI.Page
    Dim csNeg As New ClaseNegocios
    Dim csSQLsvr As New BaseDatosSQL
    Dim csDAL As New DALClass

    Private Sub cargaCausasCancelacion()
        Dim comando As String = "SELECT     Clave_Cancela, Descripcion_Cancela FROM         CancelacionGestoria_Tipos where Tipo_cancela=2 order by Clave_Cancela"
        csSQLsvr.LlenarRadCombo(cboCancela, comando, Session("connGestion"))
    End Sub
    Private Function GetCustomerPhoto(ByVal consec As String) As Byte()
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

    Private Sub buscaImagenes(ByVal noGestion As String, ByVal clvTramite As Integer, ByVal clvSubtramite As Integer, ByVal Tramite_TipoPersona As Integer, ByVal Tramite_servVeh As Integer)
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
            "Tramite_servVeh=" & Tramite_servVeh & " and " & _
            "chkAutentiificado in(0,1)"
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
                    With sUrlImagen
                    .NavigateUrl = "Default.aspx?Tramite_clvTramite=" & clvTramite & "&Tramite_cvlSubTramite=" & clvSubtramite & "&Tramite_TipoPersona=" & Tramite_TipoPersona & "&Tramite_servVeh=" & Tramite_servVeh & "&consec=" & p_consec & "&imagen=" & urlImagen & "&pagina=" & 1
                    .Text = "Ver imagen  "
                End With
                nImagen.ImageUrl = urlImagen

            Next
            ds2.Clear()
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            If Session("noGestionIntegral") <> Nothing Then
                cargaCausasCancelacion()
                buscaImagenes(Session("noGestionIntegral"), Request.QueryString("Tramite_clvTramite"), Request.QueryString("Tramite_cvlSubTramite"), Request.QueryString("Tramite_TipoPersona"), Request.QueryString("Tramite_servVeh"))
                txtDesc.Text = csDAL.TipoTramite(Request.QueryString("Tramite_clvTramite"), Request.QueryString("Tramite_cvlSubTramite"), Request.QueryString("Tramite_TipoPersona"), Request.QueryString("Tramite_servVeh"))
            End If
        End If
    End Sub

    Protected Sub tblAceptada_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tblAceptada.SelectedIndexChanged

        If tblAceptada.SelectedValue = 1 Then
            Label1.Visible = False
            cboCancela.Visible = False
        End If
        If tblAceptada.SelectedValue = 2 Then
            Label1.Visible = True
            cboCancela.Visible = True
        End If
    End Sub

    'Protected Sub RadButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButton1.Click

    '    Dim observacion As String = cboCancela.Text
    '    Dim chkAutentifica As Integer


    '    If tblAceptada.SelectedValue = 2 Then

    '        If cboCancela.SelectedValue = 0 Then
    '            lblError.Text = "Es necesario escoger una causa de rechazo del documento"
    '        Else

    '            chkAutentifica = 2
    '            csDAL.InsertValidaImagenHistorico(Session("noGestionIntegral"), Request.QueryString("Tramite_clvTramite"), Request.QueryString("Tramite_cvlSubTramite"), observacion, Session("clvUsuario"), chkAutentifica)
    '            lblError.Text = "los datos se guardaron con exito"

    '        End If
    '    Else

    '        chkAutentifica = 1
    '        csDAL.InsertValidaImagenHistorico(Session("noGestionIntegral"), Request.QueryString("Tramite_clvTramite"), Request.QueryString("Tramite_cvlSubTramite"), observacion, Session("clvUsuario"), chkAutentifica)
    '        lblError.Text = "los datos se guardaron con exito"
    '        lblError.ForeColor = Drawing.Color.Green
    '    End If
    'End Sub

    Protected Sub button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles button1.Click
        Dim observacion As String = cboCancela.Text
        Dim chkAutentifica As Integer


        If tblAceptada.SelectedValue = 2 Then

            If cboCancela.SelectedValue = 0 Then
                lblError.Text = "Es necesario escoger una causa de rechazo del documento"
            Else

                chkAutentifica = 2
                csDAL.InsertValidaImagenHistorico(Session("noGestionIntegral"), Request.QueryString("Tramite_clvTramite"), Request.QueryString("Tramite_cvlSubTramite"), observacion, Session("clvUsuario"), chkAutentifica)
                lblError.Text = "los datos se guardaron con exito"

            End If
        Else

            chkAutentifica = 1
            csDAL.InsertValidaImagenHistorico(Session("noGestionIntegral"), Request.QueryString("Tramite_clvTramite"), Request.QueryString("Tramite_cvlSubTramite"), observacion, Session("clvUsuario"), chkAutentifica)
            lblError.Text = "los datos se guardaron con exito"
            lblError.ForeColor = Drawing.Color.Green
        End If
    End Sub
End Class

Partial Class GestionDocumentos_Default
Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("noGestionIntegral") <> Nothing Then
            RadBinaryImage1.ImageUrl = Request.QueryString("imagen")
        End If
    End Sub

    'Protected Sub RadButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButton1.Click

    '    If Request.QueryString("pagina") = 0 Then
    '        Response.Redirect("CargaImagenGestion.aspx?Tramite_clvTramite=" & Request.QueryString("Tramite_clvTramite") & "&Tramite_cvlSubTramite=" & Request.QueryString("Tramite_cvlSubTramite") & "&Tramite_TipoPersona=" & Request.QueryString("Tramite_TipoPersona") & "&Tramite_servVeh=" & Request.QueryString("Tramite_servVeh") & "&consec=" & Request.QueryString("consec"))
    '    Else
    '        Response.Redirect("AutorizarImagenesGestion.aspx?Tramite_clvTramite=" & Request.QueryString("Tramite_clvTramite") & "&Tramite_cvlSubTramite=" & Request.QueryString("Tramite_cvlSubTramite") & "&Tramite_TipoPersona=" & Request.QueryString("Tramite_TipoPersona") & "&Tramite_servVeh=" & Request.QueryString("Tramite_servVeh") & "&consec=" & Request.QueryString("consec"))

    '    End If

    'End Sub

    Protected Sub button_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles button.Click
        If Request.QueryString("pagina") = 0 Then
            Response.Redirect("CargaImagenGestion.aspx?Tramite_clvTramite=" & Request.QueryString("Tramite_clvTramite") & "&Tramite_cvlSubTramite=" & Request.QueryString("Tramite_cvlSubTramite") & "&Tramite_TipoPersona=" & Request.QueryString("Tramite_TipoPersona") & "&Tramite_servVeh=" & Request.QueryString("Tramite_servVeh") & "&consec=" & Request.QueryString("consec"))
        Else
            Response.Redirect("AutorizarImagenesGestion.aspx?Tramite_clvTramite=" & Request.QueryString("Tramite_clvTramite") & "&Tramite_cvlSubTramite=" & Request.QueryString("Tramite_cvlSubTramite") & "&Tramite_TipoPersona=" & Request.QueryString("Tramite_TipoPersona") & "&Tramite_servVeh=" & Request.QueryString("Tramite_servVeh") & "&consec=" & Request.QueryString("consec"))

        End If
    End Sub
End Class


Partial Class AsignacionControl_ControlTermino_Download
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Dim id As Integer = Convert.ToInt32(Request.QueryString("id"))
        Dim tabla As String = Request.QueryString("tabla")

        Dim archivo As Archivo = DALClass.GetById(tabla, id)

        Response.Clear()

        Response.AddHeader("content-disposition", String.Format("attachment;filename={0}", archivo.Nombre))
        Response.ContentType = "application/octet-stream"

        Response.BinaryWrite(archivo.ContenidoArchivo)
        Response.[End]()

    End Sub
End Class

Imports System.Data

Partial Class RecepcionExpedientesGeneral
Inherits System.Web.UI.Page
    Dim csBaseGes As New ClaseBaseGestoria
    Dim bd As New BaseDatosSQL
    Dim csSQLsvr As New BaseDatosSQL
    Protected Sub txtExpediente_TextChanged(sender As Object, e As System.EventArgs) Handles txtExpediente.TextChanged
        If txtExpediente.Text.Trim <> String.Empty Then
            buscaServicio(txtExpediente.Text)
        End If

    End Sub

    Public Sub BuscaServicio(ByVal noServicio As String)

        Dim sGestion As String = noServicio.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Dim ds As New DataSet


        cbomensajeria.SelectedValue = 0
        txtComentarios.Text = String.Empty
        txtGuia.Text = String.Empty

        If p_Anio.Trim = String.Empty Then p_Anio = 0
        If p_Cliente.Trim = String.Empty Then p_Cliente = 0
        If p_tipo.Trim = String.Empty Then p_tipo = 0
        If p_estado.Trim = String.Empty Then p_estado = 0
        If p_consec.Trim = String.Empty Then p_consec = 0

        Dim comando As String = "select * from ResportesGestionTotal_vw where CAST(Reporte_anio AS varchar) + CAST(Reporte_cliente AS varchar) + CAST(Reporte_Tipo AS varchar) + CAST(Reporte_clvEstado AS varchar) + CAST(Reporte_Numero AS varchar)='" & noServicio & "'"
        ds = bd.QueryDataSet(comando, Session("connGestion"))
        Dim dr As DataRow

        If ds.Tables(0).Rows.Count > 0 Then
            For Each dr In ds.Tables(0).Rows
                lbldatos.Text = " No. de Servicio:" & noServicio & Chr(13) & "Asegurado: " & dr("asegurado") & Chr(13) & "No. de Poliza:" & dr("Reporte_poliza") & "  Tipo de Servicio:" & dr("servicio_nomServicio") & " Gestor: " & dr("nombre") & "  " & dr("paterno")
                cmdGuardar.Enabled = True
                Panel1.Visible = True
                txtFechaRecep.Text = Format(Now(), "MM/dd/yyyy HH:mm")
                txtFechaRecep.Enabled = False
            Next
        Else
            lbldatos.Text = " El No. de Servicio no Existe"
            cmdGuardar.Enabled = False
            Panel1.Visible = False
        End If

    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CargarCiaPaqueteria()
        End If
    End Sub

    Public Sub CargarCiaPaqueteria()
        Dim comando As String = "select * from mensajeriaCompañias_tbl order by mensajeria_id "
        csSQLsvr.LlenarRadCombo(cbomensajeria, comando, Session("connGestion"))
    End Sub

    Protected Sub cmdGuardar_Click(sender As Object, e As System.EventArgs) Handles cmdGuardar.Click
        Dim Reporte_anio As String = String.Empty
        Dim Reporte_cliente As String = String.Empty
        Dim Reporte_Tipo As String = String.Empty
        Dim Reporte_clvEstado As String = String.Empty
        Dim Reporte_Numero As String = String.Empty
        Dim EntregaExpediente_Comentario As String = String.Empty
        Dim EntregaExpediente_usuario As String = String.Empty
        Dim EntregaExpediente_fecha As String = String.Empty
        Dim EntregaExpediente_tipoEntre As String = String.Empty
        Dim EntregaExpediente_Guia As String = String.Empty
        Dim EntregaExpediente_cia As String = String.Empty



        If rblTipoEntrega.SelectedValue = 1 And txtGuia.Text.Trim = String.Empty Then
            lbldatos0.Text = " Si la entrega fue Foranea es necesario dar el número de guia.."
            Exit Sub
        End If

        If cbomensajeria.SelectedValue = 0 And rblTipoEntrega.SelectedValue = 1 Then
            lbldatos0.Text = " Si la entrega fue Foranea es necesario dar el la empresa de mensajeria.."
            Exit Sub
        End If

        If txtComentarios.Text.Trim = String.Empty Then
            lbldatos0.Text = " Es necesario dar comentarios sobre la recepción ejemplo: Nombre de la persona que recibe, si hay desviacion con la entrega, etc.."
            Exit Sub
        End If

        Dim sGestion As String = txtExpediente.Text.Trim
        Dim nLargo As Integer = Len(sGestion)
        Reporte_anio = Mid(sGestion, 1, 4)
        Reporte_cliente = Mid(sGestion, 5, 2)
        Reporte_Tipo = Mid(sGestion, 7, 2)
        Reporte_clvEstado = Mid(sGestion, 9, 2)
        Reporte_Numero = Mid(sGestion, 11, nLargo)
        EntregaExpediente_Comentario = txtComentarios.Text.Trim.ToUpper
        EntregaExpediente_usuario = rblTipoEntrega0.SelectedItem.Text.ToUpper
        EntregaExpediente_fecha = txtFechaRecep.Text.Trim
        EntregaExpediente_tipoEntre = rblTipoEntrega.SelectedValue
        EntregaExpediente_cia = cbomensajeria.SelectedValue
        EntregaExpediente_Guia = txtGuia.Text.Trim.ToUpper

        Dim comando As String = "insert into EntregaExpedientesGestoriaGeneral  (Reporte_anio,	Reporte_cliente,	Reporte_Tipo,	Reporte_clvEstado,	Reporte_Numero,	EntregaExpediente_Comentario,	EntregaExpediente_usuario,	EntregaExpediente_fecha,	EntregaExpediente_tipoEntre,	EntregaExpediente_Guia,	EntregaExpediente_cia,	entregaExpdienteAlta) values (" & Reporte_anio & "," & Reporte_cliente & "," & Reporte_Tipo & "," & Reporte_clvEstado & "," & Reporte_Numero & ",'" & EntregaExpediente_Comentario & "','" & EntregaExpediente_usuario & "','" & EntregaExpediente_fecha & "'," & EntregaExpediente_tipoEntre & ",'" & EntregaExpediente_Guia & "'," & EntregaExpediente_cia & ",getdate())"
        If bd.EjecutarSP(comando, Session("connGestion")) = BaseDatosSQL.Estatus.OK Then
            lbldatos0.Text = " La información se guardo correctamente.."
        Else
            lbldatos0.Text = "Error al guardar favor de verificar los datos.."
        End If

    End Sub

    Protected Sub ImageButton1_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        ABRIR_VENTANA("ReporteExpedientesRecibidosGeneral.aspx", 800, 1024)
    End Sub

    Public Sub ABRIR_VENTANA(ByVal PopUpWindowPage As String, ByVal alto As Integer, ByVal largo As Integer)
        Dim Script As String = ""
        Script = " <script language=JavaScript id='PopupWindow'>  var confirmWin = null; confirmWin = window.open('" & PopUpWindowPage & "','myWindow','status = 1, scrollbars=1,height = " & alto & ", width = " & largo & ", resizable = 1 '); if((confirmWin != null) && (confirmWin.opener==null)) { confirmWin.opener = self; } </script> "
        If Not ClientScript.IsStartupScriptRegistered("PopupWindow") Then
            ClientScript.RegisterStartupScript(Me.GetType, "PopupWindow", Script)
        End If
    End Sub
End Class

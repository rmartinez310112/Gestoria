Imports System.Data
Partial Class Default3
Inherits System.Web.UI.Page
    Dim csNeg As New ClaseNegocios
    Dim csSQLsvr As New BaseDatosSQL
    Dim csDAL As New DALClass


    Private Function buscarTerminado(ByVal numservicio As String) As Integer
        buscarTerminado = 1
        Dim comando As String = "select reporte_status from reportegestion where  CAST(Reporte_anio AS varchar) + CAST(Reporte_cliente AS varchar) + CAST(Reporte_Tipo AS varchar) + CAST(Reporte_clvEstado AS varchar) + CAST(Reporte_Numero AS varchar) ='" & numservicio & "'"
        Dim ds As DataSet = New DataSet
        ds = csSQLsvr.QueryDataSet(comando, Session("connGestion"))
        Dim dr As DataRow
        For Each dr In ds.Tables(0).Rows
            If dr("reporte_status") <> 0 Then
                buscarTerminado = 1
            Else
                buscarTerminado = 0
            End If
        Next
        ds.Clear()
        ds.Dispose()
        Return buscarTerminado

    End Function




    Protected Sub ConfigureNotification(ByVal texto As String)
        'String
        'lblError0.Text = texto
        RadNotification2.Title = "Atención"
        RadNotification2.Text = texto
        'Enum
        RadNotification2.Position = Telerik.Web.UI.NotificationPosition.Center
        RadNotification2.Animation = Telerik.Web.UI.NotificationAnimation.Fade
        'notificacion.ContentScrolling = Telerik.Web.UI.NotificationScrolling.Default
        RadNotification2.AutoCloseDelay = 50000
        'Unit
        RadNotification2.Width = 300
        RadNotification2.Height = 150
        RadNotification2.OffsetX = -10
        RadNotification2.OffsetY = 10

        RadNotification2.Pinned = False
        RadNotification2.EnableRoundedCorners = True
        RadNotification2.EnableShadow = True
        RadNotification2.KeepOnMouseOver = False
        RadNotification2.VisibleTitlebar = True
        RadNotification2.ShowCloseButton = True
        RadNotification2.Show()

    End Sub
    Protected Sub rdoBtnRechazo_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdoBtnRechazo.CheckedChanged
        If Not Page.IsPostBack Then
            If rdoBtnRechazo.Checked = True Then
                'RadGrid1.Visible = True
                Dim ds As New DataSet
                ds = csDAL.HistoricaRechazo(Session("noGestionIntegral"))
                    With RadGrid1
                    .DataSource = ds.Tables(0)
                    .DataBind()
                End With
            End If
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            'Session("noGestionIntegral") = 201413105169
            'Session("clvUsuario") = "LGONZA"
            If Session("noGestionIntegral") <> Nothing Then
                If buscarTerminado(Session("noGestionIntegral")) = 1 Then
                    ' ConfigureNotification("El siniestro esta terminado o cancelado, no se puede realizar el termino")
                    ScriptManager.RegisterStartupScript(Page, Page.GetType, "1", "alert('Error: El siniestro esta terminado o cancelado, no se puede realizar el termino');", True)
                    button.Visible = False
                End If
                RadDatePicker1.SelectedDate = Now()
                'RadGrid1.Visible = False
                Dim ds As New DataSet
                ds = csDAL.HistoricaRechazo(Session("noGestionIntegral"))
                With RadGrid1
                    .DataSource = ds.Tables(0)
                    .DataBind()
                End With
            Else
                ConfigureNotification("Favor de Introducir No.Gestion")
            End If
        End If
    End Sub

   
   
    'Protected Sub cmdGuardar0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGuardar0.Click
    '    Dim registro As Date = Now.Date
    '    Dim fecha As Date = RadDatePicker1.SelectedDate
    '    If rdoBtnRecibio.Checked = True Then
    '        Panel1.Visible = False
    '        If csDAL.ValidaEntrega(Session("noGestionIntegral")) <> Nothing Then
    '            ScriptManager.RegisterStartupScript(Page, Page.GetType, "1", "alert('Error: faltan documentos');", True)
    '        Else
    '            csDAL.GuardarEntregaAseguradora(Session("noGestionIntegral"), registro, fecha, 1)
    '            lblEntrega.Text = "Los datos se guardaron con exito"
    '        End If
    '    Else
    '        Panel1.Visible = True
    '    End If
    'End Sub

    'Protected Sub cmdGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGuardar.Click
    '    If RadTxtObservacion.Text.Trim <> String.Empty Then
    '        csDAL.InsertaHistoricaRechazo(Session("noGestionIntegral"), RadTxtObservacion.Text.Trim, Session("clvUsuario"))
    '        Panel1.Visible = False
    '        RadTxtObservacion.Text = String.Empty
    '        Dim ds As New DataSet
    '        ds = csDAL.HistoricaRechazo(Session("noGestionIntegral"))
    '            With RadGrid1
    '            .DataSource = ds.Tables(0)
    '            .DataBind()
    '        End With
    '        lblEntrega.Text = "La observacion se guardo con exito"
    '    End If
    'End Sub

    Protected Sub button_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles button.Click
        Dim registro As String = Format(Now(), "MM/dd/yyyy HH:mm")
        Dim fecha As String = Format(RadDatePicker1.SelectedDate, "MM/dd/yyyy")
        If rdoBtnRecibio.Checked = True Then
            Panel1.Visible = False
            Dim ValidaEntr As Integer = csDAL.ValidaEntrega(Session("noGestionIntegral"))

            ValidaEntr = 1
            If ValidaEntr = 0 Then
                ScriptManager.RegisterStartupScript(Page, Page.GetType, "1", "alert('Error: faltan documentos');", True)
                lblEntrega.Text = "Error:Faltan documentos por verificar"
            Else
                If csDAL.GuardarEntregaAseguradora(Session("noGestionIntegral"), registro, fecha, 1, Session("clvUsuario")) = True Then
                    lblEntrega.Text = "Los datos se guardaron con exito..."
                Else
                    lblEntrega.Text = "Error: al Guardar la informacion..."
                End If

            End If
        Else
            Panel1.Visible = True
        End If
    End Sub

    Protected Sub button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles button2.Click
        If RadTxtObservacion.Text.Trim <> String.Empty Then
            csDAL.InsertaHistoricaRechazo(Session("noGestionIntegral"), RadTxtObservacion.Text.Trim, Session("clvUsuario"))
            Panel1.Visible = False
            RadTxtObservacion.Text = String.Empty
            Dim ds As New DataSet
            ds = csDAL.HistoricaRechazo(Session("noGestionIntegral"))
                With RadGrid1
                .DataSource = ds.Tables(0)
                .DataBind()
            End With
            lblEntrega.Text = "La observacion se guardo con exito"
        End If
    End Sub
End Class

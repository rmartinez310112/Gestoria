Imports System.Data
Partial Class AsignacionControl_BitacoraGestionExpediente
Inherits System.Web.UI.Page
    Dim csNeg As New ClaseNegocios
    Dim csSQLsvr As New BaseDatosSQL
    Dim csDAL As New DALClass
    'Protected Sub cmdGuardar0_Click(sender As Object, e As System.EventArgs) Handles cmdGuardar0.Click
    '    Panel1.Visible = True
    '    cmdGuardar0.Visible = False
    'End Sub

    'Protected Sub cmdGuardar_Click(sender As Object, e As System.EventArgs) Handles cmdGuardar.Click
    '    If txtComentarios.Text.Trim <> String.Empty Then
    '        csDAL.Insert_BitacoraGestionExpe(Session("noGestionIntegral"), txtComentarios.Text.Trim, Session("clvUsuario"))
    '        Panel1.Visible = False
    '        txtComentarios.Text = String.Empty
    '        Dim ds As New DataSet
    '        ds = csDAL.Select_BitacoraGestionExpe(Session("noGestionIntegral"))
    '            With RadGrid1
    '            .DataSource = ds.Tables(0)
    '            .DataBind()
    '        End With
    '    End If
    'End Sub

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
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Session("noGestionIntegral") <> Nothing Then
                Dim ds As New DataSet
                ds = csDAL.Select_BitacoraGestionExpe(Session("noGestionIntegral"))
                    With RadGrid1
                    .DataSource = ds.Tables(0)
                    .DataBind()
                End With
                buscaEstatus(Session("noGestionIntegral"))
            Else

                ConfigureNotification("Favor de Introducir No.Gestion")
            End If
        End If
    End Sub
    Private Sub buscaEstatus(ByVal noServicio As String)
        Dim comando As String = "select Reporte_status from ResportesGestionTotal_vw where NoGestion='" & noServicio & "'"
        Dim ds As New DataSet
        ds = csSQLsvr.EjecutarSPDataset(comando, Session("connGestion"))
        Dim dr As DataRow
        For Each dr In ds.Tables(0).Rows
            If dr("Reporte_status") = 10 Then
                lblError.Text = "El servicio es INACTIVO, favor de verificar si procede una nueva bitacora con su supervisor"
            End If

            If dr("Reporte_status") = 3 Then
                lblError.Text = "El servicio YA ESTA TERMINADO, UNICAMENTE puedes dar de alta una bitacora si el cliente se comunica, si tienes dudas habla con tu supervisor y/o coordinador"
            End If

            If dr("Reporte_status") = 1 Then
                lblError.Text = "El servicio ya esta como CANCELADO."
            End If
        Next

    End Sub
   
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Panel1.Visible = True
        Button1.Visible = False
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        If txtComentarios.Text.Trim <> String.Empty Then
            csDAL.Insert_BitacoraGestionExpe(Session("noGestionIntegral"), txtComentarios.Text.Trim, Session("clvUsuario"))
            Panel1.Visible = False
            txtComentarios.Text = String.Empty
            Dim ds As New DataSet
            ds = csDAL.Select_BitacoraGestionExpe(Session("noGestionIntegral"))
                With RadGrid1
                .DataSource = ds.Tables(0)
                .DataBind()
            End With
        End If

    End Sub
End Class

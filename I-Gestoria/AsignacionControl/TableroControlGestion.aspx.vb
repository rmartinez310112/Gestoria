Imports System.Data
Imports System.Web
Partial Class AsignacionControl_TableroControlGestion
    Inherits System.Web.UI.Page
    Dim csNeg As New ClaseNegocios
    Dim csSQLsvr As New BaseDatosSQL
    Dim csDAL As New DALClass

#Region "Procesos"

    Private Sub cargaIndicadores()

        Dim cuenta As Integer = RadGrid1.Items.Count - 1
        If cuenta >= 0 Then
            ' 13
            Dim x As Integer = 0
            For x = 0 To cuenta
                Try
                    Dim noGestion As String = RadGrid1.Items(x).Cells(3).Text
                    RadGrid1.Items(x).Cells(13).Text = csDAL.ChecaDocSolicitados(noGestion)
                    ' RadGrid1.Items(x).Cells(14).Text = csDAL.ChecaDocSolicitadosEntregados(noGestion)
                    'RadGrid1.Items(x).Cells(15).Text = csDAL.ChecaDocSEntregadosDigitalizados(noGestion)
                    'RadGrid1.Items(x).Cells(16).Text = csDAL.ChecaDocSolicitadosVerificados(noGestion)
                    'RadGrid1.Items(x).Cells(17).Text = csDAL.ChecaDocEntregadosGestor(noGestion)
                    'RadGrid1.Items(x).Cells(18).Text = csDAL.ChecaDocEntregadosCliente(noGestion)
                    ' falta Rutina de pagados
                    If RadGrid1.Items(x).Cells(13).Text.Trim = "SI" Then RadGrid1.Items(x).Cells(13).BackColor = Drawing.Color.GreenYellow Else RadGrid1.Items(x).Cells(13).BackColor = Drawing.Color.Red
                    If RadGrid1.Items(x).Cells(14).Text.Trim = "SI" Then RadGrid1.Items(x).Cells(14).BackColor = Drawing.Color.GreenYellow Else RadGrid1.Items(x).Cells(14).BackColor = Drawing.Color.Red
                    If RadGrid1.Items(x).Cells(15).Text.Trim = "SI" Then RadGrid1.Items(x).Cells(15).BackColor = Drawing.Color.GreenYellow Else RadGrid1.Items(x).Cells(15).BackColor = Drawing.Color.Red
                    If RadGrid1.Items(x).Cells(16).Text.Trim = "SI" Then RadGrid1.Items(x).Cells(16).BackColor = Drawing.Color.GreenYellow Else RadGrid1.Items(x).Cells(16).BackColor = Drawing.Color.Red
                    If RadGrid1.Items(x).Cells(17).Text.Trim = "SI" Then RadGrid1.Items(x).Cells(17).BackColor = Drawing.Color.GreenYellow Else RadGrid1.Items(x).Cells(17).BackColor = Drawing.Color.Red
                    If RadGrid1.Items(x).Cells(18).Text.Trim = "SI" Then RadGrid1.Items(x).Cells(18).BackColor = Drawing.Color.GreenYellow Else RadGrid1.Items(x).Cells(18).BackColor = Drawing.Color.Red

                Catch ex As Exception

                End Try
               
            Next

        End If
    End Sub
    Public Sub ABRIR_VENTANA(ByVal PopUpWindowPage As String, ByVal alto As Integer, ByVal largo As Integer)
        Dim Script As String = ""
        Script = " <script language=JavaScript id='PopupWindow'>  var confirmWin = null; confirmWin = window.open('" & PopUpWindowPage & "','myWindow','status = 1, scrollbars=1,height = " & alto & ", width = " & largo & ", resizable = 1 '); if((confirmWin != null) && (confirmWin.opener==null)) { confirmWin.opener = self; } </script> "
        If Not ClientScript.IsStartupScriptRegistered("PopupWindow") Then
            ClientScript.RegisterStartupScript(Me.GetType, "PopupWindow", Script)
        End If
    End Sub
    Public Sub cargaEstados()

        Dim comando As String = "exec Select_cbo_estados"
        csSQLsvr.LlenarRadCombo(cboEstado, comando, Session("connGestion"))

    End Sub

    Public Sub cargaClientes()
        Dim comando As String = "exec Select_cbo_clientes"
        csSQLsvr.LlenarRadCombo(CboCliente, comando, Session("connGestion"))
    End Sub

    Public Sub cargaEstatus()
        Dim comando As String = "select status_Clave, status_Descripcion from statusGestion order by status_Clave"
        csSQLsvr.LlenarRadCombo(cboEstatus, comando, Session("connGestion"))
        CboCliente.SelectedValue = 100
    End Sub

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            txtFecha2.SelectedDate = Now()
            txtFecha1.SelectedDate = DateTime.Now.AddDays(-7)
            cargaEstados()
            cargaClientes()
            cargaEstatus()
            Panel1.Visible = False
            Button1.Visible = False

        End If
    End Sub

    'Protected Sub RadButton1_Click(sender As Object, e As System.EventArgs) Handles RadButton1.Click
    '    Dim ds As New DataSet
    '    Dim fecha1 As String = Format(txtFecha1.SelectedDate, "yyyyMMdd") & " 00:00"
    '    Dim fecha2 As String = Format(txtFecha2.SelectedDate, "yyyyMMdd") & " 23:59"
    '    Dim cliente As Integer = CboCliente.SelectedValue
    '    Dim estado As Integer = cboEstado.SelectedValue
    '    Dim status As Integer = cboEstatus.SelectedValue
    '    Dim noServicio As Double = 0
    '    If RadTextBox1.Text.Trim <> String.Empty Then
    '        noServicio = RadTextBox1.Text.Trim
    '    End If
    '    ds = csDAL.CargaExpedientesGestion(fecha1, fecha2, noServicio, cliente, estado, status)
    '        With RadGrid1
    '        .DataSource = ds.Tables(0)
    '        .DataBind()
    '    End With
    '    cargaIndicadores()
    '    If (RadGrid1.Items.Count - 1) <> 0 Then
    '        cmdExcel.Visible = True
    '    End If
    'End Sub

    'Protected Sub cmdExcel_Click(sender As Object, e As System.EventArgs) Handles cmdExcel.Click
    '    RadGrid1.AllowPaging = False
    '    RadGrid1.ExportSettings.OpenInNewWindow = True
    '    RadGrid1.ExportSettings.ExportOnlyData = False

    '    RadGrid1.MasterTableView.ExportToExcel()
    'End Sub

    Protected Sub RadGrid1_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If e.CommandName = "cmdGestion" Then
            Dim master As MasterPageGestionOperativa = DirectCast(Me.Master, MasterPageGestionOperativa)
            Dim nExpediente As Telerik.Web.UI.RadNumericTextBox = Me.Master.FindControl("txtNoGestion")
            nExpediente.Text = e.Item.Cells(3).Text.Trim
            Session("noGestionIntegral") = e.Item.Cells(3).Text.Trim
            master.CargaDatosExpediente()
            master.Response.Redirect("~/AsignacionControl/TableroControlGestion.aspx")
        End If
    End Sub

    Protected Sub Button1234_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1234.Click
        Dim ds As New DataSet
        Dim fecha1 As String = Format(txtFecha1.SelectedDate, "yyyyMMdd") & " 00:00"
        Dim fecha2 As String = Format(txtFecha2.SelectedDate, "yyyyMMdd") & " 23:59"
        Dim cliente As Integer = CboCliente.SelectedValue
        Dim estado As Integer = cboEstado.SelectedValue
        Dim status As Integer = cboEstatus.SelectedValue

        Dim noControl As Double = 0
        
        ds = csDAL.CargaExpedientesGestion(fecha1, fecha2, cliente, estado, status, noControl)
        With RadGrid1
            .DataSource = ds.Tables(0)
            .DataBind()
        End With
        ' cargaIndicadores()
        If RadGrid1.Items.Count <> 0 Then
            Button1.Visible = True
            Panel1.Visible = True
        Else
            ConfigureNotification("ATENCION!,No existe informacion,Favor de verificar parametros")
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        RadGrid1.AllowPaging = False
        RadGrid1.ExportSettings.OpenInNewWindow = True
        RadGrid1.ExportSettings.ExportOnlyData = False

        RadGrid1.MasterTableView.ExportToExcel()
    End Sub
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
End Class

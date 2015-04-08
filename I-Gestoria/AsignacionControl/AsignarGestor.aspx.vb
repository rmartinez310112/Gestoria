Imports System.Data

Partial Class AsignacionControl_AsignarGestor
Inherits System.Web.UI.Page
    Dim csNeg As New ClaseNegocios
    Dim csSQLsvr As New BaseDatosSQL
    Dim csDAL As New DALClass
#Region "Procesos"
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
#End Region

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
           ' If Session("noGestionIntegral") <> Nothing Then
                cargaEstados()
                cargaClientes()
                Panel1.Visible = False

            'Else
                'ConfigureNotification("Favor de Introducir No.Gestion")
            'End If
        End If
    End Sub




    Protected Sub RadGrid1_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If e.CommandName = "cmdAsigna" Then
            Dim sGestion As String = e.Item.Cells(3).Text.Trim
            Dim p_estado As String = Mid(sGestion, 9, 2)
            Dim master As MasterPageGestionOperativa = DirectCast(Me.Master, MasterPageGestionOperativa)
            Dim nExpediente As Telerik.Web.UI.RadNumericTextBox = Me.Master.FindControl("txtNoGestion")
            nExpediente.Text = e.Item.Cells(3).Text.Trim
            master.CargaDatosExpediente()
            ' ABRIR_VENTANA("BuscarGestor.aspx?nogestion=" & sGestion & "&clvEstado=" & p_estado, 800, 1024)
            Response.Redirect("AsignarGestorTramite.aspx?nogestion=" & sGestion & "&clvEstado=" & p_estado)
        End If

        If e.CommandName = "cmdConfirma" Then
            Dim sGestion As String = e.Item.Cells(3).Text.Trim
            Dim p_estado As String = Mid(sGestion, 9, 2)
            ABRIR_VENTANA("CierreAsignacionGestionCC.aspx?nogestion=" & sGestion & "&clvEstado=" & p_estado, 200, 800)
        End If

        If e.CommandName = "cmdNoGes" Then
            Dim sGestion As String = e.Item.Cells(3).Text.Trim
            Dim p_estado As String = Mid(sGestion, 9, 2)
            Dim master As MasterPageGestionOperativa = DirectCast(Me.Master, MasterPageGestionOperativa)
            Dim nExpediente As Telerik.Web.UI.RadNumericTextBox = Me.Master.FindControl("txtNoGestion")
            nExpediente.Text = e.Item.Cells(3).Text.Trim
            master.CargaDatosExpediente()
            ' ABRIR_VENTANA("BuscarGestor.aspx?nogestion=" & sGestion & "&clvEstado=" & p_estado, 800, 1024)
            Response.Redirect("AsignarGestorTramite.aspx?nogestion=" & sGestion & "&clvEstado=" & p_estado)
        End If

        'If e.CommandName = "cmdGestion" Then
        '    Dim master As MasterPageGestionOperativa = DirectCast(Me.Master, MasterPageGestionOperativa)
        '    Dim nExpediente As Telerik.Web.UI.RadNumericTextBox = Me.Master.FindControl("txtNoGestion")
        '    nExpediente.Text = e.Item.Cells(3).Text.Trim
        '    Session("noGestionIntegral") = e.Item.Cells(3).Text.Trim
        '    master.CargaDatosExpediente()
        '    master.Response.Redirect("~/AsignacionControl/TableroControlGestion.aspx")
        'End If


    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ds As New DataSet
        ds = csDAL.buscaAsuntosSinAsignar(CboCliente.SelectedValue, cboEstado.SelectedValue)
        Panel1.Visible = True
            With RadGrid1
            .DataSource = ds.Tables(0)
            .DataBind()
        End With
    End Sub

End Class

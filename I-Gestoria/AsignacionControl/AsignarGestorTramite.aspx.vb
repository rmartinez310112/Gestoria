Imports System.Data
Imports System.Web
Partial Class AsignacionControl_AsignarGestorTramite
Inherits System.Web.UI.Page
    Dim csNeg As New ClaseNegocios
    Dim csSQLsvr As New BaseDatosSQL
    Dim csDAL As New DALClass
    #Region "PROCESOS"
    'Public Sub ABRIR_VENTANA(ByVal PopUpWindowPage As String, ByVal alto As Integer, ByVal largo As Integer)
    '    Dim Script As String = ""
    '    Script = " <script language=JavaScript id='PopupWindow'>  var confirmWin = null; confirmWin = window.open('" & PopUpWindowPage & "','myWindow','status = 1, scrollbars=1,height = " & alto & ", width = " & largo & ", resizable = 1 '); if((confirmWin != null) && (confirmWin.opener==null)) { confirmWin.opener = self; } </script> "
    '    If Not ClientScript.IsStartupScriptRegistered("PopupWindow") Then
    '        ClientScript.RegisterStartupScript(Me.GetType, "PopupWindow", Script)
    '    End If
    'End Sub


    Private Sub GestorAsignado()
        Dim cuenta As Integer = RadGrid2.Items.Count - 1
        Dim x As Integer = 0
        For x = 0 To cuenta
            Dim rfcGestor As String = RadGrid2.Items(x).Cells(4).Text.Trim
            Dim nomGestor As String = csDAL.buscaGestorAsignado(rfcGestor)
            RadGrid2.Items(x).Cells(7).Text = nomGestor
        Next
    End Sub
    #End Region
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Session("noGestionIntegral") <> Nothing Then
                Dim ds As DataSet = csDAL.buscaTramitesPendientesAsignar(Request.QueryString("nogestion"))
                    With RadGrid1
                    .DataSource = ds.Tables(0)
                    .DataBind()
                End With

                ds.Clear()
                ds = csDAL.buscaDocumentosGestionAsignados(Request.QueryString("nogestion"))
                    With RadGrid2
                    .DataSource = ds.Tables(0)
                    .DataBind()
                End With
                GestorAsignado()
            End If
        End If
    End Sub

  

   
    Protected Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If e.CommandName = "cmdAsigna" Then
            Dim TRAMITE As Integer = e.Item.Cells(2).Text.Trim
            Dim sGestion As String = Request.QueryString("nogestion")
            Dim p_estado As String = Mid(sGestion, 9, 2)
            'ABRIR_VENTANA("BuscarGestor.aspx?nogestion=" & sGestion & "&clvEstado=" & p_estado & "&tramite=" & TRAMITE & "&consec=0", 800, 1024)
            'Response.Redirect("BuscarGestor.aspx?nogestion=" & sGestion & "&clvEstado=" & p_estado & "&tramite=" & TRAMITE & "&consec=0")
            Dim window As New Telerik.Web.UI.RadWindow
                With window
                .NavigateUrl = "BuscarGestor.aspx?nogestion=" & sGestion & "&clvEstado=" & p_estado & "&tramite=" & TRAMITE & "&consec=0"
                .VisibleOnPageLoad = True
                .ID = "RadWindow1"
                .Width = 900
                .Height = 400
                .Modal = True
                RadWindowManager1.Windows.Add(window)

            End With
        End If
    End Sub

    Protected Sub RadGrid2_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid2.ItemCommand
        If e.CommandName = "cmdReasigna" Then
            Dim TRAMITE As Integer = e.Item.Cells(2).Text.Trim
            Dim sGestion As String = Request.QueryString("nogestion")
            Dim p_estado As String = Mid(sGestion, 9, 2)
            Dim consecDoc As Integer = e.Item.Cells(3).Text.Trim
            'ABRIR_VENTANA("BuscarGestor.aspx?nogestion=" & sGestion & "&clvEstado=" & p_estado & "&tramite=" & TRAMITE & "&consec=" & consecDoc, 800, 1024)
            Dim window As New Telerik.Web.UI.RadWindow
                With window
                .NavigateUrl = "BuscarGestor.aspx?nogestion=" & sGestion & "&clvEstado=" & p_estado & "&tramite=" & TRAMITE & "&consec=" & consecDoc
                .VisibleOnPageLoad = True
                .ID = "RadWindow1"
                .Width = 900
                .Height = 400
                .Modal = True
                RadWindowManager1.Windows.Add(window)

            End With
        End If
    End Sub
End Class

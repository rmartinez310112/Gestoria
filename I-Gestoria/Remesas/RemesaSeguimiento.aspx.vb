Imports System.Data
Imports Telerik.Web.UI
Imports Telerik.Web


Partial Class RemesaSeguimiento
    Inherits System.Web.UI.Page
    Dim csSQLsvr As New BaseDatosSQL
    Dim resp As New Resultado
    'Private master As MasterPage
    Dim VentanasWin As New Ventanas
    Dim csDAL As New DALClass

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        VentanasWin = New Ventanas(Master)

        If Not Page.IsPostBack Then

            cargaClientes()
            CargaTipoSeg()
            cargaEstados()
            Seleccioninicialfechas()
            SetFechas()
            CargarGrid()
            cargaTipoSeguimiento()


        End If
    End Sub

    Public Sub cargaTipoSeguimiento()
        csSQLsvr.LlenarRadCombo(cmbSeguimiento, "SELECT catTipoSeg_clvTipoSeg,catTipoSeg_Descripcion FROM catTipoSeguimiento", Session("connGestion"))
    End Sub
    Public Sub cargaClientes()
        Dim comando As String = "exec Select_cbo_clientes"
        csSQLsvr.LlenarRadCombo(cmbEstado, comando, Session("connGestion"))
    End Sub


    Public Sub cargaEstados()

        Dim comando As String = "exec Select_cbo_estados"
        csSQLsvr.LlenarRadCombo(cmbEstado, comando, Session("connGestion"))

    End Sub
    Public Sub CargaMpio(ByVal clvEstado As Integer)

        Dim comando As String = "exec Select_cbo_Municipios " & clvEstado
        csSQLsvr.LlenarRadCombo(cboMpio, comando, Session("connGestion"))
    End Sub
    Public Sub CargaTipoSeg()

        Dim comando As String = "exec Select_cbo_TipoSeguimientoAsigCat "
        csSQLsvr.LlenarRadCombo(cmbSeguimiento, comando, Session("connGestion"))
    End Sub

    

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click


    End Sub
   


   

   
    

    Protected Sub radSeguimiento_PageSizeChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridPageSizeChangedEventArgs) Handles radSeguimiento.PageSizeChanged
        Dim num As Integer
        num = e.NewPageSize
        CargarGrid()
    End Sub
    Public Function SetFechas()
        Dim FechaActual As System.DateTime
        Dim answer As System.DateTime
        FechaActual = System.DateTime.Now
        answer = FechaActual.AddDays(-30)

        'answer = CDate(Today.Date.Year & "/" & Today.Date.Month & "/" & Today.Day - 30)
        Me.rdDtpFI.SelectedDate = answer
        Me.rdDtpFF.SelectedDate = DateTime.Now.Date

  
       
    End Function
    Private Sub CargarGrid()

        Dim remesa As String = txtRemesa.Text.Trim
        Dim gestor As String = txtGestor.Text.Trim
        Dim estado As Integer = cmbEstado.SelectedValue
        Dim Finicio As String = rdDtpFI.SelectedDate.Value.ToString("yyyy/MM/dd")
        Dim Ffinal As String = rdDtpFF.SelectedDate.Value.ToString("yyyy/MM/dd")
        Dim tipoSeg As Integer = cmbSeguimiento.SelectedValue

       
        Dim strQuery As String

        strQuery = "'where re.Remesa<> ''" & remesa & "'' and  (RTRIM(aj.NOMBRE) + '' '' + RTRIM(aj.PATERNO) + '' '' + RTRIM(aj.MATERNO))LIKE''" & gestor & "%'' and rg.Reporte_clvEstado<> " & estado & " and re.FechaAlta BETWEEN ''" & Finicio & "'' and ''" & Ffinal & "'''"




        resp.DataTable = csSQLsvr.QueryDataDatable("exec sp_filtroAsig_Seguimiento " & strQuery & "", Session("connGestion"))
        ViewState("dataset") = resp.DataTable


        'csSQLsvr.LlenarRadGridCustom(radSeguimiento, "exec spGetSeguimientoGestoria", Session("connGestion"), numPage)

        ' Carga el grid
        radSeguimiento.CurrentPageIndex = 0
        radSeguimiento.DataSource = ViewState("dataset")
        radSeguimiento.DataBind()
        radSeguimiento.Dispose()



        'lblNumcitas.Text = resp.DataTable.Rows.Count


        ''UpdatePanelGrid.Update()
    End Sub

  

    Protected Sub radSeguimiento_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles radSeguimiento.ItemCommand
       

    End Sub

    Protected Sub radSeguimiento_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles radSeguimiento.ItemDataBound
        If TypeOf e.Item Is GridDataItem Then
            Dim gridDataItem As GridDataItem = CType(e.Item, GridDataItem)
            'Dim strColumnValue As String = gridDataItem("FieldName").Text
            'DO SOMETHING
            'gridDataItem("FieldName").Text = strColumnValue
        End If
    End Sub

    Protected Sub RadAjaxManager1_AjaxRequest(ByVal sender As Object, ByVal e As UI.AjaxRequestEventArgs) 'Handles RadAjaxManager1.AjaxRequest
        ' RadAjaxManager1.RaisePostBackEvent("Rebind")
        If e.Argument = "Rebind" Then
            radSeguimiento.MasterTableView.SortExpressions.Clear()
            radSeguimiento.MasterTableView.GroupByExpressions.Clear()
            radSeguimiento.Rebind()
            CargarGrid()
        ElseIf e.Argument = "RebindAndNavigate" Then
            radSeguimiento.MasterTableView.SortExpressions.Clear()
            radSeguimiento.MasterTableView.GroupByExpressions.Clear()
            radSeguimiento.MasterTableView.CurrentPageIndex = radSeguimiento.MasterTableView.PageCount - 1
            radSeguimiento.Rebind()
        End If
        'RadAjaxManager1.EnableAJAX = False
    End Sub

    Protected Sub detalle1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles detalle1.Click

        If Session("noGestionIntegral") <> "" Then

            VentanasWin.Abrir_winwinDetalleSeguimientoGestor()

        Else
            ConfigureNotification("Favor de seleccionar un numero de servicio")
        End If

    End Sub

    Protected Sub RadButton3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButton3.Click

        If Session("noGestionIntegral") <> "" Then

            VentanasWin.Abrir_winwinDetalleSeguimientoLlamada()

        Else
            ConfigureNotification("Favor de seleccionar un numero de servicio")
        End If

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


    Protected Sub Button1_Click(sender As Object, e As System.EventArgs) Handles BtnActualiza.Click

        CargarGrid()
    End Sub

    Public Sub Seleccioninicialfechas()

        Finicio.Visible = True
        Ffinal.Visible = True
        rdDtpFF.Visible = True
        rdDtpFI.Visible = True
    End Sub

    Protected Sub cmbEstado_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbEstado.SelectedIndexChanged
        CargaMpio(cmbEstado.SelectedValue)
    End Sub
End Class
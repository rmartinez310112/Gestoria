Imports System.Data
Imports System.Web.UI.WebControls
Imports Telerik.Web.UI
Partial Class PagosGastosGestor_Consulta_Pagos
    Inherits System.Web.UI.Page

    'Dim csNeg As New ClaseNegocios
    'Dim csSQLsvr As New BaseDatosSQL
    'Dim Cadena As String = GlobalVariables.sqlString
    Dim csDAL As New DALClass
    Dim win As Ventanas

    Protected Sub ConfigureNotification(ByVal texto As String)
        'String
        'lblError0.Text = texto
        RadNotification1.Title = "Atención"
        RadNotification1.Text = texto
        'Enum
        RadNotification1.Position = Telerik.Web.UI.NotificationPosition.Center
        RadNotification1.Animation = Telerik.Web.UI.NotificationAnimation.Fade
        'notificacion.ContentScrolling = Telerik.Web.UI.NotificationScrolling.Default
        RadNotification1.AutoCloseDelay = 50000
        'Unit
        RadNotification1.Width = 300
        RadNotification1.Height = 150
        RadNotification1.OffsetX = -10
        RadNotification1.OffsetY = 10

        RadNotification1.Pinned = False
        RadNotification1.EnableRoundedCorners = True
        RadNotification1.EnableShadow = True
        RadNotification1.KeepOnMouseOver = False
        RadNotification1.VisibleTitlebar = True
        RadNotification1.ShowCloseButton = True
        RadNotification1.Show()

    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        win = New Ventanas(Master)
        If Not Page.IsPostBack Then
           
        End If
        If Page.IsPostBack Then
           
        End If
    End Sub

    Public Sub cargaGastosC()
        Dim ds As New DataSet
        Dim FInicial As Telerik.Web.UI.RadDatePicker = SelectorFechas.FindControl("rdFI")
        Dim FFinal As Telerik.Web.UI.RadDatePicker = SelectorFechas.FindControl("rdFF")

        Dim FechaI As String = FInicial.SelectedDate.Value.ToString("yyyy-MM-dd") '  .SelectedDate .ToString("yyyy-MM-dd")
        Dim FechaF As String = FFinal.SelectedDate.Value.ToString("yyyy-MM-dd") '.ToString("yyyy-MM-dd")
        Dim serv As String = txtServ.Text
        Dim gest As String = txtGest.Text
        ds = csDAL.buscaReciboPago(FechaI, FechaF, serv, gest)
        With rgRegistrados
            .DataSource = ds.Tables(0).Rows
            .DataBind()
        End With
        'rfc = ""
        ds.Clear()
        ds.Dispose()
    End Sub

    Public Sub cargaGastosAutorizados()
        Dim ds As New DataSet

        Dim FInicial As Telerik.Web.UI.RadDatePicker = SelectorFechas.FindControl("rdFI")
        Dim FFinal As Telerik.Web.UI.RadDatePicker = SelectorFechas.FindControl("rdFF")

        Dim FechaI As String = FInicial.SelectedDate.Value.ToString("yyyy-MM-dd") '  .SelectedDate .ToString("yyyy-MM-dd")
        Dim FechaF As String = FFinal.SelectedDate.Value.ToString("yyyy-MM-dd") '.ToString("yyyy-MM-dd")
        Dim serv As String = txtServ.Text
        Dim gest As String = txtGest.Text

        ds = csDAL.buscaPagosAutorizados(FechaI, FechaF, serv, gest)
        With rgAutorizados
            .DataSource = ds.Tables(0).Rows
            .DataBind()
        End With
        'rfc = ""
        ds.Clear()
        ds.Dispose()
        rgAutorizados.Visible = True
    End Sub

    Public Sub cargaGastosCancelados()
        Dim ds As New DataSet
        Dim FInicial As Telerik.Web.UI.RadDatePicker = SelectorFechas.FindControl("rdFI")
        Dim FFinal As Telerik.Web.UI.RadDatePicker = SelectorFechas.FindControl("rdFF")

        Dim FechaI As String = FInicial.SelectedDate.Value.ToString("yyyy-MM-dd") '  .SelectedDate .ToString("yyyy-MM-dd")
        Dim FechaF As String = FFinal.SelectedDate.Value.ToString("yyyy-MM-dd") '.ToString("yyyy-MM-dd")
        Dim serv As String = txtServ.Text
        Dim gest As String = txtGest.Text
        ds = csDAL.buscaPagosCancelados(FechaI, FechaF, serv, gest)
        With rgCancelados
            .DataSource = ds.Tables(0).Rows
            .DataBind()
        End With
        'rfc = ""
        ds.Clear()
        ds.Dispose()
        rgCancelados.Visible = True
    End Sub


    Protected Sub BtnResultado_Click(sender As Object, e As System.EventArgs) Handles BtnResultado.Click
        If RadComboBox1.SelectedValue = 1 Then
            cargaGastosC()
            rgRegistrados.Visible = True
            rgAutorizados.Visible = False
            rgCancelados.Visible = False

        ElseIf RadComboBox1.SelectedValue = 2 Then
            cargaGastosAutorizados()
            rgAutorizados.Visible = True
            rgRegistrados.Visible = False
            rgCancelados.Visible = False

        Else
            cargaGastosCancelados()
            rgCancelados.Visible = True
            rgRegistrados.Visible = False
            rgAutorizados.Visible = False

        End If
    End Sub

    Protected Sub RadButton1_Click(sender As Object, e As System.EventArgs) Handles RadButton1.Click
        Dim grid As RadGrid

        If rgRegistrados.Visible Then
            grid = rgRegistrados
        ElseIf rgAutorizados.Visible Then
            grid = rgAutorizados
        ElseIf rgCancelados.Visible Then
            grid = rgCancelados
        End If



        grid.AllowPaging = False
        grid.Columns(7).Display = False
        grid.Columns(8).Display = False
        If grid.UniqueID <> rgCancelados.UniqueID Then grid.Columns(9).Display = False


        grid.ExportSettings.OpenInNewWindow = True
        grid.ExportSettings.ExportOnlyData = False

        grid.MasterTableView.ExportToExcel()
    End Sub

    Protected Sub RadGrid2_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles rgRegistrados.ItemCommand
        Dim dataItem As GridDataItem = e.Item
        Dim indexRow As Integer = Convert.ToInt32(e.Item.ItemIndex)
        Dim item As GridDataItem = rgRegistrados.Items(indexRow)
        Dim item3 As GridDataItem = DirectCast(e.Item, GridDataItem)

        If e.CommandName = "cmdCancela" Then

            Session("servicio") = item.Cells(2).Text
            Dim fechaCancela As String = "getdate()"
            Dim usua As String = Session("clvUsuario")
            csDAL.update_cancelaComprobacion(fechaCancela, usua, Session("servicio"))
            cargaGastosC()
        ElseIf e.CommandName = "cmdGuardar" Then
            Session("servicio") = item.Cells(2).Text
            Dim usua1 As String = Session("clvUsuario")
            Dim fechaAprueba As String = "getdate()"
            Dim txt As Telerik.Web.UI.RadTextBox = e.Item.FindControl("RadTextBox1")


            If txt.Text <> Nothing Then

                csDAL.update_GuardaComprobacion(txt.Text.Trim, fechaAprueba, usua1, Session("servicio"))
                cargaGastosC()
            Else
                ConfigureNotification("Para guardar autorizacion se necesita poner No. de Recibo")
            End If

        End If
    End Sub

    

End Class

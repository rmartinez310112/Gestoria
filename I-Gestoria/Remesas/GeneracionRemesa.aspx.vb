Imports System.Data
Imports Telerik.Web.UI
Imports Telerik.Web


Partial Class Seguimiento
    Inherits System.Web.UI.Page
    Dim csSQLsvr As New BaseDatosSQL
    Dim serv As New ClaseBaseGestoria
    Dim resp As New Resultado
    'Private master As MasterPage
    Dim VentanasWin As New Ventanas
    Dim csDAL As New DALClass

    'enumerado del grid
    ''' <summary>
    ''' enumerado del grid(columnas
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Enum ColGrid
        Gestion = 2
        Servicio
        NoGestion2
        Poliza
        Estado
        Municipio
        Cliente
        TipoServicio
        FechaHoraCita
        DiasTranscurridos
        SegACita
        SegDCita
        SegATramite
        SegEnvDoc
        Int
        SigAc
        FecLimSeg
        ExpeRec
        MotiRec

    End Enum



    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        VentanasWin = New Ventanas(Master)
        If Not Page.IsPostBack Then
            cargaClientes()
            cargaEstados()
            cargaServicioTipo()
            'CargarGrid()
        End If
    End Sub

    Public Sub AgregarValorInicialDDL(ByRef ddl As Telerik.Web.UI.RadComboBox)
        ddl.Items.Add(New Telerik.Web.UI.RadComboBoxItem("----------", "0"))
        ddl.SelectedValue = "0"
    End Sub

    Public Sub cargaClientes()
        Dim comando As String = "exec Select_cbo_clientes"
        csSQLsvr.LlenarRadCombo(cmbCliente, comando, Session("connGestion"))
    End Sub

    Public Sub cargaEstados()
        Dim comando As String = "Select Clave, Nombre from Estados Order By Clave"
        csSQLsvr.LlenarRadCombo(cmbEstado, comando, Session("connGestion"))
    End Sub

    Protected Sub cmbEstado_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbEstado.SelectedIndexChanged
        Dim idEstado As Integer
        idEstado = cmbEstado.SelectedValue
        cargaMunicipios(idEstado)
    End Sub

    Public Sub cargaMunicipios(ByVal estado As String)
        Dim comando As String
        If estado <> "" Then
            comando = "exec Select_municipios_sp @id_estado = " & estado
        Else
            comando = "exec Select_municipios_sp"
        End If
        csSQLsvr.LlenarRadCombo(cmbMunicipio, comando, Session("connGestion"))
        AgregarValorInicialDDL(cmbMunicipio)

    End Sub

    Public Sub cargaServicioTipo()
        Dim comando As String = "Select Tramite_clvTramite, Tramite_Descripcion from TramitesGestion order by Tramite_clvTramite "
        csSQLsvr.LlenarRadCombo(cmbServicio, comando, Session("connGestion"))

    End Sub

    Protected Sub btnBuscar_Click(sender As Object, e As System.EventArgs) Handles btnBuscar.Click
        If cmbCliente.SelectedValue = 0 Then
            ConfigureNotification("Debe seleccionar un Cliente.")
            cmbCliente.Focus()
            Exit Sub
        ElseIf cmbEstado.SelectedValue = 0 Then
            ConfigureNotification("Debe seleccionar un Estado.")
            cmbEstado.Focus()
            Exit Sub
        ElseIf cmbServicio.SelectedValue = 0 Then
            ConfigureNotification("Debe seleccionar un Tipo de Servicio.")
            cmbServicio.Focus()
            Exit Sub
        End If
        CargarGrid()
        btnGenerar.Enabled = True
    End Sub


    Protected Sub radSeguimiento_PageSizeChanged(sender As Object, e As Telerik.Web.UI.GridPageSizeChangedEventArgs) Handles radSeguimiento.PageSizeChanged
        Dim num As Integer
        num = e.NewPageSize
        CargarGrid()
    End Sub

    Private Sub CargarGrid()

        Dim s As New CBusqueda_Servicios

        s.Cliente = IIf(cmbCliente.SelectedValue = 0, "", cmbCliente.SelectedValue)
        s.Estado = IIf(cmbEstado.SelectedValue = 0, "", cmbEstado.SelectedValue)
        s.Municipio = IIf(cmbMunicipio.SelectedValue = 0, "", cmbMunicipio.SelectedValue)
        s.Servicio = IIf(cmbServicio.SelectedValue = 0, "", cmbServicio.SelectedValue)

        Dim dt As New DataTable
        dt = serv.Consultar_Servicios_Filtrados(Session("IdUsuario"), s)
        ViewState("dataset") = dt

        radSeguimiento.CurrentPageIndex = 0
        radSeguimiento.DataSource = ViewState("dataset")
        radSeguimiento.DataBind()
        radSeguimiento.Dispose()

        lblNumcitas.Text = dt.Rows.Count


    End Sub

    Protected Sub radSeguimiento_PageIndexChanged(sender As Object, e As Telerik.Web.UI.GridPageChangedEventArgs) Handles radSeguimiento.PageIndexChanged
        ' Paginación
        Dim dt As DataTable = ViewState("dataset")
        radSeguimiento.DataSource = dt.DefaultView
        radSeguimiento.DataBind()
        radSeguimiento.Dispose()
        'UpdatePanelGrid.Update()
    End Sub

    Protected Sub radSeguimiento_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles radSeguimiento.ItemCommand
    

    End Sub

    Protected Sub radSeguimiento_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles radSeguimiento.ItemDataBound
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

    Protected Sub radSeguimiento_ItemCreated(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles radSeguimiento.ItemCreated
        'If TypeOf e.Item Is GridDataItem Then
        '    Dim editLink As HyperLink = DirectCast(e.Item.FindControl("EditLink"), HyperLink)
        '    editLink.Attributes("href") = "javascript:void(0);"
        '    editLink.Attributes("onclick") = [String].Format("return ShowEditForm('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues(e.Item.ItemIndex)("EmployeeID"), e.Item.ItemIndex)
        'End If
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


    Protected Sub ToggleRowSelection(ByVal sender As Object, ByVal e As EventArgs)
        CType(CType(sender, CheckBox).NamingContainer, GridItem).Selected = CType(sender, CheckBox).Checked
    End Sub

    Protected Sub ToggleSelectedState(ByVal sender As Object, ByVal e As EventArgs)
        Dim headerCheckBox As CheckBox = CType(sender, CheckBox)
        For Each dataItem As GridDataItem In radSeguimiento.MasterTableView.Items
            CType(dataItem.FindControl("CheckBox1"), CheckBox).Checked = headerCheckBox.Checked
            'dataItem.Selected = headerCheckBox.Checked
        Next
    End Sub


    Protected Sub btnGenerar_Click(sender As Object, e As System.EventArgs) Handles btnGenerar.Click
        Dim cuantos As Integer = 0
        For Each dataItem As GridDataItem In radSeguimiento.MasterTableView.Items
            If CType(dataItem.FindControl("CheckBox1"), CheckBox).Checked = True Then
                cuantos = cuantos + 1
            End If
        Next

        If cuantos = 0 Then
            ConfigureNotification("Selecciona uno o más Registros")
            Exit Sub
        Else
            ServiciosRemesa()
            Dim Remesa = New CNumero_Remesa
            Dim result As Boolean
            Dim result2 As String
            Dim dt As DataTable = ViewState("DT")

            Remesa.Etapa = 0
            Remesa.Usuario = Session("clvUsuario")
            Remesa.Fecha = Date.Now

            result2 = Convert.ToString(serv.genRemesa(Remesa))

            For Each dtRow In dt.Rows
                Remesa = New CNumero_Remesa

                Remesa.NumServicio = dtRow(0)
                Remesa.NumRemesa = result2
                result = serv.insRemesa(Remesa)
            Next

            CargarGrid()
            ConfigureNotification("Se genera la flotilla: " & result2)

        End If
    End Sub

    Public Function ServiciosRemesa() As DataTable
        Dim dtServicios As New DataTable
        dtServicios.Columns.Add("NumeroServicio")

        Dim cuantos1 As Integer = 0
        For Each dataItem As GridDataItem In radSeguimiento.MasterTableView.Items
            If CType(dataItem.FindControl("CheckBox1"), CheckBox).Checked = True Then
                'Session("NumServicio") = dataItem.Cells(ColGrid.NoGestion2).Text
                cuantos1 = cuantos1 + 1
                Dim NumServ As String = dataItem.Cells(ColGrid.NoGestion2).Text
                Dim Servicio As String = dataItem.Cells(ColGrid.TipoServicio).Text
                If Servicio = "ALTA DE VEHICULOS NUEVOS" Or Servicio = "ALTA DE VEHICULOS USADOS" Or Servicio = "CERTIFICACION DE TENENCIAS" Or Servicio = "CONSTANCIA DE NO INFRACCION" Or Servicio = "PAGO DE  MULTAS" Or Servicio = "PAGO DE TENENCIA" Or Servicio = "PERMISO PARA CIRCULAR" Or Servicio = "CERTIFICACION DEL PAGO DE LA VERIFICACION VEHICULAR" Then
                    dtServicios.Rows.Add(NumServ)
                Else
                    ConfigureNotification("Los servicios que quiere generar como flotilla requieren cita, por lo tanto debe asignarlos de manera individual. Diríjase al módulo de control de asignación.")
                    dtServicios.Clear()
                End If
            End If
        Next
        ViewState("DT") = dtServicios
        Return dtServicios

    End Function

  
End Class
Imports System.Data
Imports System.Web
Imports System.Text
Imports System.Web.Configuration
Imports GlobalVariables
Imports Telerik.Web.UI

Partial Class TableroGestion_Desempeño
    Inherits System.Web.UI.Page
    Dim Cadena As String = GlobalVariables.sqlString

    Dim csNeg As New ClaseNegocios
    Dim csSQLsvr As New BaseDatosSQL
    Dim csDAL As New DALClass
    Dim csTC As New TableroControl

    Private _idmes As Integer
    Private _fechai As String
    Private _fechaf As String
    Private _strquery As String
    'Private _bandera As Boolean = False
    Public _bandera As Boolean = False

    Public Property strQuery As String
        Set(value As String)
            ViewState("_strquery") = value
        End Set
        Get
            Return ViewState("_strquery")
        End Get

        'Public Property [CostTotal] As Decimal
        'Get
        '    Return CStr(ViewState("CostTotal"))
        'End Get
        'Set(ByVal value As Decimal)
        '    ViewState("CostTotal") = value
        'End Set
    End Property

    Public Property IDmes() As String
        Set(value As String)
            _idmes = value
        End Set
        Get
            Return _idmes
        End Get
    End Property

    Public Property FechaI() As String
        Set(value As String)
            _fechai = value
        End Set
        Get
            Return _fechai
        End Get
    End Property

    Public Property FechaF() As String
        Set(value As String)
            _fechaf = value
        End Set
        Get
            Return _fechaf
        End Get
    End Property

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
    Public Sub cargaEstados()
        Dim comando As String = ""
        If cboRegion.SelectedValue <> "" Or cboRegion.SelectedValue <> Nothing Then
            comando = "select distinct clave as clvEstado,NOMBRE as Nombre_Estado from Estados where Regional in (0, "
            comando = comando & cboRegion.SelectedValue & ") "
            comando = comando & " order by clvEstado"

        Else

            comando = "select distinct clave as clvEstado,NOMBRE as Nombre_Estado from Estados order by clvEstado"

        End If

        csSQLsvr.LlenarRadCombo(cboEstado, comando, Session("connGestion"))

    End Sub

    Public Sub cargaClientes(Optional ByVal Scliente As String = "0")
        Dim where As String = ""
        If Scliente <> "0" Then
            where = " Where cliente_clvCliente in (0," & Scliente & ") "
        End If

        Dim comando As String = "SELECT DISTINCT cliente_clvCliente, cliente_NomCliente FROM Servicios_Clientes_Activos_vw " & _
                    where & " ORDER BY cliente_clvCliente"
        csSQLsvr.LlenarRadCombo(CboCliente, comando, Session("connGestion"))
    End Sub
    Public Sub cargaRegion()
        Dim comando As String = "select clave, nombre from Regional order by clave"
        csSQLsvr.LlenarRadCombo(cboRegion, comando, Session("connGestion"))

    End Sub
    Public Sub cargaServicioTipo(Optional ByVal Scliente As String = "0")

        Dim where As String = ""
        If Scliente <> "0" Then
            where = " Where cliente_clvCliente in (0," & Scliente & ") "
        End If

        Dim comando As String = "select Servicio_clvTipo, Servicio_NomServicio from Servicios_Clientes_Activos_vw  " & _
                        where & "order by Servicio_clvTipo "

        csSQLsvr.LlenarRadCombo(cboServicioTipo, comando, Session("connGestion"))

    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            cargaEstados()

            cargaClientes(csTC.obtieneClienteTableto(Request.QueryString("sesionClienteTablero"), CStr(cbocliente.SelectedValue)))
            cargaServicioTipo(csTC.obtieneClienteTableto(Request.QueryString("sesionClienteTablero"), CStr(cbocliente.SelectedValue)))

            'If Request.QueryString("sesionClienteTablero") <> 0 Then
            '    cargaClientes(csTC.obtieneClienteTableto(Request.QueryString("sesionClienteTablero"), CStr(cbocliente.SelectedValue)))
            '    cargaServicioTipo(csTC.obtieneClienteTableto(Request.QueryString("sesionClienteTablero"), CStr(cbocliente.SelectedValue)))
            'Else
            '    cargaClientes()
            '    cargaServicioTipo()
            'End If
            cargaRegion()

            LlenaValoresDefault()
            RadGrid1.Visible = False
            radBtnRegresar.Visible = False
            TotalesDesempeño1.Visible = False
            LlenaFiltros()

        End If
    End Sub
    Private Function LlenaTotales(ByVal DT As DataTable)
        Dim terminadosTotal As LinkButton = TotalesDesempeño1.FindControl("lblTerminados")

        Dim antesTiempo As Label = TotalesDesempeño1.FindControl("lblAntes")
        Dim antesTiempoPorc As Label = TotalesDesempeño1.FindControl("lblAntesP")
        Dim enTiempo As LinkButton = TotalesDesempeño1.FindControl("lblTiempo")
        Dim enTiempoPorc As Label = TotalesDesempeño1.FindControl("lblTiempoP")
        Dim fueraTiempo As LinkButton = Me.TotalesDesempeño1.FindControl("lblFuera")
        Dim fueraTiempoPorc As Label = TotalesDesempeño1.FindControl("lblFueraP")
        Dim porcentaje As Single
        Dim Tiemoporc As Decimal = 0

        terminadosTotal.Text = DT.Compute("Sum(terminados)", String.Empty)

        'Tiemoporc = Convert.ToDecimal(antesTiempo.Text) / Convert.ToDecimal(terminadosTotal.Text)
        'Dim iva As Single

        'iva = Val(lblSubt.Text) * 21 / 100
        'lblIva.Text = Math.Abs(CSng(Format(iva, "#,#0.00")))
        'lblIva.Text = Val(lblIva.Text)

        'IIf(Tiemoporc, Tiemoporc, 0)
        antesTiempo.Text = DT.Compute("Sum(Antes_de_Tiempo)", String.Empty)
        If (CInt(antesTiempo.Text) <> 0) Then
            antesTiempoPorc.Text = String.Format("{0:P0}", (Convert.ToDecimal(antesTiempo.Text) / Convert.ToDecimal(terminadosTotal.Text)))
        Else
            antesTiempoPorc.Text = "0%"
        End If
        
        enTiempo.Text = DT.Compute("Sum(En_Tiempo)", String.Empty)
        If (CInt(enTiempo.Text) <> 0) Then
            enTiempoPorc.Text = String.Format("{0:P0}", (Convert.ToDecimal(enTiempo.Text) / Convert.ToDecimal(terminadosTotal.Text)))
        Else
            enTiempoPorc.Text = "0%"
        End If

        fueraTiempo.Text = DT.Compute("Sum(Fuera_de_Tiempo)", String.Empty)
        If (CInt(fueraTiempo.Text) <> 0) Then
            fueraTiempoPorc.Text = String.Format("{0:P0}", (Convert.ToDecimal(fueraTiempo.Text) / Convert.ToDecimal(terminadosTotal.Text)))
'fueraTiempoPorc.Text = String.Format("{0:P0}", (Convert.ToDecimal(terminadosTotal.Text) / Convert.ToDecimal(fueraTiempo.Text)))
        Else
            fueraTiempoPorc.Text = "0%"
        End If

        If (RadComboBox3.SelectedValue = 1) Then

            Dim FInicial As Telerik.Web.UI.RadDatePicker = SelectorFechas.FindControl("rdFI")
            Dim FFinal As Telerik.Web.UI.RadDatePicker = SelectorFechas.FindControl("rdFF")
            FechaI = FInicial.SelectedDate.Value.ToString("yyyy-MM-dd")
            FechaF = FFinal.SelectedDate.Value.ToString("yyyy-MM-dd")
            terminadosTotal.Attributes.Add("onclick", "window.open('D1.aspx?IdCliente=" + cbocliente.SelectedValue + "&IdServicio=" + cboServicioTipo.SelectedValue + "&IdRegion=" + cboRegion.SelectedValue + "&IdEstado=" + cboEstado.SelectedValue + "&FechaI=" + FechaI + "&FechaF=" + FechaF + "&sesionClienteTablero=" + csTC.obtieneClienteTableto(Request.QueryString("sesionClienteTablero"), CStr(cbocliente.SelectedValue)) + "', 'newwindow','toolbar=yes,location=no,menubar=no,width=1300,height=700,resizable=yes,scrollbars=yes,top=200,left=250');return true;")
            enTiempo.Attributes.Add("onclick", "window.open('D2.aspx?IdCliente=" + cbocliente.SelectedValue + "&IdServicio=" + cboServicioTipo.SelectedValue + "&IdRegion=" + cboRegion.SelectedValue + "&IdEstado=" + cboEstado.SelectedValue + "&FechaI=" + FechaI + "&FechaF=" + FechaF + "&sesionClienteTablero=" + csTC.obtieneClienteTableto(Request.QueryString("sesionClienteTablero"), CStr(cbocliente.SelectedValue)) + "', 'newwindow','toolbar=yes,location=no,menubar=no,width=1300,height=700,resizable=yes,scrollbars=yes,top=200,left=250');return true;")
            fueraTiempo.Attributes.Add("onclick", "window.open('D3.aspx?IdCliente=" + cbocliente.SelectedValue + "&IdServicio=" + cboServicioTipo.SelectedValue + "&IdRegion=" + cboRegion.SelectedValue + "&IdEstado=" + cboEstado.SelectedValue + "&FechaI=" + FechaI + "&FechaF=" + FechaF + "&sesionClienteTablero=" + csTC.obtieneClienteTableto(Request.QueryString("sesionClienteTablero"), CStr(cbocliente.SelectedValue)) + "', 'newwindow','toolbar=yes,location=no,menubar=no,width=1300,height=700,resizable=yes,scrollbars=yes,top=200,left=250');return true;")



        Else
            terminadosTotal.Attributes.Add("onclick", "window.open('D1.aspx?IdCliente=" + cbocliente.SelectedValue + "&IdServicio=" + cboServicioTipo.SelectedValue + "&IdRegion=" + cboRegion.SelectedValue + "&IdEstado=" + cboEstado.SelectedValue + "&IdMes=" + IDmes + "&sesionClienteTablero=" + csTC.obtieneClienteTableto(Request.QueryString("sesionClienteTablero"), CStr(cbocliente.SelectedValue)) + "', 'newwindow','toolbar=yes,location=no,menubar=no,width=1300,height=700,resizable=yes,scrollbars=yes,top=200,left=250');return true;")
            enTiempo.Attributes.Add("onclick", "window.open('D2.aspx?IdCliente=" + cbocliente.SelectedValue + "&IdServicio=" + cboServicioTipo.SelectedValue + "&IdRegion=" + cboRegion.SelectedValue + "&IdEstado=" + cboEstado.SelectedValue + "&IdMes=" + IDmes + "&sesionClienteTablero=" + csTC.obtieneClienteTableto(Request.QueryString("sesionClienteTablero"), CStr(cbocliente.SelectedValue)) + "', 'newwindow','toolbar=yes,location=no,menubar=no,width=1300,height=700,resizable=yes,scrollbars=yes,top=200,left=250');return true;")
            fueraTiempo.Attributes.Add("onclick", "window.open('D3.aspx?IdCliente=" + cbocliente.SelectedValue + "&IdServicio=" + cboServicioTipo.SelectedValue + "&IdRegion=" + cboRegion.SelectedValue + "&IdEstado=" + cboEstado.SelectedValue + "&IdMes=" + IDmes + "&sesionClienteTablero=" + csTC.obtieneClienteTableto(Request.QueryString("sesionClienteTablero"), CStr(cbocliente.SelectedValue)) + "', 'newwindow','toolbar=yes,location=no,menubar=no,width=1300,height=700,resizable=yes,scrollbars=yes,top=200,left=250');return true;")


        End If


    End Function

    Public Function calculaPorc(ByRef datos As Object) As Integer
        Dim result As Decimal
        result = Convert.ToDecimal(datos) * 100
        Return result
    End Function


    Protected Sub radBtnResultado_Click(sender As Object, e As System.EventArgs) Handles radBtnResultado.Click
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim cliente As Integer = CboCliente.SelectedValue


        If (cliente <> 0) Then
            cliente = CboCliente.SelectedValue
        Else
            'If (clientetablero <> "") Or (clientetablero <> "0") Then
            '    cliente = clientetablero
            'End If
            ConfigureNotification("Debe seleccionar un cliente en especifico")
            Exit Sub
        End If

        Dim servicio_tipo As Integer = cboServicioTipo.SelectedValue
        Dim FInicial As Telerik.Web.UI.RadDatePicker = SelectorFechas.FindControl("rdFI")
        Dim FFinal As Telerik.Web.UI.RadDatePicker = SelectorFechas.FindControl("rdFF")
        FechaI = FInicial.SelectedDate.Value.ToString("yyyy-MM-dd") '  .SelectedDate .ToString("yyyy-MM-dd")
        FechaF = FFinal.SelectedDate.Value.ToString("yyyy-MM-dd")   '.ToString("yyyy-MM-dd")
        Dim ComboMeses As Telerik.Web.UI.RadComboBox = ComboMes.FindControl("rcMes")
        IDmes = ComboMeses.SelectedValue
        Dim region As Integer = cboRegion.SelectedValue
        Dim estado As Integer = cboEstado.SelectedValue


        ds = csDAL.CargaTableroDesempeño(cliente, servicio_tipo, FechaI, FechaF, IDmes, region, estado)
        dt = ds.Tables(0)
        If dt.Rows.Count <> 0 Then
            LlenaTotales(dt)

            With RadGrid1
                .DataSource = ds.Tables(0)
                .DataBind()
            End With
            RadGrid1.Visible = True
            radBtnRegresar.Visible = True
            TotalesDesempeño1.Visible = True
        Else
            ''Mensage de que no se tienen valores a mostrar
            ds.Tables.Clear()
            ConfigureNotification("No existen datos a mostrar.")
            LimpiaDatos()
        End If

    End Sub
    Private Function LimpiaDatos()
        RadGrid1.DataSource = Nothing
        RadGrid1.DataBind()
        TotalesDesempeño1.Visible = False
        RadGrid1.Visible = False

    End Function
    'Private Function GetOpcion() As Boolean
    '    If RadComboBox3.SelectedValue = 2 Then 'MES
    '        Dim ComboMeses As Telerik.Web.UI.RadComboBox = ComboMes.FindControl("rcMes")
    '        IDmes = ComboMeses.SelectedValue
    '        If (IDmes <> 0) Then
    '            strQuery = strQuery + " AND (MONTH(RSG.Reporte_FechaRepor) = " + IDmes + " AND YEAR(RSG.Reporte_FechaRepor) = YEAR(GETDATE()))"
    '            _bandera = True
    '        End If
    '        FechaI = ""
    '        FechaF = ""
    '    Else
    '        Dim FInicial As Telerik.Web.UI.RadDatePicker = SelectorFechas.FindControl("rdFI")
    '        FInicial.SelectedDate = Now
    '        Dim FFinal As Telerik.Web.UI.RadDatePicker = SelectorFechas.FindControl("rdFF")
    '        FFinal.SelectedDate = Now
    '        FechaI = FInicial.SelectedDate.Value.ToString("yyyy-MM-dd") '  .SelectedDate .ToString("yyyy-MM-dd")
    '        FechaF = FFinal.SelectedDate.Value.ToString("yyyy-MM-dd") '.ToString("yyyy-MM-dd")
    '        strQuery = strQuery + " AND RSG.Reporte_FechaRepor BETWEEN ''" + FechaI + "'' AND ''" + FechaF + "''"
    '        _bandera = True
    '        Return True
    '    End If
    'End Function

    Protected Sub RadComboBox3_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBox3.SelectedIndexChanged
        If (RadComboBox3.SelectedValue = 1) Then
            SelectorFechas.Visible = True
            ComboMes.Visible = False
        ElseIf (RadComboBox3.SelectedValue = 2) Then 'MES
            SelectorFechas.Visible = False
            ComboMes.Visible = True
        End If
        LimpiaDatos()
        udpFiltro.Update()
    End Sub

    Private Sub LlenaValoresDefault()
        SelectorFechas.Visible = True
    End Sub

    Protected Sub radBtnRegresar_Click(sender As Object, e As System.EventArgs) Handles radBtnRegresar.Click
        Response.Redirect("~/TableroGestion/Servicio1.aspx")
    End Sub

    Protected Sub CboCliente_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles CboCliente.SelectedIndexChanged
        LimpiaDatos()

    End Sub

    Protected Sub cboServicioTipo_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cboServicioTipo.SelectedIndexChanged
        LimpiaDatos()

    End Sub

    Protected Sub cboRegion_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cboRegion.SelectedIndexChanged
        LimpiaDatos()
        cargaEstados()
    End Sub

    Protected Sub cboEstado_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cboEstado.SelectedIndexChanged
        LimpiaDatos()

    End Sub


    Protected Sub RadGrid1_ItemDataBound(ByVal s As Object, ByVal e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If TypeOf e.Item Is GridDataItem Then

            Dim dataItem As GridDataItem = e.Item
            Dim myCell As TableCell = dataItem("column4")

            If myCell.Text <> "En Tiempo" Then
                dataItem.Cells(4).BackColor = Drawing.Color.Green
                dataItem.Cells(4).ForeColor = Drawing.Color.White
                dataItem.Cells(5).BackColor = Drawing.Color.Green
                dataItem.Cells(5).ForeColor = Drawing.Color.White
                dataItem.Cells(6).BackColor = Drawing.Color.Yellow
                'dataItem.Cells(6).ForeColor = Drawing.Color.White
                dataItem.Cells(7).BackColor = Drawing.Color.Yellow
                'dataItem.Cells(7).ForeColor = Drawing.Color.White
                dataItem.Cells(8).BackColor = Drawing.Color.Red
                dataItem.Cells(8).ForeColor = Drawing.Color.White
                dataItem.Cells(9).BackColor = Drawing.Color.Red
                dataItem.Cells(9).ForeColor = Drawing.Color.White

                'dataItem.ForeColor = Drawing.Color.White
            Else
                dataItem.BackColor = Drawing.Color.Gray
            End If
        End If
        'Dim x As String = String.Empty

        'RadGrid1.Items(x).Cells(4).BackColor = Drawing.Color.Yellow
    End Sub

    Private Sub LlenaFiltros()
        Dim Ds As New DataSet

        Dim clientetablero As String
        Dim IdCliente As String
        Dim IdServicio As String
        Dim IdRegion As String
        Dim IdEstado As String
        Dim FechaI As String
        Dim FechaF As String
        Dim IdMes As String
        'Dim IdTipo As String

        'Tipo = 0 (TODOSOCURRIDOS) , TIPO = 1(CANCELADOS)
        clientetablero = Request.QueryString("sesionClienteTablero")
        IdCliente = Request.QueryString("IdCliente")
        IdServicio = Request.QueryString("IdServicio")
        IdRegion = Request.QueryString("IdRegion")
        IdEstado = Request.QueryString("IdEstado")
        FechaI = Request.QueryString("FechaI")
        FechaF = Request.QueryString("FechaF")
        IdMes = Request.QueryString("IdMes")
        'IdTipo = Request.QueryString("Tipo")

        'If (IdTipo = 1) Then

        'strQuery = strQuery + " AND RSG.Reporte_status=1"
        'End If

        If (IdCliente <> 0) Then
            strQuery = strQuery + " AND RSG.Reporte_cliente = " + IdCliente + ""
        Else
            If (clientetablero <> "") Or (clientetablero <> "0") Then
                strQuery = strQuery + " AND RSG.Reporte_cliente in (" + clientetablero + ")"
            End If
        End If

        If (IdServicio <> "") And (IdServicio <> "0") Then
            cboServicioTipo.SelectedValue = IdServicio
            'strQuery = strQuery + " AND RSG.Reporte_Tipo = " + IdServicio + ""
        End If

        If (IsNothing(IdMes) = False) Then
            RadComboBox3.SelectedValue = 1
            Dim ComboMeses As Telerik.Web.UI.RadComboBox = ComboMes.FindControl("rcMes")
            ComboMeses.SelectedValue = IdMes
            'strQuery = strQuery + " AND (MONTH(convert(datetime,RSG.Reporte_FechaRepor)) = " + IdMes + " AND YEAR(convert(datetime,RSG.Reporte_FechaRepor)) = YEAR(GETDATE()))"
        End If

        If (IsNothing(FechaI) = False And IsNothing(FechaF) = False) Then
            Dim FInicial As Telerik.Web.UI.RadDatePicker = SelectorFechas.FindControl("rdFI")
            Dim FFinal As Telerik.Web.UI.RadDatePicker = SelectorFechas.FindControl("rdFF")
            FInicial.SelectedDate = FechaI
            FFinal.SelectedDate = FechaF
            'strQuery = strQuery + " AND convert(datetime,RSG.Reporte_FechaRepor) BETWEEN ''" + FechaI + "'' AND ''" + FechaF + "''"
        End If

        If (IdRegion <> 0) Then
            cboRegion.SelectedValue = IdRegion
            'strQuery = strQuery + " AND RSG.clvRegional = " + IdRegion + ""
        End If

        If (IdEstado <> 0) Then
            cboEstado.SelectedValue = IdEstado
            'strQuery = strQuery + " AND RSG.Reporte_clvEstado = " + IdEstado + ""
        End If

    End Sub

End Class




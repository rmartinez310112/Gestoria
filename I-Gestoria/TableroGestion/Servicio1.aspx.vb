Imports System.Data
Imports System.Text
Imports System.Web.Configuration
Imports System.Web
Imports GlobalVariables

Partial Class Reportes
    Inherits System.Web.UI.Page
    Dim csNeg As New ClaseNegocios
    Dim csSQLsvr As New BaseDatosSQL
    Dim csDAL As New DALClass
    Dim csTC As New TableroControl
    Dim Cadena As String = GlobalVariables.sqlString


    'Variables y Propiedades
    'VARIABLES
    Private _clienteTablero As String
    Private _cliente As String
    Private _estado As Integer
    Private _servicio As String
    Private _region As Integer
    Private _idmes As Integer
    Private _fechai As String
    Private _fechaf As String
    Private _strquery As String
    'Private _bandera As Boolean = False
    Public _bandera As Boolean
    Public flat As Boolean

    'PROPIEDADES

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

    Public Property clienteTablero As String
        Set(value As String)
            _clienteTablero = value
        End Set
        Get
            Return _clienteTablero
        End Get

    End Property

    'Public Property Bandera() As Boolean
    '    Set(value As Boolean)
    '        _bandera = value
    '    End Set
    '    Get
    '        Return _bandera
    '    End Get
    'End Property

    Public Property Cliente() As String
        Set(value As String)
            _cliente = value
        End Set
        Get
            Return _cliente
        End Get
    End Property

    Public Property Estado() As String
        Set(value As String)
            _estado = value
        End Set
        Get
            Return _estado
        End Get
    End Property

    Public Property Servicio() As String
        Set(value As String)
            _servicio = value
        End Set
        Get
            Return _servicio
        End Get
    End Property

    Public Property Region() As String
        Set(value As String)
            _region = value
        End Set
        Get
            Return _region
        End Get
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
        RadNotification1.Title = "Aviso"
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

            cargaClientes(csTC.obtieneClienteTableto(Session("ClienteTablero"), CStr(cbocliente.SelectedValue)))
            cargaServicioTipo(csTC.obtieneClienteTableto(Session("ClienteTablero"), CStr(cbocliente.SelectedValue)))
            'If Session("ClienteTablero") <> 0 Then

            '    cargaClientes(csTC.obtieneClienteTableto(Session("ClienteTablero"), CStr(cbocliente.SelectedValue)))
            '    cargaServicioTipo(csTC.obtieneClienteTableto(Session("ClienteTablero"), CStr(cbocliente.SelectedValue)))

            'Else

            '    cargaClientes()
            '    cargaServicioTipo()

            'End If




            cargaEstados()

            cargaRegion()

            LlenaValoresDefault()

            strQuery = String.Empty
            ValidaParametros()


        End If
    End Sub
    Private Sub LlenaValoresDefault()
        SelectorFechas.Visible = True

        'Dim FechaActual As System.DateTime
        'Dim answer As System.DateTime
        'FechaActual = System.DateTime.Now
        'answer = FechaActual.AddDays(-30)

        ''answer = CDate(Today.Date.Year & "/" & Today.Date.Month & "/" & Today.Day - 30)
        'FECHAINICIAL.Text = answer.ToString("dd-MM-yyyy")
        'FECHAFINAL.Text = FechaActual.ToString("dd-MM-yyyy")

    End Sub
    Public Sub cargaGrid()
        'Dim comando As String = ""
        Dim SB As New StringBuilder
        Dim Dt As New DataTable
        'SB.Append(" select distinct (RSG.Tramite_Descripcion) ,RSG.Reporte_Tipo, ")
        'SB.Append(" 'OCURRIDOSN' = COUNT(*),  ")
        'SB.Append(" 'OCURRIDOSP' = ( select dbo.f_Porcentaje(48,COUNT(RSG.Reporte_Tipo))) ,  ")
        'SB.Append(" 'CANCELADOSN'  =(select COUNT(*) from dbo.vw_ReporteServiciosGeneral where Reporte_status =1 and Reporte_Tipo = (RSG.Reporte_Tipo)), ")
        'SB.Append(" 'CANCELADOSP' =(select dbo.f_Porcentaje(7,(select COUNT(*) from dbo.vw_ReporteServiciosGeneral where Reporte_status =1 and Reporte_Tipo = (RSG.Reporte_Tipo))))  ")
        'SB.Append("  FROM dbo.vw_ReporteServiciosGeneral RSG ")
        'SB.Append("  where(RSG.Reporte_Tipo <> 14)  ")
        'SB.Append("  GROUP BY RSG.Tramite_Descripcion,RSG.Reporte_Tipo ")
        Dim comando As String = " GestionaTableros"

        Dt = csSQLsvr.LlenaGridTableros(RadGrid1, comando, Session("connGestion"))
        LlenaTotales(Dt)
    End Sub
    Private Function LlenaTotales(ByVal DT As DataTable)

        Dim ocurridoTotal As LinkButton = selectorCuentas1.FindControl("lblNO")
        Dim ocurridoPorc As Label = selectorCuentas1.FindControl("lblPO")
        Dim canceladoTotal As LinkButton = selectorCuentas1.FindControl("lblNC")
        Dim canceladoPorc As Label = selectorCuentas1.FindControl("lblPC")
        Dim atendidoTotal As Label = selectorCuentas1.FindControl("lblNA")
        Dim atendidoPorc As Label = selectorCuentas1.FindControl("lblPA")
        Dim terminadoTotal As LinkButton = selectorCuentas1.FindControl("lblNT")
        Dim terminadoPorc As Label = selectorCuentas1.FindControl("lblPT")
        Dim procesoTotal As LinkButton = selectorCuentas1.FindControl("lblNP")
        Dim procesoPorc As Label = selectorCuentas1.FindControl("lblPP")
        Dim TotalesOcurridos As Decimal = Convert.ToDecimal(DT.Compute("Sum(OCURRIDOSN)", String.Empty))

        If (DT.Compute("Sum(OCURRIDOSN)", String.Empty) = 0) Then
            ocurridoTotal.CssClass.Remove(0, ocurridoTotal.CssClass.Count())
            ocurridoTotal.CssClass = "LabelStyle"
            ocurridoTotal.Enabled = False
        Else
            ocurridoTotal.Enabled = True
            ocurridoTotal.CssClass = "TotalesLink"
        End If
        ocurridoTotal.Text = DT.Compute("Sum(OCURRIDOSN)", String.Empty)

        If (DT.Compute("Sum(CANCELADOSN)", String.Empty) = 0) Then
            canceladoTotal.CssClass.Remove(0, canceladoTotal.CssClass.Count())
            canceladoTotal.CssClass = "LabelStyle"
            canceladoTotal.Enabled = False
        Else
            canceladoTotal.Enabled = True
            canceladoTotal.CssClass = "TotalesLink"
        End If

        ocurridoPorc.Text = calculaPorc(CalculaPorcentajes(TotalesOcurridos, Convert.ToDecimal(DT.Compute("Sum(OCURRIDOSN)", String.Empty)))) & "%"
        canceladoTotal.Text = DT.Compute("Sum(CANCELADOSN)", String.Empty)

        canceladoPorc.Text = calculaPorc(CalculaPorcentajes(TotalesOcurridos, Convert.ToDecimal(DT.Compute("Sum(CANCELADOSN)", String.Empty)))) & "%"
        atendidoTotal.Text = DT.Compute("Sum(ATENDIDOSN)", String.Empty)
        atendidoPorc.Text = calculaPorc(CalculaPorcentajes(TotalesOcurridos, Convert.ToDecimal(DT.Compute("Sum(ATENDIDOSN)", String.Empty)))) & "%"
        terminadoTotal.Text = DT.Compute("Sum(TERMINADOSN)", String.Empty)
        terminadoPorc.Text = calculaPorc(CalculaPorcentajes(TotalesOcurridos, Convert.ToDecimal(DT.Compute("Sum(TERMINADOSN)", String.Empty)))) & "%"
        procesoTotal.Text = DT.Compute("Sum(PROCESON)", String.Empty)
        procesoPorc.Text = calculaPorc(CalculaPorcentajes(TotalesOcurridos, Convert.ToDecimal(DT.Compute("Sum(PROCESON)", String.Empty)))) & "%"

        If (RadComboBox3.SelectedValue = 1) Then
            'Dim FInicial As Telerik.Web.UI.RadDatePicker = SelectorFechas.FindControl("rdFI")
            'Dim FFinal As Telerik.Web.UI.RadDatePicker = SelectorFechas.FindControl("rdFF")
            'FechaI = FInicial.SelectedDate.Value.ToString("yyyy-MM-dd")
            'FechaF = FFinal.SelectedDate.Value.ToString("yyyy-MM-dd")    'Tipo = 0 (TODOSOCURRIDOS) , TIPO = 1(CANCELADOS)
            ocurridoTotal.Attributes.Add("onclick", "window.open('Detalle.aspx?IdCliente=" + CboCliente.SelectedValue + "&Tipo=0&IdServicio=" + cboServicioTipo.SelectedValue + "&IdRegion=" + cboRegion.SelectedValue + "&IdEstado=" + cboEstado.SelectedValue + "&FechaI=" + FechaI + "&FechaF=" + FechaF + "&sesionClienteTablero=" + csTC.ObtieneClienteTableto(Session("ClienteTablero"), CStr(CboCliente.SelectedValue)) + "', 'newwindow','toolbar=yes,location=no,menubar=no,width=1300,height=700,resizable=yes,scrollbars=yes,top=200,left=250');return true;")
            canceladoTotal.Attributes.Add("onclick", "window.open('Detalle.aspx?IdCliente=" + CboCliente.SelectedValue + "&Tipo=1&IdServicio=" + cboServicioTipo.SelectedValue + "&IdRegion=" + cboRegion.SelectedValue + "&IdEstado=" + cboEstado.SelectedValue + "&FechaI=" + FechaI + "&FechaF=" + FechaF + "&sesionClienteTablero=" + csTC.ObtieneClienteTableto(Session("ClienteTablero"), CStr(CboCliente.SelectedValue)) + "', 'newwindow','toolbar=yes,location=no,menubar=no,width=1300,height=700,resizable=yes,scrollbars=yes,top=200,left=250');return true;")
            terminadoTotal.Attributes.Add("onclick", "window.open('Detalle.aspx?IdCliente=" + CboCliente.SelectedValue + "&Tipo=3&IdServicio=" + cboServicioTipo.SelectedValue + "&IdRegion=" + cboRegion.SelectedValue + "&IdEstado=" + cboEstado.SelectedValue + "&FechaI=" + FechaI + "&FechaF=" + FechaF + "&sesionClienteTablero=" + csTC.ObtieneClienteTableto(Session("ClienteTablero"), CStr(CboCliente.SelectedValue)) + "', 'newwindow','toolbar=yes,location=no,menubar=no,width=1300,height=700,resizable=yes,scrollbars=yes,top=200,left=250');return true;")
            procesoTotal.Attributes.Add("onclick", "window.open('Detalle.aspx?IdCliente=" + CboCliente.SelectedValue + "&Tipo=4&IdServicio=" + cboServicioTipo.SelectedValue + "&IdRegion=" + cboRegion.SelectedValue + "&IdEstado=" + cboEstado.SelectedValue + "&FechaI=" + FechaI + "&FechaF=" + FechaF + "&sesionClienteTablero=" + csTC.ObtieneClienteTableto(Session("ClienteTablero"), CStr(CboCliente.SelectedValue)) + "', 'newwindow','toolbar=yes,location=no,menubar=no,width=1300,height=700,resizable=yes,scrollbars=yes,top=200,left=250');return true;")
        Else
            ocurridoTotal.Attributes.Add("onclick", "window.open('Detalle.aspx?IdCliente=" + CboCliente.SelectedValue + "&Tipo=0&IdServicio=" + cboServicioTipo.SelectedValue + "&IdRegion=" + cboRegion.SelectedValue + "&IdEstado=" + cboEstado.SelectedValue + "&IdMes=" + IDmes + "&sesionClienteTablero=" + csTC.ObtieneClienteTableto(Session("ClienteTablero"), CStr(CboCliente.SelectedValue)) + "', 'newwindow','toolbar=yes,location=no,menubar=no,width=1300,height=700,resizable=yes,scrollbars=yes,top=200,left=250');return true;")
            canceladoTotal.Attributes.Add("onclick", "window.open('Detalle.aspx?IdCliente=" + CboCliente.SelectedValue + "&Tipo=1&IdServicio=" + cboServicioTipo.SelectedValue + "&IdRegion=" + cboRegion.SelectedValue + "&IdEstado=" + cboEstado.SelectedValue + "&IdMes=" + IDmes + "&sesionClienteTablero=" + csTC.ObtieneClienteTableto(Session("ClienteTablero"), CStr(CboCliente.SelectedValue)) + "', 'newwindow','toolbar=yes,location=no,menubar=no,width=1300,height=700,resizable=yes,scrollbars=yes,top=200,left=250');return true;")
            terminadoTotal.Attributes.Add("onclick", "window.open('Detalle.aspx?IdCliente=" + CboCliente.SelectedValue + "&Tipo=3&IdServicio=" + cboServicioTipo.SelectedValue + "&IdRegion=" + cboRegion.SelectedValue + "&IdEstado=" + cboEstado.SelectedValue + "&IdMes=" + IDmes + "&sesionClienteTablero=" + csTC.ObtieneClienteTableto(Session("ClienteTablero"), CStr(CboCliente.SelectedValue)) + "', 'newwindow','toolbar=yes,location=no,menubar=no,width=1300,height=700,resizable=yes,scrollbars=yes,top=200,left=250');return true;")
            procesoTotal.Attributes.Add("onclick", "window.open('Detalle.aspx?IdCliente=" + CboCliente.SelectedValue + "&Tipo=4&IdServicio=" + cboServicioTipo.SelectedValue + "&IdRegion=" + cboRegion.SelectedValue + "&IdEstado=" + cboEstado.SelectedValue + "&IdMes=" + IDmes + "&sesionClienteTablero=" + csTC.ObtieneClienteTableto(Session("ClienteTablero"), CStr(CboCliente.SelectedValue)) + "', 'newwindow','toolbar=yes,location=no,menubar=no,width=1300,height=700,resizable=yes,scrollbars=yes,top=200,left=250');return true;")
        End If

    End Function
    Public Function CalculaPorcentajes(ByRef Totales As Decimal, ByRef TotalesTipo As Decimal) As Decimal
        Dim result As Decimal
        result = TotalesTipo / Totales
        Return result
    End Function

    Public Function calculaPorc(ByRef datos As Object) As Integer
        Dim result As Decimal
        result = Convert.ToDecimal(datos) * 100
        Return result
    End Function

    'Protected Sub radBtnAvances_Click(sender As Object, e As System.EventArgs) 'Handles radBtnAvances.Click
    '    Response.Redirect("~/TableroGestion/Avances.aspx")
    'End Sub

    'Protected Sub radBtnDesempeño_Click(sender As Object, e As System.EventArgs) 'Handles radBtnDesempeño.Click
    '    Response.Redirect("~/TableroGestion/Desempeño.aspx")
    'End Sub

    Protected Sub radBtnResultado_Click(sender As Object, e As System.EventArgs) Handles radBtnResultado.Click
        strQuery = String.Empty
        ValidaParametros()

    End Sub
    Public Function OnClientSelectIndexChanging(sender, eventarqs)
        eventarqs.set_cancel(True)
    End Function
    Private Function ValidaParametros()
        Dim Ds As New DataSet
        EvaluaCondiciones(Cliente, Estado, Servicio, Region)
        If Cliente = 0 Then
            If (Session("ClienteTablero") <> 0) And Not strQuery.Contains("AND Reporte_cliente") Then
                strQuery = strQuery + " AND Reporte_cliente in (" + Session("ClienteTablero") + ")"

            End If
        End If
        If (_bandera) Then
            Ds = csDAL.CargaTableroServicio(strQuery, flat)
            If (Ds.Tables(0).Rows.Count > 0) Then
                panelResultados.Visible = True
                With RadGrid1
                    .DataSource = Ds.Tables(0)
                    .DataBind()
                End With
                LlenaTotales(Ds.Tables(0))
                panelResultados.Update()
            Else
                Ds.Tables.Clear()
                ConfigureNotification("No existen datos a mostrar.")
                LimpiaDatos()
            End If
        Else
            ConfigureNotification("Ingrese Filtros de búsqueda.")
            LimpiaDatos()
        End If
    End Function
    Private Function LimpiaDatos()
        RadGrid1.DataSource = Nothing
        RadGrid1.DataBind()
        panelResultados.Visible = False
        ' ConfigureNotification("No existen datos a mostrar.")
    End Function
    Private Function EvaluaCondiciones(ByVal cliente As Integer, ByVal estado As Integer, ByVal servicio As Integer, ByVal region As Integer) As Boolean
        GetCliente()
        GetServicio()
        GetOpcion()
        GetRegion()
        GetEstado()
    End Function
    Private Function GetCliente() As Boolean
        Cliente = CboCliente.SelectedValue

        If (Cliente <> "0") Then
            strQuery = strQuery + " AND Reporte_cliente = " + Cliente + ""
        End If

        Return True
    End Function

    Private Function GetServicio() As Boolean
        Servicio = cboServicioTipo.SelectedValue
        If (Servicio <> "") And (Servicio <> "0") Then
            strQuery = strQuery + " AND Reporte_Tipo = " + Servicio + ""
            flat = True 'si hubo cambio de Servicio(si hubo filtros)
        Else
            flat = False   'no hubo cambio de Servicio(si hubo filtros)
        End If
        Return True
    End Function

    Private Function GetOpcion() As Boolean
        If RadComboBox3.SelectedValue = 2 Then 'MES
            Dim ComboMeses As Telerik.Web.UI.RadComboBox = ComboMes.FindControl("rcMes")
            IDmes = ComboMeses.SelectedValue
            FECHAINICIAL.Visible = False
            FECHAINICIAL.Visible = False
            lblAL.Visible = False
            FECHAFINAL.Visible = False
            If (IDmes <> 0) Then
                strQuery = strQuery + " AND (MONTH(Reporte_FechaRepor) = " + IDmes + " AND YEAR(Reporte_FechaRepor) = YEAR(GETDATE()))"
                _bandera = True
            End If
            FechaI = ""
            FechaF = ""
        Else
            Dim FInicial As Telerik.Web.UI.RadDatePicker = SelectorFechas.FindControl("rdFI")
            Dim FFinal As Telerik.Web.UI.RadDatePicker = SelectorFechas.FindControl("rdFF")
	If FInicial.SelectedDate IsNot Nothing Then
                FechaI = FInicial.SelectedDate.Value.ToString("yyyy-MM-dd") '  .SelectedDate .ToString("yyyy-MM-dd")
                FechaF = FFinal.SelectedDate.Value.ToString("yyyy-MM-dd") '.ToString("yyyy-MM-dd")
                FECHAINICIAL.Text = FInicial.SelectedDate.Value.ToString("dd-MM-yyyy")
                FECHAFINAL.Text = FFinal.SelectedDate.Value.ToString("dd-MM-yyyy")
            Else
                Dim FechaActual As System.DateTime
                Dim answer As System.DateTime
                FechaActual = System.DateTime.Now
                answer = FechaActual.AddDays(-30)
                FechaI = answer.ToString("yyyy-MM-dd")
                FechaF = FechaActual.ToString("yyyy-MM-dd")
                FECHAINICIAL.Text = answer.ToString("dd-MM-yyyy")
                FECHAFINAL.Text = FechaActual.ToString("dd-MM-yyyy")
            End If

            strQuery = strQuery + " AND Reporte_FechaRepor BETWEEN ''" + FechaI + "'' AND ''" + FechaF + "''"
            lbltitulo.Visible = True
            FECHAINICIAL.Visible = True
            lblAL.Visible = True
            FECHAFINAL.Visible = True
           
            _bandera = True
            Return True
            End If
    End Function

    Private Function GetRegion() As Boolean
        Region = cboRegion.SelectedValue
        If (Region <> 0) Then
            strQuery = strQuery + " AND clvRegional = " + Region + ""
        End If
        Return True
    End Function

    Private Function GetEstado() As Boolean
        Estado = cboEstado.SelectedValue
        If (Estado <> 0) Then
            strQuery = strQuery + " AND Reporte_clvEstado = " + Estado + ""
        End If
        Return True
    End Function
    Protected Sub RadComboBox3_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBox3.SelectedIndexChanged 'Handles RadComboBox3.SelectedIndexChanged

        If (RadComboBox3.SelectedValue = 1) Then

            SelectorFechas.Visible = True
            ComboMes.Visible = False

        ElseIf (RadComboBox3.SelectedValue = 2) Then 'MES

            SelectorFechas.Visible = False
            lbltitulo.Visible = False
            FECHAINICIAL.Visible = False
            lblAL.Visible = False
            FECHAFINAL.Visible = False
            ComboMes.Visible = True

        End If

        LimpiaDatos()
        udpFiltro.Update()
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

    Protected Sub radBtnAvances_Click1(sender As Object, e As System.EventArgs) Handles radBtnAvances.Click

        If (RadComboBox3.SelectedValue = 1) Then
            Dim FInicial As Telerik.Web.UI.RadDatePicker = SelectorFechas.FindControl("rdFI")
            Dim FFinal As Telerik.Web.UI.RadDatePicker = SelectorFechas.FindControl("rdFF")
            FechaI = FInicial.SelectedDate.Value.ToString("yyyy-MM-dd")
            FechaF = FFinal.SelectedDate.Value.ToString("yyyy-MM-dd")    'Tipo = 0 (TODOSOCURRIDOS) , TIPO = 1(CANCELADOS)

            Response.Redirect("~/TableroGestion/Avances.aspx?IdCliente=" + cbocliente.SelectedValue + "&Tipo=0&IdServicio=" + cboServicioTipo.SelectedValue + "&IdRegion=" + cboRegion.SelectedValue + "&IdEstado=" + cboEstado.SelectedValue + "&FechaI=" + FechaI + "&FechaF=" + FechaF + "&sesionClienteTablero=" + csTC.obtieneClienteTableto(Session("ClienteTablero"), CStr(cbocliente.SelectedValue)))
        Else
            Response.Redirect("~/TableroGestion/Avances.aspx?IdCliente=" + cbocliente.SelectedValue + "&Tipo=0&IdServicio=" + cboServicioTipo.SelectedValue + "&IdRegion=" + cboRegion.SelectedValue + "&IdEstado=" + cboEstado.SelectedValue + "&IdMes=" + IDmes + "&sesionClienteTablero=" + csTC.obtieneClienteTableto(Session("ClienteTablero"), CStr(cbocliente.SelectedValue)))
        End If

    End Sub

    Protected Sub radBtnDesempeño_Click1(sender As Object, e As System.EventArgs) Handles radBtnDesempeño.Click

        If (RadComboBox3.SelectedValue = 1) Then
            Dim FInicial As Telerik.Web.UI.RadDatePicker = SelectorFechas.FindControl("rdFI")
            Dim FFinal As Telerik.Web.UI.RadDatePicker = SelectorFechas.FindControl("rdFF")
            FechaI = FInicial.SelectedDate.Value.ToString("yyyy-MM-dd")
            FechaF = FFinal.SelectedDate.Value.ToString("yyyy-MM-dd")    'Tipo = 0 (TODOSOCURRIDOS) , TIPO = 1(CANCELADOS)
            Response.Redirect("~/TableroGestion/Desempeño.aspx?IdCliente=" + cbocliente.SelectedValue + "&Tipo=0&IdServicio=" + cboServicioTipo.SelectedValue + "&IdRegion=" + cboRegion.SelectedValue + "&IdEstado=" + cboEstado.SelectedValue + "&FechaI=" + FechaI + "&FechaF=" + FechaF + "&sesionClienteTablero=" + csTC.obtieneClienteTableto(Session("ClienteTablero"), CStr(cbocliente.SelectedValue)))
        Else
            Response.Redirect("~/TableroGestion/Desempeño.aspx?IdCliente=" + cbocliente.SelectedValue + "&Tipo=0&IdServicio=" + cboServicioTipo.SelectedValue + "&IdRegion=" + cboRegion.SelectedValue + "&IdEstado=" + cboEstado.SelectedValue + "&IdMes=" + IDmes + "&sesionClienteTablero=" + csTC.obtieneClienteTableto(Session("ClienteTablero"), CStr(cbocliente.SelectedValue)))
        End If

    End Sub



End Class

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

    Private _idmes As Integer
    Private _fechai As String
    Private _fechaf As String
    Private _strquery As String
    'Private _bandera As Boolean = False
    Public _bandera As Boolean = False


    Public Property IDmes() As String
        Set(ByVal value As String)
            _idmes = value
        End Set
        Get
            Return _idmes
        End Get
    End Property

    Public Property FechaI() As String
        Set(ByVal value As String)
            _fechai = value
        End Set
        Get
            Return _fechai
        End Get
    End Property

    Public Property FechaF() As String
        Set(ByVal value As String)
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

    Public Sub cargaClientes()
        Dim comando As String = "exec Select_cbo_clientes"
        csSQLsvr.LlenarRadCombo(CboCliente, comando, Session("connGestion"))
    End Sub

    Public Sub cargaRegion()
        Dim comando As String = "select clave, nombre from Regional order by clave"
        csSQLsvr.LlenarRadCombo(cboRegion, comando, Session("connGestion"))
    End Sub

    Public Sub cargaServicioTipo()
        Dim comando As String = "select Tramite_clvTramite, Tramite_Descripcion from TramitesGestion where Tramite_clvTramite < 14 order by Tramite_clvTramite"
        csSQLsvr.LlenarRadCombo(cboServicioTipo, comando, Session("connGestion"))

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Me.Image1
        'Me.Label29
        'Label29.Text = 1
        'Label29.Visible = True
        'Me.Image1.Controls.Add(Me.Label29)
        'Label29.BackColor = Drawing.Color.Transparent
        ''Label29.Parent.Controls.Add(Image1)


        If Not Page.IsPostBack Then
            cargaEstados()
            cargaClientes()
            cargaRegion()
            cargaServicioTipo()
            LlenaValoresDefault()
            RadGridRobo.Visible = False
            RadGridFallecimiento.Visible = False
            RadGridInvalidez.Visible = False
            RadGridDanosMateriales.Visible = False
            RadGridRobo.Visible = False
            RadGridFallecimiento.Visible = False
            RadGridInvalidez.Visible = False
            RadGridDanosMateriales.Visible = False

            pnRobo.Visible = False
            pnInvalidez.Visible = False
            pnFallecimiento.Visible = False
            pnDM.Visible = False
            'radBtnRegresar.Visible = False
            'TotalesDesempeño1.Visible = False
        End If

    End Sub

    'Private Function LlenaTotales(ByVal DT As DataTable)
    '    'Dim terminadosTotal As LinkButton = TotalesDesempeño1.FindControl("lblTerminados")
    '    'Dim antesTiempo As Label = TotalesDesempeño1.FindControl("lblAntes")
    '    'Dim antesTiempoPorc As Label = TotalesDesempeño1.FindControl("lblAntesP")
    '    'Dim enTiempo As LinkButton = TotalesDesempeño1.FindControl("lblTiempo")
    '    'Dim enTiempoPorc As Label = TotalesDesempeño1.FindControl("lblTiempoP")
    '    'Dim fueraTiempo As LinkButton = Me.TotalesDesempeño1.FindControl("lblFuera")
    '    'Dim fueraTiempoPorc As Label = TotalesDesempeño1.FindControl("lblFueraP")
    '    'Dim porcentaje As Single

    '    If (RadComboBox3.SelectedValue = 1) Then
    '        Dim FInicial As Telerik.Web.UI.RadDatePicker = SelectorFechas.FindControl("rdFI")
    '        Dim FFinal As Telerik.Web.UI.RadDatePicker = SelectorFechas.FindControl("rdFF")
    '        FechaI = FInicial.SelectedDate.Value.ToString("yyyy-MM-dd")
    '        FechaF = FFinal.SelectedDate.Value.ToString("yyyy-MM-dd")
    '    End If

    'End Function

    Protected Sub radBtnResultado_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles radBtnResultado.Click

        Dim ds As New DataSet
        Dim ds2 As New DataSet
        Dim dt As New DataTable
        Dim dt2 As New DataTable
        Dim cliente As Integer = CboCliente.SelectedValue
        Dim servicio_tipo As Integer = cboServicioTipo.SelectedValue
        Dim FInicial As Telerik.Web.UI.RadDatePicker = SelectorFechas.FindControl("rdFI")
        Dim FFinal As Telerik.Web.UI.RadDatePicker = SelectorFechas.FindControl("rdFF")
        Dim ComboMeses As Telerik.Web.UI.RadComboBox = ComboMes.FindControl("rcMes")

        If RadComboBox3.SelectedValue = 1 Then

            FechaI = FInicial.SelectedDate.Value.ToString("yyyyMMdd")
            FechaF = FFinal.SelectedDate.Value.ToString("yyyyMMdd")

        ElseIf RadComboBox3.SelectedValue = 2 Then

            IDmes = ComboMeses.SelectedValue

            If IDmes <> 0 Then
                Dim listMes As New List(Of String)

                listMes = Asignames(IDmes)
                FechaI = listMes.Item(0)
                FechaF = listMes.Item(1)

            Else
                ConfigureNotification("Favor de seleccionar un mes")
                Exit Sub
            End If

        Else
            FechaI = "1900-01-01"
            FechaF = "1900-01-01"
        End If

        Dim region As Integer = IIf(cboRegion.SelectedValue = 0, -1, cboRegion.SelectedValue)
        Dim estado As Integer = IIf(cboEstado.SelectedValue = 0, -1, cboEstado.SelectedValue)
        Dim estatus As Integer = cboEstatus.SelectedValue

            If cliente <> 0 And servicio_tipo <> 0 Then
                ds = csDAL.CargaServiciosEtapas(cliente, servicio_tipo, estatus, FechaI, FechaF, region, estado)
                dt = ds.Tables(0)

                ds2 = csDAL.CargaEncabezadosEtapas(cliente, servicio_tipo)
                dt2 = ds.Tables(0)

                '10:     Daños(Materiales)
                '11:     Robo()
                '12:     Fallecimiento()
                '13:     Invalidez() Telerik.Web.UI
                Dim ipanel As Panel
                Dim grid As Telerik.Web.UI.RadGrid
                Select Case servicio_tipo
                    Case 10
                        ipanel = pnDM
                        grid = RadGridDanosMateriales
                        llenaencabezadosDM(dt2)
                    Case 11
                        ipanel = pnRobo
                        grid = RadGridRobo
                        llenaencabezadosRobo(dt2)
                    Case 12
                        ipanel = pnFallecimiento
                        grid = RadGridFallecimiento
                        llenaencabezadosFallecimiento(dt2)
                    Case 13
                        ipanel = pnInvalidez
                        grid = RadGridInvalidez
                        llenaencabezadosInvalidez(dt2)
                End Select

                If dt.Rows.Count <> 0 Then
                    'LlenaTotales(dt)

                    With grid
                        .DataSource = ds.Tables(0)
                        .DataBind()
                    End With

                    'For Each rw In ds.Tables(0).Rows
                    '    grid.Items(rw).FindControl("linkImagen") = rw("clv_ordas")

                    'Next

                    ds.Clear()
                    MuestraGrid(grid)
                Else
                    ''Mensage de que no se tienen valores a mostrar
                    ds.Tables.Clear()
                    ConfigureNotification("No existen datos a mostrar.")
                    LimpiaDatos()
                End If

            Else

                ConfigureNotification("Favor de seleccionar cliente y tipo de servicio")

            End If

    End Sub

    Private Function LimpiaDatos()
        RadGridRobo.DataSource = Nothing
        RadGridRobo.DataBind()
        'TotalesDesempeño1.Visible = False
        RadGridRobo.Visible = False

    End Function

    Protected Sub RadComboBox3_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBox3.SelectedIndexChanged
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

    'Protected Sub radBtnRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles radBtnRegresar.Click
    '    Response.Redirect("~/TableroGestion/Servicio1.aspx")
    'End Sub

    Protected Sub CboCliente_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles CboCliente.SelectedIndexChanged
        LimpiaDatos()

    End Sub

    Protected Sub cboServicioTipo_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cboServicioTipo.SelectedIndexChanged
        LimpiaDatos()

    End Sub

    Protected Sub cboRegion_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cboRegion.SelectedIndexChanged

        LimpiaDatos()
        cargaEstados()

    End Sub

    Protected Sub cboEstado_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cboEstado.SelectedIndexChanged

        LimpiaDatos()

    End Sub

    Public Sub MuestraGrid(ByRef grid As Telerik.Web.UI.RadGrid)

        Select Case grid.ID

            Case RadGridDanosMateriales.ID
                RadGridDanosMateriales.Visible = True
                RadGridFallecimiento.Visible = False
                RadGridInvalidez.Visible = False
                RadGridRobo.Visible = False

                cambia_imagenDanosMateriales()

                pnDM.Visible = True
                pnFallecimiento.Visible = False
                pnInvalidez.Visible = False
                pnRobo.Visible = False

            Case RadGridFallecimiento.ID
                RadGridFallecimiento.Visible = True
                RadGridDanosMateriales.Visible = False
                RadGridInvalidez.Visible = False
                RadGridRobo.Visible = False

                cambia_imagenFallecimiento()

                pnFallecimiento.Visible = True
                pnInvalidez.Visible = False
                pnRobo.Visible = False
                pnDM.Visible = False

            Case RadGridInvalidez.ID
                RadGridInvalidez.Visible = True
                RadGridFallecimiento.Visible = False
                RadGridDanosMateriales.Visible = False
                RadGridRobo.Visible = False

                cambia_imagenInvalidez()

                pnInvalidez.Visible = True
                pnFallecimiento.Visible = False
                pnRobo.Visible = False
                pnDM.Visible = False


            Case RadGridRobo.ID
                RadGridRobo.Visible = True
                RadGridFallecimiento.Visible = False
                RadGridInvalidez.Visible = False
                RadGridDanosMateriales.Visible = False

                cambia_imagenRobo()

                pnRobo.Visible = True
                pnInvalidez.Visible = False
                pnFallecimiento.Visible = False
                pnDM.Visible = False

        End Select

    End Sub

    Public Sub llenaencabezadosRobo(ByRef dt As DataTable)
        If dt.Rows.Count <> 0 Then
            Dim row As DataRow = dt.Rows(0)

            'Robo
            lblTR.Text = "&nbsp;" & row("Toma_reporte")
            lblAA.Text = "&nbsp;" & row("AsignacionAbogado")
            lblDT.Text = "&nbsp;" & row("DenunciaTelefonica")
            lblCCC.Text = "&nbsp;" & row("CitaContactoCliente")
            lblDMP.Text = "&nbsp;" & row("DenunciaAnteMP")
            lblAP.Text = "&nbsp;" & row("AcreditacionPropiedad")
            lblOCCD.Text = "&nbsp;" & row("ObtencionCopiasCertificadasDenuncia")
            lblSD.Text = "&nbsp;" & row("SolicitudDocumento")
            lblAG.Text = "&nbsp;" & row("AsignacionGestor")
            lblSPD.Text = "&nbsp;" & row("SolicitudPagoDerechos")
            lblCCCII.Text = "&nbsp;" & row("CitaContactoClienteII")
            lblRDPTA.Text = "&nbsp;" & row("RecepcionDictamenPTAseguradora")
            lblRDO.Text = "&nbsp;" & row("RecepcionDocOriginales")
            lblTBP.Text = "&nbsp;" & row("TramiteBajaPlacas")
            lblED.Text = "&nbsp;" & row("EntregaDocumentos")
            lblIE.Text = "&nbsp;" & row("IntegracionExpediente")
            lblDD.Text = "&nbsp;" & row("DigitilizacionDocumentos")
            lblEEF.Text = "&nbsp;" & row("EntregaExpedienteFisico")
            lblAR.Text = "&nbsp;" & row("AcuseRecibo")

        Else
            pnDM.Visible = False
            pnFallecimiento.Visible = False
            pnInvalidez.Visible = False
            pnRobo.Visible = False
            ConfigureNotification("No se encuntran datos. Favor de validar filtros")
        End If

    End Sub

    Public Sub llenaencabezadosDM(ByRef dt As DataTable)


        If dt.Rows.Count <> 0 Then
            Dim row As DataRow = dt.Rows(0)
            'Daños Materiales

            DMlblTR.Text = "&nbsp;" & row("Toma_reporte")
            DMlblSD.Text = "&nbsp;" & row("SolicitudDocumento")
            DMlblAG.Text = "&nbsp;" & row("AsignacionGestor")
            DMlblFPD.Text = "&nbsp;" & row("FondoPagoDerechos")
            DMlblSPD.Text = "&nbsp;" & row("SolicitudPagoDerechos")
            DMlblCCC.Text = "&nbsp;" & row("CitaContactoCliente")
            DMlblRDO.Text = "&nbsp;" & row("RecepcionDocOriginales")
            DMlblTBP.Text = "&nbsp;" & row("TramiteBajaPlacas")
            DMlblED.Text = "&nbsp;" & row("EntregaDocumentos")
            DMlblIE.Text = "&nbsp;" & row("IntegracionExpediente")
            DMlblDD.Text = "&nbsp;" & row("DigitilizacionDocumentos")
            DMlblEEF.Text = "&nbsp;" & row("EntregaExpedienteFisico")
            DMlblAR.Text = "&nbsp;" & row("AcuseRecibo")

        Else
            pnDM.Visible = False
            pnFallecimiento.Visible = False
            pnInvalidez.Visible = False
            pnRobo.Visible = False
            ConfigureNotification("No se encuntran datos. Favor de validar filtros")
        End If

    End Sub

    Public Sub llenaencabezadosInvalidez(ByRef dt As DataTable)


        'Invalidez

        If dt.Rows.Count <> 0 Then
            Dim row As DataRow = dt.Rows(0)
            IlblTR.Text = "&nbsp;" & row("Toma_reporte")
            IlblSD.Text = "&nbsp;" & row("SolicitudDocumento")
            IlblAG.Text = "&nbsp;" & row("AsignacionGestor")
            IlblFPD.Text = "&nbsp;" & row("FondoPagoDerechos")
            IlblSPD.Text = "&nbsp;" & row("SolicitudPagoDerechos")
            IlblCCC.Text = "&nbsp;" & row("CitaContactoCliente")
            IlblRDO.Text = "&nbsp;" & row("RecepcionDocOriginales")
            IlblGI.Text = "&nbsp;" & row("GestoriaInvalidez")
            IlblED.Text = "&nbsp;" & row("EntregaDocumentos")
            IlblIE.Text = "&nbsp;" & row("IntegracionExpediente")
            IlblDD.Text = "&nbsp;" & row("DigitilizacionDocumentos")
            IlblEEF.Text = "&nbsp;" & row("EntregaExpedienteFisico")
            IlblAR.Text = "&nbsp;" & row("AcuseRecibo")

        Else
            pnDM.Visible = False
            pnFallecimiento.Visible = False
            pnInvalidez.Visible = False
            pnRobo.Visible = False
            ConfigureNotification("No se encuntran datos. Favor de validar filtros")
        End If

    End Sub

    Public Sub llenaencabezadosFallecimiento(ByRef dt As DataTable)


        'Fallecimiento

        If dt.Rows.Count <> 0 Then
            Dim row As DataRow = dt.Rows(0)

            FlblTR.Text = "&nbsp;" & row("Toma_reporte")
            FlblSD.Text = "&nbsp;" & row("SolicitudDocumento")
            FlblAG.Text = "&nbsp;" & row("AsignacionGestor")
            FlblFPD.Text = "&nbsp;" & row("FondoPagoDerechos")
            FlblSPD.Text = "&nbsp;" & row("SolicitudPagoDerechos")
            FlblCCC.Text = "&nbsp;" & row("CitaContactoCliente")
            FlblRDO.Text = "&nbsp;" & row("RecepcionDocOriginales")
            FlblGF.Text = "&nbsp;" & row("GestoriaFallecimiento")
            FlblED.Text = "&nbsp;" & row("EntregaDocumentos")
            FlblIE.Text = "&nbsp;" & row("IntegracionExpediente")
            FlblDD.Text = "&nbsp;" & row("DigitilizacionDocumentos")
            FlblEEF.Text = "&nbsp;" & row("EntregaExpedienteFisico")
            FlblAR.Text = "&nbsp;" & row("AcuseRecibo")

        Else
            pnDM.Visible = False
            pnFallecimiento.Visible = False
            pnInvalidez.Visible = False
            pnRobo.Visible = False
            ConfigureNotification("No se encuntran datos. Favor de validar filtros")
        End If

    End Sub

    Public Function Quitaespacion(ByVal cadena As String)

        Quitaespacion = Replace(cadena, "&nbsp;", "")

        Return Quitaespacion
    End Function

    Private Sub cambia_imagenInvalidez()

        Dim x As Integer = 0
        For Each item As GridDataItem In RadGridInvalidez.Items

            Dim iImagen As New Image
            iImagen = RadGridInvalidez.Items(x).FindControl("imgToma_ReporteA")
            If CInt(item.Item("Toma_Reporte").Text) = CInt(Quitaespacion(IlblTR.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Amarillo.png"
            ElseIf CInt(item.Item("Toma_Reporte").Text) < CInt(Quitaespacion(IlblTR.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Verde.png"
            Else
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_rojo.png"
            End If

            iImagen = RadGridInvalidez.Items(x).FindControl("imgSolicitudDocumentoA")
            If CInt(item.Item("SolicitudDocumento").Text) = CInt(Quitaespacion(IlblSD.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Amarillo.png"
            ElseIf CInt(item.Item("SolicitudDocumento").Text) < CInt(Quitaespacion(IlblSD.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Verde.png"
            Else
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_rojo.png"
            End If

            iImagen = RadGridInvalidez.Items(x).FindControl("imgAsignacionGestorA")
            If CInt(item.Item("AsignacionGestor").Text) = CInt(Quitaespacion(IlblAG.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Amarillo.png"
            ElseIf CInt(item.Item("AsignacionGestor").Text) < CInt(Quitaespacion(IlblAG.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Verde.png"
            Else
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_rojo.png"
            End If

            iImagen = RadGridInvalidez.Items(x).FindControl("imgFondoPagoDerechosA")
            If CInt(item.Item("FondoPagoDerechos").Text) = CInt(Quitaespacion(IlblFPD.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Amarillo.png"
            ElseIf CInt(item.Item("FondoPagoDerechos").Text) < CInt(Quitaespacion(IlblFPD.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Verde.png"
            Else
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_rojo.png"
            End If

            iImagen = RadGridInvalidez.Items(x).FindControl("imgSolicitudPagoDerechosA")
            If CInt(item.Item("SolicitudPagoDerechos").Text) = CInt(Quitaespacion(IlblSPD.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Amarillo.png"
            ElseIf CInt(item.Item("SolicitudPagoDerechos").Text) < CInt(Quitaespacion(IlblSPD.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Verde.png"
            Else
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_rojo.png"
            End If

            iImagen = RadGridInvalidez.Items(x).FindControl("imgCitaContactoClienteA")
            If CInt(item.Item("CitaContactoCliente").Text) = CInt(Quitaespacion(IlblCCC.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Amarillo.png"
            ElseIf CInt(item.Item("CitaContactoCliente").Text) < CInt(Quitaespacion(IlblCCC.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Verde.png"
            Else
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_rojo.png"
            End If

            iImagen = RadGridInvalidez.Items(x).FindControl("imgRecepcionDocOriginalesA")
            If CInt(item.Item("RecepcionDocOriginales").Text) = CInt(Quitaespacion(IlblRDO.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Amarillo.png"
            ElseIf CInt(item.Item("RecepcionDocOriginales").Text) < CInt(Quitaespacion(IlblRDO.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Verde.png"
            Else
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_rojo.png"
            End If

            iImagen = RadGridInvalidez.Items(x).FindControl("imgGestoriaInvalidezA")
            If CInt(item.Item("GestoriaInvalidez").Text) = CInt(Quitaespacion(IlblGI.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Amarillo.png"
            ElseIf CInt(item.Item("GestoriaInvalidez").Text) < CInt(Quitaespacion(IlblGI.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Verde.png"
            Else
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_rojo.png"
            End If

            iImagen = RadGridInvalidez.Items(x).FindControl("imgEntregaDocumentosA")
            If CInt(item.Item("EntregaDocumentos").Text) = CInt(Quitaespacion(IlblED.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Amarillo.png"
            ElseIf CInt(item.Item("EntregaDocumentos").Text) < CInt(Quitaespacion(IlblED.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Verde.png"
            Else
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_rojo.png"
            End If

            iImagen = RadGridInvalidez.Items(x).FindControl("imgIntegracionExpedienteA")
            If CInt(item.Item("IntegracionExpediente").Text) = CInt(Quitaespacion(IlblIE.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Amarillo.png"
            ElseIf CInt(item.Item("IntegracionExpediente").Text) < CInt(Quitaespacion(IlblIE.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Verde.png"
            Else
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_rojo.png"
            End If

            iImagen = RadGridInvalidez.Items(x).FindControl("imgDigitilizacionDocumentosA")
            If CInt(item.Item("DigitilizacionDocumentos").Text) = CInt(Quitaespacion(IlblDD.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Amarillo.png"
            ElseIf CInt(item.Item("DigitilizacionDocumentos").Text) < CInt(Quitaespacion(IlblDD.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Verde.png"
            Else
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_rojo.png"
            End If

            iImagen = RadGridInvalidez.Items(x).FindControl("imgEntregaExpedienteFisicoA")
            If CInt(item.Item("EntregaExpedienteFisico").Text) = CInt(Quitaespacion(IlblEEF.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Amarillo.png"
            ElseIf CInt(item.Item("EntregaExpedienteFisico").Text) < CInt(Quitaespacion(IlblEEF.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Verde.png"
            Else
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_rojo.png"
            End If

            iImagen = RadGridInvalidez.Items(x).FindControl("imgAcuseReciboA")
            If CInt(item.Item("AcuseRecibo").Text) = CInt(Quitaespacion(IlblAR.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Amarillo.png"
            ElseIf CInt(item.Item("AcuseRecibo").Text) < CInt(Quitaespacion(IlblAR.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Verde.png"
            Else
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_rojo.png"
            End If

            x += 1

        Next
    End Sub

    Private Sub cambia_imagenFallecimiento()

        Dim x As Integer = 0
        For Each item As GridDataItem In RadGridFallecimiento.Items

            Dim iImagen As New Image
            iImagen = RadGridFallecimiento.Items(x).FindControl("imgToma_ReporteA")
            If CInt(item.Item("Toma_Reporte").Text) = CInt(Quitaespacion(FlblTR.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Amarillo.png"
            ElseIf CInt(item.Item("Toma_Reporte").Text) < CInt(Quitaespacion(FlblTR.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Verde.png"
            Else
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_rojo.png"
            End If

            iImagen = RadGridFallecimiento.Items(x).FindControl("imgSolicitudDocumentoA")
            If CInt(item.Item("SolicitudDocumento").Text) = CInt(Quitaespacion(FlblSD.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Amarillo.png"
            ElseIf CInt(item.Item("SolicitudDocumento").Text) < CInt(Quitaespacion(FlblSD.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Verde.png"
            Else
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_rojo.png"
            End If

            iImagen = RadGridFallecimiento.Items(x).FindControl("imgAsignacionGestorA")
            If CInt(item.Item("AsignacionGestor").Text) = CInt(Quitaespacion(FlblAG.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Amarillo.png"
            ElseIf CInt(item.Item("AsignacionGestor").Text) < CInt(Quitaespacion(FlblAG.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Verde.png"
            Else
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_rojo.png"
            End If

            iImagen = RadGridFallecimiento.Items(x).FindControl("imgFondoPagoDerechosA")
            If CInt(item.Item("FondoPagoDerechos").Text) = CInt(Quitaespacion(FlblFPD.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Amarillo.png"
            ElseIf CInt(item.Item("FondoPagoDerechos").Text) < CInt(Quitaespacion(FlblFPD.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Verde.png"
            Else
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_rojo.png"
            End If

            iImagen = RadGridFallecimiento.Items(x).FindControl("imgSolicitudPagoDerechosA")
            If CInt(item.Item("SolicitudPagoDerechos").Text) = CInt(Quitaespacion(FlblSPD.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Amarillo.png"
            ElseIf CInt(item.Item("SolicitudPagoDerechos").Text) < CInt(Quitaespacion(FlblSPD.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Verde.png"
            Else
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_rojo.png"
            End If

            iImagen = RadGridFallecimiento.Items(x).FindControl("imgCitaContactoClienteA")
            If CInt(item.Item("CitaContactoCliente").Text) = CInt(Quitaespacion(FlblCCC.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Amarillo.png"
            ElseIf CInt(item.Item("CitaContactoCliente").Text) < CInt(Quitaespacion(FlblCCC.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Verde.png"
            Else
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_rojo.png"
            End If

            iImagen = RadGridFallecimiento.Items(x).FindControl("imgRecepcionDocOriginalesA")
            If CInt(item.Item("RecepcionDocOriginales").Text) = CInt(Quitaespacion(FlblRDO.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Amarillo.png"
            ElseIf CInt(item.Item("RecepcionDocOriginales").Text) < CInt(Quitaespacion(FlblRDO.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Verde.png"
            Else
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_rojo.png"
            End If

            iImagen = RadGridFallecimiento.Items(x).FindControl("imgGestoriaFallecimientoA")
            If CInt(item.Item("GestoriaFallecimiento").Text) = CInt(Quitaespacion(FlblGF.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Amarillo.png"
            ElseIf CInt(item.Item("GestoriaFallecimiento").Text) < CInt(Quitaespacion(FlblGF.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Verde.png"
            Else
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_rojo.png"
            End If

            iImagen = RadGridFallecimiento.Items(x).FindControl("imgEntregaDocumentosA")
            If CInt(item.Item("EntregaDocumentos").Text) = CInt(Quitaespacion(FlblED.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Amarillo.png"
            ElseIf CInt(item.Item("EntregaDocumentos").Text) < CInt(Quitaespacion(FlblED.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Verde.png"
            Else
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_rojo.png"
            End If

            iImagen = RadGridFallecimiento.Items(x).FindControl("imgIntegracionExpedienteA")
            If CInt(item.Item("IntegracionExpediente").Text) = CInt(Quitaespacion(FlblIE.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Amarillo.png"
            ElseIf CInt(item.Item("IntegracionExpediente").Text) < CInt(Quitaespacion(FlblIE.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Verde.png"
            Else
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_rojo.png"
            End If

            iImagen = RadGridFallecimiento.Items(x).FindControl("imgDigitilizacionDocumentosA")
            If CInt(item.Item("DigitilizacionDocumentos").Text) = CInt(Quitaespacion(FlblDD.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Amarillo.png"
            ElseIf CInt(item.Item("DigitilizacionDocumentos").Text) < CInt(Quitaespacion(FlblDD.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Verde.png"
            Else
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_rojo.png"
            End If

            iImagen = RadGridFallecimiento.Items(x).FindControl("imgEntregaExpedienteFisicoA")
            If CInt(item.Item("EntregaExpedienteFisico").Text) = CInt(Quitaespacion(FlblEEF.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Amarillo.png"
            ElseIf CInt(item.Item("EntregaExpedienteFisico").Text) < CInt(Quitaespacion(FlblEEF.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Verde.png"
            Else
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_rojo.png"
            End If

            iImagen = RadGridFallecimiento.Items(x).FindControl("imgAcuseReciboA")
            If CInt(item.Item("AcuseRecibo").Text) = CInt(Quitaespacion(FlblAR.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Amarillo.png"
            ElseIf CInt(item.Item("AcuseRecibo").Text) < CInt(Quitaespacion(FlblAR.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Verde.png"
            Else
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_rojo.png"
            End If

            x += 1

        Next
    End Sub

    Private Sub cambia_imagenDanosMateriales()

        Dim x As Integer = 0
        For Each item As GridDataItem In RadGridDanosMateriales.Items

            Dim iImagen As New Image
            iImagen = RadGridDanosMateriales.Items(x).FindControl("imgToma_ReporteA")
            If CInt(item.Item("Toma_Reporte").Text) = CInt(Quitaespacion(DMlblTR.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Amarillo.png"
            ElseIf CInt(item.Item("Toma_Reporte").Text) < CInt(Quitaespacion(DMlblTR.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Verde.png"
            Else
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_rojo.png"
            End If

            iImagen = RadGridDanosMateriales.Items(x).FindControl("imgSolicitudDocumentosA")
            If CInt(item.Item("SolicitudDocumentos").Text) = CInt(Quitaespacion(DMlblSD.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Amarillo.png"
            ElseIf CInt(item.Item("SolicitudDocumentos").Text) < CInt(Quitaespacion(DMlblSD.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Verde.png"
            Else
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_rojo.png"
            End If

            iImagen = RadGridDanosMateriales.Items(x).FindControl("imgAsignacionGestorA")
            If CInt(item.Item("AsignacionGestor").Text) = CInt(Quitaespacion(DMlblAG.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Amarillo.png"
            ElseIf CInt(item.Item("AsignacionGestor").Text) < CInt(Quitaespacion(DMlblAG.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Verde.png"
            Else
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_rojo.png"
            End If

            iImagen = RadGridDanosMateriales.Items(x).FindControl("imgFondoPagoDerechosA")
            If CInt(item.Item("FondoPagoDerechos").Text) = CInt(Quitaespacion(DMlblFPD.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Amarillo.png"
            ElseIf CInt(item.Item("FondoPagoDerechos").Text) < CInt(Quitaespacion(DMlblFPD.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Verde.png"
            Else
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_rojo.png"
            End If

            iImagen = RadGridDanosMateriales.Items(x).FindControl("imgSolicitudPagoDerechosA")
            If CInt(item.Item("SolicitudPagoDerechos").Text) = CInt(Quitaespacion(DMlblSPD.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Amarillo.png"
            ElseIf CInt(item.Item("SolicitudPagoDerechos").Text) < CInt(Quitaespacion(DMlblSPD.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Verde.png"
            Else
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_rojo.png"
            End If

            iImagen = RadGridDanosMateriales.Items(x).FindControl("imgCitaContactoClienteA")
            If CInt(item.Item("CitaContactoCliente").Text) = CInt(Quitaespacion(DMlblCCC.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Amarillo.png"
            ElseIf CInt(item.Item("CitaContactoCliente").Text) < CInt(Quitaespacion(DMlblCCC.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Verde.png"
            Else
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_rojo.png"
            End If

            iImagen = RadGridDanosMateriales.Items(x).FindControl("imgRecepcionDocOriginalesA")
            If CInt(item.Item("RecepcionDocOriginales").Text) = CInt(Quitaespacion(DMlblRDO.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Amarillo.png"
            ElseIf CInt(item.Item("RecepcionDocOriginales").Text) < CInt(Quitaespacion(DMlblRDO.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Verde.png"
            Else
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_rojo.png"
            End If

            iImagen = RadGridDanosMateriales.Items(x).FindControl("imgTramiteBajaPlacasA")
            If CInt(item.Item("TramiteBajaPlacas").Text) = CInt(Quitaespacion(DMlblTBP.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Amarillo.png"
            ElseIf CInt(item.Item("TramiteBajaPlacas").Text) < CInt(Quitaespacion(DMlblTBP.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Verde.png"
            Else
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_rojo.png"
            End If

            iImagen = RadGridDanosMateriales.Items(x).FindControl("imgEntregaDocumentosA")
            If CInt(item.Item("EntregaDocumentos").Text) = CInt(Quitaespacion(DMlblED.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Amarillo.png"
            ElseIf CInt(item.Item("EntregaDocumentos").Text) < CInt(Quitaespacion(DMlblED.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Verde.png"
            Else
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_rojo.png"
            End If

            iImagen = RadGridDanosMateriales.Items(x).FindControl("imgIntegracionExpedienteA")
            If CInt(item.Item("IntegracionExpediente").Text) = CInt(Quitaespacion(DMlblIE.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Amarillo.png"
            ElseIf CInt(item.Item("IntegracionExpediente").Text) < CInt(Quitaespacion(DMlblIE.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Verde.png"
            Else
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_rojo.png"
            End If

            iImagen = RadGridDanosMateriales.Items(x).FindControl("imgDigitilizacionDocumentosA")
            If CInt(item.Item("DigitilizacionDocumentos").Text) = CInt(Quitaespacion(DMlblDD.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Amarillo.png"
            ElseIf CInt(item.Item("DigitilizacionDocumentos").Text) < CInt(Quitaespacion(DMlblDD.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Verde.png"
            Else
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_rojo.png"
            End If

            iImagen = RadGridDanosMateriales.Items(x).FindControl("imgEntregaExpedienteFisicoA")
            If CInt(item.Item("EntregaExpedienteFisico").Text) = CInt(Quitaespacion(DMlblEEF.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Amarillo.png"
            ElseIf CInt(item.Item("EntregaExpedienteFisico").Text) < CInt(Quitaespacion(DMlblEEF.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Verde.png"
            Else
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_rojo.png"
            End If

            iImagen = RadGridDanosMateriales.Items(x).FindControl("imgAcuseReciboA")
            If CInt(item.Item("AcuseRecibo").Text) = CInt(Quitaespacion(DMlblAR.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Amarillo.png"
            ElseIf CInt(item.Item("AcuseRecibo").Text) < CInt(Quitaespacion(DMlblAR.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Verde.png"
            Else
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_rojo.png"
            End If

            x += 1

        Next
    End Sub

    Private Sub cambia_imagenRobo()

        Dim x As Integer = 0
        For Each item As GridDataItem In RadGridRobo.Items

            Dim iImagen As New Image
            iImagen = RadGridRobo.Items(x).FindControl("imgToma_ReporteA")
            If CInt(item.Item("Toma_Reporte").Text) = CInt(Quitaespacion(lblTR.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Amarillo.png"
            ElseIf CInt(item.Item("Toma_Reporte").Text) < CInt(Quitaespacion(lblTR.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Verde.png"
            Else
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_rojo.png"
            End If

            iImagen = RadGridRobo.Items(x).FindControl("imgAsignacionAbogadoA")
            If CInt(item.Item("AsignacionAbogado").Text) = CInt(Quitaespacion(lblAA.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Amarillo.png"
            ElseIf CInt(item.Item("AsignacionAbogado").Text) < CInt(Quitaespacion(lblAA.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Verde.png"
            Else
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_rojo.png"
            End If

            iImagen = RadGridRobo.Items(x).FindControl("imgDenunciaTelefonicaA")
            If CInt(item.Item("DenunciaTelefonica").Text) = CInt(Quitaespacion(lblDT.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Amarillo.png"
            ElseIf CInt(item.Item("DenunciaTelefonica").Text) < CInt(Quitaespacion(lblDT.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Verde.png"
            Else
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_rojo.png"
            End If

            'iImagen = RadGridRobo.Items(x).FindControl("imgCitaContactoClienteA")
            'If CInt(item.Item("CitaContactoCliente").Text) = CInt(Quitaespacion(lblCCC.Text).Trim) Then
            '    iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Amarillo.png"
            'ElseIf CInt(item.Item("FondoPagoDerechos").Text) < CInt(Quitaespacion(IlblFPD.Text).Trim) Then
            '    iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Verde.png"
            'Else
            '    iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_rojo.png"
            'End If

            iImagen = RadGridRobo.Items(x).FindControl("imgDenunciaAnteMPA")
            If CInt(item.Item("DenunciaAnteMP").Text) = CInt(Quitaespacion(lblDMP.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Amarillo.png"
            ElseIf CInt(item.Item("DenunciaAnteMP").Text) < CInt(Quitaespacion(lblDMP.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Verde.png"
            Else
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_rojo.png"
            End If

            iImagen = RadGridRobo.Items(x).FindControl("imgAcreditacionPropiedadA")
            If CInt(item.Item("AcreditacionPropiedad").Text) = CInt(Quitaespacion(lblAP.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Amarillo.png"
            ElseIf CInt(item.Item("AcreditacionPropiedad").Text) < CInt(Quitaespacion(lblAP.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Verde.png"
            Else
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_rojo.png"
            End If

            iImagen = RadGridRobo.Items(x).FindControl("imgObtencionCopiasCertificadasDenunciaA")
            If CInt(item.Item("ObtencionCopiasCertificadasDenuncia").Text) = CInt(Quitaespacion(lblOCCD.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Amarillo.png"
            ElseIf CInt(item.Item("ObtencionCopiasCertificadasDenuncia").Text) < CInt(Quitaespacion(lblOCCD.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Verde.png"
            Else
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_rojo.png"
            End If

            iImagen = RadGridRobo.Items(x).FindControl("imgSolicitudDocumentoA")
            If CInt(item.Item("SolicitudDocumento").Text) = CInt(Quitaespacion(lblSD.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Amarillo.png"
            ElseIf CInt(item.Item("SolicitudDocumento").Text) < CInt(Quitaespacion(lblSD.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Verde.png"
            Else
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_rojo.png"
            End If

            iImagen = RadGridRobo.Items(x).FindControl("imgAsignacionGestorA")
            If CInt(item.Item("AsignacionGestor").Text) = CInt(Quitaespacion(lblAG.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Amarillo.png"
            ElseIf CInt(item.Item("AsignacionGestor").Text) < CInt(Quitaespacion(lblAG.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Verde.png"
            Else
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_rojo.png"
            End If

            iImagen = RadGridRobo.Items(x).FindControl("imgSolicitudPagoDerechosA")
            If CInt(item.Item("SolicitudPagoDerechos").Text) = CInt(Quitaespacion(lblSPD.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Amarillo.png"
            ElseIf CInt(item.Item("SolicitudPagoDerechos").Text) < CInt(Quitaespacion(lblSPD.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Verde.png"
            Else
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_rojo.png"
            End If

            iImagen = RadGridRobo.Items(x).FindControl("imgCitaContactoClienteIIA")
            If CInt(item.Item("CitaContactoClienteII").Text) = CInt(Quitaespacion(lblCCCII.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Amarillo.png"
            ElseIf CInt(item.Item("CitaContactoClienteII").Text) < CInt(Quitaespacion(lblCCCII.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Verde.png"
            Else
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_rojo.png"
            End If

            iImagen = RadGridRobo.Items(x).FindControl("imgRecepcionDictamenPTAseguradoraA")
            If CInt(item.Item("RecepcionDictamenPTAseguradora").Text) = CInt(Quitaespacion(lblRDPTA.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Amarillo.png"
            ElseIf CInt(item.Item("RecepcionDictamenPTAseguradora").Text) < CInt(Quitaespacion(lblRDPTA.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Verde.png"
            Else
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_rojo.png"
            End If

            iImagen = RadGridRobo.Items(x).FindControl("imgRecepcionDocOriginalesA")
            If CInt(item.Item("RecepcionDocOriginales").Text) = CInt(Quitaespacion(lblRDO.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Amarillo.png"
            ElseIf CInt(item.Item("RecepcionDocOriginales").Text) < CInt(Quitaespacion(lblRDO.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Verde.png"
            Else
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_rojo.png"
            End If

            iImagen = RadGridRobo.Items(x).FindControl("imgTramiteBajaPlacasA")
            If CInt(item.Item("TramiteBajaPlacas").Text) = CInt(Quitaespacion(lblTBP.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Amarillo.png"
            ElseIf CInt(item.Item("TramiteBajaPlacas").Text) < CInt(Quitaespacion(lblTBP.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Verde.png"
            Else
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_rojo.png"
            End If

            iImagen = RadGridRobo.Items(x).FindControl("imgDigitilizacionDocumentosA")
            If CInt(item.Item("DigitilizacionDocumentos").Text) = CInt(Quitaespacion(lblDD.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Amarillo.png"
            ElseIf CInt(item.Item("DigitilizacionDocumentos").Text) < CInt(Quitaespacion(lblDD.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Verde.png"
            Else
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_rojo.png"
            End If

            iImagen = RadGridRobo.Items(x).FindControl("imgEntregaExpedienteFisicoA")
            If CInt(item.Item("EntregaExpedienteFisico").Text) = CInt(Quitaespacion(lblEEF.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Amarillo.png"
            ElseIf CInt(item.Item("EntregaExpedienteFisico").Text) < CInt(Quitaespacion(lblEEF.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Verde.png"
            Else
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_rojo.png"
            End If

            iImagen = RadGridRobo.Items(x).FindControl("imgAcuseReciboA")
            If CInt(item.Item("AcuseRecibo").Text) = CInt(Quitaespacion(lblAR.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Amarillo.png"
            ElseIf CInt(item.Item("AcuseRecibo").Text) < CInt(Quitaespacion(lblAR.Text).Trim) Then
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_Verde.png"
            Else
                iImagen.ImageUrl = "~/Imagenes/ImgEtapas/indice_rojo.png"
            End If

            x += 1

        Next
    End Sub

    Public Function Asignames(ByVal idmes As Integer) As List(Of String)
        Dim fechas As New List(Of String)
        'yyyy-MM-dd

        Select Case idmes
            Case 1
                fechas.Add(Year(Now()) & "0101")
                fechas.Add(Year(Now()) & "0131")
            Case 2
                fechas.Add(Year(Now()) & "0201")
                fechas.Add(Year(Now()) & "0229")
            Case 3
                fechas.Add(Year(Now()) & "0301")
                fechas.Add(Year(Now()) & "0331")
            Case 4
                fechas.Add(Year(Now()) & "0401")
                fechas.Add(Year(Now()) & "0430")
            Case 5
                fechas.Add(Year(Now()) & "0501")
                fechas.Add(Year(Now()) & "0531")
            Case 6
                fechas.Add(Year(Now()) & "0601")
                fechas.Add(Year(Now()) & "0630")
            Case 7
                fechas.Add(Year(Now()) & "0701")
                fechas.Add(Year(Now()) & "0731")
            Case 8
                fechas.Add(Year(Now()) & "0801")
                fechas.Add(Year(Now()) & "0831")
            Case 9
                fechas.Add(Year(Now()) & "0901")
                fechas.Add(Year(Now()) & "0930")
            Case 10
                fechas.Add(Year(Now()) & "1001")
                fechas.Add(Year(Now()) & "1031")
            Case 11
                fechas.Add(Year(Now()) & "1101")
                fechas.Add(Year(Now()) & "1130")
            Case 12
                fechas.Add(Year(Now()) & "1201")
                fechas.Add(Year(Now()) & "1231")
        End Select
        Asignames = fechas
        Return Asignames
    End Function

End Class




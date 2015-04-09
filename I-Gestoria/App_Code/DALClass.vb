Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Public Class DALClass
    Dim csNeg As New ClaseNegocios
    Dim csSQLsvr As New BaseDatosSQL
    Dim conBaseDatos As String = System.Configuration.ConfigurationManager.AppSettings("ConnStringSQL")

#Region "General"

    'Combos Comunes
    Public Sub CargaEstados(ByRef catEstado As Telerik.Web.UI.RadComboBox)

        Dim comando As String = "exec Select_cbo_estados"
        csSQLsvr.LlenarRadCombo(catEstado, comando, conBaseDatos)

    End Sub

    Public Sub CargaMpio(ByRef catMpio As Telerik.Web.UI.RadComboBox, ByVal clvEstado As Integer)

        Dim comando As String = ""
        Dim dt As DataTable

        If clvEstado > 0 Then
            comando = "exec Select_Municipios "
            Dim filtro As String = ""

            dt = csSQLsvr.QueryDataDatable(comando, conBaseDatos)
            Dim DV As New DataView(dt)
            filtro = "ESTADO in (0," & clvEstado & ")"
            DV.RowFilter = filtro
            DV.Sort = "estado,clvMpio"
            dt = DV.ToTable()

            csSQLsvr.LlenarRadCombo(catMpio, comando, conBaseDatos, dt)
        Else

            catMpio.Items.Clear()
            catMpio.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("<Seleccione un Estado>", "0"))

        End If


    End Sub


    'Mensajes
    Public Sub ConfigureNotification(ByRef notificacion As Telerik.Web.UI.RadNotification, ByVal texto As String, Optional ByVal titulo As String = "Atención")
        'String
        'lblError0.Text = texto
        notificacion.Title = titulo
        notificacion.Text = texto
        'Enum
        notificacion.Position = Telerik.Web.UI.NotificationPosition.Center
        notificacion.Animation = Telerik.Web.UI.NotificationAnimation.Fade
        'notificacion.ContentScrolling = Telerik.Web.UI.NotificationScrolling.Default
        notificacion.AutoCloseDelay = 50000
        'Unit
        notificacion.Width = 300
        notificacion.Height = 150
        notificacion.OffsetX = -10
        notificacion.OffsetY = 10

        notificacion.Pinned = False
        notificacion.EnableRoundedCorners = True
        notificacion.EnableShadow = True
        notificacion.KeepOnMouseOver = False
        notificacion.VisibleTitlebar = True
        notificacion.ShowCloseButton = True
        notificacion.Show()

    End Sub


#End Region



    Public Function CargaEstadosSinAsignar(ByVal rfc As String) As DataSet

        Dim comando As String = String.Empty
        comando = "exec sp_EstadosMulti '" & rfc & "'"

        CargaEstadosSinAsignar = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        Return CargaEstadosSinAsignar

    End Function
    Public Function eliminarestadosMpio(ByVal rfc As String, ByVal clvEstado As Integer) As Boolean
        Dim comando As String = String.Empty
        comando = "exec sp_elimina_EstadosMpioMulti '" & rfc & "'," & clvEstado
        eliminarestadosMpio = csSQLsvr.EjecutarSP(comando, conBaseDatos)
        Return eliminarestadosMpio
    End Function
    Public Function BuscaGestoresconPoder(ByVal rfc As String) As DataSet

        Dim comando As String = String.Empty
        comando = "select * from Poderes_Empresas where rfcGestor= '" & rfc & "'"
        BuscaGestoresconPoder = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        Return BuscaGestoresconPoder

    End Function

    Public Function InsertaMultipleEstadoMpio(ByVal rfc As String, ByVal estado As String, ByVal mpio As String) As Boolean
        Dim comando As String = String.Empty
        comando = "exec GestoresMultiMpio_SP '" & rfc & "'," & estado & "," & mpio
        InsertaMultipleEstadoMpio = csSQLsvr.EjecutarSP(comando, conBaseDatos)
        Return InsertaMultipleEstadoMpio
    End Function
    Public Function CargaEncabezadosEtapas(ByVal contrato As String, ByVal servicio As String) As DataSet

        Dim comando As String = String.Empty
        comando = "exec DiasLimiteServicios_sp '" & contrato & "', '" & servicio & "'"
        CargaEncabezadosEtapas = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        Return CargaEncabezadosEtapas

    End Function

    Public Function CargaServiciosEtapas(ByVal contrato As String, ByVal servicio As String, ByVal estatus As Integer, Optional ByVal FechaIni As String = "1900-01-01", Optional ByVal FechaFin As String = "1900-01-01", Optional ByVal Region As String = "-1", Optional ByVal Estado As String = "-1") As DataSet

        Dim comando As String = String.Empty
        comando = "exec ReporteServiciosEtapas_SP '" & contrato & "', '" & servicio & "', " & estatus & ", '" & FechaIni & _
            "', '" & FechaFin & "', '" & Region & "', '" & Estado & "'"
        CargaServiciosEtapas = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        Return CargaServiciosEtapas

    End Function


    Public Function buscaExpedienteGestionGeneral(ByVal NoGestion As String) As DataSet

        ' descomponemos el No dado en los datos correctos:
        Dim sGestion As String = NoGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)

        Dim comando As String = "exec buscaExpedienteGestionGeneral_sp " & p_Anio & "," & p_Cliente & "," & p_tipo & "," & p_estado & "," & p_consec
        Dim dsExpediente As New DataSet
        dsExpediente = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        buscaExpedienteGestionGeneral = dsExpediente
        Return buscaExpedienteGestionGeneral
    End Function

    'Public Function update_ReporteGestionGeneral(ByVal NoGestion As String, ByVal ReporteGestionPTRobo_MarcaVehi As String, _
    '                                         ByVal ReporteGestionPTRobo_SubMarcaVehi As String, ByVal ReporteGestionPTRobo_ModeloVehi As Integer, ByVal ReporteGestionPTRobo_ColorVehi As String, _
    '                                         ByVal ReporteGestionPTRobo_SerieVehi As String, ByVal ReporteGestionPTRobo_PlacasVehi As String, ByVal ReporteGestionInfo_correo As String, ByVal ReporteGestionInfo_Cel As String, ByVal ReporteGestionPTRobo_Descripcion As String, ByVal GestionGeneral_Llama As Integer) As Boolean
    '    Dim sGestion As String = NoGestion.Trim
    '    Dim nLargo As Integer = Len(sGestion)
    '    Dim p_Anio As String = Mid(sGestion, 1, 4)
    '    Dim p_Cliente As String = Mid(sGestion, 5, 2)
    '    Dim p_tipo As String = Mid(sGestion, 7, 2)
    '    Dim p_estado As String = Mid(sGestion, 9, 2)
    '    Dim p_consec As String = Mid(sGestion, 11, nLargo)
    '    Dim comando As String = "exec update_ReporteGestionGeneral " & _
    '    p_Anio & "," & _
    '    p_Cliente & "," & _
    '    p_tipo & "," & _
    '    p_estado & "," & _
    '    p_consec & "," & _
    '    csNeg.myStr(ReporteGestionPTRobo_MarcaVehi) & "," & _
    '    csNeg.myStr(ReporteGestionPTRobo_SubMarcaVehi) & "," & _
    '    ReporteGestionPTRobo_ModeloVehi & "," & _
    '    csNeg.myStr(ReporteGestionPTRobo_ColorVehi) & "," & _
    '    csNeg.myStr(ReporteGestionPTRobo_PlacasVehi) & "," & _
    '    csNeg.myStr(ReporteGestionPTRobo_SerieVehi) & "," & _
    '    csNeg.myStr(ReporteGestionInfo_correo) & "," & _
    '    csNeg.myStr(ReporteGestionInfo_Cel) & "," & _
    '    csNeg.myStr(ReporteGestionPTRobo_Descripcion) & "," & _
    '    GestionGeneral_Llama

    '    If csSQLsvr.EjecutarSP(comando, conBaseDatos) = BaseDatosSQL.Estatus.OK Then
    '        update_ReporteGestionGeneral = True
    '    Else
    '        update_ReporteGestionGeneral = False
    '    End If

    '    'Insert_BitacoraCambios(NoGestion, "Se realizaron cambios en los datos de Gestion por Perdida Total", clvUsuario)


    '    Return update_ReporteGestionGeneral
    'End Function





    Public Function buscaDocumentosGestionAsignados(ByVal nogestion As String) As DataSet
        Dim sGestion As String = nogestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Dim comando As String = "select distinct  Tramite_clvTramite,Consec,rfcGestor,TramitesGestion_Descrip,documentos_descrip from  DocumentosSolicitados_gestion2_vw where " & _
        " Reporte_anio=" & p_Anio & " and " & _
        " Reporte_cliente=" & p_Cliente & " and " & _
        " Reporte_Tipo=" & p_tipo & " and " & _
        " Reporte_clvEstado=" & p_estado & " and " & _
        " Reporte_Numero=" & p_consec
        buscaDocumentosGestionAsignados = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        Return buscaDocumentosGestionAsignados

    End Function

    Public Function BuscaAsegOrdas(ByVal aseg As Integer) As Integer
        BuscaAsegOrdas = 0
        Dim comando As String = "select  clv_ordas from   Aseguradoras_Cliente_ordas where  clv_Aseguradora=" & aseg
        Dim ds As New DataSet
        ds = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        Dim rw As DataRow

        For Each rw In ds.Tables(0).Rows
            BuscaAsegOrdas = rw("clv_ordas")
        Next
        ds.Clear()
        Return BuscaAsegOrdas

    End Function

    Public Sub GrabaErrorPoliza(ByVal poliza As String, ByVal mensaje As String)
        Dim comando As String = "insert into Polizas_error_ordas (no_poliza,mensaje) values (" & csNeg.myStr(poliza) & "," & csNeg.myStr(mensaje) & ")"
        csSQLsvr.EjecutarSP(comando, conBaseDatos)
    End Sub

    Public Function buscaDocumentosGestionAsignadosTramite(ByVal nogestion As String, ByVal Tramite_clvTramite As String, ByVal Tramite_cvlSubTramite As String, ByVal Tramite_TipoPersona As String, ByVal Tramite_servVeh As String) As Integer
        Dim sGestion As String = nogestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Dim comando As String = "select distinct  Tramite_clvTramite,Consec,rfcGestor,TramitesGestion_Descrip,documentos_descrip from  DocumentosSolicitados_gestion2_vw where " & _
        " Reporte_anio=" & p_Anio & " and " & _
        " Reporte_cliente=" & p_Cliente & " and " & _
        " Reporte_Tipo=" & p_tipo & " and " & _
        " Reporte_clvEstado=" & p_estado & " and " & _
        " Reporte_Numero=" & p_consec & " and " & _
        " Tramite_clvTramite=" & Tramite_clvTramite & " and " & _
        " Tramite_cvlSubTramite=" & Tramite_cvlSubTramite & " and " & _
        " Tramite_TipoPersona=" & Tramite_TipoPersona & " and " & _
        " Tramite_servVeh=" & Tramite_servVeh
        Dim documenSolicitado As DataSet = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        If documenSolicitado.Tables(0).Rows.Count > 0 Then
            buscaDocumentosGestionAsignadosTramite = 1
        Else
            buscaDocumentosGestionAsignadosTramite = 0
        End If
        documenSolicitado.Clear()

        Return buscaDocumentosGestionAsignadosTramite

    End Function

    Public Function buscaTramitesPendientesAsignar(ByVal nogestion As String) As DataSet
        Dim sGestion As String = nogestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Dim comando As String = "select distinct  Tramite_clvTramite,TramitesGestion_Descrip from ReportesGestionPendientesAsignar_vw where TramitesGestion_Descrip is not null and " & _
        " Reporte_anio=" & p_Anio & " and " & _
        " Reporte_cliente=" & p_Cliente & " and " & _
        " Reporte_Tipo=" & p_tipo & " and " & _
        " Reporte_clvEstado=" & p_estado & " and " & _
        " Reporte_Numero=" & p_consec
        buscaTramitesPendientesAsignar = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        Return buscaTramitesPendientesAsignar

    End Function

    Public Function BuscarTipoVehi(ByVal nogestion As String) As Integer
        Dim sGestion As String = nogestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        BuscarTipoVehi = 0
        Dim comando As String = "select servicio_TipoVehi from Servicios where  Servicio_clvCliente=" & p_Cliente & " and  Servicio_clvTipo=" & p_tipo
        Dim ds As DataSet
        ds = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        If ds.Tables(0).Rows.Count <> 0 Then
            Dim dr As DataRow
            For Each dr In ds.Tables(0).Rows
                If dr("servicio_TipoVehi") <> 0 Then
                    comando = "select  ReporteGestionPT_TipoVehi from ReporteGestionPT where " & _
                    " Reporte_anio=" & p_Anio & " and " & _
                    " Reporte_cliente=" & p_Cliente & " and " & _
                    " Reporte_Tipo=" & p_tipo & " and " & _
                    " Reporte_clvEstado=" & p_estado & " and " & _
                    " Reporte_Numero=" & p_consec
                    Dim ds2 As New DataSet
                    ds2 = csSQLsvr.QueryDataSet(comando, conBaseDatos)
                    Dim dr2 As DataRow
                    For Each dr2 In ds2.Tables(0).Rows
                        BuscarTipoVehi = dr2("ReporteGestionPT_TipoVehi")
                    Next
                    ds2.Clear()

                Else
                    BuscarTipoVehi = 0
                End If
            Next
            ds.Clear()
        End If

        Return BuscarTipoVehi

    End Function

    Public Function CerrarGestionCC(ByVal noGestion As String, ByVal sUsuario As String, ByVal sIdentificacion As String) As Boolean
        Dim sGestion As String = noGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Dim comando As String = "exec insert_GestionCierreContactoCliente  " & _
        p_Anio & "," & _
        p_Cliente & "," & _
        p_tipo & "," & _
        p_estado & "," & _
        p_consec & "," & _
        csNeg.myStr(sIdentificacion) & "," & _
        csNeg.myStr(sUsuario)
        If csSQLsvr.EjecutarSP(comando, conBaseDatos) = BaseDatosSQL.Estatus.OK Then
            CerrarGestionCC = True
        Else
            CerrarGestionCC = False
        End If
    End Function

    Public Function ChecaDocSolicitados(ByVal noGestion As String) As String

        Dim comando As String = "select NoGestion from   ResportesGestionTotal_vw where nogestion not in (select nogestion from DocumentosSolicitados_gestion_vw where nogestion='" & noGestion & "')"
        Dim ds As New DataSet
        ds = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        Dim cuenta As Integer = ds.Tables(0).Rows.Count



        If cuenta = 0 Then
            ChecaDocSolicitados = "NO"
        Else
            ChecaDocSolicitados = "SI"
        End If
        ds.Clear()
        ds.Dispose()
        Return ChecaDocSolicitados
    End Function

    Public Function ChecaDocSolicitadosEntregados(ByVal noGestion As String) As String

        Dim comando As String = "select nogestion, Tramite_clvTramite, Tramite_cvlSubTramite from DocumentosSolicitados_gestion_vw where nogestion=" & csNeg.myStr(noGestion)
        Dim ds As New DataSet
        ds = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        Dim cuentaIni As Integer = ds.Tables(0).Rows.Count
        comando = "select nogestion, Tramite_clvTramite, Tramite_cvlSubTramite from DocumentosSolicitados_gestion_vw where chkEntregado=1 and  nogestion=" & csNeg.myStr(noGestion)
        ds.Clear()
        ds = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        Dim cuentaFin As Integer = ds.Tables(0).Rows.Count
        If cuentaIni = 0 Or cuentaFin = 0 Then
            ChecaDocSolicitadosEntregados = "NO"
        Else
            If cuentaIni <> cuentaFin Then
                ChecaDocSolicitadosEntregados = "NO"
            Else
                ChecaDocSolicitadosEntregados = "SI"

            End If
        End If

        ds.Clear()
        ds.Dispose()
        Return ChecaDocSolicitadosEntregados

    End Function

    Public Function ChecaDocSEntregadosDigitalizados(ByVal noGestion As String) As String

        Dim comando As String = "select nogestion, Tramite_clvTramite, Tramite_cvlSubTramite from DocumentosSolicitados_gestion_vw where chkEntregado=1 and  nogestion=" & csNeg.myStr(noGestion)
        Dim ds As New DataSet
        ds = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        Dim cuentaIni As Integer = ds.Tables(0).Rows.Count
        comando = "select nogestion, Tramite_clvTramite, Tramite_cvlSubTramite from DocumentosDigitalizadosGestion_vw where   nogestion=" & csNeg.myStr(noGestion)
        ds.Clear()
        ds = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        Dim cuentaFin As Integer = ds.Tables(0).Rows.Count
        If cuentaIni = 0 Or cuentaFin = 0 Then
            ChecaDocSEntregadosDigitalizados = "NO"
        Else
            If cuentaIni <> cuentaFin Then
                ChecaDocSEntregadosDigitalizados = "NO"
            Else
                ChecaDocSEntregadosDigitalizados = "SI"

            End If
        End If


        ds.Clear()
        ds.Dispose()
        Return ChecaDocSEntregadosDigitalizados

    End Function

    Public Function ChecaDocSolicitadosVerificados(ByVal noGestion As String) As String

        Dim comando As String = "select nogestion, Tramite_clvTramite, Tramite_cvlSubTramite from DocumentosSolicitados_gestion_vw where nogestion=" & csNeg.myStr(noGestion)
        Dim ds As New DataSet
        ds = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        Dim cuentaIni As Integer = ds.Tables(0).Rows.Count
        comando = "select nogestion, Tramite_clvTramite, Tramite_cvlSubTramite from DocumentosSolicitados_gestion_vw where chkEntregado=1 and chkAutentiificado=1 and  nogestion=" & csNeg.myStr(noGestion)
        ds.Clear()
        ds = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        Dim cuentaFin As Integer = ds.Tables(0).Rows.Count

        If cuentaIni = 0 Or cuentaFin = 0 Then
            ChecaDocSolicitadosVerificados = "NO"
        Else

            If cuentaIni <> cuentaFin Then
                ChecaDocSolicitadosVerificados = "NO"
            Else
                ChecaDocSolicitadosVerificados = "SI"

            End If
        End If

        ds.Clear()
        ds.Dispose()
        Return ChecaDocSolicitadosVerificados

    End Function

    Public Function ChecaDocEntregadosGestor(ByVal noGestion As String) As String

        Dim comando As String = "select nogestion, Tramite_clvTramite, Tramite_cvlSubTramite from DocumentosSolicitados_gestion_vw where nogestion=" & csNeg.myStr(noGestion)
        Dim ds As New DataSet
        ds = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        Dim cuentaIni As Integer = ds.Tables(0).Rows.Count
        comando = "select nogestion, Tramite_clvTramite, Tramite_cvlSubTramite from DocumentosSolicitados_gestion_vw where chkEntregado=1 and chkAutentiificado=1 and chkEntregado =1 and  nogestion=" & csNeg.myStr(noGestion)
        ds.Clear()
        ds = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        Dim cuentaFin As Integer = ds.Tables(0).Rows.Count
        If cuentaIni = 0 Or cuentaFin = 0 Then
            ChecaDocEntregadosGestor = "NO"
        Else
            If cuentaIni <> cuentaFin Then
                ChecaDocEntregadosGestor = "NO"
            Else
                ChecaDocEntregadosGestor = "SI"

            End If
        End If

        ds.Clear()
        ds.Dispose()
        Return ChecaDocEntregadosGestor

    End Function

    Public Function ChecaDocEntregadosCliente(ByVal noGestion As String) As String

        Dim comando As String = "select nogestion, Tramite_clvTramite, Tramite_cvlSubTramite from DocumentosSolicitados_gestion_vw where nogestion=" & csNeg.myStr(noGestion)
        Dim ds As New DataSet
        ds = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        Dim cuentaIni As Integer = ds.Tables(0).Rows.Count
        comando = "select nogestion, Tramite_clvTramite, Tramite_cvlSubTramite from DocumentosSolicitados_gestion_vw where chkEntregado=1 and chkAutentiificado=1 and chkEntregado =1 and fechaEntregaCliente<>'01/01/1900' and nogestion=" & csNeg.myStr(noGestion)
        ds.Clear()
        ds = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        Dim cuentaFin As Integer = ds.Tables(0).Rows.Count
        If cuentaIni = 0 Or cuentaFin = 0 Then
            ChecaDocEntregadosCliente = "NO"
        Else
            If cuentaIni <> cuentaFin Then
                ChecaDocEntregadosCliente = "NO"
            Else
                ChecaDocEntregadosCliente = "SI"
            End If

        End If



        ds.Clear()
        ds.Dispose()
        Return ChecaDocEntregadosCliente

    End Function

    Public Function AsignarGestor(ByVal noGestion As String, ByVal rfcGestor As String, ByVal clv_tramite As Integer, ByVal consecDoc As Integer) As Boolean

        Dim sGestion As String = noGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Dim comando As String = String.Empty
        If consecDoc = 0 Then
            comando = "update CheckListDocumentosExpedienteGestion set   RFCGestor = " & csNeg.myStr(rfcGestor) & " ,HRAVISO=getdate() where  " & _
            " Reporte_anio=" & p_Anio & " and " & _
            " Reporte_cliente=" & p_Cliente & " and " & _
            " Reporte_Tipo=" & p_tipo & " and " & _
            " Reporte_clvEstado=" & p_estado & " and " & _
            " Reporte_Numero=" & p_consec & " and   Tramite_clvTramite=" & clv_tramite
        End If

        If consecDoc <> 0 Then
            comando = "update CheckListDocumentosExpedienteGestion set   RFCGestor = " & csNeg.myStr(rfcGestor) & " ,HRAVISO=getdate() where  " & _
            " Reporte_anio=" & p_Anio & " and " & _
            " Reporte_cliente=" & p_Cliente & " and " & _
            " Reporte_Tipo=" & p_tipo & " and " & _
            " Reporte_clvEstado=" & p_estado & " and " & _
            " Reporte_Numero=" & p_consec & " and   Tramite_clvTramite=" & clv_tramite & " and   consec=" & consecDoc
        End If

        'Dim comando As String = "update ReporteGestion set   RFC_Gestor = " & csNeg.myStr(rfcGestor) & " ,HRAVISO_Gestor=getdate() where  " & _

        If csSQLsvr.EjecutarSP(comando, conBaseDatos) = BaseDatosSQL.Estatus.OK Then
            AsignarGestor = True
        Else
            AsignarGestor = False
        End If

        Return AsignarGestor

    End Function

    Public Function CargaExpedientesGestionControl(Optional ByVal noControl As Double = 0) As DataSet

        Dim comando As String = String.Empty
        If noControl <> 0 Then
            Dim nControl As Double = noControl
            Dim nLargo As Integer = Len(nControl)
            Dim pAnio As String = Mid(nControl, 1, 4)
            Dim pConsec As String = Mid(nControl, 5, nLargo)
            comando = "select * from   ResportesGestionTotal2_vw where Reporte_anio = '" & pAnio & "' and Reporte_Numero = '" & pConsec & "'"
        End If

        CargaExpedientesGestionControl = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        Return CargaExpedientesGestionControl
    End Function
    Public Function CargaExpedientesGestion(ByVal fecha1 As String, ByVal fecha2 As String, Optional ByVal aseg As Integer = 0, Optional ByVal estado As Integer = 0, Optional ByVal status As Integer = 100, Optional ByVal noControl As Double = 0) As DataSet

        Dim comando As String = String.Empty
        Dim filtroTotal As String = String.Empty
        Dim filtro1 As String = String.Empty
        Dim filtro2 As String = String.Empty
        Dim filtro3 As String = String.Empty


        comando = "select * from   ResportesGestionTotal2_vw where     Reporte_FechaRepor>=" & csNeg.myStr(fecha1) & " and Reporte_FechaRepor<= " & csNeg.myStr(fecha2)

        If aseg <> 0 Then
            filtro1 = " and Reporte_cliente=" & aseg
        End If

        If estado <> 0 Then
            filtro2 = " and  Reporte_clvEstado=" & estado
        End If

        If status <> 100 Then
            filtro3 = " and   Reporte_status=" & status
        End If

        filtroTotal = filtro1 & filtro2 & filtro3
        comando = comando & filtroTotal



        If noControl <> 0 Then
            Dim nControl As Double = noControl
            Dim nLargo As Integer = Len(nControl)
            Dim pAnio As String = Mid(nControl, 1, 4)
            Dim pConsec As String = Mid(nControl, 5, nLargo)
            comando = "select * from   ResportesGestionTotal2_vw where Reporte_anio = '" & pAnio & "' and Reporte_Numero = '" & pConsec & "'"
        End If

        CargaExpedientesGestion = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        Return CargaExpedientesGestion
    End Function

    Public Function buscaGestorAsignado(ByVal rfcgestor As String) As String
        Dim comando As String = "SELECT  distinct      rtrim( NOMBRE) + rtrim( MATERNO) +rtrim( PATERNO) as Gestor FROM         Ajustadores2 where rfcAjustador =" & csNeg.myStr(rfcgestor)
        buscaGestorAsignado = String.Empty
        Dim ds As New DataSet
        If rfcgestor <> String.Empty Then
            ds = csSQLsvr.QueryDataSet(comando, conBaseDatos)
            Dim dr As DataRow
            For Each dr In ds.Tables(0).Rows
                buscaGestorAsignado = dr("Gestor")
            Next
        End If
        ds.Clear()
        Return buscaGestorAsignado


    End Function

    Public Function buscaGestores(Optional ByVal estado As Integer = 0, Optional ByVal mpio As Integer = 0, Optional ByVal fechaIni As String = "", Optional ByVal fechaFIn As String = "") As DataSet

        Dim comando As String = String.Empty
        If estado = 0 And mpio = 0 Then
            comando = "exec GestoresXestadoparaTodos_sp  "
            buscaGestores = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        Else
            If fechaIni <> "" And fechaFIn <> "" And mpio = 0 Then
                buscaGestores = GestorProgramado(fechaIni, fechaFIn, estado)
            ElseIf estado <> 0 And mpio <> 0 Then
                comando = "exec GestoresXmpio" & " " & estado & "," & mpio
                buscaGestores = csSQLsvr.QueryDataSet(comando, conBaseDatos)
            Else
                comando = "exec GestoresXestadoNew_sp" & " " & estado
                buscaGestores = csSQLsvr.QueryDataSet(comando, conBaseDatos)
            End If
        End If


        Return buscaGestores
    End Function
    Public Function buscaAsuntosSinAsignar(Optional ByVal Aseguradora As Integer = 0, Optional ByVal estado As Integer = 0) As DataSet
        Dim comando As String = String.Empty

        If estado = 0 And Aseguradora = 0 Then
            comando = "select distinct NoGestion,cliente_NomCliente,Estado,Mpio,asegurado,Servicio_NomServicio  from ReportesGestionPendientesAsignar_vw"
        End If
        If estado <> 0 And Aseguradora = 0 Then
            comando = "select distinct NoGestion,cliente_NomCliente,Estado,Mpio,asegurado,Servicio_NomServicio  from ReportesGestionPendientesAsignar_vw where  Reporte_clvEstado=" & estado
        End If

        If estado = 0 And Aseguradora <> 0 Then
            comando = "select distinct NoGestion,cliente_NomCliente,Estado,Mpio,asegurado,Servicio_NomServicio  from ReportesGestionPendientesAsignar_vw where   Reporte_cliente=" & Aseguradora
        End If

        If estado <> 0 And Aseguradora <> 0 Then
            comando = "select distinct NoGestion,cliente_NomCliente,Estado,Mpio,asegurado,Servicio_NomServicio  from ReportesGestionPendientesAsignar_vw where   Reporte_cliente=" & Aseguradora & " and Reporte_clvEstado=" & estado
        End If
        buscaAsuntosSinAsignar = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        Return buscaAsuntosSinAsignar

    End Function

    Public Function RevisaRegImagenes(ByVal nogestion As String, ByVal clvTramite As Integer, ByVal clvSubtramite As Integer) As Integer
        Dim sGestion As String = nogestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Dim comando As String = "exec Select_DocumentosDigitalizadosXtramite  " & _
        p_Anio & "," & _
        p_Cliente & "," & _
        p_tipo & "," & _
        p_estado & "," & _
        p_consec & "," & _
        clvTramite & "," & _
        clvSubtramite
        Dim ds As New DataSet
        ds = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        RevisaRegImagenes = ds.Tables(0).Rows.Count
        ds.Clear()
        Return RevisaRegImagenes
    End Function

    Public Function TipoTramite(ByVal clvTramite As Integer, ByVal clvSubtramite As Integer, ByVal Tramite_TipoPersona As Integer, ByVal Tramite_servVeh As Integer) As String
        TipoTramite = String.Empty
        ' Dim comando As String = "SELECT DISTINCT Tramite_Descripcion FROM TramitesXEstadoGestion where  Tramite_clvTramite=" & clvTramite & " and  Tramite_cvlSubTramite=" & clvSubtramite
        Dim comando As String = "SELECT DISTINCT TramitesGestion_Descrip,documentos_descrip FROM   DocumentosSolicitados_gestion2_vw where  Tramite_clvTramite=" & clvTramite & " and  Tramite_cvlSubTramite=" & clvSubtramite & " and Tramite_TipoPersona=" & Tramite_TipoPersona & " and Tramite_servVeh=" & Tramite_servVeh
        Dim ds As New DataSet
        ds = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        Dim dr As DataRow
        For Each dr In ds.Tables(0).Rows
            TipoTramite = "TIPO DE TRAMITE:" & vbCrLf & vbCrLf & dr("TramitesGestion_Descrip") & vbCrLf & vbCrLf & " DOCUMENTO:" & vbCrLf & vbCrLf & dr("documentos_descrip")
        Next
        ds.Clear()
        ds.Dispose()
        Return TipoTramite
    End Function

    Public Function BuscaListaDocumentos(ByVal TipoServicio As Integer, ByVal clvCliente As Integer) As DataSet
        Dim ds As New DataSet
        Dim comando As String = "exec Select_TramiteServiciosGestion " & TipoServicio & "," & clvCliente
        ds = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        BuscaListaDocumentos = ds
        Return BuscaListaDocumentos
    End Function

    Public Function DocumentosExpedienteGestionRechazados(ByVal noGestion As String, ByVal Tramite_Descripcion As String, ByVal Tramite_Documento As String, ByVal usuario_rechaza As String, ByVal comen_Rechazo As String) As Boolean

        Dim sGestion As String = noGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Dim comando As String = "exec insert_DocumentosExpedienteGestionRechazados  " & _
        p_Anio & "," & _
        p_Cliente & "," & _
        p_tipo & "," & _
        p_estado & "," & _
        p_consec & "," & _
        csNeg.myStr(Tramite_Descripcion) & "," & _
        csNeg.myStr(Tramite_Documento) & "," & _
        csNeg.myStr(usuario_rechaza) & "," & _
        csNeg.myStr(comen_Rechazo)
        If csSQLsvr.EjecutarSP(comando, conBaseDatos) = BaseDatosSQL.Estatus.OK Then
            DocumentosExpedienteGestionRechazados = True
        Else
            DocumentosExpedienteGestionRechazados = False
        End If

        Return DocumentosExpedienteGestionRechazados

    End Function

    Public Function DocumentosExpedienteGestionAceptados(ByVal noGestion As String, ByVal Tramite_clvTramite As Integer, ByVal Tramite_cvlSubTramite As Integer, ByVal fechaAcepta As String, ByVal usuarioAcepta As String, ByVal comentarios As String, ByVal consecDoc As Integer) As Boolean

        Dim sGestion As String = noGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Dim comando As String = "update CheckListDocumentosExpedienteGestion set chkEntregado=1 , FechaChkEntregado= " & csNeg.myStr(fechaAcepta) & ", fechaCapturaChkEntregado=getdate(),comen_chkEntregado=" & csNeg.myStr(comentarios) & ",fk_usuario_chkEntregado=  " & csNeg.myStr(usuarioAcepta) & " where  " & _
        " Reporte_anio=" & p_Anio & " and " & _
        " Reporte_cliente=" & p_Cliente & " and " & _
        " Reporte_Tipo=" & p_tipo & " and " & _
        " Reporte_clvEstado=" & p_estado & " and " & _
        " Reporte_Numero=" & p_consec & " and " & _
        " Tramite_clvTramite=" & Tramite_clvTramite & " and " & _
        " Tramite_cvlSubTramite=" & Tramite_cvlSubTramite & " and " & _
        " consec =" & consecDoc

        If csSQLsvr.EjecutarSP(comando, conBaseDatos) = BaseDatosSQL.Estatus.OK Then
            DocumentosExpedienteGestionAceptados = True
        Else
            DocumentosExpedienteGestionAceptados = False
        End If

        Return DocumentosExpedienteGestionAceptados

    End Function

    Public Function DocumentosEntregadosGestor(ByVal noGestion As String, ByVal Tramite_clvTramite As Integer, ByVal Tramite_cvlSubTramite As Integer, ByVal fechaAcepta As String, ByVal usuarioAcepta As String, ByVal comentarios As String, ByVal tipoEntrega As Integer, ByVal consecImg As Integer) As Boolean

        Dim sGestion As String = noGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Dim comando As String = "update CheckListDocumentosExpedienteGestion set chkAutentiificado=1 , fechaChkAutententificado= " & csNeg.myStr(fechaAcepta) & ", fechaCapturaChkAutentificado=getdate(), comen_chkAutentificado=" & csNeg.myStr(comentarios) & ", fk_usuario_chkAutenti=  " & csNeg.myStr(usuarioAcepta) & ",TipoEntrega=" & tipoEntrega & " where  " & _
        " Reporte_anio=" & p_Anio & " and " & _
        " Reporte_cliente=" & p_Cliente & " and " & _
        " Reporte_Tipo=" & p_tipo & " and " & _
        " Reporte_clvEstado=" & p_estado & " and " & _
        " Reporte_Numero=" & p_consec & " and " & _
        " Tramite_clvTramite=" & Tramite_clvTramite & " and " & _
        " Tramite_cvlSubTramite=" & Tramite_cvlSubTramite & " and consec=" & consecImg

        If csSQLsvr.EjecutarSP(comando, conBaseDatos) = BaseDatosSQL.Estatus.OK Then
            DocumentosEntregadosGestor = True
        Else
            DocumentosEntregadosGestor = False
        End If

        Return DocumentosEntregadosGestor

    End Function

    Public Function DocumentosEntregadosCliente(ByVal noGestion As String, ByVal Tramite_clvTramite As Integer, ByVal Tramite_cvlSubTramite As Integer, ByVal fechaAcepta As String, ByVal usuarioAcepta As String, ByVal comentarios As String, ByVal tipoEntrega As Integer) As Boolean

        Dim sGestion As String = noGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Dim comando As String = "update CheckListDocumentosExpedienteGestion set  fechaEntregaCliente= " & csNeg.myStr(fechaAcepta) & ", fechaCapturaEntreCliente=getdate(), comen_entreCliente=" & csNeg.myStr(comentarios) & ", fk_usuario_EntreCliente=  " & csNeg.myStr(usuarioAcepta) & ",TipoEntregaCliente=" & tipoEntrega & " where  " & _
        " Reporte_anio=" & p_Anio & " and " & _
        " Reporte_cliente=" & p_Cliente & " and " & _
        " Reporte_Tipo=" & p_tipo & " and " & _
        " Reporte_clvEstado=" & p_estado & " and " & _
        " Reporte_Numero=" & p_consec & " and " & _
        " Tramite_clvTramite=" & Tramite_clvTramite & " and " & _
        " Tramite_cvlSubTramite=" & Tramite_cvlSubTramite

        If csSQLsvr.EjecutarSP(comando, conBaseDatos) = BaseDatosSQL.Estatus.OK Then
            DocumentosEntregadosCliente = True
        Else
            DocumentosEntregadosCliente = False
        End If

        Return DocumentosEntregadosCliente

    End Function

    Public Function DocumentosSolicitados(ByVal noGestion As String) As DataSet

        Dim sGestion As String = noGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo) 'DocumentosSolicitados_gestion2_vw
        Dim comando As String = "select * from   DocumentosSolicitados_gestioBO_vw where chkEntregado=1 and " & _
        " Reporte_anio=" & p_Anio & " and " & _
        "Reporte_cliente=" & p_Cliente & " and " & _
        " Reporte_Tipo=" & p_tipo & " and " & _
        "Reporte_clvEstado=" & p_estado & " and " & _
        " Reporte_Numero=" & p_consec
        DocumentosSolicitados = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        Return DocumentosSolicitados

    End Function

    Public Function DocumentosEntregadosGestor(ByVal noGestion As String) As DataSet

        Dim sGestion As String = noGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Dim comando As String = "select * from   DocumentosSolicitados_gestion_vw where chkAutentiificado=1  and " & _
        " Reporte_anio=" & p_Anio & " and " & _
        "Reporte_cliente=" & p_Cliente & " and " & _
        " Reporte_Tipo=" & p_tipo & " and " & _
        "Reporte_clvEstado=" & p_estado & " and " & _
        " Reporte_Numero=" & p_consec
        DocumentosEntregadosGestor = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        Return DocumentosEntregadosGestor

    End Function

    Public Function DocumentosEntregadosCliente(ByVal noGestion As String) As DataSet

        Dim sGestion As String = noGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Dim comando As String = "select * from   DocumentosSolicitados_gestion_vw where chkAutentiificado=1   and fechaEntregaCliente='01/01/1900'  and " & _
        " Reporte_anio=" & p_Anio & " and " & _
        "Reporte_cliente=" & p_Cliente & " and " & _
        " Reporte_Tipo=" & p_tipo & " and " & _
        "Reporte_clvEstado=" & p_estado & " and " & _
        " Reporte_Numero=" & p_consec
        DocumentosEntregadosCliente = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        Return DocumentosEntregadosCliente

    End Function

    Public Function ChecarDocumentosSolicitados(ByVal noGestion As String) As DataSet

        Dim sGestion As String = noGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Dim comando As String = "exec Select_CheckListDocumentosExpedienteGestion  " & _
        p_Anio & "," & _
        p_Cliente & "," & _
        p_tipo & "," & _
        p_estado & "," & _
        p_consec
        ChecarDocumentosSolicitados = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        Return ChecarDocumentosSolicitados

    End Function

    Public Function revisarDocumentos(ByVal noGestion As String) As DataSet

        Dim sGestion As String = noGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Dim comando As String = "exec Select_CheckListDocumentosExpedienteGestionVista2  " & _
        p_Anio & "," & _
        p_Cliente & "," & _
        p_tipo & "," & _
        p_estado & "," & _
        p_consec
        revisarDocumentos = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        Return revisarDocumentos

    End Function

    Public Function revisarDocumentosPendientesRecepcion(ByVal noGestion As String) As DataSet

        Dim sGestion As String = noGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Dim comando As String = "exec Select_CheckListDocumentosGestionPendientesEntregar2  " & _
        p_Anio & "," & _
        p_Cliente & "," & _
        p_tipo & "," & _
        p_estado & "," & _
        p_consec
        revisarDocumentosPendientesRecepcion = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        Return revisarDocumentosPendientesRecepcion

    End Function

    Public Function revisarDocumentosPendientesEntregaGestor(ByVal noGestion As String) As DataSet

        Dim sGestion As String = noGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Dim comando As String = "select * from  DocumentosSolicitados_gestion2_vw where chkAutentiificado=0 and " & _
        " Reporte_anio=" & p_Anio & " and " & _
        "Reporte_cliente=" & p_Cliente & " and " & _
        " Reporte_Tipo=" & p_tipo & " and " & _
        "Reporte_clvEstado=" & p_estado & " and " & _
        " Reporte_Numero=" & p_consec
        revisarDocumentosPendientesEntregaGestor = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        Return revisarDocumentosPendientesEntregaGestor

    End Function

    Public Function revisarDocumentosPendientesEntregaCliente(ByVal noGestion As String) As DataSet

        Dim sGestion As String = noGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Dim comando As String = "select * from  DocumentosSolicitados_gestion_vw where chkAutentiificado=1 and fechaEntregaCliente='01/01/1900' and " & _
        " Reporte_anio=" & p_Anio & " and " & _
        "Reporte_cliente=" & p_Cliente & " and " & _
        " Reporte_Tipo=" & p_tipo & " and " & _
        "Reporte_clvEstado=" & p_estado & " and " & _
        " Reporte_Numero=" & p_consec
        revisarDocumentosPendientesEntregaCliente = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        Return revisarDocumentosPendientesEntregaCliente

    End Function

    Public Function Insert_GestionContacto(ByVal NoGestion As String, ByVal GestionContacto_ApePat As String, _
    ByVal GestionContacto_ApeMat As String, ByVal GestionContacto_Nombre As String, ByVal GestionContacto_Lada As String, ByVal GestionContacto_Telefono As String, ByVal GestionContacto_Observaciones As String, _
    ByVal GestionContacto_UsrCambio As String) As Boolean
        Dim sGestion As String = NoGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Dim comando As String = "exec insert_GestionContacto  " & _
        p_Anio & "," & _
        p_Cliente & "," & _
        p_tipo & "," & _
        p_estado & "," & _
        p_consec & "," & _
        csNeg.myStr(GestionContacto_ApePat) & "," & _
        csNeg.myStr(GestionContacto_ApeMat) & "," & _
        csNeg.myStr(GestionContacto_Nombre) & "," & _
        csNeg.myStr(GestionContacto_Lada) & "," & _
        csNeg.myStr(GestionContacto_Telefono) & "," & _
        csNeg.myStr(GestionContacto_Observaciones) & "," & _
        csNeg.myStr(GestionContacto_UsrCambio)
        If csSQLsvr.EjecutarSP(comando, conBaseDatos) = BaseDatosSQL.Estatus.OK Then
            Insert_GestionContacto = True
        Else
            Insert_GestionContacto = False
        End If
        Insert_BitacoraCambios(NoGestion, "Se realizaron cambios en los datos de Gestion datos del Contacto", GestionContacto_UsrCambio)
        Return Insert_GestionContacto




    End Function

    Public Function GuardarEntregaAseguradora(ByVal NoGestion As String, ByVal registro As String, ByVal alta As String, ByVal estatus As Integer, ByVal Usuario As String) As Boolean
        Dim sGestion As String = NoGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Dim comando As String = "exec InsertDeliveryDate_sp " & _
        p_Anio & "," & _
        p_Cliente & "," & _
        p_tipo & "," & _
        p_estado & "," & _
        p_consec & ",'" & _
        registro & "','" & _
        alta & "'," & _
        estatus & ", '" & _
        Usuario & "'"

        If csSQLsvr.EjecutarSP(comando, conBaseDatos) = BaseDatosSQL.Estatus.OK Then
            GuardarEntregaAseguradora = True
        Else
            GuardarEntregaAseguradora = False
        End If
        Return GuardarEntregaAseguradora


    End Function

    Public Function ValidaEntrega(ByVal NoGestion As String) As Integer
        Dim sGestion As String = NoGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Dim comando As String = "exec ValidarEntrega_sp " & _
        p_Anio & "," & _
        p_Cliente & "," & _
        p_tipo & "," & _
        p_estado & "," & _
        p_consec

        Dim ds As New DataSet
        ds = csSQLsvr.QueryDataSet(comando, conBaseDatos)

        Dim Cuenta As Integer = ds.Tables.Item(0).Rows.Count

        If Cuenta <> 0 Then
            ValidaEntrega = ds.Tables(0).Rows(0).Item(0)
        Else
            ValidaEntrega = 1
        End If
        Return ValidaEntrega
    End Function

    Public Function ValidaChkAutentificado(ByVal nogestion As String, ByVal Tramite_clvTramite As String, _
    ByVal Tramite_cvlSubTramite As String, ByVal Tramite_TipoPersona As String, _
    ByVal Tramite_servVeh As String, ByVal chkAutentifica As Integer) As Integer
        Dim sGestion As String = nogestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Dim comando As String = "exec select_chkAutenficathed " & _
        p_Anio & "," & _
        p_Cliente & "," & _
        p_tipo & "," & _
        p_estado & "," & _
        p_consec & "," & _
        Tramite_clvTramite & "," & _
        Tramite_cvlSubTramite & "," & _
        Tramite_TipoPersona & "," & _
        Tramite_servVeh & "," & _
        chkAutentifica

        If csSQLsvr.QueryDataSet(comando, conBaseDatos).Tables.Item(0).Rows.Count <> 0 Then
            ValidaChkAutentificado = csSQLsvr.QueryDataSet(comando, conBaseDatos).Tables(0).Rows(0).Item(0)
        Else
            ValidaChkAutentificado = False
        End If
        Return ValidaChkAutentificado
    End Function

    Public Function InsertaHistoricaRechazo(ByVal NoGestion As String, ByVal Observacion As String, ByVal Usuario As String) As Boolean
        Dim sGestion As String = NoGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Dim comando As String = "exec InserthistoricRejection_sp " & _
        p_Anio & "," & _
        p_Cliente & "," & _
        p_tipo & "," & _
        p_estado & "," & _
        p_consec & ", '" & _
        Observacion.Trim & "', '" & _
        Usuario.Trim & "'"



        If csSQLsvr.EjecutarSP(comando, conBaseDatos) = BaseDatosSQL.Estatus.OK Then
            InsertaHistoricaRechazo = True
        Else
            InsertaHistoricaRechazo = False
        End If
        Return InsertaHistoricaRechazo
    End Function

    Public Function InsertValidaImagenHistorico(ByVal NoGestion As String, ByVal clvTramite As Integer, ByVal clvSubtramite As Integer, ByVal Observacion As String, ByVal Usuario As String, ByVal chkAutentificado As Integer) As Boolean
        Dim sGestion As String = NoGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Dim comando As String = "exec chkAutentify_sp  " & _
        p_Anio & "," & _
        p_Cliente & "," & _
        p_tipo & "," & _
        p_estado & "," & _
        p_consec & "," & _
        clvTramite & "," & _
        clvSubtramite & ", " & _
        Usuario.Trim & ",'" & _
        Observacion.Trim & "'," & chkAutentificado & ""

        If csSQLsvr.EjecutarSP(comando, conBaseDatos) = BaseDatosSQL.Estatus.OK Then
            InsertValidaImagenHistorico = True
        Else
            InsertValidaImagenHistorico = False
        End If
        Return InsertValidaImagenHistorico
    End Function

    Public Function ValidaImagenHistorico(ByVal NoGestion As String) As DataSet
        Dim sGestion As String = NoGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Dim comando As String = "exec ValidHistoricalImage_sp " & _
        p_Anio & "," & _
        p_Cliente & "," & _
        p_tipo & "," & _
        p_estado & "," & _
        p_consec

        ValidaImagenHistorico = csSQLsvr.QueryDataSet(comando, conBaseDatos)

        Return ValidaImagenHistorico
    End Function


    Public Function InicioSesion(ByVal usua As String, ByVal pass As String) As DataSet
        'InicioSesion = String.Empty
        Dim ds As New DataSet

        Dim comando As String = "select id_sesion, nivel_sesion, Cliente from Inicio_Sesion where Usuario_Sesion = '" & usua & "' and Passwword_Sesion = '" & pass & "'"
        ds = csSQLsvr.QueryDataSet(comando, conBaseDatos)

        Return ds
        ds.Clear()
    End Function

    Public Function HistoricaRechazo(ByVal NoGestion As String) As DataSet
        Dim sGestion As String = NoGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Dim comando As String = "exec historicRejection_sp " & _
        p_Anio & "," & _
        p_Cliente & "," & _
        p_tipo & "," & _
        p_estado & "," & _
        p_consec

        HistoricaRechazo = csSQLsvr.QueryDataSet(comando, conBaseDatos)

        Return HistoricaRechazo
    End Function

    Public Function GuardaDocumentosSolicitado(ByVal NoGestion As String, ByVal Tramite_clvTramite As Integer, ByVal Tramite_cvlSubTramite As Integer, ByVal fechachkSolicitado As String, ByVal fk_usuario_chkSolicitado As String, ByVal Tramite_TipoPersona As Integer, ByVal Tramite_servVeh As Integer) As Boolean
        Dim sGestion As String = NoGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Dim comando As String = "exec insert_CheckListDocumentosExpedienteGestion " & _
        p_Anio & "," & _
        p_Cliente & "," & _
        p_tipo & "," & _
        p_estado & "," & _
        p_consec & "," & _
        Tramite_clvTramite & "," & _
        Tramite_cvlSubTramite & ", '" & _
        fechachkSolicitado & "'," & _
        csNeg.myStr(fk_usuario_chkSolicitado) & "," & _
        Tramite_TipoPersona & "," & _
        Tramite_servVeh
        If csSQLsvr.EjecutarSP(comando, conBaseDatos) = BaseDatosSQL.Estatus.OK Then
            GuardaDocumentosSolicitado = True
        Else
            GuardaDocumentosSolicitado = False
        End If
        Return GuardaDocumentosSolicitado
    End Function

    Public Function update_ReporteGestionPT(ByVal NoGestion As String, ByVal ReporteGestionPT_NoSiniestro As String, _
    ByVal ReporteGestionPT_MarcaVehi As String, ByVal ReporteGestionPT_SubMarcaVehi As String, ByVal ReporteGestionPT_SubMarcaVehi2 As String, _
    ByVal ReporteGestionPT_ModeloVehi As String, ByVal ReporteGestionPT_ColorVehi As String, ByVal ReporteGestionPT_SerieVehi As String, ByVal ReporteGestionPT_PlacasVehi As String, ByVal ReporteGestionPT_Llama As String, ByVal ReporteGestionPT_NoReporte As String, ByVal clvUsuario As String, ByVal reporte_medio As Integer) As Boolean
        Dim sGestion As String = NoGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Dim comando As String = "exec update_ReporteGestionPT " & _
        p_Anio & "," & _
        p_Cliente & "," & _
        p_tipo & "," & _
        p_estado & "," & _
        p_consec & "," & _
        csNeg.myStr(ReporteGestionPT_NoSiniestro) & "," & _
        csNeg.myStr(ReporteGestionPT_MarcaVehi) & "," & _
        csNeg.myStr(ReporteGestionPT_SubMarcaVehi) & "," & _
        csNeg.myStr(ReporteGestionPT_SubMarcaVehi2) & "," & _
        csNeg.myStr(ReporteGestionPT_ModeloVehi) & "," & _
        csNeg.myStr(ReporteGestionPT_ColorVehi) & "," & _
        csNeg.myStr(ReporteGestionPT_SerieVehi) & "," & _
        csNeg.myStr(ReporteGestionPT_PlacasVehi) & "," & _
        csNeg.myStr(ReporteGestionPT_Llama) & "," & _
        csNeg.myStr(ReporteGestionPT_NoReporte) & "," & _
        reporte_medio
        If csSQLsvr.EjecutarSP(comando, conBaseDatos) = BaseDatosSQL.Estatus.OK Then
            update_ReporteGestionPT = True
        Else
            update_ReporteGestionPT = False
        End If

        Insert_BitacoraCambios(NoGestion, "Se realizaron cambios en los datos de Gestion por Perdida Total", clvUsuario)


        Return update_ReporteGestionPT
    End Function

    Public Function update_ReporteGestionPTxRobo(ByVal NoGestion As String, ByVal ReporteGestionPTRobo_NoSiniestro As String, ByVal ReporteGestionPTRobo_NoReporte As String, ByVal ReporteGestionPTRobo_NoAveriguacion As String, ByVal ReporteGestionPTRobo_FechaAverigua As String, ByVal ReporteGestionPTRobo_MarcaVehi As String, ByVal ReporteGestionPTRobo_SubMarcaVehi As String, ByVal ReporteGestionPTRobo_SubMarcaVehi2 As String, ByVal ReporteGestionPTRobo_ModeloVehi As String, ByVal ReporteGestionPTRobo_ColorVehi As String, ByVal ReporteGestionPTRobo_SerieVehi As String, ByVal ReporteGestionPTRobo_PlacasVehi As String, ByVal ReporteGestionPTRobo_TipoVehi As String, ByVal ReporteGestionPTRobo_Llama As String, ByVal ReporteGestionPTRobo_FEchaRobo As String, ByVal ReporteGestionPTRobo_HoraRobo As String, ByVal ReporteGestionPTRobo_CalleRobo As String, ByVal ReporteGestionPTRobo_ColoniaRobo As String, ByVal ReporteGestionPTRobo_Referencias As String, ByVal ReporteGestionPTRobo_TipoRobo As String, ByVal ReporteGestionPTRobo_QuienConducia As String, ByVal ReporteGestionPTRobo_nombreConducia As String, ByVal ReporteGestionPTRobo_PaternoConducia As String, ByVal ReporteGestionPTRobo_MaternoConducia As String, ByVal ReporteGestionPTRobo_LadaConducia As String, ByVal ReporteGestionPTRobo_telConducia As String, ByVal ReporteGestionPTRobo_CelLadaConducia As String, ByVal ReporteGestionPTRobo_CelTelConducia As String, ByVal ReporteGestionPTRobo_EdoPlacas As String, ByVal ReporteGestionPTRobo_MpioPlacas As String, ByVal ReporteGestionPTRobo_TipoCarga As String, ByVal ReporteGestionPTRobo_Paquete As String, ByVal ReporteGestionPTRobo_Descripcion As String, ByVal reporte_medio As Integer) As Boolean
        Dim sGestion As String = NoGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Dim comando As String = "exec update_ReporteGestionPTxRobo " & _
        p_Anio & "," & _
        p_Cliente & "," & _
        p_tipo & "," & _
        p_estado & "," & _
        p_consec & "," & _
        csNeg.myStr(ReporteGestionPTRobo_NoSiniestro) & "," & _
        csNeg.myStr(ReporteGestionPTRobo_NoReporte) & "," & _
        csNeg.myStr(ReporteGestionPTRobo_NoAveriguacion) & "," & _
        csNeg.myStr(ReporteGestionPTRobo_FechaAverigua) & "," & _
        csNeg.myStr(ReporteGestionPTRobo_MarcaVehi) & "," & _
        csNeg.myStr(ReporteGestionPTRobo_SubMarcaVehi) & "," & _
        csNeg.myStr(ReporteGestionPTRobo_SubMarcaVehi2) & "," & _
        csNeg.myStr(ReporteGestionPTRobo_ModeloVehi) & "," & _
        csNeg.myStr(ReporteGestionPTRobo_ColorVehi) & "," & _
        csNeg.myStr(ReporteGestionPTRobo_SerieVehi) & "," & _
        csNeg.myStr(ReporteGestionPTRobo_PlacasVehi) & "," & _
        csNeg.myStr(ReporteGestionPTRobo_TipoVehi) & "," & _
        csNeg.myStr(ReporteGestionPTRobo_Llama) & "," & _
        csNeg.myStr(ReporteGestionPTRobo_FEchaRobo) & "," & _
        csNeg.myStr(ReporteGestionPTRobo_HoraRobo) & "," & _
        csNeg.myStr(ReporteGestionPTRobo_CalleRobo) & "," & _
        csNeg.myStr(ReporteGestionPTRobo_ColoniaRobo) & "," & _
        csNeg.myStr(ReporteGestionPTRobo_Referencias) & "," & _
        csNeg.myStr(ReporteGestionPTRobo_TipoRobo) & "," & _
        csNeg.myStr(ReporteGestionPTRobo_QuienConducia) & "," & _
        csNeg.myStr(ReporteGestionPTRobo_nombreConducia) & "," & _
        csNeg.myStr(ReporteGestionPTRobo_PaternoConducia) & "," & _
        csNeg.myStr(ReporteGestionPTRobo_MaternoConducia) & "," & _
        csNeg.myStr(ReporteGestionPTRobo_LadaConducia) & "," & _
        csNeg.myStr(ReporteGestionPTRobo_telConducia) & "," & _
        csNeg.myStr(ReporteGestionPTRobo_CelLadaConducia) & "," & _
        csNeg.myStr(ReporteGestionPTRobo_CelTelConducia) & "," & _
        csNeg.myStr(ReporteGestionPTRobo_EdoPlacas) & "," & _
        csNeg.myStr(ReporteGestionPTRobo_MpioPlacas) & "," & _
        csNeg.myStr(ReporteGestionPTRobo_TipoCarga) & "," & _
        csNeg.myStr(ReporteGestionPTRobo_Paquete) & "," & _
        csNeg.myStr(ReporteGestionPTRobo_Descripcion) & "," & _
        reporte_medio

        If csSQLsvr.EjecutarSP(comando, conBaseDatos) = BaseDatosSQL.Estatus.OK Then
            update_ReporteGestionPTxRobo = True
        Else
            update_ReporteGestionPTxRobo = False
        End If

        'Insert_BitacoraCambios(NoGestion, "Se realizaron cambios en los datos de Gestion por Perdida Total", clvUsuario)


        Return update_ReporteGestionPTxRobo
    End Function

    Public Function update_reporteGestion(ByVal NoGestion As String, ByVal Reporte_clvMpio As String, ByVal Reporte_APaternoReporta As String, ByVal Reporte_AMaternoReporta As String, ByVal Reporte_NombreReporta As String, ByVal Reporte_LadaReporta As String, ByVal Reporte_telReporta As String, ByVal Reporte_poliza As String, ByVal Reporte_Inciso As String, ByVal Reporte_ApaternoAseg As String, ByVal Reporte_AMaternoAseg As String, ByVal Reporte_NombreAseg As String, ByVal Reporte_MailAseg As String, ByVal Reporte_CiaAsegura As String, ByVal Reporte_UsuarioMod As String, ByVal Reporte_LadaAseg As String, ByVal Reporte_TelAseg As String, ByVal Reporte_LadamovilAseg As String, ByVal Reporte_TelmovilAseg As String, ByVal pReporte_contrato As String, ByVal pReporte_AsegContrato As Integer, ByVal pReporte_Leasing As Integer, ByVal reporte_LadaEx As String, ByVal reporte_TelEx As String, ByVal Reporte_NoCorreo As Integer) As Boolean
        update_reporteGestion = False
        ' descomponemos el No dado en los datos correctos:
        Dim sGestion As String = NoGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Dim comando As String = "exec update_ReporteGestion " & _
        p_Anio & "," & _
        p_Cliente & "," & _
        p_tipo & "," & _
        p_estado & "," & _
        Reporte_clvMpio & "," & _
        p_consec & "," & _
        csNeg.myStr(Reporte_APaternoReporta) & "," & _
        csNeg.myStr(Reporte_AMaternoReporta) & "," & _
        csNeg.myStr(Reporte_NombreReporta) & "," & _
        csNeg.myStr(Reporte_LadaReporta) & "," & _
        csNeg.myStr(Reporte_telReporta) & "," & _
        csNeg.myStr(Reporte_poliza) & "," & _
        csNeg.myStr(Reporte_Inciso) & "," & _
        csNeg.myStr(Reporte_ApaternoAseg) & "," & _
        csNeg.myStr(Reporte_AMaternoAseg) & "," & _
        csNeg.myStr(Reporte_NombreAseg) & "," & _
        csNeg.myStr(Reporte_MailAseg) & "," & _
        csNeg.myStr(Reporte_CiaAsegura) & "," & _
        csNeg.myStr(Reporte_UsuarioMod) & "," & _
        csNeg.myStr(Reporte_LadaAseg) & "," & _
        csNeg.myStr(Reporte_TelAseg) & "," & _
        csNeg.myStr(Reporte_LadamovilAseg) & "," & _
        csNeg.myStr(Reporte_TelmovilAseg) & "," & _
        csNeg.myStr(pReporte_contrato) & "," & _
        pReporte_AsegContrato & "," & _
        pReporte_Leasing & ",'" & _
        reporte_LadaEx & "','" & _
        reporte_TelEx & "'," & _
        Reporte_NoCorreo


        If csSQLsvr.EjecutarSP(comando, conBaseDatos) = BaseDatosSQL.Estatus.OK Then
            update_reporteGestion = True
        Else
            update_reporteGestion = False
        End If

        Insert_BitacoraCambios(NoGestion, "Se realizaron cambios en los datos Generales de  Gestion", Reporte_UsuarioMod)
        Return update_reporteGestion

    End Function

    Public Function update_reporteGestionFallecimiento(ByVal NoGestion As String, ByVal GestionFallecimiento_Llama As Integer, ByVal GestionFallecimiento_TipoFallece As Integer, ByVal GestionFallecimiento_Descripcion As String, ByVal Reporte_UsuarioMod As String, ByVal Reporte_MedioContacto As Integer) As Boolean
        update_reporteGestionFallecimiento = False
        ' descomponemos el No dado en los datos correctos:
        Dim sGestion As String = NoGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Dim comando As String = "exec update_ReporteGestionFallecimiento " & _
        p_Anio & "," & _
        p_Cliente & "," & _
        p_tipo & "," & _
        p_estado & "," & _
        p_consec & "," & _
        GestionFallecimiento_Llama & "," & _
        GestionFallecimiento_TipoFallece & "," & _
        csNeg.myStr(GestionFallecimiento_Descripcion) & "," & _
        Reporte_MedioContacto

        If csSQLsvr.EjecutarSP(comando, conBaseDatos) = BaseDatosSQL.Estatus.OK Then
            update_reporteGestionFallecimiento = True
        Else
            update_reporteGestionFallecimiento = False
        End If
        Insert_BitacoraCambios(NoGestion, "Se realizaron cambios en los datos Generales de  Gestion x Fallecimiento", Reporte_UsuarioMod)

        Return update_reporteGestionFallecimiento

    End Function

    Public Function update_reporteGestionInvalidez(ByVal NoGestion As String, ByVal GestionInvalidez_Llama As Integer, ByVal GestionInvalidez_Tipo As Integer, ByVal GestionInvalidez_Descripcion As String, ByVal Reporte_UsuarioMod As String, ByVal reporte_medio As Integer) As Boolean
        update_reporteGestionInvalidez = False
        ' descomponemos el No dado en los datos correctos:
        Dim sGestion As String = NoGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Dim comando As String = "exec update_ReporteGestionInvalidez " & _
        p_Anio & "," & _
        p_Cliente & "," & _
        p_tipo & "," & _
        p_estado & "," & _
        p_consec & "," & _
        GestionInvalidez_Llama & "," & _
        GestionInvalidez_Tipo & "," & _
        csNeg.myStr(GestionInvalidez_Descripcion) & "," & _
        reporte_medio

        If csSQLsvr.EjecutarSP(comando, conBaseDatos) = BaseDatosSQL.Estatus.OK Then
            update_reporteGestionInvalidez = True
        Else
            update_reporteGestionInvalidez = False
        End If
        Insert_BitacoraCambios(NoGestion, "Se realizaron cambios en los datos Generales de  Gestion x Invalidez", Reporte_UsuarioMod)

        Return update_reporteGestionInvalidez

    End Function


    Public Function Insert_ReporteGestion(ByVal Reporte_cliente As String, ByVal Reporte_Tipo As String, ByVal Reporte_clvEstado As String, ByVal Reporte_clvMpio As String, _
    ByVal Reporte_FechaOcurre As String, ByVal Reporte_APaternoReporta As String, ByVal Reporte_AMaternoReporta As String, ByVal Reporte_NombreReporta As String, ByVal Reporte_LadaReporta As String, ByVal Reporte_telReporta As String, _
    ByVal Reporte_status As String, ByVal Reporte_UsuarioReg As String, ByVal Reporte_FechaRepor As String, ByVal Reporte_HRiniCaptura As String, _
    ByVal Reporte_poliza As String, ByVal Reporte_Inciso As String, ByVal Reporte_ApaternoAseg As String, _
    ByVal Reporte_AMaternoAseg As String, ByVal Reporte_NombreAseg As String, ByVal Reporte_MailAseg As String, ByVal Reporte_CiaAsegura As String, ByVal Reporte_UsuarioMod As String) As DataSet

        Reporte_status = 0
        Dim comando As String = "exec insert_ReporteGestion " & _
        Reporte_cliente & "," & _
        Reporte_Tipo & "," & _
        Reporte_clvEstado & "," & _
        Reporte_clvMpio & "," & _
        csNeg.myStr(Reporte_FechaOcurre) & "," & _
        csNeg.myStr(Reporte_APaternoReporta) & "," & _
        csNeg.myStr(Reporte_AMaternoReporta) & "," & _
        csNeg.myStr(Reporte_NombreReporta) & "," & _
        csNeg.myStr(Reporte_LadaReporta) & "," & _
        csNeg.myStr(Reporte_telReporta) & "," & _
        Reporte_status & "," & _
        csNeg.myStr(Reporte_UsuarioReg) & "," & _
        csNeg.myStr(Reporte_HRiniCaptura) & "," & _
        csNeg.myStr(Reporte_poliza) & "," & _
        csNeg.myStr(Reporte_Inciso) & "," & _
        csNeg.myStr(Reporte_ApaternoAseg) & "," & _
        csNeg.myStr(Reporte_AMaternoAseg) & "," & _
        csNeg.myStr(Reporte_NombreAseg) & "," & _
        csNeg.myStrlwr(Reporte_MailAseg) & "," & _
        csNeg.myStr(Reporte_CiaAsegura) & "," & _
        csNeg.myStr(Reporte_UsuarioMod)


        Dim ds As New DataSet
        ds = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        Insert_ReporteGestion = ds
        Return Insert_ReporteGestion

    End Function

    Public Function select_DatosContactos(ByVal NoGestion As String) As DataSet

        ' descomponemos el No dado en los datos correctos:
        Dim sGestion As String = NoGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)

        Dim comando As String = "exec Select_DatosContactoGestion_sp " & p_Anio & "," & p_Cliente & "," & p_tipo & "," & p_estado & "," & p_consec
        Dim dsExpediente As New DataSet
        dsExpediente = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        select_DatosContactos = dsExpediente
        Return select_DatosContactos

    End Function

    Public Function select_GestionFallecimiento(ByVal NoGestion As String) As DataSet

        ' descomponemos el No dado en los datos correctos:
        Dim sGestion As String = NoGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)

        Dim comando As String = "exec buscaExpedienteGestionFallecimiento_sp " & p_Anio & "," & p_Cliente & "," & p_tipo & "," & p_estado & "," & p_consec
        Dim dsExpediente As New DataSet
        dsExpediente = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        select_GestionFallecimiento = dsExpediente
        Return select_GestionFallecimiento

    End Function

    Public Function GestionInvalidez(ByVal NoGestion As String) As DataSet

        ' descomponemos el No dado en los datos correctos:
        Dim sGestion As String = NoGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)

        Dim comando As String = "exec buscaExpedienteInvalidez_sp " & p_Anio & "," & p_Cliente & "," & p_tipo & "," & p_estado & "," & p_consec
        Dim dsExpediente As New DataSet
        dsExpediente = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        GestionInvalidez = dsExpediente
        Return GestionInvalidez

    End Function

    Public Function Update_GestionFallecimiento(ByVal Reporte_anio As String, ByVal Reporte_cliente As String, ByVal Reporte_Tipo As String, ByVal Reporte_clvEstado As String, ByVal Reporte_Numero As String, ByVal GestionFallecimiento_Llama As String, _
    ByVal GestionFallecimiento_TipoFallece As String, ByVal GestionFallecimiento_Descripcion As String) As Boolean
        Update_GestionFallecimiento = False

        Dim comando As String = "exec update_ReporteGestionFallecimiento " & Reporte_anio & "," & Reporte_cliente & "," & Reporte_Tipo & "," & Reporte_clvEstado & "," & Reporte_Numero & "," & GestionFallecimiento_Llama & "," & GestionFallecimiento_TipoFallece & "," & csNeg.myStr(GestionFallecimiento_Descripcion)

        If csSQLsvr.EjecutarSP(comando, conBaseDatos) = BaseDatosSQL.Estatus.OK Then
            Update_GestionFallecimiento = True
        Else
            Update_GestionFallecimiento = False
        End If
        Return Update_GestionFallecimiento
    End Function

    Public Function Insert_GestionFallecimiento(ByVal Reporte_anio As String, ByVal Reporte_cliente As String, ByVal Reporte_Tipo As String, ByVal Reporte_clvEstado As String, ByVal Reporte_Numero As String, ByVal GestionFallecimiento_Llama As String, _
    ByVal GestionFallecimiento_TipoFallece As String, ByVal GestionFallecimiento_Descripcion As String) As Boolean
        Insert_GestionFallecimiento = False
        Dim comando As String = "exec insert_ReporteGestionFallecimiento " & Reporte_anio & "," & _
        Reporte_cliente & "," & _
        Reporte_Tipo & "," & _
        Reporte_clvEstado & "," & _
        Reporte_Numero & "," & _
        GestionFallecimiento_Llama & "," & _
        GestionFallecimiento_TipoFallece & "," & _
        csNeg.myStr(GestionFallecimiento_Descripcion)
        If csSQLsvr.EjecutarSP(comando, conBaseDatos) = BaseDatosSQL.Estatus.OK Then
            Insert_GestionFallecimiento = True
        Else
            Insert_GestionFallecimiento = False
        End If
        Return Insert_GestionFallecimiento
    End Function

    Public Function Insert_GestionPt(ByVal Reporte_anio As String, ByVal Reporte_cliente As String, ByVal Reporte_Tipo As String, ByVal Reporte_clvEstado As String, ByVal Reporte_Numero As String, ByVal ReporteGestionPT_NoSiniestro As String, _
    ByVal ReporteGestionPT_NoAveriguacion As String, ByVal ReporteGestionPT_FechaAverigua As String, ByVal ReporteGestionPT_MarcaVehi As String, ByVal ReporteGestionPT_SubMarcaVehi As String, ByVal ReporteGestionPT_ModeloVehi As String, ByVal ReporteGestionPT_ColorVehi As String, _
    ByVal ReporteGestionPT_SerieVehi As String, ByVal ReporteGestionPT_PlacasVehi As String, ByVal ReporteGestionPT_Llama As String, ByVal ReporteGestionPT_SubMarcaVehi2 As String) As Boolean
        Insert_GestionPt = False
        Dim comando As String = "exec insert_ReporteGestionPT " & Reporte_anio & "," & _
        Reporte_cliente & "," & _
        Reporte_Tipo & "," & _
        Reporte_clvEstado & "," & _
        Reporte_Numero & "," & _
        csNeg.myStr(ReporteGestionPT_NoSiniestro) & "," & _
        csNeg.myStr(ReporteGestionPT_NoAveriguacion) & "," & _
        csNeg.myStr(ReporteGestionPT_FechaAverigua) & "," & _
        csNeg.myStr(ReporteGestionPT_MarcaVehi) & "," & _
        csNeg.myStr(ReporteGestionPT_SubMarcaVehi) & "," & _
        csNeg.myStr(ReporteGestionPT_ModeloVehi) & "," & _
        csNeg.myStr(ReporteGestionPT_ColorVehi) & "," & _
        csNeg.myStr(ReporteGestionPT_SerieVehi) & "," & _
        csNeg.myStr(ReporteGestionPT_PlacasVehi) & "," & _
        ReporteGestionPT_Llama & "," & _
        csNeg.myStr(ReporteGestionPT_SubMarcaVehi2)
        If csSQLsvr.EjecutarSP(comando, conBaseDatos) = BaseDatosSQL.Estatus.OK Then
            Insert_GestionPt = True
        Else
            Insert_GestionPt = False
        End If
        Return Insert_GestionPt


    End Function

    Public Function buscaExpedienteGestion(ByVal NoGestion As String) As DataSet

        ' descomponemos el No dado en los datos correctos:
        Dim sGestion As String = NoGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)

        Dim comando As String = "exec buscaExpedienteGestion_sp " & p_Anio & "," & p_Cliente & "," & p_tipo & "," & p_estado & "," & p_consec
        Dim dsExpediente As New DataSet


        dsExpediente = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        buscaExpedienteGestion = dsExpediente
        Return buscaExpedienteGestion
    End Function
    Public Function buscaExpedienteControl(ByVal NoControl As String) As DataSet


        Dim nControl As Double = NoControl
        Dim nLargo As Integer = Len(nControl)
        Dim pAnio As String = Mid(nControl, 1, 4)
        Dim pConsec As String = Mid(nControl, 5, nLargo)
        Dim comando As String = "select * from   ResportesGestionTotal2_vw where Reporte_anio = '" & pAnio & "' and Reporte_Numero = '" & pConsec & "'"
        Dim dsExpediente As New DataSet

        dsExpediente = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        buscaExpedienteControl = dsExpediente
        Return buscaExpedienteControl
    End Function

    Public Function buscaExpedienteGestionPTxDM(ByVal NoGestion As String) As DataSet

        ' descomponemos el No dado en los datos correctos:
        Dim sGestion As String = NoGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)

        Dim comando As String = "exec buscaExpedienteGestionPT_sp " & p_Anio & "," & p_Cliente & "," & p_tipo & "," & p_estado & "," & p_consec
        Dim dsExpediente As New DataSet
        dsExpediente = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        buscaExpedienteGestionPTxDM = dsExpediente
        Return buscaExpedienteGestionPTxDM
    End Function

    Public Function buscaExpedienteGestionPTxRobo(ByVal NoGestion As String) As DataSet

        ' descomponemos el No dado en los datos correctos:
        Dim sGestion As String = NoGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)

        Dim comando As String = "exec buscaExpedienteGestionRobo_sp " & p_Anio & "," & p_Cliente & "," & p_tipo & "," & p_estado & "," & p_consec
        Dim dsExpediente As New DataSet
        dsExpediente = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        buscaExpedienteGestionPTxRobo = dsExpediente
        Return buscaExpedienteGestionPTxRobo
    End Function

    Public Function buscaSubmarca(ByVal consec As Integer, ByVal campo As String) As String
        buscaSubmarca = String.Empty
        Dim comando As String = "select " & campo & " from Amisdescrip where consec=" & consec
        Dim dsSub As New DataSet
        dsSub = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        Dim drSub As DataRow
        For Each drSub In dsSub.Tables(0).Rows
            buscaSubmarca = drSub(campo)
        Next

        Return buscaSubmarca
        dsSub.Clear()
    End Function

    Public Function HoraServidor() As String
        HoraServidor = Format(Now(), "MM/dd/yyyy HH:mm")
        Dim comando As String = "exec select_horaServidor"
        Dim ds As New DataSet
        ds = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        Dim dr As DataRow
        For Each dr In ds.Tables(0).Rows
            HoraServidor = Format(dr("horaSvr"), "MM/dd/yyyy HH:mm")
        Next
        Return HoraServidor
        ds.Clear()
        ds.Dispose()
    End Function

    Public Function buscaEstado(ByVal clvEstado As Integer) As String
        buscaEstado = "Estado no valido"
        Dim comando As String = "exec BuscaEstadoGestion_Sp " & clvEstado
        Dim dsResultado As New DataSet
        dsResultado = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        If dsResultado.Tables(0).Rows.Count = 0 Then
            buscaEstado = "Estado no valido"

        Else
            Dim dr1 As DataRow
            For Each dr1 In dsResultado.Tables(0).Rows
                buscaEstado = dr1("Nombre_Estado")
            Next
        End If
        dsResultado.Clear()
        dsResultado.Dispose()
        Return buscaEstado
    End Function

    Public Function buscaMpio(ByVal clvEstado As Integer, ByVal clvMpio As Integer) As String
        buscaMpio = "Mpio no valido"
        Dim comando As String = "exec BuscaMpioGestion_sp " & clvEstado & "," & clvMpio
        Dim dsResultado As New DataSet
        dsResultado = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        If dsResultado.Tables(0).Rows.Count = 0 Then
            buscaMpio = "Mpio no valido"

        Else
            Dim dr1 As DataRow
            For Each dr1 In dsResultado.Tables(0).Rows
                buscaMpio = dr1("Nombre_mpio")
            Next
        End If
        dsResultado.Clear()
        dsResultado.Dispose()
        Return buscaMpio
    End Function

    Public Function buscaAseguradora(ByVal clvCliente As Integer) As String
        'buscaAseguradoraGestion_sp

        buscaAseguradora = "Cliente no valido"
        Dim comando As String = "exec buscaAseguradoraGestion_sp " & clvCliente
        Dim dsResultado As New DataSet
        dsResultado = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        If dsResultado.Tables(0).Rows.Count = 0 Then
            buscaAseguradora = "Cliente no valido"

        Else
            Dim dr1 As DataRow
            For Each dr1 In dsResultado.Tables(0).Rows
                buscaAseguradora = dr1("cliente_NomCliente")
            Next
        End If
        dsResultado.Clear()
        dsResultado.Dispose()
        Return buscaAseguradora
    End Function

    Public Function buscaTipoServicio(ByVal clvCliente As Integer, ByVal clvServicio As Integer) As String
        'buscaAseguradoraGestion_sp

        buscaTipoServicio = "Servicio no valido"
        Dim comando As String = "exec buscaTipoServicioGestion_sp " & clvCliente & "," & clvServicio
        Dim dsResultado As New DataSet
        dsResultado = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        If dsResultado.Tables(0).Rows.Count = 0 Then
            buscaTipoServicio = "Servicio no valido"

        Else
            Dim dr1 As DataRow
            For Each dr1 In dsResultado.Tables(0).Rows
                buscaTipoServicio = dr1("Servicio_NomServicio")
            Next
        End If
        dsResultado.Clear()
        dsResultado.Dispose()
        Return buscaTipoServicio
    End Function

    Public Function buscaEstatusServicio(ByVal clvstatus As Integer) As String
        'buscaAseguradoraGestion_sp

        buscaEstatusServicio = "Estatus no valido"
        Dim comando As String = "exec buscaEstatusGestion_sp " & clvstatus
        Dim dsResultado As New DataSet
        dsResultado = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        If dsResultado.Tables(0).Rows.Count = 0 Then
            buscaEstatusServicio = "Estatus no valido"

        Else
            Dim dr1 As DataRow
            For Each dr1 In dsResultado.Tables(0).Rows
                buscaEstatusServicio = dr1("status_Descripcion")
            Next
        End If
        dsResultado.Clear()
        dsResultado.Dispose()
        Return buscaEstatusServicio
    End Function

    Public Sub Insert_BitacoraCambios(ByVal NoGestion As String, ByVal bitacora_Comentario As String, ByVal bitacora_usuario As String)
        Dim sGestion As String = NoGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Try
            Dim comando As String = "exec insert_BitacoraGestionCambios " & p_Anio & "," & p_Cliente & "," & p_tipo & "," & p_estado & "," & p_consec & "," & csNeg.myStr(bitacora_Comentario) & "," & csNeg.myStr(bitacora_usuario)
            csSQLsvr.EjecutarSP(comando, conBaseDatos)
        Catch ex As Exception

        End Try


    End Sub

    Public Sub Insert_BitacoraGestionExpe(ByVal NoGestion As String, ByVal bitacora_Comentario As String, ByVal bitacora_usuario As String)
        Dim sGestion As String = NoGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Try
            Dim comando As String = "exec insert_BitacoraGestionExpe " & p_Anio & "," & p_Cliente & "," & p_tipo & "," & p_estado & "," & p_consec & "," & csNeg.myStr(bitacora_Comentario) & "," & csNeg.myStr(bitacora_usuario)
            csSQLsvr.EjecutarSP(comando, conBaseDatos)
        Catch ex As Exception

        End Try


    End Sub

    Public Function Select_BitacoraGestionExpe(ByVal NoGestion As String) As DataSet
        Dim sGestion As String = NoGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Try
            Dim comando As String = "select bitacora_Comentario as 'Comentario',bitacora_usuario as 'Usuario',bitacora_fecha as 'Fecha' from BitacoraGestion where " & _
            " Reporte_anio=" & p_Anio & " and " & _
            "Reporte_cliente=" & p_Cliente & " and " & _
            " Reporte_Tipo=" & p_tipo & " and " & _
            "Reporte_clvEstado=" & p_estado & " and " & _
            " Reporte_Numero=" & p_consec & " order by bitacora_fecha desc"
            Select_BitacoraGestionExpe = csSQLsvr.QueryDataSet(comando, conBaseDatos)
            Return Select_BitacoraGestionExpe
        Catch ex As Exception

        End Try




    End Function

    Public Function llenaMenu() As DataSet
        Dim comando = "SELECT * FROM  tbl_MENUS  ORDER BY id ASC "
        llenaMenu = csSQLsvr.QueryDataSet(comando, conBaseDatos)

        Return llenaMenu
    End Function

    Public Function CancelaServicio(ByVal noGestion As String, ByVal usuario As String, ByVal causaCancela As String, ByVal status As String) As String
        Dim sGestion As String = noGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim pAnio As String = Mid(sGestion, 1, 4)
        Dim pCliente As String = Mid(sGestion, 5, 2)
        Dim ptipo As String = Mid(sGestion, 7, 2)
        Dim pestado As String = Mid(sGestion, 9, 2)
        Dim pconsec As String = Mid(sGestion, 11, nLargo)
        Try

            Using commandQuery As New SqlCommand
                commandQuery.Connection = New SqlConnection(Me.conBaseDatos)
                commandQuery.CommandText = "dbo.CancelaServicio_sp"
                commandQuery.CommandType = CommandType.StoredProcedure

                commandQuery.Parameters.Add("@anio", SqlDbType.Decimal).Value = pAnio
                commandQuery.Parameters.Add("@cliente", SqlDbType.Decimal).Value = pCliente
                commandQuery.Parameters.Add("@Tipo", SqlDbType.Decimal).Value = ptipo
                commandQuery.Parameters.Add("@clvEstado", SqlDbType.Decimal).Value = pestado
                commandQuery.Parameters.Add("@Numero", SqlDbType.Decimal).Value = pconsec
                commandQuery.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = usuario
                commandQuery.Parameters.Add("@FechaCancelacion", SqlDbType.SmallDateTime).Value = Now()
                commandQuery.Parameters.Add("@CausaCancela", SqlDbType.VarChar).Value = causaCancela
                commandQuery.Parameters.Add("@Estatus", SqlDbType.Decimal).Value = status

                CancelaServicio = csSQLsvr.EjecutarSPNew(commandQuery, conBaseDatos)
                Return CancelaServicio
            End Using

        Catch ex As Exception

        End Try




    End Function

    Public Function select_direccion(ByVal NoGestion As String) As DataSet
        Dim sGestion As String = NoGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Try
            Dim comando As String = "select ReporteGestionPTRobo_CalleRobo,ReporteGestionPTRobo_ColoniaRobo from ReporteGestionPTRobo where " & _
            " Reporte_anio=" & p_Anio & " and " & _
            "Reporte_cliente=" & p_Cliente & " and " & _
            " Reporte_Tipo=" & p_tipo & " and " & _
            "Reporte_clvEstado=" & p_estado & " and " & _
            " Reporte_Numero=" & p_consec
            select_direccion = csSQLsvr.QueryDataSet(comando, conBaseDatos)
            Return select_direccion
        Catch ex As Exception

        End Try

    End Function

    Public Function CargaTableroServicio(ByVal strQuery As String, ByVal _Bandera As Boolean) As DataSet
        Dim comando As String = String.Empty
        Dim bandera As Integer
        If (_Bandera = True) Then
            bandera = 1 'si hubo filtros
        Else
            bandera = 0 'no hubo filtros
        End If
        comando = "exec GestionaTableros '" & strQuery & "' , '" & bandera & "'"
        CargaTableroServicio = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        Return CargaTableroServicio
    End Function

    Public Function CargaDetalleTableroServicio(ByVal strQuery As String) As DataSet
        Dim comando As String = String.Empty
        comando = "exec " & strQuery & ""
        CargaDetalleTableroServicio = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        Return CargaDetalleTableroServicio
    End Function

    Public Function CargaTableroDesempeño(ByVal aseg As Integer, ByVal servicioTipo As Integer, ByVal fecha1 As String, ByVal fecha2 As String, ByVal mes As Integer, ByVal region As Integer, ByVal estado As Integer) As DataSet


        Dim comando As String = String.Empty

        comando = " EXEC TableroDesempeño_sp " & aseg & "," & servicioTipo & ",'" & fecha1 & "','" & fecha2 & "'," & mes & "," & region & "," & estado


        CargaTableroDesempeño = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        Return CargaTableroDesempeño

    End Function
    'TableroAvances_sp

    Public Function CargaTableroAvance(ByVal aseg As Integer, ByVal servicioTipo As Integer, ByVal fecha1 As String, ByVal fecha2 As String, ByVal mes As Integer, ByVal region As Integer, ByVal estado As Integer) As DataSet


        Dim comando As String = String.Empty

        comando = " EXEC TableroAvances_sp " & aseg & "," & servicioTipo & ",'" & fecha1 & "','" & fecha2 & "'," & mes & "," & region & "," & estado


        CargaTableroAvance = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        Return CargaTableroAvance

    End Function



    Public Function CargaDetalleTableroDesempeño(ByVal strQuery As String) As DataSet
        Dim comando As String = String.Empty
        comando = "exec " & strQuery & ""
        CargaDetalleTableroDesempeño = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        Return CargaDetalleTableroDesempeño
    End Function

    Public Function DocumentosExpedienteGestionAceptadosBO(ByVal noGestion As String, ByVal Tramite_clvTramite As Integer, ByVal Tramite_cvlSubTramite As Integer, ByVal fechaAcepta As String, ByVal usuarioAcepta As String, ByVal comentarios As String, ByVal consecDoc As Integer) As Boolean

        Dim sGestion As String = noGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Dim comando As String = "update CheckListDocumentosIntegracionExpediente set chkAutentiificado=1 ,fk_usuario_chkAutenti='" & usuarioAcepta & "', fechaChkAutententificado=getdate(),chkEntregado=1 , FechaChkEntregado= " & csNeg.myStr(fechaAcepta) & ", fechaCapturaChkEntregado=getdate(),comen_chkEntregado=" & csNeg.myStr(comentarios) & ",fk_usuario_chkEntregado=  " & csNeg.myStr(usuarioAcepta) & " where  " & _
        " Reporte_anio=" & p_Anio & " and " & _
        " Reporte_cliente=" & p_Cliente & " and " & _
        " Reporte_Tipo=" & p_tipo & " and " & _
        " Reporte_clvEstado=" & p_estado & " and " & _
        " Reporte_Numero=" & p_consec & " and " & _
        " Tramite_clvTramite=" & Tramite_clvTramite & " and " & _
        " Tramite_cvlSubTramite=" & Tramite_cvlSubTramite & " and " & _
        " consec =" & consecDoc

        If csSQLsvr.EjecutarSP(comando, conBaseDatos) = BaseDatosSQL.Estatus.OK Then
            DocumentosExpedienteGestionAceptadosBO = True
        Else
            DocumentosExpedienteGestionAceptadosBO = False
        End If

        Return DocumentosExpedienteGestionAceptadosBO

    End Function

    Public Function DocumentosExpedienteGestionRechazadosBO(ByVal noGestion As String, ByVal Tramite_Descripcion As String, ByVal Tramite_Documento As String, ByVal usuario_rechaza As String, ByVal comen_Rechazo As String) As Boolean

        Dim sGestion As String = noGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Dim comando As String = "exec insert_DocumentosExpedienteGestionRechazadosBO  " & _
        p_Anio & "," & _
        p_Cliente & "," & _
        p_tipo & "," & _
        p_estado & "," & _
        p_consec & "," & _
        csNeg.myStr(Tramite_Descripcion) & "," & _
        csNeg.myStr(Tramite_Documento) & "," & _
        csNeg.myStr(usuario_rechaza) & "," & _
        csNeg.myStr(comen_Rechazo) & "," & _
        csNeg.myStr(comen_Rechazo)
        If csSQLsvr.EjecutarSP(comando, conBaseDatos) = BaseDatosSQL.Estatus.OK Then
            DocumentosExpedienteGestionRechazadosBO = True
        Else
            DocumentosExpedienteGestionRechazadosBO = False
        End If

        Return DocumentosExpedienteGestionRechazadosBO

    End Function

    Public Function revisarDocumentosPendientesRecepcionBO(ByVal noGestion As String) As DataSet

        Dim sGestion As String = noGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Dim comando As String = "exec Select_CheckListDocumentosGestionPendientesEntregarBO  " & _
        p_Anio & "," & _
        p_Cliente & "," & _
        p_tipo & "," & _
        p_estado & "," & _
        p_consec
        revisarDocumentosPendientesRecepcionBO = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        Return revisarDocumentosPendientesRecepcionBO

    End Function

    Public Function DocumentosSolicitadosBO(ByVal noGestion As String) As DataSet

        Dim sGestion As String = noGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Dim comando As String = "select * from   DocumentosSolicitados_gestioBO_vw where chkEntregado=1 and " & _
        " Reporte_anio=" & p_Anio & " and " & _
        "Reporte_cliente=" & p_Cliente & " and " & _
        " Reporte_Tipo=" & p_tipo & " and " & _
        "Reporte_clvEstado=" & p_estado & " and " & _
        " Reporte_Numero=" & p_consec
        DocumentosSolicitadosBO = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        Return DocumentosSolicitadosBO

    End Function

    Public Function GuardaDocumentosSolicitadoBO(ByVal NoGestion As String, ByVal Tramite_clvTramite As Integer, ByVal Tramite_cvlSubTramite As Integer, ByVal fechachkSolicitado As String, ByVal fk_usuario_chkSolicitado As String, ByVal Tramite_TipoPersona As Integer, ByVal Tramite_servVeh As Integer) As Boolean
        Dim sGestion As String = NoGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Dim comando As String = "exec insert_CheckListDocumentosExpedienteBO " & _
        p_Anio & "," & _
        p_Cliente & "," & _
        p_tipo & "," & _
        p_estado & "," & _
        p_consec & "," & _
        Tramite_clvTramite & "," & _
        Tramite_cvlSubTramite & ", '" & _
        fechachkSolicitado & "'," & _
        csNeg.myStr(fk_usuario_chkSolicitado) & "," & _
        Tramite_TipoPersona & "," & _
        Tramite_servVeh
        If csSQLsvr.EjecutarSP(comando, conBaseDatos) = BaseDatosSQL.Estatus.OK Then
            GuardaDocumentosSolicitadoBO = True
        Else
            GuardaDocumentosSolicitadoBO = False
        End If
        Return GuardaDocumentosSolicitadoBO
    End Function

    Public Function BuscaDatosGestores(ByVal rfc As String) As DataSet

        Dim comando As String = String.Empty
        comando = "select * from ajustadores2 where rfcajustador = '" & rfc & "'"
        BuscaDatosGestores = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        Return BuscaDatosGestores

    End Function

    Public Function AltaGestores(ByVal rfc As String, ByVal nombre As String, ByVal paterno As String, ByVal materno As String _
 , ByVal callenumero As String, ByVal COLONIA As String, ByVal ESTADO As String, ByVal MPIO As String _
 , ByVal CP As String, ByVal CELULAR As String, ByVal TELFIJO As String, ByVal NEXTEL As String _
 , ByVal EMAIL As String, ByVal CLABE As String, ByVal BANCO As String, ByVal TABULADOR As String, ByVal TIPOPERSONA As String, ByVal CLABE2 As String, ByVal BANCO2 As String) As String


        Dim comando As String = String.Empty
        comando = "exec ALTAGESTORES2_SP '" & rfc & "', '" & nombre & "', '" & paterno & "', '" & materno & "', '" & callenumero & "', '" & COLONIA & "', " & _
        "" & ESTADO & ", " & MPIO & ", " & CP & ", '" & CELULAR & "', '" & TELFIJO & "', '" & NEXTEL & "','" & _
        "" & EMAIL & "', '" & CLABE & "', '" & BANCO & "', '" & TABULADOR & "', " & TIPOPERSONA & ", '" & CLABE2 & "', '" & BANCO2 & "'"
        AltaGestores = csSQLsvr.EjecutarSP(comando, conBaseDatos)
        Return AltaGestores

    End Function

    Public Function ModificaGestores(ByVal rfc As String, ByVal nombre As String, ByVal paterno As String, ByVal materno As String _
, ByVal callenumero As String, ByVal COLONIA As String, ByVal ESTADO As String, ByVal MPIO As String _
, ByVal CP As String, ByVal CELULAR As String, ByVal TELFIJO As String, ByVal NEXTEL As String _
, ByVal EMAIL As String, ByVal CLABE As String, ByVal CLABE2 As String, ByVal BANCO As String, ByVal BANCO2 As String, ByVal TABULADOR As String, ByVal TIPOPERSONA As String, ByVal activo As Integer) As String


        Dim comando As String = String.Empty
        comando = "exec ModificaGESTORES_SP '" & rfc & "', '" & nombre & "', '" & paterno & "', '" & materno & "', '" & callenumero & "', '" & COLONIA & "', " & _
        "" & ESTADO & ", " & MPIO & ", " & CP & ", '" & CELULAR & "', '" & TELFIJO & "', '" & NEXTEL & "','" & _
        "" & EMAIL & "', '" & CLABE & "','" & CLABE2 & "', " & BANCO & "," & BANCO2 & ", '" & TABULADOR & "', " & TIPOPERSONA & ", " & activo
        ModificaGestores = csSQLsvr.EjecutarSP(comando, conBaseDatos)
        Return ModificaGestores

    End Function


    '

    Public Function ValidaGestores(ByVal Rfc As String) As Int32
        Dim comando As String = String.Empty
        comando = "exec ValidaGestores_SP '" & Rfc & "'"
        Dim ds As New DataSet
        Dim dt As DataTable
        ds = csSQLsvr.EjecutarSPDataset(comando, conBaseDatos)
        dt = ds.Tables(0)

        Dim rw As DataRow

        For Each rw In dt.Rows
            ValidaGestores = CInt(rw("GestorId"))
        Next

        Return ValidaGestores

    End Function

    Public Function CargaGestores(ByVal activo As String, ByVal rfc As String, ByVal regional As String, ByVal estado As String) As DataSet

        Dim comando As String = String.Empty
        comando = "exec Select_Gestores '" & activo & "', '" & rfc & "', '" & regional & "', '" & estado & "'"

        CargaGestores = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        Return CargaGestores

    End Function

    Public Function CargaAsignaciones(ByVal poliza As String, ByVal cliente As String, ByVal tipoServicio As String, ByVal fechaIni As String, ByVal fechaFin As String, ByVal regional As String, ByVal estado As String, ByVal estatusAsignacion As String, ByVal orden As String) As DataSet

        Dim comando As String = String.Empty
        comando = "exec Asignaciones_sp '" & poliza & "', '" & cliente & "', '" & tipoServicio & "', '" & _
            "" & fechaIni & "', '" & fechaFin & "', '" & regional & "', '" & estado & "', '" & estatusAsignacion & "', '" & orden & "'"

        CargaAsignaciones = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        Return CargaAsignaciones

    End Function

    Public Function CargaTerminos(ByVal EstatusExpediente As String) As DataSet

        Dim comando As String = String.Empty
        comando = "exec ControlTermino_sp "

        CargaTerminos = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        Return CargaTerminos

    End Function


    Public Function CargaAsignacionesSinJuridico(ByVal poliza As String, ByVal cliente As String, ByVal tipoServicio As String, ByVal fechaIni As String, ByVal fechaFin As String, ByVal regional As String, ByVal estado As String, ByVal estatusAsignacion As String, ByVal orden As String) As DataSet

        Dim comando As String = String.Empty
        comando = "exec AsignacionesSinServJuridico_sp '" & poliza & "', '" & cliente & "', '" & tipoServicio & "', '" & _
            "" & fechaIni & "', '" & fechaFin & "', '" & regional & "', '" & estado & "', '" & estatusAsignacion & "', '" & orden & "'"

        CargaAsignacionesSinJuridico = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        Return CargaAsignacionesSinJuridico

    End Function

    Public Function CargaDetallesPrimerContacto(ByVal anio As String, ByVal cliente As String, ByVal tipo As String, ByVal Estado As String, ByVal consec As String) As DataSet

        Dim comando As String = String.Empty
        comando = "exec sp_DetallePrimerContacto " & anio & ", " & cliente & ", " & tipo & ", " & _
            "" & Estado & "," & consec

        CargaDetallesPrimerContacto = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        Return CargaDetallesPrimerContacto

    End Function


    Public Function CargaDocumentos(ByVal tipo As String, ByVal cliente As String) As DataSet

        Dim comando As String = String.Empty
        comando = "exec Select_DocumentosTramites '" & tipo & "', '" & cliente & "'"

        CargaDocumentos = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        Return CargaDocumentos

    End Function

    Public Function GestorProgramado(ByVal FechaI As String, ByVal FechaF As String, ByVal estado As Integer) As DataSet


        Dim comando As String = String.Empty
        comando = "exec ChecaGestorDisponible_sp '" & FechaI & "', '" & FechaF & "', " & estado

        GestorProgramado = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        Return GestorProgramado

    End Function

    Public Function AsignarGestorManual(ByVal noGestion As String, ByVal rfcGestor As String) As Boolean

        Dim sGestion As String = noGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Dim comando As String = String.Empty

        comando = "update ReporteGestion set   RFC_Gestor = " & csNeg.myStr(rfcGestor) & "  where  " & _
        " Reporte_anio=" & p_Anio & " and " & _
        " Reporte_cliente=" & p_Cliente & " and " & _
        " Reporte_Tipo=" & p_tipo & " and " & _
        " Reporte_clvEstado=" & p_estado & " and " & _
        " Reporte_Numero=" & p_consec & " and Reporte_status=0 "

        'Dim comando As String = "update ReporteGestion set   RFC_Gestor = " & csNeg.myStr(rfcGestor) & " ,HRAVISO_Gestor=getdate() where  " & _

        If csSQLsvr.EjecutarSP(comando, conBaseDatos) = BaseDatosSQL.Estatus.OK Then
            AsignarGestorManual = True
        Else
            AsignarGestorManual = False
        End If

        Return AsignarGestorManual

    End Function

    Public Function RegresoSeguimiento(ByVal noGestion As String) As String

        Dim sGestion As String = noGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Dim comando As String = "exec RegresoSeguimiento_Sp  " & _
        p_Anio & "," & _
        p_Cliente & "," & _
        p_tipo & "," & _
        p_estado & "," & _
        p_consec & ""
        Dim ds As New DataSet
        ds = csSQLsvr.EjecutarSPDataset(comando, conBaseDatos)
        If ds.Tables(0).Rows.Count <> 0 Then
            RegresoSeguimiento = True

            For Each dr In ds.Tables(0).Rows
                If Trim(dr("Errores")) <> 0 Then
                    RegresoSeguimiento = Trim(dr("msg")).ToString
                Else
                    RegresoSeguimiento = ""
                End If
            Next

        Else
            RegresoSeguimiento = False
        End If

        Return RegresoSeguimiento

    End Function

    Public Function TerminoDocumentosExpedienteGestionRechazadosBO(ByVal noGestion As String, ByVal Tramite_Descripcion As String, ByVal Tramite_Documento As String, ByVal usuario_rechaza As String, ByVal comen_Rechazo As String, ByVal fechaSol As DateTime) As Boolean

        Dim sGestion As String = noGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Dim comando As String = "exec insert_DocumentosExpedienteGestionRechazadosBO  " & _
        p_Anio & "," & _
        p_Cliente & "," & _
        p_tipo & "," & _
        p_estado & "," & _
        p_consec & "," & _
        csNeg.myStr(Tramite_Descripcion) & "," & _
        csNeg.myStr(Tramite_Documento) & "," & _
        csNeg.myStr(usuario_rechaza) & "," & _
        csNeg.myStr(comen_Rechazo) & "," & _
        csNeg.myStr(comen_Rechazo) & ",'" & _
        fechaSol & "'"

        If csSQLsvr.EjecutarSP(comando, conBaseDatos) = BaseDatosSQL.Estatus.OK Then
            TerminoDocumentosExpedienteGestionRechazadosBO = True
        Else
            TerminoDocumentosExpedienteGestionRechazadosBO = False
        End If

        Return TerminoDocumentosExpedienteGestionRechazadosBO

    End Function
    Public Function buscaExpedienteGestionPTxRobo2(ByVal NoGestion As String) As DataSet

        ' descomponemos el No dado en los datos correctos:
        Dim sGestion As String = NoGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)

        Dim comando As String = "exec buscaExpedienteGestionRobo2_sp " & p_Anio & "," & p_Cliente & "," & p_tipo & "," & p_estado & "," & p_consec
        Dim dsExpediente As New DataSet
        dsExpediente = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        buscaExpedienteGestionPTxRobo2 = dsExpediente
        Return buscaExpedienteGestionPTxRobo2
    End Function
    Public Function update_reporteGestion2(ByVal NoGestion As String, ByVal Reporte_clvMpio As String, ByVal Reporte_APaternoReporta As String, ByVal Reporte_AMaternoReporta As String, ByVal Reporte_NombreReporta As String, ByVal Reporte_LadaReporta As String, ByVal Reporte_telReporta As String, ByVal Reporte_poliza As String, ByVal Reporte_Inciso As String, ByVal Reporte_ApaternoAseg As String, ByVal Reporte_AMaternoAseg As String, ByVal Reporte_NombreAseg As String, ByVal Reporte_MailAseg As String, ByVal Reporte_CiaAsegura As String, ByVal Reporte_UsuarioMod As String, ByVal Reporte_LadaAseg As String, ByVal Reporte_TelAseg As String, ByVal Reporte_LadamovilAseg As String, ByVal Reporte_TelmovilAseg As String, ByVal pReporte_contrato As String, ByVal preporte_staPol As String, ByVal preporte_IniVig As String, ByVal preporte_FinVig As String, ByVal pReporte_AsegContrato As Integer, ByVal reporte_leasing As Integer, ByVal Reporte_LadaEx As String, ByVal Reporte_TelEx As String, ByVal Reporte_NoCorreo As Integer) As Boolean
        update_reporteGestion2 = False
        ' descomponemos el No dado en los datos correctos:
        Dim sGestion As String = NoGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Dim comando As String = "exec update_ReporteGestion2 " & _
        p_Anio & "," & _
        p_Cliente & "," & _
        p_tipo & "," & _
        p_estado & "," & _
        Reporte_clvMpio & "," & _
        p_consec & "," & _
        csNeg.myStr(Reporte_APaternoReporta) & "," & _
        csNeg.myStr(Reporte_AMaternoReporta) & "," & _
        csNeg.myStr(Reporte_NombreReporta) & "," & _
        csNeg.myStr(Reporte_LadaReporta) & "," & _
        csNeg.myStr(Reporte_telReporta) & "," & _
        csNeg.myStr(Reporte_poliza) & "," & _
        csNeg.myStr(Reporte_Inciso) & "," & _
        csNeg.myStr(Reporte_ApaternoAseg) & "," & _
        csNeg.myStr(Reporte_AMaternoAseg) & "," & _
        csNeg.myStr(Reporte_NombreAseg) & "," & _
        csNeg.myStr(Reporte_MailAseg) & "," & _
        csNeg.myStr(Reporte_CiaAsegura) & "," & _
        csNeg.myStr(Reporte_UsuarioMod) & "," & _
        csNeg.myStr(Reporte_LadaAseg) & "," & _
        csNeg.myStr(Reporte_TelAseg) & "," & _
        csNeg.myStr(Reporte_LadamovilAseg) & "," & _
        csNeg.myStr(Reporte_TelmovilAseg) & "," & _
        csNeg.myStr(pReporte_contrato) & ",'" & _
        preporte_staPol & "','" & _
        preporte_IniVig & "','" & _
        preporte_FinVig & "'," & _
        pReporte_AsegContrato & "," & _
        reporte_leasing & ",'" & _
        Reporte_LadaEx & "','" & _
        Reporte_TelEx & "'," & _
        Reporte_NoCorreo

        If csSQLsvr.EjecutarSP(comando, conBaseDatos) = BaseDatosSQL.Estatus.OK Then
            update_reporteGestion2 = True
        Else
            update_reporteGestion2 = False
        End If

        Insert_BitacoraCambios(NoGestion, "Se realizaron cambios en los datos Generales de  Gestion", Reporte_UsuarioMod)
        Return update_reporteGestion2

    End Function
    Public Function update_ReporteGestionGeneral(ByVal NoGestion As String, ByVal ReporteGestionPTRobo_MarcaVehi As String, _
                                                   ByVal ReporteGestionPTRobo_SubMarcaVehi As String, ByVal ReporteGestionPTRobo_ModeloVehi As Integer, ByVal ReporteGestionPTRobo_ColorVehi As String, _
                                                   ByVal ReporteGestionPTRobo_SerieVehi As String, ByVal ReporteGestionPTRobo_PlacasVehi As String, ByVal ReporteGestionInfo_correo As String, ByVal ReporteGestionInfo_Cel As String, ByVal ReporteGestionPTRobo_Descripcion As String, ByVal GestionGeneral_Llama As Integer, ByVal Reporte_MedioContacto As Integer) As Boolean
        Dim sGestion As String = NoGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Dim comando As String = "exec update_ReporteGestionGeneral " & _
        p_Anio & "," & _
        p_Cliente & "," & _
        p_tipo & "," & _
        p_estado & "," & _
        p_consec & "," & _
        csNeg.myStr(ReporteGestionPTRobo_MarcaVehi) & "," & _
        csNeg.myStr(ReporteGestionPTRobo_SubMarcaVehi) & "," & _
        ReporteGestionPTRobo_ModeloVehi & "," & _
        csNeg.myStr(ReporteGestionPTRobo_ColorVehi) & "," & _
        csNeg.myStr(ReporteGestionPTRobo_PlacasVehi) & "," & _
        csNeg.myStr(ReporteGestionPTRobo_SerieVehi) & "," & _
        csNeg.myStr(ReporteGestionInfo_correo) & "," & _
        csNeg.myStr(ReporteGestionInfo_Cel) & "," & _
        csNeg.myStr(ReporteGestionPTRobo_Descripcion) & "," & _
        GestionGeneral_Llama & "," & _
        Reporte_MedioContacto

        If csSQLsvr.EjecutarSP(comando, conBaseDatos) = BaseDatosSQL.Estatus.OK Then
            update_ReporteGestionGeneral = True
        Else
            update_ReporteGestionGeneral = False
        End If

        'Insert_BitacoraCambios(NoGestion, "Se realizaron cambios en los datos de Gestion por Perdida Total", clvUsuario)


        Return update_ReporteGestionGeneral
    End Function
    'Public Function buscaExpedienteGestionGeneral(ByVal NoGestion As String) As DataSet

    '       ' descomponemos el No dado en los datos correctos:
    '       Dim sGestion As String = NoGestion.Trim
    '       Dim nLargo As Integer = Len(sGestion)
    '       Dim p_Anio As String = Mid(sGestion, 1, 4)
    '       Dim p_Cliente As String = Mid(sGestion, 5, 2)
    '       Dim p_tipo As String = Mid(sGestion, 7, 2)
    '       Dim p_estado As String = Mid(sGestion, 9, 2)
    '       Dim p_consec As String = Mid(sGestion, 11, nLargo)

    '       Dim comando As String = "exec buscaExpedienteGestionGeneral_sp " & p_Anio & "," & p_Cliente & "," & p_tipo & "," & p_estado & "," & p_consec
    '       Dim dsExpediente As New DataSet
    '       dsExpediente = csSQLsvr.QueryDataSet(comando, conBaseDatos)
    '       buscaExpedienteGestionGeneral = dsExpediente
    '       Return buscaExpedienteGestionGeneral
    '   End Function

    Public Function valida_EntregaExpedientesGestoria(ByVal Reporte_anio As String, ByVal Reporte_cliente As String, ByVal Reporte_Tipo As String, ByVal Reporte_clvEstado As String, ByVal Reporte_Numero As String) As Boolean
        Dim dts As New DataSet()
        Dim cmd As String = "usp_EntregaExpedientesGestoriaValida " & Reporte_anio & "," & Reporte_cliente & "," & Reporte_Tipo & _
                                  "," & Reporte_clvEstado & "," & Reporte_Numero

        Try
            Dim ds As New DataSet
            ds = csSQLsvr.EjecutarSPDataset(cmd, conBaseDatos)
            If ds.Tables(0).Rows.Count <> 0 Then
                valida_EntregaExpedientesGestoria = True
            Else
                valida_EntregaExpedientesGestoria = False
            End If

            Return valida_EntregaExpedientesGestoria
        Catch

        Finally
            cmd = String.Empty
        End Try
    End Function

    Public Shared Sub Guardar(noGestion As String, tabla As String, usuario As String, nombrearchivo As String, length As Integer, archivo As Byte())
        Using conn As New SqlConnection(ConfigurationManager.AppSettings("ConnStringSQL").ToString())

            Dim sGestion As String = noGestion.Trim
            Dim nLargo As Integer = Len(sGestion)
            Dim p_Anio As String = Mid(sGestion, 1, 4)
            Dim p_Cliente As String = Mid(sGestion, 5, 2)
            Dim p_tipo As String = Mid(sGestion, 7, 2)
            Dim p_estado As String = Mid(sGestion, 9, 2)
            Dim p_consec As String = Mid(sGestion, 11, nLargo)

            conn.Open()

            Dim query As String = "INSERT INTO " & tabla & " (Reporte_anio, Reporte_cliente, Reporte_Tipo, Reporte_clvEstado " & _
                                    ", Reporte_Numero, nombre, length, archivo, usuario_alta, fecha_alta) " & _
                                    " VALUES (@Reporte_anio, @Reporte_cliente, @Reporte_Tipo, @Reporte_clvEstado " & _
                                    ", @Reporte_Numero, @name, @length, @archivo, @usuario_alta, @fecha_alta)"

            Dim cmd As New SqlCommand(query, conn)

            cmd.Parameters.AddWithValue("@name", nombrearchivo)
            cmd.Parameters.AddWithValue("@length", length)
            cmd.Parameters.AddWithValue("@Reporte_anio", p_Anio)
            cmd.Parameters.AddWithValue("@Reporte_cliente", p_Cliente)
            cmd.Parameters.AddWithValue("@Reporte_Tipo", p_tipo)
            cmd.Parameters.AddWithValue("@Reporte_clvEstado", p_estado)
            cmd.Parameters.AddWithValue("@Reporte_Numero", p_consec)

            Dim archParam As SqlParameter = cmd.Parameters.Add("@archivo", System.Data.SqlDbType.VarBinary)
            archParam.Value = archivo

            cmd.Parameters.AddWithValue("@usuario_alta", usuario)
            cmd.Parameters.AddWithValue("@fecha_alta", Now())

            'Executa primer sentencia
            cmd.ExecuteNonQuery()

            If tabla = "ArchivosAceptadosPDF" Then

                query = " InsertaImagenesPDFAceptadasImagDocs_sp @Reporte_anio, @Reporte_cliente, @Reporte_Tipo, @Reporte_clvEstado, @Reporte_Numero"
                Dim cmd2 As New SqlCommand(query, conn)
                cmd2.Parameters.AddWithValue("@Reporte_anio", p_Anio)
                cmd2.Parameters.AddWithValue("@Reporte_cliente", p_Cliente)
                cmd2.Parameters.AddWithValue("@Reporte_Tipo", p_tipo)
                cmd2.Parameters.AddWithValue("@Reporte_clvEstado", p_estado)
                cmd2.Parameters.AddWithValue("@Reporte_Numero", p_consec)

                cmd2.ExecuteNonQuery()

            End If

        End Using

    End Sub

    Public Shared Function GetAll(ByVal noGestion As String, ByVal Tabla As String) As List(Of Archivo)
        Dim sGestion As String = noGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Dim lista As New List(Of Archivo)()

        Using conn As New SqlConnection(ConfigurationManager.AppSettings("ConnStringSQL").ToString())
            conn.Open()

            Dim query As String = "SELECT Id, Nombre, Length " & _
                                   "FROM " & Tabla & " WHERE " & _
                                    " Reporte_anio=" & p_Anio & " and " & _
                                    " Reporte_cliente=" & p_Cliente & " and " & _
                                    " Reporte_Tipo=" & p_tipo & " and " & _
                                    " Reporte_clvEstado=" & p_estado & " and " & _
                                    " Reporte_Numero=" & p_consec

            Dim cmd As New SqlCommand(query, conn)

            Dim reader As SqlDataReader = cmd.ExecuteReader()

            While reader.Read()
                Dim img As New Archivo(Convert.ToInt32(reader("Id")), Convert.ToString(reader("nombre")), Convert.ToInt32(reader("length")))
                lista.Add(img)

            End While
        End Using

        Return lista

    End Function

    Public Shared Function GetById(tabla As String, Id As Integer) As Archivo
        Dim arch As Archivo = Nothing

        Using conn As New SqlConnection(ConfigurationManager.AppSettings("ConnStringSQL").ToString())
            conn.Open()

            Dim query As String = "SELECT Id, Nombre, Length, archivo " & _
                                "FROM " & tabla & _
                                " WHERE Id = @id"

            Dim cmd As New SqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@id", Id)

            Dim reader As SqlDataReader = cmd.ExecuteReader()

            If reader.Read() Then
                arch = New Archivo(Convert.ToInt32(reader("Id")), Convert.ToString(reader("nombre")), Convert.ToInt32(reader("length")))


                arch.ContenidoArchivo = DirectCast(reader("archivo"), Byte())

            End If
        End Using

        Return arch

    End Function

    Public Shared Sub DeleteById(Id As Integer)

        Using conn As New SqlConnection(ConfigurationManager.AppSettings("ConnStringSQL").ToString())
            conn.Open()

            Dim query As String = "DELETE FROM Archivos WHERE Id = @id"

            Dim cmd As New SqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@id", Id)


            cmd.ExecuteNonQuery()
        End Using
    End Sub

    Public Function DocumentosExpedienteGestionAceptadosBOTermino(ByVal noGestion As String, ByVal Tramite_clvTramite As Integer, ByVal Tramite_cvlSubTramite As Integer, ByVal fechaAcepta As String, ByVal usuarioAcepta As String, ByVal motivoRechazo As String, ByVal comentarios As String, ByVal consecDoc As Integer) As Boolean

        Dim sGestion As String = noGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Dim comando As String = "update CheckListDocumentosIntegracionExpediente set chkAutentiificado=1 ,fk_usuario_chkAutenti='" & usuarioAcepta & "', fechaChkAutententificado=getdate(),chkEntregado=1 , FechaChkEntregado= " & csNeg.myStr(fechaAcepta) & ", fechaCapturaChkEntregado=getdate(),comen_chkEntregado=" & csNeg.myStr(motivoRechazo) & ",comen_chkSolicitado=" & csNeg.myStr(comentarios) & ", fk_usuario_chkEntregado=  " & csNeg.myStr(usuarioAcepta) & " where  " & _
        " Reporte_anio=" & p_Anio & " and " & _
        " Reporte_cliente=" & p_Cliente & " and " & _
        " Reporte_Tipo=" & p_tipo & " and " & _
        " Reporte_clvEstado=" & p_estado & " and " & _
        " Reporte_Numero=" & p_consec & " and " & _
        " Tramite_clvTramite=" & Tramite_clvTramite & " and " & _
        " Tramite_cvlSubTramite=" & Tramite_cvlSubTramite & " and " & _
        " consec =" & consecDoc

        If csSQLsvr.EjecutarSP(comando, conBaseDatos) = BaseDatosSQL.Estatus.OK Then
            DocumentosExpedienteGestionAceptadosBOTermino = True
        Else
            DocumentosExpedienteGestionAceptadosBOTermino = False
        End If

        Return DocumentosExpedienteGestionAceptadosBOTermino

    End Function
    Public Function GestoresEdos_Mpios(ByVal noGestion As String) As DataTable

        Dim sGestion As String = noGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Dim comando As String = "exec GestoresEstados_mpios_sp  " & _
        p_Anio & "," & _
        p_Cliente & "," & _
        p_tipo & "," & _
        p_estado & "," & _
        p_consec & ""
        GestoresEdos_Mpios = csSQLsvr.QueryDataDatable(comando, conBaseDatos)
        Return GestoresEdos_Mpios

    End Function

    Public Function buscaExpedienteDatos(ByVal NoGestion As String) As DataSet

        ' descomponemos el No dado en los datos correctos:
        Dim comando As String = "select * from ResportesGestionTotal_vw where NoGestion= '" & NoGestion & "'"
        Dim dsExpediente As New DataSet
        dsExpediente = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        buscaExpedienteDatos = dsExpediente
        Return buscaExpedienteDatos
    End Function
    Public Function buscaReciboPago(ByVal fechaIni As String, ByVal fechaFin As String, ByVal serv As String, ByVal gestor As String) As DataSet

        Dim comando As String = String.Empty


        comando = "exec Comprobacion_Gastos_sp '" & fechaIni & "','" & fechaFin & "','" & serv & "','" & gestor & "'"
        buscaReciboPago = csSQLsvr.QueryDataSet(comando, conBaseDatos)


        Return buscaReciboPago
    End Function
    Public Function update_cancelaComprobacion(ByVal FECHA As String, ByVal USUA As String, ByVal SERVICIO As String) As Boolean
        update_cancelaComprobacion = False

        Dim comando As String = "update PagosGestor set STATUSPAGOAJUS=1, FECHACANCELA=" & FECHA & ",USUACANCELA='" & USUA & "' WHERE Servicio=" & SERVICIO & " "

        '"update CheckListDocumentosExpedienteGestion set chkAutentiificado=1 , fechaChkAutententificado= " & csNeg.myStr(fechaAcepta) & ", fechaCapturaChkAutentificado=getdate(), comen_chkAutentificado=" & csNeg.myStr(comentarios) & ", fk_usuario_chkAutenti=  " & csNeg.myStr(usuarioAcepta) & ",TipoEntrega=" & tipoEntrega & " where  " & _
        '" Reporte_anio=" & p_Anio

        If csSQLsvr.EjecutarSP(comando, conBaseDatos) = BaseDatosSQL.Estatus.OK Then
            update_cancelaComprobacion = True
        Else
            update_cancelaComprobacion = False
        End If


        Return update_cancelaComprobacion

    End Function
    Public Function update_GuardaComprobacion(ByVal recibo As String, ByVal fecha As String, ByVal usua As String, ByVal SERVICIO As String) As Boolean
        update_GuardaComprobacion = False

        Dim comando As String = "update PagosGestor set STATUSPAGOAJUS=2, reciboPago=" & recibo & ", FECHA_AUTO='" & fecha & "', USUARIOAUTO='" & usua & "' WHERE Servicio=" & SERVICIO & " "

        '"update CheckListDocumentosExpedienteGestion set chkAutentiificado=1 , fechaChkAutententificado= " & csNeg.myStr(fechaAcepta) & ", fechaCapturaChkAutentificado=getdate(), comen_chkAutentificado=" & csNeg.myStr(comentarios) & ", fk_usuario_chkAutenti=  " & csNeg.myStr(usuarioAcepta) & ",TipoEntrega=" & tipoEntrega & " where  " & _
        '" Reporte_anio=" & p_Anio

        If csSQLsvr.EjecutarSP(comando, conBaseDatos) = BaseDatosSQL.Estatus.OK Then
            update_GuardaComprobacion = True
        Else
            update_GuardaComprobacion = False
        End If


        Return update_GuardaComprobacion

    End Function
    Public Function buscaPagosAutorizados(ByVal fechaIni As String, ByVal fechaFin As String, ByVal serv As String, ByVal gestor As String) As DataSet

        Dim comando As String = String.Empty


        comando = "exec Comprobacion_GastosAutorizados_sp '" & fechaIni & "','" & fechaFin & "','" & serv & "','" & gestor & "'"
        buscaPagosAutorizados = csSQLsvr.QueryDataSet(comando, conBaseDatos)


        Return buscaPagosAutorizados
    End Function
    Public Function buscaPagosCancelados(ByVal fechaIni As String, ByVal fechaFin As String, ByVal serv As String, ByVal gestor As String) As DataSet

        Dim comando As String = String.Empty


        comando = "exec Comprobacion_GastosCancelados_sp '" & fechaIni & "','" & fechaFin & "','" & serv & "','" & gestor & "'"
        buscaPagosCancelados = csSQLsvr.QueryDataSet(comando, conBaseDatos)


        Return buscaPagosCancelados
    End Function


    Public Function GastosfondosAutorizadosConta(ByVal noServicio As String) As DataSet
        Dim sGestion As String = noServicio.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)

        Dim ds As New DataSet
        Dim conn As New SqlConnection(conBaseDatos)
        Dim cmd As New SqlCommand("Select_GastosfondosAutorizadosConta_sp", conn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Reporte_anio", p_Anio)
        cmd.Parameters.AddWithValue("@Reporte_cliente", p_Cliente)
        cmd.Parameters.AddWithValue("@Reporte_Tipo", p_tipo)
        cmd.Parameters.AddWithValue("@Reporte_clvEstado", p_estado)
        cmd.Parameters.AddWithValue("@Reporte_Numero", p_consec)

        Try

            ds = csSQLsvr.QueryDataSetNew(cmd)
            'cmd.ExecuteNonQuery()
            GastosfondosAutorizadosConta = ds

        Catch

        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Dispose()
            cmd.Dispose()
        End Try
        Return GastosfondosAutorizadosConta
    End Function

    Public Function ValidaExpedienteVerificado(ByVal noGestion As String) As Boolean

        Dim sGestion As String = noGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Dim comando As String = "exec Sp_ValidaDocumentosComplet_Pagos " & _
        " @Reporte_anio=" & p_Anio & ", " & _
        " @Reporte_cliente=" & p_Cliente & ", " & _
        " @Reporte_Tipo=" & p_tipo & ", " & _
        " @Reporte_clvEstado=" & p_estado & ", " & _
        " @Reporte_Numero=" & p_consec
        Dim ds As New DataSet
        Dim valida As Boolean

        ds = csSQLsvr.EjecutarSPDataset(comando, conBaseDatos)
        If ds.Tables(0).Rows.Count <> 0 Then
            Dim dr As DataRow

            For Each dr In ds.Tables(0).Rows

                valida = dr("VALIDA")

            Next

            If valida Then

                ValidaExpedienteVerificado = True

            Else

                ValidaExpedienteVerificado = False

            End If

        End If

        Return ValidaExpedienteVerificado

    End Function

    'Public Function ValidaComprobacionPagoDerechos(ByVal noGestion As String) As Boolean

    '    Dim sGestion As String = noGestion.Trim
    '    Dim nLargo As Integer = Len(sGestion)
    '    Dim p_Anio As String = Mid(sGestion, 1, 4)
    '    Dim p_Cliente As String = Mid(sGestion, 5, 2)
    '    Dim p_tipo As String = Mid(sGestion, 7, 2)
    '    Dim p_estado As String = Mid(sGestion, 9, 2)
    '    Dim p_consec As String = Mid(sGestion, 11, nLargo)
    '    Dim comando As String = "exec ValidaComprobacionPagoDerechos_sp " & _
    '    " @Reporte_anio=" & p_Anio & ", " & _
    '    " @Reporte_cliente=" & p_Cliente & ", " & _
    '    " @Reporte_Tipo=" & p_tipo & ", " & _
    '    " @Reporte_clvEstado=" & p_estado & ", " & _
    '    " @Reporte_Numero=" & p_consec
    '    Dim ds As New DataSet
    '    Dim valida As Boolean

    '    ds = csSQLsvr.EjecutarSPDataset(comando, conBaseDatos)
    '    If ds.Tables(0).Rows.Count <> 0 Then
    '        Dim dr As DataRow

    '        For Each dr In ds.Tables(0).Rows

    '            valida = dr("VALIDA")

    '        Next

    '        If valida Then

    '            ValidaComprobacionPagoDerechos = True

    '        Else

    '            ValidaComprobacionPagoDerechos = False

    '        End If

    '    End If

    '    Return ValidaComprobacionPagoDerechos

    'End Function

    Public Function ValidaFondoEntrada(ByVal noGestion As String) As Boolean

        Dim sGestion As String = noGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)

        Dim comando As String = "select 1 from Fondo_entrada WHERE cliente_clvCliente = " & p_Cliente
        Dim ds As New DataSet
        Dim valida As Boolean

        ds = csSQLsvr.EjecutarSPDataset(comando, conBaseDatos)



        'Dim comando As String = "exec ValidaComprobacionPagoDerechos_sp " & _
        '" @Reporte_anio=" & p_Anio & ", " & _
        '" @Reporte_cliente=" & p_Cliente & ", " & _
        '" @Reporte_Tipo=" & p_tipo & ", " & _
        '" @Reporte_clvEstado=" & p_estado & ", " & _
        '" @Reporte_Numero=" & p_consec

        If ds.Tables(0).Rows.Count <> 0 Then
            Dim dr As DataRow

            ValidaFondoEntrada = True

        Else

            ValidaFondoEntrada = False

        End If

        Return ValidaFondoEntrada

    End Function

    Public Function ValidaRegistroFondoSalida(ByVal noGestion As String) As Boolean

        Dim sGestion As String = noGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)

        Dim comando As String = " select 1 from Fondo_Salida WHERE reporte_anio = " & p_Anio & _
        " and Reporte_cliente = " & p_Cliente & " and Reporte_clvEstado = " & p_estado & _
        " and Reporte_Tipo = " & p_tipo & " and Reporte_Numero = " & p_consec & " and usuarioDisperso <> '' "
        Dim ds As New DataSet
        Dim valida As Boolean

        ds = csSQLsvr.EjecutarSPDataset(comando, conBaseDatos)



        'Dim comando As String = "exec ValidaComprobacionPagoDerechos_sp " & _
        '" @Reporte_anio=" & p_Anio & ", " & _
        '" @Reporte_cliente=" & p_Cliente & ", " & _
        '" @Reporte_Tipo=" & p_tipo & ", " & _
        '" @Reporte_clvEstado=" & p_estado & ", " & _
        '" @Reporte_Numero=" & p_consec

        If ds.Tables(0).Rows.Count <> 0 Then
            Dim dr As DataRow

            ValidaRegistroFondoSalida = True

        Else

            ValidaRegistroFondoSalida = False

        End If

        Return ValidaRegistroFondoSalida

    End Function

    Public Function ValidaCompobacionFondoSalida(ByVal noGestion As String) As Boolean

        Dim sGestion As String = noGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)

        Dim comando As String = " select 1 from Fondo_Salida WHERE reporte_anio = " & p_Anio & _
        " and Reporte_cliente = " & p_Cliente & " and Reporte_clvEstado = " & p_estado & _
        " and Reporte_Tipo = " & p_tipo & " and Reporte_Numero = " & p_consec & _
        " and usuario_justifico <> '' "

        Dim ds As New DataSet
        Dim valida As Boolean

        ds = csSQLsvr.EjecutarSPDataset(comando, conBaseDatos)



        'Dim comando As String = "exec ValidaComprobacionPagoDerechos_sp " & _
        '" @Reporte_anio=" & p_Anio & ", " & _
        '" @Reporte_cliente=" & p_Cliente & ", " & _
        '" @Reporte_Tipo=" & p_tipo & ", " & _
        '" @Reporte_clvEstado=" & p_estado & ", " & _
        '" @Reporte_Numero=" & p_consec

        If ds.Tables(0).Rows.Count <> 0 Then
            Dim dr As DataRow

            ValidaCompobacionFondoSalida = True

        Else

            ValidaCompobacionFondoSalida = False

        End If

        Return ValidaCompobacionFondoSalida

    End Function

    Public Function CargaPagoGestor(ByVal noServicio As String, usuario As String) As Boolean

        Try
            Dim lista As New List(Of String)
            Dim sRfcGestor As String
            Dim nEstado As Integer
            Dim nMpio As Integer
            Dim COSTO As Integer = 0
            Dim ID_PAGO As Integer = 0
            Dim NumRegion As Integer = 0

            lista = SolicitudPago(noServicio, usuario)
            nEstado = Trim(lista.Item(0))
            nMpio = Trim(lista.Item(1))
            sRfcGestor = Trim(lista.Item(2))
            NumRegion = Trim(lista.Item(3))
            COSTO = Trim(lista.Item(4))
            ID_PAGO = Trim(lista.Item(5))

            If COSTO <> 0 And ID_PAGO <> 0 Then
                If Insert_pagosGestor(noServicio, sRfcGestor, ID_PAGO, COSTO, usuario, NumRegion, nEstado, nMpio) Then
                    CargaPagoGestor = True
                End If
            End If

        Catch ex As Exception
            CargaPagoGestor = False
        End Try

        Return CargaPagoGestor

    End Function

    Public Function Verifica_pagosGestor(ByVal Servicio As String) As Boolean
        Verifica_pagosGestor = False
        Dim comando As String

        comando = "select * from PagosGestor where Servicio = '" & Servicio & "'"


        Try
            Dim dsDAtos As DataSet = New DataSet
            dsDAtos = csSQLsvr.QueryDataSet(comando, conBaseDatos)
            If dsDAtos.Tables(0).Rows.Count = 0 Then
                Verifica_pagosGestor = True
            End If
        Catch

        End Try
        Return Verifica_pagosGestor
    End Function

    Public Function SolicitudPago(ByVal noServicio As String, usuario As String) As List(Of String)
        Dim sGestion As String = noServicio.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Dim nTipoPagoOficina As Integer = 0
        Dim comando As String
        Dim sRfcGestor As String
        Dim nEstado As Integer
        Dim nMpio As Integer
        Dim lista As New List(Of String)

        Try


            ' rutina para saber si el pago es con oficina o sin oficina
            'Start *******************************************************************************
            Dim dsServicio As DataSet = New DataSet
            dsServicio = BuscaExpedienteDatos(noServicio)
            Dim dr As DataRow
            For Each dr In dsServicio.Tables(0).Rows
                nEstado = dr("reporte_clvEStado")
                nMpio = dr("reporte_clvMpio")
                sRfcGestor = dr("rfc_gestor")

                'If sRfcGestor IsNot Nothing Then
                ' buscamos si el estado y mpio esta como con oficina, si esta  en automatico el pago es con oficina
                comando = "select TIPO_FORMA_PAGO from mpio where ESTADO=" & nEstado & " and CLAVE=" & nMpio
                Dim dsTipoOficina As DataSet = New DataSet
                dsTipoOficina = csSQLsvr.QueryDataSet(comando, conBaseDatos)
                Dim dr2 As DataRow
                For Each dr2 In dsTipoOficina.Tables(0).Rows
                    nTipoPagoOficina = dr2("TIPO_FORMA_PAGO") ' 1= es con oficina 2= sin oficina
                Next

                If nTipoPagoOficina = 2 Then
                    '  si es "sin oficina" buscamos el estado y mpio del servicio para ver si el gestor esta dado de alta en ese estado.
                    'si llegara estar en ese estado y mpio el servicio se cataloga como Con Oficina, en automatico.
                    If sRfcGestor <> String.Empty Then
                        comando = "select * from   Gestores_MultiEstado where rfcgestor='" & sRfcGestor & "' and  clave_estado=" & nEstado & " and  clave_mpio=" & nMpio
                        Dim dsGestorEstado As DataSet = New DataSet
                        dsGestorEstado = csSQLsvr.QueryDataSet(comando, conBaseDatos)
                        If dsGestorEstado.Tables(0).Rows.Count <> 0 Then
                            nTipoPagoOficina = 1  ' el gestor esta dado de alta el pago es con oficina
                        End If

                    End If
                End If
                'Else
                'Exit For
                ' End If
            Next

            lista.Add(nEstado)
            lista.Add(nMpio)
            lista.Add(sRfcGestor)

            'End *******************************************************************************
            If sRfcGestor IsNot Nothing Then


                If nTipoPagoOficina <> 0 Then
                    ' rutina para buscar todos los datos del servicio para catalogar el tipo de pago.
                    comando = "select * from Pagos_servicios_Tipos_vw where Reporte_anio=" & p_Anio & "  and Reporte_cliente=" & p_Cliente & " and Reporte_Tipo=" & p_tipo & " and  Reporte_clvEstado=" & p_estado & " and  Reporte_Numero=" & p_consec
                    Dim dsDAtos As DataSet = New DataSet
                    dsDAtos = csSQLsvr.QueryDataSet(comando, conBaseDatos)
                    Dim drDatos As DataRow
                    Dim NumRegion As Integer
                    Dim TIPO_TRAMITE_PAGO As Integer
                    Dim TIPO_SERVICIO_PAGO As Integer

                    For Each drDatos In dsDAtos.Tables(0).Rows
                        NumRegion = drDatos("NumRegion")
                        TIPO_TRAMITE_PAGO = drDatos("TIPO_TRAMITE_PAGO")
                        TIPO_SERVICIO_PAGO = drDatos("TIPO_SERVICIO_PAGO")
                    Next
                    lista.Add(NumRegion)

                    dsDAtos.Clear()
                    ' con los datos de regional, tipo tramite, tipo servicio, tipoPagoOficina traemos el tabulador correspondiente
                    comando = "select * from vw_tabuladores_pago_gestores  where clave=" & NumRegion & "  and TIPO_TRAMITE_PAGO=" & TIPO_TRAMITE_PAGO & " and tipo_servicio_pago=" & TIPO_SERVICIO_PAGO & " and  tipo_forma_pago=" & nTipoPagoOficina
                    dsDAtos = New DataSet
                    dsDAtos = csSQLsvr.QueryDataSet(comando, conBaseDatos)
                    Dim COSTO As Integer = 0
                    Dim ID_PAGO As Integer = 0
                    For Each drDatos In dsDAtos.Tables(0).Rows
                        COSTO = drDatos("COSTO")
                        ID_PAGO = drDatos("ID_PAGO")
                    Next
                    lista.Add(COSTO)
                    lista.Add(ID_PAGO)
                End If

            Else

                SolicitudPago = lista
            End If
            SolicitudPago = lista
        Catch ex As Exception
            SolicitudPago = Nothing
        End Try
        Return SolicitudPago

    End Function

    Public Function ObtieneNombreGestor(ByVal rFC As String) As String


        Dim comando As String = "select * from Ajustadores2 where" & _
        " rfcajustador like '%" & rFC & "%' "

        Dim ds As New DataSet
        Dim Gestor As String

        ds = csSQLsvr.EjecutarSPDataset(comando, conBaseDatos)
        If ds.Tables(0).Rows.Count <> 0 Then
            Dim dr As DataRow

            For Each dr In ds.Tables(0).Rows
                Gestor = Trim(dr("NOMBRE")) & " " & Trim(dr("PATERNO")) & " " & Trim(dr("MATERNO"))
            Next

            If Gestor IsNot String.Empty Then
                ObtieneNombreGestor = Gestor
            Else
                ObtieneNombreGestor = Nothing
            End If

        End If

        Return ObtieneNombreGestor

    End Function

    Public Function Insert_pagosGestor(ByVal Servicio As String, ByVal RFCGESTOR As String, ByVal CLAVETAB As String, ByVal TOTALPAGO As String, ByVal USUARIO As String, ByVal REGIONAL As String, ByVal ESTADO As String, ByVal MPIO As String) As Boolean
        Insert_pagosGestor = False
        Dim conn As New SqlConnection(conBaseDatos)
        Dim cmd As New SqlCommand("Insert_PagosGestor", conn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Servicio", Servicio)
        cmd.Parameters.AddWithValue("@RFCGESTOR", RFCGESTOR)
        cmd.Parameters.AddWithValue("@CLAVETAB", CLAVETAB)
        cmd.Parameters.AddWithValue("@TOTALPAGO", TOTALPAGO)
        cmd.Parameters.AddWithValue("@USUARIO", USUARIO)
        cmd.Parameters.AddWithValue("@REGIONAL", REGIONAL)
        cmd.Parameters.AddWithValue("@ESTADO", ESTADO)
        cmd.Parameters.AddWithValue("@MPIO", MPIO)

        Try
            conn.Open()
            cmd.ExecuteNonQuery()
            Insert_pagosGestor = True
        Catch

        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Dispose()
            cmd.Dispose()
        End Try
        Return Insert_pagosGestor
    End Function

    Public Function update_gastoGestor(ByVal Servicio As String, ByVal TOTALPAGO As String, ByVal USUARIO As String, ByVal Concepto As String, ByVal Consec As String) As Boolean
        '@Servicio [varchar](30)  
        ', @TOTALPAGO      [float]  
        ', @USUARIO      [char](18)  
        ', @CONCEPTO  [varchar](MAX)  

        update_gastoGestor = False
        Dim conn As New SqlConnection(conBaseDatos)
        Dim cmd As New SqlCommand("update_gastoGestor", conn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Servicio", Servicio)
        cmd.Parameters.AddWithValue("@TOTALPAGO", TOTALPAGO)
        cmd.Parameters.AddWithValue("@USUARIO", USUARIO)
        cmd.Parameters.AddWithValue("@CONCEPTO", Trim(Concepto))
        cmd.Parameters.AddWithValue("@CONSEC", Consec)

        Try
            conn.Open()
            cmd.ExecuteNonQuery()
            update_gastoGestor = True
        Catch

        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Dispose()
            cmd.Dispose()
        End Try
        Return update_gastoGestor
    End Function

    Public Function update_fondoGestor(ByVal Servicio As String, ByVal TOTALPAGO As String, ByVal USUARIO As String, ByVal Concepto As String, ByVal Consec As String) As Boolean
        Dim sGestion As String = Servicio.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)

        update_fondoGestor = False
        Dim conn As New SqlConnection(conBaseDatos)
        Dim cmd As New SqlCommand("update_FondoGestor", conn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Reporte_anio", p_Anio)
        cmd.Parameters.AddWithValue("@Reporte_cliente", p_Cliente)
        cmd.Parameters.AddWithValue("@Reporte_Tipo", p_tipo)
        cmd.Parameters.AddWithValue("@Reporte_clvEstado", p_estado)
        cmd.Parameters.AddWithValue("@Reporte_Numero", p_consec)
        cmd.Parameters.AddWithValue("@TOTALPAGO", CInt(TOTALPAGO))
        cmd.Parameters.AddWithValue("@USUARIO", USUARIO)
        cmd.Parameters.AddWithValue("@CONCEPTO", Concepto)
        cmd.Parameters.AddWithValue("@CONSEC", Consec)

        Try
            conn.Open()
            cmd.ExecuteNonQuery()
            update_fondoGestor = True
        Catch

        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Dispose()
            cmd.Dispose()
        End Try
        Return update_fondoGestor
    End Function
    Public Function Insert_TelExtrass(ByVal NoGestion As String, ByVal GestionContacto_Lada As String, ByVal GestionContacto_Telefono As String, ByVal tipotel As String) As Boolean
        Dim sGestion As String = NoGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Dim comando As String = "exec insert_TelExtrasss  " & _
        p_Anio & "," & _
        p_Cliente & "," & _
        p_tipo & "," & _
        p_estado & "," & _
        p_consec & "," & _
        csNeg.myStr(GestionContacto_Lada) & "," & _
        csNeg.myStr(GestionContacto_Telefono) & "," & _
        csNeg.myStr(tipotel)

        If csSQLsvr.EjecutarSP(comando, conBaseDatos) = BaseDatosSQL.Estatus.OK Then
            Insert_TelExtrass = True
        Else
            Insert_TelExtrass = False
        End If
        'Insert_BitacoraCambios(NoGestion, "Se realizaron cambios en los datos de Gestion datos del Contacto", GestionContacto_UsrCambio)
        Return Insert_TelExtrass




    End Function
    Public Function select_Leasing(ByVal NoGestion As String) As DataTable

        ' descomponemos el No dado en los datos correctos:
        Dim sGestion As String = NoGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)

        Dim comando As String = "exec Select_ReporteGestionLeasing_sp " & p_Anio & "," & p_Cliente & "," & p_tipo & "," & p_estado & "," & p_consec
        select_Leasing = csSQLsvr.QueryDataDatable(comando, conBaseDatos)
        Return select_Leasing

    End Function
    Public Function select_TelExtras(ByVal NoGestion As String) As DataSet

        ' descomponemos el No dado en los datos correctos:
        Dim sGestion As String = NoGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)

        Dim comando As String = "exec Select_TelExtrass_sp " & p_Anio & "," & p_Cliente & "," & p_tipo & "," & p_estado & "," & p_consec
        Dim dsExpediente As New DataSet
        dsExpediente = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        select_TelExtras = dsExpediente
        Return select_TelExtras

    End Function
    Public Function CargaDirCita(ByVal dist As String) As DataSet

        Dim comando As String = String.Empty

        comando = "exec Select_cbo_distribuidorDirec " & "'" & dist & "'"


        CargaDirCita = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        Return CargaDirCita
    End Function

    Public Function SelectDetalleRechazosSeguimiento(ByVal nogestion As String) As DataSet
        Dim sGestion As String = nogestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        ''--,fecha_rechazo
        Dim comando As String = "SELECT ROW_NUMBER() OVER(ORDER BY DEGRBO.consec) AS numero " & _
        ", DEGRBO.Tramite_Documento, DEGRBO.usuario_rechaza, DEGRBO.causa_rechazo  FROM         dbo.DocumentosExpedienteGestionRechazadosBO  DEGRBO " & _
        " inner join DocumentosSolicitadosBO_gestion_vw DSBOGVW on DEGRBO.Reporte_anio = DSBOGVW.Reporte_anio " & _
 " and DEGRBO.Reporte_cliente = DSBOGVW.Reporte_cliente " & _
" and DEGRBO.Reporte_tipo = DSBOGVW.Reporte_tipo" & _
" and DEGRBO.Reporte_clvEstado = DSBOGVW.Reporte_clvEstado " & _
" and DEGRBO.Reporte_Numero = DSBOGVW.Reporte_Numero " & _
" AND DEGRBO.Tramite_Documento = DSBOGVW.documentos_descrip and DSBOGVW.chkEntregado=0" & _
        "where " & _
        " DEGRBO.Reporte_anio=" & p_Anio & " and " & _
        " DEGRBO.Reporte_cliente=" & p_Cliente & " and " & _
        " DEGRBO.Reporte_Tipo=" & p_tipo & " and " & _
        " DEGRBO.Reporte_clvEstado=" & p_estado & " and " & _
        " DEGRBO.Reporte_Numero=" & p_consec
        SelectDetalleRechazosSeguimiento = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        Return SelectDetalleRechazosSeguimiento

    End Function
    Public Function eliminarPoderes(ByVal rfc As String) As Boolean
        Dim comando As String = String.Empty
        comando = "exec sp_elimina_Multipoderes '" & rfc & "'"
        eliminarPoderes = csSQLsvr.EjecutarSP(comando, conBaseDatos)
        Return eliminarPoderes
    End Function
    Public Function InsertaMultiplePoderes(ByVal rfc As String, ByVal clvEmpresas As String) As Boolean
        Dim comando As String = String.Empty
        comando = "exec GestoresMultiPoderes_SP '" & rfc & "'," & clvEmpresas & ""
        InsertaMultiplePoderes = csSQLsvr.EjecutarSP(comando, conBaseDatos)
        Return InsertaMultiplePoderes
    End Function
    Public Function buscaGestoresLeasing(Optional ByVal estado As Integer = 0, Optional ByVal mpio As Integer = 0, Optional ByVal cliente As Integer = 0, Optional ByVal fechaIni As String = "", Optional ByVal fechaFIn As String = "") As DataSet

        Dim comando As String = String.Empty

        If fechaIni <> "" And fechaFIn <> "" And mpio = 0 Then
            buscaGestoresLeasing = GestorProgramadoleasing(fechaIni, fechaFIn, estado)
        ElseIf estado <> 0 And mpio <> 0 Then
            comando = "exec GestoresXmpioLeasing" & " " & estado & "," & mpio & "," & cliente
            buscaGestoresLeasing = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        ElseIf estado <> 0 And cliente <> 0 Then
            comando = "exec GestoresXestadoNewLeasing_sp" & " " & estado & "," & cliente
            buscaGestoresLeasing = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        ElseIf estado = 0 And cliente <> 0 Then
            comando = "exec GestoresXClienteLeasing_sp " & cliente
            buscaGestoresLeasing = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        End If

        'buscaGestoresLeasing.Clear()

        Return buscaGestoresLeasing

    End Function
    Public Function select_EtapaCintillo(ByVal NoGestion As String) As DataSet

        ' descomponemos el No dado en los datos correctos:
        Dim sGestion As String = NoGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)

        Dim comando As String = "exec Select_EtapaCintillo_sp " & p_Anio & "," & p_Cliente & "," & p_tipo & "," & p_estado & "," & p_consec
        Dim dsExpediente As New DataSet
        dsExpediente = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        select_EtapaCintillo = dsExpediente
        Return select_EtapaCintillo

    End Function
    Public Function select_GestorCintillo(ByVal NoGestion As String) As DataSet

        ' descomponemos el No dado en los datos correctos:
        Dim sGestion As String = NoGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)

        Dim comando As String = "exec Select_GestorCintillo_sp " & p_Anio & "," & p_Cliente & "," & p_tipo & "," & p_estado & "," & p_consec
        Dim dsExpediente As New DataSet
        dsExpediente = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        select_GestorCintillo = dsExpediente
        Return select_GestorCintillo

    End Function
    Public Function select_MarcaySubmarca(ByVal NoGestion As String) As DataSet

        ' descomponemos el No dado en los datos correctos:
        Dim sGestion As String = NoGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Dim comando As String

        If p_tipo = 11 Then
            comando = "exec Select_MarcaSubMarCintilloptR_sp " & p_Anio & "," & p_Cliente & "," & p_tipo & "," & p_estado & "," & p_consec
        ElseIf p_tipo = 10 Then
            comando = "exec Select_MarcaSubMarCintilloPT_sp " & p_Anio & "," & p_Cliente & "," & p_tipo & "," & p_estado & "," & p_consec
        Else
            comando = "exec Select_MarcaSubMarCintilloRGG_sp " & p_Anio & "," & p_Cliente & "," & p_tipo & "," & p_estado & "," & p_consec
        End If

        Dim dsExpediente As New DataSet
        dsExpediente = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        select_MarcaySubmarca = dsExpediente
        Return select_MarcaySubmarca

    End Function
    Public Function buscaNombreCliente(ByVal cliente As Integer) As DataSet

        Dim comando As String = String.Empty

        comando = " select * from clientes where cliente_clvCliente = " & cliente
        buscaNombreCliente = csSQLsvr.QueryDataSet(comando, conBaseDatos)

        Return buscaNombreCliente
    End Function
    Public Function GestorProgramadoleasing(ByVal FechaI As String, ByVal FechaF As String, ByVal estado As Integer) As DataSet


        Dim comando As String = String.Empty
        comando = "exec ChecaGestorDisponibleLeasing_sp '" & FechaI & "', '" & FechaF & "', " & estado

        GestorProgramadoleasing = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        Return GestorProgramadoleasing

    End Function
    Public Function select_CorreoOpc(ByVal NoGestion As String) As DataSet

        ' descomponemos el No dado en los datos correctos:
        Dim sGestion As String = NoGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)

        Dim comando As String = "exec buscaExpedienteGestion_sp " & p_Anio & "," & p_Cliente & "," & p_tipo & "," & p_estado & "," & p_consec
        Dim dsExpediente As New DataSet
        dsExpediente = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        select_CorreoOpc = dsExpediente
        Return select_CorreoOpc

    End Function
    Public Function update_ReporteGestionGeneralPagoxEvento(ByVal NoGestion As String, ByVal ReporteGestionPTRobo_MarcaVehi As String, _
                                                   ByVal ReporteGestionPTRobo_SubMarcaVehi As String, ByVal ReporteGestionPTRobo_ModeloVehi As Integer, ByVal ReporteGestionPTRobo_ColorVehi As String, _
                                                   ByVal ReporteGestionPTRobo_SerieVehi As String, ByVal ReporteGestionPTRobo_PlacasVehi As String, ByVal ReporteGestionInfo_correo As String, ByVal ReporteGestionInfo_Cel As String, ByVal ReporteGestionPTRobo_Descripcion As String, ByVal GestionGeneral_Llama As Integer, ByVal Reporte_MedioContacto As Integer, ByVal NomEnt As String, ByVal ladaEnt As String, ByVal telEnt As String) As Boolean
        Dim sGestion As String = NoGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)
        Dim comando As String = "exec update_ReporteGestionGeneral1 " & _
        p_Anio & "," & _
        p_Cliente & "," & _
        p_tipo & "," & _
        p_estado & "," & _
        p_consec & "," & _
        csNeg.myStr(ReporteGestionPTRobo_MarcaVehi) & "," & _
        csNeg.myStr(ReporteGestionPTRobo_SubMarcaVehi) & "," & _
        ReporteGestionPTRobo_ModeloVehi & "," & _
        csNeg.myStr(ReporteGestionPTRobo_ColorVehi) & "," & _
        csNeg.myStr(ReporteGestionPTRobo_PlacasVehi) & "," & _
        csNeg.myStr(ReporteGestionPTRobo_SerieVehi) & "," & _
        csNeg.myStr(ReporteGestionInfo_correo) & "," & _
        csNeg.myStr(ReporteGestionInfo_Cel) & "," & _
        csNeg.myStr(ReporteGestionPTRobo_Descripcion) & "," & _
        GestionGeneral_Llama & "," & _
        Reporte_MedioContacto & ",'" & _
        NomEnt & "','" & _
        ladaEnt & "','" & _
        telEnt & "'"

        If csSQLsvr.EjecutarSP(comando, conBaseDatos) = BaseDatosSQL.Estatus.OK Then
            update_ReporteGestionGeneralPagoxEvento = True
        Else
            update_ReporteGestionGeneralPagoxEvento = False
        End If

        'Insert_BitacoraCambios(NoGestion, "Se realizaron cambios en los datos de Gestion por Perdida Total", clvUsuario)


        Return update_ReporteGestionGeneralPagoxEvento
    End Function
    Public Function select_PagoEvento(ByVal NoGestion As String) As DataSet

        ' descomponemos el No dado en los datos correctos:
        Dim sGestion As String = NoGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)

        Dim comando As String = "exec buscaPagoEvento_sp " & p_Anio & "," & p_Cliente & "," & p_tipo & "," & p_estado & "," & p_consec
        Dim dsExpediente As New DataSet
        dsExpediente = csSQLsvr.QueryDataSet(comando, conBaseDatos)
        select_PagoEvento = dsExpediente
        Return select_PagoEvento

    End Function

    Public Function InsertEnvioSms(ByVal servicio As String, ByVal Etapa As Integer) As DataTable
        Dim conexion As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("ConnStringSQL"))
        Dim objTransac As SqlTransaction = Nothing
        Dim dtLayOutOrden = New DataTable()


        Dim dtExiste As New DataTable
        Dim existe As Integer

        dtExiste = ValidaEnvioSms(servicio, Etapa)

        If dtExiste.Rows.Count <> 0 Then
            Dim dr As DataRow

            For Each dr In dtExiste.Rows
                existe = dr("Existe")
            Next

        End If

        If existe = 0 Then
            Try
                conexion.Open()
                Dim comman As New SqlCommand("InsertaEtapasSMS", conexion)
                objTransac = conexion.BeginTransaction
                comman.CommandType = CommandType.StoredProcedure

                comman.Parameters.AddWithValue("@Servicio", servicio)
                comman.Parameters.AddWithValue("@Etapa", Etapa)

                With comman
                    .Transaction = objTransac
                    .ExecuteNonQuery() ' ejecutar  
                End With
                comman.Parameters.Clear()

                objTransac.Commit()

            Catch ex As DataException

                objTransac.Rollback()
                'inLogger.insError("Error en metodo: insGastos()", ex.Message)
                'Return False
            Catch ex As Exception

                objTransac.Rollback()
                'inLogger.insError("Error en metodo: insGastos()", ex.Message)
                'Return False
            Finally
                conexion.Close()
                conexion.Dispose()
            End Try
        Else
            dtExiste.TableName = "Existe"
            dtLayOutOrden = dtExiste
        End If
        Return dtLayOutOrden
    End Function

    Public Function ValidaEnvioSms(ByVal servicio As String, ByVal Etapa As Integer) As DataTable

        Dim comando As String = "ValidaEtapasSMS '" & servicio & "', " & Etapa

        ValidaEnvioSms = csSQLsvr.EjecutarSPDataset(comando, conBaseDatos).Tables(0)

        Return ValidaEnvioSms
    End Function


 Public Function FormatoFecha(ByVal fecha As String) As String

        FormatoFecha = fecha
        If System.Configuration.ConfigurationManager.AppSettings("ConnStringSQL").ToString.Contains("192.168.23.107") Then
            FormatoFecha = CDate(fecha).ToString("dd/MM/yyyy")
        Else
            FormatoFecha = CDate(fecha).ToString("MM/dd/yyyy")
        End If

        Return FormatoFecha
    End Function

#Region "Remesas"

    Public Function SelectServicio(ByVal remesa As String) As List(Of String)
        Dim servicios As New List(Of String)

        Dim comando As String = "Remesa_SelectServicio_Sp '" & remesa & "'"
        Dim ds As New DataSet
        Dim dt As DataTable
        ds = csSQLsvr.EjecutarSPDataset(comando, conBaseDatos)
        dt = ds.Tables(0)

        If dt.Rows.Count <> 0 Then
            Dim dr As DataRow

            For Each dr In dt.Rows
                servicios.Add(dr("Servicio"))
            Next

        End If

        Return servicios
    End Function


    Public Function GestoresEdos(ByVal remesa As String) As DataTable

        Dim comando As String = "exec RemesaGestoresEstados_sp  '" & remesa & "'"
       
        GestoresEdos = csSQLsvr.QueryDataDatable(comando, conBaseDatos)
        Return GestoresEdos

    End Function


    Public Function RemesaCargaAsignaciones(ByVal sQuery As String) As DataTable

        Dim comando As String = String.Empty
        comando = "exec Select_RemesasAsignacion_Sp '" & sQuery & "'"

        RemesaCargaAsignaciones = csSQLsvr.QueryDataSet(comando, conBaseDatos).Tables(0)
        Return RemesaCargaAsignaciones

    End Function

#End Region


End Class


Public Class Archivo
    Public Sub New(id As Integer, nombre As String, length As Integer)
        Me.Id = id
        Me.Nombre = nombre
        Me.Length = length
    End Sub
    Public Property Id() As Integer
        Get
            Return m_Id
        End Get
        Set(value As Integer)
            m_Id = value
        End Set
    End Property
    Private m_Id As Integer
    Public Property Length() As Integer
        Get
            Return m_Length
        End Get
        Set(value As Integer)
            m_Length = value
        End Set
    End Property
    Private m_Length As Integer
    Public Property Nombre() As String
        Get
            Return m_Nombre
        End Get
        Set(value As String)
            m_Nombre = value
        End Set
    End Property
    Private m_Nombre As String

    Public Property ContenidoArchivo() As Byte()
        Get
            Return m_ContenidoArchivo
        End Get
        Set(value As Byte())
            m_ContenidoArchivo = value
        End Set
    End Property
    Private m_ContenidoArchivo As Byte()

End Class
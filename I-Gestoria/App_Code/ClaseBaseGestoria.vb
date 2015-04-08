Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

Public Class ClaseBaseGestoria

    Dim ConnectionString As String = System.Configuration.ConfigurationManager.AppSettings("ConnStringSQL")

    Public Sub Update_EntregaExpedientesGestoria(ByVal Reporte_anio As String, ByVal Reporte_cliente As String, ByVal Reporte_Tipo As String, ByVal Reporte_clvEstado As String, ByVal Reporte_Numero As String, ByVal EntregaExpediente_Comentario As String, ByVal EntregaExpediente_usuario As String, ByVal EntregaExpediente_fecha As String, ByVal EntregaExpediente_Verificado As String, ByVal EntregaExpediente_fechaVer As String, ByVal EntregaExpediente_tipoEntre As String, ByVal EntregaExpediente_Guia As String, ByVal EntregaExpediente_consec As String)
        Dim conn As New SqlConnection(ConnectionString)
        Dim cmd As New SqlCommand("usp_EntregaExpedientesGestoriaUpdate", conn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Reporte_anio", Reporte_anio)
        cmd.Parameters.AddWithValue("@Reporte_cliente", Reporte_cliente)
        cmd.Parameters.AddWithValue("@Reporte_Tipo", Reporte_Tipo)
        cmd.Parameters.AddWithValue("@Reporte_clvEstado", Reporte_clvEstado)
        cmd.Parameters.AddWithValue("@Reporte_Numero", Reporte_Numero)
        cmd.Parameters.AddWithValue("@EntregaExpediente_Comentario", EntregaExpediente_Comentario)
        cmd.Parameters.AddWithValue("@EntregaExpediente_usuario", EntregaExpediente_usuario)
        cmd.Parameters.AddWithValue("@EntregaExpediente_fecha", EntregaExpediente_fecha)
        cmd.Parameters.AddWithValue("@EntregaExpediente_Verificado", EntregaExpediente_Verificado)
        cmd.Parameters.AddWithValue("@EntregaExpediente_fechaVer", EntregaExpediente_fechaVer)
        cmd.Parameters.AddWithValue("@EntregaExpediente_tipoEntre", EntregaExpediente_tipoEntre)
        cmd.Parameters.AddWithValue("@EntregaExpediente_Guia", EntregaExpediente_Guia)
        cmd.Parameters.AddWithValue("@EntregaExpediente_consec", EntregaExpediente_consec)

        Try
            conn.Open()
            cmd.ExecuteNonQuery()
        Catch
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Dispose()
            cmd.Dispose()
        End Try
    End Sub


    Public Sub Insert_EntregaExpedientesGestoria(ByVal Reporte_anio As String, ByVal Reporte_cliente As String, ByVal Reporte_Tipo As String, ByVal Reporte_clvEstado As String, ByVal Reporte_Numero As String, ByVal EntregaExpediente_Comentario As String, ByVal EntregaExpediente_usuario As String, ByVal EntregaExpediente_fecha As String, ByVal EntregaExpediente_Verificado As String, ByVal EntregaExpediente_fechaVer As String, ByVal EntregaExpediente_tipoEntre As String, ByVal EntregaExpediente_Guia As String)
        Dim conn As New SqlConnection(ConnectionString)
        Dim cmd As New SqlCommand("usp_EntregaExpedientesGestoriaInsert ", conn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Reporte_anio", Reporte_anio)
        cmd.Parameters.AddWithValue("@Reporte_cliente", Reporte_cliente)
        cmd.Parameters.AddWithValue("@Reporte_Tipo", Reporte_Tipo)
        cmd.Parameters.AddWithValue("@Reporte_clvEstado", Reporte_clvEstado)
        cmd.Parameters.AddWithValue("@Reporte_Numero", Reporte_Numero)
        cmd.Parameters.AddWithValue("@EntregaExpediente_Comentario", EntregaExpediente_Comentario)
        cmd.Parameters.AddWithValue("@EntregaExpediente_usuario", EntregaExpediente_usuario)
        cmd.Parameters.AddWithValue("@EntregaExpediente_fecha", EntregaExpediente_fecha)
        cmd.Parameters.AddWithValue("@EntregaExpediente_Verificado", EntregaExpediente_Verificado)
        cmd.Parameters.AddWithValue("@EntregaExpediente_fechaVer", EntregaExpediente_fechaVer)
        cmd.Parameters.AddWithValue("@EntregaExpediente_tipoEntre", EntregaExpediente_tipoEntre)
        cmd.Parameters.AddWithValue("@EntregaExpediente_Guia", EntregaExpediente_Guia)


        Try
            conn.Open()
            cmd.ExecuteNonQuery()
        Catch
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Dispose()
            cmd.Dispose()
        End Try
    End Sub


    Public Function SelectRecords_EntregaExpedientesGestoria(ByVal EntregaExpediente_consec As Integer) As DataSet
        Dim conn As New SqlConnection(ConnectionString)
        Dim cmd As New SqlDataAdapter("usp_EntregaExpedientesGestoriaSelect " & EntregaExpediente_consec, conn)
        Dim dts As New DataSet()

        Try
            conn.Open()
            cmd.Fill(dts)
            Return dts
        Catch

        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Dispose()
            cmd.Dispose()
        End Try
    End Function


    Public Function SelectRecords_EntregaExpedientesSinVerificar() As DataSet
        Dim conn As New SqlConnection(ConnectionString)
        Dim cmd As New SqlDataAdapter("CargaExpedientesRecibidosSinVerificar ", conn)
        Dim dts As New DataSet()

        Try
            conn.Open()
            cmd.Fill(dts)
            Return dts
            conn.Close()
        Catch

        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Dispose()
            cmd.Dispose()
        End Try
    End Function


    Public Function SelectRecords_reportesGestion(ByVal Reporte_anio As String, ByVal Reporte_cliente As String, ByVal Reporte_Tipo As String, ByVal Reporte_clvEstado As String, ByVal Reporte_Numero As String) As DataSet
        Dim conn As New SqlConnection(ConnectionString)
        Dim cmd As New SqlDataAdapter("usp_ReporteGestionSelect " & Reporte_anio & "," & Reporte_cliente & "," & Reporte_Tipo & "," & Reporte_clvEstado & "," & Reporte_Numero, conn)
        Dim dts As New DataSet()

        Try
            conn.Open()
            cmd.Fill(dts)
            Return dts
        Catch

        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Dispose()
            cmd.Dispose()
        End Try
    End Function

    Public Function Insert_ResultadoLlamadasGestoria_tbl(ByVal Reporte_anio As String, ByVal Reporte_cliente As String, ByVal Reporte_Tipo As String, ByVal Reporte_clvEstado As String, ByVal Reporte_Numero As String, ByVal CatTipoLlamada_cvLlamada As String, ByVal CatResLlamadas_ClvResultado As String, ByVal Etapa_clvEtapa As String, ByVal catRechazo_clvRechazo As String, ByVal ResLlamadas_FechaAlta As String, ByVal ResLlamadas_Usuario As String) As Integer

        Dim ds As New DataSet
        Dim adapter As SqlDataAdapter = New SqlDataAdapter
        Dim conn As New SqlConnection(ConnectionString)
        Dim cmd As New SqlCommand("usp_ResultadoLlamadasGestoria_tblInsert", conn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Reporte_anio", Reporte_anio)
        cmd.Parameters.AddWithValue("@Reporte_cliente", Reporte_cliente)
        cmd.Parameters.AddWithValue("@Reporte_Tipo", Reporte_Tipo)
        cmd.Parameters.AddWithValue("@Reporte_clvEstado", Reporte_clvEstado)
        cmd.Parameters.AddWithValue("@Reporte_Numero", Reporte_Numero)
        cmd.Parameters.AddWithValue("@CatTipoLlamada_cvLlamada", CatTipoLlamada_cvLlamada)
        cmd.Parameters.AddWithValue("@CatResLlamadas_ClvResultado", CatResLlamadas_ClvResultado)
        cmd.Parameters.AddWithValue("@Etapa_clvEtapa", Etapa_clvEtapa)
        cmd.Parameters.AddWithValue("@catRechazo_clvRechazo", catRechazo_clvRechazo)
        cmd.Parameters.AddWithValue("@ResLlamadas_FechaAlta", Format(Now(), "MM/dd/yyyy HH:mm:ss"))
        cmd.Parameters.AddWithValue("@ResLlamadas_Usuario", ResLlamadas_Usuario)

        Try
            conn.Open()
            adapter.SelectCommand = cmd
            adapter.SelectCommand.CommandTimeout = 500
            adapter.Fill(ds)
            Insert_ResultadoLlamadasGestoria_tbl = ds.Tables(0).Rows.Count
            'Return Insert_ResultadoLlamadasGestoria_tbl
        Catch
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Dispose()
            cmd.Dispose()
            'ds.Clear()
            'ds.Dispose()
        End Try
    End Function

    Public Function Insert_Cita(ByVal Reporte_anio As String, ByVal Reporte_cliente As String, ByVal Reporte_Tipo As String, ByVal Reporte_clvEstado As String, ByVal Reporte_Numero As String, ByVal Subject As String, ByVal Start As DateTime, ByVal Description As String, ByVal MailCliente As String) As Integer

        Dim ds As New DataSet
        Dim adapter As SqlDataAdapter = New SqlDataAdapter
        Dim conn As New SqlConnection(ConnectionString)
        Dim cmd As New SqlCommand("sp_InsertCita_Appointments", conn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Reporte_anio", Reporte_anio)
        cmd.Parameters.AddWithValue("@Reporte_cliente", Reporte_cliente)
        cmd.Parameters.AddWithValue("@Reporte_Tipo", Reporte_Tipo)
        cmd.Parameters.AddWithValue("@Reporte_clvEstado", Reporte_clvEstado)
        cmd.Parameters.AddWithValue("@Reporte_Numero", Reporte_Numero)
        cmd.Parameters.AddWithValue("@Subject", Subject)
        cmd.Parameters.AddWithValue("@Start", Start)
        cmd.Parameters.AddWithValue("@Description", Description)
        cmd.Parameters.AddWithValue("@MailCliente", MailCliente)

        Try
            conn.Open()
            adapter.SelectCommand = cmd
            adapter.SelectCommand.CommandTimeout = 500
            adapter.Fill(ds)
            Insert_Cita = ds.Tables(0).Rows.Count
            'Return Insert_Cita
        Catch
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Dispose()
            cmd.Dispose()
            'ds.Clear()
            'ds.Dispose()
        End Try
    End Function

    Public Function Cancela_Servicio(ByVal Reporte_anio As String, ByVal Reporte_cliente As String, ByVal Reporte_Tipo As String, ByVal Reporte_clvEstado As String, ByVal Reporte_Numero As String, ByVal CausaCancela As String, ByVal Usuario As String) As Integer

        Dim ds As New DataSet
        Dim adapter As SqlDataAdapter = New SqlDataAdapter
        Dim conn As New SqlConnection(ConnectionString)
        Dim cmd As New SqlCommand("sp_Update_CancelaServicio", conn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Reporte_anio", Reporte_anio)
        cmd.Parameters.AddWithValue("@Reporte_cliente", Reporte_cliente)
        cmd.Parameters.AddWithValue("@Reporte_Tipo", Reporte_Tipo)
        cmd.Parameters.AddWithValue("@Reporte_clvEstado", Reporte_clvEstado)
        cmd.Parameters.AddWithValue("@Reporte_Numero", Reporte_Numero)
        cmd.Parameters.AddWithValue("@CausaCancela", CausaCancela)
        cmd.Parameters.AddWithValue("@Usuario", Usuario)

        Try
            conn.Open()
            adapter.SelectCommand = cmd
            adapter.SelectCommand.CommandTimeout = 500
            adapter.Fill(ds)
            Cancela_Servicio = ds.Tables(0).Rows.Count
            'Return Insert_ResultadoLlamadasGestoria_tbl
        Catch
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Dispose()
            cmd.Dispose()
            'ds.Clear()
            'ds.Dispose()
        End Try

    End Function

    Public Sub Insert_ProximaAccion(ByVal Reporte_anio As String, ByVal Reporte_cliente As String, ByVal Reporte_Tipo As String, ByVal Reporte_clvEstado As String, ByVal Reporte_Numero As String, ByVal RegistroAccion_Etapa As String, ByVal RegistroAccion_TipoPersona As String, ByVal RegistroAccion_AccionSiguiente As String, ByVal RegistroAccion_usuario As String)
        Dim conn As New SqlConnection(ConnectionString)
        Dim cmd As New SqlCommand("Insert_RegistroProximaAccionGestoria_tbl", conn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Reporte_anio", Reporte_anio)
        cmd.Parameters.AddWithValue("@Reporte_cliente", Reporte_cliente)
        cmd.Parameters.AddWithValue("@Reporte_Tipo", Reporte_Tipo)
        cmd.Parameters.AddWithValue("@Reporte_clvEstado", Reporte_clvEstado)
        cmd.Parameters.AddWithValue("@Reporte_Numero", Reporte_Numero)
        cmd.Parameters.AddWithValue("@RegistroAccion_Etapa", RegistroAccion_Etapa)
        cmd.Parameters.AddWithValue("@RegistroAccion_TipoPersona", RegistroAccion_TipoPersona)
        cmd.Parameters.AddWithValue("@RegistroAccion_AccionSiguiente", RegistroAccion_AccionSiguiente)
        cmd.Parameters.AddWithValue("@RegistroAccion_usuario", RegistroAccion_usuario)


        Try
            conn.Open()
            cmd.ExecuteNonQuery()
        Catch
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Dispose()
            cmd.Dispose()
        End Try
    End Sub

    Public Sub Insert_EnvioEmailGestoria(ByVal Reporte_anio As String, ByVal Reporte_cliente As String, ByVal Reporte_Tipo As String, ByVal Reporte_clvEstado As String, ByVal Reporte_Numero As String, ByVal EnvioMail_email As String, ByVal EnvioMail_etapa As String)
        Dim conn As New SqlConnection(ConnectionString)
        Dim cmd As New SqlCommand("Insert_EnvioEmailGestoria_tbl", conn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Reporte_anio", Reporte_anio)
        cmd.Parameters.AddWithValue("@Reporte_cliente", Reporte_cliente)
        cmd.Parameters.AddWithValue("@Reporte_Tipo", Reporte_Tipo)
        cmd.Parameters.AddWithValue("@Reporte_clvEstado", Reporte_clvEstado)
        cmd.Parameters.AddWithValue("@Reporte_Numero", Reporte_Numero)
        cmd.Parameters.AddWithValue("@EnvioMail_email", EnvioMail_email)
        cmd.Parameters.AddWithValue("@EnvioMail_etapa", EnvioMail_etapa) ' la etapa ser refiere en que parte se envia el email: Etapa=1 cuando sea en la parte de 1° contacto, Etapa=2 cuando sea rechazo de documentos, Etapa=3 cuando se haga el termino del servicio
        Try
            conn.Open()
            cmd.ExecuteNonQuery()
        Catch
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Dispose()
            cmd.Dispose()
        End Try
    End Sub

    Public Function Update_AsignaGestor(ByVal Reporte_anio As String, ByVal Reporte_cliente As String, ByVal Reporte_Tipo As String, ByVal Reporte_clvEstado As String, ByVal Reporte_Numero As String, ByVal rfc As String) As Integer

        Dim ds As New DataSet
        Dim adapter As SqlDataAdapter = New SqlDataAdapter
        Dim conn As New SqlConnection(ConnectionString)
        Dim cmd As New SqlCommand("update_AsignaGestorPC", conn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Reporte_anio", Reporte_anio)
        cmd.Parameters.AddWithValue("@Reporte_cliente", Reporte_cliente)
        cmd.Parameters.AddWithValue("@Reporte_Tipo", Reporte_Tipo)
        cmd.Parameters.AddWithValue("@Reporte_clvEstado", Reporte_clvEstado)
        cmd.Parameters.AddWithValue("@Reporte_Numero", Reporte_Numero)
        'cmd.Parameters.AddWithValue("@aviso", Format(Now(), "MM/dd/yyyy HH:mm"))
        cmd.Parameters.AddWithValue("@RFC", rfc)

        Try
            conn.Open()
            adapter.SelectCommand = cmd
            adapter.SelectCommand.CommandTimeout = 500
            adapter.Fill(ds)
            'Update_AsignaGestor = ds.Tables(0).Rows.Count
            'Return Insert_ResultadoLlamadasGestoria_tbl

        Catch
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Dispose()
            cmd.Dispose()
            'ds.Clear()
            'ds.Dispose()
        End Try

    End Function

    Public Function Insert_CitaGestor(ByVal Reporte_anio As String, ByVal Reporte_cliente As String, ByVal Reporte_Tipo As String, ByVal Reporte_clvEstado As String, ByVal Reporte_Numero As String, ByVal Subject As String, ByVal Start As DateTime, ByVal Description As String, ByVal MailGestor As String, ByVal MailCliente As String) As Integer

        Dim ds As New DataSet
        Dim adapter As SqlDataAdapter = New SqlDataAdapter
        Dim conn As New SqlConnection(ConnectionString)
        Dim cmd As New SqlCommand("sp_InsertCita_Appointments2etapa", conn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Reporte_anio", Reporte_anio)
        cmd.Parameters.AddWithValue("@Reporte_cliente", Reporte_cliente)
        cmd.Parameters.AddWithValue("@Reporte_Tipo", Reporte_Tipo)
        cmd.Parameters.AddWithValue("@Reporte_clvEstado", Reporte_clvEstado)
        cmd.Parameters.AddWithValue("@Reporte_Numero", Reporte_Numero)
        cmd.Parameters.AddWithValue("@Subject", Subject)
        cmd.Parameters.AddWithValue("@Start", Start)
        cmd.Parameters.AddWithValue("@Description", Description)
        cmd.Parameters.AddWithValue("@MailGestor", MailGestor)
        cmd.Parameters.AddWithValue("@MailCliente", MailCliente)

        Try
            conn.Open()
            adapter.SelectCommand = cmd
            adapter.SelectCommand.CommandTimeout = 500
            adapter.Fill(ds)
            Insert_CitaGestor = ds.Tables(0).Rows.Count
            'Return Insert_ResultadoLlamadasGestoria_tbl
        Catch
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Dispose()
            cmd.Dispose()
            'ds.Clear()
            'ds.Dispose()
        End Try
    End Function

    Public Function Insert_SeguimientosTramiteGestor_tbl(ByVal Reporte_anio As String, ByVal Reporte_cliente As String, ByVal Reporte_Tipo As String, ByVal Reporte_clvEstado As String, ByVal Reporte_Numero As String, ByVal SegTramite_StatusTamite As String, ByVal SegTramite_respTramite As String, ByVal SegTramite_FechaProxLlamada As String) As Integer

        Dim ds As New DataSet
        Dim adapter As SqlDataAdapter = New SqlDataAdapter
        Dim conn As New SqlConnection(ConnectionString)
        Dim cmd As New SqlCommand("usp_SeguimientosTramiteGestor_tblInsert", conn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Reporte_anio", Reporte_anio)
        cmd.Parameters.AddWithValue("@Reporte_cliente", Reporte_cliente)
        cmd.Parameters.AddWithValue("@Reporte_Tipo", Reporte_Tipo)
        cmd.Parameters.AddWithValue("@Reporte_clvEstado", Reporte_clvEstado)
        cmd.Parameters.AddWithValue("@Reporte_Numero", Reporte_Numero)
        cmd.Parameters.AddWithValue("@SegTramite_StatusTamite", SegTramite_StatusTamite)
        cmd.Parameters.AddWithValue("@SegTramite_respTramite", SegTramite_respTramite)
        cmd.Parameters.AddWithValue("@SegTramite_FechaProxLlamada", SegTramite_FechaProxLlamada)


        Try
            conn.Open()
            adapter.SelectCommand = cmd
            adapter.SelectCommand.CommandTimeout = 500
            adapter.Fill(ds)
            Insert_SeguimientosTramiteGestor_tbl = ds.Tables(0).Rows.Count
            'Return Insert_ResultadoLlamadasGestoria_tbl
        Catch
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Dispose()
            cmd.Dispose()
            ds.Clear()
            ds.Dispose()
        End Try
    End Function


    Public Sub InsertDatosSeguimiento(ByVal p_Anio As String, ByVal p_Cliente As String, ByVal p_tipo As String, ByVal p_estado As String, ByVal p_consec As String, ByVal IFE As String, ByVal Acuerdo As String, ByVal usuario As String)
        Dim conn As New SqlConnection(ConnectionString)
        Dim cmd As New SqlCommand("Insert into DatosSeguimientoCliente_tbl values ('" + p_Anio + "','" + p_Cliente + "','" + p_tipo + "','" + p_estado + "' ,'" + p_consec + "' ,'" + IFE + "','" + Acuerdo + "','" + usuario + "',GETDATE()) ", conn)
        Try
            conn.Open()
            cmd.ExecuteNonQuery()
        Catch
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Dispose()
            cmd.Dispose()
        End Try
    End Sub

    Public Function LlenaBitacoraGuia(ByVal NoGestion As String) As DataTable


        Dim sGestion As String = NoGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim Reporte_anio As String = Mid(sGestion, 1, 4)
        Dim Reporte_cliente As String = Mid(sGestion, 5, 2)
        Dim Reporte_Tipo As String = Mid(sGestion, 7, 2)
        Dim Reporte_clvEstado As String = Mid(sGestion, 9, 2)
        Dim Reporte_Numero As String = Mid(sGestion, 11, nLargo)

        Dim ds As New DataSet
        Dim dt As DataTable
        Dim adapter As SqlDataAdapter = New SqlDataAdapter
        Dim conn As New SqlConnection(ConnectionString)
        Dim cmd As New SqlCommand("selectBitacoraGuia_sp", conn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Reporte_anio", Reporte_anio)
        cmd.Parameters.AddWithValue("@Reporte_cliente", Reporte_cliente)
        cmd.Parameters.AddWithValue("@Reporte_Tipo", Reporte_Tipo)
        cmd.Parameters.AddWithValue("@Reporte_clvEstado", Reporte_clvEstado)
        cmd.Parameters.AddWithValue("@Reporte_Numero", Reporte_Numero)


        Try
            conn.Open()
            adapter.SelectCommand = cmd
            adapter.SelectCommand.CommandTimeout = 500
            adapter.Fill(ds)
            dt = ds.Tables(0)

            Return dt
        Catch
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Dispose()
            cmd.Dispose()
            'ds.Clear()
            'ds.Dispose()
        End Try

    End Function

    Public Function Select_DetalleEntrega_Sp(ByVal NoGestion As String) As DataTable


        Dim sGestion As String = NoGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim Reporte_anio As String = Mid(sGestion, 1, 4)
        Dim Reporte_cliente As String = Mid(sGestion, 5, 2)
        Dim Reporte_Tipo As String = Mid(sGestion, 7, 2)
        Dim Reporte_clvEstado As String = Mid(sGestion, 9, 2)
        Dim Reporte_Numero As String = Mid(sGestion, 11, nLargo)

        Dim ds As New DataSet
        Dim dt As DataTable
        Dim adapter As SqlDataAdapter = New SqlDataAdapter
        Dim conn As New SqlConnection(ConnectionString)
        Dim cmd As New SqlCommand("Select_DetalleEntrega_Sp", conn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Reporte_anio", CInt(Reporte_anio))
        cmd.Parameters.AddWithValue("@Reporte_cliente", CInt(Reporte_cliente))
        cmd.Parameters.AddWithValue("@Reporte_Tipo", CInt(Reporte_Tipo))
        cmd.Parameters.AddWithValue("@Reporte_clvEstado", CInt(Reporte_clvEstado))
        cmd.Parameters.AddWithValue("@Reporte_Numero", CInt(Reporte_Numero))

        Try
            conn.Open()
            adapter.SelectCommand = cmd
            adapter.SelectCommand.CommandTimeout = 500
            adapter.Fill(ds)
            dt = ds.Tables(0)

            Return dt
        Catch
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Dispose()
            cmd.Dispose()
            'ds.Clear()
            'ds.Dispose()
        End Try

    End Function

    Public Function Select_DetalleDigitalizacion(ByVal NoGestion As String) As DataTable


        Dim sGestion As String = NoGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim Reporte_anio As String = Mid(sGestion, 1, 4)
        Dim Reporte_cliente As String = Mid(sGestion, 5, 2)
        Dim Reporte_Tipo As String = Mid(sGestion, 7, 2)
        Dim Reporte_clvEstado As String = Mid(sGestion, 9, 2)
        Dim Reporte_Numero As String = Mid(sGestion, 11, nLargo)

        Dim ds As New DataSet
        Dim dt As DataTable
        Dim adapter As SqlDataAdapter = New SqlDataAdapter
        Dim conn As New SqlConnection(ConnectionString)
        Dim cmd As New SqlCommand("Select_DetalleDigitalizacion", conn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Reporte_anio", CInt(Reporte_anio))
        cmd.Parameters.AddWithValue("@Reporte_cliente", CInt(Reporte_cliente))
        cmd.Parameters.AddWithValue("@Reporte_Tipo", CInt(Reporte_Tipo))
        cmd.Parameters.AddWithValue("@Reporte_clvEstado", CInt(Reporte_clvEstado))
        cmd.Parameters.AddWithValue("@Reporte_Numero", CInt(Reporte_Numero))


        Try
            conn.Open()
            adapter.SelectCommand = cmd
            adapter.SelectCommand.CommandTimeout = 500
            adapter.Fill(ds)
            dt = ds.Tables(0)

            Return dt
        Catch
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Dispose()
            cmd.Dispose()
            'ds.Clear()
            'ds.Dispose()
        End Try

    End Function

    Public Function SelectDetalleVerificacion(ByVal NoGestion As String) As DataTable


        Dim sGestion As String = NoGestion.Trim
        Dim nLargo As Integer = Len(sGestion)
        Dim Reporte_anio As String = Mid(sGestion, 1, 4)
        Dim Reporte_cliente As String = Mid(sGestion, 5, 2)
        Dim Reporte_Tipo As String = Mid(sGestion, 7, 2)
        Dim Reporte_clvEstado As String = Mid(sGestion, 9, 2)
        Dim Reporte_Numero As String = Mid(sGestion, 11, nLargo)

        Dim ds As New DataSet
        Dim dt As DataTable
        Dim adapter As SqlDataAdapter = New SqlDataAdapter
        Dim conn As New SqlConnection(ConnectionString)
        Dim cmd As New SqlCommand("DetalleVerificacion_sp", conn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Reporte_anio", CInt(Reporte_anio))
        cmd.Parameters.AddWithValue("@Reporte_cliente", CInt(Reporte_cliente))
        cmd.Parameters.AddWithValue("@Reporte_Tipo", CInt(Reporte_Tipo))
        cmd.Parameters.AddWithValue("@Reporte_clvEstado", CInt(Reporte_clvEstado))
        cmd.Parameters.AddWithValue("@Reporte_Numero", CInt(Reporte_Numero))


        Try
            conn.Open()
            adapter.SelectCommand = cmd
            adapter.SelectCommand.CommandTimeout = 500
            adapter.Fill(ds)
            dt = ds.Tables(0)

            Return dt
        Catch
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Dispose()
            cmd.Dispose()
            'ds.Clear()
            'ds.Dispose()
        End Try

    End Function

    Public Function Consultar_Servicios_Filtrados(usr As String, s As CBusqueda_Servicios) As DataTable
        'Se crean objetos de Resultado2 y para llamar ws

        Dim ds As New DataSet
        Dim dt As DataTable
        Dim adapter As SqlDataAdapter = New SqlDataAdapter
        Dim conn As New SqlConnection(ConnectionString)
        Dim comando As New SqlCommand("Select_Servicios", conn)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@Cliente", (s.Cliente))
        comando.Parameters.AddWithValue("@Estado", (s.Estado))
        comando.Parameters.AddWithValue("@Municipio", (s.Municipio))
        comando.Parameters.AddWithValue("@TipoServicio", (s.Servicio))

        Try
            conn.Open()
            adapter.SelectCommand = comando
            adapter.SelectCommand.CommandTimeout = 5000
            adapter.Fill(ds)
            dt = ds.Tables(0)

            Return dt
        Catch
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Dispose()
            comando.Dispose()
            'ds.Clear()
            'ds.Dispose()
        End Try
    End Function


    Public Function insRemesa(ByVal remesa As CNumero_Remesa) As Boolean


        Dim conn As New SqlConnection(ConnectionString)
        Dim objTransac As SqlTransaction = Nothing

        Try
            conn.Open()

            Dim command As New SqlCommand("spr_Ins_Remesas", conn)
            objTransac = conn.BeginTransaction
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.AddWithValue("@strNumServicio", remesa.NumServicio)
            command.Parameters.AddWithValue("@Reporte_Remesa", remesa.NumRemesa)


            With command
                .Transaction = objTransac
                .ExecuteNonQuery()
            End With

            command.Parameters.Clear()
            objTransac.Commit()
            Return True
        Catch ex As DataException
            objTransac.Rollback()
            Return False
        Catch ex As Exception
            objTransac.Rollback()
            Return False
        Finally
            conn.Close()
            conn.Dispose()
        End Try

    End Function

    Public Function genRemesa(ByVal remesa As CNumero_Remesa) As String

        Dim ds As New DataSet
        Dim dt As DataTable
        Dim adapter As SqlDataAdapter = New SqlDataAdapter
        Dim conn As New SqlConnection(ConnectionString)
        Dim objTransac As SqlTransaction = Nothing


        Try
            conn.Open()

            Dim command As New SqlCommand("spr_Gen_Remesas", conn)
            objTransac = conn.BeginTransaction
            command.CommandType = CommandType.StoredProcedure


            command.Parameters.AddWithValue("@dtmFechaAlta", remesa.Fecha)
            command.Parameters.AddWithValue("@strUsuario", remesa.Usuario)
            command.Parameters.AddWithValue("@intEtapa", remesa.Etapa)



            With command
                .Transaction = objTransac
                '.ExecuteNonQuery()
            End With

            Dim numRemesa As String = command.ExecuteScalar()

            'adapter.SelectCommand = command
            'adapter.SelectCommand.CommandTimeout = 5000
            'adapter.Fill(ds)
            'dt = ds.Tables(0)

            command.Parameters.Clear()
            objTransac.Commit()
            'Return dt.Rows(0)
            Return numRemesa

        Catch ex As DataException
            objTransac.Rollback()

        Catch ex As Exception
            objTransac.Rollback()

        Finally
            conn.Close()
            conn.Dispose()
        End Try

    End Function


End Class

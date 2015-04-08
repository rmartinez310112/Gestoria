Imports Microsoft.VisualBasic
Imports Acceso_a_Datos
Imports System.Data
Imports System.Data.SqlClient

Public Class Datos_Fondos

#Region "Ingreso Fondos"

    Public Function Insertar_Fondos_Ingreso(ByVal fondo As Ingreso_Fondos) As Resultado
        Dim res As New Resultado 'Objeto para resultados
        Dim datos As New ObjDatos 'Objetod para mandar llamar el ws
        'insertamos ingresos
        Try
            'Se crea parámetro y se manda llamar el ws

            'exec(sp_ServAutoSustituto)
            '@titular = 'Prueba',       seria = servicio.AsegNombre &" "& servicio.AsegMaterno &" "& servicio.AsegPaterno
            '@ClaPaisUbica = 0,         seria = 0
            '@claEstadoUbica = 33,      seria = servicio.RepIdEstado
            '@ClaMunicipioUbica = 35,   seria = servicio.RepIdMunicipio
            '@usuario = 'prueba',       seria = usr
            '@FechaSiniestro = '2013-12-26 00:00:00.000',  seria = format(now(), "MM-dd-yyyy HH:mm")
            '@ClaContrato = 1,          seria = servicio.IdAseguradora
            '@ClaServicio = ''          seria = servicio.IdEvento

            'datos.Consultar_Servcio_Asistencia_II("exec sp_ServAutoSustituto '" & servicio.AsegNombre & " " & servicio.AsegPaterno & " " & servicio.AsegMaterno & _
            '                                     "'," & 0 & "," & servicio.RepIdEstado & ", " & servicio.AsisIdMunicipio & ", '" & usr & "', '" & Format(Now(), "MM-dd-yyyy HH:mm") & "', " & servicio.IdAseguradora & ", " & servicio.IdEvento, res.DataTable)

            datos.sqlParameters.Add(New SqlParameter("@cliente_clvCliente", fondo.cliente_clvCliente))
            datos.sqlParameters.Add(New SqlParameter("@monto", fondo.monto))
            datos.sqlParameters.Add(New SqlParameter("@ref_bancaria", fondo.ref_bancaria))
            datos.sqlParameters.Add(New SqlParameter("@usuario", fondo.usuario))
            datos.sqlParameters.Add(New SqlParameter("@fechadeposito", fondo.fechadeposito))
            'datos.sqlParameters.Add(New SqlParameter("@fechaalta", fondo.fechaalta))

            datos.Comando_SP("Insert_Fondo_Ingreso @cliente_clvCliente,@monto,@ref_bancaria,@usuario,@fechadeposito", res.DataTable)

            ' Verifica si todo salió bien:
            'res.Dato =  'Aqui devuelve el Id
            'Dim NumServicio As String = res.DataTable.Rows(0)(0) & "" & res.DataTable.Rows(0)(1)

            ' Graba la auditoria
            'Auditoria.Registrar(usr, 55, res.Dato & "-" & NumServicio)
        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Datos_Fondos", "Insert_Fondo_Ingreso", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Consulta_Clientes(ByVal clave As Integer) As Resultado
        Dim res As New Resultado 'Objeto para resultados
        Dim datos As New ObjDatos 'Objetod para mandar llamar el ws
        'llenamos combobox
        Try

            datos.sqlParameters.Add(New SqlParameter("@cliente_clvCliente", clave))

            datos.Consulta_SP("Select_Clientes @cliente_clvCliente", res.DataTable)

            ' Verifica si todo salió bien:
            'res.Dato = res.DataTable.Rows(0)(0) 'Aqui devuelve el Id

        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Datos_Fondos.vb", "Select_Clientes", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Consultar_Fondo_Ingreso(ByVal monto As Retiro_Fondos) As Resultado
        Dim res As New Resultado 'Objeto para resultados
        Dim datos As New ObjDatos 'Objetod para mandar llamar el ws
        'llenamos data grid
        Try

            datos.sqlParameters.Add(New SqlParameter("@clave", monto.cliente_clvCliente))

            datos.Consulta_SP("Select_Fondo_Ingreso @clave", res.DataTable)

            ' Verifica si todo salió bien:
            'res.Dato = res.DataTable.Rows(0)(0) 'Aqui devuelve el Id

        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Datos_Fondos.vb", "Select_Fondo_Ingreso", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Consultar_MontoTotal_Ingreso_Retiro(ByVal monto As Retiro_Fondos) As Resultado
        Dim res As New Resultado 'Objeto para resultados
        Dim datos As New ObjDatos 'Objetod para mandar llamar el ws
        'llenamos data grid
        Try

            datos.sqlParameters.Add(New SqlParameter("@cliente_clvCliente", monto.cliente_clvCliente))
            datos.sqlParameters.Add(New SqlParameter("@reporte_anio", monto.Anio))
            datos.sqlParameters.Add(New SqlParameter("@reporte_cliente", monto.Cliente))
            datos.sqlParameters.Add(New SqlParameter("@reporte_tipo", monto.Tipo))
            datos.sqlParameters.Add(New SqlParameter("@reporte_clvestado", monto.ClvEstado))
            datos.sqlParameters.Add(New SqlParameter("@reporte_numero", monto.Numero))

            datos.Consulta_SP("Select_Monto_Cliente @cliente_clvCliente, @reporte_anio, @reporte_cliente, @reporte_tipo, @reporte_clvestado, @reporte_numero", res.DataTable)

            ' Verifica si todo salió bien:
            'res.Dato = res.DataTable.Rows(0)(0) 'Aqui devuelve el Id

        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Datos_Fondos.vb", "Select_Monto_Cliente", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

#End Region

#Region "Retiro Fondos"

    Public Function Insertar_Fondos_Retiro(ByVal fondo As Retiro_Fondos) As Resultado
        Dim res As New Resultado 'Objeto para resultados
        Dim datos As New ObjDatos 'Objetod para mandar llamar el ws
        'insertamos el retiro
        Try

            datos.sqlParameters.Add(New SqlParameter("@reporte_anio", fondo.Anio))
            datos.sqlParameters.Add(New SqlParameter("@reporte_cliente", fondo.Cliente))
            datos.sqlParameters.Add(New SqlParameter("@reporte_tipo", fondo.Tipo))
            datos.sqlParameters.Add(New SqlParameter("@reporte_clvestado", fondo.ClvEstado))
            datos.sqlParameters.Add(New SqlParameter("@reporte_numero", fondo.Numero))

            datos.sqlParameters.Add(New SqlParameter("@cliente_clvCliente", fondo.cliente_clvCliente))
            datos.sqlParameters.Add(New SqlParameter("@monto", fondo.monto))
            datos.sqlParameters.Add(New SqlParameter("@motivosalida", fondo.motivosalida))
            datos.sqlParameters.Add(New SqlParameter("@rfcgestor", fondo.rfcgestor))
            datos.sqlParameters.Add(New SqlParameter("@clavedeposito", fondo.clavedeposito))
            datos.sqlParameters.Add(New SqlParameter("@usuario", fondo.usuario))
            'datos.sqlParameters.Add(New SqlParameter("@fechadispersion", fondo.fechadispersion))
            'datos.sqlParameters.Add(New SqlParameter("@fechacontabilidad", fondo.fechacontabilidad))
            'datos.sqlParameters.Add(New SqlParameter("@numautorizadis", fondo.numautorizadis))
            'datos.sqlParameters.Add(New SqlParameter("@numautorizaconta", fondo.numautorizaconta))
            'datos.sqlParameters.Add(New SqlParameter("@usuariodipersion", fondo.usuariodipersion))
            'datos.sqlParameters.Add(New SqlParameter("@usuariocontabilidad", fondo.usuariocontabilidad))

            datos.Comando_SP("Insert_Fondo_Retiro @reporte_anio, @reporte_cliente, @reporte_tipo, @reporte_clvestado, @reporte_numero, @cliente_clvCliente, @monto, @motivosalida, @rfcgestor, @clavedeposito, @usuario", res.DataTable) ', @fechadispersion, @fechacontabilidad, @numautorizadis, @numautorizaconta, @usuariodipersion, @usuariocontabilidad", res.DataTable)

            ' Verifica si todo salió bien:
            'res.Dato =  'Aqui devuelve el Id
            'Dim NumServicio As String = res.DataTable.Rows(0)(0) & "" & res.DataTable.Rows(0)(1)

            ' Graba la auditoria
            'Auditoria.Registrar(usr, 55, res.Dato & "-" & NumServicio)
        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Datos_Fondos", "Insert_Fondo_Retiro", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Actualizar_Fondos_Retiro(ByVal fondo As Retiro_Fondos) As Resultado
        Dim res As New Resultado 'Objeto para resultados
        Dim datos As New ObjDatos 'Objetod para mandar llamar el ws
        'insertamos el retiro
        Try
            datos.sqlParameters.Add(New SqlParameter("@fase", fondo.fase))

            datos.sqlParameters.Add(New SqlParameter("@reporte_anio", fondo.Anio))
            datos.sqlParameters.Add(New SqlParameter("@reporte_cliente", fondo.Cliente))
            datos.sqlParameters.Add(New SqlParameter("@reporte_tipo", fondo.Tipo))
            datos.sqlParameters.Add(New SqlParameter("@reporte_clvestado", fondo.ClvEstado))
            datos.sqlParameters.Add(New SqlParameter("@reporte_numero", fondo.Numero))

            datos.sqlParameters.Add(New SqlParameter("@cliente_clvCliente", fondo.cliente_clvCliente))
            datos.sqlParameters.Add(New SqlParameter("@monto", fondo.monto))
            datos.sqlParameters.Add(New SqlParameter("@motivosalida", fondo.motivosalida))
            datos.sqlParameters.Add(New SqlParameter("@rfcgestor", fondo.rfcgestor))
            datos.sqlParameters.Add(New SqlParameter("@clavedeposito", fondo.clavedeposito))
            datos.sqlParameters.Add(New SqlParameter("@usuario", fondo.usuario))
            datos.sqlParameters.Add(New SqlParameter("@UsuarioAutoriza", fondo.usuarioAutoriza))

            datos.sqlParameters.Add(New SqlParameter("@fechadispersion", fondo.fechadispersion))
            datos.sqlParameters.Add(New SqlParameter("@fechacontabilidad", fondo.fechacontabilidad))
            datos.sqlParameters.Add(New SqlParameter("@numautorizadis", fondo.numautorizadis))
            datos.sqlParameters.Add(New SqlParameter("@numautorizaconta", fondo.numautorizaconta))
            datos.sqlParameters.Add(New SqlParameter("@usuariodipersion", fondo.usuariodipersion))
            datos.sqlParameters.Add(New SqlParameter("@usuariocontabilidad", fondo.usuariocontabilidad))

            datos.sqlParameters.Add(New SqlParameter("@motivorechazo", fondo.motivorechazo))

            datos.Comando_SP("Update_Fondo_Retiro @fase,@reporte_anio, @reporte_cliente, @reporte_tipo, @reporte_clvestado, @reporte_numero, @cliente_clvCliente, @monto, @motivosalida, @rfcgestor, @clavedeposito, @usuario,@fechadispersion, @fechacontabilidad, @numautorizadis, @numautorizaconta, @usuariodipersion, @usuariocontabilidad,@UsuarioAutoriza,@motivorechazo", res.DataTable)

            ' Verifica si todo salió bien:
            'res.Dato =  'Aqui devuelve el Id
            'Dim NumServicio As String = res.DataTable.Rows(0)(0) & "" & res.DataTable.Rows(0)(1)

            ' Graba la auditoria
            'Auditoria.Registrar(usr, 55, res.Dato & "-" & NumServicio)
        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Datos_Fondos", "Update_Fondo_Retiro", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Consultar_Fondo_Retiro(ByVal fondo As Retiro_Fondos) As Resultado
        Dim res As New Resultado 'Objeto para resultados
        Dim datos As New ObjDatos 'Objetod para mandar llamar el ws
        'llenamos data grid
        Try
            datos.sqlParameters.Add(New SqlParameter("@fase", fondo.fase2))

            datos.sqlParameters.Add(New SqlParameter("@reporte_anio", fondo.Anio))
            datos.sqlParameters.Add(New SqlParameter("@reporte_cliente", fondo.Cliente))
            datos.sqlParameters.Add(New SqlParameter("@reporte_tipo", fondo.Tipo))
            datos.sqlParameters.Add(New SqlParameter("@reporte_clvestado", fondo.ClvEstado))
            datos.sqlParameters.Add(New SqlParameter("@reporte_numero", fondo.Numero))

            datos.Consulta_SP("Select_Fondo_Retiro @fase,@reporte_anio,@reporte_cliente,@reporte_tipo,@reporte_clvestado,@reporte_numero", res.DataTable)

            ' Verifica si todo salió bien:
            'res.Dato = res.DataTable.Rows(0)(0) 'Aqui devuelve el Id

        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Datos_Fondos.vb", "Select_Fondo_Retiro", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Consultar_NumServicio(ByVal servicio As String) As Resultado
        Dim res As New Resultado 'Objeto para resultados
        Dim datos As New ObjDatos 'Objetod para mandar llamar el ws
        'consultamos el num de gestion
        Try

            datos.sqlParameters.Add(New SqlParameter("@NoGestion", servicio))

            datos.Consulta_SP("Select_NoGestion @NoGestion", res.DataTable)

            ' Verifica si todo salió bien:
            'res.Dato = res.DataTable.Rows(0)(0) 'Aqui devuelve el Id

        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Datos_Fondos.vb", "Select_NoGestion", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Consultar_ClaveCliente(ByVal nombre As String) As Resultado
        Dim res As New Resultado 'Objeto para resultados
        Dim datos As New ObjDatos 'Objetod para mandar llamar el ws
        'consultamos el num de gestion
        Try

            datos.sqlParameters.Add(New SqlParameter("@nombre", nombre))

            datos.Consulta_SP("Select_Clave_Cliente @nombre", res.DataTable)

            ' Verifica si todo salió bien:
            'res.Dato = res.DataTable.Rows(0)(0) 'Aqui devuelve el Id

        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Datos_Fondos.vb", "Select_Clave_Cliente", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Consulta_MotivosRetiros(ByVal clavecliente As Integer, ByVal tiposerv As Integer) As Resultado
        Dim res As New Resultado 'Objeto para resultados
        Dim datos As New ObjDatos 'Objetod para mandar llamar el ws
        'llenamos combobox
        Try

            datos.sqlParameters.Add(New SqlParameter("@ClaveCliente", clavecliente))
            datos.sqlParameters.Add(New SqlParameter("@TipoServicio", tiposerv))

            datos.Consulta_SP("Select_Motivos_Retiros @ClaveCliente,@TipoServicio", res.DataTable)

            ' Verifica si todo salió bien:
            'res.Dato = res.DataTable.Rows(0)(0) 'Aqui devuelve el Id

        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Datos_Fondos.vb", "Select_Motivos_Retiros", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

#End Region

End Class

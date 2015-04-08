Imports System.Data.SqlClient
Imports System.Data

'//////////////////////////////////////////////////////////////////////////////////////
' Clase para accesar la base de datos
Namespace Acceso_a_Datos

#Region "Clase de Datos"

    ''' <summary>
    ''' Objeto de acceso a datos
    ''' </summary>
    ''' <remarks></remarks>
    Public Class ObjDatos

#Region "Variables y objetos"

        'Objetos de acceso a datos 
        Protected connection As SqlConnection
        Protected connString As String

        ' Para las transacciones
        Protected transaction As SqlTransaction = Nothing

        ''' <summary>
        ''' Objeto con una colección de parámetros sql para ser usados en las consultas
        ''' </summary>
        ''' <remarks></remarks>
        Public sqlParameters As New Collection()

        ''' <summary>
        ''' Contiene la cantidad de registros involucrados en la última ejecución de algún comando
        ''' </summary>
        ''' <remarks></remarks>
        Public registrosAfectados As Integer = 0

        ' Manejo de errores
        ''' <summary>
        ''' Indica si ocurrió algún error en la última instrucción que se ejecutó
        ''' </summary>
        ''' <remarks></remarks>
        Public hayError As Boolean = False

        ''' <summary>
        ''' Error de la última instrucción que se ejecutó. "" si no hay error
        ''' </summary>
        ''' <remarks></remarks>
        Public errorDesc As String = ""

        ' Cadena de conexión y timeout de los comandos
        ''' <summary>
        ''' Cadena de conexion
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared CONNECTION_STRING As String = System.Configuration.ConfigurationManager.AppSettings("ConnStringSQL")

        ' ''' <summary>
        ' ''' cadena de conexión con permisos para ingresar a AsistenciaII
        ' ''' </summary>
        ' ''' <remarks></remarks>
        'Public Shared CONNECTION_STRING_AsistenciaII As String = System.Configuration.ConfigurationManager.AppSettings("ConnAsistencia")

        ' ''' <summary>
        ' ''' Conexion a la base de basesemisiongestoria
        ' ''' </summary>
        ' ''' <remarks></remarks>
        'Public Shared CONNECTION_EMISIONGESTORIA As String = System.Configuration.ConfigurationManager.AppSettings("EmisionGestoria")

        ''' <summary>
        ''' Timeout de los comandos
        ''' </summary>
        ''' <remarks></remarks>
        Public Const COMMAND_TIMEOUT As Integer = 60

#End Region

#Region "Constructores"

        ''' <summary>
        ''' Constructor. El objeto utilizará la cadena de conexión predefinida
        ''' </summary>
        ''' <remarks></remarks>
        Sub New()
            Me.connString = CONNECTION_STRING
            connection = New SqlConnection(Me.connString)
        End Sub
        ''' <summary>
        ''' Constructor. El objeto utilizará la cadena de conexión especificada
        ''' </summary>
        ''' <param name="conn_string">Cadena de conexión</param>
        ''' <remarks></remarks>
        Sub New(ByVal conn_string As String)
            Me.connString = conn_string
            connection = New SqlConnection(Me.connString)
        End Sub

#End Region

#Region "Conectar y desconectar"

        ''' <summary>
        ''' Se conecta a la base de datos
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Conectar() As Estatus
            errorDesc = ""
            hayError = False
            Conectar = Estatus.Exito
            Try
                ' Se conecta
                connection.Open()
            Catch ex As Exception
                ' error
                errorDesc = ex.Message
                hayError = True
                Conectar = Estatus.Error
                Logs.LogError("AccesoDatos.vb", "Conectar", ex.Message)
            End Try

            If hayError Then Throw New AccesoDatos_Exception(errorDesc)
        End Function

        ''' <summary>
        ''' Se desconecta de la base de datos
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Desconectar() As Estatus
            Desconectar = Estatus.Exito
            Try
                ' Se desconecta
                If connection.State = ConnectionState.Open Then
                    connection.Close()
                End If
            Catch ex As Exception
                Desconectar = Estatus.Error
                Logs.LogError("AccesoDatos.vb", "Desconectar", ex.Message)
            End Try

        End Function

#End Region

#Region "Consultas y comandos"

        ''' <summary>
        ''' Agrega un sqlParameter a la colección de parámetros
        ''' </summary>
        ''' <param name="nombre">Nombre del sqlParameter</param>
        ''' <param name="valor">Valor que tendrá el sqlParameter</param>
        ''' <remarks></remarks>
        Public Sub AddSqlParameter(nombre As String, valor As Object)
            sqlParameters.Add(New SqlParameter(nombre, valor))
        End Sub

        '////////////////////////////////////////////////////////////////////////////////

        ''' <summary>
        ''' Ejecuta un Procedimiento Almacenado que contiene un Select
        ''' </summary>
        ''' <param name="query">Instruccion de Store Procedure</param>
        ''' <param name="datatable">Objeto Dataset donde quedarán los datos</param>
        ''' <param name="timeout">Timeout del comando</param>
        ''' <returns></returns>
        ''' <remarks>Al finalizar, la variable miembro registrosAfectados contiene la cantidad de registros involucrados en la ejecución del SP.</remarks>
        Public Function Consulta_SP(ByVal query As String, ByRef datatable As DataTable, Optional ByVal timeout As Integer = 0) As Estatus
            registrosAfectados = 0
            errorDesc = ""
            hayError = False
            Consulta_SP = Estatus.Exito

            Dim adapter As New SqlDataAdapter

            Try
                ' Ejecuta el SP
                Conectar()

                'Prepara el adapter
                adapter.SelectCommand = New SqlCommand(query, connection)
                adapter.SelectCommand.CommandTimeout = IIf(timeout = 0, COMMAND_TIMEOUT, timeout)

                'Prepara los parámetros
                If sqlParameters.Count > 0 Then
                    For Each param As SqlParameter In sqlParameters
                        adapter.SelectCommand.Parameters.Add(param)
                    Next
                End If

                ' Prepara el datatable
                datatable.Clear()
                datatable.TableName = "tabla"

                ' Ejecuta el SP
                registrosAfectados = adapter.Fill(datatable)

            Catch ex As Exception
                ' Error
                errorDesc = ex.Message
                hayError = True
                Consulta_SP = Estatus.Error
                Dim params As String = ""
                If sqlParameters.Count > 0 Then
                    For Each param As SqlParameter In sqlParameters
                        params &= param.ParameterName & ":" & param.Value & "|"
                    Next
                End If
                Logs.LogError("AccesoDatos.vb", "Consulta_SP", ex.Message, query & " Parametros: " & params)
            Finally
                Desconectar()
                adapter.Dispose()
                sqlParameters.Clear()
            End Try

            If hayError Then Throw New AccesoDatos_Exception(errorDesc)
        End Function

        ''' <summary>
        ''' Ejecuta un Procedimiento Almacenado que contiene Insert, Delete o Update
        ''' </summary>
        ''' <param name="query">Instruccion de Store Procedure</param>
        ''' <param name="timeout">Timeout del comando</param>
        ''' <returns></returns>
        ''' <remarks>Al finalizar, la variable miembro registrosAfectados contiene la cantidad de registros involucrados en la ejecución del SP.</remarks>
        Public Function Comando_SP(ByVal query As String, ByRef datatable As DataTable, Optional ByVal timeout As Integer = 0) As Estatus
            registrosAfectados = 0
            errorDesc = ""
            hayError = False
            Comando_SP = Estatus.Exito

            Dim adapter As New SqlDataAdapter

            Try
                ' Ejecuta el SP
                Conectar()

                'Prepara el adapter
                adapter.SelectCommand = New SqlCommand(query, connection)
                adapter.SelectCommand.CommandTimeout = IIf(timeout = 0, COMMAND_TIMEOUT, timeout)

                'Prepara los parámetros
                If sqlParameters.Count > 0 Then
                    For Each param As SqlParameter In sqlParameters
                        adapter.SelectCommand.Parameters.Add(param)
                    Next
                End If

                ' Ejecuta el SP
                adapter.Fill(datatable)

                ' Verifica si hubo error
                If datatable.Rows(0)(0) = -1 Then
                    Throw New Exception("(Error " & datatable.Rows(0)(1) & ")" & datatable.Rows(0)(2)) ' Num. y Msg de error
                Else
                    registrosAfectados = datatable.Rows(0)(1)
                End If
            Catch ex As Exception
                ' Error
                errorDesc = ex.Message
                hayError = True
                Comando_SP = Estatus.Error
                Dim params As String = ""
                If sqlParameters.Count > 0 Then
                    For Each param As SqlParameter In sqlParameters
                        params &= param.ParameterName & ":" & param.Value & "|"
                    Next
                End If
                Logs.LogError("AccesoDatos.vb", "Comando_SP", ex.Message, query & " Parametros: " & params)
            Finally
                Desconectar()
                adapter.Dispose()
                sqlParameters.Clear()
            End Try

            If hayError Then Throw New AccesoDatos_Exception(errorDesc)
        End Function

        ''' <summary>
        ''' Ejecuta un Procedimiento Almacenado que contiene un select como parte de una transaccion
        ''' </summary>
        ''' <param name="query">Instruccion de Store Procedure</param>
        ''' <param name="datatable">Objeto Dataset donde quedarán los datos</param>
        ''' <param name="timeout">Timeout del comando</param>
        ''' <returns></returns>
        ''' <remarks>Al finalizar, la variable miembro registrosAfectados contiene la cantidad de registros involucrados en la ejecución del SP.</remarks>
        Public Function Consulta_SP_Transaccion(ByVal query As String, ByRef datatable As DataTable, Optional ByVal timeout As Integer = 0) As Estatus

            registrosAfectados = 0
            errorDesc = ""
            hayError = False
            Consulta_SP_Transaccion = Estatus.Exito

            Dim adapter As New SqlDataAdapter

            Try
                ' Prepara el adapter
                adapter.SelectCommand = New SqlCommand(query, connection, transaction)
                adapter.SelectCommand.CommandTimeout = IIf(timeout = 0, COMMAND_TIMEOUT, timeout)

                'Prepara los parámetros
                If sqlParameters.Count > 0 Then
                    For Each param As SqlParameter In sqlParameters
                        adapter.SelectCommand.Parameters.Add(param)
                    Next
                End If

                ' Prepara el datatable
                datatable.Clear()
                datatable.TableName = "tabla"

                ' Ejecuta el SP
                registrosAfectados = adapter.Fill(datatable)

                '' Verifica si hubo error
                'If datatable.Rows.Count > 0 AndAlso datatable.Rows(0)(0) = -1 Then
                '    Throw New Exception("(Error " & datatable.Rows(0)(1) & ")" & datatable.Rows(0)(2)) ' Num. y Msg de error
                'End If

            Catch ex As Exception
                ' Error
                errorDesc = ex.Message
                hayError = True
                Consulta_SP_Transaccion = Estatus.Error
                Dim params As String = ""
                If sqlParameters.Count > 0 Then
                    For Each param As SqlParameter In sqlParameters
                        params &= param.ParameterName & "|" & param.Value
                    Next
                End If
                Logs.LogError("AccesoDatos.vb", "Consulta_SP_Transaccion", ex.Message, query & " Parametros: " & params)
            Finally
                adapter.Dispose()
                sqlParameters.Clear()
            End Try

            If hayError Then Throw New AccesoDatos_Exception(errorDesc)
        End Function

        ''' <summary>
        ''' Ejecuta un Procedimiento Almacenado que contiene un insert, update o delete como parte de una transaccion
        ''' </summary>
        ''' <param name="query">Instruccion de Store Procedure</param>
        ''' <param name="timeout">Timeout del comando</param>
        ''' <returns></returns>
        ''' <remarks>Al finalizar, la variable miembro registrosAfectados contiene la cantidad de registros involucrados en la ejecución del SP.</remarks>
        Public Function Comando_SP_Transaccion(ByVal query As String, ByRef datatable As DataTable, Optional ByVal timeout As Integer = 0) As Estatus
            registrosAfectados = 0
            errorDesc = ""
            hayError = False
            Comando_SP_Transaccion = Estatus.Exito

            Dim adapter As New SqlDataAdapter

            Try
                ' Prepara el adapter
                adapter.SelectCommand = New SqlCommand(query, connection, transaction)
                adapter.SelectCommand.CommandTimeout = IIf(timeout = 0, COMMAND_TIMEOUT, timeout)

                'Prepara los parámetros
                If sqlParameters.Count > 0 Then
                    For Each param As SqlParameter In sqlParameters
                        adapter.SelectCommand.Parameters.Add(param)
                    Next
                End If

                ' Ejecuta el SP
                adapter.Fill(datatable)

                ' Verifica si hubo error
                If datatable.Rows(0)(0) = -1 Then
                    Throw New Exception("(Error " & datatable.Rows(0)(1) & ")" & datatable.Rows(0)(2)) ' Num. y Msg de error
                Else
                    registrosAfectados = datatable.Rows(0)(1)
                End If
            Catch ex As Exception
                ' Error
                errorDesc = ex.Message
                hayError = True
                Comando_SP_Transaccion = Estatus.Error
                Dim params As String = ""
                If sqlParameters.Count > 0 Then
                    For Each param As SqlParameter In sqlParameters
                        params &= param.ParameterName & "|" & param.Value
                    Next
                End If
                Logs.LogError("AccesoDatos.vb", "Comando_SP_Transccion", ex.Message, query & " Parametros: " & params)
            Finally
                adapter.Dispose()
                sqlParameters.Clear()
            End Try

            If hayError Then Throw New AccesoDatos_Exception(errorDesc)
        End Function


#End Region

#Region "Transacciones"

        '////////////////////////////////////////////////////////////////////////////////
        ''' <summary>
        ''' Hace el commit
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Commit() As Estatus
            errorDesc = ""
            hayError = False
            Commit = Estatus.Exito
            Try
                ' Ejecuta Commit
                transaction.Commit()
            Catch ex As Exception
                ' Error
                errorDesc = ex.Message
                hayError = True
                Commit = Estatus.Error
                Logs.LogError("AccesoDatos.vb", "Commit", ex.Message)
            Finally
                transaction = Nothing
                Desconectar()
            End Try

            If hayError Then Throw New AccesoDatos_Exception(errorDesc)
        End Function
        ''' <summary>
        ''' Hace el Rollback
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Rollback() As Estatus
            Rollback = Estatus.Exito
            Try
                ' Rollback
                If transaction.Connection IsNot Nothing Then
                    transaction.Rollback()
                End If
            Catch ex As Exception
                ' Error
                Rollback = Estatus.Error
                Logs.LogError("AccesoDatos.vb", "RollBack", ex.Message)
            Finally
                transaction = Nothing
                Desconectar()
            End Try

        End Function
        ''' <summary>
        ''' Inicia una transacción
        ''' </summary>
        ''' <param name="isolation">Nivel de Isolasion</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function BeginTransaction(Optional ByVal isolation As System.Data.IsolationLevel = IsolationLevel.Unspecified) As Estatus
            errorDesc = ""
            hayError = False
            BeginTransaction = Estatus.Exito
            transaction = Nothing

            Try
                ' Inicia transaccion
                If Conectar() = Estatus.Error Then
                    Throw New Exception(Me.errorDesc)
                End If
                transaction = connection.BeginTransaction(isolation)
            Catch ex As Exception
                ' Error
                errorDesc = ex.Message
                hayError = True
                BeginTransaction = Estatus.Error
                Logs.LogError("AccesoDatos.vb", "BeginTransaction", ex.Message)
            End Try

            If hayError Then Throw New AccesoDatos_Exception(errorDesc)
        End Function

        ''' <summary>
        ''' Permite saber si hay o no una transacción en proceso
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property TransaccionIniciada() As Boolean
            Get
                Return (transaction IsNot Nothing)
            End Get
        End Property
#End Region

        'Public Function Consultar_Servcio_Asistencia_II(ByVal query As String, ByRef datatable As DataTable, Optional ByVal timeout As Integer = 0) As Estatus
        '    registrosAfectados = 0
        '    errorDesc = ""
        '    hayError = False
        '    Consultar_Servcio_Asistencia_II = Estatus.Exito
        '    Dim datos As New ObjDatos(ObjDatos.CONNECTION_STRING_AsistenciaII)
        '    Dim adapter As New SqlDataAdapter

        '    Try
        '        ' Ejecuta el SP
        '        datos.Conectar()

        '        'Prepara el adapter
        '        adapter.SelectCommand = New SqlCommand(query, datos.connection)
        '        adapter.SelectCommand.CommandTimeout = IIf(timeout = 0, COMMAND_TIMEOUT, timeout)

        '        ''Prepara los parámetros
        '        'If sqlParameters.Count > 0 Then
        '        '    For Each param As SqlParameter In sqlParameters
        '        '        adapter.SelectCommand.Parameters.Add(param)
        '        '    Next
        '        'End If

        '        ' Prepara el datatable
        '        datatable.Clear()
        '        datatable.TableName = "tabla"

        '        ' Ejecuta el SP
        '        registrosAfectados = adapter.Fill(datatable)

        '    Catch ex As Exception
        '        ' Error
        '        errorDesc = ex.Message
        '        hayError = True
        '        Consultar_Servcio_Asistencia_II = Estatus.Error
        '        Dim params As String = ""
        '        If sqlParameters.Count > 0 Then
        '            For Each param As SqlParameter In sqlParameters
        '                params &= param.ParameterName & ":" & param.Value & "|"
        '            Next
        '        End If
        '        Logs.LogError("AccesoDatos.vb", "Consulta_SP", ex.Message, query & " Parametros: " & params)
        '    Finally
        '        datos.Desconectar()
        '        adapter.Dispose()
        '        sqlParameters.Clear()
        '    End Try

        '    If hayError Then Throw New AccesoDatos_Exception(errorDesc)
        'End Function

        ''Isra
        'Public Function Actualizar_Servcio_Asistencia_II(ByVal query As String, ByRef datatable As DataTable, Optional ByVal timeout As Integer = 0) As Estatus
        '    registrosAfectados = 0
        '    errorDesc = ""
        '    hayError = False
        '    Actualizar_Servcio_Asistencia_II = Estatus.Exito
        '    Dim datos As New ObjDatos(ObjDatos.CONNECTION_STRING_AsistenciaII)
        '    Dim adapter As New SqlDataAdapter

        '    Try
        '        ' Ejecuta el SP
        '        datos.Conectar()

        '        'Prepara el adapter
        '        adapter.SelectCommand = New SqlCommand(query, datos.connection)
        '        adapter.SelectCommand.CommandTimeout = IIf(timeout = 0, COMMAND_TIMEOUT, timeout)

        '        'Prepara los parámetros
        '        'If sqlParameters.Count > 0 Then
        '        '    For Each param As SqlParameter In sqlParameters
        '        '        adapter.SelectCommand.Parameters.Add(param)
        '        '    Next
        '        'End If

        '        ' Prepara el datatable
        '        datatable.Clear()
        '        datatable.TableName = "tabla"

        '        ' Ejecuta el SP
        '        registrosAfectados = adapter.Fill(datatable)

        '    Catch ex As Exception
        '        ' Error
        '        errorDesc = ex.Message
        '        hayError = True
        '        Actualizar_Servcio_Asistencia_II = Estatus.Error
        '        Dim params As String = ""
        '        If sqlParameters.Count > 0 Then
        '            For Each param As SqlParameter In sqlParameters
        '                params &= param.ParameterName & ":" & param.Value & "|"
        '            Next
        '        End If
        '        Logs.LogError("AccesoDatos.vb", "Actualizar_Servcio_Asistencia_II", ex.Message, query & " Parametros: " & params)
        '    Finally
        '        datos.Desconectar()
        '        adapter.Dispose()
        '        sqlParameters.Clear()
        '    End Try

        '    If hayError Then Throw New AccesoDatos_Exception(errorDesc)
        'End Function
        ''isra
    End Class

#End Region

#Region "Excepción Personalizada"

    ''' <summary>
    ''' Excepción especial para el acceso a datos
    ''' </summary>
    ''' <remarks></remarks>
    Public Class AccesoDatos_Exception
        Inherits Exception

        ''' <summary>
        ''' Constructor
        ''' </summary>
        ''' <param name="Mensaje">Mensaje de la excepción</param>
        ''' <remarks></remarks>
        Sub New(ByVal Mensaje As String)
            MyBase.New(Mensaje)
        End Sub

    End Class

#End Region

End Namespace

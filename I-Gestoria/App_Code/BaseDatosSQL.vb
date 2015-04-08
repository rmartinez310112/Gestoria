Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Public Class BaseDatosSQL


    '''''''''''''''''''''''''''''''
    '' Objetos de Acceso a Datos ''
    '''''''''''''''''''''''''''''''
    Public conn As SqlConnection = Nothing
    Public adapter As SqlDataAdapter = Nothing
    Public dataReader As SqlDataReader = Nothing
    Public dataSet As DataSet = Nothing
    Public dataRow As DataRow = Nothing
    Public transaction As SqlTransaction = Nothing
    Public fecha As Date
    Public errorDesc As String

    Public sqlConnectionString As String
    Public mostrarErrores As Boolean = False

    '''''''''''''''''''
    '' Constructores ''

    '''''''''''''''''
    Sub New(Optional ByVal sqlConnStr As String = "")
        If Not sqlConnStr = "" Then
            sqlConnectionString = sqlConnStr
        End If
    End Sub

    Public Enum Estatus As Byte
        OK = 0
        [ERROR] = 1
    End Enum

    ''''''''''''''''''''''''''''
    '' Conectar Y Desconectar ''
    ''''''''''''''''''''''''''''
    Public Function Conectar(Optional ByVal conn_string As String = "") As Boolean
        Try
            If Not conn_string = "" Then
                conn = New SqlConnection(conn_string)
            Else
                conn = New SqlConnection(sqlConnectionString)
            End If
            conn.Open()
            Return True
        Catch ex As Exception
            MostrarError(ex)
            Return False
        End Try
    End Function

    Public Function Desconectar() As Boolean
        Try
            If Not conn Is Nothing Then
                conn.Close()
                conn = Nothing
            End If
            Return True
        Catch ex As Exception
            MostrarError(ex)
            Return False
        End Try
    End Function

    ''''''''''''''''''''
    '' Sentencias SQL ''
    ''''''''''''''''''''
    Public Function EjecutarInsert(ByVal query As String, Optional ByVal conn_string As String = "", Optional ByVal conectar As Boolean = True) As Boolean
        Dim respuesta As Boolean = False
        Try
            If conectar Then
                Me.Conectar(conn_string)
            End If
            adapter = New SqlDataAdapter()

            adapter.InsertCommand = New SqlCommand(query, conn)
            adapter.InsertCommand.CommandTimeout = 500
            adapter.InsertCommand.Transaction = Me.transaction
            adapter.InsertCommand.ExecuteNonQuery()
            If conectar Then
                Desconectar()
            End If
            Return True
        Catch ex As Exception
            MostrarError(ex)
            If conectar Then
                Desconectar()
            End If
            Return False
        End Try
        Return respuesta
    End Function

    Public Function QueryDataSet(ByVal strSQL As String, Optional ByVal conn_string As String = "") As DataSet
        Dim ds As New DataSet
        adapter = New SqlDataAdapter

        If conn_string.Trim <> String.Empty Then
            Me.Conectar(conn_string)
        Else
            Conectar()
        End If


        Dim objCmd As SqlCommand = New SqlCommand
        With objCmd
            .Connection = conn
            .CommandText = strSQL
            .CommandType = CommandType.Text
            .CommandTimeout = 1000
        End With
        adapter.SelectCommand = objCmd
        adapter.Fill(ds)


        Desconectar()


        Return ds   '*** Return DataSet ***'

    End Function


    Public Function EjecutarUpdate(ByVal query As String, Optional ByVal conn_string As String = "", Optional ByVal conectar As Boolean = True) As Boolean
        Try
            If conectar Then
                Me.Conectar(conn_string)
            End If
            adapter = New SqlDataAdapter()
            adapter.UpdateCommand = New SqlCommand(query, conn)
            adapter.UpdateCommand.CommandTimeout = 500
            adapter.UpdateCommand.Transaction = Me.transaction
            adapter.UpdateCommand.ExecuteNonQuery()
            If conectar Then
                Desconectar()
            End If
            Return True
        Catch ex As Exception
            MostrarError(ex)
            If conectar Then
                Desconectar()
            End If
            Return False
        End Try
    End Function

    Public Function LeerRegistrosDataset(ByVal query As String, Optional ByVal conn_string As String = "") As Boolean
        Try
            Conectar(conn_string)
            dataSet = New DataSet()
            adapter = New SqlDataAdapter(query, conn)
            adapter.Fill(dataSet)
            Desconectar()
            Return True
        Catch ex As Exception
            MostrarError(ex)
            Desconectar()
            Return False
        End Try
    End Function

    '''''''''''
    '' FECHA ''
    '''''''''''
    ' Obtiene la fecha del servidor
    Public Function ObtenerFecha(Optional ByVal conn_string As String = "") As Boolean
        Try
            Conectar(conn_string)
            adapter = New SqlDataAdapter("select getdate()", conn)
            fecha = adapter.SelectCommand.ExecuteScalar
            Desconectar()
        Catch ex As Exception
            fecha = DateSerial(1900, 1, 1)
            MostrarError(ex)
            Desconectar()
            Return False
        End Try
    End Function

    Public Function LlenarGrid(ByRef grid As DataGrid, Optional ByVal query As String = "", Optional ByVal conn_string As String = "") As Estatus
        errorDesc = ""
        LlenarGrid = Estatus.OK
        Try
            If Not query = "" Then
                LeerRegistrosDataset(query, conn_string)
            End If
            grid.DataSource = dataSet.Tables(0)
            grid.DataBind()
        Catch ex As Exception
            errorDesc = ex.Message
            LlenarGrid = Estatus.ERROR
        End Try
    End Function

    Public Function LlenarRadGrid(ByRef grid As Telerik.Web.UI.RadGrid, Optional ByVal query As String = "", Optional ByVal conn_string As String = "") As Estatus
        errorDesc = ""
        LlenarRadGrid = Estatus.OK
        Try
            If Not query = "" Then
                LeerRegistrosDataset(query, conn_string)
            End If
            grid.DataSource = dataSet.Tables(0)
            grid.DataBind()
        Catch ex As Exception
            errorDesc = ex.Message
            LlenarRadGrid = Estatus.ERROR
        End Try
    End Function

    ' Llena un combo
    Public Function LlenarCombo(ByRef combo As DropDownList, ByVal query As String, Optional ByVal conn_string As String = "") As Estatus
        errorDesc = ""
        LlenarCombo = Estatus.OK
        Try
            LeerRegistrosDataset(query, conn_string)
            combo.DataSource = dataSet.Tables(0)
            combo.DataValueField = dataSet.Tables(0).Columns(0).Caption
            combo.DataTextField = dataSet.Tables(0).Columns(1).Caption
            combo.DataBind()
        Catch ex As Exception
            errorDesc = ex.Message
            LlenarCombo = Estatus.ERROR
        End Try
    End Function

    Public Function LlenaGridTableros(ByRef Grid As Telerik.Web.UI.RadGrid, ByVal query As String, Optional ByVal conn_string As String = "") As DataTable
        errorDesc = ""
        'LlenaGridTableros = Estatus.OK
        Try
            LeerRegistrosDataset(query, conn_string)
            Grid.DataSource = dataSet.Tables(0)
            Grid.DataBind()
            Return dataSet.Tables(0)
        Catch ex As Exception
            errorDesc = ex.Message
            '   LlenaGridTableros = Estatus.ERROR
        End Try
    End Function

    Public Function LlenarRadCombo(ByRef combo As Telerik.Web.UI.RadComboBox, ByVal query As String, Optional ByVal conn_string As String = "") As Estatus
        errorDesc = ""
        LlenarRadCombo = Estatus.OK
        Try
            LeerRegistrosDataset(query, conn_string)
            combo.DataSource = dataSet.Tables(0)
            combo.DataValueField = dataSet.Tables(0).Columns(0).Caption
            combo.DataTextField = dataSet.Tables(0).Columns(1).Caption
            combo.DataBind()
        Catch ex As Exception
            errorDesc = ex.Message
            LlenarRadCombo = Estatus.ERROR
        End Try
    End Function
    'Public Function LlenarComboAjax(ByRef combo As Telerik.Web.UI.RadComboBox, ByVal query As String, Optional ByVal conn_string As String = "") As Estatus
    '    errorDesc = ""
    '    LlenarComboAjax = Estatus.OK
    '    Try
    '        LeerRegistrosDataset(query, conn_string)
    '        combo.DataSource = dataSet.Tables(0)
    '        combo.DataValueField = dataSet.Tables(0).Columns(0).Caption
    '        combo.DataTextField = dataSet.Tables(0).Columns(1).Caption
    '        combo.DataBind()
    '    Catch ex As Exception
    '        errorDesc = ex.Message
    '        LlenarComboAjax = Estatus.ERROR
    '    End Try
    'End Function
    Public Function EjecutarSP(ByVal query As String, Optional ByVal conn_string As String = "") As Estatus
        errorDesc = ""
        EjecutarSP = Estatus.OK
        Try
            Conectar(conn_string)
            dataSet = New DataSet()
            adapter = New SqlDataAdapter '(query, conn)
            adapter.SelectCommand = New SqlCommand(query, conn)
            adapter.SelectCommand.CommandTimeout = 500

            adapter.Fill(dataSet)
            Desconectar()

        Catch ex As Exception
            errorDesc = ex.Message
            Desconectar()
            EjecutarSP = Estatus.ERROR
        End Try
    End Function

    '''''''''''''''''''''''
    '' Mensajes De Error ''
    '''''''''''''''''''''''
    Private Sub MostrarError(Optional ByVal ex As Exception = Nothing)
        If Not ex Is Nothing And mostrarErrores Then
            'MsgBox(ex.ToString())
            'Dim FS As New System.IO.FileStream("C:/Documents and Settings/Administrador/Escritorio/eeerror.txt", IO.FileMode.Append)
            'Dim SW As New System.IO.StreamWriter(FS)
            'SW.Write(ex.ToString() & vbCrLf & vbCrLf)
            'SW.Close()
            'FS.Close()
        End If
    End Sub

    Public Function QueryDataSetNew(ByVal query As SqlClient.SqlCommand, Optional ByVal conn_string As String = "") As DataSet
        Dim ds As New DataSet
        adapter = New SqlDataAdapter
        Try


            query.Connection.Open()
            Me.adapter.SelectCommand = Query
            Me.adapter.SelectCommand.CommandTimeout = 500
            Me.adapter.Fill(ds)

            Me.Desconectar()
        Catch ex As Exception
            Me.Desconectar()
        End Try

        Return ds   '*** Return DataSet ***'

    End Function

    Public Function EjecutarSPNew(ByVal query As SqlClient.SqlCommand, Optional ByVal conn_string As String = "") As Estatus
        errorDesc = ""
        EjecutarSPNew = Estatus.OK
        Dim ds As New DataSet
        adapter = New SqlDataAdapter
        Try
            query.Connection.Open()
            Me.adapter.SelectCommand = query
            Me.adapter.SelectCommand.CommandTimeout = 500
            Me.adapter.Fill(ds)

            adapter.Fill(ds)
            Me.Desconectar()

        Catch ex As Exception
            errorDesc = ex.Message
            Desconectar()
            EjecutarSPNew = Estatus.ERROR
        End Try
    End Function

    Public Function EjecutarSPDataset(ByVal query As String, Optional ByVal conn_string As String = "") As DataSet
        errorDesc = ""

        Try
            Conectar(conn_string)
            dataSet = New DataSet()
            adapter = New SqlDataAdapter '(query, conn)
            adapter.SelectCommand = New SqlCommand(query, conn)
            adapter.SelectCommand.CommandTimeout = 500

            adapter.Fill(dataSet)
            EjecutarSPDataset = dataSet
            Desconectar()

        Catch ex As Exception
            errorDesc = ex.Message
            Desconectar()

        End Try
    End Function

    Public Function QueryDataDatable(ByVal strSQL As String, Optional ByVal conn_string As String = "") As DataTable
        Dim dt As New DataTable
        adapter = New SqlDataAdapter

        If conn_string.Trim <> String.Empty Then
            Me.Conectar(conn_string)
        Else
            Conectar()
        End If


        Dim objCmd As SqlCommand = New SqlCommand
        With objCmd
            .Connection = conn
            .CommandText = strSQL
            .CommandType = CommandType.Text
            .CommandTimeout = 1000
        End With
        adapter.SelectCommand = objCmd
        adapter.Fill(dt)


        Desconectar()


        Return dt   '*** Return DataSet ***'

    End Function

    Public Function ExecuteEscalar(ByVal query As String, Optional ByVal conn_string As String = "") As Int32
        Dim connetionString As String
        Dim cnn As SqlConnection
        Dim cmd As SqlCommand
        Dim sql As String

        'connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
        'sql = "Your SQL Statement Here like Select Count(*) from product"

        cnn = New SqlConnection(conn_string)
        Try
            cnn.Open()
            cmd = New SqlCommand(query, cnn)
            Dim count As Int32 = Convert.ToInt32(cmd.ExecuteScalar())
            cmd.Dispose()
            cnn.Close()
            'MsgBo(angry)" No. of Rows " & count)
            Return count
        Catch ex As Exception
            ' MsgBox("Can not open connection ! ")
        End Try


    End Function

    Public Function ResultLlamada(ByVal NoGestion As String, Optional ByVal conn_string As String = "") As Boolean
        Dim _query As String = "   SELECT     COUNT(*)              " & _
        " FROM ResultadoLlamadasGestoria_tbl                        " & _
        " WHERE     (CatTipoLlamada_cvLlamada = 2)                  " & _
        " AND CatResLlamadas_ClvResultado = 1 and  Etapa_clvEtapa = 2 " & _
        " AND CAST(Reporte_anio AS varchar) +                       " & _
        " CAST(Reporte_cliente AS varchar) +                        " & _
        " CAST(Reporte_Tipo AS varchar) + CAST(Reporte_clvEstado AS varchar) " & _
        " + CAST(Reporte_Numero AS varchar)=  '" & NoGestion & "'  "

        If (Me.ExecuteEscalar(_query, conn_string) >= 1) Then
            ResultLlamada = True
        Else
            ResultLlamada = False
        End If
    End Function

    Public Function LlenarList(ByRef list As CheckBoxList, Optional ByVal query As String = "", Optional ByVal conn_string As String = "") As Estatus
        errorDesc = ""
        LlenarList = Estatus.OK
        Try
            If Not query = "" Then
                LeerRegistrosDataset(query, conn_string)
            End If
            list.DataSource = dataSet.Tables(0)
            list.DataBind()
        Catch ex As Exception
            errorDesc = ex.Message
            LlenarList = Estatus.ERROR
        End Try
    End Function

End Class
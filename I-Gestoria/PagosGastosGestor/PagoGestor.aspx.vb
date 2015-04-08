Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.Web.UI

Partial Class PagosGastosGestor_PagoGestor
    Inherits System.Web.UI.Page
    Dim csNeg As New ClaseNegocios
    Dim csSQLsvr As New BaseDatosSQL
    Dim csDAL As New DALClass
    Dim Cadena As String = GlobalVariables.sqlString

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        'Session("clvUsuario") = "CZL"
        If Not IsPostBack Then
            'RadGrid2.Visible = False
            'rgAutorizados.Visible = False
            'rgCancelados.Visible = False
            'RadButton1.Visible = False
            'RadButton2.Visible = False

            If Session("noGestionIntegral") IsNot Nothing Then

                Session("nogasto") = Nothing
                CargaGastosServicio(Session("noGestionIntegral")) ' rutina que carga los datos en el grid de pagos, verificar el nievel del usuario para ver que opciones se activan
                'Label5.Text = Session("noGestionIntegral")
                Label16.Text = Session("clvUsuario")
                lblFecha.Text = Format(Now(), "MM/dd/yyyy")
                TiposGastos() ' carga los tipos de gastos a capturar

                Dim dsGastos As DataSet = New DataSet
                dsGastos = csDAL.BuscaExpedienteDatos(Session("noGestionIntegral")) ' buscamos todos los datos del servicio
                Dim dr0 As DataRow
                For Each dr0 In dsGastos.Tables(0).Rows
                    lblEstado.Text = dr0("reporte_clvEstado")
                    lblMpio.Text = dr0("reporte_clvMpio")
                    ' Empezamos las validaciones.

                    If dr0("rfc_gestor").ToString.Trim = String.Empty Then
                        ConfigureNotification("No hay gestor Asignado, no se puede registrar un gasto...")
                        Exit Sub
                    End If
                    ' Gestor asignado, traemos sus datos
                    rfcGestor.Text = dr0("rfc_gestor")
                    'Label6.Text = dr("paterno").ToString.Trim & " " & dr("nombre").ToString.Trim
                    'Label8.Text = dr("servicio_nomServicio").ToString.Trim
                    If IsDBNull(dr0("clave")) Then dr0("clave") = String.Empty
                    Label10.Text = dr0("clave")

                    If dr0("reporte_status") <> 0 Then
                        ConfigureNotification("El servicio no esta activo, no se puede registrar un gasto.")
                        Exit Sub
                    End If


                    'If Not IsDBNull(dr0("fecha_verifico")) Then
                    '    If Format(dr0("fecha_verifico"), "MM/dd/yyyy") <> "01/01/1900" Then
                    '        ConfigureNotification("El expediente ya ha sido entregado a Backoffice y esta ya como verificado, no se puede registrar un gasto.")
                    '        Exit Sub
                    '    End If
                    'End If

                Next
                ' si pasa las verificados activamos el boton para resgistrar el gasto
                Button1.Enabled = True
                txtMontoSolicita.Text = 0
                dsGastos.Clear()

                cargaGastos()
            Else
                ConfigureNotification("Favor de ingresar un numero de servicio")
            End If
        Else
            If Session("noGestionIntegral") <> Nothing Then
                Dim master As MasterPageGestionOperativa = DirectCast(Me.Master, MasterPageGestionOperativa)
                Dim nExpediente As Telerik.Web.UI.RadNumericTextBox = Me.Master.FindControl("txtNoGestion")
                If lblServicio.Text <> nExpediente.Text Then
                    Session("noGestionIntegral") = nExpediente.Text
                    Response.Redirect("PagoGestor.aspx")
                End If
            End If
        End If
    End Sub

    Public Sub CargaGastos()
        If Session("noGestionIntegral") IsNot Nothing Then

            Dim ds As New DataSet
            Dim total As Integer = 0
            ds = csDAL.GastosfondosAutorizadosConta(Session("noGestionIntegral"))

            Dim dr As DataRow
            If ds.Tables(0).Rows.Count <> 0 Then
                For Each dr In ds.Tables(0).Rows

                    lblServicio.Text = dr("Servicio")
                    LblTipo.Text = dr("Servicio_NomServicio")
                    lblGestor.Text = dr("NombreGestor")
                    total += CInt(IIf(IsDBNull(dr("Monto")), "0", dr("Monto")))

                Next
                lblMonto.Text = " $" & total & ".00"
                'lblMonto0.Text = total

                With dtgPagos
                    .DataSource = ds.Tables(0)
                    .DataBind()
                End With
                RecalculaValoresGrid()
            Else
                ConfigureNotification("Solo se mostraran servicios autorizados por tesoreria")
            End If

        Else
            ConfigureNotification("Se requiere agregar numero de servicio, favor de validar")
        End If
    End Sub

    Private Sub TiposGastos()
        csSQLsvr.LlenarCombo(cboTipoGastos, "select  CLV_GASTO, DESCRIPCION_GASTO from  TIPOS_GASTOS_GESTORIA order by CLV_GASTO", Session("connGestion"))
    End Sub

    Public Function CargaGastosServicio(ByVal noservicio As String) As Boolean
        Dim comando As String = " select * from GASTOS_VW where SERVICIO='" & noservicio & "'"
        Dim dsGastos As DataSet = New DataSet
        dsGastos = csSQLsvr.QueryDataSet(comando, Session("connGestion"))
        'If dsGastos.Tables(0).Rows.Count <> 0 Then
        '    ConfigureNotification("Solo se mostraran servicios autorizados por tesoreria")
        'End If
        'With dtgGastos
        '    .DataSource = dsGastos.Tables(0)
        '    .DataBind()
        'End With
        '' nivel de operador, no puede autoriza , cancelar o poner fichas de deposito, favor de verificar el numero
        'If Session("nivel") = 1 Then
        '    dtgGastos.Columns(0).Display = False
        '    dtgGastos.Columns(1).Display = False
        '    dtgGastos.Columns(2).Display = False
        '    dtgGastos.Columns(3).Display = False
        '    dtgGastos.Columns(4).Display = False
        'End If

        'If Session("nivel") = 3 Then ' nivel de supervisor solo puede autorizar y cancelar
        '    dtgGastos.Columns(2).Display = False
        '    dtgGastos.Columns(3).Display = False
        '    dtgGastos.Columns(4).Display = False

        'End If

        'If Session("nivel") = 4 Then ' nivel de Tesoreria solo puede registrar el numero de ficha de deposito
        '    dtgGastos.Columns(0).Display = False
        '    dtgGastos.Columns(1).Display = False
        '    dtgGastos.Columns(2).Display = True
        '    dtgGastos.Columns(3).Display = False
        '    dtgGastos.Columns(4).Display = False
        'End If

    End Function

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

    Protected Sub btnGuardarPago_Click(sender As Object, e As System.EventArgs) Handles btnGuardarPago.Click

        Dim cuenta As Integer = dtgPagos.Items.Count - 1
        Dim x As Integer
        Dim validaErrores As Integer = 0


        Dim comprobado As Integer = 0
        Dim Sincomprobar As Integer = 0

        For x = 0 To cuenta
            Dim rblAceptado As RadioButtonList = dtgPagos.Items(x).FindControl("rblAcep") ' checamos si esta aceptado o rechazado

            If rblAceptado.SelectedValue <> "" Then
                If rblAceptado.SelectedValue = 1 Then
                    If Trim(dtgPagos.Items(x).Cells(5).Text) = "Fondo" Then
                        csDAL.update_fondoGestor(Session("noGestionIntegral"), dtgPagos.Items(x).Cells(3).Text, Session("clvUsuario"), dtgPagos.Items(x).Cells(2).Text, dtgPagos.Items(x).Cells(6).Text)
                    ElseIf Trim(dtgPagos.Items(x).Cells(5).Text) = "Gasto" Then
                        csDAL.update_gastoGestor(Session("noGestionIntegral"), dtgPagos.Items(x).Cells(3).Text, Session("clvUsuario"), dtgPagos.Items(x).Cells(2).Text, dtgPagos.Items(x).Cells(6).Text)
                    End If
                    comprobado += CInt(dtgPagos.Items(x).Cells(3).Text)

                Else
                    Sincomprobar += CInt(dtgPagos.Items(x).Cells(3).Text)
                End If
            Else
                ConfigureNotification("Es necesario calificar todos los documentos. Favor de validar..")
            End If

        Next

        If comprobado <> 0 Then
            lblMontoSI.Text = comprobado
        Else
            lblMontoSI.Visible = False

        End If

        If Sincomprobar <> 0 Then
            lblMontoNo.Text = Sincomprobar
        Else
            lblMontoNo.Visible = False

        End If

        'RadButton2.Visible = True
        lblMonto0.Text = CInt(lblMontoSI.Text) - CInt(lblMontoNo.Text)

        CargaGastos()
        RecalculaValoresGrid()
        ConfigureNotification("Se guardó la comprobación exitosamente")
    End Sub

    Protected Sub Button1_Click(sender As Object, e As System.EventArgs) Handles Button1.Click
        Panel1.Visible = True
        btnGuardarPago.Visible = True
    End Sub

    Public Function Insert_gasto(ByVal SERVICIO As String, ByVal RFCGESTOR As String, ByVal CANTIDAD As String, ByVal CLAVETAB As String, ByVal TABDESCRIP As String, ByVal TOTALGASTO As String, ByVal USUARIO As String, ByVal ESTADO As String, ByVal MPIO As String, ByVal CTACLABE As String, ByVal Deposito As String, numAutTesoreria As String) As Boolean
        Dim conn As New SqlConnection(Session("connGestion"))
        Dim cmd As New SqlCommand("insert_GastosGestorAutorizadosConta", conn)

        Insert_gasto = False
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@SERVICIO", SERVICIO)
        cmd.Parameters.AddWithValue("@RFCGESTOR", RFCGESTOR)
        cmd.Parameters.AddWithValue("@CANTIDAD", CANTIDAD)
        cmd.Parameters.AddWithValue("@CLAVETAB", CLAVETAB)
        cmd.Parameters.AddWithValue("@TABDESCRIP", TABDESCRIP)
        cmd.Parameters.AddWithValue("@TOTALGASTO", TOTALGASTO)
        cmd.Parameters.AddWithValue("@USUARIO", USUARIO)
        cmd.Parameters.AddWithValue("@ESTADO", ESTADO)
        cmd.Parameters.AddWithValue("@MPIO", MPIO)
        cmd.Parameters.AddWithValue("@CTACLABE", CTACLABE)
        cmd.Parameters.AddWithValue("@GASTODOC", Deposito)
        cmd.Parameters.AddWithValue("@numAutTesoreria", numAutTesoreria)


        Try
            conn.Open()
            cmd.ExecuteNonQuery()
            Insert_gasto = True
        Catch
            Insert_gasto = False
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Dispose()
            cmd.Dispose()
        End Try
        Return Insert_gasto
    End Function

    Protected Sub Button2_Click(sender As Object, e As System.EventArgs) Handles Button2.Click
        If cboTipoGastos.SelectedValue = 0 Then
            ConfigureNotification("No ha dado el tipo de gasto, seleccione un tipo.")
            Exit Sub

        End If

        If Not IsNumeric(txtMontoSolicita.Text) Then
            ConfigureNotification("No ha dado el monto de gasto.")
            Exit Sub
        End If

        If txtMontoSolicita.Text = 0 Then
            ConfigureNotification("No ha dado el monto de gasto.")
            Exit Sub
        End If

        If txtDeposito0.Text.Trim = String.Empty Then
            ConfigureNotification("La clave de deposito no puede estar vacia..")
            Exit Sub
        End If

        If txtAutorizacion.Text.Trim = String.Empty Then
            ConfigureNotification("El numero de autorización no puede estar vacio..")
            Exit Sub
        End If

        Dim respuesta As Boolean
        'txtAutorizacion
        respuesta = Insert_gasto(Session("noGestionIntegral"), rfcGestor.Text, 1, cboTipoGastos.SelectedValue, cboTipoGastos.SelectedItem.Text.Trim.ToUpper, txtMontoSolicita.Text, Label16.Text.Trim.ToUpper, lblEstado.Text, lblMpio.Text, Label10.Text.Trim, txtDeposito0.Text, txtAutorizacion.Text)
        If respuesta = True Then

            ConfigureNotification("Se ha guardado el gasto.")
            ' se envian los email para avisar que hay un nuevo gasto pendiente de autorizar.
            'EnvioMailgasto(2)
            cargaGastos() ' cargamos otra vez la informacion del grid para q se vean los cambios
            Panel1.Visible = False
            Response.Redirect("PagoGestor.aspx")
        End If
    End Sub

    Protected Sub dtgPagos_ItemEvent(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles dtgPagos.ItemEvent

    End Sub

    'CheckBox chkbx = (CheckBox)sender; 

    '//to access the row containg the Corresponding CheckBox 
    'GridDataItem item = (GridDataItem)chkbx.NamingContainer; 
    '// to get the CheckBox value 
    'bool checkValue = chkbx.Checked; 


    'Public Sub cargaGastosC()
    '    Dim ds As New DataSet
    '    Dim FInicial As Telerik.Web.UI.RadDatePicker = SelectorFechas.FindControl("rdFI")
    '    Dim FFinal As Telerik.Web.UI.RadDatePicker = SelectorFechas.FindControl("rdFF")

    '    Dim FechaI As String = FInicial.SelectedDate.Value.ToString("yyyy-MM-dd") '  .SelectedDate .ToString("yyyy-MM-dd")
    '    Dim FechaF As String = FFinal.SelectedDate.Value.ToString("yyyy-MM-dd") '.ToString("yyyy-MM-dd")
    '    Dim serv As String = txtServ.Text
    '    Dim gest As String = txtGest.Text
    '    ds = csDAL.buscaReciboPago(FechaI, FechaF, serv, gest)
    '    With RadGrid2
    '        .DataSource = ds.Tables(0).Rows
    '        .DataBind()
    '    End With
    '    'rfc = ""
    '    ds.Clear()
    '    ds.Dispose()
    'End Sub
    'Public Sub cargaGastosAutorizados()
    '    Dim ds As New DataSet

    '    Dim FInicial As Telerik.Web.UI.RadDatePicker = SelectorFechas.FindControl("rdFI")
    '    Dim FFinal As Telerik.Web.UI.RadDatePicker = SelectorFechas.FindControl("rdFF")

    '    Dim FechaI As String = FInicial.SelectedDate.Value.ToString("yyyy-MM-dd") '  .SelectedDate .ToString("yyyy-MM-dd")
    '    Dim FechaF As String = FFinal.SelectedDate.Value.ToString("yyyy-MM-dd") '.ToString("yyyy-MM-dd")
    '    Dim serv As String = txtServ.Text
    '    Dim gest As String = txtGest.Text

    '    ds = csDAL.buscaPagosAutorizados(FechaI, FechaF, serv, gest)
    '    With rgAutorizados
    '        .DataSource = ds.Tables(0).Rows
    '        .DataBind()
    '    End With
    '    'rfc = ""
    '    ds.Clear()
    '    ds.Dispose()
    '    rgAutorizados.Visible = True
    'End Sub
    'Public Sub cargaGastosCancelados()
    '    Dim ds As New DataSet
    '    Dim FInicial As Telerik.Web.UI.RadDatePicker = SelectorFechas.FindControl("rdFI")
    '    Dim FFinal As Telerik.Web.UI.RadDatePicker = SelectorFechas.FindControl("rdFF")

    '    Dim FechaI As String = FInicial.SelectedDate.Value.ToString("yyyy-MM-dd") '  .SelectedDate .ToString("yyyy-MM-dd")
    '    Dim FechaF As String = FFinal.SelectedDate.Value.ToString("yyyy-MM-dd") '.ToString("yyyy-MM-dd")
    '    Dim serv As String = txtServ.Text
    '    Dim gest As String = txtGest.Text
    '    ds = csDAL.buscaPagosCancelados(FechaI, FechaF, serv, gest)
    '    With rgCancelados
    '        .DataSource = ds.Tables(0).Rows
    '        .DataBind()
    '    End With
    '    'rfc = ""
    '    ds.Clear()
    '    ds.Dispose()
    '    rgCancelados.Visible = True
    'End Sub



    'Protected Sub BtnResultado_Click(sender As Object, e As System.EventArgs) Handles BtnResultado.Click
    '    If RadComboBox1.SelectedValue = 1 Then
    '        cargaGastosC()
    '        RadGrid2.Visible = True
    '        rgAutorizados.Visible = False
    '        rgCancelados.Visible = False
    '        RadButton1.Visible = True
    '    ElseIf RadComboBox1.SelectedValue = 2 Then
    '        cargaGastosAutorizados()
    '        rgAutorizados.Visible = True
    '        RadGrid2.Visible = False
    '        rgCancelados.Visible = False
    '        RadButton1.Visible = False
    '    Else
    '        cargaGastosCancelados()
    '        rgCancelados.Visible = True
    '        RadGrid2.Visible = False
    '        rgAutorizados.Visible = False
    '        RadButton1.Visible = False
    '    End If
    'End Sub

    'Protected Sub RadButton1_Click(sender As Object, e As System.EventArgs) Handles RadButton1.Click
    '    RadGrid2.AllowPaging = False
    '    RadGrid2.Columns(7).Visible = False
    '    RadGrid2.Columns(8).Visible = False
    '    RadGrid2.Columns(9).Visible = False


    '    RadGrid2.ExportSettings.OpenInNewWindow = True
    '    RadGrid2.ExportSettings.ExportOnlyData = False

    '    RadGrid2.MasterTableView.ExportToExcel()
    'End Sub


    'Protected Sub RadGrid2_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid2.ItemCommand
    '    Dim dataItem As GridDataItem = e.Item
    '    Dim indexRow As Integer = Convert.ToInt32(e.Item.ItemIndex)
    '    Dim item As GridDataItem = RadGrid2.Items(indexRow)
    '    Dim item3 As GridDataItem = DirectCast(e.Item, GridDataItem)

    '    If e.CommandName = "cmdCancela" Then

    '        Session("servicio") = item.Cells(2).Text
    '        Dim fechaCancela As String = "getdate()"
    '        Dim usua As String = Session("clvUsuario")
    '        csDAL.update_cancelaComprobacion(fechaCancela, usua, Session("servicio"))
    '        cargaGastosC()
    '    ElseIf e.CommandName = "cmdGuardar" Then
    '        Session("servicio") = item.Cells(2).Text
    '        Dim usua1 As String = Session("clvUsuario")
    '        Dim fechaAprueba As String = "getdate()"
    '        Dim txt As Telerik.Web.UI.RadTextBox = e.Item.FindControl("RadTextBox1")


    '        If txt.Text <> Nothing Then

    '            csDAL.update_GuardaComprobacion(txt.Text.Trim, fechaAprueba, usua1, Session("servicio"))
    '            cargaGastosC()
    '        Else
    '            ConfigureNotification("Para guardar autorizacion se necesita poner No. de Recibo")
    '        End If

    '    End If
    'End Sub

    'Protected Sub RadButton2_Click(sender As Object, e As System.EventArgs) Handles RadButton2.Click
    '    dtgPagos.AllowPaging = False
    '    dtgPagos.ExportSettings.OpenInNewWindow = True
    '    dtgPagos.ExportSettings.ExportOnlyData = False
    '    dtgPagos.MasterTableView.ExportToExcel()
    'End Sub

    Public Sub RecalculaValoresGrid()

        Dim cuentaSi As Integer = 0
        Dim cuentaNo As Integer = 0

        For Each item As GridDataItem In dtgPagos.Items

            Dim rblAceptado As RadioButtonList = item.FindControl("rblAcep") ' checamos si esta aceptado o rechazado
            

            If Trim(item.Cells(7).Text) IsNot String.Empty Then
                rblAceptado.SelectedValue = 1
                rblAceptado.Enabled = False
                If rblAceptado.SelectedValue = 1 Then cuentaSi += CInt(Trim(item.Cells(3).Text))

            Else
                If rblAceptado.SelectedValue = 1 Then cuentaSi += CInt(Trim(item.Cells(3).Text))
                If rblAceptado.SelectedValue = 0 Then cuentaNo += CInt(Trim(item.Cells(3).Text))
            End If

        Next

        lblMontoSI.Text = " $" & cuentaSi & ".00"
        lblMontoNo.Text = " $" & cuentaNo & ".00"
        lblMonto0.Text = Trim(lblMonto.Text)
        lblMontoNo.Visible = True
        lblMontoSI.Visible = True

    End Sub

    Protected Sub cboTipoGastos_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboTipoGastos.SelectedIndexChanged

        ' buscamos los tipos de gastos y sus limites, para que no se pueda registrar mas del limite, si se pone mas por default se deja el limite
        If cboTipoGastos.SelectedValue <> 0 Then
            Dim dsLimite As DataSet = New DataSet
            Dim comando As String = "select  LIMITE_GASTO from   TIPOS_GASTOS_GESTORIA where   CLV_GASTO=" & cboTipoGastos.SelectedValue
            dsLimite = csSQLsvr.QueryDataSet(comando, Session("connGestion"))
            Dim dr As DataRow

            For Each dr In dsLimite.Tables(0).Rows
                Label13.Text = dr("LIMITE_GASTO")
                txtMontoSolicita.MaxValue = dr("LIMITE_GASTO")
            Next

            dsLimite.Clear()
        Else
            Label13.Text = 0
            txtMontoSolicita.MaxValue = 0
        End If

    End Sub
  
End Class

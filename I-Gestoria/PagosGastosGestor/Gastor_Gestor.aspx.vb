
Imports System.Data

Imports System.Data.SqlClient
Imports Telerik.Web.UI

Partial Class PagosGastosGestor_Gastor_Gestor
    Inherits System.Web.UI.Page
    Dim csNeg As New ClaseNegocios
    Dim csSQLsvr As New BaseDatosSQL
    Dim csDAL As New DALClass
    Dim Cadena As String = GlobalVariables.sqlString

#Region "procedimientos"

    Public Sub CargaGastosServicio(ByVal noservicio As String)
        Dim comando As String = " select * from GASTOS_VW where SERVICIO='" & noservicio & "' order by FECHAREGISTRO desc"
        Dim dsGastos As DataSet = New DataSet
        dsGastos = csSQLsvr.QueryDataSet(comando, Session("connGestion"))

        With dtgGastos
            .DataSource = dsGastos.Tables(0)
            .DataBind()
        End With

        RecalculaValoresGrid()
        ' nivel de operador, no puede autoriza , cancelar o poner fichas de deposito, favor de verificar el numero
        If Session("nivel") = 1 Then
            dtgGastos.Columns(0).Display = False
            dtgGastos.Columns(1).Display = False
            dtgGastos.Columns(2).Display = False
            dtgGastos.Columns(3).Display = False
            dtgGastos.Columns(4).Display = False
        End If

        If Session("nivel") = 3 Then ' nivel de supervisor solo puede autorizar y cancelar
            dtgGastos.Columns(2).Display = False
            dtgGastos.Columns(3).Display = False
            dtgGastos.Columns(4).Display = False

        End If

        If Session("nivel") = 4 Then ' nivel de Tesoreria solo puede registrar el numero de ficha de deposito
            dtgGastos.Columns(0).Display = False
            dtgGastos.Columns(1).Display = False
            dtgGastos.Columns(2).Display = True
            dtgGastos.Columns(3).Display = False
            dtgGastos.Columns(4).Display = False
        End If

    End Sub


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


    Protected Sub ConfigureNotificationSiNo(ByVal texto As String)
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

    Public Function Insert_gasto(ByVal SERVICIO As String, ByVal RFCGESTOR As String, ByVal CANTIDAD As String, ByVal CLAVETAB As String, ByVal TABDESCRIP As String, ByVal TOTALGASTO As String, ByVal USUARIO As String, ByVal ESTADO As String, ByVal MPIO As String, ByVal CTACLABE As String) As Boolean
        Dim conn As New SqlConnection(Session("connGestion"))
        Dim cmd As New SqlCommand("Insert_GastosGestor", conn)
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


    Public Sub EnvioMailgasto(ByVal tipoMial As Integer)
        ' Se envia el mail.

        Dim comando As String = "select * from Gastos_mail where tipoMail=" & tipoMial ' tipomail=2 es para enviar a los supervisores es cuando se registra , tipomail=1 es para cuando se autoriza
        Dim dsmail As DataSet = New DataSet
        dsmail = csSQLsvr.QueryDataSet(comando, Session("connGestion"))
        Dim tipo As String = ""
        If tipoMial = 2 Then
            tipo = "CONFIRMACION DE DEPOSITO DE PAGO"
        Else
            tipo = "AVISO DE REGISTRO DE GASTO"
        End If

        Dim mensaje As String = "AVISO DE " & tipo & ":" & vbCr & _
                     "DATOS DEL SERVICIO" & vbCr & _
                     "No. de Servicio:" & " " & Session("noGestionIntegral") & vbCr & _
                     "Tipo de Servicio:" & " " & Trim(Label8.Text) & vbCr & _
                     "DATOS DEL GASTO" & vbCr & _
                     "Gestor:" & " " & Trim(Label6.Text) & vbCr & _
                     "Fecha del gasto:" & " " & Trim(lblFecha.Text) & vbCr
        If tipoMial = 1 Then mensaje = mensaje & "Tipo de gasto:" & " " & Trim(cboTipoGastos.SelectedItem.Text) & vbCr
        If tipoMial = 1 Then mensaje = mensaje & "Monto que se solicito:" & " $" & Trim(txtMontoSolicita.Text.Trim) & ".00" & vbCr & _
                     "Usuario que requisita gasto:" & " " & Trim(Session("clvUsuario")) & vbCr & _
                     "Banco del Gestor: " & Label21.Text & vbCr & _
                     "Clabe interbancaria de Gestor: " & Label10.Text & vbCr
        If tipoMial = 2 Then mensaje = mensaje & "Fecha del deposito:" & " " & Now() & vbCr

        Dim dr As DataRow

        ' Envio Emial de pruebas
        Try
            Dim para As New List(Of String)
            Dim copia As New List(Of String)
            'For Each dr In dsmail.Tables(0).Rows

            'Esta linea se descomenta aqui tiene los usuarios a los q se enviara
            'para.Add(dr("ctaMail"))


            'csNeg.EnviarMail("robotGestoria@gintegra.com.mx", "ncalvo@gintegra.com.mx", "Gasto Registrado i-gestoria", mensaje, "192.168.23.50", 0, "")

            ' descomentar esta linea cuando se encuentre en produccion, envio real de email
            ' csNeg.EnviarMail("robotGestoria@gintegra.com.mx", dr("ctamail"), "Gasto Registrado i-gestoria", mensaje, "192.168.23.50", 0, "")
            'Next
            para.Add("ncalvo@gintegra.com.mx")
            para.Add("jbahena@gintegra.com.mx")
            para.Add("czavala@gintegra.com.mx")
            csNeg.EnviarTxt("robotGestoria@gintegra.com.mx", para, copia, tipo & " I-GESTORIA", mensaje, Nothing, Nothing, Nothing, Nothing)

        Catch ex As Exception
            ConfigureNotification("El gasto fue registrado con exito, pero hay error para enviar el correo para su autorizacion, por favor contacte al supervisor para que se autorice...")
            Exit Sub
        End Try

        dsmail.Clear()
    End Sub


    Private Sub TiposGastos()
        csSQLsvr.LlenarCombo(cboTipoGastos, "select  CLV_GASTO, DESCRIPCION_GASTO from  TIPOS_GASTOS_GESTORIA order by CLV_GASTO", Session("connGestion"))
    End Sub

    Private Sub TiposCancelacion()
        csSQLsvr.LlenarCombo(cboTipoCancela, "SELECT    clv_cancela_gasto, Descrip_cancela_gasto FROM causas_cancela_gasto", Session("connGestion"))
    End Sub
#End Region

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        ' cometariar las siguientes lineas cuando se monte a producion, solo son para pruebas
        '************************************
        'Session("noGestionIntegral") = 20141310224507
        'Session("clvUsuario") = "CZL"
        'Session("nivel") = 4
        '****************************************

        If Not Page.IsPostBack Then

            If Session("noGestionIntegral") <> Nothing Then

                Session("nogasto") = Nothing
                CargaGastosServicio(Session("noGestionIntegral")) ' rutina que carga los datos en el grid de pagos, verificar el nievel del usuario para ver que opciones se activan
                Label5.Text = Session("noGestionIntegral")
                Label16.Text = Session("clvUsuario")
                lblFecha.Text = Format(Now(), "MM/dd/yyyy")
                TiposGastos() ' carga los tipos de gastos a capturar
                TiposCancelacion() ' carga los tipos de cancelacion

                Dim dsGastos As DataSet = New DataSet
                dsGastos = csDAL.BuscaExpedienteDatos(Session("noGestionIntegral")) ' buscamos todos los datos del servicio
                Dim dr As DataRow
                For Each dr In dsGastos.Tables(0).Rows
                    lblEstado.Text = dr("reporte_clvEstado")
                    lblMpio.Text = dr("reporte_clvMpio")
                    ' Empezamos las validaciones.

                    If dr("rfc_gestor").ToString.Trim = String.Empty Then
                        ConfigureNotification("No hay gestor Asignado, no se puede registrar un gasto...")
                        Exit Sub
                    End If
                    ' Gestor asignado, traemos sus datos
                    rfcGestor.Text = dr("rfc_gestor")
                    Label6.Text = dr("paterno").ToString.Trim & " " & dr("nombre").ToString.Trim
                    Label8.Text = dr("servicio_nomServicio").ToString.Trim
                    If IsDBNull(dr("clave")) Then dr("clave") = String.Empty
                    Label10.Text = dr("clave")

                    'BancoNombre

                    If IsDBNull(dr("BancoNombre")) Then dr("BancoNombre") = String.Empty
                    Label21.Text = dr("BancoNombre")


                    If dr("reporte_status") <> 0 Then
                        ConfigureNotification("El servicio no esta activo, no se puede registrar un gasto.")
                        Exit Sub
                    End If


                    If Not IsDBNull(dr("fecha_verifico")) Then
                        If Format(dr("fecha_verifico"), "MM/dd/yyyy") <> "01/01/1900" Then
                            ConfigureNotification("El expediente ya ha sido entregado a Backoffice y esta ya como verificado, no se puede registrar un gasto.")
                            Exit Sub
                        End If
                    End If

                Next
                ' si pasa las verificados activamos el boton para resgistrar el gasto
                Button1.Enabled = True
                Button6.Enabled = True
                txtMontoSolicita.Text = 0
                dsGastos.Clear()

            Else

                ConfigureNotification("No ha dado ningun número de servicio de gestoria...")
                Exit Sub
            End If
        Else
            If Session("noGestionIntegral") <> Nothing Then
                Dim master As MasterPageGestionOperativa = DirectCast(Me.Master, MasterPageGestionOperativa)
                Dim nExpediente As Telerik.Web.UI.RadNumericTextBox = Me.Master.FindControl("txtNoGestion")
                If Label5.Text <> nExpediente.Text Then
                    Session("noGestionIntegral") = nExpediente.Text
                    Response.Redirect("Gastor_Gestor.aspx")
                End If
            End If

        End If

    End Sub

    Public Sub RecalculaValoresGrid()

        For Each item As GridDataItem In dtgGastos.Items

            If Trim(item.Cells(15).Text) = "01/01/1900" Then
                item.Cells(15).Text = ""
            End If

            If Trim(item.Cells(17).Text) = "01/01/1900" Then
                item.Cells(17).Text = ""
            End If

            If Trim(item.Cells(19).Text) = "01/01/1900" Then
                item.Cells(19).Text = ""
            End If

            If Trim(item.Cells(20).Text) = "01/01/1900" Then
                item.Cells(20).Text = ""
            End If

            If Trim(item.Cells(22).Text) = "01/01/1900" Then
                item.Cells(20).Text = ""
            End If

        Next

    End Sub

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

        lit.Text = "¿desea registrar un nuevo gasto por la cantidad de: $" & txtMontoSolicita.Text & ".00?"
        ConfigureNotificationSiNo("Se ha guardado el gasto.")

    End Sub

    Protected Sub btnAceptar_Click(sender As Object, e As System.EventArgs) Handles btnAceptar.Click

        Dim respuesta As Boolean
        respuesta = Insert_gasto(Session("noGestionIntegral"), rfcGestor.Text, 1, cboTipoGastos.SelectedValue, cboTipoGastos.SelectedItem.Text.Trim.ToUpper, txtMontoSolicita.Text, Label16.Text.Trim.ToUpper, lblEstado.Text, lblMpio.Text, Label10.Text.Trim)
        If respuesta = True Then
            ConfigureNotification("Se ha guardado el gasto.")
            ' se envian los email para avisar que hay un nuevo gasto pendiente de autorizar.
            'EnvioMailgasto(2)
            CargaGastosServicio(Session("noGestionIntegral")) ' cargamos otra vez la informacion del grid para q se vean los cambios
            RecalculaValoresGrid()
            Panel1.Visible = False
        End If
    End Sub

    Protected Sub btnRechazar_Click(sender As Object, e As System.EventArgs) Handles btnRechazar.Click
        
    End Sub

    Protected Sub dtgGastos_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles dtgGastos.ItemCommand
        If e.CommandName = "cmdAutoriza" Then
            Dim nogasto As Integer = e.Item.Cells(6).Text ' le  asiganmos el numero de gasto que se registro en la tabla GastosGestor
            Dim status As Integer = e.Item.Cells(7).Text ' le  asiganmos el status del gasto que se registro en la tabla GastosGestor, 0= resgitrado 1= autorizado 2= autorizado por tesoreria 3=cancelado

            If status = 1 Or status = 2 Or status = 3 Then
                ConfigureNotification("El gasto ya no se puede autorizar.")
                Exit Sub
            End If

            Dim comando As String = "update GastosGestor set STATUSGASTO=1, FECHA_AUTO_GASTO=getdate(), USUARIOAUTO='" & Session("clvUsuario") & "' where numConsec=" & nogasto
            If csSQLsvr.EjecutarSP(comando, Session("connGestion")) = Estatus.Exito Then
                ConfigureNotification("Gasto autorizado.")
                EnvioMailgasto(1)
                CargaGastosServicio(Session("noGestionIntegral")) ' cargamos otra vez la informacion del grid para q se vean los cambios
                RecalculaValoresGrid()
            Else
                ConfigureNotification("Error al autorizar el gasto, favor de verificar.")
            End If
        End If


        If e.CommandName = "cmdCancela" Then

            Session("nogasto") = e.Item.Cells(6).Text ' le  asiganmos el numero de gasto que se registro en la tabla GastosGestor
            Dim status As Integer = e.Item.Cells(7).Text ' le  asiganmos el status del gasto que se registro en la tabla GastosGestor, 0= resgitrado 1= autorizado 2= autorizado por tesoreria 3=cancelado
            If status > 0 Then
                ConfigureNotification("El gasto ya no se puede cancelar.")
                Exit Sub
            End If

            Panel2.Visible = True
            Panel1.Visible = False
            Panel3.Visible = False
            Panel4.Visible = False

        End If
        If e.CommandName = "cmdRegDeposito" Then

            txtDeposito.Text = ""
            Session("nogasto") = e.Item.Cells(6).Text ' le  asiganmos el numero de gasto que se registro en la tabla GastosGestor
            Dim status As Integer = e.Item.Cells(7).Text ' le  asiganmos el status del gasto que se registro en la tabla GastosGestor, 0= resgitrado 1= autorizado 2= autorizado por tesoreria 3=cancelado
            If status = 0 Then
                ConfigureNotification("El gasto requiere ser autorizado para poder registrar una clave de deposito.")
                Exit Sub
            ElseIf status = 2 Or status = 3 Then
                ConfigureNotification("El gasto ya no se le puede registrar una clave de deposito.")
                Exit Sub
            End If
            

            Panel1.Visible = False
            Panel2.Visible = False
            Panel3.Visible = True
            Panel4.Visible = False
        End If

        If e.CommandName = "cmdautTesoreria" Then

            txtAutorizacion.Text = ""
            Session("nogasto") = e.Item.Cells(6).Text ' le  asiganmos el numero de gasto que se registro en la tabla GastosGestor
            Dim status As Integer = e.Item.Cells(7).Text ' le  asiganmos el status del gasto que se registro en la tabla GastosGestor, 
            '0= resgitrado 1= autorizado 2= autorizado por tesoreria 3=cancelado
            If status = 0 Or status = 4 Or status = 3 Or status = 1 Then
                ConfigureNotification("El gasto ya no se le puede registrar un numero de autorización.")
                Exit Sub
            End If

            Panel1.Visible = False
            Panel2.Visible = False
            Panel3.Visible = False
            Panel4.Visible = True

        End If

    End Sub

    Protected Sub Button3_Click(sender As Object, e As System.EventArgs) Handles Button3.Click
        If cboTipoCancela.SelectedItem.Value <> 0 Then
            Dim causa_cancel As Integer = cboTipoCancela.SelectedItem.Value
            Dim comando As String = "update GastosGestor set STATUSGASTO=3, fecha_cancel=getdate(), usuario_cancel='" & Session("clvUsuario") & "', causa_cancel=" & causa_cancel & " where numConsec=" & Session("nogasto")
            If csSQLsvr.EjecutarSP(comando, Session("connGestion")) = Estatus.Exito Then
                ConfigureNotification("Gasto cancelado.")
                Panel2.Visible = False
                CargaGastosServicio(Session("noGestionIntegral")) ' cargamos otra vez la informacion del grid para q se vean los cambios
                RecalculaValoresGrid()
            Else
                ConfigureNotification("Error al cancelar el gasto, favor de verificar.")
            End If
        Else
            ConfigureNotification("Escoga una causa de cancelación.")
        End If

    End Sub

    Protected Sub Button4_Click(sender As Object, e As System.EventArgs) Handles Button4.Click

        If txtDeposito.Text.Trim <> String.Empty Then
            Dim GASTODOC As String = txtDeposito.Text.Trim
            Dim comando As String = "update GastosGestor set STATUSGASTO=2, GASTODOC='" & GASTODOC & "', FECHA_DESPOSITO=getdate(), USUARIO_DEPOSITO='" & Session("clvUsuario") & "' where numConsec=" & Session("nogasto")
            If csSQLsvr.EjecutarSP(comando, Session("connGestion")) = Estatus.Exito Then
                ConfigureNotification("La clave del desposito se registro correctamente.")
                EnvioMailgasto(2)
                Panel3.Visible = False
                CargaGastosServicio(Session("noGestionIntegral")) ' cargamos otra vez la informacion del grid para q se vean los cambios
                RecalculaValoresGrid()
            Else
                ConfigureNotification("Error al registrar la clave deposito, favor de verificar.")
            End If
        Else
            ConfigureNotification("La clave de deposito no puede estar vacia..")
        End If



    End Sub

    Protected Sub Button1_Click(sender As Object, e As System.EventArgs) Handles Button1.Click
        Panel1.Visible = True
        Panel2.Visible = False
        Panel3.Visible = False
        Panel4.Visible = False
    End Sub

    Protected Sub Button5_Click(sender As Object, e As System.EventArgs) Handles Button5.Click

        If txtAutorizacion.Text.Trim <> String.Empty Then
            Dim NumAutorizacion As String = txtAutorizacion.Text.Trim
            Dim comando As String = "update GastosGestor set STATUSGASTO=4, numAutTesoreria='" & NumAutorizacion & "', fecha_AutTesoreria=getdate(), usuario_AutTesoreria='" & Session("clvUsuario") & "' where numConsec=" & Session("nogasto")
            If csSQLsvr.EjecutarSP(comando, Session("connGestion")) = Estatus.Exito Then
                ConfigureNotification("El numero de autorizacion se registro correctamente.")
                Panel4.Visible = False
                CargaGastosServicio(Session("noGestionIntegral")) ' cargamos otra vez la informacion del grid para q se vean los cambios

                RecalculaValoresGrid()
                'EnvioMailgasto(2)
            Else
                ConfigureNotification("Error al registrar numero de autorizacion, favor de verificar.")
            End If

        Else
            ConfigureNotification("El numero de autorizacion no puede estar vacio..")
        End If
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

    Protected Sub Button6_Click(sender As Object, e As System.EventArgs) Handles Button6.Click
        dtgGastos.AllowPaging = False
        dtgGastos.Columns(0).Visible = False
        dtgGastos.Columns(1).Visible = False
        dtgGastos.Columns(2).Visible = False
        dtgGastos.Columns(3).Visible = False
        dtgGastos.Columns(4).Visible = False
        dtgGastos.Columns(5).Visible = False

        dtgGastos.ExportSettings.OpenInNewWindow = True
        dtgGastos.ExportSettings.ExportOnlyData = False

        dtgGastos.MasterTableView.ExportToExcel()
    End Sub
End Class

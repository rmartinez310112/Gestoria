Imports System.Data
Imports System.Web
Imports System.Data.SqlClient

Partial Class AsignacionControl_TableroControlGestion
    Inherits System.Web.UI.Page
    Dim csNeg As New ClaseNegocios
    Dim csSQLsvr As New BaseDatosSQL
    Dim csDAL As New DALClass
    Dim conn As SqlConnection

#Region "Procesos"


    Private Sub cargaMpioNoAsignados(ByVal clvestado As Integer, ByVal rfcGestor As String)
        Dim comando As String = "select * from mpio where CLAVE not in (Select  clave_mpio  from   Gestores_MultiEstado where  clave_estado=" & clvestado & " and rfcGestor='" & rfcGestor & "') and ESTADO=" & clvestado
        Dim ds As New DataSet
        ds = csSQLsvr.QueryDataSet(comando, Session("connGestion"))
        With lstEstados
            .DataSource = ds.Tables(0)
            .DataValueField = "clave"
            .DataTextField = "nombre"
            .DataBind()
        End With
      

    End Sub

    Private Sub cargaMpioAsignados(ByVal clvestado As Integer, ByVal rfcGestor As String)
        Dim comando As String = "select * from mpio where CLAVE  in (Select  clave_mpio  from   Gestores_MultiEstado where  clave_estado=" & clvestado & " and rfcGestor='" & rfcGestor & "') and ESTADO=" & clvestado
        Dim ds As New DataSet
        ds = csSQLsvr.QueryDataSet(comando, Session("connGestion"))
        With lstEstadosAgre
            .DataSource = ds.Tables(0)
            .DataValueField = "clave"
            .DataTextField = "nombre"
            .DataBind()
        End With
        

    End Sub


    Public Sub ABRIR_VENTANA(ByVal PopUpWindowPage As String, ByVal alto As Integer, ByVal largo As Integer)
        Dim Script As String = ""
        Script = " <script language=JavaScript id='PopupWindow'>  var confirmWin = null; confirmWin = window.open('" & PopUpWindowPage & "','myWindow','status = 1, scrollbars=1,height = " & alto & ", width = " & largo & ", resizable = 1 '); if((confirmWin != null) && (confirmWin.opener==null)) { confirmWin.opener = self; } </script> "
        If Not ClientScript.IsStartupScriptRegistered("PopupWindow") Then
            ClientScript.RegisterStartupScript(Me.GetType, "PopupWindow", Script)
        End If
    End Sub

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim tipo As String = Request.QueryString("tipo")
        Button2.Visible = False
        If Not Page.IsPostBack Then
            llenalist()
            cargaBancos()
            cargaBancos2()
            cargaEstados()
            cargaMpio(0)

            '
            If Request.QueryString("tipo") = 0 Then 'Cuando Tipo  = 0
                ModoVentana(0)
                ' llenamos_Estado()
            Else                                   'Cuando Tipo  = 1
                ModoVentana(1)
            End If
            ValidaRfc()
        End If
    End Sub
    Public Sub ValidaRfc()
        If TxtRFC.Text <> Nothing Then

            Dim ds As New DataSet
            ds = csDAL.BuscaGestoresconPoder(TxtRFC.Text)

            If ds.Tables(0).Rows.Count <> 0 Then
                Dim dr As DataRow
                For Each dr In ds.Tables(0).Rows
                    Dim exist As Integer
                    exist = dr("clv_Empresas")


                    'For Each chklst_Poderes.Items.Item In chklst_Poderes.Items

                    'Next
                    'If chklst_Poderes.Items.FindByValue(dr("clv_Empresas")) Then

                    'End If

                    Dim item As ListItem
                    For Each item In chklst_Poderes.Items
                        If item.Value = exist Then
                            'codigo para agregar registro
                            item.Selected = True
                        End If
                    Next
                Next

            End If

        End If
    End Sub

    Public Sub llenalist()

        Dim comando As String = ""
        comando = "SELECT [cliente_clvCliente], [cliente_NomCliente] FROM [Clientes] WHERE [cliente_clvCliente]<>0"
        csSQLsvr.LlenarList(chklst_Poderes, comando, Session("connGestion"))

    End Sub


    Protected Sub ConfigureNotification(ByVal texto As String)
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

    Public Sub cargaEstados()
        Dim comando As String = ""

        comando = "select distinct clave as clvEstado,NOMBRE as Nombre_Estado from Estados order by clvEstado"

        csSQLsvr.LlenarRadCombo(CboEstado, comando, Session("connGestion"))
        csSQLsvr.LlenarRadCombo(CboEstadoAtencion, comando, Session("connGestion"))

        csSQLsvr.LlenarRadCombo(CboEstados, comando, Session("connGestion"))
        'csSQLsvr.LlenarRadCombo(CboEstadoAtencion, comando, Session("connGestion"))

    End Sub

    Public Sub cargaMpio(ByVal Estado As Integer)
        Dim comando As String = ""

        If Estado <> 0 Then
            comando = "select 0 as nummpio, 'seleccione' as Nombre_mpio union Select nummpio, Nombre_mpio from mpio_estado_gestoria_vw where numedo = " & CboEstado.SelectedValue & " order by Nombre_mpio"
        Else
            comando = "select 0 as nummpio, 'seleccione' as Nombre_mpio union Select nummpio, Nombre_mpio from mpio_estado_gestoria_vw order by Nombre_mpio"
        End If

        csSQLsvr.LlenarRadCombo(CboMpio, comando, Session("connGestion"))

    End Sub

    Public Sub cargaBancos()
        Dim comando As String = ""

        comando = "Select Id,nombre from Bancos order by Id"

        csSQLsvr.LlenarRadCombo(CboBancos, comando, Session("connGestion"))

    End Sub
    Public Sub cargaBancos2()
        Dim comando As String = ""

        comando = "Select Id,nombre from Bancos order by Id"

        csSQLsvr.LlenarRadCombo(CboBancos2, comando, Session("connGestion"))

    End Sub
    Protected Sub CboEstado_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles CboEstado.SelectedIndexChanged
        cargaMpio(CboEstado.SelectedValue)
    End Sub

    Protected Sub RdTipoPersona_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RdTipoPersona.SelectedIndexChanged
        If RdTipoPersona.SelectedValue = 0 Then
            LlbNombre.Text = "Nombre"
            LblAMaterno.Visible = True
            LblAPaterno.Visible = True
            RadTxtAMaterno.Visible = True
            RadTxtAPaterno.Visible = True
            'RadTxtNombre.Width = "160px"
        Else
            LlbNombre.Text = "Nombre Comercial / Razon Social"
            LblAMaterno.Visible = False
            LblAPaterno.Visible = False
            RadTxtAMaterno.Visible = False
            RadTxtAPaterno.Visible = False
            'RadTxtNombre.Width = "310px"
        End If
    End Sub

    Protected Sub CmdAlta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdAlta.Click

        Dim rfc As String = Me.TxtRFC.Text
        Dim NOMBRE As String = Me.RadTxtNombre.Text
        Dim APATERNO As String = Me.RadTxtAPaterno.Text
        Dim AMATERNO As String = Me.RadTxtAMaterno.Text
        Dim CALLEYNUMERO As String = Me.TxtDireccion.Text
        Dim COLONIA As String = Me.TxtColonia.Text
        Dim ESTADO As String = Me.CboEstado.SelectedValue
        Dim MPIO As String = Me.CboMpio.SelectedValue
        Dim CP As String = Me.TxtCP.Text
        Dim CELULAR As String = Me.TxtCelular.Text
        Dim TELFIJO As String = Me.TxtFijo.Text
        Dim NEXTEL As String = Me.TxtNextel.Text
        Dim EMAIL As String = Me.TxtEmail.Text
        Dim CLABE As String = Me.TxtClabe.Text
        Dim BANCO As String = Me.CboBancos.SelectedValue.Trim.ToUpper
        Dim TABULADOR As String = Me.CboTabulador.SelectedValue
        Dim TIPOPERSONA As String = RdTipoPersona.SelectedValue
        Dim CLABE2 As String = TxtClabe2.Text
        Dim BANCO2 As String = Me.CboBancos2.SelectedValue.Trim.ToUpper


        Dim CUENTAERRORES As Integer = 0
        If (CELULAR = Nothing And TELFIJO = Nothing And NEXTEL = Nothing And EMAIL = Nothing) Then
            ConfigureNotification("Se requiere al menos un dato de contacto (telefono fijo, celular, nextel o email)")
            Exit Sub
        End If

        If CP = Nothing Then
            CP = 0
        End If

        If BANCO = "Seleccionar" Then
            BANCO = ""
        End If

        If NOMBRE = "" Then
            CUENTAERRORES = 1
        End If

        If APATERNO = "" Then
            CUENTAERRORES += 1
        End If

        If ESTADO = "0" Then
            CUENTAERRORES += 1
        End If

        If MPIO = "0" Then
            CUENTAERRORES += 1
        End If

        Dim valida As Integer
        valida = csDAL.ValidaGestores(Trim(rfc))
        If valida = 5 Then
            Dim resultado As String
            'Dim resultado1 As String
            Dim item As New ListItem
            Dim item1 As New ListItem


            resultado = csDAL.AltaGestores(Trim(rfc), Trim(NOMBRE), Trim(APATERNO), Trim(AMATERNO), Trim(CALLEYNUMERO) _
                               , Trim(COLONIA), Trim(ESTADO), Trim(MPIO), Trim(CP), Trim(CELULAR) _
                               , Trim(TELFIJO), Trim(NEXTEL), Trim(EMAIL), Trim(CLABE), Trim(BANCO) _
                               , Trim(TABULADOR), Trim(TIPOPERSONA), Trim(CLABE2), Trim(BANCO2))

            If (lstEstadosAgre.Items.Count >= 1) Then

                For Each item In lstEstadosAgre.Items
                    csDAL.InsertaMultipleEstadoMpio(rfc, CboEstados.SelectedItem.Value, item.Value)
                    'Dim valores As String = item.Value

                Next
            Else
                ConfigureNotification("Se requiere al menos un mpio.")
                Exit Sub
            End If

            If chklst_Poderes.SelectedValue <> Nothing Then

                For Each item1 In chklst_Poderes.Items
                    If item1.Selected = True Then
                        csDAL.InsertaMultiplePoderes(rfc, item1.Value)
                        'Dim valores As String = item.Value
                    End If
                Next


            End If




            If resultado = "0" Then
                ConfigureNotification("Se guardo con exito")
                Response.Redirect("Gestores.aspx")
            Else
                ConfigureNotification("Error al cargar los datos del gestor")
                Exit Sub
            End If
        Else
            Dim activo As String
            If valida = 0 Then
                activo = "Activo"
            Else
                activo = "Inactivo"
            End If
            ConfigureNotification("El Gestor con RFC: " & rfc & " ya se encuantra dado de alta y esta " & activo)
        End If

    End Sub

    Public Sub ModoVentana(ByVal tipo As Integer)
        If tipo = 0 Then
            Me.TxtRFC.ReadOnly = False
            Me.TxtRFC.Text = ""
            Me.RadTxtNombre.Text = ""
            Me.RadTxtAMaterno.Text = ""
            Me.RadTxtAPaterno.Text = ""
            Me.CboEstado.SelectedValue = 0
            Me.CboBancos.SelectedValue = 0
            Me.CboBancos2.SelectedValue = 0
            Me.CboMpio.SelectedValue = 0
            Me.CboEstadoAtencion.SelectedValue = 0
            Me.CboTabulador.SelectedValue = 0
            Me.TxtCelular.Text = ""
            Me.TxtClabe.Text = ""
            Me.TxtClabe2.Text = ""
            Me.TxtColonia.Text = ""
            Me.TxtCP.Text = ""
            Me.TxtDireccion.Text = ""
            Me.TxtEmail.Text = ""
            Me.TxtFijo.Text = ""
            Me.TxtNextel.Text = ""
            CmdAlta.Visible = True
            CmdModifica.Visible = False
        Else
            'csDAL.BuscaDatosGestores(Request.QueryString("rfc"))
            Dim datosGestion As New DataSet
            datosGestion = csDAL.BuscaDatosGestores(Request.QueryString("rfc"))
            Dim dr As DataRow

            For Each dr In datosGestion.Tables(0).Rows
                If Not IsDBNull(dr("EstadoBase")) Then
                    Me.CboEstado.SelectedValue = dr("EstadoBase")
                End If

                If Not IsDBNull(dr("banco")) Then
                    cargaBancos()
                    Me.CboBancos.SelectedValue = dr("banco")
                End If
                If Not IsDBNull(dr("banco2")) Then
                    cargaBancos2()
                    Me.CboBancos2.SelectedValue = dr("banco2")
                End If
                If Not IsDBNull(dr("EstadoBase")) Then
                    cargaEstados()
                    Me.CboEstadoAtencion.SelectedValue = dr("EstadoBase")
                End If

                If Not IsDBNull(dr("MpioBase")) Then
                    cargaMpio(dr("EstadoBase"))
                    Me.CboMpio.SelectedValue = dr("MpioBase")
                End If

                If Not IsDBNull(dr("TABULADOR")) Then
                    Me.CboTabulador.SelectedValue = dr("TABULADOR")
                End If

                If Not IsDBNull(dr("CELULAR")) Then
                    Me.TxtCelular.Text = dr("CELULAR")
                End If

                If Not IsDBNull(dr("clave")) Then
                    Me.TxtClabe.Text = Trim(dr("clave"))
                End If

                If Not IsDBNull(dr("clave2")) Then
                    Me.TxtClabe2.Text = Trim(dr("clave2"))
                End If

                If Not IsDBNull(dr("COLONIA")) Then
                    Me.TxtColonia.Text = dr("COLONIA")
                End If

                If Not IsDBNull(dr("CP")) Then
                    Me.TxtCP.Text = dr("CP")
                End If

                If Not IsDBNull(dr("CALLEYNUMERO")) Then
                    Me.TxtDireccion.Text = dr("CALLEYNUMERO")
                End If

                If Not IsDBNull(dr("EMAIL")) Then
                    Me.TxtEmail.Text = dr("EMAIL")
                End If

                If Not IsDBNull(dr("TEL1")) Then
                    Me.TxtFijo.Text = dr("TEL1")
                End If

                If Not IsDBNull(dr("TELNEX")) Then
                    Me.TxtNextel.Text = dr("TELNEX")
                End If

                If Not IsDBNull(dr("RFCAJUSTADOR")) Then
                    Me.TxtRFC.Text = dr("RFCAJUSTADOR")
                    Me.TxtRFC.ReadOnly = True
                End If

                If Not IsDBNull(dr("EMAIL")) Then
                    Me.TxtEmail.Text = dr("EMAIL")
                End If

                If Not IsDBNull(dr("NOMBRE")) Then
                    Me.RadTxtNombre.Text = dr("NOMBRE")
                End If

                If Not IsDBNull(dr("MATERNO")) Then
                    Me.RadTxtAMaterno.Text = dr("MATERNO")
                End If

                If Not IsDBNull(dr("PATERNO")) Then
                    Me.RadTxtAPaterno.Text = dr("PATERNO")
                End If

            Next

            'cuando tipo = 1
            CmdAlta.Visible = False
            CmdModifica.Visible = True
            datosGestion.Clear()
            datosGestion.Dispose()
            'llenamos_EstadoSinAsignar()
            'llenamos_EstadoAsignado()
        End If
    End Sub

    Protected Sub CmdModifica_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdModifica.Click
        Dim rfc As String = Me.TxtRFC.Text
        Dim NOMBRE As String = Me.RadTxtNombre.Text
        Dim APATERNO As String = Me.RadTxtAPaterno.Text
        Dim AMATERNO As String = Me.RadTxtAMaterno.Text
        Dim CALLEYNUMERO As String = Me.TxtDireccion.Text
        Dim COLONIA As String = Me.TxtColonia.Text
        Dim ESTADO As String = Me.CboEstado.SelectedValue
        Dim MPIO As String = Me.CboMpio.SelectedValue
        Dim CP As String = Me.TxtCP.Text
        Dim CELULAR As String = Me.TxtCelular.Text
        Dim TELFIJO As String = Me.TxtFijo.Text
        Dim NEXTEL As String = Me.TxtNextel.Text
        Dim EMAIL As String = Me.TxtEmail.Text
        Dim CLABE As String = Me.TxtClabe.Text
        Dim CLABE2 As String = Me.TxtClabe2.Text
        Dim BANCO As String = Me.CboBancos.SelectedValue
        Dim BANCO2 As String = Me.CboBancos2.SelectedValue
        Dim TABULADOR As String = Me.CboTabulador.SelectedValue
        Dim TIPOPERSONA As String = RdTipoPersona.SelectedValue
        Dim activo As Integer = RadioButtonList1.SelectedValue

        If (CELULAR = Nothing And TELFIJO = Nothing And NEXTEL = Nothing And EMAIL = Nothing) Then
            ConfigureNotification("Se requiere al menos un dato de contacto (telefono fijo, celular, nextel o email)")
            Exit Sub
        End If

        If CP = Nothing Then
            CP = 0
        End If

        If BANCO = "Seleccionar" Then
            BANCO = ""
        End If


        Dim resultado As String

        resultado = csDAL.ModificaGestores(Trim(rfc), Trim(NOMBRE), Trim(APATERNO), Trim(AMATERNO), Trim(CALLEYNUMERO) _
                           , Trim(COLONIA), Trim(ESTADO), Trim(MPIO), Trim(CP), Trim(CELULAR) _
                           , Trim(TELFIJO), Trim(NEXTEL), Trim(EMAIL), Trim(CLABE), Trim(CLABE2), Trim(BANCO), Trim(BANCO2) _
                           , Trim(TABULADOR), Trim(TIPOPERSONA), activo)

        If (lstEstadosAgre.Items.Count >= 1) Then
            csDAL.eliminarestadosMpio(rfc, CboEstados.SelectedItem.Value)
            For Each item In lstEstadosAgre.Items
                csDAL.InsertaMultipleEstadoMpio(rfc, CboEstados.SelectedItem.Value, item.Value)
                'Dim valores As String = item.Value

            Next
        Else
            ConfigureNotification("Se requiere al menos un mpio.")
            Exit Sub
        End If

        If chklst_Poderes.SelectedValue <> Nothing Then

            csDAL.eliminarPoderes(rfc)

            For Each item1 In chklst_Poderes.Items
                If item1.selected = True Then
                    csDAL.InsertaMultiplePoderes(rfc, item1.Value)
                    'Dim valores As String = item.Value
                End If
            Next


        End If


        If resultado = "0" Then
            ConfigureNotification("Se guardo con exito")
            Response.Redirect("Gestores.aspx")
        Else
            ConfigureNotification("Error al cargar los datos del gestor")
            Exit Sub
        End If


    End Sub

    'Private Sub llenamos_Estado()
    '    Dim ds As New DataSet

    '    lstEstados.Items.Clear()
    '    lstEstadosAgre.Items.Clear()
    '    ds = csDAL.llenalstEstados()

    '    lstEstados.DataSource = ds.Tables(0)
    '    lstEstados.DataTextField = "NOMBRE"
    '    lstEstados.DataValueField = "CLAVE"
    '    lstEstados.DataBind()


    'End Sub
    'Private Sub llenamos_EstadoAsignado()
    '    Dim rfc As String = TxtRFC.Text.Trim()
    '    Dim ds As New DataSet

    '    lstEstadosAgre.Items.Clear()
    '    'lstEstados.Items.Clear()
    '    ds = csDAL.CargaEstadosAsignados(rfc)

    '    lstEstadosAgre.DataSource = ds.Tables(0)
    '    lstEstadosAgre.DataTextField = "NOMBRE"
    '    lstEstadosAgre.DataValueField = "clave_estado"
    '    lstEstadosAgre.DataBind()


    'End Sub



    Private Sub llenamos_EstadoSinAsignar()
        Dim rfc As String = TxtRFC.Text.Trim()
        Dim nds As New DataSet

        'lstEstados.Items.Clear()
        'lstEstadosAgre.Items.Clear()
        nds = csDAL.CargaEstadosSinAsignar(rfc)
        lstEstados.DataSource = nds.Tables("Table")
        lstEstados.DataTextField = "NOMBRE"
        lstEstados.DataValueField = "CLAVE"
        lstEstados.DataBind()

    End Sub

    Protected Sub cmdasigna_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdasigna.Click
        Dim i As Integer
        Dim values As New ArrayList()
        Dim mail As New ArrayList()

        'nuevo esquema2
        Dim dt As New DataTable()
        Dim dr As DataRow

        For i = 0 To lstEstados.Items.Count - 1
            If lstEstados.Items(i).Selected Then
                lstEstadosAgre.Items.Add(New ListItem(Trim(lstEstados.Items(i).Text), Trim(lstEstados.Items(i).Value)))
            Else
                values.Add(New ListItem(Trim(lstEstados.Items(i).Text)))
                mail.Add(New ListItem(Trim(lstEstados.Items(i).Value)))
            End If
        Next

        dt.Columns.Add(New DataColumn("clave", GetType(String)))
        dt.Columns.Add(New DataColumn("Nombre", GetType(String)))

        lstEstados.Items.Clear()

        Dim myEnumerator As System.Collections.IEnumerator = _
           values.GetEnumerator()

        Dim mymail As System.Collections.IEnumerator = _
           mail.GetEnumerator()

        While myEnumerator.MoveNext()
            mymail.MoveNext()
            dr = dt.NewRow()
            dr(0) = mymail.Current
            dr(1) = myEnumerator.Current
            dt.Rows.Add(dr)

        End While

        Dim dv As New DataView(dt)
        With lstEstados
            .DataSource = dv
            .DataValueField = "clave"
            .DataTextField = "Nombre"
            .DataBind()
        End With

    End Sub

    Protected Sub cmdelimina_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdelimina.Click
        Dim i As Integer
        Dim values As New ArrayList()
        Dim mail As New ArrayList()

        'nuevo esquema2
        Dim dt As New DataTable()
        Dim dr As DataRow

        For i = 0 To lstEstadosAgre.Items.Count - 1
            If lstEstadosAgre.Items(i).Selected Then
                lstEstados.Items.Add(New ListItem(Trim(lstEstadosAgre.Items(i).Text), Trim(lstEstadosAgre.Items(i).Value)))

            Else
                values.Add(New ListItem(Trim(lstEstadosAgre.Items(i).Text)))
                mail.Add(New ListItem(Trim(lstEstadosAgre.Items(i).Value)))
            End If
        Next

        dt.Columns.Add(New DataColumn("clave", GetType(String)))
        dt.Columns.Add(New DataColumn("Nombre", GetType(String)))

        lstEstadosAgre.Items.Clear()
        Dim myEnumerator As System.Collections.IEnumerator = _
           values.GetEnumerator()
        Dim mymail As System.Collections.IEnumerator = _
           mail.GetEnumerator()
        While myEnumerator.MoveNext()
            mymail.MoveNext()
            dr = dt.NewRow()
            dr(0) = mymail.Current
            dr(1) = myEnumerator.Current
            dt.Rows.Add(dr)
        End While
        Dim dv As New DataView(dt)
        With lstEstadosAgre
            .DataSource = dv
            .DataValueField = "clave"
            .DataTextField = "Nombre"
            .DataBind()
        End With

    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim i As Integer
        Dim values As New ArrayList()
        Dim mail As New ArrayList()

        'nuevo esquema2
        Dim dt As New DataTable()
        Dim dr As DataRow

        For i = 0 To lstEstados.Items.Count - 1
            lstEstadosAgre.Items.Add(New ListItem(Trim(lstEstados.Items(i).Text), Trim(lstEstados.Items(i).Value)))
        Next

        dt.Columns.Add(New DataColumn("clave", GetType(Strings)))
        dt.Columns.Add(New DataColumn("Nombre", GetType(String)))

        lstEstados.Items.Clear()

        Dim myEnumerator As System.Collections.IEnumerator = _
           values.GetEnumerator()

        Dim mymail As System.Collections.IEnumerator = _
           mail.GetEnumerator()

        While myEnumerator.MoveNext()
            mymail.MoveNext()
            dr = dt.NewRow()
            dr(0) = mymail.Current
            dr(1) = myEnumerator.Current
            dt.Rows.Add(dr)

        End While

        Dim dv As New DataView(dt)
        With lstEstados
            .DataSource = dv
            .DataValueField = "clave"
            .DataTextField = "Nombre"
            .DataBind()
        End With
    End Sub



    Protected Sub CboEstados_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles CboEstados.SelectedIndexChanged
        If CboEstados.SelectedItem.Value <> 0 Then
            cargaMpioNoAsignados(CboEstados.SelectedItem.Value, TxtRFC.Text.Trim)
            cargaMpioAsignados(CboEstados.SelectedItem.Value, TxtRFC.Text.Trim)

        End If
    End Sub


End Class

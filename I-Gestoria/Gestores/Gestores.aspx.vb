Imports System.Data
Imports System.Web
Imports Telerik.Web.UI

Partial Class AsignacionControl_TableroControlGestion
    Inherits System.Web.UI.Page
    Dim csNeg As New ClaseNegocios
    Dim csSQLsvr As New BaseDatosSQL
    Dim csDAL As New DALClass

    Private Enum ColGrid
        nombre
        rfcajustador = 4
        activo
    End Enum


#Region "Procesos"



    Public Sub ABRIR_VENTANA(ByVal PopUpWindowPage As String, ByVal alto As Integer, ByVal largo As Integer)
        Dim Script As String = ""
        Script = " <script language=JavaScript id='PopupWindow'>  var confirmWin = null; confirmWin = window.open('" & PopUpWindowPage & "','myWindow','status = 1, scrollbars=1,height = " & alto & ", width = " & largo & ", resizable = 1 '); if((confirmWin != null) && (confirmWin.opener==null)) { confirmWin.opener = self; } </script> "
        If Not ClientScript.IsStartupScriptRegistered("PopupWindow") Then
            ClientScript.RegisterStartupScript(Me.GetType, "PopupWindow", Script)
        End If
    End Sub



#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CargaEstado(0)
            CargaRegion()
            Radios()
            ' CargaGestores()
        End If
    End Sub

    Protected Sub Button1234_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1234.Click

        Response.Redirect("~/Gestores/altagestor.aspx?tipo=0")
        
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

    Public Sub CargaRegion()
        Dim comando As String = ""

        comando = "select * from Regional order by clave"

        csSQLsvr.LlenarRadCombo(CboRegion, comando, Session("connGestion"))

    End Sub

    Public Sub CargaEstado(ByVal Region As Integer)
        Dim comando As String = ""

        If Region <> 0 Then
            comando = "Select distinct clave as clvEstado,NOMBRE as Nombre_Estado from Estados where regional = " & Region & " order by clvEstado"
        Else
            comando = "Select distinct clave as clvEstado,NOMBRE as Nombre_Estado from Estados order by clvEstado"
        End If

        csSQLsvr.LlenarRadCombo(CboEstado, comando, Session("connGestion"))

    End Sub

    Public Sub Radios()

        If RdbTipo.SelectedValue = 0 Then
            RadTxtNombre.Visible = True
            TxtRFC.Visible = False
            CboEstado.Visible = False
            CboRegion.Visible = False
            LblRegion.Visible = False
            LblEstado.Visible = False
        ElseIf RdbTipo.SelectedValue = 1 Then
            RadTxtNombre.Visible = False
            TxtRFC.Visible = True
            CboEstado.Visible = False
            CboRegion.Visible = False
            LblRegion.Visible = False
            LblEstado.Visible = False
        Else
            RadTxtNombre.Visible = False
            TxtRFC.Visible = False
            CboEstado.Visible = True
            CboRegion.Visible = True
            LblRegion.Visible = True
            LblEstado.Visible = True
        End If

    End Sub

    Protected Sub RdbTipo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RdbTipo.SelectedIndexChanged
        Radios()
    End Sub

    Protected Sub CboRegion_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles CboRegion.SelectedIndexChanged
        CargaEstado(CboRegion.SelectedValue)
    End Sub

    Protected Sub RadButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButton1.Click
        Dim ds As New DataSet

        Dim noControl As Double = 0
        Dim activo As String
        Dim rfc As String
        Dim regional As String
        Dim estado As String

        If ChkInactivos.Checked = True Then
            activo = "1"
        Else
            activo = "0"
        End If



        If RdbTipo.SelectedValue = 0 Then
            rfc = SeleccionaGestores()
            regional = ""
            estado = ""

        ElseIf RdbTipo.SelectedValue = 1 Then
            rfc = TxtRFC.Text
            regional = ""
            estado = ""
        Else
            rfc = ""
            regional = CboRegion.SelectedValue
            estado = CboEstado.SelectedValue
        End If

        ds = csDAL.CargaGestores(activo, rfc, regional, estado)

        If ds.Tables(0).Rows.Count <> 0 Then
            Dim dt As DataTable
            dt = ds.Tables(0)

            With gridGestores
                .DataSource = dt
                .DataBind()
                .Dispose()
            End With
        Else
            ConfigureNotification("ATENCION!,No existe informacion,Favor de verificar parametros")
gridGestores.Rebind()
        End If

    End Sub

    Protected Sub grid_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles gridGestores.ItemCommand
        'Fila seleccionada
        Dim r As GridItem = e.Item

        'Redirecciona a la siguiente página

        If r.Cells(ColGrid.rfcajustador).Text = "&nbsp;" Then
            Session("rfcajustador") = 0
        Else
            Session("rfcajustador") = r.Cells(ColGrid.rfcajustador).Text

            If e.CommandName = "cmdModificar" Then

                Response.Redirect("~/Gestores/altagestor.aspx?tipo=1&rfc=" & Session("rfcajustador"))

            ElseIf e.CommandName = "cmdBaja" Then

                Dim comando As String = ""

                comando = "Update Ajustadores2 set ACTIVO = 1, FINACT = GETDATE() where RFCAJUSTADOR = '" & Session("rfcajustador") & "'"
                csSQLsvr.EjecutarUpdate(comando, Session("connGestion"))
                comando = "Update gestores set ACTIVO = 1 where rfcGestor = '" & Session("rfcajustador") & "'"
                csSQLsvr.EjecutarUpdate(comando, Session("connGestion"))

            End If
        End If



    End Sub

    'Public Sub CargaGestores()

    '    Dim comando As String = ""

    '    comando = "select  rfcajustador, (LTRIM(RTRIM(NOMBRE))) + ' ' + (LTRIM(RTRIM(MATERNO))) " & _
    '            "+ ' ' + (LTRIM(RTRIM(PATERNO))) as nombre from ajustadores2"

    '    csSQLsvr.LlenarRadCombo(CboGestores, comando, Session("connGestion"))

    'End Sub

    'Protected Sub Button1235_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1235.Click
    '    If grid.SelectedCells.Count <> 0 Then

    '    Else
    '        ConfigureNotification("Debe seleccionar al Gestor a Modificar")
    '    End If

    'End Sub

    Public Function SeleccionaGestores() As String
        Dim comando As String = ""

        comando = "select  DISTINCT rfcajustador, (LTRIM(RTRIM(NOMBRE))) + ' ' + (LTRIM(RTRIM(MATERNO))) " & _
                "+ ' ' + (LTRIM(RTRIM(PATERNO))) as nombre from ajustadores2 WHERE NOMBRE LIKE '%" & RadTxtNombre.Text & "%' OR MATERNO LIKE '%" & RadTxtNombre.Text & "%'" & _
                " OR PATERNO LIKE '%" & RadTxtNombre.Text & "%'"

        Dim ds As New DataSet
        ds = csSQLsvr.QueryDataSet(comando, Session("connGestion"))
        Dim dr As DataRow

        If ds.Tables(0).Rows.Count > 0 Then


            For Each dr In ds.Tables(0).Rows
                SeleccionaGestores = dr("rfcajustador").ToString
            Next

        End If
        Return SeleccionaGestores
    End Function

    Protected Sub ChkInactivos_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkInactivos.CheckedChanged

    End Sub
End Class

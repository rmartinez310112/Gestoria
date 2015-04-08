Imports System.Data
Imports System.Web
Partial Class AsignacionControl_BuscarGestor
Inherits System.Web.UI.Page
    Dim csNeg As New ClaseNegocios
    Dim csSQLsvr As New BaseDatosSQL
    Dim csDAL As New DALClass
    #Region "Procesos"
    Public Sub cargaEstados()

        Dim comando As String = "exec Select_cbo_estados"
        csSQLsvr.LlenarRadCombo(cboEstado, comando, Session("connGestion"))
        cboEstado.SelectedValue = Request.QueryString("clvEstado")
    End Sub

    Public Sub cargaGestores(ByVal estado As Integer)
        Dim ds As New DataSet
        ds = csDAL.buscaGestores(estado)
            With grdiGestores
            .DataSource = ds.Tables(0).Rows
            .DataBind()
        End With
        ds.Clear()
        ds.Dispose()
    End Sub

    Private Sub asignaGestor(noGestion As String, rfcGestor As String)
        If csDAL.AsignarGestor(noGestion, rfcGestor, Request.QueryString("tramite"), Request.QueryString("consec")) = True Then
            lblError.Text = "El gestor fue Asignado con exito.."
            csDAL.Insert_BitacoraCambios(Request.QueryString("nogestion"), "Se realizo la asignación de un gestor", Session("clvUsuario"))
        Else
            lblError.Text = "Error al asignar al gestor.."
        End If

    End Sub

    #End Region

    'Protected Sub RadButton1_Click(sender As Object, e As System.EventArgs) Handles RadButton1.Click
    '    cargaGestores(cboEstado.SelectedValue)
    'End Sub

    Protected Sub grdiGestores_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles grdiGestores.ItemCommand
        If e.CommandName = "cmdAsignar" Then
            Dim rfc As String = e.Item.Cells(2).Text.Trim
            asignaGestor(Request.QueryString("nogestion"), rfc)
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Session("noGestionIntegral") <> Nothing Then
                cargaEstados()
            End If
        End If
    End Sub

    Protected Sub Button123_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button123.Click
        cargaGestores(cboEstado.SelectedValue)
    End Sub
End Class

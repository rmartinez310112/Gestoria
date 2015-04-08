Imports System.Data
Imports System.Web
Partial Class GestionDocumentos_EntregaDocumentosCliente
Inherits System.Web.UI.Page
    Dim csNeg As New ClaseNegocios
    Dim csSQLsvr As New BaseDatosSQL
    Dim csDAL As New DALClass

    #Region "procesos"

    Private Sub cargaDocumentosSolicitad(nogestion As String)
        Dim ds As New DataSet
        ds = csDAL.DocumentosEntregadosCliente(nogestion)
            With RadGrid2
            .DataSource = ds.Tables(0)
            .DataBind()
        End With

    End Sub

    Private Sub CargaDocumentosPEndientesEntregar(nogestion As String)
        Dim ds As New DataSet
        ds = csDAL.revisarDocumentosPendientesEntregaCliente(nogestion)
            With RadGrid1
            .DataSource = ds.Tables(0)
            .DataBind()
        End With

    End Sub
    #End Region

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Session("noGestionIntegral") <> Nothing Then
                fechaSol.SelectedDate = csDAL.HoraServidor
                CargaDocumentosPEndientesEntregar(Session("noGestionIntegral"))
                cargaDocumentosSolicitad(Session("noGestionIntegral"))
            End If
        End If
    End Sub

    'Protected Sub RadButton2_Click(sender As Object, e As System.EventArgs) Handles RadButton2.Click
    '    Dim cuenta As Integer = RadGrid1.Items.Count - 1
    '    Dim x As Integer = 0
    '    For x = 0 To cuenta
    '        Dim chkSoli As CheckBox = RadGrid1.Items(x).FindControl("chkRev")
    '        Dim Tramite_clvTramite As Integer = RadGrid1.Items(x).Cells(2).Text.Trim
    '        Dim Tramite_cvlSubTramite As Integer = RadGrid1.Items(x).Cells(3).Text.Trim
    '        Dim fechachkSolicitado = Format(fechaSol.SelectedDate, "yyyyMMdd")
    '        Dim fk_usuario_chkSolicitado As String = Session("clvUsuario")
    '        Dim txtObervaciones As Telerik.Web.UI.RadTextBox = RadGrid1.Items(x).FindControl("txtobs")
    '        Dim tipoEntrega As Integer = rblTipoEntrega.SelectedValue
    '        If chkSoli.Checked = True Then

    '            If csDAL.DocumentosEntregadosCliente(Session("noGestionIntegral"), Tramite_clvTramite, Tramite_cvlSubTramite, fechachkSolicitado, fk_usuario_chkSolicitado, txtObervaciones.Text.Trim, tipoEntrega) = True Then
    '                RadGrid1.Items(x).Cells(6).Text = "Documento Entregado"
    '                chkSoli.Checked = False
    '                RadGrid1.Items(x).Enabled = False
    '                RadGrid1.Items(x).BackColor = System.Drawing.ColorTranslator.FromHtml("#6600FF")
    '                RadGrid1.Items(x).ForeColor = Drawing.Color.White
    '            Else
    '                RadGrid1.Items(x).Cells(6).Text = "Error al guardar el registro"
    '            End If
    '        End If
    '    Next
    'End Sub

    Protected Sub chkEntregados_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkEntregados.CheckedChanged
        'DocumentosEntregadosGestor
        cargaDocumentosSolicitad(Session("noGestionIntegral"))
        If chkEntregados.Checked = True Then
            RadGrid2.Visible = True
        Else
            RadGrid2.Visible = False
        End If
    End Sub

    Protected Sub button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles button1.Click
        Dim cuenta As Integer = RadGrid1.Items.Count - 1
        Dim x As Integer = 0
        For x = 0 To cuenta
            Dim chkSoli As CheckBox = RadGrid1.Items(x).FindControl("chkRev")
            Dim Tramite_clvTramite As Integer = RadGrid1.Items(x).Cells(2).Text.Trim
            Dim Tramite_cvlSubTramite As Integer = RadGrid1.Items(x).Cells(3).Text.Trim
            Dim fechachkSolicitado = Format(fechaSol.SelectedDate, "yyyyMMdd")
            Dim fk_usuario_chkSolicitado As String = Session("clvUsuario")
            Dim txtObervaciones As Telerik.Web.UI.RadTextBox = RadGrid1.Items(x).FindControl("txtobs")
            Dim tipoEntrega As Integer = rblTipoEntrega.SelectedValue
            If chkSoli.Checked = True Then

                If csDAL.DocumentosEntregadosCliente(Session("noGestionIntegral"), Tramite_clvTramite, Tramite_cvlSubTramite, fechachkSolicitado, fk_usuario_chkSolicitado, txtObervaciones.Text.Trim, tipoEntrega) = True Then
                    RadGrid1.Items(x).Cells(6).Text = "Documento Entregado"
                    chkSoli.Checked = False
                    RadGrid1.Items(x).Enabled = False
                    RadGrid1.Items(x).BackColor = System.Drawing.ColorTranslator.FromHtml("#6600FF")
                    RadGrid1.Items(x).ForeColor = Drawing.Color.White
                Else
                    RadGrid1.Items(x).Cells(6).Text = "Error al guardar el registro"
                End If
            End If
        Next
    End Sub
End Class


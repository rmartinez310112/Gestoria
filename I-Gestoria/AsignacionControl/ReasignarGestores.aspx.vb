Imports System.Data
Imports System.Web
Partial Class AsignacionControl_ReasignarGestores
    Inherits System.Web.UI.Page
    Dim csNeg As New ClaseNegocios
    Dim csSQLsvr As New BaseDatosSQL
    Dim csDAL As New DALClass
#Region "Procesos"
    Public Sub cargaEstados()

        Dim sGestion As String = Session("noGestionIntegral")
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)


        Dim comando As String = "exec Select_cbo_estados"
        csSQLsvr.LlenarRadCombo(cboEstado, comando, Session("connGestion"))
        cboEstado.SelectedValue = p_estado
        cargaGestores(p_estado)
    End Sub

    Public Function RevisarServicio(ByVal noGestion As String) As Integer
        RevisarServicio = 0
        Dim sGestion As String = Session("noGestionIntegral")
        Dim nLargo As Integer = Len(sGestion)
        Dim p_Anio As String = Mid(sGestion, 1, 4)
        Dim p_Cliente As String = Mid(sGestion, 5, 2)
        Dim p_tipo As String = Mid(sGestion, 7, 2)
        Dim p_estado As String = Mid(sGestion, 9, 2)
        Dim p_consec As String = Mid(sGestion, 11, nLargo)

        Dim comando As String = "select * from reporteGestion where  " & _
        " Reporte_anio=" & p_Anio & " and " & _
        " Reporte_cliente=" & p_Cliente & " and " & _
        " Reporte_Tipo=" & p_tipo & " and " & _
        " Reporte_clvEstado=" & p_estado & " and " & _
        " Reporte_Numero=" & p_consec & " and Reporte_status=0 and HRCONFIR_Gestor<>'01/01/1900'"

        Dim ds As DataSet = New DataSet
        ds = csSQLsvr.QueryDataSet(comando, Session("connGestion"))
        If ds.Tables(0).Rows.Count > 0 Then
            RevisarServicio = 1
        End If
        ds.Clear()
        Return RevisarServicio

    End Function

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
        If csDAL.AsignarGestorManual(noGestion, rfcGestor) = True Then
            lblError.Text = "El gestor fue Asignado con exito.."
            Dim nombreGestor As String = csDAL.buscaGestorAsignado(rfcGestor)
            csDAL.Insert_BitacoraCambios(Session("noGestionIntegral"), "Se realizo la Reasignación de un gestor: " & rfcGestor & "  " & nombreGestor, Session("clvUsuario"))
        Else
            lblError.Text = "Error al asignar al gestor, verifique que el asunto este activo..."
        End If

    End Sub

#End Region

    'Protected Sub RadButton1_Click(sender As Object, e As System.EventArgs) Handles RadButton1.Click
    '    cargaGestores(cboEstado.SelectedValue)
    'End Sub

    Protected Sub grdiGestores_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles grdiGestores.ItemCommand
        If e.CommandName = "cmdAsignar" Then
            Dim rfc As String = e.Item.Cells(2).Text.Trim
            asignaGestor(Session("noGestionIntegral"), rfc)

            ' Proceso para SMS ''Insertamos en tabla EnvioMailSMS_tbl la etapa 6 (Etapa de reasignacion de gestor)
            csDAL.InsertEnvioSms(Session("NumGestionSeguimiento").Trim, 6)

        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then


            If Session("noGestionIntegral") <> Nothing Then
                If RevisarServicio(Session("noGestionIntegral") = 1) Then
                    cargaEstados()
                Else
                    lblError.Text = "Este servicio, no tiene asignado un Gestor, no se puede realizar una reasignación.."
                    Button123.Enabled = False
                    cboEstado.Enabled = False
                End If

            Else
                lblError.Text = "No ha dado un No. de Servicio de Gestoria Valido, no se puede hacer el cambio de un gestor"
            End If


        End If
    End Sub

    Protected Sub Button123_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button123.Click
        cargaGestores(cboEstado.SelectedValue)
    End Sub
End Class

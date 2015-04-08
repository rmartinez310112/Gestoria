Imports System.Data
Imports System.Web
Partial Class GestionDocumentos_AceptarDocumentosGestion
Inherits System.Web.UI.Page
    Dim csNeg As New ClaseNegocios
    Dim csSQLsvr As New BaseDatosSQL
    Dim csDAL As New DALClass

    #Region "procesos"
    Protected Sub ConfigureNotification(ByVal titulo As String, ByVal texto As String)
        'String
        lblError.Text = texto
        lblError.Text = texto
        RadNotification2.Title = "Aviso!"
        RadNotification2.Text = texto
        'Enum
        RadNotification2.Position = Telerik.Web.UI.NotificationPosition.Center
        RadNotification2.Animation = Telerik.Web.UI.NotificationAnimation.Fade
        'notificacion.ContentScrolling = Telerik.Web.UI.NotificationScrolling.Default
        RadNotification2.AutoCloseDelay = 10000
        'Unit
        RadNotification2.Width = 300
        RadNotification2.Height = 150
        RadNotification2.OffsetX = -10
        RadNotification2.OffsetY = 10

        RadNotification2.Pinned = True
        RadNotification2.EnableRoundedCorners = True
        RadNotification2.EnableShadow = True
        RadNotification2.KeepOnMouseOver = False
        RadNotification2.VisibleTitlebar = True
        RadNotification2.ShowCloseButton = True
        RadNotification2.Show()

    End Sub

    Private Sub revisarDocumentosPendientesRecepcion(noGestion As String)
        Dim dsDocSol As New DataSet
        dsDocSol = csDAL.revisarDocumentosPendientesRecepcion(noGestion)
            With RadGrid1
            .DataSource = dsDocSol.Tables(0)
            .DataBind()
        End With


    End Sub

    Private Sub cargaDocumentosSolicitad(nogestion As String)
        Dim ds As New DataSet
        ds = csDAL.DocumentosSolicitados(nogestion)
            With RadGrid2
            .DataSource = ds.Tables(0)
            .DataBind()
        End With

    End Sub
    #End Region


    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Session("noGestionIntegral") <> Nothing Then
                fechaSol.SelectedDate = Now()  'csDAL.HoraServidor
                revisarDocumentosPendientesRecepcion(Session("noGestionIntegral"))
                cargaDocumentosSolicitad(Session("noGestionIntegral"))
                Panel1.Visible = True
            Else
                ConfigureNotification("Aviso", "Favor de Introducir No.Gestion")
            End If
        End If
    End Sub

    Public Function verificaRechazados() As Integer
        Dim cuenta As Integer = RadGrid1.Items.Count - 1
        Dim x As Integer = 0
        verificaRechazados = 1
        For x = 0 To cuenta ' revisamos q este toda la información para guardar los datos
            Dim rblAceptado As RadioButtonList = RadGrid1.Items(x).FindControl("rblAcep") ' checamos si esta aceptado o rechazado
            Dim txtObervaciones As TextBox = RadGrid1.Items(x).FindControl("txtObs") ' checamos q este la causa del rechazo.


            If rblAceptado.SelectedValue = 0 And txtObervaciones.Text.Trim = String.Empty Then
                lblError.Text = "Si hay un documento rechazado es necesario dar las obervaciones, no es posible guardar la entrega de documentos.."
                RadGrid1.Items(x).Cells(9).Text = "Si hay un documento rechazado es necesario dar las obervaciones.."
                ConfigureNotification("Aviso", "Si hay un documento rechazado es necesario dar las obervaciones, no es posible guardar la entrega de documentos..")
                verificaRechazados = 1
                Exit For

            Else
                lblError.Text = String.Empty
                RadGrid1.Items(x).Cells(9).Text = String.Empty
                verificaRechazados = 0
            End If
        Next

        Return verificaRechazados

    End Function

    Protected Sub chkEntregados_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkEntregados.CheckedChanged
        cargaDocumentosSolicitad(Session("noGestionIntegral"))
        If chkEntregados.Checked = True Then
            RadGrid2.Visible = True
            Panel2.Visible = True
            Panel1.Visible = False
            RadGrid1.Visible = False
            Label8.Visible = False
            Label9.Visible = False
        Else
            RadGrid2.Visible = False
            Panel2.Visible = False
        End If
    End Sub

    Private Function causaRecha() As String
        Throw New NotImplementedException
    End Function

    Protected Sub button_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button.Click
        If verificaRechazados() = 0 Then

            Dim cuenta As Integer = RadGrid1.Items.Count - 1
            Dim x As Integer

            For x = 0 To cuenta
                Dim rblAceptado As RadioButtonList = RadGrid1.Items(x).FindControl("rblAcep") ' checamos si esta aceptado o rechazado
                Dim txtOberv As TextBox = RadGrid1.Items(x).FindControl("txtObs")

                Dim Tramite_clvTramite As Integer = RadGrid1.Items(x).Cells(2).Text.Trim
                Dim Tramite_cvlSubTramite As Integer = RadGrid1.Items(x).Cells(3).Text.Trim
                Dim consec As Integer = RadGrid1.Items(x).Cells(4).Text.Trim
                Dim fechachkSolicitado = Format(fechaSol.SelectedDate, "yyyyMMdd")
                Dim fk_usuario_chkSolicitado As String = Session("clvUsuario")
                Dim tramDescrip As String = RadGrid1.Items(x).Cells(5).Text.Trim
                Dim tramDoc As String = RadGrid1.Items(x).Cells(6).Text.Trim
                Dim causaRecha As String = ""


                If rblAceptado.SelectedValue = 1 Then

                    If csDAL.DocumentosExpedienteGestionAceptados(Session("noGestionIntegral"), Tramite_clvTramite, Tramite_cvlSubTramite, fechachkSolicitado, fk_usuario_chkSolicitado, causaRecha, consec) Then
                        RadGrid1.Items(x).Cells(9).Text = "El documento ha sido guardado como aceptado.."
                        RadGrid1.Items(x).Enabled = False
                        RadGrid1.Items(x).BackColor = System.Drawing.ColorTranslator.FromHtml("#6600FF")
                        RadGrid1.Items(x).ForeColor = Drawing.Color.White
                        For Each li As ListItem In rblAceptado.Items
                            li.Selected = False
                        Next
                    Else
                        RadGrid1.Items(x).Cells(9).Text = "Error al marcar el documento como entregado..vuelva a intentarlo.."
                    End If

                Else
                    If csDAL.DocumentosExpedienteGestionRechazados(Session("noGestionIntegral"), tramDescrip, tramDoc, fk_usuario_chkSolicitado, causaRecha) = True Then
                        RadGrid1.Items(x).Cells(9).Text = "Documento Rechazado.."
                        RadGrid1.Items(x).Enabled = False
                        RadGrid1.Items(x).BackColor = Drawing.Color.DarkRed
                        RadGrid1.Items(x).ForeColor = Drawing.Color.White
                        For Each li As ListItem In rblAceptado.Items
                            li.Selected = False
                        Next
                    Else
                        RadGrid1.Items(x).Cells(9).Text = "Error al marcar el documento como rechazado..vuelva a intentarlo.."
                    End If
                End If


            Next
        End If
    End Sub
End Class

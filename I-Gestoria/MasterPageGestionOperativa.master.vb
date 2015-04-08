Imports System.Data
Imports System.Web
Imports Telerik.Web.UI

Partial Class MasterPageGestionOperativa
Inherits System.Web.UI.MasterPage
    Dim csNeg As New ClaseNegocios
    Dim csSQLsvr As New BaseDatosSQL
    Dim csDAL As New DALClass
    Dim expande As Integer
    Dim gest As String
    Dim nocontrol As String

    #Region "Procedimientos"
    'Dim RadPanelItemBinding As NavigationItemBinding

    Private Sub cargaDatosGestion(ByVal datosGestion As DataSet)
        If Session("noGestionIntegral") <> String.Empty Then
            Dim dr As DataRow
            Dim cuenta As Integer = 0
            'If cuenta < 1 Then
            For Each dr In datosGestion.Tables(0).Rows
                lblEstado.Text = csDAL.buscaEstado(dr("Reporte_clvEstado"))
                lblMunicipio.Text = csDAL.buscaMpio(dr("Reporte_clvEstado"), dr("Reporte_clvMpio"))
                lblfReporte.Text = dr("Reporte_FechaRepor")
                lblReporto.Text = dr("Reporte_NombreReporta").ToString.Trim & " " & dr("Reporte_APaternoReporta").ToString.Trim & " " & dr("Reporte_AMaternoReporta").ToString.Trim
                'txtLadaRep.Text = dr("Reporte_LadaReporta")
                lblTelefono.Text = "(" & dr("Reporte_LadaReporta") & ") " & dr("Reporte_telReporta")
                lblTel2.Text = "(" & dr("Reporte_LadaAseg") & ") " & dr("Reporte_TelAseg")
                lblAsegurado.Text = dr("Reporte_NombreAseg").ToString.Trim & " " & dr("Reporte_ApaternoAseg").ToString.Trim & " " & dr("Reporte_AMaternoAseg").ToString.Trim & "|" & dr("Reporte_CiaAsegura").ToString.Trim
                lblMail.Text = dr("Reporte_MailAseg").ToString.Trim
                lblnoPoliza.Text = dr("Reporte_poliza")
                'lblTelefono.Text = dr("Reporte_Inciso")
                lblAseguradora.Text = csDAL.buscaAseguradora(dr("Reporte_cliente"))
                lblTipos.Text = csDAL.buscaTipoServicio(dr("Reporte_cliente"), dr("Reporte_Tipo"))
                lblEstatus.Text = csDAL.buscaEstatusServicio(dr("Reporte_status"))
                lblPrincipal.Text = "[  " & dr("Reporte_NombreAseg").ToString.Trim & " " & dr("Reporte_ApaternoAseg").ToString.Trim & " , " & csDAL.buscaTipoServicio(dr("Reporte_cliente"), dr("Reporte_Tipo")) & " , " & csDAL.buscaEstatusServicio(dr("Reporte_status")) & "  ]"
                'lblDireccion.Visible = True

                Dim ds1 As New DataSet
                Dim dr1 As DataRow


                ds1 = csDAL.select_EtapaCintillo(Session("noGestionIntegral"))
                If ds1.Tables(0).Rows.Count <> 0 Then
                    For Each dr1 In ds1.Tables(0).Rows
                        If dr1("Etapa") <> Nothing Then
                            lblEtapasCintillo.Text = dr1("Etapa")


                        End If
                    Next
                Else
                    lblEtapasCintillo.Text = "Aun Sin Etapa"
                End If

                ds1 = csDAL.select_GestorCintillo(Session("noGestionIntegral"))
                If ds1.Tables(0).Rows.Count <> 0 Then
                    For Each dr1 In ds1.Tables(0).Rows
                        If dr("RFC_Gestor") <> Nothing Then
                            lblGesCintillo.Text = dr1("gestor")
                            lblFechaAsigCintillo.Text = dr1("HRCONFIR_Gestor")
                        Else
                            lblGesCintillo.Text = "Aun sin Asignar"
                            lblFechaAsigCintillo.Text = "Aun sin Asignar"
                        End If
                    Next

                End If

                If dr("Reporte_Tipo") = 11 Then
                    ds1 = csDAL.select_MarcaySubmarca(Session("noGestionIntegral"))
                    If ds1.Tables(0).Rows.Count <> 0 Then
                        For Each dr1 In ds1.Tables(0).Rows
                            lblMarcaCintillo.Text = dr1("marca")
                            lblSubMarCintillo.Text = dr1("submarca")
                        Next

                    End If
                ElseIf dr("Reporte_Tipo") > 13 Then
                    ds1 = csDAL.select_MarcaySubmarca(Session("noGestionIntegral"))
                    If ds1.Tables(0).Rows.Count <> 0 Then
                        For Each dr1 In ds1.Tables(0).Rows
                            lblMarcaCintillo.Text = dr1("marca")
                            lblSubMarCintillo.Text = IIf(IsDBNull(dr1("submarca")), "", dr1("submarca"))
                        Next
                    End If

                ElseIf dr("Reporte_Tipo") = 10 Then
                    ds1 = csDAL.select_MarcaySubmarca(Session("noGestionIntegral"))
                    If ds1.Tables(0).Rows.Count <> 0 Then
                        For Each dr1 In ds1.Tables(0).Rows
                            lblMarcaCintillo.Text = dr1("marca")
                            lblSubMarCintillo.Text = dr1("submarca")
                        Next
                    End If
                Else
                    lblMarcaCintillo.Text = "N/A"
                    lblMarcaCintillo.Text = "N/A"
                End If
                    'lblDireccion.Text = ""
                    If Trim(dr("Reporte_CiaAsegura")) <> String.Empty Then ' para saber si es moral o fisica
                        Session("tipoPersona") = 2 'moral
                    Else
                        Session("tipoPersona") = 1 'fisica
                    End If
            Next
           
        End If
        '    Dim dsRobo As New DataSet
        '    Dim dr1 As DataRow
        '    dsRobo = csDAL.select_direccion(Session("noGestionIntegral"))
        '    If dsRobo.Tables(0).Rows.Count <> 0 Then
        '        For Each dr1 In dsRobo.Tables(0).Rows
        '            lblDireccion.Text = "Calle: " & dr1("ReporteGestionPTRobo_CalleRobo").ToString.Trim & ", Colonia: " & dr1("ReporteGestionPTRobo_ColoniaRobo").ToString.Trim
        '        Next
        '    Else
        '        lblDireccion.Text = "S/N"
        '    End If

        'Else
        '    lblDireccion.Text = "N/A"
        'cuenta += 1
        'End If
        'datosGestion.Clear()
        'datosGestion.Dispose()
    End Sub

    Public Sub ConfigureNotification(ByVal titulo As String, ByVal texto As String, Optional ByVal tiempo As Integer = 5000, Optional ByVal Ancho As Integer = 300, Optional ByVal Alto As Integer = 100)
        'String
        'lblerror.Text = texto
        notificacion0.Title = titulo
        notificacion0.Text = texto
        'Enum
        notificacion0.Position = Telerik.Web.UI.NotificationPosition.Center
        notificacion0.Animation = Telerik.Web.UI.NotificationAnimation.Fade
        'notificacion.ContentScrolling = Telerik.Web.UI.NotificationScrolling.Default
        'notificacion0.AutoCloseDelay = tiempo
        'Unit
        notificacion0.Width = Ancho
        notificacion0.Height = Alto
        notificacion0.OffsetX = -10
        notificacion0.OffsetY = 10

        notificacion0.Pinned = True
        notificacion0.EnableRoundedCorners = True
        notificacion0.EnableShadow = True
        notificacion0.KeepOnMouseOver = False
        notificacion0.VisibleTitlebar = True
        notificacion0.ShowCloseButton = True
        notificacion0.Show()

    End Sub

    #End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

       If Not Page.IsPostBack Then
            If Session("clvUsuario") <> Nothing Then

                If Session("noGestionIntegral") <> Nothing Then
                    Try

                    
                    If Session("datosExp") Then


                        
                        End If
                    Catch ex As Exception
                        If Session("datosExp").Tables(0).Rows.Count <> 0 Then
                            cargaDatosGestion(Session("datosExp"))
                            txtNoGestion.Text = Session("noGestionIntegral")

                        Else

                            CargaDatosExpediente()
                        End If
                    End Try
                End If
            Else
                Response.Redirect("~/InicioSesion.aspx")

            End If
        End If
    End Sub

    Public Sub CargaDatosExpediente()
        If txtNoGestion.Text.Trim <> String.Empty Then
            ' checamos la longitud de la cadena para ver que sea un no. de gestion valido.
            ' El No. esta constituido por 4 digitos del año, 2 digitos del no. de cliente, 2 digitos del tipo de Gestion, 
            ' 2 digitos de clave de estado y un consecutivo por año q arranca en 1 y puede ser hasta de 6 digitos
            Dim dsGestion As New DataSet

            If Len(txtNoGestion.Text.Trim) < 11 Then
                ConfigureNotification("Atención", "No es un número de gestión valido..", 6000)
                Session("noGestionIntegral") = Nothing
                Exit Sub
            Else
                dsGestion = csDAL.buscaExpedienteGestion(txtNoGestion.Text.Trim)
                If dsGestion.Tables(0).Rows.Count = 0 Then
                    ConfigureNotification("Atención", "El  número de gestión no existe..", 6000)
                    Session("noGestionIntegral") = Nothing
                    dsGestion.Clear()
                    dsGestion.Dispose()
                    Exit Sub
                Else
                    'lblerror.Text = String.Empty
                   
                    
                    Session("datosExp") = dsGestion
                    cargaDatosGestion(dsGestion)
                    Session("noGestionIntegral") = txtNoGestion.Text.Trim

                    TablePane.Collapsed = False
                End If
            End If
        End If
    End Sub
    Public Sub CargaDatosExpedienteControl()
        If TxtControl.Text.Trim <> String.Empty Then
            ' checamos la longitud de la cadena para ver que sea un no. de gestion valido.
            ' El No. esta constituido por 4 digitos del año, 2 digitos del no. de cliente, 2 digitos del tipo de Gestion, 
            ' 2 digitos de clave de estado y un consecutivo por año q arranca en 1 y puede ser hasta de 6 digitos
            Dim dsGestion As New DataSet
            If Len(TxtControl.Text.Trim) < 5 Then
                ConfigureNotification("Atención", "No es un número de control valido..", 6000)
                Session("noGestionIntegral") = Nothing
                Exit Sub
            Else
                dsGestion = csDAL.buscaExpedienteControl(TxtControl.Text.Trim)
                If dsGestion.Tables(0).Rows.Count = 0 Then
                    ConfigureNotification("Atención", "El  número de control no existe..", 6000)
                    Session("noGestionIntegral") = Nothing
                    dsGestion.Clear()
                    dsGestion.Dispose()
                    Exit Sub
                Else
                    'lblerror.Text = String.Empty
                    Dim dr As DataRow
                    For Each dr In dsGestion.Tables(0).Rows
                        Session("noGestionIntegral") = dr("NoGestion")
                    Next
                    Session("datosExp") = dsGestion
                    cargaDatosGestion(Session("datosExp"))

                    txtNoGestion.Text = Session("noGestionIntegral").ToString.Trim

                    TablePane.Collapsed = False
                End If
            End If
        End If
    End Sub

    Protected Sub txtNoGestion_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNoGestion.TextChanged

        If txtNoGestion.Text <> Nothing Then

            CargaDatosExpediente()

        End If
    End Sub

    Protected Sub TxtControl_TextChanged(sender As Object, e As System.EventArgs) Handles TxtControl.TextChanged

        If TxtControl.Text <> Nothing Then

            CargaDatosExpedienteControl()
        End If

    End Sub
End Class


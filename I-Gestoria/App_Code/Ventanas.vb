Imports Microsoft.VisualBasic
Imports Telerik.Web.UI
Imports System.Web.UI.WebControls
Public Class Ventanas
    Public master As MasterPage
    Public popup As Page

    Sub New(ByRef master As MasterPage)
        Me.master = master
    End Sub

    Sub New(ByRef popup As Page)
        Me.popup = popup
    End Sub

    Sub New()
        ' TODO: Complete member initialization 
        'Me.master = master
    End Sub

    Public Sub Abrir_winwinSegACita()
        Dim rad As RadAjaxPanel
        'Control lbl = this.Page.Master.FindControl("Cabecera1");
        ' Recupera el RadAjaxPanel
        rad = master.FindControl("RadAjaxPanel")

        ' Abre la ventana
        rad.ResponseScripts.Add("Abrir_winSegACita();")

    End Sub

    Public Sub Abrir_winwinDetalleUsuario()
        Dim rad As RadAjaxPanel
        'Control lbl = this.Page.Master.FindControl("Cabecera1");
        ' Recupera el RadAjaxPanel
        rad = master.FindControl("RadAjaxPanel")

        ' Abre la ventana
        rad.ResponseScripts.Add("Abrir_winDetalleUsuario();")

    End Sub

    Public Sub Abrir_winwinDetalleGestor()
        Dim rad As RadAjaxPanel
        'Control lbl = this.Page.Master.FindControl("Cabecera1");
        ' Recupera el RadAjaxPanel
        rad = master.FindControl("RadAjaxPanel")

        ' Abre la ventana
        rad.ResponseScripts.Add("Abrir_winDetalleGestor();")

    End Sub

    Public Sub Abrir_WinWinRemesaPrimerContacto()
        Dim rad As RadAjaxPanel
        'Control lbl = this.Page.Master.FindControl("Cabecera1");
        ' Recupera el RadAjaxPanel
        rad = master.FindControl("RadAjaxPanel")

        ' Abre la ventana
        rad.ResponseScripts.Add("Abrir_WinRemesaPrimerContacto();")

    End Sub


    Public Sub Abrir_WinWinRemesaRecepcionDocumentos()
        Dim rad As RadAjaxPanel
        'Control lbl = this.Page.Master.FindControl("Cabecera1");
        ' Recupera el RadAjaxPanel
        rad = master.FindControl("RadAjaxPanel")

        ' Abre la ventana
        rad.ResponseScripts.Add("Abrir_WinRemesaRecepcionDocumentos();")
    End Sub

    Public Sub Abrir_winwinRemesaEntregaCotizacion()

        Dim rad As RadAjaxPanel
        'Control lbl = this.Page.Master.FindControl("Cabecera1");
        ' Recupera el RadAjaxPanel
        rad = master.FindControl("RadAjaxPanel")

        ' Abre la ventana
        rad.ResponseScripts.Add("Abrir_winRemesaEntregaCotizacion();")

    End Sub

    Public Sub Abrir_winwinPrimerCg()
        Dim rad As RadAjaxPanel
        'Control lbl = this.Page.Master.FindControl("Cabecera1");
        ' Recupera el RadAjaxPanel
        rad = master.FindControl("RadAjaxPanel")

        ' Abre la ventana
        rad.ResponseScripts.Add("Abrir_winPrimerContactoGestor();")
    End Sub

    Public Sub Abrir_winwinSegDCita()
        Dim rad As RadAjaxPanel
        'Control lbl = this.Page.Master.FindControl("Cabecera1");
        ' Recupera el RadAjaxPanel
        rad = master.FindControl("RadAjaxPanel")

        ' Abre la ventana
        rad.ResponseScripts.Add("Abrir_winSegDCita();")

    End Sub

    Public Sub Abrir_winwinSeguimiento()
        Dim rad As RadAjaxPanel
        'Control lbl = this.Page.Master.FindControl("Cabecera1");
        ' Recupera el RadAjaxPanel
        rad = master.FindControl("RadAjaxPanel")

        ' Abre la ventana
        rad.ResponseScripts.Add("Abrir_winSeguimiento();")
    End Sub

    Public Sub Abrir_winSegACita()
        Dim rad As RadAjaxPanel
        rad = master.FindControl("RadAjaxPanel")
        rad.ResponseScripts.Add("Abrir_winSegACita();")
    End Sub

    Public Sub Abrir_winSegDCita()
        Dim rad As RadAjaxPanel
        rad = master.FindControl("RadAjaxPanel")
        rad.ResponseScripts.Add("Abrir_winSegDCita();")
    End Sub

    Public Sub Abrir_winSegTramite()
        Dim rad As RadAjaxPanel
        rad = master.FindControl("RadAjaxPanel")
        rad.ResponseScripts.Add("Abrir_winSegTramite();")
    End Sub

    Public Sub Abrir_winSegEnvDoc()
        Dim rad As RadAjaxPanel
        rad = master.FindControl("RadAjaxPanel")
        rad.ResponseScripts.Add("Abrir_winSegEnvDoc();")
    End Sub

    Public Sub Abrir_winwinDetalleSeguimientoGestor()
        Dim rad As RadAjaxPanel
        rad = master.FindControl("RadAjaxPanel")
        rad.ResponseScripts.Add("Abrir_winDetalleSeguimientoGestor();")
    End Sub

    Public Sub Abrir_winwinDetalleSeguimientoLlamada()
        Dim rad As RadAjaxPanel
        rad = master.FindControl("RadAjaxPanel")
        rad.ResponseScripts.Add("Abrir_winDetalleSeguimientoLlamada();")
    End Sub
    Public Sub Abrir_winwinCargaImg()
        Dim rad As RadAjaxPanel
        rad = master.FindControl("RadAjaxPanel")
        rad.ResponseScripts.Add("Abrir_winCargaImg();")
    End Sub

    Public Sub Abrir_winwinDetalleRecepcion()
        Dim rad As RadAjaxPanel
        rad = master.FindControl("RadAjaxPanel")
        rad.ResponseScripts.Add("Abrir_winDetalleRecepcion();")
    End Sub

    Public Sub Abrir_winwinDetalleVerificacion()
        Dim rad As RadAjaxPanel
        rad = master.FindControl("RadAjaxPanel")
        rad.ResponseScripts.Add("Abrir_winDetalleVerificacion();")
    End Sub

    Public Sub Abrir_winwinDetalleDigitalizacion()
        Dim rad As RadAjaxPanel
        rad = master.FindControl("RadAjaxPanel")
        rad.ResponseScripts.Add("Abrir_winDetalleDigitalizacion();")
    End Sub

    Public Sub Abrir_winwinDetalleEntrega()
        Dim rad As RadAjaxPanel
        rad = master.FindControl("RadAjaxPanel")
        rad.ResponseScripts.Add("Abrir_winDetalleEntrega();")
    End Sub

    Public Sub Abrir_winwinRecepcion()
        Dim rad As RadAjaxPanel
        'Control lbl = this.Page.Master.FindControl("Cabecera1");
        ' Recupera el RadAjaxPanel
        rad = master.FindControl("RadAjaxPanel")

        ' Abre la ventana
        rad.ResponseScripts.Add("Abrir_winRecepcion();")
    End Sub

    Public Sub Abrir_winwinVerificacionExp()
        Dim rad As RadAjaxPanel
        'Control lbl = this.Page.Master.FindControl("Cabecera1");
        ' Recupera el RadAjaxPanel
        rad = master.FindControl("RadAjaxPanel")

        ' Abre la ventana
        rad.ResponseScripts.Add("Abrir_winVerificacionExp();")
    End Sub

    'Public Sub Abrir_winwinVerifica()
    '    Dim rad As RadAjaxPanel
    '    'Control lbl = this.Page.Master.FindControl("Cabecera1");
    '    ' Recupera el RadAjaxPanel
    '    rad = master.FindControl("RadAjaxPanel")

    '    ' Abre la ventana
    '    rad.ResponseScripts.Add("Abrir_winVerifica();")
    'End Sub

    Public Sub Abrir_winwinDigitalizacion()
        Dim rad As RadAjaxPanel
        'Control lbl = this.Page.Master.FindControl("Cabecera1");
        ' Recupera el RadAjaxPanel
        rad = master.FindControl("RadAjaxPanel")

        ' Abre la ventana
        rad.ResponseScripts.Add("Abrir_winDigitalizacion();")
    End Sub

    Public Sub Abrir_winwinEntrega()
        Dim rad As RadAjaxPanel
        'Control lbl = this.Page.Master.FindControl("Cabecera1");
        ' Recupera el RadAjaxPanel
        rad = master.FindControl("RadAjaxPanel")

        ' Abre la ventana
        rad.ResponseScripts.Add("Abrir_winEntrega();")
    End Sub

    Public Sub Confirm(mensaje As String, callback As String)
        Dim rad As RadWindowManager

        ' Recupera el RadWindowManager
        rad = master.FindControl("RadWindowManager")

        ' Muestra el mensaje
        rad.RadConfirm(Comillas_JS(mensaje), callback, 450, 200, Nothing, "AutoSigue")
    End Sub

    Public Sub Alert(mensaje As String, Optional callBack As String = Nothing)
        Dim rad As RadWindowManager

        ' Recupera el RadWindowManager
        rad = master.FindControl("RadWindowManager")

        ' Muestra el mensaje
        rad.RadAlert(Comillas_JS(mensaje), 450, 200, "iGestoria", callBack)
    End Sub

    Public Sub Abrir_winwinSegDetRec()
        Dim rad As RadAjaxPanel
        'Control lbl = this.Page.Master.FindControl("Cabecera1");
        ' Recupera el RadAjaxPanel
        rad = master.FindControl("RadAjaxPanel")

        ' Abre la ventana
        rad.ResponseScripts.Add("Abrir_winSegDetRec();")
    End Sub

End Class

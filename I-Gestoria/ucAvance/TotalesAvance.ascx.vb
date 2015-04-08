Imports System.Data
Imports System.Web
Partial Class UserControls_Totales
    Inherits System.Web.UI.UserControl

    Dim csNeg As New ClaseNegocios
    Dim csSQLsvr As New BaseDatosSQL
    Dim csDAL As New DALClass

  

    Protected Sub lblTerminados_Click(sender As Object, e As System.EventArgs) Handles lblTerminados.Click
        'Dim window As New Telerik.Web.UI.RadWindow
        'RadWindowManager1.Windows.Clear()
        'With window
        '    .NavigateUrl = "D1.aspx?"
        '    .VisibleOnPageLoad = True
        '    .ID = "RadWindow1"
        '    .Width = 900
        '    .Height = 600
        '    .Modal = True
        '    .DestroyOnClose = True
        '    RadWindowManager1.Windows.Add(window)
        'End With



    End Sub

    Protected Sub lblTiempo_Click(sender As Object, e As System.EventArgs) Handles lblTiempo.Click
        'Dim window As New Telerik.Web.UI.RadWindow
        'RadWindowManager1.Windows.Clear()
        'With window

        '    .NavigateUrl = "D2.aspx?"
        '    .VisibleOnPageLoad = True
        '    .ID = "RadWindow2"
        '    .Width = 900
        '    .Height = 600
        '    .Modal = True
        '    .DestroyOnClose = True
        '    RadWindowManager1.Windows.Add(window)
        'End With
    End Sub

    Protected Sub lblFuera_Click(sender As Object, e As System.EventArgs) Handles lblFuera.Click
        'Dim window As New Telerik.Web.UI.RadWindow
        'RadWindowManager1.Windows.Clear()
        'With window
        '    .NavigateUrl = "D3.aspx?"
        '    .VisibleOnPageLoad = True
        '    .ID = "RadWindow3"
        '    .Width = 900
        '    .Height = 600
        '    .Modal = True
        '    .DestroyOnClose = True
        '    RadWindowManager1.Windows.Add(window)
        'End With
    End Sub
    
End Class

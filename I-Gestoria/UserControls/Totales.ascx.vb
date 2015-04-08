
Partial Class UserControls_Totales
    Inherits System.Web.UI.UserControl

    Private Name As String


    Public Property FullName() As String
        Get
            Return Me.Name
        End Get
        Set(ByVal Value As String)
            Me.Name = Value
        End Set
    End Property

    'Protected Sub lblNO_Click(sender As Object, e As System.EventArgs)
    '    'cboServicioTipo.SelectedValue()

    '    'Dim strName As String = "Alberto"
    '    ' lblNO.Attributes.Add("onclick", "window.open('Download.aspx?NAME=" + strName + "', 'newwindow','toolbar=yes,location=no,menubar=no,width=450,height=200,resizable=yes,scrollbars=yes,top=200,left=250');return false;")
    '    ' ScriptManager.RegisterStartupScript(ME.Page, ME.GetType(), "abrirManPagosR", "<script type=\"text/javascript\">myWindow=window.open('Manuales/Manual de Usuario (Contribuyente) Módulo Pagos_V3.0.htm','_blank','resizable=1,location=0,menubar=0,toolbar=0,scrollbars=yes')</script>", false);
    '    '}

    '    ' ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "InformacionDetalle", "<script type=\"text/javascript\">myWindow=window.open('Manuales/Manual de Usuario (Contribuyente) Módulo Consultas Gráficas y Alfanuméricas_V3.0.htm','_blank','resizable=1,location=0,menubar=0,toolbar=0,scrollbars=yes')</script>", false);

    'End Sub

End Class

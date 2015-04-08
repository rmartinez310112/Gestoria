<%@ Page Language="VB" AutoEventWireup="false" CodeFile="DetalleSeguimientoDocumentos.aspx.vb" Inherits="AsignacionControl_DetalleSeguimientoDocumentos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

        .style21
        {
            width: 100%;
        }
    </style>
</head>
<body style="background-color:#999E9B; color:White; font-family:Arial; font-size:smaller">
    <form id="form1" runat="server">
    <div>
    
        <table cellspacing="1" style="width: 100%">
            <tr>
                <td>
                    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel" Runat="server" 
                        Skin="Default">
                    </telerik:RadAjaxLoadingPanel>
                    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" 
                        DefaultLoadingPanelID="RadAjaxLoadingPanel">
                        <AjaxSettings>
                            <telerik:AjaxSetting AjaxControlID="RadAjaxPanel1">
                                <UpdatedControls>
                                    <telerik:AjaxUpdatedControl ControlID="RadAjaxPanel1" />
                                </UpdatedControls>
                            </telerik:AjaxSetting>
                        </AjaxSettings>
                    </telerik:RadAjaxManager>
                </td>
            </tr>
            <tr>
                <td>
                    <table class="style21">
                        <tr>
                            <td>
                                                                    <asp:Label ID="Label4" runat="server" 
                                                                        Text="Detalle de Seguimiento a Documentos"></asp:Label>
                                                                </td>
                        </tr>
                        <tr>
                            <td>
                    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="100%" 
                        LoadingPanelID="RadAjaxLoadingPanel" Width="100%">
                        <telerik:RadGrid ID="RadGrid1" runat="server">
                        </telerik:RadGrid>
                    </telerik:RadAjaxPanel>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    
    </div>
                                <telerik:RadScriptManager ID="RadScriptManager1" 
        Runat="server">
    </telerik:RadScriptManager>
    </form>
</body>
</html>

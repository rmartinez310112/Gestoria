<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="GestionDocumentos_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
        <link href="../HojaEstilos/StyleSheet3H.css" rel="stylesheet" type="text/css" />
    </head>
    <body style="height: 156px">
        <form id="form1" runat="server">
            <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy2" runat="server">
                <AjaxSettings>
                    <telerik:AjaxSetting AjaxControlID="RadAjaxPanel1">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="RadAjaxPanel1" 
                                                        LoadingPanelID="RadAjaxLoadingPanel1" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                </AjaxSettings>
            </telerik:RadAjaxManagerProxy>
            <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="" Transparency="30">
                <div class="loading">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/preloader.gif" AlternateText="loading">
                    </asp:Image>
                </div>
            </telerik:RadAjaxLoadingPanel>



            <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server"
                                  LoadingPanelID="RadAjaxLoadingPanel1">

                <table style="width:600px; border:1px;margin:auto;" >
                    <tr>
                        <td style="text-align:center;">
                            <asp:Button ID="button" Text="Regresar" runat="server" CssClass="button" />
                            
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align:center;">
                            <telerik:RadBinaryImage ID="RadBinaryImage1" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
                            </telerik:RadScriptManager>
                        </td>
                    </tr>
                </table>
            </telerik:RadAjaxPanel>
        </form>
    </body>
</html>

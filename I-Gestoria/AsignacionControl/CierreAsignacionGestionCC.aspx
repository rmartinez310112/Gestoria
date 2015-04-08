<%@ Page Language="VB" AutoEventWireup="false" CodeFile="CierreAsignacionGestionCC.aspx.vb"
Inherits="AsignacionControl_CierreAsignacionGestionCC" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <link href="../HojaEstilos/StyleSheet3H.css" rel="stylesheet" type="text/css" />
        <title></title>
        <style type="text/css">
            .style1
            {
            width: 100%;
            }
            .style2
            {
            width: 295px;
            }
        </style>
    </head>
    <body>
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
                <table class="style1">
                    <tr>
                        <td class="style2">
                            <asp:Label ID="Label1" runat="server" CssClass="EtiquetasEncabezado" Text="Confirmar Contacto con Cliente"></asp:Label>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <asp:Label ID="Label2" runat="server" 
                                       Text="Por favor de los No. de Identificación del cliente:" 
                                       CssClass="letrasdehojasblancas"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCierre" runat="server" Width="250px" CssClass="TxtBox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            &nbsp;
                        </td>
                        <td>
                            <asp:Button ID="Button1" runat="server" Text="Guardar y realizar Cierre" 
                                        CssClass="button" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            &nbsp;
                        </td>
                        <td>
                            <asp:Label ID="lblError" runat="server" CssClass="EtiquetasEncabezado" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </telerik:RadAjaxPanel>
            <div>
            </div>
        </form>
    </body>
</html>

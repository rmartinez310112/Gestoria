<%@ Page Language="VB" AutoEventWireup="false" CodeFile="SeguimientoGestor.aspx.vb" Inherits="FrontOffice_SeguimientoGestor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script type="text/javascript">

        function CloseAndRebind(args) {
            GetRadWindow().BrowserWindow.refreshGrid(args);
            GetRadWindow().close();
        }
        function GetRadWindow() {
            var oWindow = null;
            if (window.radWindow) oWindow = window.radWindow;
            //Will work in Moz in all cases, including clasic dialog                  
            else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
            //IE (and Moz as well)                  
            return oWindow;
        }
        function CancelEdit() {
            GetRadWindow().close();
        }


     </script>

    <style type="text/css">
        .style1
        {
            width: 100%;
            height: 134px;
        }
        .style2
        {}
        .style6
        {
        }
        .style9
        {
        }
        .style10
        {
            width: 271px;
        }
        .style14
        {
            width: 286px;
        }
        .style16
        {
            width: 84%;
        }
        .style17
        {
            width: 271px;
            height: 46px;
        }
        .style18
        {
            height: 46px;
        }
        .style19
        {
            height: 30px;
        }
        .style20
        {
            height: 22px;
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
                    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="100%" 
                        LoadingPanelID="RadAjaxLoadingPanel" Width="100%">
                        <table cellspacing="1" class="style1">
                            <tr>
                                <td class="style2" colspan="2">
                                    <asp:Label ID="Label1" runat="server" CssClass="TituloGestoria" 
                                        Font-Bold="True" Font-Size="15pt" Text="Seguimiento a Tramite del Gestor"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    <asp:Label ID="Label11" runat="server" Text="&nbsp;Sr (a) "></asp:Label>
                                </td>
                                <td class="style2">
                                    <asp:Label ID="lblNomAjustador" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    &nbsp;</td>
                                <td class="style2">
                                    <asp:Label ID="Label13" runat="server" 
                                        Text="Buenos días / tardes / noches, nos comunicamos de BENEFICIA.MX, para  solicitar informacion del servicio."></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style20">
                                    <asp:Label ID="lblDatosServicio1" runat="server">No. de Servicio:</asp:Label>
                                </td>
                                <td class="style20">
                                    <asp:Label ID="lblDatosServicio0" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style20">
                                    <asp:Label ID="lblDatosServicio2" runat="server">Asegurado:</asp:Label>
                                </td>
                                <td class="style20">
                                    <asp:Label ID="lblDatosServicio" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style6">
                                    <asp:Label ID="Label2" runat="server" Text="La llamada al Gestor es:"></asp:Label>
                                </td>
                                <td class="style16">
                                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                                        RepeatDirection="Horizontal" AutoPostBack="True">
                                        <asp:ListItem Value="1">Efectiva</asp:ListItem>
                                        <asp:ListItem Value="2">No Efectiva</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td class="style6" colspan="2">
                                    <hr style="color: #009933" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style6">
                                    &nbsp;</td>
                                <td class="style16">
                                    <asp:Panel ID="PanelEfectiva" runat="server" Visible="False">
                                        <table cellspacing="1" class="style1">
                                            <tr>
                                                <td class="style19">
                                                    <asp:Label ID="Label3" runat="server" Text="El tramite esta concluido:"></asp:Label>
                                                </td>
                                                <td class="style19">
                                                    <asp:RadioButtonList ID="RadioButtonList2" runat="server" 
                                                        RepeatDirection="Horizontal" AutoPostBack="True">
                                                        <asp:ListItem Value="1">Tramite Sigue Pendiente</asp:ListItem>
                                                        <asp:ListItem Value="2">Tramite ya se concluyo</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style9" colspan="2">
                                                    <asp:Panel ID="PanelPendiente" runat="server" Visible="False">
                                                        <table cellspacing="1" class="style1">
                                                            <tr>
                                                                <td class="style10">
                                                                    <asp:Label ID="Label4" runat="server" 
                                                                        Text="Motivo por el cual no se ha concluido:"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <telerik:RadComboBox ID="cboCausasConclusion" Runat="server" 
                                                                        Width="70%">
                                                                    </telerik:RadComboBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style17">
                                                                    <asp:Label ID="Label5" runat="server" Text="Fecha  se dara Seguimiento:"></asp:Label>
                                                                </td>
                                                                <td class="style18">
                                                                    <telerik:RadDatePicker ID="fechaSeguiDoc" Runat="server">
                                                                    </telerik:RadDatePicker>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style10">
                                                                    <asp:Label ID="Label6" runat="server" 
                                                                        Text="Se le recuerda que la fecha de conclución del tramite es:"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblFechaMaxTramite" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style9" colspan="2">
                                                    <asp:Panel ID="PanelConcluido" runat="server" Visible="False">
                                                        <table cellspacing="1" class="style1">
                                                            <tr>
                                                                <td class="style17">
                                                                    <asp:Label ID="Label8" runat="server" 
                                                                        Text="Fecha  en que enviara los documentos:"></asp:Label>
                                                                </td>
                                                                <td class="style18">
                                                                    <telerik:RadDatePicker ID="fechaSegEnvio" Runat="server">
                                                                    </telerik:RadDatePicker>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style10">
                                                                    <asp:Label ID="Label9" runat="server" 
                                                                        Text="Se le recuerda que la fecha de conclución del tramite es:"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblFechaMaxTramite0" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td class="style6">
                                    &nbsp;</td>
                                <td class="style16">
                                    <asp:Panel ID="PanelNOEfectiva" runat="server" Visible="False">
                                        <table cellspacing="1" class="style1">
                                            <tr>
                                                <td class="style14">
                                                    <asp:Label ID="Label10" runat="server" 
                                                        Text="Causa por la cual no se contacto al Gestor:"></asp:Label>
                                                </td>
                                                <td>
                                                    <telerik:RadComboBox ID="cboMotivoNoefectivo" Runat="server" 
                                                        Width="70%">
                                                    </telerik:RadComboBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td class="style6">
                                    &nbsp;</td>
                                <td class="style16">
                                    <asp:Button ID="cmdGuardar" runat="server" Enabled="False" Height="35px" 
                                        Text="Guardar" Width="184px" />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadAjaxPanel>
                </td>
            </tr>
        </table>
    
    </div>
                                    <telerik:RadNotification ID="RadNotification"   runat="server">
                                    </telerik:RadNotification>
                                <telerik:RadScriptManager ID="RadScriptManager1" 
        Runat="server">
    </telerik:RadScriptManager>
    </form>
</body>
</html>

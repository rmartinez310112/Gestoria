<%@ Page Language="VB" AutoEventWireup="false" CodeFile="SeguimientoEnvioDocumentos.aspx.vb" Inherits="FrontOffice_SeguimientoEnvioDocumentos" %>

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
        .style19
        {
            height: 30px;
            width: 85%;
        }
        .style10
        {
            width: 271px;
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
        .style14
        {
            width: 286px;
            height: 21px;
        }
        .style20
        {
            height: 30px;
            width: 273px;
        }
        .style21
        {
            width: 271px;
            height: 29px;
        }
        .style22
        {
            height: 29px;
        }
        .style23
        {
            width: 271px;
            height: 21px;
        }
        .style24
        {
            height: 21px;
        }
        .style25
        {
            width: 271px;
            height: 24px;
        }
        .style26
        {
            height: 24px;
        }
        .style27
        {
            width: 271px;
            height: 63px;
        }
        .style28
        {
            height: 63px;
        }
        .style29
        {
            width: 100%;
            height: 115px;
        }
        .style31
        {
            width: 3%;
            height: 22px;
        }
        .style32
        {
            height: 22px;
        }
        .style34
        {
            width: 83%;
        }
        .style35
        {
            width: 3%;
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
                                <td class="style2" colspan="3">
                                    <asp:Label ID="Label1" runat="server" CssClass="TituloGestoria" 
                                        Font-Bold="True" Font-Size="15pt" 
                                        Text="Seguimiento a Envio de Documentos:"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style35">
                                    <asp:Label ID="Label11" runat="server" Text="&nbsp;Sr (a) "></asp:Label>
                                </td>
                                <td class="style2" colspan="2">
                                    <asp:Label ID="lblNomAjustador" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style35">
                                    &nbsp;</td>
                                <td class="style2" colspan="2">
                                    <asp:Label ID="Label13" runat="server" 
                                        Text="Buenos días / tardes / noches, nos comunicamos de BENEFICIA.MX, para  solicitar informacion del servicio."></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style31">
                                </td>
                                <td class="style32" colspan="2">
                                    <asp:Label ID="lblDatosServicio1" runat="server">No. de Servicio:</asp:Label>
                                    <asp:Label ID="lblDatosServicio0" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style35">
                                    &nbsp;</td>
                                <td class="style2" colspan="2">
                                    <asp:Label ID="lblDatosServicio2" runat="server">Asegurado:</asp:Label>
                                    <asp:Label ID="lblDatosServicio" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style6" colspan="3">
                                    <hr style="color: #009933" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style6" colspan="2">
                                    <asp:Label ID="Label2" runat="server" Text="La llamada al Gestor es:"></asp:Label>
                                </td>
                                <td class="style34">
                                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" 
                                        RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1">Efectiva</asp:ListItem>
                                        <asp:ListItem Value="2">No Efectiva</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td class="style6" colspan="3">
                                    <hr style="color: #009933" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style6" colspan="2">
                                    &nbsp;</td>
                                <td class="style34">
                                    <asp:Panel ID="PanelEfectiva" runat="server" Visible="False">
                                        <table cellspacing="1" class="style1">
                                            <tr>
                                                <td class="style20">
                                                    <asp:Label ID="Label3" runat="server" 
                                                        Text="Nos podria indicar si ya se enviaron los documentos:"></asp:Label>
                                                </td>
                                                <td class="style19">
                                                    <asp:RadioButtonList ID="RadioButtonList2" runat="server" 
                                                        RepeatDirection="Horizontal" AutoPostBack="True">
                                                        <asp:ListItem Value="1">Si</asp:ListItem>
                                                        <asp:ListItem Value="2">No</asp:ListItem>
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
                                                                        Text="Motivo por el cual no se ha enviado:"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <telerik:RadComboBox ID="cboCausasConclusion" Runat="server" 
                                                                        Width="70%">
                                                                    </telerik:RadComboBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style17">
                                                                    <asp:Label ID="Label5" runat="server" 
                                                                        Text="Me podria dar la fecha estimada de envio:"></asp:Label>
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
                                                                        Text="Me podria indicar la fecha en que se enviarón:"></asp:Label>
                                                                </td>
                                                                <td class="style18">
                                                                    <telerik:RadDatePicker ID="fechaSegEnvio" Runat="server">
                                                                    </telerik:RadDatePicker>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style21">
                                                                    <asp:Label ID="Label14" runat="server" Text="Tipo de entrega es:"></asp:Label>
                                                                </td>
                                                                <td class="style22">
                                                                    <asp:RadioButtonList ID="rblTipoEntrega" runat="server" 
                                                                        RepeatDirection="Horizontal" TabIndex="2">
                                                                        <asp:ListItem Selected="True" Value="1">Local</asp:ListItem>
                                                                        <asp:ListItem Value="2">Foranea</asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style23">
                                                                    <asp:Label ID="Label17" runat="server" Text="Cia. de mensajeria:"></asp:Label>
                                                                </td>
                                                                <td class="style24">
                                                                    <telerik:RadComboBox ID="cbomensajeria" Runat="server" Width="70%">
                                                                    </telerik:RadComboBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style25">
                                                                    <asp:Label ID="Label15" runat="server" Text="No. de Guia:"></asp:Label>
                                                                </td>
                                                                <td class="style26">
                                                                    <asp:TextBox ID="txtGuia" runat="server" TabIndex="3" Width="245px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style27">
                                                                    <asp:Label ID="Label16" runat="server" Text="Comentarios:"></asp:Label>
                                                                </td>
                                                                <td class="style28">
                                                                    <asp:TextBox ID="txtComentarios" runat="server" Height="55px" TabIndex="4" 
                                                                        TextMode="MultiLine" Width="573px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style10">
                                                                    &nbsp;</td>
                                                                <td>
                                                                    &nbsp;</td>
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
                                <td class="style6" colspan="2">
                                    &nbsp;</td>
                                <td class="style34">
                                    <asp:Panel ID="PanelNOEfectiva" runat="server" Visible="False" Height="120px" 
                                        Width="1278px">
                                        <table cellspacing="1" class="style29">
                                            <tr>
                                                <td class="style14">
                                                    <asp:Label ID="Label10" runat="server" 
                                                        Text="Causa por la cual no se contacto al Gestor:"></asp:Label>
                                                </td>
                                                <td class="style24">
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
                                <td class="style6" colspan="3">
                                    <hr style="color: #009933" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style6" colspan="2">
                                    &nbsp;</td>
                                <td class="style34">
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

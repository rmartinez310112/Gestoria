<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RecepcionExpedientesGeneral.aspx.vb" Inherits="RecepcionExpedientesGeneral" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}.RadInput .riTextBox{height:17px}.RadInput .riTextBox{height:17px}.rdfd_{position:absolute}.rdfd_{position:absolute}div.RadPicker table.rcSingle .rcInputCell{padding-right:0}div.RadPicker table.rcSingle .rcInputCell{padding-right:0}.RadComboBox{margin:0;padding:0;min-height:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;*zoom:1;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox {width: 160px !important}.RadComboBox{margin:0;padding:0;min-height:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;*zoom:1;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}
.RadComboBox {width: 160px !important}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2012.3.1016.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2012.3.1016.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2012.3.1016.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2012.3.1016.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:none;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:none;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}
        .RadComboBox .rcbArrowCell{width:18px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2012.3.1016.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2012.3.1016.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2012.3.1016.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2012.3.1016.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}
        .style3
        {
        }
        .style4
        {
            width: 326px;
        }
        .style5
        {
            width: 362px;
        }
        .style6
        {
            width: 1303px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="" Transparency="30">
        <div class="loading">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/preloader.gif" AlternateText="loading">
            </asp:Image>
        </div>
    </telerik:RadAjaxLoadingPanel>
                </td>
            </tr>
            <tr>
                <td>
                        <table class="style1">
                            <tr>
                                <td class="style4">
                                    <asp:Image ID="Image2" runat="server" Height="64px" 
                                        ImageUrl="~/Imagenes/logo_beneficia.png" Width="315px" />
                                </td>
                                <td colspan="2">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style3" colspan="3">
                                    <hr />
                                </td>
                            </tr>
                            <tr>
                                <td class="style4">
                                    &nbsp;</td>
                                <td class="style6">
                                    <asp:Label ID="Label5" runat="server" Font-Size="20pt" 
                                        Text="Recepción de Expedientes Gestoria"></asp:Label>
                                </td>
                                <td>
                                    <asp:ImageButton ID="ImageButton1" runat="server" 
                                        ImageUrl="~/Imagenes/reporte_icon.jpeg" 
                                        ToolTip="Reporte de Expedientes Recibidos" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style4">
                                    &nbsp;</td>
                                <td colspan="2">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style4">
                                    &nbsp;</td>
                                <td colspan="2">
                                    <asp:Label ID="Label6" runat="server" 
                Text="Teclee el número. de Servicio:"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style4">
                                    &nbsp;</td>
                                <td colspan="2">
                                    <telerik:RadNumericTextBox ID="txtExpediente" Runat="server" 
                                        AutoPostBack="True" Culture="es-MX" DbValueFactor="1" LabelWidth="64px" 
                                        MinValue="0" ResolvedRenderMode="Classic" Width="160px">
                                         <NumberFormat GroupSeparator="" DecimalDigits="0" />
                                        
                                    </telerik:RadNumericTextBox>
                                    <asp:Button ID="Button1" runat="server" Text="Buscar Expediente" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style4">
                                    &nbsp;</td>
                                <td colspan="2">
                                    <asp:Label ID="lbldatos" runat="server" Font-Bold="True"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style4">
                                    &nbsp;</td>
                                <td colspan="2">
                                    <asp:Panel ID="Panel1" runat="server" Height="352px" Visible="False" 
                                        Width="100%">
                                        <table cellspacing="1" class="style1">
                                            <tr>
                                                <td class="style5">
                                                    <asp:Label ID="Label2" runat="server" Text="Fecha que se recibe el Expediente:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtFechaRecep" runat="server" Enabled="False" TabIndex="3" 
                                                        Width="245px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style5">
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="style5">
                                                    <asp:Label ID="Label7" runat="server" Text="Recibe:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:RadioButtonList ID="rblTipoEntrega0" runat="server" 
                                                        RepeatDirection="Horizontal" TabIndex="2">
                                                        <asp:ListItem Selected="True" Value="0">Recepcionista</asp:ListItem>
                                                        <asp:ListItem Value="1">Vigilancia</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style5">
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="style5">
                                                    <asp:Label ID="Label3" runat="server" Text="Tipo de entrega:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:RadioButtonList ID="rblTipoEntrega" runat="server" 
                                                        RepeatDirection="Horizontal" TabIndex="2">
                                                        <asp:ListItem Selected="True" Value="0">Local</asp:ListItem>
                                                        <asp:ListItem Value="1">Foranea</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style5">
                                                    &nbsp;</td>
                                                <td>
                                                    <telerik:RadComboBox ID="cbomensajeria" Runat="server" Width="70%">
                                                    </telerik:RadComboBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style5">
                                                    <asp:Label ID="Label4" runat="server" Text="No. de Guia:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtGuia" runat="server" TabIndex="3" Width="245px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style5">
                                                    <asp:Label ID="Label1" runat="server" Text="Comentarios:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtComentarios" runat="server" Height="55px" TabIndex="4" 
                                                        TextMode="MultiLine" Width="573px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style5">
                                                    &nbsp;</td>
                                                <td>
                                                    <asp:Button ID="cmdGuardar" runat="server" Enabled="False" 
                                                        style="margin-top: 0px" Text=" Guardar Expediente" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style5">
                                                    &nbsp;</td>
                                                <td>
                                                    <asp:Label ID="lbldatos0" runat="server" Font-Bold="True"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td class="style4">
                                    &nbsp;</td>
                                <td colspan="2">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style3" colspan="3">
                                    <hr />
                                </td>
                            </tr>
                        </table>
                    </td>
            </tr>
            <tr>
                <td>
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                <Scripts>
                    <%--Needed for JavaScript IntelliSense in VS2010--%>
                    <%--For VS2008 replace RadScriptManager with ScriptManager--%>
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
                </Scripts>
            </telerik:RadScriptManager>

                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>

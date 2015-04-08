<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGestionOperativa.master" AutoEventWireup="false" CodeFile="AltaGestor.aspx.vb" Inherits="AsignacionControl_TableroControlGestion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../HojaEstilos/StyleSheet3H.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .RadComboBox {width: 160px !important}.RadComboBox_Default{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox{margin:0;padding:0;min-height:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;*zoom:1;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2012.3.1016.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2012.3.1016.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:none;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2012.3.1016.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2012.3.1016.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}
        .style54
        {
        }
        .style55
        {
        width: 86%;
        }
        .style56
        {
            width: 1283px;
        }
    .style57
    {
        height: 49px;
    }
        .style58
        {
            height: 26px;
        }
        .style59
        {
            width: 86%;
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
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
    <table id="tabla1" cellspacing="1" class="style7">
        <tr>
            <td class="style56">
                <asp:Label ID="Label18" runat="server" CssClass="Titulos" 
                           Text="Alta de Gestores"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style56"> 
                <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server"
                                      LoadingPanelID="RadAjaxLoadingPanel1" Width="16px">
                    <table>
                        <tr>
                            <td class="style54">
                                <asp:Label ID="Label47" runat="server" Text="Tipo de Persona"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style57" colspan="2">
                                <asp:RadioButtonList ID="RdTipoPersona" runat="server" 
                                    RepeatDirection="Horizontal" AutoPostBack="True">
                                    <asp:ListItem Selected="True" Value="0">Persona Fisica</asp:ListItem>
                                    <asp:ListItem Value="1">Persona Moral</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td class="style54">
                                &nbsp;<asp:Label ID="LlbNombre" runat="server" Text="Nombre"></asp:Label>
                                &nbsp;</td>
                            <td class="style55">
                                &nbsp;
                                <asp:Label ID="LblAPaterno" runat="server" Text="Apellido Paterno"></asp:Label>
                            </td>
                            <td class="style55">
                                <asp:Label ID="LblAMaterno" runat="server" Text="Apellido Materno"></asp:Label>
                            </td>
                            <td class="style55">
                                <asp:Label ID="Label30" runat="server" Text="RFC"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style54">
                                <telerik:RadTextBox ID="RadTxtNombre" Runat="server" LabelWidth="" 
                                    Resize="None">
                                </telerik:RadTextBox>
                            </td>
                            <td class="style55">
                                
                                <telerik:RadTextBox ID="RadTxtAPaterno" Runat="server" 
                                    Width="147px" LabelWidth="">
                                </telerik:RadTextBox>
                                &nbsp;&nbsp;

                            </td>
                            <td class="style55">
                                <telerik:RadTextBox ID="RadTxtAMaterno" Runat="server" 
                                    Width="147px">
                                </telerik:RadTextBox>
                            </td>
                            <td class="style55">
                                <telerik:RadTextBox ID="TxtRFC" Runat="server">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style54">
                                <asp:Label ID="Label31" runat="server" Text="Direccion"></asp:Label>
                            </td>
                            <td class="style55">
                                &nbsp;</td>
                            <td>
                                <asp:Label ID="Label32" runat="server" Text="Colonia"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style54" colspan="2">
                                <telerik:RadTextBox ID="TxtDireccion" Runat="server" Width="300px">
                                </telerik:RadTextBox>
                            </td>
                            <td class="style55">
                                <telerik:RadTextBox ID="TxtColonia" Runat="server" LabelWidth="">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style54">
                                <asp:Label ID="Label33" runat="server" Text="Estado"></asp:Label>
                            </td>
                            <td class="style55">
                                <asp:Label ID="Label34" runat="server" Text="Municipio / Delegacion"></asp:Label>
                            </td>
                            <td class="style55">
                                <asp:Label ID="Label35" runat="server" Text="Codigo Postal"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style54">
                                <telerik:RadComboBox ID="CboEstado" Runat="server" AutoPostBack="True">
                                </telerik:RadComboBox>
                            </td>
                            <td class="style55">
                                <telerik:RadComboBox ID="CboMpio" Runat="server">
                                </telerik:RadComboBox>
                            </td>
                            <td class="style55">
                                <telerik:RadTextBox ID="TxtCP" Runat="server" MaxLength="6">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style54">
                                <asp:Label ID="Label36" runat="server" Text="Estado Atencion" Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style54">
                                <telerik:RadComboBox ID="CboEstadoAtencion" Runat="server" Visible="False">
                                </telerik:RadComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style54">
                                <asp:Label ID="Label37" runat="server" Text="Celular"></asp:Label>
                            </td>
                            <td class="style55">
                                <asp:Label ID="Label38" runat="server" Text="Fijo"></asp:Label>
                            </td>
                            <td class="style55">
                                <asp:Label ID="Label39" runat="server" Text="Nextel"></asp:Label>
                            </td>
                            <td class="style55">
                                <asp:Label ID="Label40" runat="server" Text="Email"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style54">
                                <telerik:RadTextBox ID="TxtCelular" Runat="server" LabelWidth="">
                                </telerik:RadTextBox>
                            </td>
                            <td class="style55">
                                <telerik:RadTextBox ID="TxtFijo" Runat="server" LabelWidth="">
                                </telerik:RadTextBox>
                            </td>
                            <td class="style55">
                                <telerik:RadTextBox ID="TxtNextel" Runat="server" LabelWidth="">
                                </telerik:RadTextBox>
                            </td>
                            <td class="style55">
                                <telerik:RadTextBox ID="TxtEmail" Runat="server" LabelWidth="">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style54">
                                <asp:Label ID="Label41" runat="server" Text="Cuanta Clabe"></asp:Label>
                            </td>
                            <td class="style55">
                                &nbsp;</td>
                            <td class="style55">
                                <asp:Label ID="Label42" runat="server" Text="Banco"></asp:Label>
                            </td>
                            <td class="style55">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style58">
                                <asp:TextBox ID="TxtClabe" runat="server" Width="157px"></asp:TextBox>
                            </td>
                            <td>
                                </td>
                            <td>
                                <telerik:RadComboBox ID="CboBancos" Runat="server">
                                </telerik:RadComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style58">
                                <asp:Label ID="Label51" runat="server" Text="Cuanta Clabe"></asp:Label>
                                &nbsp;2</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:Label ID="Label52" runat="server" Text="Banco"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style58">
                                <asp:TextBox ID="TxtClabe2" runat="server" Width="157px"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>
                                <telerik:RadComboBox ID="CboBancos2" Runat="server">
                                </telerik:RadComboBox>
                            </td>
                        </tr>
                        </table>
                        <table>
                        <tr>
                            <td class="style54">
                                <asp:Label ID="Label43" runat="server" Text="Tipo de Tabulador"></asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:Label ID="Label53" runat="server" Text="Si cuenta con poderes marque las empresas que puede atender:"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style54">
                                <telerik:RadComboBox ID="CboTabulador" Runat="server" Culture="es-ES">
                                    <Items>
                                        <telerik:RadComboBoxItem runat="server" Text="Seleccionar" Value="" />
                                        <telerik:RadComboBoxItem runat="server" Text="A" Value="A" />
                                        <telerik:RadComboBoxItem runat="server" Text="B" Value="B" />
                                        <telerik:RadComboBoxItem runat="server" Text="C" Value="C" />
                                        <telerik:RadComboBoxItem runat="server" Text="Propio" Value="Propio" />
                                    </Items>
                                </telerik:RadComboBox>
                            </td>
                            <td colspan="2" rowspan="4">
                                <asp:CheckBoxList ID="chklst_Poderes" runat="server" 
                                     DataTextField="cliente_NomCliente" 
                                    DataValueField="cliente_clvCliente">
                                    
                                </asp:CheckBoxList>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:ConnStringSQL %>" 
                                    SelectCommand="SELECT [cliente_clvCliente], [cliente_NomCliente] FROM [Clientes] WHERE [cliente_clvCliente]<>0">
                                </asp:SqlDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td class="style54">
                                <asp:Label ID="Label44" runat="server" Text="Estatus"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style54">
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                                    RepeatDirection="Horizontal" Width="71px">
                                    <asp:ListItem Selected="True" Value="0">Activo</asp:ListItem>
                                    <asp:ListItem Value="1">Inactivo</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                        <td style="color:White;">
                            &nbsp;</td>
                        </tr>
                            <tr>
                                <td style="color:White;">
                                    <asp:Label ID="Label48" runat="server" Text="Estados:"></asp:Label>
                                </td>
                                <td colspan="2">
                                </td>
                            </tr>
                        <tr>
                            <td style="color: White;">
                                <telerik:RadComboBox ID="CboEstados" Runat="server" AutoPostBack="True" 
                                    Culture="es-ES" Width="100%">
                                    <Items>
                                        <telerik:RadComboBoxItem runat="server" Owner="CboEstados" Text="Seleccionar" 
                                            Value="" />
                                        <telerik:RadComboBoxItem runat="server" Owner="CboEstados" Text="A" Value="A" />
                                        <telerik:RadComboBoxItem runat="server" Owner="CboEstados" Text="B" Value="B" />
                                        <telerik:RadComboBoxItem runat="server" Owner="CboEstados" Text="C" Value="C" />
                                        <telerik:RadComboBoxItem runat="server" Owner="CboEstados" Text="Propio" 
                                            Value="Propio" />
                                    </Items>
                                </telerik:RadComboBox>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td style="color: White;">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="color: White;">
                                <asp:Label ID="Label50" runat="server" Text="Mpios:"></asp:Label>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td style="color: White;">
                                <asp:Label ID="Label49" runat="server" Text="Mpios Asignados:"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                                    <td style="width: 121px; height: 143px">
                                        <asp:ListBox ID="lstEstados" TabIndex="4" runat="server" Width="305px" Height="141px"
                                            SelectionMode="Multiple"></asp:ListBox>
                                    </td>
                                    <td style="width: 27px; height: 143px" align="center">
                                        <table id="Table5" style="width: 24px; height: 109px" cellspacing="1" cellpadding="1"
                                            width="24" border="0">
                                            <tr>
                                                <td align="center">
                                                    <asp:Button ID="cmdasigna" TabIndex="5" runat="server" Text=">>"></asp:Button>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <asp:Button ID="cmdelimina" TabIndex="6" runat="server" Text="<<"></asp:Button>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <asp:Button ID="Button2" TabIndex="5" runat="server" Text="Todos"></asp:Button>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td style="height: 143px">
                                        <asp:ListBox ID="lstEstadosAgre" TabIndex="7" runat="server" Width="305px" Height="142px"
                                            SelectionMode="Multiple"></asp:ListBox>
                                    </td>
                                </tr>
                        <tr>
                            <td class="style54">
                                <asp:Button ID="CmdAlta" runat="server" CssClass="button" 
                                    Text="Agregar Gestor" />
                            </td>
                            <td class="style55">
                                <asp:Button ID="CmdModifica" runat="server" CssClass="button" 
                                    Text="Modificar Datos" />
                            </td>
                        </tr>
                    </table>
                        <telerik:RadNotification ID="RadNotification2" runat="server" 
                                    AnimationDuration="2000" LoadContentOn="EveryShow" Position="Center" 
                                    Title="Atención!">
                                </telerik:RadNotification>
                </telerik:RadAjaxPanel>
            </td>
        </tr>
        </table>
</asp:Content>
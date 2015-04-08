<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGestionOperativa.master" AutoEventWireup="false" CodeFile="Gestores.aspx.vb" Inherits="AsignacionControl_TableroControlGestion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../HojaEstilos/StyleSheet3H.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .RadComboBox {
        }.RadComboBox_Default{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox{margin:0;padding:0;min-height:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;*zoom:1;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2012.3.1016.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2012.3.1016.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:none;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2012.3.1016.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2012.3.1016.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}
        .style56
        {
            width: 1283px;
        }
        .style58
        {
            width: 44%;
        }
        .style64
        {
            width: 100%;
        }
        .style66
        {
            width: 575px;
        }
        .style67
        {
            width: 20px;
        }
        .style55
        {
        width: 86%;
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
                           Text="Control de Gestores"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style56"> 
                <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server"
                                      LoadingPanelID="RadAjaxLoadingPanel1">
                    <table cellspacing="1" class="style7" width="130px">
                        <tr>
                            <td class="style66">
                                <asp:RadioButtonList ID="RdbTipo" runat="server" AutoPostBack="True" 
                                    Width="167px">
                                    <asp:ListItem Selected="True" Value="0">Nombre del Ajustador</asp:ListItem>
                                    <asp:ListItem Value="1">RFC</asp:ListItem>
                                    <asp:ListItem Value="2">Estado</asp:ListItem>
                                </asp:RadioButtonList>
                                </td>
                            <td class="style58">
                                <table class="style64">
                                    <tr>
                                        <td class="style54">
                                            &nbsp;<asp:Label ID="LlbNombre" runat="server" Text="Nombre"></asp:Label>
                                            &nbsp;</td>
                                        <td class="style55">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style54" colspan="2">
                                            <telerik:RadTextBox ID="RadTxtNombre" Runat="server" Height="22px" 
                                                LabelWidth="" Resize="None" Width="292px">
                                            </telerik:RadTextBox>
                                            &nbsp;&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <telerik:RadTextBox ID="TxtRFC" Runat="server">
                                            </telerik:RadTextBox>
                                        </td>
                                        <td class="style67">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="LblRegion" runat="server" Text="Regional"></asp:Label>
                                        </td>
                                        <td class="style67">
                                            <asp:Label ID="LblEstado" runat="server" Text="Estado"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <telerik:RadComboBox ID="CboRegion" Runat="server" AutoPostBack="True">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td class="style67">
                                            <telerik:RadComboBox ID="CboEstado" Runat="server">
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                </table>
                                </td>
                        </tr>
                        <tr>
                            <td class="style66">
                                <asp:CheckBox ID="ChkInactivos" runat="server" Text="Inactivos" />
                            </td>
                            <td class="style58" dir="rtl">
                                <telerik:RadButton ID="RadButton1" runat="server" Text="Buscar">
                                </telerik:RadButton>
                            </td>
                        </tr>
                    </table>
                    <telerik:RadGrid ID="gridGestores" runat="server" CellSpacing="0" 
                    Culture="es-ES" GridLines="None" AutoGenerateColumns="False" Width="90%">
                    <MasterTableView>
                        <Columns>
                            <telerik:GridBoundColumn DataField="Nombre" 
                                FilterControlAltText="Filter nombre column" HeaderText="Nombre" 
                                UniqueName="nombre">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Activo" 
                                FilterControlAltText="Filter activo column" HeaderText="Activo" 
                                UniqueName="activo">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="RFCajustador" 
                                FilterControlAltText="Filter RFCAJUSTADOR column" HeaderText="RFCAJUSTADOR" 
                                UniqueName="RFCAJUSTADOR">
                            </telerik:GridBoundColumn>
                            <telerik:GridButtonColumn CommandName="cmdModificar" 
                                FilterControlAltText="Filter cmdModificar column" Text="Modificar" 
                                UniqueName="cmdModificar">
                            </telerik:GridButtonColumn>
                            <telerik:GridButtonColumn CommandName="cmdBaja" 
                                FilterControlAltText="Filter cmdBaja column" Text="Dar de Baja" 
                                UniqueName="cmdBaja">
                            </telerik:GridButtonColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
                </telerik:RadAjaxPanel>
                
<asp:Button ID="Button1234" runat="server" CssClass="button" Text="Agregar Gestor" />
                                <telerik:RadNotification ID="RadNotification2" runat="server" 
                                    AnimationDuration="2000" LoadContentOn="EveryShow" Position="Center" 
                                    Title="Atención!">
                                </telerik:RadNotification>
            </td>
        </tr>
        </table>
</asp:Content>
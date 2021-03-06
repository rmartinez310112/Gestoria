﻿<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGestionOperativa.master" AutoEventWireup="false" CodeFile="ReasignarGestores.aspx.vb" Inherits="AsignacionControl_ReasignarGestores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

            .style1
            {
            width: 100%;
            }

            .RadComboBox{margin:0;padding:0;min-height:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;*zoom:1;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}

            .RadComboBox {width: 160px !important}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2012.3.1016.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2012.3.1016.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:none;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}
        .RadComboBox .rcbArrowCell{width:18px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2012.3.1016.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2012.3.1016.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table cellspacing="1" class="style1">
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                            &nbsp;
                        <asp:Label  ID="lbltittle" runat="server" Text="Reasignación de Gestor" 
                    Font-Bold="True" Font-Size="20pt"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <table class="style1">
                    <tr>
                        <td>
                            <asp:Label ID="Label19" runat="server" CssClass="letrasdehojasblancas" 
                                                   Text="Estado:"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadComboBox ID="cboEstado" runat="server" Width="80%">
                            </telerik:RadComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                                        &nbsp;
                                    </td>
                        <td>
                            <asp:Button ID="Button123" Text="Buscar Gestor" runat="server" CssClass="button"/>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadGrid ID="grdiGestores" runat="server" AutoGenerateColumns="False" CellSpacing="0"
                                             Culture="es-ES" GridLines="None" Skin="Forest" 
                    Width="961px">
                    <MasterTableView>
                        <CommandItemSettings ExportToPdfText="Export to PDF">
                        </CommandItemSettings>
                        <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridBoundColumn DataField="rfcAjustador" FilterControlAltText="Filter column8 column"
                                                                 UniqueName="column8">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Nombre" FilterControlAltText="Filter column column"
                                                                 HeaderText="Nombre" UniqueName="column">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Paterno" FilterControlAltText="Filter column1 column"
                                                                 HeaderText="Paterno" UniqueName="column1">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="celular" FilterControlAltText="Filter column2 column"
                                                                 HeaderText="Celular" UniqueName="column2">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Tel1" FilterControlAltText="Filter column3 column"
                                                                 HeaderText="Telefono 1" UniqueName="column3">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Tel2" FilterControlAltText="Filter column4 column"
                                                                 HeaderText="Telefono 2" UniqueName="column4">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Tel3" FilterControlAltText="Filter column5 column"
                                                                 HeaderText="Telefono 2" UniqueName="column5">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Tel4" FilterControlAltText="Filter column6 column"
                                                                 HeaderText="Telefono 4" UniqueName="column6">
                            </telerik:GridBoundColumn>
                            <telerik:GridButtonColumn ButtonType="PushButton" CommandName="cmdAsignar" FilterControlAltText="Filter column7 column"
                                                                  HeaderText="Asignar Gestor" UniqueName="column7" 
                                            Text="Confirmar">
                            </telerik:GridButtonColumn>
                        </Columns>
                        <EditFormSettings>
                            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                            </EditColumn>
                        </EditFormSettings>
                    </MasterTableView>
                    <FilterMenu EnableImageSprites="False">
                    </FilterMenu>
                </telerik:RadGrid>
            </td>
        </tr>
        <tr>
            <td>
                            &nbsp;
                        </td>
        </tr>
        <tr>
            <td>
                            &nbsp;
                        </td>
        </tr>
        <tr>
            <td>
                            &nbsp;
                        </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                            &nbsp;
                        </td>
        </tr>
    </table>
</asp:Content>


<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGestionOperativa.master" AutoEventWireup="false" CodeFile="AsignarGestor.aspx.vb" Inherits="AsignacionControl_AsignarGestor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style52
        {
        width: 81px;
        }
    </style>
    <link href="../HojaEstilos/StyleSheet3H.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
                          LoadingPanelID="RadAjaxLoadingPanel1" Width="90%">
        <table cellspacing="1" class="style7">
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label20" runat="server" CssClass="Titulos" Text="Asignacion"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <table style="margin:justify;">
                        <tr>
                            <td style="text-align:right;">
                            <asp:Label ID="Label18" runat="server" CssClass="letrasdetodo" 
                                           Text="Cliente:"></asp:Label>
                            </td>
                            <td style="width:300px;">
                            <telerik:RadComboBox style="text-align:center" ID="CboCliente" Runat="server" Width="250px">
                                </telerik:RadComboBox>
                            </td>
                            <td style="text-align:right;">
                            <asp:Label ID="Label19" runat="server" CssClass="letrasdetodo" Text="Estado:"></asp:Label>
                            </td>
                            <td style="width:250px;">
                            <telerik:RadComboBox ID="cboEstado" Runat="server" Width="200px">
                            </telerik:RadComboBox>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>
                            <asp:Button ID="Button1" runat="server" CssClass="button" 
                                    Text="Buscar Servicios" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <telerik:RadNotification ID="RadNotification2" runat="server" 
                                                         AnimationDuration="2000" LoadContentOn="EveryShow" Position="Center" 
                                                         Title="Atención!">
                                </telerik:RadNotification>
                </td>
            </tr>
            
            <tr>
                <td>
                    <table> <%--style="width:100%"--%>
                        <tr>
                            <td style="width:70%">
                            
                    <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" 
                        Width="100%" Wrap="False">
                    <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" 
                                     CellSpacing="0" Culture="es-ES" 
                            Font-Size="10pt" Width="800px" HorizontalAlign="Center" Height="400px" 
                            GridLines="None"   >
                        <GroupHeaderItemStyle Font-Size="10pt" />
                        <MasterTableView>
                            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

                            <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                                <HeaderStyle Width="10px"></HeaderStyle>
                            </RowIndicatorColumn>

                            <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                                <HeaderStyle Width="10px"></HeaderStyle>
                            </ExpandCollapseColumn>

                            <Columns>
                                <telerik:GridButtonColumn CommandName="cmdNoGes" DataTextField="NoGestion" 
                                                          FilterControlAltText="Filter column1 column" UniqueName="column1">
                                    <FooterStyle Font-Size="10pt" Width="10px" />
                                    <HeaderStyle Font-Size="10pt" Width="10px" />
                                    <ItemStyle Font-Size="10pt" Width="10px" />
                                </telerik:GridButtonColumn>
                                <telerik:GridBoundColumn DataField="NoGestion" 
                                                         FilterControlAltText="Filter column column" UniqueName="column" 
                                                         Visible="False">
                                                         <FooterStyle Font-Size="10pt" Width="50px" />
                                    <HeaderStyle Font-Size="10pt" Width="50px" />
                                    <ItemStyle Font-Size="10pt" Width="50px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="cliente_NomCliente" 
                                                         FilterControlAltText="Filter column2 column" HeaderText="Aseguradora" 
                                                         UniqueName="column2">
                                                         <FooterStyle Font-Size="10pt" Width="50px" />
                                    <HeaderStyle Font-Size="10pt" Width="40px" />
                                    <ItemStyle Font-Size="10pt" Width="40px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Estado" 
                                                         FilterControlAltText="Filter column3 column" HeaderText="Estado" 
                                                         UniqueName="column3">
                                                         <FooterStyle Font-Size="10pt" Width="50px" />
                                    <HeaderStyle Font-Size="10pt" Width="40px" />
                                    <ItemStyle Font-Size="10pt" Width="40px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Mpio" 
                                                         FilterControlAltText="Filter column4 column" HeaderText="Municipio" 
                                                         UniqueName="column4">
                                                         <FooterStyle Font-Size="10pt" Width="50px" />
                                    <HeaderStyle Font-Size="10pt" Width="20px" />
                                    <ItemStyle Font-Size="10pt" Width="20px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="asegurado" 
                                                         FilterControlAltText="Filter column5 column" HeaderText="Asegurado" 
                                                         UniqueName="column5">
                                                         <FooterStyle Font-Size="10pt" Width="20px" />
                                    <HeaderStyle Font-Size="10pt" Width="20px" />
                                    <ItemStyle Font-Size="10pt" Width="20px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridButtonColumn ButtonType="PushButton" CommandName="cmdAsigna" 
                                                          FilterControlAltText="Filter column10 column" Text="Asignar Gestor" 
                                                          UniqueName="column10">
                                     <FooterStyle Font-Size="10pt" Width="20px" />
                                    <HeaderStyle Font-Size="10pt" Width="20px" />
                                    <ItemStyle Font-Size="10pt" Width="20px" />
                                </telerik:GridButtonColumn>
                                <telerik:GridBoundColumn DataField="Servicio_NomServicio" 
                                    FilterControlAltText="Filter column8 column" HeaderText="Servicio" 
                                    UniqueName="column8" Visible="False">
                                    <FooterStyle Font-Size="10pt" Width="50px" />
                                    <HeaderStyle Font-Size="10pt" Width="50px" />
                                    <ItemStyle Font-Size="10pt" Width="50px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridButtonColumn ButtonType="PushButton" CommandName="cmdConfirma" 
                                                          FilterControlAltText="Filter column9 column" Text="Confirmar Contacto" 
                                                          UniqueName="column9" Visible="False">
                                                          <FooterStyle Font-Size="10pt" Width="50px" />
                                    <HeaderStyle Font-Size="10pt" Width="20px" />
                                    <ItemStyle Font-Size="10pt" Width="20px" />
                                </telerik:GridButtonColumn>
                            </Columns>

                            <EditFormSettings>
                                <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                            </EditFormSettings>
                        </MasterTableView>

                        <FooterStyle Font-Size="10pt" />
                        <HeaderStyle Font-Size="10pt" />
                        <ItemStyle Font-Size="10pt" />

                        <FilterMenu EnableImageSprites="False"></FilterMenu>
                    </telerik:RadGrid>
                    </asp:Panel>
                    </td>
                        </tr>
                    </table>
                    
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
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </telerik:RadAjaxPanel>
</asp:Content>


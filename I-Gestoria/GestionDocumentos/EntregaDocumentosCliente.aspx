<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGestionOperativa.master" AutoEventWireup="false" CodeFile="EntregaDocumentosCliente.aspx.vb" Inherits="GestionDocumentos_EntregaDocumentosCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">




        .style10
        {
        width: 101%;
        }
        .style56
        {
        width: 218px;
        }
        .style57
        {
        width: 71%;
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
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel2" runat="server" Skin="" Transparency="30">
        <div class="loading">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/preloader.gif" AlternateText="loading">
            </asp:Image>
        </div>
    </telerik:RadAjaxLoadingPanel>



    <telerik:RadAjaxPanel ID="RadAjaxPanel2" runat="server"
                          LoadingPanelID="RadAjaxLoadingPanel1">

        <table cellspacing="1" class="style7">
            <tr>
                <td>
                    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
                        <AjaxSettings>
                            <telerik:AjaxSetting AjaxControlID="RadAjaxPanel1">
                                <UpdatedControls>
                                    <telerik:AjaxUpdatedControl ControlID="RadAjaxPanel1" 
                                                                LoadingPanelID="RadAjaxLoadingPanel1" />
                                </UpdatedControls>
                            </telerik:AjaxSetting>
                        </AjaxSettings>
                    </telerik:RadAjaxManagerProxy>
                    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" Runat="server" 
                                                 MinDisplayTime="10" Skin="Default">
                    </telerik:RadAjaxLoadingPanel>
                    <telerik:RadNotification ID="RadNotification2" runat="server" 
                                             LoadContentOn="EveryShow" Position="Center">
                    </telerik:RadNotification>
                </td>
            </tr>
            <tr>
                <td>
                    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" height="100%" 
                                          LoadingPanelID="RadAjaxLoadingPanel1" width="100%">
                        <table class="style10">
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="Label2" runat="server" CssClass="Titulos" 
                                               Text="Entrega  de Documentos al Cliente"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style56">
                                    <asp:Label ID="Label7" runat="server" CssClass="letrasdetodo" 
                                               Text="Fecha de Entrega de  documentos:"></asp:Label>
                                </td>
                                <td class="style57">
                                    <telerik:RadDatePicker ID="fechaSol" Runat="server">
                                        <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" 
                                                  ViewSelectorText="x">
                                        </Calendar>
                                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                        <DateInput DateFormat="MM/dd/yyyy" DisplayDateFormat="MM/dd/yyyy">
                                        </DateInput>
                                    </telerik:RadDatePicker>
                                </td>
                            </tr>
                            <tr>
                                <td class="style56">
                                    <asp:Label ID="Label10" runat="server" CssClass="letrasdetodo" 
                                               Text="Tipo de Entrega:"></asp:Label>
                                </td>
                                <td class="style57">
                                    <asp:RadioButtonList ID="rblTipoEntrega" runat="server" 
                                                         RepeatDirection="Horizontal" CssClass="letrasdetodo">
                                        <asp:ListItem Value="1" Selected="True">Fisica</asp:ListItem>
                                        <asp:ListItem Value="2">Paqueteria</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td class="style56">
                                </td>
                                <td class="style57">
                                    <asp:Button ID="button1" Text="Guardar Fecha de Entrega" runat="server" 
                                                CssClass="button" />
                                   
                                </td>
                            </tr>
                            <tr>
                                <td class="style56">
                                    &nbsp;
                                </td>
                                <td class="style57">
                                    <asp:Label ID="lblError" runat="server" CssClass="Errores" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style56">
                                    &nbsp;
                                </td>
                                <td class="style57">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="Label8" runat="server" CssClass="letrasdetodo" 
                                               Text="Documentos Pendientes de Entregar"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="Label9" runat="server" CssClass="Titulo" Font-Size="10pt" 
                                               ForeColor="Blue" 

                                               Text="Marque unicamente los documentos que va a entregar al cliente(Unicamente se podran entregar documentos validados)"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" 
                                                     CellSpacing="0" Culture="es-ES" GridLines="None">
                                        <MasterTableView>
                                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" 
                                                                Visible="True">
                                                <HeaderStyle Width="20px" />
                                            </RowIndicatorColumn>
                                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" 
                                                                  Visible="True">
                                                <HeaderStyle Width="20px" />
                                            </ExpandCollapseColumn>
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="Tramite_clvTramite" 
                                                                         FilterControlAltText="Filter column column" UniqueName="column">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Tramite_cvlSubTramite" 
                                                                         FilterControlAltText="Filter column1 column" UniqueName="column1">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Tramite_Descripcion" 
                                                                         FilterControlAltText="Filter column2 column" 
                                                                         HeaderText="Descripción del Documento" UniqueName="column2">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" 
                                                                            HeaderText="Entregado" UniqueName="TemplateColumn">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkRev" runat="server" Text="Revisado y Entregado" />
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="130px" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn1 column" 
                                                                            HeaderText="Observaciones" UniqueName="TemplateColumn1">
                                                    <ItemTemplate>
                                                        <telerik:RadTextBox ID="txtobs" Runat="server" TextMode="MultiLine">
                                                        </telerik:RadTextBox>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridBoundColumn FilterControlAltText="Filter column3 column" 
                                                                         HeaderText="Mensaje Sistema" UniqueName="column3" DataField="vacio">
                                                </telerik:GridBoundColumn>
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
                                <td colspan="2">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:CheckBox ID="chkEntregados" runat="server" AutoPostBack="True" 
                                                  Text="Documentos entregados al cliente" CssClass="letrasdetodo" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <telerik:RadGrid ID="RadGrid2" runat="server" AutoGenerateColumns="False" 
                                                     CellSpacing="0" Culture="es-ES" GridLines="None" Visible="False">
                                        <MasterTableView>
                                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" 
                                                                Visible="True">
                                                <HeaderStyle Width="20px" />
                                            </RowIndicatorColumn>
                                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" 
                                                                  Visible="True">
                                                <HeaderStyle Width="20px" />
                                            </ExpandCollapseColumn>
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="Tramite_Descripcion" 
                                                                         FilterControlAltText="Filter column2 column" 
                                                                         HeaderText="Descripción del Documento" UniqueName="column2">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="FechaChkEntregado" 
                                                                         DataFormatString=" {0:dd/MM/yyyy}" FilterControlAltText="Filter column column" 
                                                                         HeaderText="Fecha en que se Aceptaron" UniqueName="column">
                                                </telerik:GridBoundColumn>
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
                        </table>
                    </telerik:RadAjaxPanel>
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


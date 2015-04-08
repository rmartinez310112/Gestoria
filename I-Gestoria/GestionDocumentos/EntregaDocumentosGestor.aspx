<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGestionOperativa.master" AutoEventWireup="false" CodeFile="EntregaDocumentosGestor.aspx.vb" Inherits="GestionDocumentos_EntregaDocumentosGestor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">



        .style10
        {
        width: 101%;
        }
        .style56
        {
        }
        </style>
    <link href="../HojaEstilos/StyleSheet3H.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    

    <table class="style10">
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
                            <td>
                                <asp:Label ID="Label2" runat="server" CssClass="Titulos" 
                                           Text="Entrega  de Documentos al Gestor"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                        <td></td>
                        </tr>
                        <tr>
                        <td>
                            <asp:Label ID="Label7" runat="server" CssClass="letrasdetodo" 
                                Text="Fecha de Entrega de  documentos:" Visible="False"></asp:Label>
                            <telerik:RadDatePicker ID="fechaSol" Runat="server" Visible="False">
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
                            <td>
                            
                                
                            </td>
                            
                        </tr>
                        <tr>
                            <td class="style56">
                                &nbsp; &nbsp;
                                <asp:Label ID="lblError" runat="server" CssClass="Errores" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label8" runat="server" CssClass="letrasdetodo" 
                                           Text="Documentos Pendientes de Entregar"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label9" runat="server" CssClass="Titulo" Font-Size="10pt" 
                                           ForeColor="Blue" 
                                           Text="Marque unicamente los documentos que va a Recibir del  cliente"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" 
                                    Width="1350px" Wrap="False">
                                <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" 
                                                 CellSpacing="0" Culture="es-ES" GridLines="None" 
                                        Skin="Hay">
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
                                                                     FilterControlAltText="Filter column column" UniqueName="column" 
                                                                     Visible="False">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Tramite_cvlSubTramite" 
                                                                     FilterControlAltText="Filter column1 column" UniqueName="column1" 
                                                                     Visible="False">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="consec" 
                                                                     FilterControlAltText="Filter column4 column" UniqueName="column4" 
                                                                     Visible="False">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="TramitesGestion_Descrip" 
                                                                     FilterControlAltText="Filter column5 column" 
                                                                     HeaderText="Tramite" UniqueName="column5">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="documentos_descrip" 
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
                                </asp:Panel>
                                
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="width:195px;">
                                            <asp:Label ID="Label10" runat="server" CssClass="letrasdetodo" 
                                                Text="Tipo de Entrega:"></asp:Label>
                                            <asp:RadioButtonList ID="rblTipoEntrega" runat="server" CssClass="letrasdetodo" 
                                                RepeatDirection="Horizontal">
                                                <asp:ListItem Selected="True" Value="1">Fisica</asp:ListItem>
                                                <asp:ListItem Value="2">Paqueteria</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <td style="width:170px;">
                                            <asp:Button ID="button1" runat="server" CssClass="button" 
                                                Text="Guardar Fecha de Entrega" />
                                        </td>
                                        <td style="width:140px;text-align:right;">
                                            &nbsp;</td>
                                        <td style="width:190px;">
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                
                            </td>
                            <td>
                                
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID="chkEntregados" runat="server" AutoPostBack="True" 
                                              Text="Documentos Revisados y aceptados" CssClass="letrasdetodo" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="Panel2" runat="server" ScrollBars="Auto" Width="1350px">
                                <telerik:RadGrid ID="RadGrid2" runat="server" AutoGenerateColumns="False" 
                                                 CellSpacing="0" Culture="es-ES" GridLines="None" Visible="False" 
                                        Skin="Hay">
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
                                </asp:Panel>
                                
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
  
</asp:Content>


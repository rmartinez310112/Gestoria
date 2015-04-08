<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGestionOperativa.master" AutoEventWireup="false" CodeFile="AceptarDocumentosGestion.aspx.vb" Inherits="GestionDocumentos_AceptarDocumentosGestion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">


        .style10
        {
        width: 101%;
        }
        .style56
        {
        }
        .style57
        {
        width: 71%;
        }
    </style>
    <link href="../HojaEstilos/StyleSheet3H.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style10">
        <tr>
            <td>
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
                                           Text="Recepción de Documentos "></asp:Label>
                            </td>
                        </tr>
                        <tr>
                        <td></td>
                        </tr>
                        <tr>
                        <td></td>
                        </tr>
                        <tr>
                        
                            <td>
                                <table>
                                    <tr>
                                        <td style="width:250px;text-align:right;">
                                        <asp:Label ID="Label7" runat="server" CssClass="letrasdetodo" 
                                           Text="Fecha de recepción de  documentos:" Visible="False"></asp:Label>
                                        </td>
                                        <td style="width:200px;">
                                        <telerik:RadDatePicker ID="fechaSol" Runat="server" Enabled="False" Visible="False">
                                    <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" 
                                              ViewSelectorText="x" >
                                    </Calendar>
                                    <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                    <DateInput DateFormat="MM/dd/yyyy" DisplayDateFormat="MM/dd/yyyy">
                                    </DateInput>
                                </telerik:RadDatePicker>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="style56">
                                &nbsp;
                                <asp:Label ID="lblError" runat="server" CssClass="Errores" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label8" runat="server" CssClass="letrasdetodo" 
                                    Text="Documentos Pendientes de Recibir"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label9" runat="server" CssClass="Titulo" 
                                           
                                    Text="Marque unicamente los documentos que va a Recibir del  cliente" 
                                    Font-Size="10pt" ForeColor="Blue"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" Width="1350px">
                                    <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" 
                                        CellSpacing="0" Culture="es-ES" GridLines="None" Skin="Hay">
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
                                                    FilterControlAltText="Filter column column" UniqueName="column" Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Tramite_cvlSubTramite" 
                                                    FilterControlAltText="Filter column1 column" UniqueName="column1" 
                                                    Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="consec" 
                                                    FilterControlAltText="Filter column4 column" UniqueName="column4" 
                                                    Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField=" TramitesGestion_Descrip" 
                                                    FilterControlAltText="Filter column5 column" HeaderText="Tramite" 
                                                    UniqueName="column5">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField=" documentos_descrip" 
                                                    FilterControlAltText="Filter column2 column" 
                                                    HeaderText="Descripción del Documento" UniqueName="column2">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" 
                                                    HeaderText="Documento Revisado y Aceptado" UniqueName="TemplateColumn">
                                                    <ItemTemplate>
                                                        <asp:RadioButtonList ID="rblAcep" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Selected="True" Value="1">Aceptado</asp:ListItem>
                                                            <asp:ListItem Value="0">Rechazado</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn1 column" 
                                                    HeaderText="Observaciones" UniqueName="TemplateColumn1">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtObs" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridBoundColumn DataField="vacio" 
                                                    FilterControlAltText="Filter column3 column" HeaderText="Mensaje Sistema" 
                                                    UniqueName="column3">
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
                                &nbsp;
                                
                                <asp:Button ID="button" runat="server" CssClass="button" 
                                    Text="Guardar Fecha de Aceptacion" />
                                
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID="chkEntregados" runat="server" AutoPostBack="True" 
                                    CssClass="letrasdetodo" Text="Documentos Revisados y aceptados" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="Panel2" runat="server" Height="300px" ScrollBars="Auto" 
                                    Width="1350px">
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
                                                <telerik:GridBoundColumn DataField="documentos_descrip" 
                                                    FilterControlAltText="Filter column2 column" 
                                                    HeaderText="Descripción del Documento" UniqueName="column2">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="HRAVISO" DataFormatString=" {0:dd/MM/yyyy}" 
                                                    FilterControlAltText="Filter column column" 
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
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>


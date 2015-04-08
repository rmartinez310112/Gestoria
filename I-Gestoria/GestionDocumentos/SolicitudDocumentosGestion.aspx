<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGestionOperativa.master" AutoEventWireup="false" CodeFile="SolicitudDocumentosGestion.aspx.vb" Inherits="GestionDocumentos_SolicitudDocumentosGestion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

        .style10
        {
        width: 101%;
        }
        .style54
        {
        }
        .style55
        {
        width: 74%;
        }
    </style>
    <link href="../HojaEstilos/StyleSheet3H.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">






    <table class="style10">
        <tr>
            <td>
                
                <table class="style10">
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="Label2" runat="server" CssClass="Titulos" 
                                       Text="Solicitud de Documentos "></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style54">
                            &nbsp;
                        </td>
                        <td class="style55">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width:800px;">
                            &nbsp;</td>
                        <td style="width:800px;">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="width:150px;text-align:right;">
                                    <asp:Label ID="Label4" runat="server" CssClass="letrasdetodo" 
                                       Text="Documentos a Solicitar:"></asp:Label>
                                    </td>
                                    <td style="width:500px;">
                                    <telerik:RadComboBox ID="cboTipo" Runat="server" Width="450px">
                            </telerik:RadComboBox>
                                    </td>
                                    <td>
                                    <asp:Button ID="button12" Text="Buscar Documentos" runat="server"  CssClass="button" />
                                    </td>
                                </tr>
                            </table>
                          
                        </td>
                    </tr>
                    <tr>
                        <td class="style54">
                            <asp:Label ID="lblError" runat="server" CssClass="Errores"></asp:Label>
                        </td>
                        <td class="style55">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="Label9" runat="server" CssClass="Titulo" Font-Size="10pt" 
                                       ForeColor="Blue" 
                                       Text="Marque unicamente los documentos que va a solicitarle al cliente"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" 
                                Width="1300px" Height="300px">
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
                                                                 Visible="False" HeaderText="Tramite_clvTramite">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Tramite_cvlSubTramite" 
                                                                 FilterControlAltText="Filter column1 column" UniqueName="column1" 
                                                                 Visible="False" HeaderText="Tramite_cvlSubTramite">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Tramite_TipoPersona" 
                                                                 FilterControlAltText="Filter column5 column" HeaderText="Tramite_TipoPersona" 
                                                                 UniqueName="column5" Visible="False">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="clv_servVeh" 
                                                                 FilterControlAltText="Filter column6 column" HeaderText="clv_servVeh" 
                                                                 UniqueName="column6" Visible="False">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="TramitesGestion_Descrip" 
                                                                 FilterControlAltText="Filter column4 column" HeaderText="Tramite" 
                                                                 UniqueName="column4">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Tramite_Descripcion" 
                                                                 FilterControlAltText="Filter column2 column" 
                                                                 HeaderText="Descripción del Documento" UniqueName="column2">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" 
                                                                    HeaderText="Solicitar" UniqueName="TemplateColumn">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkSol" runat="server" />
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
                        <td colspan="2">
                            &nbsp;
                                                        
                            <asp:Button  ID="button2" Text="Guardar Fecha de Solicitud" runat="server" CssClass="button"/>
                               
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:CheckBox ID="chkEntregados" runat="server" AutoPostBack="True" 
                                          Text="Revisar documentos Solicitados" CssClass="letrasdetodo" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Panel ID="Panel2" runat="server" Height="300px" ScrollBars="Auto" 
                                Width="1300px">
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
                                        <telerik:GridBoundColumn DataField="TramitesGestion_Descrip" 
                                                                 FilterControlAltText="Filter column1 column" 
                                                                 HeaderText="Tramite" UniqueName="column1">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField=" documentos_descrip" 
                                                                 FilterControlAltText="Filter column2 column" 
                                                                 HeaderText="Descripción del Documento" UniqueName="column2">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="fechachkSolicitado" 
                                                                 DataFormatString=" {0:dd/MM/yyyy}" FilterControlAltText="Filter column column" 
                                                                 HeaderText="Fecha en que se Solicito" UniqueName="column">
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
    </table>
   
</asp:Content>


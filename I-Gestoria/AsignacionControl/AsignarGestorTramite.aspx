<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGestionOperativa.master" AutoEventWireup="false" CodeFile="AsignarGestorTramite.aspx.vb" Inherits="AsignacionControl_AsignarGestorTramite" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">



        .Titulos {
        color: navy;
        font-family: Tahoma, Arial, sans-serif;
        font-size: 14pt;
        font-stretch: normal;
        font-style: normal;
        font-weight: bold;
        text-align: left;
        text-transform: capitalize;
        }

    </style>
    <link href="../HojaEstilos/StyleSheet3H.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <meta http-equiv="refresh" content="30">

    <table cellspacing="1" class="style7">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label20" runat="server" CssClass="Titulos" 
                           Text="Asignacion"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" 
                                 CellSpacing="0" Culture="es-ES" GridLines="None" 
                    Skin="Forest">
                    <MasterTableView>
                        <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

                        <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </RowIndicatorColumn>

                        <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </ExpandCollapseColumn>

                        <Columns>
                            <telerik:GridBoundColumn DataField="Tramite_clvTramite" 
                                                     FilterControlAltText="Filter column column" UniqueName="column" Visible="False">
                                <ItemStyle Width="100px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TramitesGestion_Descrip" 
                                                     FilterControlAltText="Filter column1 column" HeaderText="Tramite" 
                                                     UniqueName="column1">
                            </telerik:GridBoundColumn>
                            <telerik:GridButtonColumn ButtonType="PushButton" CommandName="cmdAsigna" 
                                                      FilterControlAltText="Filter column2 column" HeaderText="Asignar" 
                                                      Text="Asignar Gestor" UniqueName="column2" ItemStyle-Width="50PX">
                                <ItemStyle Width="50px"></ItemStyle>
                            </telerik:GridButtonColumn>
                        </Columns>

                        <EditFormSettings>
                            <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                        </EditFormSettings>
                    </MasterTableView>

                    <FilterMenu EnableImageSprites="False"></FilterMenu>
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
                <telerik:RadGrid ID="RadGrid2" runat="server" AutoGenerateColumns="False" 
                                 CellSpacing="0" Culture="es-ES" GridLines="None" 
                    Skin="Forest">
                    <MasterTableView>
                        <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

                        <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </RowIndicatorColumn>

                        <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </ExpandCollapseColumn>

                        <Columns>
                            <telerik:GridBoundColumn DataField="Tramite_clvTramite" 
                                                     FilterControlAltText="Filter column3 column" UniqueName="column3" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Consec" 
                                                     FilterControlAltText="Filter column column" UniqueName="column" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="rfcGestor" 
                                                     FilterControlAltText="Filter column5 column" UniqueName="column5" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TramitesGestion_Descrip" 
                                                     FilterControlAltText="Filter column1 column" HeaderText="Tramite" 
                                                     UniqueName="column1">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="documentos_descrip" 
                                                     FilterControlAltText="Filter column2 column" HeaderText="Documento" 
                                                     UniqueName="column2">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn FilterControlAltText="Filter column6 column" 
                                                     HeaderText="Gestor Asignado" UniqueName="column6">
                            </telerik:GridBoundColumn>
                            <telerik:GridButtonColumn ButtonType="PushButton" CommandName="cmdReasigna" 
                                                      FilterControlAltText="Filter column4 column" Text="Reasignar" 
                                                      UniqueName="column4">
                            </telerik:GridButtonColumn>
                        </Columns>

                        <EditFormSettings>
                            <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                        </EditFormSettings>
                    </MasterTableView>

                    <FilterMenu EnableImageSprites="False"></FilterMenu>
                </telerik:RadGrid>
                <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
                </telerik:RadWindowManager>
                <telerik:RadWindow ID="RadWindow1" runat="server">
                </telerik:RadWindow>
            </td>
        </tr>
    </table>

    
</asp:Content>


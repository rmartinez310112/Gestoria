<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGestionOperativa.master"
AutoEventWireup="false" CodeFile="EnviarImagenDocumentosGestion.aspx.vb" Inherits="GestionDocumentos_EnviarImagenDocumentosGestion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function openWin() {
            radopen(null, "RadWindow1");
        }
    </script>
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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

        <table class="style10">
            <tr>
                <td>
                    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
                        <AjaxSettings>
                            <telerik:AjaxSetting AjaxControlID="RadAjaxPanel1">
                                <UpdatedControls>
                                    <telerik:AjaxUpdatedControl ControlID="RadAjaxPanel1" LoadingPanelID="RadAjaxLoadingPanel1" />
                                </UpdatedControls>
                            </telerik:AjaxSetting>
                        </AjaxSettings>
                    </telerik:RadAjaxManagerProxy>
                    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" MinDisplayTime="10"
                                                 Skin="Default">
                    </telerik:RadAjaxLoadingPanel>
                    <telerik:RadNotification ID="RadNotification2" runat="server" LoadContentOn="EveryShow"
                                             Position="Center">
                    </telerik:RadNotification>
                </td>
            </tr>
            <tr>
                <td>
                    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="100%" LoadingPanelID="RadAjaxLoadingPanel1"
                                          Width="100%">
                        <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
                        
                        </telerik:RadWindowManager>
                        <table class="style10">
                            <tr>
                                <td class="style56">
                                    &nbsp;
                                </td>
                                <td class="style57">
                                    <asp:Label ID="lblError" runat="server" CssClass="Errores" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="Label8" runat="server" CssClass="letrasdetodo" 
                                               Text="Envio de Imagenes Digitalizadas"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" CellSpacing="0"
                                                     Culture="es-ES" GridLines="None">
                                        <MasterTableView>
                                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                                                <HeaderStyle Width="20px" />
                                            </RowIndicatorColumn>
                                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                                                <HeaderStyle Width="20px" />
                                            </ExpandCollapseColumn>
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="Tramite_clvTramite" FilterControlAltText="Filter column column"
                                                                         UniqueName="column">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Tramite_cvlSubTramite" FilterControlAltText="Filter column1 column"
                                                                         UniqueName="column1">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Tramite_Descripcion" FilterControlAltText="Filter column2 column"
                                                                         HeaderText="Descripción del Documento" UniqueName="column2">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridButtonColumn ButtonType="PushButton" CommandName="cmdEnviar" FilterControlAltText="Filter column3 column"
                                                                          Text="Enviar Imagen" UniqueName="column3">
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
                                <td colspan="2">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    &nbsp;
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

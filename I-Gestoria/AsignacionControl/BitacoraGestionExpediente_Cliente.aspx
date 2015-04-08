<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGestionOperativa.master" AutoEventWireup="false" CodeFile="BitacoraGestionExpediente_Cliente.aspx.vb" Inherits="AsignacionControl_BitacoraGestionExpediente_Cliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../HojaEstilos/StyleSheet3H.css" rel="stylesheet" type="text/css" />

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
                          LoadingPanelID="RadAjaxLoadingPanel1">
        <table style="width:70%">
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label18" runat="server" Text="Bitacora" 
                               CssClass="Titulos"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: left">
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Panel ID="Panel1" runat="server" Visible="False">
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="Label19" runat="server" Text="Nuevo Registro en Bitacora:" 
                                               CssClass="letrasdetodo"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width:80%;">
                                    <telerik:RadTextBox ID="txtComentarios" Runat="server" Height="62px" 
                                                        TextMode="MultiLine" Width="474%">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="Button2" Text="Guardar Bitacora" runat="server" CssClass="button" /> 
                                    
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td>
                    <telerik:RadGrid ID="RadGrid1" runat="server" Skin="Hay" 
                        AutoGenerateColumns="False" CellSpacing="0" Culture="es-ES" GridLines="None">
                        <MasterTableView>
                            <Columns>
                                <telerik:GridBoundColumn DataField="Fecha" 
                                    FilterControlAltText="Filter column1 column" HeaderText="Fecha" 
                                    UniqueName="column1">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Comentario" 
                                    FilterControlAltText="Filter column column" HeaderText="Comentario" 
                                    UniqueName="column">
                                </telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
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

    </telerik:RadAjaxPanel>
</asp:Content>


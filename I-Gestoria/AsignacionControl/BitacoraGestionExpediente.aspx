<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGestionOperativa.master" AutoEventWireup="false" CodeFile="BitacoraGestionExpediente.aspx.vb" Inherits="AsignacionControl_BitacoraGestionExpediente" %>

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
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblError" runat="server" BorderColor="#FFFFCC" 
                        BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" Font-Overline="False" 
                        Font-Size="20pt" Font-Underline="False" ForeColor="Yellow"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: left">
                    <asp:Button ID="Button1" Text="Nuevo Registro" runat="server" CssClass="button" /> 
                    
                </td>
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
                    <telerik:RadGrid ID="RadGrid1" runat="server" Skin="Hay">
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


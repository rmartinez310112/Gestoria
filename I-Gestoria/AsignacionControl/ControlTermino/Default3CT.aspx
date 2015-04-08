<%@ Page Language="VB" MasterPageFile="~/AsignacionControl/MasterControlTermino.master" AutoEventWireup="false" CodeFile="Default3CT.aspx.vb" Inherits="Default3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style52
        {
        }
        .style55
        {
        width: 90px;
        height: 25px;
        }
        .style56
        {
        height: 25px;
            width: 469px;
        }
        .style57
        {
        width: 593px;
        height: 25px;
        }
        .style58
        {
        width: 408px;
        height: 25px;
        }
        .style59
        {
        width: 593px;
        }
        .style61
        {
        }
        .style62
        {
        width: 408px;
        }
        </style>
    <link href="HojaEstilos/StyleSheet3H.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            cambioRad()
        });

        function cambioRad() {
            if (document.getElementById('<%=rdoBtnRecibio .ClientID %>').checked == false) {
                (document.getElementById('<%=button.ClientID%>').innerHTML = 'Nuevo Registro');
                (document.getElementById('<%=RadGrid1.ClientID%>').style.display = "");
            }
            else {
                (document.getElementById('<%=button.ClientID%>').innerHTML = 'Guardar');
                (document.getElementById('<%=RadGrid1.ClientID%>').style.display = 'none');
                (document.getElementById('<%=Panel1.ClientID%>').style.display = 'none');
            }
        }

        function CloseAndRebind(args) {
            GetRadWindow().BrowserWindow.refreshGrid(args);
            GetRadWindow().close();
        }
        function GetRadWindow() {
            var oWindow = null;
            if (window.radWindow) oWindow = window.radWindow;
            //Will work in Moz in all cases, including clasic dialog                  
            else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
            //IE (and Moz as well)                  
            return oWindow;
        }
        function CancelEdit() {
            GetRadWindow().close();
        }
    </script>
    <link href="HojaEstilos/StyleSheet3H.css" rel="stylesheet" type="text/css" />
     


    <table style="width:600px;border:1px;">
        <tr>
            <td class="style52" colspan="4">

                <asp:Label ID="Label19" runat="server" Text="Entrega de Documentos Aseguradora" 
                           CssClass="Titulos"></asp:Label>
                <br />
                <br />
                <br />

            </td>
        </tr>
        <tr>
            <td style="text-align:right" class="style52" colspan="2">
                <asp:Label ID="Label18" runat="server" Text="Fecha de Entrega Aseguradora:" 
                           CssClass="letrasdetodo"></asp:Label>
            </td>
            <td class="style59">
                <telerik:RadDatePicker ID="RadDatePicker1" Runat="server" Culture="es-MX" 
                    HiddenInputTitleAttibute="Visually hidden input created for functionality purposes." 
                    WrapperTableSummary="Table holding date picker control for selection of dates." >
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%"></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
            <td class="style62">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style55">
            </td>
            <td class="style56">
                <asp:RadioButton ID="rdoBtnRecibio" runat="server" Text="Recibio Aseguradora" 
                                 CausesValidation="True" GroupName="rdo" CssClass="letrasdetodo" 
                                 Checked="True" onClick="cambioRad();"/>
            </td>
            <td class="style57">
                <asp:RadioButton ID="rdoBtnRechazo" runat="server" Text="Rechazo Aseguradora" 
                                 GroupName="rdo" CssClass="letrasdetodo" onClick="cambioRad();" 
                                 AutoPostBack="True"/>
            </td>
            <td class="style58">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style55">
                &nbsp;</td>
            <td style="text-align:center" colspan="2">
                
                <asp:Button ID="button" Text="Guardar" runat="server" CssClass="button"/>
            </td>
            <td class="style58">
                &nbsp;</td>
        </tr>
        <td class="style61" colspan="4">
            <asp:Panel ID="Panel1" runat="server" Visible="False">
                <table class="style7" style="height: 250px">
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Nuevo Registro de Rechazo:" 
                                CssClass="letrasdetodo"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadComboBox ID="CboMtvoRechazo" Runat="server" Culture="es-ES" 
                                DataSourceID="SqlDataSource1" DataTextField="Descripcion_Rechazo" 
                                DataValueField="id">
                            </telerik:RadComboBox>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:ConnStringSQL %>" 
                                SelectCommand="SELECT * FROM [Cat_RechazoPendienteTermino]">
                            </asp:SqlDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadTextBox ID="RadTxtObservacion" Runat="server" Height="69px" 
                                TextMode="MultiLine" Visible="False" Width="552px">
                            </telerik:RadTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="button2" Text="GuardarObservacionRechazo" runat="server" CssClass="button"/>
                            
                        </td>
                    </tr>
                   
                </table>
            </asp:Panel>
            &nbsp;
        </td>
        <tr>
            <td class="style61" colspan="4">
                <telerik:RadGrid ID="RadGrid1" runat="server" Skin="Office2007">
                </telerik:RadGrid>
            </td>
        </tr>
        <tr>
            <td class="style52" colspan="4">
                <asp:Label ID="lblEntrega" runat="server" CssClass="riLabel"></asp:Label>
                <br />
                        <telerik:RadNotification ID="RadNotification2" runat="server" 
                                                         AnimationDuration="2000" 
                                LoadContentOn="EveryShow" Position="Center" 
                                                         Title="Atención!">
                                </telerik:RadNotification>
            </td>
        </tr>
    </table>
</asp:Content>





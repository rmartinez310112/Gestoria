<%@ Page Title="" Language="VB" MasterPageFile="~/AsignacionControl/MasterControlTermino.master" AutoEventWireup="false" CodeFile="RecepcionExpedientesCT.aspx.vb" Inherits="AsignacionControl_ControlTermino_RecepcionExpedientesCT" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">


<script type="text/javascript" language="javascript">

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
    <style type="text/css">
.RadComboBox {width: 160px !important}.RadComboBox_Default{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox{margin:0;padding:0;min-height:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;*zoom:1;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox {width: 160px !important}.RadComboBox_Default{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox{margin:0;padding:0;min-height:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;*zoom:1;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2012.3.1016.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2012.3.1016.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2012.3.1016.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2012.3.1016.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:none;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:none;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2012.3.1016.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2012.3.1016.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2012.3.1016.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2012.3.1016.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}
        .style1
        {
            padding-left: 5px;
            padding-right: 4px;
            padding-top: 0;
            padding-bottom: 0;
        }
        .style2
        {
            padding: 0;
        }
    </style>
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
    <table class="style1">
            <tr>
                <td>
                    <asp:Panel ID="Panel1" runat="server" Visible="False">
                        <table class="style1">
                            <tr>
                                <td class="style2">
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Font-Size="20pt" 
                                        Text="Recepción de Expedientes Back Office"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    <asp:Label ID="Label6" runat="server" 
                Text="No. de Expediente:"></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="txtExpediente" Runat="server" 
                                        AutoPostBack="True" Culture="es-MX" DbValueFactor="1" LabelWidth="64px" 
                                        MinValue="0" ResolvedRenderMode="Classic" Width="160px">
                                         <NumberFormat GroupSeparator="" DecimalDigits="0" />
                                        
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="lbldatos" runat="server" Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style3">
                                    <asp:Label ID="Label2" runat="server" Text="Fecha que se recibe el Expediente:"></asp:Label>
                                </td>
                                <td class="style4">
                                    <telerik:RadDatePicker ID="dateRecibe" Runat="server" TabIndex="1" 
                                        Culture="es-MX" 
                                        HiddenInputTitleAttibute="Visually hidden input created for functionality purposes." 
                                        WrapperTableSummary="Table holding date picker control for selection of dates.">
                                        <Calendar Culture="es-ES" EnableWeekends="True" 
                                            FastNavigationNextText="&amp;lt;&amp;lt;" UseColumnHeadersAsSelectors="False" 
                                            UseRowHeadersAsSelectors="False">
                                        </Calendar>
                                        <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" 
                                            LabelWidth="40%" TabIndex="1">
                                            
                                        </DateInput>
                                        <DatePopupButton HoverImageUrl="" ImageUrl="" TabIndex="1" />
                                    </telerik:RadDatePicker>
                                    <telerik:RadTimePicker ID="RadTimePicker1" Runat="server" 
                                        SelectedTime="12:00:00">
                                        <Calendar EnableWeekends="True" UseColumnHeadersAsSelectors="False" 
                                            UseRowHeadersAsSelectors="False">
                                        </Calendar>
                                        <DatePopupButton CssClass="" HoverImageUrl="" ImageUrl="" Visible="False" />
                                        <TimeView CellSpacing="-1" Culture="es-MX">
                                        </TimeView>
                                        <TimePopupButton CssClass="" HoverImageUrl="" ImageUrl="" />
                                        <DateInput DateFormat="MM/dd/yyyy" DisplayDateFormat="MM/dd/yyyy" 
                                             LabelWidth="64px" SelectedDate="07/03/2014 12:00:00">
                                        </DateInput>
                                    </telerik:RadTimePicker>
                                </td>
                                <td class="style4">
                                </td>
                                <td class="style4">
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    <asp:Label ID="Label3" runat="server" 
                Text="Tipo de entrega:"></asp:Label>
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="rblTipoEntrega" runat="server" 
                RepeatDirection="Horizontal" TabIndex="2">
                                        <asp:ListItem Value="0" Selected="True">Local</asp:ListItem>
                                        <asp:ListItem Value="1">Foranea</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    &nbsp;</td>
                                <td>
                                    <telerik:RadComboBox ID="cbomensajeria" Runat="server" Width="70%" 
                                        Visible="False">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    <asp:Label ID="Label4" runat="server" Text="No. de Guia:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtGuia" runat="server" TabIndex="3" Width="245px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    <asp:Label ID="Label1" runat="server" Text="Comentarios:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtComentarios" runat="server" Height="55px" 
                TextMode="MultiLine" Width="573px" TabIndex="4"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    &nbsp;</td>
                                <td>
                                    <asp:Button ID="cmdGuardar" runat="server" 
                                        style="margin-top: 0px" Text=" Guardar Expediente" />
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                                    <asp:Label ID="Label7" runat="server" Font-Size="20pt" 
                                        Text="Expedientes  recibidos en Back Office sin verificar"></asp:Label>
                                </td>
            </tr>
            <tr>
                <td>
                                    <asp:Button ID="cmdGuardar0" runat="server" 
                                        style="margin-top: 0px" Text="Recibir Expediente" />
                                </td>
            </tr>
            <tr>
                <td>
                    <telerik:RadGrid ID="radExpedienteVer" runat="server" AutoGenerateColumns="False" 
                        Culture="es-ES" Width="1406px" CellSpacing="0" GridLines="None">
                        <MasterTableView>
                            <Columns>
                                <telerik:GridButtonColumn CommandName="cmdServicio" DataTextField="NoGestion" 
                                    FilterControlAltText="Filter column column" UniqueName="column">
                                </telerik:GridButtonColumn>
                                <telerik:GridBoundColumn DataField="NoGestion" Display="False" 
                                    FilterControlAltText="Filter column1 column" UniqueName="column1">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="TipoServicio" 
                                    FilterControlAltText="Filter column10 column" HeaderText="Servicio" 
                                    UniqueName="column10">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Reporte_FechaRepor" 
                                    FilterControlAltText="Filter column2 column" HeaderText="Fecha Reporte" 
                                    UniqueName="column2" DataFormatString="{0:dd/MM/yyyy}">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Reporte_poliza" 
                                    FilterControlAltText="Filter column3 column" HeaderText="No. de Poliza" 
                                    UniqueName="column3">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Aseguradora" 
                                    FilterControlAltText="Filter column4 column" HeaderText="Aseguradora" 
                                    UniqueName="column4">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="NombreAseg" 
                                    FilterControlAltText="Filter column5 column" HeaderText="Asegurado" 
                                    UniqueName="column5">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="EntregaExpediente_fecha" 
                                    FilterControlAltText="Filter column6 column" HeaderText="Fecha Recepcion BO" 
                                    UniqueName="column6" DataFormatString="{0:dd/MM/yyyy}">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="TipoEntrega" 
                                    FilterControlAltText="Filter column7 column" HeaderText="Tipo de Entrega" 
                                    UniqueName="column7">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="EntregaExpediente_Guia" 
                                    FilterControlAltText="Filter column8 column" HeaderText="No. Guia" 
                                    UniqueName="column8">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="EntregaExpediente_fechaVer" 
                                    FilterControlAltText="Filter column9 column" HeaderText="Fecha Verificacion BO" 
                                    UniqueName="column9" DataFormatString="{0:dd/MM/yyyy}">
                                </telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </div>
     <telerik:RadNotification ID="RadNotification2" runat="server">
     </telerik:RadNotification>
</asp:Content>



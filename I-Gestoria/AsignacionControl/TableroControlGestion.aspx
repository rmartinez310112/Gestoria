<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGestionOperativa.master" AutoEventWireup="false" CodeFile="TableroControlGestion.aspx.vb" Inherits="AsignacionControl_TableroControlGestion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../HojaEstilos/StyleSheet3H.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .RadComboBox {width: 160px !important}.RadComboBox_Default{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox{margin:0;padding:0;min-height:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;*zoom:1;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2012.3.1016.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2012.3.1016.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:none;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2012.3.1016.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2012.3.1016.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}
        .style54
        {
        }
        .style55
        {
        width: 86%;
        }
        .style56
        {
            width: 1283px;
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
    <table id="tabla1" cellspacing="1" class="style7">
        <tr>
            <td class="style56">
                <asp:Label ID="Label18" runat="server" CssClass="Titulos" 
                           Text="Control de Documentos"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style56"> 
                <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server"
                                      LoadingPanelID="RadAjaxLoadingPanel1">
                    <table cellspacing="1" class="style7">
                        <tr>
                            <td class="style54">
                                &nbsp;</td>
                            <td class="style55">
                                &nbsp;</td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td class="style54">
                                &nbsp;</td>
                            <td class="style55">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                 
                                 <table style="margin:justify;text-align:right;">
                                    <tr>
                                        <td>
                                        <asp:Label ID="Label1" runat="server" CssClass="letrasdetodo" 
                                             Text="Fecha Inicial:"></asp:Label>
                                        </td>
                                        <td>
                                        <telerik:RadDatePicker ID="txtFecha1" Runat="server">
                                         </telerik:RadDatePicker>
                                        </td>
                                        <td>
                                        <asp:Label ID="Label20" runat="server" CssClass="letrasdetodo" 
                                    Text="Fecha Final:"></asp:Label>
                                        </td>
                                        <td>
                                         <telerik:RadDatePicker ID="txtFecha2" Runat="server">
                                </telerik:RadDatePicker>
                                        </td>
                                        <td>
                                        <asp:Label ID="Label2" runat="server" CssClass="letrasdetodo" Text="Cliente:"></asp:Label>
                                        </td>
                                        <td>
                                        <telerik:RadComboBox ID="CboCliente" Runat="server" Width="80%">
                                </telerik:RadComboBox>
                                        </td>
                                        <td>
                                        <asp:Label ID="Label3" runat="server" CssClass="letrasdetodo" Text="Estado:"></asp:Label>
                                        </td>
                                        <td>
                                        <telerik:RadComboBox ID="cboEstado" Runat="server" Width="80%">
                                </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label24" runat="server" CssClass="letrasdetodo" Text="Estatus:"></asp:Label>
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="cboEstatus" Runat="server" Width="80%">
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                     <tr>
                                         <td>
                                             &nbsp;</td>
                                         <td>
                                             &nbsp;</td>
                                         <td>
                                             &nbsp;</td>
                                         <td>
                                             &nbsp;</td>
                                         <td>
                                             &nbsp;</td>
                                         <td>
                                             &nbsp;</td>
                                         <td>
                                             &nbsp;</td>
                                         <td>
                                             &nbsp;</td>
                                     </tr>
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                </table>
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
                            <td class="style54">
                                &nbsp;
                            </td>
                            <td class="style55">
                                
                                &nbsp;
                                &nbsp;
                                &nbsp;
                                &nbsp;
                                &nbsp;

                                <asp:Button ID="Button1234" runat="server" CssClass="button" 
                                    Text="Buscar Información" />
                                <asp:Button ID="Button1" runat="server" CssClass="button" Text="Exportar Excel" 
                                    Visible="False" />

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
                            <td class="style54">
                                &nbsp;
                            </td>
                            <td class="style55">
                                
                                <asp:Panel ID="Panel1" runat="server" 
                                    ScrollBars="Auto" Width="1300px" Font-Size="10pt" Wrap="False">
                                    <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" 
                                        Culture="es-ES" Font-Size="10pt" 
                                       >
                                        <GroupHeaderItemStyle Font-Size="10pt" />
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
                                                <telerik:GridButtonColumn CommandName="cmdGestion" DataTextField="NoGestion" 
                                                    FilterControlAltText="Filter column column" HeaderText="No.Gestion" 
                                                    UniqueName="column">
                                                    <HeaderStyle Font-Size="10pt" />
                                                    <ItemStyle Font-Size="8pt" />
                                                </telerik:GridButtonColumn>
                                                <telerik:GridBoundColumn DataField="NoGestion" 
                                                    FilterControlAltText="Filter column1 column" UniqueName="column1" 
                                                    Visible="False">
                                                     <HeaderStyle Font-Size="10pt" />
                                                    <ItemStyle Font-Size="8pt" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Reporte_FechaRepor" 
                                                    FilterControlAltText="Filter column2 column" HeaderText="Fecha.Reporte" 
                                                    UniqueName="column2" DataType="System.DateTime" 
                                                    DataFormatString="{0:MM/dd/yy H:mm:ss }">
                                                     <HeaderStyle Font-Size="10pt" />
                                                    <ItemStyle Font-Size="8pt" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Reporte_NombreAseg" 
                                                    FilterControlAltText="Filter column3 column" HeaderText="Nombre" 
                                                    UniqueName="column3">
                                                     <HeaderStyle Font-Size="10pt" />
                                                    <ItemStyle Font-Size="8pt" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Reporte_ApaternoAseg" 
                                                    FilterControlAltText="Filter column4 column" HeaderText="A.Paterno" 
                                                    UniqueName="column4">
                                                     <HeaderStyle Font-Size="10pt" />
                                                    <ItemStyle Font-Size="8pt" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Reporte_poliza" 
                                                    FilterControlAltText="Filter column5 column" HeaderText="Poliza" 
                                                    UniqueName="column5">
                                                     <HeaderStyle Font-Size="10pt" />
                                                    <ItemStyle Font-Size="8pt" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField=" Reporte_Inciso" 
                                                    FilterControlAltText="Filter column6 column" HeaderText="Inciso" 
                                                    UniqueName="column6">
                                                     <HeaderStyle Font-Size="10pt" />
                                                    <ItemStyle Font-Size="8pt" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Estado" 
                                                    FilterControlAltText="Filter column7 column" HeaderText="Estado" 
                                                    UniqueName="column7">
                                                     <HeaderStyle Font-Size="10pt" />
                                                    <ItemStyle Font-Size="8pt" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Mpio" 
                                                    FilterControlAltText="Filter column8 column" HeaderText="Mpio" 
                                                    UniqueName="column8">
                                                     <HeaderStyle Font-Size="10pt" />
                                                    <ItemStyle Font-Size="8pt" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField=" cliente_NomCliente" 
                                                    FilterControlAltText="Filter column9 column" HeaderText="Cliente" 
                                                    UniqueName="column9">
                                                     <HeaderStyle Font-Size="10pt" />
                                                    <ItemStyle Font-Size="8pt" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Servicio_NomServicio" 
                                                    FilterControlAltText="Filter column10 column" HeaderText="Tipo" 
                                                    UniqueName="column10">
                                                     <HeaderStyle Font-Size="10pt" />
                                                    <ItemStyle Font-Size="8pt" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn FilterControlAltText="Filter column11 column" 
                                                    HeaderText="Doc.Solicitados" UniqueName="column11" Display="False" 
                                                    Visible="False">
                                                     <HeaderStyle Font-Size="10pt" />
                                                    <ItemStyle Font-Size="8pt" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn FilterControlAltText="Filter column12 column" 
                                                    HeaderText="Entregados" UniqueName="column12" Display="False" 
                                                    Visible="False">
                                                     <HeaderStyle Font-Size="10pt" />
                                                    <ItemStyle Font-Size="8pt" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn FilterControlAltText="Filter column13 column" 
                                                    HeaderText="Digitalizados" UniqueName="column13" Display="False" 
                                                    Visible="False">
                                                     <HeaderStyle Font-Size="10pt" />
                                                    <ItemStyle Font-Size="8pt" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn FilterControlAltText="Filter column14 column" 
                                                    HeaderText="Verificados" UniqueName="column14" Display="False" 
                                                    Visible="False">
                                                     <HeaderStyle Font-Size="10pt" />
                                                    <ItemStyle Font-Size="8pt" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn FilterControlAltText="Filter column17 column" 
                                                    HeaderText="Entre.Gestor" UniqueName="column17" Display="False" 
                                                    Visible="False">
                                                     <HeaderStyle Font-Size="10pt" />
                                                    <ItemStyle Font-Size="8pt" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn FilterControlAltText="Filter column15 column" 
                                                    HeaderText="Entre.Cliente" UniqueName="column15" Display="False" 
                                                    Visible="False">
                                                     <HeaderStyle Font-Size="10pt" />
                                                    <ItemStyle Font-Size="8pt" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="'no'" 
                                                    FilterControlAltText="Filter column16 column" HeaderText="Pagado" 
                                                    UniqueName="column16" Visible="False" Display="False">
                                                     <HeaderStyle Font-Size="10pt" />
                                                    <ItemStyle Font-Size="8pt" />
                                                </telerik:GridBoundColumn>
                                            </Columns>
                                            <EditFormSettings>
                                                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                                </EditColumn>
                                            </EditFormSettings>
                                        </MasterTableView>
                                        <FooterStyle Font-Size="10pt" />
                                        <ItemStyle Font-Size="10pt" />
                                        <PagerStyle Font-Size="10pt" />
                                        <FilterMenu EnableImageSprites="False">
                                        </FilterMenu>
                                    </telerik:RadGrid>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                                <telerik:RadNotification ID="RadNotification2" runat="server" 
                                    AnimationDuration="2000" LoadContentOn="EveryShow" Position="Center" 
                                    Title="Atención!">
                                </telerik:RadNotification>
                            </td>
                        </tr>
                    </table>
                </telerik:RadAjaxPanel>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style56">

            </td>
        </tr>
        <tr>
            <td class="style56">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style56">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style56">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style56">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style56">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style56">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style56">
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
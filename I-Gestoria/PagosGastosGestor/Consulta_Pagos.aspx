<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGestionOperativa.master" AutoEventWireup="false" CodeFile="Consulta_Pagos.aspx.vb" Inherits="PagosGastosGestor_Consulta_Pagos" %>

<%@ Register src="../UserControls/Fechas.ascx" tagname="Fechas" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        function confirmCallBack_Guardar(arg) {
            // Hace un postback enviando el parámetro "Eliminar"
            if (arg) __doPostBack('Guardar', 'true');
        }

        function Regresar_a_Busqueda() {
            __doPostBack('Regresar_a_Busqueda', '');
        }
    </script>
    <style type="text/css">
        .RadComboBox {width: 160px !important}.RadComboBox_Default{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox{margin:0;padding:0;min-height:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;*zoom:1;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox {width: 160px !important}.RadComboBox_Default{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox{margin:0;padding:0;min-height:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;*zoom:1;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox{margin:0;padding:0;min-height:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;*zoom:1;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}
        .RadComboBox {width: 160px !important}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2012.3.1016.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2012.3.1016.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2012.3.1016.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2012.3.1016.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2012.3.1016.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2012.3.1016.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:none;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:none;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:none;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2012.3.1016.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2012.3.1016.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2012.3.1016.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2012.3.1016.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}
    .RadComboBox .rcbArrowCell{width:18px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2012.3.1016.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2012.3.1016.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>
    <table cellspacing="1" class="style7">
        <tr>
            <td colspan="5">
                <asp:Label ID="Label3" runat="server" Text="Consulta de Pagos" Font-Size="20pt"></asp:Label>
            </td>
        </tr>
       <tr>
                    <td style="width:100px">
                        &nbsp;</td>
                    <td style="width:100px;color:White">
										<asp:Label ID="Label32" runat="server" Text="Servicio:"></asp:Label>
                    
                    </td>
                    <td style="width:100px;color:White">
                    
										<asp:Label ID="Label33" runat="server" Text="Gestor:"></asp:Label>
                    

                    </td>
                    <td style="width:300px">
                        &nbsp;</td>
                    <td style="width:100px">
                    

                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width:100px">
     <telerik:RadComboBox ID="RadComboBox1" Runat="server">
        <Items>
        <telerik:RadComboBoxItem Selected="true" runat="server" Text="Pagos Registrados" Value="1" />
        <telerik:RadComboBoxItem runat="server" Text="Pagos Autorizados" Value="2" />
        <telerik:RadComboBoxItem runat="server" Text="Pagos Cancelados" Value="3" />
        </Items>
        </telerik:RadComboBox>
                    </td>
                    <td style="width:100px">
										<telerik:RadTextBox ID="txtServ" runat="server" 
															CssClass="TxtBox" MaxLength="100">
											<EmptyMessageStyle BackColor="#6666FF" ForeColor="Black" />
										</telerik:RadTextBox>
                    
                    </td>
                    <td style="width:100px">
                    
										<telerik:RadTextBox ID="txtGest" runat="server" 
															CssClass="TxtBox" MaxLength="100">
											<EmptyMessageStyle BackColor="#6666FF" ForeColor="Black" />
										</telerik:RadTextBox>
                    

                    </td>
                    <td style="width:100px">
                        <telerik:RadButton ID="BtnResultado" runat="server" Text="Buscar">
                        </telerik:RadButton>
                        &nbsp;&nbsp;&nbsp;
                        <telerik:RadButton ID="RadButton1" runat="server" Text="Exportar a Excel">
                        </telerik:RadButton>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width:100px">
                        &nbsp;</td>
                    <td colspan="3">
      <uc1:fechas ID="SelectorFechas" runat="server" />
                    </td>
                    <td style="width:100px">
        
                        &nbsp;</td>
                </tr>                
                 <tr>
                    <td colspan="5">
                        <telerik:RadGrid ID="rgRegistrados" runat="server" AutoGenerateColumns="False" 
                            CellSpacing="0" Culture="es-ES" GridLines="None"  Skin="Forest" 
                        HorizontalAlign="Center" Width="90%" Visible="false">
                                <MasterTableView>
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="Servicio" 
                                            FilterControlAltText="Filter column column" HeaderText="No.Gestion" 
                                            UniqueName="column">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Servicio_NomServicio" 
                                            FilterControlAltText="Filter column2 column" HeaderText="Tramite" 
                                            UniqueName="column2">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="COSTO" 
                                            FilterControlAltText="Filter column1 column" HeaderText="Monto" 
                                            UniqueName="column1">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="GESTOR" 
                                            FilterControlAltText="Filter column3 column" HeaderText="Gestor" 
                                            UniqueName="column3">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="FECHAREGISTRO" 
                                            FilterControlAltText="Filter column4 column" 
                                            HeaderText="Fecha de Requerimiento" UniqueName="column4" DataFormatString="{0:dd-MM-yyyy HH:mm}">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="USUARIO" 
                                            FilterControlAltText="Filter column6 column" HeaderText="Requisitó" 
                                            UniqueName="column6">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="TIPO_FORMA_DESCRIPCION" 
                                            FilterControlAltText="Filter column8 column" HeaderText="Tipo de Pago" 
                                            UniqueName="column8">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridTemplateColumn DataField="reciboPago" 
                                            FilterControlAltText="Filter TemplateColumn column" HeaderText="No. Recibo" 
                                            UniqueName="TemplateColumn">
                                            <ItemTemplate>
                                                <telerik:RadTextBox ID="RadTextBox1" Runat="server" Skin="Forest">
                                                </telerik:RadTextBox>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridButtonColumn CommandName="cmdGuardar" 
                                            FilterControlAltText="Filter column10 column" Text="Guardar" 
                                            UniqueName="column10">
                                        </telerik:GridButtonColumn>
                                        <telerik:GridButtonColumn CommandName="cmdCancela" 
                                            FilterControlAltText="Filter column9 column" Text="Cancelar" 
                                            UniqueName="column9">
                                        </telerik:GridButtonColumn>
                                    </Columns>
                                </MasterTableView>
                           </telerik:RadGrid>
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                       <telerik:RadGrid ID="rgAutorizados" runat="server" AutoGenerateColumns="False" CellSpacing="0" Culture="es-ES" GridLines="None" Skin="Forest" Width="90%"  Visible="false">
                    <MasterTableView>
                        <Columns>
                            <telerik:GridBoundColumn DataField="Servicio" 
                                FilterControlAltText="Filter column column" HeaderText="No.Gestion" 
                                UniqueName="column">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Servicio_NomServicio" 
                                FilterControlAltText="Filter column2 column" HeaderText="Tramite" 
                                UniqueName="column2">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="COSTO" 
                                FilterControlAltText="Filter column1 column" HeaderText="Monto" 
                                UniqueName="column1">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="GESTOR" 
                                FilterControlAltText="Filter column3 column" HeaderText="Gestor" 
                                UniqueName="column3">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="FECHAREGISTRO" 
                                FilterControlAltText="Filter column4 column" 
                                HeaderText="Fecha de Requerimiento" UniqueName="column4" DataFormatString="{0:dd-MM-yyyy HH:mm}">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="FECHA_AUTO" 
                                FilterControlAltText="Filter column5 column" HeaderText="Fecha de Autorizacion" 
                                UniqueName="column5" DataFormatString="{0:dd-MM-yyyy HH:mm}">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="USUARIO" 
                                FilterControlAltText="Filter column6 column" HeaderText="Requisitó" 
                                UniqueName="column6">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="USUARIOAUTO" 
                                FilterControlAltText="Filter column7 column" HeaderText="Autorizó" 
                                UniqueName="column7">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TIPO_FORMA_DESCRIPCION" 
                                FilterControlAltText="Filter column8 column" HeaderText="Tipo de Pago" 
                                UniqueName="column8">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="reciboPago" 
                                FilterControlAltText="Filter column9 column" HeaderText="No. Recibo" 
                                UniqueName="column9">
                            </telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                   <telerik:RadGrid ID="rgCancelados" runat="server" AutoGenerateColumns="False" CellSpacing="0" Culture="es-ES" GridLines="None" Skin="Forest" Width="90%"  Visible="false">
                <MasterTableView>
                    <Columns>
                        <telerik:GridBoundColumn DataField="Servicio" 
                            FilterControlAltText="Filter column column" HeaderText="No.Gestion" 
                            UniqueName="column">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Servicio_NomServicio" 
                            FilterControlAltText="Filter column2 column" HeaderText="Tramite" 
                            UniqueName="column2">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="COSTO" 
                            FilterControlAltText="Filter column1 column" HeaderText="Monto" 
                            UniqueName="column1">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="GESTOR" 
                            FilterControlAltText="Filter column3 column" HeaderText="Gestor" 
                            UniqueName="column3">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="FECHAREGISTRO" 
                            FilterControlAltText="Filter column4 column" 
                            HeaderText="Fecha de Requerimiento" UniqueName="column4" DataFormatString="{0:dd-MM-yyyy HH:mm}">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="FECHACANCELA" 
                            FilterControlAltText="Filter column5 column" HeaderText="Fecha de Cancelacion" 
                            UniqueName="column5" DataFormatString="{0:dd-MM-yyyy HH:mm}">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="USUARIO" 
                            FilterControlAltText="Filter column6 column" HeaderText="Requisitó" 
                            UniqueName="column6">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="USUACANCELA" 
                            FilterControlAltText="Filter column7 column" HeaderText="Canceló" 
                            UniqueName="column7">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="TIPO_FORMA_DESCRIPCION" 
                            FilterControlAltText="Filter column8 column" HeaderText="Tipo de Pago" 
                            UniqueName="column8">
                        </telerik:GridBoundColumn>
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>
                    </td>
                </tr>
                <tr>
                    <td style="width:100px">
                        <telerik:RadNotification ID="RadNotification1" runat="server">
                        </telerik:RadNotification>
                    </td>
                    <td>
                    </td>
                    <td></td>
                    <td>
                    </td>
                    <td></td>
                </tr>
    </table>
    </div>
</asp:Content>


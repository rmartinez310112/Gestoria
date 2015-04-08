<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGestionOperativa.master" AutoEventWireup="false" CodeFile="BuscarServiciosGestoria_cliente.aspx.vb" Inherits="BuscarServiciosGestoria_cliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../HojaEstilos/StyleSheet3H.css" rel="stylesheet" type="text/css" /> 

    <style type="text/css">


		.style21
		{
			width: 100%;
		}
	
.table_td
{
	width:11.8%;
	border: 1;
	/*padding: 3px 0;*/ 
}

.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}.RadInput .riTextBox{height:17px}.RadInput .riTextBox{height:17px}.rdfd_{position:absolute}.rdfd_{position:absolute}div.RadPicker table.rcSingle .rcInputCell{padding-right:0}div.RadPicker table.rcSingle .rcInputCell{padding-right:0}.RadButton_Default.rbSkinnedButton{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png');color:#333}.RadButton_Default{font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px}.rbSkinnedButton{padding-left:2px}.RadButton{cursor:pointer}.rbSkinnedButton{vertical-align:text-top}.rbSkinnedButton{vertical-align:top}.rbSkinnedButton{display:inline-block;position:relative;background-color:transparent;background-repeat:no-repeat;border:0 none;height:22px;text-align:center;text-decoration:none;white-space:nowrap;background-position:left -525px;padding-left:4px;vertical-align:top}.RadButton{font-size:12px;font-family:"Segoe UI",Arial,Helvetica,sans-serif}.RadButton{box-sizing:content-box;-moz-box-sizing:content-box}.RadButton_Default .rbDecorated{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png');color:#333}.RadButton_Default .rbDecorated{font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px}.rbDecorated{padding-left:8px;padding-right:12px}.rbDecorated{display:block;*display:inline;zoom:1;height:22px;padding-left:6px;*padding-left:8px;padding-right:10px;border:0;text-align:center;background-position:right -88px;overflow:visible;background-color:transparent;outline:0;cursor:pointer;-webkit-border-radius:0;*line-height:22px}.rbDecorated{font-size:12px;font-family:"Segoe UI",Arial,Helvetica,sans-serif}
		.style22
		{
			border-style: none;
			border-color: inherit;
			border-width: 1;
			width: 11.8%;
			height: 22px;
		}
		.style23
		{
			width: 100px;
			height: 22px;
		}
	</style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>
	
		<table cellspacing="1" style="width: 100%">
			<tr>
				<td>
					<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel" Runat="server" 
						Skin="Default">
					</telerik:RadAjaxLoadingPanel>
					<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" 
						DefaultLoadingPanelID="RadAjaxLoadingPanel">
						<AjaxSettings>
							<telerik:AjaxSetting AjaxControlID="RadAjaxPanel1">
								<UpdatedControls>
									<telerik:AjaxUpdatedControl ControlID="RadAjaxPanel1" />
								</UpdatedControls>
							</telerik:AjaxSetting>
						</AjaxSettings>
					</telerik:RadAjaxManager>
				</td>
			</tr>
			<tr>
				<td>
					<table class="style21">
						<tr>
							<td>
																	<asp:Label ID="Label4" runat="server" 
																		Text="Busqueda de Servicios" Font-Size="20pt"></asp:Label>
																</td>
						</tr>
						<tr>
							<td>
					<telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="100%" 
						LoadingPanelID="RadAjaxLoadingPanel" Width="100%">
						<table class="style21">
							<tr>
								<td>
									<fieldset style="background-color: #808080">
										<table border="0" style="text-align:center;width:90%">
											<tr>
												<td align="right" class="table_td">
													<asp:Label ID="Finicio" runat="server" Font-Size="Small" ForeColor="White" 
														Text="Fecha de Inicio:"></asp:Label>
												</td>
												<td align="left" class="table_td">
													<telerik:RadDatePicker ID="rdFI" runat="server">
													</telerik:RadDatePicker>
												</td>
												<td align="right" class="table_td">
													<asp:Label ID="Ffinal0" runat="server" Font-Size="Small" ForeColor="White" 
														Text="Fecha Final:"></asp:Label>
												</td>
												<td align="left" class="table_td">
													<telerik:RadDatePicker ID="rdFF" runat="server">
													</telerik:RadDatePicker>
												</td>
												<td align="right" class="table_td">
													&nbsp;</td>
												<td align="left" class="table_td">
													&nbsp;</td>
												<td align="right" class="table_td">
													&nbsp;</td>
												<td align="left" class="table_td">
													&nbsp;</td>
											</tr>
											<tr>
												<td align="right" class="table_td">
													<asp:Label ID="Label33" runat="server" Font-Size="Small" ForeColor="White" 
														Text="Cliente:"></asp:Label>
												</td>
												<td align="left" class="table_td">
													<telerik:RadComboBox ID="CboCliente" runat="server">
													</telerik:RadComboBox>
												</td>
												<td align="right" class="table_td">
													<asp:Label ID="idEstado0" runat="server" Font-Size="Small" ForeColor="White" 
														Text="Estado:"></asp:Label>
												</td>
												<td align="left" class="table_td">
													<telerik:RadComboBox ID="cboEstado" runat="server" Culture="es-ES">
													</telerik:RadComboBox>
												</td>
												<td align="right" class="table_td">
													<asp:Label ID="Label34" runat="server" Font-Size="Small" ForeColor="White" 
														Text="Tipo de Servicio:"></asp:Label>
												</td>
												<td align="left" class="table_td">
													<telerik:RadComboBox ID="cboServicioTipo" Runat="server">
													</telerik:RadComboBox>
												</td>
												<td align="right" class="table_td">
													&nbsp;</td>
												<td align="left" class="table_td">
													&nbsp;</td>
											</tr>
											<tr>
												<td align="right" class="table_td">
													&nbsp;</td>
												<td align="left" class="table_td">
													&nbsp;</td>
												<td align="right" class="table_td">
													&nbsp;</td>
												<td align="left" class="table_td">
													&nbsp;</td>
												<td align="right" class="table_td">
													&nbsp;</td>
												<td align="left" class="table_td">
													&nbsp;</td>
												<td align="right" class="table_td">
													&nbsp;</td>
												<td align="left" class="table_td">
													&nbsp;</td>
											</tr>
											<tr>
												<td align="right" class="table_td">
													<asp:Label ID="idpoliza" runat="server" Font-Size="Small" ForeColor="White" 
														Text="Póliza:"></asp:Label>
												</td>
												<td align="left" class="table_td">
													<telerik:RadTextBox ID="txtPoliza" runat="server">
													</telerik:RadTextBox>
												</td>
												<td align="right" class="table_td">
													&nbsp;</td>
												<td align="left" class="table_td">
													&nbsp;</td>
												<td align="right" class="table_td">
													&nbsp;</td>
												<td align="left" class="table_td">
													&nbsp;</td>
												<td align="right" class="table_td">
													&nbsp;</td>
												<td align="left" class="table_td">
													&nbsp;</td>
											</tr>
											<tr>
												<td align="right" class="table_td">
													<asp:Label ID="idpoliza4" runat="server" Font-Size="Small" ForeColor="White" 
														Text=" Contrato:"></asp:Label>
												</td>
												<td align="left" class="table_td">
													<telerik:RadTextBox ID="txtContrato" runat="server">
													</telerik:RadTextBox>
												</td>
												<td align="right" class="table_td">
													&nbsp;</td>
												<td align="left" class="table_td">
													&nbsp;</td>
												<td align="right" class="table_td">
													&nbsp;</td>
												<td align="left" class="table_td">
													&nbsp;</td>
												<td align="right" class="table_td">
													&nbsp;</td>
												<td align="left" class="table_td">
													&nbsp;</td>
											</tr>
											<tr>
												<td align="right" class="table_td">
													<asp:Label ID="idpoliza0" runat="server" Font-Size="Small" ForeColor="White" 
														Text="Nombre Reporta:"></asp:Label>
												</td>
												<td align="left" class="table_td">
													<telerik:RadTextBox ID="txtNomReporta" runat="server">
													</telerik:RadTextBox>
												</td>
												<td align="right" class="table_td">
													<asp:Label ID="idpoliza1" runat="server" Font-Size="Small" ForeColor="White" 
														Text="A. Paterno Reporta:"></asp:Label>
												</td>
												<td align="left" class="table_td">
													<telerik:RadTextBox ID="txtApePatReporta" runat="server">
													</telerik:RadTextBox>
												</td>
												<td align="left" class="table_td">
													&nbsp;</td>
												<td style="width:100px;">
													&nbsp;</td>
												<td align="right" class="table_td">
													&nbsp;</td>
												<td align="left" class="table_td">
													&nbsp;</td>
											</tr>
											<tr>
												<td align="right" class="style22">
													<asp:Label ID="idpoliza2" runat="server" Font-Size="Small" ForeColor="White" 
														Text="Nombre Asegurado:"></asp:Label>
												</td>
												<td align="left" class="style22">
													<telerik:RadTextBox ID="txtNomASeg" runat="server">
													</telerik:RadTextBox>
												</td>
												<td align="right" class="style22">
													<asp:Label ID="idpoliza3" runat="server" Font-Size="Small" ForeColor="White" 
														Text="Paterno Asegurado:"></asp:Label>
												</td>
												<td align="left" class="style22">
													<telerik:RadTextBox ID="txtApePatAseg" runat="server">
													</telerik:RadTextBox>
												</td>
												<td align="left" class="style22">
													<asp:Label ID="idpoliza6" runat="server" Font-Size="Small" ForeColor="White" 
														Text="No.Telefonico"></asp:Label>
												</td>
												<td class="style23">
													<telerik:RadTextBox ID="txtelAseg" runat="server" 
														ToolTip="No. telefonico del Aseg. sin lada">
													</telerik:RadTextBox>
												</td>
												<td align="right" class="style22">
												</td>
												<td align="left" class="style22">
												</td>
											</tr>
											<tr>
												<td align="right" class="style22">
													&nbsp;</td>
												<td align="left" class="style22">
													&nbsp;</td>
												<td align="right" class="style22">
													&nbsp;</td>
												<td align="left" class="style22">
													&nbsp;</td>
												<td align="left" class="style22">
													&nbsp;</td>
												<td class="style23">
													<telerik:RadButton ID="btnBuscar0" runat="server" Text="Buscar">
                                                    </telerik:RadButton>
                                                </td>
												<td align="right" class="style22">
													&nbsp;</td>
												<td align="left" class="style22">
													&nbsp;</td>
											</tr>
										</table>
									</fieldset></td>
							</tr>
							<tr>
								<td>
									<telerik:RadNotification ID="RadNotification2" runat="server">
									</telerik:RadNotification>
								</td>
							</tr>
							<tr>
								<td>
									<telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" 
                                        CellSpacing="0" Culture="es-ES" GridLines="None">
									    <MasterTableView>
                                            <Columns>
                                                <telerik:GridButtonColumn CommandName="cmdServicio" DataTextField="NoGestion" 
                                                    FilterControlAltText="Filter column column" HeaderText="Servicio" 
                                                    UniqueName="column">
                                                </telerik:GridButtonColumn>
                                                <telerik:GridBoundColumn DataField="NoGestion" 
                                                    FilterControlAltText="Filter column1 column" UniqueName="column1" 
                                                    Display="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="status" 
                                                    FilterControlAltText="Filter column12 column" HeaderText="Status" 
                                                    UniqueName="column12">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="estado" 
                                                    FilterControlAltText="Filter column2 column" HeaderText="Estado" 
                                                    UniqueName="column2">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="reporte_fecharepor" 
                                                    FilterControlAltText="Filter column3 column" HeaderText="Fecha Reporte" 
                                                    UniqueName="column3" DataFormatString="{0:dd-MM-yyyy HH:mm}">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="NombreReporta" 
                                                    FilterControlAltText="Filter column4 column" HeaderText="Nombre Reporto" 
                                                    UniqueName="column4">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="asegurado" 
                                                    FilterControlAltText="Filter column5 column" HeaderText="Asegurado" 
                                                    UniqueName="column5">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Reporte_TelAseg" 
                                                    FilterControlAltText="Filter column6 column" HeaderText="Tel.Asegurado" 
                                                    UniqueName="column6">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="cliente_NomCliente" 
                                                    FilterControlAltText="Filter column7 column" HeaderText="Cliente" 
                                                    UniqueName="column7">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Nom_Aseguradora" 
                                                    FilterControlAltText="Filter column8 column" HeaderText="Aseguradora" 
                                                    UniqueName="column8">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Reporte_poliza" 
                                                    FilterControlAltText="Filter column9 column" HeaderText="No.Poliza" 
                                                    UniqueName="column9">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Reporte_contrato" 
                                                    FilterControlAltText="Filter column10 column" HeaderText="Contrato" 
                                                    UniqueName="column10">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Servicio_NomServicio" 
                                                    FilterControlAltText="Filter column11 column" HeaderText="Tipo.Servicio" 
                                                    UniqueName="column11">
                                                </telerik:GridBoundColumn>
                                            </Columns>
                                        </MasterTableView>
									</telerik:RadGrid>
								</td>
							</tr>
						</table>
					</telerik:RadAjaxPanel>
							</td>
						</tr>
					</table>
				</td>
			</tr>
		</table>
	
	</div>
</asp:Content>

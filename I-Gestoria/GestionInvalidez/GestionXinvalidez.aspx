<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGestionOperativa.master" AutoEventWireup="false" CodeFile="GestionXinvalidez.aspx.vb" Inherits="GestionInvalidez_GestionXinvalidez" %>


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

		.Etiquetas {
		color: navy;
		font-family: Tahoma, Arial, sans-serif;
		font-size: 9pt;
		font-stretch: normal;
		font-style: normal;
		font-variant: normal;
		font-weight: normal;
		text-align: left;
		text-transform: none;
		white-space: normal;
		}

		.Etiquetas {
		color: navy;
		font-family: Tahoma, Arial, sans-serif;
		font-size: 9pt;
		font-stretch: normal;
		font-style: normal;
		font-variant: normal;
		font-weight: normal;
		text-align: left;
		text-transform: none;
		white-space: normal;
		}

		.style58
		{
		height: 16px;
		}
		.style60
		{
		width: 40px;
		height: 24px;
		}
		.button {
		border-top: 1px solid #96d1f8;
		background: #65a9d7;
		background: -webkit-gradient(linear, left top, left bottom, from(#3e779d), to(#65a9d7));
		background: -webkit-linear-gradient(top, #3e779d, #65a9d7);
		background: -moz-linear-gradient(top, #3e779d, #65a9d7);
		background: -ms-linear-gradient(top, #3e779d, #65a9d7);
		background: -o-linear-gradient(top, #3e779d, #65a9d7);
		padding: 8px 16px;
		-webkit-border-radius: 12px;
		-moz-border-radius: 12px;
		border-radius: 12px;
		-webkit-box-shadow: rgba(0,0,0,1) 0 1px 0;
		-moz-box-shadow: rgba(0,0,0,1) 0 1px 0;
		box-shadow: rgba(0,0,0,1) 0 1px 0;
		text-shadow: rgba(0,0,0,.4) 0 1px 0;
		color: white;
		font-size: 12px;
		font-family: Georgia, Serif;
		text-decoration: none;
		vertical-align: middle;
		}
		.button {
		border-top: 1px solid #96d1f8;
		background: #65a9d7;
		background: -webkit-gradient(linear, left top, left bottom, from(#3e779d), to(#65a9d7));
		background: -webkit-linear-gradient(top, #3e779d, #65a9d7);
		background: -moz-linear-gradient(top, #3e779d, #65a9d7);
		background: -ms-linear-gradient(top, #3e779d, #65a9d7);
		background: -o-linear-gradient(top, #3e779d, #65a9d7);
		padding: 8px 16px;
		-webkit-border-radius: 12px;
		-moz-border-radius: 12px;
		border-radius: 12px;
		-webkit-box-shadow: rgba(0,0,0,1) 0 1px 0;
		-moz-box-shadow: rgba(0,0,0,1) 0 1px 0;
		box-shadow: rgba(0,0,0,1) 0 1px 0;
		text-shadow: rgba(0,0,0,.4) 0 1px 0;
		color: white;
		font-size: 12px;
		font-family: Georgia, Serif;
		text-decoration: none;
		vertical-align: middle;
		}
		.style84
		{
		width: 76%;
		}
		.style85
		{
		width: 145px;
		height: 4px;
		}
		.style87
		{
		width: 576px;
		}
		.style88
		{
		width: 40px;
		}
	</style>
	<link href="../HojaEstilos/StyleSheet3H.css" rel="stylesheet" type="text/css" />
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



	<telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server"
						  LoadingPanelID="RadAjaxLoadingPanel1">

		<table cellspacing="1" class="style7">
			<tr>
				<td>
					&nbsp;
				</td>
			</tr>
			<tr>
				<td>
					<telerik:RadTabStrip ID="RadTabStrip1" runat="server" Skin="Black" MultiPageID="RadMultiPage1"
										 SelectedIndex="0" CssClass="tabStrip">
						<Tabs>
							<telerik:RadTab Text="Datos del Reporte" 
											PageViewID="RadPageView1"  Selected="True">
							</telerik:RadTab>
							<telerik:RadTab Text="Datos Contacto" PageViewID="RadPageView2">
							</telerik:RadTab>
                            <telerik:RadTab Text="Telefonos Extra" PageViewID="RadPageView3">
							</telerik:RadTab>
						</Tabs>
					</telerik:RadTabStrip>
				</td>
			</tr>
			<tr>
				<td>
					<telerik:RadMultiPage ID="RadMultiPage1" Runat="server" Height="100%" 
										  Width="100%" SelectedIndex="0">
						<telerik:RadPageView ID="RadPageView1" runat="server">
							<table cellspacing="1" class="style1">
								<tr>
									<td colspan="6">

									</td>
								</tr>
								<asp:Label ID="Label1" runat="server" CssClass="Titulos" 
										   Text="Gestión X Invalidez"></asp:Label>
								<tr>
									<td colspan="6">
										<asp:Label ID="Label2" runat="server" CssClass="letrasdetodo" Text="Cliente:"></asp:Label>
									</td>
								</tr>
								<tr>
									<td colspan="6">
										<telerik:RadTextBox ID="txtCliente" runat="server" AutoPostBack="True" 
															CssClass="TxtBox" EmptyMessage="Obligatorio" Enabled="False" Width="60%">
											<EmptyMessageStyle BackColor="#6666FF" ForeColor="Black" />
										</telerik:RadTextBox>
									</td>
								</tr>
								<tr>
									<td colspan="6">
										<asp:Label ID="Label3" runat="server" CssClass="letrasdetodo" 
												   Text="Tipo de Gestión:"></asp:Label>
									</td>
								</tr>
								<tr>
									<td colspan="6">
										<telerik:RadTextBox ID="txtTipoServicio" runat="server" AutoPostBack="True" 
															CssClass="TxtBox" EmptyMessage="Obligatorio" Enabled="False" Width="75%">
											<EmptyMessageStyle BackColor="#6666FF" ForeColor="Black" />
										</telerik:RadTextBox>
									</td>
								</tr>
								<tr>
									<td colspan="6">
										<asp:Label ID="Label4" runat="server" CssClass="letrasdetodo" 
												   Text="Datos de la persona de Reporto"></asp:Label>
									</td>
								</tr>
								<tr>
									<td colspan="6">
										<table>
											<tr>
												<td>
													<asp:Label ID="Label18" runat="server" CssClass="letrasdetodo" 
															   Text="Apellido Paterno"></asp:Label>
												</td>
												<td>
													<asp:Label ID="Label19" runat="server" CssClass="letrasdetodo" 
															   Text="Apellido Materno"></asp:Label>
												</td>
												<td>
													<asp:Label ID="Label20" runat="server" CssClass="letrasdetodo" Text="Nombre"></asp:Label>
												</td>
											</tr>
											<tr>
												<td>
													<telerik:RadTextBox ID="txtPaterno" runat="server" AutoPostBack="True" 
																		CssClass="TxtBox" EmptyMessage="Obligatorio" Enabled="False" Width="99%">
														<EmptyMessageStyle BackColor="#6666FF" ForeColor="Black" />
													</telerik:RadTextBox>
												</td>
												<td>
													<telerik:RadTextBox ID="txtMaterno" runat="server" AutoPostBack="True" 
																		CssClass="TxtBox" EmptyMessage="Obligatorio" Enabled="False" Width="99%">
														<EmptyMessageStyle BackColor="#6666FF" ForeColor="Black" />
													</telerik:RadTextBox>
												</td>
												<td>
													<telerik:RadTextBox ID="txtNombre" runat="server" AutoPostBack="True" 
																		CssClass="TxtBox" EmptyMessage="Obligatorio" Enabled="False" Width="99%">
														<EmptyMessageStyle BackColor="#6666FF" ForeColor="Black" />
													</telerik:RadTextBox>
												</td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td colspan="6">
										<asp:RadioButtonList ID="tblTipoLlamada" runat="server" CssClass="letrasdetodo" 
															 RepeatDirection="Horizontal">
											<asp:ListItem Selected="True" Value="1">Familiar</asp:ListItem>
											<asp:ListItem Value="2">Conocido</asp:ListItem>
											<asp:ListItem Value="3">Representante</asp:ListItem>
											<asp:ListItem Value="4">
												CC de la Aseguradora
											</asp:ListItem>
											<asp:ListItem Value="5">Asegurado</asp:ListItem>
											<asp:ListItem Value="6">Otros/GO</asp:ListItem>
										</asp:RadioButtonList>
									</td>
								</tr>
								<tr>
									<td colspan="6">
										<table>
							<tr>
                                <td style="width:200px">
                        <asp:Label ID="Label113" runat="server" Text="Activacion por:" CssClass="letrasdetodo"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label117" runat="server" Text="Leasing:" CssClass="letrasdetodo"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:RadioButtonList ID="tblTipoActivacion" runat="server" CssClass="letrasdetodo" 
                            RepeatDirection="Horizontal">
                            <asp:ListItem Selected="True" Value="1">Voz</asp:ListItem>
                            <asp:ListItem Value="2">FTP</asp:ListItem>
                            <asp:ListItem Value="3">Mail Interno(sup. de Red)</asp:ListItem>
                            
                        </asp:RadioButtonList>
                    </td>
                    <td>
                        <asp:RadioButtonList ID="rdoLeasing" runat="server" CssClass="letrasdetodo" 
                            RepeatDirection="Horizontal">
                            <asp:ListItem  Value="1">Si</asp:ListItem>
                            <asp:ListItem Selected="True" Value="2">No</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                            </tr>
                            </table>
                                        </td>
								</tr>
								<tr>
                                    <td colspan="6">
                                        <asp:Label ID="Label6" runat="server" CssClass="letrasdetodo" 
                                            Text="Telefono de la persona que reporto"></asp:Label>
                                    </td>
                                </tr>
								<tr>
									<td colspan="6">
										<table cellspacing="1">
											<tr>
												<td>
													<asp:Label ID="Label21" runat="server" CssClass="letrasdetodo" Text="Lada"></asp:Label>
												</td>
												<td class="style58">
													<asp:Label ID="Label22" runat="server" CssClass="letrasdetodo" Text="Telefono"></asp:Label>
												</td>
											</tr>
											<tr>
												<td style="width:40px">
													<telerik:RadTextBox ID="txtLadaCto" runat="server" 
																		EmptyMessage="Obligatorio" Width="40px" CssClass="TxtBox">
														<EmptyMessageStyle BackColor="#6666FF" ForeColor="Black" />
													</telerik:RadTextBox>
												</td>
												<td>
													<telerik:RadTextBox ID="txtTelCon" runat="server" CssClass="TxtBox" 
																		EmptyMessage="Obligatorio">
														<EmptyMessageStyle BackColor="#6666FF" ForeColor="Black" />
													</telerik:RadTextBox>
												</td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td colspan="6">
										<table cellspacing="1">
											<tr>
												<td class="style85">
													<asp:Label ID="Label25" runat="server" CssClass="letrasdetodo" Text="Poliza"></asp:Label>
												</td>
												<td style="width: 220px">
													<asp:Label ID="Label26" runat="server" CssClass="letrasdetodo" Text="Inciso"></asp:Label>
												</td>
												<td style="width: 220px">
													<asp:Label ID="Label38" runat="server" CssClass="letrasdetodo" Text="Contrato"></asp:Label>
												</td>
											</tr>
											<tr>
												<td class="style2">
													<telerik:RadTextBox ID="txtNoPoliza" runat="server" CssClass="TxtBox" 
																		EmptyMessage=" " Width="99%">
														<EmptyMessageStyle BackColor="#6666FF" ForeColor="Black" />
													</telerik:RadTextBox>
												</td>
												<td class="style2">
													<telerik:RadTextBox ID="txtInciso" runat="server" CssClass="TxtBox" 
																		EmptyMessage=" " Width="99%">
														<EmptyMessageStyle BackColor="#6666FF" ForeColor="Black" />
													</telerik:RadTextBox>
												</td>
												<td class="style2">
													<telerik:RadTextBox ID="txtContrato" runat="server" CssClass="TxtBox" Width="99%">
													</telerik:RadTextBox>
												</td>
											</tr>
											<tr>
												<td class="style85">
													<asp:Label ID="Label43" runat="server" CssClass="letrasdetodo" 
															   Text="Aseguradora:"></asp:Label>
												</td>
												<td colspan="2">
													<asp:RadioButtonList ID="rblAsegContr" runat="server" 
																		 RepeatDirection="Horizontal" CssClass="letrasdetodo">
														<asp:ListItem Selected="True" Value="1">AXA</asp:ListItem>
														<asp:ListItem Value="2">GNP</asp:ListItem>
														<asp:ListItem Value="3">ABA</asp:ListItem>
														<asp:ListItem Value="4">Mapfre</asp:ListItem>
														<asp:ListItem Value="5">Qualitas</asp:ListItem>
														<asp:ListItem Value="6">Chubb</asp:ListItem>
													</asp:RadioButtonList>
												</td>
											</tr>
											<tr>
												<td class="style85">
													<asp:Label ID="Label42" runat="server" CssClass="letrasdetodo" 
															   Text="Estatus de la póliza"></asp:Label>
												</td>
												<td style="width: 220px">

													<telerik:RadTextBox ID="txtStatus" runat="server" CssClass="TxtBox">
													</telerik:RadTextBox>

												</td>
												<td style="width: 220px">
													&nbsp;
												</td>
											</tr>
											<tr>
												<td class="style85">
													<asp:Label ID="Label44" runat="server" CssClass="letrasdetodo" 
															   Text="Inicio de Vigencia"></asp:Label>
												</td>
												<td style="width: 220px">
													<asp:Label ID="Label45" runat="server" CssClass="letrasdetodo" 
															   Text="Fin de Vigencia"></asp:Label>
												</td>
												<td style="width: 220px">
													&nbsp;
												</td>
											</tr>
											<tr>
												<td class="style85">
													<telerik:RadDatePicker ID="txtInicioVig" runat="server" 
																		   ShowPopupOnFocus="True">
													</telerik:RadDatePicker>
												</td>
												<td style="width: 220px">
													<telerik:RadDatePicker ID="txtFinVig" runat="server" 
																		   ShowPopupOnFocus="True">
													</telerik:RadDatePicker>
												</td>
												<td style="width: 220px">
													&nbsp;
												</td>
											</tr>
											<tr>
												<td class="style4" colspan="2">
													<asp:Label ID="Label46" runat="server" CssClass="letrasdetodo" 
															   Text="Si quien reporta es GO, es necesario el No. de Control:" 
															   Width="1510%"></asp:Label>
												</td>
												<td style="width: 220px">
													&nbsp;
												</td>
											</tr>
											<tr>
												<td class="style4" colspan="2">

													<telerik:RadTextBox ID="txtNoGo" runat="server" CssClass="TxtBox" Width="150px">
													</telerik:RadTextBox>

												</td>
												<td style="width: 220px">
													&nbsp;
												</td>
											</tr>
											<tr>
												<td class="style4" colspan="3">
													<asp:Label ID="Label47" runat="server" CssClass="letrasdetodo" 
															   Text="Por favor, proporcióneme datos del crédito / contrato del vehículo" 
															   Width="1443%"></asp:Label>
												</td>
											</tr>
											<tr>
												<td class="style4">
													<asp:Label ID="Label48" runat="server" CssClass="letrasdetodo" 
															   Text="Número de crédito" Width="463%"></asp:Label>
												</td>
												<td class="style4">
													<telerik:RadTextBox ID="txtnocredito" runat="server" CssClass="TxtBox" 
																		Width="160px">
													</telerik:RadTextBox>
												</td>
												<td class="style4">
													&nbsp;
												</td>
											</tr>
											<tr>
												<td class="style4">
													<asp:Label ID="Label49" runat="server" CssClass="letrasdetodo" 
															   Text="Inicio vigencia" Width="527%"></asp:Label>
												</td>
												<td class="style4">
													<telerik:RadDatePicker ID="txtFechaInicioCred" runat="server" 
																		   ShowPopupOnFocus="True">
													</telerik:RadDatePicker>
												</td>
												<td class="style4">
													&nbsp;
												</td>
											</tr>
											<tr>
												<td class="style4">
													<asp:Label ID="Label50" runat="server" CssClass="letrasdetodo" Text="Fin vigencia" 
															   Width="310%"></asp:Label>
												</td>
												<td class="style4">
													<telerik:RadDatePicker ID="txtFechaFinCred" runat="server" 
																		   ShowPopupOnFocus="True">
													</telerik:RadDatePicker>
												</td>
												<td class="style4">
													&nbsp;
												</td>
											</tr>
											<tr>
												<td class="style4">
													<asp:Label ID="Label51" runat="server" CssClass="letrasdetodo" 
															   Text="Aviso de Servicio" Width="423%"></asp:Label>
												</td>
												<td class="style4">
													<telerik:RadTextBox ID="txtAviso" runat="server" CssClass="TxtBox" 
																		Width="160px">
													</telerik:RadTextBox>
												</td>
												<td class="style4">
													&nbsp;
												</td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td colspan="6">
										<asp:Label ID="Label10" runat="server" CssClass="letrasdetodo" 
												   Text="Datos del Asegurado:"></asp:Label>
									</td>
								</tr>
								<tr>
									<td colspan="6">
										<table>
											<tr>
												<td>
													<asp:Label ID="Label27" runat="server" CssClass="letrasdetodo" 
															   Text="Apellido Paterno"></asp:Label>
												</td>
												<td>
													<asp:Label ID="Label28" runat="server" CssClass="letrasdetodo" 
															   Text="Apellido Materno"></asp:Label>
												</td>
												<td>
													<asp:Label ID="Label29" runat="server" CssClass="letrasdetodo" Text="Nombre"></asp:Label>
												</td>
											</tr>
											<tr>
												<td>
													<telerik:RadTextBox ID="txtApepatAseg" runat="server" CssClass="TxtBox" 
																		EmptyMessage="Obligatorio" Width="99%">
														<EmptyMessageStyle BackColor="#6666FF" ForeColor="Black" />
													</telerik:RadTextBox>
												</td>
												<td>
													<telerik:RadTextBox ID="txtApeMatAseg" runat="server" CssClass="TxtBox" 
																		EmptyMessage="Obligatorio" Width="99%">
														<EmptyMessageStyle BackColor="#6666FF" ForeColor="Black" />
													</telerik:RadTextBox>
												</td>
												<td>
													<telerik:RadTextBox ID="txtNomAseg" runat="server" CssClass="TxtBox" 
																		EmptyMessage="Obligatorio" Width="99%">
														<EmptyMessageStyle BackColor="#6666FF" ForeColor="Black" />
													</telerik:RadTextBox>
												</td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td class="style88">
										&nbsp;
									</td>
									<td colspan="2">
										<asp:CheckBox ID="chkMoral" runat="server" AutoPostBack="True" 
													  CssClass="letrasdetodo" Text="Persona Moral" />
									</td>
									<td colspan="2">
										<asp:Label ID="lblCia" runat="server" CssClass="letrasdetodo" 
												   Text="Nombre de la Cia." Visible="False"></asp:Label>
									</td>
									<td>
										&nbsp;
									</td>
								</tr>
								<tr>
									<td colspan="2">
										&nbsp;
									</td>
									<td>
										&nbsp;
									</td>
									<td>
										<telerik:RadTextBox ID="txtCia" runat="server" CssClass="TxtBox" 
															Visible="False" Width="95%">
										</telerik:RadTextBox>
									</td>
									<td colspan="2">
										&nbsp;
									</td>
								</tr>
								<tr>
									<td colspan="5">
										<asp:Label ID="Label41" runat="server" CssClass="letrasdetodo" 
												   Text="Proporcione un No. Telefonico del Asegurado:"></asp:Label>
									</td>
									<td>
										&nbsp;
									</td>
								</tr>
								<tr>
									<td>
										<asp:Label ID="Label39" runat="server" CssClass="letrasdetodo" Text="Lada"></asp:Label>
									</td>
									<td class="style87" colspan="4">
										<asp:Label ID="Label40" runat="server" CssClass="letrasdetodo" Text="Telefono"></asp:Label>
									</td>
									<td>
										&nbsp;
									</td>
								</tr>
								<tr>
									<td class="style60">
										<telerik:RadTextBox ID="txtLadaAseg" runat="server" AutoPostBack="True" 
															CssClass="TxtBox" EmptyMessage=" " Width="50px">
											<EmptyMessageStyle BackColor="#6666FF" ForeColor="Black" />
										</telerik:RadTextBox>
									</td>
									<td class="style87" colspan="4">
										<telerik:RadTextBox ID="txtTelAseg" runat="server" AutoPostBack="True" 
															CssClass="TxtBox" EmptyMessage=" " MaxLength="9">
											<EmptyMessageStyle BackColor="#6666FF" ForeColor="Black" />
										</telerik:RadTextBox>
									</td>
									<td>
										&nbsp;
									</td>
								</tr>
								<tr>
									<td class="style88">
										<asp:Label ID="Label52" runat="server" CssClass="letrasdetodo" Text="Celular"></asp:Label>
									</td>
									<td class="style87" colspan="4">
										&nbsp;
									</td>
									<td>
										&nbsp;
									</td>
								</tr>
								<tr>
									<td class="style88">
										<asp:Label ID="Label53" runat="server" CssClass="letrasdetodo" Text="Lada"></asp:Label>
									</td>
									<td class="style87" colspan="4">
										<asp:Label ID="Label54" runat="server" CssClass="letrasdetodo" Text="Telefono"></asp:Label>
									</td>
									<td>
										&nbsp;
									</td>
								</tr>
								<tr>
									<td class="style60">
										<telerik:RadTextBox ID="txtLadaMovil" runat="server" AutoPostBack="True" 
															CssClass="TxtBox"  Width="50px">
											<EmptyMessageStyle BackColor="#6666FF" ForeColor="Black" />
										</telerik:RadTextBox>
									</td>
									<td class="style87" colspan="4">
										<telerik:RadTextBox ID="txtTelMovil" runat="server" AutoPostBack="True" 
															CssClass="TxtBox" MaxLength="9">
											<EmptyMessageStyle BackColor="#6666FF" ForeColor="Black" />
										</telerik:RadTextBox>
									</td>
									<td>
										&nbsp;
									</td>
								</tr>
                                <tr>
                                <td>
                                    <asp:Label ID="Label118" runat="server" CssClass="letrasdetodo" Text="Lada"></asp:Label>
                                    </td>
                                <td>
                                    <asp:Label ID="Label119" runat="server" CssClass="letrasdetodo" Text="Telefono Extra"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                <td>
                                    <telerik:RadTextBox ID="txtLadaEx" Runat="server" Width="100%">
                                    </telerik:RadTextBox>
                                    </td>
                                <td>
                                    <telerik:RadTextBox ID="txtTelEx" Runat="server">
                                    </telerik:RadTextBox>
                                    </td>
                                </tr>
								<tr>
									<td colspan="6">
										<asp:Label ID="Label12" runat="server" CssClass="letrasdetodo" 
												   Text="Email del Asegurado."></asp:Label>
									</td>
								</tr>
								<tr>
									<td colspan="6">
										<table>
            <tr>
            <td colspan="2">
                <asp:Label ID="Label116" runat="server" Text="Proporciona Correo:" 
                    CssClass="letrasdetodo"></asp:Label>
                <asp:RadioButtonList ID="rdoNoCorreo" runat="server" CssClass="letrasdetodo" 
                    RepeatDirection="Horizontal" AutoPostBack="True">
                    <asp:ListItem Selected="True" Value="1">Si</asp:ListItem>
                    <asp:ListItem Value="2">No</asp:ListItem>
                </asp:RadioButtonList>
                </td>
            </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label9" runat="server" Text="E-mail:" CssClass="letrasdetodo"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label115" runat="server" Text="Motivo:" CssClass="letrasdetodo"></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td style="width:300px">
                     <telerik:RadTextBox ID="txtEmail" runat="server" CssClass="TxtBox" Width="95%">
                                    </telerik:RadTextBox>
                    </td>
                    <td style="width:200px">
                        <telerik:RadComboBox ID="cboMotivoNoCorreo" runat="server" AutoPostBack="True" 
                            Skin="Forest" Width="95%">
                        </telerik:RadComboBox>
                    </td>
                </tr>
            </table>
									</td>
								</tr>
								<tr>
									<td colspan="6">
										<asp:Label ID="Label16" runat="server" CssClass="letrasdetodo" 
												   Text="Estado y Municipio donde se realizara el proceso de Gestoria:"></asp:Label>
									</td>
								</tr>
								<tr>
									<td colspan="6">
										<table cellspacing="1">
											<tr>
												<td>
													<asp:Label ID="Label34" runat="server" CssClass="letrasdetodo" Text="Estado"></asp:Label>
												</td>
												<td>
													<asp:Label ID="Label35" runat="server" CssClass="letrasdetodo" Text="Municipio"></asp:Label>
												</td>
											</tr>
											<tr>
												<td style="width:200px">
													<telerik:RadComboBox ID="cboEstado" runat="server" AutoPostBack="True" 
																		 Enabled="False" Width="99%">
													</telerik:RadComboBox>
												</td>
												<td style="width:200px">
													<telerik:RadComboBox ID="cboMpio" runat="server" Width="99%">
													</telerik:RadComboBox>
												</td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td colspan="6">
										&nbsp;
									</td>
								</tr>
								<tr>
									<td colspan="6">
										<asp:Label ID="Label7" runat="server" CssClass="letrasdetodo" 
												   Text=" Fecha  de inicio de Invalidez:"></asp:Label>
									</td>
								</tr>
								<tr>
									<td colspan="6">
										<asp:Label ID="Label23" runat="server" CssClass="letrasdetodo" Text="Fecha"></asp:Label>
									</td>
								</tr>
								<tr>
									<td colspan="6">
										<telerik:RadDatePicker ID="txtFechaOcur" runat="server">
										</telerik:RadDatePicker>
									</td>
								</tr>
								<tr>
									<td colspan="6">
										<asp:Label ID="Label36" runat="server" CssClass="letrasdetodo" 
												   Text="La invalidez fue por:"></asp:Label>
									</td>
								</tr>
								<tr>
									<td colspan="6">
										<asp:RadioButtonList ID="rblTipoInvalidez" runat="server" CssClass="letrasdetodo" 
															 RepeatDirection="Horizontal">
											<asp:ListItem Selected="True" Value="1">Accidente</asp:ListItem>
											<asp:ListItem Value="2">
												Causas Naturales/Enfermedad
											</asp:ListItem>
										</asp:RadioButtonList>
									</td>
								</tr>
								<tr>
									<td colspan="6">
										<asp:Label ID="Label63" runat="server" CssClass="letrasdetodo" 
												   Text="Describa Brevemente la causa de la invalidez:"></asp:Label>
									</td>
								</tr>
								<tr>
									<td colspan="6">
										<telerik:RadTextBox ID="txtDescripInvalidez" runat="server" 
															TextMode="MultiLine" Width="100%" EmptyMessage=" " Height="105px">
											<EmptyMessageStyle BackColor="#6666FF" ForeColor="Black" />
										</telerik:RadTextBox>
									</td>
								</tr>
								<tr>
									<td colspan="6">
										<asp:Label ID="lblError0" runat="server" Font-Size="12pt" ForeColor="Red"></asp:Label>
									</td>
								</tr>
								<tr>
									<td colspan="6">
										<asp:Button ID="Button1" runat="server" CssClass="button" 
													Text="Guardar Datos" />
									</td>
								</tr>
							</table>
						</telerik:RadPageView>
						<telerik:RadPageView ID="RadPageView2" runat="server">
							<table cellspacing="1" class="style7">
								<tr>
									<td>
										<asp:Panel ID="Panel1" runat="server" Visible="False">
											<table cellspacing="1" class="style7">
												<tr>
													<td class="style83">
														<asp:Label ID="Label57" runat="server" CssClass="Titulos" 
																   Text="Datos de Contacto"></asp:Label>
													</td>
													<td class="style84">
														&nbsp;
													</td>
												</tr>
												<tr>
													<td class="style83">
														<asp:Label ID="Label58" runat="server" CssClass="letrasdetodo" Text="Nombre:"></asp:Label>
													</td>
													<td class="style84">
														<telerik:RadTextBox ID="txtNomCot" runat="server" CssClass="TxtBox">
														</telerik:RadTextBox>
													</td>
												</tr>
												<tr>
													<td class="style83">
														<asp:Label ID="Label59" runat="server" CssClass="letrasdetodo" 
																   Text="Apellido Paterno:"></asp:Label>
													</td>
													<td class="style84">
														<telerik:RadTextBox ID="txtPatCot" runat="server" CssClass="TxtBox">
														</telerik:RadTextBox>
													</td>
												</tr>
												<tr>
													<td class="style83">
														<asp:Label ID="Label60" runat="server" CssClass="letrasdetodo" 
																   Text="Apellido Materno:"></asp:Label>
													</td>
													<td class="style84">
														<telerik:RadTextBox ID="txtMatCot" runat="server" CssClass="TxtBox">
														</telerik:RadTextBox>
													</td>
												</tr>
												<tr>
													<td class="style83">
														<asp:Label ID="Label61" runat="server" CssClass="letrasdetodo" 
																   Text="Lada/Télefono:"></asp:Label>
													</td>
													<td class="style84">
														<telerik:RadTextBox ID="txtLadaCot" runat="server" CssClass="TxtBox" 
																			ToolTip="Clave Lada" Width="100px">
														</telerik:RadTextBox>
														<telerik:RadTextBox ID="txtTelCot" runat="server" CssClass="TxtBox" 
																			ToolTip="No. de Teléfono">
														</telerik:RadTextBox>
													</td>
												</tr>
												<tr>
													<td class="style83">
														<asp:Label ID="Label62" runat="server" CssClass="letrasdetodo" 
																   Text="Observaciones:"></asp:Label>
													</td>
													<td class="style84">
														<telerik:RadTextBox ID="txtObservaciones" runat="server" CssClass="TxtBox" 
																			Height="47px" TextMode="MultiLine" Width="85%">
														</telerik:RadTextBox>
													</td>
												</tr>
												<tr>
													<td class="style83">
														&nbsp;
													</td>
													<td class="style84">

														<asp:Button ID="cmdNewContac1" runat="server" CssClass="button" 
																	Text="Guardar Contacto" Visible="true" />

													</td>
												 
												</tr>
												<tr>
													<td>
														&nbsp;
													</td>
												</tr>
											</table>
										</asp:Panel>
									</td>
								</tr>
								<tr>
									<td>
										<telerik:RadGrid ID="RadGrid1" runat="server">
										</telerik:RadGrid>
									</td>
								</tr>
								<tr>
									<td>
										<asp:Button ID="cmdNewContac" runat="server" CssClass="button" 
											Text="Nuevo Contacto" />
									</td>
								</tr>
								<tr>
									<td>
										&nbsp;
									</td>
								</tr>
							</table>
						</telerik:RadPageView>
                        <telerik:RadPageView ID="RadPageView3" runat="server">
							<table cellspacing="1" class="style7">
								<tr>
									<td>
										<asp:Panel ID="Panel2" runat="server" Visible="False">
											<table cellspacing="1" class="style7">
												<tr>
													<td class="style83">
														<asp:Label ID="Label5" runat="server" CssClass="Titulos" 
																   Text="Telefonos Extra"></asp:Label>
													</td>
													<td class="style84">
														&nbsp;
													</td>
												</tr>
												<tr>
													<td class="style83">
														&nbsp;</td>
													<td class="style84">
														&nbsp;</td>
												</tr>
												<tr>
													<td class="style83">
														<asp:Label ID="Label13" runat="server" CssClass="letrasdetodo" 
																   Text="Lada/Télefono:"></asp:Label>
													</td>
													<td class="style84">
														<telerik:RadTextBox ID="txt_ladaextra" runat="server" CssClass="TxtBox" 
																			ToolTip="Clave Lada" Width="100px">
														</telerik:RadTextBox>
														<telerik:RadTextBox ID="txt_telextra" runat="server" CssClass="TxtBox" 
																			ToolTip="No. de Teléfono">
														</telerik:RadTextBox>
													</td>
												</tr>
												<tr>
													<td class="style83">
														<asp:Label ID="Label64" runat="server" CssClass="letrasdetodo" 
                                                            Text="Tipo:"></asp:Label>
                                                    </td>
													<td class="style84">
														<telerik:RadTextBox ID="txt_tipoTelExtra" runat="server" CssClass="TxtBox" 
                                                            ToolTip="No. de Teléfono">
                                                        </telerik:RadTextBox>
                                                    </td>
												</tr>
												<tr>
                                                    <td class="style83">
                                                        &nbsp;</td>
                                                    <td class="style84">
                                                        &nbsp;</td>
                                                </tr>
												<tr>
													<td class="style83">
														&nbsp;
													</td>
													<td class="style84">

														<asp:Button ID="Button2" runat="server" CssClass="button" 
                                                            Text="Guardar Telefono" Visible="true" />

													</td>
												 
												</tr>
												<tr>
													<td>
														&nbsp;
													</td>
												</tr>
											</table>
										</asp:Panel>
									</td>
								</tr>
								<tr>
									<td>
										<telerik:RadGrid ID="RadGrid2" runat="server" AutoGenerateColumns="False" 
                                            CellSpacing="0" Culture="es-ES" GridLines="None">
										    <MasterTableView>
                                                <Columns>
                                                    <telerik:GridBoundColumn DataField="Reporte_LadaExtra" 
                                                        FilterControlAltText="Filter column column" HeaderText="Lada" 
                                                        UniqueName="column">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="Reporte_TelExtra" 
                                                        FilterControlAltText="Filter column1 column" HeaderText="Telefono" 
                                                        UniqueName="column1">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="Reporte_TipoTelExtra" 
                                                        FilterControlAltText="Filter column2 column" HeaderText="Tipo" 
                                                        UniqueName="column2">
                                                    </telerik:GridBoundColumn>
                                                </Columns>
                                            </MasterTableView>
										</telerik:RadGrid>
									</td>
								</tr>
								<tr>
									<td>
										<asp:Button ID="Button3" runat="server" CssClass="button" 
											Text="Nuevo Telefono" />
									</td>
								</tr>
								<tr>
									<td>
										&nbsp;
									</td>
								</tr>
							</table>
						</telerik:RadPageView>
					</telerik:RadMultiPage>
				</td>
			</tr>
			<tr>
				<td>
					<table cellspacing="1" class="style7">
						<tr>
							<td>

								<telerik:RadNotification ID="RadNotification2" runat="server" 
														 AnimationDuration="2000" LoadContentOn="EveryShow" Position="Center" 
														 Title="Atención!">
								</telerik:RadNotification>

	
							</td>
						</tr>
					</table>
				</td>
			</tr>
		</table>
	</telerik:RadAjaxPanel>
</asp:Content>

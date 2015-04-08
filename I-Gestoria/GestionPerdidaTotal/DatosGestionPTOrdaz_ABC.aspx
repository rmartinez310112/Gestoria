<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGestionOperativa.master" AutoEventWireup="false" CodeFile="DatosGestionPTOrdaz_ABC.aspx.vb" Inherits="GestionPerdidaTotal_DatosGestionPTOrdaz_ABC" %>

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

		.style52
		{
		width: 40px;
		height: 28px;
		}
		.style53
		{
		height: 28px;
		}
		.style59
		{
		width: 100%;
		height: 43px;
		}
		.style57
		{
		width: 40px;
		height: 16px;
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
		.style61
		{
		height: 24px;
		}
		.style70
		{
		width: 100%;
		height: 37px;
		}
		.style71
		{
		height: 18px;
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
		width: 100px;
		height: 4px;
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
					<div class="exampleWrapper">
						<telerik:RadTabStrip ID="RadTabStrip1" runat="server" Skin="Black" MultiPageID="RadMultiPage1"
											 SelectedIndex="0" CssClass="tabStrip">
							<Tabs>
								<telerik:RadTab Text="Datos Aseguradora" 
												PageViewID="RadPageView1"  Selected="True">
								</telerik:RadTab>
								<telerik:RadTab Text="Datos Asegurado" PageViewID="RadPageView2">
								</telerik:RadTab>
								<telerik:RadTab Text="Datos Contacto" PageViewID="RadPageView3">
								</telerik:RadTab>
                                <telerik:RadTab Text="Telefonos Extras" PageViewID="RadPageView4" >
								</telerik:RadTab>
							</Tabs>
						</telerik:RadTabStrip>
						<telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0" 
											  CssClass="multiPage" Width="100%">
							<telerik:RadPageView ID="RadPageView1" runat="server">
								<table class="style7">
									<tr>
										<td colspan="3">
											<asp:Label ID="Label1" runat="server" CssClass="Titulos" 
													   Text="Gestión  Perdida Total X DM"></asp:Label>
										</td>
									</tr>
									<tr>
										<td colspan="3">
											&nbsp;
										</td>
									</tr>
									<tr>
										<td colspan="3">
											<asp:Label ID="Label2" runat="server" CssClass="letrasdetodo" Text="Cliente:"></asp:Label>
										</td>
									</tr>
									<tr>
										<td colspan="3">
											<telerik:RadTextBox ID="txtCliente" runat="server" AutoPostBack="True" 
																CssClass="TxtBox" EmptyMessage="Obligatorio" Enabled="False" Width="60%">
												<EmptyMessageStyle BackColor="#6666FF" ForeColor="Black" />
											</telerik:RadTextBox>
										</td>
									</tr>
									<tr>
										<td colspan="3">
											<asp:Label ID="Label3" runat="server" CssClass="letrasdetodo" 
													   Text="Tipo de Gestión:"></asp:Label>
										</td>
									</tr>
									<tr>
										<td colspan="3">
											<telerik:RadTextBox ID="txtTipoServicio" runat="server" AutoPostBack="True" 
																CssClass="TxtBox" EmptyMessage="Obligatorio" Enabled="False" Width="85%">
												<EmptyMessageStyle BackColor="#6666FF" ForeColor="Black" />
											</telerik:RadTextBox>
										</td>
									</tr>
									<tr>
										<td colspan="3">
											&nbsp;</td>
									</tr>
									<tr>
										<td colspan="3">
											<asp:Label ID="Label4" runat="server" CssClass="letrasdetodo" 
													   Text="Persona que Reporto:"></asp:Label>
										</td>
									</tr>
									<tr>
										<td colspan="3">
											<table cellpadding="0" cellspacing="0">
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
													<td class="style2">
														<telerik:RadTextBox ID="txtPaterno" runat="server" AutoPostBack="True" 
																			CssClass="TxtBox" EmptyMessage="Obligatorio" Enabled="False" Width="99%">
															<EmptyMessageStyle BackColor="#6666FF" ForeColor="Black" />
														</telerik:RadTextBox>
													</td>
													<td class="style2">
														<telerik:RadTextBox ID="txtMaterno" runat="server" AutoPostBack="True" 
																			CssClass="TxtBox" EmptyMessage="Obligatorio" Enabled="False" Width="99%">
															<EmptyMessageStyle BackColor="#6666FF" ForeColor="Black" />
														</telerik:RadTextBox>
													</td>
													<td class="style2">
														<telerik:RadTextBox ID="txtNombre" runat="server" AutoPostBack="True" Width="95%"
																			CssClass="TxtBox" EmptyMessage="Obligatorio" Enabled="False" >
															<EmptyMessageStyle BackColor="#6666FF" ForeColor="Black" />
														</telerik:RadTextBox>
													</td>
												</tr>
											</table>
										</td>
									</tr>
									<tr>
										<td colspan="3">
											<asp:RadioButtonList ID="tblTipoLlamada" runat="server" CssClass="letrasdetodo" 
																 RepeatDirection="Horizontal">
												<asp:ListItem Selected="True" Value="1">
													Call Center Cia. Seguros
												</asp:ListItem>
												<asp:ListItem Value="2">Financiera</asp:ListItem>
												<asp:ListItem Value="3">
													Agencia Automotriz
												</asp:ListItem>
												<asp:ListItem Value="4">Cliente/Asegurado</asp:ListItem>
												<asp:ListItem Value="5">Otro/GO</asp:ListItem>
											</asp:RadioButtonList>
										</td>
									</tr>
                                    <tr>
                                    <td>
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
										<td colspan="3">
											<table cellspacing="1" >
												<tr>
													<td>
														&nbsp;</td>
													<td class="style58">
														&nbsp;</td>
												</tr>
												<tr>
                                                    <td>
                                                        <asp:Label ID="Label21" runat="server" CssClass="letrasdetodo" Text="Lada"></asp:Label>
                                                    </td>
                                                    <td class="style58">
                                                        <asp:Label ID="Label22" runat="server" CssClass="letrasdetodo" Text="Telefono"></asp:Label>
                                                    </td>
                                                </tr>
												<tr>
													<td class="style60">
														<telerik:RadTextBox ID="txtLadaCto" runat="server" AutoPostBack="True" 
																			CssClass="TxtBox" EmptyMessage="Obligatorio" Width="50px">
															<EmptyMessageStyle BackColor="#6666FF" ForeColor="Black" />
														</telerik:RadTextBox>
													</td>
													<td class="style60">
														<telerik:RadTextBox ID="txtTelCon" runat="server" AutoPostBack="True" 
																			CssClass="TxtBox" EmptyMessage="Obligatorio">
															<EmptyMessageStyle BackColor="#6666FF" ForeColor="Black" />
														</telerik:RadTextBox>
													</td>
												</tr>
											</table>
										</td>
									</tr>
									<tr>
										<td colspan="3">
											<asp:Label ID="Label8" runat="server" CssClass="letrasdetodo" 
													   Text=" No. de poliza/certificado/Contrato"></asp:Label>
										</td>
									</tr>
									<tr>
										<td colspan="3">
											<table cellspacing="1" class="style61">
												<tr>
													<td class="style66">
														<asp:Label ID="Label25" runat="server" CssClass="letrasdetodo" Text="Poliza"></asp:Label>
													</td>
													<td class="style76">
														<asp:Label ID="Label26" runat="server" CssClass="letrasdetodo" Text="Inciso"></asp:Label>
													</td>
													<td>
														<asp:Label ID="Label45" runat="server" CssClass="letrasdetodo" Text="Contrato:"></asp:Label>
													</td>
												</tr>
												<tr>
													<td class="style2">
														<telerik:RadTextBox ID="txtNoPoliza" runat="server" 
																			EmptyMessage="Obligatorio" Width="99%" Enabled="false" 
															CssClass="TxtBox">
															<EmptyMessageStyle BackColor="#6666FF" ForeColor="Black" />
														</telerik:RadTextBox>
													</td>
													<td class="style2">
														<telerik:RadTextBox ID="txtInciso" runat="server"  Width="99%" Enabled="false" 
															CssClass="TxtBox">
														</telerik:RadTextBox>
													</td>
													<td class="style2">
														<telerik:RadTextBox ID="txtContrato" runat="server"  Enabled="false" 
															CssClass="TxtBox">
														</telerik:RadTextBox>
													</td>
												</tr>
												<tr>
													<td class="style67">
														<asp:Label ID="Label63" runat="server" CssClass="letrasdetodo" 
																   Text="Estatus de la póliza"></asp:Label>
													</td>
													<td class="style77">
														<telerik:RadTextBox ID="txtStatus" runat="server" CssClass="TxtBox">
														</telerik:RadTextBox>
													</td>
													<td class="style60">
														&nbsp;
													</td>
												</tr>
											</table>
										</td>
									</tr>
									<tr>
										<td colspan="3">
											<asp:RadioButtonList ID="rblAsegContr" runat="server" CssClass="letrasdetodo" 
																 RepeatDirection="Horizontal">
												<asp:ListItem Selected="True" Value="1">AXA</asp:ListItem>
												<asp:ListItem Value="2">GNP</asp:ListItem>
												<asp:ListItem Value="3">ABA</asp:ListItem>
												<asp:ListItem Value="4">Mapfre</asp:ListItem>
												<asp:ListItem Value="5">Qualitas</asp:ListItem>
											</asp:RadioButtonList>
										</td>
									</tr>
									<tr>
										<td>
											<asp:Label ID="Label64" runat="server" CssClass="letrasdetodo" 
													   Text="Inicio de Vigencia"></asp:Label>
										</td>
										<td>
											<asp:Label ID="Label65" runat="server" CssClass="letrasdetodo" 
													   Text="Fin de Vigencia"></asp:Label>
										</td>
										<td>
											&nbsp;
										</td>
									</tr>
									<tr>
										<td style="width:150px">
											<telerik:RadDatePicker ID="txtFechaOcur0" runat="server" 
																   ShowPopupOnFocus="True">
											</telerik:RadDatePicker>
										</td>
										<td>
											<telerik:RadDatePicker ID="txtFechaOcur1" runat="server" 
																   ShowPopupOnFocus="True">
											</telerik:RadDatePicker>
										</td>
										<td>
											&nbsp;
										</td>
									</tr>
									<tr>
										<td>
											<asp:Label ID="Label66" runat="server" CssClass="letrasdetodo" 
													   Text="Si quien reporta es GO, es necesario el No. de Control:"></asp:Label>
										</td>
										<td>
											&nbsp;
										</td>
										<td>
											&nbsp;
										</td>
									</tr>
									<tr>
										<td>
											<telerik:RadTextBox ID="txtNoGo" runat="server" CssClass="TxtBox" Width="150px">
											</telerik:RadTextBox>
										</td>
										<td>
											&nbsp;
										</td>
										<td>
											&nbsp;
										</td>
									</tr>
									<tr>
										<td>
											<asp:Label ID="Label67" runat="server" CssClass="letrasdetodo" 
													   Text="Datos del crédito / contrato del vehículo"></asp:Label>
										</td>
										<td>
											&nbsp;
										</td>
										<td>
											&nbsp;
										</td>
									</tr>
									<tr>
										<td>
											<asp:Label ID="Label68" runat="server" CssClass="letrasdetodo" 
													   Text="Número de crédito"></asp:Label>
										</td>
										<td>
											<telerik:RadTextBox ID="txtnocredito" runat="server" CssClass="TxtBox" 
																Width="160px">
											</telerik:RadTextBox>
										</td>
										<td>
											&nbsp;
										</td>
									</tr>
									<tr>
										<td>
											<asp:Label ID="Label69" runat="server" CssClass="letrasdetodo" 
													   Text="Inicio vigencia"></asp:Label>
										</td>
										<td>
											<telerik:RadDatePicker ID="txtFechaInicioCred" runat="server" 
																   ShowPopupOnFocus="True">
											</telerik:RadDatePicker>
										</td>
										<td>
											&nbsp;
										</td>
									</tr>
									<tr>
										<td>
											<asp:Label ID="Label50" runat="server" CssClass="letrasdetodo" 
													   Text="Fin vigencia"></asp:Label>
										</td>
										<td>
											<telerik:RadDatePicker ID="txtFechaFinCred" runat="server" 
																   ShowPopupOnFocus="True">
											</telerik:RadDatePicker>
										</td>
										<td>
											&nbsp;
										</td>
									</tr>
									<tr>
										<td>
											<asp:Label ID="Label51" runat="server" CssClass="letrasdetodo" 
													   Text="Aviso de Servicio"></asp:Label>
										</td>
										<td>
											<telerik:RadTextBox ID="txtAviso" runat="server" CssClass="TxtBox" 
																Width="160px" Enabled="False">
											</telerik:RadTextBox>
										</td>
										<td>
											&nbsp;
										</td>
									</tr>
									<tr>
										<td>
											&nbsp;
										</td>
										<td>
											&nbsp;
										</td>
										<td>
											&nbsp;
										</td>
									</tr>
									<tr>
										<td colspan="2">
											&nbsp;
											<asp:Label ID="lblError" runat="server" Font-Size="12pt" ForeColor="Red"></asp:Label>
											&nbsp;
										</td>
										<td>
											&nbsp;
										</td>
									</tr>
									<tr>
										<td colspan="3">
											<asp:Button ID="Button1" runat="server" CssClass="button" 
														Text="Guardar Datos" />
										</td>
									</tr>
								</table>
							</telerik:RadPageView>
							<telerik:RadPageView ID="RadPageView2" runat="server" CssClass="pageViewEducation">
								&nbsp;
								<table cellpadding="0" cellspacing="0" class="style1">
									<tr>
										<td>
											<asp:Label ID="Label10" runat="server" CssClass="letrasdetodo" 
													   Text="Nombre del Asegurado/Beneficiario:"></asp:Label>
										</td>
									</tr>
									<tr>
										<td>
											<table cellpadding="0" cellspacing="0">
												<tr>
													<td class="style2">
														<asp:Label ID="Label27" runat="server" CssClass="letrasdetodo" 
																   Text="Apellido Paterno"></asp:Label>
													</td>
													<td class="style2">
														<asp:Label ID="Label28" runat="server" CssClass="letrasdetodo" 
																   Text="Apellido Materno"></asp:Label>
													</td>
													<td>
														<asp:Label ID="Label29" runat="server" CssClass="letrasdetodo" Text="Nombre"></asp:Label>
													</td>
												</tr>
												<tr>
													<td class="style2">
														<telerik:RadTextBox ID="txtApepatAseg" runat="server" CssClass="TxtBox" 
																			EmptyMessage="Obligatorio" Width="99%">
															<EmptyMessageStyle BackColor="#6666FF" ForeColor="Black" />
														</telerik:RadTextBox>
													</td>
													<td class="style2">
														<telerik:RadTextBox ID="txtApeMatAseg" runat="server" CssClass="TxtBox" 
																			EmptyMessage="Obligatorio" Width="99%">
															<EmptyMessageStyle BackColor="#6666FF" ForeColor="Black" />
														</telerik:RadTextBox>
													</td>
													<td class="style2">
														<telerik:RadTextBox ID="txtNomAseg" runat="server" CssClass="TxtBox" 
																			EmptyMessage="Obligatorio">
															<EmptyMessageStyle BackColor="#6666FF" ForeColor="Black" />
														</telerik:RadTextBox>
													</td>
												</tr>
												<tr>
													<td class="style2">
														<asp:CheckBox ID="chkMoral" runat="server" AutoPostBack="True" 
																	  CssClass="letrasdetodo" Text="Persona Moral" Width="270%" />
													</td>
													<td class="style2">
														&nbsp;
													</td>
													<td>
														<asp:Label ID="lblCia0" runat="server" CssClass="letrasdetodo" 
																   Text="Nombre de la Cia." Visible="False"></asp:Label>
													</td>
												</tr>
												<tr>
													<td class="style2" colspan="2">
														&nbsp;
													</td>
													<td>
														<telerik:RadTextBox ID="txtCia" runat="server" CssClass="TxtBox" 
																			Visible="False" Width="95%">
														</telerik:RadTextBox>
													</td>
												</tr>
											</table>
										</td>
									</tr>
									<tr>
										<td>
											<asp:Label ID="Label11" runat="server" CssClass="letrasdetodo" 
													   Text="No. Telefonico Asegurado/Beneficiario:"></asp:Label>
										</td>
									</tr>
									<tr>
										<td>
											<table cellspacing="1">
												<tr>
													<td class="style57">
														<asp:Label ID="Label30" runat="server" CssClass="letrasdetodo" Text="Lada"></asp:Label>
													</td>
													<td class="style62">
														<asp:Label ID="Label31" runat="server" CssClass="letrasdetodo" Text="Telefono"></asp:Label>
													</td>
													<td class="style58">
														&nbsp;
													</td>
												</tr>
												<tr>
													<td class="style60">
														<telerik:RadTextBox ID="txtLadaAseg" runat="server" CssClass="TxtBox" 
																			EmptyMessage="Obligatorio" Width="50px">
															<EmptyMessageStyle BackColor="#6666FF" ForeColor="Black" />
														</telerik:RadTextBox>
													</td>
													<td class="style77">
														<telerik:RadTextBox ID="txtTelAseg" runat="server" CssClass="TxtBox" 
																			EmptyMessage="Obligatorio">
															<EmptyMessageStyle BackColor="#6666FF" ForeColor="Black" />
														</telerik:RadTextBox>
													</td>
													<td class="style60">
														&nbsp;
													</td>
												</tr>
												<tr>
													<td class="style59">
														<asp:Label ID="Label52" runat="server" CssClass="letrasdetodo" Text="Celular"></asp:Label>
													</td>
													<td class="style77">
														&nbsp;
													</td>
													<td class="style60">
														&nbsp;
													</td>
												</tr>
												<tr>
													<td class="style59">
														<asp:Label ID="Label70" runat="server" CssClass="letrasdetodo" Text="Lada"></asp:Label>
													</td>
													<td class="style77">
														<asp:Label ID="Label72" runat="server" CssClass="letrasdetodo" Text="Telefono"></asp:Label>
													</td>
													<td class="style60">
														&nbsp;
													</td>
												</tr>
												<tr>
													<td class="style60">
														<telerik:RadTextBox ID="txtLadaCto1" runat="server" AutoPostBack="True" 
																			CssClass="TxtBox" Width="50px">
															<EmptyMessageStyle BackColor="#6666FF" ForeColor="Black" />
														</telerik:RadTextBox>
													</td>
													<td class="style77">
														<telerik:RadNumericTextBox ID="txtTelMovil" Runat="server" MaxLength="9" 
															CssClass="TxtBox">
															<NumberFormat DecimalDigits="0" GroupSeparator="" ZeroPattern="n" />
														</telerik:RadNumericTextBox>
													</td>
													<td class="style60">
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
                                                    <telerik:RadTextBox ID="txtLadaEx" runat="server" AutoPostBack="True" 
                                                        CssClass="TxtBox" Width="50px">
                                                        <EmptyMessageStyle BackColor="#6666FF" ForeColor="Black" />
                                                    </telerik:RadTextBox>
                                                    </td>
                                                <td>
                                                    <telerik:RadNumericTextBox ID="txtTelEx" Runat="server" CssClass="TxtBox" 
                                                        MaxLength="9">
                                                        <NumberFormat DecimalDigits="0" GroupSeparator="" ZeroPattern="n" />
                                                    </telerik:RadNumericTextBox>
                                                    </td>
                                                </tr>
											</table>
										</td>
									</tr>
									<tr>
										<td>
											<asp:Label ID="Label12" runat="server" CssClass="letrasdetodo" 
													   Text=" Email Asegurado/Beneficiario:"></asp:Label>
										</td>
									</tr>
									<tr>
										<td>
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
                        <asp:Label ID="Label5" runat="server" Text="E-mail:" CssClass="letrasdetodo"></asp:Label>
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
										<td>
											<asp:Label ID="Label13" runat="server" CssClass="letrasdetodo" 
													   Text=" No. de siniestro/Reporte de la Cia. Aseguradora"></asp:Label>
										</td>
									</tr>
									<tr>
										<td>
											<table cellspacing="1">
												<tr>
													<td class="style78">
														<asp:Label ID="Label46" runat="server" CssClass="letrasdetodo" 
																   Text="No. Siniestro"></asp:Label>
													</td>
													<td class="style58">
														<asp:Label ID="Label47" runat="server" CssClass="letrasdetodo" 
																   Text="No.Reporte"></asp:Label>
													</td>
												</tr>
												<tr>
													<td class="style60">
														<telerik:RadTextBox ID="txtNoSiniestro" runat="server" CssClass="TxtBox" 
																			EmptyMessage="Obligatorio" Width="99%">
															<EmptyMessageStyle BackColor="#6666FF" ForeColor="Black" />
														</telerik:RadTextBox>
													</td>
													<td class="style60">
														<telerik:RadTextBox ID="txtNoReporte" runat="server" CssClass="TxtBox" 
																			Width="99%">
															<EmptyMessageStyle BackColor="#6666FF" ForeColor="Black" />
														</telerik:RadTextBox>
													</td>
												</tr>
											</table>
										</td>
									</tr>
									<tr>
										<td>
											<asp:Label ID="Label7" runat="server" CssClass="letrasdetodo" 
													   Text="Me podria indicar la fecha y hora en que ocurrio el siniestro:"></asp:Label>
										</td>
									</tr>
									<tr>
										<td>
											<table cellspacing="1">
												<tr>
													<td>
														<asp:Label ID="Label48" runat="server" CssClass="letrasdetodo" 
																   Text="Fecha"></asp:Label>
													</td>
													<td>
														<asp:Label ID="Label49" runat="server" CssClass="letrasdetodo" Text="Hora"></asp:Label>
													</td>
												</tr>
												<tr>
													<td style="width:150px">
														<telerik:RadDatePicker ID="txtFechaOcur" runat="server">
														</telerik:RadDatePicker>
													</td>
													<td style="width:150px">
														<telerik:RadTimePicker  ID="txtHoraOcurr" runat="server">
														</telerik:RadTimePicker>
													</td>
												</tr>
											</table>
										</td>
									</tr>
									<tr>
										<td>
											<asp:Label ID="Label16" runat="server" CssClass="letrasdetodo" 
													   Text="Estado y Municipio donde se realizara el proceso de Gestoria:"></asp:Label>
										</td>
									</tr>
									<tr>
										<td>
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
										<td>
											<asp:Label ID="Label17" runat="server" CssClass="letrasdetodo" 
													   Text="Me puede proporcionar los datos del Vehiculo:"></asp:Label>
										</td>
									</tr>
									<tr>
										<td>
											<table cellspacing="1">
												<tr>
													<td>
														<asp:Label ID="Label36" runat="server" CssClass="letrasdetodo" Text="Marca"></asp:Label>
													</td>
													<td>
														<asp:Label ID="Label37" runat="server" CssClass="letrasdetodo" Text="SubMarca"></asp:Label>
													</td>
												</tr>
												<tr>
													<td style="width:200px">
														<telerik:RadComboBox ID="cboMarca" runat="server" AutoPostBack="True" 
																			 Width="99%">
														</telerik:RadComboBox>
													</td>
													<td style="width:200px">
														<telerik:RadComboBox ID="cboSubmarca" runat="server" Width="99%">
														</telerik:RadComboBox>
													</td>
												</tr>
												<tr>
													<td class="style73">
														<asp:Label ID="Label38" runat="server" CssClass="letrasdetodo" Text="Modelo:"></asp:Label>
													</td>
													<td>
														<asp:Label ID="Label39" runat="server" CssClass="letrasdetodo" Text="Color:"></asp:Label>
													</td>
												</tr>
												<tr>
													<td class="style73">
														<telerik:RadTextBox ID="txtModelo" runat="server" CssClass="TxtBox">
															
														</telerik:RadTextBox>
													</td>
													<td>
														<telerik:RadTextBox ID="txtColor" runat="server" CssClass="TxtBox">
														</telerik:RadTextBox>
													</td>
												</tr>
												<tr>
													<td class="style73">
														<asp:Label ID="Label40" runat="server" CssClass="letrasdetodo" Text="Placas:"></asp:Label>
													</td>
													<td>
														<asp:Label ID="Label41" runat="server" CssClass="letrasdetodo" Text="Serie:"></asp:Label>
													</td>
												</tr>
												<tr>
													<td class="style73">
														<telerik:RadTextBox ID="txtPlacas" runat="server" CssClass="TxtBox">
														</telerik:RadTextBox>
													</td>
													<td>
														<telerik:RadTextBox ID="txtSerie" runat="server" CssClass="TxtBox">
														</telerik:RadTextBox>
													</td>
												</tr>
												<tr>
													<td class="style73">
														<asp:Label ID="Label73" runat="server" CssClass="letrasdetodo" 
																   Text="Tipo de uso del Vehiculo"></asp:Label>
													</td>
													<td>
														&nbsp;
													</td>
												</tr>
												<tr>
													<td class="style73">
														<asp:RadioButtonList ID="rblTipVehi" runat="server" CssClass="letrasdetodo" 
																			 RepeatDirection="Horizontal">
															<asp:ListItem Selected="True" Value="1">Particular</asp:ListItem>
															<asp:ListItem Value="2">Público</asp:ListItem>
														</asp:RadioButtonList>
													</td>
													<td>
														&nbsp;
													</td>
												</tr>
											</table>
										</td>
									</tr>
									<tr>
										<td>
											<asp:Label ID="lblError0" runat="server" Font-Size="12pt" ForeColor="Red"></asp:Label>
										</td>
									</tr>
									<tr>
										<td style="vertical-align: top">
											<asp:Button ID="Button2" runat="server" CssClass="button" 
														Text="Guardar Datos" />
										</td>
									</tr>
								</table>
							</telerik:RadPageView>
							<telerik:RadPageView ID="RadPageView3" runat="server" >
								<table cellpadding="0" cellspacing="0" class="style1">
									<tr>
										<td style="vertical-align: top">
											<table cellspacing="1" class="style7">
												<tr>
													<td class="style83" colspan="2">
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
																		<telerik:RadTextBox ID="txtObservaciones" runat="server" 
																							Height="47px" TextMode="MultiLine" Width="85%">
																		</telerik:RadTextBox>
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
													<td class="style83">
														&nbsp;
													</td>
													<td class="style84">
														<asp:Button ID="cmdNewContac0" runat="server" CssClass="button" 
																	Text="Guardar Contacto" Visible="False" />
													</td>
												</tr>
												<tr>
													<td class="style83">
														&nbsp;
													</td>
													<td class="style84">
														&nbsp;
													</td>
												</tr>
												<tr>
													<td class="style80" colspan="2">
														<telerik:RadGrid ID="RadGrid1" runat="server">
														</telerik:RadGrid>
													</td>
												</tr>
												<tr>
													<td class="style80" colspan="2" style="text-align: center">
														<asp:Button ID="cmdNewContac" runat="server" CssClass="button" 
																	Text="Nuevo Contacto" />
													</td>
												</tr>
											</table>
										</td>
									</tr>
								</table>
							</telerik:RadPageView>
                            <telerik:RadPageView ID="RadPageView4" runat="server">
							<table cellspacing="1" class="style7">
								<tr>
									<td>
										<asp:Panel ID="Panel2" runat="server" Visible="False">
											<table cellspacing="1" class="style7">
												<tr>
													<td class="style83">
														<asp:Label ID="Label9" runat="server" CssClass="Titulos" 
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
														<asp:Label ID="Label15" runat="server" CssClass="letrasdetodo" 
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
														<asp:Label ID="Label32" runat="server" CssClass="letrasdetodo" 
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

														<asp:Button ID="Button3" runat="server" CssClass="button" 
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
										<asp:Button ID="Button4" runat="server" CssClass="button" 
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
					</div>
				</td>
			</tr>
			<tr>
				<td>
					<telerik:RadNotification ID="RadNotification2" runat="server" 
											 LoadContentOn="EveryShow" Position="Center">
					</telerik:RadNotification>
				
				</td>
			</tr>
		</table>
	</telerik:RadAjaxPanel>
</asp:Content>


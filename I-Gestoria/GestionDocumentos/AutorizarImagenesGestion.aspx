<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AutorizarImagenesGestion.aspx.vb" Inherits="GestionDocumentos_AutorizarImagenesGestion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title></title>
		<style type="text/css">

			.style1
			{
			width: 100%;
			}
		</style>
		<link href="../HojaEstilos/StyleSheet3H.css" rel="stylesheet" type="text/css" />
	</head>
	<body>
		<form id="form1" runat="server" class="style1">
			<div>
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

					<table cellspacing="1" class="style1">
						<tr>
							<td>
								<asp:TextBox ID="txtDesc" runat="server" Height="80px" TextMode="MultiLine" 
											 Width="80%"></asp:TextBox>
								<telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
								</telerik:RadScriptManager>
								<telerik:RadWindowManager ID="RadWindowManager1" runat="server">
								</telerik:RadWindowManager>
							</td>
						</tr>
						<tr>
							<td>
								<asp:RadioButtonList ID="tblAceptada" runat="server" AutoPostBack="True" 
													 RepeatDirection="Horizontal" CssClass="letrasdehojasblancas">
									<asp:ListItem Selected="True" Value="1">
										Documentos Verificados y Aceptados
									</asp:ListItem>
									<asp:ListItem Value="2">
										Documentos Rechazados
									</asp:ListItem>
								</asp:RadioButtonList>
							</td>
						</tr>
						<tr>
							<td>
								<asp:Label ID="Label1" runat="server" Text="Causa de Rechazo:" Visible="False" 
										   CssClass="letrasdehojasblancas"></asp:Label>
								<telerik:RadComboBox ID="cboCancela" Runat="server" Visible="False" Width="70%">
								</telerik:RadComboBox>
							</td>
						</tr>
						<tr>
							<td>
								&nbsp;
							</td>
						</tr>
						<tr>
							<td>
								<asp:Button ID="button1" Text="Aceptar" runat="server" CssClass="button" />
								
								&nbsp;
								<asp:Label ID="lblError" runat="server" ForeColor="#CC0000"></asp:Label>
							</td>
						</tr>
						<tr>
							<td>

								<telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" 
												 CellSpacing="0" Culture="es-ES" GridLines="None" Width="80%" 
									Skin="Hay">
									<FilterMenu EnableImageSprites="False">
									</FilterMenu>
									<HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" 
													   EnableImageSprites="True">
									</HeaderContextMenu>
									<ClientSettings>
										<Selecting CellSelectionMode="None" />
									</ClientSettings>
									<MasterTableView>
										<CommandItemSettings ExportToPdfText="Export to Pdf" />
										<RowIndicatorColumn>
											<HeaderStyle Width="20px" />
										</RowIndicatorColumn>
										<ExpandCollapseColumn>
											<HeaderStyle Width="20px" />
										</ExpandCollapseColumn>
										<Columns>
											<telerik:GridBoundColumn DataField="img_pk" UniqueName="column" Visible="False">
											</telerik:GridBoundColumn>
											<telerik:GridTemplateColumn UniqueName="TemplateColumn" HeaderText="Imagen">
												<ItemTemplate>
													<asp:Image ID="Image1" runat="server" Height="200px" Width="200px" />
												</ItemTemplate>
											</telerik:GridTemplateColumn>
											<telerik:GridBoundColumn DataField=" img_name" 
																	 FilterControlAltText="Filter column3 column" UniqueName="column3" HeaderText="Observaciones">
											</telerik:GridBoundColumn>
											<telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn1 column" 
																		UniqueName="TemplateColumn1">
												<ItemTemplate>
													<asp:HyperLink ID="linkImagen" runat="server">[linkImagen]</asp:HyperLink>
												</ItemTemplate>
											</telerik:GridTemplateColumn>
										</Columns>
										<EditFormSettings>
											<EditColumn FilterControlAltText="Filter EditCommandColumn column">
											</EditColumn>
										</EditFormSettings>
									</MasterTableView>
								</telerik:RadGrid>

							</td>
						</tr>
					</table>
	
				</telerik:RadAjaxPanel>
			</div>
		</form>
	</body>
</html>

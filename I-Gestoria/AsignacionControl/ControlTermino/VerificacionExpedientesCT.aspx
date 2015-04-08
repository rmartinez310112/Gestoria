<%@ Page Language="VB" MasterPageFile="~/AsignacionControl/MasterControlTermino.master" AutoEventWireup="false" CodeFile="VerificacionExpedientesCT.aspx.vb" Inherits="BackOffice_VerificacionExpedientesBO" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
		.style1
		{
			width: 100%;
		}
	

.Titulos {
	color: White;
	font-family: Tahoma, Arial, sans-serif;
	font-size: 14pt;
	font-stretch: normal;
	font-style: normal;
	font-weight: bold;
	text-align: left;
	text-transform: capitalize;
}

	  .letrasdetodo
{
	font-family:Helvetica;
	font-size:12px;
	font-weight:lighter;
	color:White;
	}
	
	 .rdfd_{position:absolute}.rdfd_{position:absolute}div.RadPicker table.rcSingle .rcInputCell{padding-right:0}div.RadPicker table.rcSingle .rcInputCell{padding-right:0}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}.RadInput .riTextBox{height:17px}.RadInput .riTextBox{height:17px}
.button {
   border:1px solid #8bcf54; -webkit-border-radius: 3px; -moz-border-radius: 3px;border-radius: 3px;font-size:12px;font-family:arial, helvetica, sans-serif; padding: 10px 10px 10px 10px; text-decoration:none; display:inline-block;text-shadow: -1px -1px 0 rgba(0,0,0,0.3);font-weight:bold; color: #FFFFFF;
 background-color: #a9db80; background-image: linear-gradient(to bottom, #a9db80, #96c56f);
 }
	</style>

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

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table cellspacing="1" class="style1">
			<tr>
				<td>
								<asp:Label ID="Label2" runat="server" CssClass="Titulos" 
										   Text="Verificacion de Documentos" ForeColor="Black"></asp:Label>
							</td>
			</tr>
			<tr>
				<td>
					&nbsp;</td>
			</tr>
			<tr>
				<td>
								<table>
									<tr>
										<td style="width:250px;text-align:right;">
										<asp:Label ID="Label7" runat="server" CssClass="letrasdetodo" 
										   Text="Fecha de verificación de  documentos:" ForeColor="Black"></asp:Label>
										       <asp:SqlDataSource ID="SqlDS" runat="server" 
                                                ConnectionString="<%$ ConnectionStrings:ConnStringSQL %>" 
                                                SelectCommand="SELECT * FROM [Cat_RechazoPendienteTermino]">
                                            </asp:SqlDataSource>
										</td>
										<td style="width:200px;">
										<telerik:RadDatePicker ID="fechaSol" Runat="server" Culture="es-MX" 
                                                HiddenInputTitleAttibute="Visually hidden input created for functionality purposes." 
                                                WrapperTableSummary="Table holding date picker control for selection of dates.">
									<Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" 
											  ViewSelectorText="x" >
									</Calendar>
									<DatePopupButton HoverImageUrl="" ImageUrl="" />
									<DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy">
									</DateInput>
								</telerik:RadDatePicker>
										</td>
										<td>
								
								<asp:Button ID="button" runat="server" CssClass="button" 
									Text="Guardar Fecha de Aceptacion" Width="199px" />
								
										</td>
									</tr>
								</table>
							</td>
			</tr>
			<tr>
				<td>
								<asp:Label ID="lblError" runat="server" CssClass="Errores" 
						ForeColor="Red"></asp:Label>
							    <br />
								<asp:Label ID="lblAviso" runat="server" CssClass="Errores" 
						ForeColor="Red"></asp:Label>
							</td>
			</tr>
			<tr>
				<td>
									<telerik:RadGrid ID="RadGrid2" runat="server" 
						AutoGenerateColumns="False" Culture="es-ES" Width="1104px" >
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
												<telerik:GridBoundColumn DataField="Tramite_clvTramite" 
													FilterControlAltText="Filter column column" UniqueName="column" 
													Display="False">
												</telerik:GridBoundColumn>
												<telerik:GridBoundColumn DataField="Tramite_cvlSubTramite" 
													FilterControlAltText="Filter column1 column" UniqueName="column1" 
													Display="False">
												</telerik:GridBoundColumn>
												<telerik:GridBoundColumn DataField="consec" 
													FilterControlAltText="Filter column4 column" UniqueName="column4" 
													Display="False">
												</telerik:GridBoundColumn>
												<telerik:GridBoundColumn DataField=" TramitesGestion_Descrip" 
													FilterControlAltText="Filter column5 column" HeaderText="Tramite" 
													UniqueName="column5" Display="False">
												</telerik:GridBoundColumn>
												<telerik:GridBoundColumn DataField=" documentos_descrip" 
													FilterControlAltText="Filter column2 column" 
													HeaderText="Descripción del Documento" UniqueName="column2">
												</telerik:GridBoundColumn>
												<telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" 
													HeaderText="Documento Revisado y Aceptado" UniqueName="TemplateColumn">
													<ItemTemplate>
														<asp:RadioButtonList ID="rblAcep" runat="server" RepeatDirection="Horizontal" 
															Font-Size="10pt" Height="10px" Width="187px">
															<asp:ListItem  Value="1">Aceptado</asp:ListItem>
															<asp:ListItem Selected="True" Value="0">Rechazado</asp:ListItem>
														</asp:RadioButtonList>
													</ItemTemplate>
												</telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn1 column" 
													HeaderText="Motivo de Rechazo" UniqueName="TemplateColumn1">
													<ItemTemplate>
                                                        <telerik:RadComboBox ID="RadComboBox1" Runat="server" Culture="es-ES" 
                                                        DataSourceID="SqlDS" DataTextField="Descripcion_Rechazo" DataValueField="id">
                                                </telerik:RadComboBox>
													</ItemTemplate>
												</telerik:GridTemplateColumn>
												<telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn1 column" 
													HeaderText="Observaciones" UniqueName="TemplateColumn1">
													<ItemTemplate>
														<asp:TextBox ID="txtObs" runat="server" TextMode="MultiLine" Height="23px" 
															Width="212px"></asp:TextBox>
													</ItemTemplate>
												</telerik:GridTemplateColumn>
												<telerik:GridBoundColumn DataField="vacio" 
													FilterControlAltText="Filter column3 column" HeaderText="Mensaje Sistema" 
													UniqueName="column3">
												</telerik:GridBoundColumn>
											</Columns>
											<EditFormSettings>
												<EditColumn FilterControlAltText="Filter EditCommandColumn column">
												</EditColumn>
											</EditFormSettings>
										</MasterTableView>
										<FilterMenu EnableImageSprites="False">
										</FilterMenu>
									</telerik:RadGrid>
								</td>
			</tr>
			<tr>
				<td>
								<asp:CheckBox ID="chkEntregados" runat="server" AutoPostBack="True" 
									CssClass="letrasdetodo" 
						Text="Mostrar Documentos Revisados y aceptados" ForeColor="#0066FF" />
							</td>
			</tr>
			<tr>
				<td>
									<telerik:RadGrid ID="RadGrid3" runat="server" 
						AutoGenerateColumns="False" Culture="es-ES" Visible="False" Width="746px" 
										>
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
												<telerik:GridBoundColumn DataField="documentos_descrip" 
													FilterControlAltText="Filter column2 column" 
													HeaderText="Descripción del Documento" UniqueName="column2">
												</telerik:GridBoundColumn>
												<telerik:GridBoundColumn DataField="FechaChkEntregado" DataFormatString=" {0:dd/MM/yyyy}" 
													FilterControlAltText="Filter column column" 
													HeaderText="Fecha en que se Aceptaron" UniqueName="column">
												</telerik:GridBoundColumn>
											</Columns>
											<EditFormSettings>
												<EditColumn FilterControlAltText="Filter EditCommandColumn column">
												</EditColumn>
											</EditFormSettings>
										</MasterTableView>
										<FilterMenu EnableImageSprites="False">
										</FilterMenu>
									</telerik:RadGrid>
								</td>
			</tr>
			<tr>
				<td>
					&nbsp;</td>
			</tr>
			<tr>
				<td>
					<telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" 
						Culture="es-ES" Width="1173px" Visible="False"  >
								<ClientSettings>
									<Resizing AllowResizeToFit="True" ResizeGridOnColumnResize="True" />
								</ClientSettings>
								<MasterTableView TableLayout="Fixed">
									<CommandItemSettings ExportToPdfText="Export to PDF" />
									<RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" 
														Visible="True">
									   
									</RowIndicatorColumn>
									<ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" 
														  Visible="True">
									   
									</ExpandCollapseColumn>
									<Columns>
										<telerik:GridBoundColumn DataField="Tramite_clvTramite" 
																 FilterControlAltText="Filter column column" 
											UniqueName="column" HeaderText="Tramite_clvTramite" Display="False">
										</telerik:GridBoundColumn>
										<telerik:GridBoundColumn DataField="Tramite_cvlSubTramite" 
																 FilterControlAltText="Filter column1 column" 
											UniqueName="column1" HeaderText="Tramite_cvlSubTramite" Display="False">
										</telerik:GridBoundColumn>
										<telerik:GridBoundColumn DataField="Tramite_TipoPersona" 
																 FilterControlAltText="Filter column5 column" HeaderText="Tramite_TipoPersona" 
																 UniqueName="column5" Display="False">
										</telerik:GridBoundColumn>
										<telerik:GridBoundColumn DataField="clv_servVeh" 
																 FilterControlAltText="Filter column6 column" HeaderText="clv_servVeh" 
																 UniqueName="column6" Display="False">
										</telerik:GridBoundColumn>
										<telerik:GridBoundColumn DataField="TramitesGestion_Descrip" 
																 FilterControlAltText="Filter column4 column" HeaderText="Tramite" 
																 UniqueName="column4">
										</telerik:GridBoundColumn>
										<telerik:GridBoundColumn DataField="Tramite_Descripcion" 
																 FilterControlAltText="Filter column2 column" 
																 HeaderText="Descripción del Documento" UniqueName="column2">
										</telerik:GridBoundColumn>
										<telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" 
																	HeaderText="Solicitar" UniqueName="TemplateColumn">
											<ItemTemplate>
												<asp:CheckBox ID="chkSol" runat="server" />
											</ItemTemplate>
										</telerik:GridTemplateColumn>
										<telerik:GridBoundColumn FilterControlAltText="Filter column3 column" 
																 HeaderText="Mensaje Sistema" UniqueName="column3" DataField="vacio">
										</telerik:GridBoundColumn>
									</Columns>
									<EditFormSettings>
										<EditColumn FilterControlAltText="Filter EditCommandColumn column">
										</EditColumn>
									</EditFormSettings>
								</MasterTableView>
								<FilterMenu EnableImageSprites="False">
								</FilterMenu>
							</telerik:RadGrid>
				</td>
			</tr>
		</table>
    <telerik:RadNotification ID="RadNotification1" runat="server">
    </telerik:RadNotification>
    <telerik:RadNotification ID="RadNotification2" runat="server" ContentIcon="">
     <ContentTemplate>
      <asp:Literal ID="lit" runat="server" Text="¿Desea solicitar el pago de honorarios del gestor asignado?"/>
     <br/>
     <br/>
        <asp:Button ID="btnAceptar" runat="server" Text="Si" />
        <asp:Button ID="btnRechazar" runat="server" Text="No" /><br />
        <asp:Button ID="btnSinCosto" runat="server" Text="Terminar sin Costo" />
     </ContentTemplate>
    </telerik:RadNotification>
</asp:Content>

<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGestionOperativa.master" AutoEventWireup="false" CodeFile="General.aspx.vb" Inherits="GestionGeneral_General" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="../HojaEstilos/StyleSheet3H.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .tabStrip
        {}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>--%>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
    
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server"  Width="100%" 
         LoadingPanelID="RadAjaxLoadingPanel1">
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                <telerik:RadTabStrip ID="RadTabStrip1" runat="server" Skin="Black" MultiPageID="RadMultiPage1"
										 SelectedIndex="0" CssClass="tabStrip" Width="605px">
						<Tabs>
							<telerik:RadTab Text="Datos del Reporte" PageViewID="RadPageView1" Selected="True">
							</telerik:RadTab>
                            <telerik:RadTab Text="Telefonos Extra" PageViewID="RadPageView2">
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
                        <div>
        
    <div class="Titulo"> 
        <asp:Label ID="lblDatos" runat="server" Text="Gestion General" 
            CssClass="Titulos"></asp:Label>
        </div>
        <br />
        <div class="Preguntas">
            <asp:Label ID="lblPreg1" runat="server" Text="Cliente:" CssClass="letrasdetodo"></asp:Label>
            <div >
                <telerik:RadTextBox ID="txtCliente" runat="server" AutoPostBack="True" 
                    CssClass="TxtBox" EmptyMessage="Obligatorio" Enabled="False" Width="20%">
                    <EmptyMessageStyle BackColor="#6666FF" ForeColor="Black" />
                </telerik:RadTextBox>
            </div>
    </div>
    <div class="Preguntas">
        <asp:Label ID="Label5" runat="server" Text="Tipo de Gestion:" 
            CssClass="letrasdetodo"></asp:Label>
        <div>
            <telerik:RadTextBox ID="txtTipoServicio" runat="server" AutoPostBack="True" 
                CssClass="TxtBox" EmptyMessage="Obligatorio" Enabled="False" Width="30%">
                <EmptyMessageStyle BackColor="#6666FF" ForeColor="Black" />
            </telerik:RadTextBox>
        </div>
    <div class="Preguntas">
        <asp:Label ID="lblPreg2" runat="server" Text="Persona que Reporto:" 
            CssClass="letrasdetodo"></asp:Label>
        <div>
            <table >
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Nombre:" CssClass="letrasdetodo"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="A.Paterno:" CssClass="letrasdetodo"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="A.Materno:" CssClass="letrasdetodo"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                                                <telerik:RadTextBox ID="txtNombre" runat="server" CssClass="TxtBox"
                                                    EmptyMessage=" " Enabled="False">
                                                    <EmptyMessageStyle BackColor="#8EC640" ForeColor="Black" />
                                                </telerik:RadTextBox>
                                            </td>
                                            <td class="style2">
                                                <telerik:RadTextBox ID="txtPaterno" runat="server" CssClass="TxtBox"
                                                    EmptyMessage=" " Enabled="False">
                                                    <EmptyMessageStyle BackColor="#8EC640" ForeColor="Black" />
                                                </telerik:RadTextBox>
                                            </td>
                                            <td>
                                                <telerik:RadTextBox ID="txtMaterno" runat="server" CssClass="TxtBox"
                                                    EmptyMessage=" " Enabled="False">
                                                    <EmptyMessageStyle BackColor="#8EC640" ForeColor="Black" />
                                                </telerik:RadTextBox>
                                            </td>
                </tr>
            </table>
            <div class="Preguntas">
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblLada3" runat="server" Text="Lada:" CssClass="letrasdetodo"></asp:Label>
                    </td>
                    <td style="width:45px;">
                        <telerik:RadTextBox ID="txtLadaCto" Runat="server" Width="40px" 
                            CssClass="TxtBox">
                        </telerik:RadTextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblTel3" runat="server" Text="Numero Telefonico:" 
                            CssClass="letrasdetodo"></asp:Label>
                    </td>
                    <td>
                        <telerik:RadTextBox ID="txtTelCon" Runat="server" CssClass="TxtBox">
                        </telerik:RadTextBox>
                    </td>
                </tr>
            </table>
        </div>
    </div>
            <table>
               
                 <tr>
                    <td>
                    <asp:RadioButtonList ID="tblTipoLlamada" runat="server" CssClass="letrasdetodo" 
                            RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True" Value="1">Compañia Contratante</asp:ListItem>
                                        <asp:ListItem Value="2">Cliente</asp:ListItem>
                                        <asp:ListItem Value="3">Usuario/Conductor</asp:ListItem>
                                        <asp:ListItem Value="4">Representante</asp:ListItem>
                                        <asp:ListItem Value="5">Cabina</asp:ListItem>
                                        
                                    </asp:RadioButtonList>
                    </td>
                  
                </tr>
            </table>
        </div>
    </div>
    
    </div>
    <div>
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
    </div>
    
    
    <div class="Preguntas">
        <asp:Label ID="Label8" runat="server" Text="Datos del Asegurado/Beneficiario:" 
            CssClass="letrasdetodo"></asp:Label>
        <div>
            <table>
                <tr>
                    <td>
                        <asp:RadioButtonList ID="rdoPersona" runat="server" CssClass="letrasdetodo" 
                            RepeatDirection="Horizontal" AutoPostBack="True">
                            <asp:ListItem Selected="True" Value="1">Fisica</asp:ListItem>
                            <asp:ListItem Value="2">Moral</asp:ListItem>
                            
                        </asp:RadioButtonList>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="Preguntas">
        <div >
            <table>
            <tr>
            <td>
                <asp:Label ID="lblFisica" runat="server" Text="Persona Fisica" 
                    CssClass="letrasdetodo"></asp:Label>
            
            </td>
             <td></td>
              <td></td>
            </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label10" runat="server" Text="Nombre:" CssClass="letrasdetodo"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label11" runat="server" Text="A.Paterno:" 
                            CssClass="letrasdetodo"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label12" runat="server" Text="A.Materno:" 
                            CssClass="letrasdetodo"></asp:Label>
                    </td>
                </tr>
                <tr>
                   <td class="style2">
                                                <telerik:RadTextBox ID="txtNomAseg" runat="server" CssClass="TxtBox" EmptyMessage=" ">
                                                    <EmptyMessageStyle BackColor="#8EC640" ForeColor="Black" />
                                                </telerik:RadTextBox>
                                            </td>
                                            <td class="style2">
                                                <telerik:RadTextBox ID="txtApepatAseg" runat="server" CssClass="TxtBox" EmptyMessage=" ">
                                                    <EmptyMessageStyle BackColor="#8EC640" ForeColor="Black" />
                                                </telerik:RadTextBox>
                                            </td>
                                            <td>
                                                <telerik:RadTextBox ID="txtApeMatAseg" runat="server" CssClass="TxtBox" EmptyMessage=" ">
                                                    <EmptyMessageStyle BackColor="#8EC640" ForeColor="Black" />
                                                </telerik:RadTextBox>
                                            </td>
                </tr>
                <tr>
                <td>
                
                    <asp:Label ID="lblMoral" runat="server" Text="Persona Moral" 
                        CssClass="letrasdetodo"></asp:Label>
                </td>
                <td></td>
                <td></td>
                </tr>
                <tr>
                <td colspan="2">
                    <telerik:RadTextBox ID="txtCia" runat="server" CssClass="TxtBox" 
                        Visible="False" Width="95%">
                    </telerik:RadTextBox>
                    </td>
                <td></td>
                </tr>
            </table>
        </div>
    </div>
    <div class="Preguntas">
        <div >
            <table>
                <tr>
                    <td class="style3">
                        <asp:Label ID="Label14" runat="server" Text="Lada:" CssClass="letrasdetodo"></asp:Label>
                    </td>
                    <td class="style4">
                        <telerik:RadTextBox ID="txtLadaCto0" Width="40px" Runat="server" Height="22px" 
                            CssClass="TxtBox">
                        </telerik:RadTextBox>
                    </td>
                    <td class="style3">
                        <asp:Label ID="Label42" runat="server" Text="Numero Telefonico:" 
                            CssClass="letrasdetodo"></asp:Label>
                    </td>
                    <td class="style3">
                        <telerik:RadTextBox ID="txtTelCon0" Runat="server" Height="22px" 
                            CssClass="TxtBox">
                        </telerik:RadTextBox>
                    </td>
                    
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label15" runat="server" Text="Lada:" CssClass="letrasdetodo"></asp:Label>
                    </td>
                    <td style="width:45px;">
                        <telerik:RadTextBox ID="txtLadaCto1" Width="40px" Runat="server" 
                            CssClass="TxtBox">
                        </telerik:RadTextBox>
                    </td>
                        <td style="width:150px">
                            <asp:Label ID="Label18" runat="server" Text="Numero Celular:" 
                                CssClass="letrasdetodo"></asp:Label>
                    </td>
                    <td>
                        <telerik:RadTextBox ID="txtTelCon1" Runat="server" CssClass="TxtBox">
                        </telerik:RadTextBox>
                    </td>
                    
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label118" runat="server" CssClass="letrasdetodo" Text="Lada:"></asp:Label>
                    </td>
                    <td style="width:45px;">
                        <telerik:RadTextBox ID="txtLadaEx" Runat="server" CssClass="TxtBox" 
                            Width="40px">
                        </telerik:RadTextBox>
                    </td>
                    <td>
                        <asp:Label ID="Label119" runat="server" CssClass="letrasdetodo" 
                            Text="Telefono Extra:"></asp:Label>
                    </td>
                    <td>
                        <telerik:RadTextBox ID="txtTelEx" Runat="server" CssClass="TxtBox">
                        </telerik:RadTextBox>
                    </td>
                </tr>
                <tr>
                <td colspan="4" class="style3">
                    <asp:Label ID="Label20" runat="server" 
                        Text="Enviar información acerca del servicio a su telefóno movil:" 
                        CssClass="letrasdetodo"></asp:Label>
                    </td>
                </tr>
                 <tr>
                <td></td>
                <td></td>
                <td>
                    <asp:RadioButtonList ID="rdoInfoCorreo" runat="server" CssClass="letrasdetodo" 
                        RepeatDirection="Horizontal" Enabled="False">
                        <asp:ListItem Selected="True" Value="1">Si</asp:ListItem>
                        <asp:ListItem Value="2">No</asp:ListItem>
                    
                    </asp:RadioButtonList>
                     </td>
                <td>
                    &nbsp;</td>
                </tr>
            </table>
        </div>
    </div>
    <div class="Preguntas">
        <asp:Label ID="Label21" runat="server" Text="Email Asegurado/Beneficiario:" 
            CssClass="letrasdetodo"></asp:Label>
        <div>
            <table>
                 <tr>
                    <td colspan="4">
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
                    <td colspan="4">
                        <asp:Label ID="Label23" runat="server" 
                            Text="Enviar información acerca del servicio a su correo electronico:" 
                            CssClass="letrasdetodo"></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:RadioButtonList ID="rdoInfoCel" runat="server" CssClass="letrasdetodo" 
                            RepeatDirection="Horizontal" Enabled="False">
                            <asp:ListItem Selected="True" Value="1">Si</asp:ListItem>
                            <asp:ListItem Value="2">No</asp:ListItem>
                           
                        </asp:RadioButtonList>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="Titulo">
        <asp:Label ID="Label4" runat="server" Text="No. de poliza/certificado/Contrato" 
            CssClass="letrasdetodo"></asp:Label>
        </div>
    <div class="Preguntas">
        <div >
            <table >
                <tr>
                    <td style="width:150px">

                        <asp:Label ID="Label26" runat="server" Text="No.Poliza:" 
                            CssClass="letrasdetodo"></asp:Label>

                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:Label ID="Label27" runat="server" Text="Inciso:" CssClass="letrasdetodo"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                     <telerik:RadTextBox ID="txtNoPoliza" runat="server" CssClass="TxtBox" EmptyMessage=" "
                                                    Width="100%" Enabled="False">
                                                    <EmptyMessageStyle BackColor="#8EC640" ForeColor="Black" />
                                                </telerik:RadTextBox>
                    </td>
                    <td>
                    </td>
                    <td>
                    <telerik:RadTextBox ID="txtInciso" runat="server" CssClass="TxtBox" Enabled="False">
                                                </telerik:RadTextBox>
                    </td>
                </tr>
            </table>
        </div>
        </div>
        <div class="Titulo">
            <asp:Label ID="Label28" runat="server" Text="Datos Vehiculo" 
                CssClass="letrasdetodo"></asp:Label>
        </div>
    <div class="Preguntas">
        <div >
            <table>
                <tr>
                    <td class="style1">
                        <asp:Label ID="Label30" runat="server" Text="Marca:" CssClass="letrasdetodo"></asp:Label>
                    </td>
                    <td class="style1">
                        <asp:Label ID="Label31" runat="server" Text="Tipo:" CssClass="letrasdetodo"></asp:Label>
                    </td>
                    <td class="style1">
                    </td>
                    <td class="style1">
                    </td>
                    <td class="style1">
                    </td>
                </tr>
                <tr>
                    <td style="width:200px">
                        <telerik:RadComboBox ID="cboMarca" runat="server" AutoPostBack="True" 
                            Width="95%" Skin="Forest">
                        </telerik:RadComboBox>
                    </td>
                    <td style="width:200px">
                        <telerik:RadComboBox ID="cboSubmarca" runat="server" Width="100%" Skin="Forest">
                        </telerik:RadComboBox>
                    </td>
                    
                </tr>
                </table>
                <table>
                <tr>
                    <td>
                        <asp:Label ID="Label32" runat="server" Text="Modelo:" CssClass="letrasdetodo"></asp:Label>
                       </td>
                    <td>
                        <asp:Label ID="Label33" runat="server" Text="Color:" CssClass="letrasdetodo"></asp:Label>
                        </td>
                    <td>
                        <asp:Label ID="Label34" runat="server" Text="Placas:" CssClass="letrasdetodo"></asp:Label>
                       </td>
                    <td>

                       </td>
                    <td>
                        <asp:Label ID="Label35" runat="server" Text="No.Serie:" CssClass="letrasdetodo"></asp:Label>
                        </td>
                </tr>
                <tr>
                    <td style="width:150px">
                      <telerik:RadTextBox ID="txtModelo" runat="server" CssClass="TxtBox" >
                                                <EmptyMessageStyle BackColor="#6666FF" ForeColor="Black" />
                                            </telerik:RadTextBox>
                        </td>
                    <td style="width:150px">
                    <telerik:RadTextBox ID="txtColor" runat="server" CssClass="TxtBox">
                                            </telerik:RadTextBox>
                        </td>
                    <td style="width:150px">
                    <telerik:RadTextBox ID="txtPlacas" runat="server" CssClass="TxtBox">
                                            </telerik:RadTextBox>
                       </td>
                    <td style="width:100px">
                        &nbsp;</td>
                    <td style="width:150px">
                    <telerik:RadTextBox ID="txtSerie" runat="server" CssClass="TxtBox">
                                            </telerik:RadTextBox>
                       </td>
                </tr>
                </table>
        </div>
    </div>
    <div class="Titulo">
        <asp:Label ID="Label36" runat="server" Text="Datos Ubicacion" 
            CssClass="letrasdetodo"></asp:Label>
    </div>
    <div class="Preguntas">
        <div>
            <table >
                <tr>
                    <td>
                    <asp:Label ID="Label39" runat="server" Text="Estado:" CssClass="letrasdetodo"></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td style="width:200px">
                    <telerik:RadComboBox ID="cboEstado" runat="server" AutoPostBack="True" Width="95%" 
                            Skin="Forest">
                                            </telerik:RadComboBox>
                    </td>
                </tr>
                 <tr>
                    <td>
                    <asp:Label ID="Label38" runat="server" Text="Municipio/Delegacion:" 
                            CssClass="letrasdetodo"></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td style="width:200px">
                    <telerik:RadComboBox ID="cboMpio" runat="server" Width="95%" Skin="Forest">
                                            </telerik:RadComboBox>
                    </td>
                </tr>
            </table>
            
             
        </div>
    </div>
    <div class="Titulo">
        <asp:Label ID="Label40" runat="server" Text="Observaciones" 
            CssClass="letrasdetodo"></asp:Label>

    </div>
    <div class="Preguntas">
     
    </div>
    <div>
        <table style="margin-bottom: 0px" >
           <tr>
           <td>
               <telerik:RadTextBox ID="txtObservaciones" Runat="server" Height="100px" 
                   TextMode="MultiLine" Width="800px">
               </telerik:RadTextBox>
           </td>
           </tr>
           
            <tr>
                <td style="width:500px;text-align:center">
                    <asp:Button ID="Button1" runat="server" Text="Guardar" />
                </td>
            </tr>
            <tr>
                <td style="width:500px;">
                    
                    

                </td>
            </tr>
        </table>
        
        <telerik:RadNotification ID="RadNotification2" runat="server" Skin="Forest">
                                </telerik:RadNotification>
        </div>
        </div>
                        </telerik:RadPageView>
                        <telerik:RadPageView ID="RadPageView2" runat="server">
							<table cellspacing="1" class="style7">
								<tr>
									<td>
										<asp:Panel ID="Panel2" runat="server" Visible="False">
											<table cellspacing="1" class="style7">
												<tr>
													<td class="style83">
														<asp:Label ID="Label6" runat="server" CssClass="Titulos" 
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
        </table>
        
        </telerik:RadAjaxPanel>
</asp:Content>
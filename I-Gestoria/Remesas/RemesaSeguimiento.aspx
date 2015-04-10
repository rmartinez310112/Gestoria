<%@ Page Language="VB" MasterPageFile="~/MasterPageGestionOperativa.master" AutoEventWireup="false" CodeFile="RemesaSeguimiento.aspx.vb" Inherits="RemesaSeguimiento" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../HojaEstilos/StyleSheet3H.css" rel="stylesheet" type="text/css" /> 
    <style type="text/css">
        .style87
        {
            width: 16%;
            border-style: none;
            border-color: inherit;
            border-width: 1;
        }
        .style89
        {
            width: 23%;
            border-style: none;
            border-color: inherit;
            border-width: 1;
        }
        .style90
        {
            width: 12%;
            border-style: none;
            border-color: inherit;
            border-width: 1;
        }
    </style>
</asp:Content>
 
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%-- <telerik:RadSkinManager ID="QsfSkinManager" runat="server" ShowChooser="true" />
    <telerik:RadFormDecorator ID="QsfFromDecorator" runat="server" DecoratedControls="All" EnableRoundedCorners="false" />--%>
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">

            function ShowEditForm(id, rowIndex) {
                var grid = $find("<%= radSeguimiento.ClientID %>");
                var rowControl = grid.get_masterTableView().get_dataItems()[rowIndex].get_element();
                grid.get_masterTableView().selectItem(rowControl, true);
                //window.radopen("EditFormVB.aspx?EmployeeID=" + id, "UserListDialog");
                window.radopen("Seguimiento.aspx", "UserListDialog");
                return false;
            }

            function ShowInsertForm() {
                window.radopen("EditFormVB.aspx", "UserListDialog");
                return false;
            }

            function darClick() {

                var objO = document.getElementById('<%=BtnActualiza.ClientID %>');

                objO.click();

            }

            function refreshGrid(arg) {
                if (!arg) {
                    $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("Rebind");
                    darClick()
                }
                   else {
                       $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("RebindAndNavigate");
                       darClick()
                }
            }
        </script>
    </telerik:RadCodeBlock>
                <br /> 
                <table class="centrado" style="width:100%">
                <tr>
                <td align="center">
                <asp:Label  ID="lbltittle" CssClass="centrado" runat="server" Text="Control de Seguimiento"></asp:Label>
                </td>
                </tr>
                </table>
                 <div id="ficha_tramites"> 
                    <fieldset> 
                          <table border="0" style="text-align:center;width:90%">
                           <tr>
                               <td colspan="9">
                                   &nbsp;</td>
                           </tr>
                           <tr>
                               <td colspan="9">
                               <br />
                               </td>
                           </tr>
                           <tr>
                                <td align="right" class="table_td">
                                    <asp:Label ID="idRemesa" runat="server" ForeColor="White" Font-Size="Small" 
                                        Text="Remesa:" ></asp:Label>
                                </td>
                             <td align="left" class="table_td"> 
                              <telerik:RadTextBox ID="txtRemesa" runat="server"></telerik:RadTextBox>
                             </td>
                             <td align="right" class="table_td">
                                <asp:Label ID="idEstado0" ForeColor="White" Font-Size="Small" Text="Estado:" 
                                     runat="server"></asp:Label>
                             </td>
                             <td align="left" class="table_td"> 
                               <telerik:RadComboBox  ID="cmbEstado" runat="server" AutoPostBack="True"></telerik:RadComboBox>
                             </td>
                             <td align="left" class="style90" rowspan="2">
                                 &nbsp;</td>
                             <td align="right" class="table_td">
                               &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                               <asp:Label ID="Finicio" runat="server" ForeColor="White" Font-Size="Small" 
                                     Text="Fecha de Inicio:" ToolTip="Es contra fecha de cita" ></asp:Label>
                             </td>
                             <td align="left" class="table_td">
                              <telerik:RadDatePicker ID="rdDtpFI" runat="server" Culture="es-MX">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"></Calendar>

<DateInput DisplayDateFormat="MM/dd/yyyy" DateFormat="MM/dd/yyyy" LabelWidth="40%">
<EmptyMessageStyle Resize="None"></EmptyMessageStyle>

<ReadOnlyStyle Resize="None"></ReadOnlyStyle>

<FocusedStyle Resize="None"></FocusedStyle>

<DisabledStyle Resize="None"></DisabledStyle>

<InvalidStyle Resize="None"></InvalidStyle>

<HoveredStyle Resize="None"></HoveredStyle>

<EnabledStyle Resize="None"></EnabledStyle>
</DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                                 </telerik:RadDatePicker>
                             </td>

                             <td align="right" class="style87">
                               <asp:Label ID="Ffinal" runat="server" ForeColor="White" Font-Size="Small" 
                                     Text="Fecha Final:" ToolTip="Es contra fecha de cita" ></asp:Label>
                             </td>
                             <td align="left" class="style89">
                              <telerik:RadDatePicker ID="rdDtpFF" runat="server" Culture="es-MX">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"></Calendar>

<DateInput DisplayDateFormat="MM/dd/yyyy" DateFormat="MM/dd/yyyy" LabelWidth="40%">
<EmptyMessageStyle Resize="None"></EmptyMessageStyle>

<ReadOnlyStyle Resize="None"></ReadOnlyStyle>

<FocusedStyle Resize="None"></FocusedStyle>

<DisabledStyle Resize="None"></DisabledStyle>

<InvalidStyle Resize="None"></InvalidStyle>

<HoveredStyle Resize="None"></HoveredStyle>

<EnabledStyle Resize="None"></EnabledStyle>
</DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                                 </telerik:RadDatePicker>
                             </td>
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

                             <td align="right" class="style87">
                                 &nbsp;</td>
                             <td align="left" class="style89">
                                 &nbsp;</td>
                           </tr> 
                           <tr><td colspan="9"></td>
                           </tr>
                           <tr>
                              
                               <td align="right" class="table_td">
                                <asp:Label ID="idGestor" Text="Gestor:" ForeColor="White" Font-Size="Small" 
                                       runat="server"></asp:Label>
                               </td>
                               <td align="left" class="table_td">
                              <telerik:RadTextBox ID="txtGestor" runat="server"></telerik:RadTextBox>
                               </td>
                                <td align="right" class="table_td">
                                <asp:Label ID="idMpio" ForeColor="White" Font-Size="Small" Text="Municipio:" 
                                        runat="server"></asp:Label>
                               </td>
                               <td align="left" class="table_td">
                                  <telerik:RadComboBox ID="cboMpio" runat="server" Culture="es-ES">
                                      <Items>
                                          <telerik:RadComboBoxItem runat="server" Text="--" Value="0" Owner="cboMpio" />
                                      </Items>
                                   </telerik:RadComboBox>
                               </td>
                              
                                <td align="right" class="style90">
                                    &nbsp;</td>
                              
                                <td align="right" class="table_td">
                                <asp:Label ID="Label6" Text="Tipo de Seguimiento:" ForeColor="White" Font-Size="Small" runat="server"></asp:Label>
                               </td>
                               <td align="left" class="table_td">
                                  <telerik:RadComboBox ID="cmbSeguimiento" runat="server"></telerik:RadComboBox>
                               </td>
                               <td align="right" class="style87">
                                   &nbsp;</td>
                               <td align="left" class="style89">
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
                              
                                <td align="right" class="style90">
                                    &nbsp;</td>
                              
                                <td align="right" class="table_td">
                                    &nbsp;</td>
                               <td align="left" class="table_td">
                                   &nbsp;</td>
                               <td align="right" class="style87">
                                   &nbsp;</td>
                               <td align="left" class="style89">
                                   &nbsp;</td>
                           </tr>
                           <tr>
                           <td colspan="9">
                               <asp:Button ID="BtnActualiza" runat="server" Text="" BackColor="Transparent" BorderColor="Transparent" BorderStyle="None"  Display="False" />
                               <br />
                           </td>
                           
                           </tr>
                           <tr>
                                <td colspan ="6">
                                  <fieldset class="ficha_tramites">
                                       <table width="95%" border="0">
                                               <tr>
                                                  <td align="left" style="border: solid 1px #BDBDBD;">
                                                    <asp:Label ID="citas" ForeColor="White" Font-Size="Small" Text="Número de Citas:" runat="server"></asp:Label>
                                                  </td>
                                                  <td align="left" style="border: solid 1px #BDBDBD;">
                                                     <asp:Label ID="lblNumcitas" Font-Size="Small" runat="server"></asp:Label>
                                                  </td>
                                                  <td align="left" style="border: solid 1px #BDBDBD;">
                                                     <asp:Label ID="lblPendientes" ForeColor="White" Font-Size="Small" runat="server" Text="Pendientes de concretar Citas:"></asp:Label>
                                                  </td>

                                                  <td align="left" style="border: solid 1px #BDBDBD;"> 
                                                     <asp:Label ID="lblPendientesconcretar" Font-Size="Small" runat="server"></asp:Label>
                                                  </td>
                                                  <td align="left" style="border: solid 1px #BDBDBD;">
                                                     <asp:Label ID="Label7" runat="server" ForeColor="White" Font-Size="Small" Text="Pendientes de seguimiento a trámite:"></asp:Label>
                                                  </td>
                                                   <td align="left" style="border: solid 1px #BDBDBD;">
                                                     <asp:Label ID="lblPendientesSeguimiento" Font-Size="Small" runat="server"></asp:Label>
                                                  </td>
                                                  <td align="left" style="border: solid 1px #BDBDBD;">
                                                     <asp:Label ID="Label8" runat="server" ForeColor="White" Font-Size="Small" Text="Pendientes de seguimiento envío documentación:"></asp:Label>
                                                  </td>
                                                  <td align="left" style="border: solid 1px #BDBDBD;">
                                                     <asp:Label ID="lblSeguimeintoEnvio" Font-Size="Small" runat="server"></asp:Label>
                                                  </td>
                                                  <td align="left" style="border: solid 1px #BDBDBD;">
                                                     <asp:Label ID="Label9" runat="server" ForeColor="White" Font-Size="Small" 
                                                          Text="Expedientes Rechazados:" Visible="False"></asp:Label>
                                                   </td>
                                                   <td align="left" style="border: solid 1px #BDBDBD;">
                                                     <asp:Label ID="lblExpRechazados" Font-Size="Small" runat="server" Visible="False"></asp:Label>
                                                  </td>
                                               </tr>
                                       </table>
                                   </fieldset>
                                  
                                </td>
                                <td colspan="3" align="right">
                                 <telerik:RadButton runat="server" ID="btnBuscar" Text="Buscar"> </telerik:RadButton>
                                </td>
                           </tr>
                        </table>
                    </fieldset>
                    <br />

                    
                    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" OnAjaxRequest="RadAjaxManager1_AjaxRequest">
                        <AjaxSettings>
                            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                                <UpdatedControls>
                                    <telerik:AjaxUpdatedControl ControlID="radSeguimiento" LoadingPanelID="gridLoadingPanel"></telerik:AjaxUpdatedControl>
                                </UpdatedControls>
                            </telerik:AjaxSetting>
                            <telerik:AjaxSetting AjaxControlID="radSeguimiento">
                                <UpdatedControls>
                                    <telerik:AjaxUpdatedControl ControlID="radSeguimiento" LoadingPanelID="gridLoadingPanel"></telerik:AjaxUpdatedControl>
                                </UpdatedControls>
                            </telerik:AjaxSetting>
                        </AjaxSettings>
                     </telerik:RadAjaxManager>
                    <telerik:RadAjaxLoadingPanel runat="server" ID="gridLoadingPanel">
                     </telerik:RadAjaxLoadingPanel> 
 

                    <asp:UpdatePanel ID="UpdatePanelGrid" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <telerik:RadXmlHttpPanel ID="panelGrid" Runat="server" CssClass="PanelGrid" Visible="true">
                                <telerik:RadButton ID="detalle1" runat="server" 
                                    Text="DetalleSeguimientoLlamada">
                                </telerik:RadButton>
                                <telerik:RadButton ID="RadButton3" runat="server" Text="DetalleDocumento">
                                </telerik:RadButton>
                                <telerik:RadGrid ID="radSeguimiento" CssClass="Grid" runat="server" BorderWidth="0px" 
                                                AutoGenerateColumns="False" AllowPaging="True" PageSize="20" Skin="Transparent" 
                                                Culture="es-ES" Width="1650px" CellSpacing="0" GridLines="None">
                                        <MasterTableView>

                                            <Columns>
                                                <telerik:GridButtonColumn CommandName="cmdRemesa" ButtonType="LinkButton" 
                                                    UniqueName="column" DataTextField="Remesa" ItemStyle-ForeColor="Blue" 
                                                    HeaderText="No. Remesa" FilterControlAltText="Filter column column">
                                                    <ItemStyle ForeColor="Blue" />
                                                </telerik:GridButtonColumn>
                                                <telerik:GridBoundColumn DataField="cliente_NomCliente" HeaderText="Cliente" 
                                                    UniqueName="column1" FilterControlAltText="Filter column1 column"> 
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="NOMBRE" UniqueName="column2" 
                                                    HeaderText="Estado" FilterControlAltText="Filter column2 column">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="FechaAlta" UniqueName="column3" 
                                                    HeaderText="Fecha de Activación" 
                                                    FilterControlAltText="Filter column3 column" >
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="gestor" UniqueName="column4" 
                                                    HeaderText="Gestor Asignado" FilterControlAltText="Filter column4 column">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Dias_Transcurridos" UniqueName="column5" 
                                                    HeaderText="Dias Transcurridos" 
                                                    FilterControlAltText="Filter column5 column">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Seguimiento_a_Tramite" 
                                                    UniqueName="column6" HeaderText="Seguimiento a Tramite" 
                                                    FilterControlAltText="Filter column6 column">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="fecha_TerminoTramiteAsignacion" UniqueName="column7" 
                                                    HeaderText="Fecha Termino de Tramite" 
                                                    FilterControlAltText="Filter column7 column">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Seguimiento_Envio_Documentos" 
                                                    UniqueName="column8" HeaderText="Seguimiento Envio de Documentos" 
                                                    FilterControlAltText="Filter column8 column">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Fecha_RecepDocs" UniqueName="column9" 
                                                    HeaderText="Fecha Envio de Documentos" 
                                                    FilterControlAltText="Filter column9 column">
                                                </telerik:GridBoundColumn >

                                                <telerik:GridBoundColumn DataField="Consultar_Recepcion_Documentos" UniqueName="column10" 
                                                    HeaderText="Consultar Recepcion de Documentos" 
                                                    FilterControlAltText="Filter column10 column">
                                                </telerik:GridBoundColumn >

                                                <telerik:GridBoundColumn  DataField="Documentos_Pendientes_Recepcion" UniqueName="column11" 
                                                    HeaderText="Documentos pendientes de Recepción" 
                                                    FilterControlAltText="Filter column11 column" >
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="AccionSiguiente" 
                                                    UniqueName="column12" HeaderText="Accion Siguiente" 
                                                    FilterControlAltText="Filter column12 column">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Numero_Servicios_por_Remesa" 
                                                    UniqueName="column13" HeaderText="Numero de servicios por Remesa" 
                                                    FilterControlAltText="Filter column13 column">
                                                </telerik:GridBoundColumn>
                                            </Columns>
                                        </MasterTableView>
                                        <ClientSettings>
                                            <Selecting CellSelectionMode="None" AllowRowSelect="True" />
                                            <Scrolling AllowScroll="false" UseStaticHeaders="True" SaveScrollPosition="True" ></Scrolling>
                                        </ClientSettings>
                                        <FilterMenu EnableImageSprites="False">
                                        </FilterMenu>
                                </telerik:RadGrid>
                                <br />
                                <telerik:RadNotification ID="RadNotification2" runat="server">
                                </telerik:RadNotification>
                            </telerik:RadXmlHttpPanel>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                 </div>
</asp:Content>
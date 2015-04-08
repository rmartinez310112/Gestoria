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
                                       <%--<HeaderStyle ForeColor="White" BackColor="#8EC640" Font-Bold="true" BorderWidth="1"/>
                                            <RowIndicatorColumn Visible="true">
                                            </RowIndicatorColumn>
                                            <ExpandCollapseColumn Created="True">
                                            </ExpandCollapseColumn>--%>
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
                                                <telerik:GridButtonColumn CommandName="cmdNoGestion" ButtonType="LinkButton" UniqueName="Gestion" DataTextField="NoGestion" ItemStyle-ForeColor="Blue" HeaderText="No. Servicio">
                                                    <ItemStyle ForeColor="Blue" />
                                                </telerik:GridButtonColumn>
                                                <telerik:GridBoundColumn DataField="NoGestion" HeaderText="Sexo" 
                                                    SortExpression="NoGestion2" UniqueName="NoGestion2" Display="False" 
                                                    EmptyDataText=""> 
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Reporte_poliza" UniqueName="Poliza" 
                                                    HeaderText="No. Póliza" EmptyDataText="">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Estado" UniqueName="Estado" 
                                                    HeaderText="Estado" EmptyDataText="" >
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Mpio" UniqueName="Municipio" 
                                                    HeaderText="Municipio" EmptyDataText="">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="cliente_NomCliente" UniqueName="Cliente" 
                                                    HeaderText="Cliente" EmptyDataText="">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Servicio_NomServicio" 
                                                    UniqueName="TipoServicio" HeaderText="Tipo Servicio" EmptyDataText="">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="FechaCita" UniqueName="FechaHoraCita" 
                                                    HeaderText="Fecha y Hora cita" EmptyDataText="">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="diasTranscurridos" 
                                                    UniqueName="DiasTranscurridos" HeaderText="Días Transcurridos" EmptyDataText="">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridButtonColumn DataTextField="SegACita" UniqueName="SegACita" 
                                                    CommandName="cmdSegACita" ItemStyle-ForeColor="Blue" 
                                                    HeaderText="Seguimiento a Cita" >
                                                    <ItemStyle ForeColor="Blue" />
                                                </telerik:GridButtonColumn>
                                                <telerik:GridButtonColumn  DataTextField="SegDCita" UniqueName="SegDCita" CommandName="cmdSegDCita" ItemStyle-ForeColor="Blue" HeaderText="Seguimiento despues Cita" Visible="False" >
                                                    <ItemStyle ForeColor="Blue" />
                                                </telerik:GridButtonColumn>
                                                <telerik:GridButtonColumn  DataTextField="SegTramite" UniqueName="SegATramite" ItemStyle-ForeColor="Blue" CommandName="cmdSegTramite" HeaderText="Seguimiento a Trámite" >
                                                    <ItemStyle ForeColor="Blue" />
                                                </telerik:GridButtonColumn>
                                                <telerik:GridButtonColumn DataTextField="SegEnvioDoc" UniqueName="SegEnvDoc" ItemStyle-ForeColor="Blue" CommandName="cmdSegEnvDoc" HeaderText="Seguimiento envío de Documentos" >
                                                    <ItemStyle ForeColor="Blue" />
                                                </telerik:GridButtonColumn>
                                                <telerik:GridBoundColumn DataField="Intentos" UniqueName="Int" 
                                                    HeaderText="Intentos" EmptyDataText="">
                                                </telerik:GridBoundColumn >

                                                <telerik:GridBoundColumn DataField="SigAc" UniqueName="SigAc" 
                                                    HeaderText="Sig. Acción" EmptyDataText="">
                                                </telerik:GridBoundColumn >

                                                <telerik:GridBoundColumn  DataField="FecLimSeg" UniqueName="FecLimSeg" 
                                                    HeaderText="Fecha limite de Seguimiento" DataFormatString="{0:dd/MM/yyyy}" 
                                                    EmptyDataText="" >
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="ExpRec" Visible="false" 
                                                    UniqueName="ExpeRec" HeaderText="Expediente Rechazado" EmptyDataText="">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="MotRec" Visible="false" 
                                                    UniqueName="MotiRec" HeaderText="Motivo de Rechazo" EmptyDataText="">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridButtonColumn DataTextField="NúmeroRechazos" 
                                                    FilterControlAltText="Filter NúmeroRechazos column" 
                                                    HeaderText="Numero de Rechazos" UniqueName="NúmeroRechazos" 
                                                    CommandName="CmdNumRechazos">
                                                </telerik:GridButtonColumn>
                                            </Columns>
                                            <EditFormSettings>
                                                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                                </EditColumn>
                                            </EditFormSettings>
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
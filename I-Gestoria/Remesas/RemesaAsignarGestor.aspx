<%@ Page Language="VB" MasterPageFile="~/MasterPageGestionOperativa.master" AutoEventWireup="false" CodeFile="RemesaAsignarGestor.aspx.vb" Inherits="RemesaAsignarGestor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../HojaEstilos/StyleSheet3H.css" rel="stylesheet" type="text/css" />
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
//            var objBoton = '<%=btnBuscar.ClientID%>'
            function ShowEditForm(id, rowIndex) {
                var grid = $find("<%= radRemesaAsignacion.ClientID %>");
                var rowControl = grid.get_masterTableView().get_dataItems()[rowIndex].get_element();
                grid.get_masterTableView().selectItem(rowControl, true);
                //window.radopen("EditFormVB.aspx?EmployeeID=" + id, "UserListDialog");
                window.radopen("RemesaAsignarGestor.aspx", "UserListDialog");
                return false;
            }
            function ShowInsertForm() {
                window.radopen("EditFormVB.aspx", "UserListDialog");
                return false;
            }
            function refreshGrid(arg) {
                if (!arg) {
                    $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("Rebind");
                }
                else {
                    $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("RebindAndNavigate");
                }
                
            }
            function RowDblClick(sender, eventArgs) {
                window.radopen("EditFormVB.aspx?EmployeeID=" + eventArgs.getDataKeyValue("EmployeeID"), "UserListDialog");
            }

            

//            function darClick() {

//                var objO = document.getElementByid(objBoton);

//                objO.click();

//            }

        </script>
    </telerik:RadCodeBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                <br /> 
                <table class="centrado" style="width:100%">
                <tr>
                <td align="center">
                <asp:Label  ID="lbltittle" CssClass="centrado" runat="server" 
                        Text="Control de Asignaciones"></asp:Label>
                
                </td>
                </tr>
                </table>
                 <div id="ficha_tramites"> 
                     
                    
                    <fieldset> 
                          <table border="0" style="text-align:center;width:90%">
                           <tr>
                               <td colspan="8">
                               </td>
                           </tr>
                           <tr>
                               <td colspan="8">
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
                                  <telerik:RadComboBox ID="cboEstado" runat="server" Culture="es-ES" 
                                      AutoPostBack="True">
                                   </telerik:RadComboBox>
                             </td>
                             <td align="right" class="table_td">
                               <asp:Label ID="Finicio" runat="server" ForeColor="White" Font-Size="Small" Text="Fecha de Inicio:" ></asp:Label>
                             </td>
                             <td align="left" class="table_td">
                              <telerik:RadDatePicker ID="rdFI" runat="server" Culture="es-MX">
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

                             <td align="right" class="table_td">
                               <asp:Label ID="Ffinal" runat="server" ForeColor="White" Font-Size="Small" Text="Fecha Final:" ></asp:Label>
                             </td>
                             <td align="left" class="table_td">
                              <telerik:RadDatePicker ID="rdFF" runat="server" Culture="es-MX">
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
                           <tr><td colspan="8"></td>
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
                                   </telerik:RadComboBox>
                               </td>
                                  <td align="left" class="table_td">
                                      &nbsp;</td>
                                <td style="width:100px;">
                                    &nbsp;</td>

                                <td align="right" class="table_td">
                                <asp:Label ID="Label6" Text="Tipo de Seguimiento:" ForeColor="White" Font-Size="Small" runat="server"></asp:Label>
                               </td>
                               <td align="left" class="table_td">
                                  <telerik:RadComboBox ID="cboStatusAsigna" runat="server"></telerik:RadComboBox>
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
                                  <td align="left" class="table_td">
                                      &nbsp;</td>
                                <td style="width:100px;" align="right">
                                    &nbsp;</td>

                                <td align="right" class="table_td">
                                    &nbsp;</td>
                               <td align="left" class="table_td">
                                   &nbsp;</td>
                           </tr>
                           <tr>
                           <td colspan="8" align="right" class="table_td"><br />
                               <br />
                           </td>
                           
                           </tr>
                           <tr>
                                <td colspan ="5">
                                  <fieldset class="ficha_tramites">
                                   <table width="95%" border="0">
                                   <tr>
                                      <td align="left" style="border: solid 1px #BDBDBD;">
                                        <asp:Label ID="citas" ForeColor="White" Font-Size="Small" 
                                              Text="Número de Servicios:" runat="server"></asp:Label>
                                      </td>
                                      <td align="left" style="border: solid 1px #BDBDBD;">
                                         <asp:Label ID="lblNumServ" Font-Size="Small" runat="server"></asp:Label>
                                      </td>
                                      <td align="left" style="border: solid 1px #BDBDBD;">
                                         <asp:Label ID="lblPendientes" ForeColor="White" Font-Size="Small" runat="server" 
                                              Text="Pendientes Contacto Cliente:"></asp:Label>
                                      </td>

                                      <td align="left" style="border: solid 1px #BDBDBD;"> 
                                         <asp:Label ID="lblPendientescontactoCliente" Font-Size="Small" runat="server"></asp:Label>
                                      </td>
                                      <td align="left" style="border: solid 1px #BDBDBD;">
                                         <asp:Label ID="Label7" runat="server" ForeColor="White" Font-Size="Small" 
                                              Text="Pendientes de Asignar:"></asp:Label>
                                      </td>
                                       <td align="left" style="border: solid 1px #BDBDBD;">
                                         <asp:Label ID="lblPendientesAsignar" Font-Size="Small" runat="server"></asp:Label>
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
                    

                    <asp:UpdatePanel ID="UpdatePanelGrid" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <telerik:RadButton ID="btnDetalleGestor0" runat="server" 
                                Text="Asignacion">
                            </telerik:RadButton>
                        <telerik:RadXmlHttpPanel ID="panelGrid" Runat="server" CssClass="PanelGrid" Visible="true">
                            <telerik:RadGrid ID="radRemesaAsignacion" CssClass="Grid" runat="server" BorderWidth="0px" 
                                AutoGenerateColumns="False" PageSize="20" Skin="Windows7" 
                        Culture="es-ES"   CellSpacing="0" GridLines="None" 
                                Font-Size="Smaller">
                        <MasterTableView Font-Size="XX-Small">
                            <EditFormSettings>
                                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                </EditColumn>
                            </EditFormSettings>
                       <HeaderStyle ForeColor="White" BackColor="#8EC640" Font-Bold="true" BorderWidth="1"/>
                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                            <RowIndicatorColumn Visible="true">
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn Created="True">
                            </ExpandCollapseColumn>
    <Columns>
        <telerik:GridButtonColumn CommandName="cmdNumservicio" 
            DataTextField="NumServicio" FilterControlAltText="Filter cmdNumservicio column" 
            HeaderText="No. Servicio" UniqueName="cmdNumservicio">
            <ItemStyle ForeColor="Blue" />
        </telerik:GridButtonColumn>
        <telerik:GridBoundColumn DataField="Reporte_poliza" 
            FilterControlAltText="Filter column1 column" HeaderText="No. Poliza" 
            UniqueName="column1">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Estado" 
            FilterControlAltText="Filter column2 column" HeaderText="Estado" 
            UniqueName="column2">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Municipio" 
            FilterControlAltText="Filter column3 column" HeaderText="Municipio" 
            UniqueName="column3">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Cliente" 
            FilterControlAltText="Filter column4 column" HeaderText="Cliente" 
            UniqueName="column4">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="TipoServicio" 
            FilterControlAltText="Filter column5 column" HeaderText="Servicio" 
            UniqueName="column5">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="ServicioJuridico" 
            FilterControlAltText="Filter column6 column" HeaderText="Servicio Juridico" 
            UniqueName="column6" EmptyDataText="">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Reporte_FechaRepor" 
            FilterControlAltText="Filter column7 column" HeaderText="Fecha Reporte" 
            UniqueName="column7" DataFormatString="{0:yyyy/MM/dd}">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="DiasTranscurridos" 
            FilterControlAltText="Filter column8 column" HeaderText="Dias Transcurridos" 
            UniqueName="column8">
        </telerik:GridBoundColumn>
        
        <telerik:GridButtonColumn CommandName="cmdcontactar" 
            FilterControlAltText="Filter contactar column" HeaderText="Contactar Usuario" 
            Text="contactar" UniqueName="cmdcontactar">
            <ItemStyle ForeColor="Blue" />
        </telerik:GridButtonColumn>
        <telerik:GridBoundColumn DataField="contactar" Display="False"
            FilterControlAltText="Filter contactar column" HeaderText="fecha" 
            UniqueName="contactar" EmptyDataText="">
        </telerik:GridBoundColumn>

        <telerik:GridBoundColumn DataField="Accion_SiguienteI" 
            FilterControlAltText="Filter Accion_Siguiente column" HeaderText="Accion Siguiente" 
            UniqueName="Accion_Siguiente" EmptyDataText="">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="IntentosI" 
            FilterControlAltText="Filter IntentosI column" HeaderText="Intentos" 
            UniqueName="IntentosI">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Estatus_ContactarUsuario" 
            FilterControlAltText="Filter Estatus_ContactarUsuario column" HeaderText="Estatus Contactar Usuario" 
            UniqueName="Estatus_ContactarUsuario" Display="False">
        </telerik:GridBoundColumn>
        <telerik:GridButtonColumn CommandName="cmdAsignacion" 
            FilterControlAltText="Filter cmdAsignacion column" HeaderText="Asignacion de Gestor" 
            Text="Asignar" UniqueName="cmdAsignacion">
            <ItemStyle ForeColor="Blue" />
        </telerik:GridButtonColumn>
        <telerik:GridBoundColumn DataField="Asigna" EmptyDataText="" 
            FilterControlAltText="Filter Asigna column" UniqueName="Asigna" Display="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Accion_SiguienteII" 
            FilterControlAltText="Filter Accion_SiguienteI column" HeaderText="Accion Siguiente" 
            UniqueName="Accion_SiguienteI" EmptyDataText="">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="IntentosII" 
            FilterControlAltText="Filter IntentosII column" HeaderText="Intentos" 
            UniqueName="IntentosII">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Estado_Asignacion" 
            FilterControlAltText="Filter Estado_Asignacion column" HeaderText="Estado de Asignacion" 
            UniqueName="Estado_Asignacion" Display="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Estatus_Cita" 
            FilterControlAltText="Filter Estatus_Cita column" HeaderText="Estatus de Cita" 
            UniqueName="Estatus_Cita" Display="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Tiempo_Transcurridos" 
            FilterControlAltText="Filter Tiempo_Transcurridos column" HeaderText="Tiempo Transcurridos" 
            UniqueName="Tiempo_Transcurridos">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="NomAseg" 
            FilterControlAltText="Filter NombreAseg column" HeaderText="Nombre Asegurado" 
            UniqueName="NombreAseg">
        </telerik:GridBoundColumn>
    </Columns>
                            </MasterTableView>
                        <ClientSettings>
                            <Selecting CellSelectionMode="None" AllowRowSelect="True" />
                            <Scrolling AllowScroll="True" UseStaticHeaders="True" 
                                SaveScrollPosition="True" ></Scrolling>
                        </ClientSettings>
                                <FilterMenu EnableImageSprites="False">
                                </FilterMenu>
                    </telerik:RadGrid>
                    </telerik:RadXmlHttpPanel>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    
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
                    <telerik:RadAjaxLoadingPanel runat="server" ID="gridLoadingPanel"></telerik:RadAjaxLoadingPanel> 
                    </div>
                            <telerik:RadNotification ID="RadNotification2" runat="server">
        </telerik:RadNotification>
                 
</asp:Content>
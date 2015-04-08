<%@ Page Language="VB" MasterPageFile="~/MasterPageGestionOperativa.master" AutoEventWireup="false" CodeFile="Control_Termino.aspx.vb" Inherits="AsignacionControl_AsignarGestor_Pendiente1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../HojaEstilos/StyleSheet3H.css" rel="stylesheet" type="text/css" />
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
//            var objBoton = '<%=btnBuscar.ClientID%>'
            function ShowEditForm(id, rowIndex) {
                var grid = $find("<%= radSeguimiento.ClientID %>");
                var rowControl = grid.get_masterTableView().get_dataItems()[rowIndex].get_element();
                grid.get_masterTableView().selectItem(rowControl, true);
                //window.radopen("EditFormVB.aspx?EmployeeID=" + id, "UserListDialog");
                window.radopen("AsignarGestor_Pendiente1.aspx", "UserListDialog");
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
            function RowDblClick(sender, eventArgs) {
                window.radopen("EditFormVB.aspx?EmployeeID=" + eventArgs.getDataKeyValue("EmployeeID"), "UserListDialog");
            }

        </script>
    </telerik:RadCodeBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                <br /> 
                <table class="centrado" style="width:100%">
                <tr>
                <td align="center">
                <asp:Label  ID="lbltittle" CssClass="centrado" runat="server" 
                        Text="Pendientes de Termino"></asp:Label>
                </td>
                </tr>
                </table>
                 <div id="ficha_tramites"> 
                    <fieldset> 
                          <table border="0" style="text-align:center;width:90%">
                           <tr>
                               <td colspan="8">
                               <br />
                               </td>
                           </tr>
                           <tr>
                                <td align="right" class="table_td">
                                 <asp:Label ID="Label35" runat="server" ForeColor="White" Font-Size="Small" 
                                        Text="Poliza:" ></asp:Label>
                                </td>
                             <td align="left" class="table_td"> 
                                 <asp:TextBox ID="TxtPoliza" runat="server"></asp:TextBox>
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
                                 <asp:Label ID="Label4" runat="server" ForeColor="White" Font-Size="Small" Text="Cliente:" ></asp:Label>
                                </td>
                             <td align="left" class="table_td"> 
                               <telerik:RadComboBox  ID="CboCliente" runat="server"></telerik:RadComboBox>
                             </td>
                             <td align="right" class="table_td">
                                <asp:Label ID="idEstado" ForeColor="White" Font-Size="Small" Text="Estado:" runat="server"></asp:Label>
                             </td>
                             <td align="left" class="table_td"> 
                                  <telerik:RadComboBox ID="cboEstado" runat="server" Culture="es-ES">
                                   </telerik:RadComboBox>
                             </td>
                             <td align="right" class="table_td">
                               <asp:Label ID="Finicio" runat="server" ForeColor="White" Font-Size="Small" Text="Fecha de Inicio:" ></asp:Label>
                             </td>
                             <td align="left" class="table_td">
                              <telerik:RadDatePicker ID="rdFI" runat="server" Culture="es-MX" 
                                     HiddenInputTitleAttibute="Visually hidden input created for functionality purposes." 
                                     WrapperTableSummary="Table holding date picker control for selection of dates.">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%"></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                                 </telerik:RadDatePicker>
                             </td>

                             <td align="right" class="table_td">
                               <asp:Label ID="Ffinal" runat="server" ForeColor="White" Font-Size="Small" Text="Fecha Final:" ></asp:Label>
                             </td>
                             <td align="left" class="table_td">
                              <telerik:RadDatePicker ID="rdFF" runat="server" Culture="es-MX" 
                                     HiddenInputTitleAttibute="Visually hidden input created for functionality purposes." 
                                     WrapperTableSummary="Table holding date picker control for selection of dates.">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%"></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                                 </telerik:RadDatePicker>
                             </td>
                           </tr> 
                           <tr><td colspan="8"></td>
                           </tr>
                           <tr>
                              
                               <td align="right" class="table_td">
                               <asp:Label ID="Label31" runat="server" Text="Tipo de Servicio:" Font-Size="Small" 
                                          ForeColor="White"></asp:Label>
                               </td>
                               <td align="left" class="table_td">
                                    <telerik:RadComboBox ID="cboServicioTipo" Runat="server">
                                </telerik:RadComboBox>
                               </td>
                                <td align="right" class="table_td">
                                <asp:Label ID="idRegion" Text="Región:" ForeColor="White" Font-Size="Small" runat="server"></asp:Label>
                               </td>
                               <td align="left" class="table_td">
                                  <telerik:RadComboBox ID="cboRegion" AutoPostBack="true" runat="server"></telerik:RadComboBox>
                               </td>
                                  <td align="left" class="table_td">
                                <asp:Label ID="Label6" Text="Estatus Expediente:" ForeColor="White" Font-Size="Small" 
                                          runat="server"></asp:Label>
                                 </td>
                                <td style="width:100px;">
                                  <telerik:RadComboBox ID="cboEstatusExpediente" runat="server" Culture="es-ES">
                                      <Items>
                                          <telerik:RadComboBoxItem runat="server" Text="Seleccione" Value="0" />
                                          <telerik:RadComboBoxItem runat="server" Text="Expedientes Recibidos" 
                                              Value="9" />
                                          <telerik:RadComboBoxItem runat="server" Text="Expedientes Entregados" 
                                              Value="1" />
                                          <telerik:RadComboBoxItem runat="server" Text="Expedientes Rechazados" 
                                              Value="2" />
                                          <telerik:RadComboBoxItem runat="server" Text="Expedientes Digitalizados" 
                                              Value="3" />
                                          <telerik:RadComboBoxItem runat="server" Text="Expedientes Verificados" 
                                              Value="4" />
                                          <%--<telerik:RadComboBoxItem runat="server" Text="Expedientes en Transito" 
                                              Value="11" />--%>
                                          <telerik:RadComboBoxItem runat="server" Text="Pendientes de Recibidir" 
                                              Value="10" />
                                          <telerik:RadComboBoxItem runat="server" Text="Pendientes de Entrega" 
                                              Value="5" />
                                          <telerik:RadComboBoxItem runat="server" Text="Pendientes de Digitalizacion" 
                                              Value="7" />
                                          <telerik:RadComboBoxItem runat="server" Text="Pendientes de Verificar" 
                                              Value="8" />
                                      </Items>
                                    </telerik:RadComboBox>
                                </td>

                           </tr>
                           <tr>
                           <td colspan="8" align="right" class="table_td" id="BtnActualiza"><br />
                               <asp:Button ID="BtnActualiza" runat="server" Text="" BackColor="Transparent" BorderColor="Transparent" BorderStyle="None"  Display="False" />
                           </td>
                           
                           </tr>
                           <tr>
                                <td colspan ="5">
                                  <fieldset class="ficha_tramites">
                                   <table width="95%" border="0">
                                   <tr>
                                      <td align="left" style="border: solid 1px #BDBDBD;">
                                        <asp:Label ID="citas" ForeColor="White" Font-Size="Small" 
                                              Text="Recepción de Expediente:" runat="server"></asp:Label>
                                      </td>
                                      <td align="left" style="border: solid 1px #BDBDBD;">
                                         <asp:Label ID="lblRecepcionExpediente" Font-Size="Small" runat="server"></asp:Label>
                                      </td>
                                      <td align="left" style="border: solid 1px #BDBDBD;">
                                         <asp:Label ID="Label7" runat="server" ForeColor="White" Font-Size="Small" 
                                              Text="Expedientes Verificados:"></asp:Label>
                                      </td>

                                      <td align="left" style="border: solid 1px #BDBDBD;"> 
                                         <asp:Label ID="lblExpedientesVerificados" Font-Size="Small" runat="server"></asp:Label>
                                      </td>
                                      <td align="left" style="border: solid 1px #BDBDBD;">
                                         <asp:Label ID="lblPendientes" ForeColor="White" Font-Size="Small" runat="server" 
                                              Text="Digitalización de Expediente:"></asp:Label>
                                      </td>
                                       <td align="left" style="border: solid 1px #BDBDBD;">
                                         <asp:Label ID="lblDigitilizacionExpediente" Font-Size="Small" runat="server"></asp:Label>
                                      </td>
                                       <td align="left" style="border: solid 1px #BDBDBD;">
                                         <asp:Label ID="Label33" runat="server" ForeColor="White" Font-Size="Small" 
                                              Text="Expedientes Entregados:"></asp:Label>
                                       </td>
                                       <td align="left" style="border: solid 1px #BDBDBD;">
                                         <asp:Label ID="lblExpedientesEntregados" Font-Size="Small" runat="server"></asp:Label>
                                       </td>
                                       <td align="left" style="border: solid 1px #BDBDBD;">
                                         <asp:Label ID="Label34" runat="server" ForeColor="White" Font-Size="Small" 
                                              Text="Expedientes Rechazados:"></asp:Label>
                                       </td>
                                       <td align="left" style="border: solid 1px #BDBDBD;">
                                         <asp:Label ID="lblExpedientesRechazados" Font-Size="Small" runat="server"></asp:Label>
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
                            <telerik:RadButton ID="BtnDetRecepcion" runat="server" Text="Detalle Recepcion" 
                                Visible="False">
                            </telerik:RadButton>
                            <telerik:RadButton ID="BtnDetVerificacion" runat="server" 
                                Text="Detalle Verificacion">
                            </telerik:RadButton>
                            <telerik:RadButton ID="BtnDetDigitalizacion" runat="server" 
                                Text="Detalle Digitalizacion">
                            </telerik:RadButton>
                            <telerik:RadButton ID="BtnDetEntrega" runat="server" Text="Detalle Entrega">
                            </telerik:RadButton>
                        <telerik:RadXmlHttpPanel ID="panelGrid" Runat="server" CssClass="PanelGrid" Visible="true">
                            <telerik:RadGrid ID="radSeguimiento" CssClass="Grid" runat="server" BorderWidth="0px" 
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
        <telerik:GridBoundColumn DataField="TiempoTranscurrido" 
            FilterControlAltText="Filter Tiempo_Transcurridos column" HeaderText="Tiempo Transcurridos" 
            UniqueName="Tiempo_Transcurridos" EmptyDataText="">
        </telerik:GridBoundColumn>
        
        <telerik:GridBoundColumn DataField="TiempoTranscurridoRecepcion" 
            FilterControlAltText="Filter TiempoTranscurridoRecepcion column" 
            HeaderText="Tiempo Transcurrido Recepcion" 
            UniqueName="TiempoTranscurridoRecepcion">
        </telerik:GridBoundColumn>
        
        <telerik:GridButtonColumn CommandName="cmdRecepcion" 
            FilterControlAltText="Filter contactar column" HeaderText="Recepcion de Expediente" 
            Text="Recepcion" UniqueName="cmdRecepcion">
            <ItemStyle ForeColor="Blue" />
        </telerik:GridButtonColumn>
        <telerik:GridBoundColumn DataField="RecepcionExpediente" 
            FilterControlAltText="Filter RecepcionExpediente column" 
            UniqueName="RecepcionExpediente" EmptyDataText="" 
            HeaderText="Fecha Recepcion" DataFormatString="{0: dd/MM/yyyy}">
        </telerik:GridBoundColumn>
        <telerik:GridButtonColumn CommandName="cmdVerifica" 
            FilterControlAltText="Filter cmdAsignacion column" HeaderText="Verificacion del Expediente" 
            Text="Verifica" UniqueName="cmdVerifica">
            <ItemStyle ForeColor="Blue" />
        </telerik:GridButtonColumn>
        <telerik:GridBoundColumn DataField="VerificacionExpediente" 
            FilterControlAltText="Filter VerificacionExpediente column" 
            UniqueName="VerificacionExpediente" EmptyDataText="" 
            HeaderText="Fecha Verificacion" DataFormatString="{0: dd/MM/yyyy}">
        </telerik:GridBoundColumn>
        <telerik:GridButtonColumn CommandName="cmdDigitalizacion" 
            FilterControlAltText="Filter cmdDigitalizacion column" 
            HeaderText="Digitalizacion de Expediente" Text="Digitalizacion" 
            UniqueName="cmdDigitalizacion">
            <ItemStyle ForeColor="Blue" />
        </telerik:GridButtonColumn>
        <telerik:GridBoundColumn DataField="DigitalizacionExpediente" 
            FilterControlAltText="Filter DigitalizacionExpediente column" 
            UniqueName="DigitalizacionExpediente" EmptyDataText="" 
            HeaderText="Fecha Digitalizacion" DataFormatString="{0: dd/MM/yyyy}">
        </telerik:GridBoundColumn>
        <telerik:GridButtonColumn CommandName="cmdEntrega" 
            FilterControlAltText="Filter cmdEntrega column" 
            HeaderText="Entrega de Expediente Terminado" Text="Entrega" 
            UniqueName="cmdEntrega">
            <ItemStyle ForeColor="Blue" />
        </telerik:GridButtonColumn>
        <telerik:GridBoundColumn DataField="EntregaExpedienteTerminado" 
            FilterControlAltText="Filter EntregaExpedienteTerminado column" 
            UniqueName="EntregaExpedienteTerminado" EmptyDataText="" 
            HeaderText="Fecha Entrega" DataFormatString="{0: dd/MM/yyyy}">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn
            FilterControlAltText="Filter NúmeroRechazos column" HeaderText="Número de Desviaciones" 
            UniqueName="NúmeroRechazos" DataField="NúmeroRechazos" EmptyDataText="">
        </telerik:GridBoundColumn>

        <telerik:GridBoundColumn DataField="fecha_rechazo" 
            FilterControlAltText="Filter fecha_rechazo column" HeaderText="Fecha Desviación" 
            UniqueName="fecha_rechazo" DataFormatString="{0: dd/MM/yyyy}">
        </telerik:GridBoundColumn>

        <telerik:GridBoundColumn DataField="NúmeroRechazosAseg" 
            FilterControlAltText="Filter NúmeroRechazosAseg column" 
            HeaderText="Número Rechazos Aseg" UniqueName="NúmeroRechazosAseg">
        </telerik:GridBoundColumn>

        <telerik:GridBoundColumn DataField="EntregaExpediente_Guia" 
            FilterControlAltText="Filter EntregaExpediente_Guia column" 
            HeaderText="NumGuia" UniqueName="EntregaExpediente_Guia" EmptyDataText="">
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
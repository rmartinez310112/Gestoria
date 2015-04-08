<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PrimerContacto.aspx.vb" Inherits="AsignacionControl_PrimerContacto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
     <script type="text/javascript">

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
</head>
<body style="background-color:#999E9B; color:White; font-family:Arial; font-size:smaller">
    <form id="form1" runat="server">
    <div>
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td style="width:100px">
                    <asp:Label ID="lblContacto" runat="server" Text="Contacto:"></asp:Label>
                </td>
                <td style="width:100px">
                    <asp:Label ID="lbCliente" runat="server" Text="Cliente"></asp:Label>
                </td>
                <td style="width:100px"></td>
                <td style="width:100px"></td>
                <td style="width:100px"></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblLlamada" runat="server" Text="¿Llamada a Usuario?"></asp:Label>
                </td>
                <td colspan="3">
                    <asp:RadioButtonList ID="rdoUsuario" runat="server" 
                        RepeatDirection="Horizontal" AutoPostBack="True">
                        <asp:ListItem Value=1 Text="Efectivo" Selected="True" />
                        <asp:ListItem Value=2 Text="No Efectivo" />
                    </asp:RadioButtonList>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width:100px">&nbsp;</td>
                <td style="width:100px">&nbsp;</td>
                <td style="width:100px">&nbsp;</td>
                <td style="width:100px">&nbsp;</td>
                <td style="width:100px">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="5">&nbsp;
                    <asp:Panel ID="PanelNoefectivo" runat="server">
                    <div>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblMotivoNoEfectivo" runat="server" Text="Motivo:"></asp:Label>
                        &nbsp;&nbsp;
                        <telerik:RadComboBox ID="cboMotivoNoefectivo" runat="server" 
                            AutoPostBack="True">
                        </telerik:RadComboBox>
                    </div>
                        <br />
                        <div>
                            &nbsp;
                            <asp:Label ID="lblAccion" runat="server" Text="Accion Siguiente:"></asp:Label>
                            <asp:Label ID="lblAccionNoefectiva" runat="server" Text="Label"></asp:Label>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="PanelEfectivo" runat="server">
                       <a>-Buenos (as), Días, Tardes, Noches,
                        <br />
                           -Mi nombres es 
                            <asp:Label ID="lblUsuarioLlamada" runat="server" Text=""></asp:Label>,

                        <br />
                        <br />
                        Sr (a) 
                            <asp:Label ID="NombreAsegI" runat="server" Text="Label"></asp:Label> la financiera ha puesto a su disposición sin costo alguno el servicio de NR CONCIERGE "<asp:Label ID="Contrato" runat="server" Text="Label"></asp:Label>" asignándole personal experto en el proceso de reclamación de su siniestro, quien estará con usted hasta finalizar el trámite de la indemnización por parte de la Aseguradora, poniendo a su disposición el servicio de un GESTOR, quien:
</a>
                        <br />
                        <br />
                            1.- Revisara los documentos requeridos.

                        <br />  
                            2.- Gestiónara la obtencion de los documentos faltantes para la integración del expediente.

                        <br />
                        <br />
                            Para tal efecto coordinaremos una cita con nuestro Gestor y Usted,  puede  indicarnos Lugar, Fecha y Hora.

                        
                    </asp:Panel>
                    <asp:Panel ID="PanelFallecimiento" runat="server">
                       <a>-Buenos (as), Días, Tardes, Noches,
                        <br />
                           -Mi nombres es 
                            <asp:Label ID="Label4" runat="server" Text=""></asp:Label>,me comunico de NR Concierge, me podría comunicar con algún familiar del  Sr (a) 
                            <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>

                        <br />
                        <br />
                        Sr (a), Srita. (personalizar por apellido) El motivo de la llamada es dar seguimiento al proceso de indemnización por el fallecimiento del Sr (a)
                            <asp:Label ID="Label14" runat="server" Text="Label"></asp:Label>, entendiendo la situación por la que usted y su familia atraviesan ,
                        "<asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>"pone a su disposición, sin ningún costo el servicio de un gestor, con el objetivo de apoyarle en todo momento para agilizar el trámite de indemnización ante la aseguradora, a continuación le informaré la lista de documentos que se deberán recabar:
</a>
                        
                    </asp:Panel>
                </td>
                
            </tr>
            
        </table>


        <asp:Panel ID="divs" runat="server">
        <div id="div1">
                            <table>
                                <tr>
                                    <td ; colspan="2">
                                        <asp:Label ID="Label9" runat="server" Text="Desea agendar proxima llamada:"></asp:Label>
                                    </td>
                                     <td style="width:150px";>
                                         <asp:RadioButtonList ID="RdoClienteNextLlamada" runat="server" AutoPostBack="True" 
                                             RepeatDirection="Horizontal">
                                             <asp:ListItem Text="Si" Value="1" />
                                             <asp:ListItem Selected="True" Text="No" Value="2" />
                                         </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td ;="" style="width:150px">
                                        <asp:Label ID="lblFecha0" runat="server" Text="Fecha proxima llamada:"></asp:Label>
                                    </td>
                                    <td ;="" style="width:150px">
                                        <telerik:RadDatePicker ID="RadDatePicker2" Runat="server" MinDate="2014-05-15">
                                        </telerik:RadDatePicker>
                                    </td>
                                    <td ;="" style="width:150px">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td ;="" style="width:150px">
                                        <asp:Label ID="lblHorario0" runat="server" Text="Horario:"></asp:Label>
                                    </td>
                                    <td ;="" style="width:150px">
                                        <telerik:RadTimePicker ID="RadTimePicker2" Runat="server" Culture="es-MX">
                                            <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
                                            </Calendar>
                                            <DatePopupButton CssClass="" HoverImageUrl="" ImageUrl="" Visible="False" />
                                            <TimeView CellSpacing="-1" Culture="es-MX">
                                            </TimeView>
                                            <TimePopupButton CssClass="" HoverImageUrl="" ImageUrl="" />
                                            <DateInput DateFormat="HH:mm" DisplayDateFormat="HH:mm" 
                                                LabelWidth="64px" Width="">
                                                <EmptyMessageStyle Resize="None" />
                                                <ReadOnlyStyle Resize="None" />
                                                <FocusedStyle Resize="None" />
                                                <DisabledStyle Resize="None" />
                                                <InvalidStyle Resize="None" />
                                                <HoveredStyle Resize="None" />
                                                <EnabledStyle Resize="None" />
                                            </DateInput>
                                        </telerik:RadTimePicker>
                                    </td>
                                    <td ;="" style="width:150px">
                                        <asp:Button ID="btnProxLlamada" runat="server" Text="Guardar Proxima Llamada" />
                                    </td>
                                </tr>
                            </table>
                        </div>

                        <div id="div2">
                        <br />
                            <asp:Label ID="Label1" runat="server" Text="Usuario acepta servicio?"></asp:Label>
                            <asp:RadioButtonList ID="RdoClienteAcepta" runat="server" 
                                RepeatDirection="Horizontal" AutoPostBack="True">
                                <asp:ListItem Value=1  Text="Si" Selected="True" />
                                <asp:ListItem Value=2  Text="No" />
                                
                            </asp:RadioButtonList>
                        </div>
                        </asp:Panel>
        <div>
            <asp:Panel ID="PanelNoAceptaPreg" runat="server">
            <div>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblMotivoRechazo" runat="server" Text="Motivo:"></asp:Label>
                &nbsp;&nbsp;&nbsp;
                <telerik:RadComboBox ID="cboMotivoCanSer" runat="server" AutoPostBack="True">
                </telerik:RadComboBox>
                <br />
                <br />
                <asp:Label ID="lblAccionCancela" runat="server" Text="Accion Siguiente:"></asp:Label>
                <asp:Label ID="lblAccionCancelaServ" runat="server"></asp:Label>
            </div>
            </asp:Panel>
            <asp:Panel ID="PanelSiAceptaPreg" runat="server">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width:100px"></td>
                         <td colspan="2"><h3>Cita Tentativa</h3></td>
                           <td style="width:100px"></td>
                            <td style="width:100px"></td>
                    </tr>
                    <tr>
                        <td style="width:100px">
                            &nbsp;</td>
                        <td style="width:100px">
                            <asp:Label ID="Label8" runat="server" Text="Distribuidor:"></asp:Label>
                        </td>
                        <td colspan="2">
                            <telerik:RadComboBox ID="cboDistribuidor" runat="server" Culture="es-ES" 
                                Skin="Forest" Width="50%" AutoPostBack="True">
                                <Items>
                                    <telerik:RadComboBoxItem runat="server" Selected="True" 
                                        Text="Seleccione Distribuidor" Value="0" />
                                </Items>
                            </telerik:RadComboBox>
                        </td>
                        <td style="width:100px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            &nbsp;</td>
                        <td style="width: 100px">
                            <asp:Label ID="lblLugar" runat="server" Text="Lugar de la cita:"></asp:Label>
                        </td>
                        <td colspan="2">
                            <telerik:RadTextBox ID="txtLugar" Runat="server" TextMode="MultiLine" 
                                Width="300px">
                            </telerik:RadTextBox>
                        </td>
                        <td style="width: 100px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width:100px">
                            &nbsp;</td>
                        <td style="width:100px">
                            <asp:Label ID="lblFecha" runat="server" Text="Fecha de la cita:"></asp:Label>
                        </td>
                        <td style="width:100px">
                            <telerik:RadDatePicker ID="RadDatePicker1" Runat="server" MinDate="2014-05-15">
                            </telerik:RadDatePicker>
                        </td>
                        <td style="width:100px">
                            &nbsp;</td>
                        <td style="width:100px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width:100px">
                            &nbsp;</td>
                        <td style="width:100px">
                            <asp:Label ID="lblHorario" runat="server" Text="Horario:"></asp:Label>
                        </td>
                        <td style="width:100px">
                            <telerik:RadTimePicker ID="RadTimePicker1" Runat="server" Culture="es-MX">
                                <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
                                </Calendar>
                                <DatePopupButton CssClass="" HoverImageUrl="" ImageUrl="" Visible="False" />
                                <TimeView CellSpacing="-1" Culture="es-MX">
                                </TimeView>
                                <TimePopupButton CssClass="" HoverImageUrl="" ImageUrl="" />
                                <DateInput DateFormat="HH:mm" DisplayDateFormat="HH:mm" LabelWidth="64px" 
                                    Width="">
                                    <EmptyMessageStyle Resize="None" />
                                    <ReadOnlyStyle Resize="None" />
                                    <FocusedStyle Resize="None" />
                                    <DisabledStyle Resize="None" />
                                    <InvalidStyle Resize="None" />
                                    <HoveredStyle Resize="None" />
                                    <EnabledStyle Resize="None" />
                                </DateInput>
                            </telerik:RadTimePicker>
                        </td>
                        <td style="width:100px">
                            &nbsp;</td>
                        <td style="width:100px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width:100px">
                            &nbsp;</td>
                        <td style="width:100px">
                            <asp:Label ID="lblMotivo" runat="server" Text="Motivo:"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:Label ID="Label7" runat="server" Font-Names="Bernard MT Condensed" 
                                Font-Size="Medium" Text="Solicitud Documentos"></asp:Label>
                        </td>
                        <td style="width:100px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width:100px">
                            &nbsp;</td>
                        <td style="width:100px">
                            &nbsp;</td>
                        <td colspan="3">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width:100px">
                            &nbsp;</td>
                        <td colspan="3">
                            &nbsp;<a>Esta de acuerdo que le enviemos la información mediante correo electrónico sobre los documentos que requerirá para llevar a cabo el servicio.
 <br />
                                <br />
Acepta: Me permite corroborar su correo electrónico
 </a></td>
                        <td style="width:100px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width:100px">
                            &nbsp;</td>
                        <td style="width:100px">
                            &nbsp;</td>
                        <td style="width:100px">
                            &nbsp;</td>
                        <td style="width:100px">
                            &nbsp;</td>
                        <td style="width:100px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width:100px">
                            &nbsp;</td>
                        <td style="width:100px">
                            <asp:Label ID="Label2" runat="server" Text="No Acepta:"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:LinkButton ID="LinkButton1" runat="server">Informar Documentos para el tramite.</asp:LinkButton>
                        </td>
                        <td style="width:100px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width:100px">
                            &nbsp;</td>
                        <td style="width:100px">
                            <asp:Label ID="Label3" runat="server" Text="Correo Electronico:"></asp:Label>
                        </td>
                        <td style="width:100px">
                            <telerik:RadTextBox ID="TxtMail" Runat="server">
                            </telerik:RadTextBox>
                        </td>
                        <td style="width:100px">
                            &nbsp;</td>
                        <td style="width:100px">
                            <telerik:RadNotification ID="RadNotification" runat="server">
                            </telerik:RadNotification>
                        </td>
                    </tr>
                    <tr>
                        <td style="width:100px">
                            &nbsp;</td>
                        <td style="width:100px">
                            &nbsp;</td>
                        <td colspan="2">
                            <asp:CheckBox ID="chkEnvio" runat="server" 
                                Text="Envio de Informacio a usuario." />
                        </td>
                        <td style="width:100px">
                            <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
                            </telerik:RadScriptManager>
                        </td>
                    </tr>
                    <tr>
                        <td style="width:100px">
                            &nbsp;</td>
                        <td colspan="3">
                            Siguiente accion: contactar a Gestor</td>
                        <td style="width:100px">
                            &nbsp;</td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
        <div>
        
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
        
            <telerik:RadButton ID="btnGuardar" runat="server" Text="Guardar">
            </telerik:RadButton>
        
            <br />
            <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" 
                CellSpacing="0" Culture="es-ES" GridLines="None" Visible="False">
                <MasterTableView Font-Size="Smaller">
                <HeaderStyle ForeColor="White" Font-Bold="true" />
                    <Columns>
                        <telerik:GridBoundColumn DataField="documentos_descrip" 
                            FilterControlAltText="Filter documentos_descrip column" HeaderText="Documento" 
                            UniqueName="documentos_descrip">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="documentos_notas" 
                            FilterControlAltText="Filter documentos_notas column" 
                            HeaderText="Observaciones" UniqueName="documentos_notas">
                        </telerik:GridBoundColumn>
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>
        
        </div>
    </div>
    </form>
</body>
</html>

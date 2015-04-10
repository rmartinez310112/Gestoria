<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RemesaRecepcionDocumentos.aspx.vb" Inherits="AsignacionControl_SegACita" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">  
        <script type="text/javascript">
            {

                function VALIDATEME(sender, args) {

                    args.set_cancel(!window.confirm('Validate?'));

                }

                function VerificaCombo() {
                    var combo = $find('<%= rdIdMotivoNE.ClientID %>');
                    //var ddlCurrency = document.getElementById(combo);
                    //var selectedValue = ddlCurrency.control._value;
                    if (combo.control._value = "")
                        alert("Seleccione Motivo")
                }
              
                function ValidateCombo(combo) {
                    var isValid = false;
                    var text = combo.get_text();
                    var item = combo.findItemByText(text);
                    if (item) {
                        isValid = true;
                    }
                    return isValid;
                }
            
//                 function Navegar_Return() {
//                    window.top.location.replace('../AsignacionControl/Seguimiento.aspx');
//                }

                function GetRadWindow() {
                    var oWindow = null;

                    try {
                        if (window.radWindow) oWindow = window.radWindow;
                        else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;

                        return oWindow;
                    } catch (e) {
                    }
                }

                function onBeforeWindowClose(oWinow, args) {
                    function callbckFunction(confirmResult) {
                        if (confirmResult) {// confirmResult == true
                            // Close this RadWindow
                            // First remove the handler in order to avoid recursion
                            oWinow.remove_beforeClose(onBeforeWindowClose);

                            // Close the window
                            oWinow.close();

                            // Reattach the handles after the window is closed.
                            // RECOMMENDATION: If the DestroyOnClose="true" property is set in in the RadWindow's declaration,
                            // then remove this line of the code:
                            //oWinow.add_beforeClose(onBeforeWindowClose);
                        }
                        //                else {
                        //                // confirmResult == false
                        //                    radalert("Closing is canceled");
                        //                }
                    }
                    // Cancel closing
                    args.set_cancel(true);

                    // Show a rad confirmation dialog
                    radconfirm("¿ Cerrar Ventana ?", callbckFunction, 300, 200, null, "Seguimiento");
                }

                function CloseModal() {

                    // GetRadWindow().close();

                    setTimeout(function () {

                        GetRadWindow().close();

                    }, 0);

                }
                function onClientBeforeClose(sender, arg) {
                    function callbackFunction(arg) {
                        if (arg) {
                            sender.remove_beforeClose(onClientBeforeClose);
                            sender.close();
                        }
                    }
                    arg.set_cancel(true);
                    radconfirm("Are you sure", callbackFunction, 300, 100, null, "Close RadWindow");
                }

                function Cerrar() {
                    var oWindow = GetRadWindow();
                    oWindow.close();
                }

                function CloseDialog(button) {
                    GetRadWindow().close();
                }
                function ConfirmClose(WinName) {
                    var oManager = GetRadWindowManager();
                    var oWnd = oManager.GetWindowByName(WinName);
                    //Find the Close button on the page and attach to the 
                    //onclick event
                    var CloseButton = document.getElementById("CloseButton" + oWnd.Id);
                    CloseButton.onclick = function () {
                        CurrentWinName = oWnd.Id;
                        //radconfirm is non-blocking, so you will need to provide a callback function
                        radconfirm("Are you sure you want to close the window?", confirmCallBackFn);
                    }
                }
                function confirmCallBackFn(arg) {
                    if (arg == true) {
                        var oManager = GetRadWindowManager();
                        var oWnd = oManager.GetWindowByName(CurrentWinName);
                        oWnd.Close();
                    }
                }
                function pageLoad() {
                    // Get the RadWindoiw object that contains this page
                    var oWindow = GetRadWindow();

                    // Attach RadWindow's OnClientBeforeClose handler
                    oWindow.add_beforeClose(onBeforeWindowClose);
                }
                function pageUnload() {
                    // Get the RadWindoiw object that contains this page
                    var oWindow = GetRadWindow();

                    // NOTE! If the DestroyOnClose="true" is set in the RadWindow's declaration,
                    // then the oWindow object will be 'null'.
                    if (oWindow) {
                        // Detach RadWindow's OnClientBeforeClose handler
                        oWindow.remove_beforeClose(onBeforeWindowClose);
                    }
                }


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

            }
        </script>
    </telerik:RadScriptBlock> 
    <style type="text/css">
        .style1
        {
            height: 23px;
        }
    </style>
</head>
<body style="background-color:#999E9B; color:White; font-family:Arial; font-size:smaller">
<form id="form1" runat="server">
<telerik:RadScriptManager EnablePartialRendering="true" ID="RadScriptManager1" runat="server">
</telerik:RadScriptManager>
<%--Ventanas modales --%>
            <telerik:RadWindowManager ID="RadWindowManager" runat="server">
            </telerik:RadWindowManager>
            <telerik:RadNotification ID="RadNotification"   runat="server">
                                    </telerik:RadNotification>
   <div>
   <fieldset id="fset" runat="server">
      <table width="100%">
         <tr>
             <td style="width:20%">
                 <asp:Label ID="lblIdCliente" runat="server" Text="Contácto:"></asp:Label>
             </td> 
             <td>
                <telerik:RadComboBox ID="rdIdCliente" AutoPostBack="true" runat="server"></telerik:RadComboBox>
             </td>
             <td align="right">
                <asp:ImageButton ID="ImgGestor" runat="server" Height="30px" 
                                        ImageUrl="~/Imagenes/gestorDatos.jpg" ToolTip="Consultar Datos del Gestor" 
                                        Width="40px" Visible="false"/>
             </td>
         </tr>
         <tr>
         
           <td>
            <asp:Label ID = "numllamadas" text="Número de Cita:" runat="server" Visible="false" Font-Italic="true"></asp:Label>
           </td>
           <td colspan="2">
            <asp:Label  ID="lblNumllamadas" runat="server" Visible="false"></asp:Label>
           </td>
         </tr>
         <tr>
         <td colspan="3">
         <asp:Label ID="lblsr" runat="server" Visible="false"></asp:Label>
           <asp:Label ID="lblTexto" runat="server" Visible="false"></asp:Label> 
                 <asp:Label ID = "Texto" runat="server" Visible = "false"></asp:Label>
                 
         </td>
         </tr>
         <tr>
            <td>
            <asp:Label ID="lblTipoLlamada" runat="server" Text="Tipo de Llamada:"></asp:Label>
            </td>
            
            <td class="style16" colspan="2" align="left">
                                    <asp:RadioButtonList ID="RadioButtonList1" Enabled="false" runat="server" 
                                        RepeatDirection="Horizontal" AutoPostBack="True">
                                        <asp:ListItem Value="1" Selected="False">Efectiva</asp:ListItem>
                                        <asp:ListItem Value="2" Selected="False">No Efectiva</asp:ListItem>
                                    </asp:RadioButtonList>
            </td>
         </tr>
        
        <tr>
            <td colspan="3">
                <asp:Panel ID="PanelNoEfectiva" runat="server" Visible="False">
                        <table width="100%">
                            <tr>
                                <td colspan="2" align="justify">&nbsp;</td>
                            </tr>
                              
                            <tr>
                                  <td style="width:20%">
                                      <asp:Label ID="Label1" runat="server" Text="Motivo:"></asp:Label>
                                  </td>
                                  <td align="left">
                                       <telerik:RadComboBox ID="rdIdMotivoNE" runat="server" AutoPostBack="true"
                                           style="height: 16px">
                                       </telerik:RadComboBox>
                                  </td>
                            </tr>
                            
                            <tr>
                                  <td style="width:20%">
                                     <asp:Label ID="Label2" runat="server" Text="Acción Siguiente:"></asp:Label>
                                  </td>
                                  <td align="left">
                                  <asp:Label ID="lblAccionSigNE" runat="server" ForeColor="Gray" Text="----"></asp:Label>
                                  </td>
                            </tr>
                            <tr>
                                <td style="width:20%">
                                    <asp:Label ID="Label4" runat="server" Text="Fecha de Registro:"></asp:Label>
                                </td>
                                <td align="left"> 
                                     <asp:Label ID="lblFechaRegistro" runat="server" ></asp:Label>
                                </td>
                              </tr>
                              <tr>
                                  <td style="width:20%">
                                      <asp:Label ID="Label5" runat="server" Text="Usuario Registro:"></asp:Label>
                                  </td>
                                  <td align="left">
                                      <asp:Label ID="lblUsuarioRegistro" runat="server" ></asp:Label>
                                  </td>
                              </tr>

                               <tr>
                                    <td colspan="2">
                                    <br />
                                    </td>
                               </tr>
                               <tr>
                                   <td style="width:20%"></td>
                                   <td align="left">
                                    <telerik:RadButton runat="server" Text="Guardar" ID="btnGuardarNE">
                                    </telerik:RadButton>
                                   </td>
                               </tr>
                        </table>
                </asp:Panel>
                <%--<asp:UpdatePanel ID="panelNE" runat="server" UpdateMode="Conditional">
              <ContentTemplate>
                    <uc1:PNE id="PNE" runat="server" Visible="false" UpdateMode="Conditional"/>
                    <uc2:PE id="PE" runat="server" Visible="false" UpdateMode="Conditional"/>
              </ContentTemplate>
             </asp:UpdatePanel>--%>
            </td>
        </tr>
        <tr>
                <td colspan="3">
                    <asp:Panel ID="PanelEfectiva" runat="server" Visible="False">
                        <table width="100%">
                              <tr>
                                  <td colspan="2">
                                      <asp:Label ID="Label6" runat="server" Text="Detalle de la Cita:"></asp:Label>
                                  </td>
                              </tr>
                             
                             <tr>

                                 <td colspan="2">
                                    <br />
                                 </td>
                            </tr>
                            <tr>
                                  <td style="width:20%">
                                     <asp:Label ID="lblLugarCita" runat="server" Text="Lugar de la Cita"></asp:Label>
                                  </td>
                                  <td align="left">
                                  <asp:Label ID="lbLugarCita" runat="server"></asp:Label>
                                  </td>
                            </tr>
                            <tr>
                                <td style="width:20%">
                                    <asp:Label ID="Label9" runat="server" Text="Fecha y hora de la Cita:"></asp:Label>
                                </td>
                                <td align="left"> 
                                     <asp:Label ID="lbFechaCita" runat="server" ></asp:Label>
                                </td>
                            </tr>
                            
                             <tr>
                                  <td style="width:20%">
                                      <asp:Label ID="Label11" runat="server" Text="Gestor:"></asp:Label>
                                  </td>
                                  <td align="left">
                                      <asp:Label ID="lbGestor" runat="server"></asp:Label>
                                  </td>
                             </tr>

                             <tr>
                                  <td style="width:20%">
                                      <asp:Label ID="Label12" runat="server" Text="Motivo:"></asp:Label>
                                  </td>
                                  <td align="left">
                                     <%--<telerik:RadComboBox  ID="rdIDMotivo" runat="server"></telerik:RadComboBox>--%>
                                     <asp:Label ID="Label3" runat="server" ForeColor="Gray" Text="Revisión de Documentos."></asp:Label>
                                  </td>
                             </tr>

                             <tr>
                                  <td style="width:20%">
                                      <asp:Label ID="Label13" runat="server" Text="Asistir a la Cita:"></asp:Label>
                                  </td>
                                   <td align="left">
                                        <asp:RadioButtonList ID="AsisteCita" runat="server" 
                                            RepeatDirection="Horizontal" AutoPostBack="True">
                                            <asp:ListItem Value="1">Si</asp:ListItem>
                                            <asp:ListItem Value="2">No</asp:ListItem>
                                        </asp:RadioButtonList>
                                   </td>
                             </tr>
                              <tr>
                                  <td align="right" style="width:20%">
                                      <asp:CheckBox ID="ReqCita0" runat="server" AutoPostBack="true" 
                                          Font-Size="Smaller" ForeColor="Blue" Text="¿ Requiere otra Cita ?" 
                                          Visible="false" />
                                  </td>
                                  <td align="left">
                                      &nbsp;</td>
                              </tr>
                          </table>
                    </asp:Panel>
                </td>
        </tr>

        <tr>
                <td colspan="3">
                    <asp:Panel ID="panelGestorSiAsis" runat="server" Visible="False">
                        <table width="100%">
                            <tr>
                                  <td style="width:20%">
                                      <asp:Label ID="Label8" runat="server" Text="Cita Concretada:"></asp:Label>
                                  </td>
                                   <td align="left">
                                        <asp:RadioButtonList ID="rlCitaConcret" runat="server" 
                                            RepeatDirection="Horizontal" AutoPostBack="True">
                                            <asp:ListItem Value="1">Si</asp:ListItem>
                                            <asp:ListItem Value="2">No</asp:ListItem>
                                        </asp:RadioButtonList>
                                   </td>
                             </tr>
                             <tr>
                                  <td align="right" style="width:20%">
                                      <asp:CheckBox runat="server" ID="ReqCita" ForeColor="Blue" Font-Size="Smaller" Visible="false" Text="¿ Requiere otra Cita ?" AutoPostBack="true" />
                                  </td>
                                  <td align="left">
                                  </td>
                             </tr>
                          </table>
                    </asp:Panel>
                </td>
        </tr>

        <tr>
              <td colspan="3">
                 <asp:Panel ID="panelSiConcreta" runat="server" Visible="False">
                        <table width="100%">
                               <tr>
                                  <td style="width:20%">
                                      <asp:Label ID="Label7" runat="server" Text="IFE:"></asp:Label>
                                  </td>
                                  <td>
                                   <telerik:RadTextBox  ID="radtbIFE" runat="server"></telerik:RadTextBox>
                                  </td>
                               </tr>
  
                              <tr>
                                   <td style="width:20%">
                                          <asp:Label ID="Label10" runat="server" Text="Acuerdo:"></asp:Label>
                                   </td>
                                   <td>
                                       <telerik:RadTextBox  ID="radtbAcuerdo" runat="server"></telerik:RadTextBox>
                                   </td>
                              </tr>

                              <tr>
                                   <td style="width:20%">
                                          <asp:Label ID="Label15" runat="server" Text="Acción siguiente:"></asp:Label>
                                   </td>
                                   <td>
                                          <asp:Label ID="lblas" runat="server" ForeColor="Gray" 
                                              Text="Pendiente Seguimiento a Trámite"></asp:Label>
                                   </td>
                              </tr>
                              <tr>
                                  <td style="width:20%"></td>
                                      <td align="left">
                                       <telerik:RadButton runat="server" ID="rbSiCitaconcretada" Text="Guardar"></telerik:RadButton>
                                      </td>
                                  </tr>

                        </table>
                 </asp:Panel>
              </td>
        </tr>


        <tr>
              <td colspan="3">
                 <asp:Panel ID="panelGestor" runat="server" Visible="False">
                        <table width="100%">
                               <tr>
                                  <td style="width:20%">
                                      <asp:Label ID="Label19" runat="server" Text="Motivo:"></asp:Label>
                                  </td>
                                  <td>
                                   <telerik:RadComboBox Width="260px" ID="cmbGestor" runat="server" AutoPostBack="true"></telerik:RadComboBox>
                                  </td>
                               </tr>
  
                              <tr>
                                   <td style="width:20%">
                                          <asp:Label ID="Label20" runat="server" Text="Acción Siguiente:"></asp:Label>
                                   </td>
                                   <td align="left">
                                       <asp:Label ID="lblASGestor" runat="server" ForeColor="Gray" Text="----"></asp:Label>
                                   </td>
                              </tr>
                              <tr>
                                  <td style="width:20%"></td>
                                      <td align="left">
                                       <telerik:RadButton runat="server" ID="btnGuardaGestor" Text="Guardar"></telerik:RadButton>
                                      </td>
                              </tr>
                        </table>
                 </asp:Panel>
              </td>
        </tr>

        <tr>
               <td colspan="3">
                 <asp:Panel ID="PanelSiAsis" runat="server" Visible="False">
                    <table width="100%">
                          <tr>
                              <td style="width:20%" class="style1">
                                 <asp:Label ID="Label14" runat="server" Text="Acción Siguiente:"></asp:Label>
                              </td>
                              <td class="style1">
                              <asp:Label ID="lblSigAccNE" runat="server" ForeColor="Gray" 
                                      Text="Seguimiento a, resultado de la cita. Contacto con Cliente."></asp:Label>
                              </td>
                          </tr>
                          <tr>
                            <td style="width:20%">
                                <asp:Label ID="Label16" runat="server" Text="Fecha Registro:"></asp:Label>
                            </td>
                            <td> 
                                 <asp:Label ID="lblAsistFechaReg" runat="server"></asp:Label>
                            </td>
                          </tr>
                          <tr>
                              <td style="width:20%">
                                  <asp:Label ID="Label18" runat="server" Text="Usuario Registro:"></asp:Label>
                              </td>
                          <td>
                              <asp:Label ID="lblAsistUsuarioRegistro" runat="server"></asp:Label>
                          </td>
                          </tr>

 
                          <tr>
                          <td colspan="2">
                          <br />
                          </td>
                          </tr>
  
                          <tr>
                          <td style="width:20%"></td>
                              <td align="left">
                               <telerik:RadButton runat="server" ID="btnESiAsis" Text="Guardar"></telerik:RadButton>
                              </td>
                          </tr>
                    </table>
                 </asp:Panel>
               </td>
        </tr>
        
        <tr>
              <td colspan="3">
                 <asp:Panel ID="PanelNoCancela" runat="server" Visible="False">
                    <table width="100%">
                       <tr>
                          <td style="width:30%">
                              <asp:Label ID="lblReprogramacion" runat="server" Text="Motivo:"></asp:Label>
                          </td>
                          <td>
                           <telerik:RadComboBox  ID="cmbMotRep" Width="260px" runat="server" AutoPostBack="true"></telerik:RadComboBox>
                          </td>
                       </tr>
  
                      <tr>
                           <td style="width:30%">
                                  <asp:Label ID="Label24" runat="server" Text="Lugar de cita:"></asp:Label>
                           </td>
                           <td>
                               <telerik:RadTextBox  ID="TbLugarCita" runat="server"></telerik:RadTextBox>
                               <asp:Label ID="lbLugarCita0" runat="server"></asp:Label>
                           </td>
                      </tr>

                      <tr>
                            <td style="width:30%">
                               <asp:Label ID="lblFechaRep" Text="Fecha Reprogramación:" runat="server"></asp:Label>
                            </td>
                            <td>
                               <telerik:RadDatePicker ID="RDPFechaRep" runat="server">
                               </telerik:RadDatePicker>
                                <asp:Label ID="lbFechaCita0" runat="server"></asp:Label>
                            </td>
                      </tr>
  
                      <tr>
                          <td style="width:30%">
                             <asp:Label ID="Label25" runat="server" Text="Hora de Reprogramación:"></asp:Label>
                          </td>
                          <td>
                              <telerik:RadTimePicker ID="RadTimePicker1" runat="server">
                              </telerik:RadTimePicker>
                          </td>
                      </tr>
                      <tr>
                          <td style="width:30%">
                              <asp:Label ID="lblAccion" runat="server" Text="Acción Siguiente:"></asp:Label>
                          </td>
                          <td>
                            <asp:Label ID="lblAccionSiguiente" runat="server" Text="-----"></asp:Label>
                          </td>
                      </tr>

                      <tr>
                           <td style="width:30%">
                             <asp:Label ID="Label26" runat="server" Text="Fecha Registro:"></asp:Label>
                           </td>
                           <td>
                             <asp:Label ID="lblFechaRPanelNoCancela" runat="server"></asp:Label>
                           </td>
                      </tr>

                      <tr>
                           <td style="width:30%">
                              <asp:Label ID="Label28" runat="server" Text="Usuario Registro:"></asp:Label>
                           </td>
                           <td>
                              <asp:Label ID="lblUsuarioPanelNoCancela" runat="server"></asp:Label>
                           </td>
                      </tr>

                      <tr>
                            <td style="width:30%"></td>
                            <td align="left">
                              <telerik:RadButton ID="RadButton1" runat="server" Text="Guardar"></telerik:RadButton>
                            </td>
                      </tr>
                    </table>
                 </asp:Panel>
              </td>
        </tr>
      </table>
      </fieldset>
   </div>
</form>
</body>
</html>

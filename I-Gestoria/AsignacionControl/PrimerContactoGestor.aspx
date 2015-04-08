<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PrimerContactoGestor.aspx.vb" Inherits="AsignacionControl_PrimerContactoGestor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
<body style="background-color:#B7CBAC; color:White; font-family:Arial; font-size:smaller">
    <form id="form1" runat="server">
    <div>
        <table style="width:100%">
            <tr>
                <td style="width:20%;"></td>
                <td style="width:20%;"></td>
                <td style="width:20%;"></td>
                <td style="width:20%;"></td>
                <td style="width:20%;"></td>
            </tr>
            <tr>
                <td style="width:20%;">
                    <asp:Label ID="Label1" runat="server" Text="Contacto:"></asp:Label>
                </td>
                <td style="width:20%; font-size:medium;font-style:oblique;font-weight:bold">
                    <asp:Label ID="lblGestor" Enabled="false" runat="server" Text="Gestor"></asp:Label>
                </td>
                <td style="width:20%;">&nbsp;</td>
                <td style="width:20%;">&nbsp;</td>
                <td style="width:20%;">&nbsp;</td>
            </tr>
            <tr>
                <td style="width:20%;">
                    <asp:Label ID="Label2" runat="server" Text="Motivo de la Cita:"></asp:Label>
                </td>
                <td style="width:20%;">
                    <asp:Label ID="lblMotivoCita" runat="server" Text="Label"></asp:Label>
                </td>
                <td style="width:20%;">&nbsp;</td>
                <td style="width:20%;">&nbsp;</td>
                <td style="width:20%;">&nbsp;</td>
            </tr>
            <tr>
                <td style="width:20%;">
                    <asp:Label ID="Label3" runat="server" Text="Lugar de la Cita:"></asp:Label>
                </td>
                <td style="width:20%;">
                    <asp:Label ID="lblLugarCita" runat="server" Text="Label"></asp:Label>
                </td>
                <td style="width:20%;">
                    <asp:Label ID="Label4" runat="server" Text="Fecha y Hora de la Cita:"></asp:Label>
                </td>
                <td style="width:20%;">
                    <asp:Label ID="lblFechaCita" runat="server" Text="Label"></asp:Label>
                </td>
                <td style="width:20%;">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label ID="Label5" runat="server" Text="Gestores de acuerdo a la Cita:"></asp:Label>
                </td>
                <td style="width:20%;">&nbsp;</td>
                <td style="width:20%;">&nbsp;</td>
            </tr>
            <tr>
                <td style="width:20%;">
                    <asp:Label ID="Label6" runat="server" Text="Estado:"></asp:Label>
                </td>
                <td style="width:20%;">
                    <telerik:RadComboBox ID="cboEstado" Runat="server" AutoPostBack="True">
                    </telerik:RadComboBox>
                </td>
                <td colspan="2">
                    <asp:RadioButtonList ID="rdoGesCita" RepeatDirection="Horizontal" 
                        runat="server" AutoPostBack="True" 
                        ToolTip="Todos: mostrara los gestores asignados al estado. Disponible: Mostrara unicamente los gestores sin cita en esa fecha y hora">
                        <asp:ListItem Value=1 Text="Todos" />
                        <asp:ListItem Value=2 Text="Disponibles" />
                    </asp:RadioButtonList>
                </td>
                <td style="width:20%;">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="Label10" runat="server" 
                        Text="Por favor elija el Gestor para Asignación:"></asp:Label>
                </td>
                <td colspan="2">
                    &nbsp;</td>
                <td style="width:20%;">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="5">
                    <telerik:RadGrid ID="grdiGestores" runat="server" AutoGenerateColumns="False" 
                        CellSpacing="0" Culture="es-ES" GridLines="None" Skin="Forest">
<MasterTableView Font-Size="Smaller">
<HeaderStyle  ForeColor="White" Font-Bold="true"/>
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
<HeaderStyle Width="20%"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
<HeaderStyle Width="20%"></HeaderStyle>
</ExpandCollapseColumn>

    <Columns>
        <telerik:GridButtonColumn CommandName="cmdRfc" 
            FilterControlAltText="Filter rfc column" 
            UniqueName="rfc" ButtonType="PushButton" Text="seleccione">
        </telerik:GridButtonColumn>
        <telerik:GridBoundColumn DataField="RFCAJUSTADOR" 
            FilterControlAltText="Filter cmdRfc column" HeaderText="RFC" 
            UniqueName="rfc1">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="NOMBRE" 
            FilterControlAltText="Filter column1 column" HeaderText="Nombre" 
            UniqueName="column1">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="PATERNO" 
            FilterControlAltText="Filter column2 column" HeaderText="Paterno" 
            UniqueName="column2">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="CELULAR" 
            FilterControlAltText="Filter column3 column" HeaderText="Celular" 
            UniqueName="column3">
        </telerik:GridBoundColumn>
	<telerik:GridBoundColumn DataField="TELNEX" 
            FilterControlAltText="Filter TELNEX column" HeaderText="Nextel" 
            UniqueName="TELNEX">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="TEL1" 
            FilterControlAltText="Filter column4 column" HeaderText="Telefono 1" 
            UniqueName="column4">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="TEL2" 
            FilterControlAltText="Filter column5 column" HeaderText="Telefono 2" 
            UniqueName="column5">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="TEL3" 
            FilterControlAltText="Filter column6 column" HeaderText="Telefono 3" 
            UniqueName="column6">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="TEL4" 
            FilterControlAltText="Filter column7 column" HeaderText="Telefono 4" 
            UniqueName="column7">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Nombre_mpio" 
            FilterControlAltText="Filter column column" HeaderText="Municipio" 
            UniqueName="column">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="cuenta" 
            FilterControlAltText="Filter column8 column" HeaderText="Servicios" 
            UniqueName="column8">
        </telerik:GridBoundColumn>
    </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
</MasterTableView>

<FilterMenu EnableImageSprites="False"></FilterMenu>
                    </telerik:RadGrid>
                </td>
            </tr>
            <tr>
                <td colspan="5">
                <a>Sr (a) 
                    <asp:Label ID="lblNombreGestorLlamada" runat="server" Text=""></asp:Label> Buenos días / tardes / noches, mi nombre es 
                    <asp:Label ID="lblNombreUsuarioLlamada" runat="server" Text=""></asp:Label> nos comunicamos de BENEFICIA.MX, para solicitarle la  atencion del siguiente servicio. 
</a>
                    </td>
            </tr>
            <tr>
                <td >
                    <asp:Label ID="Label7" runat="server" Text="Llamada a Gestor?"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:RadioButtonList ID="rdoUsuario" runat="server" 
                        RepeatDirection="Horizontal" AutoPostBack="True">
                        <asp:ListItem Value=1 Text="Efectivo" />
                        <asp:ListItem Value=2 Text="No Efectivo" />
                    </asp:RadioButtonList>
                    
                </td>
               
            </tr>
            <tr><td>
            
            </td></tr>
        </table>
    </div>
    <div>
    
    <div>
        <asp:Panel ID="PanelNoefectivo" runat="server">
                    <div style="text-align:center">
                        <asp:Label ID="lblMotivoNoEfectivo" runat="server" Text="Motivo:"></asp:Label>
                        &nbsp;&nbsp;
                        <telerik:RadComboBox ID="cboMotivoNoefectivo" runat="server" 
                            AutoPostBack="True">
                        </telerik:RadComboBox>
                    </div>
                        <br />
                        <div style="text-align:center">
                            <asp:Label ID="lblAccion" runat="server" Text="Accion Siguiente:"></asp:Label>
                            <asp:Label ID="lblAccionNoefectiva" runat="server"></asp:Label>
                        </div>
                    </asp:Panel>
    </div>
        <div>
            <asp:Panel ID=PanelGestorAcepSer runat="server">
            <table>
            <tr><td>
            <a>El Gestor acepta el Servicio?</a>
            </td>
            <td>
            
                <asp:RadioButtonList ID="rdoGestorAcepta" RepeatDirection="Horizontal" 
                    runat="server" AutoPostBack="True">
                    <asp:ListItem Value=1 Text="Si" />
                    <asp:ListItem Value=2 Text="No" />
                </asp:RadioButtonList>
            
            </td>
            </tr>
            </table>
            </asp:Panel>
        </div>
        <div>
            <asp:Panel ID="PanelNoAcepSer" runat="server">
                <table style="width:100%">
                    <tr>
                        <td style="width:33%">
                        </td>
                        <td>
                            <asp:Label ID="Label8" runat="server" Text="Motivo por el cual no se Asignara:"></asp:Label>
                            &nbsp;
                            <telerik:RadComboBox ID="cboMotRechaGes" Runat="server" AutoPostBack="True">
                            </telerik:RadComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width:33%">
                            &nbsp;</td>
                        <td>
                            <asp:Label ID="Label9" runat="server" Text="Accion Siguiente:"></asp:Label>
                            &nbsp;
                            <asp:Label ID="lblAccionNoAcep" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>

    <div>
        <asp:Panel ID="PaneEfectivo" runat="server">
            <table style="width:100%">
            <tr>
                    <td colspan="4">
                    <h3>Proporcionar Datos del servicio al Gestor:</h3>
                    </td>
                </tr>
                <tr>
                    <td style="width:25%">
                        &nbsp;</td>
                    <td style="width:25%">
                        &nbsp;</td>
                    <td style="width:25%">
                        &nbsp;</td>
                    <td style="width:25%">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width:25%">
                    <a>No. de Servicio:</a>
                        &nbsp;</td>
                    <td style="width:25%">
                        <asp:Label ID="lblServicio" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td style="width:25%">
                        &nbsp;</td>
                    <td style="width:25%">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width:25%">
                    <a>Contrato:</a>
                        &nbsp;</td>
                    <td style="width:25%">
                        <asp:Label ID="lblContrato" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td style="width:25%">
                        &nbsp;</td>
                    <td style="width:25%">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width:25%">
                    <a>Tipo de Servicio:</a>
                        &nbsp;</td>
                    <td style="width:25%">
                        <asp:Label ID="lblTipo" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td style="width:25%">
                        &nbsp;</td>
                    <td style="width:25%">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width:25%">
                    <a>Nombre del Cliente:</a>
                        &nbsp;</td>
                    <td style="width:25%">
                        <asp:Label ID="lblCliente" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td style="width:25%">
                        &nbsp;</td>
                    <td style="width:25%">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width:25%">
                        &nbsp;</td>
                    <td style="width:25%">
                        &nbsp;</td>
                    <td style="width:25%">
                        &nbsp;</td>
                    <td style="width:25%">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4">
                    <h3>Cita Tentativa:</h3>
                       </td>
                </tr>
                <tr>
                    <td style="width:25%">
                        &nbsp;</td>
                    <td style="width:25%">
                        &nbsp;</td>
                    <td style="width:25%">
                        &nbsp;</td>
                    <td style="width:25%">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width:25%">
                    <a>Lugar de Cita:</a>
                        &nbsp;</td>
                    <td style="width:25%">
                        <asp:Label ID="lblLugar" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td style="width:25%">
                        &nbsp;</td>
                    <td style="width:25%">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width:25%">
                    <a>Fecha de Cita:</a>
                        &nbsp;</td>
                    <td style="width:25%">
                        <asp:Label ID="lblFecha" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td style="width:25%">
                        &nbsp;</td>
                    <td style="width:25%">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width:25%">
                    <a>Hora de Cita:</a>
                        &nbsp;</td>
                    <td style="width:25%">
                        <asp:Label ID="lblHora" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td style="width:25%">
                        &nbsp;</td>
                    <td style="width:25%">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width:25%">
                        &nbsp;</td>
                    <td style="width:25%">
                        &nbsp;</td>
                    <td style="width:25%">
                        &nbsp;</td>
                    <td style="width:25%">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width:25%">
                    <a>Motivo:</a>
                        &nbsp;</td>
                    <td style="width:25%">
                        <asp:Label ID="lblMotivo" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td style="width:25%">
                        &nbsp;</td>
                    <td style="width:25%">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:CheckBox ID="CheckBox1" runat="server" 
                            Text="Envio de Notificacion a Usuario" />
                        <telerik:RadTextBox ID="txtMailCliente" Runat="server">
                        </telerik:RadTextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:CheckBox ID="CheckBox2" runat="server" 
                            Text="Envio de Notificacion de Correo al Gestor" />
                        <telerik:RadTextBox ID="txtMailGestor" Runat="server">
                        </telerik:RadTextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width:25%">
                        &nbsp;</td>
                    <td style="width:25%">
                        &nbsp;</td>
                    <td style="width:25%">
                        &nbsp;</td>
                    <td style="width:25%">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width:25%">
                        &nbsp;</td>
                    <td style="width:25%">
                        &nbsp;</td>
                    <td style="width:25%">
                        &nbsp;</td>
                    <td style="width:25%">
                        <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
                        </telerik:RadScriptManager>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    <div style="text-align:right;width:100%">
        <telerik:RadButton ID="btnGuardar"  runat="server" Text="Guardar">
        </telerik:RadButton>
         <telerik:RadNotification ID="RadNotification"   runat="server">
                                    </telerik:RadNotification>
        </div>
    </div>
    </form>
</body>
</html>

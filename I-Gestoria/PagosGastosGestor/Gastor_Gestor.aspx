<%@ Page Language="VB" MasterPageFile="~/MasterPageGestionOperativa.master" AutoEventWireup="false" CodeFile="Gastor_Gestor.aspx.vb" Inherits="PagosGastosGestor_Gastor_Gestor" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <div>
        <table>
            <tr>
                <td class="style3">
                    <asp:Label ID="Label4" runat="server" Font-Size="20pt" 
                        Text="Control de Gastos"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        <table cellspacing="1" class="style1">
            
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="Label1" runat="server" Text="No. de Servicio:" Font-Bold="true"></asp:Label>
                </td>
                <td>
                    &nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label5" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="Label7" runat="server" Text="Tipo de Servicio:" Font-Bold="true"></asp:Label>
                </td>
                <td>
                    &nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label8" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="Label2" runat="server" Text="Gestor Asignado Actual:" Font-Bold="true"></asp:Label>
                </td>
                <td>
                    &nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label6" runat="server"></asp:Label>
                    &nbsp;
                    <asp:Label ID="rfcGestor" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                                    <asp:Label ID="Label20" runat="server" Text="Banco:" Font-Bold="true"></asp:Label>
                                </td>
                <td>
                &nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="Label21" runat="server"></asp:Label>
                                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td>
                &nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server" Enabled="False" 
                        Text="Registrar Nuevo Gasto" />
                </td>
                <td>
                    <asp:Button ID="Button6" runat="server" Enabled="False" 
                        Text="Exportar a Excel" />
                </td>
            </tr>
            </table>
            <table>
            <tr>
                <td>
                    <asp:Panel ID="Panel3" runat="server" Visible="False">
                        <table class="style1">
                            <tr>
                                <td class="style15">
                                    <asp:Label ID="Label19" runat="server" Text="Número de comprobante:" Font-Bold="true"></asp:Label>
                                </td>
                                <td class="style16">
                                    <asp:TextBox ID="txtDeposito" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Button ID="Button4" runat="server" Text="Guardar"/>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="Panel4" runat="server" Visible="False">
                        <table class="style1">
                            <tr>
                                <td class="style15">
                                    <asp:Label ID="Label3" runat="server" Text="Número de Autorizacion:" Font-Bold="true"></asp:Label>
                                </td>
                                <td class="style15">
                                    <asp:TextBox ID="txtAutorizacion" runat="server"></asp:TextBox>
                                </td>
                                <td class="style15">
                                    <asp:Button ID="Button5" runat="server" Text="Guardar " />
                                </td>
                                <td class="style16">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            </table>
            <table>
            <tr>                
                <td>
                    <asp:Panel ID="Panel2" runat="server" Visible="False">
                        <table class="style1">
                            <tr>
                                <td class="style14">
                                    <asp:Label ID="Label18" runat="server" Text="Causa de Cancelación:" Font-Bold="true"></asp:Label>
                                </td>
                                <td class="style9">
                                    <asp:DropDownList ID="cboTipoCancela" runat="server" AutoPostBack="True">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Button ID="Button3" runat="server" Text="Guardar Cancelacion" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            </table>
        <table>
            <tr>
                <td>
                    <asp:Panel ID="Panel1" runat="server" Height="100%" Width="100%" 
                        Visible="False">
                        <table cellspacing="1" class="style1">                            
                            <tr>
                                <td class="style6">
                                    <asp:Label ID="Label9" runat="server" Text="Clabe Interbancaria:" Font-Bold="true"></asp:Label>
                                </td>
                                <td class="style9">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="Label10" runat="server"></asp:Label>                                    
                                </td>
                                <td class="style10">
                                    &nbsp;
                                </td>
                                <td class="style11">
                                </td>
                                <td class="style12">                                    
                                </td>
                                <td class="style13">                                    
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style6">
                                    <asp:Label ID="Label11" runat="server" Text="Gasto a Registrar:" Font-Bold="true"></asp:Label>
                                </td>
                                <td class="style9">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:DropDownList ID="cboTipoGastos" runat="server" AutoPostBack="True">
                                    </asp:DropDownList>
                                </td>
                                <td class="style10"> 
                                &nbsp;                                   
                                </td>
                                <td class="style11">
                                    &nbsp;</td>
                                <td class="style12">
                                    &nbsp;</td>
                                <td class="style13">                                    
                                </td>
                                <td>
                                    <asp:Label ID="lblEstado" runat="server" Visible="False"></asp:Label>
                                    <asp:Label ID="lblMpio" runat="server" Visible="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style6">
                                    <asp:Label ID="Label14" runat="server" Text="Monto Solicitar:" Font-Bold="true"></asp:Label>
                                    </td>
                                <td class="style9">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <telerik:RadNumericTextBox ID="txtMontoSolicita" Runat="server" Culture="es-MX" 
                                        DbValueFactor="1" LabelWidth="64px" MinValue="0" Width="160px">
                                    </telerik:RadNumericTextBox>                                    
                                    </td>
                                <td class="style10">
                                    &nbsp;</td>
                                <td class="style11">
                                    &nbsp;</td>
                                <td class="style12">
                                    &nbsp;</td>
                                <td class="style13">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style6">
                                    <asp:Label ID="Label12" runat="server" Text="Limite a Solicitar:" Font-Bold="true"></asp:Label>
                                    </td>
                                <td class="style9">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="Label13" runat="server"></asp:Label></td>
                                <td class="style10">
                                    &nbsp;</td>
                                <td class="style11">
                                    &nbsp;</td>
                                <td class="style12">
                                    &nbsp;</td>
                                <td class="style13">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style6">
                                    <asp:Label ID="Label15" runat="server" Text="Usuario:" Font-Bold="true"></asp:Label>
                                </td>
                                <td class="style9">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="Label16" runat="server"></asp:Label>
                                </td>
                                <td class="style10">
                                    &nbsp;
                                </td>
                                <td class="style11">
                                    
                                </td>
                                <td class="style12">                                    
                                </td>
                                <td class="style13">                                    
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style6">
                                    <asp:Label ID="Label17" runat="server" Text="Fecha Alta:" Font-Bold="true"></asp:Label>
                                </td>
                                <td class="style9">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="lblFecha" runat="server"></asp:Label>
                                </td>
                                <td class="style10">
                                    &nbsp;
                                </td>
                                <td class="style11">
                                    
                                </td>
                                <td class="style12">                                    
                                </td>
                                <td class="style13">                                    
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style6">
                                    &nbsp;</td>
                                <td class="style9">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="Button2" runat="server" Text="Guardar" />
                                </td>
                                <td class="style10">
                                    &nbsp;</td>
                                <td class="style11">
                                    &nbsp;</td>
                                <td class="style12">
                                    &nbsp;</td>
                                <td class="style13">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            </table>
    
    </div>
    <table class="style1">
        <tr>
            <td>
                    <telerik:RadGrid ID="dtgGastos" runat="server" AutoGenerateColumns="False" 
                        CellSpacing="0" Culture="es-ES" GridLines="None">
                        <MasterTableView>
                            <Columns>
                                <telerik:GridButtonColumn ButtonType="PushButton" CommandName="cmdAutoriza" 
                                    FilterControlAltText="Filter column column" Text="Autorizar" 
                                    UniqueName="column">
                                </telerik:GridButtonColumn>
                                <telerik:GridButtonColumn ButtonType="PushButton" CommandName="cmdCancela" 
                                    FilterControlAltText="Filter column1 column" Text="Cancelar" 
                                    UniqueName="column1">
                                </telerik:GridButtonColumn>
                                <telerik:GridButtonColumn ButtonType="PushButton" CommandName="cmdRegDeposito" 
                                    FilterControlAltText="Filter column15 column" Text="Reg.Deposito" 
                                    UniqueName="column15">
                                </telerik:GridButtonColumn>
                                <telerik:GridButtonColumn ButtonType="PushButton" CommandName="cmdautTesoreria" 
                                    FilterControlAltText="Filter column19 column" Text="Aut.Tesoreria" 
                                    UniqueName="column19">
                                </telerik:GridButtonColumn>
                                <telerik:GridBoundColumn DataField="numConsec" display="false"
                                    FilterControlAltText="Filter column14 column" UniqueName="column14">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="STATUSGASTO" display="false"
                                    FilterControlAltText="Filter column16 column" UniqueName="column16">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="SERVICIO" 
                                    FilterControlAltText="Filter column2 column" HeaderText="SERVICIO" 
                                    UniqueName="column2">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="RFCGESTOR" 
                                    FilterControlAltText="Filter column3 column" HeaderText="RFCGESTOR" 
                                    UniqueName="column3">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="NOMBRE" 
                                    FilterControlAltText="Filter column4 column" HeaderText="NOMBRE GESTOR" 
                                    UniqueName="column4">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="PATERNO" 
                                    FilterControlAltText="Filter column5 column" HeaderText="APELLIDO" 
                                    UniqueName="column5">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="CTACLABE" 
                                    FilterControlAltText="Filter column6 column" HeaderText="CLABE" 
                                    UniqueName="column6">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="TABDESCRIP" 
                                    FilterControlAltText="Filter column7 column" HeaderText="GASTO" 
                                    UniqueName="column7">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="TOTALGASTO" 
                                    FilterControlAltText="Filter column8 column" HeaderText="MONTO" 
                                    UniqueName="column8">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="FECHAREGISTRO" 
                                    DataFormatString="{0:dd/MM/yyyy}" FilterControlAltText="Filter column9 column" 
                                    HeaderText="FECHA REGISTRO" UniqueName="column9">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="USUARIO" 
                                    FilterControlAltText="Filter column10 column" HeaderText="USUARIO" 
                                    UniqueName="column10">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="FECHA_AUTO_GASTO" 
                                    DataFormatString="{0:dd/MM/yyyy}" FilterControlAltText="Filter column11 column" 
                                    HeaderText="FECHA AUTORIZACION" UniqueName="column11">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="USUARIOAUTO" 
                                    FilterControlAltText="Filter column12 column" HeaderText="AUTORIZO" 
                                    UniqueName="column12">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="fecha_cancel" 
                                    DataFormatString="{0:dd/MM/yyyy}" FilterControlAltText="Filter column13 column" 
                                    HeaderText="FECHA CANCELA" UniqueName="column13">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="FECHA_DESPOSITO" 
                                    FilterControlAltText="Filter column17 column" HeaderText="FECHA DESPOSITO" 
                                    UniqueName="column17" DataFormatString="{0:dd/MM/yyyy}">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="GASTODOC" 
                                    FilterControlAltText="Filter column18 column" HeaderText="No. Auto" 
                                    UniqueName="column18">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="USUARIO_DEPOSITO" 
                                    FilterControlAltText="Filter USUARIO_DEPOSITO column" 
                                    HeaderText="USUARIO DEPOSITO" UniqueName="USUARIO_DEPOSITO">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="fecha_AutTesoreria" 
                                    FilterControlAltText="Filter fecha_AutTesoreria column" 
                                    HeaderText="FechaAutTesoreria" UniqueName="fecha_AutTesoreria" 
                                    DataFormatString="{0:dd/MM/yyyy}">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="usuario_AutTesoreria" 
                                    FilterControlAltText="Filter usuario_AutTesoreria column" 
                                    HeaderText="UsuarioAutTesoreria" UniqueName="usuario_AutTesoreria">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="numAutTesoreria" 
                                    FilterControlAltText="Filter numAutTesoreria column" 
                                    HeaderText="NumAutTesoreria" UniqueName="numAutTesoreria">
                                </telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
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
        <asp:Button ID="btnRechazar" runat="server" Text="No" />
     </ContentTemplate>
    </telerik:RadNotification>
    

</asp:Content>


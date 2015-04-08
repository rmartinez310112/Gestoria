<%@ Page Language="VB" MasterPageFile="~/MasterPageGestionOperativa.master" AutoEventWireup="false" CodeFile="PagoGestor.aspx.vb" Inherits="PagosGastosGestor_PagoGestor" %>

<%@ Register src="../UserControls/Fechas.ascx" tagname="Fechas" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 
    <style type="text/css">
        .style1
        {
            width: 84px;
            margin-right: 268px;
        }
        .style2
        {
            width: 93px;
        }
        .style4
        {
            width: 150px;
        }
        .style5
        {
            width: 932px;
        }
        .style6
        {
            width: 789px;
        }
    </style>

    <script type="text/javascript" id="telerikClientEvents1">
//<![CDATA[

        function rblAcep_OnSelectedIndexChanged(sender, args) {
            alert('prueba');
            //Add JavaScript handler code here
        }
//]]>
</script>

     <script type="text/javascript" language="javascript">

         
         

</script>
 
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <div>
    <div> 
        <asp:Label ID="Label35" runat="server" Text="Comprobación de pago" 
            CssClass="Titulos"></asp:Label>
        </div>
        <br />
                    <asp:Label ID="Label36" runat="server" Text="No. de Servicio:" 
                        CssClass="letrasdetodo"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="lblServicio" runat="server" 
                        CssClass="letrasdetodo"></asp:Label>
                <br />
                    <asp:Label ID="Label37" runat="server" Text="Tipo de Servicio:" 
                        CssClass="letrasdetodo"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="LblTipo" runat="server" CssClass="letrasdetodo"></asp:Label>
                <br />
                    <asp:Label ID="Label38" runat="server" Text="Gestor Asignado Actual:" 
                        CssClass="letrasdetodo"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="lblGestor" runat="server" 
                        CssClass="letrasdetodo"></asp:Label>
                    &nbsp;&nbsp;&nbsp;
                    <asp:Label ID="rfcGestor" runat="server" CssClass="letrasdetodo"></asp:Label>
                <br />
                    <asp:Label ID="Label39" runat="server" Text="Monto Total depositado a Gestor" 
                        CssClass="letrasdetodo"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblMonto" runat="server" CssClass="letrasdetodo"></asp:Label>
                    <br />
                    <asp:Button ID="Button1" runat="server" 
                        Text="Registrar un Nuevo Gasto" />
        <br />
    
        <table cellspacing="1" class="style1">
            <tr>
                <td class="style5">
                    <asp:Panel ID="Panel1" runat="server" Height="100%" Width="100%" 
                        Visible="False">
                        <table cellspacing="1" class="style1">
                            <tr>
                                <td class="style4">
                                    &nbsp;</td>
                                <td class="style9">
                                    &nbsp;</td>
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
                                <td class="style4">
                                    <asp:Label ID="Label9" runat="server" Text="Clabe Interbancaria" 
                                        CssClass="letrasdetodo"></asp:Label>
                                </td>
                                <td class="style9">
                                    <asp:Label ID="Label11" runat="server" Text="Gasto a Registrar" 
                                        CssClass="letrasdetodo"></asp:Label>
                                </td>
                                <td class="style10">
                                    <asp:Label ID="Label12" runat="server" Text="Limite a solicitar" 
                                        CssClass="letrasdetodo"></asp:Label>
                                </td>
                                <td class="style11">
                                    <asp:Label ID="Label14" runat="server" Text="Monto solicitar" 
                                        CssClass="letrasdetodo"></asp:Label>
                                </td>
                                <td class="style12">
                                    <asp:Label ID="Label15" runat="server" Text="Usuario" CssClass="letrasdetodo"></asp:Label>
                                </td>
                                <td class="style13">
                                    <asp:Label ID="Label17" runat="server" Text="Fecha Alta" 
                                        CssClass="letrasdetodo"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style4">
                                    <asp:Label ID="Label10" runat="server" CssClass="letrasdetodo"></asp:Label>
                                </td>
                                <td class="style9">
                                    <asp:DropDownList ID="cboTipoGastos" runat="server" AutoPostBack="True">
                                    </asp:DropDownList>
                                </td>
                                <td class="style10">
                                    <asp:Label ID="Label13" runat="server" CssClass="letrasdetodo"></asp:Label>
                                </td>
                                <td class="style11">
                                    <telerik:RadNumericTextBox ID="txtMontoSolicita" Runat="server" Culture="es-MX" 
                                        DbValueFactor="1" LabelWidth="64px" MinValue="0" Width="160px">
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td class="style12">
                                    <asp:Label ID="Label16" runat="server" CssClass="letrasdetodo"></asp:Label>
                                </td>
                                <td class="style13">
                                    <asp:Label ID="lblFecha" runat="server" CssClass="letrasdetodo"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblEstado" runat="server" Visible="False" 
                                        CssClass="letrasdetodo"></asp:Label>
                                    <asp:Label ID="lblMpio" runat="server" Visible="False" CssClass="letrasdetodo"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style4">
                                    <asp:Label ID="Label21" runat="server" Text="Clave de Deposito:" 
                                        CssClass="letrasdetodo"></asp:Label>
                                </td>
                                <td class="style9">
                                    <asp:TextBox ID="txtDeposito0" runat="server"></asp:TextBox>
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
                                <td class="style4">
                                    <asp:Label ID="Label22" runat="server" Text="Clave de Autorizacion:" 
                                        CssClass="letrasdetodo"></asp:Label>
                                </td>
                                <td class="style9">
                                    <asp:TextBox ID="txtAutorizacion" runat="server"></asp:TextBox>
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
                                <td class="style4">
                                    &nbsp;</td>
                                <td class="style9">
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
            <tr>
            <td colspan="2">
                    <telerik:RadGrid ID="dtgPagos" runat="server" AutoGenerateColumns="False" 
                        CellSpacing="0" Culture="es-ES" GridLines="None">
                        <MasterTableView>
                            <Columns>
                                <telerik:GridBoundColumn DataField="Motivo_Salida" 
                                    FilterControlAltText="Filter Motivo_Salida column" 
                                    UniqueName="Motivo_Salida" HeaderText="Concepto">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Monto" 
                                    FilterControlAltText="Filter Monto column" UniqueName="Monto" 
                                    HeaderText="Importe">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" 
                                    HeaderText="Comprobacion" UniqueName="TemplateColumn" >
                                    <ItemTemplate>
														<asp:RadioButtonList ID="rblAcep" runat="server" RepeatDirection="Horizontal" 
															Font-Size="10pt" Height="10px" Width="187px">
															<asp:ListItem  Value="1">Si</asp:ListItem>
															<asp:ListItem Selected="True" Value="0">No</asp:ListItem>
														</asp:RadioButtonList>
													</ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="Tipo" Display="False" 
                                    FilterControlAltText="Filter Tipo column" UniqueName="Tipo">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="consec" Display="False" 
                                    FilterControlAltText="Filter consec column" UniqueName="consec">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="usuario_justifico" 
                                    EmptyDataText="" FilterControlAltText="Filter usuario_justifico column" 
                                    UniqueName="usuario_justifico" HeaderText="Usuario Comprueba">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="fecha_justifico" 
                                    FilterControlAltText="Filter fecha_justifico column" 
                                    HeaderText="Fecha Comprobacion" UniqueName="fecha_justifico" 
                                    DataFormatString="{0:dd/MM/yyyy}">
                                </telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                    <br />
                 </td>
        </tr>
        <tr>
            <td class="style6">
                    <asp:Label ID="Label6" runat="server" Text="El monto sin comprobar es: " 
                        CssClass="letrasdetodo"></asp:Label>
                    <asp:Label ID="lblMontoNo" runat="server" 
                        CssClass="letrasdetodo"></asp:Label>
                </td>
            <td>
                    &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                    <asp:Label ID="Label8" runat="server" Text="El monto comprobado es: " 
                        CssClass="letrasdetodo"></asp:Label>
                    <asp:Label ID="lblMontoSI" runat="server" 
                        CssClass="letrasdetodo"></asp:Label>
                </td>
            <td>
                    &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                    <asp:Label ID="Label18" runat="server" Text="El monto total es: " 
                        CssClass="letrasdetodo"></asp:Label>
                    <asp:Label ID="lblMonto0" runat="server" 
                        CssClass="letrasdetodo"></asp:Label>
                </td>
            <td>
                    
                                    <asp:Button ID="btnGuardarPago" runat="server" Text="Guardar" />
                    
                    </td>
        </tr>
            </table>
    
    </div>
    <table class="style1">
        
    </table>
    <telerik:RadNotification ID="RadNotification1" runat="server">
    </telerik:RadNotification>
        <br />
     <%--<div>
       <telerik:RadNotification ID="RadNotification2" runat="server">
       </telerik:RadNotification>
   <br />
   </div>--%>
    
    </div>
    <table class="style1">
        
    </table>
    <%--<telerik:RadNotification ID="RadNotification3" runat="server">
    </telerik:RadNotification>--%>
    

   
    <br />
    

</asp:Content>
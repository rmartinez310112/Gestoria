<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGestionOperativa.master" AutoEventWireup="false" CodeFile="Fondo_Retiro.aspx.vb" Inherits="Control_Fondo_Fondo_Retiro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">

        function Notificacion_Permiso() {
            __doPostBack('Notificacion_Permiso', '');
        }
        function confirmCallBack_Guardar(arg) {
            // Hace un postback enviando el parámetro "Eliminar"
            if (arg) __doPostBack('Guardar', 'true');
        }

        function Regresar_a_Busqueda() {
            __doPostBack('Regresar_a_Busqueda', '');
        }
    </script>
    <style type="text/css">
        .style52
        {
        width: 78%;
        }
        .style53
        {
        width: 158px;
        }
        .RadComboBox {width: 160px !important}.RadComboBox_Default{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox{margin:0;padding:0;min-height:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;*zoom:1;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox {width: 160px !important}.RadComboBox_Default{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox{margin:0;padding:0;min-height:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;*zoom:1;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox{margin:0;padding:0;min-height:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;*zoom:1;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}
        .RadComboBox {width: 160px !important}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2012.3.1016.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2012.3.1016.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2012.3.1016.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2012.3.1016.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2012.3.1016.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2012.3.1016.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:none;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:none;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:none;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2012.3.1016.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2012.3.1016.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2012.3.1016.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2012.3.1016.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}
    .RadComboBox .rcbArrowCell{width:18px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2012.3.1016.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2012.3.1016.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table cellspacing="1" class="style7">
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="lbltitulo" runat="server" Text="Registro Retiro de Fondos" Font-Bold="true" Font-Size="Medium"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style53">
                <asp:Label ID="lblnoreporte" runat="server" Text="No.Servicio:"></asp:Label>
            </td>
            <td class="style52">
                <telerik:RadNumericTextBox ID="txtNoServicio" runat="server" NumberFormat-DecimalDigits="0" NumberFormat-GroupSeparator=""
                MaxLength="20" AutoPostBack="true" ForeColor="Black">                    
                </telerik:RadNumericTextBox>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style53">
                <asp:Label ID="lbltiposerv" runat="server" Text="Tipo de Servicio:"></asp:Label>
            </td>
            <td class="style52">
                <telerik:RadTextBox ID="txtTipoServicio" runat="server" ReadOnly="true"
                TextMode="MultiLine" Width="254px"></telerik:RadTextBox>
            </td>
            <td></td>
        </tr>
        <tr>
            <td class="style53">
                <asp:Label ID="lblCliente" runat="server" Text="Cliente:"></asp:Label>
            </td>
            <td class="style52">
                <telerik:RadTextBox ID="txtCliente" runat="server" ReadOnly="true"></telerik:RadTextBox>
            </td>
            <td></td>
        </tr>
        <tr>
            <td class="style53">
                <asp:Label ID="lblajusta" runat="server" Text="Ajustador:"></asp:Label>
            </td>
            <td class="style52">
                <telerik:RadTextBox ID="txtAjustador" runat="server" ReadOnly="true"></telerik:RadTextBox>
            </td>
            <td></td>
        </tr>
        <tr>
            <td class="style53">
                <asp:Label ID="lblcuentaclv" runat="server" Text="Cuenta Clave"></asp:Label>
            </td>
            <td class="style52">
                <telerik:RadTextBox ID="txtCuentaClave" runat="server" ReadOnly="true"></telerik:RadTextBox>
            </td>
            <td></td>
        </tr>
        <tr>
            <td class="style53">
                <asp:Label ID="lblEstado" runat="server" Text="Estado de Atencion"></asp:Label>
            </td>
            <td class="style52">
                <telerik:RadTextBox ID="txtEstado" runat="server" ReadOnly="true"></telerik:RadTextBox>
            </td>
            <td></td>
        </tr>        
        <tr>
            <td class="style53">
                <asp:Label ID="lblmonto" runat="server" Text="Monto:"></asp:Label>
            </td>
            <td class="style52">
                <telerik:RadNumericTextBox id="txtMonto" runat="server" Culture="es-MX" 
                    DbValueFactor="1" LabelWidth="64px" Type="Currency" Width="160px" MaxLength="8" ForeColor="Black">
<NumberFormat ZeroPattern="$n"></NumberFormat>
                </telerik:RadNumericTextBox>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3"></td>
        </tr>
        <tr>
            <td class="style53">
                <asp:Label ID="lblfecalta" runat="server" Text="Fecha de Retiro:"></asp:Label>
            </td>
            <td class="style52">
                <telerik:RadTextBox runat="server" ID="txtFecRegistro" Enabled="false" ForeColor="black"></telerik:RadTextBox>
                <%--<telerik:RadDateTimePicker ID="calFecRegistro" runat="server" Enabled="false"
                    Height="22px" Width="185px">
<TimeView ID="TimeView3" runat="server" CellSpacing="-1" Culture="es-MX"></TimeView>

<TimePopupButton CssClass="rcTimePopup rcDisabled" ImageUrl="" HoverImageUrl=""></TimePopupButton>

<Calendar ID="Calendar3" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput ID="DateInput3" runat="server" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" Height="22px" ForeColor="Black"></DateInput>

<DatePopupButton CssClass="rcCalPopup rcDisabled" ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDateTimePicker>--%>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style53">
                <asp:Label ID="lblusua" runat="server" Text="Usuario:"></asp:Label>
            </td>
            <td class="style52">
                <asp:Label ID="lblUsuario" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style53">
                <asp:Label ID="lblmotivo" runat="server" Text="Motivo de Retiro:"></asp:Label>
            </td>
            <td class="style52">
                <telerik:RadComboBox ID="ddlMotivoRetiro" runat="server" DataTextField="DescMotivo" DataValueField="ClaveMotivo" MarkFirstMatch="True" ForeColor="Black">
                </telerik:RadComboBox>
            </td>
            <td></td>
        </tr>
         <tr>
            <td colspan="3">
                &nbsp;
            </td>
        </tr>        
        <tr>
            <td colspan="3">
                <asp:Label ID="lbldatosdis" runat="server" Text="Datos de Dispersión:" Font-Bold="true" Font-Size="Small" Visible="false"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;
            </td>
        </tr>       
        <tr>
            <td class="style53">
                <asp:Label ID="lblfecdisp" runat="server" Text="Fecha Dispersión:" Visible="false"></asp:Label>
            </td>
            <td class="style52">
                <telerik:RadDateTimePicker ID="calFecDisp" runat="server" Visible="false" Height="22px" Width="185px">
                    <DateInput ID="DInputDisp" runat="server" ForeColor="Black"></DateInput>
                </telerik:RadDateTimePicker>
            </td>
            <td>
                &nbsp;
                </td>
        </tr>
        <tr>
            <td class="style53">
                <asp:Label ID="lblnumautodis" runat="server" Text="Número de Autorización:" Visible="false"></asp:Label>
            </td>
            <td class="style52">
                <telerik:RadNumericTextBox ID="txtNumAutorizaDis" runat="server" NumberFormat-DecimalDigits="0" NumberFormat-GroupSeparator=""
                MaxLength="20" Visible="false" ForeColor="Black">                    
                </telerik:RadNumericTextBox>
            </td>
            <td></td>            
        </tr>        
        <tr>
            <td class="style53">
                <asp:Label ID="lblusuariodisp" runat="server" Text="Usuario:" Visible="false"></asp:Label>
            </td>
            <td class="style52">
                <asp:Label ID="lblUsuarioDispersion" runat="server" Visible="false"></asp:Label>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
               <br />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="lbldatosconta" runat="server" Text="Datos de Contabilidad:" Font-Bold="true" Font-Size="Small" Visible="false"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;
            </td>
        </tr>       
        <tr>
            <td class="style53">
                <asp:Label ID="lblfecconta" runat="server" Text="Fecha Contabilidad:" Visible="false"></asp:Label>
            </td>
            <td class="style52">
                <telerik:RadDateTimePicker ID="calFecConta" runat="server" Visible="false" Height="22px" Width="185px">
                    <DateInput ID="DInputCon" runat="server" ForeColor="Black"></DateInput>
                </telerik:RadDateTimePicker>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style53">
                <asp:Label ID="lblnumautocont" runat="server" Text="Número de Autorización:" Visible="false"></asp:Label>
            </td>
            <td class="style52">
                <telerik:RadNumericTextBox ID="txtNumAutorizaCon" runat="server" NumberFormat-DecimalDigits="0" NumberFormat-GroupSeparator=""
                MaxLength="20" Visible="false" ForeColor="Black">                    
                </telerik:RadNumericTextBox>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style53">
                <asp:Label ID="lblusuarioconta" runat="server" Text="Usuario:" Visible="false"></asp:Label>
            </td>
            <td class="style52">
                <asp:Label ID="lblusuariocontabilidad" runat="server" Visible="false"></asp:Label>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <br />
            </td>
        </tr>
        <tr>
            <td class="style53">
                <asp:Label ID="lblMotivoRechazo" runat="server" Text="Motivo de Rechazo:" Visible="false" ></asp:Label>
            </td>
            <td class="style52">
                <telerik:RadTextBox ID="txtMotivoRechazo" runat="server" TextMode="MultiLine" 
                     Width="191px" Visible="false" ForeColor="Black"></telerik:RadTextBox>
            </td>
            <td></td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <telerik:RadButton ID="btnGuardarDisp" runat="server" Text="Guardar"  Visible="false"></telerik:RadButton>
                <telerik:RadButton ID="btnGuardarConta" runat="server" Text="Guardar"  Visible="false"></telerik:RadButton>
                &nbsp;
                <telerik:RadButton ID="btnRechaza" runat="server" Text="Rechazar Retiro"  Visible="false"></telerik:RadButton>
                <telerik:RadButton ID="btnAutoriza" runat="server" Text="Autorizar Retiro"  
                    Visible="false"></telerik:RadButton>
            </td>
            <td>
            </td>
        </tr>        
        <tr>
            <td class="style53">
                <%--<telerik:RadButton ID="btnModificar" runat="server" Text="Modificar Fondo" Display="false"></telerik:RadButton>--%>
                <asp:CheckBox ID="Check" runat="server" text="Retirar de Beneficia" Visible="false" AutoPostBack="true"/>
                <telerik:RadButton ID="btnBeneficia" runat="server" Text="Retirar de Beneficia" Visible="false"></telerik:RadButton>
            </td>
            <td class="style52">
                <telerik:RadButton ID="btnGuardar" runat="server" Text="Guardar"  Visible="false"></telerik:RadButton>
                &nbsp;
                <telerik:RadButton ID="btnNuevo" runat="server" Text="Nuevo Retiro" visible="false"></telerik:RadButton>
                <telerik:RadButton ID="btnCancelar" runat="server" Text="Cancelar Retiro"  Visible="false"></telerik:RadButton>
            </td>
            <td>
                &nbsp;
                </td>
        </tr>
        <tr>
            <td colspan="3">
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="lblhistorial" runat="server" Text="Retiros Realizados:"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style53">
                <asp:Label ID="lblsaldini" runat="server" Text="Saldo Inicial: "></asp:Label>
                &nbsp;&nbsp;
                <telerik:RadNumericTextBox ID="txtSaldoInicial" runat="server" Culture="es-MX" 
                    DbValueFactor="1" Height="21px" LabelWidth="64px" Type="Currency" Width="121px" ReadOnly="true">
<NumberFormat ZeroPattern="$n"></NumberFormat>
                </telerik:RadNumericTextBox>
            </td>
            <td class="style53" style="text-align:center">
                <asp:Label ID="lbltotreti" runat="server" Text="Total Retiros: "></asp:Label>
                &nbsp;&nbsp;
                <telerik:RadNumericTextBox ID="txtTotalRetiros" runat="server" Culture="es-MX" 
                    DbValueFactor="1" Height="21px" LabelWidth="64px" Type="Currency" Width="121px" ReadOnly="true">
<NumberFormat ZeroPattern="$n"></NumberFormat>
                </telerik:RadNumericTextBox>
            </td>
            <td class="style52">
                <asp:Label ID="lblsaldoactu" runat="server" Text="Saldo Actual: "></asp:Label>
                &nbsp;&nbsp;
                <telerik:RadNumericTextBox ID="txtSaldoActual" runat="server" Culture="es-MX" 
                    DbValueFactor="1" Height="21px" LabelWidth="64px" Type="Currency" Width="121px" ReadOnly="true">
<NumberFormat ZeroPattern="$n"></NumberFormat>
                </telerik:RadNumericTextBox>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="lblsaldoser" runat="server" Text="Saldo Retiros por el Servicio: "></asp:Label>
                &nbsp;&nbsp;
                <telerik:RadNumericTextBox ID="txtSaldoServ" runat="server" Culture="es-MX" 
                    DbValueFactor="1" Height="21px" LabelWidth="64px" Type="Currency" Width="121px" ReadOnly="true">
<NumberFormat ZeroPattern="$n"></NumberFormat>
                </telerik:RadNumericTextBox>
            </td>
        </tr>
        <tr>
            <td colspan="3">
            <asp:UpdatePanel ID="UpdatePanelGrid" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <telerik:RadGrid ID="griddepositos" runat="server" AutoGenerateColumns="false" AllowSorting="false" Visible="true">
                    <MasterTableView>
                        <Columns>
                            <telerik:GridBoundColumn DataField="Monto" DataFormatString="{0:$ ###,###,###,##0.00}" HeaderText="Monto Retirado" SortExpression="Monto" UniqueName="Consec">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="FechaAlta" HeaderText="Fecha de Retiro" SortExpression="FechaRegistro" UniqueName="FechaRegistro">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Usuario" HeaderText="Usuario Retiro" SortExpression="Usuario" UniqueName="Usuario">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Cliente_NomCliente" HeaderText="Cliente" SortExpression="Cliente" UniqueName="Cliente">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Motivo_Salida" HeaderText="Motivo de Retiro" SortExpression="Motivo_Salida" UniqueName="Motivo_Salida">
                            </telerik:GridBoundColumn>         
                            <telerik:GridBoundColumn DataField="fechaDispersion" HeaderText="Fecha Dispersion" SortExpression="fechaDispersion" UniqueName="fechaDispersion">
                            </telerik:GridBoundColumn> 
                            <telerik:GridBoundColumn DataField="usuarioDisperso" HeaderText="Usuario Dispersion" SortExpression="usuarioDisperso" UniqueName="usuarioDisperso">
                            </telerik:GridBoundColumn> 
                            <telerik:GridBoundColumn DataField="fechaContabilidad" HeaderText="Fecha Contabilidad" SortExpression="fechaContabilidad" UniqueName="fechaContabilidad">
                            </telerik:GridBoundColumn> 
                            <telerik:GridBoundColumn DataField="usuarioContabilid" HeaderText="Usuario Contabilidad" SortExpression="usuarioContabilid" UniqueName="usuarioContabilid">
                            </telerik:GridBoundColumn> 
                            <telerik:GridBoundColumn DataField="Estatus" HeaderText="Estatus Retiro" SortExpression="Estatus" UniqueName="Estatus">
                            </telerik:GridBoundColumn>                                                
                            <telerik:GridBoundColumn DataField="MotivoRechazo" HeaderText="Motivo Rechazo" SortExpression="MotivoRechazo" UniqueName="MotivoRechazo">
                            </telerik:GridBoundColumn>
                            <%--<telerik:GridBoundColumn DataField="Consec" HeaderText="Consecutivo" SortExpression="Consec" UniqueName="Consec">
                            </telerik:GridBoundColumn>--%>
                        </Columns>
                    </MasterTableView>                    
                </telerik:RadGrid>
                </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <telerik:RadNotification ID="RadNotification2" runat="server"
                AnimationDuration="2000" LoadContentOn="EveryShow" Position="Center" Title="Atención!">
                </telerik:RadNotification>
            </td>
        </tr>
    </table>
</asp:Content>


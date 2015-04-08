<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGestionOperativa.master" AutoEventWireup="false" CodeFile="Fondo_Entrada.aspx.vb" Inherits="Control_Fondo_Fondo_Entrada" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
    <script type="text/javascript">

        function Notificacion_Permiso() {
            __doPostBack('Notificacion_Permiso', '');
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
    .RadComboBox .rcbArrowCell{width:18px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2012.3.1016.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2012.3.1016.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}</style>
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
                <asp:Label ID="lbltitulo" runat="server" Text="Registro Entrada de Fondos" Font-Bold="true" Font-Size="Medium"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style53">
                <asp:Label ID="lblcliente" runat="server" Text="Cliente:"></asp:Label>
            </td>
            <td class="style52">
                <telerik:RadComboBox ID="ddlCliente" Runat="server" DataValueField="cliente_clvCliente" DataTextField="cliente_NomCliente"
                MarkFirstMatch="true" AutoPostBack="true">
                </telerik:RadComboBox>
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
                <asp:Label ID="lblmonto" runat="server" Text="Monto:"></asp:Label>
            </td>
            <td class="style52">
                <telerik:RadNumericTextBox id="txtMonto" runat="server" Culture="es-MX" 
                    DbValueFactor="1" LabelWidth="64px" Type="Currency" Width="160px" MaxLength="8">
<NumberFormat ZeroPattern="$n"></NumberFormat>
                </telerik:RadNumericTextBox>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style53">
                <asp:Label ID="lblfecdepo" runat="server" Text="Fecha de Deposito:"></asp:Label>
            </td>
            <td class="style52">
                <telerik:RadDatePicker ID="calFecDeposito" runat="server">
                    <DateInput id="txtcal" runat="server" ForeColor="Black"></DateInput>
                </telerik:RadDatePicker>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style53">
                <asp:Label ID="lblnoreferencia" runat="server" Text="No. de Referencia Bancaria:"></asp:Label>
            </td>
            <td class="style52">
                <telerik:RadNumericTextBox ID="txtNoReferencia" runat="server" NumberFormat-DecimalDigits="0" NumberFormat-GroupSeparator=""
                MaxLength="20">                    
                </telerik:RadNumericTextBox>
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
                <asp:Label ID="lblfecregi" runat="server" Text="Fecha de Registro:"></asp:Label>
            </td>
            <td class="style52">
                <telerik:RadTextBox runat="server" ID="txtFecRegistro" Enabled="false" ForeColor="black"></telerik:RadTextBox>
                <%--<telerik:RadDateTimePicker ID="calFechaAlta" runat="server" Enabled="false" 
                    Height="22px" Width="185px">
<TimeView runat="server" CellSpacing="-1" Culture="es-MX"></TimeView>

<TimePopupButton runat="server" CssClass="rcTimePopup rcDisabled" ImageUrl="" HoverImageUrl=""></TimePopupButton>

<Calendar runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput runat="server" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" Height="22px"></DateInput>

<DatePopupButton CssClass="rcCalPopup rcDisabled" ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDateTimePicker>--%>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style53">
                <%--<telerik:RadButton ID="btnModificar" runat="server" Text="Modificar Fondo" Display="false"></telerik:RadButton>--%>
            </td>
            <td class="style52">
                <telerik:RadButton ID="btnGuardar" runat="server" Text="Guardar Deposito"></telerik:RadButton>
                &nbsp;&nbsp;&nbsp;
                <telerik:RadButton ID="btnNuevo" runat="server" Text="Nuevo Deposito" visible="false"></telerik:RadButton>
                <telerik:RadButton ID="btnCancelar" runat="server" Text="Cancelar Deposito"></telerik:RadButton>
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
                <asp:Label ID="lblhistorial" runat="server" Text="Depositos Ingresados:"></asp:Label>
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
            <asp:UpdatePanel ID="UpdatePanelGrid" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <telerik:RadGrid ID="griddepositos" runat="server" AutoGenerateColumns="false" AllowSorting="false" Visible="true">
                    <MasterTableView>
                        <Columns>
                            <telerik:GridBoundColumn DataField="Monto" DataFormatString="{0:$ ###,###,###,##0.00}" HeaderText="Monto" SortExpression="Monto" UniqueName="Consec">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="FechaDeposito" HeaderText="Fecha de Deposito" SortExpression="FecDeposito" UniqueName="FecDeposito" DataFormatString="{0:d}">    
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Ref_bancaria" HeaderText="No. de Referencia" SortExpression="NoReferencia" UniqueName="NoReferencia">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Usuario" HeaderText="Nombre Usuario" SortExpression="Usuario" UniqueName="Usuario">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="FechaAlta" HeaderText="Fecha de Registro" SortExpression="FechaRegistro" UniqueName="FechaRegistro">
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


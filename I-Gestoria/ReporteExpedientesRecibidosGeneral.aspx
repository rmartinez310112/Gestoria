<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ReporteExpedientesRecibidosGeneral.aspx.vb" Inherits="ReporteExpedientesRecibidosGeneral" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
.RadPicker{vertical-align:middle}.rdfd_{position:absolute}.rdfd_{position:absolute}.rdfd_{position:absolute}.rdfd_{position:absolute}.rdfd_{position:absolute}.rdfd_{position:absolute}.rdfd_{position:absolute}.rdfd_{position:absolute}.rdfd_{position:absolute}.rdfd_{position:absolute}.rdfd_{position:absolute}.rdfd_{position:absolute}.rdfd_{position:absolute}.rdfd_{position:absolute}.RadPicker .rcTable{table-layout:auto}.RadPicker .RadInput{vertical-align:baseline}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}.RadInput{vertical-align:middle}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}

.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput .riTextBox{height:17px}.RadInput .riTextBox{height:17px}.RadInput .riTextBox{height:17px}.RadInput .riTextBox{height:17px}.RadInput .riTextBox{height:17px}.RadInput .riTextBox{height:17px}.RadInput .riTextBox{height:17px}.RadInput .riTextBox{height:17px}.RadInput .riTextBox{height:17px}.RadInput .riTextBox{height:17px}.RadInput .riTextBox{height:17px}.RadInput .riTextBox{height:17px}.RadInput .riTextBox{height:17px}.RadInput .riTextBox{height:17px}.RadPicker_Default .rcCalPopup{background-position:0 0}.RadPicker_Default .rcCalPopup{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Calendar.sprite.gif')}.RadPicker .rcCalPopup{display:block;overflow:hidden;width:22px;height:22px;background-color:transparent;background-repeat:no-repeat;text-indent:-2222px;text-align:center;-webkit-box-sizing:content-box;-moz-box-sizing:content-box;box-sizing:content-box}.RadPicker td a{position:relative;outline:0;z-index:2;margin:0 2px;text-decoration:none}
        .style2
        {
            width: 100%;
            border-style: none;
            border-color: inherit;
            border-width: 0;
            margin: 0;
            padding: 0;
        }
        .style3
        {
            width: 100%;
            vertical-align: middle;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    Fecha Inicial:<telerik:RadDatePicker ID="rdFI" runat="server">
													</telerik:RadDatePicker>
												<asp:Label ID="Label1" runat="server" 
                        Text="Fecha Final:"></asp:Label>
													<telerik:RadDatePicker ID="rdFI0" 
                        runat="server">
													</telerik:RadDatePicker>
												<asp:Button ID="Button1" runat="server" 
                        Text="Buscar Expedientes Recibidos" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    <telerik:RadGrid ID="radExpedienteVer" runat="server" AutoGenerateColumns="False" 
                        Culture="es-ES" Width="1406px" CellSpacing="0" GridLines="None">
                        <MasterTableView>
                            <Columns>
                                <telerik:GridBoundColumn DataField="NoGestion" 
                                    FilterControlAltText="Filter column1 column" UniqueName="column1" 
                                    HeaderText="No Servicio">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Servicio_NomServicio" 
                                    FilterControlAltText="Filter column10 column" HeaderText="Servicio" 
                                    UniqueName="column10">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Reporte_FechaRepor" 
                                    FilterControlAltText="Filter column2 column" HeaderText="Fecha Reporte" 
                                    UniqueName="column2" DataFormatString="{0:dd/MM/yyyy}">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="EntregaExpediente_fecha" 
                                    FilterControlAltText="Filter column6 column" HeaderText="Fecha Recepcion " 
                                    UniqueName="column6" DataFormatString="{0:dd/MM/yyyy}">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="TipoEntrega" 
                                    FilterControlAltText="Filter column7 column" HeaderText="Tipo de Entrega" 
                                    UniqueName="column7" Visible="False">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="EntregaExpediente_Guia" 
                                    FilterControlAltText="Filter column8 column" HeaderText="No. Guia" 
                                    UniqueName="column8">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Nombre" 
                                    FilterControlAltText="Filter column column" HeaderText="Gestor" 
                                    UniqueName="column">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Reporte_FechaRepor" 
                                    FilterControlAltText="Filter column4 column" HeaderText="Fecha Repor" 
                                    UniqueName="column4">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="EntregaExpediente_usuario" 
                                    FilterControlAltText="Filter column5 column" HeaderText="Recibio" 
                                    UniqueName="column5">
                                </telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                </td>
            </tr>
            <tr>
                <td>
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                <Scripts>
                    <%--Needed for JavaScript IntelliSense in VS2010--%>
                    <%--For VS2008 replace RadScriptManager with ScriptManager--%>
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
                </Scripts>
            </telerik:RadScriptManager>

                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>

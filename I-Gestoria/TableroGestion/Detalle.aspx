<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Detalle.aspx.vb" Inherits="TableroGestion_Detalle" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
        </telerik:RadScriptManager>
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        </telerik:RadAjaxManager>
    <div>
     <fieldset id="fsDomicilioLec" runat="server">
                        <legend>Detalle de Información</legend>
        <table border="0" cellpadding="0" cellspacing="0">
        <tr><td align="right">
        <asp:Label ID="labelTitle" Text ="Exportar a Excel" runat="server" ></asp:Label>&nbsp;
            <asp:ImageButton ImageUrl="~/Imagenes/ico_excel.gif" ID="Export" runat="server" ToolTip="Exportar a Excel" Text="Export" />
        
        </td>
        </tr>
        <tr>
          <td>
                    <telerik:RadGrid ID="RDDetalles" runat="server" AutoGenerateColumns="False" CellSpacing="0" Culture="es-ES" GridLines="None"> 
                      <MasterTableView>
                      <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                            <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                            <HeaderStyle Width="20px"></HeaderStyle>
                            </RowIndicatorColumn>

                            <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                            <HeaderStyle Width="20px"></HeaderStyle>
                            </ExpandCollapseColumn>
                            <HeaderStyle Font-Bold="true" Font-Size="10"/>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="NOREPORTE" 
                                        FilterControlAltText="Filter NOREPORTE column" HeaderText="Número de Reporte" 
                                        UniqueName="NOREPORTE">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="FECHA" 
                                        FilterControlAltText="Filter FECHA column" HeaderText="Fecha Reporte" 
                                        UniqueName="FECHA">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="SERVICIO" 
                                        FilterControlAltText="Filter SERVICIO column" HeaderText="Tipo Servicio" 
                                        UniqueName="SERVICIO">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="CLIENTE" 
                                        FilterControlAltText="Filter CLIENTE column" HeaderText="Contrato" 
                                        UniqueName="CLIENTE">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Reporte_CiaAsegura" 
                                        FilterControlAltText="Filter Reporte_CiaAsegura column" 
                                        HeaderText="Aseguradora" UniqueName="Reporte_CiaAsegura">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Reporte_poliza" 
                                        FilterControlAltText="Filter Reporte_poliza column" HeaderText="Num Poliza" 
                                        UniqueName="Reporte_poliza">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Reporte_contrato" 
                                        FilterControlAltText="Filter Reporte_contrato column" HeaderText="Num Contrato" 
                                        UniqueName="Reporte_contrato">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ReporteGestionPT_NoSiniestro" 
                                        FilterControlAltText="Filter ReporteGestionPT_NoSiniestro column" 
                                        HeaderText="Num Siniestro" UniqueName="ReporteGestionPT_NoSiniestro">
                                    </telerik:GridBoundColumn>
                                     <telerik:GridBoundColumn DataField="FechaSiniestro" 
                                        FilterControlAltText="Filter Reporte_FechaRepor column" 
                                        HeaderText="Fecha Siniestro" UniqueName="Reporte_FechaRepor">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ReporteGestionPT_SerieVehi" 
                                        FilterControlAltText="Filter ReporteGestionPT_SerieVehi column" 
                                        HeaderText="Numero de Serie" UniqueName="ReporteGestionPT_SerieVehi">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="NOMBRECLIENTE" 
                                        FilterControlAltText="Filter NOMBRECLIENTE column" HeaderText="Cliente" 
                                        UniqueName="NOMBRECLIENTE">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="TELEFONO" 
                                        FilterControlAltText="Filter TELEFONO column" HeaderText="Teléfono" 
                                        UniqueName="TELEFONO">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="MAIL" 
                                        FilterControlAltText="Filter MAIL column" HeaderText="Mail" 
                                        UniqueName="MAIL">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ESTADO" 
                                        FilterControlAltText="Filter ESTADO column" HeaderText="Estado" 
                                        UniqueName="ESTADO">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ESTATUS" 
                                        FilterControlAltText="Filter ESTATUS column" HeaderText="Estatus" 
                                        UniqueName="ESTATUS">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Etapa" 
                                        FilterControlAltText="Filter Etapa column" HeaderText="Etepa de Servicio" 
                                        UniqueName="Etapa">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ResLlamadas_FechaAlta" 
                                        FilterControlAltText="Filter ResLlamadas_FechaAlta column" 
                                        HeaderText="Fecha Ultima Llamada" UniqueName="ResLlamadas_FechaAlta">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="CatResLlamadas_ClvResultado" 
                                        FilterControlAltText="Filter CatResLlamadas_ClvResultado column" 
                                        HeaderText="Observacion Ultima Llamada" 
                                        UniqueName="CatResLlamadas_ClvResultado">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="datosSeguimiento_FechaAlta" 
                                        FilterControlAltText="Filter datosSeguimiento_FechaAlta column" 
                                        HeaderText="Fecha Ultimo Contacto" UniqueName="datosSeguimiento_FechaAlta">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="datosSeguimiento_Acuerdo" 
                                        FilterControlAltText="Filter datosSeguimiento_Acuerdo column" 
                                        HeaderText="Observacion Ultimo Contacto" UniqueName="datosSeguimiento_Acuerdo">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Reporte_fechaTermino" 
                                        FilterControlAltText="Filter Reporte_fechaTermino column" 
                                        HeaderText="Fecha de Terminacion del Servicio" 
                                        UniqueName="Reporte_fechaTermino">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Reporte_FechaCancela" 
                                        FilterControlAltText="Filter Reporte_FechaCancela column" 
                                        HeaderText="Fecha de Cancelacion" UniqueName="Reporte_FechaCancela">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Reporte_CausaCancela" 
                                        FilterControlAltText="Filter Reporte_CausaCancela column" 
                                        HeaderText="Motivo Cancelacion" UniqueName="Reporte_CausaCancela">
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
     </table>
     </fieldset>
    </div>
    </form>
</body>
</html>

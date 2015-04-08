<%@ Page Language="VB" AutoEventWireup="false" CodeFile="D6.aspx.vb" Inherits="TableroGestion_D6" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" CellSpacing="0" Culture="es-ES" GridLines="None"> 
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
                                        FilterControlAltText="Filter column column" HeaderText="Número de Reporte" 
                                        UniqueName="column">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="SERVICIO" 
                                        FilterControlAltText="Filter column1 column" HeaderText="Servicio" 
                                        UniqueName="column1">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ESTATUS" 
                                        FilterControlAltText="Filter column2 column" HeaderText="Status" 
                                        UniqueName="column2">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="CLIENTE" 
                                        FilterControlAltText="Filter column3 column" HeaderText="Contrato" 
                                        UniqueName="column3">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="FECHA" 
                                        FilterControlAltText="Filter column4 column" HeaderText="Fecha Reporte" 
                                        UniqueName="column4">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="NOMBRECLIENTE" 
                                        FilterControlAltText="Filter column5 column" HeaderText="Cliente" 
                                        UniqueName="column5">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="TELEFONO" 
                                        FilterControlAltText="Filter column6 column" HeaderText="Teléfono" 
                                        UniqueName="column6">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="MAIL" 
                                        FilterControlAltText="Filter column7 column" HeaderText="Mail" 
                                        UniqueName="column7">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ESTADO" 
                                        FilterControlAltText="Filter column8 column" HeaderText="Estado" 
                                        UniqueName="column8">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Dias_Meta" 
                                        FilterControlAltText="Filter column10 column" HeaderText="Dias Meta" 
                                        UniqueName="column10">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Dias_Transcurridos" 
                                        FilterControlAltText="Filter column9 column" HeaderText="Dias Transcurridos" 
                                        UniqueName="column9">
                                    </telerik:GridBoundColumn>
                                </Columns>
                            <EditFormSettings>
                            <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                            </EditFormSettings>
                            </MasterTableView>
                        <FilterMenu EnableImageSprites="False"></FilterMenu>
        
                  </telerik:RadGrid>
    <%--<telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" 
        CellSpacing="0" Culture="es-ES" GridLines="None">
        <MasterTableView>
            <Columns>
                <telerik:GridAttachmentColumn DataTextField="Nservicio" FileName="attachment" 
                    FilterControlAltText="Filter column column" HeaderText="No Servicio" 
                    UniqueName="column">
                </telerik:GridAttachmentColumn>
                <telerik:GridAttachmentColumn DataTextField="Tramite_Descripcion" 
                    FileName="attachment" FilterControlAltText="Filter column1 column" 
                    HeaderText="Tipo de Servicio" UniqueName="column1">
                </telerik:GridAttachmentColumn>
                <telerik:GridAttachmentColumn DataTextField="Reporte_status" 
                    FileName="attachment" FilterControlAltText="Filter column2 column" 
                    HeaderText="Status" UniqueName="column2">
                </telerik:GridAttachmentColumn>
                <telerik:GridAttachmentColumn DataTextField="cliente_NomCliente" 
                    FileName="attachment" FilterControlAltText="Filter column3 column" 
                    HeaderText="Contrato" UniqueName="column3">
                </telerik:GridAttachmentColumn>
                <telerik:GridAttachmentColumn DataTextField="Reporte_FechaRepor" 
                    FileName="attachment" FilterControlAltText="Filter column4 column" 
                    HeaderText="Fecha Reporte" UniqueName="column4">
                </telerik:GridAttachmentColumn>
                <telerik:GridAttachmentColumn DataTextField="cliente" FileName="attachment" 
                    FilterControlAltText="Filter column5 column" HeaderText="Cliente" 
                    UniqueName="column5">
                </telerik:GridAttachmentColumn>
                <telerik:GridAttachmentColumn DataTextField="telefono" FileName="attachment" 
                    FilterControlAltText="Filter column6 column" HeaderText="Telefono" 
                    UniqueName="column6">
                </telerik:GridAttachmentColumn>
                <telerik:GridAttachmentColumn DataTextField="Reporte_MailAseg" 
                    FileName="attachment" FilterControlAltText="Filter column7 column" 
                    HeaderText="E-mail" UniqueName="column7">
                </telerik:GridAttachmentColumn>
                <telerik:GridAttachmentColumn DataTextField="ABREVIATURA" FileName="attachment" 
                    FilterControlAltText="Filter column8 column" HeaderText="Estado" 
                    UniqueName="column8">
                </telerik:GridAttachmentColumn>
                <telerik:GridAttachmentColumn DataTextField="diasMaxTermino" 
                    FileName="attachment" FilterControlAltText="Filter column9 column" 
                    HeaderText="Dias Meta" UniqueName="column9">
                </telerik:GridAttachmentColumn>
                <telerik:GridAttachmentColumn DataTextField="DiasDiferencia" 
                    FileName="attachment" FilterControlAltText="Filter column10 column" 
                    HeaderText="Dias Transcurridos" UniqueName="column10">
                </telerik:GridAttachmentColumn>
            </Columns>
        </MasterTableView>
    </telerik:RadGrid>--%>
    </div>
    <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
    </telerik:RadScriptManager>
    </form>
</body>
</html>

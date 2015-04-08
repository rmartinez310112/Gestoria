<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGestionOperativa.master" AutoEventWireup="false" CodeFile="Servicio1.aspx.vb" Inherits="Reportes" %>
<%@ Register Src="~/UserControls/Totales.ascx" TagName="Totales" TagPrefix="uc1"%>
<%@ Register Src="~/UserControls/Fechas.ascx" TagName="Fechas" TagPrefix="uc2"%>
<%@ Register Src="~/UserControls/Combo.ascx" TagName="Combo" TagPrefix="uc3"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../css/maquetacion.css" rel="stylesheet" type="text/css" />

</asp:Content>
<asp:Content  ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >
    <div>
    
    <table class="tableq" border="0" cellpadding="0" cellspacing="4">
    
    <tr>
    <td align="center" style="width:100%" colspan="5">
    
      <asp:Label ID="lbltitulo" runat="server" CssClass="Fechas" Text="REPORTE DE SERVICIOS DEL " Visible="True"></asp:Label> 
        <asp:Label ID="FECHAINICIAL" runat="server" CssClass="Fechas" Visible="True"></asp:Label> &nbsp;
        <asp:Label ID="lblAL" runat="server" CssClass="Fechas" Text="AL" Visible="True"></asp:Label>  &nbsp;
        <asp:Label ID="FECHAFINAL" runat="server" CssClass="Fechas" Visible="True"></asp:Label> &nbsp;
       
    </td>
    </tr>

        <tr>
            <td>
                <asp:Label CssClass="LabelStyle" ID="lblContratos" runat="server" Text="Contratos:"></asp:Label>
            </td>
            <td>
                <asp:Label CssClass="LabelStyle" ID="lblServicio" runat="server" Text="Servicio:"></asp:Label>
            </td>
            <td>
                <asp:Label CssClass="LabelStyle" ID="lblFecha" runat="server" Text="Fecha:"></asp:Label>
            </td>
            <td>
                <asp:Label CssClass="LabelStyle" ID="lblRegion" runat="server" Text="Region:"></asp:Label>
            </td>
            <td>
                <asp:Label CssClass="LabelStyle" ID="lblEstado" runat="server" Text="Estados:"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadComboBox ID="CboCliente" AutoPostBack="true" Runat="server" 
                   Skin="Outlook">
                </telerik:RadComboBox>
            </td>
            <td>
                <telerik:RadComboBox ID="cboServicioTipo" AutoPostBack="true" Runat="server" 
                    Culture="es-ES" Skin="Outlook">
                </telerik:RadComboBox>
            </td>
            <td>
                <telerik:RadComboBox Skin="Outlook" ID="RadComboBox3" Runat="server" Culture="es-ES" AutoPostBack="true"
                    OnSelectedIndexChanged="RadComboBox3_SelectedIndexChanged">
                    <Items>
                       <%-- <telerik:RadComboBoxItem runat="server" Selected="True" Text="(Seleccione)" 
                            Value="0" />--%>
                        <telerik:RadComboBoxItem Selected="true" runat="server" Text="Rango" Value="1" />
                        <telerik:RadComboBoxItem runat="server" Text="Mes" Value="2" />
                    </Items>
                </telerik:RadComboBox>
            </td>
            <td>
                <telerik:RadComboBox ID="cboRegion" Skin="Outlook" AutoPostBack="true" Runat="server">
                </telerik:RadComboBox>
            </td>
            <td>
                <telerik:RadComboBox ID="cboEstado" Skin="Outlook" AutoPostBack="true" Runat="server" >
                </telerik:RadComboBox>
            </td>
        </tr>

        <tr>
            <td>
            </td>
            <td>
            </td>
            <td colspan="2">
               <asp:UpdatePanel ID="udpFiltro" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                    <uc2:Fechas id="SelectorFechas" runat="server" Visible="false"/>
                     <uc3:Combo id="ComboMes" runat="server" Visible="false" />
                    </ContentTemplate>
               </asp:UpdatePanel>
              <%-- <uc3:Combo id="ComboMes" runat="server" Visible="false" />--%>
              
              <%-- <uc2:Fechas id="Fechas1" runat="server" Visible="false"/>--%>
              
             
            </td>
            
            
             <td align="right"><telerik:RadButton ID="radBtnResultado" runat="server" Text="Buscar">
                </telerik:RadButton>
            </td>
        </tr>
        <tr>
            <td></td>
            <td></td>
            <td colspan="2">
              
            </td>
            
            <td> </td>
        </tr>
        
    </table>
    <br />
    <br />
   
    <asp:UpdatePanel ID="panelResultados" Visible="false" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
    <table>

    <tr>
    <td>
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" 
                        CellSpacing="0" Culture="es-ES" GridLines="None">
                            <MasterTableView>
                             <NoRecordsTemplate>
                                 <div>No records to display</div>
                               </NoRecordsTemplate>
                            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

                            <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                            <HeaderStyle Width="20px"></HeaderStyle>
                            </RowIndicatorColumn>

                            <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                            <HeaderStyle Width="20px"></HeaderStyle>
                            </ExpandCollapseColumn>
                            <HeaderStyle Font-Bold="true" Font-Size="10" ForeColor="White" BackColor="Green"/>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="Tramite_Descripcion" 
                                        FilterControlAltText="Filter column column" HeaderText="Tipo de Servicio" 
                                        UniqueName="column">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="OCURRIDOSN" 
                                        FilterControlAltText="Filter column1 column" HeaderText="Ocurridos #" 
                                        UniqueName="column1">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="OCURRIDOSP" DataFormatString="{0:P0}" HtmlEncode="false"
                                        FilterControlAltText="Filter column2 column" HeaderText="Ocurridos %" 
                                        UniqueName="column2">
                                        <FooterStyle HorizontalAlign="Right" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="CANCELADOSN" 
                                        FilterControlAltText="Filter column3 column" HeaderText="Cancelados #" 
                                        UniqueName="column3">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="CANCELADOSP" DataFormatString="{0:P0}" HtmlEncode="false"
                                        FilterControlAltText="Filter column4 column" HeaderText="Cancelados %" 
                                        UniqueName="column4">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ATENDIDOSN" 
                                        FilterControlAltText="Filter column5 column" HeaderText="Atendidos #" 
                                        UniqueName="column5">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ATENDIDOSP" DataFormatString="{0:P0}" HtmlEncode="false"
                                        FilterControlAltText="Filter column6 column" HeaderText="Atendidos %" 
                                        UniqueName="column6">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="TERMINADOSN" 
                                        FilterControlAltText="Filter column7 column" HeaderText="Terminados #" 
                                        UniqueName="column7">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="TERMINADOSP" DataFormatString="{0:P0}" HtmlEncode="false"
                                        FilterControlAltText="Filter column8 column" HeaderText="Terminados %" 
                                        UniqueName="column8">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="PROCESON"
                                        FilterControlAltText="Filter column9 column" HeaderText="En proceso #" 
                                        UniqueName="column9">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="PROCESOP" DataFormatString="{0:P0}" HtmlEncode="false"
                                        FilterControlAltText="Filter column10 column" HeaderText="En proceso %" 
                                        UniqueName="column10">
                                        <ItemStyle HorizontalAlign="Right" />
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
        </td>
       </tr>


       <tr>
       <td> 
            <uc1:Totales ID="selectorCuentas1" runat="server" >
            </uc1:Totales> 
       </td>
       </tr>

       <tr>
       <td>
        <table border="0" width=100%>
           <tr>
           
            <td width="20%"></td>
            <td width="20%"></td>
                <td width="20%">
                    
                 </td>
                  <td width="20%" align="right"> 
                   
                </td>
                <td width="20%" align="right">
                    <telerik:RadButton ID="radBtnAvances" BackColor="Green" runat="server" 
                        Text="Avances" ForeColor="White">
                    </telerik:RadButton>
                    <telerik:RadButton ID="radBtnDesempeño" BackColor="Green" runat="server" 
                        Text="Desempeño" ForeColor="White">
                    </telerik:RadButton>
                </td>
           </tr>
        </table>
       </td>
       </tr>

        </table>
        </ContentTemplate>
        </asp:UpdatePanel>
 <br />


       
    <telerik:RadNotification ID="RadNotification1" runat="server">
    </telerik:RadNotification>
    </div>
    </asp:Content>

<%@ Page Language="VB" MasterPageFile="~/MasterPageGestionOperativa.master" AutoEventWireup="false" CodeFile="Desempeño.aspx.vb" Inherits="TableroGestion_Desempeño" %>

<%@ Register src="../UcDesempeño/TotalesDesempeño.ascx" tagname="TotalesDesempeño" tagprefix="uc1" %>

<%@ Register src="../UcDesempeño/Fechas.ascx" tagname="Fechas" tagprefix="uc2" %>
<%@ Register src="../UcDesempeño/Combo.ascx" tagname="Combo" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <style type="text/css">
        .style1
        {
            height: 26px;
        }
        .style2
        {
            width: 171px;
        }
        .style3
        {
            width: 160px;
        }
    </style>
    <link href="../HojaEstilos/tablero.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr>
            <td colspan="2" 
                style="font-family:@Arial Unicode MS;font-size:40px; font-weight:bolder; font-style:oblique;color:White;">
                <asp:Label ID="lblSemaforo" runat="server" Text="Semaforo de Tiempos"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
          </table>
          <table class="tableq" border="0" cellpadding="0" cellspacing="4">
    

        <tr>
            <td>
                <asp:Label ID="lblContratos" runat="server" Text="Contratos:" CssClass="combos"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblServicio" runat="server" Text="Servicio:" CssClass="combos"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblFecha" runat="server" Text="Fecha:" CssClass="combos"></asp:Label>
            </td>
            <td class="style3">
                <asp:Label ID="lblRegion" runat="server" Text="Region:" CssClass="combos"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblEstado" runat="server" Text="Estados:" CssClass="combos"></asp:Label>
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
                <telerik:RadComboBox ID="RadComboBox3" Runat="server" Culture="es-ES" AutoPostBack="true"
                    OnSelectedIndexChanged="RadComboBox3_SelectedIndexChanged" Skin="Outlook">
                    <Items>
                       <%-- <telerik:RadComboBoxItem runat="server" Selected="True" Text="(Seleccione)" 
                            Value="0" />--%>
                        <telerik:RadComboBoxItem Selected="true" runat="server" Text="Rango" Value="1" />
                        <telerik:RadComboBoxItem runat="server" Text="Mes" Value="2" />
                    </Items>
                </telerik:RadComboBox>
            </td>
            <td class="style3">
                <telerik:RadComboBox ID="cboRegion" AutoPostBack="true" Runat="server" 
                    Skin="Outlook">
                </telerik:RadComboBox>
            </td>
            <td>
                <telerik:RadComboBox ID="cboEstado" AutoPostBack="true" Runat="server" 
                    style="height: 16px" Skin="Outlook" >
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
                        <uc2:Fechas ID="SelectorFechas" runat="server" Visible="false"/>
                        <uc3:Combo ID="ComboMes" runat="server" Visible="false" />
                    </ContentTemplate>
               </asp:UpdatePanel>
            </td>
            
            
             <td align="right"><telerik:RadButton ID="radBtnResultado" runat="server" 
                     Text="Buscar" CssClass="combos">
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
       <table>  
        <tr>
            <td style="width:100px;margin:center;">
                <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" 
                    CellSpacing="0" Culture="es-ES" GridLines="None" Width="1100px">
<MasterTableView RetainExpandStateOnRebind="True">
                             <NoRecordsTemplate>
                                 <div>No records to display</div>
                               </NoRecordsTemplate>
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
<HeaderStyle Width="20px"  CssClass="combos"></HeaderStyle>
</ExpandCollapseColumn>
   <HeaderStyle  ForeColor="White" BackColor="Green" Font-Bold="true" Font-Size="10"/>
    <Columns>
        <telerik:GridBoundColumn FilterControlAltText="Filter column column"
            HeaderText="Tipo de Servicio" UniqueName="column" 
            DataField="Tramite_Descripcion">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn FilterControlAltText="Filter column1 column" 
            HeaderText="Terminados   #" UniqueName="column1" DataField="terminados">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn FilterControlAltText="Filter column2 column" 
            HeaderText="Antes de Tiempo" UniqueName="column2" 
            DataField="Antes_de_Tiempo">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn FilterControlAltText="Filter column3 column" 
            UniqueName="column3" DataFormatString='{0:p0}'  DataField="AntesPorc" 
            HeaderText="Antes de Tiempo %">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn FilterControlAltText="Filter column4 column" 
            HeaderText="En Tiempo" UniqueName="column4" DataField="En_Tiempo">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn FilterControlAltText="Filter column5 column" 
            UniqueName="column5" DataFormatString='{0:p0}' DataField="EnTiempoPorc" 
            HeaderText="En Tiempo %">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn FilterControlAltText="Filter column6 column" 
            HeaderText="Fuera de Tiempo" UniqueName="column6" 
            DataField="Fuera_de_Tiempo">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn FilterControlAltText="Filter column7 column" 
            UniqueName="column7" DataFormatString='{0:p0}' DataField="FueraPorc" 
            HeaderText="Fuera de Tiempo %">
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
        <td>
         <telerik:RadNotification ID="RadNotification1" runat="server">
    </telerik:RadNotification>
            <table style="width:1100px;">
                <tr>
                    <td>
                    <uc1:TotalesDesempeño ID="TotalesDesempeño1" runat="server" />
                    </td>
                </tr>
            </table>
    
        </td>
        </tr>
        <tr>
        <td class="style1">

            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

            <telerik:RadButton ID="radBtnRegresar" runat="server" Text="Regresar">
            </telerik:RadButton>

        </td>
        </tr>
    </table>
    

   
    </asp:Content>
    
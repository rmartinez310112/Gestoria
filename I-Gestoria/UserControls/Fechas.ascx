<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Fechas.ascx.vb" Inherits="UserControls_Fechas" %>
 <link href="../css/maquetacion.css" rel="stylesheet" type="text/css" />
<div>
        <table border="0" style="width: 352px">
        <tr>
           <td> 
             <asp:Label ForeColor="White" Font-Size="Smaller" ID="lblFI" Text="Fecha Inicial:" Font-Bold="true" runat="server" 
                            ></asp:Label>
                        <telerik:RadDatePicker ID="rdFI" Runat="server" Width="100px" 
                   Culture="es-MX" 
                   HiddenInputTitleAttibute="Visually hidden input created for functionality purposes." 
                   WrapperTableSummary="Table holding date picker control for selection of dates." >
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%"></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                        </telerik:RadDatePicker>
            <asp:Label ForeColor="White" Font-Size="Smaller" ID="lblFF" Text="Fecha Final:" Font-Bold="true" runat="server" 
                            ></asp:Label>
                        <telerik:RadDatePicker ID="rdFF" Runat="server" Width="100px" 
                   Culture="es-MX" 
                   HiddenInputTitleAttibute="Visually hidden input created for functionality purposes." 
                   WrapperTableSummary="Table holding date picker control for selection of dates." >
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%"></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                        </telerik:RadDatePicker>
           </td>
         </tr>
         </table>
 </div>
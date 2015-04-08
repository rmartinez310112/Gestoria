<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Fechas.ascx.vb" Inherits="UserControls_Fechas" %>
<link href="../HojaEstilos/tablero.css" rel="stylesheet" type="text/css" />
<div>
        <table border="0" style="width: 352px">
        <tr>
           <td style="color:White"> 
             <asp:Label Font-Size="Smaller" ID="lblFI" Text="Fecha Inicial:"  Font-Bold="True" 
                   runat="server" 
                            ></asp:Label>
                        <telerik:RadDatePicker ID="rdFI" Runat="server" Width="100px" >
                        </telerik:RadDatePicker>
            <asp:Label Font-Size="Smaller" ID="lblFF" Text="Fecha Final:" Font-Bold="True" 
                   runat="server" 
                            ></asp:Label>
                        <telerik:RadDatePicker ID="rdFF" Runat="server" Width="100px" >
                        </telerik:RadDatePicker>
           </td>
         </tr>
         </table>
 </div>
<%@ Control Language="VB" AutoEventWireup="false" CodeFile="TotalesAvance.ascx.vb" Inherits="UserControls_Totales" %>

<link href="../HojaEstilos/tablero.css" rel="stylesheet" type="text/css" />
<div>
<table cellspacing="8" width="100%" border="0">
<tr>
  <td align="center"  style="height:50%;width:19%;" bgcolor="#009900">
      <asp:Label Font-Size="Medium" Text="Totales" ID="Label1" runat="server" 
          CssClass="combos" ></asp:Label>
  </td>
  
  <td bgcolor="#009900" style="height:50%;width:7.5%">
   <%--<asp:Label Font-Size="Small" ID="lblNO" runat="server"  ></asp:Label>--%>
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:LinkButton ID="lblTerminados" runat="server" Font-Bold="true" 
          ForeColor="#2B3990" Font-Size="Medium" CssClass="totales"></asp:LinkButton>
  
   </td>

  <td bgcolor="#009900" style="height:50%;width:18.5%">
  <%-- <asp:Label Font-Size="Small" ID="lblNC" runat="server" ></asp:Label>--%>

   <asp:LinkButton Font-Size="Medium" ID="lblAntes" runat="server" 
          ForeColor="#2B3990" Font-Bold="true" CssClass="totales"></asp:LinkButton>
 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
   <asp:Label Font-Size="Medium" ID="lblAntesP" runat="server" ForeColor="White" 
          Font-Bold="True" CssClass="totales"></asp:Label>
  </td>

  <td style="height:50%;width:12.5%;background-color:Yellow">
 
  <asp:LinkButton ID="lblTiempo" runat="server" Font-Bold="true" ForeColor="#2B3990" 
          Font-Size="Medium" CssClass="totales"></asp:LinkButton>
  <%--<asp:LinkButton ID="lblNA" runat="server" Font-Bold="true" Font-Size="Medium"></asp:LinkButton>--%>
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label Font-Size="Medium" ID="lblTiempoP" runat="server" ForeColor="Black" Font-Bold="True" 
          CssClass="totales"></asp:Label>
  </td>

  <td style="height:50%;width:18%;background-color:Red">
  &nbsp;<asp:LinkButton ID="lblFuera" runat="server" Font-Bold="true" ForeColor="#2B3990" 
          Font-Size="Medium" CssClass="totales"></asp:LinkButton>
  <%--<asp:LinkButton ID="lblNT" runat="server" Font-Bold="true" Font-Size="Medium"></asp:LinkButton>--%>
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
   <asp:Label Font-Size="Medium" ID="lblFueraP" runat="server" ForeColor="White" 
          Font-Bold="True" CssClass="totales" ></asp:Label>
  </td>
</tr>
</table>
    
</div>
<div>

    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
    </telerik:RadWindowManager>

</div>

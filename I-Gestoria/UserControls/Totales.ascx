<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Totales.ascx.vb" Inherits="UserControls_Totales" %>

 <link href="../css/maquetacion.css" rel="stylesheet" type="text/css" />
<div>
<table cellspacing="8" width="100%" border="0">
<tr>
  <td align="center" style="height:50%;width:18%" bgcolor="#009900">
      <asp:Label CssClass="LabelStyle" Text="Totales" ID="Label1" runat="server" ></asp:Label>
  </td>
  
  <td bgcolor="#009900" style="height:50%;width:15%">
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
   <asp:LinkButton CssClass="TotalesLink" ID="lblNO" runat="server" Text='<%# Bind("Quantity", "{0:N0}") %>'></asp:LinkButton>
   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
   <asp:Label CssClass="LabelStyle" ID="lblPO" runat="server" ></asp:Label>
  </td>

  <td bgcolor="#009900" style="height:50%;width:15%">
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
  <asp:LinkButton ID="lblNC" CssClass="TotalesLink" runat="server" ></asp:LinkButton>
   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
   <asp:Label CssClass="LabelStyle"  ID="lblPC" runat="server"></asp:Label>
  </td>

  <td bgcolor="#009900" style="height:50%;width:15%">
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
  <asp:Label ID="lblNA" CssClass="LabelStyle"  runat="server" onchange="format(this)"></asp:Label>
   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
   <asp:Label ID="lblPA" CssClass="LabelStyle"  runat="server" onchange="format(this)"></asp:Label>
  </td>

  <td bgcolor="#009900" style="height:50%;width:15%">
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
  <asp:LinkButton ID="lblNT" CssClass="TotalesLink" runat="server" ></asp:LinkButton>
   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
   <asp:Label ID="lblPT" runat="server" CssClass="LabelStyle" ></asp:Label>
  </td>

  <td bgcolor="#009900" style="height:50%;width:15%">
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
  <asp:LinkButton ID="lblNP" CssClass="TotalesLink" runat="server" ></asp:LinkButton>
   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
   <asp:Label ID="lblPP" runat="server" CssClass="LabelStyle" ></asp:Label>
  </td>
</tr>
</table>
</div>
<%@ Control Language="VB" AutoEventWireup="false" CodeFile="SegACitaESiAsis.ascx.vb" Inherits="UserControls_SegACitaESiAsis" %>


<table>
  <tr>
    <td colspan="2">
    <br />
    </td>
  </tr>
  
  <tr>
      <td>
         <asp:Label ID="lblLugarCita" runat="server" Text="Acción Siguiente:"></asp:Label>
      </td>
      <td>
      <asp:Label ID="Label3" runat="server" ForeColor="Gray" Text="Pendiente de Concretar Gestor."></asp:Label>
      </td>
  </tr>
  <tr>
    <td>
        <asp:Label ID="Label4" runat="server" Text="Fecha Registro:"></asp:Label>
    </td>
    <td> 
         <asp:Label ID="lblFechaCita" runat="server"  Text="Test Fecha Registro"></asp:Label>
    </td>
  </tr>
  <tr>
      <td>
          <asp:Label ID="Label5" runat="server" Text="Usuario Registro:"></asp:Label>
      </td>
  <td>
      <asp:Label ID="lblHoraCita" runat="server" Text="Test Usuario Registro" ></asp:Label>
  </td>
  </tr>

 
  <tr>
  <td colspan="2">
  <br />
  </td>
  </tr>
  
  <tr>
      <td colspan="2" align="right">
       <telerik:RadButton runat="server" ID="btnESiAsis" Text="Guardar"></telerik:RadButton>
      </td>
  </tr>
</table>
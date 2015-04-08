<%@ Control Language="VB" AutoEventWireup="false" CodeFile="SegACitaE.ascx.vb" Inherits="UserControls_SegACitaE" %>

<table>
<tr>
  <td>
      <asp:Label ID="Label1" runat="server" Text="Detalle de la Cita:"></asp:Label>
  </td>
  <td>
   
  </td>
  </tr>
  
  <tr>
    <td colspan="2">
    <br />
    </td>
  </tr>
  
  <tr>
      <td>
         <asp:Label ID="lblLugarCita" runat="server" Text="Lugar de la Cita"></asp:Label>
      </td>
      <td>
      <asp:Label ID="Label3" runat="server" Text="Test Lugar"></asp:Label>
      </td>
  </tr>
  <tr>
    <td>
        <asp:Label ID="Label4" runat="server" Text="Fecha de la Cita:"></asp:Label>
    </td>
    <td> 
         <asp:Label ID="lblFechaCita" runat="server"  Text="Test Fecha"></asp:Label>
    </td>
  </tr>
  <tr>
      <td>
          <asp:Label ID="Label5" runat="server" Text="Hora de la Cita:"></asp:Label>
      </td>
  <td>
      <asp:Label ID="lblHoraCita" runat="server" Text="Test Hora" ></asp:Label>
  </td>
  </tr>

  <tr>
      <td>
          <asp:Label ID="Label6" runat="server" Text="Gestor:"></asp:Label>
      </td>
  <td>
      <asp:Label ID="lblGestor" runat="server" Text="Test Gestor" ></asp:Label>
  </td>
  </tr>

  <tr>
      <td>
          <asp:Label ID="Label2" runat="server" Text="Motivo:"></asp:Label>
      </td>
  <td>
     <telerik:RadComboBox  ID="rdIDMotivo" runat="server"></telerik:RadComboBox>
  </td>
  </tr>

  <tr>
  <td>
      <asp:Label ID="Label7" runat="server" Text="Asistir a la Cita:"></asp:Label>
  </td>
   <td>
       <asp:RadioButton ID="rbSiAsis" Text="Si" runat="server" />
       <asp:RadioButton ID="rbNoAsis" Text="No" runat="server" />
   </td>
  </tr>

  <tr>
  <td colspan="2">
  <br />
  </td>
  </tr>
  
  <tr>
      <td colspan="2">
    
      </td>
  </tr>


</table>
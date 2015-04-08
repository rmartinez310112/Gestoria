<%@ Control Language="VB" AutoEventWireup="false" CodeFile="SegACitaNE.ascx.vb" Inherits="UserControls_SegACitaNE" %>
<table>
<tr>
  <td>
      <asp:Label ID="Label1" runat="server" Text="Motivo:"></asp:Label>
  </td>
  <td>
   <telerik:RadComboBox ID="rdIdMotivoNE" runat="server">
   </telerik:RadComboBox>
  </td>
  </tr>
  <tr>
      <td>
         <asp:Label ID="Label2" runat="server" Text="Acción Siguiente:"></asp:Label>
      </td>
      <td>
      <asp:Label ID="Label3" runat="server" ForeColor="Gray" Text="Nuevo intento de llamada"></asp:Label>
      </td>
  </tr>
  <tr>
    <td>
        <asp:Label ID="Label4" runat="server" Text="Fecha de Registro:"></asp:Label>
    </td>
    <td> 
         <asp:Label ID="lblFechaRegistro" runat="server" ></asp:Label>
    </td>
  </tr>
  <tr>
      <td>
          <asp:Label ID="Label5" runat="server" Text="Usuario Registro:"></asp:Label>
      </td>
  <td>
      <asp:Label ID="lblUsuarioRegistro" runat="server" ></asp:Label>
  </td>
  </tr>

  <tr>
    <td colspan="2">
    <br />
    </td>
  </tr>
   <tr>
       <td colspan="2" align="right">
        <telerik:RadButton runat="server" Text="Guardar" ID="btnGuardarNE">
        </telerik:RadButton>
       </td>
       </tr>


</table>

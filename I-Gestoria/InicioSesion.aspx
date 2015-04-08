<%@ Page Language="VB" AutoEventWireup="false" CodeFile="InicioSesion.aspx.vb" Inherits="InicioSesion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
        <style type="text/css">
            .style1
            {
                width: 100%;
                height: 608px;
            }
            .style2
            {
                width: 546px;
            }
            .style3
            {
                width: 546px;
                height: 48px;
            }
            .style4
            {
                height: 48px;
            }
            .style5
            {
                width: 546px;
                height: 51px;
            }
            .style6
            {
                height: 51px;
            }
            .style7
            {
                width: 546px;
                height: 24px;
            }
            .style8
            {
                height: 24px;
            }
            .style9
            {
                height: 48px;
                width: 142px;
            }
        </style>
    </head>
    <body>
        <form id="form1" runat="server">
        <div style=" margin: 0 auto; background-image: url('Imagenes/login_autoconcierge.jpg'); background-repeat: no-repeat; height: 760px; width: 1018px;">
            <table class="style1">
                <tr>
                    <td class="style2">
                        &nbsp;</td>
                    <td colspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style2">
                        &nbsp;</td>
                    <td colspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style2">
                        &nbsp;</td>
                    <td colspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style7">
                    </td>
                    <td class="style8" colspan="2">
                    </td>
                </tr>
                <tr>
                    <td class="style5">
                    </td>
                    <td class="style6" colspan="2">
                    </td>
                </tr>
                <tr>
                    <td class="style3">
                    </td>
                    <td class="style9">
                        <%--<asp:Label ID="Label1" runat="server" Font-Size="20pt" ForeColor="#8EC640" 
                            Text="Usuario:"></asp:Label>--%>
                    </td>
                    <td class="style4">
                        <telerik:RadTextBox ID="TextBox1" Runat="server" value="USUARIO" onfocus="this.value = '';" 
                            onblur="if (this.value == '') {this.value = 'USUARIO';}">
                        </telerik:RadTextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style3">
                    </td>
                    <td class="style9">
                        <%--<asp:Label ID="Label2" runat="server" Font-Size="20pt" ForeColor="#8EC640" 
                            Text="Password:"></asp:Label>--%>
                    </td>
                    <td class="style4">
                        <telerik:RadTextBox ID="TextBox2" Runat="server" TextMode="Password" value="Contraseña" onfocus="this.value = '';" 
                           onblur="if (this.value == '') {this.value = 'Contraseña';}">
                        </telerik:RadTextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style3">
                        &nbsp;</td>
                    <td class="style9">
                        &nbsp;</td>
                    <td class="style4">
                        <telerik:RadButton ID="Button1" runat="server" Height="34px" Text="Entrar" 
                            Width="122px">
                        </telerik:RadButton>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        &nbsp;</td>
                    <td colspan="2">
                        &nbsp;</td>
                </tr>
            </table>
        </div>
        <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
        </telerik:RadScriptManager>
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        </telerik:RadAjaxManager>
        </form>
    </body>
</html>

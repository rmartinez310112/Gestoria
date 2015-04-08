<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGestionOperativa.master" AutoEventWireup="false" CodeFile="Reportes.aspx.vb" Inherits="Reportes" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel1" BackColor="White" runat="server">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/PLANTILLA.png" 
            Width="1350px" />
    </asp:Panel>
    <telerik:RadNotification ID="RadNotification1" runat="server">
    </telerik:RadNotification>
    </asp:Content>

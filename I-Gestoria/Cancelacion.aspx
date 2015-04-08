<%@ Page Language="VB" MasterPageFile="~/MasterPageGestionOperativa.master" AutoEventWireup="False" CodeFile="Cancelacion.aspx.vb" Inherits="Cancelacion" %>

<asp:Content ID="Content" ContentPlaceHolderID="head" Runat="Server">

    <script type="text/javascript" id="telerikClientEvents1">
//<![CDATA[

//]]>
</script>

</asp:Content>

<asp:Content ID="Content11" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div align="left" style="margin-left: 40px">
<h1><asp:Label ID="Label19" runat="server" Text="Cancelacion de Servicio" 
        CssClass="Titulos" /></h1>
    <p>
        <telerik:RadNotification ID="RadNotification2" runat="server" Skin="Forest">
        </telerik:RadNotification>
        <telerik:RadComboBox ID="CboCancela" runat="server" Culture="es-ES" 
        DataSourceID="GestoriaBD" DataTextField="Descripcion_Cancela" 
        DataValueField="Clave_Cancela" Width="500px">
    </telerik:RadComboBox>
    <asp:SqlDataSource ID="GestoriaBD" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ConnStringSQL %>" 
        
            SelectCommand="SELECT [Descripcion_Cancela], [Clave_Cancela] FROM [CancelacionGestoria_Tipos] WHERE ([Tipo_cancela] = @Tipo_cancela) ORDER BY [Clave_Cancela]">
        <SelectParameters>
            <asp:Parameter DefaultValue="1" Name="Tipo_cancela" Type="Decimal" />
        </SelectParameters>
    </asp:SqlDataSource>
    </p>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <a>
        <asp:Label ID="Label1" runat="server" Text="Comentarios :" 
        CssClass="EtiquetasEncabezado" /></a>
    <p>
    <telerik:RadTextBox ID="RadTextBox1" runat="server" TextMode="MultiLine" 
            Height="84px" Width="500px">
    </telerik:RadTextBox>
    </p>
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <telerik:RadButton ID="RadButton1" runat="server" Text="Aceptar">
    </telerik:RadButton>
    </p>
    </div>
    <telerik:RadInputManager ID="RadInputManager1" runat="server">
    </telerik:RadInputManager>
</asp:Content>
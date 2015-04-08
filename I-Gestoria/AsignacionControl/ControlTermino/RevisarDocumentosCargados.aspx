<%@ Page Language="VB" MasterPageFile="~/MasterPageGestionOperativa.master" AutoEventWireup="false" CodeFile="RevisarDocumentosCargados.aspx.vb" Inherits="AsignacionControl_ControlTermino_RevisarDocumentosCargados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../HojaEstilos/StyleSheet3H.css" rel="stylesheet" type="text/css" />
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
            ForeColor="#333333" GridLines="None" DataKeyNames="Id" >
            <RowStyle BackColor="#EFF3FB" />
            <Columns>
               <%-- <asp:TemplateField HeaderText="Eliminar" ItemStyle-HorizontalAlign="Center" visible="False">
                    <ItemTemplate>
                        <asp:ImageButton ID="imgEliminar" runat="server" CommandName="Delete"  ImageUrl="~/imagenes/delete.png" Width="24px" Height="24px"/>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="Nombre Archivo">
                    <ItemTemplate>
                        <asp:Label ID="label" runat="server" Text='<%# Eval("Nombre") %>'></asp:Label>

                        <%--<asp:HyperLink ID="nombre" runat="server" NavigateUrl='<%# Eval("Id", "~/DescargaArchivo.ashx?id={0}") %>'
                            Text='<%# Eval("Nombre") %>'>
                        </asp:HyperLink>--%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Length" HeaderText="Tamaño" />
                <asp:TemplateField HeaderText="Descargar">
                    <ItemTemplate>
                        <asp:HyperLink ID="descarga" runat="server" NavigateUrl='<%# Eval("Id", "~/AsignacionControl/ControlTermino/Download.aspx?id={0}&tabla=ArchivosAceptadosPDF") %>'>
                               <img src="../../Imagenes/download.gif" alt="" width="30px" height="30px" style="border-width:0px;" />
                        </asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
            </div>
                            <telerik:RadNotification ID="RadNotification1" runat="server">
        </telerik:RadNotification>
                 
</asp:Content>
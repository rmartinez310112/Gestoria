<%@ Page Language="VB" AutoEventWireup="false" CodeFile="CargaImagenGestionPDFRechazados.aspx.vb" Inherits="GestionDocumentos_CargaImagenGestion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
        <style type="text/css">
            .style1
            {
            width: 220px;
            }
            .style28
            {
            width: 805px;
            }
        </style>
        <link rel="stylesheet" type="text/css" href="../HojaEstilos/StyleSheet3H.css" />
    </head>
    <body>
        <form id="form1" runat="server">
            <div>
                <asp:FileUpload ID="FileUpload1" runat="server" />
        <br />
        <br />
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar Archivo" OnClick="btnGuardar_Click" />
        <br />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
            ForeColor="#333333" GridLines="None" DataKeyNames="Id" 
            onrowdeleting="GridView1_RowDeleting">
            <RowStyle BackColor="#EFF3FB" />
            <Columns>
                <asp:TemplateField HeaderText="Eliminar" ItemStyle-HorizontalAlign="Center" Visible="False">
                    <ItemTemplate>
                        <asp:ImageButton ID="imgEliminar" runat="server" CommandName="Delete"  ImageUrl="~/imagenes/delete.png" Width="24px" Height="24px"/>
                    </ItemTemplate>
                </asp:TemplateField>
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
                        <asp:HyperLink ID="descarga" runat="server" NavigateUrl='<%# Eval("Id", "~/AsignacionControl/ControlTermino/Download.aspx?id={0}&tabla=ArchivosRechazadosPDF") %>'>
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
        </form>
    </body>
</html>

<%@ Page Language="VB" AutoEventWireup="false" CodeFile="CargaImagenGestion.aspx.vb" Inherits="GestionDocumentos_CargaImagenGestion" %>

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
        <script type="text/javascript" id="telerikClientEvents1">
            //<![CDATA[

            function cmdSubir_Clicking(sender, args){
                window.location = window.location.href;
            }
            //]]>
        </script>
    </head>
    <body>
        <form id="form1" runat="server">
            <div>
                <table cellspacing="1" class="style28">
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td class="style1">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="Label10" runat="server" Text="Envió de archivos para soporte" 
                                       CssClass="Titulosdehojasblancas" ></asp:Label>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td class="style1" style="text-align: center">
                            <asp:Label ID="Label15" runat="server" Text="Archivo a Cargar" 
                                       CssClass="letrasdehojasblancas"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
                            </telerik:RadScriptManager>
                        </td>
                        <td rowspan="7">
                            &nbsp;
                        </td>
                        <td class="style1" rowspan="7" style="vertical-align: top">
                            <asp:TextBox ID="txtDesc" runat="server" Height="660px" TextMode="MultiLine" 
                                         Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">


                            <INPUT style="WIDTH: 99%; text-align: center;"
                                   type="file"  id="File1" name="File1" runat="server" size="50" class="LabelsCss" onclick="return File1_onclick()" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label14" runat="server" Text="Descripción de de la imagen:" 
                                       CssClass="letrasdehojasblancas"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDescrip" runat="server" Height="46px" TextMode="MultiLine" 
                                         Width="366px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadNotification ID="notificacion" runat="server" 
                                                     CloseButtonToolTip="Cerrar" Height="71px" Text="Producto Adicionado" Skin="Web20">
                            </telerik:RadNotification>
                        </td>
                        <td style="text-align: center">
                            &nbsp;
                            <telerik:RadButton ID="cmdSubir" runat="server" 
                                               Text="Enviar Imagen" onclientclicking="cmdSubir_Clicking">
                            </telerik:RadButton>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="Label16" runat="server" 
                                       Text="Imagenes Cargadas en el Expediente" CssClass="letrasdehojasblancas"
                                       Font-Size="14pt"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">

                            <telerik:RadSplitter ID="RadSplitter1" Runat="server" 
                                                 Width="62%"  BorderColor="Transparent" BorderStyle="None">
                                <telerik:RadPane ID="RadPane1" runat="server" Width="560px" Locked="True" 
                                                 PersistScrollPosition="False" >
                                    <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" 
                                                     CellSpacing="0" Culture="es-ES" GridLines="None" Width="99%" 
                                        Skin="Hay">
                                        <FilterMenu EnableImageSprites="False">
                                        </FilterMenu>
                                        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" 
                                                           EnableImageSprites="True">
                                        </HeaderContextMenu>
                                        <ClientSettings>
                                            <Selecting CellSelectionMode="None" />
                                        </ClientSettings>
                                        <MasterTableView>
                                            <CommandItemSettings ExportToPdfText="Export to Pdf" />
                                            <RowIndicatorColumn>
                                                <HeaderStyle Width="20px" />
                                            </RowIndicatorColumn>
                                            <ExpandCollapseColumn>
                                                <HeaderStyle Width="20px" />
                                            </ExpandCollapseColumn>
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="img_pk" UniqueName="column" Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn HeaderText="Imagen" UniqueName="TemplateColumn">
                                                    <ItemTemplate>
                                                        <asp:Image ID="Image1" runat="server" Height="200px" Width="200px" />
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridBoundColumn DataField=" img_name" 
                                                                         FilterControlAltText="Filter column3 column" HeaderText="Observaciones" 
                                                                         UniqueName="column3">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn1 column" 
                                                                            UniqueName="TemplateColumn1">
                                                    <ItemTemplate>
                                                        <asp:HyperLink ID="linkImagen" runat="server">[linkImagen]</asp:HyperLink>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <EditFormSettings>
                                                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                                </EditColumn>
                                            </EditFormSettings>
                                        </MasterTableView>
                                    </telerik:RadGrid>
                                    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
                                        <Windows>
                                            <telerik:RadWindow ID="RadWindow1" runat="server" AutoSize="True" 
                                                               KeepInScreenBounds="True" style="display:none;">
                                            </telerik:RadWindow>
                                        </Windows>
                                    </telerik:RadWindowManager>
                                </telerik:RadPane>
                            </telerik:RadSplitter>

                        </td>
                    </tr>
                </table>
            </div>
        </form>
    </body>
</html>

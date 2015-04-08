<%@ Page Title="" Language="VB" MasterPageFile="~/AsignacionControl/MasterControlTermino.master" AutoEventWireup="false" CodeFile="EnviarImagenesGestionCT.aspx.vb" Inherits="GestionDocumentos_EnviarImagenesGestion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

        .style10
        {
        width: 101%;
        }
        .style56
        {
        width: 218px;
        }
        .style57
        {
        width: 71%;
        }
    </style>
    <link href="../HojaEstilos/StyleSheet3H.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" id="telerikClientEvents1">
        //<![CDATA[

        function RadWindowManager1_Close(sender, args) {

            window.close()
            window.location = window.location.href;

        }

           //]]>
    </script>

   </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <table cellspacing="1" class="style7">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <table class="style10">
                    <tr>
                        <td class="style56">
                            &nbsp;
                        </td>
                        <td class="style57">
                            <asp:Label ID="lblError" runat="server" CssClass="Errores" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="Label8" runat="server" CssClass="Titulos" 
                                       Text="Digitalizacion de Documentos"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                                                        
                            <telerik:RadButton ID="BtnAceptadosPDF" runat="server" 
                                Text="Subir/Consultar PDF Aceptados">
                            </telerik:RadButton>
                            <telerik:RadButton ID="BtnRechazadosPDF" runat="server" 
                                Text="Subir/Consultar PDF Rechazados">
                            </telerik:RadButton>
                            <telerik:RadButton ID="BtnXDocumento" runat="server" Text="Por Documento">
                            </telerik:RadButton>
                                                        
                            </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                                                        
                            <asp:LinkButton ID="LinkButton1" runat="server" 
                                ToolTip="Actualiza la ultima informacion del tablero">Actualizar</asp:LinkButton>
                                                        
                            </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Panel ID="Panel1" runat="server" Height="500px" ScrollBars="Auto" 
                                Width="1350px">
                            <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" CellSpacing="0"
                                             Culture="es-ES" GridLines="None" Skin="Hay">
                                <MasterTableView>
                                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" 
                                                        Visible="True">
                                        <HeaderStyle Width="20px" />
                                    </RowIndicatorColumn>
                                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" 
                                                          Visible="True">
                                        <HeaderStyle Width="20px" />
                                    </ExpandCollapseColumn>
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="Tramite_clvTramite" FilterControlAltText="Filter column column"
                                                                 UniqueName="column" Display="False">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Tramite_cvlSubTramite" FilterControlAltText="Filter column1 column"
                                                                 UniqueName="column1" Display="False">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField=" Tramite_TipoPersona" 
                                                                 FilterControlAltText="Filter column8 column" UniqueName="column8" 
                                                                 Display="False">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField=" Tramite_servVeh" 
                                                                 FilterControlAltText="Filter column9 column" UniqueName="column9" 
                                                                 Display="False">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="consec" 
                                                                 FilterControlAltText="Filter column5 column" UniqueName="column5" 
                                                                 Display="False">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="TramitesGestion_Descrip" 
                                                                 FilterControlAltText="Filter column6 column" HeaderText="Tipo Tramite" 
                                                                 UniqueName="column6">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="documentos_descrip" 
                                                                 FilterControlAltText="Filter column2 column" 
                                                                 HeaderText="Descripción del Documento" UniqueName="column2">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="TramitesGestion_Notas" 
                                                                 FilterControlAltText="Filter column7 column" HeaderText="Nota Adicional" 
                                                                 UniqueName="column7">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridButtonColumn ButtonType="PushButton" CommandName="cmdEnviar" FilterControlAltText="Filter column3 column"
                                                                  Text="Enviar/Ver Imagen" UniqueName="column3">
                                        </telerik:GridButtonColumn>
                                    </Columns>
                                    <EditFormSettings>
                                        <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                        </EditColumn>
                                    </EditFormSettings>
                                </MasterTableView>
                                <FilterMenu EnableImageSprites="False">
                                </FilterMenu>
                            </telerik:RadGrid>
                                <br />
                                <asp:LinkButton ID="LinkButton2" runat="server" 
                                    ToolTip="Actualizar Ultima Fecha de Digitalizacion en tablero general y salir de pantalla ">Actualiza tablero general</asp:LinkButton>
                            </asp:Panel>
                            
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
            <telerik:RadWindowManager ID="RadWindowManager1" runat="server" onclientclose="RadWindowManager1_Close">

            </telerik:RadWindowManager>


        </tr>
        <tr>
            <td>
                <telerik:RadNotification ID="RadNotification2" runat="server" 
                                                         AnimationDuration="2000" LoadContentOn="EveryShow" Position="Center" 
                                                         Title="Atención!">
                                </telerik:RadNotification>
            </td>
        </tr>
    </table>

</asp:Content>


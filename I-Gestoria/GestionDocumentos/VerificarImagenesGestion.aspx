<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGestionOperativa.master" AutoEventWireup="false" CodeFile="VerificarImagenesGestion.aspx.vb" Inherits="GestionDocumentos_VerificarImagenesGestion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">


        .style10
        {
        width: 100%;
        }
        .style56
        {
        width: 218px;
        }
        .style57
        {
        width: 71%;
        }
        .style58
        {
            height: 23px;
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
  

    <table cellspacing="1" class="style10">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <table class="style10" __designer:mapid="d">
                    <tr __designer:mapid="e">
                        <td class="style56" __designer:mapid="f">
                            &nbsp;
                        </td>
                        <td class="style57" __designer:mapid="10">
                            <asp:Label ID="lblError" runat="server" CssClass="Errores" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr __designer:mapid="12">
                        <td colspan="2" __designer:mapid="13">
                            <asp:Label ID="Label8" runat="server" CssClass="Titulos" 
                                       Text="Verificar Expediente"></asp:Label>
                        </td>
                    </tr>
                    <tr __designer:mapid="15">
                        <td colspan="2" __designer:mapid="16" class="style58">
                            &nbsp;
                        </td>
                    </tr>
                    <tr __designer:mapid="17">
                        <td colspan="2" __designer:mapid="18">
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
                                                                 UniqueName="column" Visible="False">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Tramite_cvlSubTramite" FilterControlAltText="Filter column1 column"
                                                                 UniqueName="column1" Visible="False">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField=" Tramite_TipoPersona" 
                                                                 FilterControlAltText="Filter column8 column" UniqueName="column8" 
                                                                 Visible="False">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField=" Tramite_servVeh" 
                                                                 FilterControlAltText="Filter column9 column" UniqueName="column9" 
                                                                 Visible="False">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="consec" 
                                                                 FilterControlAltText="Filter column5 column" UniqueName="column5" 
                                                                 Visible="False">
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
                                        <telerik:GridButtonColumn ButtonType="PushButton" CommandName="cmdVer" 
                                                                  FilterControlAltText="Filter column4 column" Text="Ver Imagenes" 
                                                                  UniqueName="column4">
                                        </telerik:GridButtonColumn>
                                        <telerik:GridNumericColumn DecimalDigits="2" 
                                                                   FilterControlAltText="Filter column3 column" UniqueName="column3">
                                        </telerik:GridNumericColumn>
                                    </Columns>
                                    <EditFormSettings>
                                        <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                        </EditColumn>
                                    </EditFormSettings>
                                </MasterTableView>
                                <FilterMenu EnableImageSprites="False">
                                </FilterMenu>
                            </telerik:RadGrid>
                            </asp:Panel>
                            
                        </td>
                    </tr>
                    <tr __designer:mapid="28">
                        <td colspan="2" __designer:mapid="29">
                            &nbsp;
                        </td>
                    </tr>
                    <tr __designer:mapid="2a">
                        <td colspan="2" __designer:mapid="2b">
                            &nbsp;
                        </td>
                    </tr>
                    <tr __designer:mapid="2c">
                        <td colspan="2" __designer:mapid="2d">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>

                <telerik:RadWindowManager ID="RadWindowManager1" runat="server" 
                                          onclientclose="RadWindowManager1_Close">
                </telerik:RadWindowManager>
                <telerik:RadWindow ID="RadWindow1" runat="server" Skin="Windows7" 
                                   ReloadOnShow="True" onclientclose="RadWindowManager1_Close">
                </telerik:RadWindow>
                <telerik:RadWindow ID="RadWindow2" runat="server" Skin="Windows7" 
                                   ReloadOnShow="True" onclientclose="RadWindowManager1_Close">
                </telerik:RadWindow>
            </td>
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


<%@ Page Language="VB" MasterPageFile="~/MasterPageGestionOperativa.master" AutoEventWireup="false"
    CodeFile="GeneracionRemesa.aspx.vb" Inherits="Seguimiento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../HojaEstilos/StyleSheet3H.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style87
        {
            width: 16%;
            border-style: none;
            border-color: inherit;
            border-width: 1;
        }
        .style89
        {
            width: 23%;
            border-style: none;
            border-color: inherit;
            border-width: 1;
        }
        .style90
        {
            width: 13%;
            border-style: none;
            border-color: inherit;
            border-width: 1;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">

            function ShowEditForm(id, rowIndex) {
                var grid = $find("<%= radSeguimiento.ClientID %>");
                var rowControl = grid.get_masterTableView().get_dataItems()[rowIndex].get_element();
                grid.get_masterTableView().selectItem(rowControl, true);
                //window.radopen("EditFormVB.aspx?EmployeeID=" + id, "UserListDialog");
                window.radopen("Seguimiento.aspx", "UserListDialog");
                return false;
            }

            function ShowInsertForm() {
                window.radopen("EditFormVB.aspx", "UserListDialog");
                return false;
            }

            function darClick() {

                var objO = document.getElementById('<%=BtnActualiza.ClientID %>');

                objO.click();

            }

            function refreshGrid(arg) {
                if (!arg) {
                    $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("Rebind");
                    darClick()
                }
                else {
                    $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("RebindAndNavigate");
                    darClick()
                }
            }
        </script>
    </telerik:RadCodeBlock>
    <br />
    <table class="centrado" style="width: 100%">
        <tr>
            <td align="center">
                <asp:Label ID="lbltittle" CssClass="centrado" runat="server" Text="Generar Remesa"></asp:Label>
            </td>
        </tr>
    </table>
    <div id="ficha_tramites">
        <fieldset>
            <table border="0" style="text-align: center; width: 90%">
                <tr>
                    <td colspan="9">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="9">
                        <br />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="table_td">
                        <asp:Label ID="Label4" runat="server" ForeColor="White" Font-Size="Small" Text="Cliente:"></asp:Label>
                    </td>
                    <td align="left" class="table_td">
                        <telerik:RadComboBox ID="cmbCliente" runat="server">
                        </telerik:RadComboBox>
                    </td>
                    <td align="right" class="table_td">
                        <asp:Label ID="idEstado" ForeColor="White" Font-Size="Small" Text="Estado:" runat="server"></asp:Label>
                    </td>
                    <td align="left" class="table_td">
                        <telerik:RadComboBox ID="cmbEstado" AutoPostBack="true" runat="server">
                        </telerik:RadComboBox>
                    </td>
                    <%--<td align="left" class="style90" rowspan="2">
                    </td>--%>
                    <td align="right" class="table_td">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Finicio" runat="server" ForeColor="White" Font-Size="Small" Text="Municipio:"></asp:Label>
                    </td>
                    <td align="left" class="table_td">
                        <telerik:RadComboBox ID="cmbMunicipio" runat="server" Culture="es-ES">
                            <Items>
                                <telerik:RadComboBoxItem runat="server" Text="--" Value="0" />
                            </Items>
                        </telerik:RadComboBox>
                    </td>
                    <td align="right" class="style87">
                        <asp:Label ID="Ffinal" runat="server" ForeColor="White" Font-Size="Small" Text="Tipo de Servicio:"></asp:Label>
                    </td>
                    <td align="left" class="style89">
                        <telerik:RadComboBox ID="cmbServicio" runat="server">
                        </telerik:RadComboBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="table_td">
                        &nbsp;
                    </td>
                    <td align="left" class="table_td">
                        &nbsp;
                    </td>
                    <td align="right" class="table_td">
                        &nbsp;
                    </td>
                    <td align="left" class="table_td">
                        &nbsp;
                    </td>
                    <td align="right" class="table_td">
                    </td>
                    <td align="left" class="table_td">
                        <%--<asp:Label ID="idRegion" Text="Región:" ForeColor="White" Font-Size="Small" runat="server"></asp:Label>--%>
                    </td>
                    <td align="right" class="style87">
                        <%--<telerik:RadComboBox ID="cmbRegion" AutoPostBack="true" runat="server"></telerik:RadComboBox>--%>
                    </td>
                    <td align="left" class="style89">
                        <%--<asp:Label ID="Label6" Text="Tipo de Seguimiento:" ForeColor="White" Font-Size="Small" runat="server"></asp:Label>--%>
                    </td>
                </tr>
                <tr>
                    <td colspan="9">
                    </td>
                </tr>
                <tr>
                    <td align="right" class="table_td">
                        <%--<asp:Label ID="Expedientes" Text="Expedientes:" ForeColor="White" Font-Size="Small" runat="server"></asp:Label>--%>
                    </td>
                    <td align="left" class="table_td">
                        <%--<asp:RadioButton ID="Rechazados" Text="Rechazados" ForeColor="White" Font-Size="Small" Font-Underline="true" runat="server"/>--%>
                    </td>
                    <td align="right" class="table_td">
                        &nbsp;
                    </td>
                    <td align="left" class="table_td">
                        &nbsp;
                    </td>
                    <td align="right" class="style90">
                        &nbsp;
                    </td>
                    <td align="right" class="table_td">
                        <%--<asp:Label ID="idRegion0" Text="Medio de Activacion:" ForeColor="White" Font-Size="Small" 
                                       runat="server"></asp:Label>--%>
                    </td>
                    <td align="left" class="table_td">
                        &nbsp;
                    </td>
                    <td align="right" class="style87">
                        <%--<telerik:RadComboBox ID="cboMedActiv" runat="server"></telerik:RadComboBox>--%>
                    </td>
                    <td align="left" class="style89">
                        <%--<asp:CheckBox ID="ChkOrdenar" runat="server" AutoPostBack="True" 
                                       Text="Ordenar Por:" />--%>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="table_td">
                    </td>
                    <td align="left" class="table_td">
                        <%--<asp:Label ID="lblPendientes" ForeColor="White" Font-Size="Small" runat="server" Text="Pendientes de concretar Citas:"></asp:Label>--%>
                    </td>
                    <td align="right" class="style87">
                        <%--<asp:Label ID="lblPendientesconcretar" Font-Size="Small" runat="server"></asp:Label>--%>
                    </td>
                    <td align="left" class="style89">
                        <%--<asp:Label ID="Label7" runat="server" ForeColor="White" Font-Size="Small" Text="Pendientes de seguimiento a trámite:"></asp:Label>--%>
                    </td>
                </tr>
                <tr>
                    <td colspan="9">
                        <asp:Button ID="BtnActualiza" runat="server" Text="" BackColor="Transparent" BorderColor="Transparent"
                            BorderStyle="None" Display="False" />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <fieldset class="ficha_tramites">
                            <table width="150px" border="0">
                                <tr>
                                    <td align="left" style="border: solid 1px #BDBDBD; width: 60px;">
                                        <asp:Label ID="citas" ForeColor="White" Font-Size="Small" Text="Total de Servicios:"
                                            runat="server"></asp:Label>
                                    </td>
                                    <td align="center" style="border: solid 1px #BDBDBD; width: 60px;">
                                        <asp:Label ID="lblNumcitas" Font-Size="Small" runat="server" Text="0"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </td>
                    <td colspan="3" align="right">
                        <telerik:RadButton runat="server" ID="btnBuscar" Text="Buscar">
                        </telerik:RadButton>
                    </td>
                </tr>
            </table>
        </fieldset>
        <br />
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" OnAjaxRequest="RadAjaxManager1_AjaxRequest">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="radSeguimiento" LoadingPanelID="gridLoadingPanel">
                        </telerik:AjaxUpdatedControl>
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="radSeguimiento">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="radSeguimiento" LoadingPanelID="gridLoadingPanel">
                        </telerik:AjaxUpdatedControl>
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
        <telerik:RadAjaxLoadingPanel runat="server" ID="gridLoadingPanel">
        </telerik:RadAjaxLoadingPanel>
        <asp:UpdatePanel ID="UpdatePanelGrid" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <telerik:RadXmlHttpPanel ID="panelGrid" runat="server" CssClass="PanelGrid" Visible="true">
                    <%--<telerik:RadButton ID="detalle1" runat="server" 
                                    Text="DetalleSeguimientoLlamada">
                                </telerik:RadButton>--%>
                   <%-- <asp:RadioButton ID="Todos" Text="Todos" ForeColor="White" Font-Size="Small" Font-Underline="true"
                        runat="server" GroupName="Seleccion" AutoPostBack="True" />
                    <asp:RadioButton ID="Ninguno" Text="Ninguno" ForeColor="White" Font-Size="Small"
                        Font-Underline="true" runat="server" GroupName="Seleccion" AutoPostBack="True" />
                    <br />
                    <br />--%>
                    <%--<telerik:RadButton ID="RadButton3" runat="server" Text="DetalleDocumento">
                                </telerik:RadButton>--%>
                    <telerik:RadGrid ID="radSeguimiento" CssClass="Grid" runat="server" BorderWidth="0px"
                        AutoGenerateColumns="False" AllowPaging="True" PageSize="20" Skin="Transparent"
                        Culture="es-ES" Width="1650px" CellSpacing="0" GridLines="None">
                        <MasterTableView>
                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                                <HeaderStyle Width="20px" />
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                                <HeaderStyle Width="20px" />
                            </ExpandCollapseColumn>
                            <Columns>
                                <%-- <telerik:GridCheckBoxColumn HeaderText="" UniqueName="Opcion"  >
                                </telerik:GridCheckBoxColumn>--%>
                                <telerik:GridTemplateColumn UniqueName="CheckBoxTemplateColumn">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="headerChkbox" OnCheckedChanged="ToggleSelectedState" AutoPostBack="true"
                                            runat="server"></asp:CheckBox>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBox1" OnCheckedChanged="ToggleRowSelection" runat="server">
                                        </asp:CheckBox>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridButtonColumn CommandName="cmdNoGestion" ButtonType="LinkButton" UniqueName="Gestion"
                                    DataTextField="NumServicio" ItemStyle-ForeColor="Blue" HeaderText="Número de Servicio">
                                    <ItemStyle ForeColor="Blue" />
                                </telerik:GridButtonColumn>    
                               <telerik:GridBoundColumn DataField="NumServicio" HeaderText="Sexo" 
                                                    SortExpression="NoGestion2" UniqueName="NoGestion2" Display="False" 
                                                    EmptyDataText=""> 
                                                </telerik:GridBoundColumn>                
                                <telerik:GridBoundColumn DataField="NumPoliza" UniqueName="Poliza" HeaderText="Número de Póliza"
                                    EmptyDataText="">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Estado" UniqueName="Estado" HeaderText="Estado"
                                    EmptyDataText="">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Municipio" UniqueName="Municipio" HeaderText="Municipio"
                                    EmptyDataText="">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Cliente" UniqueName="Cliente" HeaderText="Cliente"
                                    EmptyDataText="">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="TipoServicio" UniqueName="TipoServicio" HeaderText="Tipo de Servicio"
                                    EmptyDataText="">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="FechaActivacion" UniqueName="FechaHoraCita" HeaderText="Fecha de Activación"
                                    EmptyDataText="" DataFormatString="{0:ddd dd/MM/yyyy}">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="MedioActivacion" UniqueName="MedioActivacion"
                                    HeaderText="Medio de Activación" EmptyDataText="">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="diasTranscurridos" UniqueName="DiasTranscurridos"
                                    HeaderText="Días Transcurridos" EmptyDataText="">
                                </telerik:GridBoundColumn>
                            </Columns>
                            <EditFormSettings>
                                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                </EditColumn>
                            </EditFormSettings>
                        </MasterTableView>
                        <ClientSettings>
                            <Selecting CellSelectionMode="None" AllowRowSelect="True" />
                            <Scrolling AllowScroll="false" UseStaticHeaders="True" SaveScrollPosition="True">
                            </Scrolling>
                        </ClientSettings>
                        <FilterMenu EnableImageSprites="False">
                        </FilterMenu>
                    </telerik:RadGrid>
                    <br />
                    <telerik:RadButton runat="server" ID="btnGenerar" Text="Generar Remesa" 
                        Enabled="False">
                    </telerik:RadButton>
                    <br />
                    <telerik:RadNotification ID="RadNotification2" runat="server">
                    </telerik:RadNotification>
                </telerik:RadXmlHttpPanel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

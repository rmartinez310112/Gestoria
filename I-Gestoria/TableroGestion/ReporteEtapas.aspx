<%@ Page Language="VB" MasterPageFile="~/MasterPageGestionOperativa.master" AutoEventWireup="false" CodeFile="ReporteEtapas.aspx.vb" Inherits="TableroGestion_Desempeño" %>

<%@ Register src="../UcDesempeño/TotalesDesempeño.ascx" tagname="TotalesDesempeño" tagprefix="uc1" %>

<%@ Register src="../UcDesempeño/Fechas.ascx" tagname="Fechas" tagprefix="uc2" %>
<%@ Register src="../UcDesempeño/Combo.ascx" tagname="Combo" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <style type="text/css">
        .style1
        {
            height: 26px;
        }
        .style2
        {
            width: 100%;
        }
        .style6
        {
            height: 24px;
            width: 72px;
        }
        .style16
        {
            width: 1282px;
            height: 48px;
        }
        .style32
        {
            height: 24px;
            width: 58px;
        }
        </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr>
            <td colspan="2" 
                style="background-color:gray; font-family:@Arial Unicode MS;font-size:40px; font-weight:bolder; font-style:oblique" align="center">
                <asp:Label ID="lblSemaforo" runat="server" 
                    Text="Reporte de Servicios por Etapas"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2"/>
        </tr>
          </table>
          <table class="tableq" border="0" cellpadding="0" cellspacing="4">
    

        <tr>
            <td>
                <asp:Label ID="lblContratos" runat="server" Text="Contratos:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblServicio" runat="server" Text="Servicio:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblFecha" runat="server" Text="Fecha:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblRegion" runat="server" Text="Region:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblEstado" runat="server" Text="Estados:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblEstado0" runat="server" Text="Estatus:"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadComboBox ID="CboCliente" Runat="server" Skin="Outlook">
                </telerik:RadComboBox>
            </td>
            <td>
                <telerik:RadComboBox ID="cboServicioTipo" Runat="server" Culture="es-ES" 
                    Skin="Outlook">
                </telerik:RadComboBox>
            </td>
            <td>
                <telerik:RadComboBox ID="RadComboBox3" Runat="server" Culture="es-ES" AutoPostBack="true" Skin="Outlook"
                    OnSelectedIndexChanged="RadComboBox3_SelectedIndexChanged">
                    <Items>
                       <%-- <telerik:RadComboBoxItem runat="server" Selected="True" Text="(Seleccione)" 
                            Value="0" />--%>
                        <telerik:RadComboBoxItem Selected="true" runat="server" Text="Seleccionar" Value="0" />
                        <telerik:RadComboBoxItem Selected="true" runat="server" Text="Rango" Value="1" />
                        <telerik:RadComboBoxItem runat="server" Text="Mes" Value="2" />
                    </Items>
                </telerik:RadComboBox>
            </td>
            <td>
                <telerik:RadComboBox ID="cboRegion" AutoPostBack="true" Runat="server" Skin="Outlook">
                </telerik:RadComboBox>
            </td>
            <td>
                <telerik:RadComboBox ID="cboEstado" AutoPostBack="true" Runat="server" 
                    style="height: 16px" Skin="Outlook" >
                </telerik:RadComboBox>
            </td>
            <td>
                <telerik:RadComboBox ID="cboEstatus" AutoPostBack="True" Runat="server" 
                    style="height: 16px" Skin="Outlook" Culture="es-ES" >
                    <Items>
                        <telerik:RadComboBoxItem runat="server" Selected="True" Text="Activos" 
                            Value="1" />
                        <telerik:RadComboBoxItem runat="server" Text="Terminados" Value="0" />
                    </Items>
                </telerik:RadComboBox>
            </td>
        </tr>

        <tr>
            <td></td>
            <td></td>
            <td colspan="2">
               <asp:UpdatePanel ID="udpFiltro" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <uc2:Fechas ID="SelectorFechas" runat="server" Visible="false"/>
                        <uc3:Combo ID="ComboMes" runat="server" Visible="false" />
                    </ContentTemplate>
               </asp:UpdatePanel>
            </td>
            
            <td align="right"><telerik:RadButton ID="radBtnResultado" runat="server" Text="Buscar" Skin="Outlook">
            </telerik:RadButton>
            </td>

            <td align="right">&nbsp;</td>

        </tr>
        <tr>
            <td></td>
            <td></td>
            <td colspan="2">
              
                <br />
                               
              
            </td>
            
            <td> 
                <br />
            </td>
            
            <td> 
                &nbsp;</td>
        </tr>
        
    </table>

       <br />
    <asp:Panel ID="pnRobo" runat="server">
        <table class="style16">
            <tr>
                <td class="style32"  style=" width:55px;">
                     </td>
                <td class="style32" align="center" 
                    style=" background-position: center center; background-image: url('../Imagenes/ImgEtapas/circulo.png'); background-repeat: no-repeat;">
                     <asp:Label ID="lblTR" runat="server" ></asp:Label>
                </td>
                <td class="style32" align="center"
                    style=" background-position: center center; background-image: url('../Imagenes/ImgEtapas/circulo.png'); background-repeat: no-repeat;">
                    <asp:Label ID="lblAA" runat="server"></asp:Label></td>
                <td class="style32" align="center"
                    style=" background-position: center center; background-image: url('../Imagenes/ImgEtapas/circulo.png'); background-repeat: no-repeat;">
                    <asp:Label ID="lblDT" runat="server"></asp:Label></td>
                <td class="style32" align="center"
                    style=" background-position: center center; background-image: url('../Imagenes/ImgEtapas/circulo.png'); background-repeat: no-repeat;">
                    <asp:Label ID="lblCCC" runat="server"></asp:Label></td>
                <td class="style32" align="center"
                    style=" background-position: center center; background-image: url('../Imagenes/ImgEtapas/circulo.png'); background-repeat: no-repeat;">
                    <asp:Label ID="lblDMP" runat="server"></asp:Label></td>
                <td class="style32" align="center"
                    style=" background-position: center center; background-image: url('../Imagenes/ImgEtapas/circulo.png'); background-repeat: no-repeat;">
                    <asp:Label ID="lblAP" runat="server"></asp:Label></td>
                <td class="style32" align="center"
                    style=" background-position: center center; background-image: url('../Imagenes/ImgEtapas/circulo.png'); background-repeat: no-repeat;">
                    <asp:Label ID="lblOCCD" runat="server" style="position:relative"></asp:Label></td>
                <td class="style32" align="center"
                    style=" background-position: center center; background-image: url('../Imagenes/ImgEtapas/circulo.png'); background-repeat: no-repeat;">
                    <asp:Label ID="lblSD" runat="server" style="position:relative"></asp:Label></td>
                <td class="style32" align="center"
                    style=" background-position: center center; background-image: url('../Imagenes/ImgEtapas/circulo.png'); background-repeat: no-repeat;">
                    <asp:Label ID="lblAG" runat="server" style="position:relative"></asp:Label></td>
                <td class="style32" align="center"
                    style=" background-position: center center; background-image: url('../Imagenes/ImgEtapas/circulo.png'); background-repeat: no-repeat;">
                    <asp:Label ID="lblSPD" runat="server" style="position:relative"></asp:Label></td>
                <td class="style32" align="center"
                    style=" background-position: center center; background-image: url('../Imagenes/ImgEtapas/circulo.png'); background-repeat: no-repeat;">
                    <asp:Label ID="lblCCCII" runat="server" style="position:relative"></asp:Label></td>
                <td class="style32" align="center"
                    style=" background-position: center center; background-image: url('../Imagenes/ImgEtapas/circulo.png'); background-repeat: no-repeat;">
                    <asp:Label ID="lblRDPTA" runat="server" style="position:relative"></asp:Label></td>
                <td class="style32" align="center"
                    style=" background-position: center center; background-image: url('../Imagenes/ImgEtapas/circulo.png'); background-repeat: no-repeat;">
                    <asp:Label ID="lblRDO" runat="server" style="position:relative"></asp:Label></td>
                <td class="style32" align="center"
                    style=" background-position: center center; background-image: url('../Imagenes/ImgEtapas/circulo.png'); background-repeat: no-repeat;">
                    <asp:Label ID="lblTBP" runat="server" style="position:relative"></asp:Label></td>
                <td class="style32" align="center"
                    style=" background-position: center center; background-image: url('../Imagenes/ImgEtapas/circulo.png'); background-repeat: no-repeat;">
                    <asp:Label ID="lblED" runat="server" style="position:relative"></asp:Label></td>
                <td class="style32" align="center"
                    style="  background-position: center center; background-image: url('../Imagenes/ImgEtapas/circulo.png'); background-repeat: no-repeat;">
                    <asp:Label ID="lblIE" runat="server" style="position:relative"></asp:Label></td>
                <td class="style32" align="center"
                    style="  background-position: center center; background-image: url('../Imagenes/ImgEtapas/circulo.png'); background-repeat: no-repeat;">
                    <asp:Label ID="lblDD" runat="server" style="position:relative"></asp:Label></td>
                <td class="style32" align="center"
                    style="  background-position: center center; background-image: url('../Imagenes/ImgEtapas/circulo.png'); background-repeat: no-repeat;">
                    <asp:Label ID="lblEEF" runat="server" style="position:relative"></asp:Label></td>
                <td class="style32" align="center"
                    style="  background-position: center center; background-image: url('../Imagenes/ImgEtapas/circulo.png'); background-repeat: no-repeat;">
                    <asp:Label ID="lblAR" runat="server" style="position:relative"></asp:Label></td>
            </tr>
            <tr>
                <td class="style6" colspan="20">
                    <telerik:RadGrid ID="RadGridRobo" runat="server" AutoGenerateColumns="False" 
                        CellSpacing="0" Culture="es-ES" GridLines="None" Width="1100px">
                        <MasterTableView RetainExpandStateOnRebind="True">
                            <NoRecordsTemplate>
                                <div>
                                    No records to display</div>
                            </NoRecordsTemplate>
                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" 
                                Visible="True">
                                <HeaderStyle Width="20px" />
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" 
                                Visible="True">
                                <HeaderStyle Width="20px" />
                            </ExpandCollapseColumn>
                            <HeaderStyle Font-Bold="true" Font-Size="10" />
                            <Columns>
                                <telerik:GridBoundColumn DataField="numgestion" 
                                    FilterControlAltText="Filter column18 column" 
                                    HeaderImageUrl="~/Imagenes/ImgEtapas/Robo/Robo.png" HeaderText="robo" 
                                    UniqueName="column18">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter Toma_ReporteA column" 
                                    UniqueName="Toma_ReporteA" ItemStyle-Width="20px" HeaderImageUrl="~/Imagenes/ImgEtapas/Robo/TomaReporte.png" >
                                    <ItemTemplate>
                                                <asp:Image ID="imgToma_ReporteA" runat="server" ImageUrl="~/Imagenes/ImgEtapas/indice_amarillo.png"  />
                                    </ItemTemplate>
                                    <ItemStyle Width="20px" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="Toma_Reporte" 
                                    FilterControlAltText="Filter Toma_Reporte column" 
                                    UniqueName="Toma_Reporte">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter AsignacionAbogadoA column" 
                                    UniqueName="AsignacionAbogadoA" ItemStyle-Width="20px" HeaderImageUrl="~/Imagenes/ImgEtapas/Robo/AsigAbogado.png" >
                                    <ItemTemplate>
                                                <asp:Image ID="imgAsignacionAbogadoA" runat="server" ImageUrl="~/Imagenes/ImgEtapas/indice_amarillo.png"  />
                                    </ItemTemplate>
                                    <ItemStyle Width="20px" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="AsignacionAbogado" 
                                    FilterControlAltText="Filter AsignacionAbogado column" 
                                    UniqueName="AsignacionAbogado">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter DenunciaTelefonicaA column" 
                                    UniqueName="DenunciaTelefonicaA" ItemStyle-Width="20px" HeaderImageUrl="~/Imagenes/ImgEtapas/Robo/DenunciaTel.png" >
                                    <ItemTemplate>
                                                <asp:Image ID="imgDenunciaTelefonicaA" runat="server" ImageUrl="~/Imagenes/ImgEtapas/indice_amarillo.png"  />
                                    </ItemTemplate>
                                    <ItemStyle Width="20px" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="DenunciaTelefonica" 
                                    FilterControlAltText="Filter DenunciaTelefonica column" 
                                    UniqueName="DenunciaTelefonica">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter CitaContactoClienteA column" 
                                    UniqueName="CitaContactoClienteA" ItemStyle-Width="20px" HeaderImageUrl="~/Imagenes/ImgEtapas/Robo/CitaContactoCliente.png" >
                                    <ItemTemplate>
                                                <asp:Image ID="imgCitaContactoClienteA" runat="server" ImageUrl="~/Imagenes/ImgEtapas/indice_amarillo.png"  />
                                    </ItemTemplate>
                                    <ItemStyle Width="20px" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="CitaContactoCliente" 
                                    FilterControlAltText="Filter CitaContactoCliente column" 
                                    UniqueName="CitaContactoCliente">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter DenunciaAnteMPA column" 
                                    UniqueName="DenunciaAnteMPA" ItemStyle-Width="20px" HeaderImageUrl="~/Imagenes/ImgEtapas/Robo/DenunciaMP.png" >
                                    <ItemTemplate>
                                                <asp:Image ID="imgDenunciaAnteMPA" runat="server" ImageUrl="~/Imagenes/ImgEtapas/indice_amarillo.png"  />
                                    </ItemTemplate>
                                    <ItemStyle Width="20px" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="DenunciaAnteMP" 
                                    FilterControlAltText="Filter DenunciaAnteMP column" 
                                    UniqueName="DenunciaAnteMP">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter AcreditacionPropiedadA column" 
                                    UniqueName="AcreditacionPropiedadA" ItemStyle-Width="20px" HeaderImageUrl="~/Imagenes/ImgEtapas/Robo/AcredPropiedad.png" >
                                    <ItemTemplate>
                                                <asp:Image ID="imgAcreditacionPropiedadA" runat="server" ImageUrl="~/Imagenes/ImgEtapas/indice_amarillo.png"  />
                                    </ItemTemplate>
                                    <ItemStyle Width="20px" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="AcreditacionPropiedad" 
                                    FilterControlAltText="Filter AcreditacionPropiedad column" 
                                    UniqueName="AcreditacionPropiedad">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter ObtencionCopiasCertificadasDenunciaA column" 
                                    UniqueName="ObtencionCopiasCertificadasDenunciaA" ItemStyle-Width="20px" HeaderImageUrl="~/Imagenes/ImgEtapas/Robo/ObtCopiaCertyProp.png" >
                                    <ItemTemplate>
                                                <asp:Image ID="imgObtencionCopiasCertificadasDenunciaA" runat="server" ImageUrl="~/Imagenes/ImgEtapas/indice_amarillo.png"  />
                                    </ItemTemplate>
                                    <ItemStyle Width="20px" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="ObtencionCopiasCertificadasDenuncia" 
                                    FilterControlAltText="Filter ObtencionCopiasCertificadasDenuncia column" 
                                    UniqueName="ObtencionCopiasCertificadasDenuncia">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter SolicitudDocumentoA column" 
                                    UniqueName="SolicitudDocumentoA" ItemStyle-Width="20px" HeaderImageUrl="~/Imagenes/ImgEtapas/Robo/SolicitudDocumento.png" >
                                    <ItemTemplate>
                                                <asp:Image ID="imgSolicitudDocumentoA" runat="server" ImageUrl="~/Imagenes/ImgEtapas/indice_amarillo.png"  />
                                    </ItemTemplate>
                                    <ItemStyle Width="20px" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="SolicitudDocumento" 
                                    FilterControlAltText="Filter SolicitudDocumento column" 
                                    UniqueName="SolicitudDocumento">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter AsignacionGestorA column" 
                                    UniqueName="AsignacionGestorA" ItemStyle-Width="20px" HeaderImageUrl="~/Imagenes/ImgEtapas/Robo/AsignacionGestor.png" >
                                    <ItemTemplate>
                                                <asp:Image ID="imgAsignacionGestorA" runat="server" ImageUrl="~/Imagenes/ImgEtapas/indice_amarillo.png"  />
                                    </ItemTemplate>
                                    <ItemStyle Width="20px" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="AsignacionGestor" 
                                    FilterControlAltText="Filter AsignacionGestor column" 
                                    UniqueName="AsignacionGestor">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter SolicitudPagoDerechosA column" 
                                    UniqueName="SolicitudPagoDerechosA" ItemStyle-Width="20px" HeaderImageUrl="~/Imagenes/ImgEtapas/Robo/SolicitudPagoDerechos.png" >
                                    <ItemTemplate>
                                                <asp:Image ID="imgSolicitudPagoDerechosA" runat="server" ImageUrl="~/Imagenes/ImgEtapas/indice_amarillo.png"  />
                                    </ItemTemplate>
                                    <ItemStyle Width="20px" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="SolicitudPagoDerechos" 
                                    FilterControlAltText="Filter SolicitudPagoDerechos column" 
                                    UniqueName="SolicitudPagoDerechos">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter CitaContactoClienteIIA column" 
                                    UniqueName="CitaContactoClienteIIA" ItemStyle-Width="20px" HeaderImageUrl="~/Imagenes/ImgEtapas/Robo/CitaContactoClienteII.png" >
                                    <ItemTemplate>
                                                <asp:Image ID="imgCitaContactoClienteIIA" runat="server" ImageUrl="~/Imagenes/ImgEtapas/indice_amarillo.png"  />
                                    </ItemTemplate>
                                    <ItemStyle Width="20px" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="CitaContactoClienteII" 
                                    FilterControlAltText="Filter CitaContactoClienteII column" 
                                    UniqueName="CitaContactoClienteII">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter RecepcionDictamenPTAseguradoraA column" 
                                    UniqueName="RecepcionDictamenPTAseguradoraA" ItemStyle-Width="20px" HeaderImageUrl="~/Imagenes/ImgEtapas/Robo/RecepcionDicPTAseg.png" >
                                    <ItemTemplate>
                                                <asp:Image ID="imgRecepcionDictamenPTAseguradoraA" runat="server" ImageUrl="~/Imagenes/ImgEtapas/indice_amarillo.png"  />
                                    </ItemTemplate>
                                    <ItemStyle Width="20px" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="RecepcionDictamenPTAseguradora" 
                                    FilterControlAltText="Filter RecepcionDictamenPTAseguradora column" 
                                    UniqueName="RecepcionDictamenPTAseguradora">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter RecepcionDocOriginalesA column" 
                                    UniqueName="RecepcionDocOriginalesAA" ItemStyle-Width="20px" HeaderImageUrl="~/Imagenes/ImgEtapas/Robo/RecepcionDocOrig.png" >
                                    <ItemTemplate>
                                                <asp:Image ID="imgRecepcionDocOriginalesA" runat="server" ImageUrl="~/Imagenes/ImgEtapas/indice_amarillo.png"  />
                                    </ItemTemplate>
                                    <ItemStyle Width="20px" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="RecepcionDocOriginales" 
                                    FilterControlAltText="Filter RecepcionDocOriginales column" 
                                    UniqueName="RecepcionDocOriginales">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter TramiteBajaPlacasA column" 
                                    UniqueName="TramiteBajaPlacasA" ItemStyle-Width="20px" HeaderImageUrl="~/Imagenes/ImgEtapas/Robo/tramiteBajaPlacas.png" >
                                    <ItemTemplate>
                                                <asp:Image ID="imgTramiteBajaPlacasA" runat="server" ImageUrl="~/Imagenes/ImgEtapas/indice_amarillo.png"  />
                                    </ItemTemplate>
                                    <ItemStyle Width="20px" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="TramiteBajaPlacas" 
                                    FilterControlAltText="Filter TramiteBajaPlacas column" 
                                    UniqueName="TramiteBajaPlacas">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter EntregaDocumentosA column" 
                                    UniqueName="EntregaDocumentosA" ItemStyle-Width="20px" HeaderImageUrl="~/Imagenes/ImgEtapas/Robo/EntregaDocs.png" >
                                    <ItemTemplate>
                                                <asp:Image ID="imgEntregaDocumentosA" runat="server" ImageUrl="~/Imagenes/ImgEtapas/indice_amarillo.png"  />
                                    </ItemTemplate>
                                    <ItemStyle Width="20px" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="EntregaDocumentos" 
                                    FilterControlAltText="Filter EntregaDocumentos column" 
                                    UniqueName="EntregaDocumentos">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter IntegracionExpedienteA column" 
                                    UniqueName="IntegracionExpedienteA" ItemStyle-Width="20px" HeaderImageUrl="~/Imagenes/ImgEtapas/Robo/IntExp.png" >
                                    <ItemTemplate>
                                                <asp:Image ID="imgIntegracionExpedienteA" runat="server" ImageUrl="~/Imagenes/ImgEtapas/indice_amarillo.png"  />
                                    </ItemTemplate>
                                    <ItemStyle Width="20px" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="IntegracionExpediente" 
                                    FilterControlAltText="Filter IntegracionExpediente column" 
                                    UniqueName="IntegracionExpediente">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter DigitilizacionDocumentosA column" 
                                    UniqueName="DigitilizacionDocumentosA" ItemStyle-Width="20px" 
                                    HeaderImageUrl="~/Imagenes/ImgEtapas/Robo/DigDocs.png" >
                                    <ItemTemplate>
                                                <asp:Image ID="imgDigitilizacionDocumentosA" runat="server" ImageUrl="~/Imagenes/ImgEtapas/indice_amarillo.png"  />
                                    </ItemTemplate>
                                    <ItemStyle Width="20px" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="DigitilizacionDocumentos" 
                                    FilterControlAltText="Filter DigitilizacionDocumentos column" 
                                    UniqueName="DigitilizacionDocumentos">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter EntregaExpedienteFisicoA column" 
                                    UniqueName="EntregaExpedienteFisicoA" HeaderImageUrl="~/Imagenes/ImgEtapas/Robo/EntrageExpFisico.png">
                                    <ItemTemplate>
                                                <asp:Image ID="imgEntregaExpedienteFisicoA" runat="server" ImageUrl="~/Imagenes/ImgEtapas/indice_amarillo.png"  />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="EntregaExpedienteFisico"
                                    FilterControlAltText="Filter EntregaExpedienteFisico column" 
                                    UniqueName="EntregaExpedienteFisico">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter AcuseReciboA column" 
                                    UniqueName="AcuseReciboA"
                                    HeaderImageUrl="~/Imagenes/ImgEtapas/Robo/AcuseRecibo.png">
                                    <ItemTemplate>
                                                <asp:Image ID="imgAcuseReciboA" runat="server" ImageUrl="~/Imagenes/ImgEtapas/indice_amarillo.png"  />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="AcuseRecibo"
                                    FilterControlAltText="Filter AcuseRecibo column" 
                                    UniqueName="AcuseRecibo">
                                </telerik:GridBoundColumn>
                            </Columns>
                            <EditFormSettings>
                                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                </EditColumn>
                            </EditFormSettings>
                        </MasterTableView>
                        <FilterMenu EnableImageSprites="False">
                        </FilterMenu>
                    </telerik:RadGrid>
                </td>
            </tr>
        </table>
    </asp:Panel>

    <asp:Panel ID="pnDM" runat="server">
        <table class="style16">
            <tr>
                <td class="style32">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; </td>
                <td class="style32" align="center"
                    style=" background-position: center center; background-image: url('../Imagenes/ImgEtapas/circulo.png'); background-repeat: no-repeat;">
                    <asp:Label ID="DMlblTR" runat="server" style="position:relative"></asp:Label>
                </td>
                <td class="style32" align="center"
                    style=" background-position: center center; background-image: url('../Imagenes/ImgEtapas/circulo.png'); background-repeat: no-repeat;">
                    <asp:Label ID="DMlblSD" runat="server" style="position:relative"></asp:Label></td>
                <td class="style32" align="center"
                    style=" background-position: center center; background-image: url('../Imagenes/ImgEtapas/circulo.png'); background-repeat: no-repeat;">
                    <asp:Label ID="DMlblAG" runat="server" style="position:relative"></asp:Label></td>
                <td class="style32" align="center"
                    style=" background-position: center center; background-image: url('../Imagenes/ImgEtapas/circulo.png'); background-repeat: no-repeat;">
                    <asp:Label ID="DMlblFPD" runat="server" style="position:relative"></asp:Label></td>
                <td class="style32" align="center"
                    style=" background-position: center center; background-image: url('../Imagenes/ImgEtapas/circulo.png'); background-repeat: no-repeat;">
                    <asp:Label ID="DMlblSPD" runat="server" style="position:relative"></asp:Label></td>
                <td class="style32" align="center"
                    style=" background-position: center center; background-image: url('../Imagenes/ImgEtapas/circulo.png'); background-repeat: no-repeat;">
                    <asp:Label ID="DMlblCCC" runat="server" style="position:relative"></asp:Label></td>
                <td class="style32" align="center"
                    style=" background-position: center center; background-image: url('../Imagenes/ImgEtapas/circulo.png'); background-repeat: no-repeat;">
                    <asp:Label ID="DMlblRDO" runat="server" style="position:relative"></asp:Label></td>
                <td class="style32" align="center"
                    style=" background-position: center center; background-image: url('../Imagenes/ImgEtapas/circulo.png'); background-repeat: no-repeat;">
                    <asp:Label ID="DMlblTBP" runat="server" style="position:relative"></asp:Label></td>
                <td class="style32" align="center"
                    style=" background-position: center center; background-image: url('../Imagenes/ImgEtapas/circulo.png'); background-repeat: no-repeat;">
                    <asp:Label ID="DMlblED" runat="server" style="position:relative"></asp:Label></td>
                <td class="style32" align="center"
                    style=" background-position: center center; background-image: url('../Imagenes/ImgEtapas/circulo.png'); background-repeat: no-repeat;">
                    <asp:Label ID="DMlblIE" runat="server" style="position:relative"></asp:Label></td>
                <td class="style32" align="center"
                    style=" background-position: center center; background-image: url('../Imagenes/ImgEtapas/circulo.png'); background-repeat: no-repeat;">
                    <asp:Label ID="DMlblDD" runat="server" style="position:relative"></asp:Label></td>
                <td class="style32" align="center"
                    style=" background-position: center center; background-image: url('../Imagenes/ImgEtapas/circulo.png'); background-repeat: no-repeat;">
                    <asp:Label ID="DMlblEEF" runat="server" style="position:relative"></asp:Label></td>
                <td class="style32" align="center"
                    style=" background-position: center center; background-image: url('../Imagenes/ImgEtapas/circulo.png'); background-repeat: no-repeat;">
                    <asp:Label ID="DMlblAR" runat="server" style="position:relative"></asp:Label></td>
            </tr>
            <tr>
                <td class="style6" colspan="14">
                    <telerik:RadGrid ID="RadGridDanosMateriales" runat="server" 
                        AutoGenerateColumns="False" CellSpacing="0" Culture="es-ES" GridLines="None" 
                        Width="1100px">
                        <MasterTableView RetainExpandStateOnRebind="True">
                            <NoRecordsTemplate>
                                <div>
                                    No records to display</div>
                            </NoRecordsTemplate>
                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" 
                                Visible="True">
                                <HeaderStyle Width="20px" />
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" 
                                Visible="True">
                                <HeaderStyle Width="20px" />
                            </ExpandCollapseColumn>
                            <HeaderStyle Font-Bold="true" Font-Size="10" />
                            <Columns>
                                <telerik:GridBoundColumn FilterControlAltText="Filter column18 column" 
                                    HeaderImageUrl="~/Imagenes/ImgEtapas/DañosMateriales/Danosmat.png" 
                                    HeaderText="Daños materiales" UniqueName="column18" DataField="numgestion">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter Toma_ReporteA column" 
                                    UniqueName="Toma_ReporteA" ItemStyle-Width="20px" HeaderImageUrl="~/Imagenes/ImgEtapas/DañosMateriales/TomaReporte.png"  >
                                    <ItemTemplate>
                                                <asp:Image ID="imgToma_ReporteA" runat="server" ImageUrl="~/Imagenes/ImgEtapas/indice_amarillo.png"  />
                                    </ItemTemplate>
                                    <ItemStyle Width="20px" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="Toma_Reporte" 
                                    FilterControlAltText="Filter Toma_Reporte column" 
                                    UniqueName="Toma_Reporte">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter SolicitudDocumentos column" 
                                    UniqueName="SolicitudDocumentosA" ItemStyle-Width="20px" HeaderImageUrl="~/Imagenes/ImgEtapas/DañosMateriales/SolicitudDoc.png"  >
                                    <ItemTemplate>
                                                <asp:Image ID="imgSolicitudDocumentosA" runat="server" ImageUrl="~/Imagenes/ImgEtapas/indice_amarillo.png" />
                                    </ItemTemplate>
                                    <ItemStyle Width="20px" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="SolicitudDocumento" 
                                    FilterControlAltText="Filter SolicitudDocumentos column" 
                                    UniqueName="SolicitudDocumentos">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter AsignacionGestorA column" 
                                    UniqueName="AsignacionGestorA" ItemStyle-Width="20px" HeaderImageUrl="~/Imagenes/ImgEtapas/DañosMateriales/AsigGestor.png" >
                                    <ItemTemplate>
                                                <asp:Image ID="imgAsignacionGestorA" runat="server" ImageUrl="~/Imagenes/ImgEtapas/indice_amarillo.png" />
                                    </ItemTemplate>
                                    <ItemStyle Width="20px" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="AsignacionGestor" 
                                    FilterControlAltText="Filter AsignacionGestor column" 
                                    UniqueName="AsignacionGestor">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter FondoPagoDerechosA column" 
                                    UniqueName="FondoPagoDerechosA" ItemStyle-Width="20px" HeaderImageUrl="~/Imagenes/ImgEtapas/DañosMateriales/FondoPagoDerechos.png" >
                                    <ItemTemplate>
                                                <asp:Image ID="imgFondoPagoDerechosA" runat="server" ImageUrl="~/Imagenes/ImgEtapas/indice_amarillo.png" />
                                    </ItemTemplate>
                                    <ItemStyle Width="20px" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="FondoPagoDerechos" 
                                    FilterControlAltText="Filter FondoPagoDerechos column" 
                                    UniqueName="FondoPagoDerechos">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter SolicitudPagoDerechosA column" 
                                    UniqueName="SolicitudPagoDerechosA" ItemStyle-Width="20px" HeaderImageUrl="~/Imagenes/ImgEtapas/DañosMateriales/SolicitudPagoDerechos.png" >
                                    <ItemTemplate>
                                                <asp:Image ID="imgSolicitudPagoDerechosA" runat="server" ImageUrl="~/Imagenes/ImgEtapas/indice_amarillo.png" />
                                    </ItemTemplate>
                                    <ItemStyle Width="20px" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="SolicitudPagoDerechos" 
                                    FilterControlAltText="Filter SolicitudPagoDerechos column" 
                                    UniqueName="SolicitudPagoDerechos">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter CitaContactoClienteA column" 
                                    UniqueName="CitaContactoClienteA" ItemStyle-Width="20px" HeaderImageUrl="~/Imagenes/ImgEtapas/DañosMateriales/CitaContactoCliente.png"  >
                                    <ItemTemplate>
                                                <asp:Image ID="imgCitaContactoClienteA" runat="server" ImageUrl="~/Imagenes/ImgEtapas/indice_amarillo.png" />
                                    </ItemTemplate>
                                    <ItemStyle Width="20px" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="CitaContactoCliente" 
                                    FilterControlAltText="Filter CitaContactoCliente column" 
                                    UniqueName="CitaContactoCliente">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter RecepcionDocOriginalesA column" 
                                    UniqueName="RecepcionDocOriginalesA" ItemStyle-Width="20px" HeaderImageUrl="~/Imagenes/ImgEtapas/DañosMateriales/RecepcionDocOriginales.png" >
                                    <ItemTemplate>
                                                <asp:Image ID="imgRecepcionDocOriginalesA" runat="server" ImageUrl="~/Imagenes/ImgEtapas/indice_amarillo.png" />
                                    </ItemTemplate>
                                    <ItemStyle Width="20px" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="RecepcionDocOriginales" 
                                    FilterControlAltText="Filter RecepcionDocOriginales column" 
                                    UniqueName="RecepcionDocOriginales">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter TramiteBajaPlacasA column" 
                                    UniqueName="TramiteBajaPlacasA" ItemStyle-Width="20px" HeaderImageUrl="~/Imagenes/ImgEtapas/DañosMateriales/TramiteBajaPlacas.png"  >
                                    <ItemTemplate>
                                                <asp:Image ID="imgTramiteBajaPlacasA" runat="server" ImageUrl="~/Imagenes/ImgEtapas/indice_amarillo.png" />
                                    </ItemTemplate>
                                    <ItemStyle Width="20px" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="TramiteBajaPlacas" 
                                    FilterControlAltText="Filter TramiteBajaPlacas column" 
                                    UniqueName="TramiteBajaPlacas">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter EntregaDocumentosA column" 
                                    UniqueName="EntregaDocumentosA" ItemStyle-Width="20px" HeaderImageUrl="~/Imagenes/ImgEtapas/DañosMateriales/EntregaDocs.png" >
                                    <ItemTemplate>
                                                <asp:Image ID="imgEntregaDocumentosA" runat="server" ImageUrl="~/Imagenes/ImgEtapas/indice_amarillo.png" />
                                    </ItemTemplate>
                                    <ItemStyle Width="20px" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="EntregaDocumentos" 
                                    FilterControlAltText="Filter EntregaDocumentos column" 
                                    UniqueName="EntregaDocumentos">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter IntegracionExpedienteA column" 
                                    UniqueName="IntegracionExpedienteA" ItemStyle-Width="20px" HeaderImageUrl="~/Imagenes/ImgEtapas/DañosMateriales/IntegExpediente.png" >
                                    <ItemTemplate>
                                                <asp:Image ID="imgIntegracionExpedienteA" runat="server" ImageUrl="~/Imagenes/ImgEtapas/indice_amarillo.png" />
                                    </ItemTemplate>
                                    <ItemStyle Width="20px" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="IntegracionExpediente" 
                                    FilterControlAltText="Filter IntegracionExpediente column" 
                                    UniqueName="IntegracionExpediente">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter DigitilizacionDocumentosA column" 
                                    UniqueName="DigitilizacionDocumentosA" ItemStyle-Width="20px" HeaderImageUrl="~/Imagenes/ImgEtapas/DañosMateriales/DigDocs.png" >
                                    <ItemTemplate>
                                                <asp:Image ID="imgDigitilizacionDocumentosA" runat="server" ImageUrl="~/Imagenes/ImgEtapas/indice_amarillo.png" />
                                    </ItemTemplate>
                                    <ItemStyle Width="20px" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="DigitilizacionDocumentos" 
                                    FilterControlAltText="Filter DigitilizacionDocumentos column" 
                                    UniqueName="DigitilizacionDocumentos">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter EntregaExpedienteFisicoA column" 
                                    UniqueName="EntregaExpedienteFisicoA" ItemStyle-Width="20px" HeaderImageUrl="~/Imagenes/ImgEtapas/DañosMateriales/EntregaExpFisico.png"  >
                                    <ItemTemplate>
                                                <asp:Image ID="imgEntregaExpedienteFisicoA" runat="server" ImageUrl="~/Imagenes/ImgEtapas/indice_amarillo.png" />
                                    </ItemTemplate>
                                    <ItemStyle Width="20px" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="EntregaExpedienteFisico" 
                                    FilterControlAltText="Filter EntregaExpedienteFisico column" 
                                    UniqueName="EntregaExpedienteFisico">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter AcuseReciboA column" 
                                    UniqueName="AcuseReciboA" ItemStyle-Width="20px" HeaderImageUrl="~/Imagenes/ImgEtapas/DañosMateriales/AcuseRecibo.png"  >
                                    <ItemTemplate>
                                                <asp:Image ID="imgAcuseReciboA" runat="server" ImageUrl="~/Imagenes/ImgEtapas/indice_amarillo.png" />
                                    </ItemTemplate>
                                    <ItemStyle Width="20px" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="AcuseRecibo" 
                                    FilterControlAltText="Filter AcuseRecibo column" 
                                    UniqueName="AcuseRecibo">
                                </telerik:GridBoundColumn>
                            </Columns>
                            <EditFormSettings>
                                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                </EditColumn>
                            </EditFormSettings>
                        </MasterTableView>
                        <FilterMenu EnableImageSprites="False">
                        </FilterMenu>
                    </telerik:RadGrid>
                </td>
            </tr>
        </table>
    </asp:Panel>

    <asp:Panel ID="pnFallecimiento" runat="server">
        <table class="style16">
            <tr>
                <td class="style32">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                <td class="style32" align="center"
                    style=" background-position: center center; background-image: url('../Imagenes/ImgEtapas/circulo.png'); background-repeat: no-repeat;">
                    <asp:Label ID="FlblTR" runat="server" style="position:relative"></asp:Label>
                </td>
                <td class="style32" align="center"
                    style=" background-position: center center; background-image: url('../Imagenes/ImgEtapas/circulo.png'); background-repeat: no-repeat;">
                    <asp:Label ID="FlblSD" runat="server" style="position:relative"></asp:Label></td>
                <td class="style32" align="center"
                    style=" background-position: center center; background-image: url('../Imagenes/ImgEtapas/circulo.png'); background-repeat: no-repeat;">
                    <asp:Label ID="FlblAG" runat="server" style="position:relative"></asp:Label></td>
                <td class="style32" align="center"
                    style=" background-position: center center; background-image: url('../Imagenes/ImgEtapas/circulo.png'); background-repeat: no-repeat;">
                    <asp:Label ID="FlblFPD" runat="server" style="position:relative"></asp:Label></td>
                <td class="style32" align="center"
                    style=" background-position: center center; background-image: url('../Imagenes/ImgEtapas/circulo.png'); background-repeat: no-repeat;">
                    <asp:Label ID="FlblSPD" runat="server" style="position:relative"></asp:Label></td>
                <td class="style32" align="center"
                    style=" background-position: center center; background-image: url('../Imagenes/ImgEtapas/circulo.png'); background-repeat: no-repeat;">
                    <asp:Label ID="FlblCCC" runat="server" style="position:relative"></asp:Label></td>
                <td class="style32" align="center"
                    style=" background-position: center center; background-image: url('../Imagenes/ImgEtapas/circulo.png'); background-repeat: no-repeat;">
                    <asp:Label ID="FlblRDO" runat="server" style="position:relative"></asp:Label></td>
                <td class="style32" align="center"
                    style=" background-position: center center; background-image: url('../Imagenes/ImgEtapas/circulo.png'); background-repeat: no-repeat;">
                    <asp:Label ID="FlblGF" runat="server" style="position:relative"></asp:Label></td>
                <td class="style32" align="center"
                    style=" background-position: center center; background-image: url('../Imagenes/ImgEtapas/circulo.png'); background-repeat: no-repeat;">
                    <asp:Label ID="FlblED" runat="server" style="position:relative"></asp:Label></td>
                <td class="style32" align="center"
                    style=" background-position: center center; background-image: url('../Imagenes/ImgEtapas/circulo.png'); background-repeat: no-repeat;">
                    <asp:Label ID="FlblIE" runat="server" style="position:relative"></asp:Label></td>
                <td class="style32" align="center"
                    style=" background-position: center center; background-image: url('../Imagenes/ImgEtapas/circulo.png'); background-repeat: no-repeat;">
                    <asp:Label ID="FlblDD" runat="server" style="position:relative"></asp:Label></td>
                <td class="style32" align="center"
                    style=" background-position: center center; background-image: url('../Imagenes/ImgEtapas/circulo.png'); background-repeat: no-repeat;">
                    <asp:Label ID="FlblEEF" runat="server" style="position:relative"></asp:Label></td>
                <td class="style32" align="center"
                    style=" background-position: center center; background-image: url('../Imagenes/ImgEtapas/circulo.png'); background-repeat: no-repeat;">
                    <asp:Label ID="FlblAR" runat="server" style="position:relative"></asp:Label></td>
            </tr>
            <tr>
                <td class="style6" colspan="14">
                    <telerik:RadGrid ID="RadGridFallecimiento" runat="server" 
                        AutoGenerateColumns="False" CellSpacing="0" Culture="es-ES" GridLines="None" 
                        Width="1100px">
                        <MasterTableView RetainExpandStateOnRebind="True">
                            <NoRecordsTemplate>
                                <div>
                                    No records to display</div>
                            </NoRecordsTemplate>
                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" 
                                Visible="True">
                                <HeaderStyle Width="1px" />
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" 
                                Visible="True">
                                <HeaderStyle Width="1px" />
                            </ExpandCollapseColumn>
                            <HeaderStyle Font-Bold="true" Font-Size="10" />
                            <Columns>
                                <telerik:GridBoundColumn DataField="numgestion" 
                                    FilterControlAltText="Filter column18 column" 
                                    UniqueName="column18"
                                    HeaderImageUrl="~/Imagenes/ImgEtapas/Fallecimiento/Fallecimiento.png">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter Toma_ReporteA column" 
                                    UniqueName="Toma_ReporteA" ItemStyle-Width="20px" HeaderImageUrl="~/Imagenes/ImgEtapas/Fallecimiento/TomaReporte.png" >
                                    <ItemTemplate>
                                                <asp:Image ID="imgToma_ReporteA" runat="server" ImageUrl="~/Imagenes/ImgEtapas/indice_amarillo.png" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="Toma_Reporte" 
                                    FilterControlAltText="Filter Toma_Reporte column" 
                                    UniqueName="Toma_Reporte">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter SolicitudDocumentoA column" 
                                    UniqueName="SolicitudDocumentoA" ItemStyle-Width="20px" HeaderImageUrl="~/Imagenes/ImgEtapas/Fallecimiento/SolDocs.png"  >
                                    <ItemTemplate>
                                                <asp:Image ID="imgSolicitudDocumentoA" runat="server" ImageUrl="~/Imagenes/ImgEtapas/indice_amarillo.png" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="SolicitudDocumento" 
                                    FilterControlAltText="Filter SolicitudDocumento column" UniqueName="SolicitudDocumento" >
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter AsignacionGestorA column" 
                                    UniqueName="AsignacionGestorA" ItemStyle-Width="20px" HeaderImageUrl="~/Imagenes/ImgEtapas/Fallecimiento/AsigGestor.png"  >
                                    <ItemTemplate>
                                                <asp:Image ID="imgAsignacionGestorA" runat="server" ImageUrl="~/Imagenes/ImgEtapas/indice_amarillo.png" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="AsignacionGestor" 
                                    FilterControlAltText="Filter AsignacionGestorA column" UniqueName="AsignacionGestor" >
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter FondoPagoDerechosA column" 
                                    UniqueName="FondoPagoDerechosA" ItemStyle-Width="20px" HeaderImageUrl="~/Imagenes/ImgEtapas/Fallecimiento/FondoPagoDerechos.png"  >
                                    <ItemTemplate>
                                                <asp:Image ID="imgFondoPagoDerechosA" runat="server" ImageUrl="~/Imagenes/ImgEtapas/indice_amarillo.png" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="FondoPagoDerechos" 
                                    FilterControlAltText="Filter FondoPagoDerechos column" UniqueName="FondoPagoDerechos">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter SolicitudPagoDerechosA column" 
                                    UniqueName="SolicitudPagoDerechosA" ItemStyle-Width="20px" HeaderImageUrl="~/Imagenes/ImgEtapas/Fallecimiento/SolPagoDerechos.png" >
                                    <ItemTemplate>
                                                <asp:Image ID="imgSolicitudPagoDerechosA" runat="server" ImageUrl="~/Imagenes/ImgEtapas/indice_amarillo.png" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="SolicitudPagoDerechos" 
                                    FilterControlAltText="Filter SolicitudPagoDerechos column" 
                                    UniqueName="SolicitudPagoDerechos">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter CitaContactoClienteA column" 
                                    UniqueName="CitaContactoClienteA" ItemStyle-Width="20px" HeaderImageUrl="~/Imagenes/ImgEtapas/Fallecimiento/CItaContactoCliente.png"  >
                                    <ItemTemplate>
                                                <asp:Image ID="imgCitaContactoClienteA" runat="server" ImageUrl="~/Imagenes/ImgEtapas/indice_amarillo.png" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="CitaContactoCliente" 
                                    FilterControlAltText="Filter CitaContactoCliente column" UniqueName="CitaContactoCliente" >
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter RecepcionDocOriginalesA column" 
                                    UniqueName="RecepcionDocOriginalesA" ItemStyle-Width="20px" HeaderImageUrl="~/Imagenes/ImgEtapas/Fallecimiento/RecepcionDocOriginales.png" >
                                    <ItemTemplate>
                                                <asp:Image ID="imgRecepcionDocOriginalesA" runat="server" ImageUrl="~/Imagenes/ImgEtapas/indice_amarillo.png" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="RecepcionDocOriginales" 
                                    FilterControlAltText="Filter RecepcionDocOriginalesA column" 
                                    UniqueName="RecepcionDocOriginales">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter GestoriaFallecimientoA column" 
                                    UniqueName="GestoriaFallecimientoA" ItemStyle-Width="20px" HeaderImageUrl="~/Imagenes/ImgEtapas/Fallecimiento/GestoriaFallecimiento.png" >
                                    <ItemTemplate>
                                                <asp:Image ID="imgGestoriaFallecimientoA" runat="server" ImageUrl="~/Imagenes/ImgEtapas/indice_amarillo.png" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="GestoriaFallecimiento" 
                                    FilterControlAltText="Filter GestoriaFallecimiento column" 
                                    UniqueName="GestoriaFallecimiento" >
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter EntregaDocumentosA column" 
                                    UniqueName="EntregaDocumentosA" ItemStyle-Width="20px" HeaderImageUrl="~/Imagenes/ImgEtapas/Fallecimiento/EntregaDocs.png"  >
                                    <ItemTemplate>
                                                <asp:Image ID="imgEntregaDocumentosA" runat="server" ImageUrl="~/Imagenes/ImgEtapas/indice_amarillo.png" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="EntregaDocumentos" 
                                    FilterControlAltText="Filter EntregaDocumento column" 
                                    UniqueName="EntregaDocumentos">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter IntegracionExpedienteA column" 
                                    UniqueName="IntegracionExpedienteA" ItemStyle-Width="20px" HeaderImageUrl="~/Imagenes/ImgEtapas/Fallecimiento/IntegracionExp.png" >
                                    <ItemTemplate>
                                                <asp:Image ID="imgIntegracionExpedienteA" runat="server" ImageUrl="~/Imagenes/ImgEtapas/indice_amarillo.png" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="IntegracionExpediente" 
                                    FilterControlAltText="Filter IntegracionExpediente column" 
                                    UniqueName="IntegracionExpediente">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter DigitilizacionDocumentosA column" 
                                    UniqueName="DigitilizacionDocumentosA" ItemStyle-Width="20px" HeaderImageUrl="~/Imagenes/ImgEtapas/Fallecimiento/DigDocs.png"  >
                                    <ItemTemplate>
                                                <asp:Image ID="imgDigitilizacionDocumentosA" runat="server" ImageUrl="~/Imagenes/ImgEtapas/indice_amarillo.png" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="DigitilizacionDocumentos" 
                                    FilterControlAltText="Filter column12 column" UniqueName="DigitilizacionDocumentos">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter EntregaExpedienteFisicoA column" 
                                    UniqueName="EntregaExpedienteFisicoA" ItemStyle-Width="20px" HeaderImageUrl="~/Imagenes/ImgEtapas/Fallecimiento/EntregaExpFisico.png" >
                                    <ItemTemplate>
                                                <asp:Image ID="imgEntregaExpedienteFisicoA" runat="server" ImageUrl="~/Imagenes/ImgEtapas/indice_amarillo.png" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="EntregaExpedienteFisico" 
                                    FilterControlAltText="Filter column13 column" UniqueName="EntregaExpedienteFisico">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter AcuseReciboA column" 
                                    UniqueName="AcuseReciboA" ItemStyle-Width="20px" HeaderImageUrl="~/Imagenes/ImgEtapas/Fallecimiento/AcuseRecibo.png" >
                                    <ItemTemplate>
                                                <asp:Image ID="imgAcuseReciboA" runat="server" ImageUrl="~/Imagenes/ImgEtapas/indice_amarillo.png" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="AcuseRecibo" 
                                    FilterControlAltText="Filter column14 column" 
                                    UniqueName="AcuseRecibo">
                                </telerik:GridBoundColumn>
                            </Columns>
                            <EditFormSettings>
                                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                </EditColumn>
                            </EditFormSettings>
                        </MasterTableView>
                        <FilterMenu EnableImageSprites="False">
                        </FilterMenu>
                    </telerik:RadGrid>
                </td>
            </tr>
        </table>
    </asp:Panel>

    <asp:Panel ID="pnInvalidez" runat="server" ScrollBars="Horizontal">
        <table class="style16">
            <tr>
                <td class="style32">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
                <td class="style32" align="center"
                    style=" background-position: center center; background-image: url('../Imagenes/ImgEtapas/circulo.png'); background-repeat: no-repeat;">
                    <asp:Label ID="IlblTR" runat="server" style="position:relative"></asp:Label>
                </td>
                <td class="style32" align="center"
                    style=" background-position: center center; background-image: url('../Imagenes/ImgEtapas/circulo.png'); background-repeat: no-repeat;">
                    <asp:Label ID="IlblSD" runat="server" style="position:relative"></asp:Label></td>
                <td class="style32" align="center"
                    style=" background-position: center center; background-image: url('../Imagenes/ImgEtapas/circulo.png'); background-repeat: no-repeat;">
                    <asp:Label ID="IlblAG" runat="server" style="position:relative"></asp:Label></td>
                <td class="style32" align="center"
                    style=" background-position: center center; background-image: url('../Imagenes/ImgEtapas/circulo.png'); background-repeat: no-repeat;">
                    <asp:Label ID="IlblFPD" runat="server" style="position:relative"></asp:Label></td>
                <td class="style32" align="center"
                    style=" background-position: center center; background-image: url('../Imagenes/ImgEtapas/circulo.png'); background-repeat: no-repeat;">
                    <asp:Label ID="IlblSPD" runat="server" style="position:relative"></asp:Label></td>
                <td class="style32" align="center"
                    style=" background-position: center center; background-image: url('../Imagenes/ImgEtapas/circulo.png'); background-repeat: no-repeat;">
                    <asp:Label ID="IlblCCC" runat="server" style="position:relative"></asp:Label></td>
                <td class="style32" align="center"
                    style=" background-position: center center; background-image: url('../Imagenes/ImgEtapas/circulo.png'); background-repeat: no-repeat;">
                    <asp:Label ID="IlblRDO" runat="server" style="position:relative"></asp:Label></td>
                <td class="style32" align="center"
                    style=" background-position: center center; background-image: url('../Imagenes/ImgEtapas/circulo.png'); background-repeat: no-repeat;">
                    <asp:Label ID="IlblGI" runat="server" style="position:relative"></asp:Label></td>
                <td class="style32" align="center"
                    style=" background-position: center center; background-image: url('../Imagenes/ImgEtapas/circulo.png'); background-repeat: no-repeat;">
                    <asp:Label ID="IlblED" runat="server" style="position:relative"></asp:Label></td>
                <td class="style32" align="center"
                    style=" background-position: center center; background-image: url('../Imagenes/ImgEtapas/circulo.png'); background-repeat: no-repeat;">
                    <asp:Label ID="IlblIE" runat="server" style="position:relative"></asp:Label></td>
                <td class="style32" align="center"
                    style=" background-position: center center; background-image: url('../Imagenes/ImgEtapas/circulo.png'); background-repeat: no-repeat;">
                    <asp:Label ID="IlblDD" runat="server" style="position:relative"></asp:Label></td>
                <td class="style32" align="center"
                    style=" background-position: center center; background-image: url('../Imagenes/ImgEtapas/circulo.png'); background-repeat: no-repeat;">
                    <asp:Label ID="IlblEEF" runat="server" style="position:relative"></asp:Label></td>
                <td class="style32" align="center"
                    style=" background-position: center center; background-image: url('../Imagenes/ImgEtapas/circulo.png'); background-repeat: no-repeat;">
                    <asp:Label ID="IlblAR" runat="server" style="position:relative"></asp:Label></td>
            </tr>
            <tr>
                <td class="style6" colspan="14">
                    <telerik:RadGrid ID="RadGridInvalidez" runat="server" 
                        AutoGenerateColumns="False" CellSpacing="0" Culture="es-ES" GridLines="None" 
                        Width="1100px">
                        <MasterTableView RetainExpandStateOnRebind="True">
                            <NoRecordsTemplate>
                                <div>
                                    No records to display</div>
                            </NoRecordsTemplate>
                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" 
                                Visible="True">
                                <HeaderStyle Width="1px" />
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" 
                                Visible="True">
                                <HeaderStyle Width="1px" />
                            </ExpandCollapseColumn>
                            <HeaderStyle Font-Bold="true" Font-Size="10" />
                            <Columns>
                                <telerik:GridBoundColumn DataField="numgestion" 
                                    FilterControlAltText="Filter column18 column" 
                                    HeaderImageUrl="~/Imagenes/ImgEtapas/Invalidez/Invalidez.png" 
                                    HeaderText="Invalidez" UniqueName="column18" >
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter Toma_ReporteA column" 
                                    UniqueName="Toma_ReporteA" ItemStyle-Width="20px" HeaderImageUrl="~/Imagenes/ImgEtapas/Invalidez/TomaReporte.png">
                                    <ItemTemplate>
                                                <asp:Image ID="imgToma_ReporteA" runat="server" ImageUrl="~/Imagenes/ImgEtapas/indice_amarillo.png" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="Toma_Reporte" 
                                    FilterControlAltText="Filter Toma_Reporte column" SortExpression="Toma_Reporte" 
                                    UniqueName="Toma_Reporte">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter SolicitudDocumentoA column" 
                                    UniqueName="SolicitudDocumentoA" HeaderImageUrl="~/Imagenes/ImgEtapas/Invalidez/SolDocs.png">
                                    <ItemTemplate>
                                                <asp:Image ID="imgSolicitudDocumentoA" runat="server" ImageUrl="~/Imagenes/ImgEtapas/indice_amarillo.png" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="SolicitudDocumento" 
                                    FilterControlAltText="Filter column1 column" UniqueName="SolicitudDocumento">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter AsignacionGestorA column" 
                                    UniqueName="AsignacionGestorA" HeaderImageUrl="~/Imagenes/ImgEtapas/Invalidez/AsigGestor.png">
                                    <ItemTemplate>
                                                <asp:Image ID="imgAsignacionGestorA" runat="server" ImageUrl="~/Imagenes/ImgEtapas/indice_amarillo.png" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="AsignacionGestor" 
                                    FilterControlAltText="Filter column2 column" UniqueName="AsignacionGestor">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter FondoPagoDerechosA column" 
                                    UniqueName="FondoPagoDerechosA" HeaderImageUrl="~/Imagenes/ImgEtapas/Invalidez/FondoPagoDerechos.png">
                                    <ItemTemplate>
                                                <asp:Image ID="imgFondoPagoDerechosA" runat="server" ImageUrl="~/Imagenes/ImgEtapas/indice_amarillo.png" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="FondoPagoDerechos" 
                                    FilterControlAltText="Filter column5 column" UniqueName="FondoPagoDerechos">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter SolicitudPagoDerechosA column" 
                                    UniqueName="SolicitudPagoDerechosA" HeaderImageUrl="~/Imagenes/ImgEtapas/Invalidez/SolPagoDerechos.png">
                                    <ItemTemplate>
                                                <asp:Image ID="imgSolicitudPagoDerechosA" runat="server" ImageUrl="~/Imagenes/ImgEtapas/indice_amarillo.png" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="SolicitudPagoDerechos" 
                                    FilterControlAltText="Filter column6 column" UniqueName="SolicitudPagoDerechos">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter CitaContactoClienteA column" 
                                    UniqueName="CitaContactoClienteA" HeaderImageUrl="~/Imagenes/ImgEtapas/Invalidez/CitaContactoClientes.png">
                                    <ItemTemplate>
                                                <asp:Image ID="imgCitaContactoClienteA" runat="server" ImageUrl="~/Imagenes/ImgEtapas/indice_amarillo.png" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="CitaContactoCliente" 
                                    FilterControlAltText="Filter column7 column" UniqueName="CitaContactoCliente">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter RecepcionDocOriginalesA column" 
                                    UniqueName="RecepcionDocOriginalesA" HeaderImageUrl="~/Imagenes/ImgEtapas/Invalidez/RecepcionDocsOrig.png">
                                    <ItemTemplate>
                                                <asp:Image ID="imgRecepcionDocOriginalesA" runat="server" ImageUrl="~/Imagenes/ImgEtapas/indice_amarillo.png" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="RecepcionDocOriginales" 
                                    FilterControlAltText="Filter column8 column" 
                                    UniqueName="RecepcionDocOriginales">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter GestoriaInvalidezA column" 
                                    UniqueName="GestoriaInvalidezA" HeaderImageUrl="~/Imagenes/ImgEtapas/Invalidez/GestoriaInvalidez.png">
                                    <ItemTemplate>
                                                <asp:Image ID="imgGestoriaInvalidezA" runat="server" ImageUrl="~/Imagenes/ImgEtapas/indice_amarillo.png" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="GestoriaInvalidez" 
                                    FilterControlAltText="Filter column9 column" 
                                    UniqueName="GestoriaInvalidez">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter EntregaDocumentosA column" 
                                    UniqueName="EntregaDocumentosA" HeaderImageUrl="~/Imagenes/ImgEtapas/Invalidez/EntregaDocs.png">
                                    <ItemTemplate>
                                                <asp:Image ID="imgEntregaDocumentosA" runat="server" ImageUrl="~/Imagenes/ImgEtapas/indice_amarillo.png" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="EntregaDocumentos" 
                                    FilterControlAltText="Filter column10 column" 
                                    UniqueName="EntregaDocumentos">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter IntegracionExpedienteA column" 
                                    UniqueName="IntegracionExpedienteA" HeaderImageUrl="~/Imagenes/ImgEtapas/Invalidez/IntExp.png">
                                    <ItemTemplate>
                                                <asp:Image ID="imgIntegracionExpedienteA" runat="server" ImageUrl="~/Imagenes/ImgEtapas/indice_amarillo.png" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="IntegracionExpediente" 
                                    FilterControlAltText="Filter column11 column" 
                                    UniqueName="IntegracionExpediente">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter DigitilizacionDocumentosA column" 
                                    UniqueName="DigitilizacionDocumentosA" HeaderImageUrl="~/Imagenes/ImgEtapas/Invalidez/DigDocs.png">
                                    <ItemTemplate>
                                                <asp:Image ID="imgDigitilizacionDocumentosA" runat="server" ImageUrl="~/Imagenes/ImgEtapas/indice_amarillo.png" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="DigitilizacionDocumentos" 
                                    FilterControlAltText="Filter column12 column" 
                                    UniqueName="DigitilizacionDocumentos">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter EntregaExpedienteFisicoA column" 
                                    UniqueName="EntregaExpedienteFisicoA" HeaderImageUrl="~/Imagenes/ImgEtapas/Invalidez/EntregaExpFisico.png">
                                    <ItemTemplate>
                                                <asp:Image ID="imgEntregaExpedienteFisicoA" runat="server" ImageUrl="~/Imagenes/ImgEtapas/indice_amarillo.png" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="EntregaExpedienteFisico" 
                                    FilterControlAltText="Filter column13 column" 
                                    UniqueName="EntregaExpedienteFisico">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter AcuseReciboA column" 
                                    UniqueName="AcuseReciboA" HeaderImageUrl="~/Imagenes/ImgEtapas/Invalidez/AcuseRecibo.png">
                                    <ItemTemplate>
                                                <asp:Image ID="imgAcuseReciboA" runat="server" ImageUrl="~/Imagenes/ImgEtapas/indice_amarillo.png" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="AcuseRecibo" 
                                    FilterControlAltText="Filter column14 column" UniqueName="AcuseRecibo">
                                </telerik:GridBoundColumn>
                            </Columns>
                            <EditFormSettings>
                                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                </EditColumn>
                            </EditFormSettings>
                        </MasterTableView>
                        <FilterMenu EnableImageSprites="False">
                        </FilterMenu>
                    </telerik:RadGrid>
                </td>
            </tr>
        </table>
    </asp:Panel>
       <table>  
        <tr>
            <td style="width:100px;margin:center;">
                <br />
                <br />
                <br />
                <br />
            </td>
            
        </tr>
        <tr>
        <td>
         <telerik:RadNotification ID="RadNotification1" runat="server">
    </telerik:RadNotification>
        </td>
        </tr>
        <tr>
        <td class="style1">

            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

        </td>
        </tr>
    </table>
    

   
    </asp:Content>
    
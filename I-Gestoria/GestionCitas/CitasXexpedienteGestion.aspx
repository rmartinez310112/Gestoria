<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGestionOperativa.master" AutoEventWireup="false" CodeFile="CitasXexpedienteGestion.aspx.vb" Inherits="GestionCitas_CitasXexpedienteGestion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy2" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadAjaxPanel1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadAjaxPanel1" 
                                                LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="" Transparency="30">
        <div class="loading">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/preloader.gif" AlternateText="loading">
            </asp:Image>
        </div>
    </telerik:RadAjaxLoadingPanel>



    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server"
                          LoadingPanelID="RadAjaxLoadingPanel1">
        <table cellspacing="1" class="style7">
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <telerik:RadScheduler ID="RadScheduler1" runat="server" Culture="es-ES" 
                                          DataDescriptionField="Description" DataEndField="End" DataKeyField="ID" 
                                          DataRecurrenceField="RecurrenceRule" 
                                          DataRecurrenceParentKeyField="RecurrenceParentID" DataReminderField="Reminder" 
                                          DataSourceID="Citas" DataStartField="Start" DataSubjectField="Subject" 
                                          EnableDescriptionField="True" Skin="Hay">
                        <Localization AdvancedNewAppointment="Nueva Cita" AdvancedSubject="Asunto:" 
                                      HeaderDay="Dia" HeaderMonth="Mes" HeaderTimeline="Todo" HeaderToday="Hoy " 
                                      HeaderWeek="Semana" Save="Guardar" Show24Hours="Mostrar 24 Hrs." />
                        <Reminders Enabled="True" />
                    </telerik:RadScheduler>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <asp:SqlDataSource ID="Citas" runat="server" 
                                       ConnectionString="<%$ ConnectionStrings:ConnStringSQL %>" 
                                       SelectCommand="SELECT * FROM [AppointmentsGestion]"></asp:SqlDataSource>
                </td>
            </tr>
        </table>
    </telerik:RadAjaxPanel>
</asp:Content>


﻿<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGestionOperativa.master" AutoEventWireup="false" CodeFile="WebCitasXusuario.aspx.vb" Inherits="Frm_citas_WebCitasXusuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../HojaEstilos/StyleSheet3H.css" rel="stylesheet" type="text/css" />


    <table class="style2">
        <tr>
            <td>
                <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
                    <AjaxSettings>
                        <telerik:AjaxSetting AjaxControlID="RadAjaxPanel1">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="RadAjaxPanel1"  LoadingPanelID="RadAjaxLoadingPanel1"/>
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                    </AjaxSettings>
                </telerik:RadAjaxManagerProxy>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" Runat="server" 
                                             MinDisplayTime="500" Skin="Default">
                </telerik:RadAjaxLoadingPanel>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" height="100%" 
                                      width="100%">
                    <table class="style2">
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="20pt" 
                                           Text="Control de citas Sin Expediente Asignado (Cita Libre)" 
                                           CssClass="Titulos"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButtonList ID="rblTipoCita" runat="server" AutoPostBack="True" 
                                                     RepeatDirection="Horizontal" CssClass="letrasdetodo">
                                    <asp:ListItem Value="1">
                                        Asignada al Expediente
                                    </asp:ListItem>
                                    <asp:ListItem Value="2">
                                        Sin Expediente Asignado (Cita Libre)
                                    </asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <telerik:RadScheduler ID="RadScheduler1" runat="server" 
                                                      Culture="Spanish (Mexico)" DataDescriptionField="Description" 
                                                      DataEndField="End" DataKeyField="ID" DataRecurrenceField="RecurrenceRule" 
                                                      DataRecurrenceParentKeyField="RecurrenceParentID" DataReminderField="Reminder" 
                                                      DataSourceID="AppointmentsDataSource" DataStartField="Start" 
                                                      DataSubjectField="Subject" EnableDescriptionField="True" Skin="Hay" 
                                                      StartInsertingInAdvancedForm="True" Width="895px" 
                                    WorkDayEndTime="19:00:00">
                                    <Localization AdvancedAllDayEvent="Todos los dias" 
                                                  AdvancedCalendarCancel="Cancelar" AdvancedCalendarOK="Aceptar" 
                                                  AdvancedCalendarToday="Hoy" AdvancedClose="Cerrar" AdvancedDaily="Diario" 
                                                  AdvancedDay="Dia" AdvancedDays="dia(s)" AdvancedDescription="Descripción" 
                                                  AdvancedDone="Hecho" AdvancedEditAppointment="Editar Cita" 
                                                  AdvancedEndAfter="Despues de" AdvancedEndByThisDate="Por Fin" 
                                                  AdvancedEndDateRequired="La fecha final es requerida" 
                                                  AdvancedEndTimeRequired="La hora final es requerida" AdvancedEvery="Cada" 
                                                  AdvancedEveryWeekday="Cada dia de la semana" AdvancedFirst="primero" 
                                                  AdvancedFourth="cuarto" AdvancedFrom="Hora de inicio" 
                                                  AdvancedHourly="Cada hora" AdvancedHours="Hora(s)" 
                                                  AdvancedInvalidNumber="Numero invalido" AdvancedLast="proximo" 
                                                  AdvancedMaskDay="dia" AdvancedMaskWeekday="dia laborable" 
                                                  AdvancedMaskWeekendDay="fin de semana" AdvancedMonthly="Mensual" 
                                                  AdvancedMonths="mese(s)" AdvancedNewAppointment="Nueva Cita" 
                                                  AdvancedNoEndDate="Sin fecha Final" AdvancedOccurrences="ocurrencia" 
                                                  AdvancedOf="de" AdvancedOfEvery="de cada" AdvancedRecurEvery="se repite cada" 
                                                  AdvancedRecurrence="Recurrencia" AdvancedReset="restablecer excepciones" 
                                                  AdvancedSecond="segundos" 
                                                  AdvancedStartDateRequired="La fecha de inicio es requerida" 
                                                  AdvancedStartTimeBeforeEndTime="Hora de inicio debe ser antes de la hora final" 
                                                  AdvancedStartTimeRequired="La hora de inicio es requerida" 
                                                  AdvancedSubject="Asunto" 
                                                  AdvancedSubjectRequired="Por favor de el asunto de la cita" AdvancedThe="La" 
                                                  AdvancedThird="tercera" AdvancedTo="Hora Final" AdvancedWeekly="Semanal" 
                                                  AdvancedWeeks="semana (s) en" AdvancedWorking="Trabajo..." 
                                                  AdvancedYearly="Anual" AllDay="Todos los dias" Cancel="Cancelar" 
                                                  ConfirmCancel="Cancelar" 
                                                  ConfirmDeleteText="¿Está seguro que desea eliminar esta cita?" 
                                                  ConfirmDeleteTitle="Confirmar eliminacion" ConfirmOK="Aceptar" 
                                                  ConfirmRecurrenceDeleteOccurrence="Eliminar sólo esta ocurrencia." 
                                                  ConfirmRecurrenceDeleteSeries="Eliminar toda la serie" 
                                                  ConfirmRecurrenceDeleteTitle="Eliminar la cita recurrente" 
                                                  ConfirmRecurrenceEditOccurrence="Editar solo esta ocurrencia" 
                                                  ConfirmRecurrenceEditSeries="Editar toda la serie" 
                                                  ConfirmRecurrenceEditTitle="Editar cita recurrente" 
                                                  ConfirmRecurrenceMoveOccurrence="Mover solo esta ocurrencia" 
                                                  ConfirmRecurrenceMoveSeries="Mover la serie" 
                                                  ConfirmRecurrenceMoveTitle="Mover cita recurrente" 
                                                  ConfirmRecurrenceResizeOccurrence="Ajusta solo esta ocurrencia" 
                                                  ConfirmRecurrenceResizeSeries="Ajustar la serie" 
                                                  ConfirmRecurrenceResizeTitle="Ajustar la cita recurrente" 
                                                  ConfirmResetExceptionsText="¿Desea eliminar todas las excepciones recurrente ?" 
                                                  ConfirmResetExceptionsTitle="Confirmar el restablecer las excepciones " 
                                                  ContextMenuAddAppointment="Nueva Cita" 
                                                  ContextMenuAddRecurringAppointment="Nueva cita recurrente" 
                                                  ContextMenuDelete="Eliminar" ContextMenuEdit="Editar" 
                                                  ContextMenuGoToToday="Ir a la fecha" HeaderDay="Dia" HeaderMonth="Mes" 
                                                  HeaderMultiDay="Dias.Multiples" HeaderNextDay="Proximo dia" 
                                                  HeaderPrevDay="Dia anterior" HeaderToday="Hoy es:" HeaderWeek="Semana" 
                                                  Reminder="Recordatorios" ReminderBeforeStart="antes que empiece" 
                                                  ReminderDay="dia" ReminderDays="dia(s)" ReminderDismiss="Descartar" 
                                                  ReminderDismissAll="Rechazar Todas" ReminderDueIn="Debido a" 
                                                  ReminderHour="hora" ReminderHours="horas" ReminderMinute="minuto" 
                                                  ReminderMinutes="minutos" ReminderNone="No recordar" 
                                                  ReminderOpenItem="Otras opciones" ReminderOverdue="Atrazado" 
                                                  Reminders="Recordatorios" ReminderSnooze="Posponer" 
                                                  ReminderSnoozeHint="Haga clic en Posponer para recordarle una vez más en:" 
                                                  ReminderWeek="semana" ReminderWeeks="semanas" Save="Guardar" 
                                                  Show24Hours="Mostrar 24 horas.." ShowAdvancedForm="Opciones" 
                                                  ShowBusinessHours="Mostrar horario de trabajo..." ShowMore="mas..." />
                                    <Reminders Enabled="True" />
                                    <AdvancedForm Modal="True" />
                                    <ResourceTypes>
                                        <telerik:ResourceType DataSourceID="RoomsDataSource" ForeignKeyField="RoomID" 
                                                              KeyField="ID" Name="Tipo Cita" TextField="RoomName" />
                                        <telerik:ResourceType DataSourceID="UsuariosDataSource" 
                                                              ForeignKeyField="UserID" KeyField="ID" Name="Usuarios" TextField="UserName" />
                                    </ResourceTypes>
                                </telerik:RadScheduler>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </telerik:RadAjaxPanel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:SqlDataSource ID="AppointmentsDataSource" runat="server" 
                                   ConnectionString="<%$ ConnectionStrings:ConnStringSQL %>" 
                                   DeleteCommand="update  [AppointmentsGestion] set  activa=1 WHERE  [ID] = @ID" 
                                   InsertCommand="INSERT INTO [AppointmentsGestion] ([Subject], [Start], [End], [RoomID], [UserID], [RecurrenceRule], [RecurrenceParentID],[Reminder]) VALUES (@Subject, @Start, @End , @RoomID, @UserID, @RecurrenceRule, @RecurrenceParentID,@Reminder)" 
                                   SelectCommand="SELECT * FROM [AppointmentsGestion] WHERE userID=@UserID" 

                                   UpdateCommand="UPDATE [AppointmentsGestion] SET [Subject] = @Subject, [Start] = @Start, [End] = @End, [RoomID] = @RoomID, [UserID] = @UserID, [RecurrenceRule] = @RecurrenceRule, [RecurrenceParentID] = @RecurrenceParentID , [Reminder] = @Reminder WHERE (ID = @ID)">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="0" Name="UserID" Type="Int16" />
                    </SelectParameters>
                    <DeleteParameters>
                        <asp:Parameter Name="ID" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Subject" />
                        <asp:Parameter Name="Start" />
                        <asp:Parameter Name="End" />
                        <asp:Parameter Name="RoomID" />
                        <asp:Parameter Name="UserID" />
                        <asp:Parameter Name="RecurrenceRule" />
                        <asp:Parameter Name="RecurrenceParentID" />
                        <asp:Parameter Name="Reminder" />
                        <asp:Parameter Name="ID" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Subject" />
                        <asp:Parameter Name="Start" />
                        <asp:Parameter Name="End" />
                        <asp:Parameter Name="RoomID" />
                        <asp:Parameter Name="UserID" />
                        <asp:Parameter Name="RecurrenceRule" />
                        <asp:Parameter Name="RecurrenceParentID" />
                        <asp:Parameter Name="Reminder" />
                    </InsertParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="RoomsDataSource" runat="server" 
                                   ConnectionString="<%$ ConnectionStrings:ConnStringSQL %>" 
                                   SelectCommand="SELECT * FROM [Rooms]"></asp:SqlDataSource>
                <asp:SqlDataSource ID="UsuariosDataSource" runat="server" 
                                   ConnectionString="<%$ ConnectionStrings:ConnStringSQL %>" 
                                   SelectCommand="select * from vw_UsuariosSheduler where id=@userID">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="0" Name="userID" Type="Int16" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
    </table>
</asp:Content>


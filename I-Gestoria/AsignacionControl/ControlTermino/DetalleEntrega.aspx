<%@ Page Language="VB" AutoEventWireup="false" CodeFile="DetalleEntrega.aspx.vb" Inherits="AsignacionControl_ControlTermino_DetalleRechazo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script type="text/javascript" language="javascript">

        function CloseAndRebind(args) {
            GetRadWindow().BrowserWindow.refreshGrid(args);
            GetRadWindow().close();
        }
        function GetRadWindow() {
            var oWindow = null;
            if (window.radWindow) oWindow = window.radWindow;
            //Will work in Moz in all cases, including clasic dialog                  
            else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
            //IE (and Moz as well)                  
            return oWindow;
        }
        function CancelEdit() {
            GetRadWindow().close();
        }

</script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
        </telerik:RadScriptManager>
        <telerik:RadGrid ID="GridDetalleRecepcion" runat="server" CellSpacing="0" 
            Culture="es-ES" GridLines="None">
            <MasterTableView>
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column"></RowIndicatorColumn>

<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column"></ExpandCollapseColumn>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
            </MasterTableView>

<FilterMenu EnableImageSprites="False"></FilterMenu>
        </telerik:RadGrid>
        <telerik:RadNotification ID="RadNotification1" runat="server">
        </telerik:RadNotification>
    
    </div>
    </form>
</body>
</html>

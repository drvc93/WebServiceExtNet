<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportePuntos.aspx.cs" Inherits="WebServiceExtNet.ReportePuntos" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <title>Puntos Acumulados</title>
    </head>
    <body>
        <form id="form1" runat="server">
            <asp:ScriptManager runat="server"></asp:ScriptManager>
            <div>
                <telerik:RadGrid ID="gv_RepPuntos" RenderMode="Lightweight"   AllowSorting="false" AllowPaging="True" runat="server">
                    <PagerStyle  Mode="NextPrevNumericAndAdvanced"/>
                    <MasterTableView Width="100%"  ViewStateMode="Enabled"  AutoGenerateColumns="false" >
                        <Columns>
                            <telerik:GridBoundColumn DataField="c_descripcion" HeaderText="Promocion "></telerik:GridBoundColumn>
                        </Columns>
                        <Columns>
                            <telerik:GridNumericColumn DataField="n_acumulado" HeaderText="P.Acumulado "></telerik:GridNumericColumn>
                        </Columns>
                        <Columns>
                            <telerik:GridNumericColumn DataField="n_utilizado" HeaderText="P.Utilizado "></telerik:GridNumericColumn>
                        </Columns>
                        <Columns>
                            <telerik:GridNumericColumn DataField="n_saldo" HeaderText="P.Saldo "></telerik:GridNumericColumn>
                        </Columns>

                    </MasterTableView>
                </telerik:RadGrid>
            </div>
        </form>
    </body>
</html>

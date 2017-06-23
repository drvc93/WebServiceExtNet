<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FactorItem.aspx.cs" Inherits="WebServiceExtNet.FactorItem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <title></title>
        <script type="text/javascript">
            function startTimer(duration, display) {
                var start = Date.now(),
                    diff,
                    minutes,
                    hours,
                    seconds;
                function timer() {
                    // get the number of seconds that have elapsed since 
                    // startTimer() was called
                    diff = duration - (((Date.now() - start) / 1000) | 0);

                    // does the same job as parseInt truncates the float
                    hours = (diff / 3600) | 0;
                    minutes = ((diff - (hours * 3600)) / 60) | 0;
                    seconds = (diff - (hours * 3600)) % 60 | 0;

                    minutes = minutes < 10 ? "0" + minutes : minutes;
                    seconds = seconds < 10 ? "0" + seconds : seconds;

                    display.textContent = " Vence en " + hours + ":" + minutes + ":" + seconds;

                    if (diff <= 0) {
                        // add one second so that the count down starts at the full duration
                        // example 05:00 not 04:59
                        start = Date.now() + 1000;
                    }
                };
                // we don't want to wait a full second before the timer starts
                timer();
                setInterval(timer, 1000);
            }

            function Activate(durtimne, id) {
                var Segundos = durtimne,
                    display = document.getElementById(id);
                startTimer(Segundos, display);
            };
        </script>
    </head>
    <body>
        <form id="form1" runat="server">
            <div>
                <asp:Repeater runat="server" ID="rptFactorItem">
                    <HeaderTemplate>
                        <table style="width:100%">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Label runat="server" Text='<%# Eval("c_item") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" Text= '<%# Eval("c_proPaganda") %>'></asp:Label>
                                <span     id='<%# (Container.ItemIndex) %>'>  </span>
                            </td>
                        </tr>

                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </form>
    </body>
</html>

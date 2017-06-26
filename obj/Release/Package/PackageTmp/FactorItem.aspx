<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FactorItem.aspx.cs" Inherits="WebServiceExtNet.FactorItem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <title></title>
        <style>
             .divresp {float: left; margin: 10px;  max-width: 95%;height: 100%;border: 1px solid white;margin-right: 10px;width: 95%} 
        </style>
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

                    display.textContent = " Vence en " + hours + ":" + minutes + ":" + seconds +" horas.";

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
            
           
            <div class="divresp">
                <asp:Repeater runat="server" ID="rptFactorItem">
                    <HeaderTemplate>
                        <table style="width:100% ; text-align:center;">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td colspan="2" style="background-color:#242424; color:white;font-weight:bold; border-radius:10px;" >
                                <asp:Label ID="Label1"  ForeColor="White" Font-Bold="true" runat="server" Text='<%# Eval("c_htmlDesc").ToString().ToUpper() %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="background:#f5ecb7;-webkit-border-top-left-radius:10px;-webkit-border-bottom-left-radius:10px;" >
                                <asp:Label runat="server"  Font-Bold="true" Text='<%# Eval("c_item") %>'></asp:Label>
                            </td>
                            <td style="background:#f5ecb7; -webkit-border-top-right-radius:10px;-webkit-border-bottom-right-radius:10px;">
                                <asp:Label runat="server" Text= '<%# Eval("c_proPaganda") %>'></asp:Label><br />
                                <span  style="font-weight:bold;"   id='<%# (Container.ItemIndex) %>'>  </span> 
                                 
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

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Portal.aspx.cs" Inherits="WebServiceExtNet.Portal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <style>
            .divresp {float: left; margin-top:8%;  max-width:95%;height: 100%;border: 1px solid white;margin-right: 10px;width: 100%}   
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

                    display.textContent = " Vence en "+hours + ":" + minutes + ":" + seconds;

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

            function Activate(durtimne) {
                var Segundos = durtimne,
                    display = document.querySelector('#time');
                startTimer(Segundos, display);
            };
        </script>
    </head>
    <body style="width:100%;" >
            
        <form id="form1" runat="server" style="width:100%;" >
            <div class="divresp">
                <div  runat ="server" id="divConteo" style="padding:5px; border-radius:5px; width:98%;text-align:center;font-size:100%;font-weight:bold;background-color: #F2F5A9;">
                           <span runat="server" id="lblfchavcto"></span>  <span id="time"></span>
                </div>
                <asp:Repeater ID="repeatHtml" runat="server">
                    <HeaderTemplate>

                        <table style="width:100%;" >
                            <tr>
                                <td>

                                </td>
                            </tr>

                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td style="color: white; background-color:black ;padding:5% ;border-radius:10px; " >
                                <asp:Label Width="100%"  Font-Size="Larger" style="text-align:center"  runat="server" Text='<%# Eval("c_htmlTit") %>' Font-Bold="true"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: #000000; background-color:#E5E5E5 ;padding:5% ;border-radius:10px; " >
                                <asp:Label Width="100%"  Font-Size="Larger" style="text-align:center"   ID="Label1"  runat="server" Text='<%# Eval("c_htmlDesc") %>' ></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <img  style=' border-radius:10%; width: 100%; object-fit: contain'  runat="server"  src='<%# Eval("c_base64img1") %>' />
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

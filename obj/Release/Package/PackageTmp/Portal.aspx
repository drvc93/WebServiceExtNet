<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Portal.aspx.cs" Inherits="WebServiceExtNet.Portal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <style>
            .divresp {float: left; margin: 10px; padding: 10px; max-width: 95%;height: 100%;border: 1px solid white;margin-right: 10px;width: 95%}   
        </style>
    </head>
    <body>
        <asp:Label ID="lblHeader" ForeColor="Black" Text ="Promociones del dia 25/05/2017" Font-Bold="true" Font-Size="12" Font-Italic="true" runat="server"></asp:Label>
                      
        <form id="form1" runat="server">
            <div class="divresp">
                <asp:Repeater ID="repeatHtml" runat="server">
                    <HeaderTemplate>
                        
                        <table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td style="color: white; background-color:red ;padding:5% ;border-radius:10px; " >
                                <asp:Label Width="100%"  style="text-align:center"  runat="server" Text='<%# Eval("c_htmlTit") %>' Font-Bold="true"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: #000000; background-color:#E5E5E5 ;padding:5% ;border-radius:10px; " >
                                <asp:Label Width="100%" style="text-align:center"   ID="Label1"  runat="server" Text='<%# Eval("c_htmlDesc") %>' ></asp:Label>
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

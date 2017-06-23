<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reglas.aspx.cs" Inherits="WebServiceExtNet.Reglas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <title></title>
    </head>
    <body>
        <form id="form1" runat="server">
            <div class="divresp" >
                <asp:Repeater  runat="server" ID="rptReglas">

                    <HeaderTemplate>
                        <table style="width:100%" >
                            <tr>
                                <td style=" text-align:center; border-bottom-left-radius:5px; font-weight:bold;background-color:red; color:white">
                                    PROMOCION
                                </td>
                                <td style="text-align:center;border-bottom-right-radius:5px; font-weight:bold; background-color:red; color:white">
                                    <%--REGLA--%>
                                </td>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                       
                        <tr >
                            <td style="text-align:center;" >
                                <asp:Label ID="Label1"  Font-Bold="true"  ForeColor="Black" Font-Size="100%" runat="server" Text ='<%# Eval("descpromo") %>' ></asp:Label>
                            </td>
                            <td  >
                                <asp:Label ID="Label2"  Font-Bold="true"  ForeColor="Black" Font-Size="100%" runat="server" Text ='<%# Eval("c_textoHtml") %>' ></asp:Label>
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

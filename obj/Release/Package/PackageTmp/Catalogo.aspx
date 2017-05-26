<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Catalogo.aspx.cs" Inherits="WebServiceExtNet.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <style>
            .divresp {float: left; margin: 10px; padding: 10px; max-width: 95%;height: 100%;border: 1px solid white;margin-right: 10px;width: 95%}   
            .Relieve {
            box-shadow: inset 3px 3px 3px rgba(255,255,255,.7), inset -2px -2px 3px rgba(0,0,0,.1), 2px 2px 10px rgba(0,0,0,.1);
            width: 95%;  /* Ancho del botón */
            border: 1px solid #E70000; /* Borde */
            background: #FC312C;  /* Fondo */
            text-align: center;  /* Alineación del texto */
            text-shadow: -1px -1px rgba(0,0,0,.2);  /* Sombra del texto */
            border-radius: 10px;  /* Bordes redondos */
            color: white;  /* Color del texto */
            padding:3%;
            }
            .Relieve:active /* Al presionarse el botón */ {
            text-shadow: 1px 1px rgba(0,0,0,.3);  /* Sombra del texto */
            background:#8C0404;  /* Fondo más oscuro que el original */
            box-shadow:inset 4px 4px 4px rgba(0,0,0,.3), inset -3px -3px 3px rgba(255,255,255,.2);
            width: 95%; 
            padding:3%;
            border-radius: 10px; 
            }

        </style>
    </head>
    <body>
        <form id="form1" runat="server">
            <div class="divresp">

            </div>
            <asp:Repeater ID="rptCatalogo" runat="server">
                <HeaderTemplate>

                    <table>
                </HeaderTemplate>
                <ItemTemplate>

                    <tr>
                        <td  class="Relieve" >
                            <asp:Label ID="Label1" Width="100%"  style="text-align:center"  runat="server" Text='<%#  Eval("c_item").ToString() +" - " +Eval("c_descripcion").ToString() %>' Font-Bold="true"></asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <td style="color: #393636; background-color:#C1C1C1 ;padding:5% ;border-radius:10px; " >
                            <asp:Label ID="Label2" Width="100%"  style="text-align:center"  runat="server" Text='<%#  " Tipo : " +Eval("c_tipo").ToString() %>' Font-Bold="true"></asp:Label>
                        </td>
                    </tr>
                </ItemTemplate>

                <FooterTemplate>
                    </table>
                </FooterTemplate>

            </asp:Repeater>
        </form>
    </body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Premios.aspx.cs" Inherits="WebServiceExtNet.Premios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <title></title>
        <style> 
            .divresp {float: left; margin: 10px;  max-width: 95%;height: 100%;border: 1px solid white;margin-right: 10px;width: 95%} 
        .Relieve {
            box-shadow: inset 3px 3px 3px rgba(255,255,255,.7), inset -2px -2px 3px rgba(0,0,0,.1), 2px 2px 10px rgba(0,0,0,.1);
            width: 100%;  /* Ancho del botón */
            border: 1px solid black; /* Borde */
            background-color:black ;  /* Fondo */
            text-align: center;  /* Alineación del texto */
            text-shadow: -1px -1px rgba(0,0,0,.2);  /* Sombra del texto */
              /* Bordes redondos */
            color: white;  /* Color del texto */
            padding:15px;
            border-radius:15px;
            }
        </style>
    </head>
    <body>
        <form id="form1" runat="server">
            <div class="divresp">
                <asp:Repeater  runat="server" ID="rptPremios">

                    <HeaderTemplate>
                        <table style="width:100%">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr >
                            <td class="Relieve">
                                <asp:Label  Font-Bold="true"  ForeColor="White" Font-Size="100%" runat="server" Text ='<%# Eval("c_descripcion") %>' ></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <img id="Img1"  style=' border-radius:10%; width: 100%; object-fit: contain'  runat="server"  src='<%# ConvertToImg (Eval("c_fotoHtml").ToString()) %>' />

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

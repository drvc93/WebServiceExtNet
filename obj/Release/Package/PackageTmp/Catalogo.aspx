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
            padding:20px;
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
            <div class="divresp" >

                <asp:Repeater ID="rptCatalogo" runat="server">
                    <HeaderTemplate>

                        <table style="width:100%">
                    </HeaderTemplate>
                    <ItemTemplate>

                        <tr>
                            <td  class="Relieve" >
                                <asp:Label ID="Label1" Width="100%"  style="text-align:center"  runat="server" Text='<%#  Eval("c_item").ToString() +" - " +Eval("c_descripcion").ToString() %>' Font-Bold="true"></asp:Label>
                            </td>
                        </tr>

                        <tr>
                            <td style="color: #393636; background-color:rgba(193, 193, 193, 0.42) ;padding:15px ;border-radius:10px; " >
                                <asp:Label ID="Label2" Width="100%"  style="text-align:center"  runat="server" Text='<%#  " TIPO : " +Eval("c_tipo").ToString() %>' Font-Bold="true"></asp:Label>
                            </td>
                        </tr>
                        
                        <tr>
                            <td>
                                <img id="Img1"  style=' border-radius:10%; width: 100%; object-fit: contain'  runat="server"  src='<%# Eval("c_imagbase64") %>' />
                             
                            </td>
                        </tr>
                        <tr>
                            <td style="color: #393636; background-color:rgba(193, 193, 193, 0.42) ; border-radius:12px; width:100%; text-align:center">
                                <strong> <i><u><asp:Label ID="Label16" runat="server" Text ="APLICACIONES " Font-Size="Large" Font-Bold="true" ></asp:Label></u></i></strong><br />
                                <asp:Label runat="server"  Font-Bold="false" Text ='<%# Eval("c_aplicaciones") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: #393636; background-color:rgba(193, 193, 193, 0.42) ; border-radius:12px; width:100%; text-align:center">
                                <strong> <i><u><asp:Label ID="Label17" runat="server" Text ="EQUIVALENCIAS " Font-Size="Large" Font-Bold="true" ></asp:Label></u></i></strong><br />
                                <asp:Label ID="Label18" runat="server"  Font-Bold="false" Text ='<%# Eval("c_equivalencias") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: #393636; background-color:rgba(193, 193, 193, 0.42) ; border-radius:12px; width:100%; text-align:center">
                                <strong> <i><u><asp:Label ID="Label19" runat="server" Text ="ESPECIFICACIONES" Font-Size="Large" Font-Bold="true" ></asp:Label></u></i></strong><br />
                               
                            </td>
                        </tr>
                        <tr >
                            <td style="width:100%;color:white;background-color:#FC312C;border-radius:15px;">
                               <strong style="margin-left:10px"> 
                                   <asp:Label runat="server" Font-Size="Large"  Text='<%#  Eval("c_des_1").ToString() +"  " +Eval("c_val_1").ToString() %>'></asp:Label> 

                               </strong>
                            </td>

                        </tr>
                         <tr >
                            <td style="width:100%;color:white;background-color:#FC312C;border-radius:15px;">
                               <strong style="margin-left:10px"> 
                                   <asp:Label ID="Label3" runat="server" Font-Size="Large"  Text='<%#  Eval("c_des_2").ToString() +"  " +Eval("c_val_2").ToString() %>'></asp:Label> 

                               </strong>
                            </td>

                        </tr>
                        <tr >
                            <td style="width:100%;color:white;background-color:#FC312C;border-radius:15px;">
                               <strong style="margin-left:10px"> 
                                   <asp:Label ID="Label4" runat="server" Font-Size="Large"  Text='<%#  Eval("c_des_3").ToString() +"   " +Eval("c_val_3").ToString() %>'></asp:Label> 

                               </strong>
                            </td>

                        </tr>
                        <tr >
                            <td style="width:100%;color:white;background-color:#FC312C;border-radius:15px;">
                               <strong style="margin-left:10px"> 
                                   <asp:Label ID="Label5" runat="server" Font-Size="Large"  Text='<%#  Eval("c_des_4").ToString() +"  " +Eval("c_val_4").ToString() %>'></asp:Label> 

                               </strong>
                            </td>

                        </tr>

                        <tr >
                            <td style="width:100%;color:white;background-color:#FC312C;border-radius:15px;">
                               <strong style="margin-left:10px"> 
                                   <asp:Label ID="Label6" runat="server" Font-Size="Large"  Text='<%#  Eval("c_des_5").ToString() +"  " +Eval("c_val_5").ToString() %>'></asp:Label> 

                               </strong>
                            </td>

                        </tr>

                        <tr >
                            <td style="width:100%;color:white;background-color:#FC312C;border-radius:15px;">
                               <strong style="margin-left:10px"> 
                                   <asp:Label ID="Label7" runat="server" Font-Size="Large"  Text='<%#  Eval("c_des_6").ToString() +"  " +Eval("c_val_6").ToString() %>'></asp:Label> 

                               </strong>
                            </td>

                        </tr>

                        <tr >
                            <td style="width:100%;color:white;background-color:#FC312C;border-radius:15px;">
                               <strong style="margin-left:10px"> 
                                   <asp:Label ID="Label8" runat="server" Font-Size="Large"  Text='<%#  Eval("c_des_7").ToString() +"  " +Eval("c_val_7").ToString() %>'></asp:Label> 

                               </strong>
                            </td>

                        </tr>
                        
                       <tr >
                            <td style="width:100%;color:white;background-color:#FC312C;border-radius:15px;">
                               <strong style="margin-left:10px"> 
                                   <asp:Label ID="Label9" runat="server" Font-Size="Large"  Text='<%#  Eval("c_des_8").ToString() +"  " +Eval("c_val_8").ToString() %>'></asp:Label> 

                               </strong>
                            </td>

                       </tr>

                        <tr >
                            <td style="width:100%;color:white;background-color:#FC312C;border-radius:15px;">
                               <strong style="margin-left:10px"> 
                                   <asp:Label ID="Label10" runat="server" Font-Size="Large"  Text='<%#  Eval("c_des_9").ToString() +"  " +Eval("c_val_9").ToString() %>'></asp:Label> 

                               </strong>
                            </td>

                        </tr>

                        <tr >
                            <td style="width:100%;color:white;background-color:#FC312C;border-radius:15px;">
                               <strong style="margin-left:10px"> 
                                   <asp:Label ID="Label11" runat="server" Font-Size="Large"  Text='<%#  Eval("c_des_10").ToString() +"  " +Eval("c_val_10").ToString() %>'></asp:Label> 

                               </strong>
                            </td>

                        </tr>

                        <tr >
                            <td style="width:100%;color:white;background-color:#FC312C;border-radius:15px;">
                               <strong style="margin-left:10px"> 
                                   <asp:Label ID="Label12" runat="server" Font-Size="Large"  Text='<%#  Eval("c_des_11").ToString() +"  " +Eval("c_val_11").ToString() %>'></asp:Label> 

                               </strong>
                            </td>

                        </tr>
                        
                        <tr >
                            <td style="width:100%;color:white;background-color:#FC312C;border-radius:15px;">
                               <strong style="margin-left:10px"> 
                                   <asp:Label ID="Label13" runat="server" Font-Size="Large"  Text='<%#  Eval("c_des_12").ToString() +"  " +Eval("c_val_12").ToString() %>'></asp:Label> 

                               </strong>
                            </td>

                        </tr>

                        <tr >
                            <td style="width:100%;color:white;background-color:#FC312C;border-radius:15px;">
                               <strong style="margin-left:10px"> 
                                   <asp:Label ID="Label14" runat="server" Font-Size="Large"  Text='<%#  Eval("c_des_13").ToString() +"  " +Eval("c_val_13").ToString() %>'></asp:Label> 

                               </strong>
                            </td>

                        </tr>
                        <tr >
                            <td style="width:100%;color:white;background-color:#FC312C;border-radius:15px;">
                               <strong style="margin-left:10px"> 
                                   <asp:Label ID="Label15" runat="server" Font-Size="Large"  Text='<%#  Eval("c_des_14").ToString() +"  " +Eval("c_val_14").ToString() %>'></asp:Label> 

                               </strong>
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

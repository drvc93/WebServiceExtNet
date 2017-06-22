using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebServiceExtNet
{
    public partial class Portal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string dni = Request.QueryString["dni"];
                //string dni = 
                dni = dni.Trim().ToUpper();
                this.LoadPortal(dni);
            }

        }

        public void LoadPortal(string dni)
        {

            string flagconteotiempo = "";
            int hora = 0, minuto =0, segundo = 0;
            string factvence = "";
            Conexion con = new Conexion();
            // String BodyHtml = "", HeadHtml = "", FotHtml = "";
            SqlConnection cn =  con.conexion();
            cn.Open();
            SqlDataAdapter dap = new SqlDataAdapter("UP_MVE_LISTAPAGEINICIO", cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@Dni", dni);

            dap.Fill(dt);
            cn.Close();

            if (dt != null)
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string HtmlSeccion = "";

                    string imgBase64 = "";
                    string stittulo = "";
                    string sdetalle = "";
                    string rutaimg = "";
                   // string flagconteotiempo;
                   // int hora, minuto, segundo;
                   


                    stittulo = dt.Rows[i]["c_htmlTit"].ToString();
                    sdetalle = dt.Rows[i]["c_htmlDesc"].ToString();
                    rutaimg = dt.Rows[i]["c_foto1"].ToString();
                    

                    stittulo = stittulo.ToUpper();
                    sdetalle=sdetalle.ToUpper();

                    flagconteotiempo = dt.Rows[i]["c_flagactcontador"].ToString();
                    factvence = dt.Rows[i]["c_piemaxvenc"].ToString();

                    if (String.IsNullOrEmpty(factvence) == false)
                    {
                        hora = Convert.ToInt32(dt.Rows[i]["n_horaRes"]);
                        minuto = Convert.ToInt32(dt.Rows[i]["n_minuRes"]);
                        segundo = Convert.ToInt32(dt.Rows[i]["n_seguRes"]);
                    }
                  //  Bitmap b = new Bitmap(@"\\IBSERVER_1\Servidor de Archivos\Fotos\L17.jpg");
                    if (System.IO.File.Exists(@rutaimg))
                    {
                        Bitmap b = new Bitmap(rutaimg);
                        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        b.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        byte[] byteImage = ms.ToArray();
                        imgBase64 = Convert.ToBase64String(byteImage);

                        dt.Rows[i][11] = "data:image/jpeg;base64," + imgBase64;
                        dt.AcceptChanges();
                    }

                    /*HtmlSeccion = " <td><tr >  <p style='font-weight: bold' >" + stittulo + "</p> </tr> </td>";
                    HtmlSeccion = HtmlSeccion + "<td><tr >  " + sdetalle + "</tr></td>";
                    HtmlSeccion = HtmlSeccion + "<td> <tr ><img  style='height: 100%; width: 100%; object-fit: contain' src='data:image/jpeg;base64," + imgBase64 + "' /></tr></td>";
                    BodyHtml = BodyHtml + HtmlSeccion;*/

                }
                
               //  lblHeader.Text = "PROMOCIONES DEL DÍA " + DateTime.Now.ToShortDateString();
                repeatHtml.DataSource = dt;
                repeatHtml.DataBind();

                if (String.IsNullOrEmpty(factvence) == true || factvence == "")
                {

                    divConteo.Visible = false;

                }
                else
                {
                    lblfchavcto.InnerText = factvence+ " ";
                }
                

                if (flagconteotiempo == "S")
                {
                    int tiempoTotal =( hora * 3600) +( minuto *60) +  segundo;
                    ClientScript.RegisterStartupScript( typeof(Page), "Script", "Activate("+tiempoTotal+")", true);
                }


            }

        
        }
    }
}
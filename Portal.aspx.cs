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
                this.LoadPortal();
            }

        }

        public void LoadPortal() {

            Conexion con = new Conexion();
            // String BodyHtml = "", HeadHtml = "", FotHtml = "";
            SqlConnection cn = con.conexionLys();
            cn.Open();
            SqlDataAdapter dap = new SqlDataAdapter("SP_CO_MVE_APPLISTAPAGEINICIO", cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            //dap.SelectCommand.Parameters.AddWithValue("@Dni", dni);

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
                   


                    stittulo = dt.Rows[i]["c_htmlTit"].ToString();
                    sdetalle = dt.Rows[i]["c_htmlDesc"].ToString();
                    rutaimg = dt.Rows[i]["c_foto1"].ToString();
                    stittulo = stittulo.ToUpper();
                    sdetalle=sdetalle.ToUpper();
                  //  Bitmap b = new Bitmap(@"\\IBSERVER_1\Servidor de Archivos\Fotos\L17.jpg");
                     Bitmap b = new Bitmap(rutaimg);
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    b.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] byteImage = ms.ToArray();
                    imgBase64 = Convert.ToBase64String(byteImage);

                    dt.Rows[i][11] = "data:image/jpeg;base64,"+ imgBase64;
                    dt.AcceptChanges();

                    /*HtmlSeccion = " <td><tr >  <p style='font-weight: bold' >" + stittulo + "</p> </tr> </td>";
                    HtmlSeccion = HtmlSeccion + "<td><tr >  " + sdetalle + "</tr></td>";
                    HtmlSeccion = HtmlSeccion + "<td> <tr ><img  style='height: 100%; width: 100%; object-fit: contain' src='data:image/jpeg;base64," + imgBase64 + "' /></tr></td>";
                    BodyHtml = BodyHtml + HtmlSeccion;*/

                }
                
               //  lblHeader.Text = "PROMOCIONES DEL DÍA " + DateTime.Now.ToShortDateString();
                repeatHtml.DataSource = dt;
                repeatHtml.DataBind();
            }

        
        }
    }
}
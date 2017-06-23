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
    public partial class Premios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string dni = Request.QueryString["dni"];
                //string dni = 
                dni = dni.Trim().ToUpper();
                this.LoadPremios(dni);
            }
        }


        public void LoadPremios(string dni)
        {

            Conexion con = new Conexion();
            // String BodyHtml = "", HeadHtml = "", FotHtml = "";
            SqlConnection cn = con.conexion();
            cn.Open();
            SqlDataAdapter dap = new SqlDataAdapter("UP_MVE_PREMIOLYS", cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@Dni", dni);

            dap.Fill(dt);
            cn.Close();

            if (dt != null)
            {
                //   Fdt = dt;

                /*for (int i = 0; i < dt.Rows.Count; i++)
                {
                    
                    string imgBase64 = ""; 
                    string rutaimg = "";
                    
                    rutaimg = dt.Rows[i]["c_rutafoto"].ToString();
                   // rutaimg = @"\\100.100.100.1\\spring\\Planillas\\ROYALOGO.BMP";
                    //rutaimg = @Constantes.CarpetaFotos+sfilro+".jpg";
                   rutaimg = Server.MapPath("~/Fotos") + "\\" + sfilro + ".jpg";
                    //rutaimg = Constantes.CarpetaFotos+sfilro+".jpg";
                   // CopyFile(rutaimg);
                    if (System.IO.File.Exists(@rutaimg))
                    {
                        // Bitmap b = new Bitmap(@"\\IBSERVER_1\\Servidor de Archivos\\Fotos\\L50.jpg");
                        Bitmap b = new Bitmap(rutaimg);
                       // Bitmap b = new Bitmap(@"E:\Fotos\L50.jpg");
                        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        b.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        byte[] byteImage = ms.ToArray();
                        imgBase64 = Convert.ToBase64String(byteImage);

                        dt.Rows[i][35] = "data:image/jpeg;base64," + imgBase64;
                        dt.AcceptChanges();
                    }
                    

                }*/

                rptPremios.DataSource = dt;
                rptPremios.DataBind();

            }
        }
        public string ConvertToImg(string rutaimg) 
        {
            string result = "";
            if (System.IO.File.Exists(@rutaimg))
            {
                // Bitmap b = new Bitmap(@"\\IBSERVER_1\\Servidor de Archivos\\Fotos\\L50.jpg");
                Bitmap b = new Bitmap(rutaimg);
                // Bitmap b = new Bitmap(@"E:\Fotos\L50.jpg");
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                b.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] byteImage = ms.ToArray();
                result = Convert.ToBase64String(byteImage);

                result = "data:image/jpeg;base64," + result;
                return result;

            }
            else
            {

               return  result;
            
            }

          
        
        }
    }
}
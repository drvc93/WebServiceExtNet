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
    public partial class WebForm1 : System.Web.UI.Page
    {
        public DataTable Fdt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string filtro =  Request.QueryString["item"];
                filtro = filtro.Trim().ToUpper();
                this.LoadCatalogo(filtro);
            }
        }

        public void LoadCatalogo(string sfilro) 
        
        { 
            Conexion con = new Conexion();
            // String BodyHtml = "", HeadHtml = "", FotHtml = "";
            SqlConnection cn = con.conexion();
            cn.Open();
            SqlDataAdapter dap = new SqlDataAdapter("SP_CO_MVE_CATALOGOLYS", cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@Item", sfilro);

            dap.Fill(dt);
            cn.Close();

            if (dt != null)
            {
                Fdt = dt;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    
                    string imgBase64 = ""; 
                    string rutaimg = "";
                    
                    rutaimg = dt.Rows[i]["c_rutafoto"].ToString();
                    rutaimg = @Constantes.CarpetaFotos+sfilro+".jpg";
                    if (System.IO.File.Exists(rutaimg))
                    {
                        // Bitmap b = new Bitmap(@"\\IBSERVER_1\Servidor de Archivos\Fotos\L17.jpg");
                       // Bitmap b = new Bitmap(rutaimg);
                        Bitmap b = new Bitmap(rutaimg);
                        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        b.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        byte[] byteImage = ms.ToArray();
                        imgBase64 = Convert.ToBase64String(byteImage);

                        dt.Rows[i][35] = "data:image/jpeg;base64," + imgBase64;
                        dt.AcceptChanges();
                    }
                    

                }

                rptCatalogo.DataSource = dt;
                rptCatalogo.DataBind();
            
            }
        
        }
    }
}
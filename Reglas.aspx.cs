using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebServiceExtNet
{
    public partial class Reglas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string dni = Request.QueryString["dni"];
                //string dni = 
                dni = dni.Trim().ToUpper();
                this.LoadReglas(dni);
            }
        }

        public void LoadReglas(string dni) 
        {
            Conexion con = new Conexion();
            // String BodyHtml = "", HeadHtml = "", FotHtml = "";
            SqlConnection cn = con.conexion();
            cn.Open();
            SqlDataAdapter dap = new SqlDataAdapter("UP_MVE_REGLAMENTOLYS", cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@Dni", dni);

            dap.Fill(dt);
            cn.Close();

            if (dt != null)
            {
                

                rptReglas.DataSource = dt;
                rptReglas.DataBind();

            }
        
        }
    }
}
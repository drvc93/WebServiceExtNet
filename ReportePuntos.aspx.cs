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
    public partial class ReportePuntos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string dni = Request.QueryString["dni"];
                dni = dni.Trim().ToUpper();
                this.LoadReporte(dni);
               
            }
        }

        public void LoadReporte(string dni)
        { 
             Conexion con = new Conexion();
            // String BodyHtml = "", HeadHtml = "", FotHtml = "";
            SqlConnection cn = con.conexionLys();
            cn.Open();
            SqlDataAdapter dap = new SqlDataAdapter("SP_CO_MVE_CONSULTAPUNTOS", cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@Dni", dni);

            dap.Fill(dt);
            cn.Close();

            if (dt != null) 
            {
                gv_RepPuntos.DataSource = dt;
                gv_RepPuntos.DataBind();
            
            }
        
        }
    }
}
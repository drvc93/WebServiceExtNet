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
    public partial class FactorItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string dni = Request.QueryString["dni"];
                //string dni = 
                dni = dni.Trim().ToUpper();
                this.LoadFactores(dni);
            }

        }

        public void LoadFactores(string Dni)
        {

            Conexion con = new Conexion();
            // String BodyHtml = "", HeadHtml = "", FotHtml = "";
            SqlConnection cn = con.conexion();
            cn.Open();
            SqlDataAdapter dap = new SqlDataAdapter("UP_MVE_FACTORITEM", cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@Dni", Dni);

            dap.Fill(dt);
            cn.Close();

            if (dt != null)
            {


                

                rptFactorItem.DataSource = dt;
                rptFactorItem.DataBind();

            }

            ExecScript(dt);
        }

        public void ExecScript( DataTable  dtFact)
 
        {

            for (int i = 0; i < dtFact.Rows.Count; i++)
            {
                int duracion = Convert.ToInt32(dtFact.Rows[i]["n_segundosTot"]);
                string id = i.ToString();
                string keyjs = "Script" + i.ToString() ;
                string flagcot = dtFact.Rows[i]["c_flagactcontador"].ToString();
              //  id = "#" + id;
                if (flagcot == "S")
                {
                    string Jscript = "Activate(" + duracion + "," + id + ");";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), keyjs, Jscript, true);
                }
               // Page.ClientScript.RegisterStartupScript(this.GetType(), keyjs, Jscript, true);
              
                
            
            }

            
            
 
        }
    }
}
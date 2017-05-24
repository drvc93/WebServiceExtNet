using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Services;

namespace WebServiceExtNet
{
    /// <summary>
    /// Descripción breve de WSExtraNet
    /// </summary>
    [WebService(Namespace = "http://100.100.100.237:8030/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WSExtraNet : System.Web.Services.WebService
    {

        Conexion con = new Conexion();
        #region Services App Clientes

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        [WebMethod]
        public string VerificarUsuarioExiste(string dni) {

            string  sql, result = "";
            int cont=0;
            sql = "SELECT count(*) n_count FROM TBC_USUARIO where v_dni = '" + dni + "'";
            SqlConnection cn = con.conexion();
            cn.Open();
            SqlDataAdapter dap = new SqlDataAdapter(sql, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.Text;
            dap.Fill(dt); 
            cn.Close();

            if (dt != null)
            {
                cont  =  Convert.ToInt32( dt.Rows[0]["n_count"]);
            }
            if (cont == 0)
            {
                result = "OK";
            }
            else if(cont > 0)
            {
                result = "NO";
            }

            return result;
        
        }

        [WebMethod]

        public string InsertarUsuario  ( string  dni , string  nombre  , string apellido , string fechanac ,string mail ,
                                        string telefono ,string empruc , string empnom) {
            string res = "-1";
            int sqlrows;

            if (dni == "" || String.IsNullOrEmpty(dni)==true) 
            {
                return "-1";
            }

            try
            {
                SqlConnection cn = con.conexion();
                SqlCommand sqlcmd = new SqlCommand("SP_CO_INSERTUSERAPP", cn);
                sqlcmd.Connection = cn;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                sqlcmd.Parameters.AddWithValue("@dni", dni);
                sqlcmd.Parameters.AddWithValue("@nombre", nombre.Trim().ToUpper());
                sqlcmd.Parameters.AddWithValue("@apellido", apellido.Trim().ToUpper());
                sqlcmd.Parameters.AddWithValue("@fechaNac", Convert.ToDateTime(fechanac));
                sqlcmd.Parameters.AddWithValue("@mail", mail);
                sqlcmd.Parameters.AddWithValue("@telefono", telefono);
                sqlcmd.Parameters.AddWithValue("@empruc", empruc);
                sqlcmd.Parameters.AddWithValue("@empnom", empnom);
                SqlParameter par = new SqlParameter("@IdReg", SqlDbType.Int);
                par.Direction = ParameterDirection.Output;
                sqlcmd.Parameters.Add(par);
                sqlrows = sqlcmd.ExecuteNonQuery();

                if (sqlrows > 0)
                {
                    res = Convert.ToString(sqlcmd.Parameters["@IdReg"].Value);
                }
            }

            catch (Exception e) {

          //      res = e.Message;
                res = "-1";
            }
      

            return res;


        
        }

        [WebMethod]
        public string TransferirUsuario(string tipo, int correlativo) {

            string res = "-1";
            int sqlrows;
            try
            {
                SqlConnection cn = con.conexion();
                SqlCommand sqlcmd = new SqlCommand("UP_MVE_TRANSFERENCIA", cn);
                sqlcmd.Connection = cn;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                sqlcmd.Parameters.AddWithValue("@Tipo", tipo);
                sqlcmd.Parameters.AddWithValue("@Correlativo", correlativo);
                SqlParameter par = new SqlParameter("@Mensaje", SqlDbType.VarChar);
                par.Direction = ParameterDirection.Output;
                par.Size = 500;
                sqlcmd.Parameters.Add(par);
                sqlrows = sqlcmd.ExecuteNonQuery();
                res = sqlcmd.Parameters["@Mensaje"].Value.ToString();
                
            }

            catch (Exception e)
            {
                res = e.Message;
            }

            if (res == "OK")
            {
                this.EnviarCorreoInfo(correlativo);
            }

            return res;
        }


        public void EnviarCorreoInfo(int correlativo) {


            string correEnv ="", Html = "";

            SqlConnection cn = con.conexion();
            cn.Open();
            SqlDataAdapter dap = new SqlDataAdapter("SP_CO_GENERAR_HTML_CORREOINFOAPP", cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@Correlativo", correlativo);
            

            dap.Fill(dt);
            cn.Close();

            if (dt != null)
            {

                correEnv = dt.Rows[0]["c_correo"].ToString();
                Html = dt.Rows[0]["c_html"].ToString();

            }

          

            SmtpClient client = new SmtpClient();
            client.Port = 465;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = false;
            client.Timeout = 15000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("acmenconle.info@gmail.com", "probando123");


            MailMessage mm = new MailMessage("acmenconle.info@gmail.com", correEnv, "Confirmación de pago", Html);
            mm.IsBodyHtml = true;

            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            client.Send(mm);

        }
        #endregion
    }
}

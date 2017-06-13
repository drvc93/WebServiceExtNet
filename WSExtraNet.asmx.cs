using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Services;

namespace WebServiceExtNet
{
    /// <summary>
    /// Descripción breve de WSExtraNet
    /// </summary>
 //[WebService(Namespace = "http://100.100.100.237:8030/")]
  [WebService(Namespace = "http://190.187.181.57:8030/")]
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
        public string VerificarUsuarioExiste(string dni)
        {
            string sql, result = "";
            int cont = 0;
            sql = "SELECT count(*) n_count FROM co_mve_usuario where c_dni = '" + dni + "'";
            SqlConnection cn = con.conexionLys();
            cn.Open();
            SqlDataAdapter dap = new SqlDataAdapter(sql, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.Text;
            dap.Fill(dt); 
            cn.Close();

            if (dt != null)
            {
                cont = Convert.ToInt32(dt.Rows[0]["n_count"]);
            }
            if (cont == 0)
            {
                result = "OK";
            }
            else if (cont > 0)
            {
                result = "NO";
            }

            return result;
        }

        [WebMethod]

        public string InsertarUsuario(string dni, string nombre, string apellido, string fechanac, string mail,
            string telefono, string empruc, string empnom)
        {
            string res = "-1";
            int sqlrows;

            if (dni == "" || String.IsNullOrEmpty(dni) == true) 
            {
                return "-1";
            }

            try
            {
                SqlConnection cn = con.conexion();
                SqlCommand sqlcmd = new SqlCommand("UP_MVE_INSERTUSERAPP", cn);
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

               
                    res = Convert.ToString(sqlcmd.Parameters["@IdReg"].Value);
                
            }
            catch (Exception e)
            {
                //      res = e.Message;
                res = "-1";
            }

            return res;
        }

        [WebMethod]
        public string InsertarCodigoQR(string dniQR, string codigoQR, string dniUF, string telefonoUF, string correoUF)
        {
            string res = "-1";
            int sqlrows;
            try
            {
                SqlConnection cn = con.conexion();
                SqlCommand sqlcmd = new SqlCommand("UP_MVE_INSERT_CODIGOQR", cn);
                sqlcmd.Connection = cn;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                sqlcmd.Parameters.AddWithValue("@dniQR", dniQR);
                sqlcmd.Parameters.AddWithValue("@CodigoQR", codigoQR);
                sqlcmd.Parameters.AddWithValue("@dniUF", dniUF);
                sqlcmd.Parameters.AddWithValue("@TelefonoUF", telefonoUF);
                sqlcmd.Parameters.AddWithValue("@CorreoUF", correoUF.Trim().ToLower());
               
                SqlParameter par = new SqlParameter("@IdReg", SqlDbType.Int);
                par.Direction = ParameterDirection.Output;
                sqlcmd.Parameters.Add(par);
                sqlrows = sqlcmd.ExecuteNonQuery();

               
                    res = Convert.ToString(sqlcmd.Parameters["@IdReg"].Value);
                
            }
            catch (Exception e)
            {
                res = "-1";
            }

            return res;
        }

        [WebMethod]
        public string TransferirUsuario(string tipo, int correlativo)
        {
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
                
                    res = this.EnviarCorreoInfo(tipo,correlativo);
                

            }

            return res;
        }


        [WebMethod]
        public string ValidarLogin(string user, string clave)
        {
            string res = "-99";
            int sqlrows;
            try
            {
                SqlConnection cn = con.conexion();
                SqlCommand sqlcmd = new SqlCommand("UP_MVE_GETVALLOGEO", cn);
                sqlcmd.Connection = cn;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                sqlcmd.Parameters.AddWithValue("@Dni", user);
                sqlcmd.Parameters.AddWithValue("@Clave", clave);
                SqlParameter par = new SqlParameter("@Msg", SqlDbType.Int);
                par.Direction = ParameterDirection.Output;
                //par.Size = 500;
                sqlcmd.Parameters.Add(par);
                sqlrows = sqlcmd.ExecuteNonQuery();
                res = sqlcmd.Parameters["@Msg"].Value.ToString();

                switch (res) 
                { 
                
                    case "-1":
                        res = "Usuario no Existe.";
                        break;
                    case "-2":
                         res = "Clave incorrecta.";
                        break;
                    case "-3":
                        res = "Usuario Inactivo.";
                        break;
                    case "0":
                    res = "OK";
                        break;

                }

            }
            catch (Exception e)
            {
                res = e.Message;
            }

            return res;

        }

        [WebMethod]
        public CUsuario[] AutenticarLogin(string user, string clave)
        {
            List<CUsuario> listaUsuarios = new List<CUsuario>();
            string SqL = "SELECT c_dni, c_clave, c_nombre, c_apellido, d_fechaNac, c_mail, c_telefono, c_emprRuc, c_emprNom " +
                         " FROM co_mve_usuario where c_dni = '" + user + "'";
            SqlConnection cn = con.conexionLys();
            cn.Open();
            SqlDataAdapter dap = new SqlDataAdapter(SqL, cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.Text;
           
            dap.Fill(dt);
            cn.Close();

            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CUsuario u = new CUsuario();
                    u.Dni = dt.Rows[i]["c_dni"].ToString();
                    u.Clave = dt.Rows[i]["c_clave"].ToString();
                    u.Nombre = dt.Rows[i]["c_nombre"].ToString();
                    u.Apellido = dt.Rows[i]["c_apellido"].ToString();
                    u.FechaNacimiento = dt.Rows[i]["d_fechaNac"].ToString();
                    u.Mail = dt.Rows[i]["c_mail"].ToString();
                    u.Telefono = dt.Rows[i]["c_telefono"].ToString();
                    u.Empruc = dt.Rows[i]["c_emprRuc"].ToString();
                    u.Empnom = dt.Rows[i]["c_emprNom"].ToString();

                    listaUsuarios.Add(u);
                }
            }

            return listaUsuarios.ToArray();
        }

        public string  EnviarCorreoInfo( string  tipo , int correlativo)
        {
            string correEnv = "", Html = "";
            string resulmail="";
            string SP_FINAL = "";
            string ASUNTO = "";
            if (tipo == "RU")
            {
                SP_FINAL = "UP_MVE_HTMLCORREOUSER";
                ASUNTO= "Datos de accesso";
            }
            else if (tipo=="EQ")
            {
                SP_FINAL = "UP_MVE_HTMLCORREOINFOQR";
                ASUNTO = "Se registro su codigo QR";
            }
            try
            {
                SqlConnection cn = con.conexion();
                cn.Open();
                SqlDataAdapter dap = new SqlDataAdapter(SP_FINAL, cn);
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
                client.Port = Constantes.PuertoSMTP;
                client.Host = Constantes.HostSMPT;//"filtroslys.com.pe";//"smtp.gmail.com";
                client.EnableSsl = false;
                client.Timeout = Constantes.TimeOutMail;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential(Constantes.UserCorreo, Constantes.Password);

                MailMessage mm = new MailMessage(Constantes.Correo, correEnv, ASUNTO, Html);
                mm.IsBodyHtml = true;

                mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                client.Send(mm);
                resulmail = "OK";
            }
            catch (Exception e)
            {

                resulmail = e.Message;
            }

            return resulmail;
        }


        [WebMethod]
        public string HtmlPortalApp() {
            string resulthtml = "";

            String BodyHtml = "", HeadHtml = "", FotHtml = "";
            SqlConnection cn = con.conexion();
            cn.Open();
            SqlDataAdapter dap = new SqlDataAdapter("SP_CO_MVE_APPLISTAPAGEINICIO", cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            //dap.SelectCommand.Parameters.AddWithValue("@Dni", dni);
            
            dap.Fill(dt);
            cn.Close();

            if (dt != null)
            {
                HeadHtml = "<!DOCTYPE html><html lang='en-us'><head><style>.divresp {float: left; margin: 10px; padding: 10px; max-width: 95%;height: 100%;border: 1px solid white;margin-right: 10px;width: 95%}" +
                            "</style></head><body><br><div class='divresp'><table>";
                FotHtml = "  </table></div></body></html>";

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
                   // Bitmap b = new Bitmap(@"\\Ibserver_1\servidor de archivos\Fotos\LWP2040P-web.jpg");
                    Bitmap b = new Bitmap(@"E:\Fotos\AFL116.jpg");
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    b.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] byteImage = ms.ToArray();
                    imgBase64 = Convert.ToBase64String(byteImage);

                    HtmlSeccion =  " <td><tr >  <p style='font-weight: bold' >"+stittulo+"</p> </tr> </td>";
                    HtmlSeccion = HtmlSeccion + "<td><tr >  "+sdetalle+"</tr></td>";
                    HtmlSeccion = HtmlSeccion + "<td> <tr ><img  style='height: 100%; width: 100%; object-fit: contain' src='data:image/jpeg;base64,"+imgBase64+"' /></tr></td>";
                    BodyHtml = BodyHtml + HtmlSeccion;

                }

                resulthtml = HeadHtml + BodyHtml + FotHtml;

            }




            return resulthtml;
        

        }

        [WebMethod]

        public CAccesos[] ListaAccesos(string dni) 
        {
            List<CAccesos> listAccesos = new List<CAccesos>();
            // string correEnv = "", Html = "";

            SqlConnection cn = con.conexionLys();
            cn.Open();
            SqlDataAdapter dap = new SqlDataAdapter("UP_MVE_LISTACCESOAPP", cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@Dni", dni);

            dap.Fill(dt);
            cn.Close();

            if (dt != null)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int nivel1 = Convert.ToInt32(dt.Rows[i]["n_nivel1"]);
                    int nivel2 = Convert.ToInt32(dt.Rows[i]["n_nivel2"]);
                    int nivel3 = Convert.ToInt32(dt.Rows[i]["n_nivel3"]);
                    int nivel4 = Convert.ToInt32(dt.Rows[i]["n_nivel4"]);
                    int nivel5 = Convert.ToInt32(dt.Rows[i]["n_nivel5"]);
                    int nivelGN = Convert.ToInt32(dt.Rows[i]["n_nivelGN"]);
                    string descripcion = Convert.ToString(dt.Rows[i]["c_descripcion"]);
                    CAccesos ac = new CAccesos(nivel1, nivel2, nivel3, nivel4, nivel5, descripcion, nivelGN);

                    listAccesos.Add(ac);

                }

                   
            }

            return listAccesos.ToArray();
        
        }

        [WebMethod] 
        public string VerificarCatalogo(string sfilro)
        {
            string resul = "N";
            Conexion con = new Conexion();
            // String BodyHtml = "", HeadHtml = "", FotHtml = "";
            SqlConnection cn = con.conexionLys();
            cn.Open();
            SqlDataAdapter dap = new SqlDataAdapter("SP_CO_MVE_APPCATALOGOLYS", cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@Item", sfilro);

            dap.Fill(dt);
            cn.Close();

            if (dt == null)
            {
                resul = "N";

                

            }
            else if (dt.Rows.Count <= 0) {

                resul = "N";
            }
            else if (dt.Rows.Count > 0) {

                resul = "S";
                return resul;

            }

            return resul;

        }
        
        #endregion
    }
}
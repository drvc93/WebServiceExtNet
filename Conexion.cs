using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace WebServiceExtNet
{
    public class Conexion
    {
        SqlConnection con;
        string Conn;
        public Conexion()
        {
            if (con == null)
                con = conexion();
        }

        public SqlConnection conexion()
        {
           // Conn = Constantes.ConexionString;

            string userdb  = System.Configuration.ConfigurationManager.AppSettings["UserDB"];
            string password = System.Configuration.ConfigurationManager.AppSettings["Password"];
            string DB = System.Configuration.ConfigurationManager.AppSettings["DB"];
            string server = System.Configuration.ConfigurationManager.AppSettings["Server"];

            Conn = "data source = " + server+ "; initial catalog = " + DB + "; user id = " + userdb+ "; password =" + password;


            return new SqlConnection(Conn);
        }

        
    }
}
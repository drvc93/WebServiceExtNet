using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceExtNet
{
    public class Constantes
    {
        //public static string ConexionString = "server=IBSERVER_29;uid=desarrollador2;pwd=@desit39;database=lys";
        public static string   CarpetaFotos =System.Configuration.ConfigurationManager.AppSettings["CarpetaFotos"];
        public static string Correo = System.Configuration.ConfigurationManager.AppSettings["Correo"];
        public static string UserCorreo = System.Configuration.ConfigurationManager.AppSettings["UserCorreo"];
        public static string Password = System.Configuration.ConfigurationManager.AppSettings["CorreoPassword"];
        public static string HostSMPT = System.Configuration.ConfigurationManager.AppSettings["hostSMTP"];
        public static int PuertoSMTP = Convert.ToInt32( System.Configuration.ConfigurationManager.AppSettings["PuertoSMTP"]);
        public static int TimeOutMail = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["TimeOutMail"]);
    }
}
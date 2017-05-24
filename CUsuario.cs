using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceExtNet
{
    public class CUsuario
    {
        private string dni;
        private string clave;
        private string nombre;
        private string apellido;
        private string fechaNacimiento;
        private string mail;
        private string telefono;
        private string empruc;
        private string empnom;


        public CUsuario() { }

        public CUsuario (string Dni , string Clave , string Nombre , string Apellido , string FechaNacimiento, string Mail,
                          string Telefono, string Empruc, string Empnom)
        {
            this.dni = Dni;
            this.clave = Clave;
            this.nombre = Nombre;
            this.apellido = Apellido;
            this.fechaNacimiento = FechaNacimiento;
            this.mail = Mail;
            this.telefono = Telefono;
            this.empruc = Empruc;
            this.empnom = Empnom;

        }

        public string Dni
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = value;
            }
        }

        public string Clave
        {
            get
            {
                return this.clave;
            }
            set
            {
                this.clave = value;
            }
        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }

        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = value;
            }
        }

        public string FechaNacimiento
        {
            get
            {
                return this.fechaNacimiento;
            }
            set
            {
                this.fechaNacimiento = value;
            }
        }

        public string Mail
        {
            get
            {
                return this.mail;
            }
            set
            {
                this.mail = value;
            }
        }

        public string Telefono
        {
            get
            {
                return this.telefono;
            }
            set
            {
                this.telefono = value;
            }
        }

        public string Empruc
        {
            get
            {
                return this.empruc;
            }
            set
            {
                this.empruc = value;
            }
        }

        public string Empnom
        {
            get
            {
                return this.empnom;
            }
            set
            {
                this.empnom = value;
            }
        }
    }
}
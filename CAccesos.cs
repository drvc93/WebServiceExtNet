using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceExtNet
{
    public class CAccesos
    {
        private int nivel1;
        private   int nivel2;
        private int nivel3;
        private int nivel4;
        private int nivel5;
        private string descripcion ;
        private int nivelgGN;

        public CAccesos() { }

        public CAccesos(int Nivel1, int Nivel2, int Nivel3, int Nivel4, int Nivel5, string Descripcion, int NivelGN) {

            this.nivel1 = Nivel1;
            this.nivel2 = Nivel2;
            this.nivel3 = Nivel3;
            this.nivel4 = Nivel4;
            this.nivel5 = Nivel5;
            this.descripcion = Descripcion;
            this.nivelgGN = NivelGN;

        
        }
             
        public int Nivel1
        {
            get
            {
                return this.nivel1;
            }
            set
            {
                this.nivel1 = value;
            }
        }

        public int Nivel2
        {
            get
            {
                return this.nivel2;
            }
            set
            {
                this.nivel2 = value;
            }
        }

        public int Nivel3
        {
            get
            {
                return this.nivel3;
            }
            set
            {
                this.nivel3 = value;
            }
        }

        public int Nivel4
        {
            get
            {
                return this.nivel4;
            }
            set
            {
                this.nivel4 = value;
            }
        }

        public int Nivel5
        {
            get
            {
                return this.nivel5;
            }
            set
            {
                this.nivel5 = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return this.descripcion;
            }
            set
            {
                this.descripcion = value;
            }
        }

        public int NivelgGN
        {
            get
            {
                return this.nivelgGN;
            }
            set
            {
                this.nivelgGN = value;
            }
        }
    }
}
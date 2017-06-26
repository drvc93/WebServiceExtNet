using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceExtNet
{
    public class ItemFactor
    {
        private string item;
        private string propaganda;
        private string flagcontador;
        private int segundos;
        private string descPromo;

        public ItemFactor() { }

        public ItemFactor(string Item, string Propaganda, string Flag, int Segundos) 
        {

            this.item = Item;
            this.propaganda = Propaganda;
            this.flagcontador = Flag;
            this.segundos = Segundos;

        }

       

        public string Item
        {
            get
            {
                return this.item;
            }
            set
            {
                this.item = value;
            }
        }

        public string Propaganda
        {
            get
            {
                return this.propaganda;
            }
            set
            {
                this.propaganda = value;
            }
        }

        public string Flagcontador
        {
            get
            {
                return this.flagcontador;
            }
            set
            {
                this.flagcontador = value;
            }
        }

        public int Segundos
        {
            get
            {
                return this.segundos;
            }
            set
            {
                this.segundos = value;
            }
        }
        public string DescPromo
        {
            get
            {
                return this.descPromo;
            }
            set
            {
                this.descPromo = value;
            }
        }
    }
}
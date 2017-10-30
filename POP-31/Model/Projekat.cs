using POP_31.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_31.Model
{
    public class Projekat
    {
        public static Projekat Instance { get; } = new Projekat();

        private List<Namestaj> namestaj = new List<Namestaj>();
        
        public List<Namestaj> Namestaj
        {
            get
            {
                this.namestaj = GenericSerializer.Deserialize<Namestaj>("namestaj.xml");
                return this.namestaj;
            }
            set
            {
                this.namestaj = value;
                GenericSerializer.Serialize<Namestaj>("namestaj.xml", this.namestaj);
            }
        }


        //public List<TipNamestaja> TipoviNamestaja { get: set:}
        //public List<Namestaj> Namestaj { get: set:}
        
        

        public Projekat()
        {
            
        }
    }
}

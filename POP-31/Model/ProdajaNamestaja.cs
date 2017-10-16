using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_31.Model
{
    public class ProdajaNamestaja
    {

        public string Id { get; set; }

        public List<Namestaj> NamestajZaProdaju { get; set; }

        public DateTime DatumProdaje { get; set; }

        public string BrojRacuna { get; set; }

        public string Kupac { get; set; }

        public double PDV { get; set; }

        public List<DodatnaUsluga> DodatnaUsluga { get; set; }

        public double UkupanIznos { get; set; }



    }
}

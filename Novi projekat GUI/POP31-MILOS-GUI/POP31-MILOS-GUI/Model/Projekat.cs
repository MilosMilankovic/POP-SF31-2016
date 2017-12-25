using POP_31.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_31.Model
{
    public class Projekat
    {
        public static Projekat Instance { get; private set; } = new Projekat();

        public ObservableCollection<Namestaj> Namestaj;
        public ObservableCollection<TipNamestaja> TipNamestaja;
        public ObservableCollection<Akcija> Akcije;
        public ObservableCollection<Korisnik> Korisnici;
        public Projekat()
        {
            Namestaj = GenericSerializer.Deserialize<Namestaj>("Namestaj.xml");
            TipNamestaja = GenericSerializer.Deserialize<TipNamestaja>("tipoviNamestaja.xml");
            //Akcije = GenericSerializer.Deserialize<Akcija>("akcije.xml");
            Korisnici = GenericSerializer.Deserialize<Korisnik>("korisnici.xml");
        }
    }
}

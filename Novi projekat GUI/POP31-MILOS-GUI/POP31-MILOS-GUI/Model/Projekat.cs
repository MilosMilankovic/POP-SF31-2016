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
        //public object DodatnaUsluga { get; internal set; }

        public Korisnik ulogovaniKorisnik;
        public ObservableCollection<Namestaj> Namestaj;
        public ObservableCollection<TipNamestaja> TipNamestaja;
        public ObservableCollection<Akcija> Akcije;
        public ObservableCollection<Korisnik> Korisnici;
        public ObservableCollection<DodatnaUsluga> DodatneUsluge;
        public Salon Salon;
        public ObservableCollection<ProdajaNamestaja> Prodaja;
        public Projekat()
        {
            //Namestaj = GenericSerializer.Deserialize<Namestaj>("Namestaj.xml");
            //TipNamestaja = GenericSerializer.Deserialize<TipNamestaja>("tipoviNamestaja.xml");
            TipNamestaja = Model.TipNamestaja.GetAll();
            Namestaj = Model.Namestaj.GetAll();
            //Akcije = GenericSerializer.Deserialize<Akcija>("akcije.xml");
            Akcije = Akcija.GetAll();
            //Korisnici = GenericSerializer.Deserialize<Korisnik>("korisnici.xml");
            Korisnici = Korisnik.GetAll();
            //DodatneUsluge = GenericSerializer.Deserialize<DodatnaUsluga>("dodatneUsluge.xml");
            DodatneUsluge = DodatnaUsluga.GetAll();
            //Salon = GenericSerializer.DeSerializeObject<Salon>("salon.xml");
            Salon = Model.Salon.Get();
            Prodaja = GenericSerializer.Deserialize<ProdajaNamestaja>("prodaje.xml");

        }
    }
}

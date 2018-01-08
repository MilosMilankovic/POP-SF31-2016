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
            TipNamestaja = Model.TipNamestaja.GetAll();
            Namestaj = Model.Namestaj.GetAll();
            Akcije = Akcija.GetAll();
            Korisnici = Korisnik.GetAll();
            DodatneUsluge = DodatnaUsluga.GetAll();
            Salon = Model.Salon.Get();
            Prodaja = GenericSerializer.Deserialize<ProdajaNamestaja>("prodaje.xml");

        }
    }
}

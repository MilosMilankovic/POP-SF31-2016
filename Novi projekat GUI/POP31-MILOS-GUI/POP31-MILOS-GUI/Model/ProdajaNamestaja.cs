using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POP_31.Model
{
    [Serializable]

    public class ProdajaNamestaja : INotifyPropertyChanged
    {

        private string kupac;
        private string brojRacuna;
        private int id;
        private DateTime vremeKupovine;
        public ObservableCollection<int> listaDodatnihUslugaID;
        [XmlIgnore]
        public ObservableCollection<DodatnaUsluga> listaDodatnihUsluga; 
        public ObservableCollection<ParProdaja> listaParova;  


        public ObservableCollection<DodatnaUsluga> ListaDodatnihUsluga
        {
            get
            {
                ObservableCollection < DodatnaUsluga > lista = new ObservableCollection<DodatnaUsluga>();
                foreach(int id in listaDodatnihUslugaID)
                {
                    lista.Add(DodatnaUsluga.GetById(id));
                }
                return lista;
            }
        }

        public string Kupac
        {
            get
            {
                return kupac;
            }
            set
            {
                kupac = value;
                OnPropertyChanged("Kupac");
            }
        }

        public string BrojRacuna
        {
            get
            {
                return brojRacuna;
            }
            set
            {
                brojRacuna = value;
                OnPropertyChanged("BrojRacuna");
            }
        }

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        public DateTime VremeKupovine
        {
            get
            {
                return vremeKupovine;
            }
            set
            {
                vremeKupovine = value;
                OnPropertyChanged("VremeKupovine");
            }
        }

       
        public double UkupnaCena 
        {
            get
            {
                double cena = 0;
                
                foreach (ParProdaja par in listaParova)
                {
                    cena += par.Namestaj.JedinicnaCena * par.Kolicina *  (100-Akcija.GetPopustByNamestaj(par.Namestaj))/100; 
                }
                foreach(DodatnaUsluga usluga in ListaDodatnihUsluga)
                {
                    cena += usluga.Cena;
                }
                return cena * 1.2;
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class ParProdaja : INotifyPropertyChanged    // za popust
    {
        int kolicina;
        int namestajId;

        public ParProdaja()
        {

        }

        public ParProdaja(Namestaj namestaj, int kolicina)
        {
            this.Namestaj = namestaj;
            this.Kolicina = kolicina;
        }

        [XmlIgnore]
        public Namestaj Namestaj  
        {
            get { return Namestaj.GetById(namestajId); }
            set
            {
                namestajId = value.Id;
                OnPropertyChanged("Namestaj");

            }
        }

        public int NamestajId  
        {
            get { return namestajId; }
            set
            {
                namestajId = value;
                OnPropertyChanged("Namestaj");
                OnPropertyChanged("NamestajId");
            }
        }

        public int Kolicina
        {
            get
            {
                return kolicina;
            }
            set
            {
                kolicina = value;
                OnPropertyChanged("Kolicina");
            }
        }

        public void Copy(ParProdaja source)
        {
            this.NamestajId = source.NamestajId;
            this.Kolicina = source.Kolicina;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }

        }
    }
}

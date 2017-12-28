using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POP_31.Model
{
    [Serializable]


    public class Akcija : INotifyPropertyChanged
    {
        ObservableCollection<Par> listaParova;

        public ObservableCollection<Par> ListaParova
        {
            get { return listaParova; }
            set
            {
                listaParova = value;
                OnPropertyChanged("ListaParova");
            }
        }


        public Akcija()
        {
            this.listaParova = new ObservableCollection<Par>();
        }

        public Akcija(string naziv, DateTime pocetak, DateTime kraj, ObservableCollection<Par> listaParova)
        {
            this.Id = Projekat.Instance.Akcije.Count;
            this.Naziv = naziv;
            this.Pocetak = pocetak;
            this.Kraj = kraj;
            this.ListaParova = listaParova;
        }


        private int id;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        private string naziv;

        public string Naziv
        {
            get { return naziv; }
            set
            {
                naziv = value;
                OnPropertyChanged("Naziv");
            }
        }

        private bool obrisan;

         public bool Obrisan
        {
            get { return obrisan; }
            set
            {
                obrisan = value;
                OnPropertyChanged("Obrisan");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }

        }
        

        private DateTime pocetak;

        public DateTime Pocetak
        {
            get { return pocetak; }
            set
            {
                pocetak = value;
                OnPropertyChanged("Pocetak");
            }
        }


        private DateTime kraj;

        public DateTime Kraj
        {
            get { return kraj; }
            set
            {
                kraj = value;
                OnPropertyChanged("Kraj");
            }
        }
        public void Copy(Akcija source)
        {
            this.Naziv = source.Naziv;
            this.Id = source.Id;
            this.Obrisan = source.Obrisan;
            this.Pocetak = source.Pocetak;
            this.Kraj = source.Kraj;
            this.ListaParova = new ObservableCollection<Par>(source.listaParova); // nova lista
        }


    }

    public class Par  : INotifyPropertyChanged    // za popust
    {
        double popust;
        int namestajId;

        public Par()
        {

        }

        public Par(Namestaj namestaj, double popust)
        {
            this.Namestaj = namestaj;
            this.Popust = popust;
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

        public double Popust
        {
            get
            {
                return popust;
            }
            set
            {
                popust = value;
                OnPropertyChanged("Popust");
            }
        }
        
        public void Copy(Par source)
        {
            this.NamestajId = source.NamestajId;
            this.Popust = source.Popust;
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

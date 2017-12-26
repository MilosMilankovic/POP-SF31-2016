using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static POP_31.Model.Namestaj;

namespace POP_31.Model
{
    [Serializable]

    public class Namestaj : INotifyPropertyChanged
    {
        private int id;
        private string naziv;
        private double jedinicnaCena;
        private int kolicinaUMagacinu;
        private string sifra;
        private int tipNamestajaId;
        private bool obrisan;

        public Namestaj()
        {

        }

        public Namestaj(string naziv, string sifra, double cena, int kolicinaUMagacinu, int tipNamestajaId)
        {
            this.Id = Projekat.Instance.Namestaj.Count;
            this.Obrisan = false;
            this.Naziv = naziv;
            this.Sifra = sifra;
            this.JedinicnaCena = cena;
            this.KolicinaUMagacinu = kolicinaUMagacinu;
            this.TipNamestajaId = tipNamestajaId;
        }

        public bool Obrisan
        {
            get { return obrisan; }
            set
            {
                obrisan = value;
                OnPropertyChanged("Obrisan");
            }
        }

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Naziv
        {
            get { return naziv; }
            set
            {
                naziv = value;
                OnPropertyChanged("Naziv");
            }
        }
        public double JedinicnaCena
        {
            get { return jedinicnaCena; }
            set
            {
                jedinicnaCena = value;
                OnPropertyChanged("JedinicnaCena");
            }
        }

        public int KolicinaUMagacinu
        {
            get { return kolicinaUMagacinu; }
            set
            {
                kolicinaUMagacinu = value;
                OnPropertyChanged("KolicinaUMagacinu");
            }
        }


        public string Sifra
        {
            get { return sifra; }
            set
            {
                sifra = value;
                OnPropertyChanged("Sifra");
            }
        }

        [XmlIgnore] 
        public TipNamestaja TipNamestaja
        {
           get { return TipNamestaja.GetById(tipNamestajaId); }
            set
            {
                TipNamestajaId = value.Id;
                OnPropertyChanged("TipNamestaja");
            }
        }

        public int TipNamestajaId
        {
            get { return tipNamestajaId; }
            set
            {
                tipNamestajaId = value;
                OnPropertyChanged("TipNamestajaId");
            }
        }
       
        public event PropertyChangedEventHandler PropertyChanged;
    

   
        protected void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null) 
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void Copy(Namestaj source)
        {
            this.Id = source.Id;
            this.JedinicnaCena = source.JedinicnaCena;
            this.Naziv = source.Naziv;
            this.KolicinaUMagacinu = source.KolicinaUMagacinu;
            this.TipNamestaja = source.TipNamestaja;
            this.Sifra = source.Sifra;
            this.Obrisan = source.Obrisan;
        }
       
    }
}

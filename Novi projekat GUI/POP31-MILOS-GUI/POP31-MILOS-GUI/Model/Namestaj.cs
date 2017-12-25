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
        private int kolicinaUmagacinu;
        private string sifra;
        private int tipNamestajaId;
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

        public int KolicinaUmagacinu
        {
            get { return kolicinaUmagacinu; }
            set
            {
                kolicinaUmagacinu = value;
                OnPropertyChanged("KolicinaUmagacinu");
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
    }
}

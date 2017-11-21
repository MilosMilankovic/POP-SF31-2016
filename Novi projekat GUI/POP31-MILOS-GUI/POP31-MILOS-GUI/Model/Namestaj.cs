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
        private TipNamestaja tipNamestaja;
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


        public int TipNamestajaId
        {
            get { return tipNamestajaId; }
            set
            {
                tipNamestajaId = value;
                OnPropertyChanged("TipNamestajaId");
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
                OnPropertyChanged("Cena");
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

        [XmlIgnore]  //atributi
        public TipNamestaja TipNamestaja
        {
            get
            {
                if(tipNamestaja ==null)
                {
                    //tipNamestaja = GetTipNamestaja().GetById(GetTipNamestaja());
                }
                return tipNamestaja;
            }
            set
            {
                tipNamestaja = value;
                OnPropertyChanged("TipNamestaja");

            }
        }
        /*
        public int Obrisan
        {
            get { return obrisan; }
            set
            {
                obrisan = value;
                OnPropertyChanged("Obrisan");
            }
        }*/
        public event PropertyChangedEventHandler PropertyChanged;
    

    
/*
    public class Namestaj
    {
        
        public int Id { get; set; }

        public string Naziv { get; set; }

        public string Sifra { get; set; }

        public double JedinicnaCena { get; set; }

        public int KolicinaUmagacinu { get; set; }

        public int TipNamestaja{ get; set; }

        public Akcija Akcija { get; set; }

         public bool Obrisan { get; set; }

*/
        protected void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null) 
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

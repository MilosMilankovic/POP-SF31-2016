using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_31.Model
{
    [Serializable]

    public enum TipKorisnika
    {
        Administrator,
        Prodavac
    }

    public class Korisnik : INotifyPropertyChanged
    {

       
        public Korisnik()
        {

        }

        public Korisnik(string ime, string prezime, string korisnickoIme, string lozinka, TipKorisnika tipKorisnika)
        {
            this.Id = Projekat.Instance.Korisnici.Count;
            this.Ime = ime;
            this.Prezime = prezime;
            this.KorisnickoIme = korisnickoIme;
            this.Lozinka = lozinka;
            this.TipKorisnika = tipKorisnika;
            this.Obrisan = false;
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

     
        private string ime;

        public string Ime
        {
            get { return ime; }
            set
            {
                ime = value;
                OnPropertyChanged("Ime");
            }
        }
        
        private string prezime;

        public string Prezime
        {
            get { return prezime; }
            set
            {
                prezime = value;
                OnPropertyChanged("Prezime");
            }
        }

        private string korisnickoIme;

        public string KorisnickoIme
        {
            get { return korisnickoIme; }
            set
            {
                korisnickoIme = value;
                OnPropertyChanged("KorisnickoIme");
            }
        }

        
        private string lozinka;

        public string Lozinka
        {
            get { return lozinka; }
            set
            {
                lozinka = value;
                OnPropertyChanged("Lozinka");
            }
        }
        

        private TipKorisnika tipKorisnika;

        public TipKorisnika TipKorisnika
        {
            get { return tipKorisnika; }
            set
            {
                tipKorisnika = value;
                OnPropertyChanged("TipKorisnika");
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


        public void Copy(Korisnik source)
        {
            this.Id = source.Id;
            this.Ime = source.Ime;
            this.Prezime = source.Prezime;
            this.KorisnickoIme = source.KorisnickoIme;
            this.Lozinka = source.Lozinka;
            this.TipKorisnika = source.TipKorisnika;
            this.Obrisan = source.Obrisan;
        }
      
    }
}

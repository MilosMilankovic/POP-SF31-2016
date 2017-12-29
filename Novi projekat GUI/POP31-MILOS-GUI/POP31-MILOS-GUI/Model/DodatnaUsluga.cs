using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_31.Model
{
    [Serializable]

    public class DodatnaUsluga : INotifyPropertyChanged
    {
        private string naziv;
        private double cena;
        private bool obrisan;
        private int id;

        public DodatnaUsluga()
        {

        }

        public DodatnaUsluga(string naziv, double cena)
        {
            this.Naziv = naziv;
            this.Cena = cena;
            this.Obrisan = false;
            this.Id = Projekat.Instance.DodatneUsluge.Count;
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
        
        public double Cena
        {
            get { return cena; }
            set
            {
                cena = value;
                OnPropertyChanged("Cena");
            }
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

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public static DodatnaUsluga GetById(int id)
        {
            foreach(DodatnaUsluga usluga in Projekat.Instance.DodatneUsluge)
            {
                if(usluga.Id == id)
                {
                    return usluga;
                }
             }
            return null;
        }

        public void Copy(DodatnaUsluga source)
        {
            this.Id = source.Id;
            this.Naziv = source.Naziv;
            this.Cena = source.Cena;
            this.Obrisan = source.Obrisan;
        }
    }
}

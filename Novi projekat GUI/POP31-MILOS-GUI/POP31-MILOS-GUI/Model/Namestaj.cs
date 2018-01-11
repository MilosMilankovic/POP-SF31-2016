using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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

        public static Namestaj GetById(int id)
        {
            foreach( Namestaj namestaj in Projekat.Instance.Namestaj)
            {
                if(namestaj.Id == id)
                {
                    return namestaj;
                }
            }
            return null;
        }




        public static ObservableCollection<Namestaj> GetAll()
        {
            ObservableCollection<Namestaj> namestaj = new ObservableCollection<Namestaj>();

            using (SqlConnection con = new SqlConnection("Integrated Security=true;Initial Catalog=POP;Data Source=DESKTOP-R18IMBS"))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.CommandText = "SELECT * FROM Namestaj Where Obrisan = 0;";
                da.SelectCommand = cmd;
                da.Fill(ds, "Namestaj");

                foreach (DataRow row in ds.Tables["Namestaj"].Rows)
                {
                    Namestaj n = new Namestaj()
                    {
                        Id = Convert.ToInt32(row["Id"]),
                        Naziv = row["Naziv"].ToString(),
                        Sifra = row["Sifra"].ToString(),
                        JedinicnaCena = Convert.ToDouble(row["JedinicnaCena"]),
                        KolicinaUMagacinu = Convert.ToInt32(row["KolicinaUMagacinu"]),
                        TipNamestajaId = Convert.ToInt32(row["TipNamestajaId"]), 
                        Obrisan = bool.Parse(row["Obrisan"].ToString())
                    };
                    namestaj.Add(n);
                }
            }
            return namestaj;
        }

        public static Namestaj Create(Namestaj n)
        {
            using (var con = new SqlConnection("Integrated Security=true;Initial Catalog=POP;Data Source=DESKTOP-R18IMBS"))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "INSERT INTO Namestaj (TipNamestajaId, Naziv, Sifra, JedinicnaCena, KolicinaUMagacinu, Obrisan) VALUES (@TipNamestajaId, @Naziv, @Sifra, @JedinicnaCena, @KolicinaUMagacinu, @Obrisan);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("TipNamestajaId", n.TipNamestajaId);
                cmd.Parameters.AddWithValue("Naziv", n.Naziv);
                cmd.Parameters.AddWithValue("Sifra", n.Sifra);
                cmd.Parameters.AddWithValue("JedinicnaCena", n.JedinicnaCena);
                cmd.Parameters.AddWithValue("KolicinaUMagacinu", n.KolicinaUMagacinu);
                cmd.Parameters.AddWithValue("Obrisan", n.Obrisan);

                n.Id = int.Parse(cmd.ExecuteScalar().ToString());
            }

            Projekat.Instance.Namestaj.Add(n);

            return n;
        }

        public static void Update(Namestaj n)
        {
            using (var con = new SqlConnection("Integrated Security=true;Initial Catalog=POP;Data Source=DESKTOP-R18IMBS"))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "UPDATE Namestaj SET TipNamestajaId=@TipNamestajaId, Naziv=@Naziv, Sifra=@Sifra, JedinicnaCena=@JedinicnaCena, KolicinaUMagacinu=@KolicinaUMagacinu, Obrisan=@Obrisan WHERE Id=@Id;";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";

                cmd.Parameters.AddWithValue("Id", n.Id);
                cmd.Parameters.AddWithValue("TipNamestajaId", n.TipNamestajaId);
                cmd.Parameters.AddWithValue("Naziv", n.Naziv);
                cmd.Parameters.AddWithValue("Sifra", n.Sifra);
                cmd.Parameters.AddWithValue("JedinicnaCena", n.JedinicnaCena);
                cmd.Parameters.AddWithValue("KolicinaUMagacinu", n.KolicinaUMagacinu);
                cmd.Parameters.AddWithValue("Obrisan", n.Obrisan);

                cmd.ExecuteNonQuery();
            }

            // Update model
            Namestaj.GetById(n.Id).Copy(n);
        }

        public static void Delete(Namestaj n)
        {
            n.Obrisan = true;
            Update(n);
        }

    }
}

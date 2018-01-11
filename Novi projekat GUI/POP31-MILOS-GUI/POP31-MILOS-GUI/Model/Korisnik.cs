using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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

        public static Korisnik GetById(int id)  
        {
            foreach( Korisnik korisnik in Projekat.Instance.Korisnici)
            {
                if(korisnik.Id == id)
                {
                    return korisnik;
                }
            }
            return null;
        }


        public static ObservableCollection<Korisnik> GetAll()
        {
            ObservableCollection<Korisnik> korisnici = new ObservableCollection<Korisnik>();

            using (SqlConnection con = new SqlConnection("Integrated Security=true;Initial Catalog=POP;Data Source=DESKTOP-R18IMBS"))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.CommandText = "SELECT * FROM Korisnik Where Obrisan = 0;";
                da.SelectCommand = cmd;
                da.Fill(ds, "Korisnik");

                foreach (DataRow row in ds.Tables["Korisnik"].Rows)
                {
                    Korisnik k = new Korisnik()
                    {
                        Id = Convert.ToInt32(row["Id"]),
                        Ime = row["Ime"].ToString(),
                        Prezime = row["Prezime"].ToString(),
                        KorisnickoIme = row["KorisnickoIme"].ToString(),
                        Lozinka = row["Lozinka"].ToString(),
                        TipKorisnika = (row["TipKorisnika"].ToString() == "Administrator") ? TipKorisnika.Administrator : TipKorisnika.Prodavac,
                        Obrisan = bool.Parse(row["Obrisan"].ToString())
                    };
                    korisnici.Add(k);
                }
            }
            return korisnici;
        }

        public static Korisnik Create(Korisnik k)
        {
            using (var con = new SqlConnection("Integrated Security=true;Initial Catalog=POP;Data Source=DESKTOP-R18IMBS"))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "INSERT INTO Korisnik (Ime, Prezime, KorisnickoIme, Lozinka, TipKorisnika, Obrisan) VALUES (@Ime,@Prezime,@KorisnickoIme,@Lozinka, @TipKorisnika, @Obrisan);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("Ime", k.Ime);
                cmd.Parameters.AddWithValue("Prezime", k.Prezime);
                cmd.Parameters.AddWithValue("KorisnickoIme", k.KorisnickoIme);
                cmd.Parameters.AddWithValue("Lozinka", k.Lozinka);
                cmd.Parameters.AddWithValue("Obrisan", k.Obrisan);
                cmd.Parameters.AddWithValue("TipKorisnika", k.TipKorisnika.ToString());


                k.Id = int.Parse(cmd.ExecuteScalar().ToString());
            }


            Projekat.Instance.Korisnici.Add(k);

            return k;
        }

        public static void Update(Korisnik k)
        {
            using (var con = new SqlConnection("Integrated Security=true;Initial Catalog=POP;Data Source=DESKTOP-R18IMBS"))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "UPDATE Korisnik SET Ime=@Ime, Prezime=@Prezime, KorisnickoIme=@KorisnickoIme, Lozinka=@Lozinka, TipKorisnika=@TipKorisnika, Obrisan=@Obrisan WHERE Id=@Id;";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";

                cmd.Parameters.AddWithValue("Id", k.Id);
                cmd.Parameters.AddWithValue("Ime", k.Ime);
                cmd.Parameters.AddWithValue("Prezime", k.Prezime);
                cmd.Parameters.AddWithValue("KorisnickoIme", k.KorisnickoIme);
                cmd.Parameters.AddWithValue("Lozinka", k.Lozinka);
                cmd.Parameters.AddWithValue("TipKorisnika", k.TipKorisnika.ToString());
                cmd.Parameters.AddWithValue("Obrisan", k.Obrisan);

                cmd.ExecuteNonQuery();
            }

            // Update model
            Korisnik.GetById(k.Id).Copy(k);
        }

        public static void Delete(Korisnik k)
        {
            k.Obrisan = true;
            
            Update(k);
        }


    }
}

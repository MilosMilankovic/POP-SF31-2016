using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_31.Model
{
    [Serializable]

    public class Salon : INotifyPropertyChanged
    {
       
        private string naziv;
        private string adresa;
        private string telefon;
        private string email;
        private string adresaSajta;
        private int pib;
        private int maticniBroj;
        private string ziroRacun;

        

        //public int Id { get; set; }




        public string Naziv
        {
            get
            {
                return naziv;
            }
            set
            {
                naziv = value;
                OnPropertyChanged("Naziv");
            }
        }

        public string Adresa
        {
            get
            {
                return adresa;
            }
            set
            {
                adresa = value;
                OnPropertyChanged("Adresa");
            }
        }

        public string Telefon
        {
            get
            {
                return telefon;
            }
            set
            {
                telefon = value;
                OnPropertyChanged("Telefon");
            }
        }
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }

        public string AdresaSajta
        {
            get
            {
                return adresaSajta;
            }
            set
            {
                adresaSajta = value;
                OnPropertyChanged("AdresaSajta");
            }
        }
        public int PIB
        {
            get
            {
                return pib;
            }
            set
            {
                pib = value;
                OnPropertyChanged("PIB");
            }
        }

        public int MaticniBroj
        {
            get
            {
                return maticniBroj;
            }
            set
            {
                maticniBroj = value;
                OnPropertyChanged("MaticniBroj");
            }
        }
        public string ZiroRacun
        {
            get
            {
                return ziroRacun;
            }
            set
            {
                ziroRacun = value;
                OnPropertyChanged("ZiroRacun");
            }
        }

        public Salon() { }
        public Salon(string naziv, string adresa, string telefon, string email, string adresaSajta, int pib, int maticniBroj, string ziroRacun)
        {
            this.Naziv = naziv;
            this.Adresa = adresa;
            this.Telefon = telefon;
            this.Email = email;
            this.AdresaSajta = adresaSajta;
            this.PIB = pib;
            this.MaticniBroj = maticniBroj;
            this.ZiroRacun = ziroRacun;
            
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void Copy (Salon source)
        {
            this.Naziv = source.Naziv;
            this.Adresa = source.Adresa;
            this.Telefon = source.Telefon;
            this.Email = source.Email;
            this.AdresaSajta = source.AdresaSajta;
            this.PIB = source.PIB;
            this.MaticniBroj = source.MaticniBroj;
            this.ZiroRacun = source.ZiroRacun;
        }



        public static Salon Get()
        {
            Salon salon = new Salon();

            using (SqlConnection con = new SqlConnection("Integrated Security=true;Initial Catalog=POP;Data Source=DESKTOP-R18IMBS"))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.CommandText = "SELECT * FROM Salon;";
                da.SelectCommand = cmd;
                da.Fill(ds, "Salon");

                foreach (DataRow row in ds.Tables["Salon"].Rows)
                {

                    //Id = Convert.ToInt32(row["Id"]),
                    salon.Naziv = row["Naziv"].ToString();
                    salon.Adresa = row["Adresa"].ToString();
                    salon.Telefon = row["Telefon"].ToString();
                    salon.ZiroRacun = row["ZiroRacun"].ToString();
                    salon.PIB = Convert.ToInt32(row["Pib"]);
                    salon.MaticniBroj= Convert.ToInt32(row["MaticniBroj"]);
                    salon.AdresaSajta= row["AdresaSajta"].ToString();
                    salon.Email= row["Email"].ToString();


                }
            }
            return salon;
        }


        public static void Update(Salon s)
        {
            using (var con = new SqlConnection("Integrated Security=true;Initial Catalog=POP;Data Source=DESKTOP-R18IMBS"))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "UPDATE Salon SET Naziv=@Naziv,Telefon=@Telefon,Adresa=@Adresa,Email=@Email,AdresaSajta=@AdresaSajta,Pib=@Pib,MaticniBroj=@MaticniBroj,ZiroRacun=@ZiroRacun WHERE Id=1;";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";


                cmd.Parameters.AddWithValue("Naziv", s.Naziv);
                cmd.Parameters.AddWithValue("Telefon", s.Telefon);
                cmd.Parameters.AddWithValue("Adresa", s.Adresa);
                cmd.Parameters.AddWithValue("Email", s.Email);
                cmd.Parameters.AddWithValue("AdresaSajta", s.AdresaSajta);
                cmd.Parameters.AddWithValue("Pib", s.PIB);
                cmd.Parameters.AddWithValue("MaticniBroj", s.MaticniBroj);
                cmd.Parameters.AddWithValue("ZiroRacun", s.ZiroRacun);

                cmd.ExecuteNonQuery();
            }

            Projekat.Instance.Salon.Copy(s);


        }






    }
}

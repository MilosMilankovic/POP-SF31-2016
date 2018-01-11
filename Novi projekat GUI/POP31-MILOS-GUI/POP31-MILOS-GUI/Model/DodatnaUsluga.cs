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




        public static ObservableCollection<DodatnaUsluga> GetAll()
        {
            ObservableCollection<DodatnaUsluga> dodatneUsluge = new ObservableCollection<DodatnaUsluga>();

            using (SqlConnection con = new SqlConnection("Integrated Security=true;Initial Catalog=POP;Data Source=DESKTOP-R18IMBS"))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.CommandText = "SELECT * FROM DodatnaUsluga Where Obrisan = 0;";
                da.SelectCommand = cmd;
                da.Fill(ds, "DodatnaUsluga");

                foreach (DataRow row in ds.Tables["DodatnaUsluga"].Rows)
                {
                    DodatnaUsluga du = new DodatnaUsluga()
                    {
                        Id = Convert.ToInt32(row["Id"]),
                        Naziv = row["Naziv"].ToString(),
                        Cena = Convert.ToDouble(row["Cena"]),
                        Obrisan = bool.Parse(row["Obrisan"].ToString())
                    };
                    dodatneUsluge.Add(du);
                }
            }
            return dodatneUsluge;
        }

        public static DodatnaUsluga Create(DodatnaUsluga du)
        {
            using (var con = new SqlConnection("Integrated Security=true;Initial Catalog=POP;Data Source=DESKTOP-R18IMBS"))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "INSERT INTO DodatnaUsluga (Naziv,Cena,Obrisan) VALUES (@Naziv,@Cena, @Obrisan);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("Naziv", du.Naziv);
                cmd.Parameters.AddWithValue("Cena", du.Cena);
                cmd.Parameters.AddWithValue("Obrisan", du.Obrisan);

                du.Id = int.Parse(cmd.ExecuteScalar().ToString());
            }


            Projekat.Instance.DodatneUsluge.Add(du);

            return du;
        }

        public static void Update(DodatnaUsluga du)
        {
            using (var con = new SqlConnection("Integrated Security=true;Initial Catalog=POP;Data Source=DESKTOP-R18IMBS"))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "UPDATE DodatnaUsluga SET Naziv=@Naziv, Cena=@Cena, Obrisan=@Obrisan WHERE Id=@Id;";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";

                cmd.Parameters.AddWithValue("Id", du.Id);
                cmd.Parameters.AddWithValue("Naziv", du.Naziv);
                cmd.Parameters.AddWithValue("Cena", du.Cena);
                cmd.Parameters.AddWithValue("Obrisan", du.Obrisan);

                cmd.ExecuteNonQuery();
            }

            // Update model
            DodatnaUsluga.GetById(du.Id).Copy(du);
        }

        public static void Delete(DodatnaUsluga du)
        {
            du.Obrisan = true;
            
            Update(du);
        }


    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_31.Model
{
    [Serializable]

    public class TipNamestaja : INotifyPropertyChanged
    {


        public string naziv;
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


        public string Naziv
        {
            get { return naziv; }
            set
            {
                naziv = value;
                OnPropertyChanged("Naziv");
            }
        }

      
        
    
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #region Database
        public static ObservableCollection<TipNamestaja> GetAll()
        {
            var tipoviNamestaja = new ObservableCollection<TipNamestaja>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))           /*using, sve sto je definisano u bloku, nakon izlaza se brise, zatvara se konekcija*/
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM TipNamestaja WHERE Obrisan=0";

                //cmd.CommandText = "SELECT * FROM TipNamestaja WHERE Obrisan=@Obrisan";

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();

                da.SelectCommand = cmd;
                da.Fill(ds, "TipNamestaja");  //izvrsava se query nad bazom

                foreach (DataRow row in ds.Tables["TipNamestaja"].Rows)
                {
                    var tn = new TipNamestaja();
                    tn.Id = int.Parse(row["Id"].ToString());
                    tn.Naziv = row["Naziv"].ToString();
                    //tn.Obrisan = bool.Parse(row["Obrisan"].ToString());

                    tipoviNamestaja.Add(tn);
                }
            }
             return tipoviNamestaja;

            }                  
            
         public static TipNamestaja Create(TipNamestaja tn)
          {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {

                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = $"INSERT INTO TipNamestaja (Naziv, Obrisan) VALUES (@Naziv, @Obrisan);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";

                cmd.Parameters.AddWithValue("Naziv", tn.Naziv);
                //cmd.Parameters.AddWithValue("Obrisan", tn.Obrisan);

                int newId = int.Parse(cmd.ExecuteScalar().ToString());
                tn.Id = newId;
             }

            Projekat.Instance.TipNamestaja.Add(tn); //azuriran i  stanje modela

            return tn;
          }

        public static void Update(TipNamestaja tn)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE TipNamestaja SET Naziv=@Naziv, @Obrisan WHERE id=@Id";

                cmd.Parameters.AddWithValue("Id", tn.Id);
                cmd.Parameters.AddWithValue("Naziv", tn.Id);
                //cmd.Parameters.AddWithValue("Obrisan", tn.Obrisan);

                cmd.ExecuteNonQuery();

                foreach (var tipNamestaja in Projekat.Instance.TipNamestaja)
                {
                    if(tipNamestaja.Id == tn.Id)
                    {
                        tipNamestaja.Naziv = tn.Naziv;
                        //tipNamestaja.Obrisan = tn.Obrisan;
                        break;
                    }
                }
            }
        }


        public static void Delete(TipNamestaja tn)
        {
            //tn.Obrisan = true;
            Update(tn);
        }


        }

        
        #endregion

    }


 
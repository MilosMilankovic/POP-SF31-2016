﻿using System;
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
        private bool obrisan;

        public TipNamestaja()
        {
           
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

        public bool Obrisan
        {
            get { return obrisan; }
            set
            {
                obrisan = value;
                OnPropertyChanged("Obrisan");
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

        public static TipNamestaja GetById(int id)  
        {
            foreach (TipNamestaja tip in Projekat.Instance.TipNamestaja)
            {
                if(tip.Id== id)
                {
                    return tip;
                }
            }
            return null;
        }

        public void Copy(TipNamestaja source)   
        {
            this.Naziv = source.Naziv;
            this.Id = source.Id;
            this.Obrisan = source.Obrisan;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public override string ToString()
        {
            return $"{Naziv}";
        }


        public static ObservableCollection<TipNamestaja> GetAll()
        {
            ObservableCollection<TipNamestaja> tipoviNamestaja = new ObservableCollection<TipNamestaja>();

            using (SqlConnection con = new SqlConnection("Integrated Security=true;Initial Catalog=POP;Data Source=DESKTOP-R18IMBS"))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.CommandText = "SELECT * FROM TipNamestaja WHERE Obrisan = 0;";
                da.SelectCommand = cmd;
                da.Fill(ds, "TipNamestaja");

                foreach (DataRow row in ds.Tables["TipNamestaja"].Rows)  
                {
                    TipNamestaja tn = new TipNamestaja()  
                    {
                        Id = Convert.ToInt32(row["Id"]),
                        Naziv = row["Naziv"].ToString(),
                        Obrisan = bool.Parse(row["Obrisan"].ToString())
                    };
                    tipoviNamestaja.Add(tn); 
                }
            }
            return tipoviNamestaja; 
        }

        public static TipNamestaja Create(TipNamestaja tn)
        {
            using (var con = new SqlConnection("Integrated Security=true;Initial Catalog=POP;Data Source=DESKTOP-R18IMBS"))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "INSERT INTO TipNamestaja (Naziv, Obrisan) VALUES (@Naziv, @Obrisan);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("Naziv", tn.Naziv);
                cmd.Parameters.AddWithValue("Obrisan", tn.Obrisan);

                tn.Id = int.Parse(cmd.ExecuteScalar().ToString());
            }


            Projekat.Instance.TipNamestaja.Add(tn); 

            return tn;
        }

        public static void Update(TipNamestaja tn)
        {
            using (var con = new SqlConnection("Integrated Security=true;Initial Catalog=POP;Data Source=DESKTOP-R18IMBS"))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "UPDATE TipNamestaja SET Naziv=@Naziv, Obrisan=@Obrisan WHERE Id=@Id;";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";

                cmd.Parameters.AddWithValue("Id", tn.Id);
                cmd.Parameters.AddWithValue("Naziv", tn.Naziv);
                cmd.Parameters.AddWithValue("Obrisan", tn.Obrisan);

                cmd.ExecuteNonQuery();
            }

            // Update model
            TipNamestaja.GetById(tn.Id).Copy(tn);
        }

        public static void Delete(TipNamestaja tn)
        {
            tn.Obrisan = true;
            foreach (Namestaj namestaj in Projekat.Instance.Namestaj)
            {
                if (namestaj.TipNamestajaId == tn.Id)
                {
                    namestaj.Obrisan = true;
                }
            }
            Update(tn);
        }


    }
}


 
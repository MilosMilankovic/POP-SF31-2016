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

namespace POP_31.Model
{
    [Serializable]


    public class Akcija : INotifyPropertyChanged
    {
        ObservableCollection<Par> listaParova;

        public ObservableCollection<Par> ListaParova
        {
            get { return listaParova; }
            set
            {
                listaParova = value;
                OnPropertyChanged("ListaParova");
            }
        }


        public Akcija()
        {
            this.listaParova = new ObservableCollection<Par>();
        }

        public Akcija(string naziv, DateTime pocetak, DateTime kraj, ObservableCollection<Par> listaParova)
        {
            this.Id = Projekat.Instance.Akcije.Count;
            this.Naziv = naziv;
            this.Pocetak = pocetak;
            this.Kraj = kraj;
            this.ListaParova = listaParova;
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

        private string naziv;

        public string Naziv
        {
            get { return naziv; }
            set
            {
                naziv = value;
                OnPropertyChanged("Naziv");
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

        public static Akcija GetById(int id)
        {
            foreach(Akcija akcija in Projekat.Instance.Akcije)
            {
                if(akcija.Id == id)
                {
                    return akcija;
                }
            }
            return null;
        }


        public static double GetPopustByNamestaj(Namestaj namestaj)  //trazi popust za namestaj
        {
            foreach(Akcija akcija in Projekat.Instance.Akcije)
            {
                if (akcija.Obrisan == false)
                {
                    foreach(Par par in akcija.ListaParova)
                    {
                        if(par.NamestajId == namestaj.Id)
                        {
                            return par.Popust;
                        }
                    }
                }
            }
            return 0;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }

        }
        

        private DateTime pocetak;

        public DateTime Pocetak
        {
            get { return pocetak; }
            set
            {
                pocetak = value;
                OnPropertyChanged("Pocetak");
            }
        }


        private DateTime kraj;

        public DateTime Kraj
        {
            get { return kraj; }
            set
            {
                kraj = value;
                OnPropertyChanged("Kraj");
            }
        }
        public void Copy(Akcija source)
        {
            this.Naziv = source.Naziv;
            this.Id = source.Id;
            this.Obrisan = source.Obrisan;
            this.Pocetak = source.Pocetak;
            this.Kraj = source.Kraj;
            this.ListaParova = new ObservableCollection<Par>(source.listaParova); // nova lista
        }



        public static ObservableCollection<Akcija> GetAll()
        {
            ObservableCollection<Akcija> akcije = new ObservableCollection<Akcija>();

            using (SqlConnection con = new SqlConnection("Integrated Security=true;Initial Catalog=POP;Data Source=DESKTOP-R18IMBS"))
            {
                con.Open();


                SqlCommand cmd = con.CreateCommand();
                SqlCommand cmd2 = con.CreateCommand();

                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                DataSet ds2 = new DataSet();

                cmd.CommandText = "SELECT * FROM Akcija;";
                cmd2.CommandText = "Select * From NaAkciji;";
                da.SelectCommand = cmd;
                da.Fill(ds, "Akcija");
                da.SelectCommand = cmd2;
                da.Fill(ds, "NaAkciji");

                foreach (DataRow row in ds.Tables["Akcija"].Rows)
                {
                    Akcija a = new Akcija()
                    {
                        Id = Convert.ToInt32(row["Id"]),
                        Naziv = row["Naziv"].ToString(),
                        Pocetak = Convert.ToDateTime(row["DatumPocetka"]),
                        Kraj = Convert.ToDateTime(row["DatumKraja"]),
                        Obrisan = bool.Parse(row["Obrisan"].ToString())
                    };


                    foreach (DataRow row2 in ds.Tables["NaAkciji"].Rows)
                    {
                        if (a.Id == Convert.ToInt32(row2["IdAkcija"]))
                        {


                            Par par = new Par()
                            {
                                NamestajId = Convert.ToInt32(row2["IdNamestaj"]),
                                Popust = Convert.ToDouble(row2["Popust"])
                            };
                            a.listaParova.Add(par);
                        }
                    }


                    akcije.Add(a);
                }
            }
            return akcije;
        }
        
        public static Akcija Create(Akcija a)
        {
            using (var con = new SqlConnection("Integrated Security=true;Initial Catalog=POP;Data Source=DESKTOP-R18IMBS"))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                SqlCommand cmd2 = con.CreateCommand();

                cmd.CommandText = "INSERT INTO Akcija (Naziv,DatumPocetka, DatumKraja,Obrisan) VALUES (@Naziv,@DatumPocetka,@DatumKraja, 0);";
                //cmd.CommandText = "INSERT INTO Akcija (Naziv,DatumPocetka,DatumKraja,Obrisan) VALUES (@Naziv,'2017-01-12T00:00:00', '2018-01-02T00:00:00', @Obrisan);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("Naziv", a.Naziv);
                cmd.Parameters.AddWithValue("DatumPocetka", a.Pocetak);
                cmd.Parameters.AddWithValue("DatumKraja", a.Kraj);
                cmd.Parameters.AddWithValue("Obrisan", a.Obrisan);

                
                a.Id = int.Parse(cmd.ExecuteScalar().ToString());

                foreach (Par par in a.listaParova)
                {
                    cmd2.CommandText = "INSERT INTO NaAkciji (IdAkcija,IdNamestaj,Popust) VALUES (@IdAkcija,@IdNamestaj,@Popust);";

                    cmd2.CommandText += "SELECT SCOPE_IDENTITY();";
                    cmd2.Parameters.AddWithValue("IdAkcija", a.Id);
                    cmd2.Parameters.AddWithValue("IdNamestaj", par.NamestajId );
                    cmd2.Parameters.AddWithValue("Popust", par.Popust);

                    cmd2.ExecuteScalar();
                }
            }


            Projekat.Instance.Akcije.Add(a);

            return a;
        }
        
        public static void Update(Akcija a)
        {
            a.Obrisan = true;

            Create(a);

            //Delete(a);

            // Update model
            
        }

        public static void Delete(Akcija a)
        {
            a.Obrisan = true;

            Update(a);
        }

    

    






    }

    public class Par  : INotifyPropertyChanged    // za popust
    {
        double popust;
        int namestajId;

        public Par()
        {

        }

        public Par(Namestaj namestaj, double popust)
        {
            this.Namestaj = namestaj;
            this.Popust = popust;
        }

        [XmlIgnore]
        public Namestaj Namestaj
        {
            get { return Namestaj.GetById(namestajId); }
            set
            {
                namestajId = value.Id;
                OnPropertyChanged("Namestaj");
                
            }
        }

        public int NamestajId
        {
            get { return namestajId; }
            set
            {
                namestajId = value;
                OnPropertyChanged("Namestaj");
                OnPropertyChanged("NamestajId");
            }
        }

        public double Popust
        {
            get
            {
                return popust;
            }
            set
            {
                popust = value;
                OnPropertyChanged("Popust");
            }
        }
        
        public void Copy(Par source)
        {
            this.NamestajId = source.NamestajId;
            this.Popust = source.Popust;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }

        }


        



    }


}

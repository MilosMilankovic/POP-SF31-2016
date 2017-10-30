
using POP_31.Model;
using POP_31.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_31
{
    class Program
    {

        public static List<Namestaj> lista { get; set; } = new List<Namestaj>();
        public static string filename = "namestaj.xml";

        static void Main(string[] args)
        {
            lista = Projekat.Instance.Namestaj;
          

            
            Salon s1 = new Salon()
            {
                Id = 1,
                Naziv = "Forma FTNale",
                Adresa = "Trg Dositeja Obradovica 6",
                BrojZiroRacuna = "840-000768666",
                Email = "kontakt@uns.ftn.ac.rs",
                MaticniBroj = 12244245,
                PIB = 33244443,
                Telefon = "021/445-342",
                AdresaInternetSajta = "http://www.ftn.uns.ac.rs"
            };


            


            Console.WriteLine("Dobrodosli u salon namestaja. ");
            IspisiGlavniMeni();


            Console.ReadLine();
            
        
        }


        private static void IspisiGlavniMeni()
        {
            int izbor = 0;

            do
            {
                Console.WriteLine("====GLAVNI MENI====");
                Console.WriteLine("1. Rad sa namestajem");
                Console.WriteLine("2. Rad sa tipom namestaja");
                Console.WriteLine("0. Izlaz iz aplikacije");
                izbor = int.Parse(Console.ReadLine());
            } while (izbor < 0 || izbor > 2);

            
            

            switch (izbor)
            {

                case 1:
                    IspisiMeniNamestaja();
                    break;
                case 2:
                    IspisiMeniTipaNamestaja();
                    break;
                case 0:
                    GenericSerializer.Serialize<Namestaj>(filename, lista);
                    Environment.Exit(0);
                    break;

                default:
                    break;
            }

        }


        private static void IspisiMeniTipaNamestaja()
        {
           //
        }

        private static void IspisiMeniNamestaja()
        {
            int izbor = 0;
            do
            {
                Console.WriteLine("====NAMESTAJ====");
                Console.WriteLine("1. Listing namestaja");
                Console.WriteLine("2. Dodaj novi namestaj");
                Console.WriteLine("3. Izmeni postojeci");
                Console.WriteLine("4. Obrisi postojeci");
                Console.WriteLine("5. Pretraga po id-u");
                Console.WriteLine("0. Povratak na meni");
                izbor = int.Parse(Console.ReadLine());
            } while (izbor < 0 || izbor > 5);

            

            switch (izbor)
            {
                case 1:
                    IzlistajNamestaj();
                    IspisiMeniNamestaja();
                    break;

                case 2:
                    DodajNamestaj();
                    IspisiMeniNamestaja();
                    break;

                case 3:
                    IzmeniNamestaj();
                    IspisiMeniNamestaja();
                    break;

                case 4:
                    ObrisiNamestaj();
                    IspisiMeniNamestaja();
                    break;
                case 5:
                    PretraziListu();
                    IspisiMeniNamestaja();
                    break;

                case 0:
                    IspisiGlavniMeni();
                    break;

                default:
                    break;
            }

        }

        private static void PretraziListu()
        {
            Console.Write("Unesite id po kom trazite:");
            int id=int.Parse(Console.ReadLine());
            bool nadjen=false;

            foreach(Namestaj nn in lista)
            {
                if(nn.Id==id)
                {
                    Console.WriteLine();
                    nadjen = true;
                    Console.WriteLine($"Id:{nn.Id}");
                    Console.WriteLine($"Naziv:{nn.Naziv}");
                    Console.WriteLine($"Jedinicna cena:{nn.JedinicnaCena}");
                    Console.WriteLine($"Kolicina u magacinu: {nn.KolicinaUmagacinu}");
                    Console.WriteLine($"Tip namestaja:{nn.TipNamestaja.Naziv}");
                    Console.WriteLine();
                }
            }
            if(nadjen==false)
            {
                Console.WriteLine("Ne postoji namestaj sa tim id-em!");
            }
        }
        private static void ObrisiNamestaj()
        {
            Console.WriteLine("Unesite id namestaja koji zelite da obrisete");
            int id= int.Parse(Console.ReadLine());
            bool obrisan = false;
            foreach(var a in lista)
            {
                if(a.Id==id)
                {
                    lista.Remove(a);
                    obrisan = true;
                    break;
                }
            }

            if(obrisan==false)
            {
                Console.WriteLine("Ne postoji element sa ovim id-em");
            }

        }
        private static void IzmeniNamestaj()
        {
            bool nadjen = false;
            int id = 0;
            do
            {
                
                Console.WriteLine("Unesite Id namestaja");
                id = int.Parse(Console.ReadLine());
                foreach (Namestaj nm in lista)
                {
                    if (nm.Id == id)
                    {
                        nadjen = true;
                    }
                }
            } while (nadjen == false);

            
            Console.WriteLine("Unesite novi naziv namestaja");
            string naziv = Console.ReadLine();

            Console.WriteLine("Unesite novu jedinicnu cenu");
            double jc = double.Parse(Console.ReadLine());

            Console.WriteLine("Unesite kolicinu");
            int kolicina = int.Parse(Console.ReadLine());
            foreach(var a in lista)
            {
                if(a.Id==id)
                {
                    a.Naziv = naziv;
                    a.JedinicnaCena = jc;
                    a.KolicinaUmagacinu = kolicina;
                   
                }
            }




        }
        private static void DodajNamestaj()
        {
            
            bool nadjen = false;
            int id = 0;
            do
            {
                nadjen = false;
                Console.WriteLine("Unesi Id namestaja");
                id = int.Parse(Console.ReadLine());
                foreach (Namestaj namestaj in lista)
                {
                    if (namestaj.Id == id)
                    {
                        nadjen = true;
                    }
                }
            } while (nadjen == true);

            Console.WriteLine("Unesite naziv namestaja");
            string naziv =Console.ReadLine();

            Console.WriteLine("Unesite sifru");
            string sifra = Console.ReadLine();

            Console.WriteLine("Unesite jedinicnu cenu");
            double jc = double.Parse(Console.ReadLine());

            Console.WriteLine("Unesite kolicinu");
            int kolicina = int.Parse(Console.ReadLine());
            int opcija = 0;
            do
            {
                Console.WriteLine("Unesite koji je tip namestaja(1-stolovi,2-kreveti,3-ormari):");
                opcija = int.Parse(Console.ReadLine());
            } while (opcija != 1 && opcija != 2 && opcija != 3);
            TipNamestaja t1 = new TipNamestaja();





            if (opcija == 1)
            {

                t1.Id = 5;
                t1.Naziv = "Stolovi";
                t1.Obrisan = false;
            }

            if(opcija==2)
            {
                t1.Id = 6;
                t1.Naziv = "Kreveti";
                t1.Obrisan = false;
            }
            if(opcija==3)
            {
                t1.Id = 7;
                t1.Naziv = "Ormari";
                t1.Obrisan = false;
            }



                Namestaj n = new Namestaj();
                n.Obrisan = false;
                n.Akcija = null;
                n.TipNamestaja = t1;        

                n.Id = id;
                n.Naziv = naziv;
                n.Sifra = sifra;
                n.JedinicnaCena = jc;
                n.KolicinaUmagacinu = kolicina;

                lista.Add(n);
            
            
        }
        private static void IzlistajNamestaj()
        {
            
            Console.WriteLine("==== LISTING NAMESTAJA====");

            foreach (var nam in lista)
            {
                Console.WriteLine($"Id:{nam.Id}");
                Console.WriteLine($"Naziv:{nam.Naziv}");
                Console.WriteLine($"Jedinicna cena:{nam.JedinicnaCena}");
                Console.WriteLine($"Kolicina u magacinu: {nam.KolicinaUmagacinu}");
                Console.WriteLine($"Tip namestaja:{nam.TipNamestaja.Naziv}");
                Console.WriteLine();
                
            }
            IspisiMeniNamestaja();
        }


    }

}
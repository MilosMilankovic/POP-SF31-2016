
using POP_31.Model;

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


        static void Main(string[] args)
        {
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

            var sofaTipNamestaj = new TipNamestaja()
            {
                Id = 1,
                Naziv = "Sofa",
                Obrisan=false
                
            };

            TipNamestaja krevet = new TipNamestaja();
            krevet.Id = 2;
            krevet.Naziv = "dormeo";
            krevet.Obrisan = false;

           

            
           
            
            /*Namestaj.Add(new Namestaj() 
            {
                Id = 1,
                Cena = 20,
                Naziv = "Sofa 123",
                KolicinaUmagacinu = 2,
                Akcija = null,
                Sifra = "SF123",
                TipNamestaja = sofaTipNamestaj

            });
            */

            Namestaj n = new Model.Namestaj();
            n.Akcija = null;
            n.Id = 1;
            n.Naziv = "Sofa 123";
            n.KolicinaUmagacinu = 2;
            n.JedinicnaCena = 100;
            n.Sifra = "sf123";
            n.TipNamestaja = sofaTipNamestaj;

            lista.Add(n);

            Namestaj n1 = new Model.Namestaj();
            n1.Akcija = null;
            n1.Id = 2;
            n1.Naziv = "krevet 123";
            n1.JedinicnaCena = 500;
            n1.KolicinaUmagacinu = 2;
            n1.Sifra = "sf1";
            n1.TipNamestaja = krevet;
       
            lista.Add(n1);




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
                // TODO: dodati ostale entitete
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
                Console.WriteLine("0. Povratak na meni");
                izbor = int.Parse(Console.ReadLine());
            } while (izbor < 0 || izbor > 4);

            

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

                case 0:
                    IspisiGlavniMeni();
                    break;

                default:
                    break;
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
            Console.WriteLine("Unesite Id namestaja");
            int id = int.Parse(Console.ReadLine());


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
            Console.WriteLine("Unesi Id namestaja");
            int id =int.Parse(Console.ReadLine());

            Console.WriteLine("Unesite naziv namestaja");
            string naziv =Console.ReadLine();

            Console.WriteLine("Unesite sifru");
            string sifra = Console.ReadLine();

            Console.WriteLine("Unesite jedinicnu cenu");
            double jc = double.Parse(Console.ReadLine());

            Console.WriteLine("Unesite kolicinu");
            int kolicina = int.Parse(Console.ReadLine());

            Namestaj n = new Namestaj();
            n.Obrisan = false;
            n.Akcija = null;
            n.TipNamestaja = null;

            n.Id = id;
            n.Naziv = naziv;
            n.Sifra = sifra;
            n.JedinicnaCena = jc;
            n.KolicinaUmagacinu = kolicina;

            lista.Add(n);






            
        }

        private static void IzlistajNamestaj()
        {
            int index = 0;
            Console.WriteLine("==== LISTING NAMESTAJA====");

            foreach (var namestaj in lista)
            {
                Console.WriteLine($"{ ++index}. {namestaj.Naziv}, cena: {namestaj.JedinicnaCena}");
                
            }
            IspisiMeniNamestaja();
        }
    }

}
using POP_31.Model;
using POP_31.Util;
using POP31_MILOS_GUI.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace POP31_MILOS_GUI
{
    

    public partial class MainWindow : Window
    {
        public static List<Namestaj> lista;
        public static List<TipNamestaja> tipNamLista;
        public static List<string> listString;
        public MainWindow()
        {

            InitializeComponent();
            this.DataContext = this;
            lista = new List<Namestaj>();
            lista = GenericSerializer.Deserialize<Namestaj>("file.xml");
            tipNamLista = new List<TipNamestaja>();
            listString = new List<string>();
            dataGr.ItemsSource = lista;
            TipNamestaja tip = new TipNamestaja();
            tip.Id = 1;
            tip.Naziv = "Krevet";
            tip.Obrisan = false;

            TipNamestaja tip1 = new TipNamestaja();
            tip1.Id = 2;
            tip1.Naziv = "Sto";
            tip1.Obrisan = false;

            tipNamLista.Add(tip);
            tipNamLista.Add(tip1);
            foreach(TipNamestaja nnn in tipNamLista)
            {
                listString.Add(nnn.Naziv);
            }

           


        }

        private void Dodaj(object sender, RoutedEventArgs e)
        {
            AddWindow window = new AddWindow();
            window.ShowDialog();
            dataGr.Items.Refresh();
        }

       
       
        

        private void Izmeni(object sender, RoutedEventArgs e)
        {
           if(dataGr.SelectedItem!=null)
            {
                Namestaj temp = dataGr.SelectedItem as Namestaj;
                AddWindow prozor = new AddWindow();
                prozor.TBId.Text = Convert.ToString(temp.Id);
                prozor.TBId.IsEnabled = false;
                prozor.TBNaziv.Text = temp.Naziv;
                prozor.TBSifra.Text = Convert.ToString(temp.Sifra);
                prozor.TBjedCena.Text = Convert.ToString(temp.JedinicnaCena);
                prozor.TBkolicinaUmag.Text = temp.KolicinaUmagacinu.ToString();
                //prozor.TBTipNamestaja.Text = temp.TipNamestaja.ToString();
                prozor.ShowDialog();
                dataGr.Items.Refresh();
                GenericSerializer.Serialize<Namestaj>("file.xml", MainWindow.lista);
            }
           else
            {
                MessageBox.Show("Morate selektovati ono sto menjate!");
            }
        }

        private void Obrisi(object sender, RoutedEventArgs e)
        {
            if (dataGr.SelectedItem != null)
            {
                if (MessageBox.Show($"Da li ste sigurni da zelite da izbrisete?", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Namestaj n = dataGr.SelectedItem as Namestaj;
                    foreach (Namestaj nam in MainWindow.lista)
                    {
                        if (nam.Id == n.Id)
                        {
                            MainWindow.lista.Remove(nam);
                            break;
                        }
                    }
                    dataGr.Items.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Niste selektovali sta hocete da obrisete!");
                
            }
        }
    }
}

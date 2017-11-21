using POP_31.Model;
using POP_31.Util;
using POP31_MILOS_GUI.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public static ObservableCollection<Namestaj> lista;
        public static ObservableCollection<TipNamestaja> tipNamLista;
        public static ObservableCollection<string> listString;
        public MainWindow()
        {

            InitializeComponent();
            lista = new ObservableCollection<Namestaj>();
            lista= Projekat.Instance.Namestaj;
            dataGr.ItemsSource = lista;
            tipNamLista = new ObservableCollection<TipNamestaja>();
            listString = new ObservableCollection<string>();
            tipNamLista = GenericSerializer.Deserialize<TipNamestaja>("tipoviNamestaja.xml");
            foreach (var a in tipNamLista)
            {
                listString.Add(a.Naziv);
            }
            



        }

        private void Dodaj(object sender, RoutedEventArgs e)
        {
            AddWindow window = new AddWindow();
            window.labelaDodavanje.IsEnabled = true;
            window.labelaIzmena.IsEnabled = false;
            window.labelaId.Visibility = Visibility.Hidden;
            window.ShowDialog();
            dataGr.Items.Refresh();
        }

       
       
        

        private void Izmeni(object sender, RoutedEventArgs e)
        {
           if(dataGr.SelectedItem!=null)
            {
                Namestaj temp = dataGr.SelectedItem as Namestaj;
                AddWindow prozor = new AddWindow();
                prozor.labelaId.Content = temp.Id;
                prozor.labelaId.Visibility = Visibility.Hidden;
                prozor.labelaDodavanje.IsEnabled = false;
                prozor.labelaIzmena.IsEnabled = true;
                prozor.TBNaziv.Text = Convert.ToString(temp.Naziv);
                prozor.TBSifra.Text = Convert.ToString(temp.Sifra);
                prozor.TBjedCena.Text = Convert.ToString(temp.JedinicnaCena);
                prozor.TBkolicinaUmag.Text = temp.KolicinaUmagacinu.ToString();
                foreach(var item in MainWindow.listString)
                {
                    if(item==temp.TipNamestaja.naziv)
                    {
                        prozor.Combobx.SelectedValue = item;
                    }
                }
                prozor.ShowDialog();
                dataGr.Items.Refresh();
                GenericSerializer.Serialize<Namestaj>("Namestaj.xml", MainWindow.lista);
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

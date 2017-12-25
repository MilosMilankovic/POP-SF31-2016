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
        public MainWindow()
        {
            
            
            InitializeComponent();
            lista = new ObservableCollection<Namestaj>();
            lista= Projekat.Instance.Namestaj;
            tipNamLista = new ObservableCollection<TipNamestaja>();
            tipNamLista = GenericSerializer.Deserialize<TipNamestaja>("tipoviNamestaja.xml");
            dataGr.ItemsSource = lista;






        }

        private void Dodaj(object sender, RoutedEventArgs e)
        {
            if (LogInWindow.isAdmin == true)
            {
                AddWindow window = new AddWindow();
                window.labelaIzmena.Content = "Dodavanje";
                window.ShowDialog();
                dataGr.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Samo admin moze da dodaje artikle!");
            }
        }
        private void Izmeni(object sender, RoutedEventArgs e)
        {
            if (LogInWindow.isAdmin == true)
            {

                if (dataGr.SelectedItem != null)
                {
                    AddWindow prozor = new AddWindow(dataGr.SelectedItem as Namestaj);
                    prozor.labelaIzmena.Content = "Izmena";
                    prozor.ShowDialog();
                    dataGr.Items.Refresh();
                }
                else
                {
                    MessageBox.Show("Morate odabrati sta menjate!");
                }
            }
            else
            {
                MessageBox.Show("Samo admin moze da menja artikle!");
            }
        }
        private void Obrisi(object sender, RoutedEventArgs e)
        {
            
            if (dataGr.SelectedItem != null)
            {
                if (LogInWindow.isAdmin == true)
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
                        GenericSerializer.Serialize<Namestaj>("Namestaj.xml", lista);
                    }

                    
                }
                else
                {
                    MessageBox.Show("Samo admin moze da brise artikle!");
                }
            }
            else
            {
                MessageBox.Show("Niste selektovali sta hocete da obrisete!");

            }

        }

        private void Prikaz_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if ((string)e.Column.Header =="Id" ) 
            {
                e.Cancel = true;
            }

            if ((string)e.Column.Header == "Obrisan")
            {
                e.Cancel = true;
            }

            if ((string)e.Column.Header == "TipNamestaja")
            {
                e.Cancel = true;
            }


        }

        private void Racun(object sender, RoutedEventArgs e)
        {
            if(dataGr.SelectedItem!=null)
            {
                TicketWindow win = new TicketWindow(dataGr.SelectedItem as Namestaj);
                win.ShowDialog();
                GenericSerializer.Serialize<Namestaj>("Namestaj.xml", lista);
            }
            else
            {
                MessageBox.Show("Morate selektovati sta kupujete");
            }
        }

        private void Zatvori(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void DodajTipNamestaja(object sender, RoutedEventArgs e)
        {
            NewType window = new NewType();
            window.ShowDialog();
        }

        private void AkcijeMeni(object sender, RoutedEventArgs e)
        {

        }
    }
}

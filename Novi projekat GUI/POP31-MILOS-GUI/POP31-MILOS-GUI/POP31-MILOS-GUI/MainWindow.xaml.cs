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
 // da izbaci tip namestaja kad se otvori izmjena i dodavanje
 // da izmene upise u xml

    public partial class MainWindow : Window

    {



        /*
        public static ObservableCollection<Namestaj> lista;
        public static ObservableCollection<TipNamestaja> tipNamLista;
        */ //da se izbaci static
        public MainWindow()
        {

            InitializeComponent();
            
            view = CollectionViewSource.GetDefaultView(Projekat.Instance.Namestaj);
            view.Filter = NamestajFilter;
            dgNamestaj.ItemSource = view; //dgMainwindo
            dgNamestaj.issyncronizedWithcurrentitems = true;

            dgNamestaj.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

        } 

        private bool NamestajFilter(object obj)
        {
            return ((Namestaj)obj).Obrisan == false;
        
        */

            /*
            lista = new ObservableCollection<Namestaj>();
            lista= Projekat.Instance.Namestaj;
            tipNamLista = new ObservableCollection<TipNamestaja>();
            tipNamLista = GenericSerializer.Deserialize<TipNamestaja>("tipoviNamestaja.xml");
            dataGr.ItemsSource = lista;
            */


        }

        private void Dodaj(object sender, RoutedEventArgs e)
        {
            AddWindow window = new AddWindow();
            window.labelaDodavanje.IsEnabled = true;
            window.labelaIzmena.IsEnabled = false;
            window.ShowDialog();
            dataGr.Items.Refresh();
        }
        private void Izmeni(object sender, RoutedEventArgs e)
        {
           
            if(dataGr.SelectedItem!=null)
            {
                AddWindow prozor = new AddWindow(dataGr.SelectedItem as Namestaj);
                prozor.labelaDodavanje.IsEnabled = false;
                prozor.labelaIzmena.IsEnabled = true;
                prozor.ShowDialog();
                //dataGr.Items.Refresh();
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
                            //view.Refresh();
                            break;
                        }
                    }
                    dataGr.Items.Refresh();
                    GenericSerializer.Serialize<Namestaj>("Namestaj.xml", lista);
                }
            }
            else
            {
                MessageBox.Show("Niste selektovali sta hocete da obrisete!");
                
            }
       
        private void dgPrikaz_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
            {
                if ((string)e.Column.Header == 'ID') //da izbacimo kolonu koja nam ne treba
                {
                    e.Cancel = true;
                }
            }
        
        }
            

    }
}

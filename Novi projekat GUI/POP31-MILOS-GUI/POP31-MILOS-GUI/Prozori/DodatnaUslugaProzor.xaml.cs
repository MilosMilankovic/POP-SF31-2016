using POP_31.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace POP31_MILOS_GUI.Prozori
{
    /// <summary>
    /// Interaction logic for DodatnaUslugaProzor.xaml
    /// </summary>
    public partial class DodatnaUslugaProzor : Window
    {
        ICollectionView view;
        public DodatnaUslugaProzor()
        {
            InitializeComponent();

            view = CollectionViewSource.GetDefaultView(Projekat.Instance.DodatneUsluge);
            view.Filter = HideDeletedFilter;
            dgDodatnaUsluga.ItemsSource = view;

            if(Projekat.Instance.ulogovaniKorisnik.TipKorisnika == TipKorisnika.Prodavac)
            {
                btnDodaj.IsEnabled = false;
                btnIzmeni.IsEnabled = false;
                btnObrisi.IsEnabled = false;
            }

        }

        private bool HideDeletedFilter(object obj)
        {
            return !((DodatnaUsluga)obj).Obrisan;   // nemoj prikazati ako je obrisan
        }
        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            DodatnaUslugaEditProzor prozor = new DodatnaUslugaEditProzor();
            prozor.Show();

        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            if (dgDodatnaUsluga.SelectedItem != null)
            {
                DodatnaUslugaEditProzor prozor = new DodatnaUslugaEditProzor((DodatnaUsluga)dgDodatnaUsluga.SelectedItem);
                prozor.Show();

            }
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            if(dgDodatnaUsluga.SelectedItem != null)
            {
                DodatnaUsluga.Delete((DodatnaUsluga)dgDodatnaUsluga.SelectedItem);
                view.Refresh();
            }
        }
    }
}

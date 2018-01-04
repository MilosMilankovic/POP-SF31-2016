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
    /// Interaction logic for KorisnikProzor.xaml
    /// </summary>
    public partial class KorisnikProzor : Window
    {
        ICollectionView view;
        public KorisnikProzor()
        {
            InitializeComponent();

            view = CollectionViewSource.GetDefaultView(Projekat.Instance.Korisnici);
            view.Filter = HideDeletedFilter;
            dgKorisnik.ItemsSource = view;


            if (Projekat.Instance.ulogovaniKorisnik.TipKorisnika == TipKorisnika.Prodavac)
            {
                btnDodaj.IsEnabled = false;
                btnIzmeni.IsEnabled = false;
                btnObrisi.IsEnabled = false;
            }

        }
        private bool HideDeletedFilter(object obj)
        {
            return !((Korisnik)obj).Obrisan;   // nemoj prikazati ako je obrisan
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            KorisnikEditProzor prozor = new KorisnikEditProzor();
            prozor.Show();
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            if(dgKorisnik.SelectedItem != null)
            {
                KorisnikEditProzor prozor = new KorisnikEditProzor((Korisnik)dgKorisnik.SelectedItem);
                prozor.Show();
            }
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            
            if(dgKorisnik.SelectedItem != null)
            {
                Korisnik.Delete((Korisnik)dgKorisnik.SelectedItem);
                view.Refresh();
            }
        }
    }
}

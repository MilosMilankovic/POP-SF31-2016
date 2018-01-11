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

            view = CollectionViewSource.GetDefaultView(Projekat.Instance.Korisnici);
            InitializeComponent();

            
            view.Filter = Filter;
            dgKorisnik.ItemsSource = view;


            if (Projekat.Instance.ulogovaniKorisnik.TipKorisnika == TipKorisnika.Prodavac)
            {
                btnDodaj.IsEnabled = false;
                btnIzmeni.IsEnabled = false;
                btnObrisi.IsEnabled = false;
            }

        }
        private bool Filter(object obj)
        {
            if (((Korisnik)obj).Obrisan == false) 
            {
                var text = ((ComboBoxItem)cbIzbor.SelectedItem).Content.ToString(); 
                if (text.Equals("Ime"))
                {
                    return ((Korisnik)obj).Ime.IndexOf(tbPretraga.Text, StringComparison.OrdinalIgnoreCase) >= 0;
                }
                else if (text.Equals("Prezime"))
                {
                    return ((Korisnik)obj).Prezime.IndexOf(tbPretraga.Text, StringComparison.OrdinalIgnoreCase) >= 0;
                }
                else if (text.Equals("Korisnicko ime"))
                {
                    return ((Korisnik)obj).KorisnickoIme.IndexOf(tbPretraga.Text, StringComparison.OrdinalIgnoreCase) >= 0;
                }
                return false;
            }
            return false;
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            KorisnikEditProzor prozor = new KorisnikEditProzor();
            prozor.ShowDialog();
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            if(dgKorisnik.SelectedItem != null)
            {
                KorisnikEditProzor prozor = new KorisnikEditProzor((Korisnik)dgKorisnik.SelectedItem);
                prozor.ShowDialog();
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

        private void tbPretraga_TextChanged(object sender, TextChangedEventArgs e)
        {
            view.Refresh();
        }

        private void cbIzbor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            view.Refresh();
        }
    }
}

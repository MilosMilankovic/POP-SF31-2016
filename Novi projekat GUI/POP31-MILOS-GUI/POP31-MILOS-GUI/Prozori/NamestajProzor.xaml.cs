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
    /// Interaction logic for NamestajProzor.xaml
    /// </summary>
    public partial class NamestajProzor : Window
    {

        ICollectionView view;
        public NamestajProzor()
        {
            view = CollectionViewSource.GetDefaultView(Projekat.Instance.Namestaj);
            InitializeComponent();
            
            view.Filter = Filter;
            dgNamestaj.ItemsSource = view;


            if (Projekat.Instance.ulogovaniKorisnik.TipKorisnika == TipKorisnika.Prodavac)
            {
                btnDodaj.IsEnabled = false;
                btnIzmeni.IsEnabled = false;
                btnObrisi.IsEnabled = false;
            }
        }
        private bool Filter(object obj)
        {
            if (((Namestaj)obj).Obrisan == false)
            {
                var text = ((ComboBoxItem)cbIzbor.SelectedItem).Content.ToString(); //uzimammo text iz cb
                if (text.Equals("Tip"))
                {
                    return ((Namestaj)obj).TipNamestaja.Naziv.IndexOf(tbPretraga.Text, StringComparison.OrdinalIgnoreCase) >= 0;
                }
                else if (text.Equals("Sifra"))
                {
                    return ((Namestaj)obj).Sifra.IndexOf(tbPretraga.Text, StringComparison.OrdinalIgnoreCase) >= 0;
                }
                else if (text.Equals("Naziv"))
                {
                    return ((Namestaj)obj).Naziv.IndexOf(tbPretraga.Text, StringComparison.OrdinalIgnoreCase) >= 0;
                }
                return false;
            }
            return false;
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            NamestajEditProzor prozor = new NamestajEditProzor();
            prozor.Show();
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            if (Projekat.Instance.ulogovaniKorisnik.TipKorisnika == TipKorisnika.Administrator)
            {

                if (dgNamestaj.SelectedItem != null)
                {
                    NamestajEditProzor prozor = new NamestajEditProzor((Namestaj)dgNamestaj.SelectedItem);
                    prozor.Show();
                    view.Refresh();
                }
            }
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            if(dgNamestaj.SelectedItem != null)
            {
                ((Namestaj)dgNamestaj.SelectedItem).Obrisan = true;
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

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
            InitializeComponent();
            view = CollectionViewSource.GetDefaultView(Projekat.Instance.Namestaj);
            view.Filter = HideDeletedFilter;
            dgNamestaj.ItemsSource = view;


            if (Projekat.Instance.ulogovaniKorisnik.TipKorisnika == TipKorisnika.Prodavac)
            {
                btnDodaj.IsEnabled = false;
                btnIzmeni.IsEnabled = false;
                btnObrisi.IsEnabled = false;
            }
        }
        private bool HideDeletedFilter(object obj)
        {
            return !((Namestaj)obj).Obrisan;   // nemoj prikazati ako je obrisan
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
    }
}

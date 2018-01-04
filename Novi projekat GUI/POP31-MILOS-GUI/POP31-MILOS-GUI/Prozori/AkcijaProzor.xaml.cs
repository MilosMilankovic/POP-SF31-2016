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
    /// Interaction logic for AkcijaProzor.xaml
    /// </summary>
    public partial class AkcijaProzor : Window
    {

        ICollectionView view;
        public AkcijaProzor()
        {
            InitializeComponent();

            view = CollectionViewSource.GetDefaultView(Projekat.Instance.Akcije);
            view.Filter = HideDeletedFilter;
            dgAkcija.ItemsSource = view;

            if(Projekat.Instance.ulogovaniKorisnik.TipKorisnika == TipKorisnika.Prodavac)
            {
                btnDodaj.IsEnabled = false;
                btnIzmeni.IsEnabled = false;
                btnObrisi.IsEnabled = false;
            }

        }
        private bool HideDeletedFilter(object obj)
        {
            return !((Akcija)obj).Obrisan;   // nemoj prikazati ako je obrisan
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            AkcijaEditProzor prozor = new AkcijaEditProzor();
            prozor.Show();
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            
            if(dgAkcija.SelectedItem != null)
            {
                AkcijaEditProzor prozor = new AkcijaEditProzor((Akcija)dgAkcija.SelectedItem);
                prozor.Show();
            }
            
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
           if(dgAkcija.SelectedItem != null)
            {
                ((Akcija)dgAkcija.SelectedItem).Obrisan = true;
                view.Refresh();
            }
        }
    }
}

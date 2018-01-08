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
            view = CollectionViewSource.GetDefaultView(Projekat.Instance.Akcije);
            InitializeComponent();


            view.Filter = Filter;
            dgAkcija.ItemsSource = view;

            if (Projekat.Instance.ulogovaniKorisnik.TipKorisnika == TipKorisnika.Prodavac)
            {
                btnDodaj.IsEnabled = false;
                btnIzmeni.IsEnabled = false;
                btnObrisi.IsEnabled = false;
            }

        }
        private bool Filter(object obj)
        {
            if (((Akcija)obj).Obrisan == false)
            {
                if (cbAkcija.IsChecked == true)
                {



                    if (((Akcija)obj).Pocetak > DateTime.Now || ((Akcija)obj).Kraj < DateTime.Now)
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            AkcijaEditProzor prozor = new AkcijaEditProzor();
            prozor.Show();
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {

            if (dgAkcija.SelectedItem != null)
            {
                AkcijaEditProzor prozor = new AkcijaEditProzor((Akcija)dgAkcija.SelectedItem);
                prozor.ShowDialog();
                view.Refresh();
            }
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (dgAkcija.SelectedItem != null)
            {
                Akcija.Delete((Akcija)dgAkcija.SelectedItem);
                view.Refresh();
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            view.Refresh();
        }
    }
}

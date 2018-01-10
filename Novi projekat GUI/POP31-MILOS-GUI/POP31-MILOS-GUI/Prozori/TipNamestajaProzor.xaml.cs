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
    /// Interaction logic for TipNamestajaProzor.xaml
    /// </summary>
    public partial class TipNamestajaProzor : Window
    {

        ICollectionView view;

        public TipNamestajaProzor()
        {
            InitializeComponent();

            view = CollectionViewSource.GetDefaultView(Projekat.Instance.TipNamestaja);
            view.Filter = HideDeletedFilter;
            dgTipNamestaja.ItemsSource = view;

            if (Projekat.Instance.ulogovaniKorisnik.TipKorisnika == TipKorisnika.Prodavac)
            {
                btnDodaj.IsEnabled = false;
                btnIzmeni.IsEnabled = false;
                btnObrisi.IsEnabled = false;
            }
        }

        private bool HideDeletedFilter(object obj)
        {
            return !((TipNamestaja)obj).Obrisan;   
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (dgTipNamestaja.SelectedItem != null)
            {
                
                TipNamestaja.Delete((TipNamestaja)dgTipNamestaja.SelectedItem);
                view.Refresh();
            }
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            TipNamestajaEditProzor widnowEdit = new TipNamestajaEditProzor();
            widnowEdit.Show();
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            if (dgTipNamestaja.SelectedItem != null)
            {
                TipNamestajaEditProzor widnowEdit = new TipNamestajaEditProzor((TipNamestaja)dgTipNamestaja.SelectedItem);
                widnowEdit.Show();
            }
            
        }
    }

}

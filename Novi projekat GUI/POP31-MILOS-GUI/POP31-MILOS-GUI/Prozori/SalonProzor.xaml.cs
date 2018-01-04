using POP_31.Model;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for SalonProzor.xaml
    /// </summary>
    public partial class SalonProzor : Window
    {

       
        public SalonProzor()
        {
            InitializeComponent();

            tbAdresa.DataContext = Projekat.Instance.Salon;
            tbAdresaSajta.DataContext = Projekat.Instance.Salon;
            tbMaticniBroj.DataContext = Projekat.Instance.Salon;
            tbNaziv.DataContext = Projekat.Instance.Salon;
            tbPIB.DataContext = Projekat.Instance.Salon;
            tbTelefon.DataContext = Projekat.Instance.Salon;
            tbZiroRacun.DataContext = Projekat.Instance.Salon;



            if (Projekat.Instance.ulogovaniKorisnik.TipKorisnika == TipKorisnika.Prodavac)
            {
                
                btnIzmeni.IsEnabled = false;
              
            }
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            SalonEditProzor prozor = new SalonEditProzor();
            prozor.Show();

        }
    }
}

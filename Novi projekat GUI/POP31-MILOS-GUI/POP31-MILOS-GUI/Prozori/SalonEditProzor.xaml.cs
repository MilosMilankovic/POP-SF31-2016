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
    /// Interaction logic for SalonEditProzor.xaml
    /// </summary>
    public partial class SalonEditProzor : Window
    {
        Salon salonCopy;
        public SalonEditProzor()
        {
            

            InitializeComponent();

            salonCopy = new Salon();

            salonCopy.Copy(Projekat.Instance.Salon);

            tbAdresa.DataContext = salonCopy;
            tbAdresaSajta.DataContext = salonCopy;
            tbMaticniBroj.DataContext = salonCopy;
            tbNaziv.DataContext = salonCopy;
            tbPIB.DataContext = salonCopy;
            tbTelefon.DataContext = salonCopy;
            tbZiroRacun.DataContext = salonCopy;

        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            Projekat.Instance.Salon.Copy(salonCopy);
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

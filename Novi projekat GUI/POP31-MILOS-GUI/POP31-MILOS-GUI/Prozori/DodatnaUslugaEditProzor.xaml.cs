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
    /// Interaction logic for DodatnaUslugaEditProzor.xaml
    /// </summary>
    public partial class DodatnaUslugaEditProzor : Window
    {

        private enum Operacija
        {
            IZMENA,
            DODAVANJE
        }

        private Operacija operacija;
        DodatnaUsluga dodatnaUslugaCopy;
        DodatnaUsluga dodatnaUslugaReal;

        public DodatnaUslugaEditProzor()
        {
            InitializeComponent();
            dodatnaUslugaCopy = new DodatnaUsluga("", 0);

            tbNaziv.DataContext = dodatnaUslugaCopy;
            tbCena.DataContext = dodatnaUslugaCopy;

            operacija = Operacija.DODAVANJE;
        }

        public DodatnaUslugaEditProzor(DodatnaUsluga dodatnaUsluga)
        {
            InitializeComponent();
            dodatnaUslugaCopy = new DodatnaUsluga();
            dodatnaUslugaCopy.Copy(dodatnaUsluga);

            dodatnaUslugaReal = dodatnaUsluga;
            tbNaziv.DataContext = dodatnaUslugaCopy;
            tbCena.DataContext = dodatnaUslugaCopy;

            operacija = Operacija.IZMENA;
        }
        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (operacija == Operacija.DODAVANJE)
            {
                Projekat.Instance.DodatneUsluge.Add(dodatnaUslugaCopy);
            }
            else if (operacija == Operacija.IZMENA)
            {
                dodatnaUslugaReal.Copy(dodatnaUslugaCopy);
            }
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

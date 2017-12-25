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
    /// Interaction logic for TipNamestajaEditProzor.xaml
    /// </summary>
    public partial class TipNamestajaEditProzor : Window
    {
        private enum Operacija
        {
            IZMENA,
            DODAVANJE
        }

        Operacija operacija;
        TipNamestaja tipNamestajaCopy;
        TipNamestaja tipNamestajaReal;
        public TipNamestajaEditProzor()
        {
            InitializeComponent();
            tipNamestajaCopy = new TipNamestaja("");
            tbNaziv.DataContext = tipNamestajaCopy;
            operacija = Operacija.DODAVANJE;
        }

        public TipNamestajaEditProzor(TipNamestaja tipNamestaja)
        {
            InitializeComponent();
            tipNamestajaCopy = new TipNamestaja();
            tipNamestajaCopy.Copy(tipNamestaja);
            tipNamestajaReal = tipNamestaja;
            tbNaziv.DataContext = tipNamestajaCopy;
            operacija = Operacija.IZMENA;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            
            
            if( operacija == Operacija.DODAVANJE)
            {
                Projekat.Instance.TipNamestaja.Add(tipNamestajaCopy);
            }
            if (operacija == Operacija.IZMENA)
            {
                tipNamestajaReal.Copy(tipNamestajaCopy);
            }
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

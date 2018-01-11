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
        TipNamestaja tipNamestaja;
        
        
        public TipNamestajaEditProzor()  
        {
            InitializeComponent();
            tipNamestaja = new TipNamestaja();
            tbNaziv.DataContext = tipNamestaja;
            operacija = Operacija.DODAVANJE;
        }

        public TipNamestajaEditProzor(TipNamestaja tipNamestaja) 
        {
            InitializeComponent();
            
            this.tipNamestaja = new TipNamestaja();
            this.tipNamestaja.Copy(tipNamestaja);

            //tbNaziv.DataContext = tipNamestajaCopy;
            tbNaziv.DataContext = this.tipNamestaja;
            operacija = Operacija.IZMENA;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (tbNaziv.Text !="")
            {


                if (operacija == Operacija.DODAVANJE)
                {
                    TipNamestaja.Create(tipNamestaja);
                }
                else if (operacija == Operacija.IZMENA)
                {
                    TipNamestaja.Update(tipNamestaja);
                   
                }
                Close();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

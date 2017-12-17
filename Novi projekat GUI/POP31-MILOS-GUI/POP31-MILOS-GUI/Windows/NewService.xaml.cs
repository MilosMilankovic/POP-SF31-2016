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

namespace POP31_MILOS_GUI.Windows
{
    /// <summary>
    /// Interaction logic for NewService.xaml
    /// </summary>
    public partial class NewService : Window
    {
        
        public NewService()
        {
            InitializeComponent();
        }

        private void Finish(object sender, RoutedEventArgs e)
        {
            string naziv = tbName.Text;
            double cena = Convert.ToDouble(tbCena.Text);
            DodatnaUsluga d = new DodatnaUsluga();
            d.Naziv = naziv;
            d.Cena = cena;
            d.Id = TicketWindow.usluge.Count + 1;
            TicketWindow.usluge.Insert(0, d);
            this.Close();
        }
    }
}

using POP_31.Model;
using POP_31.Util;
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
    /// Interaction logic for NewType.xaml
    /// </summary>
    public partial class NewType : Window
    {
        public NewType()
        {
            InitializeComponent();
        }

        private void Finish(object sender, RoutedEventArgs e)
        {
            string ime = tb1.Text.ToString();
            TipNamestaja tip = new TipNamestaja();
            tip.naziv = ime;
            tip.Id = MainWindow.tipNamLista.Count + 1;
            MainWindow.tipNamLista.Add(tip);
            GenericSerializer.Serialize<TipNamestaja>("tipoviNamestaja.xml", MainWindow.tipNamLista);
            this.Close();
        }
    }
}

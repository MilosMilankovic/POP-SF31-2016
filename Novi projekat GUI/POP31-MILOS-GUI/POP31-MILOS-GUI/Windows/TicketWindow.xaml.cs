using POP_31.Model;
using POP_31.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for TicketWindow.xaml
    /// </summary>
    public partial class TicketWindow : Window
    {
        public static ObservableCollection<DodatnaUsluga> usluge;
        private Namestaj nam;
        public TicketWindow()
        {
            InitializeComponent();
            usluge = new ObservableCollection<DodatnaUsluga>();
        }

        public TicketWindow(Namestaj n)
        {
            nam = n;
            InitializeComponent();
            usluge = new ObservableCollection<DodatnaUsluga>();
            DodatnaUsluga d1 = new DodatnaUsluga();
            d1.Naziv = "Prevoz";
            d1.Cena = 3000;

            DodatnaUsluga d2 = new DodatnaUsluga();
            d2.Naziv = "Montaza";
            d2.Cena = 5000;

            DodatnaUsluga d3 = new DodatnaUsluga();
            d3.Naziv = "Nova usluga...";
            d3.Cena = 0;


            usluge.Add(d1);
            usluge.Add(d2);
            usluge.Add(d3);
            comboBoxDU.ItemsSource = usluge;

            DataContext = n; 
        }

        private void Finish(object sender, RoutedEventArgs e)
        {
            double ukupnaCena = 0;
                DodatnaUsluga d = comboBoxDU.SelectedItem as DodatnaUsluga;
            if (comboBoxDU.SelectedItem != null)
            {
                if (d.Naziv == "Nova usluga...")
                {
                    NewService ns = new NewService();
                    ns.ShowDialog();
                    ukupnaCena = nam.JedinicnaCena + usluge[0].Cena;
                }
                else
                {
                    ukupnaCena = nam.JedinicnaCena + d.Cena;
                }
            }
            else
            {
                ukupnaCena = nam.JedinicnaCena;
            }
                if (MessageBox.Show($"Ukupan racun iznosi {ukupnaCena},da li zelite da kupite?", "Racun", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    MessageBox.Show("Uspesno obavljena kupovina");
                    foreach(Namestaj a in MainWindow.lista)
                    {
                        if(a.Id==nam.Id)
                        {
                            a.KolicinaUmagacinu--;
                        break;
                        }
                    }
                this.Close();

                }
            this.Close();
            
        }
    }
}

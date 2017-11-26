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
    /// Interaction logic for LogInWindow.xaml
    /// </summary>
    public partial class LogInWindow : Window
    {
        public static ObservableCollection<Korisnik> korisnici;
        public LogInWindow()
        {
            korisnici = new ObservableCollection<Korisnik>();
            korisnici = GenericSerializer.Deserialize<Korisnik>("korisnici.xml");
            InitializeComponent();
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            string user = userTB.Text;
            string pass = passTB.Text;
            bool nadjen = false;
            foreach(Korisnik k in korisnici)
            {
                if(k.KorisnickoIme==user && k.Lozinka==pass)
                {
                    nadjen = true;
                    break;
                }
            }

            if(nadjen==true)
            {
                MainWindow win = new MainWindow();
                this.Close();
                win.ShowDialog();
                
            }
            else
            {
                MessageBox.Show("Dati korisnik ne postoji u bazi podataka!");
            }

        }

        
    }
}

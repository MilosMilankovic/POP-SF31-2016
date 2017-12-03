using POP_31.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_31.Model
{
    public class Projekat
    {
        public static Projekat Instance { get; private set; } = new Projekat();

        public ObservableCollection<Namestaj> Namestaj;
        public Projekat()
        {
            Namestaj = new ObservableCollection<Namestaj>(GenericSerializer.Deserialize<Namestaj>("Namestaj.xml"));
        }
    }
}

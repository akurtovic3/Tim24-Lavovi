using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatRentACar.Models
{
    public class ListaVozilaProba
    {
        public string Marka { get; set; }
        public string Model { get; set; }
        public string Tip { get; set; }
        public string Cijena { get; set; }
        public string SlikaPath { get; set; }

        public ListaVozilaProba(string marka, string model, string tip, string cijena, string slikapath)
        {
            Marka = marka;
            Model = model;
            Tip = tip;
            Cijena = cijena;
            SlikaPath = slikapath;
        }

    }
}

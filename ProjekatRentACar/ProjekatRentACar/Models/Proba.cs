using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatRentACar.Models
{
    public class Proba
    {
        public string Naziv { get; set; }
        public string OdDatum { get; set; }
        public string DoDatum { get; set; }
        public string SlikaPath { get; set; }

        public Proba(string naziv, string odDatum, string doDatum, string slikaPath)
        {
            Naziv = naziv;
            OdDatum = odDatum;
            DoDatum = doDatum;
            SlikaPath = slikaPath;
        }
    }
}

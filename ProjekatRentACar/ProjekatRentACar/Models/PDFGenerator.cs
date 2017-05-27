using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace ProjekatRentACar.Models
{
    public class PDFGenerator
    {
        private DateTime datumKreiranja;
        private List<Vozilo> vozila;

        public DateTime DatumKreiranja
        {
            get
            {
                return datumKreiranja;
            }

            set
            {
                datumKreiranja = value;
            }
        }

        public List<Vozilo> Vozila
        {
            get
            {
                return vozila;
            }

            set
            {
                vozila = value;
            }
        }

        public PDFGenerator(DateTime datum_kreiranja)
        {
            DatumKreiranja = datum_kreiranja;
            Vozila = new List<Vozilo>();
        }
        public void generisiIzvjestaj() {
           
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatRentACar.Models
{
    public class Oprema
    {
        private string naziv;
        private float cijenaPoDanu;
        private string kategorija;
        private int maxOpseg;

        public Oprema(string naziv, float cijenaPoDanu, string kategorija, int maxOpseg)
        {
            this.naziv = naziv;
            this.cijenaPoDanu = cijenaPoDanu;
            this.kategorija = kategorija;
            this.maxOpseg = maxOpseg;
        }

        public string Naziv
        {
            get
            {
                return naziv;
            }

            set
            {
                naziv = value;
            }
        }

        public float CijenaPoDanu
        {
            get
            {
                return cijenaPoDanu;
            }

            set
            {
                cijenaPoDanu = value;
            }
        }

        public string Kategorija
        {
            get
            {
                return kategorija;
            }

            set
            {
                kategorija = value;
            }
        }

        public int MaxOpseg
        {
            get
            {
                return maxOpseg;
            }

            set
            {
                maxOpseg = value;
            }
        }
    }
}

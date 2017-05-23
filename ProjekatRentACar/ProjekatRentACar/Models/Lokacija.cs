using Prism.Windows.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatRentACar.Models
{
    public class Lokacija : ValidatableBindableBase
    {
        private string naziv;
        [Required(ErrorMessage = "Morate unijeti lokaciju")]
        public string Naziv
        {
            get { return naziv; }
            set { naziv = value; }
        }

        private float sirina;

        public float Sirina
        {
            get { return sirina; }
            set { sirina = value; }
        }

        private float duzina;

        public float Duzina
        {
            get { return duzina; }
            set { duzina = value; }
        }

        private string adresa;

        public string Adresa
        {
            get { return adresa; }
            set { adresa = value; }
        }

        private string opis;

        public string Opis
        {
            get { return opis; }
            set { opis = value; }
        }


    }
}

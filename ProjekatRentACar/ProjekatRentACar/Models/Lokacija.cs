using Prism.Windows.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace ProjekatRentACar.Models
{
    public class Lokacija 
    {
        private string naziv;
        public string Naziv
        {
            get { return naziv; }
            set { naziv = value; }
        }

        private Geopoint lokacija;
        public Geopoint LokacijaMjesta
        {
            get { return lokacija; }
            set { lokacija = value; }
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

        public Lokacija(string naziv, Geopoint lokacija, string adresa, string opis)
        {
            this.Naziv = naziv;
            this.LokacijaMjesta = lokacija;
            this.Adresa = adresa;
            this.Opis = opis;
        }

        public Lokacija()
        {
            
        }
    }
}

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

        private int id;
        public double Sirina { get; set; }
        public double Duzina { get; set; }




    
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

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public Lokacija(int id,string naziv, double duzina, double sirina, string adresa, string opis)
         {
            Id = id;
             this.Naziv = naziv;
             this.LokacijaMjesta = lokacija;
             this.Adresa = adresa;
             this.Opis = opis;
            this.Duzina = duzina;
            this.Sirina = sirina;
            this.LokacijaMjesta = new Geopoint(new BasicGeoposition() { Longitude = duzina, Latitude=sirina});
         }
         

        public Lokacija()
        {
            this.LokacijaMjesta = new Geopoint(new BasicGeoposition() { Longitude = Duzina, Latitude = Sirina });

        }
    }
}

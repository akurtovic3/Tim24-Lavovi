using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace ProjekatRentACar.Models
{
   public  enum Medalje { Zlato, Srebro, Bronza };
    public class Korisnik:Osoba
    {
        public Korisnik()
        {

        }
        private Medalje rejting { get; set; }
        private List<Najam> najmovi;

        private int id;
        public Medalje Rejting
        {
            get { return rejting; }
            set { rejting = value; }
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

        public List<Najam> Najmovi
        {
            get
            {
                return najmovi;
            }

            set
            {
                najmovi = value;
            }
        }

        public Korisnik(string ime, string prezime, DateTime datum_rodjenja, string telefon, string email, string adresa,
             Medalje r,int i) : base(ime, prezime, datum_rodjenja, telefon, email, adresa)
        {
            Rejting = r;
            Id=i;
            Najmovi = new List<Najam>();
            
        }
        public void iznajmiVozilo(Najam n)
        {
            Najmovi.Add(n);
           
        }
    }
}

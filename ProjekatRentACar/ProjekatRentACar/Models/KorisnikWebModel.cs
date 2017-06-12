using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatRentACar.Models
{
    public class KorisnikWebModel
    {
        public KorisnikWebModel(int id, string ime, string prezime, string datum_rodjenja, string telefon, string email, string drzava, string adresa, string datum_zaposlenja, string rating, string role)
        {
            this.id = id;
            this.ime = ime;
            this.prezime = prezime;
            this.datum_rodjenja = datum_rodjenja;
            this.telefon = telefon;
            this.email = email;
            this.drzava = drzava;
            this.adresa = adresa;
            this.datum_zaposlenja = datum_zaposlenja;
            this.rating = rating;
            this.role = role;
        }

        public int id { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public string datum_rodjenja { get; set; }
        public string telefon { get; set; }
        public string email { get; set; }
        public string drzava { get; set; }
        public string adresa { get; set; }
        public string datum_zaposlenja { get; set; }
        public string rating { get; set; }
        public string role { get; set; }
    }
}

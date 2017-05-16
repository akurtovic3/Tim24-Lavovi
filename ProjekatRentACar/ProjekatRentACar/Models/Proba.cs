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
        public string ImeKorisnika { get; set; }
        public string LokacijaVracanja { get; set; }
        public string LokacijaPreuzimanja { get; set; }

        public string Ime { get; set; }
        public string DatumRodjenja { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Drzava { get; set; }
        public string Ulica { get; set; }
        public string PostanskiBroj { get; set; }
        public string Uposlenik { get; set; }


        public Proba(string naziv, string odDatum, string doDatum, string slikaPath)
        {
            Naziv = naziv;
            OdDatum = odDatum;
            DoDatum = doDatum;
            SlikaPath = slikaPath;
        }

        public Proba(string naziv, string odDatum, string doDatum, string slikaPath, string imeKorisnika, string lokacijaVracanja, string lokacijaPreuzimanja)
        {
            Naziv = naziv;
            OdDatum = odDatum;
            DoDatum = doDatum;
            SlikaPath = slikaPath;
            ImeKorisnika = imeKorisnika;
            LokacijaVracanja = lokacijaVracanja;
            LokacijaPreuzimanja = lokacijaPreuzimanja;
        }

        public Proba(string slikaPath, string ime, string datumRodjenja, string telefon, string email, string drzava, string ulica, string postanskiBroj, string uposlenik)
        {
            Ime = ime;
            DatumRodjenja = datumRodjenja;
            Telefon = telefon;
            Email = email;
            Drzava = drzava;
            Ulica = ulica;
            PostanskiBroj = postanskiBroj;
            Uposlenik = uposlenik;
            SlikaPath = slikaPath;
        }
    }
}

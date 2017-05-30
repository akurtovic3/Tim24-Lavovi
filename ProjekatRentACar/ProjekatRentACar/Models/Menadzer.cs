using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;


namespace ProjekatRentACar.Models
{
    public class Menadzer:Osoba
    {

        public Menadzer()
        {

        }
        private DateTime datumZaposlenja { get; set; }
        private List<Korisnik> korisnici;
        private List<Uposlenik> uposlenici;
        private PDFGenerator generator;
        public DateTime DatumZaposlenja
        {
            get { return datumZaposlenja; }
            set { datumZaposlenja = value; }
        }

        public List<Korisnik> Korisnici
        {
            get
            {
                return korisnici;
            }

            set
            {
                korisnici = value;
            }
        }

        public List<Uposlenik> Uposlenici
        {
            get
            {
                return uposlenici;
            }

            set
            {
                uposlenici = value;
            }
        }

        public PDFGenerator Generator
        {
            get
            {
                return generator;
            }

            set
            {
                generator = value;
            }
        }
        /*
        public Menadzer(string ime, string prezime, DateTime datum_rodjenja, string telefon, string email, string adresa,
           int postanski_broj, string korisnicko_ime, string sifra, Image slika, DateTime datum_zaposlenja) : base(ime, prezime, datum_rodjenja, telefon, email, adresa, postanski_broj, korisnicko_ime, sifra, slika)
        {
            
            datumZaposlenja = datum_zaposlenja;
            Korisnici = new List<Korisnik>();
            Uposlenici = new List<Uposlenik>();
        }
        public void dodajUposlenika(Uposlenik u)
        {
            Uposlenici.Add(u);
        }
        public void izbrisiUposlenika(int i)
        {
            if (i > Uposlenici.Count)
                return;
            Uposlenici.RemoveAt(i);
        }
        public void azurirajUposlenika(int i, string ime, string prezime, DateTime datum_rodjenja, string telefon, string email, string adresa,
           int postanski_broj, string korisnicko_ime, string sifra, Image slika, DateTime datum_zaposlenja, float plata)
        {
            Uposlenici[i] = new Uposlenik(ime, prezime, datum_rodjenja, telefon, email, adresa, postanski_broj, korisnicko_ime, sifra, slika, datum_zaposlenja, plata);
        }
        */
    }
}

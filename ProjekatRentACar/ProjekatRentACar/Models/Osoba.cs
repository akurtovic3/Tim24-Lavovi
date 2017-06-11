using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace ProjekatRentACar.Models
{
    abstract public class Osoba
    {
        public Osoba()
        {

        }

        private string ime { get; set; }
        private string prezime { get; set; }
        private DateTime datumRodjenja { get; set; }
        private string telefon { get; set; }
        private string email { get; set; }
        private string adresa { get; set; }
        private string korisnickoIme { get; set; } 
        private string sifra { get; set; }
        private Image slika { get; set; }

        public string Ime
        {
            get { return ime; }
            set { ime = value; }
        }

        public string Prezime
        {
            get { return prezime; }
            set { prezime = value; }
        }

        public DateTime DatumRodjenja
        {
            get { return datumRodjenja; }
            set { DatumRodjenja = value; }
        }

        public string Telefon
        {
            get { return telefon; }
            set { telefon = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Adresa
        {
            get { return adresa; }
            set { adresa = value; }
        }

       

        public string KorisnickoIme
        {
            get { return korisnickoIme; }
            set { korisnickoIme = value; }
        }

        public string Sifra
        {
            get { return sifra; }
            set { sifra = value; }
        }

        public Image Slika
        {
            get { return slika; }
            set { slika = value; }
        }

        public Osoba(string ime, string prezime, DateTime datum_rodjenja, string telefon, string email, string adresa
            )
        {
            Ime = ime;
            Prezime = prezime;
            datumRodjenja = datum_rodjenja;
            Telefon = telefon;
            Email = email;
            Adresa = adresa;
            
        }
    }
}

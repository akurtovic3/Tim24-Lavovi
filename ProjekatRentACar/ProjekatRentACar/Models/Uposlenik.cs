using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace ProjekatRentACar.Models
{
    public class Uposlenik : Osoba
    {
        private DateTime datumZaposlenja { get; set; }
        private float plata { get; set; }
        private List<Oprema> oprema;
        private List<Vozilo> vozila;
        private PDFGenerator generator;
        public DateTime DatumZaposlenja
        {
            get { return datumZaposlenja; }
            set { datumZaposlenja = value; }
        }

        public float  Plata
        {
            get { return plata; }
            set { plata = value; }
        }

        public List<Oprema> Oprema
        {
            get
            {
                return oprema;
            }

            set
            {
                oprema = value;
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

        public Uposlenik(string ime, string prezime, DateTime datum_rodjenja, string telefon, string email, string adresa,
           int postanski_broj, string korisnicko_ime, string sifra, Image slika,DateTime datum_zaposlenja,float plata) : base(ime, prezime, datum_rodjenja, telefon, email, adresa, postanski_broj, korisnicko_ime, sifra, slika)
        {
            Plata = plata;
            datumZaposlenja = datum_zaposlenja;
            Oprema = new List<Oprema>();
            Vozila = new List<Vozilo>();
        }
        public void dodajVozilo(Vozilo v)
        {
            Vozila.Add(v);

        }
        public void izbrisiVozilo(int i)
        {
            if (i > Vozila.Count)
                return;
            Vozila.RemoveAt(i);
        }
        public void azurirajVozilo(int i, TipVozila tip, string proizvodjac, string model, int snaga, VrstaGoriva vrstaGoriva, float kilometraza, int brojSjedista, int brojVrata, Mjenjac vrstaMjenjaca, float kubikaza, int godiste, bool klima, int zapreminaPrtljaznika, bool navigacija, float cijenaPoDanu, int popust)
        {
            Vozila[i] = new Vozilo(tip, proizvodjac, model, snaga, vrstaGoriva, kilometraza, brojSjedista, brojVrata, vrstaMjenjaca, kubikaza, godiste, klima, zapreminaPrtljaznika, navigacija, cijenaPoDanu, popust);
        }
        public void dodajOpremu(Oprema o)
        {
            Oprema.Add(o);
        }
        public void izbrisiOpremu(int i)
        {
            if (i > Oprema.Count)
                return;
            Oprema.RemoveAt(i);

        }
        public void azurirajOpremu(int i, string naziv, float cijenaPoDanu, string kategorija, int maxOpseg)
        {
            Oprema[i] = new Oprema(naziv, cijenaPoDanu, kategorija, maxOpseg);
        }
    }
}

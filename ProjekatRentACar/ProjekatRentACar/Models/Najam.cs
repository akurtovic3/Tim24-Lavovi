using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatRentACar.Models
{
    public class Najam
    {
        private int id;
        private DateTime pocetniDatum;
        private DateTime krajniDatum;
        private double cijena;
        private Lokacija mjestoPreuzimanja;
        private Lokacija mjestoVracanja;
        private List<Oprema> oprema;
        private Vozilo vozilo;
        public Najam(int id, DateTime pocetniDatum, DateTime krajniDatum, double cijena, Lokacija mjestoPreuzimanja, Lokacija mjestoVracanja)
        {
            this.id = id;
            this.pocetniDatum = pocetniDatum;
            this.krajniDatum = krajniDatum;
            this.cijena = cijena;
            this.mjestoPreuzimanja = mjestoPreuzimanja;
            this.mjestoVracanja = mjestoVracanja;
            Oprema = new List<Oprema>();
        }

        public Najam()
        {

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

        public DateTime PocetniDatum
        {
            get
            {
                return pocetniDatum;
            }

            set
            {
                pocetniDatum = value;
            }
        }

        public DateTime KrajniDatum
        {
            get
            {
                return krajniDatum;
            }

            set
            {
                krajniDatum = value;
            }
        }

        public double Cijena
        {
            get
            {
                return cijena;
            }

            set
            {
                cijena = value;
            }
        }

        public Lokacija MjestoPreuzimanja
        {
            get
            {
                return mjestoPreuzimanja;
            }

            set
            {
                mjestoPreuzimanja = value;
            }
        }

        public Lokacija MjestoVracanja
        {
            get
            {
                return mjestoVracanja;
            }

            set
            {
                mjestoVracanja = value;
            }
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

        public Vozilo Vozilo
        {
            get
            {
                return vozilo;
            }

            set
            {
                vozilo = value;
            }
        }
    }
}

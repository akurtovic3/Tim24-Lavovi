﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatRentACar.Models
{
    public enum TipVozila { Kompakt, Limuzina, Terenac,Karavan,Kupe,Kombi };
    public enum VrstaGoriva { Benzin, Dizel, Plin, Hibrid };
    public enum Mjenjac { Automatski, Manuelni };
    public class Vozilo
    {
        private TipVozila tip;
        private string proizvodjac;
        private string model;
        private int snaga;
        private VrstaGoriva vrstaGoriva;
        private float kilometraza;
        private int brojSjedista;
        private int brojVrata;
        private Mjenjac vrstaMjenjaca;
        private float kubikaza;
        private int godiste;
        private Boolean klima;
        private int zapreminaPrtljaznika;
        private Boolean navigacija;
        private float cijenaPoDanu;
        private int popust;

        public Vozilo(TipVozila tip, string proizvodjac, string model, int snaga, VrstaGoriva vrstaGoriva, float kilometraza, int brojSjedista, int brojVrata, Mjenjac vrstaMjenjaca, float kubikaza, int godiste, bool klima, int zapreminaPrtljaznika, bool navigacija, float cijenaPoDanu, int popust)
        {
            this.tip = tip;
            this.proizvodjac = proizvodjac;
            Model = model;
            this.snaga = snaga;
            this.vrstaGoriva = vrstaGoriva;
            this.kilometraza = kilometraza;
            this.brojSjedista = brojSjedista;
            this.brojVrata = brojVrata;
            this.vrstaMjenjaca = vrstaMjenjaca;
            this.kubikaza = kubikaza;
            this.godiste = godiste;
            this.klima = klima;
            this.zapreminaPrtljaznika = zapreminaPrtljaznika;
            this.navigacija = navigacija;
            this.cijenaPoDanu = cijenaPoDanu;
            this.popust = popust;
        }

        public TipVozila Tip
        {
            get
            {
                return tip;
            }

            set
            {
                tip = value;
            }
        }

        public string Proizvodjac
        {
            get
            {
                return proizvodjac;
            }

            set
            {
                proizvodjac = value;
            }
        }

        public string Model
        {
            get
            {
                return Model;
            }

            set
            {
                Model = value;
            }
        }

        public int Snaga
        {
            get
            {
                return snaga;
            }

            set
            {
                snaga = value;
            }
        }

        public VrstaGoriva VrstaGoriva
        {
            get
            {
                return vrstaGoriva;
            }

            set
            {
                vrstaGoriva = value;
            }
        }

        public float Kilometraza
        {
            get
            {
                return kilometraza;
            }

            set
            {
                kilometraza = value;
            }
        }

        public int BrojSjedista
        {
            get
            {
                return brojSjedista;
            }

            set
            {
                brojSjedista = value;
            }
        }

        public int BrojVrata
        {
            get
            {
                return brojVrata;
            }

            set
            {
                brojVrata = value;
            }
        }

        public Mjenjac VrstaMjenjaca
        {
            get
            {
                return vrstaMjenjaca;
            }

            set
            {
                vrstaMjenjaca = value;
            }
        }

        public float Kubikaza
        {
            get
            {
                return kubikaza;
            }

            set
            {
                kubikaza = value;
            }
        }

        public int Godiste
        {
            get
            {
                return godiste;
            }

            set
            {
                godiste = value;
            }
        }

        public bool Klima
        {
            get
            {
                return klima;
            }

            set
            {
                klima = value;
            }
        }

        public int ZapreminaPrtljaznika
        {
            get
            {
                return zapreminaPrtljaznika;
            }

            set
            {
                zapreminaPrtljaznika = value;
            }
        }

        public bool Navigacija
        {
            get
            {
                return navigacija;
            }

            set
            {
                navigacija = value;
            }
        }

        public float CijenaPoDanu
        {
            get
            {
                return cijenaPoDanu;
            }

            set
            {
                cijenaPoDanu = value;
            }
        }

        public int Popust
        {
            get
            {
                return popust;
            }

            set
            {
                popust = value;
            }
        }
    }
}

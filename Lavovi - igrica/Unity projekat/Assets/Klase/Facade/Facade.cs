using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Klase
{
    public class Facade
    {
        private Vrijeme vrijeme;
        private Pozicija pozicija;

        public Facade()
        {
            vrijeme = new Vrijeme();
            pozicija = new Pozicija();
        }

        public void ispisiVrijemeIPoziciju()
        {
            vrijeme.ispisiVrijeme();
            pozicija.ispisiPoziciju();
        }
    }
}

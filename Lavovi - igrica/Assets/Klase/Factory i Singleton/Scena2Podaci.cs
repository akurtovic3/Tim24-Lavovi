using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Klase
{
    public class Scena2Podaci : Podaci
    {
        private static Scena2Podaci instance;

        private Scena2Podaci()
        {
            Ime = "Game screen";
            Godina = "2017";
        }

        public static Scena2Podaci Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Scena2Podaci();
                }
                return instance;
            }
        }
    }
}

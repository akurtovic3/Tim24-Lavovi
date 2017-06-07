using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Klase
{
    public class Scena1Podaci : Podaci
    {

        private static Scena1Podaci instance;

        private Scena1Podaci()
        {
            Ime = "Početni screen";
            Godina = "2017";
        }

        public static Scena1Podaci Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Scena1Podaci();
                }
                return instance;
            }
        }
    }
}

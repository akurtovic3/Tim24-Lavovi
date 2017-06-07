using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Klase
{
    public class FactoryClass
    {
        public Podaci getPodatak(string imeScene)
        {
            
            if(imeScene == "Scena1")
            {
                return Scena1Podaci.Instance;
            }else if(imeScene == "Scena2")
            {
                return Scena2Podaci.Instance;
            }
            return null;
        }
    }
}

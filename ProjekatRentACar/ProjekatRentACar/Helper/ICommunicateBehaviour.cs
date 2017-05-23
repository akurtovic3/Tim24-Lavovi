using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Contacts;

namespace ProjekatRentACar.Helper
{
    public interface ICommunicateBehaviour
    {
        //glavno ponasanje koje obavi komunikaciju sa kontaktom
        //void Communicate(Contact kontakt);
        void Communicate(string kontaktBroj);
        //vraca koji je trenutni behaviour naziv njegov za UI
    }
}

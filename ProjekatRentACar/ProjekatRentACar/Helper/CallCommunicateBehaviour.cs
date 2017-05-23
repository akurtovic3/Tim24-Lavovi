using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Contacts;
using Windows.ApplicationModel.Calls;
using Windows.Foundation.Metadata;

namespace ProjekatRentACar.Helper
{

    public class CallCommunicateBehaviour : ICommunicateBehaviour
    {
        public void Communicate(string kontaktBroj)
        {
            //izvuci broj korisnika iz kontakta
            //string telBroj = kontakt.Phones.FirstOrDefault<ContactPhone>().Number;
            //potrebno je prvo dodati referencu u projekat Windows Mobile Extensions for the UWP
            if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.ApplicationModel.Calls.PhoneCallManager"))
                //pozvati ui koji preuzima poziv
                Windows.ApplicationModel.Calls.PhoneCallManager.ShowPhoneCallUI(kontaktBroj, " ");
        }    }
}

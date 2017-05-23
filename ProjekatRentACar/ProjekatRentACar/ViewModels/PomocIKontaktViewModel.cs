using ProjekatRentACar.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Storage;

namespace ProjekatRentACar.ViewModels
{
    class PomocIKontaktViewModel
    {
        public ICommand Rezervacije { get; set; }
        public ICommand BrigaOKorisnicima { get; set; }
        public ICommand TehnickaPodrska { get; set; }
        public ICommand Broj { get; set; }
        public string telbroj { get; set; }


        public PomocIKontaktViewModel()
        {
            Rezervacije = new RelayCommand<object>(prebaciNaMail, moguLiSePrikazatiRezervacije);
            BrigaOKorisnicima = new RelayCommand<object>(prebaciNaMail);
            TehnickaPodrska = new RelayCommand<object>(prebaciNaMail);
            Broj = new RelayCommand<object>(pozoviBroj);
            telbroj = "+387 62 859 491";
        }

        private void prebaciNaMail(object parametar)
        {
            ComposeEmail("sterovic1@etf.unsa.ba").GetAwaiter();
        }
        public bool moguLiSePrikazatiRezervacije(object parametar)
        {
            return true;
        }

        private async Task ComposeEmail(string primaoc)
        {
            var emailMessage = new Windows.ApplicationModel.Email.EmailMessage();
            
            var emailRecipient = new Windows.ApplicationModel.Email.EmailRecipient(primaoc);
            emailMessage.To.Add(emailRecipient);
           
            await Windows.ApplicationModel.Email.EmailManager.ShowComposeNewEmailAsync(emailMessage);
        }

        void pozoviBroj(object parametar)
        {
            CallCommunicateBehaviour c = new CallCommunicateBehaviour();
            c.Communicate(telbroj);
        }
    }
}

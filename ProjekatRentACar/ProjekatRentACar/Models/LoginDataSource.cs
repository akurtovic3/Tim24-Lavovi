using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;

namespace ProjekatRentACar.Models
{

    public class LoginDataSource
    {
        
        public bool isError = false;
        public string ErrorText = "";

        public async Task prijaviKorisnika(string email, string sifra, Action callback)
        {
            HttpClient httpClient = new HttpClient();
            string urlString = "http://www.lavovi.space/api/login.php";
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("email", email),
                new KeyValuePair<string, string>("sifra", sifra)
            });
            var result = await httpClient.PostAsync(new Uri(urlString), content);
            string response = await result.Content.ReadAsStringAsync();
            Debug.WriteLine(response);
            JsonObject value = JsonObject.Parse(response).GetObject();
            
                IJsonValue jsonValue;
                if (value.TryGetValue("error", out jsonValue))
                {
                    isError = jsonValue.GetBoolean();
                }
                if(isError == true)
                {
                    if (value.TryGetValue("error_msg", out jsonValue))
                    {
                        ErrorText = jsonValue.GetString();
                    }
                    callback();
            }else
            {
                
                if (value.TryGetValue("role", out jsonValue))
                {
                    ErrorText = jsonValue.GetString();
                }
               
                //---------------------
                callback();

            }
        }
    }
}

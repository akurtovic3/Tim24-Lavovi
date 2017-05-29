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
    public class RegistracijaDataSource
    {

        public bool isError = false;
        public string ErrorText = "";

        public async Task registrujKorisnika(string ime, string prezime,
            string datum_rodjenja, string kontakt_broj,string email,string drzava,
            string adresa,string sifra, Action callback)
        {
            HttpClient httpClient = new HttpClient();
            string urlString = "http://www.lavovi.space/api/registracija.php";
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("ime", ime),
                new KeyValuePair<string, string>("prezime", prezime),
                new KeyValuePair<string, string>("datum_rodjenja", datum_rodjenja),
                new KeyValuePair<string, string>("kontakt_broj", kontakt_broj),
                new KeyValuePair<string, string>("email", email),
                new KeyValuePair<string, string>("drzava", drzava),
                new KeyValuePair<string, string>("adresa", adresa),
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
            if (isError == true)
            {
                if (value.TryGetValue("error_msg", out jsonValue))
                {
                    ErrorText = jsonValue.GetString();
                }
                callback();
            }
            else
            {
                //---------------------
                callback();

            }
        }
    }
}

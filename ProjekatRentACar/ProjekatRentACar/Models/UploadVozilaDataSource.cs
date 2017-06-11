using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

namespace ProjekatRentACar.Models
{
    public class UploadVozilaDataSource
    {


        public bool isError = false;
        public string ErrorText = "";


        

        public async Task unesiVozilo(Vozilo vozilo, byte[] slika, Action callback)
        {
            HttpClient httpClient = new HttpClient();
            string urlString = "http://www.lavovi.space/api/upload_vozila.php";
            MultipartFormDataContent form = new MultipartFormDataContent();
            form.Add(new ByteArrayContent(slika, 0, slika.Count()), "fileToUpload", "logo.png");
            form.Add(new StringContent("2"), "tip");
            form.Add(new StringContent("Pr"), "proizvodjac");
            form.Add(new StringContent("Mr"), "model");
            form.Add(new StringContent("222"), "snaga");
            form.Add(new StringContent("1"), "vrsta_goriva");
            form.Add(new StringContent("1"), "kilometraza");
            form.Add(new StringContent("1"), "broj_sjedista");
            form.Add(new StringContent("1"), "broj_vrata");
            form.Add(new StringContent("1"), "vrsta_mjenjaca");
            form.Add(new StringContent("1"), "kubikaza");
            form.Add(new StringContent("1"), "godiste");
            form.Add(new StringContent("1"), "klima");
            form.Add(new StringContent("1"), "zapremina_prtljaznika");
            form.Add(new StringContent("1"), "navigacija");
            form.Add(new StringContent("1"), "cijena_po_danu");
            form.Add(new StringContent("1"), "popust");

            var result = await httpClient.PostAsync(new Uri(urlString), form);
            string response = await result.Content.ReadAsStringAsync();
            Debug.WriteLine(response);
            JsonObject value = JsonObject.Parse(response).GetObject();


            IJsonValue jsonValue;
            if (value.TryGetValue("error", out jsonValue))
            {
                isError = jsonValue.GetBoolean();
            }
            if (value.TryGetValue("error_msg", out jsonValue))
            {
                ErrorText = jsonValue.GetString();
            }
            callback();
        }
    }
}

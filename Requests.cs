using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BancoConsole
{
    public class Requests
    {
        static HttpClient client = new HttpClient();
        public static async Task<T> Get<T>(string url)
        {
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(res);
            }
            else
            {
                return JsonConvert.DeserializeObject<T>(null);
            }
        }

        public static async Task Post<T>(string url, Object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            // Adicionado o mediaType diretamente na requisição
            HttpResponseMessage response = await client.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));
        }
    }
}
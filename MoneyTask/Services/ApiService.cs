using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace MoneyTask.Services
{
    public class ApiService
    {
        private readonly HttpClient _client;

        public ApiService()
        {
            string baseUrl = (string)Application.Current.Resources["apiBaseUrl"];
            _client = new HttpClient { BaseAddress = new Uri(baseUrl) };
            Console.WriteLine("TEST");
        }

        public async Task<T> GetAsync<T>(string route)
        {
            try
            {
                var response = await _client.GetAsync(route);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<T>(json);
                    return result;
                }
                else
                {
                    Console.WriteLine("Api request failed");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Api request failed with exception: " + ex.Message);
            }

            return default;
        }


        public async Task<T> PostAsync<T>(string route, object data)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(route, content);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(json);
            }

            throw new Exception("Api request failed");
        }

        // Można dodać także metody PutAsync, DeleteAsync itp.
    }


}

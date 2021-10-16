using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WpfApp1.Services.Data;

namespace WpfApp1.Services
{
    public class WeatherforcastService : IWeatherforcastService
    {
        public const string BASEURL = "http://api.weatherapi.com/v1";
        public const string API_KEY = "6644101487d349c6878172935211510";

        // http://api.weatherapi.com/v1/current.json?key=f06803843c8f4307b64120215211510&q=London&aqi=no
        public async Task<WeatherDataResponse> GetWeatherData(string city)
        {
            return await GetServiceData<WeatherDataResponse>($"{BASEURL}/current.json?key={API_KEY}&q={city}&aqi=no");
        }

        // http://api.weatherapi.com/v1/forecast.json?key=6644101487d349c6878172935211510&q=London&days=1&aqi=no&alerts=no
        public async Task<WeatherForcastDataResponse> GetWeatherForcastData(string city)
        {
            return await GetServiceData<WeatherForcastDataResponse>($"{BASEURL}/forecast.json?key={API_KEY}&q={city}&days=1&aqi=no&alerts=no");
        }

        private async Task<T> GetServiceData<T>(string url)
        {
            T responseObj = default;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BASEURL);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.Timeout = TimeSpan.FromSeconds(Convert.ToDouble(1000000));
                    HttpResponseMessage response = new HttpResponseMessage();
                    response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        string result = response.Content.ReadAsStringAsync().Result;
                        responseObj = JsonConvert.DeserializeObject<T>(result);
                        response.Dispose();
                    }
                    else
                    {
                        string result = response.Content.ReadAsStringAsync().Result;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return responseObj;
        }
    }
}

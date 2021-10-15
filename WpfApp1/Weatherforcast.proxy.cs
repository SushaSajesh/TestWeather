using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WpfApp1.Data;

namespace WpfApp1
{
    public class WeatherforcastService
    {
        public const string BASEURL = "http://api.weatherapi.com/v1";
        public const string API_KEY = "f06803843c8f4307b64120215211510";

        // http://api.weatherapi.com/v1/current.json?key=f06803843c8f4307b64120215211510&q=London&aqi=no

        public async Task<WeatherDataResponse> GetWeatherData(string city)
        {
            WeatherDataResponse responseObj = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BASEURL);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.Timeout = TimeSpan.FromSeconds(Convert.ToDouble(1000000));
                    HttpResponseMessage response = new HttpResponseMessage();
                    response = await client.GetAsync($"{BASEURL}/current.json?key={API_KEY}&q={city}&aqi=no");
                    if (response.IsSuccessStatusCode)
                    {
                        string result = response.Content.ReadAsStringAsync().Result;
                        responseObj = JsonConvert.DeserializeObject<WeatherDataResponse>(result);
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

    /*
{
    "location": {
        "name": "London",
        "region": "City of London, Greater London",
        "country": "United Kingdom",
        "lat": 51.52,
        "lon": -0.11,
        "tz_id": "Europe/London",
        "localtime_epoch": 1634296139,
        "localtime": "2021-10-15 12:08"
    },
    "current": {
        "last_updated_epoch": 1634292000,
        "last_updated": "2021-10-15 11:00",
        "temp_c": 12.0,
        "temp_f": 53.6,
        "is_day": 1,
        "condition": {
            "text": "Partly cloudy",
            "icon": "//cdn.weatherapi.com/weather/64x64/day/116.png",
            "code": 1003
        },
        "wind_mph": 8.1,
        "wind_kph": 13.0,
        "wind_degree": 60,
        "wind_dir": "ENE",
        "pressure_mb": 1021.0,
        "pressure_in": 30.15,
        "precip_mm": 0.0,
        "precip_in": 0.0,
        "humidity": 77,
        "cloud": 75,
        "feelslike_c": 10.9,
        "feelslike_f": 51.6,
        "vis_km": 10.0,
        "vis_miles": 6.0,
        "uv": 4.0,
        "gust_mph": 8.1,
        "gust_kph": 13.0
    }
}     
     */
}

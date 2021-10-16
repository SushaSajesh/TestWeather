using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WpfApp1.Services.Data
{
    public class WeatherDataResponse
    {
        public WeatherDataResponse()
        {
            this.Location = new WeatherLocation();
            this.Data = new WeatherData();
        }

        [JsonProperty("location")]
        public WeatherLocation Location { get; set; }
        [JsonProperty("current")]
        public WeatherData Data { get; set; }
    }

    public class WeatherForcastDataResponse: WeatherDataResponse
    {
        [JsonProperty("forecast")]
        public Forecast Forecast { get; set; }
    }

    public class WeatherLocation
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("region")]
        public string Region { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("lat")]
        public double Lat { get; set; }
        [JsonProperty("lon")]
        public double Lon { get; set; }
        [JsonProperty("tz_id")]
        public string TZ_id { get; set; }
        [JsonProperty("localtime_epoch")]
        public double LocalTime_Epoch { get; set; }

        [JsonProperty("localtime")]
        public DateTimeOffset LocalTime { get; set; }
    }

    public class WeatherData
    {
        public WeatherData()
        {
            this.Condition = new WeatherCondition();
        }

        [JsonProperty("last_updated_epoch")]
        public double LastUpdatedEpoch { get; set; }
        [JsonProperty("last_updated")]
        public DateTimeOffset UastUpdated { get; set; }
        [JsonProperty("temp_c")]
        public double TempInC { get; set; }
        [JsonProperty("temp_f")]
        public double TempInF { get; set; }
        [JsonProperty("is_day")]
        public bool IsDay { get; set; }
        [JsonProperty("condition")]
        public WeatherCondition Condition { get; set; }
        [JsonProperty("wind_mph")]
        public double WindMPH { get; set; }
        [JsonProperty("wind_kph")]
        public double WindKMPH { get; set; }
        [JsonProperty("wind_degree")]
        public double WindDegree { get; set; }
        [JsonProperty("wind_dir")]
        public string WindDir { get; set; }
        [JsonProperty("pressure_mb")]
        public double PressureMB { get; set; }
        [JsonProperty("pressure_in")]
        public double PressureIN { get; set; }
        [JsonProperty("precip_mm")]
        public double PrecipMM { get; set; }
        [JsonProperty("precip_in")]
        public double PrecipIN { get; set; }
        [JsonProperty("humidity")]
        public double Humidity { get; set; }
        [JsonProperty("cloud")]
        public double Cloud { get; set; }
        [JsonProperty("feelslike_c")]
        public double FeelslikeC { get; set; }
        [JsonProperty("feelslike_f")]
        public double FeelslikeF { get; set; }
        [JsonProperty("vis_km")]
        public double VisKM { get; set; }
        [JsonProperty("vis_miles")]
        public double VisMiles { get; set; }
        [JsonProperty("uv")]
        public double UV { get; set; }
        [JsonProperty("gust_mph")]
        public double GustMPH { get; set; }
        [JsonProperty("gust_kph")]
        public double GustKMH { get; set; }
    }

    public class WeatherCondition
    {
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("icon")]
        public string Icon { get; set; }
        [JsonProperty("code")]
        public long Code { get; set; }
    }

    public class WeatherDay
    {
        public double maxtemp_c { get; set; }
        public double maxtemp_f { get; set; }
        public double mintemp_c { get; set; }
        public double mintemp_f { get; set; }
        public double avgtemp_c { get; set; }
        public double avgtemp_f { get; set; }
        public double maxwind_mph { get; set; }
        public double maxwind_kph { get; set; }
        public double totalprecip_mm { get; set; }
        public double totalprecip_in { get; set; }
        public double avgvis_km { get; set; }
        public double avgvis_miles { get; set; }
        public double avghumidity { get; set; }
        public int daily_will_it_rain { get; set; }
        public int daily_chance_of_rain { get; set; }
        public int daily_will_it_snow { get; set; }
        public int daily_chance_of_snow { get; set; }
        public WeatherCondition condition { get; set; }
        public double uv { get; set; }
    }

    public class WeatherAstro
    {
        public string sunrise { get; set; }
        public string sunset { get; set; }
        public string moonrise { get; set; }
        public string moonset { get; set; }
        public string moon_phase { get; set; }
        public string moon_illumination { get; set; }
    }

    public class WeatherHour
    {
        public int time_epoch { get; set; }
        [JsonProperty("time")]
        public DateTimeOffset Time { get; set; }
        public double temp_c { get; set; }
        public double temp_f { get; set; }
        public int is_day { get; set; }
        [JsonProperty("condition")]
        public WeatherCondition Condition { get; set; }
        public double wind_mph { get; set; }
        public double wind_kph { get; set; }
        public int wind_degree { get; set; }
        public string wind_dir { get; set; }
        public double pressure_mb { get; set; }
        public double pressure_in { get; set; }
        public double precip_mm { get; set; }
        public double precip_in { get; set; }
        public int humidity { get; set; }
        public int cloud { get; set; }
        public double feelslike_c { get; set; }
        public double feelslike_f { get; set; }
        public double windchill_c { get; set; }
        public double windchill_f { get; set; }
        public double heatindex_c { get; set; }
        public double heatindex_f { get; set; }
        public double dewpoint_c { get; set; }
        public double dewpoint_f { get; set; }
        public int will_it_rain { get; set; }
        public int chance_of_rain { get; set; }
        public int will_it_snow { get; set; }
        public int chance_of_snow { get; set; }
        public double vis_km { get; set; }
        public double vis_miles { get; set; }
        public double gust_mph { get; set; }
        public double gust_kph { get; set; }
        public double uv { get; set; }
    }

    public class WeatherForecastday
    {
        public string date { get; set; }
        public int date_epoch { get; set; }
        [JsonProperty("day")]
        public WeatherDay Day { get; set; }
        public WeatherAstro astro { get; set; }
        [JsonProperty("hour")]
        public List<WeatherHour> Hour { get; set; }
    }

    public class Forecast
    {
        [JsonProperty("forecastday")]
        public List<WeatherForecastday> ForecastDay { get; set; }
    }
}
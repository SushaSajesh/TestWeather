using System;
using Newtonsoft.Json;

namespace WpfApp1.Data
{
    public class WeatherDataResponse
    {
        [JsonProperty("location")]
        public WeatherLocation Location { get; set; }
        [JsonProperty("current")]
        public WeatherData Data { get; set; }
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

}

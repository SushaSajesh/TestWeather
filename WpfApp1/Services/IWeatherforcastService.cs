using System.Threading.Tasks;
using WpfApp1.Services.Data;

namespace WpfApp1.Services
{
    public interface IWeatherforcastService
    {
        Task<WeatherDataResponse> GetWeatherData(string city);
        Task<WeatherForcastDataResponse> GetWeatherForcastData(string city);
    }
}
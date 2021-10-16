using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using WpfApp1.Services;
using WpfApp1.Services.Data;

namespace WpfApp1.Models
{
    public class WeatherDataContext : WeatherVM
    {
        public WeatherDataContext() : base(new WeatherforcastService())
        {
            this.Init();
        }
    }

    public class WeatherVM : NotifyModel
    {
        private WeatherDataResponse _data = new WeatherDataResponse();
        private ObservableCollection<WeatherHour> threeHourForcast = new ObservableCollection<WeatherHour>();
        private string searchText;
        private readonly IWeatherforcastService service;

        public WeatherVM(IWeatherforcastService service)
        {
            this.service = service;
            this.SearchText = "London";
        }

        public void Init()
        {
            this.SearchCommand = new ActionCommand(ExecuteSearch, CanExecuteSearch);
            this.SearchForcastCommand = new ActionCommand(ExecuteForcastSearch, CanExecuteSearch);
        }

        public bool CanExecuteSearch(object parameter)
        {
            return !string.IsNullOrWhiteSpace(SearchText);
        }

        public async void ExecuteSearch(object parameter)
        {
            this.Data = await service.GetWeatherData(this.searchText);
        }

        public async void ExecuteForcastSearch(object parameter)
        {
            var dataResult = await service.GetWeatherForcastData(this.searchText);
            this.Data = dataResult;
            RefreshforcastData();
        }

        private void RefreshforcastData()
        {
            threeHourForcast.Clear();
            var forcastData = this.Data as WeatherForcastDataResponse;
            if (forcastData != null && forcastData.Forecast != null &&
                forcastData.Forecast.ForecastDay != null &&
                forcastData.Forecast.ForecastDay.Any())
            {
                var threeHours_ForcastData = forcastData.Forecast.ForecastDay.First().Hour.Where(x =>
                x.Time >= this.Data.Location.LocalTime &&
                x.Time <= this.Data.Location.LocalTime.AddHours(3)
                ).ToList();

                threeHours_ForcastData.ForEach(threeHourForcast.Add);
            }
        }

        public ICommand SearchCommand { get; set; }
        public ICommand SearchForcastCommand { get; set; }

        public string SearchText
        {
            get
            {
                return searchText;
            }

            set
            {
                this.searchText = value;
                this.NotifyPropertyChanged("SearchText");
            }
        }

        public WeatherDataResponse Data
        {
            get
            {
                return _data;
            }

            set
            {
                this._data = value;
                this.NotifyPropertyChanged("Data");
            }
        }

        public ObservableCollection<WeatherHour> ThreeHourForcast
        {
            get
            {
                return threeHourForcast;
            }
        }
    }
}

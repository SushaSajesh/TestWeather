using System.Collections.Generic;
using System.Windows.Input;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WpfApp1.Models;
using WpfApp1.Services;
using WpfApp1.Services.Data;

namespace WpfApp1.Test
{
    [TestClass]
    public class WeatherVMTest
    {
        [TestMethod]
        public void SearchTextIsMandatoryForWeatherSearch()
        {
            var weatherforcastServiceMock = new Mock<IWeatherforcastService>();
            WeatherVM vm = new WeatherVM(weatherforcastServiceMock.Object);
            vm.Init();

            vm.SearchText = "";
            var canSearch = vm.SearchCommand.CanExecute(null);
            Assert.IsFalse(canSearch);

            vm.SearchText = "London";
           canSearch = vm.SearchCommand.CanExecute(null);
            Assert.IsTrue(canSearch);
        }

        [TestMethod]
        public void SearchMustSearchWeatherService()
        {
            var weatherforcastServiceMock = new Mock<IWeatherforcastService>();
            weatherforcastServiceMock.Setup(x => x.GetWeatherData(It.IsAny<string>())).ReturnsAsync(new WeatherDataResponse() { Location = new WeatherLocation() {  Name = "London" } });
            WeatherVM vm = new WeatherVM(weatherforcastServiceMock.Object);
            vm.Init();

            vm.SearchText = "London";
            vm.SearchCommand.Execute(null);
            Assert.IsNotNull(vm.Data);
            Assert.IsNotNull(vm.Data.Location);
            Assert.AreEqual(vm.Data.Location.Name, "London");
        }

        [TestMethod]
        public void SearchMustSearchWeatherForcastService()
        {
            var weatherforcastServiceMock = new Mock<IWeatherforcastService>();
            weatherforcastServiceMock.Setup(x => x.GetWeatherForcastData(It.IsAny<string>())).ReturnsAsync(new WeatherForcastDataResponse() { Forecast = new Forecast() { ForecastDay = new List<WeatherForecastday>() { new WeatherForecastday() { Hour = new List<WeatherHour>() { new WeatherHour() { Condition = new WeatherCondition() { Text = "Partly Cloudy" } } } } } } });
            WeatherVM vm = new WeatherVM(weatherforcastServiceMock.Object);
            vm.Init();

            vm.SearchText = "London";
            vm.SearchForcastCommand.Execute(null);
            Assert.IsNotNull(vm.Data);
            Assert.IsInstanceOfType(vm.Data, typeof(WeatherForcastDataResponse));
        }
    }
}

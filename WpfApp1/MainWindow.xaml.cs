using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Services;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WeatherforcastService service = new WeatherforcastService();

        public MainWindow()
        {
            InitializeComponent();
        }


        //private async void btnSearch_Click(object sender, RoutedEventArgs e)
        //{
        //    //var data = await service.GetWeatherData(txtCity.Text);
        //    //cityName.Text = data.Location.Name;
        //    //cityCountry.Text = data.Location.Country;
        //    //cityRegion.Text = data.Location.Region;
        //    //cityLat.Text = data.Location.Lat.ToString();
        //    //cityLon.Text = data.Location.Lon.ToString();

        //    //tempF.Text = data.Data.TempInF.ToString();
        //    //windmph.Text = data.Data.WindMPH.ToString();

        //    //tempCond.Text = data.Data.Condition.Text.ToString();

        //    //try
        //    //{
        //    //    BitmapImage bitmap = new BitmapImage();
        //    //    bitmap.BeginInit();
        //    //    bitmap.UriSource = new Uri(data.Data.Condition.Icon, UriKind.Absolute);
        //    //    bitmap.EndInit();
        //    //    imgWeatherCondition.Source = bitmap;
        //    //}
        //    //catch { }
        //}
    }
}

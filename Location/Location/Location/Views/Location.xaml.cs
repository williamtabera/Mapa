using Location.ClassMaster;
using Location.Resource;
using Newtonsoft.Json;
using Plugin.Geolocator;
using System;
using System.Net.Http;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Location.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Location : ContentPage
    {
        //inicializaciones
        TimeSpan span = new TimeSpan(100000);

        public Location()
        {
            InitializeComponent();
        }
        async void lbllabelGPS()
        {
            try
            {
                if (CrossGeolocator.Current.IsListening)
                {
                    await CrossGeolocator.Current.StopListeningAsync();
                    buttonTrack.Text = AppResources.ObtenerUbicacion;
                }
                else
                {
                    if (await CrossGeolocator.Current.StartListeningAsync(span, 0))
                    {
                        labelGPSTrack.Text = AppResources.ComenzoelSeguimiento;
                        buttonTrack.Text = AppResources.DetenerUbicacion;
                    }
                }
            }
            catch //(Exception ex)
            {
                //Xamarin.Insights.Report(ex);
                //await DisplayAlert("Uh oh", "Something went wrong, but don't worry we captured it in Xamarin Insights! Thanks.", "OK");
            }
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                CrossGeolocator.Current.PositionChanged += CrossGeolocator_Current_PositionChanged;
                CrossGeolocator.Current.PositionError += CrossGeolocator_Current_PositionError;
            }
            catch
            {
            }
        }

        void CrossGeolocator_Current_PositionError(object sender, Plugin.Geolocator.Abstractions.PositionErrorEventArgs e)
        {

            labelGPSTrack.Text = "Error en la localización: " + e.Error.ToString();
        }

        void CrossGeolocator_Current_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            var position = e.Position;
            labelGPSTrack.Text = string.Format("Time: {0} \nLat: {1} \nLong: {2} \nAltitude: {3} \nAltitude Accuracy: {4} \nAccuracy: {5} \nHeading: {6} \nSpeed: {7}",
                position.Timestamp.LocalDateTime, position.Latitude, position.Longitude,
                position.Altitude, position.AltitudeAccuracy, position.Accuracy, position.Heading, position.Speed);


        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            try
            {
                CrossGeolocator.Current.PositionChanged -= CrossGeolocator_Current_PositionChanged;
                CrossGeolocator.Current.PositionError -= CrossGeolocator_Current_PositionError;
            }
            catch
            {
            }
        }

        async void buttonGetGPS_Clicked(object sender, EventArgs e)
        {
            try
            {
                var locator = CrossGeolocator.Current;

                locator.DesiredAccuracy = 1000;
                var position = await locator.GetPositionAsync(span);
                if (position == null)
                {
                    labelGPS.Text = "null gps :(";
                    return;
                }
                labelGPS.Text = string.Format("Time: {0} \nLat: {1} \nLong: {2} \nAltitude: {3} \nAltitude Accuracy: {4} \nAccuracy: {5} \nHeading: {6} \nSpeed: {7}",
                    position.Timestamp.LocalDateTime, position.Latitude, position.Longitude,
                    position.Altitude, position.AltitudeAccuracy, position.Accuracy, position.Heading, position.Speed);

                HttpClient publicaciones = new HttpClient();
                publicaciones.BaseAddress = new Uri("http://192.168.137.1");
                var autenticacion = new location
                {
                    LocalDateTime = position.Timestamp.LocalDateTime.ToString(),
                    Latitude = position.Latitude.ToString(),
                    Longitude = position.Longitude.ToString(),
                    Altitude = position.Altitude.ToString(),
                    AltitudeAccuracy = position.AltitudeAccuracy.ToString(),
                    Accuracy = position.Accuracy.ToString(),
                    Heading = position.Heading.ToString(),
                    Speed = position.Speed.ToString()
                };

                string json = JsonConvert.SerializeObject(autenticacion);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                var request = await publicaciones.PostAsync("Login/api/localizacion", content);

                if (request.IsSuccessStatusCode)
                {
                    var responseJson = await request.Content.ReadAsStringAsync();
                    var response = JsonConvert.DeserializeObject<location>(responseJson);

                    await DisplayAlert("Exito", "Guardado Correctamente", "Aceptar");
                }
                else
                {
                    await DisplayAlert("Error", "Lo sentimos, ocurrio un error con el servidor", "Aceptar");
                }
            }
            catch //(Exception ex)
            {
                // Xamarin.Insights.Report(ex);
                // await DisplayAlert("Uh oh", "Something went wrong, but don't worry we captured it in Xamarin Insights! Thanks.", "OK");
            }
        }
        void buttonTrack_Clicked(object sender, EventArgs e)
        {
            lbllabelGPS();
        }
    }
}
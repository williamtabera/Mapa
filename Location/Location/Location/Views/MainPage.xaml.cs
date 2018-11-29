using Plugin.Geolocator;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Location
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            if (MapView.Count() == 0)
            {
                MapView.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(37, -122), Distance.FromMiles(1)));
            }
        }

        #region "Maps"
        async void Maps()
        {
            TimeSpan span = new TimeSpan(100000);
            if (CrossGeolocator.Current.IsListening)
            {
                await CrossGeolocator.Current.StopListeningAsync();                
                Ubicacion.Text = "Obtener Ubicación";                
            }
            else
            {
                if (await CrossGeolocator.Current.StartListeningAsync(span, 0))
                {
                    Ubicacion.Text = "Detener seguimiento";
                    //MapView.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(37, -122), Distance.FromMiles(1)));                
                    //var pin = new Pin()
                    //{
                    //    Position = new Position(37, -122),
                    //    Label = "Some Pin!"
                    //};
                    //MapView.Pins.Add(pin);
                }
            }
        }
        #endregion

        #region "Botones"
        private void Street_OnClicked(object sender, EventArgs e)
        {
            MapView.MapType = MapType.Street;
        }


        private void Hybrid_OnClicked(object sender, EventArgs e)
        {
            MapView.MapType = MapType.Hybrid;
        }

        private void Satellite_OnClicked(object sender, EventArgs e)
        {
            MapView.MapType = MapType.Satellite;
        }
        #endregion

        #region "ubicacion"
        // este es para tener la ubicacion de forma asincronica
        protected override void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                CrossGeolocator.Current.PositionChanged += CrossGeolocator_Current_PositionChanged;
            }
            catch
            {
            }
        }
        void CrossGeolocator_Current_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            var position = e.Position;

            MapView.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(position.Latitude, position.Longitude), Distance.FromMiles(1)));
            Pin pin = new Pin()
            {
                Position = new Position(position.Latitude, position.Longitude),
                Label = "Some Pin!"
            };
            if (MapView.Pins.Count() == 0)
            {
                MapView.Pins.Add(pin);
            }



        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            try
            {
                CrossGeolocator.Current.PositionChanged -= CrossGeolocator_Current_PositionChanged;
            }
            catch
            {
            }
        }

        #endregion

        private void Obtener_Clicked(object sender, EventArgs e)
        {
            Maps();
        }
    }
}

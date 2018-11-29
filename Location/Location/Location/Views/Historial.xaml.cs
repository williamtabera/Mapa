using Location.ClassMaster;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Location.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Historial : ContentPage
    {
        public Historial()
        {
            InitializeComponent();
            CargarPublicacion();
        }

        private async Task CargarPublicacion()
        {
            HttpClient publicaciones = new HttpClient();
            publicaciones.BaseAddress = new Uri("http://192.168.137.1");

            var request = await publicaciones.GetAsync("Login/api/Localizacion");
            if (request.IsSuccessStatusCode)
            {
                var responseJson = await request.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<List<location>>(responseJson);
                listPublicacionCine.ItemsSource = response;
            }

        }

    }
}
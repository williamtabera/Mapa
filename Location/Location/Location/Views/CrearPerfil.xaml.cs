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
    public partial class CrearPerfil : ContentPage
    {
        public CrearPerfil()
        {
            InitializeComponent();
        }

        private async void Acep_Clicked(object sender, EventArgs e)
        {
            var nombres = Nombres.Text;
            var apellidos = Apellidos.Text;            
            var direccion = Direccion.Text;
            var celular = Celular.Text;
            var estrato = Estrato.Text;
            var fechaNacimiento = FechaNacimiento.Date;           
            var correo = Correo.Text;
            var contraseña = Contraseña.Text;

            if (string.IsNullOrEmpty(nombres))
            {
                await DisplayAlert("Validación", "Ingrese los Nombres", "Aceptar");
                Nombres.Focus();
                return;
            }

            if (string.IsNullOrEmpty(apellidos))
            {
                await DisplayAlert("Validación", "Ingrese los Apellidos", "Aceptar");
                Apellidos.Focus();
                return;
            }

            if (string.IsNullOrEmpty(direccion))
            {
                await DisplayAlert("Validación", "Ingrese la Direccion", "Aceptar");
                Direccion.Focus();
                return;
            }

            if (string.IsNullOrEmpty(celular))
            {
                await DisplayAlert("Validación", "Ingrese el numero de Celular", "Aceptar");
                Celular.Focus();
                return;
            }

            if (string.IsNullOrEmpty(estrato))
            {
                await DisplayAlert("Validación", "Ingrese el Estrato", "Aceptar");
                Estrato.Focus();
                return;
            }

            if (fechaNacimiento == DateTime.Now)
            {
                await DisplayAlert("Validación", "Ingrese la FechaNacimiento", "Aceptar");
                FechaNacimiento.Focus();
                return;
            }

            if (string.IsNullOrEmpty(correo))
            {
                await DisplayAlert("Validación", "Ingrese el Correo", "Aceptar");
                Correo.Focus();
                return;
            }
            if (string.IsNullOrEmpty(contraseña))
            {
                await DisplayAlert("Validación", "Ingrese la Contraseña", "Aceptar");
                Contraseña.Focus();
                return;
            }

            HttpClient publicaciones = new HttpClient();
            publicaciones.BaseAddress = new Uri("http://192.168.137.1");
            var autenticacion = new clsLogin
            {
                Nombres = nombres,
                Apellidos = apellidos,
                Direccion = direccion,
                Celular = celular,
                Estrato = estrato,
                FechaNacimiento = Convert.ToDateTime(fechaNacimiento),
                Correo = correo,
                Contraseña = contraseña
            };

            string json = JsonConvert.SerializeObject(autenticacion);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = await publicaciones.PostAsync("Login/api/CrearPerfil", content);

            if (request.IsSuccessStatusCode)
            {
                var responseJson = await request.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<clsLogin>(responseJson);
                await Navigation.PushAsync(new Login());                
            }
            else
            {
                await DisplayAlert("Error", "Lo sentimos, ocurrio un error con el servidor", "Aceptar");
            }
        }

        private void FechaNacimiento_DateSelected(object sender, DateChangedEventArgs e)
        {
            FechaNacimiento.Date = e.NewDate.Date;
        }
    }
}
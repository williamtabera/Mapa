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
	public partial class Login
	{
        public bool EsPermitido { get; set; } = true;
        public Login ()
		{
            InitializeComponent();            

        }        

        private async void Login_Clicked(object sender, EventArgs e)
        {
            var correo = Correo.Text;
            var password = Password.Text;

            if (string.IsNullOrEmpty(correo))
            {
                await DisplayAlert("Validación", "Ingrese el Correo", "Aceptar");
                Correo.Focus();
                return;
            }
            if (string.IsNullOrEmpty(password))
            {
                await DisplayAlert("Validación", "Ingrese la Contraseña", "Aceptar");
                Password.Focus();
                return;
            }

            HttpClient publicaciones = new HttpClient();
            publicaciones.BaseAddress = new Uri("http://192.168.137.1");     
            var autenticacion = new Login2
            {
                Correo = correo,
                Contraseña = password
            };

            string json = JsonConvert.SerializeObject(autenticacion);
            StringContent content = new StringContent(json,Encoding.UTF8,"application/json");

            var request = await publicaciones.PostAsync("Login/api/Login",content);

            if (request.IsSuccessStatusCode)
            {
                var responseJson = await request.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<bool>(responseJson);
           
                if (response == true)
                {
                    await Navigation.PushAsync(new MasterDetail());
                }
                else
                {
                    await DisplayAlert("Lo sentimos", "es incorrecto", "Aceptar");
                }
            }
            else
            {
                await DisplayAlert("Error", "Lo sentimos, ocurrio un error con el servidor", "Aceptar");
            }

        }

        private async void Crear_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CrearPerfil());
        }
    }
}
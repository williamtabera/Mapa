using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Location.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MasterDetail : MasterDetailPage
	{
		public MasterDetail ()
		{
			InitializeComponent ();
		}

        private void Mapa_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new MainPage());
        }

        private void Geolocalizacion_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Location());
        }

        private void Historial_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Historial());
        }
    }
}
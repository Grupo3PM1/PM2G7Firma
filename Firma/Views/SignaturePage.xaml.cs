using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Firma.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignaturePage : ContentPage
    {
        public SignaturePage()
        {
            InitializeComponent();
        }

        private async Task<bool> ValidationSignature()
        {
            if (String.IsNullOrWhiteSpace(Nombre.Text))
            {
                await this.DisplayAlert("Advertencia", "Debe describir un nombre", "OK");
                return false;
            }

            if (String.IsNullOrWhiteSpace(Descripcion.Text))
            {
                await this.DisplayAlert("Advertencia", "Debe escribir una descripción", "OK");
                return false;
            }

            if (Signature.IsBlank)
            {
                await this.DisplayAlert("Advertencia", "Escriba su firma", "OK");
                return false;
            }

            return true;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            //Boton de Guardar
            if (await ValidationSignature())
            {
                await DisplayAlert("Exito", "Guardado Correctamente", "OK");
                await Navigation.PushAsync(new SignaturePage());
            }
        }
    }
}
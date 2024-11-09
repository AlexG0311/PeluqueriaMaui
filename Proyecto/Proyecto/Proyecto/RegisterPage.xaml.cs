using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Proyecto.Helpers;
using Proyecto.Model;

namespace Proyecto
{
    public partial class RegisterPage : ContentPage
    {
        private ApiService _apiService;

        public RegisterPage()
        {
            InitializeComponent();

            _apiService = new ApiService("https://9fcd-181-78-20-113.ngrok-free.app");
        }

        private async void Insertar(object sender, EventArgs e)
        {
            Usuarios usuario = LlenarPersona();


            int result = await _apiService.PostAsync<Usuarios,int>("api/Usuarios", usuario);

            if (result > 0)
            {
                await DisplayAlert("Insert", "Exitoo", "Ok");
            }

       
        }

        private Usuarios LlenarPersona(bool isUpdate = false)
        {
            Usuarios usuario = new Usuarios();


            usuario.Nombre = NombreEntry.Text;
            usuario.Apellido = ApellidosEntry.Text;
            usuario.Correo = CorreoEntry.Text;
            usuario.Contraseña = PasswordEntry.Text;

            // Convertir el texto a un entero
            if (int.TryParse(TelefonoEntry.Text, out int telefono))
            {
                usuario.Telefono = telefono;
            }
            else
            {
                // Manejo de error en caso de que la conversión falle
                // Puedes lanzar una excepción o mostrar un mensaje de error
                throw new FormatException("El número de teléfono debe ser un valor numérico válido.");
            }


            return usuario;
        }
        private async void OnLoginTapped(object sender, EventArgs e)
        {
            // Redirigir a la página de inicio de sesión
            await Navigation.PushAsync(new LoginPage());
        }
    }
}

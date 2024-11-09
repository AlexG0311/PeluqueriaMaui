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

            _apiService = new ApiService("https://b6e0-181-78-20-113.ngrok-free.app");
        }

        private async void Insertar(object sender, EventArgs e)
        {
            Usuarios usuario = LlenarPersona();

            // Llama al método PostAsync y espera un objeto Usuarios como respuesta.
            Usuarios result = await _apiService.PostAsync<Usuarios, Usuarios>("api/Usuarios", usuario);

            if (result != null && result.idUsuario > 0)
            {
                await DisplayAlert("Insert", "¡Registro exitoso!", "Ok");
            }
            else
            {
                await DisplayAlert("Error", "Hubo un problema al insertar el usuario.", "Ok");
            }
        }



        private Usuarios LlenarPersona(bool isUpdate = false)
        {
            Usuarios usuario = new Usuarios();


            usuario.nombre = NombreEntry.Text;
            usuario.apellidos = ApellidosEntry.Text;
            usuario.correo = CorreoEntry.Text;
            usuario.contrasena = PasswordEntry.Text;
            usuario.telefono = TelefonoEntry.Text;
          


            return usuario;
        }
        private async void OnLoginTapped(object sender, EventArgs e)
        {
            // Redirigir a la página de inicio de sesión
            await Navigation.PushAsync(new LoginPage());
        }
    }
}

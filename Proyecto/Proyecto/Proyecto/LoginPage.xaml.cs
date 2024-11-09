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
    public partial class LoginPage : ContentPage
    {

        private ApiService _apiService;
        public LoginPage()
        {
            InitializeComponent();

            _apiService = new ApiService("https://b6e0-181-78-20-113.ngrok-free.app");
        }

        private async void Login(object sender, EventArgs e)
        {
            try
            {
                // Obtener la lista de usuarios desde la API
                List<Usuarios> usuarios = await _apiService.GetAsync<List<Usuarios>>("api/Usuarios");

                // Validar el correo y la contraseña ingresados
                var usuarioEncontrado = usuarios.FirstOrDefault(u =>
                    u.correo == CorreoEntry.Text && u.contrasena == PasswordEntry.Text);

                if (usuarioEncontrado != null)
                {
                    // Navegar a la página de destino si el login es correcto
                    await DisplayAlert("Login", "Inicio de sesión exitoso", "OK");
                    await Navigation.PushAsync(new Cliente()); // Reemplaza `PaginaDestino` con la página a la que quieras redirigir
                }
                else
                {
                    // Mostrar un mensaje de error si no se encuentra el usuario
                    await DisplayAlert("Error", "Correo o contraseña incorrectos", "Cerrar");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en el login: " + ex.Message);
                await DisplayAlert("Error", "Hubo un problema al iniciar sesión. Intenta de nuevo más tarde.", "Cerrar");
            }
        }

        private async void Registrar(object sender, EventArgs e)
        {
            // Redirigir a la página de inicio de sesión
            await Navigation.PushAsync(new RegisterPage());
        }


    }

}

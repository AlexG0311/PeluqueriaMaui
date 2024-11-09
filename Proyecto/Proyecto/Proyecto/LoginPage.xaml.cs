using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace Proyecto
{
    public partial class LoginPage : ContentPage
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            var loginData = new
            {
                Username = UsernameEntry.Text,
                Password = PasswordEntry.Text
            };

            var json = JsonSerializer.Serialize(loginData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync("https://b137-190-0-245-162.ngrok-free.app/api/Usuarios", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<LoginResponse>(responseContent);
                    await DisplayAlert("Éxito", $"Bienvenido, {result?.Username}", "OK");
                    // Navegar a la página principal o dashboard
                }
                else
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    await DisplayAlert("Error", $"Fallo en el inicio de sesión: {errorMessage}", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Ocurrió un problema: {ex.Message}", "OK");
            }
        }

        private async void OnRegisterTapped(object sender, EventArgs e)
        {
            // Navegar a la página de registro
            await Navigation.PushAsync(new RegisterPage());
        }
    }

    public class LoginResponse
    {
        public string Username { get; set; }
        public string Token { get; set; }
    }
}

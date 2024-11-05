using System;
using Microsoft.Maui.Controls;

namespace Proyecto
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            string username = UsernameEntry.Text;
            string password = PasswordEntry.Text;

            // Validación básica del usuario y la contraseña
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                await DisplayAlert("Error", "Por favor, ingrese su usuario y contraseña.", "OK");
                return;
            }

            // Lógica de autenticación (puedes reemplazarla con la autenticación real)
            bool isValid = await AuthenticateUser(username, password);
            if (isValid)
            {
                await DisplayAlert("Éxito", "Inicio de sesión exitoso", "OK");
                // Redirigir a otra página después del inicio de sesión
                // Por ejemplo: await Navigation.PushAsync(new HomePage());
            }
            else
            {
                await DisplayAlert("Error", "Usuario o contraseña incorrectos.", "OK");
            }
        }

        private async void OnRegisterTapped(object sender, EventArgs e)
        {
            // Redirigir a la página de registro
            await Navigation.PushAsync(new SignUpPage());
        }

        private Task<bool> AuthenticateUser(string username, string password)
        {
            // Lógica de autenticación simulada (reemplaza con tu lógica real)
            return Task.FromResult(username == "usuario" && password == "contraseña123");
        }
    }
}
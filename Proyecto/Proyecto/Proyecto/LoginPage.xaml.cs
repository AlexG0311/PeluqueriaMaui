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

            // Validaci�n b�sica del usuario y la contrase�a
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                await DisplayAlert("Error", "Por favor, ingrese su usuario y contrase�a.", "OK");
                return;
            }

            // L�gica de autenticaci�n (puedes reemplazarla con la autenticaci�n real)
            bool isValid = await AuthenticateUser(username, password);
            if (isValid)
            {
                await DisplayAlert("�xito", "Inicio de sesi�n exitoso", "OK");
                // Redirigir a otra p�gina despu�s del inicio de sesi�n
                // Por ejemplo: await Navigation.PushAsync(new HomePage());
            }
            else
            {
                await DisplayAlert("Error", "Usuario o contrase�a incorrectos.", "OK");
            }
        }

        private async void OnRegisterTapped(object sender, EventArgs e)
        {
            // Redirigir a la p�gina de registro
            await Navigation.PushAsync(new SignUpPage());
        }

        private Task<bool> AuthenticateUser(string username, string password)
        {
            // L�gica de autenticaci�n simulada (reemplaza con tu l�gica real)
            return Task.FromResult(username == "usuario" && password == "contrase�a123");
        }
    }
}
namespace SpotifyPremium;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        string user = UsernameEntry.Text?.Trim();
        string pass = PasswordEntry.Text?.Trim();

        if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
        {
            await DisplayAlert("Error", "Usuario y contraseña son obligatorios", "OK");
            return;
        }

        // === KEYAUTH LOGIN ===
        try
        {
            // Asegúrate de que KeyAuth.cs tenga tus datos (lo hacemos en el paso 2)
            var keyAuth = new KeyAuthApp();   // ← este es el nombre de clase que trae keyauth.cc

            bool loginExitoso = await Task.Run(() => keyAuth.login(user, pass));

            if (loginExitoso)
            {
                FileVaultService.Init();                    // inicializa el vault de archivos ocultos
                await Navigation.PushAsync(new MainPage()); // va a la pantalla principal de Spotify
            }
            else
            {
                await DisplayAlert("Error", "Usuario o contraseña incorrectos (KeyAuth)", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Error de KeyAuth: {ex.Message}", "OK");
        }
    }
}

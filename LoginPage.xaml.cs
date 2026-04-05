namespace SpotifyPremium;

public partial class LoginPage : ContentPage
{
    public LoginPage() => InitializeComponent();

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        string user = UsernameEntry.Text?.Trim();
        string pass = PasswordEntry.Text?.Trim();

        if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
        {
            await DisplayAlert("Error", "Usuario y contraseña son obligatorios", "OK");
            return;
        }

        try
        {
            var keyAuth = new KeyAuthApp();
            bool loginExitoso = await Task.Run(() => keyAuth.login(user, pass));

            if (loginExitoso)
            {
                FileVaultService.Init();
                await Navigation.PushAsync(new MainPage());
            }
            else
            {
                await DisplayAlert("Error", "Usuario o contraseña incorrectos", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"KeyAuth error: {ex.Message}", "OK");
        }
    }
}

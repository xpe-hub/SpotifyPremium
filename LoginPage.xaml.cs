namespace SpotifyPremium;

public partial class LoginPage : ContentPage
{
    public LoginPage() => InitializeComponent();

    private async void OnLogin(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(UserEntry.Text) || string.IsNullOrEmpty(PassEntry.Text))
        {
            await DisplayAlert("Error", "Usuario y contraseña requeridos", "OK");
            return;
        }

        // KeyAuth login (ajusta según tu clase KeyAuth.cs)
        var keyAuth = new KeyAuthApp(); // nombre exacto de tu clase descargada
        if (await Task.Run(() => keyAuth.login(UserEntry.Text, PassEntry.Text)))
        {
            FileVaultService.Init();
            await Navigation.PushAsync(new MainPage());
        }
        else
        {
            await DisplayAlert("Error", "Credenciales inválidas", "OK");
        }
    }
}
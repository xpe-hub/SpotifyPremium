namespace SpotifyPremium;

public partial class VaultPage : ContentPage
{
    public VaultPage()
    {
        InitializeComponent();
        LoadVault();
    }

    private void LoadVault()
    {
        VaultList.ItemsSource = FileVaultService.ObtenerArchivos();
    }

    private async void OnAddFile(object sender, EventArgs e)
    {
        var file = await FilePicker.Default.PickAsync();
        if (file == null) return;

        using var stream = await file.OpenReadAsync();
        var nombre = await FileVaultService.GuardarArchivo(stream, file.FileName);

        await DisplayAlert("Éxito", $"Archivo {nombre} encriptado y oculto en Vault", "OK");
        LoadVault();
    }

    private async void OnActivateDns(object sender, EventArgs e)
    {
        await VpnDnsService.ActivarDns();
        await DisplayAlert("DNS", "DNS activado (solo visible en Vault)", "OK");
    }

    private async void OnDeactivateDns(object sender, EventArgs e)
    {
        await VpnDnsService.DesactivarDns();
        await DisplayAlert("DNS", "DNS eliminado COMPLETAMENTE sin rastros", "OK");
    }

    private async void OnExit(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}
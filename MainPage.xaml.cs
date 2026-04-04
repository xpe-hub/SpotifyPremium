namespace SpotifyPremium;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        LoadSongs();
    }

    private void LoadSongs()
    {
        var songs = new List<Song>
        {
            new Song { Title = "Blinding Lights", Artist = "The Weeknd" },
            new Song { Title = "Levitating", Artist = "Dua Lipa" },
            new Song { Title = "Save Your Tears", Artist = "The Weeknd" },
            new Song { Title = "As It Was", Artist = "Harry Styles" },
            new Song { Title = "Industry Baby", Artist = "Lil Nas X" }
        };
        SongsList.ItemsSource = songs;
    }

    private async void OnTripleTap(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new VaultPage());
    }
}

public class Song
{
    public string Title { get; set; } = "";
    public string Artist { get; set; } = "";
}
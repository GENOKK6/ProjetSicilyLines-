using Newtonsoft.Json;

namespace ProjetSicilyLines;

public partial class Reservations : ContentPage
{
    public Reservations()
    {
        InitializeComponent();
        LoadDataFromAPI();
    }

    private async void LoadDataFromAPI()
    {
        HttpClient client = new HttpClient();
        var restURL = "http://localhost:5079/Reservation?pseudo=Gospel";
        client.BaseAddress = new Uri(restURL);
        HttpResponseMessage response = await client.GetAsync(restURL);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var Items = JsonConvert.DeserializeObject<List<ReservationAffichage>>(content);
            lv.ItemsSource = Items;
        }
        else
        {
            await DisplayAlert("Erreur", "Pas de connexion avec l'API", "OK");
        }
    }
}

public class ReservationAffichage
{
    public string NomTraversee { get; set; }
    public DateTime DateDepart { get; set; }
    public Color Couleur => DateDepart < DateTime.Now ? Colors.LightGray : Colors.LightGreen;
}
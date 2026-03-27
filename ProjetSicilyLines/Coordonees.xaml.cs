using Newtonsoft.Json;

namespace ProjetSicilyLines;

public partial class Coordonnees : ContentPage
{
    private Client _client;

    public Coordonnees()
    {
        InitializeComponent();
        LoadDataFromAPI();
    }

    private async void LoadDataFromAPI()
    {
        HttpClient client = new HttpClient();
        var restURL = "http://localhost:5079/Client?pseudo=Gospel";
        client.BaseAddress = new Uri(restURL);
        HttpResponseMessage response = await client.GetAsync(restURL);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            _client = JsonConvert.DeserializeObject<Client>(content);

            EntryNom.Text = _client.Nom;
            EntryPrenom.Text = _client.Prenom;
            EntryEmail.Text = _client.Email;
            EntryTelephone.Text = _client.Telephone;
            EntryAdresse.Text = _client.Adresse;
            EntryVille.Text = _client.Ville;
            EntryCodePostal.Text = _client.CodePostal;
        }
    }

    private async void BtnEnregistrer_Clicked(object sender, EventArgs e)
    {


        _client.Email = EntryEmail.Text;
        _client.Telephone = EntryTelephone.Text;
        _client.Adresse = EntryAdresse.Text;
        _client.Ville = EntryVille.Text;
        _client.CodePostal = EntryCodePostal.Text;

        HttpClient http = new HttpClient();
        var json = JsonConvert.SerializeObject(_client);
        var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
        var response = await http.PutAsync("http://localhost:5079/Client", content);

        if (response.IsSuccessStatusCode)
            await DisplayAlert("Succès", "Coordonnées enregistrées !", "OK");
        else
            await DisplayAlert("Erreur", "Impossible de sauvegarder.", "OK");
    }
}
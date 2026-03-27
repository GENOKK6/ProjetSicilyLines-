namespace ProjetSicilyLines;

public partial class Coordonnees : ContentPage
{
    public Coordonnees()
    {
        InitializeComponent();
        ChargerDonneesSimulees();
    }

    private void ChargerDonneesSimulees()
    {
       
        EntryNom.Text = "Dupont";
        EntryPrenom.Text = "Jean";
        EntryEmail.Text = "jean.dupont@email.com";
        EntryTelephone.Text = "0612345678";
        EntryAdresse.Text = "12 rue de la Paix";
        EntryVille.Text = "Paris";
        EntryCodePostal.Text = "75000";
    }

    private async void BtnEnregistrer_Clicked(object sender, EventArgs e)
    {
        await DisplayAlert("Succès", "Coordonnées enregistrées !", "OK");
    }
}
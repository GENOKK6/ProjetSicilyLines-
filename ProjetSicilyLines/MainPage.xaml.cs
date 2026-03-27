namespace ProjetSicilyLines;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void BtnCoordonnees_Clicked(object sender, EventArgs e)
    {
        
        await Navigation.PushAsync(new Coordonnees());
    }

    private async void BtnReservations_Clicked(object sender, EventArgs e)
    {
        
        await Navigation.PushAsync(new Reservations());
    }

    private async void BtnDeconnexion_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
namespace ProjetSicilyLines;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

    private async void  Button_Clicked(object sender, EventArgs e)
    {
        HttpClient client = new HttpClient();
        var restURL = "http://localhost:5079/Login?pseudo=" + pseudo.Text + "&pass=" + pass.Text;
        client.BaseAddress = new Uri(restURL);
        HttpResponseMessage response = await client.GetAsync(restURL);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            if (Convert.ToBoolean(content))
            {
                await Navigation.PushAsync(new MainPage());
            }
            else
            {
                await DisplayAlert("Alerte", "Connexion user refusée car tu n'as pâs mis le bon mot de passe eh bah oe frero", "Cancel");
            }
        }

        else
        {
            await DisplayAlert("Alerte", "Pas de connexion avec l'API", "Cancel");
        }

    }
}
namespace ProjetSicilyLines;

public partial class Reservations : ContentPage
{
    public Reservations()
    {
        InitializeComponent();
        ChargerDonneesSimulees();
    }

    private void ChargerDonneesSimulees()
    {
        var reservations = new List<ReservationAffichage>
        {
            new ReservationAffichage { NomTraversee = "Marseille - Tunis", DateDepart = new DateTime(2025, 12, 10) },
            new ReservationAffichage { NomTraversee = "Gênes - Palerme", DateDepart = new DateTime(2026, 5, 20) },
            new ReservationAffichage { NomTraversee = "Barcelone - Alger", DateDepart = new DateTime(2024, 8, 3) },
            new ReservationAffichage { NomTraversee = "Nice - Bastia", DateDepart = new DateTime(2026, 7, 15) },
        };

        ListeReservations.ItemsSource = reservations;
    }
}

public class ReservationAffichage
{
    public string NomTraversee { get; set; }
    public DateTime DateDepart { get; set; }

    
    public Color Couleur => DateDepart < DateTime.Now ? Colors.LightGray : Colors.LightGreen;
}
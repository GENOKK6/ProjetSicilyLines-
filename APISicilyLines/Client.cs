using System.Runtime.CompilerServices;

namespace APISicilyLines
{
    public class Client
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public int Telephone { get; set; }
        public string Adresse { get; set; }
        public string Ville { get; set; }
        public int CodePostal { get; set; }
     
    

    public Client(string nom, string prenom, string email, int telephone, string adresse, string ville)
        {
            this.Nom = nom;
            this.Prenom = prenom;
            this.Email = email;
            this.Telephone = telephone;
            this.Adresse = adresse;
            this.Ville = ville;

        }
        public List<Reservation> Reservations { get; set; }

    }




}

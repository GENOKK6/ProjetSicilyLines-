namespace APISicilyLines
{
    public class Reservation
    {
        public int Id { get; set; }
        public string NomTraversee { get; set; }
        public DateTime DateDepart { get; set; }
        public int ClientId { get; set; }     
        public Client Client { get; set; }
    }
}

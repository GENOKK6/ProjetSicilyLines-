using Microsoft.AspNetCore.Mvc;

namespace APISicilyLines.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservationController : ControllerBase
    {
        private DatabaseService _db = new DatabaseService();

        [HttpGet]
        public List<Reservation> Get(string pseudo)
        {
            var client = _db.GetClient(pseudo);
            if (client == null) return new List<Reservation>();
            return _db.GetReservations(client.Id);
        }
    }
}
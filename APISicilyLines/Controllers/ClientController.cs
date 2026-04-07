using Microsoft.AspNetCore.Mvc;

namespace APISicilyLines.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private DatabaseService _db = new DatabaseService();

        [HttpGet]
        public Client Get(string pseudo)
        {
            return _db.GetClient(pseudo);
        }

        [HttpPut]
        public bool Put([FromBody] Client client)
        {
            return _db.UpdateClient(client);
        }
    }
}
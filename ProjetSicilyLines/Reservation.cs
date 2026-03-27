using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetSicilyLines
{
   
    public class Reservation
    {
        public int Id { get; set; }
        public string NomTraversee { get; set; }
        public DateTime DateDepart { get; set; }
        public int ClientId { get; set; }
    }
}


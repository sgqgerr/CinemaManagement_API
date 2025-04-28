using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Ticket
    {
        public Ticket() { }

        public enum Status
        {
            Bought = 0,
            Reserved = 1,
            Returned = 2
        }
        public int Id { get; set; }

        public int SessionId { get; set; }

        public Session? CurrentSession {  get; set; }

        public List<int> Place {  get; set; }

        public int PriceOfTicket { get; set; }

        public Status StatusTicket { get; set; }

    }
}

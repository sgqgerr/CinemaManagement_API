using DataAccess.Entities;

namespace CinemaManagement_API.Models
{
    public class AddTicketModel
    {
        public enum Status
        {
            Bought = 0,
            Reserved = 1,
            Returned = 2
        }

        public List<int> Place { get; set; }

        public int PriceOfTicket { get; set; }

        public Status StatusTicket { get; set; }
    }
}

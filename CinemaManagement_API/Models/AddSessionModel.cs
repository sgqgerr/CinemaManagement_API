using DataAccess.Entities;

namespace CinemaManagement_API.Models
{
    public class AddSessionModel
    {

        public DateTime DateOfSession { get; set; }

        public int PriceOfTicket { get; set; }

        public bool Status { get; set; }
    }
}

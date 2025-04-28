using DataAccess.Entities;

namespace CinemaManagement_API.Models
{
    public class AddSalesModel
    {
        public int AmountTickets { get; set; }

        public int ToPayBill { get; set; }

        public DateTime DateOfPurchase { get; set; }
    }
}

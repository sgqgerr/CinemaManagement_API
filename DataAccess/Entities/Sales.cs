using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Sales
    {
        public Sales() { }

        public int Id { get; set; } 

        public int UserId { get; set; } 

        public User? CurrentUser { get; set; }  

        public int AmountTickets { get; set; }

        public int ToPayBill {  get; set; }

        public DateTime DateOfPurchase { get; set; }

    }
}

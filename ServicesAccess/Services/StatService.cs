using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaManagement.Entities;
using CinemaManagement.Data;

namespace CinemaManagement.Services
{
    internal class StatService
    {
        private readonly CinemaManagementDbContext _database;

        public StatService(CinemaManagementDbContext database)
        {
            _database = database;
        }

        protected internal void CreateStat()
        {

            var tickets = _database.Ticket.ToList();

            int totalRevenue = tickets
                .Where(t => t.StatusTicket == Ticket.Status.Bought)
                .Sum(t => t.PriceOfTicket);

            int totalTicketsSold = tickets
                .Count(t => t.StatusTicket == Ticket.Status.Bought);

            int totalReturnedTickets = tickets
                .Count(t => t.StatusTicket == Ticket.Status.Returned);

            Console.WriteLine("------ Financial Statistics ------");
            Console.WriteLine($"Total revenue: {totalRevenue} UAH");
            Console.WriteLine($"Total tickets sold: {totalTicketsSold}");
            Console.WriteLine($"Total tickets returned: {totalReturnedTickets}");
            Console.WriteLine("----------------------------------");

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaManagement.Data;
using CinemaManagement.Entities;

namespace CinemaManagement.Services
{
    internal class TicketService
    {
        readonly private CinemaManagementDbContext _database;

        public TicketService(CinemaManagementDbContext database)
        {
            _database = database;
        }

        protected internal void CreateTicket()
        {
            Console.WriteLine("Enter Session ID...");
            if (!int.TryParse(Console.ReadLine(), out int sessionId))
            {

                Console.WriteLine("Invalid session ID.");
                return;

            }

            var session = _database.Sessions.FirstOrDefault(s => s.Id == sessionId);
            if (session == null)
            {

                Console.WriteLine("Session not found.");
                return;

            }

            Console.WriteLine("Enter seat numbers separated by commas (e.g., 1,2,3)...");
            string seatInput = Console.ReadLine();

            var seatList = seatInput.Split(',')
                                    .Select(s => int.TryParse(s, out int val) ? val : -1)
                                    .Where(val => val >= 0)
                                    .ToList();

            if (seatList.Count == 0)
            {

                Console.WriteLine("Invalid seat numbers.");
                return;

            }

            Console.WriteLine("Enter ticket price...");
            if (!int.TryParse(Console.ReadLine(), out int price))
            {

                Console.WriteLine("Invalid price.");
                return;

            }

            Console.WriteLine("Enter ticket status (0 - Bought, 1 - Reserved, 2 - Returned)...");
            if (!int.TryParse(Console.ReadLine(), out int statusValue) || !Enum.IsDefined(typeof(Ticket.Status), statusValue))
            {

                Console.WriteLine("Invalid status.");
                return;

            }

            var ticket = new Ticket
            {
                SessionId = sessionId,
                Place = seatList,
                PriceOfTicket = price,
                StatusTicket = (Ticket.Status)statusValue
            };

            _database.Ticket.Add(ticket);
            _database.SaveChanges();

            Console.WriteLine("Ticket was created successfully...");

        }

        protected internal void EditTicket() 
        {
            Console.WriteLine("Enter Ticket ID to edit...");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {

                Console.WriteLine("Invalid ID.");
                return;

            }

            var ticket = _database.Ticket.FirstOrDefault(t => t.Id == id);
            if (ticket == null)
            {

                Console.WriteLine("Ticket not found.");
                return;

            }

            Console.WriteLine("Enter new ticket price (or leave empty to keep current)...");
            string priceInput = Console.ReadLine();

            if (int.TryParse(priceInput, out int newPrice))
            {

                ticket.PriceOfTicket = newPrice;

            }

            Console.WriteLine("Enter new seat numbers (comma-separated) or leave empty...");
            string seatsInput = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(seatsInput))
            {
                var newSeats = seatsInput.Split(',')
                                         .Select(s => int.TryParse(s, out int val) ? val : -1)
                                         .Where(val => val >= 0)
                                         .ToList();
                if (newSeats.Count > 0)
                {

                    ticket.Place = newSeats;

                }
            }

            Console.WriteLine("Enter new ticket status (0 - Bought, 1 - Reserved, 2 - Returned)...");
            if (int.TryParse(Console.ReadLine(), out int statusValue) && Enum.IsDefined(typeof(Ticket.Status), statusValue))
            {

                ticket.StatusTicket = (Ticket.Status)statusValue;

            }

            _database.SaveChanges();

            Console.WriteLine("Ticket updated successfully...");
        }

        protected internal void DeleteTicket() 
        {

            Console.WriteLine("Enter the ID of the ticket...");

            int.TryParse(Console.ReadLine() , out int  id);

            var ticket = _database.Ticket.FirstOrDefault(t => t.Id == id);

            if (ticket == null) 
            {

                Console.WriteLine("Invalid ID.");
                return;

            }

            _database.Ticket.Remove(ticket);
            _database.SaveChanges();

            Console.WriteLine("Ticket was successfully deleted...");

        }

        protected internal void ViewTickets() 
        {

            var tickets = _database.Ticket.ToList();

            if (!tickets.Any()) 
            {

                Console.WriteLine("There are no more available tickets...");
                return;

            }

            foreach (var ticket in tickets) 
            {

                string places = string.Join(", ", ticket.Place ?? new List<int>());

                Console.WriteLine($"ID : {ticket.Id} | SessionID : {ticket.SessionId} " +
                    $"| CurrentSession : {ticket.CurrentSession} | Place/Places : {places} | " +
                    $"PriceOfTicket : {ticket.PriceOfTicket} | StatusTicket : {ticket.StatusTicket}");

            }

        }
    }
}

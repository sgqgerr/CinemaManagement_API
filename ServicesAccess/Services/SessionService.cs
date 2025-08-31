using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Data;
using DataAccess.Entities;

namespace CinemaManagement.Services
{
    internal class SessionService
    {
        private readonly CinemaManagementDbContext _database;

        public SessionService(CinemaManagementDbContext database)
        {
            _database = database;
        }

        protected internal void CreateSession()
        {
            #region
            Console.WriteLine("Enter the film ID...");
            if (!int.TryParse(Console.ReadLine(), out int filmId))
            {

                Console.WriteLine("Invalid film ID.");
                return;

            }

            bool film = _database.Films.Any(f => f.Id == filmId);
            if (!film)
            {

                Console.WriteLine("Film not found.");
                return;

            }

            Console.WriteLine("Enter the hall ID...");
            if (!int.TryParse(Console.ReadLine(), out int hallId))
            {

                Console.WriteLine("Invalid Hall ID.");
                return;

            }

            bool hall = _database.Halls.Any(h => h.Id == hallId);
            if (!hall)
            {

                Console.WriteLine("Hall not found.");
                return;

            }

            Console.WriteLine("Enter the date and time of the session (yyyy-MM-dd HH:mm)...");

            if (!DateTime.TryParse(Console.ReadLine(), out DateTime sessionDate))
            {

                Console.WriteLine("Invalid date format.");
                return;

            }

            Console.WriteLine("Enter the ticket price...");
            if (!int.TryParse(Console.ReadLine(), out int price) || price < 0)
            {

                Console.WriteLine("Invalid price.");
                return;

            }
            #endregion

            var session = new Session
            {
                FilmId = filmId,
                HallId = hallId,
                DateOfSession = sessionDate,
                PriceOfTicket = price,
                Status = true
            };

            _database.Sessions.Add(session);
            _database.SaveChanges();

            Console.WriteLine("Session created successfully...");


        }

        protected internal void DeleteSession()
        {

            Console.WriteLine("Enter the ID of the session...");

            int.TryParse(Console.ReadLine(), out int  id);

            var session = _database.Sessions.FirstOrDefault(s => s.Id == id);

            if (session == null) 
            {

                Console.WriteLine("Invalid ID.");
                return;

            }

            _database.Sessions.Remove(session);
            _database.SaveChanges();

            Console.WriteLine("Session deleted successfully...");

        }

        protected internal void EditSession()
        {

            Console.WriteLine("Enter the session ID ...");

            int.TryParse(Console.ReadLine(), out int id);

            var session = _database.Sessions.FirstOrDefault(s => s.Id == id);

            if (session == null) 
            {
                Console.WriteLine("Invalid ID.");
            }

            Console.WriteLine("Enter new date (yyyy-MM-dd HH:mm)...");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime newDate))
            {
                session.DateOfSession = newDate;
            }

            Console.WriteLine("Enter new price...");
            if (int.TryParse(Console.ReadLine(), out int newPrice))
            {
                session.PriceOfTicket = newPrice;
            }

            Console.WriteLine("Is session active? (y/n)...");
            char status = char.ToLower(Console.ReadKey().KeyChar);

            Console.WriteLine();
            session.Status = (status == 'y');

            _database.SaveChanges();

            Console.WriteLine("Session updated successfully...");

        }

        protected internal void ViewSession()
        {

            var sessions = _database.Sessions.ToList();

            if (!sessions.Any()) 
            {

                Console.WriteLine("There are no more available sessions...");
                return;

            }

            foreach (var session in sessions) 
            {
                Console.WriteLine($"ID : {session.Id} | FilmID : {session.FilmId} | " +
                    $"HallID : {session.HallId} | PriceOfTicket : {session.PriceOfTicket} |" +
                    $"Status : {session.Status}");
            }
        }

    }
}

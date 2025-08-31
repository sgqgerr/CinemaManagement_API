using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Data;
using DataAccess.Entities;

namespace CinemaManagement.Services
{
    internal class HallService
    {
        private readonly CinemaManagementDbContext _database;
        public HallService(CinemaManagementDbContext database) 
        { 

            _database = database;

        }

        protected internal void CreateHall()
        {

            Console.WriteLine("Enter the number of the seats...");

            int.TryParse(Console.ReadLine(), out int hallSeats);

            Console.WriteLine("Answer , is the hall VIP? \n(y/n ," +
                " only 1 letter \n y - yes \n n - no)");

            char answerVIP = char.ToLower(Console.ReadKey().KeyChar);

            bool _IsVIP = false;

            switch (answerVIP) 
            {

                case 'y':

                    _IsVIP = true;
                    break;

                case 'n':

                    _IsVIP = false;
                    break;

            }

            var hall = new Hall()
            {
                Seats = hallSeats,
                IsVIP = _IsVIP
            };


            _database.Halls.Add(hall);
            _database.SaveChanges();

            Console.WriteLine("Hall has been added successfully...");

        }

        protected internal void DeleteHall()
        {

            Console.WriteLine("Enter the hall id...");

            int.TryParse(Console.ReadLine(), out int id);

            var hall = _database.Halls.FirstOrDefault(h => h.Id == id);

            _database.Halls.Remove(hall);

            _database.SaveChanges();

            Console.WriteLine("Hall was successfully deleted...");
        }

        protected internal void EditHall()
        {

            Console.WriteLine("Enter the id of the hall...");

            int.TryParse(Console.ReadLine(), out int id);

            var hall = _database.Halls.FirstOrDefault(h => h.Id == id);

            if(hall == null)
            {

                Console.WriteLine("There is no hall with this id...");
                return;

            }

            Console.WriteLine("Enter the new number of seats:");

            if (!int.TryParse(Console.ReadLine(), out int seats) || seats <= 0)
            {

                Console.WriteLine("Invalid seat number.");

                return;

            }

            Console.WriteLine("Answer , is the hall VIP? \n(y/n ," +
                " only 1 letter \n y - yes \n n - no)");

            char answer = char.ToLower(Console.ReadKey().KeyChar);

            switch (answer) 
            {
                case 'y':

                    hall.IsVIP = true;
                    break;

                case 'n':

                    hall.IsVIP = false;
                    break;
            }

            _database.SaveChanges();

            Console.WriteLine("Hall edited successfully...");
        }

        protected internal void ViewHalls()
        {

            var halls = _database.Halls.ToList();

            if (!halls.Any())
            {

                Console.WriteLine("");
                return;

            }

            foreach (var hall in halls)
            {

                Console.WriteLine($"ID : {hall.Id} | Seats : {hall.Seats} | IsVIP : {hall.IsVIP}");

            }
        }
    }
}

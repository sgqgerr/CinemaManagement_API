using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaManagement.Data;
using CinemaManagement.Entities;
using Microsoft.EntityFrameworkCore.Storage;


namespace CinemaManagement.Services
{
    internal class FilmService
    {
        private readonly CinemaManagementDbContext _database =new CinemaManagementDbContext();    

        public FilmService(CinemaManagementDbContext database)
        {
            _database = database;
        }

        protected internal void CreateFilm() 
        {
            #region
            Console.WriteLine("Enter the film name...");

            var filmName = Console.ReadLine();

            Console.WriteLine("Enter the genre of the film...");

            var filmGenre = Console.ReadLine();

            Console.WriteLine("Enter the director`s name and surname...");

            var filmDirector = Console.ReadLine();

            Console.WriteLine("Enter the duration of the film...");

            int.TryParse(Console.ReadLine(), out int filmDuration);

            Console.WriteLine("Enter the release year of the film...");

            int.TryParse(Console.ReadLine(), out int filmReleaseYear);

            Console.WriteLine("Enter the age restriction for film...");

            int.TryParse(Console.ReadLine(), out int filmAgeRestriction);    

            Console.WriteLine("Enter the description of the film...");

            var filmDescription = Console.ReadLine();

            #endregion

            var film = new Film()
            {
                Name = filmName,
                Genre = filmGenre,
                Director = filmDirector,
                Duration = TimeSpan.FromMinutes(filmDuration),
                ReleaseYear = filmReleaseYear,
                AgeRestriction = filmAgeRestriction,
                Description = filmDescription

            };

            _database.Films.Add(film);
            _database.SaveChanges();

            Console.WriteLine("Film created sucsessfully...");

        }

        protected internal void DeleteFilm() 
        {
            Console.WriteLine("Enter ID of the film...");

            int.TryParse(Console.ReadLine(), out int id);

            var film = _database.Films.FirstOrDefault(f => f.Id == id);

            if(film == null)
            {
                Console.WriteLine("Invalid ID...");
                return;
            }

            _database.Films.Remove(film);

            _database.SaveChanges();

            Console.WriteLine("Film was deleted succesfully...");
        }

        protected internal void EditFilm()
        {

            Console.WriteLine("Enter ID of the film to edit...");

            int.TryParse(Console.ReadLine(), out int id);

            var film = _database.Films.FirstOrDefault(f => f.Id == id);

            if (film == null) 
            {

                return;

            }

            #region

            Console.WriteLine("Enter the new film name...");

            string newName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(newName)) 
            {

                film.Name = newName;

            }

            Console.WriteLine("Enter the new genre...");

            string newGenre = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(newGenre))
            {

                film.Genre = newGenre;

            }

            Console.WriteLine("Enter the new director...");

            string newDirector = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(newDirector))
            {

                film.Director = newDirector;

            }

            Console.WriteLine("Enter the new duration of the film (hh:mm)...");

            string input = Console.ReadLine();

            if (TimeSpan.TryParse(input, out TimeSpan newDuration))
            {

                film.Duration = newDuration;

            }
            else
            {

                Console.WriteLine("Invalid duration format.");

            }

            Console.WriteLine("Enter the new year of release...");

            int.TryParse(Console.ReadLine(), out int newYearOfRelease);

            if (string.IsNullOrWhiteSpace(newDirector))
            {

                film.ReleaseYear = newYearOfRelease;

            }

            Console.WriteLine("Enter the new age restriction...");

            var ageRestrictionInput = Console.ReadLine();

            if (int.TryParse(ageRestrictionInput, out int newAgeRestriction))
            {

                film.AgeRestriction = newAgeRestriction;

            }

            Console.WriteLine("Enter the new description of the film...");

            string newDescription = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(newDescription))
            {

                film.Description = newDescription;

            }

            #endregion

            _database.SaveChanges();

            Console.WriteLine("Film updated successfully...");

        }

        protected internal void ViewFilms()
        {

            var films = _database.Films.ToList();

            if (!films.Any()) 
            {

                Console.WriteLine("There are no more films available...");

                return;
            }

            foreach (var film in films) 
            {

                Console.WriteLine($"ID : {film.Id} | Name : {film.Name} | " +
                    $"Genre : {film.Genre} | Director : {film.Director} |" +
                    $"Duretion : {film.Duration} | Release year : {film.ReleaseYear} | " +
                    $"Description : {film.Description}");

            }

        }
    }
}

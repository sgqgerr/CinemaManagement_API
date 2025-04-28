namespace CinemaManagement_API.Models
{
    public class AddFilmModel
    {
        public string Name { get; set; }

        public string Genre { get; set; }

        public string Director { get; set; }

        public TimeSpan Duration { get; set; }

        public int? ReleaseYear { get; set; }

        public int? AgeRestriction { get; set; }

        public string Description { get; set; }
    }
}

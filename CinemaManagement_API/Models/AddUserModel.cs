namespace CinemaManagement_API.Models
{
    public class AddUserModel
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public bool IsAdmin { get; set; }

        public List<string> AccumulatedDiscounts { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class User
    {
        public User(){}

        public int Id { get; set; } 

        public string Name {  get; set; }

        public string Email { get; set; }

        public bool IsAdmin { get; set; }

        public List<string> AccumulatedDiscounts {  get; set; }

    }
}

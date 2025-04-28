using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Film
    {

        public Film() { }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Genre { get; set; } 
        
        public string Director { get; set; }

        public TimeSpan Duration { get; set; }

        public int ReleaseYear { get; set; }

        public int AgeRestriction { get; set; }

        public string Description { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Session
    {
        public Session() { }

        public int Id { get; set; } 

        public int FilmId { get; set; }
        public Film? CurrentFilm {  get; set; }

        public int HallId { get; set; }

        public Hall? CurrentHall { get; set; }

        public DateTime DateOfSession { get; set; }

        public int PriceOfTicket { get; set; }

        public bool Status { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Hall
    {
        public Hall() { }

        public int Id { get; set; }

        public int Seats { get; set; }

        public bool IsVIP { get; set; }

    }
}

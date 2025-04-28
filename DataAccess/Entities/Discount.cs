using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Discount
    {
        public Discount() { }

        public int Id { get; set; }

        public string DiscountSuggetion {  get; set; }

        public string DiscountForRegularCustomer { get; set; }

    }
}

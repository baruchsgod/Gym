using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gym.Models
{
    public class Purchase
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public decimal Total { get; set; }

        public DateTime Date { get; set; }

        

        public ApplicationUser ApplicationUser { get; set; }

        public string ApplicationUserId { get; set; }

        public Supplement Supplement { get; set; }

        public int SupplementId { get; set; }
    }
}
using Gym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gym.ViewModel
{
    public class CustomerReservesViewModel
    {
        public ApplicationUser ApplicationUser { get; set; }

        public List<Reserve> Reserves { get; set; }

        public List<Activity> Activities { get; set; }
    }
}
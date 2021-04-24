using Gym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gym.ViewModel
{
    public class CustRoutinesViewModel
    {
        public ApplicationUser User { get; set; }

        public List<Routine> Routine { get; set; }
    }
}
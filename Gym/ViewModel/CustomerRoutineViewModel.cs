using Gym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gym.ViewModel
{
    public class CustomerRoutineViewModel
    {
        public ApplicationUser User { get; set; }

        public Routine Routine { get; set; }
    }
}
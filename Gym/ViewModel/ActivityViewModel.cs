using Gym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gym.ViewModel
{
    public class ActivityViewModel
    {
        public Activity Activity { get; set; }

        public List<Exercise> Exercises { get; set; }

        public List<ApplicationUser> Trainers { get; set; }
    }
}
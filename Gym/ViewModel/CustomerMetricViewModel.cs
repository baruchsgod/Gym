using Gym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gym.ViewModel
{
    public class CustomerMetricViewModel
    {
        public ApplicationUser User { get; set; }

        public Metric Metric { get; set; }
    }
}
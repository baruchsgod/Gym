using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gym.Models
{
    public class Calendar
    {
        public int Id { get; set; }
        public DateTime ActivityDate { get; set; }
        public string Activity { get; set; }
    }
}
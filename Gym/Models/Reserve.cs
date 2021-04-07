using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gym.Models
{
    public class Reserve
    {
        public int Id { get; set; }

        public Activity Activity { get; set; }

        public int ActivityId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        [Display(Name = "User Id")]
        public string ApplicationUserId { get; set; }

        public DateTime Date { get; set; }
    }
}
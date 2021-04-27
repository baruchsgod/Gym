using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gym.Models
{
    public class Error
    {
        public int Id { get; set; }

        [Display(Name = "Error Name")]
        public string Description { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        [Display(Name = "User Id")]
        public string ApplicationUserId { get; set; }

        public DateTime Date { get; set; }
    }
}
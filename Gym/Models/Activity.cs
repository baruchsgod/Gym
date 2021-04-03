using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gym.Models
{
    public class Activity
    {
        public int Id { get; set; }

        [Range(2021,2030)]
        public int Year { get; set; }

        [Required]
        public string Month { get; set; }

        [Range(1,31)]
        public int day { get; set; }

        [Required]
        [Display(Name = "Activity Name")]
        public string Description { get; set; }

        [Range(1,25)]
        public int Quantity { get; set; }

        [Range(1,12)]
        public int Hour { get; set; }

        [Required]
        public string Minutes { get; set; }

        [Required]
        [Display(Name = "AM / PM")]
        public string Shift { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        [Required]
        [Display(Name = "Instructor")]
        public string ApplicationUserId { get; set; }


        [Range(1000,5000)]
        public decimal Price { get; set; }

        public int? Reserve { get; set; }

        [Range(1,12)]
        public int? MonthNum { get; set; }
    }
}
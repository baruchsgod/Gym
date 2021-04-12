using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gym.Models
{
    public class Metric
    {
        public int Id { get; set; }

        [Display(Name = "Mass Index")]
        public double MassIndex { get; set; }

        
        public double Weight { get; set; }

        public double Chest { get; set; }

        public double Waist { get; set; }

        [Display(Name = "Right Bicep")]
        public double RightBicep { get; set; }

        [Display(Name = "Left Bicep")]
        public double LeftBicep { get; set; }

        [Display(Name = "Right Calf")]
        public double RightCalf { get; set; }

        [Display(Name = "Left Calf")]
        public double LeftCalf { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        [Display(Name = "User Id")]
        public string ApplicationUserId { get; set; }
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Metric Month")]
        public string Month { get; set; }

        [Range(2021,2021)]
        public int Year { get; set; }
    }
}
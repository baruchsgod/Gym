using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gym.Models
{
    public class Routine
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Type of Workout")]
        public string Type { get; set; }

        [Display(Name = "Begin Day")]
        public DateTime BeginWeek { get; set; }

        [Display(Name = "End Day")]
        public DateTime EndWeek { get; set; }

        [Required]
        [Display(Name = "Warm Up Workout")]
        public List<string> WarmUp { get; set; }

        [Required]
        [Display(Name = "Core Body Workout")]
        public List<string> CoreBody { get; set; }

        [Required]
        [Display(Name = "Upper Body Workout")]
        public List<string> UpperBody { get; set; }

        [Required]
        [Display(Name = "Lower Body Workout")]
        public List<string> LowerBody { get; set; }

        [Required]
        [Display(Name = "Cool Down Workout")]
        public List<string> CoolDown { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        [Display(Name = "User Id")]
        public string ApplicationUserId { get; set; }
    }
}
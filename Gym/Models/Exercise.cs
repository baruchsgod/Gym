using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gym.Models
{
    public class Exercise
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "You must enter an activity")]
        [Display(Name = "Class Name")]
        public string Name { get; set; }
    }
}
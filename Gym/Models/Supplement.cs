using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gym.Models
{
    public class Supplement
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Description must be included")]
        [StringLength(100)]
        public string Description { get; set; }


        public decimal Price { get; set; }

        [Required]
        public string Image { get; set; }
    }
}
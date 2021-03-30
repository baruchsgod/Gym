using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gym.Models
{
    public class Membership
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the Membership Type")]
        [Display(Name = "Membership Type")]
        public string MembershipType { get; set; }

        [Required(ErrorMessage = "Please enter the price before move on")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please enter the number of months covered with the payment")]
        [Display(Name = "Months Covered")]
        [Range(1,12)]
        public int DurationInMonths { get; set; }

        [Required(ErrorMessage = "Please enter the discount of the payment")]
        [Display(Name = "Discount")]
        [Range(0,30)]
        public int DiscountRate { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gym.Models
{
    public class Payment
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name on the Card")]
        public string NameCard { get; set; }

        [Required]
        [Display(Name = "Card Number")]
        [Range(100000000000, 99999999999999999, ErrorMessage = "Your Credit Card must be between 12 and 17 digits")]
        public long CardNumber { get; set; }

        
        [Required]
        [Display(Name = "Payment Type")]
        public string PaymentType { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Display(Name = "Expiration Date")]
        [MinDate]
        public DateTime ExpirationDate { get; set; }

        [Display(Name = "CVV")]
        [Range(100,9999, ErrorMessage = "The CVV number must be between 100 and 9999")]
        public int Cvv { get; set; }

        [Required]
        public string Address { get; set; }


        public string City { get; set; }

        [Required]
        public string Province { get; set; }

        [Display(Name = "ZIP")]
        public int Zip { get; set; }


        public DateTime DatePurchase { get; set; }


        [Required]
        [Display(Name = "Purchase Total")]
        public decimal Total { get; set; }

    }
}
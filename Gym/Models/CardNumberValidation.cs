using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gym.Models
{
    public class CardNumberValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var payment = (Payment)validationContext.ObjectInstance;

            if (payment.CardNumber >= 100000000000 && payment.CardNumber <= 99999999999999999)
            {
                return new ValidationResult("Your Credit Card must between 12 and 17 digits");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
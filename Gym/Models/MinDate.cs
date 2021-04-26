using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gym.Models
{
    public class MinDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var payment = (Payment)validationContext.ObjectInstance;

            if (DateTime.Now >= payment.ExpirationDate)
            {
                return new ValidationResult("Your Method of Payment seems to be overdue, please use other method");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
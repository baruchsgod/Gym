using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gym.Models
{
    public class ValidateBeginDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var routine = (Routine)validationContext.ObjectInstance;

            if (routine.BeginWeek >= routine.EndWeek)
            {
                return new ValidationResult("Your begin day should not be higher or equal to the end day.");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gym.Models
{
    public class MinActivityQuantity : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var activity = (Activity)validationContext.ObjectInstance;

            

            if (activity.Id == 0)
            {
                if (activity.Quantity == null)
                {
                    return new ValidationResult("Quantity is a required field");
                }

                if (activity.Quantity > 25 || activity.Quantity < 1)
                {
                    return new ValidationResult("The maximum capacity of every room is 25 and the mininum is 1");
                }

                return ValidationResult.Success;

            }
            else
            {


                
                
                

                if (activity.Quantity == null)
                {
                    return new ValidationResult("Quantity is a required field");
                }

                if (activity.Quantity > 25 || activity.Quantity < 1)
                {
                    return new ValidationResult("The maximum capacity of every room is 25 and the mininum is 1");
                }

                var minimumQuantity = activity.Reserve;

                if (activity.Reserve == null)
                {
                    minimumQuantity = 0;
                }
                

                if (activity.Quantity < minimumQuantity)
                {
                    return new ValidationResult("There are " + minimumQuantity + " people registered already, please select a quantity equal or higher than this");
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly_App.Models
{
    public class Above18:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
             if (customer.MembershipTypeId == MembershipType.PayAsYouGo ||
                customer.MembershipTypeId == MembershipType.unknown)
            {
                return ValidationResult.Success;
            }
             if(customer.DateOfBirth == null)
            {
                return new ValidationResult("Birthday is Required");
            }

            var age = DateTime.Today.Year - customer.DateOfBirth.Value.Year;
            return (age >= 18) ? ValidationResult.Success :
                new ValidationResult("Customer Must Be Above 18 to go On membership");
        }
      
    }
    
}
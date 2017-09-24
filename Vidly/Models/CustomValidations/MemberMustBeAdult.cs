using AutoMapper;
using System;
using System.ComponentModel.DataAnnotations;
using Vidly.DTOs;

namespace Vidly.Models
{
    public class MemberMustBeAdult : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext vContext)
        {
            var customer = new Customer();
            if (vContext.ObjectType == typeof(Customer)) {
                customer = (Customer)vContext.ObjectInstance;
            }
            else {
                customer = Mapper.Map((CustomerDTO)vContext.ObjectInstance,customer);
            }
            
            if (customer.MembershipTypeId == 0 || customer.MembershipTypeId == 1)
            {
                return ValidationResult.Success;
            }

            if (customer.Birthdate == null)
                return new ValidationResult("Birthdate is required.");

            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;
            return age < 18 ? new ValidationResult("Customer needs to be atleast 18 years old to have this membership.") : ValidationResult.Success; 
        }
    }
}
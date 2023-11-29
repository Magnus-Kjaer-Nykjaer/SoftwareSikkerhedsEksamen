using System;
using System.ComponentModel.DataAnnotations;
using System.IO.Compression;
using System.Linq;

namespace WebGoatCore.Controllers
{
    public class PostalCode
    {
        private string? postalCode;
        public PostalCode(string? postalCode)
        {
            IsPostalCodeValid(postalCode);
            this.postalCode = postalCode;
        }

        public string? GetPostalCode()
        {
            return postalCode;
        }

        private void IsPostalCodeValid(string? postalCode)
        {
            if(postalCode is not null)
            {
                if(!LengthCheck(postalCode))
                    throw new ValidationException("PostalCode is not valid");

                var isOnlyNumbers = postalCode.All(c => Char.IsNumber(c));
                if(!isOnlyNumbers)
                    throw new ValidationException("PostalCode is not valid");
            }
        }

        private bool LengthCheck(string input)
        {
            if(input.Length <= 11 && input.Length >= 2)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }
    }
}
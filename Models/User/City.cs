using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WebGoatCore.Controllers
{
    public class City
    {
         private string? city;
        public City(string? city)
        {
            IsCityValid(city);
            this.city = city;
        }

        public string? GetCity()
        {
            return city;
        }

        private void IsCityValid(string? city)
        {
            if(city is not null)
            {
                if(!LengthCheck(city))
                    throw new ValidationException("City is not valid");

                var isOnlyLetters = city.All(c => Char.IsLetter(c));
                if(!isOnlyLetters)
                    throw new ValidationException("City is not valid");
            }
        }

        private bool LengthCheck(string input)
        {
            if(input.Length <= 64 && input.Length >= 2)
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
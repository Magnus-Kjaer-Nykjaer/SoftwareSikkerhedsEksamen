using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WebGoatCore.Controllers
{
    public class Region
    {
        private string? region;
        public Region(string? region)
        {
            IsRegionValid(region);
            this.region = region;
        }

        public string? GetRegion()
        {
            return region;
        }

        private void IsRegionValid(string? region)
        {
            if(region is not null)
            {
                if(!LengthCheck(region))
                    throw new ValidationException("Region is not valid");

                var isOnlyLetters = region.All(c => Char.IsLetter(c));
                if(!isOnlyLetters)
                    throw new ValidationException("Region is not valid");
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
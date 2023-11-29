using System;
using System.ComponentModel.DataAnnotations;

namespace WebGoatCore.Controllers
{
    public class Address
    {
         private string? address;
        public Address(string? address)
        {
            IsAddressValid(address);
            this.address = address;
        }

        public string? GetAddress()
        {
            return address;
        }

        private void IsAddressValid(string? address)
        {
            if(address is not null)
                if(!LengthCheck(address))
                    throw new ValidationException("Address is not valid");
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
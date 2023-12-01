using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WebGoatCore.Controllers
{
  public class Country
  {
    private string? country;
    public Country(string? country)
    {
      IsCountryValid(country);
      this.country = country;
    }

    public string? GetCountry()
    {
      return country;
    }

    private void IsCountryValid(string? country)
    {
      if (country is not null)
      {
        if (!LengthCheck(country))
          throw new ValidationException("Country is not valid");

        var isOnlyLetters = country.All(c => Char.IsLetter(c));
        if (!isOnlyLetters)
          throw new ValidationException("Country is not valid");
      }
    }

    private bool LengthCheck(string input)
    {
      if (input.Length <= 64 && input.Length >= 2)
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
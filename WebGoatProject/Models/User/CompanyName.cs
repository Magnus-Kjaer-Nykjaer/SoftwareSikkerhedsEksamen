using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WebGoatCore.Controllers
{
  public class CompanyName
  {
    private string companyName;

    public CompanyName(string companyName)
    {
      IsCompanyNameValid(companyName);
      this.companyName = companyName;
    }

    public string GetCompanyName()
    {
      return companyName;
    }

    private void IsCompanyNameValid(string companyName)
    {
      if (string.IsNullOrWhiteSpace(companyName)) //Tjekker for om companyName er null eller tomt
        throw new ValidationException("Company name is not valid");

      if (!LengthCheck(companyName)) //Tjekker for om min og max længde er indenfor 2 og 20 karaktere
        throw new ValidationException("Company name is not valid");

      var isLetters = companyName.All(c => Char.IsLetter(c)); //Tjekker for om companyName kun består af bogstaver
      if (!isLetters)
      {
        throw new ValidationException("Company name is not valid");
      }
    }
    private bool LengthCheck(string input)
    {
      if (input.Length <= 20 && input.Length >= 2)
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
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WebGoatCore.Controllers
{
  public class Username
  {
    private string username;

    public Username(string username)
    {
      IsUsernameValid(username);
      this.username = username;
    }

    public string GetUsername()
    {
      return username;
    }

    private void IsUsernameValid(string username)
    {
      if (string.IsNullOrWhiteSpace(username)) //Tjekker for om username er null eller tomt
        throw new ValidationException("Username can not be null");

      if (!LengthCheck(username)) //Tjekker for om min og max længde er indenfor 2 og 20 karaktere
        throw new ValidationException("Username is not within lenght parameters");

      var isLettersOrNumbers = username.All(c => Char.IsLetter(c) || Char.IsNumber(c)); //Tjekker for om username kun består af bogstaver og tal
      if (!isLettersOrNumbers)
      {
        throw new ValidationException("Username can only be letters and numbers");
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
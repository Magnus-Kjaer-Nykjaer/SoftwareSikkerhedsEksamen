using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WebGoatCore.Controllers
{
  public class Password
  {
    private string password;
    public Password(string password)
    {
      IsPasswordValid(password);
      this.password = password;
    }

    public string GetPassword()
    {
      return password;
    }

    private void IsPasswordValid(string password)
    {
      if (string.IsNullOrWhiteSpace(password)) //Tjekker for om password er null eller tomt
        throw new ValidationException("Password is not valid");

      if (LengthCheck(password)) //Tjekker for min længde på 12 og max længde på 64
        throw new ValidationException("Password is not valid");

      var hasUppercase = password.Any(char.IsUpper); //Tjekker om password indeholder store bogstaver
      if (!hasUppercase)
        throw new ValidationException("Password is not valid");

      var hasLowerCase = password.Any(char.IsLower); //Tjekker om password indeholder små bogstaver
      if (!hasLowerCase)
        throw new ValidationException("Password is not valid");

      var hasNumbers = password.Any(char.IsNumber); //Tjekker om password indeholder tal
      if (!hasNumbers)
        throw new ValidationException("Password is not valid");

      var hasSpecialCharacters = password.Any(c => !char.IsLetterOrDigit(c)); //Tjekker om password indeholder special tegn
      if (!hasSpecialCharacters)
        throw new ValidationException("Password is not valid");
    }

    private bool LengthCheck(string input)
    {
      if (input.Length <= 64 && input.Length >= 12)
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
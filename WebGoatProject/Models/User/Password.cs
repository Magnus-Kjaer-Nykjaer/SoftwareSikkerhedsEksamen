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

    public string GetPassword() //Bruge dette metode kald til at få retuneret værdien
    {
      return password;
    }

    private void IsPasswordValid(string password)
    {
      if (string.IsNullOrWhiteSpace(password)) //Tjekker for om password er null eller tomt
        throw new ValidationException("Password is null or empty");

      if (!LengthCheck(password)) //Tjekker for min længde på 12 og max længde på 64
        throw new ValidationException("Password is not within lenght parameters");

      var hasUppercase = password.Any(char.IsUpper); //Tjekker om password indeholder store bogstaver
      if (!hasUppercase)
        throw new ValidationException("Password does not contain an upper case letter");

      var hasLowerCase = password.Any(char.IsLower); //Tjekker om password indeholder små bogstaver
      if (!hasLowerCase)
        throw new ValidationException("Password does not contain a lower case letter");

      var hasNumbers = password.Any(char.IsNumber); //Tjekker om password indeholder tal
      if (!hasNumbers)
        throw new ValidationException("Password does not contain a number");

      var hasSpecialCharacters = password.Any(c => !char.IsLetterOrDigit(c)); //Tjekker om password indeholder special tegn
      if (!hasSpecialCharacters)
        throw new ValidationException("Password does not contain a special character");
    }

    private bool LengthCheck(string input) //Bruges til at tjekke om passwordet er inden for længde specifikationerne
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
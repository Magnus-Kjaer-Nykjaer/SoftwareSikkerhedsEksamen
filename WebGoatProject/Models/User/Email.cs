using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace WebGoatCore.Controllers
{
  public class Email
  {
    private string email;

    public Email(string email)
    {
      IsEmailValid(email);
      this.email = email;
    }

    public string GetEmail()
    {
      return email;
    }

    private void IsEmailValid(string email)
    {
      if (string.IsNullOrWhiteSpace(email)) //Tjekker for om email er null eller tomt
        throw new ValidationException("Email is not valid");

      if (!LengthCheck(email)) //Tjekker for om min og max længde er indenfor 2 og 30 karaktere
        throw new ValidationException("Email is not valid");

      try
      {
        var isValid = Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)); //Tjekker for om email er en valid email

        if (!isValid)
          throw new ValidationException("Email is not valid");
      }
      catch (RegexMatchTimeoutException)
      {
        throw new RegexMatchTimeoutException("Regex check ran in to a timeout");
      }
    }

    private bool LengthCheck(string input)
    {
      if (input.Length <= 30 && input.Length >= 2)
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
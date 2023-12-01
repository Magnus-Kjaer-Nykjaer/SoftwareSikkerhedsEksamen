using WebGoatCore.Controllers;

namespace SoftwareSikkerhedsEksamen.Tests;

public class UserUnitTest
{
  [Theory]
  [InlineData("hej")]
  [InlineData("DetteSkulleGernveVaereForLangt")]
  [InlineData("hej123")]
  [InlineData("a")]
  [InlineData("VirkerIkke'")]
  public void UsernameTest(string input)
  {
    var username = new Username(input);
  }
}
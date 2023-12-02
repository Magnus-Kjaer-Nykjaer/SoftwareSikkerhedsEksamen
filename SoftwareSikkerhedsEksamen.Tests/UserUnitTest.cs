using WebGoatCore.Controllers;

namespace SoftwareSikkerhedsEksamen.Tests;

public class UserUnitTest
{
  [Theory]
  [InlineData("hej")]
  [InlineData("DetteSkulleGernveV�reForLangt")]
  [InlineData("hej123")]
  [InlineData("a")]
  [InlineData("VirkerIkke'")]
  public void UsernameTest(string input)
  {
    var username = new Username(input);
  }

  [Theory]
  [InlineData("")] //Skal fejle fordi der ikke er noget i den
  [InlineData("11tegne!!!!")] //Skal fejle fordi den er forkort
  [InlineData("DetteSkulleGernveV�reForLangt!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!111111")] //Skal fejle fordi den er for lang
  [InlineData("denneskalfejlefordiderikkeertal!1")] //Skal fejle fordi der mangler store bogstaver
  [InlineData("DENNESKALFEJLEFORDIDERMANGLESM�BOGSTAVER!1")] //Skal fejle fordi der mangler sm� bostaver
  [InlineData("Denneskalfejlefordiderikkeertal!")] //Skal fejle fordi der mangler tal
  [InlineData("Denneskalfejlefordiderikkeertegn1")] //Skal fejle fordi der mangler tegn
  [InlineData("6iN#WYZO*FVe%Rt68U8l'")] //Skulle ikke fejle
  public void PasswordTest(string input)
  {
    var password = new Password(input);
  }
}
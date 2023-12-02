namespace WebGoatCore.Controllers
{
  public class RegisterCustomer
  {
    public required Username Username { get; set; }

    public required Email Email { get; set; }

    public required CompanyName CompanyName { get; set; }

    public required Password Password { get; set; }

    public Address? Address { get; set; }

    public City? City { get; set; }

    public Region? Region { get; set; }

    public PostalCode? PostalCode { get; set; }

    public Country? Country { get; set; }
  }
}
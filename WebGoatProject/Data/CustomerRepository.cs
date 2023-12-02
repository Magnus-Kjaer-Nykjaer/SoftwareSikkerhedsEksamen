using System;
using System.Linq;
using WebGoatCore.Controllers;
using WebGoatCore.Models;

namespace WebGoatCore.Data
{
  public class CustomerRepository
  {
    private readonly NorthwindContext _context;

    public CustomerRepository(NorthwindContext context)
    {
      _context = context;
    }

    public Customer? GetCustomerByUsername(string username)
    {
      return _context.Customers.FirstOrDefault(c => c.ContactName == username);
    }

    public Customer GetCustomerByCustomerId(string customerId)
    {
      return _context.Customers.Single(c => c.CustomerId == customerId);
    }

    public void SaveCustomer(Customer customer)
    {
      _context.Update(customer);
      _context.SaveChanges();
    }

    public string CreateCustomer(RegisterCustomer registerCustomer)
    {
      try
      {
        var customerId = GenerateCustomerId(registerCustomer.CompanyName.GetCompanyName());
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        var customer = new Customer()
        {
          CompanyName = registerCustomer.CompanyName.GetCompanyName(),
          CustomerId = customerId,
          ContactName = registerCustomer.Username.GetUsername(),
          Address = registerCustomer.Address.GetAddress(),
          City = registerCustomer.City.GetCity(),
          Region = registerCustomer.Region.GetRegion(),
          PostalCode = registerCustomer.PostalCode.GetPostalCode(),
          Country = registerCustomer.Country.GetCountry()
        };
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        _context.Customers.Add(customer);
        _context.SaveChanges();
        return customerId;
      }
      catch
      {
        throw;
      }
    }

    public bool CustomerIdExists(string customerId)
    {
      return _context.Customers.Any(c => c.CustomerId == customerId);
    }

    /// <summary>Returns an unused CustomerId based on the company name</summary>
    /// <param name="companyName">What we want to base the CompanyId on.</param>
    /// <returns>An unused CustomerId.</returns>
    private string GenerateCustomerId(string companyName)
    {
      var random = new Random();
      var customerId = companyName.Replace(" ", "");
      customerId = (customerId.Length >= 5) ? customerId.Substring(0, 5) : customerId;
      while (CustomerIdExists(customerId))
      {
        customerId = customerId.Substring(0, 4) + "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ"[random.Next(35)];
      }
      return customerId;
    }
  }
}

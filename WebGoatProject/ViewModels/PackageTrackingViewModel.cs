using System.Collections.Generic;
using WebGoatCore.Models;

namespace WebGoatCore.ViewModels
{
  public class PackageTrackingViewModel
  {
    public IEnumerable<Order>? Orders { get; set; }
    public string? SelectedCarrier { get; set; }
    public string? SelectedTrackingNumber { get; set; }
  }
}

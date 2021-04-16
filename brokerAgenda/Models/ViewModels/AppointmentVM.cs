using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace brokerAgenda.Models.ViewModels
{
  public class AppointmentVM
  {
    public Appointment Appointment { get; set; }
    public IEnumerable<SelectListItem> BrokerDropDown { get; set; }
    public IEnumerable<SelectListItem> CustomerDropDown { get; set; }
  }
}

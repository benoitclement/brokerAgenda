using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace brokerAgenda.Models.ViewModels
{
  public class BrokerDetailsVM
  {
    public Broker Broker { get; set; }
    //public IEnumerable<SelectListItem> BrokerAppointmentsDropDown { get; set; }
    public IEnumerable<Appointment> AppointmentList { get; set; }
  }
}

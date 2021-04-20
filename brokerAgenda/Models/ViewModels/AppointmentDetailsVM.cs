using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace brokerAgenda.Models.ViewModels
{
  public class AppointmentDetailsVM
  {
    public Appointment Appointment { get; set; }
    public string BrokerName { get; set; }
    public string CustomerName { get; set; }
  }
}

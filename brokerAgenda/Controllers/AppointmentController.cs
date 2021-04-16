using brokerAgenda.Data;
using brokerAgenda.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace brokerAgenda.Controllers
{
  public class AppointmentController : Controller
  {
    private readonly BrokerAppDbContext _db;
    public AppointmentController(BrokerAppDbContext db)
    {
      _db = db;
    }
    public IActionResult Index()
    {
      IEnumerable<Appointment> objList = _db.Appointments;
      foreach(var obj in objList)
      {
        obj.IdBrokerNavigation = _db.Brokers.FirstOrDefault(b => b.Id == obj.IdBroker);
        obj.IdCustomerNavigation = _db.Customers.FirstOrDefault(c => c.Id == obj.IdCustomer);
      }
      return View();
    }
  }
}

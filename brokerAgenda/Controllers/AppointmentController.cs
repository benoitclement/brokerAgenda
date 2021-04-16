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
      return View(objList);
    }
    
    // GET-Details
    public IActionResult Details(int? id)
    {
      Appointment AppointmentDetails = new Appointment();
      if (id == null || id == 0)
      {
        return NotFound();
      }
      AppointmentDetails = _db.Appointments.Find(id);
      if (AppointmentDetails == null)
      {
        return NotFound();
      }
      AppointmentDetails.IdBrokerNavigation = _db.Brokers.FirstOrDefault(b => b.Id == AppointmentDetails.IdBroker);
      AppointmentDetails.IdCustomerNavigation = _db.Customers.FirstOrDefault(c => c.Id == AppointmentDetails.IdCustomer);
      return View(AppointmentDetails);
    }

  }
}

using brokerAgenda.Data;
using brokerAgenda.Models;
using brokerAgenda.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
      foreach (var obj in objList)
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

    // Get-Create
    public IActionResult Create()
    {
      AppointmentVM newAppointmentVM = new AppointmentVM()
      {
        Appointment = new Appointment(),
        BrokerDropDown = _db.Brokers.Select(broker => new SelectListItem
        {
          Text = broker.Lastname + " " + broker.Firstname,
          Value = broker.Id.ToString()
        }),
        CustomerDropDown = _db.Customers.Select(customer => new SelectListItem
        {
          Text = customer.Lastname + " " + customer.Firstname,
          Value = customer.Id.ToString()
        })
      };
      return View(newAppointmentVM);
    }

    // POST-Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(AppointmentVM obj)
    {
      if (ModelState.IsValid)
      {
        _db.Appointments.Add(obj.Appointment);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
      return View(obj);

    }
  }
}

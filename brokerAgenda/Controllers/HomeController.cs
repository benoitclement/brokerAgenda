using brokerAgenda.Data;
using brokerAgenda.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace brokerAgenda.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, BrokerAppDbContext db)
    {
      _logger = logger;
      _db = db;
    }
    private readonly BrokerAppDbContext _db;
    //public HomeController(BrokerAppDbContext db)
    //{
    //  _db = db;
    //}
    //public IActionResult Index(string sortOrder, string searchString)
    //{
    //  IEnumerable<Appointment> appointmentList = _db.Appointments;
    //  foreach (var appointment in appointmentList)
    //  {
    //    appointment.IdBrokerNavigation = _db.Brokers.FirstOrDefault(b => b.Id == appointment.IdBroker);
    //    appointment.IdCustomerNavigation = _db.Customers.FirstOrDefault(c => c.Id == appointment.IdCustomer);
    //  }
    //  if (!String.IsNullOrEmpty(searchString))
    //  {
    //    searchString = searchString.ToLower();
    //    appointmentList = appointmentList.Where(a =>
    //      a.IdBrokerNavigation.Lastname.ToLower().Contains(searchString)
    //      || a.IdBrokerNavigation.Firstname.ToLower().Contains(searchString)
    //      || a.IdCustomerNavigation.Lastname.ToLower().Contains(searchString)
    //      || a.IdCustomerNavigation.Firstname.ToLower().Contains(searchString)
    //    );
    //  }
    //  appointmentList = sortOrder switch //new syntax for switch _ is default
    //  {
    //    "BrokerName" => appointmentList.OrderBy(row => row.IdBrokerNavigation.Lastname),
    //    "CustomerName" => appointmentList.OrderBy(row => row.IdCustomerNavigation.Lastname),
    //    "DateTime" => appointmentList.OrderBy(row => row.DateHour),
    //    _ => appointmentList.OrderBy(row => row.IdBrokerNavigation.Lastname),
    //  };
    //  return View(appointmentList);
    //}
    public IActionResult Index()
    {
      return View();
    }

    public IActionResult Help()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}

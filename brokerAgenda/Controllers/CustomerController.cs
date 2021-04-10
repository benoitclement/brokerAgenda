using brokerAgenda.Data;
using brokerAgenda.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace brokerAgenda.Controllers
{
  public class CustomerController : Controller
  {
    private readonly BrokerAppDbContext _db;

    public CustomerController(BrokerAppDbContext db)
    {
      _db = db;
    }
    public IActionResult Index()
    {
      IEnumerable<Customer> objList = _db.Customers;
      return View(objList);
    }

    // GET-Create
    public IActionResult Create()
    {
      return View();
    }
    
    // POST-Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Customer obj)
    {
      _db.Customers.Add(obj);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}

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
      if (ModelState.IsValid)
      {
        _db.Customers.Add(obj);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
      return View(obj);
    }

    // GET-Details
    public IActionResult Details(int? id)
    {
      var obj = _db.Customers.Find(id);
      if (obj == null)
      {
        return NotFound();
      }
      return View(obj);
    }

    //GET Delete
    public IActionResult Delete(int? id)
    {
      if (id == null || id == 0)
      {
        return NotFound();
      }
      var obj = _db.Customers.Find(id);
      if (obj == null)
      {
        return NotFound();
      }
      return View(obj);
    }
    
    //POST Delete
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePost(int? id)
    {
      var obj = _db.Customers.Find(id);
      if (obj == null)
      {
        return NotFound();
      }
      _db.Customers.Remove(obj);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    //GET Update
    public IActionResult Update(int? id)
    {
      if (id == null || id == 0)
      {
        return NotFound();
      }
      var obj = _db.Customers.Find(id);
      if (obj == null)
      {
        return NotFound();
      }
      return View(obj);
    }

    //POST Update
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Update(Customer obj)
    {
      if (ModelState.IsValid)
      {
        _db.Customers.Update(obj);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
      return View(obj);
    }

  }
}

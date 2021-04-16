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
    //GET-index
    public IActionResult Index(string SortOrder)
    {
      IEnumerable<Customer> objList = _db.Customers;
      objList = SortOrder switch //new syntax for switch _ is default
      {
        "Id" => objList.OrderBy(o => o.Id),
        "LastName" => objList.OrderBy(o => o.Lastname),
        "FirstName" => objList.OrderBy(o => o.Firstname),
        _ => objList.OrderBy(o => o.Id),
      };
      return View(objList);
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
        TempData["modifiedId"] = obj.Id;
        TempData["modification"] = "create";
        TempData["customerName"] = obj.Firstname + " " + obj.Lastname;
        return RedirectToAction("Index");
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
      TempData["modification"] = "delete";
      TempData["customerName"] = obj.Firstname + " " + obj.Lastname;
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

        TempData["modifiedId"] = obj.Id;
        TempData["modification"] = "update";
        TempData["customerName"] = obj.Firstname + " " + obj.Lastname;
        return RedirectToAction("Index");
      }
      return View(obj);
    }

  }
}

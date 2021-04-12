using brokerAgenda.Data;
using brokerAgenda.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace brokerAgenda.Controllers
{
  public class BrokerController : Controller
  {
    private readonly BrokerAppDbContext _db;

    public BrokerController(BrokerAppDbContext db)
    {
      _db = db;
    }
    // Default GET for Index
    public IActionResult Index()
    {
      IEnumerable<Broker> objList = _db.Brokers;
      return View(objList);
    }

    // GET-Details
    public IActionResult Details(int? id)
    {
      var obj = _db.Brokers.Find(id);
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
    public IActionResult Create(Broker obj)
    {
      if (ModelState.IsValid)
      {
        _db.Brokers.Add(obj);
        _db.SaveChanges();
        return RedirectToAction("Index", obj);

      }
      return View(obj);
    }

    // GET-Delete
    public IActionResult Delete(int? id)
    {
      if (id == null || id == 0)
      {
        return NotFound();
      }
      var obj = _db.Brokers.Find(id);
      if (obj == null)
      {
        return NotFound();
      }
      return View(obj);
    }

    // POST-Delete
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePost(int? id)
    {
      var obj = _db.Brokers.Find(id);
      if (obj == null)
      {
        return NotFound();
      }
      _db.Brokers.Remove(obj);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    // GET-Update
    public IActionResult Update(int? id)
    {
      if (id == null || id == 0)
      {
        return NotFound();
      }
      var obj = _db.Brokers.Find(id);
      if (obj == null)
      {
        return NotFound();
      }
      return View(obj);
    }

    // POST-Update
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Update(Broker obj)
    {
      if (ModelState.IsValid)
      {
        _db.Brokers.Update(obj);
        _db.SaveChanges();
        return RedirectToAction("Index");

      }
      return View(obj);
    }
  }
}

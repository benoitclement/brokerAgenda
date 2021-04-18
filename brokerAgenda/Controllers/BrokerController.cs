﻿using brokerAgenda.Data;
using brokerAgenda.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
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
    // GET-Index
    public IActionResult Index(string SortOrder)
    {
      IEnumerable<Broker> brokerList = _db.Brokers;
      brokerList = SortOrder switch //new syntax for switch _ is default
      {
        "Id" => brokerList.OrderBy(row => row.Id),
        "LastName" => brokerList.OrderBy(row => row.Lastname),
        "FirstName" => brokerList.OrderBy(row => row.Firstname),
        _ => brokerList.OrderBy(row => row.Id),
      };
      return View(brokerList);
    }

    // GET-Details
    public IActionResult Details(int? id)
    {
      var broker = _db.Brokers.Find(id);
      if (broker == null)
      {
        return NotFound();
      }
      return View(broker);
    }

    // GET-Create
    public IActionResult Create()
    {
      return View();
    }

    // POST-Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Broker broker)
    {
      if (ModelState.IsValid)
      {
        _db.Brokers.Add(broker);
        _db.SaveChanges();
        TempData["modifiedId"] = broker.Id;
        TempData["modification"] = "create";
        TempData["brokerName"] = broker.Firstname + " " + broker.Lastname;
        return RedirectToAction("Index");
      }
      return View(broker);
    }

    // GET-Delete
    public IActionResult Delete(int? id)
    {
      if (id == null || id == 0)
      {
        return NotFound();
      }
      var broker = _db.Brokers.Find(id);
      if (broker == null)
      {
        return NotFound();
      }
      return View(broker);
    }

    // POST-Delete
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePost(int? id)
    {
      var broker = _db.Brokers.Find(id);
      if (broker == null)
      {
        return NotFound();
      }
      _db.Brokers.Remove(broker);
      _db.SaveChanges();
      TempData["modification"] = "delete";
      TempData["brokerName"] = broker.Firstname + " " + broker.Lastname;
      return RedirectToAction("Index");
    }

    // GET-Update
    public IActionResult Update(int? id)
    {
      if (id == null || id == 0)
      {
        return NotFound();
      }
      var broker = _db.Brokers.Find(id);
      if (broker == null)
      {
        return NotFound();
      }
      return View(broker);
    }

    // POST-Update
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Update(Broker broker)
    {
      if (ModelState.IsValid)
      {
        _db.Brokers.Update(broker);
        _db.SaveChanges();
        TempData["modifiedId"] = broker.Id;
        TempData["modification"] = "update";
        TempData["brokerName"] = broker.Firstname + " " + broker.Lastname;
        return RedirectToAction("Index");
      }
      return View(broker);
    }
  }
}

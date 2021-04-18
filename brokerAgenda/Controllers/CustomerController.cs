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
    public IActionResult Index(string sortOrder, string searchString)
    {
      //var customers = from c in _db.Customers select c;

      IEnumerable<Customer> customerList = _db.Customers;
      if (!String.IsNullOrEmpty(searchString))
      {
        searchString = searchString.ToLower(); 
        customerList = customerList.Where(c => c.Lastname.ToLower().Contains(searchString) || c.Firstname.ToLower().Contains(searchString));
      }
      customerList = sortOrder switch //new syntax for switch _ is default
      {
        "Id" => customerList.OrderBy(row => row.Id),
        "LastName" => customerList.OrderBy(row => row.Lastname),
        "FirstName" => customerList.OrderBy(row => row.Firstname),
        _ => customerList.OrderBy(row => row.Id),
      };
      return View(customerList);
    }

    // GET-Details
    public IActionResult Details(int? id)
    {
      var customer = _db.Customers.Find(id);
      if (customer == null)
      {
        return NotFound();
      }
      return View(customer);
    }

    // GET-Create
    public IActionResult Create()
    {
      return View();
    }

    // POST-Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Customer customer)
    {
      if (ModelState.IsValid)
      {
        _db.Customers.Add(customer);
        _db.SaveChanges();
        TempData["modifiedId"] = customer.Id;
        TempData["modification"] = "create";
        TempData["customerName"] = customer.Firstname + " " + customer.Lastname;
        return RedirectToAction("Index");
      }
      return View(customer);
    }

    //GET Delete
    public IActionResult Delete(int? id)
    {
      if (id == null || id == 0)
      {
        return NotFound();
      }
      var customer = _db.Customers.Find(id);
      if (customer == null)
      {
        return NotFound();
      }
      return View(customer);
    }
    
    //POST Delete
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePost(int? id)
    {
      var customer = _db.Customers.Find(id);
      if (customer == null)
      {
        return NotFound();
      }
      _db.Customers.Remove(customer);
      _db.SaveChanges();
      TempData["modification"] = "delete";
      TempData["customerName"] = customer.Firstname + " " + customer.Lastname;
      return RedirectToAction("Index");
    }

    //GET Update
    public IActionResult Update(int? id)
    {
      if (id == null || id == 0)
      {
        return NotFound();
      }
      var customer = _db.Customers.Find(id);
      if (customer == null)
      {
        return NotFound();
      }
      return View(customer);
    }

    //POST Update
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Update(Customer customer)
    {
      if (ModelState.IsValid)
      {
        _db.Customers.Update(customer);
        _db.SaveChanges();

        TempData["modifiedId"] = customer.Id;
        TempData["modification"] = "update";
        TempData["customerName"] = customer.Firstname + " " + customer.Lastname;
        return RedirectToAction("Index");
      }
      return View(customer);
    }

  }
}

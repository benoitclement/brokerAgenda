﻿using brokerAgenda.Data;
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
    public IActionResult Index(string SortOrder)
    {
      IEnumerable<Appointment> appointmentList = _db.Appointments;
      foreach (var appointment in appointmentList)
      {
        appointment.IdBrokerNavigation = _db.Brokers.FirstOrDefault(b => b.Id == appointment.IdBroker);
        appointment.IdCustomerNavigation = _db.Customers.FirstOrDefault(c => c.Id == appointment.IdCustomer);
      }
      appointmentList = SortOrder switch //new syntax for switch _ is default
      {
        "BrokerName" => appointmentList.OrderBy(row => row.IdBrokerNavigation.Lastname),
        "CustomerName" => appointmentList.OrderBy(row => row.IdCustomerNavigation.Lastname),
        "DateTime" => appointmentList.OrderBy(row => row.DateHour),
        _ => appointmentList.OrderBy(row => row.IdBrokerNavigation.Lastname),
      };
      return View(appointmentList);
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
    public IActionResult Create(AppointmentVM appointmentVM)
    {
      if (ModelState.IsValid)
      {
        _db.Appointments.Add(appointmentVM.Appointment);
        _db.SaveChanges();
        TempData["modifiedId"] = appointmentVM.Appointment.Id;
        TempData["modification"] = "create";
        Customer customer = _db.Customers.FirstOrDefault(c => c.Id == appointmentVM.Appointment.IdCustomer);
        TempData["customerName"] = customer.Firstname + " " + customer.Lastname;
        TempData["dateTime"] = appointmentVM.Appointment.DateHour;
        return RedirectToAction("Index");
      }
      return View(appointmentVM.Appointment);
    }

    //GET Delete
    public IActionResult Delete(int? id)
    {
      if (id == null || id == 0)
      {
        return NotFound();
      }
      var appointment = _db.Appointments.Find(id);
      if (appointment == null)
      {
        return NotFound();
      }
      AppointmentVM newAppointmentVM = new AppointmentVM()
      {
        Appointment = appointment,
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
    
    //POST Delete
    [HttpPost]
    [ValidateAntiForgeryToken]
    //public IActionResult DeletePost(int? id)
    public IActionResult DeletePost(AppointmentVM appointmentVM)
    {
      var appointment = _db.Appointments.Find(appointmentVM.Appointment.Id);
      if (appointment == null)
      {
        return NotFound();
      }
      _db.Appointments.Remove(appointment);
      _db.SaveChanges();
      TempData["modification"] = "delete";
      Customer customer = _db.Customers.FirstOrDefault(c => c.Id == appointment.IdCustomer);
      TempData["customerName"] = customer.Firstname + " " + customer.Lastname;
      TempData["dateTime"] = appointment.DateHour;
      TempData["customerName"] = customer.Firstname + " " + customer.Lastname;
      return RedirectToAction("Index");
    }

    // GET-Update
    public IActionResult Update(int? id)
    {
      if (id == null || id == 0)
      {
        return NotFound();
      }
      var appointment = _db.Appointments.Find(id);
      if (appointment == null)
      {
        return NotFound();
      }
      AppointmentVM newAppointmentVM = new AppointmentVM()
      {
        Appointment = appointment,
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

    // POST-Update
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Update(AppointmentVM appointmentVM)
    {
      if (ModelState.IsValid)
      {
        var appointment = appointmentVM.Appointment;
        _db.Appointments.Update(appointment);
        _db.SaveChanges();
        TempData["modification"] = "update";
        Customer customer = _db.Customers.FirstOrDefault(c => c.Id == appointment.IdCustomer);
        TempData["customerName"] = customer.Firstname + " " + customer.Lastname;
        TempData["dateTime"] = appointment.DateHour;
        return RedirectToAction("Index");
      }
      return View(appointmentVM);
    }
  }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace brokerAgenda.Models
{
  public partial class Appointment
  {
    [Key]
    public int Id { get; set; }

    [Display(Name = "Date et heure")]
    [Required(ErrorMessage = "Veuillez renseigner date et heure")]
    public DateTime DateHour { get; set; }

    [Display(Name = "Objet du RDV")]
    [Required(ErrorMessage = "Veuillez renseigner l'objet du RDV")]
    public string Subject { get; set; }

    [Display(Name = "Id courtier")]
    public int IdBroker { get; set; }

    [Display(Name = "Id client")]
    public int IdCustomer { get; set; }

    public virtual Broker IdBrokerNavigation { get; set; }
    public virtual Customer IdCustomerNavigation { get; set; }
  }
}

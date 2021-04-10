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
        public DateTime DateHour { get; set; }
        public string Subject { get; set; }
        public int IdBroker { get; set; }
        public int IdCustomer { get; set; }

        public virtual Broker IdBrokerNavigation { get; set; }
        public virtual Customer IdCustomerNavigation { get; set; }
    }
}

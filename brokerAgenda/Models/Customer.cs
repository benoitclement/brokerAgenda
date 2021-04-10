using System;
using System.Collections.Generic;

#nullable disable

namespace brokerAgenda.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int Id { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public int Budget { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}

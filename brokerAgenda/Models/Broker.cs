using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace brokerAgenda.Models
{
    public partial class Broker
    {
        public Broker()
        {
            Appointments = new HashSet<Appointment>();
        }

        [Key]
        public int Id { get; set; }
        
        [DisplayName("Nom de famille")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "veuillez saisir uniquement des lettres")]
        [Required(ErrorMessage = "Veuillez saisir un nom de famille")]
        public string Lastname { get; set; }
        
        [DisplayName("Prénom")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "veuillez saisir uniquement des lettres")]
        [Required(ErrorMessage = "Veuillez saisir un prénom")]
        public string Firstname { get; set; }
        
        [DisplayName("Courriel")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[\w\.=-]+@[\w\.-]+\.[\w]{2,3}$", ErrorMessage = "veuillez saisir une adresse courriel valide")]
        [Required(ErrorMessage = "Veuillez saisir une adresse courriel")]
        [EmailAddress(ErrorMessage = "Veuillez saisir une adresse courriel valide")]
        public string Mail { get; set; }
        
        [DisplayName("Numéro de téléphone")]
        [RegularExpression(@"^0[1-9]\d{8}$", ErrorMessage = "Veuillez saisir un numéro de téléphone français en 10 chiffres")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Veuillez saisir un numéro de téléphone")]
        [Phone(ErrorMessage="Veuillez saisir un numéro de téléphone valide")]
        public string PhoneNumber { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}

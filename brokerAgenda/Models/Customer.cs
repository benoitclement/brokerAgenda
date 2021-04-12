using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace brokerAgenda.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Appointments = new HashSet<Appointment>();
        }

        [Key]
        public int Id { get; set; }

        [Display(Name = "Nom de famille")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[a-zA-Z]+[ \-']?[[a-zA-Z]+[ \-']?]*[a-zA-Z]+$", ErrorMessage = "Veuillez saisir un nom usuel")]
        [Required(ErrorMessage = "Veuillez saisir un nom de famille")]
        public string Lastname { get; set; }
        
        [Display(Name = "Prénom")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[a-zA-Z]+[ \-']?[[a-zA-Z]+[ \-']?]*[a-zA-Z]+$", ErrorMessage = "Veuillez saisir un prénom usuel")]
        [Required(ErrorMessage = "Veuillez saisir un prénom")]
        public string Firstname { get; set; }

        [Display(Name = "Courriel")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[\w\.=-]+@[\w\.-]+\.[\w]{2,3}$", ErrorMessage = "Veuillez saisir une adresse courriel valide")]
        [Required(ErrorMessage = "Veuillez saisir une adresse courriel")]
        [EmailAddress(ErrorMessage = "Veuillez saisir une adresse courriel valide")]
        public string Mail { get; set; }

        [Display(Name = "Numéro de téléphone")]
        [RegularExpression(@"^0[1-9]\d{8}$", ErrorMessage = "Veuillez saisir un numéro de téléphone français en 10 chiffres")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Veuillez saisir un numéro de téléphone")]
        [Phone(ErrorMessage="Veuillez saisir un numéro de téléphone valide")]
        public string PhoneNumber { get; set; }
        
        [RegularExpression(@"^\d+$", ErrorMessage = "Veuillez saisir un montant en chiffres")]
        public int? Budget { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}

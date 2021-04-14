using System;
using System.Collections.Generic;
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
        
        [Display(Name = "Nom de famille")]
        [RegularExpression(@"^[a-zA-Z'àâéèêîôùûäëïçÀÂÉÈÎÔÙÛÄËÏÇ\s-]{1,75}$", ErrorMessage = "Veuillez saisir un nom usuel")]
        [Required(ErrorMessage = "Veuillez saisir un nom de famille")]
        public string Lastname { get; set; }
        
        [Display(Name = "Prénom")]
        [RegularExpression(@"^[a-zA-Z'àâéèêîôùûäëïçÀÂÉÈÎÔÙÛÄËÏÇ\s-]{1,75}$", ErrorMessage = "Veuillez saisir un prénom usuel")]
        [Required(ErrorMessage = "Veuillez saisir un prénom")]
        public string Firstname { get; set; }
        
        [Display(Name = "Courriel")]
        [RegularExpression(@"^[\w\.=-]+@[\w\.-]+\.[\w]{2,3}$", ErrorMessage = "Veuillez saisir une adresse courriel valide")]
        [Required(ErrorMessage = "Veuillez saisir une adresse courriel")]
        public string Mail { get; set; }
        
        [Display(Name = "Numéro de téléphone")]
        [RegularExpression(@"^0[1-9]\d{8}$", ErrorMessage = "Veuillez saisir un numéro de téléphone français en 10 chiffres")]
        [Required(ErrorMessage = "Veuillez saisir un numéro de téléphone")]
        public string PhoneNumber { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}

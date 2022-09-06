using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IT_Project.Models
{
    public class TheatrePlayTicketPurchase
    {
        [Key]
        public int Id { get; set; }
        public int TheatrePlayInfoId { get; set; }
        public TheatrePlayInfo Info { get; set; }
        public string UserEmail { get; set; }
        public DateTime PurchaseDate { get; set; }
        [Display(Name = "Број на билети")]
        [Required(ErrorMessage = "Полето е задолжително!")]
        public int TicketsCount { get; set; }
        [Display(Name = "Име и презиме(картичка)")]
        [Required(ErrorMessage = "Полето е задолжително!")]
        public string CreditCardFullName { get; set; }
        [Display(Name = "Број на картичка")]
        [Required(ErrorMessage = "Полето е задолжително!")]
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        [StringLength(19, ErrorMessage = "Ве молиме следете го форматот!")]
        public string CreditCardNumber { get; set; }
        [Display(Name = "Рок на важност")]
        [Required(ErrorMessage = "Полето е задолжително!")]
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        [StringLength(5, ErrorMessage = "Ве молиме следете го форматот!")]
        public string CreditCardExpirationDate { get; set; }
        [Required(ErrorMessage = "Полето е задолжително!")]
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        [StringLength(3, ErrorMessage = "Ве молиме следете го форматот!")]
        public string CVV { get; set; }

        public TheatrePlayTicketPurchase()
        {
            this.TicketsCount = 1;
        }
    }
}
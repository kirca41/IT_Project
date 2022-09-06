using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IT_Project.Models
{
    public class TheatrePlayReservation
    {
        [Key]
        public int Id { get; set; }
        public int TheatrePlayInfoId { get; set; }
        public TheatrePlayInfo Info { get; set; }
        public string UserEmail { get; set; }
        public DateTime ReservationDate { get; set; }
        [Display(Name = "Број на билети")]
        [Required(ErrorMessage = "Полето е задолжително!")]
        public int ReservationCount { get; set; }
        [Display(Name = "Име")]
        [Required(ErrorMessage = "Полето е задолжително!")]
        public string FirstName { get; set; }
        [Display(Name = "Презиме")]
        [Required(ErrorMessage = "Полето е задолжително!")]
        public string LastName { get; set; }
        [Display(Name = "Телефонски број")]
        [Required(ErrorMessage = "Полето е задолжително!")]
        public string Phone { get; set; }
        public bool Paid { get; set; }

        public TheatrePlayReservation()
        {
            this.ReservationCount = 1;
            this.Paid = false;
        }
    }
}
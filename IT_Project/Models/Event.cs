using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IT_Project.Models
{
    public class Event
    {
        [Display(Name = "Наслов")]
        [Required(ErrorMessage = "Полето е задолжително!")]
        public string Title { get; set; }
        [Display(Name = "Опис")]
        [Required(ErrorMessage = "Полето е задолжително!")]
        public string Description { get; set; }
    }
}
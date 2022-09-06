using IT_Project.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IT_Project.Models
{
    public class MovieInfo
    {
        [Key]
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string Title { get; set; }
        [Required(ErrorMessage = "Полето е задолжително")]
        [IsDateTimeValid(ErrorMessage = "Внесениот термин не е валиден!")]
        [Display(Name = "Датум и време")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime DateAndTime { get; set; }
        [Display(Name = "Резервирани/продадени билети")]
        [Required(ErrorMessage = "Полето е задолжително!")]
        public int TicketsGiven { get; set; }
        [Required(ErrorMessage = "Полето е задолжително")]
        [Display(Name = "Цена на билет")]
        public int Price { get; set; }

        public MovieInfo()
        {
            this.TicketsGiven = 0;
        }
    }
}
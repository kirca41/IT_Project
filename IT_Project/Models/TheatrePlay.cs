using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IT_Project.Models
{
    public class TheatrePlay : Event
    {
        public int TheatrePlayId { get; set; }
        [Display(Name = "Режисер")]
        [Required(ErrorMessage = "Полето е задолжително!")]
        public string Director { get; set; }
        [Display(Name = "Автор")]
        [Required(ErrorMessage = "Полето е задолжително!")]
        public string Author { get; set; }
        [Display(Name = "Улоги")]
        [Required(ErrorMessage = "Полето е задолжително!")]
        public string Cast { get; set; }
        [Display(Name = "Времетраење во минути")]
        [Required(ErrorMessage = "Полето е задолжително!")]
        public int Duration { get; set; }
        [Display(Name = "Пауза")]
        public bool Intermission { get; set; }
        [Display(Name = "Сцена")]
        public string Stage { get; set; }
        [Display(Name = "Жанр")]
        [Required(ErrorMessage = "Полето е задолжително!")]
        public string Genre { get; set; }
        public byte[] Poster { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        [Required(ErrorMessage = "Полето е задолжително!")]
        [Display(Name = "Плакат")]
        public HttpPostedFileBase File { get; set; }

        public TheatrePlay()
        {
            this.Stage = "Мала";
        }
    }
}
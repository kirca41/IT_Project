using IT_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IT_Project.ViewModels
{
    public class HomePageViewModel
    {
        public List<Event> Events { get; set; }
        public TheatrePlayInfo NextPlayInfo { get; set; }
        public TheatrePlay NextPlay { get; set; }
        public MovieInfo NextMovieInfo { get; set; }
        public Movie NextMovie { get; set; }
    }
}
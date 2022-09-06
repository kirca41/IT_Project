using IT_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IT_Project.ViewModels
{
    public class ReservationsViewModel
    {
        public Dictionary<TheatrePlayInfo, List<TheatrePlayReservation>> Plays { get; set; }
        public Dictionary<MovieInfo, List<MovieReservation>> Movies { get; set; }
    }
}
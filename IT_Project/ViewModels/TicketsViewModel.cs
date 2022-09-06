using IT_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IT_Project.ViewModels
{
    public class TicketsViewModel
    {
        public Dictionary<TheatrePlayInfo, List<TheatrePlayTicketPurchase>> Plays { get; set; }
        public Dictionary<MovieInfo, List<MovieTicketPurchase>> Movies { get; set; }
    }
}
using IT_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IT_Project.ViewModels
{
    public class EventInfoViewModel
    {
        public Dictionary<string, List<TheatrePlayInfo>> Plays { get; set; }
        public Dictionary<string, List<MovieInfo>> Movies { get; set; }
    }
}
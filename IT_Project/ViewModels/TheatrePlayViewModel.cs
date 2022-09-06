using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IT_Project.ViewModels
{
    public class TheatrePlayViewModel
    {
        public int TheatrePlayId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public byte[] Poster { get; set; }
    }
}
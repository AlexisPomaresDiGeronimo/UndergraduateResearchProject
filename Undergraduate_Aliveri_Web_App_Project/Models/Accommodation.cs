using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Undergraduate_Aliveri_Web_App_Project.Models
{
    public class Accommodation
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public bool Opened { get; set; }
        public string Photo { get; set; }
    }
}
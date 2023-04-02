using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Undergraduate_Aliveri_Web_App_Project.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
    }
}
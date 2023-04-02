using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Undergraduate_Aliveri_Web_App_Project.Models.Dtos
{
    public class ContactDto
    {
        public ContactDto(Contact contact)
        {
            Id = contact.Id;
            Firstname = contact.Firstname;
            Lastname = contact.Lastname;
            Email = contact.Email;
            Phone = contact.Phone;
            Message = contact.Message;

        }
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
    }
}
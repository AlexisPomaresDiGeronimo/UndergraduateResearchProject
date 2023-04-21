using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Undergraduate_Aliveri_Web_App_Project.Models.Dtos
{
    public class EntertainmentDto
    {
        public EntertainmentDto(Entertainment entertainment)
        {
            Id = entertainment.Id;
            Title = entertainment.Title;
            Type = entertainment.Type;
            Description = entertainment.Description;
            Location = entertainment.Location;
            Phone = entertainment.Phone;
            Opened = entertainment.Opened;
            Photo = entertainment.Photo;
        }
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
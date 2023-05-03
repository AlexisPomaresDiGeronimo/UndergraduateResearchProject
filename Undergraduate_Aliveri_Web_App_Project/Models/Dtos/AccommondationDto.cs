using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Undergraduate_Aliveri_Web_App_Project.Models.Dtos
{
    public class AccommodationDto
    {
        public AccommodationDto(Accommodation Accommodation)
        {
            Id = Accommodation.Id;
            Title = Accommodation.Title;
            Type = Accommodation.Type;
            Description = Accommodation.Description;
            Location = Accommodation.Location;
            Phone = Accommodation.Phone;
            Opened = Accommodation.Opened;
            Photo = Accommodation.Photo;
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
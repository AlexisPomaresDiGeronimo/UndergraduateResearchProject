using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Undergraduate_Aliveri_Web_App_Project.Models.Dtos
{
    public class TransportationDto
    {
        public TransportationDto(Transportation transportation)
        {
            Id = transportation.Id;
            Name = transportation.Name;
            Type = transportation.Type;
            Description = transportation.Description;
            Location = transportation.Location;
            Phone = transportation.Phone;
            Photo = transportation.Photo;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public string Photo { get; set; }
    }
}
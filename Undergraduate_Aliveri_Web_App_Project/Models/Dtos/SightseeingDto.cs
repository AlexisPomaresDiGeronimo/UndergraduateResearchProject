using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Undergraduate_Aliveri_Web_App_Project.Models.Dtos
{
    public class SightseeingDto
    {
        public SightseeingDto(Sightseeing sightseeing)
        {
            Id = sightseeing.Id;
            Name = sightseeing.Name;
            Description = sightseeing.Description;
            Location = sightseeing.Location;
            Photo = sightseeing.Photo;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Photo { get; set; }
    }
}
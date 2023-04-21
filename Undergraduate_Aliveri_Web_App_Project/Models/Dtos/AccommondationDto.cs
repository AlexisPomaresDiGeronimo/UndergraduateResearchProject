using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Undergraduate_Aliveri_Web_App_Project.Models.Dtos
{
    public class AccommondationDto
    {
        public AccommondationDto(Accommondation accommondation)
        {
            Id = accommondation.Id;
            Title = accommondation.Title;
            Type = accommondation.Type;
            Description = accommondation.Description;
            Location = accommondation.Location;
            Phone = accommondation.Phone;
            Opened = accommondation.Opened;
            Photo = accommondation.Photo;
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
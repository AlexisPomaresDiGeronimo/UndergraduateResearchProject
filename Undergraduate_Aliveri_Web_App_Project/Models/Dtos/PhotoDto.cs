using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Undergraduate_Aliveri_Web_App_Project.Models.Dtos
{
    public class PhotoDto
    {
        public PhotoDto(Photo photo)
        {
            Id = photo.Id;
            Name = photo.Name;
            Url = photo.Url;
            Description = photo.Description;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public Post Post { get; set; }
    }
}
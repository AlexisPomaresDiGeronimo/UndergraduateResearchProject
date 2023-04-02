using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Undergraduate_Aliveri_Web_App_Project.Models.Dtos
{
    public class PostDto
    {
        public PostDto(Post post)
        {
            Id = post.Id;
            Title = post.Title;
            Description = post.Description;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Undergraduate_Aliveri_Web_App_Project.Models.Dtos;
using Undergraduate_Aliveri_Web_App_Project.Models;
using Undergraduate_Aliveri_Web_App_Project.Persistance;

namespace Undergraduate_Aliveri_Web_App_Project.Controllers
{
    public class PostController : ApiController
    {
        private UnitOfWork unit;
        public PostController()
        {
            unit = new UnitOfWork(new ApplicationDbContext());
        }

        // GET: api/Post
        public IEnumerable<object> GetPosts()
        {
            var posts = unit.Post.GetAll();
            var postDtos = unit.Post.GetAll().Select(post => new PostDto(post));
            return postDtos;
        }

        // GET: api/Post/5
        [ResponseType(typeof(Post))]
        public IHttpActionResult GetPost(int id)
        {
            Post post = unit.Post.GetById(id);
            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        // POST: api/Post
        [ResponseType(typeof(Post))]
        public IHttpActionResult PostPost(Post post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            unit.Post.Insert(post);
            unit.Post.Save();
            return CreatedAtRoute("DefaultApi", new { id = post.Id }, post);
        }

        // PUT: api/Post/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPost(int id, Post post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != post.Id)
            {
                return BadRequest();
            }

            unit.Post.Update(post);

            try
            {
                unit.Post.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(post);
        }

        // DELETE: api/Post/5
        [ResponseType(typeof(Post))]
        public IHttpActionResult DeletePost(int id)
        {
            Post post = unit.Post.GetById(id);
            if (post == null)
            {
                return NotFound();
            }
            unit.Post.Delete(id);
            unit.Post.Save();

            return Ok(post);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unit.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PostExists(int id)
        {
            return unit.Post.GetAll().Count(e => e.Id == id) > 0;
        }
    }
}

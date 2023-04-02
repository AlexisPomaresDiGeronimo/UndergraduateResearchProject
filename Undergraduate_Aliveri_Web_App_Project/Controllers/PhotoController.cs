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
    public class PhotoController : ApiController
    {
        private UnitOfWork unit;
        public PhotoController()
        {
            unit = new UnitOfWork(new ApplicationDbContext());
        }

        // GET: api/Photo
        public IEnumerable<object> GetPhotos()
        {
            var photos = unit.Photo.GetAll();
            var photoDtos = unit.Photo.GetAll().Select(photo => new PhotoDto(photo));
            return photoDtos;
        }

        // GET: api/Photo/5
        [ResponseType(typeof(Photo))]
        public IHttpActionResult GetPhoto(int id)
        {
            Photo photo = unit.Photo.GetById(id);
            if (photo == null)
            {
                return NotFound();
            }

            return Ok(photo);
        }

        // POST: api/Photo
        [ResponseType(typeof(Photo))]
        public IHttpActionResult PostPhoto(Photo photo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            unit.Photo.Insert(photo);
            unit.Photo.Save();
            return CreatedAtRoute("DefaultApi", new { id = photo.Id }, photo);
        }

        // PUT: api/Photo/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPhoto(int id, Photo photo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != photo.Id)
            {
                return BadRequest();
            }

            unit.Photo.Update(photo);

            try
            {
                unit.Photo.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhotoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(photo);
        }

        // DELETE: api/Photo/5
        [ResponseType(typeof(Photo))]
        public IHttpActionResult DeletePhoto(int id)
        {
            Photo photo = unit.Photo.GetById(id);
            if (photo == null)
            {
                return NotFound();
            }
            unit.Photo.Delete(id);
            unit.Photo.Save();

            return Ok(photo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unit.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PhotoExists(int id)
        {
            return unit.Photo.GetAll().Count(e => e.Id == id) > 0;
        }
    }
}

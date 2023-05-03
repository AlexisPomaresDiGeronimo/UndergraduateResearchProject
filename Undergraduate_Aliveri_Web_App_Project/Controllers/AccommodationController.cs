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
using System.Web.Http.Cors;

namespace Undergraduate_Aliveri_Web_App_Project.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AccommodationController : ApiController
    {
        private UnitOfWork unit;
        public AccommodationController()
        {
            unit = new UnitOfWork(new ApplicationDbContext());
        }

        // GET: api/Accommodation
        public IEnumerable<object> GetAccommodations()
        {
            var Accommodations = unit.Accommodation.GetAll();
            var AccommodationDtos = unit.Accommodation.GetAll().Select(Accommodation => new AccommodationDto(Accommodation));
            return AccommodationDtos;
        }

        // GET: api/Accommodation/5
        [ResponseType(typeof(Accommodation))]
        public IHttpActionResult GetAccommodation(int id)
        {
            Accommodation Accommodation = unit.Accommodation.GetById(id);
            if (Accommodation == null)
            {
                return NotFound();
            }

            return Ok(Accommodation);
        }

        // POST: api/Accommodation
        [ResponseType(typeof(Accommodation))]
        public IHttpActionResult PostAccommodation(Accommodation Accommodation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            unit.Accommodation.Insert(Accommodation);
            unit.Accommodation.Save();
            return CreatedAtRoute("DefaultApi", new { id = Accommodation.Id }, Accommodation);
        }

        // PUT: api/Accommodation/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAccommodation(int id, Accommodation Accommodation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Accommodation.Id)
            {
                return BadRequest();
            }

            unit.Accommodation.Update(Accommodation);

            try
            {
                unit.Accommodation.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccommodationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(Accommodation);
        }

        // DELETE: api/Accommodation/5
        [ResponseType(typeof(Accommodation))]
        public IHttpActionResult DeleteAccommodation(int id)
        {
            Accommodation Accommodation = unit.Accommodation.GetById(id);
            if (Accommodation == null)
            {
                return NotFound();
            }
            unit.Accommodation.Delete(id);
            unit.Accommodation.Save();

            return Ok(Accommodation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unit.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AccommodationExists(int id)
        {
            return unit.Accommodation.GetAll().Count(e => e.Id == id) > 0;
        }
    }
}

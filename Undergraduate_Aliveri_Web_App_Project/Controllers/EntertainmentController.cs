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
    public class EntertainmentController : ApiController
    {
        private UnitOfWork unit;
        public EntertainmentController()
        {
            unit = new UnitOfWork(new ApplicationDbContext());
        }
        // GET: api/Entertainment
        public IEnumerable<object> GetContacts()
        {
            var entertainments = unit.Entertainment.GetAll();
            var entertainmentsDtos = unit.Entertainment.GetAll().Select(entertainment => new EntertainmentDto(entertainment));
            return entertainmentsDtos;
        }

        // GET: api/Entertainment/5
        [ResponseType(typeof(Entertainment))]
        public IHttpActionResult GetEntertainment(int id)
        {
            Entertainment entertainment = unit.Entertainment.GetById(id);
            if (entertainment == null)
            {
                return NotFound();
            }

            return Ok(entertainment);
        }

        // POST: api/Entertainment
        [ResponseType(typeof(Entertainment))]
        public IHttpActionResult PostEntertainment(Entertainment entertainment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            unit.Entertainment.Insert(entertainment);
            unit.Entertainment.Save();
            return CreatedAtRoute("DefaultApi", new { id = entertainment.Id }, entertainment);
        }

        // PUT: api/Entertainment/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEntertainment(int id, Entertainment entertainment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != entertainment.Id)
            {
                return BadRequest();
            }

            unit.Entertainment.Update(entertainment);

            try
            {
                unit.Entertainment.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntertainmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(entertainment);
        }

        // DELETE: api/Entertainment/5
        [ResponseType(typeof(Entertainment))]
        public IHttpActionResult DeleteEntertainment(int id)
        {
            Entertainment entertainment = unit.Entertainment.GetById(id);
            if (entertainment == null)
            {
                return NotFound();
            }
            unit.Entertainment.Delete(id);
            unit.Entertainment.Save();

            return Ok(entertainment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unit.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EntertainmentExists(int id)
        {
            return unit.Entertainment.GetAll().Count(e => e.Id == id) > 0;
        }
    }
}

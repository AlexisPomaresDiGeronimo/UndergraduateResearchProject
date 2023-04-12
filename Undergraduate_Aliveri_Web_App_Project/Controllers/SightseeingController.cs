using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using Undergraduate_Aliveri_Web_App_Project.Models.Dtos;
using Undergraduate_Aliveri_Web_App_Project.Models;
using Undergraduate_Aliveri_Web_App_Project.Persistance;
using System.Web.Http.Cors;

namespace Undergraduate_Aliveri_Web_App_Project.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SightseeingController : ApiController
    {
        private UnitOfWork unit;
        public SightseeingController()
        {
            unit = new UnitOfWork(new ApplicationDbContext());
        }

        // GET: api/Sightseeing
        public IEnumerable<object> GetSightseeings()
        {
            var sightseeings = unit.Sightseeing.GetAll();
            var sightseeingDtos = unit.Sightseeing.GetAll().Select(sightseeing => new SightseeingDto(sightseeing));
            return sightseeingDtos;
        }

        // GET: api/Sightseeing/5
        [ResponseType(typeof(Sightseeing))]
        public IHttpActionResult GetSightseeing(int id)
        {
            Sightseeing sightseeing = unit.Sightseeing.GetById(id);
            if (sightseeing == null)
            {
                return NotFound();
            }

            return Ok(sightseeing);
        }

        // POST: api/Sightseeing
        [ResponseType(typeof(Sightseeing))]
        public IHttpActionResult PostAccomondation(Sightseeing sightseeing)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            unit.Sightseeing.Insert(sightseeing);
            unit.Sightseeing.Save();
            return CreatedAtRoute("DefaultApi", new { id = sightseeing.Id }, sightseeing);
        }

        // PUT: api/Sightseeing/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAccomondation(int id, Sightseeing sightseeing)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sightseeing.Id)
            {
                return BadRequest();
            }

            unit.Sightseeing.Update(sightseeing);

            try
            {
                unit.Sightseeing.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SightseeingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(sightseeing);
        }

        // DELETE: api/Sightseeing/5
        [ResponseType(typeof(Sightseeing))]
        public IHttpActionResult DeleteSightseeing(int id)
        {
            Sightseeing sightseeing = unit.Sightseeing.GetById(id);
            if (sightseeing == null)
            {
                return NotFound();
            }
            unit.Sightseeing.Delete(id);
            unit.Sightseeing.Save();

            return Ok(sightseeing);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unit.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SightseeingExists(int id)
        {
            return unit.Sightseeing.GetAll().Count(e => e.Id == id) > 0;
        }
    }
}

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
    public class TransportationController : ApiController
    {
        private UnitOfWork unit;
        public TransportationController()
        {
            unit = new UnitOfWork(new ApplicationDbContext());
        }

        // GET: api/Transportation
        public IEnumerable<object> GetTransportations()
        {
            var transportations = unit.Transportation.GetAll();
            var transportationDtos = unit.Transportation.GetAll().Select(transportation => new TransportationDto(transportation));
            return transportationDtos;
        }

        // GET: api/Transportation/5
        [ResponseType(typeof(Transportation))]
        public IHttpActionResult GetTransportation(int id)
        {
            Transportation transportation = unit.Transportation.GetById(id);
            if (transportation == null)
            {
                return NotFound();
            }

            return Ok(transportation);
        }

        // POST: api/Transportation
        [ResponseType(typeof(Transportation))]
        public IHttpActionResult PostTransportation(Transportation transportation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            unit.Transportation.Insert(transportation);
            unit.Transportation.Save();
            return CreatedAtRoute("DefaultApi", new { id = transportation.Id }, transportation);
        }

        // PUT: api/Transportation/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTransportation(int id, Transportation transportation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != transportation.Id)
            {
                return BadRequest();
            }

            unit.Transportation.Update(transportation);

            try
            {
                unit.Transportation.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransportationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(transportation);
        }

        // DELETE: api/Transportation/5
        [ResponseType(typeof(Transportation))]
        public IHttpActionResult DeleteTransportation(int id)
        {
            Transportation transportation = unit.Transportation.GetById(id);
            if (transportation == null)
            {
                return NotFound();
            }
            unit.Transportation.Delete(id);
            unit.Transportation.Save();

            return Ok(transportation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unit.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TransportationExists(int id)
        {
            return unit.Transportation.GetAll().Count(e => e.Id == id) > 0;
        }
    }
}

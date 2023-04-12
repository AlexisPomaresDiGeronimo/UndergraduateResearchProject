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
    public class AccommondationController : ApiController
    {
        private UnitOfWork unit;
        public AccommondationController()
        {
            unit = new UnitOfWork(new ApplicationDbContext());
        }

        // GET: api/Accommondation
        public IEnumerable<object> GetAccommondations()
        {
            var accommondations = unit.Accommondation.GetAll();
            var accommondationDtos = unit.Accommondation.GetAll().Select(accommondation => new AccommondationDto(accommondation));
            return accommondationDtos;
        }

        // GET: api/Accommondation/5
        [ResponseType(typeof(Accommondation))]
        public IHttpActionResult GetAccommondation(int id)
        {
            Accommondation accommondation = unit.Accommondation.GetById(id);
            if (accommondation == null)
            {
                return NotFound();
            }

            return Ok(accommondation);
        }

        // POST: api/Accommondation
        [ResponseType(typeof(Accommondation))]
        public IHttpActionResult PostAccommondation(Accommondation accommondation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            unit.Accommondation.Insert(accommondation);
            unit.Accommondation.Save();
            return CreatedAtRoute("DefaultApi", new { id = accommondation.Id }, accommondation);
        }

        // PUT: api/Accommondation/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAccommondation(int id, Accommondation accommondation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != accommondation.Id)
            {
                return BadRequest();
            }

            unit.Accommondation.Update(accommondation);

            try
            {
                unit.Accommondation.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccommondationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(accommondation);
        }

        // DELETE: api/Accommondation/5
        [ResponseType(typeof(Accommondation))]
        public IHttpActionResult DeleteAccommondation(int id)
        {
            Accommondation accommondation = unit.Accommondation.GetById(id);
            if (accommondation == null)
            {
                return NotFound();
            }
            unit.Accommondation.Delete(id);
            unit.Accommondation.Save();

            return Ok(accommondation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unit.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AccommondationExists(int id)
        {
            return unit.Accommondation.GetAll().Count(e => e.Id == id) > 0;
        }
    }
}

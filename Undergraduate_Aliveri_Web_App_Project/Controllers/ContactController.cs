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
    public class ContactController : ApiController
    {
        private UnitOfWork unit;
        public ContactController()
        {
            unit = new UnitOfWork(new ApplicationDbContext());
        }
        // GET: api/Contact
        public IEnumerable<object> GetContacts()
        {
            var contacts = unit.Contact.GetAll();
            var contactsDtos = unit.Contact.GetAll().Select(contact => new ContactDto(contact));
            return contactsDtos;
        }

        // GET: api/Contact/5
        [ResponseType(typeof(Contact))]
        public IHttpActionResult GetContact(int id)
        {
            Contact contact = unit.Contact.GetById(id);
            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        // POST: api/Contact
        [ResponseType(typeof(Contact))]
        public IHttpActionResult PostAccomondation(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            unit.Contact.Insert(contact);
            unit.Contact.Save();
            return CreatedAtRoute("DefaultApi", new { id = contact.Id }, contact);
        }

        // PUT: api/Contact/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutContact(int id, Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contact.Id)
            {
                return BadRequest();
            }

            unit.Contact.Update(contact);

            try
            {
                unit.Contact.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(contact);
        }

        // DELETE: api/Contact/5
        [ResponseType(typeof(Contact))]
        public IHttpActionResult DeleteContact(int id)
        {
            Contact contact = unit.Contact.GetById(id);
            if (contact == null)
            {
                return NotFound();
            }
            unit.Contact.Delete(id);
            unit.Contact.Save();

            return Ok(contact);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unit.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContactExists(int id)
        {
            return unit.Contact.GetAll().Count(e => e.Id == id) > 0;
        }
    }
}

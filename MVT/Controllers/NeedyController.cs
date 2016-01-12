using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MVT.Models;
using MVT;

namespace MVT.Controllers
{
    [Authorize(Roles = "Admin")]
    public class NeedyController : ApiController
    {
        private MVTContext db = new MVTContext();

        // GET api/Needy
        public IQueryable<NeedyModel> GetNeedy()
        {
            return db.Needy.Where(f => f.IsActive == true)
                .Select(f => new NeedyModel
                {
                    Id = f.Id,
                    Name = f.Name,
                    PhoneNumber = f.PhoneNumber,
                    Location = f.Location
                });
        }

        // GET api/Needy/5
        [ResponseType(typeof(NeedyModel))]
        public IHttpActionResult GetNeedy(long id)
        {
            Needy needy = db.Needy.Find(id);
            if (needy == null)
            {
                return NotFound();
            }

            return Ok(App.Convert(needy));
        }

        // PUT api/Needy/5
        public IHttpActionResult PutNeedy(long id, NeedyModel needy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != needy.Id)
            {
                return BadRequest();
            }

            var n = db.Needy.Find(id);
            if (n == null)
            {
                return NotFound();
            }
            n.Name = needy.Name;
            n.Location = needy.Location;
            n.PhoneNumber = needy.PhoneNumber;
            db.Entry(n).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NeedyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Needy
        [ResponseType(typeof(NeedyModel))]
        public IHttpActionResult PostNeedy(NeedyModel needy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var n = db.Needy.Add( App.Convert(needy));
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = n.Id }, App.Convert(n));
        }

        // DELETE api/Needy/5
        public IHttpActionResult DeleteNeedy(long id)
        {
            Needy needy = db.Needy.Find(id);
            if (needy == null)
            {
                return NotFound();
            }

            needy.IsActive = false;
            db.Entry(needy).State = EntityState.Modified;
            db.SaveChanges();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NeedyExists(long id)
        {
            return db.Needy.Count(e => e.Id == id) > 0;
        }
    }
}
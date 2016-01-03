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
    public class NeedyController : ApiController
    {
        private MVTContext db = new MVTContext();

        // GET api/Needy
        public IQueryable<Needy> GetNeedy()
        {
            return db.Needy.Where(f => f.IsActive == true);
        }

        // GET api/Needy/5
        [ResponseType(typeof(Needy))]
        public IHttpActionResult GetNeedy(long id)
        {
            Needy needy = db.Needy.Find(id);
            if (needy == null)
            {
                return NotFound();
            }

            return Ok(needy);
        }

        // PUT api/Needy/5
        public IHttpActionResult PutNeedy(long id, Needy needy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != needy.Id)
            {
                return BadRequest();
            }

            db.Entry(needy).State = EntityState.Modified;

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
        [ResponseType(typeof(Needy))]
        public IHttpActionResult PostNeedy(Needy needy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Needy.Add(needy);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = needy.Id }, needy);
        }

        // DELETE api/Needy/5
        [ResponseType(typeof(Needy))]
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

            return Ok(needy);
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
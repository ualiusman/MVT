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
    public class ContributionController : ApiController
    {
        private MVTContext db = new MVTContext();

        // GET api/Contribution
        public IQueryable<ContributionModel> GetContributions()
        {
            return db.Contributions.Where(f => f.IsActive == true)
                .Select(f =>  new ContributionModel
                { 
                    ContributionId = f.ContributionId,
                    Contributor = f.Contributor,
                    Date = f.Date,
                    Ammount = f.Ammount,
                    ProjectId = f.ProjectId
                });
        }

        // GET api/Contribution/5
        [ResponseType(typeof(ContributionModel))]
        public IHttpActionResult GetContribution(long id)
        {
            Contribution contribution = db.Contributions.Find(id);
            if (contribution == null)
            {
                return NotFound();
            }

            return Ok(App.Convert(contribution));
        }

        // PUT api/Contribution/5
        public IHttpActionResult PutContribution(long id, ContributionModel contribution)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contribution.ContributionId)
            {
                return BadRequest();
            }

            var c = db.Contributions.Find(id);
            if (c == null)
            {
                return NotFound();
            }
            c.Ammount = contribution.Ammount;
            c.ProjectId = contribution.ProjectId;
            c.Contributor = contribution.Contributor;
            db.Entry(c).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContributionExists(id))
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

        // POST api/Contribution
        [ResponseType(typeof(ContributionModel))]
        public IHttpActionResult PostContribution(ContributionModel contribution)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var c = db.Contributions.Add(App.Convert(contribution));
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = c.ContributionId }, App.Convert(c));
        }

        // DELETE api/Contribution/5
        public IHttpActionResult DeleteContribution(long id)
        {
            Contribution contribution = db.Contributions.Find(id);
            if (contribution == null)
            {
                return NotFound();
            }

            contribution.IsActive = false;
            db.Entry(contribution).State = EntityState.Modified;
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

        private bool ContributionExists(long id)
        {
            return db.Contributions.Count(e => e.ContributionId == id) > 0;
        }
    }
}
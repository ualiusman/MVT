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

        [Authorize(Roles = "Admin")]
        // GET api/Contribution
        public List<ContributionModel> GetContributions()
        {
            AuthRepository repo = new AuthRepository();
            return db.Contributions.Where(f => f.IsActive == true).ToList()
                .Select(f =>  new ContributionModel
                { 
                    ContributionId = f.ContributionId,
                    Contributor = f.Contributor,
                    Date = f.Date,
                    Ammount = f.Ammount,
                    ProjectId = f.ProjectId,
                    ProjectName = f.Project.Name,
                    ContributorName = repo.GetName(f.Contributor)
                }).ToList();
        }

        // GET api/Contribution/5
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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

        [Route("api/MonthlyContribution/{id}")]
        [HttpGet]
        public List<int> MonthlyContribution(long id)
        {
            List<int> lst = db.Contributions.Where(f => f.IsActive == true && f.ProjectId == id).GroupBy(f => f.Date.Month).Select(f => f.Sum(i => i.Ammount)).ToList<int>();
            return lst;
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
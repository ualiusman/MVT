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
    //[Authorize(Roles = "Admin")]
    public class DonationController : ApiController
    {
        private MVTContext db = new MVTContext();

        // GET api/Donation
        public IQueryable<DonationModel> GetDonations()
        {
            return db.Donations.Where(f => f.IsActive == true)
                .Select(f => new DonationModel() 
                { 
                    Ammount = f.Ammount,
                    NeedyId = f.NeedyId, 
                    Date = f.Date,
                    ProjectId = f.ProjectId, 
                    DonationId = f.DonationId,
                    ProjectName = f.Project.Name,
                    NeedyName = f.Needy.Name
                });
        }

        // GET api/Donation/5
        [ResponseType(typeof(DonationModel))]
        public IHttpActionResult GetDonation(long id)
        {
            Donation donation = db.Donations.Find(id);
            if (donation == null)
            {
                return NotFound();
            }

            return Ok(App.Convert(donation));
        }

        // PUT api/Donation/5
        public IHttpActionResult PutDonation(long id, DonationModel donation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != donation.DonationId)
            {
                return BadRequest();
            }
            var d = db.Donations.Find(id);
            if (d == null)
            {
                return NotFound();
            }
            d.ProjectId = donation.ProjectId;
            d.NeedyId = donation.NeedyId;
            d.Ammount = donation.Ammount;
            db.Entry(d).State = EntityState.Modified;


            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonationExists(id))
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

        // POST api/Donation
        [ResponseType(typeof(DonationModel))]
        public IHttpActionResult PostDonation(DonationModel donation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dn = db.Donations.Add(App.Convert(donation));
            db.SaveChanges();
            db.Entry(dn).Reference(d => d.Project).Load();
            db.Entry(dn).Reference(d => d.Needy).Load();


            return CreatedAtRoute("DefaultApi", new { id = dn.DonationId }, App.Convert(dn));
        }

        // DELETE api/Donation/5
        public IHttpActionResult DeleteDonation(long id)
        {
            Donation donation = db.Donations.Find(id);
            if (donation == null)
            {
                return NotFound();
            }

            donation.IsActive = false;
            db.Entry(donation).State = EntityState.Modified;
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

        private bool DonationExists(long id)
        {
            return db.Donations.Count(e => e.DonationId == id) > 0;
        }
    }
}
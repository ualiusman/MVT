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
    public class ProjectController : ApiController
    {
        private MVTContext db = new MVTContext();

        // GET api/Project
        public IQueryable<Project> GetProjects()
        {
            return db.Projects.Where(proj=>proj.isActive==true
);
        }

        // GET api/Project/5
        [ResponseType(typeof(Project))]
        public IHttpActionResult GetProject(long id)
        {
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        // PUT api/Project/5
        public IHttpActionResult PutProject(long id, Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != project.Id)
            {
                return BadRequest();
            }

            db.Entry(project).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(id))
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

        // POST api/Project
        [ResponseType(typeof(Project))]
        public IHttpActionResult PostProject(Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Projects.Add(project);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = project.Id }, project);
        }

        // DELETE api/Project/5
        [ResponseType(typeof(Project))]
        public IHttpActionResult DeleteProject(long id)
        {
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return NotFound();
            }

            project.isActive = false;
            db.Entry(project).State = EntityState.Modified;
            db.SaveChanges();

            return Ok(true);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProjectExists(long id)
        {
            return db.Projects.Count(e => e.Id == id) > 0;
        }
    }
}
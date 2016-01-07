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
        public IQueryable<ProjectModel> GetProjects()
        {
            return db.Projects.Where(proj => proj.isActive == true)
                .Select(f => new ProjectModel { Description = f.Description, Name=f.Name, Id = f.Id });
        }
         [Authorize(Roles = "Admin")]
        // GET api/Project/5
        [ResponseType(typeof(ProjectModel))]
        public IHttpActionResult GetProject(long id)
        {
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return NotFound();
            }

            return Ok(App.Convert(project));
        }
         [Authorize(Roles = "Admin")]
        // PUT api/Project/5
        public IHttpActionResult PutProject(long id, ProjectModel project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != project.Id)
            {
                return BadRequest();
            }
            var p = db.Projects.Find(id);
            if(p == null)
            {
                return NotFound();
            }
            p.Name = project.Name;
            p.Description = project.Description;
             db.Entry(p).State = EntityState.Modified;

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
         [Authorize(Roles = "Admin")]
        // POST api/Project
        [ResponseType(typeof(ProjectModel))]
        public IHttpActionResult PostProject(ProjectModel project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var p = db.Projects.Add(App.Convert(project));
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = p.Id }, App.Convert(p));
        }
         [Authorize(Roles = "Admin")]
        // DELETE api/Project/5
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
         [Authorize(Roles = "Admin")]
        private bool ProjectExists(long id)
        {
            return db.Projects.Count(e => e.Id == id) > 0;
        }
    }
}
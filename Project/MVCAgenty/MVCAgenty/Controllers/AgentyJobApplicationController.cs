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
using MVCAgenty.Models;

namespace MVCAgenty.Controllers
{
    public class AgentyJobApplicationController : ApiController
    {
        private ResumeContext db = new ResumeContext();

        // GET: api/AgentyJobApplication
        public IQueryable<MyResume> GetmyResumes()
        {
            return db.myResumes;
        }

        // GET: api/AgentyJobApplication/5
        [ResponseType(typeof(MyResume))]
        public IHttpActionResult GetMyResume(int id)
        {
            MyResume myResume = db.myResumes.Find(id);
            if (myResume == null)
            {
                return NotFound();
            }

            return Ok(myResume);
        }

        // PUT: api/AgentyJobApplication/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMyResume(int id, MyResume myResume)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != myResume.Id)
            {
                return BadRequest();
            }

            db.Entry(myResume).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MyResumeExists(id))
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

        // POST: api/AgentyJobApplication
        [ResponseType(typeof(MyResume))]
        public IHttpActionResult PostMyResume(MyResume myResume)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.myResumes.Add(myResume);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = myResume.Id }, myResume);
        }

        // DELETE: api/AgentyJobApplication/5
        [ResponseType(typeof(MyResume))]
        public IHttpActionResult DeleteMyResume(int id)
        {
            MyResume myResume = db.myResumes.Find(id);
            if (myResume == null)
            {
                return NotFound();
            }

            db.myResumes.Remove(myResume);
            db.SaveChanges();

            return Ok(myResume);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MyResumeExists(int id)
        {
            return db.myResumes.Count(e => e.Id == id) > 0;
        }
    }
}
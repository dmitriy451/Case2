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
using SchoolPortalAPI.DataBase;

namespace SchoolPortalAPI.Controllers
{
    public class MarksController : ApiController
    {
        private SchoolPortalEntities db = new SchoolPortalEntities();

        // GET: api/Marks
        public IQueryable<Marks> GetMarks()
        {
            return db.Marks;
        }

        // GET: api/Marks/5
        [ResponseType(typeof(List<Models.ResponsLessonsMarks>))]
        public IHttpActionResult GetMarks(int Studentid)
        {
            List<Models.ResponsLessonsMarks> lessons = db.Lessons.ToList().ConvertAll(p => new Models.ResponsLessonsMarks(p, Studentid));
            if (lessons == null)
            {
                return NotFound();
            }
            return Ok(lessons);
        }

        // PUT: api/Marks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMarks(Models.ResponseMark markk,int id, string mark)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Marks.First(p => p.Id == id).Mark = mark;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarksExists(id))
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

        // POST: api/Marks
        [ResponseType(typeof(Marks))]
        public IHttpActionResult PostMarks(Marks marks)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Marks.Add(marks);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = marks.Id }, marks);
        }

        // DELETE: api/Marks/5
        [ResponseType(typeof(Marks))]
        public IHttpActionResult DeleteMarks(int id)
        {
            Marks marks = db.Marks.Find(id);
            if (marks == null)
            {
                return NotFound();
            }

            db.Marks.Remove(marks);
            db.SaveChanges();

            return Ok(marks);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MarksExists(int id)
        {
            return db.Marks.Count(e => e.Id == id) > 0;
        }
    }
}
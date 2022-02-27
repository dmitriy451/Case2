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
    public class LessonsController : ApiController
    {
        private SchoolPortalEntities db = new SchoolPortalEntities();

        // GET: api/Lessons
        public IQueryable<Lessons> GetLessons()
        {
            return db.Lessons;
        }

        // GET: api/Lessons/5
        [ResponseType(typeof(Models.ResponcseLesson))]
        public IHttpActionResult GetLessons(int id)
        {
            TimeTable lessons = new TimeTable();
            string NowDay = DateTime.Now.DayOfWeek.ToString();
            TimeSpan NowTime = DateTime.Now.TimeOfDay;
            lessons = db.TimeTable.FirstOrDefault(p => p.Lessons.TeacherId == id && p.DayOfTheWeek == NowDay && (p.Start <= NowTime && p.End >= NowTime));
            if (lessons == null)
            {
                return NotFound();
            }
            Models.ResponcseLesson responcseLesson = new Models.ResponcseLesson(lessons);
            return Ok(responcseLesson);
        }

        // PUT: api/Lessons/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLessons(int id, Lessons lessons)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lessons.Id)
            {
                return BadRequest();
            }

            db.Entry(lessons).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LessonsExists(id))
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

        // POST: api/Lessons
        [ResponseType(typeof(Lessons))]
        public IHttpActionResult PostLessons(Lessons lessons)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Lessons.Add(lessons);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = lessons.Id }, lessons);
        }

        // DELETE: api/Lessons/5
        [ResponseType(typeof(Lessons))]
        public IHttpActionResult DeleteLessons(int id)
        {
            Lessons lessons = db.Lessons.Find(id);
            if (lessons == null)
            {
                return NotFound();
            }

            db.Lessons.Remove(lessons);
            db.SaveChanges();

            return Ok(lessons);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LessonsExists(int id)
        {
            return db.Lessons.Count(e => e.Id == id) > 0;
        }
    }
}
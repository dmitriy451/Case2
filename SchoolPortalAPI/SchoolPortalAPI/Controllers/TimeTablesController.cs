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
    public class TimeTablesController : ApiController
    {
        private SchoolPortalEntities db = new SchoolPortalEntities();

        // GET: api/TimeTables
        public IQueryable<TimeTable> GetTimeTable()
        {
            return db.TimeTable;
        }

        // GET: api/TimeTables/5
        [ResponseType(typeof(Models.ResponseTimeTable))]
        public IHttpActionResult GetTimeTable(int id, int ClassId)
        {
            if (db.User.First(p => p.Id == id).Position.ToLower() == "ученик")
            {
                return Ok(new Models.ResponseTimeTable(db.TimeTable.Where(p => p.Class.Id == db.Group.FirstOrDefault(z => z.StudentId == id).Class.Id).ToList()));
            }
            Models.ResponseTimeTable timeTable = new Models.ResponseTimeTable(db.TimeTable.Where(p => p.ClassId == ClassId && p.Lessons.TeacherId == id).ToList());
            return Ok(timeTable);
        }

        // PUT: api/TimeTables/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTimeTable(int id, TimeTable timeTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != timeTable.Id)
            {
                return BadRequest();
            }

            db.Entry(timeTable).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimeTableExists(id))
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

        // POST: api/TimeTables
        [ResponseType(typeof(TimeTable))]
        public IHttpActionResult PostTimeTable(TimeTable timeTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TimeTable.Add(timeTable);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = timeTable.Id }, timeTable);
        }

        // DELETE: api/TimeTables/5
        [ResponseType(typeof(TimeTable))]
        public IHttpActionResult DeleteTimeTable(int id)
        {
            TimeTable timeTable = db.TimeTable.Find(id);
            if (timeTable == null)
            {
                return NotFound();
            }

            db.TimeTable.Remove(timeTable);
            db.SaveChanges();

            return Ok(timeTable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TimeTableExists(int id)
        {
            return db.TimeTable.Count(e => e.Id == id) > 0;
        }
    }
}
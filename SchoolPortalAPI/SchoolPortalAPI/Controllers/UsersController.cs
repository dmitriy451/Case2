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
    public class UsersController : ApiController
    {
        private SchoolPortalEntities db = new SchoolPortalEntities();

        // GET: api/Users
        public IQueryable<User> GetUser()
        {
            return db.User.Where(p => p.Position.ToLower() == "ученик");
        }

        // GET: api/Users/5
        [ResponseType(typeof(List<User>))]
        public IHttpActionResult GetUser(int id)
        {
            User user = db.User.Find(id);
            List<User> Peoples;
            if (user.Position == "Ученик")
            {
                Peoples = db.User.Where(p => p.Position == "Учитель" && p.Id != user.Id).ToList();
                Peoples.AddRange(db.User.Where(p => p.Group.FirstOrDefault().ClassId == db.Group.FirstOrDefault(c => c.StudentId == user.Id).ClassId && p.Id != user.Id));
            }
            else
            {
                Peoples = db.User.Where(p => p.Id != user.Id).ToList();
            }

            Peoples = Peoples.Distinct<User>().ToList();
            if (user == null)
            {
                return NotFound();
            }

            return Ok(Peoples);
        }
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(string login, string password)
        {
            User user = db.User.FirstOrDefault(p => p.Login == login && p.Password == password);
            
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.Id)
            {
                return BadRequest();
            }

            db.Entry(user).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.User.Add(user);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            User user = db.User.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            db.User.Remove(user);
            db.SaveChanges();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return db.User.Count(e => e.Id == id) > 0;
        }
    }
}
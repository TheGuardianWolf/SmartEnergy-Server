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
using SmartEnergy_Server.Models;

namespace SmartEnergy_Server.Controllers
{
    /// <summary>
    /// A set of endpoints relating to user data.
    /// </summary>
    public class UsersController : ApiController
    {
        private SmartEnergy_ServerContext db = new SmartEnergy_ServerContext();

        // GET: api/Users
        /// <summary>
        /// Get an object containing all users and their details.
        /// </summary>
        public IQueryable<User> GetUser()
        {
            return db.User;
        }

        // GET: api/Users/5
        /// <summary>
        /// Get details for user by user table ID.
        /// </summary>
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(int id)
        {
            User users = db.User.Find(id);
            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        // GET: api/Users/Username
        /// <summary>
        /// Get details on specific user by username. Can be used for user validation.
        /// </summary>
        [Route("api/Users/Username/{username}")]
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(string username)
        {
            var users = db.User.Where(i => i.Username == username);
            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        // PUT: api/Users/5
        /// <summary>
        /// Modify user entry.
        /// </summary>
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

            if (UsernameExists(user.Username))
            {
                return BadRequest("User already exists.");
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
        /// <summary>
        /// Create a user.
        /// </summary>
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (UsernameExists(user.Username))
            {
                return BadRequest("User already exists.");
            }

            db.User.Add(user);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        /// <summary>
        /// Delete a user.
        /// </summary>
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            User users = db.User.Find(id);
            if (users == null)
            {
                return NotFound();
            }

            db.User.Remove(users);
            db.SaveChanges();

            return Ok(users);
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

        private bool UsernameExists(string username)
        {
            return db.User.Count(e => e.Username == username) > 0;
        }
    }
}

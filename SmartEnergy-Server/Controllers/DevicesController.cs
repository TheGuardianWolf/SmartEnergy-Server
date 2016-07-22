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
    public class DevicesController : ApiController
    {
        private SmartEnergy_ServerContext db = new SmartEnergy_ServerContext();

        // GET: api/Devices
        public IQueryable<Devices> GetDevices()
        {
            return db.Devices;
        }

        // GET: api/Devices/5
        [ResponseType(typeof(Devices))]
        public IHttpActionResult GetDevices(int id)
        {
            Devices devices = db.Devices.Find(id);
            if (devices == null)
            {
                return NotFound();
            }

            return Ok(devices);
        }

        // PUT: api/Devices/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDevices(int id, Devices devices)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != devices.Id)
            {
                return BadRequest();
            }

            db.Entry(devices).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DevicesExists(id))
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

        // POST: api/Devices
        [ResponseType(typeof(Devices))]
        public IHttpActionResult PostDevices(Devices devices)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Devices.Add(devices);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = devices.Id }, devices);
        }

        // DELETE: api/Devices/5
        [ResponseType(typeof(Devices))]
        public IHttpActionResult DeleteDevices(int id)
        {
            Devices devices = db.Devices.Find(id);
            if (devices == null)
            {
                return NotFound();
            }

            db.Devices.Remove(devices);
            db.SaveChanges();

            return Ok(devices);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DevicesExists(int id)
        {
            return db.Devices.Count(e => e.Id == id) > 0;
        }
    }
}
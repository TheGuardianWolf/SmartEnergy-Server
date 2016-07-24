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
        private IQueryable<Device> GetDevice()
        {
            return db.Device;
        }

        // GET: api/Devices/5
        [ResponseType(typeof(Device))]
        public IHttpActionResult GetDevice(int id)
        {
            Device device = db.Device.Find(id);
            if (device == null)
            {
                return NotFound();
            }

            return Ok(device);
        }

        // GET: api/Devices/User/
        [Route("api/Devices/User/{userId}")]
        [ResponseType(typeof(Device))]
        public IHttpActionResult GetDevicesByUserId(int userId)
        {
            if (UserIdExists(userId))
            {
                return NotFound();
            }

            return Ok(db.Devices.Where(i => i.UserId == userId));
        }

        // PUT: api/Devices/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDevice(int id, Device device)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != device.Id)
            {
                return BadRequest();
            }

            if (HardwareIdExists(device.HardwareId))
            {
                return BadRequest("Device already exists.");
            }

            db.Entry(device).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeviceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            catch (DbUpdateException)
            {
                if (!UserIdExists(device.UserId))
                {
                    return BadRequest("Specified UserId must match an existing UserId.");
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Devices
        [ResponseType(typeof(Device))]
        public IHttpActionResult PostDevice(Device device)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (HardwareIdExists(device.HardwareId))
            {
                return BadRequest("Device already exists.");
            }

            db.Device.Add(device);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (!UserIdExists(device.UserId))
                {
                    return BadRequest("Specified UserId must match an existing UserId.");
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = device.Id }, device);
        }

        // DELETE: api/Devices/5
        [ResponseType(typeof(Device))]
        private IHttpActionResult DeleteDevice(int id)
        {
            Device device = db.Device.Find(id);
            if (device == null)
            {
                return NotFound();
            }

            db.Device.Remove(device);
            db.SaveChanges();

            return Ok(device);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DeviceExists(int id)
        {
            return db.Device.Count(e => e.Id == id) > 0;
        }

        private bool UserIdExists(int id)
        {
            return db.User.Count(e => e.Id == id) > 0;
        }

        private bool HardwareIdExists(string hardwareId)
        {
            return db.Device.Count(e => e.HardwareId == hardwareId) > 0;
        }
    }
}

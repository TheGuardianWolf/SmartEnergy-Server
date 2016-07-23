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
    public class DataController : ApiController
    {
        private SmartEnergy_ServerContext db = new SmartEnergy_ServerContext();

        // GET: api/Data
        public IQueryable<Data> GetData()
        {
            return db.Data;
        }

        // GET: api/Data/5
        [ResponseType(typeof(Data))]
        public IHttpActionResult GetData(int id)
        {
            Data data = db.Data.Find(id);
            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        // GET: api/Data/Device/5
        [Route("api/Data/Device/{deviceId}")]
        [ResponseType(typeof(Data))]
        public IHttpActionResult GetDataByDeviceId(int deviceId)
        {
            var data = db.Data.Where(i => i.DeviceId == deviceId);

            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        // PUT: api/Data/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutData(int id, Data data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != data.Id)
            {
                return BadRequest();
            }

            // TODO: Input should contain nested JSON object for time and power which is looped over and inserted to DB

            db.Entry(data).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DataExists(id))
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

        // POST: api/Data
        [ResponseType(typeof(Data))]
        public IHttpActionResult PostData(Data data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Data.Add(data);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = data.Id }, data);
        }

        // DELETE: api/Data/5
        [ResponseType(typeof(Data))]
        public IHttpActionResult DeleteData(int id)
        {
            Data data = db.Data.Find(id);
            if (data == null)
            {
                return NotFound();
            }

            db.Data.Remove(data);
            db.SaveChanges();

            return Ok(data);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DataExists(int id)
        {
            return db.Data.Count(e => e.Id == id) > 0;
        }

        private bool TimeExists(DateTime time)
        {
            return db.Data.Count(e => e.Time == time) > 0;
        }
    }
}
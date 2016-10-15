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
using System.Web.Http.OData;

namespace SmartEnergy_Server.Controllers
{
	/// <summary>
    /// A set of endpoints relating to data.
    /// </summary>
    public class DataController : ApiController
    {
        private SmartEnergy_ServerContext db = new SmartEnergy_ServerContext();

        // GET: api/Data
		/// <summary>
		/// Get an object containing all data.
		/// </summary>
        private IQueryable<Data> GetData()
        {
            return db.Data;
        }

        // GET: api/Data/Device/5
		/// <summary>
		/// Get details for data by device ID.
		/// </summary>
        [Route("api/Data/Device/{deviceId}")]
        [EnableQueryAttribute]
        [ResponseType(typeof(Data))]
        public IQueryable<Data> GetDataByDeviceId(int deviceId)
        {
            return db.Data.Where(i => i.DeviceId == deviceId);
        }

        // GET: api/Data/5
		/// <summary>
		/// Get details for data by data table ID.
		/// </summary>
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

        // PUT: api/Data/5
		/// <summary>
		/// /// Modify data entry.
		/// </summary>
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

            db.Entry(data).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                if (!DataExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw e;
                }
            }
            catch (DbUpdateException e)
            {
                if (!DeviceExists(data.DeviceId))
                {
                    return BadRequest("Specified DeviceId must match an existing DeviceId.");
                }
                else
                {
                    throw e;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // TIP: Use batch requests to submit multiple
        // POST: api/Data
		/// <summary>
		/// Create data.
		/// </summary>
        [ResponseType(typeof(Data))]
        public IHttpActionResult PostData(Data data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Data.Add(data);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                if (!DeviceExists(data.DeviceId))
                {
                    return BadRequest("Specified DeviceId must match an existing DeviceId.");
                }
                else
                {
                    throw e;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = data.Id }, data);
        }

        // DELETE: api/Data/5
		/// <summary>
		/// Delete data.
		/// </summary>
        [ResponseType(typeof(Data))]
        private IHttpActionResult DeleteData(int id)
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

        private bool DeviceExists(int id)
        {
            return db.Device.Count(e => e.Id == id) > 0;
        }

        private bool DataExists(int id)
        {
            return db.Data.Count(e => e.Id == id) > 0;
        }
    }
}
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
using zeta_temp.Models;
using System.Web.Http.Cors;

namespace zeta_temp.Controllers
{
    [EnableCors(origins:"*",headers:"*",methods:"*")]
    public class PRODUCTOsController : ApiController
    {
        private zeta_bdEntities db = new zeta_bdEntities();

        // GET: api/PRODUCTOs
        public IQueryable<PRODUCTO> GetPRODUCTO()
        {
            return db.PRODUCTO;
        }

        // GET: api/PRODUCTOs/5
        [ResponseType(typeof(PRODUCTO))]
        public IHttpActionResult GetPRODUCTO(decimal id)
        {
            PRODUCTO pRODUCTO = db.PRODUCTO.Find(id);
            if (pRODUCTO == null)
            {
                return NotFound();
            }

            return Ok(pRODUCTO);
        }

        // PUT: api/PRODUCTOs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPRODUCTO(decimal id, PRODUCTO pRODUCTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pRODUCTO.ID_PRODUCTO)
            {
                return BadRequest();
            }

            db.Entry(pRODUCTO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PRODUCTOExists(id))
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

        // POST: api/PRODUCTOs
        [ResponseType(typeof(PRODUCTO))]
        public IHttpActionResult PostPRODUCTO(PRODUCTO pRODUCTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PRODUCTO.Add(pRODUCTO);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pRODUCTO.ID_PRODUCTO }, pRODUCTO);
        }

        // DELETE: api/PRODUCTOs/5
        [ResponseType(typeof(PRODUCTO))]
        public IHttpActionResult DeletePRODUCTO(decimal id)
        {
            PRODUCTO pRODUCTO = db.PRODUCTO.Find(id);
            if (pRODUCTO == null)
            {
                return NotFound();
            }

            db.PRODUCTO.Remove(pRODUCTO);
            db.SaveChanges();

            return Ok(pRODUCTO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PRODUCTOExists(decimal id)
        {
            return db.PRODUCTO.Count(e => e.ID_PRODUCTO == id) > 0;
        }
    }
}
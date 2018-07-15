using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using zeta_temp.Models;

namespace zeta_temp.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CATEGORIAsController : ApiController
    {
        private zeta_bdEntities db = new zeta_bdEntities();

        // GET: api/CATEGORIAs
        public IQueryable<CATEGORIA> GetCATEGORIA()
        {
            return db.CATEGORIA;
        }

        // GET: api/CATEGORIAs/5
        [ResponseType(typeof(CATEGORIA))]
        public IHttpActionResult GetCATEGORIA(decimal id)
        {
            CATEGORIA cATEGORIA = db.CATEGORIA.Find(id);
            if (cATEGORIA == null)
            {
                return NotFound();
            }

            return Ok(cATEGORIA);
        }

        // PUT: api/CATEGORIAs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCATEGORIA(decimal id, CATEGORIA cATEGORIA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cATEGORIA.ID_CATEGORIA)
            {
                return BadRequest();
            }

            db.Entry(cATEGORIA).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CATEGORIAExists(id))
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

        // POST: api/CATEGORIAs
        [ResponseType(typeof(CATEGORIA))]
        public IHttpActionResult PostCATEGORIA(CATEGORIA cATEGORIA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CATEGORIA.Add(cATEGORIA);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cATEGORIA.ID_CATEGORIA }, cATEGORIA);
        }

        // DELETE: api/CATEGORIAs/5
        [ResponseType(typeof(CATEGORIA))]
        public IHttpActionResult DeleteCATEGORIA(decimal id)
        {
            CATEGORIA cATEGORIA = db.CATEGORIA.Find(id);
            if (cATEGORIA == null)
            {
                return NotFound();
            }

            db.CATEGORIA.Remove(cATEGORIA);
            db.SaveChanges();

            return Ok(cATEGORIA);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CATEGORIAExists(decimal id)
        {
            return db.CATEGORIA.Count(e => e.ID_CATEGORIA == id) > 0;
        }
    }
}
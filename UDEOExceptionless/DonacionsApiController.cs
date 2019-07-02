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

namespace UDEOExceptionless
{
    public class DonacionsApiController : ApiController
    {
        private UdeoEntities db = new UdeoEntities();
        public ExceptionLess_ ex = new ExceptionLess_();


        // GET: api/DonacionsApi
        public IQueryable<Donacion> GetDonacions()
        {
            try
            {
                ex.info("Entro a lista de donaciones");
                return db.Donacions;
            }
            catch (Exception e)
            {
                ex.error("Error al entrar a lista donaciones: " + e.ToString());
                return null;
            }
        }

        // GET: api/DonacionsApi/5
        [ResponseType(typeof(Donacion))]
        public IHttpActionResult GetDonacion(int id)
        {
            Donacion donacion = db.Donacions.Find(id);
            if (donacion == null)
            {
                return NotFound();
            }

            return Ok(donacion);
        }


        // GET: api/DonacionsApi/5
        [Route("api/DonacionsApi/lista")]
        [ResponseType(typeof(Donacion))]
        public IHttpActionResult GetDonaciones(string mes, string anio)
        {
            try
            {
                ex.info("Entro a lista de balance de donaciones");
                var donacion = (from cust in db.Donacions
                                where cust.Mes == mes && cust.Anio == anio
                                select cust).ToList();

                if (donacion == null)
                {
                    return NotFound();
                }

                return Ok(donacion);
            }
            catch (Exception e)
            {
                ex.error("Error al entrar a lista balance donaciones: " + e.ToString());
                return null;
            }
        }


        // PUT: api/DonacionsApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDonacion(int id, Donacion donacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != donacion.Id)
            {
                return BadRequest();
            }

            db.Entry(donacion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonacionExists(id))
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

        // POST: api/DonacionsApi
        [ResponseType(typeof(Donacion))]
        public IHttpActionResult PostDonacion(Donacion donacion)
        {
            if (!ModelState.IsValid)
            {
                ex.error("Error al crear donacion: " + donacion.ToString());
                return BadRequest(ModelState);
            }

            try
            {
                ex.info("Creando nueva donacion: " + donacion.ToString());
                db.Donacions.Add(donacion);
                db.SaveChanges();
                return CreatedAtRoute("DefaultApi", new { id = donacion.Id }, donacion);
            }
            catch (Exception e)
            {
                ex.error("Error al crear donacion: " + e.ToString());
                throw;
            }            
        }

        // DELETE: api/DonacionsApi/5
        [ResponseType(typeof(Donacion))]
        public IHttpActionResult DeleteDonacion(int id)
        {
            Donacion donacion = db.Donacions.Find(id);
            if (donacion == null)
            {
                return NotFound();
            }

            db.Donacions.Remove(donacion);
            db.SaveChanges();

            return Ok(donacion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DonacionExists(int id)
        {
            return db.Donacions.Count(e => e.Id == id) > 0;
        }
    }
}
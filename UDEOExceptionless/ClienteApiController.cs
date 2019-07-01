using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace UDEOExceptionless
{
    public class ClienteApiController : ApiController
    {
        private UdeoEntities db = new UdeoEntities();
        public ExceptionLess_ ex = new ExceptionLess_();

        // GET api/<controller>

        public IQueryable<Cliente> Get()
        {
            try
            {
                ex.info("Lista de Clientes");
                return db.Clientes;
            } catch (Exception e)
            {
                ex.error("Error en mostar data clientes");
                return null;
            }
        }
         

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}
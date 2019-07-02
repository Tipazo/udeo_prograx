using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UDEOExceptionless.DB;

namespace UDEOExceptionless
{
    public class ClienteApiController : ApiController
    {
        private UdeoEntities db = new UdeoEntities();
        public ExceptionLess_ ex = new ExceptionLess_();
        public ClientesDb db2 = new ClientesDb(new Connection());

        // GET api/<controller>
        public IQueryable<Cliente> Get()
        {
            try
            {
                ex.info("Entrando a lista de Clientes");
                //return db2.getAll();
                return db.Clientes;
            } catch (Exception e)
            {
                ex.error("Error al listar clientes: " + e.ToString());
                return null;
            }
        }
         

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }


        // POST api/<controller>
        public void Post([FromBody]Cliente cliente)
        {
            try
            {
                ex.info("Creando nuevo cliente: " + cliente.ToString());
                db.Clientes.Add(cliente);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                ex.error("Error al crear clientes: " + e.ToString());
                throw;
            }
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
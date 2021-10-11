using Dal;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServicioRESTWebApi.Controllers
{
    public class ProductosController : ApiController
    {
        private static readonly IDao<Producto> dao = DaoSqlServerProducto.ObtenerDao();
        // GET: api/Productos
        public IEnumerable<Producto> Get()
        {
            return dao.ObtenerTodos();
        }

        // GET: api/Productos/5
        public IHttpActionResult Get(long id)
        {
            Producto producto = dao.ObtenerPorId(id);

            if (producto != null)
            {
                return Ok(producto);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/Productos
        public IHttpActionResult Post([FromBody] Producto producto)
        {
            return Content(HttpStatusCode.Created, dao.Insertar(producto));
        }

        // PUT: api/Productos/5
        public IHttpActionResult Put(long id, [FromBody] Producto producto)
        {
            try
            {
                producto = dao.Modificar(producto);
                return Ok(producto);
            }
            catch (Exception)
            {
                return NotFound();
            }


        }

        // DELETE: api/Productos/5
        public IHttpActionResult Delete(long id)
        {
            try
            {
                dao.Borrar(id);
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}

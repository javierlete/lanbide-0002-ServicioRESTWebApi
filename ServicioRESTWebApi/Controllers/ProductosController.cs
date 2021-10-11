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
        public HttpResponseMessage Get(long id)
        {
            Producto producto = dao.ObtenerPorId(id);

            HttpStatusCode estado = producto != null ? HttpStatusCode.OK : HttpStatusCode.NotFound;
            
            return Request.CreateResponse(estado, producto);
        }

        // POST: api/Productos
        public HttpResponseMessage Post([FromBody]Producto producto)
        {
            return Request.CreateResponse(HttpStatusCode.Created, dao.Insertar(producto));
        }

        // PUT: api/Productos/5
        public HttpResponseMessage Put(long id, [FromBody]Producto producto)
        {
            try
            {
                producto = dao.Modificar(producto);
                return Request.CreateResponse(HttpStatusCode.OK, producto);
            }
            catch (Exception)
            {
               return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            
        }

        // DELETE: api/Productos/5
        public HttpResponseMessage Delete(long id)
        {
            HttpStatusCode estado = HttpStatusCode.NoContent;

            try
            {
                dao.Borrar(id);
            }
            catch (Exception)
            {
                estado = HttpStatusCode.NotFound;
            }

            return Request.CreateResponse(estado);
        }
    }
}

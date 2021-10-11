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
        public Producto Get(long id)
        {
            return dao.ObtenerPorId(id);
        }

        // POST: api/Productos
        public Producto Post([FromBody]Producto producto)
        {
            return dao.Insertar(producto);
        }

        // PUT: api/Productos/5
        public Producto Put(long id, [FromBody]Producto producto)
        {
            return dao.Modificar(producto);
        }

        // DELETE: api/Productos/5
        public void Delete(long id)
        {
            dao.Borrar(id);
        }
    }
}

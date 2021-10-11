using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServicioRESTWebApi.Controllers
{
    public class PruebaController : ApiController
    {
        public object Get()
        {
            return new { Id = 1, Nombre = "Javier" };
        }
    }
}

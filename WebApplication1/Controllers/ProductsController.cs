using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    [RoutePrefix("api")]
    public class ProductsController : ApiController
    {
        [Route("products")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Content(HttpStatusCode.OK, "Hello from Web Api");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVT.Controllers
{
    [RoutePrefix("api/Users")]
    public class UsersController : ApiController
    {
        
        [Route("")]
        [Authorize]
        public IHttpActionResult Get()
        {
            AuthRepository rep = new AuthRepository();
            return Ok(rep.GetAllUsers());
            
        }
    }
}

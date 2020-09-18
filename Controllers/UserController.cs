using Chaperone_API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Chaperone_API.Controllers
{
    [RoutePrefix("api/users")]
    public class UserController : ApiController
    {
        UserRepository userRepo = new UserRepository();
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(userRepo.GetAll());
        }
    }
}

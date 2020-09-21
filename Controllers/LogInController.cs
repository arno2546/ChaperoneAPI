using Chaperone_API.Models;
using Chaperone_API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Chaperone_API.Controllers
{
    [RoutePrefix("api/login")]
    public class LogInController : ApiController
    {
        [Route("")]
        public IHttpActionResult Post(LogIn l)
        {
            LogIn valUser = new LogIn();
            UserRepository userRepo = new UserRepository();
            User u = userRepo.GetAll().Where(x => x.Email == l.Email && x.Password == l.Password).FirstOrDefault();
            if (u!= null)
            {
                valUser.UserType = u.UserType;
                valUser.Email = u.Email;
                return Ok(valUser);
            }
            return StatusCode(HttpStatusCode.NotFound);
        }
    }
}

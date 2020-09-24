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
    [RoutePrefix("api/userRatio")]
    public class UserRatioController : ApiController
    {
        [Route("")]
        public IHttpActionResult Get()
        {
            UserRepository userRepo = new UserRepository();
            int Guide = userRepo.GetAll().Where(x => x.UserType == "Guide").Count();
            int Admin = userRepo.GetAll().Where(x => x.UserType == "Admin").Count();
            int Tourist = userRepo.GetAll().Where(x => x.UserType == "Gen").Count();
            UserRatio userRatio = new UserRatio();
            userRatio.Admin = Admin;
            userRatio.Guide = Guide;
            userRatio.Tourist = Tourist;
            return Ok(userRatio);
        }
    }
}

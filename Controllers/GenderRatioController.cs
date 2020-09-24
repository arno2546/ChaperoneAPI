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
    [RoutePrefix("api/genderRatio")]
    public class GenderRatioController : ApiController
    {
        [Route("")]
        public IHttpActionResult Get()
        {
            UserRepository userRepo = new UserRepository();
            int male = userRepo.GetAll().Where(x =>x.UserType=="Guide" && x.Gender == "Male").Count();
            int female = userRepo.GetAll().Where(x => x.UserType == "Guide" && x.Gender == "Female").Count();                
            GenderRatio genRatio = new GenderRatio();
            genRatio.MaleRatio = male;
            genRatio.FemaleRatio = female;
            return Ok(genRatio);
        }
    }
}

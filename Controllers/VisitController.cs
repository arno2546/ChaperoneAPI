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
    [RoutePrefix("api/visits")]
    public class VisitController : ApiController
    {
        VisitRepository visitRepo = new VisitRepository();

        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(visitRepo.GetAll());
        }

        [Route("{id}", Name = "GetVisitById")]
        public IHttpActionResult Get(int id)
        {
            Visit r = visitRepo.GetById(id);
            return Ok(r);
        }

        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            visitRepo.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }

        [Route("")]
        public IHttpActionResult Post(Visit u)
        {
            visitRepo.Insert(u);
            string url = Url.Link("GetVisitById", new { id = u.VisitId });
            return Created(url, u);
        }

        [Route("{id}")]
        public IHttpActionResult Put([FromBody] Visit u, [FromUri] int id)
        {
            u.VisitId = id;
            visitRepo.Edit(u);
            return Ok(u);
        }
    }
}

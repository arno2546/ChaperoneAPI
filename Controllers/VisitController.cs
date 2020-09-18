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
            if (r == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            r.HyperLinks.Add(new HyperLink() { HRef = "https://localhost:44310/api/users/" + r.VisitId, HttpMethod = "GET", Relation = "Self" });
            r.HyperLinks.Add(new HyperLink() { HRef = "https://localhost:44310/api/users", HttpMethod = "Post", Relation = "Create a new Visit" });
            r.HyperLinks.Add(new HyperLink() { HRef = "https://localhost:44310/api/users/" + r.VisitId, HttpMethod = "PUT", Relation = "Edit self" });
            r.HyperLinks.Add(new HyperLink() { HRef = "https://localhost:44310/api/users/" + r.VisitId, HttpMethod = "DELETE", Relation = "DELETE self" });
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

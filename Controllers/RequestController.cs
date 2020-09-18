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
    [RoutePrefix("api/request")]
    public class RequestController : ApiController
    {
        RequestRepository reqRepo = new RequestRepository();

        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(reqRepo.GetAll());
        }
        [Route("{id}", Name = "GetReqById")]
        public IHttpActionResult Get(int id)
        {
            Request u = reqRepo.GetById(id);
            if (u == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(u);
        }

        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            reqRepo.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }

        [Route("")]
        public IHttpActionResult Post(Request u)
        {
            reqRepo.Insert(u);
            string url = Url.Link("GetReqById", new { id = u.RequestId });
            return Created(url, u);
        }

        [Route("{id}")]
        public IHttpActionResult Put([FromBody] Request u, [FromUri] int id)
        {
            u.RequestId = id;
            reqRepo.Edit(u);
            return Ok(u);
        }
    }
}

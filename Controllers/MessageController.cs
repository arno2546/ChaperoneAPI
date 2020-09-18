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
    [RoutePrefix("api/messages")]
    public class MessageController : ApiController
    {
        MessageRepository msgRepo = new MessageRepository();

        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(msgRepo.GetAll());
        }
        [Route("{id}", Name = "GetMsgById")]
        public IHttpActionResult Get(int id)
        {
            Message u = msgRepo.GetById(id);
            if (u == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            u.HyperLinks.Add(new HyperLink() { HRef = "https://localhost:44310/api/reviews/" + u.MessageId, HttpMethod = "GET", Relation = "Self" });
            u.HyperLinks.Add(new HyperLink() { HRef = "https://localhost:44310/api/reviews", HttpMethod = "Post", Relation = "Create a new  Message" });
            u.HyperLinks.Add(new HyperLink() { HRef = "https://localhost:44310/api/reviews/" + u.MessageId, HttpMethod = "PUT", Relation = "Edit self" });
            u.HyperLinks.Add(new HyperLink() { HRef = "https://localhost:44310/api/reviews/" + u.MessageId, HttpMethod = "DELETE", Relation = "DELETE self" });
            return Ok(u);
        }

        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            msgRepo.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }

        [Route("")]
        public IHttpActionResult Post(Message u)
        {
            msgRepo.Insert(u);
            string url = Url.Link("GetMsgById", new { id = u.MessageId });
            return Created(url, u);
        }

        [Route("{id}")]
        public IHttpActionResult Put([FromBody] Message u, [FromUri] int id)
        {
            u.MessageId = id;
            msgRepo.Edit(u);
            return Ok(u);
        }
    }
}

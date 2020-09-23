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
    [RoutePrefix("api/users")]
    public class UserController : ApiController
    {
        UserRepository userRepo = new UserRepository();

        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(userRepo.GetAll());
        }
        [Route("{id}", Name ="GetUserById")]
        public IHttpActionResult Get(int id)
        {
            User u = userRepo.GetById(id);
            if (u == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            u.HyperLinks.Add(new HyperLink() { HRef = "https://localhost:44310/api/users/" + u.UserId, HttpMethod = "GET", Relation = "Self" });
            u.HyperLinks.Add(new HyperLink() { HRef = "https://localhost:44310/api/users", HttpMethod = "Post", Relation = "Create a new  User" });
            u.HyperLinks.Add(new HyperLink() { HRef = "https://localhost:44310/api/users/" + u.UserId, HttpMethod = "PUT", Relation = "Edit self" });
            u.HyperLinks.Add(new HyperLink() { HRef = "https://localhost:44310/api/users/" + u.UserId, HttpMethod = "DELETE", Relation = "DELETE self" });
            return Ok(u);
        }

        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            userRepo.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }

        [Route("")]
        public IHttpActionResult Post(User u)
        {
            userRepo.Insert(u);
            string url = Url.Link("GetUserById", new { id = u.UserId });
            return Created(url, u);
        }

        [Route("{id}")]
        public IHttpActionResult Put([FromBody]User u,[FromUri]int id)
        {
            u.UserId = id;
            userRepo.Edit(u);
            return Ok(u);
        }
        [Route("{id}/requests")]
        public IHttpActionResult GetRequests(int id)
        {
            RequestRepository reqRepo = new RequestRepository();
            List<Request> requests = new List<Request>();
            requests = reqRepo.GetAll().Where(x => x.GuideId == id || x.TouristId == id).ToList();
            return Ok(requests);
        }
    }
}

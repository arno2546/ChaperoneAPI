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
    [RoutePrefix("api/reviews")]
    public class ReviewController : ApiController
    {
        ReviewRepository revwRepo = new ReviewRepository();

        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(revwRepo.GetAll());
        }

        [Route("{id}", Name = "GetReviewById")]
        public IHttpActionResult Get(int id)
        {
            Review r = revwRepo.GetById(id);
            if (r == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            r.HyperLinks.Add(new HyperLink() { HRef = "https://localhost:44310/api/reviews/" + r.ReviewId, HttpMethod = "GET", Relation = "Self" });
            r.HyperLinks.Add(new HyperLink() { HRef = "https://localhost:44310/api/reviews", HttpMethod = "Post", Relation = "Create a new  Review" });
            r.HyperLinks.Add(new HyperLink() { HRef = "https://localhost:44310/api/reviews/" + r.ReviewId, HttpMethod = "PUT", Relation = "Edit self" });
            r.HyperLinks.Add(new HyperLink() { HRef = "https://localhost:44310/api/reviews/" + r.ReviewId, HttpMethod = "DELETE", Relation = "DELETE self" });
            return Ok(r);
        }

        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            revwRepo.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }

        [Route("")]
        public IHttpActionResult Post(Review u)
        {
            revwRepo.Insert(u);
            string url = Url.Link("GetReviewById", new { id = u.ReviewId });
            return Created(url, u);
        }

        [Route("{id}")]
        public IHttpActionResult Put([FromBody] Review u, [FromUri] int id)
        {
            u.ReviewId = id;
            revwRepo.Edit(u);
            return Ok(u);
        }
    }
}

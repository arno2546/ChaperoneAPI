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
    [RoutePrefix("api/search")]
    public class SearchController : ApiController
    {
        [Route("")]
        public IHttpActionResult Post(Search s)
        {
            UserRepository userRepo = new UserRepository();
            List<User> FilterdUsers = userRepo.GetAll().Where(x => x.UserType == "Guide" && x.Location.Contains(s.SearchString.ToString())).ToList();
            if (s.Male)
            {
                List<User> user = new List<User>();
                foreach (User u in FilterdUsers)
                {
                    if (u.Gender == "Male")
                    {
                        user.Add(u);
                    }
                }
                FilterdUsers = user;
            }
            if (s.Female)
            {
                List<User> user = new List<User>();
                foreach (User u in FilterdUsers)
                {
                    if (u.Gender=="Female")
                    {
                        user.Add(u);
                    }
                }
                FilterdUsers = user;
            }
            if (s.Culture)
            {
                List<User> user = new List<User>();
                foreach (User u in FilterdUsers)
                {
                    if (u.Culture)
                    {
                        user.Add(u);
                    }
                }
                FilterdUsers = user;
            }
            if (s.Festival)
            {
                List<User> user = new List<User>();
                foreach (User u in FilterdUsers)
                {
                    if (u.Festival)
                    {
                        user.Add(u);
                    }
                }
                FilterdUsers = user;
            }
            if (s.NightLife)
            {
                List<User> user = new List<User>();
                foreach (User u in FilterdUsers)
                {
                    if (u.NightLife)
                    {
                        user.Add(u);
                    }
                }
                FilterdUsers = user;
            }
            if (s.Food)
            {
                List<User> user = new List<User>();
                foreach (User u in FilterdUsers)
                {
                    if (u.Food)
                    {
                        user.Add(u);
                    }
                }
                FilterdUsers = user;
            }
            if (s.Sports)
            {
                List<User> user = new List<User>();
                foreach (User u in FilterdUsers)
                {
                    if (u.Sports)
                    {
                        user.Add(u);
                    }
                }
                FilterdUsers = user;
            }
            return Ok(FilterdUsers);
        }
    //    public IHttpActionResult Post(Search s)
    //    {
    //        UserRepository userRepo = new UserRepository();
    //        List<User> FilterdUsers = userRepo.GetAll().Where(x => x.Location.ToString().Contains(s.SearchString.ToString()) && x.UserType == "Guide").ToList();
    //        if (s.Male)
    //        {
    //            List<User> user = new List<User>();
    //            foreach (User u in FilterdUsers)
    //            {
    //                if (u.Gender=="Male")
    //                {
    //                    user.Add(u);
    //                }
    //            }
    //            FilterdUsers = user;
    //        }
    //        if (s.Female)
    //        {
    //            List<User> user = new List<User>();
    //            foreach (User u in FilterdUsers)
    //            {
    //                if (u.Gender == "Female")
    //                {
    //                    user.Add(u);
    //                }
    //            }
    //            FilterdUsers = user;
    //        }
    //        if (s.Culture)
    //        {
    //            List<User> user = new List<User>();
    //            foreach(User u in FilterdUsers)
    //            {
    //                if (u.Culture)
    //                {
    //                    user.Add(u);
    //                }
    //            }
    //            FilterdUsers = user;
    //        }
    //        if (s.NightLife)
    //        {
    //            List<User> user = new List<User>();
    //            foreach (User u in FilterdUsers)
    //            {
    //                if (u.NightLife)
    //                {
    //                    user.Add(u);
    //                }
    //            }
    //            FilterdUsers = user;
    //        }
    //        if (s.Food)
    //        {
    //            List<User> user = new List<User>();
    //            foreach (User u in FilterdUsers)
    //            {
    //                if (u.Food)
    //                {
    //                    user.Add(u);
    //                }
    //            }
    //            FilterdUsers = user;
    //        }
    //        if (s.Festival)
    //        {
    //            List<User> user = new List<User>();
    //            foreach (User u in FilterdUsers)
    //            {
    //                if (u.Festival)
    //                {
    //                    user.Add(u);
    //                }
    //            }
    //            FilterdUsers = user;
    //        }
    //        if (s.Sports)
    //        {
    //            List<User> user = new List<User>();
    //            foreach (User u in FilterdUsers)
    //            {
    //                if (u.Sports)
    //                {
    //                    user.Add(u);
    //                }
    //            }
    //            FilterdUsers = user;
    //        }
    //        bool noMatch = !FilterdUsers.Any();
    //        if (noMatch)
    //        {
    //            return StatusCode(HttpStatusCode.NoContent);
    //        }
    //        return Ok(FilterdUsers);
    //    }
    }
}

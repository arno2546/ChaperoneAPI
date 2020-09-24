using Chaperone_API.Models;
using Chaperone_API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Chaperone_API.Attributes
{
    public class BasicAuthorizationAttribute:AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);
            if (actionContext.Request.Headers.Authorization != null)
            {
                string encoded = actionContext.Request.Headers.Authorization.Parameter;
                string decoded = Encoding.UTF8.GetString(Convert.FromBase64String(encoded));
                string[] splittedData = decoded.Split(new char[]{':'});
                string username = splittedData[0];
                string password = splittedData[1];
                UserRepository userRepo = new UserRepository();
                User u = userRepo.GetAll().Where(x => x.Email == username && x.Password == password).FirstOrDefault();
                if(u!=null)
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(username),null);
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
                }
            }
            else
            {
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
            }
        }
    }
}
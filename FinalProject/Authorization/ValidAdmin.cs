using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace FinalProject.Authorization
{
    public class ValidAdmin : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var token = actionContext.Request.Headers.Authorization;
            if (token == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "No Token Supplied");
            }
            else
            {
                var rs = AuthServices.TokenValidity(token.ToString());
                var role = AuthServices.IsAdmin(token.ToString());
                if (rs == false || role == false)
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "Supplied token is invalid or Restricted");
                }
                
            }
            base.OnAuthorization(actionContext);
        }
    }
}
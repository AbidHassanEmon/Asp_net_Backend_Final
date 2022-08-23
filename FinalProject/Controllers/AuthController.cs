using BLL.Entites;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FinalProject.Controllers
{
    public class AuthController : ApiController
    {
        [Route("api/login")]
        [HttpPost]
        public HttpResponseMessage Login(LoginModel obj)
        {
           if(!ModelState.IsValid)
            { 
                return Request.CreateResponse(HttpStatusCode.BadRequest,ModelState);
            }
            var data = AuthServices.Authenticate(obj.Username, obj.Password);
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        [Route("api/logout")]
        public HttpResponseMessage Logout(TokenModel obj)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            var data = AuthServices.Logout(obj);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}

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
    public class UserController : ApiController
    {
        [Route("api/Users/all")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = UserServices.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/Users/get/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = UserServices.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/User/Delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            var data = UserServices.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/users/admin/create")]
        [HttpPost]
        public HttpResponseMessage Create(UserAdminModel st)
        {
            var data = UserServices.Create(st);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/Users/User/create")]
        [HttpPost]
        public HttpResponseMessage Create(UserModel st)
        {
            var data = UserServices.Create(st);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/User/Update")]
        [HttpPost]
        public HttpResponseMessage Update(UserPrifileUpdate st)
        {
            var data = UserServices.UpdateProfile(st);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/User/changepassword")]
        [HttpPost]
        public HttpResponseMessage Changepassword(UserChangePassword st)
        {
            var data = UserServices.UpdatePassword(st);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}

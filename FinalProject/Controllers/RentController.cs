using BLL.Entites;
using BLL.Services;
using FinalProject.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FinalProject.Controllers
{
    public class RentController : ApiController
    {
        [ValidAdmin]
        [Route("api/Rents/all")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = RentServices.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/Rents/get/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = RentServices.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/rent/Delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            var data = RentServices.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/rent/Update")]
        [HttpPost]
        public HttpResponseMessage Update(RentModel st)
        {
            var data = RentServices.Update(st);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/Rent/create")]
        [HttpPost]
        public HttpResponseMessage Create(RentModel st)
        {
            var data = RentServices.Create(st);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

    }
}

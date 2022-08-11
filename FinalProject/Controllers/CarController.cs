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
    public class CarController : ApiController
    {
        [ValidUser]
        [Route("api/Cars/all")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = CarServices.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/Cars/get/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = CarServices.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/Car/create")]
        [HttpPost]
        public HttpResponseMessage Create(CarModel st)
        {
            var data = CarServices.Create(st);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/Car/Delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            var data = CarServices.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/Car/Update")]
        [HttpPost]
        public HttpResponseMessage Update(CarModel st)
        {
            var data = CarServices.Update(st);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}

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
    public class MailController : ApiController
    {
        [Route("api/OTP/Mail")]
        [HttpPost]
        public HttpResponseMessage SendEmail(OTPMail st)
        {
            var data = OTPServices.Otp(st);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/OTP/Mail/ChangePass")]
        [HttpPost]
        public HttpResponseMessage OtpchangePass(OTPSubmit st)
        {
            var data = OTPServices.OtpSubmit(st);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}

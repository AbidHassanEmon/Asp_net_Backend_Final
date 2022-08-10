using BLL.Entites;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class OTPServices
    {
        public static bool Otp(OTPMail c)
        {
            var Userid = c.User_id;
            var data = DataAccessFactory.UserDataAccess().Get(Userid);
            if (data == null)
            {
                return false;
            }
            Random r = new Random();
            var x = r.Next(99999, 1000000).ToString();

            var m = "Your Forget Password OTP Is: " + x;
            var senderEmail = new MailAddress("shovon2186@gmail.com", "No_reply");
            var receiverEmail = new MailAddress(c.Email, "Receiver");
            var password = "sbfyatzqliswpvzx";
            var sub = "Recover Account";
            var body = m;
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderEmail.Address, password)
            };
            using (var mess = new MailMessage(senderEmail, receiverEmail)
            {
                Subject = sub,
                Body = body
            })
            {
                smtp.Send(mess);
            }
            
            data.Otp = Convert.ToInt32(x);
            data.Otp_expired = DateTime.Now.AddMinutes(30);

            return DataAccessFactory.UserDataAccess().Update(data);
        }

        public static bool OtpSubmit(OTPSubmit c)
        {
            var usr = DataAccessFactory.UserDataAccess().Get(c.User_id);
            if (usr == null)
            {
                return false;
            }
            if (usr.Otp == c.Otp && usr.Otp_expired >= DateTime.Now && c.Password==c.NPassword)
            {
                usr.Password = c.Password;
                
            }
            else
            {
                return false;
            }
            return DataAccessFactory.UserDataAccess().Update(usr);
        }
    }
}

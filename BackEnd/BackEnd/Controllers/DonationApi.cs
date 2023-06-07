using BackEnd.DTO;
using BackEnd.Models;
using BackEnd.RepoPattren.interfaces;
using BackEnd.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonationApi : ControllerBase
    {
        private IPayment _payment;
        private readonly IuserClass _user;

        public DonationApi(IPayment payment,IuserClass iuser ) { 
        
        _payment = payment;
            _user = iuser;
        }


        [HttpPost]

        public ActionResult sendDonation(newPayment newPayment)
        {
            Donation d = new Donation();

            d.PaymentDate = DateTime.Now;
            d.Amount = newPayment.amount;
            d.Month = newPayment.month;
            d.Year = newPayment.year;
            d.UserId = newPayment.userID;

            _payment.Add(d);


            

            return Ok(newPayment);
        }


        [HttpGet("getpayment/{id}")]

        public async Task< ActionResult> getby(string id)
        {
            var data = from p in _payment.Get()
                       where p.UserId == id
                       orderby p.Year,p.Month
                       select new
                       {
                           month = p.Month,
                           year = p.Year,
                           amount = p.Amount
                       };

            return Ok(data);
        }


        [HttpGet("{id}")]

        public ActionResult DonationOtp(string id)
        {
            var ob = _user.Get().FirstOrDefault(x => x.UserId == id);

            var otp = id.Substring(2) + "12";
            string body = "payment Otp ="+ otp;
            string sub = "Payment";
            EmailServices.sendEmailUserCre(ob.Email, body, sub);
            var OT = new
            {
                otp = otp
            };
            return Ok(OT);

        }



    }
}

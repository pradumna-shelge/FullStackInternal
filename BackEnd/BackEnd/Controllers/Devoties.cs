using BackEnd.RepoPattren.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Devoties : ControllerBase
    {
        private readonly IuserClass _user;
        private readonly IPayment _payment;

        public Devoties(IuserClass iuser, IPayment payment
           )
        {
            _user = iuser;
            _payment = payment;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var year = DateTime.Now.Year;
            var month = DateTime.Now.Month;
            var users = (from d in _payment.Get().ToList()
                        join u in _user.Get().ToList() on d.UserId equals u.UserId
                        where d.Year != year || d.Month != month
                        select new
                        {
                            name = u.FirstName + " " + u.MiddleName + " " + u.LastName,
                            id = u.UserId,
                            email = u.Email,
                            lastAmount = d.Amount,
                            lastDate = d.Year + " " + d.Month
                        }).Distinct();

            return Ok(users);
                       


        }

    }
}

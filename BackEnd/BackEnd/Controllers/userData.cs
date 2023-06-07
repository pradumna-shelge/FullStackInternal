using BackEnd.DTO;
using BackEnd.Models;
using BackEnd.RepoPattren.interfaces;
using BackEnd.Services;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userData : ControllerBase
    {
        private readonly IuserClass _user;

        public userData(IuserClass iuser
           )
        {
            _user = iuser;
        }


        [HttpPost]

        public ActionResult adduser(Newuser ob)
        {


            UserDatum userData = new UserDatum
            {
                UserId = GenerateDynamicId(ob.FirstName,ob.LastName,ob.InitiationDate),
                UserPassword = ob.Email,
                FirstName = ob.FirstName,
                LastName = ob.LastName,
                Email = ob.Email,
                MiddleName = ob.MiddleName,
                FlatNumber = ob.FlatNumber,
                StateId = Convert.ToInt32(ob.StateId),
                CityId = ob.CityId,
                PinCode = ob.PinCode,
                AddressLine = ob.AddressLine,
                RoleId = 2,
                InitiationDate = ob.InitiationDate,
                PhotoUrl = ob.PhotoURL

            };


            _user.Add(userData);

          
            string body = $"username: {userData.UserId} \n password:{userData.UserPassword}";
            string sub = "Welcome ";
            EmailServices.sendEmailUserCre(ob.Email,body,sub);

            return Ok(userData);

        }

       

        [HttpGet]

        public ActionResult users() { 
        

         var data =    from ob in _user.Get()
            where ob.RoleId == 2
            select new
            {

                UserId = ob.UserId,
                FirstName = ob.FirstName,
                LastName = ob.LastName,
                Email = ob.Email,
                MiddleName = ob.MiddleName,
                FlatNumber = ob.FlatNumber,
                StateId = Convert.ToInt32(ob.StateId),
                CityId = ob.CityId,
                PinCode = ob.PinCode,
                AddressLine = ob.AddressLine,
                InitiationDate = ob.InitiationDate,
                
            };


            return Ok(data);






        
        }


        [HttpDelete("{id}")]

        public ActionResult Delete(string id)
        {

            var ob  = _user.Get().FirstOrDefault(x=>x.UserId == id);

            if(ob == null)
            {
                return BadRequest();
            }
            _user.Delete(ob);


            return Ok(ob);
        }

        private string GenerateDynamicId(string firstName, string lastName, DateTime initiationDate)
        {
            int year = initiationDate.Year;
            string firstTwoLettersOfFirstName = firstName.Substring(0, Math.Min(firstName.Length, 2)).ToUpper();
            string firstTwoLettersOfLastName = lastName.Substring(0, Math.Min(lastName.Length, 2)).ToUpper();
            int month = initiationDate.Month;

            string dynamicId = $"{year}-{firstTwoLettersOfFirstName}{firstTwoLettersOfLastName}-{month}";

            return dynamicId;
        }



        [HttpGet("{id}")]

        public ActionResult Get(string id)
        {

            var ob  = _user.Get().FirstOrDefault(_x => _x.UserId == id);
            if(ob == null)
            {
                return BadRequest();
            }

            var data = new
            {
                UserId = ob.UserId,
                FirstName = ob.FirstName,
                LastName = ob.LastName,
                Email = ob.Email,
                MiddleName = ob.MiddleName,
                FlatNumber = ob.FlatNumber,
                StateId = Convert.ToInt32(ob.StateId),
                CityId = ob.CityId,
                PinCode = ob.PinCode,
                AddressLine = ob.AddressLine,
                InitiationDate = ob.InitiationDate,
            };


            return Ok(data);

        }

    }
}

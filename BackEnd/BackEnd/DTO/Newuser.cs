using System.ComponentModel.DataAnnotations;

namespace BackEnd.DTO
{
    public class Newuser
    {

        public string FirstName { get; set; }

        public string MiddleName { get; set; }


        public string LastName { get; set; }

        public string PhotoURL { get; set; }

        public string FlatNumber { get; set; }

        public string AddressLine { get; set; }


        public int StateId { get; set; }

        public int CityId { get; set; }

        public string PinCode { get; set; }

  
        public string Email { get; set; }

        public DateTime InitiationDate { get; set; }

    }
}

using BackEnd.Models;
using BackEnd.RepoPattren.interfaces;

namespace BackEnd.RepoPattren.Classes
{
    public class UserClass : Genric<UserDatum>, IuserClass
    {
        public UserClass(DonationSystemContext context) : base(context)
        {
        }
    }
}

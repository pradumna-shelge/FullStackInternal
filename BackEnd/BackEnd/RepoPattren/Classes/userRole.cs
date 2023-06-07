using BackEnd.Models;
using BackEnd.RepoPattren.interfaces;

namespace BackEnd.RepoPattren.Classes
{
    public class userRole : Genric<Role>, IuserRole
    {
        public userRole(DonationSystemContext context) : base(context)
        {
        }
    }
}

using BackEnd.Models;
using BackEnd.RepoPattren.interfaces;

namespace BackEnd.RepoPattren.Classes
{
    public class cityes : Genric<City>, Icity
    {
        public cityes(DonationSystemContext context) : base(context)
        {
        }
    }
}

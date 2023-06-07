using BackEnd.Models;
using BackEnd.RepoPattren.interfaces;

namespace BackEnd.RepoPattren.Classes
{
    public class Payment : Genric<Donation>, IPayment
    {
        public Payment(DonationSystemContext context) : base(context)
        {
        }
    }
}

using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class Donation
{
    public int PaymentId { get; set; }

    public int? Month { get; set; }

    public int? Year { get; set; }

    public DateTime? PaymentDate { get; set; }

    public decimal? Amount { get; set; }

    public string? UserId { get; set; }

    public virtual UserDatum? User { get; set; }
}

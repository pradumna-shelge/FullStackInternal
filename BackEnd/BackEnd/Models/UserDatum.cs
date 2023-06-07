using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class UserDatum
{
    public string UserId { get; set; } = null!;

    public string? UserPassword { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public string? PhotoUrl { get; set; }

    public string? FlatNumber { get; set; }

    public string? AddressLine { get; set; }

    public int? StateId { get; set; }

    public int? CityId { get; set; }

    public string? PinCode { get; set; }

    public string? Email { get; set; }

    public DateTime? InitiationDate { get; set; }

    public int? RoleId { get; set; }

    public virtual City? City { get; set; }

    public virtual Role? Role { get; set; }

    public virtual City? State { get; set; }
}

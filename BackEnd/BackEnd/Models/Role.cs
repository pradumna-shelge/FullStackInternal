using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class Role
{
    public int RoleId { get; set; }

    public string? RoleName { get; set; }

    public virtual ICollection<UserDatum> UserData { get; set; } = new List<UserDatum>();
}

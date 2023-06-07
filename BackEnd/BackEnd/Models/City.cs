using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class City
{
    public int CityId { get; set; }

    public string CityName { get; set; } = null!;

    public int? StateId { get; set; }

    public virtual ICollection<City> InverseState { get; set; } = new List<City>();

    public virtual City? State { get; set; }

    public virtual ICollection<UserDatum> UserDatumCities { get; set; } = new List<UserDatum>();

    public virtual ICollection<UserDatum> UserDatumStates { get; set; } = new List<UserDatum>();
}

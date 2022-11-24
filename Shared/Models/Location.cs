using System;
using System.Collections.Generic;

namespace OnTheTaps.Shared.Models;

public partial class Location
{
    public int LocationId { get; set; }

    public string LocationName { get; set; }

    public virtual ICollection<Establishment> Establishments { get; } = new List<Establishment>();
}

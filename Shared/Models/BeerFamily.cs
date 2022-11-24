using System;
using System.Collections.Generic;

namespace OnTheTaps.Shared.Models;

public partial class BeerFamily
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int BeerTypeId { get; set; }

    public virtual ICollection<BeerStyle> BeerStyles { get; } = new List<BeerStyle>();

    public virtual BeerType BeerType { get; set; }
}

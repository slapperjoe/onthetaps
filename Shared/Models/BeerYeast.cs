using System;
using System.Collections.Generic;

namespace OnTheTaps.Shared.Models;

public partial class BeerYeast
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string BaseColour { get; set; }

    public virtual ICollection<BeerStyle> BeerStyles { get; } = new List<BeerStyle>();
}

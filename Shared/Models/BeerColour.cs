using System;
using System.Collections.Generic;

namespace OnTheTaps.Shared.Models;

public partial class BeerColour
{
    public int Id { get; set; }

    public string Hex { get; set; }

    public virtual ICollection<BeerStyle> BeerStyleSrmhighs { get; } = new List<BeerStyle>();

    public virtual ICollection<BeerStyle> BeerStyleSrmlows { get; } = new List<BeerStyle>();
}

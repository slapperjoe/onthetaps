using System;
using System.Collections.Generic;

namespace OnTheTaps.Shared.Models;

public partial class BeerType
{
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<BeerFamily> BeerFamilies { get; } = new List<BeerFamily>();

    public virtual ICollection<BeerStyle> BeerStyles { get; } = new List<BeerStyle>();
}

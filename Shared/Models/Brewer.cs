using System;
using System.Collections.Generic;

namespace OnTheTaps.Shared.Models;

public partial class Brewer
{
    public int BrewerId { get; set; }

    public string Slug { get; set; }

    public string BrewerName { get; set; }

    public double Lat { get; set; }

    public double Long { get; set; }

    public string Type { get; set; }

    public string Location { get; set; }

    public string Country { get; set; }

    public string State { get; set; }

    public string City { get; set; }

    public string Url { get; set; }

    public virtual ICollection<Beer> Beers { get; } = new List<Beer>();
}

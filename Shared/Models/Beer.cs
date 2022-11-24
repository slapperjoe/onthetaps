using System;
using System.Collections.Generic;

namespace OnTheTaps.Shared.Models;

public partial class Beer
{
    public int Bid { get; set; }

    public string Slug { get; set; }

    public string BeerName { get; set; }

    public string BeerPic { get; set; }

    public string Style { get; set; }

    public double Abv { get; set; }

    public int BrewerId { get; set; }

    public string BaseStyle { get; set; }

    public virtual Brewer Brewer { get; set; }

    public virtual ICollection<Checkin> Checkins { get; } = new List<Checkin>();
}

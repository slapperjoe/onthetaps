using System;
using System.Collections.Generic;

namespace OnTheTaps.Shared.Models;

public partial class BeerStyle
{
    public int Id { get; set; }

    public int FamilyId { get; set; }

    public string Name { get; set; }

    public int TypeId { get; set; }

    public double Abvlow { get; set; }

    public double Abvhigh { get; set; }

    public double Ibulow { get; set; }

    public double Ibuhigh { get; set; }

    public int SrmlowId { get; set; }

    public int SrmhighId { get; set; }

    public double OrigGravLow { get; set; }

    public double OrigGravHigh { get; set; }

    public double FinalGravLow { get; set; }

    public double FinalGravHigh { get; set; }

    public int YeastId { get; set; }

    public virtual BeerFamily Family { get; set; }

    public virtual BeerColour Srmhigh { get; set; }

    public virtual BeerColour Srmlow { get; set; }

    public virtual BeerType Type { get; set; }

    public virtual BeerYeast Yeast { get; set; }
}

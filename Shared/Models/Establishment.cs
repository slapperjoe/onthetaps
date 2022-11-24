using System;
using System.Collections.Generic;

namespace OnTheTaps.Shared.Models;

public partial class Establishment
{
    public int EstablishmentId { get; set; }

    public string EstablishmentName { get; set; }

    public double Lat { get; set; }

    public double Long { get; set; }

    public DateTime? LastCheckinUpdate { get; set; }

    public int BaseZoom { get; set; }

    public int LocationId { get; set; }

    public bool MaxedCheckinHistory { get; set; }

    public virtual ICollection<Checkin> Checkins { get; } = new List<Checkin>();

    public virtual Location Location { get; set; }
}

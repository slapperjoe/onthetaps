using System;
using System.Collections.Generic;

namespace OnTheTaps.Shared.Models;

public partial class Checkin
{
    public double CheckinId { get; set; }

    public DateTime CheckinTime { get; set; }

    public int EstablishmentId { get; set; }

    public int Bid { get; set; }

    public double? Rating { get; set; }

    public virtual Beer BidNavigation { get; set; }

    public virtual Establishment Establishment { get; set; }
}

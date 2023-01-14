using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheTaps.Shared.Models.Taps
{
	public class User
	{
		public int UserId { get; set; }
		public string Name { get; set; }
		public string LoginType { get; set; }

		public int VenueId { get; set; }
		public virtual Venue Venue { get; set; }
	}

	public class Venue
	{
		public int VenueId { get; set; }
		public string Name { get; set; }
		public virtual List<Tap> Taps { get; set; }

		public virtual List<User> Users { get; set; }
	}

	public class Tap
	{
		public int TapId { get; set; }
		public string Name { get; set; }
		public string Type { get; set; }
		public string Brewer { get; set; }
		public decimal Percentage { get; set; }

		[Column(TypeName ="money")]
		public decimal SchoonerCost { get; set; }
		[Column(TypeName = "money")]
		public decimal SquealerCost { get; set; }
		[Column(TypeName = "money")]
		public decimal GrowlerCost { get; set; }
		[Column(TypeName = "bit")]
		public bool Empty { get; set; }

		public int VenueId { get; set; }
		public virtual Venue Venue { get; set; }

	}
}

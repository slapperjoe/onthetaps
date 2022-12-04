using BigBeerData.Shared.DTOs;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheTaps.Client.Types
{
	public class BeerItemDTO
	{
		public BeerItemDTO(int tap, BeerDTO beer, ElementReference loadBox)
		{
			tapNumber = tap;
			this.beer = beer;
			this.loadBox = loadBox;
		}
		public int tapNumber { get; set; }
		public BeerDTO beer { get; set; }
		public ElementReference loadBox { get; set; }
	}
}

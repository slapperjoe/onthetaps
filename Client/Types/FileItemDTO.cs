using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheTaps.Client.Types
{
	public class FileItemDTO
	{
		public FileItemDTO(int tap, InputFileChangeEventArgs file, ElementReference loadBox)
		{
			tapNumber = tap;
			this.file = file;
			this.loadBox = loadBox;
		}
		public int tapNumber { get; set; }
		public InputFileChangeEventArgs file { get; set; }
		public ElementReference loadBox { get; set; }
	}
}

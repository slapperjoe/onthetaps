using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace OnTheTaps.Client.Types
{
	public class FileItemDTO
	{
		const int maxFileSize = 10240000;

		public FileItemDTO(int tap, InputFileChangeEventArgs file, ElementReference loadBox)
		{
			tapNumber = tap;
			this.file = file;
			this.loadBox = loadBox;
		}
		public int tapNumber { get; set; }
		public InputFileChangeEventArgs file { get; set; }
		public ElementReference loadBox { get; set; }

		public string fileName => tapNumber + file.File.Name.Substring(file.File.Name.LastIndexOf('.'));

		public StreamContent GetFileStream()
		{
			var fileContent = new StreamContent(file.File.OpenReadStream(maxFileSize));
			fileContent.Headers.ContentType = new MediaTypeHeaderValue(file.File.ContentType);
			return fileContent;
		}
	}
}

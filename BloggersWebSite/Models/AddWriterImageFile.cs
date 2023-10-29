using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BloggersWebSite.Models
{
    public class AddWriterImageFile
    {
		[Key]
		public int WriterId { get; set; }
		public string WriterName { get; set; }
		public string WriterAbout { get; set; }
		public IFormFile WriterImage { get; set; }
		public string WriterMail { get; set; }
		public string WriterPassword { get; set; }
		public bool WriterStatus { get; set; }
		public string Location { get; set; }
	}
}

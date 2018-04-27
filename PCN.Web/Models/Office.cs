using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PCN.Web.Models
{
	public class Office
	{
		public long Id { get; set; }
		[MaxLength(100)]
		[Required]
		[Index(IsUnique =true)]
		public string Name { get; set; }
	}
}
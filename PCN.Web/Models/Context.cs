namespace PCN.Web.Models
{
	using System;
	using System.Data.Entity;
	using System.Linq;

	public class Context : DbContext
	{
		public Context()
			: base("name=Context")
		{
		}

		public virtual DbSet<Office>  Offices{ get; set; }
	}

}
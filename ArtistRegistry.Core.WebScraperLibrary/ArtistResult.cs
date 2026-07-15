using ArtistRegistry.Standard.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtistRegistry.Core.WebScraperLibrary
{
	public class ArtistResult
	{
		public string Title { get; set; }
		public string FamilyName { get; set; }
		public string GivenName { get; set; }
		public string FullName { get; set; }
		public string Excerpt { get; set; }
		public string Slug { get; set; }

		public ArtistResult()
		{
			Title = "";
			FamilyName = "";
			GivenName = "";
			FullName = "";
			Excerpt = "";
			Slug = "";
		}


		public Contact BuildContact(string url)
		{
			Contact c = new Contact();

			c.FirstName = GivenName;
			c.LastName = FamilyName;
			c.OhioArtistRegistry = url;
			c.StatusId = 1;
			c.InitialSource = "Ohio Artist Registry";
			c.Country = "US";
			c.State = "OH";


			return c;
		}


	}
}

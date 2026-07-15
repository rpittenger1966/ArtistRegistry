using System;
using System.Collections.Generic;
using System.Text;

namespace ArtistRegistry.Standard.Data
{
	public partial class FirstLetter
	{
		
		public string UrlCalculated
		{
			get
			{
				return $"https://oovar.ohioartscouncil.org/char/{FirstLetterId.ToLower()}/";
			}
		}

	}  // end of class
}

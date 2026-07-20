using System;
using System.Collections.Generic;
using System.Text;

namespace ArtistRegistry.Standard.Data
{
	public partial class GalleryExhibition
	{
		public string EntryDealineString
		{
			get
			{
				if (EntryDeadline is null) return "";
				return EntryDeadline.Value.ToShortDateString();
			}
			set
			{
				if (value == "")
				{
					EntryDeadline = null;
					return;
				}
				DateTime dt;
				if (DateTime.TryParse(value, out dt))
				{
					EntryDeadline = dt;
				}
				else
				{
					EntryDeadline = null;
				}

			}
		}

	}
}
